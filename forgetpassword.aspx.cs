using Common.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Web.Security;

public partial class forgetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }

    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }

    public static string CreateRandomPassword(int PasswordLength)
    {
        string _allowedChars = "0123456789abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ";
        Random randNum = new Random();
        char[] chars = new char[PasswordLength];
        int allowedCharCount = _allowedChars.Length;
        for (int i = 0; i < PasswordLength; i++)
        {
            chars[i] = _allowedChars[(int)((_allowedChars.Length) * randNum.NextDouble())];
        }
        return new string(chars);
    }

    public bool SendMail(string pwd, string toEmailId, string empcode, string empName)
    {
        //Smart.HR.Common.Mail.Module.Email email = new Smart.HR.Common.Mail.Module.Email();
        //email.FromEmailId = ConfigurationManager.AppSettings["fromEmail"].ToString();
        //email.Password = ConfigurationManager.AppSettings["pwd"].ToString();
        //email.FromName = ConfigurationManager.AppSettings["fromName"].ToString();
        //email.SMTP = ConfigurationManager.AppSettings["smtp"].ToString();
        //email.ToEmailId = toEmailId;
        //email.IsHtml = true;
        //email.Subject = "Password Reset";
        //string Template = EmailTemplate(pwd, empName);
        ////string preBody = "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Dear " + empName + ",</p>";
        ////preBody += "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>You password is : </p>";

        ////string body = pwd;

        ////string postBody = "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Thanks</p>";
        ////postBody += "<p style='font-size:11.0pt;font-family:Calibri,sans-serif;'>Escalon - HR Team</p>";

        //email.Body = Template; 
        //email.Send();

        try
        {
            //string senderId = "connect@escalon.services";
            //string senderPassword = "Escalon2017$";

            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];   

            string Template = EmailTemplate(pwd, empName);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(toEmailId);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Password Reset";
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

    public string EmailTemplate(string pwd, string empName)
    {
        string password = pwd.ToString();
        string emp = empName.ToString();
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
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your password has been successfully changed and your new password is " +password+"</p>"+
                                                            "<p>Click here - https://escalon.sdlapps.com </p>" +

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

    protected void Reset_Click(object sender, EventArgs e)
    {
        if (empcode.Value.Trim() == "")
        {
            Common.Console.Output.Show("Please enter your employee code.");
            return;
        }
        else if (email.Value.Trim() == "")
        {
            Common.Console.Output.Show("Please enter your official email id.");
            return;
        }
        else
        {
            SqlConnection Connection = null;
            string password = "";
            string ecode = "";
            string ename = "";
            string officialemailid = "";

            Common.Data.DataActivity Activity = new Common.Data.DataActivity();
            string Query = @"select *
                                  from  tbl_intranet_employee_jobDetails 
                                   where empcode = '" + empcode.Value.Trim() + "' and official_email_id = '" + email.Value.Trim() + "'";
            try
            {
                Connection = Activity.OpenConnection();
                DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    ecode = row["empcode"].ToString();
                    ename = row["emp_fname"].ToString();
                    officialemailid = row["official_email_id"].ToString();

                    Random random = new Random();
                    password = CreateRandomPassword(8);
                    int saltSize = 5;
                    string salt = CreateSalt(saltSize);
                    string passwordHash = CreatePasswordHash(password.ToString(), salt);
                    Query = @"insert into tbl_login_history( login_id,pwd,empcode,role,status,createddate,updateddate,lastlogin)
                                 select login_id,pwd,empcode,role,status,createddate,updateddate,lastlogin from  tbl_login where empcode='" + empcode.Value.Trim() + "'";
                    Common.Data.SQLServer.ExecuteNonQuery(Connection, CommandType.Text, Query);

                    Query = "update tbl_login set pwd='" + passwordHash + "' ,lastlogin=GETDATE()  where empcode= '" + empcode.Value.Trim() + "' and status = 1";
                    Common.Data.SQLServer.ExecuteNonQuery(Connection, CommandType.Text, Query);

                }
                else
                {
                    Common.Console.Output.Show("Your given information is incorrect. Please enter the correct information.");
                }

            }
            catch (Exception ex)
            {
                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                Activity.CloseConnection();
            }
          
            try
            {
                SendMail(password, officialemailid, ecode, ename);
                Common.Console.Output.Show("Employee Password Resetted Successfully!!!");
            }
            catch
            {
                Common.Console.Output.Show("There is some techinical issue. Please try again later.");
            }

        }

    }
}
