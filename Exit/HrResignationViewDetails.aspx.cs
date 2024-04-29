using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;


public partial class Exit_HrResignationViewDetails : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
    int ExitWorkFlowTypeId = 2;    // Resignation
    int ApplicationId = 1;
    string PageId = "Approver";

    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitCompanyRule CompanyRule = null;
    ExitWorkFlowRule ApproverRule = null;

    int ResignId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            ResignId = Convert.ToInt32(Request.QueryString["ResignId"].ToString().Trim());

            #region Rule
            Exit = new ExitCommon();
            Lib = new Base();

            DataSet ds = Lib.Bee.WGetData("select EmpCode from tbl_exit_Resignation where ResignationId = " + ResignId + "");
            DataRow row = ds.Tables[0].Rows[0];
            CompanyRule = Exit.GetExitCompanyRules();
            ApproverRule = Exit.GetExitWorkRules(UserCode, row["EmpCode"].ToString().Trim());
         
            #endregion

            if (ApproverRule.CommentBoxRequired != "Y")
                CommentBox.Visible = false;

            if (ApproverRule.CanEditLWD != "Y")
                EditLED.Visible = false;

            if (!IsPostBack)
            {
                LWD.Visible = false;
                EmployeeTypeId.Value = "";
                BindDetails();
                BindDetails1();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindDetails()
    {
        Lib = new Base();
        Exit = new ExitCommon();

        Query = @"select ResignPro.ApproversCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,ResignPro.ApproverComments,ApproverStatus,WF.WorkFlowName
                  from tbl_exit_ResignationProcess ResignPro
                   inner join tbl_exit_Resignation Resign on ResignPro.ResignationId = Resign.ResignationId
                   left join tbl_intranet_employee_jobDetails job on ResignPro.ApproversCode = job.empcode
                   left join tbl_exit_workflow WF on ResignPro.Level = WF.WorkFlowId
                  where ResignPro.ResignationId = " + ResignId + " order by WF.WorkFlowId";

        Lib.Bee.WBindGrid(Query, Grid);

        Query = @"select ResignationId,AppliedDate,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,Comments,stat.employeestatus as EmployeeStatus,Resign.NoticePeriod,DefaultLWD
                   from tbl_exit_Resignation Resign
                    left join tbl_intranet_employee_jobDetails job on Resign.EmpCode = job.empcode
                    left join tbl_intranet_employee_status stat on Resign.EmployeeType = stat.id
                   where Resign.ResignationId = " + ResignId + "";

        DataSet ds = Lib.Bee.WGetData(Query);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            lblAppliedDate.Text = row["AppliedDate"].ToString();
            lblEmployeeType.Text = row["EmployeeStatus"].ToString();
            lblNoticePeriod.Text = row["NoticePeriod"].ToString();
            lblDLWD.Text = row["DefaultLWD"].ToString();
            lblComments.Text = row["Comments"].ToString();
        }

        //if (Grid.Rows.Count >2)
        //{
        //    Label lblStatus = (Label)Grid.Rows[2].FindControl("lblStatus");
        //    if (lblStatus.Text == "Approved")
        //    {
        //        btnInitiateExit.Visible = true;
        //        btnCancel.Visible = true;
        //    }
        //    else
        //    {
        //        btnInitiateExit.Visible = false;
        //        btnCancel.Visible = false;
        //    }
        //}
    }

    private void BindDetails1()
    {
        Lib = new Base();
        // Application Type and Work Flow Type
        // Pending - Status = 1 and Resign Status = U
        Query = @"
select ExitId,A.EmpCode,job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName, ApplicationId, ApplicationName,case when ApproverStatus='A' then 'Submitted' else 'Pending' end as ApproverStatus
from
(
select E.ExitId,E.EmpCode EmpCode,ApplicationId,ApplicationName,EP.ApproverStatus
from tbl_exit_Exit E 
inner join tbl_exit_ExitProcess EP on E.ExitId = EP.ResignationId
inner join tbl_exit_applicationtype AT on EP.ApplicationId = AT.ApplicationTypeId
where E.ResignationId='" + ResignId+"') A inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode order by job.empcode";

        Lib.Bee.WBindGrid(Query, GridView1);


        // Cancelled - Status = 0 and Resign Status = C
        // Rejected - Status = 0 and Resign Status = J
        // Freezed - Status = 1 and Resign Status = F
        // Re-Initiate - Make Status = 0 and Resign Status = R for the previous record and insert new record with the same values except, Status = 1 and Resign Status = U
    }

    private void Cancel()
    {
        IBase Base = new Base();
        bool istrue = false;

        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'C' where ResignationId = " + ResignId + ";";
            Query += "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'C' where ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "';";
            Query += "update tbl_intranet_employee_jobDetails set emp_doleaving = null where empcode = (select EmpCode from tbl_exit_Resignation where ResignationId = " + ResignId + " );";

            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (Flag > 0)
            {
                //BindDetails();
                //Output.Show("Resignation application cancelled successfully.");
                istrue = true;
            }
            else
                Output.Show("Resignation application not cancelled. Please try again later.");


        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
            Server.Transfer("HrResignationView.aspx?msg=Cancel");
    }

    private void Reject()
    {
        IBase Base = new Base();
        bool istrue = false;

        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'J' where ResignationId = " + ResignId + ";";
            Query += "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'J' where ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "';";
            Query += "update tbl_intranet_employee_jobDetails set emp_doleaving = null where empcode = (select EmpCode from tbl_exit_Resignation where ResignationId = " + ResignId + " );";

            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (Flag > 0)
            {
                string[] splitCooments = lblComments.Text.Split('-');
                string emp_code = splitCooments[1].Substring(1, 8);
                DataSet dsEmpDetails = GetEmpEmail(emp_code);
                string dlmName = "", EmpEmailId = "", empName = "";
                if (dsEmpDetails.Tables[0].Rows.Count > 0)
                {
                    empName = dsEmpDetails.Tables[0].Rows[0]["name"].ToString();
                    EmpEmailId = dsEmpDetails.Tables[0].Rows[0]["official_email_id"].ToString();
                }

                if (dsEmpDetails.Tables[1].Rows.Count > 0)
                    dlmName = dsEmpDetails.Tables[1].Rows[0]["name"].ToString();
                sendmail_TemplateEmpRej(EmpEmailId, dlmName, empName, emp_code);
                //BindDetails();
                //Output.Show("Resignation application rejected successfully.");
                istrue = true;
            }
            else
                Output.Show("Resignation application not rejected. Please try again later.");

        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
            Server.Transfer("HrResignationView.aspx?msg=Reject");
    }

    private DataSet GetEmpEmail(string emp_code)
    {
        string strAllemail;
        DataSet dsAllemail = new DataSet();
        DataSet ds3 = new DataSet();
        Label bhCode = (Label)Grid.Rows[1].Cells[0].FindControl("lblAppvrCode");
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //transaction = connection.BeginTransaction();
        try
        {
            strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name,empcode, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + emp_code.Trim() + "' SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + UserCode.Trim() + "'";
            dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
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

        return dsAllemail;
    }

    public bool sendmail_TemplateEmp(string recievermailid, string employee, string approver)
    {
        try
        {
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"]; 

            string Template = EmailTemplateEmp(employee, approver);
            //string Template = EmailTemplateEmp(employee, approver, empCode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Resignation Request Status";
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

    public string EmailTemplateEmp(string employee, string approver)
    {
        string appr = approver.ToString();
        string emp = employee.ToString();
        //string empcod = empcode.ToString();
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
    "<title>Resignation Request Status</title>" +
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
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your Resignation Request has been approved by HR - " + appr + ".</p>" +

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

    private void InitiateNextWorkFlow()
    {
        IBase Base = new Base();
        DataSet Flag = null;
        bool istrue = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "sp_exit_initiatenextworkflow";

            Flag = Base.Bee.TGetAllDataByProcedure(Base.Bee.Connection, Base.Bee.Transaction, Query, ResignId, WorkFlowTypeId, UserCode, txtComments.Text.Trim());
            DataRow Row = Flag.Tables[0].Rows[0];
            Base.Bee.Commit();
            if (Row["Msg"].ToString() == "True")
                istrue = true;
            else
                Output.Show(Row["Msg"].ToString());
        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
        {
            string[] splitCooments = lblComments.Text.Split('-');
            string emp_code = splitCooments[1].Substring(1, 8);
            DataSet dsAppvrDetails = GetAppvrsEmail(emp_code);
            string empName = "";
            string EmailId = "";
            if (dsAppvrDetails.Tables[0].Rows.Count > 0)
            {
                empName = dsAppvrDetails.Tables[0].Rows[0]["name"].ToString();
                EmailId = dsAppvrDetails.Tables[0].Rows[0]["official_email_id"].ToString();
            }
            string dlmName = "";
            if (dsAppvrDetails.Tables[1].Rows.Count > 0)
                dlmName = dsAppvrDetails.Tables[1].Rows[0]["name"].ToString();
            sendmail_TemplateEmp(EmailId, empName, dlmName);
            //SendEmailToLevel(ResignId);
            Server.Transfer("HrResignationView.aspx?msg=Approved");
        }
    }

    private DataSet GetAppvrsEmail(string emplCode)
    {
        string strAllemail;
        DataSet dsAllemail = new DataSet();
        DataSet ds3 = new DataSet();
        Label HRCode = (Label)Grid.Rows[2].Cells[0].FindControl("lblAppvrCode");
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //transaction = connection.BeginTransaction();
        try
        {
            strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name,empcode, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + emplCode.Trim() + "' SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + HRCode.Text.Trim() + "'";
            dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
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

        return dsAllemail;
    }

    public bool sendmail_TemplateEmpRej(string recievermailid, string approver, string employee, string empCode)
    {
        try
        {
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"]; 

            string Template = EmailTemplateEmpRej(employee, approver, empCode);
            //string Template = EmailTemplateEmp(employee, approver, empCode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Resignation Request Status";
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

    public string EmailTemplateEmpRej(string employee, string approver, string empcode)
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
    "<title>Resignation Request Status</title>" +
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
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your Resignation Request has been rejected by HR - " + appr + ".</p>" +

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

    void SendEmailToLevel(int resignId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Exit.InitiateExitWorkFlow();
        EmailClient client = new EmailClient(email);
        ExitApprovers objEmail = new ExitApprovers();
        DataTable dt = objEmail.GetExitApproverLevel(resignId);
        DataRow eRow = objEmail.GetResignationEmployee(resignId);

        foreach (DataRow row in dt.Rows)
        {
            client.toEmailId = row["officialemailid"].ToString().Trim();
            client.empCode = row["empcode"].ToString();
            client.employeeName = row["empname"].ToString().Trim();
            client.requestNumber = eRow["empname"].ToString().Trim() + " ( " + eRow["empcode"].ToString().Trim() + " ) ";
            client.fromDate = row["ApplicationName"].ToString().Trim();
            client.Send();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Cancel == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Cancel();
        else
            Output.Show("You do not have permission to cancel resignation application. Please contact admin.");
    }

    //protected void btnReject_Click(object sender, EventArgs e)
    //{
    //    if (ApproverRule.Reject == "Y" && ApproverRule.ApplicationId == ApplicationId)
    //        Reject();
    //    else
    //        Output.Show("You do not have permission to reject resignation application. Please contact admin.");
    //}

    protected void btnInitiateExit_Click(object sender, EventArgs e)
    {
        IBase Base = new Base();
        bool istrue = false;

        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = @"select qun.ExitId from tbl_exit_interviewquestion qun
inner join tbl_exit_Exit ex on ex.ExitId=qun.ExitId
inner join tbl_exit_Resignation res on res.ResignationId=ex.ResignationId
 where res.ResignationId='" + ResignId + "' ";

//            Query = @"select ex.ExitId from  
// tbl_exit_Exit ex 
//inner join tbl_exit_Resignation res on res.ResignationId=ex.ResignationId
// where res.ResignationId='" + ResignId + "' ";


            DataSet ds = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ApproverRule.InitiateNextWorkFlow == "Y" && ApproverRule.ApplicationId == ApplicationId)
                    InitiateNextWorkFlow();
                else
                    Output.Show("You do not have permission to approve resignation application. Please contact admin.");
            }
            else
            {
                Output.Show("Exit Interview Questionarie Pending");
              //  Page.ClientScript.RegisterStartupScript(this.GetType(), "closewindow()", true);
            }
        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

    }

    protected void Grid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            Label Status = (Label)e.Row.FindControl("lblStatus");
            if (Status.Text == "A")
            {
                Status.ForeColor = System.Drawing.Color.Green;
                Status.Text = "Approved";
            }
            else if (Status.Text == "P")
            {
                Status.ForeColor = System.Drawing.Color.Orange;
                Status.Text = "Pending";
            }
            else if (Status.Text == "C")
            {
                Status.ForeColor = System.Drawing.Color.Red;
                Status.Text = "Cancelled";
            }
            else if (Status.Text == "J")
            {
                Status.ForeColor = System.Drawing.Color.SteelBlue;
                Status.Text = "Rejected";
            }
            else if (Status.Text == "I")
            {
                Status.ForeColor = System.Drawing.Color.SteelBlue;
                Status.Text = "Exit Initiated";
            }
        }
    }

    private bool UpdateLWD()
    {
        IBase Base = new Base();
        int Flag = 0;
        bool Flip = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set DefaultLWD = '" + NewLWD.Text.Trim() + "' where ResignationId = " + ResignId + ";";
            Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);

            Query = "insert into tbl_exit_Resignation_LWD (ResignationId,Old_LWD,New_LWD,Status,UpdatedBy,UpdatedDate) values (" + ResignId + ",'" + lblDLWD.Text.Trim() + "','" + NewLWD.Text.Trim() + "',1,'" + UserCode + "',getdate())";
            Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);

            Base.Bee.Commit();

            if (Flag > 0)
            {
                Flip = true;
            }
        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Updating LWD: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        return Flip;
    }

    protected void EditLED_Click(object sender, EventArgs e)
    {
        if (EditLED.Text == "Update LWD")
        {
            if (NewLWD.Text.Trim() != "")
            {
                if (Convert.ToDateTime(lblAppliedDate.Text) <= Convert.ToDateTime(NewLWD.Text.Trim()))
                {
                    if (ApproverRule.CanEditLWD == "Y")
                    {
                        if (UpdateLWD())
                        {
                            LWD.Visible = false;
                            EditLED.Text = "Edit";
                            BindDetails();
                        }
                    }
                    else
                        //Output.Show("You do not have permission to edit LWD. Please contact admin.");
                        if (UpdateLWD())
                        {
                            LWD.Visible = false;
                            EditLED.Text = "Edit";
                            BindDetails();
                        }
                }
                else
                {
                    Output.Show("You have entered invalid date.");
                }
            }
        }
    }

    protected void imgbtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        imgbtn.Visible = false;
        LWD.Visible = true;
        EditLED.Visible = true;
    }
    protected void btnreject_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Reject == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Reject();
        else
            Output.Show("You do not have permission to reject resignation application. Please contact admin.");
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
    ////    Lib = new Base();
    ////    int Id = (int)Grid.DataKeys[(int)e.NewEditIndex].Value;
    ////    Label AppId = (Label)Grid.Rows[(int)e.NewEditIndex].FindControl("lblAppId");

    ////    Query = @"select * from tbl_exit_applicationtype where ApplicationTypeId = " + AppId.Text.Trim() + "";

    ////    DataSet ds = Lib.Bee.WGetData(Query);
    ////    if (ds.Tables[0].Rows.Count > 0)
    ////    {
    ////        DataRow row = ds.Tables[0].Rows[0];
    ////        string Path = row["Path"].ToString().Trim();

    ////        Server.Transfer(Path + "?Id= " + Id);
    ////    }
    ////    else
    ////    {
    ////        Output.Show("Applications are not defined. Please contact system admin.");
    ////    }
        int Id = (int)GridView1.DataKeys[(int)e.NewEditIndex].Value;
        Server.Transfer("ViewFormExitInterviewQuestionaries.aspx?ResignId=" + Id + "");
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}