using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;
using System.Configuration;
using System.Net.Mail;
using Common.Data;
using System.Data.SqlClient;


public partial class Exit_ApproverResignationViewDetails : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
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
                
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");

        }
    }

    private DataSet CheckDesignation(string employeeCode)
    {
        string strAllemail;
        DataSet dsAllemail = new DataSet();
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //transaction = connection.BeginTransaction();
        try
        {
            strAllemail = @"select ApproverCode from [tbl_exit_approverdetails] where UserCode = '" + employeeCode.Trim() + "' and WorkFlowId in(1, 2, 3) select app_dotted_linemanager from tbl_employee_approvers where empcode = '" + employeeCode.Trim() + "'";
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

    private void BindDetails()
    {
        Lib = new Base();
        Exit = new ExitCommon();

        string query = @"select distinct pro.ResignationId from tbl_exit_ResignationProcess pro
inner join tbl_employee_approvers app on app.app_dotted_linemanager=pro.ApproversCode
inner join tbl_exit_Resignation res on res.ResignationId=pro.ResignationId
where pro.ResignationId='"+ResignId+"' and pro.Level=1 and CONVERT(varchar(20), DATEADD(day, 2, res.AppliedDate), 102) = CONVERT(varchar(20), GETDATE(), 102)";
        DataSet ds1 = Lib.Bee.WGetData(query);

        if (ds1.Tables[0].Rows.Count > 0)
        {
            Query = @"select ResignPro.ApproversCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,ResignPro.ApproverComments,ApproverStatus,WF.WorkFlowName
                 from tbl_exit_ResignationProcess ResignPro
                   inner join tbl_exit_Resignation Resign on ResignPro.ResignationId = Resign.ResignationId
                  left join tbl_intranet_employee_jobDetails job on ResignPro.ApproversCode = job.empcode
                   left join tbl_exit_workflow WF on ResignPro.Level = WF.WorkFlowId
                  where ResignPro.ResignationId = " + ResignId + " order by WF.WorkFlowId";

            DataSet ds2 = Lib.Bee.WGetData(Query);
            ds2.Tables[0].Rows[0]["WorkFlowName"] = "Dotted Line Manager";
            //Lib.Bee.WBindGrid(, Grid);
            Grid.DataSource = ds2;
            Grid.DataBind();

            

        }
        else
        {
         

            Query = @"select ResignPro.ApproversCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,ResignPro.ApproverComments,ApproverStatus,WF.WorkFlowName
                  from tbl_exit_ResignationProcess ResignPro
                   inner join tbl_exit_Resignation Resign on ResignPro.ResignationId = Resign.ResignationId
                   left join tbl_intranet_employee_jobDetails job on ResignPro.ApproversCode = job.empcode
                   left join tbl_exit_workflow WF on ResignPro.Level = WF.WorkFlowId
                  where ResignPro.ResignationId = " + ResignId + " order by WF.WorkFlowId";

            DataSet ds2 = Lib.Bee.WGetData(Query);
            //Lib.Bee.WBindGrid(, Grid);
            Grid.DataSource = ds2;
            Grid.DataBind();
        }

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
        

    }


    private void Cancel()
    {
        IBase Base = new Base();
        bool istrue = false;

        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'C' where ResignStatus = 'U' and ResignationId = " + ResignId + ";";
            Query += "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'C' where ApproverStatus in ('P','A') and ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "';";

            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (Flag > 0)
            {
                // BindDetails();
                istrue = true;
                // Output.Show("Resignation application cancelled successfully.");
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
        {
            string TransferPage = "<script>window.open('ApproverResignationView.aspx?msg=Cancel','_self');</script>";
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "temp", TransferPage, false);
        }
    }

    private void Reject()
    {
        IBase Base = new Base();
        bool istrue = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'J' where ResignStatus = 'U' and ResignationId = " + ResignId + ";";
            Query += "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'J' where ApproverStatus in ('P','A') and ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "';";

            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (Flag > 0)
            {
                string qryAppvlStts = @"select ApproverStatus from [tbl_exit_ResignationProcess] where [ResignationId] = '" + ResignId + "' and Level in(1, 2)";
                DataSet dsqryAppvlStts = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, qryAppvlStts);
                string stttsLM = dsqryAppvlStts.Tables[0].Rows[0]["ApproverStatus"].ToString();
                string stttsBH = dsqryAppvlStts.Tables[0].Rows[1]["ApproverStatus"].ToString();

                string isDLM = @"select Status from tbl_exit_Resignation where ResignationId = '" + ResignId + "'";
                DataSet dsisDLM = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, isDLM);
                int isDLMStts = Convert.ToInt32(dsisDLM.Tables[0].Rows[0]["Status"]);

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
                DataSet bh = CheckDesignation(emp_code);
                if (bh.Tables[0].Rows[0]["ApproverCode"].ToString().Trim() == UserCode.Trim() && bh.Tables[0].Rows[1]["ApproverCode"].ToString().Trim() == UserCode.Trim() && stttsLM.Trim() == "J" && stttsBH.Trim() == "P")
                    sendmail_TemplateEmp(EmpEmailId, dlmName, empName, emp_code, stttsLM, stttsBH, isDLMStts);
                else if (bh.Tables[0].Rows[1]["ApproverCode"].ToString().Trim() == UserCode.Trim() && stttsLM.Trim() == "A" && stttsBH.Trim() == "A")
                {
                    DataSet dsAppvrDetailsBH = GetAppvrsEmailBH(emp_code);
                    sendmail_TemplateBHRej(EmpEmailId, empName, dsAppvrDetailsBH.Tables[0].Rows[0]["name"].ToString());
                }
                else
                    sendmail_TemplateEmp(EmpEmailId, dlmName, empName, emp_code, stttsLM, stttsBH, isDLMStts);
                // BindDetails();
                istrue = true;               
                // Output.Show("Resignation application rejected successfully.");
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
        {
            //string str = SendRejectEmailToEmployee(ResignId);
            string TransferPage = "<script>window.open('ApproverResignationView.aspx?msg=Reject','_self');</script>";
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "temp", TransferPage, false);
        }
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

    public bool sendmail_TemplateEmp(string recievermailid, string approver, string employee, string empCode, string lm, string bh, int isdlm)
    {
        try
        {
            //string senderId = "connect@escalon.services";
            //string senderPassword = "Escalon2017$";
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];    
            DataSet dlmanager = CheckDesignation(empCode);
            string Template;
            if (dlmanager.Tables[1].Rows[0]["app_dotted_linemanager"].ToString().Trim() == UserCode.Trim() && lm.Trim() == "J" && bh.Trim() == "P" && isdlm == 0)
                Template = EmailTemplateDLMRej(employee, approver, empCode);
            else
                Template = EmailTemplateEmp(employee, approver, empCode);
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

    private string EmailTemplateDLMRej(string employee, string approver, string empCode)
    {
        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = empCode.ToString();
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your Resignation Request has been rejected by Dotted Line Manager - " + appr + ".</p>" +

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

    public string EmailTemplateEmp(string employee, string approver, string empcode)
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your Resignation Request has been rejected by Line Manager - " + appr + ".</p>" +

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

    private void Approve()
    {
        IBase Base = new Base();
        bool istrue = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'A' where ApproverStatus in ('P') and ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "' and Level = (select min(Level) from tbl_exit_ResignationProcess where ResignationId = " + ResignId + " and ApproverStatus='P')";
            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            if (Flag > 0)
            {

                //            Query = @"select tbl_exit_ResignationProcess.ApproversCode, Level
                //                          from tbl_exit_ResignationProcess inner join tbl_exit_approverdetails 
                //                          on tbl_exit_ResignationProcess.ApproversCode = tbl_exit_approverdetails.ApproverCode 
                //                          where tbl_exit_ResignationProcess.ResignationId = " + ResignId + " and tbl_exit_ResignationProcess.ApproverStatus = 'P' and tbl_exit_ResignationProcess.Status = 1 and tbl_exit_approverdetails.Hr <> 'Y' order by Level;";

                Query = @"select tbl_exit_ResignationProcess.ApproversCode, Level
                          from tbl_exit_ResignationProcess inner join tbl_exit_approverdetails 
                          on tbl_exit_ResignationProcess.ApproversCode = tbl_exit_approverdetails.ApproverCode 
                          where tbl_exit_ResignationProcess.ResignationId = " + ResignId + " and tbl_exit_ResignationProcess.ApproverStatus = 'P' and tbl_exit_ResignationProcess.Status = 1  order by Level;";


                DataSet ds = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, Query);

                string query1 = @"select * from tbl_exit_Resignation where WhichLevel=2 and ResignationId='"+ResignId+"' ";
                DataSet ds1 = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, query1);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    Query = "update tbl_exit_Resignation set WhichLevel = " + row["Level"].ToString().Trim() + " where ResignStatus = 'U' and ResignationId = " + ResignId + ";";
                    Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
                }

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    string Query1 = @"insert into tbl_exit_Exit (ResignationId,EmpCode,AppliedDate,WorkFlowTypeId,ResignStatus,WhichLevel,Status) 
 select ResignationId,EmpCode,GETDATE(),2,'U',1,1
  from tbl_exit_Resignation
   where ResignationId ='" + ResignId + "' declare @ID int set @id = SCOPE_IDENTITY() insert into tbl_exit_ExitProcess (ResignationId,ApproversCode,ApproverStatus,ApplicationId,Level,Status) values (@id,(select EmpCode from tbl_exit_Resignation where ResignationId = '" + ResignId + "'),'P',6,4,1)";
                    Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query1);
                }
            }

            Base.Bee.Commit();

            if (Flag > 0)
            {
                string qryAppvlStts = @"select ApproverStatus from [tbl_exit_ResignationProcess] where [ResignationId] = '" + ResignId + "' and Level in(1, 2)";
                DataSet dsqryAppvlStts = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, qryAppvlStts);
                string stttsLM = dsqryAppvlStts.Tables[0].Rows[0]["ApproverStatus"].ToString();
                string stttsBH = dsqryAppvlStts.Tables[0].Rows[1]["ApproverStatus"].ToString();

                string isDLM = @"select Status from tbl_exit_Resignation where ResignationId = '" + ResignId + "'";
                DataSet dsisDLM = Base.Bee.TGetAllDataByQuery(Base.Bee.Connection, Base.Bee.Transaction, isDLM);
                int isDLMStts = Convert.ToInt32(dsisDLM.Tables[0].Rows[0]["Status"]);

                string[] splitCooments = lblComments.Text.Split('-');
                string emp_code = splitCooments[1].Substring(1, 8);
                DataSet dsAppvrDetails = GetAppvrsEmail(emp_code);
                string dlmName = "";
                string dlmEmailId = "";
                if (dsAppvrDetails.Tables[0].Rows.Count > 0)
                {
                    dlmName = dsAppvrDetails.Tables[0].Rows[0]["name"].ToString();
                    dlmEmailId = dsAppvrDetails.Tables[0].Rows[0]["official_email_id"].ToString();
                }
                string empName = "";
                if (dsAppvrDetails.Tables[1].Rows.Count > 0)
                    empName = dsAppvrDetails.Tables[1].Rows[0]["name"].ToString();
                DataSet bh = CheckDesignation(emp_code);
                if (bh.Tables[0].Rows[0]["ApproverCode"].ToString().Trim() == UserCode.Trim() && bh.Tables[0].Rows[1]["ApproverCode"].ToString().Trim() == UserCode.Trim() && stttsLM.Trim() == "A" && stttsBH.Trim() == "P")
                    sendmail_Template(dlmEmailId, dlmName, empName, emp_code, stttsLM, stttsBH, isDLMStts);
                else if (bh.Tables[0].Rows[1]["ApproverCode"].ToString().Trim() == UserCode.Trim() && stttsLM.Trim() == "A" && stttsBH.Trim() == "A")
                {
                    DataSet dsAppvrDetailsBH = GetAppvrsEmailBH(emp_code);
                    sendmail_TemplateBH(dsAppvrDetailsBH.Tables[0].Rows[0]["official_email_id"].ToString(), dsAppvrDetailsBH.Tables[0].Rows[0]["name"].ToString(), empName, emp_code);
                }
                else
                    sendmail_Template(dlmEmailId, dlmName, empName, emp_code, stttsLM, stttsBH, isDLMStts);
                // BindDetails();
                istrue = true;
                // Output.Show("Resignation application approved successfully.");
            }
            else
                Output.Show("Resignation application not approved. Please try again later.");
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
            ExitApprovers objEmail = new ExitApprovers();
            if (objEmail.GetResignationApproverLevel(ResignId, UserCode).Rows.Count > 0)
            {
               // string EmpNameCode = SendApprovedEmailToEmployee(ResignId);
                //SendApprovedEmailToLevel(ResignId, EmpNameCode);
            }
         
            string TransferPage = "<script>window.open('ApproverResignationView.aspx?msg=Approved','_self');</script>";
            System.Web.UI.ScriptManager.RegisterStartupScript(Page, Page.GetType(), "temp", TransferPage, false);
        }
    }

    private DataSet GetAppvrsEmail(string emplCode)
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
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + bhCode.Text.Trim() + "' SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + emplCode.Trim() + "'";
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

    private DataSet GetAppvrsEmailBH(string emplCode)
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
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + HRCode.Text.Trim() + "' SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + emplCode.Trim() + "'";
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

    public bool sendmail_TemplateBH(string recievermailid, string approver, string employee, string empCode)
    {
        try
        {
            //string senderId = "connect@escalon.services";
            //string senderPassword = "Escalon2017$";
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];    
            //DataSet dlmanager = CheckDesignation(empCode);
            string Template = EmailTemplateBH(approver, employee, empCode);
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
            //smtpClient.Port = 25;
            //smtpClient.Host = "secure.emailsrvr.com";
            //smtpClient.EnableSsl = true;

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

    public bool sendmail_TemplateBHRej(string recievermailid, string employee, string approver)
    {
        try
        {
            string senderId = "connect@escalon.services";
            string senderPassword = "Escalon2017$";
            //DataSet dlmanager = CheckDesignation(empCode);
            string Template = EmailTemplateBHRej(employee, approver);
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

    private string EmailTemplateBH(string approver, string employee, string empCode)
    {
        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = empCode.ToString();
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
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Business Head has approved Resignation Request from " + emp + " - " + empcod + " and now submitted for your Approval / Reject.</p>" +

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

    private string EmailTemplateBHRej(string employee, string approver)
    {
        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = UserCode;
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your Resignation request has been rejected by Business Head " + appr + " - " + empcod + ".</p>" +

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

    public bool sendmail_Template(string recievermailid, string approver, string employee, string empCode, string lm, string bh, int isdlm)
    {
        try
        {
            //string senderId = "connect@escalon.services";
            //string senderPassword = "Escalon2017$";
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];     
            DataSet dlmanager = CheckDesignation(empCode);
            string Template;
            if (dlmanager.Tables[1].Rows[0]["app_dotted_linemanager"].ToString().Trim() == UserCode.Trim() && lm.Trim() == "A" && bh.Trim() == "P" && isdlm == 0)
                Template = EmailTemplateDLM(approver, employee, empCode);
            else
                Template = EmailTemplate(approver, employee, empCode);
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
            //smtpClient.Port = 25;
            //smtpClient.Host = "secure.emailsrvr.com";
            //smtpClient.EnableSsl = true;

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

    private string EmailTemplateDLM(string approver, string employee, string empCode)
    {
        string appr = approver.ToString();
        string emp = employee.ToString();
        string empcod = empCode.ToString();
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
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Dotted Line Manager has approved Resignation Request from " + emp + " - " + empcod + " and now submitted for your Approval / Reject.</p>" +

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
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Line Manager has approved Resignation Request from " + emp + " - " + empcod + " and now submitted for your Approval / Reject.</p>" +

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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Cancel == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Cancel();
        else
            Output.Show("You do not have permission to cancel resignation application. Please contact admin.");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Reject == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Reject();
        else
            Output.Show("You do not have permission to reject resignation application. Please contact admin.");
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Approve == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Approve();
        else
            Output.Show("You do not have permission to approve resignation application. Please contact admin.");
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
                        Output.Show("You do not have permission to edit LWD. Please contact admin.");
                }
                else
                {
                    Output.Show("You have entered invalid date.");
                }
            }
        }
    }

    private bool IsHR(string ApproverCode, int ResignId)
    {
        IBase Base = new Base();
        bool Flag = false;

        try
        {
            Base.Bee.OpenConnection();


            Query = @"
select *
 from tbl_exit_Resignation R
  inner join tbl_exit_ResignationProcess RP on R.ResignationId = RP.ResignationId
   where R.EmpCode = (select EmpCode from tbl_exit_Resignation where ResignationId = '" + ResignId + "') and R.ResignationId = '" + ResignId + "' and RP.ApproversCode = '" + ApproverCode + "' and RP.Level = 3 and RP.Status = 1";

            DataSet Ds = Base.Bee.WGetData(Query);
            if (Ds.Tables[0].Rows.Count > 0)
                Flag = true;
            else
                Flag = false;

        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Checking HR: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        return Flag;

    }  

    string SendRejectEmailToEmployee(int resignId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Exit.ResignationRequestRejected();
        EmailClient client = new EmailClient(email);
        ExitApprovers objEmail = new ExitApprovers();
        DataRow row = objEmail.GetResignationEmployee(resignId);
        client.toEmailId = row["officialemailid"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["empname"].ToString().Trim();
        client.Send();

        return row["empname"].ToString().Trim() + " ( " + row["empcode"].ToString() + " ) ";
    }

    string SendApprovedEmailToEmployee(int resignId)
    {

        EmailFactory email = new Smart.HR.Common.Mail.Module.Exit.ResignationRequestApprovedEmp();
        EmailClient client = new EmailClient(email);
        ExitApprovers objEmail = new ExitApprovers();
        DataRow row = objEmail.GetResignationEmployee(resignId);
        client.toEmailId = row["officialemailid"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["empname"].ToString().Trim();
        client.Send();

        return row["empname"].ToString().Trim() + " ( " + row["empcode"].ToString() + " ) ";
    }

    void SendApprovedEmailToLevel(int resignId, string empNameCode)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Exit.ResignationRequestApprovedLM();
        EmailClient client = new EmailClient(email);
        ExitApprovers objEmail = new ExitApprovers();
        DataTable dt = objEmail.GetResignationApproversExceptHR(resignId);
        DataRow row = dt.Rows[0];
        client.toEmailId = row["officialemailid"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["empname"].ToString().Trim();
        client.requestNumber = empNameCode;
        client.Send();

        //email = new Smart.HR.Common.Mail.Module.Exit.ResignationRequestApprovedBH();
        //client = new EmailClient(email);
        //row = dt.Rows[1];
        //client.toEmailId = row["officialemailid"].ToString().Trim();
        //client.empCode = row["empcode"].ToString();
        //client.employeeName = row["empname"].ToString().Trim();
        //client.requestNumber = empNameCode;
        //client.Send();

        email = new Smart.HR.Common.Mail.Module.Exit.ResignationRequestApprovedHR();
        client = new EmailClient(email);
        row = dt.Rows[2];
        client.toEmailId = row["officialemailid"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["empname"].ToString().Trim();
        client.requestNumber = empNameCode;
        client.Send();
    }


    protected void imgbtn_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {
        imgbtn.Visible = false;
        LWD.Visible = true;
        EditLED.Visible = true;
    }
}