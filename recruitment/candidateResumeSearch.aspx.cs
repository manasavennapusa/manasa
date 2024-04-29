using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using System.Net;
using System.ComponentModel;
using System.Net.Mail;


public partial class recruitment_candidateResumeSearch : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string FName, UserCode, Role;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //Response.Redirect("~/Authenticate.aspx");
                UserCode = Session["empcode"].ToString();
                Role = Session["role"].ToString();
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bindgrid();
            bind_ddlRRF();
            binddesignation();
            //this.imgarrivaltime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtArvlTime'))");
            //if (Request.QueryString["updated"] != null)
            //    Output.Show("Candidate updated successfully");
        }
        //        CompareValidatordate.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");

        if (Request.QueryString["update"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        message.InnerHtml = "";
        //bindgrid();
    }

    private void cleartext()
    {

        txt_exp_from.Text = "";
        txt_exp_to.Text = "";
        txt_sal_from.Text = "";
        txt_sal_to.Text = "";
        txt_skills.Text = "";
    }

    protected void bindgrid()
    {
        string sqlstr = @"select id,rrf_id,candidate_name,dob,candidate_address,phone,mobile,emailid,Qualification,skills,experience,
joinstatus,expectedsalary,referredby,referrername,achievements,uploadresume,passportno,passportvalidity,note,status,relation_to_referrer,reasons_of_referrence,gender,consultancy_id,designation_id,
CONVERT(VARCHAR(15), Applied_Date, 106) as Applied_Date
 from tbl_recruitment_candidate_registration
  where status=1 and id not in(select candidateid  from tbl_recruitment_candidate_interview) order by id desc";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdcandidates.DataSource = ds;
        grdcandidates.DataBind();
    }

    protected void bind_ddlRRF()
    {
        //string sqlstr = "select * from tbl_recruitment_requisition_form where status=1 ";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        ddlRRF.DataTextField = "newrffcode";
        ddlRRF.DataValueField = "id";
        ddlRRF.DataSource = ds;
        ddlRRF.DataBind();
        ddlRRF.Items.Insert(0, new ListItem("-----Select-----", "0"));
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlParameter[] param = new SqlParameter[6];
        try
        {
            Output.AssignParameter(param, 0, "@skills", "String", 50, txt_skills.Text);
            Output.AssignParameter(param, 1, "@expriencefrom", "String", 50, txt_exp_from.Text);
            Output.AssignParameter(param, 2, "@exprienceto", "String", 50, txt_exp_to.Text);
            Output.AssignParameter(param, 3, "@exp_salaryfrom", "String", 50, txt_sal_from.Text);
            Output.AssignParameter(param, 4, "@exp_salaryto", "String", 50, txt_sal_to.Text);
            Output.AssignParameter(param, 5, "@designation", "String", 100, drpdesig.SelectedItem.ToString());

            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitmnet_resume_search", param);
            grdcandidates.DataSource = ds;
            grdcandidates.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void btnsearchclear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void lbtnview_Command(object sender, CommandEventArgs e)
    {
        string filepath = e.CommandArgument.ToString();
        DownLoad(Server.MapPath("~/recruitment/upload/" + filepath));

        // System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", " JavaScript:newPopup1('viewresume.aspx');", true);
    }

    public void DownLoad(string FName)
    {
        string path = FName;
        System.IO.FileInfo file = new System.IO.FileInfo(path);
        if (file.Exists)
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/word";
            Response.WriteFile(file.FullName);
            Response.End();
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        SqlParameter[] param = new SqlParameter[4];
        string cadidates = "";
        int seleted = 0;
        if (grdcandidates.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdcandidates.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label id = (Label)row.FindControl("lblID");
                    Label name = (Label)row.FindControl("lblname");
                    TextBox date = (TextBox)row.FindControl("txtDate");
                    TextBox time = (TextBox)row.FindControl("tbttime");
                    if (date.Text == "" || time.Text == "")
                    {
                        cadidates += "[" + id.Text + "-" + name.Text + "] ";
                    }
                    seleted++;
                }

            }
            if (seleted == 0)
            {
                Output.Show("Please Select Candidates");
                return;
            }
            if (cadidates.Trim() == "")
            {
                foreach (GridViewRow row in grdcandidates.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk.Checked)
                    {
                        Label id = (Label)row.FindControl("lblID");
                        Label name = (Label)row.FindControl("lblname");
                        Label email = (Label)row.FindControl("lblemail");
                        TextBox date = (TextBox)row.FindControl("txtDate");
                        TextBox time = (TextBox)row.FindControl("tbttime");

                        if (date.Text != "" && time.Text != "")
                        {
                            param[0] = new SqlParameter("@candidateId", SqlDbType.Int);
                            param[0].Value = Convert.ToInt32(id.Text);
                            param[1] = new SqlParameter("@round1date", SqlDbType.DateTime);
                            param[1].Value = Convert.ToDateTime(date.Text);
                            param[2] = new SqlParameter("@round1time", SqlDbType.VarChar, 10);
                            param[2].Value = time.Text;
                            param[3] = new SqlParameter("@rrfid", SqlDbType.Int);
                            param[3].Value = ddlRRF.SelectedValue;
                            string con = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString;
                            try
                            {
                                int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_candiate_interview", param);
                                if (i > 0)
                                {
                                    string sqlstr = "select candidate_name ,emailid from tbl_recruitment_candidate_registration where status=1 and id='" + id.Text.ToString() + "'";
                                    DataSet ds = new DataSet();
                                    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                                    // sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);

                                    string msgdetails = "Your  Interview is Scheduled on ";
                                    msgdetails += Convert.ToDateTime(date.Text.ToString()).ToString("dd-MMM-yyy");
                                    msgdetails += " at ";
                                    msgdetails += "(" + time.Text.ToString() + ").";
                                    msgdetails += "Please find below the further details:";
                                    msgdetails += "<br>";
                                    msgdetails += "<br>";
                                    msgdetails += "Venue: ESCALON BUSINESS SERVICES PRIVATE LIMITED.";
                                    msgdetails += "<br>" + "PLOT NO A 40 A 2ND FLOOR" + "<br>" + "CO-DEVELOPER QUARKCITY SEZ" + "<br>" + "INDUSTRIAL AREA PHASE VIII B" + "<br>" + "S.A.S NAGAR, MOHALI" + "<br>" + "PUNJAB 160059" + "<br>" + "<br>" + "Website : http://escalon.services/ " + "<br>" + "<br>" + "Feel free to get in touch with me in case of any assistance needed." + "<br>" + "*Please bring your updated CV and 1 passport size colored photograph." + "<br>" + "<br>" + "Kindly send your confirmation for the interview at jaspreet.kaur@escalon.services" + "<br>" + "Contact number: 01724643839";
                                    if (ds.Tables.Count != null || ds.Tables.Count != 0)
                                    {
                                        if (ds.Tables[0].Rows[0]["emailid"].ToString().Trim() != "")
                                        {
                                            sendmail_Template(ds.Tables[0].Rows[0]["emailid"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["candidate_name"].ToString(), msgdetails), "Interview Schedule");

                                        }
                                    }
                                    Output.Show("Submitted Successfully");

                                }
                                else
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                                Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
                            }
                        }

                    }

                }
            }
            else
            {
                Output.Show("Please Enter Date and Time for the Candidate: " + cadidates);

            }
            bindgrid();
        }
    }
    public bool sendmail_Template(string recievermailid, string bdy, string sub)
    {

        try
        {
            string sqlstr = "select official_email_id from tbl_intranet_employee_jobDetails where empcode='EIN1108'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            //string senderId = "connect@escalon.services"; // Sender EmailID
            //string senderPassword = "Escalon2017$"; // Sender Password  
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];   
            string Template = bdy;
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);
            mailMessage.CC.Add(ds.Tables[0].Rows[0]["official_email_id"].ToString());

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

                                                            //"<p>Click here - https://escalon.sdlapps.com </p>" +

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
    protected void sendMail(string id, string candidatename, string emailid, string date, string time)
    {

        if (id != "" && candidatename != "" && emailid != "")
        {

            string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
            string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
            string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
            string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
            string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
            string subject = ConfigurationManager.AppSettings["subject"].ToString();
            string greet = ConfigurationManager.AppSettings["greet"].ToString();
            string bodyContent = ConfigurationManager.AppSettings["bodyContent"].ToString();
            string body1 = ConfigurationManager.AppSettings["body1"].ToString();
            string venue = ConfigurationManager.AppSettings["venue"].ToString();
            string company = ConfigurationManager.AppSettings["company"].ToString();
            string add1 = ConfigurationManager.AppSettings["add1"].ToString();
            string add2 = ConfigurationManager.AppSettings["add2"].ToString();
            string add3 = ConfigurationManager.AppSettings["add3"].ToString();
            string phone = ConfigurationManager.AppSettings["phone"].ToString();
            string contact = ConfigurationManager.AppSettings["conctact"].ToString();
            string dt = "<b>Date :</b>" + date;
            string tm = "<b>Time :</b>" + time;
            string all = "<b>" + greet + "</b>" + "<br/>" + bodyContent + "<br/><br/>" + body1 + "<br/><br/>" + dt + "<br/>" + tm + "<br/><br/>" + venue + "<br/>" + company + "<br/>" + add1 + "<br/>" + add2 + "<br/>" + add3 + "<br/>" + phone + "<br/>" + contact;
            string completeBody = Email.GetBody(fromName, candidatename.ToString(), all);

            Email.getemail(fromEmail, fromPwd, fromName, emailid.ToString(), "", subject, completeBody, smtp, emailLogo);

        }
    }

    protected void grdcandidates_PreRender(object sender, EventArgs e)
    {
        if (grdcandidates.Rows.Count > 0)
        {
            grdcandidates.HeaderRow.TableSection = TableRowSection.TableHeader;

        }

    }

    protected void drpdesig_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void drpdesig_DataBound(object sender, EventArgs e)
    {

    }

    protected void binddesignation()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select  id,designationname FROM tbl_intranet_designation";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpdesig.DataSource = ds;
                drpdesig.DataTextField = "designationname";
                drpdesig.DataValueField = "id";
                drpdesig.DataBind();
            }
            drpdesig.Items.Insert(0, new ListItem("--Select--", "0"));
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

    //protected void binddesignation()
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string sqlstr = "select  id,designationname FROM tbl_intranet_designation";
    //        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            drpdesig.DataSource = ds;
    //            drpdesig.DataTextField = "designationname";
    //            drpdesig.DataValueField = "id";
    //            drpdesig.DataBind();
    //        }
    //        drpdesig.Items.Insert(0, new ListItem("--Select--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    protected void btnselect3_Click(object sender, EventArgs e)
    {
        SqlParameter[] param = new SqlParameter[4];
        string cadidates = "";
        int seleted = 0;
        if (grdcandidates.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdcandidates.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label id = (Label)row.FindControl("lblID");
                    Label name = (Label)row.FindControl("lblname");
                    TextBox date = (TextBox)row.FindControl("txtDate");
                    TextBox time = (TextBox)row.FindControl("tbttime");
                    if (date.Text == "" || time.Text == "")
                    {
                        cadidates += "[" + id.Text + "-" + name.Text + "] ";
                    }
                    seleted++;
                }

            }
            if (seleted == 0)
            {
                Output.Show("Please Select Candidates");
                return;
            }
            if (cadidates.Trim() == "")
            {
                foreach (GridViewRow row in grdcandidates.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk.Checked)
                    {
                        Label id = (Label)row.FindControl("lblID");
                        Label name = (Label)row.FindControl("lblname");
                        Label email = (Label)row.FindControl("lblemail");
                        TextBox date = (TextBox)row.FindControl("txtDate");
                        TextBox time = (TextBox)row.FindControl("tbttime");

                        if (date.Text != "" && time.Text != "")
                        {
                            param[0] = new SqlParameter("@candidateId", SqlDbType.Int);
                            param[0].Value = Convert.ToInt32(id.Text);
                            param[1] = new SqlParameter("@round3date", SqlDbType.DateTime);
                            param[1].Value = Convert.ToDateTime(date.Text);
                            param[2] = new SqlParameter("@round3time", SqlDbType.VarChar, 10);
                            param[2].Value = time.Text;
                            param[3] = new SqlParameter("@rrfid", SqlDbType.Int);
                            param[3].Value = ddlRRF.SelectedValue;
                            string con = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString;
                            try
                            {
                                int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_select_candiate_interview_searchreasumetoround3", param);
                                if (i > 0)
                                {
                                    // sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
                                    Output.Show("Submitted Successfully");
                                }
                                else
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                                Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
                            }
                        }

                    }

                }
            }
            else
            {
                Output.Show("Please Enter Date and Time for the Candidate: " + cadidates);

            }
            bindgrid();
        }
    }

    protected void grdcandidates_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            activity.OpenConnection();

            int a = (int)grdcandidates.DataKeys[(int)e.RowIndex].Value;
            if (a != 0)
            {
                string d = "delete from tbl_recruitment_candidate_registration where id=" + a;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, d);
                Output.Show("Deleted Successfully");
                bindgrid();
            }
            else
            {
                Output.Show("Please select the record...");
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

    //protected void DownloadFile(object sender, EventArgs e)
    //{
    //    FName = "~/recruitment/upload/";
    //    //string path = FName;
    //    //string filePath = (sender as LinkButton).CommandArgument;
    //    string filePath = FName;
    //    Response.ContentType = ContentType;
    //    Response.AppendHeader("Content-Disposition", "attachment; filename=" + Path.GetFileName(filePath));
    //    Response.WriteFile(filePath);
    //    Response.End();
    //}


    protected void grdcandidates_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        //for (int i = 0; i < basicinfolistgrid.Columns.Count; i++)
        //{
        //    }

        TableHeaderCell cell = new TableHeaderCell();
        TableHeaderCell cell1 = new TableHeaderCell();
        TableHeaderCell cell2 = new TableHeaderCell();
        TableHeaderCell cell3 = new TableHeaderCell();

        TextBox tbItemName = new TextBox();
        tbItemName.Attributes["placeholder"] = "Search Part Number";
        tbItemName.Attributes.Add("style", "padding:5px;border:2px solid #c8e8ee;width:200px; border-radius:5px");

        tbItemName.CssClass = "search_textbox";
        cell.Controls.Add(tbItemName);
        row.Controls.Add(cell);
        row.Controls.Add(cell1);
        row.Controls.Add(cell2);
        row.Controls.Add(cell3);
        //   grdcandidates.HeaderRow.Parent.Controls.AddAt(0, row);
    }

    protected void btserch_Click(object sender, EventArgs e)
    {

        string sqlstr1 = @"select id,rrf_id,candidate_name,dob,candidate_address,phone,mobile,emailid,Qualification,skills,experience,
joinstatus,expectedsalary,referredby,referrername,achievements,uploadresume,passportno,passportvalidity,note,status,relation_to_referrer,reasons_of_referrence,gender,consultancy_id,designation_id,
CONVERT(VARCHAR(15), Applied_Date, 106) as Applied_Date
 from tbl_recruitment_candidate_registration
  where status=1 and candidate_name like '" + search_textbox.Text + "%" + "' and id not in(select candidateid  from tbl_recruitment_candidate_interview rci left join tbl_recruitment_candidate_registration rcr on rcr.id=rci.candidateid  where rcr.candidate_name like '" + search_textbox.Text + "%" + "' ) order by id desc";
        DataSet ds1 = new DataSet();
        ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
               
            grdcandidates.DataSource = ds1;
            grdcandidates.DataBind();
             
            }
        }

   

