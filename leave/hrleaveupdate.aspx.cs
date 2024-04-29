using Common.Console;
using Common.Data;
using Common.Date;
using Common.Encode;
using Smart.HR.Common.Mail.Module;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leave_hrleaveupdate : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    DataSet _ds, ds1, ds2 = new DataSet();
    DataSet ds_3 = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable;
  
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr;
    public int i, error;
    string fromdt, todt ,half;
    string emp_name, emplcode, emplemail, empmsg,appmsg,appDLMmsg;
    private string dottedLMname = "";
    private string DottedLMemail = "";
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
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select app.app_dotted_linemanager,job.official_email_id,job.emp_fname+' ' +job.emp_m_name+' ' +job.emp_l_name as empname from tbl_intranet_employee_jobDetails job inner join tbl_employee_approvers app on job.empcode=app.app_dotted_linemanager where app.empcode='" + txt_employee.Text + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DottedLMemail = ds.Tables[0].Rows[0]["official_email_id"].ToString();
                dottedLMname = ds.Tables[0].Rows[0]["empname"].ToString();
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
        grdpaper.DataSource = null;
        grdpaper.DataBind();
        // rdosplit.Checked = false;
        Div7.Visible = false;
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
            txt_select.Text = "";
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

                //Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10, Utility.DateFormat(txt_sdate.Text.ToString(CultureInfo.InvariantCulture)).ToString());
                //Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, Utility.DateFormat(txt_edate.Text.ToString(CultureInfo.InvariantCulture)).ToString());
                Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10,txt_sdate.Text.ToString());
                Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, txt_edate.Text.ToString());

            }
            else
            {
                //Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10, Utility.DateFormat(txt_select.Text.ToString(CultureInfo.InvariantCulture)).ToString());
                //Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, Utility.DateFormat(txt_select.Text.ToString(CultureInfo.InvariantCulture)).ToString());

                Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10,txt_select.Text);
                Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, txt_select.Text);

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
        /*Datewise Code Start */
        if (divfull.Visible == true)
        {
            //var activity = new DataActivity();
            //if (txt_sdate.Text == "" || txt_edate.Text == "")
            //{
            //    Output.Show("Please select From Date//To date ");
            //    return false;
            //}
            Div7.Visible = true;

            List<DateTime> dates = new List<DateTime>();

            for (var dt = Convert.ToDateTime(txt_sdate.Text); dt <= Convert.ToDateTime(txt_edate.Text); dt = dt.AddDays(1))
            {
                SqlConnection connection = activity.OpenConnection();
                string query = "";
                string query1 = "";
                string query2 = "";
                query = "select DATEPART(DW,'" + dt + "') as date";
                _ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
                query1 = "declare @weakoffapplicble int; Set @weakoffapplicble=(Select weekly_off from tbl_leave_createdefaultrule where leaveid='" + dd_typeleave.SelectedValue + "' and status=1); declare @branch int; Set @branch=(Select branch_id from tbl_intranet_employee_jobDetails where empcode='" + _userCode + "'); select weekcode from tbl_leave_weekoff where branchid=@branch and @weakoffapplicble=1 and weekcode='" + Convert.ToInt32(_ds.Tables[0].Rows[0]["date"].ToString()) + "'";
                ds2 = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query1);
                query2 = "declare @holdayapplicable int; Set @holdayapplicable=(Select holidays_counted_asleave from tbl_leave_createdefaultrule where leaveid='" + dd_typeleave.SelectedValue + "' and status=1);declare @branch int; Set @branch=(Select branch_id from tbl_intranet_employee_jobDetails where empcode='" + _userCode + "');Select date from tbl_leave_holiday where branch_id=@branch and status=1 and @holdayapplicable=1 and date='" + Convert.ToDateTime(dt) + "'";
                ds1 = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query2);
                if (ds2.Tables[0].Rows.Count > 0)
                { }
                else
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    { }
                    else
                    { dates.Add(dt); }
                }
            }
            dtable = new DataTable();
            dtable.Columns.Add("dates", typeof(string));
            dtable.PrimaryKey = new DataColumn[] { dtable.Columns["dates"] };
            dtable.Columns.Add("daymode", typeof(string));
            dtable.Columns.Add(new DataColumn("halfdaymode", typeof(string)));

            for (int i = 0; i < dates.Count; i++)
            {
                DataRow dr;
                dr = dtable.NewRow();
                dr["dates"] = Convert.ToDateTime(dates[i]).ToString("dd-MMM-yyyy");
                dr["daymode"] = "1";
                dr["halfdaymode"] = "0";
                dtable.Rows.Add(dr);

            }
            grdpaper.DataSource = dtable;
            grdpaper.DataBind();
        }

        /*Datewise Code End */

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
            txt_nod.Text = "0.0";
            txt_sdate.Text = "";
            txt_edate.Text = "";
            txt_select.Text = "";
            grdpaper.DataSource = null;
            grdpaper.DataBind();
            Div7.Visible = true;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
            txt_nod.Text = "0.0";
            txt_sdate.Text = "";
            txt_edate.Text = "";
            txt_select.Text = "";
            grdpaper.DataSource = null;
            grdpaper.DataBind();
            Div7.Visible = false;
        }
    }
    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdohalfday.Checked == true)
        {
            divhalf.Visible = true;
            divfull.Visible = false;

            txt_sdate.Text = "";
            txt_edate.Text = "";
            txt_select.Text = "";
            grdpaper.DataSource = null;
            grdpaper.DataBind();
            Div7.Visible = false;
        }
        else
        {
            txt_sdate.Text = "";
            txt_edate.Text = "";
            txt_select.Text = "";
            txt_nod.Text = "0.0";
            divhalf.Visible = false;
            divfull.Visible = true;
            grdpaper.DataSource = null;
            grdpaper.DataBind();
            Div7.Visible = true;

        }
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
            if (txt_nod.Text == "0.0")
            {
                Common.Console.Output.Show("No. of Days should not be Zero.please check leave  application.");
                return;
            }
            btn_submit.Enabled = false;
            ArrayList list = new ArrayList();
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            int leaveid = Insertapplyleave(1, connection, transaction);
            Insertadjustment(leaveid, connection, transaction);
            InsertDatewise(connection, transaction, leaveid);
            updatependingleave(leaveid, connection, transaction);
            updateleaveapplication(6, 1, leaveid, connection, transaction);
            Approvedatewise(6, connection, transaction, leaveid);

            updatebackmonth(leaveid, connection, transaction);
            transaction.Commit();
              list.Add("Leave application applied & updated successfully.");
            error++;
           SendMail(leaveid);
          MailtodottedLM(list, leaveid);
          

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
    protected void Approvedatewise(int leavestus, SqlConnection connection, SqlTransaction transaction,int leave)
    {
        //DataSet ds1 = new DataSet();
        //sqlstr = "select * from tbl_leave_apply_leave_datewise where leaveid='" + hidd_leaveapplyid.Value + "' and leave_status=0";
        //ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);
        //if (ds1.Tables[0].Rows.Count > 1)
        //{
        SqlParameter[] sqlparm;
        string sqlstr1 = "update tbl_leave_apply_leave_datewise set leave_status=@leave_status,status=1,approvel_status=1,aproverlevel=@approver_level where leaveid=@applyleaveid";
        sqlparm = new SqlParameter[3];

        Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, leave.ToString());
        Output.AssignParameter(sqlparm, 1, "@leave_status", "Int", 50, leavestus.ToString());


        Output.AssignParameter(sqlparm, 2, "@approver_level", "Int", 50, "0");

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1, sqlparm);

        //}
    }

    #region Send  Mails to Approvers

    void SendEmail(int leaveid)
    {
        try
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestFactory();
            EmailClient client = new EmailClient(email);

            ServicePointManager.ServerCertificateValidationCallback =
           delegate(object s, X509Certificate certificate,
           X509Chain chain, SslPolicyErrors sslPolicyErrors)
           { return true; };

            client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
            client.empCode = Session["empcode"].ToString();
            client.employeeName = Session["name"].ToString().Trim();
            client.appsendername = Session["name"].ToString().Trim();
            client.requestNumber = leaveid.ToString();
            client.Send();
        }
        catch (Exception ex)
        {
            Smart.HR.Common.Console.Output.Log("During Apply Leave: " + ex.Message + ".    " + DateTime.Now);
            throw ex;
        }
    }


    private void Mail(ArrayList list, int leaveid, string type)
    {
        SendEmail(leaveid);

        var activity = new DataActivity();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 20, type.ToString());

        SqlConnection connection = activity.OpenConnection();
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        activity.CloseConnection();

        if (ds.Tables[0].Rows.Count > 0)
        {
            int n = ds.Tables[0].Rows.Count;

            for (int i = 0; i < n; i++)
            {
                if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
                {
                    EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestApprover();
                    EmailClient client = new EmailClient(email);

                    //ServicePointManager.ServerCertificateValidationCallback =
                    //delegate(object s, X509Certificate certificate,
                    //X509Chain chain, SslPolicyErrors sslPolicyErrors)
                    //{ return true; };

                    client.toEmailId = ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim();
                    client.empCode = ds.Tables[0].Rows[i]["approvercode"].ToString().Trim();
                    client.employeeName = ds.Tables[0].Rows[i]["a_name"].ToString().Trim();
                    client.appsendername = Session["name"].ToString().Trim();
                    client.requestNumber = leaveid.ToString();
                    client.Send();
                }
                else
                {
                    list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[i]["a_name"]);
                }

            }
        }
        else
        {
            throw new Exception("No approvers");

        }

    }

    #endregion
    #region Insertion Datewise Details
    protected void InsertDatewise(SqlConnection connection, SqlTransaction transaction, int applyleaveid)
    {
        SqlParameter[] parm = new SqlParameter[12];
        int flag = 0;
        if (divfull.Visible == true && divhalf.Visible == false)
        {
            for (int i = 0; grdpaper.Rows.Count > i; i++)
            {
                DropDownList Daymode = (DropDownList)grdpaper.Rows[i].Cells[0].FindControl("ddlday");
                int day = Convert.ToInt32(Daymode.SelectedValue);
                DropDownList halfday = (DropDownList)grdpaper.Rows[i].Cells[0].FindControl("ddltype");
                int half = Convert.ToInt32(halfday.SelectedValue);

                Output.AssignParameter(parm, 0, "@apply_leave_id", "Int", 4, applyleaveid.ToString());

                Output.AssignParameter(parm, 1, "@dates", "DateTime", 100,
                    ((Label)grdpaper.Rows[i].Cells[0].FindControl("Label1")).Text);
                Output.AssignParameter(parm, 2, "@Daymode", "Int", 10, day.ToString());
                Output.AssignParameter(parm, 3, "@HalfDaymode", "String", 10, half.ToString());
                Output.AssignParameter(parm, 4, "@leavemode", "Int", 4, "1");


                Output.AssignParameter(parm, 5, "@companyid", "Int", 10, _companyId);
                Output.AssignParameter(parm, 6, "@empcode", "String", 50, txt_employee.Text.ToString());

                Output.AssignParameter(parm, 7, "@status", "Int", 10, "1");
                Output.AssignParameter(parm, 8, "@leavestatus", "Int", 10, "0");
                Output.AssignParameter(parm, 9, "@Createdby", "String", 50, _userCode);
                Output.AssignParameter(parm, 10, "@no_ofdays", "Decimal", 50, txt_nod.Text);
                Output.AssignParameter(parm, 11, "@leave", "Int", 4, dd_typeleave.SelectedValue);
                //Output.AssignParameter(parm, 12, "@policyid", "Int", 4, policyid.ToString());
                //Output.AssignParameter(parm, 13, "@calenderid", "Int", 4, calenderid.ToString());
                flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_savedatewiseleave", parm);
            }
        }

        if (divhalf.Visible == true && divfull.Visible == false)
        {

            Output.AssignParameter(parm, 0, "@apply_leave_id", "Int", 4, applyleaveid.ToString());

            if (divhalf.Visible == true && divfull.Visible == false)
            {
                Output.AssignParameter(parm, 1, "@dates", "DateTime", 100, txt_select.Text);
                Output.AssignParameter(parm, 2, "@Daymode", "Int", 10, "2");
                if (opt_first.Checked == true)
                {
                    Output.AssignParameter(parm, 3, "@HalfDaymode", "String", 50, "1");
                }
                if (opt_second.Checked == true)
                {
                    Output.AssignParameter(parm, 3, "@HalfDaymode", "String", 50, "2");
                }


                Output.AssignParameter(parm, 4, "@leavemode", "Int", 4, "0");
            }
            Output.AssignParameter(parm, 5, "@companyid", "Int", 10, _companyId);
            Output.AssignParameter(parm, 6, "@empcode", "String", 50, _userCode);

            Output.AssignParameter(parm, 7, "@status", "Int", 10, "1");
            Output.AssignParameter(parm, 8, "@leavestatus", "Int", 10, "0");
            Output.AssignParameter(parm, 9, "@Createdby", "String", 50, _userCode);
            Output.AssignParameter(parm, 10, "@no_ofdays", "Decimal", 50, txt_nod.Text);
            Output.AssignParameter(parm, 11, "@leave", "Int", 4, dd_typeleave.SelectedValue);
            //Output.AssignParameter(parm, 12, "@policyid", "Int", 4, policyid.ToString());
            //Output.AssignParameter(parm, 13, "@calenderid", "Int", 4, calenderid.ToString());
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_savedatewiseleave", parm);
        }


    }


    #endregion
    //protected void bind_Employee_Name()
    //{
    //    SqlConnection connection = new SqlConnection();
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string sqlstr = "SELECT emp_fname from tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text + "'";

    //        // string qry = "SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name,emp.emp_status, emp.dept_id,emp.division_id,emp.degination_id, emp.Grade, emp.branch_id,(CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,emp.reason_leaving,emp.salutation,emp.employee_type,emp.sub_emp_type,emp.official_email_id,emp.official_mob_no,emp.cost_center_group_id,emp.cost_center_code,emp.country,emp.state,emp.city,emp.location,emp.add_cost_center_group_id,emp.add_cost_center_code,emp.add_country,emp.add_state,emp.add_city,emp.add_location,emp.subgroupid,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate,emp.employee_type,emp.dep_type_id,emp.sub_emp_type FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";
    //        //DataSet ds1 = new DataSet();
    //        ds_3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds_3.Tables.Count > 0)
    //        {
    //            emp_name = ds_3.Tables[0].Rows[0]["emp_fname"].ToString();
    //        }
    //        else return;
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Name is not exist");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

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
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, txt_sdate.Text.ToString());
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, txt_edate.Text.ToString());
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 6, "@half", "String", 10, "");
        }
        else
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "0");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, "");
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, txt_select.Text.ToString());
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

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, "");
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


                    string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='" + displayleavename + "', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + Convert.ToDateTime(fromdate).ToString("dd MMM yyyy") + "' AND '" + Convert.ToDateTime(todate).ToString("dd MMM yyyy") + "'";
                    SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, str4);

                }
            }
        }
    }


    #endregion

    //#region Send  Mails to Approvers and Hand Request
    ////private void mailtohandoverrequest(ArrayList list)
    ////{
    ////    var activity = new DataActivity();
    ////    try
    ////    {
    ////        string sqlstr = @"select empcode,official_email_id,isnull(emp_fname,'')+' ' +isnull(emp_m_name,'')+' ' +isnull(emp_l_name,'') as empname from tbl_employee_details ed inner join tbl_employee_job_details ej on ej.emp_ref_no=ed.emp_ref_no where  empcode='" + txt_employee.Text + "'";
    ////        SqlConnection connection = activity.OpenConnection();
    ////        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    ////        if (_ds.Tables[0].Rows.Count > 0)
    ////        {
    ////            string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
    ////            string fromPwd = ConfigurationManager.AppSettings["pwd"];
    ////            string fromName = ConfigurationManager.AppSettings["fromName"];
    ////            string smtp = ConfigurationManager.AppSettings["smtp"];
    ////            string emailLogo = ConfigurationManager.AppSettings["emailLogo"];
    ////            string subject = "Work Handover Request Application ";

    ////            string bodyContent = "";

    ////            if (divfull.Visible == true)
    ////                bodyContent = "A new hand over request has been submitted by employee " + Session["name"] +" from " + txt_sdate.Text + " to " + txt_edate.Text + ".";
    ////            else
    ////                bodyContent = "A new hand over request has been submitted by employee " + Session["name"] +" for the date " + txt_select.Text + ".";

    ////            string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(),bodyContent);

    ////            if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
    ////            {
    ////                try
    ////                {
    ////                    Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName,ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp,emailLogo);
    ////                }
    ////                catch
    ////                {
    ////                    list.Add("Hand over request mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"] + ". Due to some technical problem.");
    ////                }
    ////            }
    ////            else
    ////            {
    ////                list.Add("Hand over request mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"] + ". Email id does not exists.");
    ////            }
    ////        }
    ////    }
    ////    catch (Exception ex)
    ////    {

    ////        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    ////        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    ////    }
    ////    finally
    ////    {
    ////        activity.CloseConnection();
    ////    }
    ////}
    //private void Mailtoapprover(ArrayList list, int leaveid, string type)
    //{
    //    // Getting the email details
    //    string fromEmail = ConfigurationManager.AppSettings["fromEmail"];
    //    string fromPwd = ConfigurationManager.AppSettings["pwd"];
    //    string fromName = ConfigurationManager.AppSettings["fromName"];
    //    string smtp = ConfigurationManager.AppSettings["smtp"];
    //    string emailLogo = ConfigurationManager.AppSettings["emailLogo"];
    //    string subject = "Leave Application for Approval";
    //    var activity = new DataActivity();
    //    try
    //    {
    //        SqlParameter[] sqlparm = new SqlParameter[2];
    //        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
    //        Output.AssignParameter(sqlparm, 1, "@type", "Int", 20, type.ToString());


    //        SqlConnection connection = activity.OpenConnection();
    //        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,"sp_leave_fetchmaildetail_employee", sqlparm);

    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            int i = ds.Tables[0].Rows.Count;
    //            int j = 0;

    //            while (i != 0)
    //            {

    //                QueryString q = new QueryString();
    //                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}",
    //                    ds.Tables[0].Rows[j]["id"], ds.Tables[0].Rows[j]["empcode"],
    //                    ds.Tables[0].Rows[j]["approvercode"], "LA");
    //                q.EncodePairs(pairs);

    //                string url =
    //                    "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" +
    //                    ConfigurationManager.AppSettings["url"] + "?m=" + pairs + "' >Approve</a>";
    //                string url1 =
    //                    "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" +
    //                    ConfigurationManager.AppSettings["url"] + "?m=" + pairs + "'>Reject</a>";
    //                string bodyContent;
    //                if (divfull.Visible == true)
    //                    bodyContent = "A new leave request has been submitted by employee " + Session["name"] +
    //                                  " from " + txt_sdate.Text + " to " + txt_edate.Text +
    //                                  ". <br/><br/>  <br/><br/>" + url + "&nbsp;&nbsp;&nbsp;" + url1;
    //                else
    //                    bodyContent = "A new leave request has been submitted by employee " + Session["name"] +
    //                                  " for the date " + txt_select.Text + ". <br/><br/>  <br/><br/>" + url +
    //                                  "&nbsp;&nbsp;&nbsp;" + url1;

    //                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(),
    //                    bodyContent);

    //                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
    //                {
    //                    try
    //                    {
    //                        Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName,ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody,smtp, emailLogo);
    //                    }
    //                    catch
    //                    {
    //                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"] +
    //                                 " due to some technical problem.");
    //                    }
    //                }
    //                else
    //                {
    //                    list.Add("Email is does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"]);
    //                }

    //                i--;
    //                j++;
    //            }
    //        }
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
        txt_employee.Text = "";
        grdpaper.DataSource = null;
        grdpaper.DataBind();
        Div7.Visible = false;
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
        hdnGender.Value = (hdnGender.Value == "Male" || hdnGender.Value == "MALE") ? "M" : "F";
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];

        Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, txt_employee.Text);
        Output.AssignParameter(sqlparm, 1, "@gender", "String", 50, hdnGender.Value);
        _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "BibdDropdownDataForLeave", sqlparm);
        
        //string sqlstr = @"select  DISTINCT  crleave.leaveid,crleave.leavetype from tbl_leave_createleave crleave INNER JOIN tbl_leave_employee_leave_master elm ON elm.leaveid=crleave.leaveid INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = elm.leaveid where elm.empcode='" + txt_employee.Text.ToString() + "' and crleave.leaveid not in (0) and ( applicable_to = 'A' or applicable_to ='" + hdnGender.Value + "' ) order by crleave.leavetype";
        //_ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (_ds.Tables[0].Rows.Count > 0)
        {
            dd_typeleave.DataTextField = "leavetype";
            dd_typeleave.DataValueField = "leaveid";
            dd_typeleave.DataSource = _ds;
            dd_typeleave.DataBind();
        }
        if (txt_employee.Text != "")
        {
           // hidd_empcode.Value = txt_employee.Text.Trim();
            Session["Leaveempcode"] = txt_employee.Text;
            lslink.Visible = true;
        }
        else Output.Show("Please Select Empcode");
        activity.CloseConnection();


        grdpaper.DataSource = null;
        grdpaper.DataBind();
        Div7.Visible = false;

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


    //protected void bind_Employee_Name()
    //{
    //    SqlConnection connection = new SqlConnection();
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string sqlstr = "SELECT empcode,emp_fname,official_email_id from tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text + "'";

    //        // string qry = "SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name,emp.emp_status, emp.dept_id,emp.division_id,emp.degination_id, emp.Grade, emp.branch_id,(CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,emp.reason_leaving,emp.salutation,emp.employee_type,emp.sub_emp_type,emp.official_email_id,emp.official_mob_no,emp.cost_center_group_id,emp.cost_center_code,emp.country,emp.state,emp.city,emp.location,emp.add_cost_center_group_id,emp.add_cost_center_code,emp.add_country,emp.add_state,emp.add_city,emp.add_location,emp.subgroupid,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate,emp.employee_type,emp.dep_type_id,emp.sub_emp_type FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";
    //        //DataSet ds1 = new DataSet();
    //        ds_3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds_3.Tables.Count < 1)
    //        {
    //            emp_name = ds_3.Tables[0].Rows[0]["emp_fname"].ToString();
    //            emplcode = ds_3.Tables[0].Rows[0]["empcode"].ToString();
    //            emplemail = ds_3.Tables[0].Rows[0]["official_email_id"].ToString();
    //            //emp_name = ds_3.Tables[0].Rows[0]["emp_fname"].ToString();
    //        }
    //        else return;
    //            //return;
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Name is not exist");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    private void SendMail(int leaveid)
    {
        if (divfull.Visible == true)
        {
            fromdt = txt_sdate.Text;
            todt = txt_edate.Text;
        }
        if (divhalf.Visible == true)
        {
            fromdt = txt_select.Text;
            todt = txt_select.Text;
            
            if (opt_first.Checked == true)
            {
                half = "First Half";
            }
            else
            {
                half = "Second Half";
            }
        }

        //-----------------------Sending Mail To Employee---------------------//

        Common.Data.DataActivity activity = new Common.Data.DataActivity();
        SqlConnection connection = new SqlConnection();
        connection = activity.OpenConnection();
        string sqlstr = "SELECT empcode,emp_fname,official_email_id from tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text + "'";

        // string qry = "SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name,emp.emp_status, emp.dept_id,emp.division_id,emp.degination_id, emp.Grade, emp.branch_id,(CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,emp.reason_leaving,emp.salutation,emp.employee_type,emp.sub_emp_type,emp.official_email_id,emp.official_mob_no,emp.cost_center_group_id,emp.cost_center_code,emp.country,emp.state,emp.city,emp.location,emp.add_cost_center_group_id,emp.add_cost_center_code,emp.add_country,emp.add_state,emp.add_city,emp.add_location,emp.subgroupid,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate,emp.employee_type,emp.dep_type_id,emp.sub_emp_type FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";
        //DataSet ds1 = new DataSet();
        ds_3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (ds_3.Tables.Count> 0)
        {
            
       
            emp_name = ds_3.Tables[0].Rows[0]["emp_fname"].ToString();
            emplcode = ds_3.Tables[0].Rows[0]["empcode"].ToString();
            emplemail = ds_3.Tables[0].Rows[0]["official_email_id"].ToString();
            //emp_name = ds_3.Tables[0].Rows[0]["emp_fname"].ToString();
            if (divfull.Visible == true)
            {
                empmsg = "Dear " + emp_name.Trim() + "," + "\n" + "\n";
                empmsg += Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString().Trim() + " has applied " + dd_typeleave.SelectedItem + " " + fromdt + "  to  " + todt + "\n";
                empmsg += "on behalf of you." + "\n" + "\n " + "\n";

                empmsg += "Regards" + "," + "\n";
                empmsg += "HR" + "\n";
                //if (emplemail.Trim() != "")
                //{
                //    sendmail_Template(emplemail, empmsg);
                //}
            }
            if (divhalf.Visible == true)
            {
              
                empmsg = "Dear " + emp_name.Trim() + "," + "\n" + "\n";
                empmsg += Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString().Trim() + " has applied " + dd_typeleave.SelectedItem + " on " + fromdt +"(Half Day - "+half+")"+"\n";
                empmsg += "on behalf of you." + "\n" + "\n " + "\n";

                empmsg += "Regards" + "," + "\n";
                empmsg += "HR" + "\n";
                //if (emplemail.Trim() != "")
                //{
                //    sendmail_Template(emplemail, empmsg);
                //}
            }
            if (emplemail != "")
            {
                sendmail_Template(emplemail.Trim(), empmsg);
            }

        }
      


     
        //----------------------Sending Mail To LM (Approver) ---------------------//

        //var activity = new DataActivity();
        //SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "l");
        DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        activity.CloseConnection();

        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            string sqlstr1 = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text + "'";
            DataSet ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
   if (divfull.Visible == true)
            {
           appmsg = "Dear " + ds2.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            appmsg += Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString().Trim() + " has applied " + dd_typeleave.SelectedItem +" "+ fromdt + "  to  " + todt + "\n";
            appmsg += "on behalf of " + ds3.Tables[0].Rows[i]["empname"].ToString().Trim() + " - " + ds3.Tables[0].Rows[i]["empcode"].ToString().Trim() +"\n" + "\n " + "\n";
            appmsg += "Regards" + "," + "\n";
            appmsg += "HR" + "\n";

   }

             if (divhalf.Visible == true)
            {
              
             appmsg = "Dear " + ds2.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            appmsg += Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString().Trim() + " has applied " + dd_typeleave.SelectedItem +" on "+ fromdt + "(Half Day - " + half + ")"+"\n";
            appmsg += "on behalf of " + ds3.Tables[0].Rows[i]["empname"].ToString().Trim() + " - " + ds3.Tables[0].Rows[i]["empcode"].ToString().Trim() +"\n" + "\n " + "\n";
            appmsg += "Regards" + "," + "\n";
            appmsg += "HR" + "\n";
            }
            if (ds2.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {
                sendmail_Template(ds2.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), appmsg);            
            }
        }




    }

    public bool sendmail_Template(string recievermailid, string bdy)
    {

        try
        {

            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];      

            string subject = "Leave Application";
            string FileName = string.Empty;
            string body = bdy;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtpClient.Host = ConfigurationManager.AppSettings["smtp"];
            smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
            object userState = mailMessage;

            try
            {
                smtpClient.Send(mailMessage);

                return true;
            }
            catch (System.Net.Mail.SmtpException)
            {
                return false;
            }

        }
        catch (Exception)
        {
            return false;
        }
    }
    private void MailtodottedLM(ArrayList list, int leaveid)
    {
       
        //-----------------------Mail to Dotted LM--------------------//


        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text + "'";
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {
                if (DottedLMemail != "")
                {
                    try
                    {
  if (divfull.Visible == true)
            {
               
                         appDLMmsg = "Dear " + dottedLMname.Trim() + "," + "\n" + "\n";
                        appDLMmsg += Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString().Trim()  + " has applied " + dd_typeleave.SelectedItem+" " + fromdt + "  to  " + todt + "\n";
                        appDLMmsg += "on behalf of " + ds.Tables[0].Rows[j]["empname"].ToString().Trim() + " - " + ds.Tables[0].Rows[j]["empcode"].ToString().Trim() + "\n" + "\n " + "\n";
                        appDLMmsg += "Regards" + "," + "\n";
                        appDLMmsg += "HR" + "\n";
  }
                           if (divhalf.Visible == true)
            {
              
           appDLMmsg = "Dear " + dottedLMname.Trim() + "," + "\n" + "\n";
                        appDLMmsg += Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString().Trim()  + " has applied " + dd_typeleave.SelectedItem+" on " + fromdt + "(Half Day - " + half +")"+ "\n";
                        appDLMmsg += "on behalf of " + ds.Tables[0].Rows[j]["empname"].ToString().Trim() + " - " + ds.Tables[0].Rows[j]["empcode"].ToString().Trim() + "\n" + "\n " + "\n";
                        appDLMmsg += "Regards" + "," + "\n";
                        appDLMmsg += "HR" + "\n";
                           }
                        if (DottedLMemail != "")
                        {

                            sendmail_Template(DottedLMemail, appDLMmsg);

                        }
                    }
                    catch
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["empname"] +
                                 " due to some technical problem.");

                    }
                }
                else
                {
                    list.Add("Dotted LM Email Id does not exists fot the employee: " + ds.Tables[0].Rows[j]["empname"]);
                }

                i--;
                j++;
            }
        }


    }
    protected void grdpaper_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        var activity = new DataActivity();
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string servicename = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "dates"));
            SqlConnection connection = activity.OpenConnection();

            string query3 = "";
            string query4 = "";

            query4 = "select DATEPART(DW,'" + servicename + "') as date";
            _ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query4);
            query3 = "declare @weakoffapplicble int; Set @weakoffapplicble=(Select weekly_off from tbl_leave_createdefaultrule where leaveid='" + dd_typeleave.SelectedValue + "' and status=1);declare @shift int; Set @shift=(Select shiftid from tbl_employee_shift_mapping where empcode='" + _userCode + "' and status=1); declare @branch int; Set @branch=(Select branch_id from tbl_intranet_employee_jobDetails where empcode='" + _userCode + "'); select weekcode from tbl_leave_weekoff where branchid=@branch  and @weakoffapplicble=1 and weekcode='" + Convert.ToInt32(_ds.Tables[0].Rows[0]["date"].ToString()) + "'";

            ds1 = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query3);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                var ddlhalf = e.Row.FindControl("ddltype") as DropDownList;
                var ddlday = e.Row.FindControl("ddlday") as DropDownList;

                // int hlfday = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "halfdaymode"));
                ddlday.SelectedValue = "2";
                ddlhalf.Enabled = true;



                DropDownList fullday = (DropDownList)e.Row.FindControl("ddlday");
                DropDownList halfday = (DropDownList)e.Row.FindControl("ddltype");



                halfday.Visible = true;
                halfday.Enabled = false;
                fullday.Enabled = false;


                ddlhalf.SelectedValue = "3";


            }

        }
    }
    protected void txt_sdate_TextChanged(object sender, EventArgs e)
    {
        grdpaper.DataSource = null;
        grdpaper.DataBind();
        // rdosplit.Checked = false;
        Div7.Visible = false;
    }
    protected void txt_edate_TextChanged(object sender, EventArgs e)
    {
        grdpaper.DataSource = null;
        grdpaper.DataBind();
        //  rdosplit.Checked = false;
        Div7.Visible = false;
    }
}
