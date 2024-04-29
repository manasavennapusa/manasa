using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Date;
using Common.Data;
using Common.Console;
using System.Net.Mail;

public partial class leave_applyholidaywork : System.Web.UI.Page
{
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    DataSet ds = new DataSet();
    int error = 0;
    string comment;
    string fromdt;
    private string _companyId, _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null && Session["role"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();

            if (!IsPostBack)
            {
                bind_empdetail();
            }
        }
        else
            Response.Redirect("~/notlogged.aspx");
    }
    #region Bind Employee Details
    protected void bind_empdetail()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm.Value = Session["empcode"].ToString();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);

            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
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
    #region Submit Button Click
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        SqlTransaction transaction = null;
        try
        {

            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            validatecompoff(connection, transaction);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Comp-off application some problem is their. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Insert the Comp off Details
    protected int insert_compoff_mark(SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@day", SqlDbType.Decimal);
        if (ddl_extrahour.SelectedIndex == 0)
            sqlparam[1].Value = 0.5;
        else
            sqlparam[1].Value = 1;

        sqlparam[2] = new SqlParameter("date", SqlDbType.DateTime);
        sqlparam[2].Value = Utilities.Utility.dataformat(txt_date.Text.Trim().ToString());

        sqlparam[3] = new SqlParameter("@half", SqlDbType.Bit);

        if (ddl_extrahour.SelectedIndex == 0)
            sqlparam[3].Value = 0;
        else
            sqlparam[3].Value = 1;


        sqlparam[4] = new SqlParameter("@approval_status", SqlDbType.Int, 3);
        sqlparam[4].Value = 0;

        sqlparam[5] = new SqlParameter("@reason", SqlDbType.VarChar, 1500);
        if (txt_comment.Text != "")
            comment = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            comment = "";
        sqlparam[5].Value = comment.ToString();

        sqlparam[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[6].Value = Session["name"].ToString();

        int a = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "[sp_leave_insert_marked_compoff_attendance]", sqlparam));

        return a;

    }
    #endregion
    #region validate compoff
    protected void validatecompoff(SqlConnection connection, SqlTransaction transaction)
    {
        //if (!ValidateCompoffDate(connection, transaction))
        //    return;
        SqlParameter[] sqparm = new SqlParameter[2];

        sqparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqparm[0].Value = Session["empcode"].ToString();

        sqparm[1] = new SqlParameter("@applieddate", SqlDbType.VarChar, 50);
        sqparm[1].Value = txt_date.Text;

        btn_sbmit.Enabled = false;

        int leaveid = 0;
        ArrayList list = new ArrayList();
         
        int b = insert_compoff_mark(connection, transaction);
        if (b > 0)
        {
            list.Add("Comp-Off Marked successfully");
            error++;
        }
        else
        {
            SmartHr.Common.Alert("You have already marked for Comp-off");
        }
        if (error > 0)
        {
            //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                //mailtoapprover(list, b, "co");

            SendMail(b);
            sendmailtoemp(b);
            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str = str + list[i].ToString();
                str = str + "\\n";
            }
            clearfield();
            SmartHr.Common.Alert(str);
        }
       

        btn_sbmit.Enabled = true;

    }
    #endregion
    #region Validate Compoff Date
    private bool ValidateCompoffDate(SqlConnection connection, SqlTransaction transaction)
    {
        string sqlstr = @"select count(*) as Weekoff from tbl_payroll_employee_attendence_detail where MODE in ('H','W') and EMPCODE='" + Session["empcode"].ToString() + "' and DATE='" + Utility.DateFormat(txt_date.Text).ToString() + "'";
        DataSet dspayroll = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);
        if (dspayroll.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(dspayroll.Tables[0].Rows[0]["Weekoff"].ToString()) <= 0)
            {
                Output.Show("You have to apply on week offs or holidays.please check the selected date.");
                return false;
            }
        }
        else
        {
            Output.Show("Attendance is not processed for the select date. Please contact your system admin.");
            return false;
        }
        SqlParameter[] sqparm = new SqlParameter[2];

        sqparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqparm[0].Value = Session["empcode"].ToString().Substring(3);

        sqparm[1] = new SqlParameter("@applieddate", SqlDbType.VarChar, 50);
        sqparm[1].Value = txt_date.Text;
        DataSet dsattendace = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_leave_get_presentornot", sqparm);
        if (dsattendace.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToInt32(dsattendace.Tables[0].Rows[0]["Punch"].ToString()) <= 0)
            {
                Output.Show("You are Absent for selected date.please check the selected date.");
                return false;
            }
        }
        return true;

    }
    #endregion
    #region Bind Employee Details
    //protected void mailtoapprover(ArrayList list, int leaveid, string type)
    //{

    //    SqlParameter[] sqlparm = new SqlParameter[2];
    //    sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
    //    sqlparm[1] = new SqlParameter("@type", type);
    //    DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
    //    if (ds.Tables[0].Rows.Count > 0)
    //    {

    //        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
    //        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
    //        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
    //        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
    //        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

    //        Common.Encode.QueryString q = new Common.Encode.QueryString();
    //        string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[0]["id"].ToString(), ds.Tables[0].Rows[0]["empcode"].ToString(), ds.Tables[0].Rows[0]["approvercode"].ToString(), "CA");
    //        string encoded;
    //        encoded = q.EncodePairs(pairs);

    //        string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
    //        string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";

    //        string subject = "Holiday Work  Application for Approval";
    //        string bodyContent = "A new Holiday Work  request has been submitted by employee " + Session["name"].ToString() + " from " + txt_date.Text + " to " + txt_date.Text + ". <br/><br/>  Kindly login to the leave module to view the request:<br/><br/> " + url + " " + url1;

    //        string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[0]["a_name"].ToString(), bodyContent);
    //        if (ds.Tables[0].Rows[0]["official_email_id"].ToString() != "")
    //        {
    //            try
    //            {
    //                Email.getemail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
    //            }
    //            catch
    //            {
    //                list.Add("Holiday Work  mail is not delivered to the Approver. Due to some technical problem.");
    //            }
    //        }
    //        else
    //        {
    //            list.Add("Holiday Work  mail  is not delivered to the Approver. Email id does not exists.");
    //        }



    //    }
    //}
    #endregion
    #region Reset Button Click
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clearfield();
    }
    #endregion
    #region Clear the Fields
    protected void clearfield()
    {
        txt_date.Text = "";
        ddl_extrahour.SelectedIndex = 0;
        txt_comment.Text = "";
    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }


    private void SendMail(int leaveid)
    {
        
           fromdt = txt_date.Text;
           
        
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
        //SqlParameter[] sqlparm = new SqlParameter[2];
        //Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        //Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "co");


        string query = @"select distinct job.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_employee_approvers app 
inner join dbo.tbl_intranet_employee_jobDetails job 
on job.empcode=app.clr_department
inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager 
where app.empcode='" + Session["empcode"].ToString() + "'";

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //string appmsg = "Dear " + ds.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            //appmsg += " You have a pending Leave Application from " + lbl_emp_name.Text.Trim() + " - " + _userCode.Trim() + "\n" + "\n " + "\n";
            //appmsg += "Regards" + "," + "\n";
            //appmsg += "HR" + "\n";
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["emp_fname"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(), fromdt, ds.Tables[0].Rows[i]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[i]["dlm_mail"].ToString().Trim());
            }
        }


    }

    public bool sendmail_Template(string recievermailid, string approver, string employee, string empcode, string fromdt,string lm_mail,string dlm_mail)
    {

        try
        {

            //string senderId = "admin@sdlglobe.com"; // Sender EmailID
            //string senderPassword = "Smart@123"; // Sender Password      
            //string subject = "Leave Application - Pending";
            //string FileName = string.Empty;
            //string body = EmailTemplate(approver, employee, empcode);
            //System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            //mailMessage.To.Add(recievermailid);
            //mailMessage.From = new MailAddress(senderId);
            //mailMessage.Subject = subject;
            //mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            //mailMessage.Body = body;
            //mailMessage.Priority = MailPriority.High;
            //SmtpClient smtpClient = new SmtpClient();
            //smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            //smtpClient.Port = 25;
            //smtpClient.Host = "md-in-59.webhostbox.net";
            //smtpClient.EnableSsl = true;
            //object userState = mailMessage;

            //try
            //{
            //    smtpClient.Send(mailMessage);

            //    return true;
            //}
            //catch (System.Net.Mail.SmtpException)
            //{
            //    return false;
            //}
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];      

            string Template = EmailTemplate(approver, employee, empcode, fromdt);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Holiday Application";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;

            //if (fileAttachment.HasFile)
            //{
            //    FileName = Path.GetFileName(fileAttachment.PostedFile.FileName);
            //    FileName = "attachments/" + FileName;
            //    fileAttachment.PostedFile.SaveAs(Server.MapPath(FileName));

            //    attachment = new System.Net.Mail.Attachment(Server.MapPath(FileName));
            //    mailMessage.Attachments.Add(attachment);

            //    IsAttachment = true;
            //}

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
    public string EmailTemplate(string approver, string employee, string empcode, string fromdt)
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Holiday work request  from  " + emp + " - " + empcod + " date  " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + "  for Approval / Reject.</p>" +

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

    private void sendmailtoemp(int leaveid)
    {

        fromdt = txt_date.Text;

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        string query = @"select distinct jobvh.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_intranet_employee_jobDetails job
 inner join tbl_employee_approvers app on app.empcode=job.empcode
 inner join tbl_intranet_employee_jobDetails jobvh on jobvh.empcode=app.clr_department
 inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
 inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager
 where job.empcode='" + Session["empcode"].ToString() + "'";

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template1(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["emp_fname"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(), fromdt, ds.Tables[0].Rows[i]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[i]["dlm_mail"].ToString().Trim());
            }
        }


    }

    public bool sendmail_Template1(string recievermailid, string approver, string employee, string empcode, string fromdt, string lm_mail, string dlm_mail)
    {

        try
        {
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];

            string Template = EmailTemplate1(approver, employee, empcode, fromdt);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Holiday Application";
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

    public string EmailTemplate1(string approver, string employee, string empcode, string fromdt)
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
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your holiday work application has been submitted successfully to Virtual Head "+appr+" from date " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + "  for Approval / Reject. Once approved by the virtual head your Comp off balance would be added in the attendance module.</p>" +

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
}
