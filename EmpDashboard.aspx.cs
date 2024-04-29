using Common.Console;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using DataAccessLayer;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Net.Mail;


public partial class EmpDashboard : System.Web.UI.Page
{
    string str, eventData, finaleventdata;
    string sqlstr, dept_value;
    DataActivity activity = new DataActivity();
    SqlConnection _Connection = new SqlConnection();

    string _companyId, _userCode, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "Calander", GenerateEvents(CreateEvents()), true);
        if (Session["role"] == null)
            Response.Redirect("Default.aspx?logout=true");
        RoleId = Session["rolename"].ToString();
        if (Session["companyid"] == null)
            Response.Redirect("Default.aspx?logout=true");

        alertOnTime.Visible = false;
        alertLate15.Visible = false;
        alertLate30.Visible = false;

        managerDiv.Visible = false;

        if (Session["empcode"] == null)
            Response.Redirect("Default.aspx?logout=true");
        //ForReporteeLeave.Visible = false;

        if (RoleId == "SUPER ADMIN")
        {// this is done to check the working of my reportee leave balance, delete the code below once the testing is done.
            managerDiv.Visible = true;
            //
        }
        else if (RoleId == "USER")
        {
            divattendance.Visible = false;
            divAttendnace2.Visible = false;
            teamAttendance.Visible = false;
            div13.Visible = false;

            //attritionReport.Visible = false;
        }
        else if (RoleId == "INDIA MANAGING DIRECTOR" || RoleId == "LINE MANAGER" || RoleId == "FINANCE SPOC" || RoleId == "ADMIN SPOC" || RoleId == "BUSINESS HEAD" || RoleId == "HR-TALENT ACQUISITION" || RoleId == "NEW EMPLOYEE LOGIN" || RoleId == "ADMIN LINE ")
        {
            divattendance.Visible = false;
            divAttendnace2.Visible = false;
            teamAttendance.Visible = false;
            div13.Visible = true;
            managerDiv.Visible = true;
        }
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        // test code 1 start
        Session["empcodeReportee"] = "EIN1001";
        Session["genderReportee"] = "Female";
        string test = (Session["genderReportee"]).ToString();
        string test1 = (Session["empcodeReportee"]).ToString();
        // test code 1 end
        RoleId = Session["rolename"].ToString();
        if (!IsPostBack)
        {
            BindLoginAlert();
            BindReportee();
            BindDept();
            GetBirthdayAnniversaries();
            GetAttendance();
            BindNumberOfReportees();
            BindNumberOfReporteesPresent();
            GetPendingLeaveDetailsByAdmin();
            BindIntoEmpPieChartData1();
            BindIntoEmpPieChartData2();
            BindIntoEmpPieChartData3();
            if (RoleId == "CEO")
            {
                divAlertsUser.Visible = false;
                divCalendar.Visible = false;
                Div4.Visible = false;
                GetPendingLeaveDetailsByAdmin();
                GetApprovedLeaveDetailsByAdmin();
                //GetRejectedLeaveDetailsByAdmin();

                GetPendingLeaveDetailByUser();
                GetApprovedLeaveDetailByUser();
                GetRejectedLeaveDetailByUser();
                //CheckResignationRequest();
                //GetPendingODbyAdmin();
                //GetApprovedODbyAdmin();

                //GetPendingODbyUser();
                //GetApprovedODbyUser();
                //GetRejectedODbyUser();

                BindIntoColumnChartTotal();
                BindIntoColumnChartPresent();

                BindIntoColumnChartDepartment1AttendanceTotal();
                BindIntoColumnChartDepartment1AttendancePresent();
                BindIntoColumnChartDepartment2AttendanceTotal();
                BindIntoColumnChartDepartment2AttendancePresent();
                BindIntoColumnChartDepartment3AttendanceTotal();
                BindIntoColumnChartDepartment3AttendancePresent();

                //attritionInNumber();
                //joinedInNumber();

                AttritionDataOverAll();
            }
            else if (RoleId == "SUPER ADMIN")
            {
                divAlertsUser.Visible = false;
                DivAttrn.Visible = true;
                divCalendar.Visible = true;
                div12.Visible = false;
                divStyle.Style.Add("width", "1111px");
                GetPendingLeaveDetailsByAdmin();
                GetApprovedLeaveDetailsByAdmin();
                //GetRejectedLeaveDetailsByAdmin();

                getLMapprbverpedingqueries();
                GetPendingLeaveDetailByUser();
                GetApprovedLeaveDetailByUser();
                GetRejectedLeaveDetailByUser();

                //CheckResignationRequest();
                //GetPendingODbyAdmin();
                //GetApprovedODbyAdmin();

                //GetPendingODbyUser();
                //GetApprovedODbyUser();
                //GetRejectedODbyUser();

                BindIntoColumnChartTotal();
                BindIntoColumnChartPresent();

                BindIntoColumnChartDepartment1AttendanceTotal();
                BindIntoColumnChartDepartment1AttendancePresent();
                BindIntoColumnChartDepartment2AttendanceTotal();
                BindIntoColumnChartDepartment2AttendancePresent();
                BindIntoColumnChartDepartment3AttendanceTotal();
                BindIntoColumnChartDepartment3AttendancePresent();

                //attritionInNumber();
                //joinedInNumber();
                AttritionDataOverAll();
            }
            else if (RoleId == "INDIA MANAGING DIRECTOR")
            {
                div12.Visible = false; ;
                divCalendar.Visible = true;
                divStyle.Style.Add("width", "1111px");
                Div1.Visible = false;
                DivAttrn.Visible = false;
                GetPendingLeaveDetailByUser();
                GetApprovedLeaveDetailByUser();
                GetRejectedLeaveDetailByUser();
                //CheckResignationRequest();
                GetPendingLeaveDetailsByAdmin();
                //GetPendingODbyAdmin();

                //GetPendingODbyUser();
                //GetApprovedODbyUser();
                //GetRejectedODbyUser();

                divnotificationtotal.Visible = true;
            }
            else
            {
                div12.Visible = false; ;
                divCalendar.Visible = true;
                divStyle.Style.Add("width", "1111px");
                Div1.Visible = false;
                DivAttrn.Visible = false;
                GetPendingLeaveDetailByUser();
                GetApprovedLeaveDetailByUser();
                GetRejectedLeaveDetailByUser();
                // CheckResignationRequest();
                getpedingquerydetails();
                getApproveddetails();
                //GetPendingODbyUser();
                //GetApprovedODbyUser();
                //GetRejectedODbyUser();
                getLMapprbverpedingqueries();

                divnotificationtotal.Visible = true;
            }
            LeaveTab2.Visible = false;
            // LeaveTab3.Visible = false;
            //lnkbtnNext2.Visible = false;
            //lnkbtnNext3.Visible = false;
            BindUserDailyLogDetails();
            GetAppraisalPerformance();
            getpedingquerydetails();
            getApproveddetails();
        }
    }

    private void CheckResignationRequest()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        string str = @"select resg.EmpCode,resg.AppliedDate,pro.ResignationId
from tbl_exit_Resignation resg
inner join  tbl_exit_ResignationProcess pro on pro.ResignationId=resg.ResignationId
where pro.Level=1 and pro.ApproverStatus='P'
and CONVERT(varchar(20), DATEADD(day, 2, resg.AppliedDate), 102) = CONVERT(varchar(20), GETDATE(), 102) and resg.Status = 1";
        DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string query = @"select app_dotted_linemanager, emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name
from dbo.tbl_employee_approvers apr 
inner join tbl_intranet_employee_jobDetails ejd on ejd.empcode = apr.empcode
where apr.empcode='" + dr["empcode"].ToString().Trim() + "'declare @dlmCode varchar(50) = (select app_dotted_linemanager from dbo.tbl_employee_approvers apr where apr.empcode='" + dr["empcode"].ToString().Trim() + "') select emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as dlm_name, official_email_id from tbl_intranet_employee_jobDetails where empcode = @dlmCode";
                DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
                DataRow row = ds1.Tables[0].Rows[0];
                string empcode = row["app_dotted_linemanager"].ToString();

                string Query = @"update tbl_exit_ResignationProcess set ApproversCode='" + empcode + "' where Level=1 and ApproverStatus='P' and ResignationId='" + dr["ResignationId"].ToString().Trim() + "'";
                DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

                string query1 = @"update tbl_exit_approverdetails set ApproverCode='" + empcode + "' where WorkFlowId=1 and UserCode='" + dr["EmpCode"].ToString().Trim() + "' ";
                DataSet ds3 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query1);

                string query4 = @"update tbl_exit_Resignation set Status='1' where ResignationId='" + dr["ResignationId"].ToString().Trim() + "'";
                DataSet ds4 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query4);

                string empName = "", dlmName = "", empCode = dr["empcode"].ToString(), dlm_emailId = "";
                if (ds1.Tables[0].Rows.Count > 0)
                    empName = ds1.Tables[0].Rows[0]["name"].ToString();
                if (ds1.Tables[1].Rows.Count > 0)
                {
                    dlmName = ds1.Tables[1].Rows[0]["dlm_name"].ToString();
                    dlm_emailId = ds1.Tables[1].Rows[0]["official_email_id"].ToString();
                }
                sendmail(dlmName, empName, empCode, dlm_emailId);
            }
        }
    }

    private void sendmail(string dlm_name, string emp_name, string emp_code, string dlm_email)
    {
        if (dlm_email != "")
        {
            try
            {
                sendmail_Template(dlm_email, dlm_name, emp_name, emp_code);
            }
            catch (Exception)
            {
                return;
            }
        }
    }

    public bool sendmail_Template(string recievermailid, string approver, string employee, string empCode)
    {
        try
        {
            string senderId = "connect@escalon.services";
            string senderPassword = "Escalon2017$";

            string Template = EmailTemplate(approver, employee, empCode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Resignation Request";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;

            mailMessage.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = 25;
            smtpClient.Host = "secure.emailsrvr.com";
            smtpClient.EnableSsl = true;

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

    public string EmailTemplate(string approver, string employee, string empcode)
    {
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
    "<title>Resignation Request</title>" +
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
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Resignation Request from  " + emp + " - " + empcod + " for Approval / Reject.</p>" +

                                                            "<p>Click here - https://escalon.sdlapps.com </p>" +

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
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may:" +
                                                                            "<br>" +
                                                                                "(1) Call our 24-hour Customer Care or<br>" +
                                                                                "(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>" +
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

    private void BindDept()
    {
        DataSet ds_dept = null;
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();

        //string query = @"SELECT tbl_internate_departmentdetails.departmentid, tbl_internate_departmentdetails.department_name,tbl_internate_departmentdetails.department_code, tbl_internate_departmentdetails.estt_date, tbl_intranet_branch_detail.branch_name FROM tbl_intranet_branch_detail INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_branch_detail.Branch_Id = tbl_internate_departmentdetails.branchid";
        string query = @"select
dd.departmentid, 
dd.dept_type_id,
dd.department_name,
dt.dept_type_name
from 
tbl_internate_departmentdetails dd
inner join tbl_internate_department_type dt
on dt.dept_type_id=dd.dept_type_id";
        ds_dept = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        if (ds_dept.Tables[0].Rows.Count < 1)
            return;
        ddl_department.DataSource = ds_dept;
        ddl_department.DataTextField = "department_name";
        ddl_department.DataValueField = "departmentid";
        ddl_department.DataBind();
        ddl_department.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_department.SelectedValue = ds_dept.Tables[0].Rows[0]["departmentid"].ToString();
    }

    private void AttritionDataOverAll()
    {
        GetNewHires();
        GetExits();
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"SELECT COUNT(*)
   FROM tbl_intranet_employee_jobDetails as J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and emp_doleaving IS NULL and YEAR(J.emp_doj) < YEAR(GETDATE()) OR YEAR(emp_doleaving) = YEAR(GETDATE())";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            Session["TotalEmply"] = ds.Tables[0].Rows[0]["column1"].ToString();

            int totalEmpJan = Convert.ToInt32(Session["TotalEmply"]);
            Session["TotalEmplyJan"] = totalEmpJan;

            int totalEmpFeb = totalEmpJan + Convert.ToInt32(Session["NewHirJan"]) - Convert.ToInt32(Session["ExitJan"]);
            Session["TotalEmplyFeb"] = totalEmpFeb;

            int totalEmpMar = totalEmpFeb + Convert.ToInt32(Session["NewHirFeb"]) - Convert.ToInt32(Session["ExitFeb"]);
            Session["TotalEmplyMar"] = totalEmpMar;

            int totalEmpApr = totalEmpMar + Convert.ToInt32(Session["NewHirMar"]) - Convert.ToInt32(Session["ExitMar"]);
            Session["TotalEmplyApr"] = totalEmpApr;

            int totalEmpMay = totalEmpApr + Convert.ToInt32(Session["NewHirApr"]) - Convert.ToInt32(Session["ExitApr"]);
            Session["TotalEmplyMay"] = totalEmpMay;

            int totalEmpJun = totalEmpMay + Convert.ToInt32(Session["NewHirMay"]) - Convert.ToInt32(Session["ExitMay"]);
            Session["TotalEmplyJun"] = totalEmpJun;

            int totalEmpJul = totalEmpJun + Convert.ToInt32(Session["NewHirJun"]) - Convert.ToInt32(Session["ExitJun"]);
            Session["TotalEmplyJul"] = totalEmpJul;

            int totalEmpAug = totalEmpJul + Convert.ToInt32(Session["NewHirJul"]) - Convert.ToInt32(Session["ExitJul"]);
            Session["TotalEmplyAug"] = totalEmpAug;

            int totalEmpSep = totalEmpAug + Convert.ToInt32(Session["NewHirAug"]) - Convert.ToInt32(Session["ExitAug"]);
            Session["TotalEmplySep"] = totalEmpSep;

            int totalEmpOct = totalEmpSep + Convert.ToInt32(Session["NewHirSep"]) - Convert.ToInt32(Session["ExitSep"]);
            Session["TotalEmplyOct"] = totalEmpOct;

            int totalEmpNov = totalEmpOct + Convert.ToInt32(Session["NewHirOct"]) - Convert.ToInt32(Session["ExitOct"]);
            Session["TotalEmplyNov"] = totalEmpNov;

            int totalEmpDec = totalEmpNov + Convert.ToInt32(Session["NewHirNov"]) - Convert.ToInt32(Session["ExitNov"]);
            Session["TotalEmplyDec"] = totalEmpDec;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

        CalculateAttrition();
    }

    private void CalculateAttrition()
    {
        try
        {
            double AttrnJan = (Convert.ToInt32(Session["TotalEmplyJan"]) + (Convert.ToInt32(Session["TotalEmplyJan"]) + Convert.ToInt32(Session["NewHirJan"]) - Convert.ToInt32(Session["ExitJan"]))) / 2;
            double AttritionJan = Convert.ToInt32(Session["ExitJan"]) / AttrnJan;
            Session["TotalAttrnJanDeci"] = Math.Round(AttritionJan, 3) * 100;
            double dJan = Math.Round(AttritionJan, 3) * 100;
            Session["TotalAttrnJan"] = Convert.ToString(dJan) + "%";

            double AttrnFeb = (Convert.ToInt32(Session["TotalEmplyFeb"]) + (Convert.ToInt32(Session["TotalEmplyFeb"]) + Convert.ToInt32(Session["NewHirFeb"]) - Convert.ToInt32(Session["ExitFeb"]))) / 2;
            double AttritionFeb = Convert.ToInt32(Session["ExitFeb"]) / AttrnFeb;
            Session["TotalAttrnFebDeci"] = Math.Round(AttritionFeb, 3) * 100;
            Session["TotalAttrnFeb"] = Convert.ToString(Math.Round(AttritionFeb, 3) * 100) + "%";

            double AttrnMar = (Convert.ToInt32(Session["TotalEmplyMar"]) + (Convert.ToInt32(Session["TotalEmplyMar"]) + Convert.ToInt32(Session["NewHirMar"]) - Convert.ToInt32(Session["ExitMar"]))) / 2;
            double AttritionMar = Convert.ToInt32(Session["ExitMar"]) / AttrnMar;
            Session["TotalAttrnMarDeci"] = Math.Round(AttritionMar, 3) * 100;
            Session["TotalAttrnMar"] = Convert.ToString(Math.Round(AttritionMar, 3) * 100) + "%";

            double AttrnApr = (Convert.ToInt32(Session["TotalEmplyApr"]) + (Convert.ToInt32(Session["TotalEmplyApr"]) + Convert.ToInt32(Session["NewHirApr"]) - Convert.ToInt32(Session["ExitApr"]))) / 2;
            double AttritionApr = Convert.ToInt32(Session["ExitApr"]) / AttrnApr;
            Session["TotalAttrnAprDeci"] = Math.Round(AttritionApr, 3) * 100;
            Session["TotalAttrnApr"] = Convert.ToString(Math.Round(AttritionApr, 3) * 100) + "%";

            double AttrnMay = (Convert.ToInt32(Session["TotalEmplyMay"]) + (Convert.ToInt32(Session["TotalEmplyMay"]) + Convert.ToInt32(Session["NewHirMay"]) - Convert.ToInt32(Session["ExitMay"]))) / 2;
            double AttritionMay = Convert.ToInt32(Session["ExitMay"]) / AttrnMay;
            Session["TotalAttrnMayDeci"] = Math.Round(AttritionMay, 3) * 100;
            Session["TotalAttrnMay"] = Convert.ToString(Math.Round(AttritionMay, 3) * 100) + "%";

            double AttrnJun = (Convert.ToInt32(Session["TotalEmplyJun"]) + (Convert.ToInt32(Session["TotalEmplyJun"]) + Convert.ToInt32(Session["NewHirJun"]) - Convert.ToInt32(Session["ExitJun"]))) / 2;
            double AttritionJun = Convert.ToInt32(Session["ExitJun"]) / AttrnJun;
            Session["TotalAttrnJunDeci"] = Math.Round(AttritionJun, 3) * 100;
            Session["TotalAttrnJun"] = Convert.ToString(Math.Round(AttritionJun, 3) * 100) + "%";

            double AttrnJul = (Convert.ToInt32(Session["TotalEmplyJul"]) + (Convert.ToInt32(Session["TotalEmplyJul"]) + Convert.ToInt32(Session["NewHirJul"]) - Convert.ToInt32(Session["ExitJul"]))) / 2;
            double AttritionJul = Convert.ToInt32(Session["ExitJul"]) / AttrnJul;
            Session["TotalAttrnJulDeci"] = Math.Round(AttritionJul, 3) * 100;
            Session["TotalAttrnJul"] = Convert.ToString(Math.Round(AttritionJul, 3) * 100) + "%";

            double AttrnAug = (Convert.ToInt32(Session["TotalEmplyAug"]) + (Convert.ToInt32(Session["TotalEmplyAug"]) + Convert.ToInt32(Session["NewHirAug"]) - Convert.ToInt32(Session["ExitAug"]))) / 2;
            double AttritionAug = Convert.ToInt32(Session["ExitAug"]) / AttrnAug;
            Session["TotalAttrnAugDeci"] = Math.Round(AttritionAug, 3) * 100;
            Session["TotalAttrnAug"] = Convert.ToString(Math.Round(AttritionAug, 3) * 100) + "%";

            double AttrnSep = (Convert.ToInt32(Session["TotalEmplySep"]) + (Convert.ToInt32(Session["TotalEmplySep"]) + Convert.ToInt32(Session["NewHirSep"]) - Convert.ToInt32(Session["ExitSep"]))) / 2;
            double AttritionSep = Convert.ToInt32(Session["ExitSep"]) / AttrnSep;
            Session["TotalAttrnSepDeci"] = Math.Round(AttritionSep, 3) * 100;
            Session["TotalAttrnSep"] = Convert.ToString(Math.Round(AttritionSep, 3) * 100) + "%";

            double AttrnOct = (Convert.ToInt32(Session["TotalEmplyOct"]) + (Convert.ToInt32(Session["TotalEmplyOct"]) + Convert.ToInt32(Session["NewHirOct"]) - Convert.ToInt32(Session["ExitOct"]))) / 2;
            double AttritionOct = Convert.ToInt32(Session["ExitOct"]) / AttrnOct;
            Session["TotalAttrnOctDeci"] = Math.Round(AttritionOct, 3) * 100;
            Session["TotalAttrnOct"] = Convert.ToString(Math.Round(AttritionOct, 3) * 100) + "%";

            double AttrnNov = (Convert.ToInt32(Session["TotalEmplyNov"]) + (Convert.ToInt32(Session["TotalEmplyNov"]) + Convert.ToInt32(Session["NewHirNov"]) - Convert.ToInt32(Session["ExitNov"]))) / 2;
            double AttritionNov = Convert.ToInt32(Session["ExitNov"]) / AttrnNov;
            Session["TotalAttrnNovDeci"] = Math.Round(AttritionNov, 3) * 100;
            Session["TotalAttrnNov"] = Convert.ToString(Math.Round(AttritionNov, 3) * 100) + "%";

            double AttrnDec = (Convert.ToInt32(Session["TotalEmplyDec"]) + (Convert.ToInt32(Session["TotalEmplyDec"]) + Convert.ToInt32(Session["NewHirDec"]) - Convert.ToInt32(Session["ExitDec"]))) / 2;
            double AttritionDec = Convert.ToInt32(Session["ExitDec"]) / AttrnDec;
            Session["TotalAttrnDecDeci"] = Math.Round(AttritionDec, 3) * 100;
            Session["TotalAttrnDec"] = Convert.ToString(Math.Round(AttritionDec, 3) * 100) + "%";
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
    }

    private void GetExits()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            string queryJan = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-01-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsJan = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJan);
            Session["ExitJan"] = dsJan.Tables[0].Rows[0]["column1"].ToString();

            string queryFeb = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-02-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsFeb = SQLServer.ExecuteDataset(connection, CommandType.Text, queryFeb);
            Session["ExitFeb"] = dsFeb.Tables[0].Rows[0]["column1"].ToString();

            string queryMar = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-03-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsMar = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMar);
            Session["ExitMar"] = dsMar.Tables[0].Rows[0]["column1"].ToString();

            string queryApr = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-04-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsApr = SQLServer.ExecuteDataset(connection, CommandType.Text, queryApr);
            Session["ExitApr"] = dsApr.Tables[0].Rows[0]["column1"].ToString();

            string queryMay = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-05-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsMay = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMay);
            Session["ExitMay"] = dsMay.Tables[0].Rows[0]["column1"].ToString();

            string queryJun = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-06-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsJun = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJun);
            Session["ExitJun"] = dsJun.Tables[0].Rows[0]["column1"].ToString();

            string queryJul = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-07-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsJul = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJul);
            Session["ExitJul"] = dsJul.Tables[0].Rows[0]["column1"].ToString();

            string queryAug = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-08-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsAug = SQLServer.ExecuteDataset(connection, CommandType.Text, queryAug);
            Session["ExitAug"] = dsAug.Tables[0].Rows[0]["column1"].ToString();

            string querySep = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-09-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsSep = SQLServer.ExecuteDataset(connection, CommandType.Text, querySep);
            Session["ExitSep"] = dsSep.Tables[0].Rows[0]["column1"].ToString();

            string queryOct = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-10-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsOct = SQLServer.ExecuteDataset(connection, CommandType.Text, queryOct);
            Session["ExitOct"] = dsOct.Tables[0].Rows[0]["column1"].ToString();

            string queryNov = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-11-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsNov = SQLServer.ExecuteDataset(connection, CommandType.Text, queryNov);
            Session["ExitNov"] = dsNov.Tables[0].Rows[0]["column1"].ToString();

            string queryDec = @"select count(empcode) from tbl_intranet_employee_jobDetails where MONTH(emp_doleaving) = MONTH('2017-12-18') and YEAR(emp_doleaving) = YEAR(GETDATE()) and emp_doleaving IS NOT NULL";
            DataSet dsDec = SQLServer.ExecuteDataset(connection, CommandType.Text, queryDec);
            Session["ExitDec"] = dsDec.Tables[0].Rows[0]["column1"].ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void GetNewHires()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            string queryJan = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-01-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsJan = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJan);
            lblHirJan.InnerText = dsJan.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirJan"] = dsJan.Tables[0].Rows[0]["column1"].ToString();

            string queryFeb = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-02-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsFeb = SQLServer.ExecuteDataset(connection, CommandType.Text, queryFeb);
            lblHirFeb.InnerText = dsFeb.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirFeb"] = dsFeb.Tables[0].Rows[0]["column1"].ToString();

            string queryMar = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-03-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsMar = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMar);
            lblHirMar.InnerText = dsMar.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirMar"] = dsMar.Tables[0].Rows[0]["column1"].ToString();

            string queryApr = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-04-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsApr = SQLServer.ExecuteDataset(connection, CommandType.Text, queryApr);
            lblHirApr.InnerText = dsApr.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirApr"] = dsApr.Tables[0].Rows[0]["column1"].ToString();

            string queryMay = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-05-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsMay = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMay);
            lblHirMay.InnerText = dsMay.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirMay"] = dsMay.Tables[0].Rows[0]["column1"].ToString();

            string queryJun = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-06-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsJun = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJun);
            lblHirJun.InnerText = dsJun.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirJun"] = dsJun.Tables[0].Rows[0]["column1"].ToString();

            string queryJul = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-07-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsJul = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJul);
            lblHirJul.InnerText = dsJul.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirJul"] = dsJul.Tables[0].Rows[0]["column1"].ToString();

            string queryAug = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-08-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsAug = SQLServer.ExecuteDataset(connection, CommandType.Text, queryAug);
            lblHirAug.InnerText = dsAug.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirAug"] = dsAug.Tables[0].Rows[0]["column1"].ToString();

            string querySep = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-09-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsSep = SQLServer.ExecuteDataset(connection, CommandType.Text, querySep);
            lblHirSep.InnerText = dsSep.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirSep"] = dsSep.Tables[0].Rows[0]["column1"].ToString();

            string queryOct = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-10-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsOct = SQLServer.ExecuteDataset(connection, CommandType.Text, queryOct);
            lblHirOct.InnerText = dsOct.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirOct"] = dsOct.Tables[0].Rows[0]["column1"].ToString();

            string queryNov = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode 
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-11-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsNov = SQLServer.ExecuteDataset(connection, CommandType.Text, queryNov);
            lblHirNov.InnerText = dsNov.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirNov"] = dsNov.Tables[0].Rows[0]["column1"].ToString();

            string queryDec = @"select count(J.empcode) from tbl_intranet_employee_jobDetails J
   INNER JOIN tbl_login as L on J.empcode = L.empcode
   left join tbl_intranet_role on tbl_intranet_role.id = L.role
   WHERE J.status = 1 and J.emp_doleaving is NULL
   and MONTH(emp_doj) = MONTH('2017-12-18') and YEAR(emp_doj) = YEAR(GETDATE())";
            DataSet dsDec = SQLServer.ExecuteDataset(connection, CommandType.Text, queryDec);
            lblHirDec.InnerText = dsDec.Tables[0].Rows[0]["column1"].ToString();
            Session["NewHirDec"] = dsDec.Tables[0].Rows[0]["column1"].ToString();

            //Session["joinedInNumber"] = ds.Tables[0].Rows[0]["column1"].ToString();
            //string test = (Session["joinedInNumber"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void BindUserDailyLogDetails()
    {
        total_hours();
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select ej.empcode empcode,CONVERT(VARCHAR(8),ea.INTIME,108) AS INTIME,CONVERT(VARCHAR(8),ea.OUTTIME,108) 
AS OUTTIME,DATEDIFF(MI,ea.INTIME, ea.OUTTIME)/60.0 AS MinuteDiff 
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and ea.EMPCODE='" + _userCode + "'";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["INTIME"].ToString() != "")
            {
                lblLoginText.Text = ds.Tables[0].Rows[0]["INTIME"].ToString();
                lblLogoutText.Text = ds.Tables[0].Rows[0]["OUTTIME"].ToString();
                lblLoginText.ForeColor = Color.Black;
                lblLogoutText.ForeColor = Color.Black;
            }
            else if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["OUTTIME"].ToString() != "")
            {
                lblLoginText.Text = ds.Tables[0].Rows[0]["INTIME"].ToString();
                lblLogoutText.Text = ds.Tables[0].Rows[0]["OUTTIME"].ToString();
                lblLoginText.ForeColor = Color.Black;
                lblLogoutText.ForeColor = Color.Black;
            }
            else
            {
                lblLoginText.Text = "Not Logged In";
                lblLogoutText.Text = "Not Logged Out";
                lblLoginText.ForeColor = Color.Black;
                lblLogoutText.ForeColor = Color.Black;
            }

            //string logAlertQry = "select earlyin, latein from tbl_leave_attendance where empcode='" + _userCode + "' and DATE=convert(varchar(10),GETDATE(),101)";
            //DataSet dsLogAlert = SQLServer.ExecuteDataset(_Connection, CommandType.Text, logAlertQry);
            //Session["log_time"] = dsLogAlert;

            string query2 = " select t_hours from tbl_break_time where CONVERT(varchar(10),created_date,102) = CONVERT(varchar(10),getdate(),102) and empcode='" + _userCode + "' order by created_date";
            DataSet ds3 = SQLServer.ExecuteDataset(_Connection, CommandType.Text, query2);
            if (ds3.Tables[0].Rows.Count > 0)
            {
                //lblBreakHourText.Text = ds3.Tables[0].Rows[0]["t_hours"].ToString();
            }
            Session["break-Time"] = ds3;
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

    protected void total_hours()
    {
        //string query = "select id from tbl_break_time where empcode='" + _userCode.ToString() + "' and break_out is null";
        //DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

        //Session["id"] = ds.Tables[0].Rows[0]["id"].ToString();

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        string time = "Select CONVERT(varchar, break_in, 108) as break_in,CONVERT(varchar, break_out, 108) as break_out from tbl_break_time where t_hours is null and CONVERT(varchar(10),created_date,102) = CONVERT(varchar(10),getdate(),102) and  empcode='" + _userCode.ToString() + "'";
        DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, time);
        if (ds2.Tables[0].Rows.Count < 1)
            return;
        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            if (ds2.Tables[0].Rows[0]["break_out"].ToString() == "")
                return;

            DateTime login = Convert.ToDateTime(ds2.Tables[0].Rows[0]["break_in"]);
            DateTime logout = Convert.ToDateTime(ds2.Tables[0].Rows[0]["break_out"]);

            TimeSpan ts = logout.Subtract(login);

            string query1 = "update tbl_break_time set t_hours = '" + ts + "' where t_hours is null and empcode='" + _userCode.ToString() + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, query1);
        }

    }

    private void GetApprovedODbyAdmin()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
	od.id id, 
	od.empcode,
	coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
	case when od.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
	case when od.leavemode = 1 then convert(varchar,od.date,101) else convert(varchar,od.hdate,101) end date,
	dbo.getleavestatus(od.leave_status,1) leavestatus,
	od.reason
	
	from tbl_leave_apply_od od
	inner join tbl_od_employee_hierarchy eh on od.id = eh.applyleaveid and eh.approverpriority > od.approval_status
	inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=od.empcode
	where eh.approverid='" + _userCode + "' and eh.hr in (0,1) and od.Approval_status in (1,2,3) and od.leave_status=0 and od.status=1) ApprovedOD";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            //lblODapproved.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblODapproved.Text = "Approved(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetPendingODbyAdmin()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
	od.id id, 
	od.empcode,
	coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
	case when od.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
	case when od.leavemode = 1 then convert(varchar,od.date,101) else convert(varchar,od.hdate,101) end date,
	dbo.getleavestatus(od.leave_status,1) leavestatus,
	od.reason
	
	from tbl_leave_apply_od od
	inner join tbl_od_employee_hierarchy eh on od.id = eh.applyleaveid and eh.approverpriority > od.approval_status
	inner join tbl_employee_jobDetails empmaster on empmaster.empcode=od.empcode
	where eh.approverid='" + _userCode + "' and eh.hr in (0,1) and od.Approval_status in (2) and od.leave_status=0 and od.status=1) PendingOD";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            lblODpending.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label8.Text = ds.Tables[0].Rows[0]["Column1"].ToString();

            string strodLM = @"select count(*) from
(
select
	od.id id, 
	od.empcode,
	coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
	case when od.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
	case when od.leavemode = 1 then convert(varchar,od.date,101) else convert(varchar,od.hdate,101) end date,
	dbo.getleavestatus(od.leave_status,1) leavestatus,
	od.reason
	
	from tbl_leave_apply_od od
	inner join tbl_od_employee_hierarchy eh on od.id = eh.applyleaveid and eh.approverpriority > od.approval_status
	inner join tbl_employee_jobDetails empmaster on empmaster.empcode=od.empcode
	where eh.approverid='" + _userCode + "' and eh.hr in (0,1) and od.Approval_status in (0) and od.leave_status=0 and od.status=1) PendingOD";
            DataSet dsodLM = SQLServer.ExecuteDataset(_Connection, CommandType.Text, strodLM);
            LabelodLM.Text = dsodLM.Tables[0].Rows[0]["Column1"].ToString();
            LblodLM.Text = dsodLM.Tables[0].Rows[0]["Column1"].ToString();

            string strodBH = @"select count(*) from
(
select
	od.id id, 
	od.empcode,
	coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
	case when od.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
	case when od.leavemode = 1 then convert(varchar,od.date,101) else convert(varchar,od.hdate,101) end date,
	dbo.getleavestatus(od.leave_status,1) leavestatus,
	od.reason
	
	from tbl_leave_apply_od od
	inner join tbl_od_employee_hierarchy eh on od.id = eh.applyleaveid and eh.approverpriority > od.approval_status
	inner join tbl_employee_jobDetails empmaster on empmaster.empcode=od.empcode
	where eh.approverid='" + _userCode + "' and eh.hr in (0,1) and od.Approval_status in (1) and od.leave_status=0 and od.status=1) PendingOD";
            DataSet dsodBH = SQLServer.ExecuteDataset(_Connection, CommandType.Text, strodBH);
            LabelodBH.Text = dsodBH.Tables[0].Rows[0]["Column1"].ToString();
            LblodBH.Text = dsodBH.Tables[0].Rows[0]["Column1"].ToString();
            //lblODpending.Text = "Pending(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetRejectedODbyUser()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
applyl.id id, 
empmaster.empcode,
coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
case when applyl.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
case when applyl.leavemode = 1 then convert(varchar, applyl.date,101) else convert(varchar,applyl.hdate,101) end date,
dbo.getleavestatus(applyl.leave_status,1) leavestatus,
applyl.reason
from tbl_leave_apply_od applyl
inner join tbl_employee_jobDetails  empmaster on empmaster.empcode=applyl.empcode
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (3)) YourRejectedOD";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            //lblODrejUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label16.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            lblODrejUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblODrejUser.Text = "Rejected(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetApprovedODbyUser()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
applyl.id id, 
empmaster.empcode,
coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
case when applyl.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
case when applyl.leavemode = 1 then convert(varchar, applyl.date,101) else convert(varchar,applyl.hdate,101) end date,
dbo.getleavestatus(applyl.leave_status,1) leavestatus,
applyl.reason
from tbl_leave_apply_od applyl
inner join tbl_employee_jobDetails  empmaster on empmaster.empcode=applyl.empcode
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (6)) YourApprovedOD";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            //lblODAppdUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label15.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            lblODAppdUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblODAppdUser.Text = "Approved(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetPendingODbyUser()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
applyl.id id, 
empmaster.empcode,
coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
case when applyl.leavemode = 1 then 'Full Day' else 'Half Day' end mode,
case when applyl.leavemode = 1 then convert(varchar, applyl.date,101) else convert(varchar,applyl.hdate,101) end date,
dbo.getleavestatus(applyl.leave_status,1) leavestatus,
applyl.reason
from tbl_leave_apply_od applyl
inner join tbl_employee_jobDetails  empmaster on empmaster.empcode=applyl.empcode
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (0,4)) YourPendingOD";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            //lblODpenUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label14.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            lblODpenUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblODpenUser.Text = "Pending(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetAppraisalPerformance()
    {
        try
        {
            _Connection = activity.OpenConnection();
            sqlstr = "select appcycle_id from tbl_appraisal_cycle where status=1";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            SqlParameter[] sqlparam = new SqlParameter[4];
            SqlConnection Connection = null;

            Connection = activity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, DBNull.Value.ToString());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, ds.Tables[0].Rows[0]["appcycle_id"].ToString());
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");

            DataSet ds1 = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_get_empgoalsbymgr", sqlparam);
            DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_Empformanageratings", sqlparam);
            lblPerformanceAppraisal.Text = ds1.Tables[0].Rows.Count.ToString();
            Label10.Text = ds1.Tables[0].Rows.Count.ToString();

            lblRating.Text = ds2.Tables[0].Rows.Count.ToString();
            LabelRating.Text = ds2.Tables[0].Rows.Count.ToString();
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

    private void GetRejectedLeaveDetailByUser()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
applyl.id id, 
empmaster.empcode,
coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
leavem.leavetype leavename,
dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
applyl.no_of_days nod,
applyl.approvel_status
from tbl_leave_apply_leave applyl
inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (3)) YourRejectedLeave";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            //lblleave235byUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label13.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            lblleave235byUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblleave235byUser.Text = "Rejected(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetApprovedLeaveDetailByUser()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select
applyl.id id, 
empmaster.empcode,
coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
leavem.leavetype leavename,
dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
applyl.no_of_days nod,
applyl.approvel_status
from tbl_leave_apply_leave applyl
inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (6)) YourApprovedLeave";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            Label12.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            lblleave16byUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblleave16byUser.Text = "Approved(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetPendingLeaveDetailByUser()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();

            string sqlstr1 = @"select count(*) as coulmn from
(
select
applyl.id id, 
empmaster.empcode,
coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
leavem.leavetype leavename,
dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
applyl.no_of_days nod,
applyl.approvel_status
from tbl_leave_apply_leave applyl
inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
where applyl.empcode='" + _userCode + "' and applyl.leave_status in (0)) YourPendingLeave";
            // DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr1);
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            //lblleave0byUser.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label11.Text = ds.Tables[0].Rows[0]["coulmn"].ToString();
            lblleave0byUser.Text = ds.Tables[0].Rows[0]["coulmn"].ToString();
            //lblleave0byUser.Text = "Pending(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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

    private void GetPendingLeaveDetailsByAdmin()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select applyl.id id, 
		empmaster.empcode,
		coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
		leavem.leavetype leavename,
		dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
		case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
		case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
		applyl.no_of_days nod ,
		eh.hr
		from tbl_leave_apply_leave applyl 
		inner join tbl_leave_employee_hierarchy eh on applyl.empcode=eh.employeecode and eh.approverpriority=applyl.approvel_status+1 
		inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
		inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
		where 
		eh.approverid='" + _userCode + "' and applyl.approvel_status in (2) and applyl.leave_status=0 and applyl.status=1) TotalPendingLeave";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            lblleave0.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            Label6.Text = ds.Tables[0].Rows[0]["Column1"].ToString();

            string sqlleaveLM = @"select count(*) from
(
select applyl.id id, 
		empmaster.empcode,
		coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
		leavem.leavetype leavename,
		dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
		case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
		case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
		applyl.no_of_days nod ,
		eh.hr
		from tbl_leave_apply_leave applyl 
		inner join tbl_leave_employee_hierarchy eh on applyl.empcode=eh.employeecode and eh.approverpriority=applyl.approvel_status+1 
		inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
		inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
		where 
		eh.approverid='" + _userCode + "' and applyl.approvel_status in (0) and applyl.leave_status=0 and applyl.status=1) TotalPendingLeave";
            DataSet dsLeaveLM = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlleaveLM);
            lblleave0LM.Text = dsLeaveLM.Tables[0].Rows[0]["Column1"].ToString();
            Label1.Text = dsLeaveLM.Tables[0].Rows[0]["Column1"].ToString();

            string sqlleaveBH = @"select count(*) from
(
select applyl.id id, 
		empmaster.empcode,
		coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
		leavem.leavetype leavename,
		dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
		case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
		case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
		applyl.no_of_days nod ,
		eh.hr
		from tbl_leave_apply_leave applyl 
		inner join tbl_leave_employee_hierarchy eh on applyl.empcode=eh.employeecode and eh.approverpriority=applyl.approvel_status+1 
		inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
		inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
		where 
		eh.approverid='" + _userCode + "' and applyl.approvel_status in (1) and applyl.leave_status=0 and applyl.status=1) TotalPendingLeave";
            DataSet dsLeaveBH = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlleaveBH);
            lblleave0BH.Text = dsLeaveBH.Tables[0].Rows[0]["Column1"].ToString();
            Label2.Text = dsLeaveBH.Tables[0].Rows[0]["Column1"].ToString();
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

    private void GetApprovedLeaveDetailsByAdmin()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select count(*) from
(
select applyl.id id, 
		empmaster.empcode,
		coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
		leavem.leavetype leavename,
		dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
		case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
		case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
		applyl.no_of_days nod ,
		eh.hr
		from tbl_leave_apply_leave applyl 
		inner join tbl_leave_employee_hierarchy eh on applyl.empcode=eh.employeecode and eh.approverpriority=applyl.approvel_status+1 and eh.id = applyl.id
		inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
		inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
		where 
		eh.approverid='" + _userCode + "' and applyl.approvel_status in (1,2,3) and eh.hr in(0,1) and applyl.leave_status=1 and applyl.status=1) TotalApprovedLeave";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            //lblleave16.Text = ds.Tables[0].Rows[0]["Column1"].ToString();
            //lblleave16.Text = "Approved(" + ds.Tables[0].Rows[0]["Column1"].ToString() + ")";
            //if (ds.Tables[0].Rows.Count > 0)
            //{

            //}
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


    private void getpedingquerydetails()
    {
        try
        {


            _Connection = activity.OpenConnection();
            sqlstr = "select COUNT(*) as Coulmn from tbl_query_raised_queries where empCode='" + _userCode + "'and status=0 ";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

            // Label13.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();
            Labelqurtupending.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();


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

    private void getApproveddetails()
    {
        try
        {


            _Connection = activity.OpenConnection();
            sqlstr = "select COUNT(*) as Coulmn from tbl_query_raised_queries where empCode='" + _userCode + "'and status=1 ";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

            //  Label13.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();
            ladbelappquery.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();


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

    private void getLMapprbverpedingqueries()
    {
        try
        {


            _Connection = activity.OpenConnection();
            sqlstr = "select COUNT(*) as Coulmn from tbl_query_raised_queries where approverCode='" + _userCode + "'and status=0 ";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

            // Label13.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();
            labelpendingqueries.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();


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

    private void getApproerAprrvedqueries()
    {
        try
        {


            _Connection = activity.OpenConnection();
            sqlstr = "select COUNT(*) as Coulmn from tbl_query_raised_queries where approverCode='" + _userCode + "'and status=1 ";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

            //  Label13.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();
            ladbelappquery.Text = ds.Tables[0].Rows[0]["Coulmn"].ToString();


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

    private void GetAttendance()
    {
        try
        {
            _Connection = activity.OpenConnection();
            string sqlstr = @"select ej.empcode empcode,CONVERT(VARCHAR(8),ea.INTIME,108) AS INTIME,CONVERT(VARCHAR(8),ea.OUTTIME,108) AS OUTTIME,CAST((DATEDIFF(MI,ea.INTIME, ea.OUTTIME)/60.0) as decimal(18,2)) AS MinuteDiff 
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2') and ep.app_reportingmanager='" + _userCode + "' and ep.status=1 order by emp_fname";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            Session["teamReportees"] = ds;
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<ul class='chats'>");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    ds.Tables[0].Columns.Add
                //}

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    //DateTime login = Convert.ToDateTime(row["INTIME"]);
                    //DateTime logout = Convert.ToDateTime(row["OUTTIME"]);
                    //TimeSpan ts = logout.Subtract(login);
                    //if (!(outputParam is DBNull))
                    str.Append("<li>");
                    str.Append(@"<div style=""padding-left:5px;"" class='clr'>");
                    str.Append(row["empcode"].ToString());
                    str.Append(@"<span style=""padding-left:21px;""></span>");
                    str.Append(row["INTIME"].ToString());
                    str.Append(@"<span style=""padding-left:45px;""></span>");
                    str.Append(row["MinuteDiff"].ToString());
                    str.Append(@"<span style=""padding-left:57px;""></span>");
                    str.Append(row["OUTTIME"].ToString());
                    str.Append(@"<span style=""padding-left:47px;""></span>");
                    str.Append(row["MinuteDiff"].ToString());
                    str.Append("</div>");
                    str.Append("</li>");
                }
            }
            str.Append("</ul>");
            Session["TA"] = str.ToString();
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

    private void GetBirthdayAnniversaries()
    {
        try
        {
            _Connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.StoredProcedure, "sp_GetCelabrationDetail");
            ViewState["EmpBrt"] = ds;
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<ul class='chats'>");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                str.Append("<li>");
                str.Append("<div class='user pull-left'>");
                if (row["photo"].ToString() != "")
                    str.Append("<img src='Upload/photo/" + row["photo"].ToString() + "' alt='user'>");
                else
                    str.Append("<img src='upload/photo/image.png' alt='user'>");
                str.Append("</div>");
                str.Append("<div class='info'>");
                str.Append("<h6>");
                str.Append(row["fname"].ToString() + " " + row["lname"].ToString());
                str.Append("</h6>");
                str.Append("<p>");
                str.Append(row["Occasion"].ToString());
                str.Append("</p>");
                str.Append("<small>");
                str.Append(row["dob"].ToString());
                str.Append("</small>");
                str.Append("</div>");
                str.Append("</li>");

            }
            str.Append("</ul>");
            //if (ds == null)
            //{
            //    Session["Birthday"] = "No occasion found!";
            //}
            //else
            //{
            //    Session["Birthday"] = str.ToString();
            //}
            Session["Birthday"] = str.ToString();
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

    #region Leave Report
    [WebMethod]
    public static LeaveBalance[] GetLeaveBalance(string empcode, string gender)
    {
        List<LeaveBalance> details = new List<LeaveBalance>();
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid 
                        inner join tbl_leave_leaveperiod cy on cy.id = 1   
                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('EL','CL & SL') );";

            sqlstr += @"if exists (select 1 from tbl_intranet_employee_jobDetails where empcode = '" + empcode.ToString() + "')";
            sqlstr += @"
select leaveid,
displayleave as leavetype,
0.0 Entitled,
0.0 UsedDays,
0.0 CurBalance 
from tbl_leave_createleave
where leaveid in (1,2)";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
                foreach (DataRow dtrow in ds.Tables[0].Rows)
                {
                    LeaveBalance leavebalance = new LeaveBalance();
                    leavebalance.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                    leavebalance.leavename = dtrow["leavetype"].ToString();
                    leavebalance.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
                    leavebalance.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
                    leavebalance.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
                    details.Add(leavebalance);
                }
            else
                foreach (DataRow dtrow in ds.Tables[1].Rows)
                {
                    LeaveBalance leavebalance = new LeaveBalance();
                    leavebalance.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                    leavebalance.leavename = dtrow["leavetype"].ToString();
                    leavebalance.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
                    leavebalance.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
                    leavebalance.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
                    details.Add(leavebalance);
                }

            //            DataSet ds1 = new DataSet();
            //            string sqlstr1;
            //            if (gender == "Female")
            //            {
            //                sqlstr1 = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
            //                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
            //                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
            //                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
            //                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('PL','ML') );";

            //                sqlstr1 += @"if exists (select 1 from tbl_employee_jobDetails where empcode = '" + empcode.ToString() + "' and emp_gender = 'Female' )";
            //                sqlstr1 += @"
            //select leaveid,
            //displayleave as leavetype,
            //0.0 Entitled,
            //0.0 UsedDays,
            //0.0 CurBalance 
            //from tbl_leave_createleave
            //where leaveid in (1,3)";
            //            }
            //            else
            //            {
            //                sqlstr1 = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
            //                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
            //                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
            //                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
            //                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('PL','ML') );";

            //                sqlstr1 += @"if exists (select 1 from tbl_employee_jobDetails where empcode = '" + empcode.ToString() + "' and emp_gender = 'Male' )";
            //                sqlstr1 += @"
            //select leaveid,
            //displayleave as leavetype,
            //0.0 Entitled,
            //0.0 UsedDays,
            //0.0 CurBalance 
            //from tbl_leave_createleave
            //where leaveid in (1,4)";
            //            }

            //            ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            //            if (ds1.Tables[0].Rows.Count > 0)
            //                foreach (DataRow dtrow in ds1.Tables[0].Rows)
            //                {
            //                    LeaveBalance leavebalance = new LeaveBalance();
            //                    leavebalance.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
            //                    leavebalance.leavename = dtrow["leavetype"].ToString();
            //                    leavebalance.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
            //                    leavebalance.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
            //                    leavebalance.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
            //                    details.Add(leavebalance);
            //                }
            //            else
            //                foreach (DataRow dtrow in ds1.Tables[1].Rows)
            //                {
            //                    LeaveBalance leavebalance = new LeaveBalance();
            //                    leavebalance.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
            //                    leavebalance.leavename = dtrow["leavetype"].ToString();
            //                    leavebalance.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
            //                    leavebalance.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
            //                    leavebalance.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
            //                    details.Add(leavebalance);
            //                }

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
        return details.ToArray();
    }

    public class LeaveBalance
    {
        public int leaveid { get; set; }
        public string leavename { get; set; }
        public decimal entitleddays { get; set; }
        public decimal useddays { get; set; }
        public decimal balance { get; set; }
    }
    #endregion

    #region Leave report1
    //[WebMethod]
    public static LeaveBalance1[] lnkbtnNext1_Click(string empcode, string gender)
    {
        List<LeaveBalance1> details1 = new List<LeaveBalance1>();
        var activity = new DataActivity();
        DataSet ds1 = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr1;
            if (gender == "Female")
            {
                sqlstr1 = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('PL','ML') );";

                sqlstr1 += @"if exists (select 1 from tbl_employee_jobDetails where empcode = '" + empcode.ToString() + "' and emp_gender = 'Female' )";
                sqlstr1 += @"
select leaveid,
displayleave as leavetype,
0.0 Entitled,
0.0 UsedDays,
0.0 CurBalance 
from tbl_leave_createleave
where leaveid in (1,3)";
            }
            else
            {
                sqlstr1 = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('PL','ML') );";

                sqlstr1 += @"if exists (select 1 from tbl_employee_jobDetails where empcode = '" + empcode.ToString() + "' and emp_gender = 'Male' )";
                sqlstr1 += @"
select leaveid,
displayleave as leavetype,
0.0 Entitled,
0.0 UsedDays,
0.0 CurBalance 
from tbl_leave_createleave
where leaveid in (1,4)";
            }

            ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            if (ds1.Tables[0].Rows.Count > 0)
                foreach (DataRow dtrow in ds1.Tables[0].Rows)
                {
                    LeaveBalance1 leaveBalance1 = new LeaveBalance1();
                    leaveBalance1.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                    leaveBalance1.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                    leaveBalance1.leavename = dtrow["leavetype"].ToString();
                    leaveBalance1.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
                    leaveBalance1.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
                    leaveBalance1.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
                    details1.Add(leaveBalance1);
                }
            else
                foreach (DataRow dtrow in ds1.Tables[1].Rows)
                {
                    LeaveBalance1 leaveBalance1 = new LeaveBalance1();
                    leaveBalance1.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                    leaveBalance1.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                    leaveBalance1.leavename = dtrow["leavetype"].ToString();
                    leaveBalance1.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
                    leaveBalance1.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
                    leaveBalance1.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
                    details1.Add(leaveBalance1);
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
        return details1.ToArray();

        //LeaveTab1.Visible = false;
        //LeaveTab2.Visible = true;
        //LeaveTab3.Visible = false;

        //lnkbtnNext1.Visible = false;
        //lnkbtnNext2.Visible = true;
        //lnkbtnNext3.Visible = false;
    }

    public class LeaveBalance1
    {
        public int leaveid { get; set; }
        public string leavename { get; set; }
        public decimal entitleddays { get; set; }
        public decimal useddays { get; set; }
        public decimal balance { get; set; }
    }
    #endregion

    #region columnChart
    protected void BindIntoColumnChartTotal()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode) from  dbo.tbl_intranet_employee_jobDetails ej 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmp"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmp"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void BindIntoColumnChartPresent()
    {
        int totlEmployees;
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode) from tbl_intranet_employee_jobDetails ej 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where ea.MODE in ('P', 'MM', 'A/P')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            int totlPresnt = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);
            Session["prsntEmployee1"] = totlPresnt;
            string totlEmpls = (string)Session["totalEmp"];
            if (Convert.ToInt32(totlEmpls) > 0)
                totlEmployees = Convert.ToInt32(totlEmpls);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresnt) / totlEmployees) * 100;
            Session["totlPrsntinDeci"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeci"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            Session["totalPresentEmp"] = totlPrsntinPrcnt;
            string test = (Session["totalPresentEmp"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion

    #region columnChartDepartment1Attendance
    protected void BindIntoColumnChartDepartment1AttendanceTotal()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        if (ddl_department.SelectedValue == "0")
        {
            dept_value = "4";
        }
        else
        {
            dept_value = ddl_department.SelectedValue;
        }
        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d on d.departmentid = jd.dept_id
INNER JOIN tbl_login as L on jd.empcode = L.empcode

where emp_doleaving is null and jd.status=1 and jd.emp_status!='2' and L.role not in ('2') and jd.dept_id='" + dept_value.Trim() + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            string qry_deptName = @"select department_name from tbl_internate_departmentdetails where departmentid = '" + dept_value.Trim() + "'";
            DataSet ds_deptName = SQLServer.ExecuteDataset(connection, CommandType.Text, qry_deptName);
            if (ds_deptName.Tables[0].Rows.Count < 1 || ds.Tables[0].Rows.Count < 1)
                return;
            Session["dept_name"] = ds_deptName.Tables[0].Rows[0]["department_name"].ToString();

            Session["totalEmpDept1"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpDept1"]).ToString();
            if (ds.Tables[0].Rows[0]["column1"].ToString() == "0")
            {
                tdRecruitment.Visible = false;
                tdRecruitment0.Visible = true;
            }
            else
            {
                tdRecruitment.Visible = true;
                tdRecruitment0.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void BindIntoColumnChartDepartment1AttendancePresent()
    {
        int totlEmployees;
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d
on d.departmentid = jd.dept_id
inner join dbo.tbl_payroll_employee_attendence_detail at
on at.empcode = jd.empcode
where jd.dept_id='" + dept_value.Trim() + "' and CONVERT(varchar(10),at.date,102) = CONVERT(varchar(10),getdate(),102) AND at.MODE in ('P', 'MM', 'A/P')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            int totlPresntDept1 = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);

            Session["prsntEmployee01"] = totlPresntDept1;
            string totlEmplsDept1 = (string)Session["totalEmpDept1"];
            if (Convert.ToInt32(totlEmplsDept1) > 0)
                totlEmployees = Convert.ToInt32(totlEmplsDept1);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresntDept1) / totlEmployees) * 100;
            Session["totlPrsntinDeciDept1"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeciDept1"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            //Session["totalPresentEmp"] = totlPrsntinPrcnt;

            Session["totalPresentEmpDept1"] = totlPrsntinPrcnt;
            string test = (Session["totalPresentEmpDept1"]).ToString();

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region columnChartDepartment2Attendance
    protected void BindIntoColumnChartDepartment2AttendanceTotal()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d on d.departmentid = jd.dept_id
INNER JOIN tbl_login as L on jd.empcode = L.empcode

where emp_doleaving is null and jd.status=1 and jd.emp_status!='2' and L.role not in ('2') and jd.dept_id=5";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmpDept2"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpDept2"]).ToString();
            if (ds.Tables[0].Rows[0]["column1"].ToString() == "0")
            {
                //tdDomestic.Visible = false;
                //tdDomestic0.Visible = true;
            }
            else
            {
                //tdDomestic.Visible = true;
                //tdDomestic0.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void BindIntoColumnChartDepartment2AttendancePresent()
    {
        int totlEmployees;
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d
on d.departmentid = jd.dept_id
inner join dbo.tbl_payroll_employee_attendence_detail at
on at.empcode = jd.empcode
where jd.dept_id=5 and CONVERT(varchar(10),at.date,102) = CONVERT(varchar(10),getdate(),102) AND at.MODE in ('P', 'MM', 'A/P')";


            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            int totlPresntDept2 = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);

            Session["prsntEmployee02"] = totlPresntDept2;
            string totlEmplsDept2 = (string)Session["totalEmpDept2"];
            if (Convert.ToInt32(totlEmplsDept2) > 0)
                totlEmployees = Convert.ToInt32(totlEmplsDept2);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresntDept2) / totlEmployees) * 100;
            Session["totlPrsntinDeciDept2"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeciDept2"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            //Session["totalPresentEmp"] = totlPrsntinPrcnt;

            Session["totalPresentEmpDept2"] = totlPrsntinPrcnt;
            string test = (Session["totalPresentEmpDept2"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion
    #region columnChartDepartment3Attendance
    protected void BindIntoColumnChartDepartment3AttendanceTotal()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d on d.departmentid = jd.dept_id
INNER JOIN tbl_login as L on jd.empcode = L.empcode

where emp_doleaving is null and jd.status=1 and jd.emp_status!='2' and L.role not in ('2') and jd.dept_id=6";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmpDept3"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpDept3"]).ToString();
            if (ds.Tables[0].Rows[0]["column1"].ToString() == "0")
            {
                //tdSF.Visible = false;
                //tdsf0.Visible = true;
            }
            else
            {
                //tdSF.Visible = true;
                //tdsf0.Visible = false;
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void BindIntoColumnChartDepartment3AttendancePresent()
    {
        int totlEmployees;
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d
on d.departmentid = jd.dept_id
inner join dbo.tbl_payroll_employee_attendence_detail at
on at.empcode = jd.empcode
where jd.dept_id=6 and CONVERT(varchar(10),at.date,102) = CONVERT(varchar(10),getdate(),102) AND at.MODE in ('P', 'MM', 'A/P')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            int totlPresntDept3 = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);

            Session["prsntEmployee03"] = totlPresntDept3;
            string totlEmplsDept3 = (string)Session["totalEmpDept3"];
            if (Convert.ToInt32(totlEmplsDept3) > 0)
                totlEmployees = Convert.ToInt32(totlEmplsDept3);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresntDept3) / totlEmployees) * 100;
            Session["totlPrsntinDeciDept3"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeciDept3"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            //Session["totalPresentEmp"] = totlPrsntinPrcnt;

            Session["totalPresentEmpDept3"] = totlPrsntinPrcnt;
            string test = (Session["totalPresentEmpDept3"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion

    #region Login alert
    protected void BindLoginAlert()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            string gettime = @"select convert(varchar(8),earlyin,108) as early, convert(varchar(8),latein,108) as late from tbl_leave_attendance where empcode='" + _userCode + "' and CONVERT(varchar(10),date,102) = CONVERT(varchar(10),getdate(),102)";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, gettime);

            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (ds.Tables[0].Rows[0]["early"].ToString() != "")
            {
                Session["log_time"] = ds.Tables[0].Rows[0]["early"];
                alertLate15.Visible = false;
                alertLate30.Visible = false;
                alertOnTime.Visible = true;
            }
            if (ds.Tables[0].Rows[0]["late"].ToString() != "")
            {
                Session["log_time"] = ds.Tables[0].Rows[0]["late"];
                alertOnTime.Visible = false;
                alertLate15.Visible = true;
                alertLate30.Visible = false;
            }
            //if (Convert.ToDateTime(ds.Tables[0].Rows[0]["time"].ToString()) > Convert.ToDateTime("08:30:00"))
            //{
            //    alertOnTime.Visible = false;
            //    alertLate15.Visible = false;
            //    alertLate30.Visible = true;
            //}

            //Session["log1"] = ds.Tables[0].Rows[0]["column1"].ToString();
            //string test = (Session["log1"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion
    #region BindNumberOfReportees
    protected void BindNumberOfReportees()
    {
        string adminCode = Session["empcode"].ToString();
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode)
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2') and av.app_reportingmanager='" + adminCode + "' AND av.status=1";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmpReportee"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpReportee"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            //Response.Redirect("../Error.aspx");
            Output.Show("Error occured while fetching reportees!");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void BindNumberOfReporteesPresent()
    {
        int totlEmployees;
        string adminCode = Session["empcode"].ToString();
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode)
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101)
where
ea.MODE in ('P', 'MM', 'A/P') and av.app_reportingmanager= '" + adminCode + "' and av.status=1";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmpReporteePresent"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpReporteePresent"]).ToString();

            int totlPresnt = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);
            Session["prsntEmployee2"] = totlPresnt;
            string totlEmpls = (string)Session["totalEmpReportee"];
            if (Convert.ToInt32(totlEmpls) > 0)
                totlEmployees = Convert.ToInt32(totlEmpls);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresnt) / totlEmployees) * 100;
            Session["totlPrsntinDeciRep"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeciRep"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            Session["totalPresentEmpRep"] = totlPrsntinPrcnt;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            //Response.Redirect("../Error.aspx");
            Output.Show("Error occured while fetching reportees!");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region attritionReport

    protected void joinedInNumber()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(empcode) from dbo.tbl_intranet_employee_jobDetails where CONVERT(varchar(10),emp_doj,102) = CONVERT(varchar(10),getdate(),102)";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["joinedInNumber"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["joinedInNumber"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void attritionInNumber()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(empcode) from dbo.tbl_intranet_employee_jobDetails where CONVERT(varchar(10),emp_doleaving,102) = CONVERT(varchar(10),getdate(),102)";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["attritionInNumber"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["attritionInNumber"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion

    protected void ddlReportee_SelectedIndexChanged2(object sender, EventArgs e)
    {
        string query, query1;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select emp_gender from dbo.tbl_intranet_employee_jobDetails where empcode = '" + ddlReportee.SelectedValue.ToString() + "'";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            query1 = @"select maritalstatus from tbl_intranet_employee_personalDetails where empcode = '" + ddlReportee.SelectedValue.ToString() + "'";

            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, query1);

            if (ds.Tables[0].Rows.Count < 1)
            {
                lblEntitledSL.Text = "0";
                lblBalanceSL.Text = "0";
                lblUsedSL.Text = "0";
                return;
            }
            Session["genderReportee"] = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            string test = (Session["genderReportee"]).ToString();

            Session["empcodeReportee"] = ddlReportee.SelectedValue.ToString();
            string test1 = (Session["empcodeReportee"]).ToString();

            Session["maritalstatusreportee"] = ds1.Tables[0].Rows[0]["maritalstatus"].ToString();
            string test2 = (Session["maritalstatusreportee"]).ToString();

            GetLeaveBalanceReportee(test1, test, test2);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    protected void BindReportee()
    {
        string adminCode = Session["empcode"].ToString();
        try
        {
            _Connection = activity.OpenConnection();
            sqlstr = @"select ej.empcode value,isnull(ej.emp_fname ,'')+' '+isnull(ej.emp_m_name,'')+ ' '+isnull(ej.emp_l_name,'') as name
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2') and av.app_reportingmanager='" + adminCode + "' and av.status=1";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddlReportee.DataSource = ds;
            ddlReportee.DataTextField = "name";
            ddlReportee.DataValueField = "value";
            ddlReportee.DataBind();
            ddlReportee.Items.Insert(0, new ListItem("---Select---", "0"));
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
    #region Reportee Leave Report
    //[WebMethod]
    public void GetLeaveBalanceReportee(string empcode, string gender, string Maritalstatus) //LeaveBalanceReportee[]
    {
        ResetMyRepoteeLeave();
        // List<LeaveBalanceReportee> detailsReportee = new List<LeaveBalanceReportee>();
        var activityReportee = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activityReportee.OpenConnection();
            string sqlstr = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance 
from tbl_leave_employee_leave_master 
						inner join tbl_intranet_employee_jobDetails jd on jd.empcode=tbl_leave_employee_leave_master.empcode
                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
                            where tbl_leave_employee_leave_master.empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('CL & SL','EL','PBL','ML','PL','Comp Off','Work from Home','Loss of Pay','Sabbatical','On Duty','PATL') ) and not(((jd.emp_gender = 'FEMALE' and r.applicable_to = 'M') or (jd.emp_gender = 'MALE' and r.applicable_to = 'F') ));";

            //            string sqlstr = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
            //                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
            //                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
            //                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
            //                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( tbl_leave_createleave.displayleave in('SL','Flexi Leave') );";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["leaveid"]) == 2)
                    {
                        lblEntitledSL.Text = ds.Tables[0].Rows[i]["Entitled"].ToString();
                        lblBalanceSL.Text = ds.Tables[0].Rows[i]["CurBalance"].ToString();
                        lblUsedSL.Text = ds.Tables[0].Rows[i]["UsedDays"].ToString();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["leaveid"]) == 1)
                    {
                        lblEntitledFL.Text = ds.Tables[0].Rows[i]["Entitled"].ToString();
                        lblBalanceFL.Text = ds.Tables[0].Rows[i]["CurBalance"].ToString();
                        lblUsedFL.Text = ds.Tables[0].Rows[i]["UsedDays"].ToString();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["leaveid"]) == 3)
                    {
                        lblEntitledPL.Text = ds.Tables[0].Rows[i]["Entitled"].ToString();
                        lblBalancePL.Text = ds.Tables[0].Rows[i]["CurBalance"].ToString();
                        lblUsedPL.Text = ds.Tables[0].Rows[i]["UsedDays"].ToString();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["leaveid"]) == 4)
                    {
                        lblEntitledML.Text = ds.Tables[0].Rows[i]["Entitled"].ToString();
                        lblBalanceML.Text = ds.Tables[0].Rows[i]["CurBalance"].ToString();
                        lblUsedML.Text = ds.Tables[0].Rows[i]["UsedDays"].ToString();
                    }
                    if (Convert.ToInt32(ds.Tables[0].Rows[i]["leaveid"]) == 5)
                    {
                        lblEntitledPTL.Text = ds.Tables[0].Rows[i]["Entitled"].ToString();
                        lblBalancePTL.Text = ds.Tables[0].Rows[i]["CurBalance"].ToString();
                        lblUsedPTL.Text = ds.Tables[0].Rows[i]["UsedDays"].ToString();
                    }

                }
            }
            if ((Maritalstatus.Trim() == "Married")||(Maritalstatus.Trim() == "MARRIED"))
            {
                if (gender.Trim() == "MALE")
                {
                    mtrnityLeave.Visible = false;
                    ptrnityLeave.Visible = true;
                }
                else
                {
                    ptrnityLeave.Visible = false;
                    mtrnityLeave.Visible = true;
                }
            }
            else
            {
                ptrnityLeave.Visible = false;
                mtrnityLeave.Visible = false;
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activityReportee.CloseConnection();
        }
    }

    private void ResetMyRepoteeLeave()
    {
        lblEntitledSL.Text = "0";
        lblBalanceSL.Text = "0";
        lblUsedSL.Text = "0";

        lblEntitledFL.Text = "0";
        lblBalanceFL.Text = "0";
        lblUsedFL.Text = "0";

        lblEntitledPL.Text = "0";
        lblBalancePL.Text = "0";
        lblUsedPL.Text = "0";

        lblEntitledML.Text = "0";
        lblBalanceML.Text = "0";
        lblUsedML.Text = "0";

        lblEntitledPTL.Text = "0";
        lblBalancePTL.Text = "0";
        lblUsedPTL.Text = "0";


    }

    public class LeaveBalanceReportee
    {
        public int leaveidReportee { get; set; }
        public string leavename { get; set; }
        public decimal entitleddays { get; set; }
        public decimal useddays { get; set; }
        public decimal balance { get; set; }
    }
    #endregion

    #region calendar
    private string CreateEvents()
    {
        //string connetionString = null;
        //SqlConnection connection;
        SqlDataAdapter adapter = new SqlDataAdapter();
        //DataSet ds = new DataSet();

        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();

            // connetionString = @"Data Source=SDL02-PC\SQLEXPRESS;Initial Catalog=Mactay_Aug;User ID=sa;Password=Reset@123";
            //connection = new SqlConnection(connetionString);

            //connection.Open();
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
                    finaleventdata = finaleventdata + eventData;
                else
                    finaleventdata = finaleventdata + "," + eventData;
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
    #endregion#region Fetch Reportee Leave Details

    protected void BindIntoEmpPieChartData1()
    {
        //string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            string sqlstrShiftId = @"select count(ad.intime) from tbl_payroll_employee_attendence_detail ad 
LEFT join tbl_attendance_employeecyclemapping am on am.empcode = ad.EMPCODE 
inner join tbl_leave_attendance_rule ar on ar.company_id = ad.company_id 
inner join tbl_leave_shift sft on sft.shiftid = ar.shiftid 
where CONVERT(varchar(20), ad.intime, 108) is not null 
and ad.empcode='" + _userCode.ToString().Trim() + "' and datepart(Month, ad.DATE) = datepart(month,getdate()) and convert(varchar(20), (ad.intime - ar.latein), 108) <= sft.starttime";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstrShiftId);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            Session["Emp_log1"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["Emp_log1"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void BindIntoEmpPieChartData2()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(ad.intime) from tbl_payroll_employee_attendence_detail ad 
LEFT join tbl_attendance_employeecyclemapping am on am.empcode = ad.EMPCODE 
inner join tbl_leave_attendance_rule ar on ar.company_id = ad.company_id 
inner join tbl_leave_shift sft on sft.shiftid = ar.shiftid 
where CONVERT(varchar(20), ad.intime, 108) is not null 
and ad.empcode='" + _userCode.ToString().Trim() + "' and datepart(Month, ad.DATE) = datepart(month,getdate()) and convert(varchar(20), (ad.intime), 108) >= sft.starttime + ar.latein and convert(varchar(20), ad.intime - (sft.starttime + ar.latein), 108) >= '00:15:00'";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["Emp_log2"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["Emp_log2"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void BindIntoEmpPieChartData3()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(ad.intime) from tbl_payroll_employee_attendence_detail ad 
LEFT join tbl_attendance_employeecyclemapping am on am.empcode = ad.EMPCODE 
inner join tbl_leave_attendance_rule ar on ar.company_id = ad.company_id 
inner join tbl_leave_shift sft on sft.shiftid = ar.shiftid 
where CONVERT(varchar(20), ad.intime, 108) is not null 
and ad.empcode='" + _userCode.ToString().Trim() + "' and datepart(Month, ad.DATE) = datepart(month,getdate()) and convert(varchar(20), (ad.intime), 108) >= sft.starttime + ar.latein and convert(varchar(20), ad.intime - (sft.starttime + ar.latein), 108) >= '00:30:00'";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["Emp_log3"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["Emp_log3"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindIntoColumnChartDepartment1AttendanceTotal();
        BindIntoColumnChartDepartment1AttendancePresent();
    }
}
