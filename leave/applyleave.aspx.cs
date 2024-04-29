using Common.Console;
using Common.Data;
using Common.Date;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net.Mail;
using System.Text;
using System.Collections.Generic;

public partial class leave_applyleave : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    private DataSet _ds, ds2, ds1 = new DataSet();
    private string _companyId, _userCode;
    string fromdt, todt;
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
                bindemployee_detail();
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
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = _ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = _ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = _ds.Tables[0].Rows[0]["emp_gender"].ToString();
            HiddenField_gender.Value = (_ds.Tables[0].Rows[0]["emp_gender"].ToString() == "Male" || _ds.Tables[0].Rows[0]["emp_gender"].ToString() == "MALE") ? "M" : "F";
            lbl_emp_status.Text = _ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = _ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = _ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = _ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Utility.DateFormat(_ds.Tables[0].Rows[0]["emp_doj"].ToString())
                .ToString("dd - MMM - yyyy");
            hdn_branchid.Value = _ds.Tables[0].Rows[0]["branch_id"].ToString();
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
            //Output.Show("Leave application applied sucessfully");
            //Output.Show("Leave application applied successfully.");
        }



    }
    #endregion
    #region Leave Type Select Index Changed Event
    protected void dd_typeleave_DataBound(object sender, EventArgs e)
    {
        dd_typeleave.Items.Insert(0, new ListItem("--Select leave--", "0"));
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
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
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
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validateleavetype", sqlparm);
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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
            //if (!validate_dutyroster())
            //    return;
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

        Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 0, dd_typeleave.SelectedValue);

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

            decimal grosssalary = 0;
            //string sql = @"exec [sp_payroll_calculate_ctc] '" + _userCode + "' ," + _companyId + "";
            //DataSet dsgross = SQLServer.ExecuteDataset(connection, CommandType.Text, sql);
            //if (dsgross.Tables[0].Rows.Count > 0)
            //{
            //    grosssalary = Convert.ToDecimal(dsgross.Tables[0].Rows[0]["MONTHLYGROSS"].ToString());

            //}
            sqlparm = new SqlParameter[19];

            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 0, dd_typeleave.SelectedValue);


            if (divfull.Visible == true)
            {

                Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10, txt_sdate.Text);
                Output.AssignParameter(sqlparm, 3, "@enddate", "DateTime", 10, txt_edate.Text);

            }
            else
            {
                Output.AssignParameter(sqlparm, 2, "@startdate", "DateTime", 10, txt_select.Text);
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
            Output.AssignParameter(sqlparm, 17, "@policyid", "Int", 40, _ds.Tables[0].Rows[0]["policyid"].ToString());

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
            sdate = Convert.ToDateTime(txt_sdate.Text);
        else
            sdate = Convert.ToDateTime(txt_select.Text);

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
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, _userCode);
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
                        // }
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

        Output.AssignParameter(sqlpar, 1, "@empcode", "String", 10, _userCode);
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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
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
            txt_nod.Text = "0.0";
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

              if (dd_typeleave.SelectedValue == "1" || dd_typeleave.SelectedValue == "2")
              {
                  SqlParameter[] sqlparm1 = new SqlParameter[1];
                  Output.AssignParameter(sqlparm1, 0, "@empcode", "String", 50, Session["empcode"].ToString());

                  ds2 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_leave_entitledcompoff]", sqlparm1);
                  if (ds2.Tables[0].Rows.Count > 0)
                  {

                      if (Convert.ToDecimal(ds2.Tables[0].Rows[0]["avalibledays"].ToString())>0)
                      {
                          Output.Show("Please Use Comp-off Before Using EL & CL/SL");
                    
                          return;
                      }
                  }
              }
            
            if (upload_attach.Enabled == true)
            {
                if (upload_attach.HasFile)
                {
                }
                else
                {
                    Output.Show("Please Attach the document.");
                    upload_attach.Focus();
                    return;
                }
            }
            Page.Validate("calculate");
            Page.Validate("all");
            if (!Page.IsValid)
                return;
            if (!validateapplyleave())
                return;
            if (txt_nod.Text == "0")
                return;

            btn_submit.Enabled = false;
            int leaveid = 0;
            if (txt_nod.Text == "0.0")
            {
                Common.Console.Output.Show("No. of Days should not be Zero.please check leave  application.");
                return;
            }
            ArrayList list = new ArrayList();
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            leaveid = Insertapplyleave(connection, transaction, 0);
            Insertadjustment(connection, transaction, leaveid);
            InsertDatewise(connection, transaction, leaveid);
            transaction.Commit();

            //list.Add("Leave application applied successfully.");
            Output.Show("Leave application applied successfully.");
            // Mail(list, leaveid, "l");
            SendMail(leaveid);
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str = str + list[i];
                str = str + "\\n";
            }

            reset();
            Output.Show(str);

            btn_submit.Enabled = true;
        }
        catch (Exception ex)
        {
            Smart.HR.Common.Console.Output.Log("During Apply Leave: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
            // if (transaction != null) transaction.Rollback();
        }
        finally
        {
            activity.CloseConnection();
           // Output.Show("Leave application applied successfully.");
        }
    }
    #endregion
    #region Insertion Leave Details
    protected int Insertapplyleave(SqlConnection connection, SqlTransaction transaction, int status)
    {
        SqlParameter[] parm = new SqlParameter[19];
        int flag = 0;


        Output.AssignParameter(parm, 0, "@empcode", "String", 50, _userCode);
        Output.AssignParameter(parm, 1, "@leaveid", "Int", 10, dd_typeleave.SelectedValue);
        if (divfull.Visible == true)
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "1");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, txt_sdate.Text);
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, txt_edate.Text);
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 6, "@half", "String", 10, "");
        }
        else
        {
            Output.AssignParameter(parm, 2, "@leavemode", "String", 10, "0");
            Output.AssignParameter(parm, 3, "@fromdate", "DateTime", 20, "");
            Output.AssignParameter(parm, 4, "@todate", "DateTime", 20, "");
            Output.AssignParameter(parm, 5, "@hdate", "DateTime", 20, txt_select.Text);
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
                upload_attach.PostedFile.SaveAs(Server.MapPath("upload/doc/" + filename));
                if (prvimg.Value != "")
                    System.IO.File.Delete("upload/doc/" + prvimg.Value);
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
        Output.AssignParameter(parm, 12, "@leave_status", "Int", 100, status.ToString(CultureInfo.InvariantCulture));
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
    protected void Insertadjustment(SqlConnection connection, SqlTransaction transaction, int applyleaveid)
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
    #region Send  Mails to Approvers

    //void SendEmail(int leaveid)
    //{
    //    try
    //    {
    //        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestFactory();
    //        EmailClient client = new EmailClient(email);

    //        ServicePointManager.ServerCertificateValidationCallback =
    //       delegate(object s, X509Certificate certificate,
    //       X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //       { return true; };

    //        client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
    //        client.empCode = Session["empcode"].ToString();
    //        client.employeeName = Session["name"].ToString().Trim();
    //        client.appsendername = Session["name"].ToString().Trim();
    //        client.requestNumber = leaveid.ToString();
    //        client.Send();
    //    }
    //    catch (Exception ex)
    //    {
    //        Smart.HR.Common.Console.Output.Log("During Apply Leave: " + ex.Message + ".    " + DateTime.Now);
    //        throw ex;
    //    }
    //}


    //private void Mail(ArrayList list, int leaveid, string type)
    //{
    //    SendEmail(leaveid);

    //    var activity = new DataActivity();
    //    SqlParameter[] sqlparm = new SqlParameter[2];
    //    Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
    //    Output.AssignParameter(sqlparm, 1, "@type", "String", 20, type.ToString());

    //    SqlConnection connection = activity.OpenConnection();
    //    DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
    //    activity.CloseConnection();

    //    if (ds.Tables[0].Rows.Count > 0)
    //    {
    //        int n = ds.Tables[0].Rows.Count;

    //        for (int i = 0; i < n; i++)
    //        {
    //            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
    //            {
    //                EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestApprover();
    //                EmailClient client = new EmailClient(email);

    //                //          ServicePointManager.ServerCertificateValidationCallback =
    //                //delegate(object s, X509Certificate certificate,
    //                //X509Chain chain, SslPolicyErrors sslPolicyErrors)
    //                //{ return true; };

    //                client.toEmailId = ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim();
    //                client.empCode = ds.Tables[0].Rows[i]["approvercode"].ToString().Trim();
    //                client.employeeName = ds.Tables[0].Rows[i]["a_name"].ToString().Trim();
    //                client.appsendername = Session["name"].ToString().Trim();
    //                client.requestNumber = leaveid.ToString();
    //                client.Send();
    //            }
    //            else
    //            {
    //                list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[i]["a_name"]);
    //            }

    //        }
    //    }
    //    else
    //    {
    //        throw new Exception("No approvers");

    //    }

    //}
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
        grdpaper.DataSource = null;
        grdpaper.DataBind();
        Div7.Visible = false;
    }
    #endregion

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
        }
        //-----------------------Sending Mail To Employee---------------------//

        //string empmsg = "Dear " + lbl_emp_name.Text + "," + "\n" + "\n";
        //empmsg += "Thanks for using Smart HR.You have applied " + dd_typeleave.SelectedItem + " for " + txt_nod.Text + " days that is from " + fromdt + "  to  " + todt + "\n";
        //empmsg += "Your application will submitted to Approver for Approval" + "\n" + "\n " + "\n";

        //empmsg += "Regards" + "," + "\n";
        //empmsg += "HR" + "\n";
        //if (Session["OfficialEmailId"].ToString().Trim() != "")
        //{
        //  //  sendmail_Template(Session["OfficialEmailId"].ToString().Trim(), empmsg);
        //}
        //----------------------Sending Mail To Approver ---------------------//

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "l");
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
           
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["a_name"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(),fromdt,todt);
            }
        }


    }

    public bool sendmail_Template(string recievermailid, string approver, string employee, string empcode,string fromdt,string todt)
    {

        try
        {


            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];      
  

            string Template = EmailTemplate(approver, employee, empcode, fromdt,todt);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Leave Application";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;


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
                if (IsAttachment)
                {
                    attachment.ContentStream.Close();

                }
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
    public string EmailTemplate(string approver, string employee, string empcode,string fromdt,string todt)
    {
        string leave;
        if (dd_typeleave.SelectedValue == "1")
        {
            leave = "EL";
        }
        else if (dd_typeleave.SelectedValue == "2")
        {
            leave = "CL/SL";
        }
        else if (dd_typeleave.SelectedValue == "3")
        {
            leave = "PBL";
        }
        else if (dd_typeleave.SelectedValue == "4")
        {
            leave = "ML";
        }
        else
        {
            leave = "PL";
        }
        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = empcode.ToString();
        string EmailFormat = @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
                    "<html lang='en'>" +
"<head>" +

    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +

    "<style type='text/css'>" +
        "body, td, div, p, a, input" +
        "{" +
            "font-family: arial, sans-serif;" +
        "}" +
    "</style>" +

    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
    "<title>OD Application</title>" +
    "<style type='text/css'>" +
        "body, td" +
        "{" +
            "font-size: 13px;" +
        "}" +

        "a:link, a:active" +
        "{" +
            "color: #1155CC;" +
            "text-decoration: none;" +
        "}" +

        "a:hover" +
       "{" +
            "text-decoration: underline;" +
            "cursor: pointer;" +
        "}" +

        "a:visited" +
        "{" +
            "color: #6611CC;" +
        "}" +

        "img" +
        "{" +
            "border: 0px;" +
        "}" +

        "pre" +
        "{" +
            "white-space: pre;" +
            "white-space: -moz-pre-wrap;" +
            "white-space: -o-pre-wrap;" +
            "white-space: pre-wrap;" +
           "word-wrap: break-word;" +
           "max-width: 800px;" +
            "overflow: auto;" +
        "}" +

        ".logo" +
        "{" +
            "left: -7px;" +
            "position: relative;" +
        "}" +
    "</style>" +
"</head>" +
"<body>" +
    "<div class='bodycontainer'>" +


        "<div class='maincontent'>" +

            "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>" +
                "<tr>" +

                    "<tr>" +
                        "<td colspan='2'><font size='-1' class='recipient'>" +
                            "<div></div>" +
                        "</font>" +
                           " <tr>" +
                                "<td colspan='2'>" +
                                    "<table width='100%' cellpadding='12' cellspacing='0' border='0'>" +
                                        "<tr>" +
                                            "<td>" +
                                                "<div style='overflow: hidden;'>" +
                                                    "<font size='-1'>" +
                                                        "<div id='leaveid'>" +
            //"<table width='100%'>" +
            //    "<tbody>" +

                                                            //        "<tr>" +
            //            "<td style='border-bottom: 1px solid #ccc; font: 12px arial'>" +
            //                "<div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Holiday Work Application</span></div>" +
            //            "</td>" +
            //            "<td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>" +
            //        "</tr>" +
            //    "</tbody>" +
            //"</table>" +
            //"<br>" +
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Leave Application(" + leave + ") from  " + emp + " - " + empcod + " dated from " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + " - " + Convert.ToDateTime(todt).ToString("dd-MMM-yyyy") + " for Approval / Reject.</p>" +

                                                            "<p>Click here - " + ConfigurationManager.AppSettings["EmailLink"] + "</p>" +

                                                            "<p>" +
                                                                "<b>Regards,<br><br>" +
                                                                    "HR<br><br>" +
                                                                "</b>" +
                                                            "</p>" +
                                                            "<br>" +

                                                            "<table width='100%'>" +
                                                                "<tbody>" +
                                                                    "<tr>" +
                                                                        "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                                                                            "<br>" +
                                                                                //"(1) Call our 24-hour Customer Care or<br>" +
                                                                                //"(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>" +
                                                                            "<br>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                        "</td>" +
                                                                    "</tr>" +
                                                                "</tbody>" +
                                                            "</table>" +

                                                        "</div>" +
                                                    "</font>" +
                                                "</div>" +
                                    "</table>" +
            "</table>" +
        "</div>" +
    "</div>" +

"</body>" +
"</html>";

        return EmailFormat;
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
