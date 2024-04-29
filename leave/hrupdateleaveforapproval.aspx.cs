using Common.Console;
using Common.Data;
using Common.Date;
using Common.Encode;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leave_hrupdateleaveforapproval : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    DataSet _ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr;
    public int i, error;
    //========================== Created By Ramu Nunna on 9-Dec-2014 ==================================================//
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                //bindemployee_detail();
            }


        }
        else
        {
           Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    //#region Bind The Employee Details
    //protected void bindemployee_detail()
    //{
    //    var activity = new DataActivity();
    //    try
    //    {
    //        SqlParameter[] sqlparm = new SqlParameter[1];
    //        Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
    //        SqlConnection connection = activity.OpenConnection();
    //        _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
    //        if (_ds.Tables[0].Rows.Count < 1)
    //            return;
    //        lbl_emp_name.Text = _ds.Tables[0].Rows[0]["name"].ToString();
    //        lbl_emp_code.Text = _ds.Tables[0].Rows[0]["empcode"].ToString();
    //        lbl_gender.Text = _ds.Tables[0].Rows[0]["emp_gender"].ToString();
    //        HiddenField_gender.Value = _ds.Tables[0].Rows[0]["emp_gender"].ToString();
    //        lbl_emp_status.Text = _ds.Tables[0].Rows[0]["status"].ToString();
    //        lbl_department.Text = _ds.Tables[0].Rows[0]["department_name"].ToString();
    //        lbl_branch.Text = _ds.Tables[0].Rows[0]["branch_name"].ToString();
    //        lbl_designation.Text = _ds.Tables[0].Rows[0]["designationname"].ToString();
    //        lbl_doj.Text = Utility.DateFormat(_ds.Tables[0].Rows[0]["emp_doj"].ToString())
    //            .ToString("dd - MMM - yyyy");
    //        hdn_branchid.Value = _ds.Tables[0].Rows[0]["branch_id"].ToString();
    //        adjustgrid.DataSource = null;
    //        adjustgrid.DataBind();

    //    }
    //    catch (Exception ex)
    //    {

    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show(
    //            "Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }



    //}
    //#endregion
    #region Leave Type Select Index Changed Event
    protected void dd_typeleave_DataBound(object sender, EventArgs e)
    {
        dd_typeleave.Items.Insert(0, new ListItem("--Select leave--", "100"));
    }
    protected void dd_typeleave_SelectedIndexChanged(object sender, EventArgs e)
    {

        var activity = new DataActivity();
        try
        {
            if (dd_typeleave.SelectedIndex == 0)
            {
                div.Visible = false;
                divhalf.Visible = false;
                divfull.Visible = true;
                div_Furnelleave.Visible = false;
            }

            btn_submit.Enabled = false;
            txt_sdate.Text = "";
            txt_edate.Text = "";
            txt_nod.Text = "0";
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 50, dd_typeleave.SelectedValue);

            if (dd_typeleave.SelectedValue == ConfigurationManager.AppSettings["FL"])
            {
                div_Furnelleave.Visible = true;

            }
            else
            {
                div_Furnelleave.Visible = false;
            }
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleavetype",
                sqlparm);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            if (Convert.ToBoolean(_ds.Tables[0].Rows[0]["halfday_leave_applicable"]))
            {
                div.Visible = true;
                divhalf.Visible = false;
                divfull.Visible = true;
                rdofullday.Checked = true;
                rdohalfday.Checked = false;


            }
            else
            {
                div.Visible = false;
                divhalf.Visible = false;
                divfull.Visible = true;

            }

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }



    }
    #endregion
    #region Calculation of No of Days click Event
    protected void btn_calc_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            if (divhalf.Visible == true)
            {
                if (txt_select.Text == "")
                {
                    Output.Show("Please select date.");
                    txt_sdate.Focus();
                    return;
                }

            }
            if (validate_applydate())
            {
                validateapplyleave();
            }
        }
    }
    #endregion
    #region Validate the Apply Leave Depending upon Leave Rule
    protected Boolean validateapplyleave()
    {
        SqlParameter[] sqlparm = new SqlParameter[2];

        Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, txt_employee.Text);
        Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 0, dd_typeleave.SelectedValue);

        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleavetype",
                sqlparm);

            //if (!valdiate_leave(_ds))
            //{
            //    txt_nod.Text = "0";
            //    btn_submit.Enabled = true;
            //    adjustgrid.DataSource = null;
            //    adjustgrid.DataBind();
            //    return false;
            //}


            sqlparm = new SqlParameter[19];

            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 0, dd_typeleave.SelectedValue);


            if (divfull.Visible == true)
            {

                Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10, Utility.DateFormat(txt_sdate.Text.ToString(CultureInfo.InvariantCulture)).ToString());
                Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, Utility.DateFormat(txt_edate.Text.ToString(CultureInfo.InvariantCulture)).ToString());

            }
            else
            {
                Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10, Utility.DateFormat(txt_select.Text.ToString(CultureInfo.InvariantCulture)).ToString());
                Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, Utility.DateFormat(txt_select.Text.ToString(CultureInfo.InvariantCulture)).ToString());

            }
            string holidayallowed = _ds.Tables[0].Rows[0]["holidays_counted_asleave"].ToString();
            Output.AssignParameter(sqlparm, 4, "@branch", "Int", 10, Session["branch"].ToString());
            Output.AssignParameter(sqlparm, 5, "@holidayallowed", "String", 10, holidayallowed.ToString());
            Output.AssignParameter(sqlparm, 6, "@maxday", "Decimal", 4, _ds.Tables[0].Rows[0]["maximum_no_days"].ToString());
            Output.AssignParameter(sqlparm, 7, "@minday", "Decimal", 4, _ds.Tables[0].Rows[0]["minimum_no_days"].ToString());

            if (divfull.Visible == true)
                Output.AssignParameter(sqlparm, 8, "@halfday", "String", 10, "false");
            else
                Output.AssignParameter(sqlparm, 8, "@halfday", "String", 10, "true");

            Output.AssignParameter(sqlparm, 9, "@leave", "String", 100, dd_typeleave.SelectedItem.Text);
            string weekoff = _ds.Tables[0].Rows[0]["weekly_off"].ToString();
            Output.AssignParameter(sqlparm, 10, "@weeklyoff", "String", 10, weekoff.ToString());
            Output.AssignParameter(sqlparm, 11, "@id", "Int", 4, "0");
            Output.AssignParameter(sqlparm, 12, "@companyid", "Int", 4, _companyId.ToString());
            string esi = _ds.Tables[0].Rows[0]["esi_applicable"].ToString();
            Output.AssignParameter(sqlparm, 13, "@esiapplicable", "String", 100, esi.ToString());
            Output.AssignParameter(sqlparm, 14, "@esicutofamount", "Decimal", 40, _ds.Tables[0].Rows[0]["esi_cutoff_amount"].ToString());
            string lsatyearapp = _ds.Tables[0].Rows[0]["is_last_year_working_days"].ToString();
            Output.AssignParameter(sqlparm, 15, "@islastyearworkdays", "String", 40, lsatyearapp.ToString());
            Output.AssignParameter(sqlparm, 16, "@lastyearworkdays", "Decimal", 40, _ds.Tables[0].Rows[0]["last_year_working_days"].ToString());
            Output.AssignParameter(sqlparm, 17, "@policyid", "Decimal", 40, _ds.Tables[0].Rows[0]["policyid"].ToString());
            decimal grosssalary = 0;
            Output.AssignParameter(sqlparm, 18, "@grosssalary", "Decimal", 40, grosssalary.ToString());
            DataSet ds10 = new DataSet();
            ds10 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleave",
                sqlparm);
            if (ds10.Tables[0].Rows[0][0].ToString() == "0")
            {
                btn_submit.Enabled = false;
                txt_nod.Text = "0";
                adjustgrid.DataSource = null;
                adjustgrid.DataBind();
                Output.Show(ds10.Tables[0].Rows[0][1].ToString());
                //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx",
                //    "<script> alert('" + ds10.Tables[0].Rows[0][1] + "')</script>", false);

                return false;
            }
            else if (ds10.Tables[0].Rows[0][0].ToString() == "1")
            {
                txt_nod.Text = ds10.Tables[0].Rows[0]["no_of_days"].ToString();
                hidden_leave.Value = ds10.Tables[0].Rows[0]["no_of_days"].ToString();
                adjustgrid.DataSource = ds10.Tables[1];
                adjustgrid.DataBind();
            }
            else if (ds10.Tables[0].Rows[0][0].ToString() == "2")
            {
                Output.Show(ds10.Tables[0].Rows[0]["message"].ToString());
                txt_nod.Text = ds10.Tables[0].Rows[0]["no_of_days"].ToString();
                hidden_leave.Value = ds10.Tables[0].Rows[0]["leave"].ToString();
                adjustgrid.DataSource = ds10.Tables[1];
                adjustgrid.DataBind();
            }

            var sqlparm30 = new SqlParameter[2];
            Output.AssignParameter(sqlparm30, 0, "@empcode", "String", 100, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparm30, 1, "@leaveid", "Int", 4, dd_typeleave.SelectedValue);
            DataSet ds30 = new DataSet();
            ds30 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleavetype",
                sqlparm30);


            if (Convert.ToDecimal(ds30.Tables[0].Rows[0]["document_days"]) <
                Convert.ToDecimal(ds10.Tables[0].Rows[0]["no_of_days"].ToString()) &&
                Convert.ToBoolean(ds30.Tables[0].Rows[0]["document_required"].ToString()) == true)
            {

                upload_attach.Enabled = true;
            }
            else
            {

                upload_attach.Enabled = false;
            }
            btn_submit.Enabled = true;

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return true;
    }
    protected Boolean valdiate_leave(DataSet ds20)
    {
        //int i = 0;
        if (ds20.Tables[0].Rows.Count < 1)
        {
            Output.Show("Leave Rule not defined,contact administrator");

            return false;
        }

        DateTime sdate;
        if (divfull.Visible == true)
            sdate = Utility.DateFormat(txt_sdate.Text);
        else
            sdate = Utility.DateFormat(txt_select.Text);

        TimeSpan ts = sdate - DateTime.Now;

        if (Convert.ToInt16(ts.TotalDays) >= 0)
        {
            if (Convert.ToInt16(ds20.Tables[0].Rows[0]["days_before_leaveapply"]) >
                Convert.ToInt16(Math.Abs(ts.TotalDays)))
            {
                Output.Show(string.Format("You can only apply leave before  {0} days", _ds.Tables[0].Rows[0]["days_before_leaveapply"]));

                return false;
            }
        }
        else
        {
            if (!Convert.ToBoolean(ds20.Tables[0].Rows[0]["backdate_leave_applicable"]))
            {
                if (sdate <= DateTime.Today)
                {
                    Output.Show("Back Date leave applying not allowed for " + dd_typeleave.SelectedItem.Text);

                    return false;
                }
            }
            else
            {

                if (Convert.ToInt16(ds20.Tables[0].Rows[0]["backdate_howmany_days"]) <
                    Convert.ToInt16(Math.Abs(ts.TotalDays)))
                {
                    Output.Show("Maximum back day leave allowed is  " + _ds.Tables[0].Rows[0]["backdate_howmany_days"]);

                    return false;
                }
            }
        }

        bool docrequired = Convert.ToBoolean(ds20.Tables[0].Rows[0]["document_required"].ToString());
        return true;
    }
    protected Boolean validate_applydate()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, txt_employee.Text.Trim());
            if (divfull.Visible == true)
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, txt_sdate.Text);
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, txt_edate.Text);

            }
            else
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, txt_select.Text);
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, txt_select.Text);

            }
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                txt_nod.Text = "0";
                adjustgrid.DataSource = null;
                adjustgrid.DataBind();
                Output.Show("You have already applied leave during this span! Please check application status");
                return false;
            }
            else
            {
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    txt_nod.Text = "0";
                    adjustgrid.DataSource = null;
                    adjustgrid.DataBind();
                    Output.Show("You have already applied for Compoff during this span! Please check application status");
                    return false;
                }
                else
                {
                    if (_ds.Tables[2].Rows.Count > 0)
                    {
                        txt_nod.Text = "0";
                        adjustgrid.DataSource = null;
                        adjustgrid.DataBind();
                        Output.Show("You have already applied for OD during this span! Please check application status");
                        return false;
                    }
                    else
                    {
                        if (_ds.Tables[3].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Output.Show("Your leave profile is not created! Please contact your Manager");
                            return false;
                        }
                    }
                }

            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return true;
    }
    protected Boolean validate_dutyroster()
    {
        if (divfull.Visible == true)
        {
            DateTime ts1 = Convert.ToDateTime(txt_edate.Text);
            DateTime ts2 = Convert.ToDateTime(txt_sdate.Text);

            TimeSpan ts = ts1 - ts2;

            if (ts.Days < 0)
            {
                adjustgrid.DataSource = null;
                adjustgrid.DataBind();
                txt_nod.Text = "0";

                Output.Show("End date should be greater than start date.");
                return false;
            }

        }

        //-----------------validate---cant apply for back year---------------------

        DateTime dt = new DateTime();

        if (divfull.Visible == true)
            dt = Convert.ToDateTime(txt_sdate.Text);
        else
            dt = Convert.ToDateTime(txt_select.Text);



        //-----------------validate---work roster creation---------------------------------

        DataSet dsdr = new DataSet();

        SqlParameter[] sqlpar = new SqlParameter[3];

        Output.AssignParameter(sqlpar, 1, "@empcode", "String", 10, txt_employee.Text.Trim().ToString());
        if (divfull.Visible == true)
        {
            Output.AssignParameter(sqlpar, 1, "@fromdate", "String", 10, txt_sdate.Text);
            Output.AssignParameter(sqlpar, 2, "@todate", "String", 10, txt_edate.Text);

        }
        else
        {
            Output.AssignParameter(sqlpar, 1, "@fromdate", "String", 10, txt_select.Text);
            Output.AssignParameter(sqlpar, 2, "@todate", "String", 10, txt_select.Text);

        }
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            dsdr = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
                "sp_leave_validate_leave_dutyroster", sqlpar);


            if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) > 0)
            {
                if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) !=
                    Convert.ToInt32(dsdr.Tables[1].Rows[0]["applieddays"].ToString()))
                {
                    Output.Show("Your work roster is not created for this date span.Please contact your Manager.");
                    return false;
                }
            }
            else
            {
                Output.Show("Your work roster is not created for this date span.Please contact your Manager.");
                return false;
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

        return true;


    }
    #endregion
    #region Other Events
    protected void opt_first_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void opt_second_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btn_draftl_Click(object sender, EventArgs e)
    {

    }
    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;

        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;

        }
    }
    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdohalfday.Checked == true)
        {
            divhalf.Visible = true;
            divfull.Visible = false;

        }
        else
        {
            divhalf.Visible = false;
            divfull.Visible = true;

        }
    }
    protected void approvergrid_PreRender(object sender, EventArgs e)
    {
        if (approvergrid.Rows.Count > 0)
            approvergrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void adjustgrid_PreRender(object sender, EventArgs e)
    {
        if (adjustgrid.Rows.Count > 0)
            adjustgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    #endregion
    #region Submit click event
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        SqlTransaction transaction = null;
        try
        {

            int error = 0;
            Page.Validate("calculate");
            Page.Validate("all");
            if (!Page.IsValid)
                return;
            if (!validateapplyleave())
                return;
            if (txt_nod.Text == "0")
                return;

            btn_submit.Enabled = false;
            ArrayList list = new ArrayList();
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            int leaveid = Insertapplyleave(1, connection, transaction);
            Insertadjustment(leaveid, connection, transaction);
            updatependingleave(leaveid, connection, transaction);
            //   updateleaveapplication(6, 1, leaveid, connection, transaction);
            // updatebackmonth(leaveid, connection, transaction);
            transaction.Commit();

            list.Add("Leave application applied for approval successfully.");
            error++;

            if (error > 0)
            {
                //  Mailtoapprover(list, leaveid, "l");
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {
                    str = str + list[i];
                    str = str + "\\n";
                }
                reset();
                Output.Show(str);
            }

            btn_submit.Enabled = true;
            lslink.Visible = false;
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Insertion Leave Details
    protected int Insertapplyleave(int status, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] parm = new SqlParameter[19];
        int flag = 0;
        Output.AssignParameter(parm, 0, "@empcode", "String", 50, txt_employee.Text.Trim().ToString());
        Output.AssignParameter(parm, 1, "@leaveid", "Int", 10, dd_typeleave.SelectedValue);
        if (divfull.Visible == true)
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "1");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, Utility.DateFormat(txt_sdate.Text).ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, Utility.DateFormat(txt_edate.Text).ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 6, "@half", "String", 10, "");
        }
        else
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "0");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, "");
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, Utility.DateFormat(txt_select.Text).ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 6, "@half", "String", 10, opt_first.Checked.ToString());

        }

        Output.AssignParameter(parm, 7, "@no_of_days", "Decimal", 100, txt_nod.Text);
        Output.AssignParameter(parm, 8, "@reason", "String", 100, txt_reason.Text);
        if (upload_attach.HasFile)
        {
            string filename;
            filename = System.IO.Path.GetFileName(upload_attach.PostedFile.FileName.ToString());
            if (filename != "")
            {
                upload_attach.PostedFile.SaveAs("upload/" + filename);
                if (prvimg.Value != "")
                    System.IO.File.Delete("upload/" + prvimg.Value);
            }
            else
            {
                filename = prvimg.Value;
            }

            Output.AssignParameter(parm, 9, "@file_path", "Decimal", 100, filename);
        }
        else Output.AssignParameter(parm, 9, "@file_path", "Decimal", 100, "");
        Output.AssignParameter(parm, 10, "@leave_adjusted", "String", 100, (adjustgrid.Rows.Count > 1) ? "1" : "0");
        Output.AssignParameter(parm, 11, "@approvel_status", "String", 100, "0");
        Output.AssignParameter(parm, 12, "@leave_status", "String", 100, status.ToString(CultureInfo.InvariantCulture));
        if (txt_comment.Text != "")
        {
            txt_comment.Text = "<h6><b>Comments added by " + Session["name"] + " on " + DateTime.Now +
                               " :</b><br>" + txt_comment.Text + "</h6>";
        }
        Output.AssignParameter(parm, 13, "@comments", "String", 2000, txt_comment.Text);
        Output.AssignParameter(parm, 14, "@createdby", "String", 100, _userCode);
        Output.AssignParameter(parm, 15, "@createddate", "DateTime", 100, DateTime.Now.ToString());
        Output.AssignParameter(parm, 16, "@modifiedby", "String", 100, _userCode);
        if (div_Furnelleave.Visible == true)
        {
            Output.AssignParameter(parm, 17, "@relation", "String", 100, ddl_relation.SelectedValue);

        }
        else
        {
            Output.AssignParameter(parm, 17, "@relation", "String", 100, "");
        }
        Output.AssignParameter(parm, 18, "@companyid", "Int", 50, _companyId);

        flag = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "sp_leave_applyleave", parm));


        return flag;

    }
    #endregion
    #region Insertion Leave Adjustment Details
    protected void Insertadjustment(int applyleaveid, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] parm = new SqlParameter[6];
        int flag = 0;
        for (int i = 0; adjustgrid.Rows.Count > i; i++)
        {
            Output.AssignParameter(parm, 0, "@apply_leave_id", "Int", 4, applyleaveid.ToString());
            var dataKey = adjustgrid.DataKeys[i];
            if (dataKey != null)
                Output.AssignParameter(parm, 1, "@leaveid", "Int", 20, dataKey.Value.ToString());
            Output.AssignParameter(parm, 2, "@days", "Decimal", 20,
                ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l3")).Text);
            Output.AssignParameter(parm, 3, "@status", "String", 20,
                ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l4")).Text);
            Output.AssignParameter(parm, 4, "@leavename", "String", 40,
                ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l2")).Text);
            Output.AssignParameter(parm, 5, "@companyid", "Int", 10, _companyId.ToString());
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_saveleaveadjustment", parm);
        }



    }
    #endregion
    #region Update leave Application

    protected void updateleaveapplication(int leavestatus, int status, int leaveid, SqlConnection connection, SqlTransaction transaction)
    {

        int approverstatus = 0;
        sqlstr = "SELECT approverpriority FROM tbl_leave_employee_hierarchy WHERE hr=1 AND employeecode=@empcode ORDER BY 1 DESC";
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, txt_employee.Text.Trim().ToString());
        approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.Text, transaction, sqlstr, sqlparm));

        sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,status=@status,modifiedby=@modifiedby,modifieddate=getdate(),approvel_status=@approvel_status where id=@applyleaveid";
        sqlparm = new SqlParameter[6];

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, (txt_comment.Text != "" ? "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>" : ""));
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 50, leaveid.ToString());
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm, 4, "@approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm, 5, "@status", "Int", 50, status.ToString());

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparm);

    }

    protected void updatependingleave(int applyleaveid, SqlConnection connection, SqlTransaction transaction)
    {
        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + applyleaveid;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        for (int i = 0; adjustgrid.Rows.Count > i; i++)
        {
            SqlParameter[] sqlparm121 = new SqlParameter[7];

            Output.AssignParameter(sqlparm121, 0, "@apply_leave_id", "Int", 50, applyleaveid.ToString());
            Output.AssignParameter(sqlparm121, 1, "@leaveid", "Int", 50, adjustgrid.DataKeys[i].Value.ToString());
            Output.AssignParameter(sqlparm121, 2, "@days", "Decimal", 50, ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l3")).Text);
            Output.AssignParameter(sqlparm121, 3, "@status", "String", 50, ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l4")).Text);
            Output.AssignParameter(sqlparm121, 4, "@leavename", "String", 50, ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l2")).Text);
            Output.AssignParameter(sqlparm121, 5, "@empcode", "String", 50, txt_employee.Text.Trim().ToString());
            Output.AssignParameter(sqlparm121, 6, "@companyid", "Int", 50, _companyId.ToString());

            int k = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_leave_saveleaveadjustment_pending]", sqlparm121);
        }

    }

    protected void updatebackmonth(int leaveid1, SqlConnection connection, SqlTransaction transaction)
    {
        DateTime fromdate, todate;
        string empcode;
        string displayleave;
        string displayleavename;
        int leavemode;
        int leaveid;
        DataSet ds2;
        string str1 = @"SELECT empcode, leavemode, leaveid,(CASE WHEN fromdate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), fromdate, 101) END) fromdate,
(CASE WHEN todate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), todate, 101) END) todate,
(CASE WHEN hdate= '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), hdate, 101) END) hdate FROM tbl_leave_apply_leave WHERE id=" + leaveid1;
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, str1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"]);
            leaveid = Convert.ToInt32(ds.Tables[0].Rows[0]["leaveid"]);
            if (leavemode == 0)
            {
                fromdate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString());
                todate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString());
            }
            else
            {
                fromdate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["fromdate"].ToString());
                todate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["todate"].ToString());
            }
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();

            if (fromdate.Month != DateTime.Now.Month)
            {
                string str2 = "SELECT leaveid, displayleave FROM tbl_leave_createleave WHERE leaveid=" + leaveid;
                ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, str2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    displayleave = ds2.Tables[0].Rows[0]["displayleave"].ToString();
                    if (leavemode == 0)
                    {
                        displayleavename = displayleave + "(HF)";
                    }
                    else
                    {
                        displayleavename = displayleave;
                    }


                    string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='" + displayleavename + "', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                    SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, str4);

                }
            }
        }
    }


    #endregion
    #region Send  Mails to Approvers and Hand Request
    private void mailtohandoverrequest(ArrayList list)
    {
        var activity = new DataActivity();
        try
        {
            string sqlstr = @"select empcode,official_email_id,isnull(emp_fname,'')+' ' +isnull(emp_m_name,'')+' ' +isnull(emp_l_name,'') as empname from tbl_employee_details ed inner join tbl_employee_job_details ej on ej.emp_ref_no=ed.emp_ref_no where  empcode='" +
                txt_employee.Text + "'";
            SqlConnection connection = activity.OpenConnection();
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
                string fromPwd = ConfigurationManager.AppSettings["pwd"];
                string fromName = ConfigurationManager.AppSettings["fromName"];
                string smtp = ConfigurationManager.AppSettings["smtp"];
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"];
                string subject = "Work Handover Request Application ";

                string bodyContent = "";

                if (divfull.Visible == true)
                    bodyContent = "A new hand over request has been submitted by employee " + Session["name"] +
                                  " from " + txt_sdate.Text + " to " + txt_edate.Text + ".";
                else
                    bodyContent = "A new hand over request has been submitted by employee " + Session["name"] +
                                  " for the date " + txt_select.Text + ".";

                string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(),
                    bodyContent);

                if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
                {
                    try
                    {
                        Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName,
                            ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp,
                            emailLogo);
                    }
                    catch
                    {
                        list.Add("Hand over request mail is not delivered to the employee: " +
                                 ds1.Tables[0].Rows[0]["empname"] + ". Due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Hand over request mail is not delivered to the employee: " +
                             ds1.Tables[0].Rows[0]["empname"] + ". Email id does not exists.");
                }
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    private void Mailtoapprover(ArrayList list, int leaveid, string type)
    {
        // Getting the email details
        string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
        string fromPwd = ConfigurationManager.AppSettings["pwd"];
        string fromName = ConfigurationManager.AppSettings["fromName"];
        string smtp = ConfigurationManager.AppSettings["smtp"];
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"];
        string subject = "Leave Application for Approval";
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
            Output.AssignParameter(sqlparm, 1, "@type", "Int", 20, type.ToString());


            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
                "sp_leave_fetchmaildetail_employee", sqlparm);

            if (ds.Tables[0].Rows.Count > 0)
            {
                int i = ds.Tables[0].Rows.Count;
                int j = 0;

                while (i != 0)
                {

                    QueryString q = new QueryString();
                    string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}",
                        ds.Tables[0].Rows[j]["id"], ds.Tables[0].Rows[j]["empcode"],
                        ds.Tables[0].Rows[j]["approvercode"], "LA");
                    q.EncodePairs(pairs);

                    string url =
                        "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" +
                        ConfigurationManager.AppSettings["url"] + "?m=" + pairs + "' >Approve</a>";
                    string url1 =
                        "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" +
                        ConfigurationManager.AppSettings["url"] + "?m=" + pairs + "'>Reject</a>";
                    string bodyContent;
                    if (divfull.Visible == true)
                        bodyContent = "A new leave request has been submitted by employee " + Session["name"] +
                                      " from " + txt_sdate.Text + " to " + txt_edate.Text +
                                      ". <br/><br/>  <br/><br/>" + url + "&nbsp;&nbsp;&nbsp;" + url1;
                    else
                        bodyContent = "A new leave request has been submitted by employee " + Session["name"] +
                                      " for the date " + txt_select.Text + ". <br/><br/>  <br/><br/>" + url +
                                      "&nbsp;&nbsp;&nbsp;" + url1;

                    string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(),
                        bodyContent);

                    if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
                    {
                        try
                        {
                            Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName,
                                ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody,
                                smtp, emailLogo);
                        }
                        catch
                        {
                            list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"] +
                                     " due to some technical problem.");
                        }
                    }
                    else
                    {
                        list.Add("Email is does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"]);
                    }

                    i--;
                    j++;
                }
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    #endregion
    #region Reset Details
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
        //upload_attach.PostedFile = "";
    }
    protected void reset()
    {
        btn_submit.Enabled = false;
        divhalf.Visible = false;
        divfull.Visible = true;
        upload_attach.Enabled = false;
        divfull.Visible = true;
        divhalf.Visible = false;

        adjustgrid.DataSource = null;
        adjustgrid.DataBind();

        txt_edate.Text = "";
        txt_sdate.Text = "";
        txt_select.Text = "";
        txt_reason.Text = "";
        txt_nod.Text = "0";
        txt_comment.Text = "";
        dd_typeleave.SelectedIndex = -1;
    }
    #endregion

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        var activity = new DataActivity();

        if (!CheckGender())
            return;
        //  if (!CheckPayStructure())
        //  return;
        string Gender = "";
        hdnGender.Value = (hdnGender.Value == "Male") ? "M" : "F";
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid where elm.empcode='" + txt_employee.Text.ToString() + "' and crleave.leaveid not in (0) and ( applicable_to = 'A' or applicable_to ='" + hdnGender.Value + "' ) order by crleave.leavetype";
        _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            dd_typeleave.DataTextField = "leavetype";
            dd_typeleave.DataValueField = "leaveid";
            dd_typeleave.DataSource = _ds;
            dd_typeleave.DataBind();
        }
        if (txt_employee.Text != "")
        {
            Session["Leaveempcode"] = txt_employee.Text;
            lslink.Visible = true;
        }
        else Output.Show("Please Select Empcode");
        activity.CloseConnection();

    }

    private bool CheckPayStructure()
    {
        var activity = new DataActivity();
        try
        {
            sqlstr = @"select count(*) as paystructure from tbl_payroll_employee_paystructure where EMPCODE='" + txt_employee.Text.Trim() + "'";
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (_ds.Tables[0].Rows.Count > 0)
            {

                if (Convert.ToInt32(_ds.Tables[0].Rows[0]["paystructure"].ToString()) <= 0)
                {
                    Common.Console.Output.Show("Leave not allowed,selected Employee Paystructure is not created.");
                    return false;
                }
            }

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return true;
    }

    private bool CheckGender()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, txt_employee.Text.Trim());
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (_ds.Tables[0].Rows.Count > 0)
            {

                if (_ds.Tables[0].Rows[0]["emp_gender"].ToString() == "" || _ds.Tables[0].Rows[0]["emp_gender"].ToString() == null || _ds.Tables[0].Rows[0]["emp_gender"].ToString() == "0")
                {
                    Common.Console.Output.Show("Leave not allowed,please check gender is not configured for the employee.");
                    return false;
                }
                hdnGender.Value = _ds.Tables[0].Rows[0]["emp_gender"].ToString();

            }

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return true;
    }
}
