using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Net.Mail;

public partial class recruitment_candidatesSelectedForRound1 : System.Web.UI.Page
{
    private string _userCode, Role;
    string sqlstr, emp_code;
    string qry;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null && Session["empcode"] != null)
        {
            //Response.Redirect("~/Authenticate.aspx");
            _userCode = Session["empcode"].ToString();
            Role = Session["role"].ToString();
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //Response.Redirect("~/Authenticate.aspx");

            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgridinround22();
            bindgrid();
            bindddlrrfcode();
            bindgridinround1();
            bindddlrrf();

        }
        // CompareValidator16.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
        if (Request.QueryString["update"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        //message.InnerHtml = "";
    }

    //Start Grid For Round One
    protected void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_for_Round1");
        grdcandidates.DataSource = ds;
        grdcandidates.DataBind();
        bind_ddlpaper();

    }

    protected void bindddlrrfcode()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        ddlrrfcode.DataTextField = "newrffcode";
        ddlrrfcode.DataValueField = "id";
        ddlrrfcode.DataSource = ds;
        ddlrrfcode.DataBind();
        ddlrrfcode.Items.Insert(0, new ListItem("---------Select---------", "0"));
    }

    protected void ddlrrfcode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrrfcode.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddlrrfcode.SelectedValue);
            SqlParameter[] sqlParam = new SqlParameter[1];

            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;
            //string sqlstr = "select * from tbl_recruitment_requisition_form where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_for_Round1byRRFCODE", sqlParam);
            grdcandidates.DataSource = ds;
            grdcandidates.DataBind();
            bind_ddlpaper();
        }
        else
        {
            bindgrid();
        }
    }

    protected void bind_ddlpaper()
    {
        string sqlstr = "select id,papercode,papername from tbl_recruitment_paper_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        foreach (GridViewRow row in grdcandidates.Rows)
        {
            DropDownList ddlpaper = (DropDownList)row.FindControl("ddlpaper");
            ddlpaper.DataTextField = "papername";
            ddlpaper.DataValueField = "id";
            ddlpaper.DataSource = ds;
            ddlpaper.DataBind();
            ddlpaper.Items.Insert(0, new ListItem("---Select---", "0"));
        }
    }

    protected void btnSelect_Click(object sender, EventArgs e)
    {
        if (grdcandidates.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdcandidates.Rows)
            {
                int count = 0;
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label id = (Label)row.FindControl("lblID");
                    Label name = (Label)row.FindControl("lblname");
                    Label email = (Label)row.FindControl("lblemail");
                    TextBox marks = (TextBox)row.FindControl("txtmarks");
                    DropDownList paper = (DropDownList)row.FindControl("ddlpaper");
                    count = count + 1;
                    if (marks.Text != "" && paper.SelectedValue != "0")
                    {
                        string sqlstr = "update tbl_recruitment_candidate_interview set round1_paperid='" + paper.SelectedValue + "', round_1_marks='" + marks.Text + "',round_1_status='S' where candidateid='" + id.Text + "' "; //(case when (select passmarks from tbl_recruitment_paper_master where id='" + ddlpaper.SelectedValue + "')<='" + lblmarks.Text + "' then 'S' else 'R' end)
                        DataSet ds = new DataSet();
                        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                        if (i < 0)
                        {
                            //SendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
                            Output.Show("Please Select Candidate");

                        }
                        else
                        {
                            Output.Show("Candidates Selected");
                        }
                    }
                    else
                    {
                        Output.Show("Please enter Paper & Marks scored before selecting candidate");
                    }
                }
                else
                {
                    Output.Show("Please select candidate");
                }
                //if (count <= 0)
                //{
                //    Output.Show("Please Select candidate");
                //    //return;
                //}
                //else
                //{
                //    Output.Show("Candidate Selected Successfully");
                //}
            }
            Output.Show("Please select Function and Marks");
            bindgrid();
            bindgridinround1();
            cleartext();
        }
        else
        {
            Output.Show("Please select Function and marks");
        }
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        if (grdcandidates.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdcandidates.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkselect");
                if (chk.Checked)
                {
                    Label id = (Label)row.FindControl("lblID");
                    Label name = (Label)row.FindControl("lblname");
                    Label email = (Label)row.FindControl("lblemail");
                    TextBox marks = (TextBox)row.FindControl("txtmarks");
                    DropDownList paper = (DropDownList)row.FindControl("ddlpaper");

                    if (marks.Text != "" && paper.SelectedValue != "0")
                    {
                        string sqlstr = "update tbl_recruitment_candidate_interview set round1_paperid='" + paper.SelectedValue + "', round_1_marks='" + marks.Text + "',round_1_status='R' where candidateid='" + id.Text + "' ";
                        DataSet ds = new DataSet();
                        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                    }
                    else
                    {
                        Output.Show("Please enter Paper & Marks scored before rejecting candidate");
                    }
                }
                else
                {
                    Output.Show("Please select candidate");
                }
            }
            Output.Show("Candidates Rejected");
            bindgrid();
            bindgridinround1();
            cleartext();
        }
    }

    protected void grdcandidates_PreRender(object sender, EventArgs e)
    {
        if (grdcandidates.Rows.Count > 0)
        {
            grdcandidates.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    //End Grid For Round One

    protected void lbtnview_Command(object sender, CommandEventArgs e)
    {

        string filepath = e.CommandArgument.ToString();
        Session["FileData"] = Server.MapPath("~/recruitment/upload/" + filepath);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", " JavaScript:newPopup1('viewresume.aspx');", true);

        //string id = e.CommandArgument.ToString();
        //DropDownList ddlpaper = new DropDownList();
        //TextBox lblmarks = new TextBox();
        //foreach (GridViewRow row in grdcandidates.Rows)
        //{
        //    Label lblid = (Label)row.FindControl("lblID");

        //    if (lblid.Text.Trim() == id)
        //    {
        //        lblmarks = (TextBox)row.FindControl("txtmarks");
        //        ddlpaper = (DropDownList)row.FindControl("ddlpaper");
        //    }
        //}

        //if (lblmarks.Text != "" || ddlpaper.SelectedValue != "0")
        //{
        //    string sqlstr = "update tbl_recruitment_candidate_interview set round1_paperid='" + ddlpaper.SelectedValue + "', round_1_marks='" + lblmarks.Text + "',round_1_status= (case when (select passmarks from tbl_recruitment_paper_master where id='" + ddlpaper.SelectedValue + "')<='" + lblmarks.Text + "' then 'S' else 'R' end) where candidateid='" + id + "' ";
        //    DataSet ds = new DataSet();
        //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //    bindgrid();
        //}
    }

    protected void cleartext()
    {
        ddlrrfcode.SelectedValue = "0";
        ddlrrf.SelectedValue = "0";
    }

    // Start Grid In Round One
    protected void bindgridinround1()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_Round1");
        grdcandidatesinround1.DataSource = ds;
        grdcandidatesinround1.DataBind();
    }

    protected void btnSelectinround1_Click(object sender, EventArgs e)
    {
        SqlParameter[] param = new SqlParameter[3];
        if (grdcandidatesinround1.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdcandidatesinround1.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label lblrrf_code = (Label)row.FindControl("lblrrfID");
                    Label id = (Label)row.FindControl("lblID");
                    Label name = (Label)row.FindControl("lblname");
                    Label email = (Label)row.FindControl("lblemail");
                    TextBox date = (TextBox)row.FindControl("txtDate");
                    TextBox time = (TextBox)row.FindControl("tbttime");
                    Label rnd1_date = (Label)row.FindControl("lblrnd_1date");

                    ////if (date.Text != "")
                    ////{
                    //    if (Convert.ToDateTime(date.Text) > Convert.ToDateTime(rnd1_date.Text))
                    //    {
                    //        Output.Show("Enter valid date");
                    //        return;
                    //    }
                    ////}


                    if (date.Text != "" && time.Text != "")
                    {
                        try
                        {
                            Output.AssignParameter(param, 0, "@candidateId", "Int", 0, id.Text);
                            Output.AssignParameter(param, 1, "@round2date", "DateTime", 0, date.Text);
                            Output.AssignParameter(param, 2, "@round2time", "String", 10, time.Text);

                            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_select_candiate_interview_round2", param);
                            if (i > 0)
                            {
                                //sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
                                SendMailTocandidate(id.Text.ToString(), date.Text.ToString(), time.Text.ToString(), lblrrf_code.Text.ToString());
                                SenderMailToPanel(id.Text.ToString(), date.Text.ToString(), time.Text.ToString(), lblrrf_code.Text.ToString());
                                Output.Show("Submitted Successfully");
                            }
                            else
                            {
                                Output.Show("Please Select candidate");
                            }
                        }
                        catch (Exception ex)
                        {
                            Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
                            Output.Show("Record not saved.Please contact system admin.For error details please go through the log file");
                        }
                    }
                    else
                    {
                        Output.Show("Please enter Date & Time before selecting candidate");
                    }
                }
                else
                {
                    //Output.Show("Please Select candidate");
                    //Output.Show("Candidate Selected Successfully");
                }
            }
            Output.Show("Please enter Date & Time before selecting candidate");
            bindgridinround1();
            cleartext();
        }
    }

    private void SendMailTocandidate(string id, string date, string time, string rrfdrp)
    {

        try
        {


            string sqlstr = "select candidate_name ,emailid from tbl_recruitment_candidate_registration where status=1 and id='" + id.ToString() + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            string msgdetails = "Your Interview is Scheduled on ";
            msgdetails += Convert.ToDateTime(date.ToString()).ToString("dd-MMM-yyy");
            msgdetails += " at ";
            msgdetails += "(" + time.ToString() + ").";
            msgdetails += "Please find below the further details:";
            msgdetails += "<br>";
            msgdetails += "<br>";
            msgdetails += "Venue: ESCALON BUSINESS SERVICES PRIVATE LIMITED.";
            msgdetails += "<br>" + "PLOT NO A 40 A 2ND FLOOR, SVEPL Building" + "<br>" + "CO-DEVELOPER QUARKCITY SEZ" + "<br>" + "INDUSTRIAL AREA PHASE 8-B" + "<br>" + "S.A.S NAGAR, MOHALI" + "<br>" + "PUNJAB 160059" + "<br>" + "<br>" + "Website : http://escalon.services/ " + "<br>" + "<br>" + "Feel free to get in touch with me in case of any assistance needed." + "<br>" + "*Please bring your updated CV and 1 passport size colored photograph." + "<br>" + "<br>" + "Kindly send your confirmation for the interview at jaspreet.kaur@escalon.services" + "<br>" + "Contact number: 01724643839";
            if (ds.Tables.Count != null || ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows[0]["emailid"].ToString().Trim() != "")
                {
                    sendmail_Template1(ds.Tables[0].Rows[0]["emailid"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["candidate_name"].ToString(), msgdetails), "Interview Schedule");

                }
            }
        }
        catch
        {


        }





    }

    private void SenderMailToPanel(string id, string date, string time, string rrfdrp)
    {

        try
        {


            string sqlstr = "select empcode,emp_fname,official_email_id from tbl_intranet_employee_jobDetails where empcode=(select top 1 Item From SplitString((SELECT mastr.resourcenames FROM  dbo.tbl_recruitment_panel_master mastr inner join tbl_recruitment_assignpanel panal on mastr.id=panal.panelid  inner join dbo.tbl_recruitment_requisition_form rrf on panal.rrf_code=rrf.id where rrf.rrf_code='" + rrfdrp + "'),'-'))";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            string sqlstr1 = "select empcode,emp_fname,official_email_id from tbl_intranet_employee_jobDetails where empcode ='" + _userCode.ToString() + "'";
            DataSet ds1 = new DataSet();
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
            if (ds.Tables.Count != null || ds.Tables.Count != 0)
            {
                if (ds1.Tables.Count != null || ds1.Tables.Count != 0)
                {
                    string msgdetails = " You have an Interview  Scheduled on ";
                    msgdetails += Convert.ToDateTime(date.ToString()).ToString("dd-MMM-yyy") + " by " + ds1.Tables[0].Rows[0]["emp_fname"].ToString() + "-" + ds1.Tables[0].Rows[0]["empcode"].ToString() + ".";
                    if (ds.Tables[0].Rows[0]["official_email_id"].ToString().Trim() != "")
                    {
                        sendmail_Template(ds.Tables[0].Rows[0]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["emp_fname"].ToString(), msgdetails), "Interview Schedule");

                    }
                }


            }
        }
        catch
        {


        }





    }

    public bool sendmail_Template(string recievermailid, string bdy, string sub)
    {

        try
        {


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

    public bool sendmail_Template1(string recievermailid, string bdy, string sub)
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

    protected void bindddlrrf()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        ddlrrf.DataTextField = "newrffcode";
        ddlrrf.DataValueField = "id";
        ddlrrf.DataSource = ds;
        ddlrrf.DataBind();
        ddlrrf.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddlrrf_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlrrf.SelectedValue != "0")
        {
            int id = Convert.ToInt32(ddlrrf.SelectedValue);
            SqlParameter[] sqlParam = new SqlParameter[1];

            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;
            //string sqlstr = "select * from tbl_recruitment_requisition_form where id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_Round1byRRFCODE", sqlParam);
            grdcandidatesinround1.DataSource = ds;
            grdcandidatesinround1.DataBind();
        }
        else
        {
            bindgridinround1();
        }
    }

    protected void grdcandidatesinround1_PreRender(object sender, EventArgs e)
    {
        if (grdcandidatesinround1.Rows.Count > 0)
        {
            grdcandidatesinround1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    //End Grind In Round One

    protected void btnSelectinround3_Click(object sender, EventArgs e)
    {

        SqlParameter[] param = new SqlParameter[3];
        if (grdcandidatesinround1.Rows.Count > 0)
        {
            foreach (GridViewRow row in grdcandidatesinround1.Rows)
            {
                int count = 0;

                CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                if (chk.Checked)
                {
                    Label id = (Label)row.FindControl("lblID");
                    Label name = (Label)row.FindControl("lblname");
                    Label email = (Label)row.FindControl("lblemail");
                    TextBox date = (TextBox)row.FindControl("txtDate");
                    TextBox time = (TextBox)row.FindControl("tbttime");
                    count = count + 1;
                    if (date.Text != "" && time.Text != "")
                    {
                        //param[0] = new SqlParameter("@candidateId", SqlDbType.Int);
                        //param[0].Value = Convert.ToInt32(id.Text);
                        //param[1] = new SqlParameter("@round3date", SqlDbType.DateTime);
                        //param[1].Value = Convert.ToDateTime(date.Text);
                        //param[2] = new SqlParameter("@round3time", SqlDbType.VarChar, 10);
                        //param[2].Value = time.Text;

                        Output.AssignParameter(param, 0, "@candidateId", "Int", 0, id.Text);
                        Output.AssignParameter(param, 1, "@round3date", "DateTime", 0, date.Text);
                        Output.AssignParameter(param, 2, "@round3time", "String", 10, time.Text);

                        try
                        {
                            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_select_candiate_interview_round3", param);
                            if (i > 0)
                            {
                                //sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
                                Output.Show("Submitted Successfully");
                            }
                            else
                            {
                                Output.Show("Please Select candidate");
                            }
                        }
                        catch (Exception ex)
                        {
                            Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
                            Output.Show("Record not saved.Please contact system admin.For error details please go through the log file");
                        }
                    }
                    else
                    {
                        Output.Show("Please enter Date & Time before selecting candidate");
                    }
                }
                if (count < 0)
                {
                    Output.Show("Please Select candidate");
                    return;
                }
            }
            Output.Show("Please enter Date & Time before selecting candidate");
            //Output.Show("Candidate Selected Successfully");
            bindgridinround22();
            cleartext();
        }



        //SqlParameter[] param = new SqlParameter[3];

        //if (grdcandidatesinround1.Rows.Count > 0)
        //{
        //    foreach (GridViewRow row in grdcandidatesinround1.Rows)
        //    {

        //        CheckBox chk = (CheckBox)row.FindControl("chkSelect");
        //        if (chk.Checked)
        //        {

        //            Label id = (Label)row.FindControl("lblID");
        //            Label lblrrf_code = (Label)row.FindControl("lblrrf_code");
        //            Label name = (Label)row.FindControl("lblname");
        //            Label email = (Label)row.FindControl("lblemail");
        //            TextBox date = (TextBox)row.FindControl("txtDate");
        //            TextBox time = (TextBox)row.FindControl("tbttime");

        //            string str = @"select count(rrf_code) from tbl_recruitment_assignpanel where rrf_code =(select rrf_id from tbl_recruitment_candidate_registration where id=" + id.Text.Trim() + ")";
        //            string count = "";
        //            count = DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, str).ToString();
        //            if (count != "0" && count != null)
        //            {
        //                if (date.Text != "" && time.Text != "")
        //                {
        //                    param[0] = new SqlParameter("@candidateId", SqlDbType.Int);
        //                    param[0].Value = Convert.ToInt32(id.Text);
        //                    param[1] = new SqlParameter("@round3date", SqlDbType.DateTime);
        //                    param[1].Value = Convert.ToDateTime(date.Text);
        //                    param[2] = new SqlParameter("@round3time", SqlDbType.VarChar, 10);
        //                    param[2].Value = time.Text;
        //                    try
        //                    {
        //                        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_select_candiate_interview_round3", param);
        //                        if (i > 0)
        //                        {
        //                            //SendMail(id.Text, name.Text, email.Text, date.Text, time.Text);
        //                            Output.Show("Candidate Selected Successfully");
        //                        }
        //                        else
        //                        {

        //                        }
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        Common.Console.Output.Log("During Validation:" + ex.Message + "." + DateTime.Now);
        //                        Output.Show("Record not saved.Please contact system admin.For error details please go through the log file");
        //                    }
        //                }
        //                else
        //                {
        //                    Output.Show("Please enter Date & Time before selecting candidate");
        //                }
        //            }
        //            else
        //            {
        //                Output.Show("Please Select candidate");
        //            }
        //        }
        //        Output.Show("Please enter Date & Time before selecting candidate");
        //        bindgridinround22();
        //        cleartext();
        //    }

        //}
    }

    private void bindgridinround22()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_Round22");
        grdcandidatesinround1.DataSource = ds;
        grdcandidatesinround1.DataBind();
    }

    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grdcandidatesinround1.Rows)
        {

            TextBox date = (TextBox)row.FindControl("txtDate");
            Label rnd1_date = (Label)row.FindControl("lblrnd_1date");
            if (date.Text != "")
            {
                if (Convert.ToDateTime(date.Text) >= Convert.ToDateTime(rnd1_date.Text))
                {
                    //Output.Show("Date Value Inserted");
                    //return;
                }
                else
                {
                    Output.Show("Please Enter Valid Date");
                    date.Text = "";
                }
            }
            //else
            //{
            //    Output.Show("Please Enter Date");
            //}
        }
    }

    protected void grdcandidatesinround1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.RowIndex);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = this.grdcandidatesinround1.Rows[index];
            // string id = grdcandidatesinround1.DataKeys[index].Value.ToString();

            //get value from Controls in ItemTemplate
            string cid = ((Label)(row.FindControl("lblID"))).Text;
            activity.OpenConnection();

            //int a = (int)grdcandidatesinround1.DataKeys[(int)e.RowIndex].Value;


            //Label id = (Label)e.FindControl("lblID");
            if (cid != "0")
            {
                string d = "update tbl_recruitment_candidate_registration set rrf_id=NULL where id=" + cid;
                DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, d);

                string db = "delete from tbl_recruitment_candidate_interview where candidateid=" + cid;
                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, db);

                Output.Show("Deleted Successfully");
                bindgridinround1();
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

    protected void grdcandidatesinround1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in grdcandidatesinround1.Rows)
        {
            HyperLink hplink = (HyperLink)row.Cells[12].Controls[0]; // 12 is the hyperlink column index
            LinkButton lnk = (LinkButton)row.FindControl("lnkDelete");
            if (Role == "3" || Role == "9")
            {
                hplink.Visible = true;
                lnk.Visible = true;
            }
            else
            {
                hplink.Visible = false;
                lnk.Visible = false;
            }
        }
    }

}