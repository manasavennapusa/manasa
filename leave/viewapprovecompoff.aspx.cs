using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Net.Mail;
public partial class leave_viewapprovecompoff : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    int error = 0;
    DataActivity activity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_requested_compoff();
        }
    }

    protected void leave_approval_grid_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        SqlTransaction _Transaction = null;
        if (e.CommandName == "reject")
        {

            string ecode = "";
            string date = "";
            int leaveid = 0;
            ArrayList list = new ArrayList();
            try
            {

                SqlConnection _Connection = activity.OpenConnection();
                _Transaction = _Connection.BeginTransaction();

                string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
                int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
                ecode = commandArgsAccept[1].ToString();//it gives second ID
                date = commandArgsAccept[2].ToString();

                sqlstr = "update tbl_leave_approve_compoff set approval_status='2' where id=" + eid + "";
                SQLServer.ExecuteScalar(_Connection, CommandType.Text, _Transaction, sqlstr);
                _Transaction.Commit();
                list.Add("Comp-off leave  request rejected successfully.");
                error++;
            }

            catch (Exception ex)
            {
                _Transaction.Rollback();
                Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                activity.CloseConnection();
            }


            if (error > 0)
            {
                //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    MailtoEmployee(list, "C", ecode.Trim(),date);
       
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {
                    str = str + list[i].ToString();
                    str = str + "\\n";
                }


                SmartHr.Common.Alert(str);
                // Response.Redirect("leave_status.aspx?leavestatus=0");
            }

        }
        if (e.CommandName == "accept")
        {
            try
            {

                SqlConnection _Connection = activity.OpenConnection();
                _Transaction = _Connection.BeginTransaction();
                string[] commandArgsAccept = e.CommandArgument.ToString().Split(new char[] { ',' });
                int eid = Convert.ToInt32(commandArgsAccept[0].ToString());//it gives first ID                
                string ecode = commandArgsAccept[1].ToString();//it gives second ID
                string date = commandArgsAccept[2].ToString();

                sqlstr = "update tbl_leave_approve_compoff set approval_status='1' where id=" + eid + "";
                SQLServer.ExecuteScalar(_Connection, CommandType.Text, _Transaction, sqlstr);
                insert_attendance_employee_compoff_table(eid, ecode.Trim(),date, _Connection, _Transaction);
                _Transaction.Commit();

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
        bind_requested_compoff();
    }

    protected void insert_attendance_employee_compoff_table(int id, string empcode,string date, SqlConnection connection, SqlTransaction transcation)
    {
       

        int leaveid = 0;
        ArrayList list = new ArrayList();

        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = Convert.ToInt32(id);

        int y = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transcation, "[sp_leave_insert_marked_compoff_attendance_approved]", sqlparam);

      
        list.Add("Holiday Work  mark request accepted successfully.");
        error++;



        if (error > 0)
        {
            //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
               MailtoEmployee(list, "A", empcode,date);

            string str = "";
            for (int i = 0; i < list.Count; i++)
            {
                str = str + list[i].ToString();
                str = str + "\\n";
            }


            SmartHr.Common.Alert(str);
            // Response.Redirect("leave_status.aspx?leavestatus=0");
        }



        //   message.InnerHtml = "";

    }
    //private void mailtoemployee(ArrayList list, string a, string empcode)
    //{
    //    SqlConnection connection = activity.OpenConnection();
    //    string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";

    //    DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, sqlstr);
    //    if (ds1.Tables[0].Rows.Count > 0)
    //    {
    //        string subject = "";
    //        string bodyContent = "";
    //        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
    //        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
    //        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
    //        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
    //        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

    //        if (a == "A")
    //        {
    //            subject = "Your Holiday Work  Application Approved Sucessfully. ";
    //            bodyContent = "Your Holiday Work  Application Approved By " + Session["name"].ToString();
    //        }
    //        else if (a == "C")
    //        {

    //            subject = "Cancelation of Compoff Application. ";
    //            bodyContent = "Your Holiday Work  Application Cancled By " + Session["name"].ToString();
    //        }
    //        string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
    //        if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
    //        {
    //            try
    //            {
    //                Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
    //            }
    //            catch
    //            {
    //                list.Add("Holiday Work  mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
    //            }
    //        }
    //        else
    //        {
    //            list.Add("Holiday Work  mail  is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
    //        }


    //    }
    //    activity.CloseConnection();
    //}
    protected void bind_requested_compoff()
    {
        try
        {
            SqlConnection conn = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[1];
            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 20);
            sqlparam[0].Value = Session["empcode"].ToString();
            ds = SQLServer.ExecuteDataset(conn, CommandType.StoredProcedure, "sp_leave_fetch_compoff_attendance_request", sqlparam);
            leave_approval_grid.DataSource = ds;
            leave_approval_grid.DataBind();
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
    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    private void MailtoEmployee(ArrayList list, string a, string empcode,string date)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select distinct job.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_intranet_employee_jobDetails job
 inner join tbl_employee_approvers app on app.empcode=job.empcode
 inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
 inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager
 where job.empcode='" + empcode + "'";
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

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


                        //EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponApprovalOfRequestFinalStep();
                        //EmailClient client = new EmailClient(email);
                        //client.toEmailId = ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim();
                        //client.employeeName = ds.Tables[0].Rows[j]["empname"].ToString().Trim();
                        //client.requestNumber = leaveid.ToString();
                        //client.Send();
                        //string empAprvemsg = "Dear " + ds.Tables[0].Rows[j]["empname"].ToString().Trim() + "," + "\n" + "\n";
                        //empAprvemsg += "Your Leave Application has been successfully Approved by " + Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString() + "\n" + "\n " + "\n";
                        //empAprvemsg += "Regards" + "," + "\n";
                        //empAprvemsg += "HR" + "\n";
                        if (a == "C")
                        {
                            if (ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim() != "")
                            {
                                string msgdetails = "Your Holiday Work Application";
                                msgdetails += " has been Rejected by Virtual Head " + Session["name"].ToString().Trim() + " from date " + date + ".";
                                sendmail_Template(ds.Tables[0].Rows[j]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[j]["emp_fname"].ToString().Trim(), msgdetails), "Holiday Application Status", ds.Tables[0].Rows[j]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[j]["dlm_mail"].ToString().Trim());

                            }
                        }
                        else if (a == "A")
                        {
                            if (ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim() != "")
                            {
                                string msgdetails = "Your Holiday Work Application";
                                msgdetails += " has been Approved successfully by Virtual Head " + Session["name"].ToString().Trim() + " from date " + date + ".";
                                sendmail_Template(ds.Tables[0].Rows[j]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[j]["emp_fname"].ToString().Trim(), msgdetails), "Holiday Application Status", ds.Tables[0].Rows[j]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[j]["dlm_mail"].ToString().Trim());

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["empname"] +
                                 " due to some technical problem.");
                        throw ex;
                    }
                }
                else
                {
                    list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[j]["empname"]);
                }

                i--;
                j++;
            }
        }

    }
    public bool sendmail_Template(string recievermailid, string bdy, string sub, string lm_mail, string dlm_mail)
     {

         try
         {

             string senderId = ConfigurationManager.AppSettings["fromEmail"];
             string senderPassword = ConfigurationManager.AppSettings["pwd"];       

             string Template = bdy;
             bool IsAttachment = false;
             string FileName = string.Empty;
             System.Net.Mail.Attachment attachment = null;

             System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
             mailMessage.To.Add(recievermailid);
             mailMessage.CC.Add(lm_mail);
             mailMessage.CC.Add(dlm_mail);
             mailMessage.From = new MailAddress(senderId);

             mailMessage.Subject = sub;
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
     public string EmailTemplate(string employee, string msg)
     {

         string emp = employee.ToString();

         string EmailFormat =
         @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
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
                                                             "<p style='text-align: justify; color: #000000; text-align: justify'> " + msg + "</p>" +

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


