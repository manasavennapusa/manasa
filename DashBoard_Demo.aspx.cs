using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class DashBoard_Demo : System.Web.UI.Page
{
    string sqlstr, str, eventData, finaleventdata;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string _companyId, _userCode, RoleId, role, gender;

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Calander", GenerateEvents(CreateEvents()), true);
        if (Session["role"] == null)
        {
            Response.Redirect("Default.aspx?logout=true");
        }
        RoleId = Session["rolename"].ToString();
        role = Session["role"].ToString();
        if (Session["companyid"] == null)
        {
            Response.Redirect("Default.aspx?logout=true");
        }
        if (Session["empcode"] == null)
        {
            Response.Redirect("Default.aspx?logout=true");
        }
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        Session["empcodeReportee"] = "EIN1001";
        Session["genderReportee"] = "Female";
        string test = (Session["genderReportee"]).ToString();
        string test1 = (Session["empcodeReportee"]).ToString();
        RoleId = Session["rolename"].ToString();
        lbl_todays_date.Text = DateTime.Now.ToString("dd'th' MMMMMMMMM yyyy");
        gender = Session["gender"].ToString();

        if (!IsPostBack)
        {
            //======================================================================================================
            if (Request.QueryString["NewsAward"] == "1")
            {
                Output.Show("Awards And Recognization Added Successfully");
            }
            if (Request.QueryString["NewsAward"] == "0")
            {
                Output.Show("Awards And Recognization Not Added Due To Some Internal Process");
            }
            if (Request.QueryString["update"] == "true")
            {
                Output.Show("Awards And Recognization Updated Successfully");
            }
            //======================================================================================================
            if (Request.QueryString["NewsUpdate"] == "1")
            {
                Output.Show("News Added Successfully");
            }
            if (Request.QueryString["NewsUpdate"] == "0")
            {
                Output.Show("News Not Added Due To Some Internal Process");
            }
            if (Request.QueryString["newsupdate"] == "true")
            {
                Output.Show("News Updated Successfully");
            }
            //======================================================================================================
            if (Request.QueryString["sent"] == "true")
            {
                Output.Show("Mail Sent Successfully");
            }
            if (Request.QueryString["sent"] == "no")
            {
                Output.Show("Mail Not Sent Due to Network Problem.Please Try again Later.");
            }
            //======================================================================================================
            bind_EL_CLSL_ML_PL();
            bind_HeadCount_Joinings_Exits();
            bind_AwardsAndRecognition();
            
            bind_NewsAndUpdates();
            GetBirthdayAnniversaries();
            GetNewJoinedEmployee();

            GetPendingLeaveDetailsByAdmin();
            bindAllQueryStatus();
            getActiveCycle();
            GetAppraisalPerformance();
        }
        PropertyInfo isreadonly = typeof(System.Collections.Specialized.NameValueCollection).GetProperty("IsReadOnly", BindingFlags.Instance | BindingFlags.NonPublic);
        isreadonly.SetValue(this.Request.QueryString, false, null);
        this.Request.QueryString.Remove("NewsAward");
        this.Request.QueryString.Remove("update");
        this.Request.QueryString.Remove("NewsUpdate");
        this.Request.QueryString.Remove("newsupdate");
        this.Request.QueryString.Remove("sent");
        //this.Response.Redirect(this.Request.Url.ToString());
        if (role == "3")
        {
            bind_Employee_Status(role);
            td_awards_recognization.Visible = true;
            td_news_update.Visible = true;
            lbl1.Text = "Total Head Count";
            lbl2.Text = "Joinings This Month";
            lbl3.Text = "Exits This Month";
            lbl4.Text = "Appraisal Due";
            Label1.Text = "Employee's Status";
            row_2.Visible = true;
            row_3.Visible = true;
            row_4.Visible = true;
            row_5.Visible = true;
            row_6.Visible = true;
        }
        else if (role == "13")
        {
            bind_Employee_Status(role);
            lbl1.Text = "My Reportees";
            lbl2.Text = "My Team - New Joinees";
            lbl3.Text = "My Team - Exits";
            lbl4.Text = "My Team - Appraisal";
            Label1.Text = "My Team Status";
            row_2.Visible = true;
            row_3.Visible = true;
            row_4.Visible = true;
            row_5.Visible = true;
            row_6.Visible = true;
        }
        else if (role == "1")
        {
            row_7.Visible = true;
            row_4.Visible = true;
            row_5.Visible = true;
            row_6.Visible = true;
        }
        else
        {
            td_awards_recognization.Visible = false;
            td_news_update.Visible = false;
            row_2.Visible = true;
            row_3.Visible = true;
            row_4.Visible = true;
            row_5.Visible = true;
            row_6.Visible = true;
        }
    }

    #region Binding of Earned Leave, Casual & SickLeave, Maternity Leave,Paternity Leave
    protected void bind_EL_CLSL_ML_PL()
    {
        DataSet ds = new DataSet();
        DataSet ds_1 = new DataSet();
        DataSet ds_2 = new DataSet();
        DataSet ds_3 = new DataSet();

        string sqlstr = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + _userCode + "' and cl.displayleave='EL'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_EL.Text = ds.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_EL.Text = "!!";
        }

        string sqlstr_1 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + _userCode + "' and cl.displayleave='CL & SL'";
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            lbl_CL_SL.Text = ds_1.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_CL_SL.Text = "!!";
        }

        string sqlstr_2 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + _userCode + "' and cl.displayleave='ML'";
        ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            lbl_ML.Text = ds_2.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_ML.Text = "!!";
        }

        string sqlstr_3 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + _userCode + "' and cl.displayleave='PL'";
        ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        if (ds_3.Tables[0].Rows.Count > 0)
        {
            lbl_PL.Text = ds_3.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_PL.Text = "!!";
        }


        if (gender == "M")
        {
            row_PL_1.Visible = true;
            row_PL_2.Visible = true;
        }
        else if (gender == "F")
        {
            row_ML_1.Visible = true;
            row_ML_2.Visible = true;
        }
        else
        {
            row_PL_1.Visible = false;
            row_PL_2.Visible = false;
            row_ML_1.Visible = false;
            row_ML_2.Visible = false;
        }

    }
    #endregion

    #region Binding of HeadCount,Joinings,Exits,AppraisalDue
    protected void bind_HeadCount_Joinings_Exits()
    {
        DataSet ds_11 = new DataSet();

        string sqlstr_11 = @"select ej.empcode empcode,emp_fname as name,designationname,photo,isnull(mode,'') as mode from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + _userCode + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null and ej.status=1 order by emp_fname";
        ds_11 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_11);

        if (ds_11.Tables[0].Rows.Count > 0)
        {
            DataSet ds_12 = new DataSet();

            string sqlstr_12 = @"select COUNT(*)[TotalHeadCount] from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + _userCode + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null and ej.status=1 select count(*)[JoiningsThisMonth]  from tbl_intranet_employee_jobDetails ej inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + _userCode + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null and emp_status=1 and DATEPART(MONTH,emp_doj) in (select MONTH(GETDATE())) and DATEPART(YEAR,emp_doj) in (select YEAR(GETDATE())) select count(*)[ExitsThisMonth]  from tbl_intranet_employee_jobDetails ej inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + _userCode + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is not null and emp_status=2 and DATEPART(MONTH,emp_doj) in (select MONTH(GETDATE())) and DATEPART(YEAR,emp_doj) in (select YEAR(GETDATE()))";
            ds_12 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_12);
            lbl_headcount.Text = ds_12.Tables[0].Rows[0]["TotalHeadCount"].ToString();
            lbl_joining.Text = ds_12.Tables[1].Rows[0]["JoiningsThisMonth"].ToString();
            lbl_exits.Text = ds_12.Tables[2].Rows[0]["ExitsThisMonth"].ToString();
        }
        else
        {
            DataSet ds = new DataSet();
            DataSet ds_1 = new DataSet();
            DataSet ds_2 = new DataSet();

            string sqlstr = @"select count(*)[TotalHeadCount] from tbl_intranet_employee_jobDetails where emp_doleaving is null and status=1";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            lbl_headcount.Text = ds.Tables[0].Rows[0]["TotalHeadCount"].ToString();

            string sqlstr_1 = @"select count(*)[JoiningsThisMonth]
from tbl_intranet_employee_jobdetails where emp_doleaving is null and emp_status=1 
and DATEPART(MONTH,emp_doj) in (select MONTH(GETDATE())) and DATEPART(YEAR,emp_doj) in (select YEAR(GETDATE()))";
            ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
            lbl_joining.Text = ds_1.Tables[0].Rows[0]["JoiningsThisMonth"].ToString();

            string sqlstr_2 = @"select count(*)[ExitsThisMonth] from tbl_intranet_employee_jobdetails where emp_doleaving is not null and emp_status=2 
and DATEPART(MONTH,emp_doj) in (select MONTH(GETDATE())) and DATEPART(YEAR,emp_doj) in (select YEAR(GETDATE()))";
            ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
            lbl_exits.Text = ds_2.Tables[0].Rows[0]["ExitsThisMonth"].ToString();
        }
    }
    #endregion

    #region Binding of AwardsAndRecognition
    protected void bind_AwardsAndRecognition()
    {
        DataSet ds = new DataSet();
        string sqlstr = @"select id,heading,description,postedby,posteddate,run_status,category,priority,Upload from NEWSROOM order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_award_heading.Text = ds.Tables[0].Rows[0]["heading"].ToString();
            lbl_award_heading_1.Text = ds.Tables[0].Rows[0]["heading"].ToString();
            lbl_award_description.Text = ds.Tables[0].Rows[0]["description"].ToString();
            lbl_award_description_1.Text = ds.Tables[0].Rows[0]["description"].ToString();
            Session["awardsID"] = ds.Tables[0].Rows[0]["id"].ToString();
        }
    }
    #endregion

    #region Binding of Employee Status

    protected void bind_Employee_Status(string emp_role)
    {
        try
        {
            connection = activity.OpenConnection();
            DataSet ds_12 = new DataSet();
            DataSet ds_13 = new DataSet();
            DataSet ds_14 = new DataSet();
            DataSet ds_15 = new DataSet();
            DataSet ds_16 = new DataSet();
            DataSet ds_17 = new DataSet();

            if (emp_role == "3")
            {
                string sqlstr_12 = @"select COUNT(*)[Present] from tbl_payroll_employee_attendence_detail 
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE IN ('MM', 'P/A', 'HF')";
                ds_12 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_12);
                lbl_Present.Text = ds_12.Tables[0].Rows[0]["Present"].ToString();

                string sqlstr_13 = @"select COUNT(*)[OnLeave] from tbl_payroll_employee_attendence_detail 
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) 
and MODE in('Leaves','PBL','ML','PL','EL','EL(HF)','PBL(HF)','CL & SL(HF)','CL & SL')";
                ds_13 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_13);
                lbl_OnLeave.Text = ds_13.Tables[0].Rows[0]["OnLeave"].ToString();

                string sqlstr_14 = @"select COUNT(*)[WFH] from tbl_payroll_employee_attendence_detail 
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('WFH')";
                ds_14 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_14);
                lbl_WFH.Text = ds_14.Tables[0].Rows[0]["WFH"].ToString();

                string sqlstr_15 = @"select COUNT(*)[LateComers] from tbl_payroll_employee_attendence_detail 
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('A/P')";
                ds_15 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_15);
                lbl_LateComers.Text = ds_15.Tables[0].Rows[0]["LateComers"].ToString();

                string sqlstr_16 = @"select COUNT(*)[OD] from tbl_payroll_employee_attendence_detail 
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('OD')";
                ds_16 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_16);
                lbl_OD.Text = ds_16.Tables[0].Rows[0]["OD"].ToString();

                string sqlstr_17 = @"select COUNT(*)[CompOff] from tbl_payroll_employee_attendence_detail 
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('CO','CO(HF)')";
                ds_17 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_17);
                lbl_CompOff.Text = ds_17.Tables[0].Rows[0]["CompOff"].ToString();
            }
            if (emp_role == "13")
            {
                string sqlstr_12 = @"select COUNT(*)[Present] from tbl_payroll_employee_attendence_detail 
inner join tbl_employee_approvers on tbl_employee_approvers.empcode=tbl_payroll_employee_attendence_detail.empcode
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE IN ('MM', 'P/A', 'HF') and tbl_employee_approvers.app_reportingmanager='"+_userCode+"'";
                ds_12 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_12);
                lbl_Present.Text = ds_12.Tables[0].Rows[0]["Present"].ToString();

                string sqlstr_13 = @"select COUNT(*)[OnLeave] from tbl_payroll_employee_attendence_detail 
inner join tbl_employee_approvers on tbl_employee_approvers.empcode=tbl_payroll_employee_attendence_detail.empcode
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) 
and MODE in('Leaves','PBL','ML','PL','EL','EL(HF)','PBL(HF)','CL & SL(HF)','CL & SL') and tbl_employee_approvers.app_reportingmanager='" + _userCode + "'";
                ds_13 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_13);
                lbl_OnLeave.Text = ds_13.Tables[0].Rows[0]["OnLeave"].ToString();

                string sqlstr_14 = @"select COUNT(*)[WFH] from tbl_payroll_employee_attendence_detail 
inner join tbl_employee_approvers on tbl_employee_approvers.empcode=tbl_payroll_employee_attendence_detail.empcode
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('WFH') and tbl_employee_approvers.app_reportingmanager='" + _userCode + "'";
                ds_14 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_14);
                lbl_WFH.Text = ds_14.Tables[0].Rows[0]["WFH"].ToString();

                string sqlstr_15 = @"select COUNT(*)[LateComers] from tbl_payroll_employee_attendence_detail 
inner join tbl_employee_approvers on tbl_employee_approvers.empcode=tbl_payroll_employee_attendence_detail.empcode
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('A/P') and tbl_employee_approvers.app_reportingmanager='" + _userCode + "'";
                ds_15 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_15);
                lbl_LateComers.Text = ds_15.Tables[0].Rows[0]["LateComers"].ToString();

                string sqlstr_16 = @"select COUNT(*)[OD] from tbl_payroll_employee_attendence_detail 
inner join tbl_employee_approvers on tbl_employee_approvers.empcode=tbl_payroll_employee_attendence_detail.empcode
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('OD') and tbl_employee_approvers.app_reportingmanager='" + _userCode + "'";
                ds_16 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_16);
                lbl_OD.Text = ds_16.Tables[0].Rows[0]["OD"].ToString();

                string sqlstr_17 = @"select COUNT(*)[CompOff] from tbl_payroll_employee_attendence_detail 
inner join tbl_employee_approvers on tbl_employee_approvers.empcode=tbl_payroll_employee_attendence_detail.empcode
where convert(varchar(20),DATE,106)=convert(varchar(20),GETDATE(),106) and MODE in('CO','CO(HF)') and tbl_employee_approvers.app_reportingmanager='" + _userCode + "'";
                ds_17 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_17);
                lbl_CompOff.Text = ds_17.Tables[0].Rows[0]["CompOff"].ToString();
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            activity.CloseConnection();
        }
    }

    #endregion

    #region Binding of NewsAndUpdates
    protected void bind_NewsAndUpdates()
    {
        DataSet ds = new DataSet();
        string sqlstr = @"select id,type,subject,description,upload,postedby,posteddate from tbl_intranet_catalogs order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_news_heading.Text = ds.Tables[0].Rows[0]["subject"].ToString();
            lbl_news_heading_1.Text = ds.Tables[0].Rows[0]["subject"].ToString();
            lbl_news_description.Text = ds.Tables[0].Rows[0]["description"].ToString();
            lbl_news_description_1.Text = ds.Tables[0].Rows[0]["description"].ToString();
            Session["NewsID"] = ds.Tables[0].Rows[0]["id"].ToString();
        }
    }
    #endregion

    #region Binding of Birthdaywishes
    private void GetBirthdayAnniversaries()
    {
        try
        {
            connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_GetCelabrationDetail");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewState["EmpBrt"] = ds;
                ViewState["email"] = ds.Tables[0].Rows[0]["email_id"].ToString();
                string email = ViewState["email"].ToString();
                System.Text.StringBuilder str = new System.Text.StringBuilder();
                str.Append("<ul class='width-100 demo'>");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    str.Append("<li class='row'>");
                    str.Append("<div class='col-lg-3 col-md-3 mt-20px transition-3 text-left'>");
                    if (row["photo"].ToString() != "")
                    {
                        //str.Append("<img src='Upload/photo/" + row["photo"].ToString() + "' alt='user' class='radius-50 height-90px width-100px' />");
                        if (File.Exists(Server.MapPath("upload/photo/" + row["photo"].ToString() + "")))
                        {
                            str.Append("<img src='upload/photo/" + row["photo"].ToString() + "' alt='user' class='radius-50 height-90px width-100px' />");
                        }
                        else
                        {
                            str.Append("<img src='upload/photo/image.png' alt='user' class='radius-10 height-90px width-100px' />");
                        }
                    }
                    else
                    {
                        str.Append("<img src='upload/photo/image.png' alt='user' class='radius-10 height-90px width-100px' />");
                    }
                    str.Append("</div>");
                    str.Append("<div class='mt-25px col-lg-9 col-md-9 transition-3 color-fff text-left'>");
                    str.Append("<h6>");
                    str.Append(row["fname"].ToString() + " " + row["lname"].ToString());
                    str.Append("</h6>");
                    str.Append("<p class='color-fff'>");
                    str.Append(row["Occasion"].ToString());
                    str.Append("</p>");
                    str.Append("<small>");
                    str.Append(row["dob"].ToString());
                    str.Append("</small>");
                    str.Append("</div>");
                    str.Append("</li>");
                    str.Append("<li><br/></li>");

                }
                str.Append("</ul>");
                Session["Birthday"] = str.ToString();
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

    #region Binding of NewJoinedEmployees
    private void GetNewJoinedEmployee()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select empcode,emp_fname,emp_m_name,convert(varchar(20),emp_doj,106) as dateofjoin,photo,emp_status,Status from tbl_intranet_employee_jobdetails
where emp_status=1 and emp_doleaving is null and Status=1 and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables.Count > 0)
            {
                ViewState["NewEmp"] = ds;
                System.Text.StringBuilder str = new System.Text.StringBuilder();
                str.Append("<ul class='demo'>");

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    str.Append("<li class='row'>");
                    str.Append("<div class='col-lg-3 col-md-3 mt-20px transition-3 text-justify'>");
                    if (row["photo"].ToString() != "")
                    {
                        //str.Append("<img src='Upload/photo/" + row["photo"].ToString() + "' alt='user' class='radius-50 height-90px width-100px' />");
                        if (File.Exists(Server.MapPath("upload/photo/" + row["photo"].ToString() + "")))
                        {
                            str.Append("<img src='upload/photo/" + row["photo"].ToString() + "' alt='user' class='radius-50 height-90px width-100px' />");
                        }
                        else
                        {
                            str.Append("<img src='upload/photo/image.png' alt='user' class='radius-10 height-90px width-100px' />");
                        }
                    }
                    else
                    {
                        str.Append("<img src='Upload/photo/image.png' alt='user' class='radius-10 height-90px width-100px' />");
                    }
                    str.Append("</div>");
                    str.Append("<div class='mt-35px col-lg-9 col-md-9 transition-3 color-black text-left'>");
                    str.Append("<h6>");
                    str.Append(row["emp_fname"].ToString() + " " + row["emp_m_name"].ToString());
                    str.Append("</h6>");
                    str.Append("<label class='fs-15 color-red'>");
                    str.Append(row["dateofjoin"].ToString());
                    str.Append("</label>");
                    str.Append("<br /><br />");
                    str.Append("</div>");
                    str.Append("</li>");
                    str.Append("<li><hr /></li>");
                }
                str.Append("</ul>");
                Session["NewEmployee"] = str.ToString();
            }
            else
            {

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

    #region Birthday wish by sending mail using button click

    protected void btnwish_Click(object sender, EventArgs e)
    {
        // Add Fake Delay to simulate long running process.
        //System.Threading.Thread.Sleep(5000);

        string sqlstr = @"SELECT jd.empcode,coalesce(jd.emp_fname,'') + '' + coalesce(jd.emp_m_name,'') +'' + coalesce(jd.emp_l_name,'') as name,  
jd.photo,jd.official_email_id,dept.department_name,
(CASE WHEN pd.dob='01/01/1900' then '' else DATENAME(MM, pd.dob) + ' ' + CAST(DAY(pd.dob) AS VARCHAR(2)) end) dob,
pd.mobile_no,pd.email_id as p_email,'Birthday' as Occasion,sw.empcode as sent2emp
FROM dbo.tbl_intranet_employee_jobDetails jd
INNER JOIN dbo.tbl_intranet_employee_personalDetails pd ON pd.empcode=jd.empcode and jd.emp_doleaving is null and jd.status=1
INNER JOIN dbo.tbl_internate_departmentdetails dept ON dept.departmentid=jd.dept_id
left outer join tbl_sentwishes sw on sw.empcode=jd.empcode and sw.occasion='Birthday' and YEAR(sentdate)=YEAR(GETDATE())
where month(dob)=MONTH(GETDATE()) and DAY(dob)=DAY(GETDATE())";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                if (ds1.Tables[0].Rows[i]["official_email_id"].ToString() != "")
                {
                    string empname = ds1.Tables[0].Rows[i]["name"].ToString();
                    string emailTo = ds1.Tables[0].Rows[i]["official_email_id"].ToString();
                    string photo = ds1.Tables[0].Rows[i]["photo"].ToString();

                    try
                    {
                        sendmail_Template(emailTo, empname, photo, System.DateTime.Now.ToString("dd'th' MMMMMMMMM,yyyy"), "connect@escalon.services", "Escalon2017$", "secure.emailsrvr.com", 25, "Greeting From Escalon");
                    }
                    catch
                    {
                        Response.Redirect("DashBoard_Demo.aspx?sent=no");
                    }
                }
            }
            Response.Redirect("DashBoard_Demo.aspx?sent=true");
        }
    }

    public bool sendmail_Template(string recievermailid, string empname, string photo, string bodyText, string fromemail, string password, string hostname, int portno, string wishes)
    {
        try
        {
            //MailMessage message = new MailMessage();
            //message.To.Add(recievermailid);// Email-ID of Receiver  
            //message.Subject = wishes;// Subject of Email  
            //message.From = new
            //System.Net.Mail.MailAddress("connect@escalon.services");// Email-ID of Sender  

            //message.IsBodyHtml = true;
            //message.AlternateViews.Add(EmailTemplate(empname, bodyText, photo));

            //SmtpClient SmtpMail = new SmtpClient();
            //SmtpMail.Host = "secure.emailsrvr.com";//name or IP-Address of Host used for SMTP transactions  
            //SmtpMail.Port = 25;//Port for sending the mail  
            //SmtpMail.Credentials = new
            //System.Net.NetworkCredential("connect@escalon.services", "Escalon2017$");//username/password of network, if apply  
            //SmtpMail.DeliveryMethod = SmtpDeliveryMethod.Network;
            //SmtpMail.EnableSsl = true;
            //SmtpMail.ServicePoint.MaxIdleTime = 0;
            //SmtpMail.ServicePoint.SetTcpKeepAlive(true, 2000, 2000);
            //message.BodyEncoding = Encoding.Default;
            //message.Priority = MailPriority.High;

            string senderId = ConfigurationManager.AppSettings["fromEmail"]; // Sender EmailID
            string senderPassword = ConfigurationManager.AppSettings["pwd"]; // Sender Password   
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);
            mailMessage.Subject = wishes;// Subject of Email  
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.AlternateViews.Add(EmailTemplate(empname, bodyText, photo));
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtpClient.Host = ConfigurationManager.AppSettings["smtp"];

            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            object userState = mailMessage;

            try
            {
                smtpClient.Send(mailMessage); //Smtpclient to send the mail message  
                return true;
            }
            catch (System.Net.Mail.SmtpException)
            {
                Output.Show("Message Not Sent.Please contact system admin.For error details please go through the log file");
                return false;
            }
        }
        catch (Exception)
        {
            return false;
        }

    }

    private AlternateView EmailTemplate(string empname, string bdate, string employephoto)
    {
        string EmailFormat = "<table style='width: 100%;'>" +
                "<tr>" +
                    "<td style='padding:35px 35px 35px 35px;'>" +
                       "<table style='width: 100%; border-top: 24px solid #f6ae2b; border-right: 6px solid #f6ae2b; border-left: 6px solid #f6ae2b' cellspacing='0' cellpadding='0'>" +
                        "<tr>" +
                         "<td>" +
                            "<table style='width: 100%;' cellspacing='0'>" +
                                "<tr>" +
                                    "<td style='text-align: right;'>" +
                                          "<img src=cid:logo alt='user' style='padding-right: 20px; padding-top: 20px' />" +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='text-align: right;'>" +
                                        "<asp:Label ID='lbldate' runat='server' Style='float: right; padding-right: 20px; padding-top: 20px; font-weight: 800; font-size: 18px; color: #264aa0;'>" + bdate + "</asp:Label> " +
                                    "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td style='padding: 70px 20px 70px 20px; text-align: center'>" +
                                        "<img src=cid:empimage alt='User' style='border-radius: 12px; height: 140px; width: 150px; border: 3px solid #264aa0' />" +
                                    "</td>" +
                                "</tr>" +
                            "</table>" +
                        "</td>" +
                     "</tr>" +
                     "<tr>" +
                        "<td>" +
                            "<p style='padding-left: 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                               " Dear <asp:Label ID='lblname' runat='server'>" + empname + "</asp:Label>" +
                            "</p>" +
                           " <p style='padding:10px 20px 5px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                                "On behalf of Escalon we wish you a very Happy Birthday!" +
                            "</p>" +
                            "<p style='padding:10px 20px 5px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                                "On this wonderful day we’d like you to know that your contribution is most valued and appreciated." +
                            "</p>" +
                            "<p style='padding:10px 20px 5px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                                "Hope all your fondest wishes come true and the day becomes as special as you are." +
                            "</p>" +
                            "<p style='padding:10px 20px 5px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                               "Wish you great accomplishments in your career. May you continue to achieve great success!" +
                            "</p>" +
                            "<p style='padding:10px 20px 5px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                                "Have a great day! Keep smiling and shining Always!" +
                            "</p>" +
                            "<p style='padding:30px 20px 5px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                                "Thanks & Regards," +
                            "</p>" +
                            "<p style='padding:10px 20px 25px 20px; color: #2f8fe0; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif; font-style: oblique;'>" +
                                "HR Department" +
                            "</p>" +
                        "</td>" +
                     "</tr>" +
                     "<tr>" +
                        "<td style='background-color: #f6ae2b;'>" +
                        "<br/>" +
                            "<hr style='background-color: #f6ae2b; height: 3px; border-top: 2px dashed #303030; border-bottom: 2px dashed #303030;' />" +
                            "<p style='padding:20px 15px 10px 15px; color: #303030; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif;'>" +
                                "DISCLAIMER: Escalon is a Limited Liability company registered under the laws of the India" +
                            "</p>" +
                            "<p style='padding:10px 15px 10px 15px; color: #303030; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif;'>" +
                                "This e-mail and the information in it is confidential and may be legally privileged and for the sole purpose of the intended recipient. If you are not the intended recipient or have received this e-mail in error, you must not read, use or disseminate the email or the information contained in it and must promptly notify the sender via e-mail and delete this email immediately." +
                            "</p>" +
                            "<p style='padding:10px 15px 25px 15px; padding-bottom: 15px; color: #303030; font-size: 23px; text-align: justify; font-family: New Century Schoolbook, TeX Gyre Schola, serif;'>" +
                                "This email and any attachments are believed to be free of any virus or other defect that might affect any computer system into which it is received and opened, it is the responsibility of the recipient to ensure that it is virus free and no responsibility is accepted by Escalon or its affiliates for loss or damage arising from its use." +
                            "</p>" +
                            "<hr style='background-color: #f6ae2b; height: 3px; border-top: 2px dashed #303030; border-bottom: 2px dashed #303030;' />" +
                            "<br/><br/>" +
                        "</td>" +
                    "</tr>" +
                 "</table>" +
               "</td>" +
             "</tr>" +
          "</table>";


        string path = Server.MapPath(@"upload/logo/escalon-logo.png");
        LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
        Img.ContentId = "logo";
        AlternateView AV = AlternateView.CreateAlternateViewFromString(EmailFormat, null, MediaTypeNames.Text.Html);
        AV.LinkedResources.Add(Img);

        string path2 = Server.MapPath(@"upload/photo/" + employephoto + "");
        LinkedResource Img2 = new LinkedResource(path2, MediaTypeNames.Image.Jpeg);
        Img2.ContentId = "empimage";
        AV.LinkedResources.Add(Img2);

        return AV;


    }

    #endregion

    #region Binding of Alerts Notification

    private void GetPendingLeaveDetailsByAdmin()
    {
        string sqlleavepending = @"select COUNT(*)[LeaveStatus]
from tbl_leave_apply_leave applyl
inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (0,4)";
        DataSet ds_leave_pending = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlleavepending);
        lblleave_pending.Text = ds_leave_pending.Tables[0].Rows[0]["LeaveStatus"].ToString();
    }

    private void bindAllQueryStatus()
    {
        string query_sqlstr = @"SELECT COUNT(*)[status] FROM tbl_query_raised_queries rq INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=rq.approverCode 
INNER JOIN dbo.tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id 
where rq.empCode='" + _userCode + "'and rq.status=0 SELECT COUNT(*)[status] FROM tbl_query_raised_queries rq INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=rq.approverCode INNER JOIN tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id where rq.empCode='" + _userCode + "'and rq.status=1";

        DataSet ds_query = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, query_sqlstr);

        if (ds_query.Tables[0].Rows.Count > 0)
        {
            lbl_allquery_pending_status.Text = ds_query.Tables[0].Rows[0]["status"].ToString();
            lbl_allquery_approved_status.Text = ds_query.Tables[1].Rows[0]["status"].ToString();
        }
    }

    private void getActiveCycle()
    {
        try
        {
            connection = activity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1";
            int cnt = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, str1);
            if (cnt > 0)
            {
                int cycle = (int)SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    Session["appcycle"] = cycle;
                }
                else
                {
                    Output.Show("Please Mark Active Appraisal Cycle");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void GetAppraisalPerformance()
    {
        try
        {
            connection = activity.OpenConnection();
            string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query1);
            string quater = ds.Tables[0].Rows[0]["quater"].ToString();
            string APP_year = ds.Tables[0].Rows[0]["APP_year"].ToString();

            if (ds.Tables[0].Rows.Count > 0)
            {
                string appraisal_sqlstr = @"select empappr.appcycle_id,isnull(emp_fname ,'')+'' +isnull( emp_m_name,'')+ '' +isnull( emp_l_name,'') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,(case when appast.G1_cycle='0' then 'Not Inititated' 
when appast.G1_cycle='1' then 'Initiated' end )as GoalStatus,
(case when R_cycle='0' then 'Pending' when appast.R_cycle='1'  then 'Pending' when   R_cycle='2' then 'Pending at LM'
when   R_cycle='3' then 'Pending at BH' when   R_cycle='4' then 'Rating Completed' end )as RatingStatus,
(case when  appast.I_cycle=0  then 'Not Inititated' when appast.I_cycle=1  then 'Inititated' end )as IncreamentStatus,
empappr.status                  
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment appast on appast.empcode=empappr.empcode
inner join tbl_appraisal_rating_details_1 rating on rating.empcode=appast.empcode and appast.quater=rating.quater and appast.APP_year=rating.APP_year
and empappr.appcycle_id =appast.appcycle_id
where 1=1 AND rating.empcode='" + _userCode + "'and empappr.appcycle_id='" + Convert.ToInt32(Session["appcycle"]) + "' and rating.quater='" + quater + "' and rating.APP_year='" + APP_year + "' ";
                DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, appraisal_sqlstr);
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    lbl_Appraisal_status.Text = ds1.Tables[0].Rows[0]["GoalStatus"].ToString();
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
    }

    #endregion

    #region Binding of Calendar

    private string CreateEvents()
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            adapter.SelectCommand = new SqlCommand("select date,name from dbo.tbl_leave_holiday", connection);
            adapter.Fill(ds);
            connection.Close();
            for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
            {
                str = ds.Tables[0].Rows[j]["name"].ToString();
                DateTime birthDate = Convert.ToDateTime(ds.Tables[0].Rows[j]["date"]);

                var year = birthDate.Year;
                var month = birthDate.Month - 1;
                var day = birthDate.Day;

                eventData = "{title:'" + str.ToString() + "', start:new Date (" + year.ToString() + "," + month.ToString() + "," + day.ToString() + "), color: '#3AB093'}";

                if (j == 0)
                {
                    finaleventdata = finaleventdata + eventData;
                }
                else
                {
                    finaleventdata = finaleventdata + "," + eventData;
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
        return finaleventdata;
    }

    private string GenerateEvents(string events)
    {
        string sript = @" $(document).ready(function () {
            
            var calendar = $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                selectable: true,
                selectHelper: true,
                select: function (start, end, allDay) {
                    var title = prompt('Event Title:');
                    if (title) {
                        calendar.fullCalendar('renderEvent',
                            {
                                title: title,
                                start: start,
                                end: end,
                                allDay: allDay
                            },
                            true
                        );
                    }
                    calendar.fullCalendar('unselect');
                },
                editable: true,

                events: [
                    " + events + @"]

            });
        });
  ";

        return sript;
    }

    #endregion

}