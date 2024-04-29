using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using Smart.HR.Common.Mail.Module;
using System.Web.UI;
using System.Net.Mail;
using System.Data.SqlClient;
using Common.Data;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Exit_ResignationRequest : System.Web.UI.Page
{

    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
    int ApplicationId = 1;

    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitEmployeeRule EmpRule = null;
    ExitCompanyRule CompanyRule = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (EmpRule.CommentBoxRequired != "Y")
                CommentBox.Visible = false;

            if (!IsPostBack)
            {
                EmployeeTypeId.Value = "";
                BindDetails();

            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindDetails()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        Exit = new ExitCommon();

        Query = Exit.ApproversDetails(UserCode, WorkFlowTypeId);
        Lib.Bee.WBindGrid(Query, Grid);

        Query = Exit.ResignationDetails(UserCode);
        DataSet ds = Lib.Bee.WGetData(Query);
        ViewState["employeeName"] = ds;
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            lblAppliedDate.Text = row["AppliedDate"].ToString();
            EmployeeTypeId.Value = row["emp_status"].ToString();
            lblEmployeeType.Text = row["EmployeeStatus"].ToString();
            //if (row["emp_status"].ToString() == "1")
            //    lblNoticePeriod.Text = row["ConfirmedEmployeeNoticePeriod"].ToString();
            //else
            //    lblNoticePeriod.Text = row["UnConfirmedEmployeeNoticePeriod"].ToString();

            string str = @"select case when noticeperiod IS null then '45' else noticeperiod end as noticeperiod from tbl_intranet_employee_jobDetails where empcode= '" + UserCode + "'";
           DataSet  dsAl = SQLServer.ExecuteDataset(connection, CommandType.Text, str);
           lblNoticePeriod.Text = dsAl.Tables[0].Rows[0]["noticeperiod"].ToString();

            DateTime dt = DateTime.Now;
            if (CompanyRule.DefaultLastWorkingDays == 1)   // 1. Applied Date + Notice Period 2. Flat Date
                dt = Convert.ToDateTime(row["AppliedDate"].ToString()).AddDays(Convert.ToDouble(lblNoticePeriod.Text));

            lblDLWD.Text = dt.ToString();
            txtComments.Text = @"Hello,

My name is " + row["EmpName"].ToString().Trim() + " - " + UserCode + " (" + row["designationname"].ToString().Trim() + ")(" + row["department_name"].ToString().Trim() + ").";
        }

    }


    private void Initiate()
    {
        IBase Base = new Base();
        bool istrue = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "sp_exit_resignationrequest";

            DataSet Flag = Base.Bee.TGetAllDataByProcedure(Base.Bee.Connection, Base.Bee.Transaction, Query, lblAppliedDate.Text, txtComments.Text, WorkFlowTypeId, ApplicationId, EmployeeTypeId.Value, lblNoticePeriod.Text, lblDLWD.Text, UserCode);
            DataRow Row = Flag.Tables[0].Rows[0];
            Base.Bee.Commit();

            if (Row["Msg"].ToString() == "True")
            {
                istrue = true;
                int resignId = Convert.ToInt32(Row["id"].ToString());

                //string EmpNameCode = SendEmailToEmployee(resignId);
                //SendEmailToLevel(resignId, EmpNameCode);
            }

            else
                Output.Show(Row["Msg"].ToString());

        }
        catch (Exception ex)
        {
            //Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
        {
            SqlConnection connection = new SqlConnection();

            DataSet dsAppvrEmails = GetAppvrsEmail(connection);
            if (dsAppvrEmails.Tables[0].Rows.Count < 1)
            {
                Common.Console.Output.Show("Approver has not been assigned. !!!");
                return;
            }
            sendmail(dsAppvrEmails);

            Output.Show("Submitted Successfully");
            string TransferPage = "<script>window.open('ResignationRequest.aspx?msg=True','_self');</script>";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "temp", TransferPage, false);
            //Server.Transfer("EmpResignationStatus.aspx?msg=True");
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (EmpRule.Initiate == "Y" && EmpRule.ApplicationTypeId == ApplicationId)
            Initiate();
        else
            Output.Show("You do not have permission to initiate resignation application. Please contact admin.");
    }

    public void sendmail(DataSet ds)
    {
        string email = ds.Tables[0].Rows[0]["official_email_id"].ToString().Trim();
        DataSet daEmpName = (DataSet)ViewState["employeeName"];
        string empName = daEmpName.Tables[0].Rows[0]["EmpName"].ToString().Trim();
        string appvrName = ds.Tables[0].Rows[0]["name"].ToString().Trim();
        if (email != "")
        {
            sendmail_Template(email, appvrName, empName);
        }
    }

    private DataSet GetAppvrsEmail(SqlConnection conn)
    {

        string strAllemail;
        DataSet dsAllemail = new DataSet();
        DataSet ds3 = new DataSet();
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //transaction = connection.BeginTransaction();
        Label empcode = (Label)Grid.Rows[0].FindControl("lblempCode");
        try
        {
            strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name,empcode, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + empcode.Text.Trim() + "'";
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

    public bool sendmail_Template(string recievermailid, string approver, string employee)
    {
        try
        {
            //string senderId = "connect@escalon.services";
            //string senderPassword = "Escalon2017$";   
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];      
            string Template = EmailTemplate(approver, employee, UserCode);
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
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR" +
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
}