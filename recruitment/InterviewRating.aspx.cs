using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using DataAccessLayer;
using System.Configuration;
using System.Net.Mail;

public partial class recruitment_InterviewRating : System.Web.UI.Page
{
    string UserCode,Role;
    DataActivity activity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null && Session["empcode"] != null)
        {
            //Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();
        Role = Session["role"].ToString();

        if (!IsPostBack)
        {
            bindgrid();
            bindddlrrfcode();
            bindgridround3();
            bindddlrrf();

            if (Request.QueryString["id"] != null)
            {
                bindDetails();
            }

            if (Request.QueryString["id"] != null)
            {
                candidatefinalgrid.Visible = false;
                candidateround3grid.Visible = false;
                Interviewdetails.Visible = true;
            }
        }
        if (Request.QueryString["update"] != null)
            SmartHr.Common.Alert("Updated Successfully");
    }

    protected void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_finalround");
        grdcandidates.DataSource = ds;
        grdcandidates.DataBind();
    }

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        SqlParameter[] sqlParam = new SqlParameter[1];

        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = id;

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_View_Finalform_details", sqlParam);
        if (ds.Tables[0].Rows.Count >= 1)
        {
            lblrrfcode.Text = ds.Tables[0].Rows[0]["rrf_code"].ToString();
            lblCandidatename.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
            lblQualification.Text = ds.Tables[0].Rows[0]["Qualification"].ToString();
            lblSkills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
            lblExperience.Text = ds.Tables[0].Rows[0]["experience"].ToString();
            hdcandidatecode.Value = ds.Tables[0].Rows[0]["id"].ToString();
            if (ds.Tables[0].Rows[0]["Personality"].ToString() == "6")
            {
                optionsRadios2.Checked = true;
                Radio1.Checked = false;
                Radio2.Disabled = true;
                Radio3.Disabled = true;
                Radio4.Disabled = true;
                Radio47.Disabled = true;
            }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "5")
            {
                Radio1.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "4")
            {
                Radio2.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "3")
            {
                Radio3.Checked = true;
            }
            else if (ds.Tables[0].Rows[0]["Personality"].ToString() == "2")
            {
                Radio4.Checked = true;
            }
            else

                Radio47.Checked = true;
            
            
if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "6") { Radio5.Checked = true; }
            else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "5") { Radio6.Checked = true; }
            else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "4") { Radio7.Checked = true; }
            else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "3") { Radio8.Checked = true; }
else if (ds.Tables[0].Rows[0]["AcademicRecord"].ToString() == "2") { Radio9.Checked = true; }
else { Radio48.Checked = true; }
           
            
            
            
            
            if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "6") { Radio10.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "5") { Radio11.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "4") { Radio12.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "3") { Radio13.Checked = true; }
            else if (ds.Tables[0].Rows[0]["GoalOrientedness"].ToString() == "2") { Radio14.Checked = true; }
            else { Radio49.Checked = true; }
            if (ds.Tables[0].Rows[0]["Communication"].ToString() == "6") { Radio15.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "5") { Radio16.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "4") { Radio17.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "3") { Radio18.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Communication"].ToString() == "2") { Radio19.Checked = true; }
            else { Radio50.Checked = true; }
            if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "6") { Radio20.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "5") { Radio21.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "4") { Radio22.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "3") { Radio23.Checked = true; }
            else if (ds.Tables[0].Rows[0]["KnowledgeofGK"].ToString() == "2") { Radio24.Checked = true; }
            else { Radio51.Checked = true; }


            if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "6") { Radio25.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "5") { Radio26.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "4") { Radio27.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "3") { Radio28.Checked = true; }
            else if (ds.Tables[0].Rows[0]["LearningAbility"].ToString() == "2") { Radio29.Checked = true; }
            else { Radio52.Checked = true; }
            if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "6") { Radio30.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "5") { Radio31.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "4") { Radio32.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "3") { Radio33.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CustomerOrientation"].ToString() == "2") { Radio34.Checked = true; }
            else { Radio53.Checked = true; }
            if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "6") { Radio35.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "5") { Radio36.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "4") { Radio37.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "3") { Radio38.Checked = true; }
            else if (ds.Tables[0].Rows[0]["CulterFit"].ToString() == "2") { Radio39.Checked = true; }
            else { Radio54.Checked = true; }
            if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "6") { Radio40.Checked = true; }
            else if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "5") { Radio41.Checked = true; }
            else if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "4") { Radio42.Checked = true; }
            //else if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "3") { Radio43.Checked = true; }
            else if (ds.Tables[0].Rows[0]["OverallAssessment"].ToString() == "2") { Radio55.Checked = true; }

            else { Radio56.Checked = true; }

            if (ds.Tables[0].Rows[0]["Behavior"].ToString() == "6") { Radio57.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Behavior"].ToString() == "5") { Radio58.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Behavior"].ToString() == "4") { Radio59.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Behavior"].ToString() == "3") { Radio60.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Behavior"].ToString() == "2") { Radio61.Checked = true; }
            else { Radio62.Checked = true; }

            if (ds.Tables[0].Rows[0]["Stability"].ToString() == "6") { Radio63.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Stability"].ToString() == "5") { Radio64.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Stability"].ToString() == "4") { Radio65.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Stability"].ToString() == "3") { Radio66.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Stability"].ToString() == "2") { Radio67.Checked = true; }
            else { Radio68.Checked = true; }

            if (ds.Tables[0].Rows[0]["Expe"].ToString() == "6") { Radio69.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Expe"].ToString() == "5") { Radio70.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Expe"].ToString() == "4") { Radio71.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Expe"].ToString() == "3") { Radio72.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Expe"].ToString() == "2") { Radio73.Checked = true; }
            else { Radio74.Checked = true; }

            if (ds.Tables[0].Rows[0]["Interest"].ToString() == "6") { Radio75.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Interest"].ToString() == "5") { Radio76.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Interest"].ToString() == "4") { Radio77.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Interest"].ToString() == "3") { Radio78.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Interest"].ToString() == "2") { Radio79.Checked = true; }
            else { Radio80.Checked = true; }

            if (ds.Tables[0].Rows[0]["skill"].ToString() == "6") { Radio81.Checked = true; }
            else if (ds.Tables[0].Rows[0]["skill"].ToString() == "5") { Radio82.Checked = true; }
            else if (ds.Tables[0].Rows[0]["skill"].ToString() == "4") { Radio83.Checked = true; }
            else if (ds.Tables[0].Rows[0]["skill"].ToString() == "3") { Radio84.Checked = true; }
            else if (ds.Tables[0].Rows[0]["skill"].ToString() == "2") { Radio85.Checked = true; }
            else { Radio86.Checked = true; }

            if (ds.Tables[0].Rows[0]["Need"].ToString() == "6") { Radio87.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Need"].ToString() == "5") { Radio88.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Need"].ToString() == "4") { Radio89.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Need"].ToString() == "3") { Radio90.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Need"].ToString() == "2") { Radio91.Checked = true; }
            else { Radio92.Checked = true; }

            if (ds.Tables[0].Rows[0]["Development"].ToString() == "6") { Radio93.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Development"].ToString() == "5") { Radio94.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Development"].ToString() == "4") { Radio95.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Development"].ToString() == "3") { Radio96.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Development"].ToString() == "2") { Radio97.Checked = true; }
            else { Radio98.Checked = true; }

            if (ds.Tables[0].Rows[0]["Management"].ToString() == "6") { Radio99.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Management"].ToString() == "5") { Radio100.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Management"].ToString() == "4") { Radio101.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Management"].ToString() == "3") { Radio102.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Management"].ToString() == "2") { Radio103.Checked = true; }
            else { Radio104.Checked = true; }

            if (ds.Tables[0].Rows[0]["Budget"].ToString() == "6") { Radio105.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Budget"].ToString() == "5") { Radio106.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Budget"].ToString() == "4") { Radio107.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Budget"].ToString() == "3") { Radio108.Checked = true; }
            else if (ds.Tables[0].Rows[0]["Budget"].ToString() == "2") { Radio109.Checked = true; }
            else { Radio110.Checked = true; }

            if (ds.Tables[0].Rows[0]["PanelsRecomendation"].ToString() == "3") { Radio44.Checked = true; }
            else if (ds.Tables[0].Rows[0]["PanelsRecomendation"].ToString() == "2") { Radio45.Checked = true; }
            else { Radio46.Checked = true; }

            txtRemarks.Text = ds.Tables[0].Rows[0]["Remarks"].ToString();
        }
    }

    protected void bindddlrrfcode()
    {
        // string sqlstr = "select * from tbl_recruitment_requisition_form";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        ddlrrfcode.DataTextField = "newrffcode";
        ddlrrfcode.DataValueField = "id";
        ddlrrfcode.DataSource = ds;
        ddlrrfcode.DataBind();
        ddlrrfcode.Items.Insert(0, new ListItem("--Select--", "0"));
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
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_in_finalroundbyRRFCODE", sqlParam);
            grdcandidates.DataSource = ds;
            grdcandidates.DataBind();
        }
        else
            bindgrid();
    }

    protected void btn_confirmed_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string rid = Request.QueryString["rrf"].ToString();
        string sqlstr = "update tbl_recruitment_interviewrrating set status='S' where Candidate_id=" + id + " and rrf_code='" + rid + "'";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string sqlstr1 = "select candidate_name ,emailid from tbl_recruitment_candidate_registration where status=1 and id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
            // sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);

            string msgdetails = "Congratulation you have been Selected.";
            if (ds.Tables.Count != null || ds.Tables.Count != 0)
            {
                if (ds.Tables[0].Rows[0]["emailid"].ToString().Trim() != "")
                {
                    sendmail_Template(ds.Tables[0].Rows[0]["emailid"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["candidate_name"].ToString(), msgdetails), "Selection Notification");

                }
            }
            Output.Show("Candidate Selected");

            candidatefinalgrid.Visible = true;
            candidateround3grid.Visible = true;
            Interviewdetails.Visible = false;
            bindgrid();
            bindgridround3();
        }
        else
        {
            Output.Show("Candidate Not Selected");
            candidatefinalgrid.Visible = true;
            candidateround3grid.Visible = true;
            Interviewdetails.Visible = false;
            bindgrid();
            bindgridround3();
        }
    }

    protected void btn_rejected_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string rid = Request.QueryString["rrf"].ToString();
        string sqlstr = "update tbl_recruitment_interviewrrating set status='R' where Candidate_id=" + id + " and rrf_code='" + rid + "'";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (i > 0)
        {
            Output.Show("Candidate Rejected");
            candidatefinalgrid.Visible = true;
            candidateround3grid.Visible = true;
            Interviewdetails.Visible = false;
            bindgrid();
            bindgridround3();
        }
        else
        {
            Output.Show("Candidate Not Rejected");
            candidatefinalgrid.Visible = true;
            candidateround3grid.Visible = true;
            Interviewdetails.Visible = false;
            bindgrid();
            bindgridround3();
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
    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("InterviewRating.aspx");
    }

    protected void grdcandidates_PreRender(object sender, EventArgs e)
    {
        if (grdcandidates.Rows.Count > 0)
        {
            grdcandidates.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    //candidates selected for round3
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
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_for_Round3byRRFCODE", sqlParam);
            grdround3.DataSource = ds;
            grdround3.DataBind();
        }
        else
        {
            bindgridround3();
        }
    }

    protected void bindgridround3()
    {
        //SqlParameter[] param = new SqlParameter[1];
        //Output.AssignParameter(param, 0, "@empcode", "String", 50, UserCode);
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_candidates_for_finalround_toHR");
        grdround3.DataSource = ds;
        grdround3.DataBind();
    }

    protected void lbtnview_Command(object sender, CommandEventArgs e)
    {
        string filepath = e.CommandArgument.ToString();
        Session["FileData"] = Server.MapPath("~/recruitment/upload/" + filepath);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "Script", " JavaScript:newPopup1('viewresume.aspx');", true);
    }

    protected void grdround3_PreRender(object sender, EventArgs e)
    {
        if (grdround3.Rows.Count > 0)
        {
            grdround3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void grdround3_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.RowIndex);

            // Retrieve the row that contains the button 
            // from the Rows collection.
            GridViewRow row = this.grdround3.Rows[index];
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
                bindgridround3();
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

    protected void grdround3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (GridViewRow row in grdround3.Rows)
        {
            HyperLink hplink = (HyperLink)row.Cells[14].Controls[0]; // 14 is the hyperlink column index
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

    protected void btn_puton_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string rid = Request.QueryString["rrf"].ToString();
        string sqlstr = "update tbl_recruitment_interviewrrating set status='H' where Candidate_id=" + id + " and rrf_code='"+ rid +"'";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string sqlstr1 = "select candidate_name ,emailid from tbl_recruitment_candidate_registration where status=1 and id='" + id + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
            // sendMail(id.Text, name.Text, email.Text, date.Text, time.Text);

            //string msgdetails = "you are in Hold.";
            //if (ds.Tables.Count != null || ds.Tables.Count != 0)
            //{
            //    if (ds.Tables[0].Rows[0]["emailid"].ToString().Trim() != "")
            //    {
            //        sendmail_Template(ds.Tables[0].Rows[0]["emailid"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["candidate_name"].ToString(), msgdetails), "Put On Hold Notification");

            //    }
            //}
            Output.Show("Candidate pushed to hold sucessfully!!!");

            candidatefinalgrid.Visible = true;
            candidateround3grid.Visible = true;
            Interviewdetails.Visible = false;
            bindgrid();
            bindgridround3();
        }
        else
        {
            Output.Show("Candidate Not Selected");
            candidatefinalgrid.Visible = true;
            candidateround3grid.Visible = true;
            Interviewdetails.Visible = false;
            bindgrid();
            bindgridround3();
        }
    }
}