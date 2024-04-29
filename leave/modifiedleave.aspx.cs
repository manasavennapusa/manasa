using Common.Console;
using Common.Data;
using Common.Date;
using Common.Encode;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;

public partial class leave_modifiedleave : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr; int error;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                Common.Encode.QueryString q = new Common.Encode.QueryString();
                hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
                btn_submit.Enabled = false;
                bindemployee_detail();
                fetchleavedata();
            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    #region Bind The Employee Details
    protected void bindemployee_detail()
    {

        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();

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
    }
    #endregion
    #region Fetch Leave Details
    protected void fetchleavedata()
    {
        try
        {
            if (hidd_leaveapplyid.Value == "0")
            {
                Output.Show("Problem fetchin leave data,try latter");
                return;
            }
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hidd_leaveid.Value = ds.Tables[0].Rows[0]["leaveid"].ToString();
                lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();

                if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
                {
                    txt_cancel.Enabled = false;
                    btn_submit.Enabled = false;
                    btn_reset.Enabled = false;
                }
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
                {
                    divfull.Visible = true;
                    divhalf.Visible = false;
                    txt_sdate.Text = ds.Tables[0].Rows[0]["fromdate"].ToString();
                    txt_edate.Text = ds.Tables[0].Rows[0]["todate"].ToString();
                }
                else
                {
                    divfull.Visible = false;
                    divhalf.Visible = true;
                    txt_select.Text = ds.Tables[0].Rows[0]["hdate"].ToString();
                    opt_first.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["half"]);
                }
                txt_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
                txt_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
                lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
                hidd_leave_status.Value = ds.Tables[0].Rows[0]["leave_status"].ToString();
                lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a target='_blank' href='Upload/Doc/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
                  "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";
                prvimg.Value = ds.Tables[0].Rows[0]["file_path"].ToString();
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                adjustgrid.DataSource = ds.Tables[1];
                adjustgrid.DataBind();
            }

            if (ds.Tables[2].Rows.Count > 0)
            {
                approvergrid.DataSource = ds.Tables[2];
                approvergrid.DataBind();
            }
            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
            {
                divhalf.Visible = false;
                divfull.Visible = true;

            }
            else
            {
                divhalf.Visible = true;
                divfull.Visible = false;

            }
            sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@leaveid", "String", 50, hidd_leaveid.Value);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, _userCode);
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleavetype", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["document_required"]) != false)
            {

                upload_attach.Enabled = true;
            }
            else
            {

                upload_attach.Enabled = false;
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
    }

    #endregion
    #region Validate the Apply Leave Depending upon Leave Rule
    protected Boolean validateapplyleave()
    {
        SqlParameter[] sqlparm = new SqlParameter[2];

        Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 0, hidd_leaveid.Value);

        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleavetype",
                sqlparm);
            if (!valdiate_leave(_ds))
            {
                txt_nod.Text = "0";
                btn_submit.Enabled = true;
                adjustgrid.DataSource = null;
                adjustgrid.DataBind();
                return false;
            }


            sqlparm = new SqlParameter[19];

            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 0, hidd_leaveid.Value);


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

            Output.AssignParameter(sqlparm, 9, "@leave", "String", 100, lbl_leave.Text);
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
            Output.AssignParameter(sqlparm30, 0, "@empcode", "String", 100, _userCode);
            Output.AssignParameter(sqlparm30, 1, "@leaveid", "Int", 4, hidd_leaveid.Value);
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
                    Output.Show("Back Date leave applying not allowed for " + lbl_leave.Text);

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
            SqlParameter[] sqlparam = new SqlParameter[4];
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, _userCode);
            if (divfull.Visible == true)
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, Utility.DateFormat(txt_sdate.Text).ToString());
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, Utility.DateFormat(txt_edate.Text).ToString());

            }
            else
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, Utility.DateFormat(txt_select.Text).ToString());
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, Utility.DateFormat(txt_select.Text).ToString());

            }
            Output.AssignParameter(sqlparam, 3, "@leaveid", "Int", 50, hidd_leaveapplyid.Value);
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_modified_applied_date", sqlparam);
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
                        //if (_ds.Tables[4].Rows.Count > 0)
                        //{
                        //    txt_nod.Text = "0";
                        //    Output.Show("You have already applied for Substitute Holiday during this span! Please check application status");
                        //    return false;
                        //}
                        //else
                        //{
                        if (_ds.Tables[3].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Output.Show("Your leave profile is not created! Please contact your Manager");
                            return false;
                        }
                        //  }
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

    #endregion
    #region Calulate the no. of days
    protected void btn_calc_Click(object sender, EventArgs e)
    {
        if (validate_applydate())
        {
            validateapplyleave();
            btn_submit.Enabled = true;
        }
        else
        {
        }

    }
    #endregion
    #region Leave Modification Details
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }


        Page.Validate("calculate");
        Page.Validate("all");
        if (!Page.IsValid)
            return;
        if (!validateapplyleave())
            return;
        if (txt_nod.Text == "0")
            return;
        string str = "";
        SqlTransaction _Transaction = null;
        int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
        ArrayList list = new ArrayList();
        btn_submit.Enabled = false;
        int status = 0;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];
        Output.AssignParameter(sqlparm, 0, "@id", "Int", 50, hidd_leaveapplyid.Value);

        try
        {
            SqlConnection _Connection = activity.OpenConnection();
            status = Convert.ToInt32(SQLServer.ExecuteScalar(_Connection, CommandType.StoredProcedure, "sp_leave_validate_confirm_hr", sqlparm));
        }
        catch (Exception ex)
        {
            if (_Transaction != null) _Transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

        switch (status)
        {
            case 0:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(0, 1, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Leave Updated Successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    reset();
                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;
                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);

                break;
            case 1: try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(1, 2, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Leave applied for modification successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }

                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    reset();
                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;
                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                break;
            case 2:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be modified,its already in cancel status");
                break;
            case 3:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(3, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be modified,its already in rejected status");
                break;
            case 4:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(0, 1, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Leave Updated Successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }

                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    reset();
                    Output.Show(str);
                }

                btn_submit.Enabled = true;
                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                break;
            case 5: try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Connection.Open();

                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(0, 1, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Leave Updated Successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    reset();
                    Output.Show(str);
                }

                btn_submit.Enabled = true;
                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                break;
            case 6:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    leaveid = updateapplyleave(6, 2, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Leave applied for modification successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }

                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    reset();
                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;

                Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                break;
        }

    }

    void SendEmail(int leaveid)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestFactory();
        EmailClient client = new EmailClient(email);
        client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
        client.empCode = Session["empcode"].ToString();
        client.employeeName = Session["name"].ToString().Trim();
        client.requestNumber = leaveid.ToString();
        client.Send();
    }


    private void Mailtoapprover(ArrayList list, int leaveid, string type)
    {
        var activity = new DataActivity();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 20, type.ToString());

        SqlConnection connection = activity.OpenConnection();
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
            "sp_leave_fetchmaildetail_employee", sqlparm);
        activity.CloseConnection();

        SendEmail(leaveid);

        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {
                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
                {
                    try
                    {
                        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestApprover();
                        EmailClient client = new EmailClient(email);
                        client.toEmailId = ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim();
                        client.empCode = ds.Tables[0].Rows[j]["approvercode"].ToString().Trim();
                        client.employeeName = ds.Tables[0].Rows[j]["a_name"].ToString().Trim();
                        client.requestNumber = leaveid.ToString();
                        client.Send();
                    }
                    catch
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"] +
                                 " due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"]);
                }

                i--;
                j++;
            }
        }

    }

    protected int updateapplyleave(int leavestatus, int status, SqlConnection connection, SqlTransaction transaction)
    {

        QueryString q = new QueryString();
        if (q["modify"] != null)
        {
            sqlstr = "DELETE FROM tbl_leave_modify_applied_leave WHERE apply_leave_id=" + hidd_leaveapplyid.Value;
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            sqlstr = "insert into tbl_leave_modify_applied_leave select id,leaveid,leavemode,fromdate,todate,hdate,no_of_days,half,reason,file_path,leave_adjusted from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        }

        SqlParameter[] parm = new SqlParameter[17];

        Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
        Output.AssignParameter(parm, 1, "@leaveid", "Int", 10, hidd_leaveid.Value.ToString());
        if (divfull.Visible == true)
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "1");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, Utility.DateFormat(txt_sdate.Text.ToString(CultureInfo.InvariantCulture)).ToString());
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, Utility.DateFormat(txt_edate.Text.ToString(CultureInfo.InvariantCulture)).ToString());
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 6, "@half", "String", 10, "");
        }
        else
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "0");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, "");
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, Utility.DateFormat(txt_select.Text.ToString(CultureInfo.InvariantCulture)).ToString());
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
                upload_attach.PostedFile.SaveAs(Server.MapPath("Upload/Doc/" + filename));
                if (prvimg.Value != "")
                    System.IO.File.Delete("Upload/Doc/" + prvimg.Value);
            }
            else
            {
                filename = prvimg.Value;
            }

            Output.AssignParameter(parm, 9, "@file_path", "String", 100, filename);
        }
        else Output.AssignParameter(parm, 9, "@file_path", "String", 100, "");
        Output.AssignParameter(parm, 10, "@leave_adjusted", "String", 100, (adjustgrid.Rows.Count > 1) ? "1" : "0");
        Output.AssignParameter(parm, 11, "@approvel_status", "Int", 100, "0");
        Output.AssignParameter(parm, 12, "@leave_status", "Int", 100, leavestatus.ToString(CultureInfo.InvariantCulture));

        if (txt_comment.Text != "")
        {
            txt_comment.Text = "<h6><b>Comments added by " + Session["name"] + " on " + DateTime.Now +
                               " :</b><br>" + txt_comment.Text + "</h6>";
        }
        Output.AssignParameter(parm, 13, "@comments", "String", 100, txt_comment.Text);
        Output.AssignParameter(parm, 14, "@applyleaveid", "Int", 100, hidd_leaveapplyid.Value);
        Output.AssignParameter(parm, 15, "@status", "Int", 100, status.ToString());
        Output.AssignParameter(parm, 16, "@modifiedby", "String", 100, _userCode);
        return Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "sp_leave_updateapplyleave", parm));
    }
    protected void updateadjustment(SqlConnection connection, SqlTransaction transaction)
    {
        QueryString q = new QueryString();
        if (q["modify"] != null)
        {
            sqlstr = "DELETE FROM tbl_leave_modify_leave where apply_leave_id=" + hidd_leaveapplyid.Value;
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            sqlstr = "insert into tbl_leave_modify_leave select apply_leave_id,leaveid,leavename,days from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        }

        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        SqlParameter[] parm;
        for (int i = 0; adjustgrid.Rows.Count > i; i++)
        {
            parm = new SqlParameter[6];
            Output.AssignParameter(parm, 0, "@apply_leave_id", "Int", 4, hidd_leaveapplyid.Value);
            Output.AssignParameter(parm, 1, "@leaveid", "Int", 20, adjustgrid.DataKeys[i].Value.ToString());
            Output.AssignParameter(parm, 2, "@days", "Decimal", 20, ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l3")).Text);
            Output.AssignParameter(parm, 3, "@status", "String", 20, ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l4")).Text);
            Output.AssignParameter(parm, 4, "@leavename", "String", 20, ((Label)adjustgrid.Rows[i].Cells[0].FindControl("l2")).Text);
            Output.AssignParameter(parm, 5, "@companyid", "String", 10, _companyId.ToString());
            SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_saveleaveadjustment", parm);

        }
    }
    #endregion
    #region Leave Cancilation Details
    protected void btn_cancel_Click(object sender, EventArgs e)
    {

        txt_cancel.Enabled = false;
        string str = "";
        SqlTransaction _Transaction = null;
        int leaveid = 0;
        ArrayList list = new ArrayList();
        int status = 0;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];
        Output.AssignParameter(sqlparm, 0, "@id", "Int", 50, hidd_leaveapplyid.Value);

        try
        {
            try
            {
                SqlConnection _Connection = activity.OpenConnection();
                status = Convert.ToInt32(SQLServer.ExecuteScalar(_Connection, CommandType.StoredProcedure, "sp_leave_validate_confirm_hr", sqlparm));
            }
            catch (Exception ex)
            {
                if (_Transaction != null) _Transaction.Rollback();
                Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                activity.CloseConnection();
            }
            switch (status)
            {
                case 0:
                    try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();
                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(2, 1, _Connection, _Transaction);
                        _Transaction.Commit();
                        list.Add("Leave Cancelled Successfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Canceled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }


                    if (error > 0)
                    {
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                        for (int i = 0; i < list.Count; i++)
                        {
                            str = str + list[i].ToString();
                            str = str + "\\n";
                        }

                        reset();
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    txt_cancel.Enabled = true;


                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                    break;
                case 1:
                    try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();
                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(1, 0, _Connection, _Transaction);
                        _Transaction.Commit();
                        list.Add("Leave applied for cancellation successfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Canceled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }


                    if (error > 0)
                    {
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                        for (int i = 0; i < list.Count; i++)
                        {
                            str = str + list[i].ToString();
                            str = str + "\\n";
                        }

                        reset();
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    txt_cancel.Enabled = true;


                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                    break;
                case 2: try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();
                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(2, 1, _Connection, _Transaction);
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Canceled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave already cancelled");
                    break;
                case 3:
                    try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();
                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(3, 1, _Connection, _Transaction);
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Canceled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=Leave cannot be cancelled,its already in rejected status");
                    break;
                case 4:
                    try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();
                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(2, 1, _Connection, _Transaction);
                        _Transaction.Commit();
                        list.Add("Leave Cancelled Successfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Canceled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }


                    if (error > 0)
                    {
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");
                        for (int i = 0; i < list.Count; i++)
                        {
                            str = str + list[i].ToString();
                            str = str + "\\n";
                        }

                        reset();
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    txt_cancel.Enabled = true;



                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                    break;
                case 5:
                    try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();

                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(2, 1, _Connection, _Transaction);

                        _Transaction.Commit();
                        list.Add("Leave Cancelled Successfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Cancelled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }


                    if (error > 0)
                    {

                        mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");
                        for (int i = 0; i < list.Count; i++)
                        {
                            str = str + list[i].ToString();
                            str = str + "\\n";
                        }

                        reset();
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    txt_cancel.Enabled = true;


                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);
                    break;
                case 6: try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Connection.Open();
                        _Transaction = _Connection.BeginTransaction();
                        cancelleave(6, 0, _Connection, _Transaction);
                        _Transaction.Commit();
                        list.Add("Leave applied for cancellation successfully.");
                        error++;
                    }

                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Cancelled. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }



                    if (error > 0)
                    {
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");
                        for (int i = 0; i < list.Count; i++)
                        {
                            str = str + list[i].ToString();
                            str = str + "\\n";
                        }

                        reset();
                        Output.Show(str);

                    }

                    txt_cancel.Enabled = true;
                    Response.Redirect("viewleavestatus.aspx?leavestatus=10&message=" + str);

                    break;
            }
        }


        catch (Exception ex)
        {
            if (_Transaction != null) _Transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Leave cancillation problem is their. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void cancelleave(int leave_status, int status, SqlConnection connection, SqlTransaction transaction)
    {

        SqlParameter[] parm = new SqlParameter[5];
        Output.AssignParameter(parm, 0, "@comments", "String", 2000, txt_comment.Text != "" ? "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "<br>" : "");
        Output.AssignParameter(parm, 1, "@modifiedby", "String", 100, _userCode);
        Output.AssignParameter(parm, 2, "@applyleaveid", "String", 100, hidd_leaveapplyid.Value);
        Output.AssignParameter(parm, 3, "@Leave_status", "String", 100, leave_status.ToString());
        Output.AssignParameter(parm, 4, "@status", "String", 100, status.ToString());

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull(@comments,''),leave_status=@leave_status,approvel_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, parm);

        }
        else
        {
            sqlstr = "update tbl_leave_apply_leave set comments=comments + @comments,leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, parm);
        }

    }
    #endregion
    #region Mail Shooting to Approvers
    protected void mailtoapprover(ArrayList list, int leaveid, string type)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 50, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 50, type);
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {

                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                QueryString q = new QueryString();
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "LA");
                string encoded;
                encoded = q.EncodePairs(pairs);

                string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
                string subject = "Leave Updation for Approval";
                string bodyContent = "A new leave updation  request has been submitted by employee " + Session["name"].ToString() + " from " + txt_sdate.Text + " to " + txt_edate.Text + ". <br/><br/> " + url + " &nbsp; &nbsp;&nbsp;" + url1;

                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);
                if (ds.Tables[0].Rows[0]["official_email_id"].ToString() != "")
                {
                    try
                    {
                        Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                    }
                    catch
                    {
                        list.Add("Leave Updation mail is not delivered to the Approver . Due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Leave Updation mail is not delivered to the Approver. Email id does not exists.");
                }

                i--;
                j++;
            }
        }
        activity.CloseConnection();
    }
    protected void mailtocancelapprover(ArrayList list, int leaveid, string type)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
        sqlparm[1] = new SqlParameter("@type", type);
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {

                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                QueryString q = new QueryString();
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "LA");
                string encoded;
                encoded = q.EncodePairs(pairs);

                string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
                string subject = "Leave Cancelation for Approval";
                string bodyContent = "A new leave Cancelation  request has been submitted by employee " + Session["name"].ToString() + " from " + txt_sdate.Text + " to " + txt_edate.Text + ". <br/><br/> " + url + " &nbsp; &nbsp;&nbsp; " + url1;

                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);
                if (ds.Tables[0].Rows[0]["official_email_id"].ToString() != "")
                {
                    try
                    {
                        Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                    }
                    catch
                    {
                        list.Add("Leave Cancelation mail is not delivered to the Approver . Due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Leave Cancelation mail is not delivered to the Approver. Email id does not exists.");
                }

                i--;
                j++;
            }
        }
    }
    #endregion
    #region Leave Reset Details
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        bindemployee_detail();
        fetchleavedata();
        btn_submit.Enabled = true;
    }
    protected void reset()
    {
        btn_submit.Enabled = false;
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
    }

    protected void opt_first_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void opt_second_CheckedChanged(object sender, EventArgs e)
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
    #endregion

    protected void adjustgrid_PreRender(object sender, EventArgs e)
    {
        if (adjustgrid.Rows.Count > 0)
            adjustgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void approvergrid_PreRender(object sender, EventArgs e)
    {
        if (approvergrid.Rows.Count > 0)
            approvergrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

}