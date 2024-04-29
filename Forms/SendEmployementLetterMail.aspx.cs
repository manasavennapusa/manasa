using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Common.Console;
using System.Net.Mail;
using System.Net.Mime;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using Common.Data;

public partial class Forms_SendEmployementLetterMail : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    static string prevPage = String.Empty; // static variable

    protected void Page_Load(object sender, EventArgs e)
    {
        string email = Request.QueryString["toemail"].ToString();
        string name = Request.QueryString["Name"].ToString();
        tbto.Text = email.ToString();
        lblname.Text = name;
    }

    protected void SendEmail(object sender, EventArgs e)
    {
        try
        {
            MailMessage mail = new MailMessage(tbfrom.Text, tbto.Text);
            //mail.To.Add(tbto.Text);

            mail.CC.Add("ritu.chitra@escalon.services");

            //mail.CC.Add("ansumanmishracool.am@gmail.com");

            mail.Subject = tbsubject.Text;
            //mail.Body = tbmessage.Text;


            mail.Body = @"<html xmlns='http://www.w3.org/1999/xhtml'>" +
"<head runat='server'>" +
    "<title></title>" +
"</head>" +
"<body>" +
    "<form id='form1' runat='server'>" +
    "<div>" +
        "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
            "<tr>" +
                "<td><asp:Label ID='lblname' runat='server' style='font-family:Cambria;font-weight:600'>Dear " + lblname.Text + "</asp:Label>" +
                "</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                          "<br/>" +
                "</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                    "<asp:Label ID='lblmessage' runat='server'>" + tbmessage.Text + "</asp:Label>" +
                "</td>" +
            "</tr>" +
            "<tr>" +
                "<td>" +
                       "<br/>" +
                "</td>" +
            "</tr>" +
        "</table>" +
        "<table><tr><td><br/></td></tr></table>" +
        "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
        "<tbody>" +
           "<tr>" +
            "<td colspan='2' style='text-align: justify;font-family:Cambria;font-weight:600'>" +
              "<hr />" +
                 "This is a system generated mail. Please do not reply to this email ID." +
                 "<hr />" +
                 "<br/>" +
              "</td>" +
            "</tr>" +
          "</tbody>" +
        "</table>" +
    "</div>" +
    "</form>" +
"</body>" +
"</html>";


            if (File_UploadDft.HasFile)
            {
                mail.Attachments.Add(new Attachment(File_UploadDft.PostedFile.InputStream, File_UploadDft.FileName));
            }
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Port = 25;
            smtp.Host = "secure.emailsrvr.com";
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("connect@escalon.services", "Escalon2017$");
            smtp.Send(mail);
            Output.Show("Sent Successfully");
            //Reset();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
            Output.Show("Message Not Sent.Please contact system admin.For error details please go through the log file");
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateEmployementLetter.aspx");
    }

    protected void Reset()
    {
        tbfrom.Text = "";
        tbto.Text = "";
        tbsubject.Text = "";
        tbmessage.Text = "";
        File_UploadDft.Attributes.Clear();
    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Reset();
    }

}