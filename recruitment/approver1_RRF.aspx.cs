using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using Smart.HR.Contracts;
using Smart.HR.BeeLogic;
using Smart.HR.Common.Mail.Module;
using System.Net.Mail;


public partial class recruitment_approve1_RRF : System.Web.UI.Page
{
    //Hiii there this is changed by me
    string UserCode;
    DataActivity activity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                bindDetails();
            }
            bind_RRF();

            requisitionformdetails.Visible = false;
        }

        if (Request.QueryString["id"] != null)
        {
            gridapprover1.Visible = false;
            requisitionformdetails.Visible = true;
            bindapproversgrid();
        }

        if (Request.QueryString["Approved"] != null)
        {
            Output.Show("Approved Successfully");
        }
        if (Request.QueryString["Rejected"] != null)
        {
            Output.Show("Rejected Successfully");
        }
    }

    protected void bind_RRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRFs_by_approver1", sqlparam);
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }

    protected void bindDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[1];
        try
        {
            sqlParam[0] = new SqlParameter("@ids", SqlDbType.Int);
            sqlParam[0].Value = id;
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF_byIDs", sqlParam);

            if (ds.Tables[0].Rows.Count >= 1)
            {
                lbl_rrfcode.Text = ds.Tables[0].Rows[0]["rrf_code"].ToString();
                lbl_requestedby.Text = ds.Tables[0].Rows[0]["requestedby"].ToString();
                lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
                lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
                //lbl_Posts.Text = ds.Tables[0].Rows[0]["total_no_posts"].ToString();
                txt_Posts.Text = ds.Tables[0].Rows[0]["total_no_posts"].ToString();
                lbl_requestType.Text = ds.Tables[0].Rows[0]["requesttype"].ToString();
                lbl_vacancyType.Text = ds.Tables[0].Rows[0]["vacancytype"].ToString();
                lbl_temparary.Text = ds.Tables[0].Rows[0]["temporary"].ToString();
                lbl_incentive.Text = ds.Tables[0].Rows[0]["expectedCTC"].ToString();
                lbl_workinghours.Text = ds.Tables[0].Rows[0]["working_hours"].ToString();
                lbl_reasons.Text = ds.Tables[0].Rows[0]["reasons_of_request"].ToString();
                lbl_costcenter.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString();
                //lbl_budget.Text = ds.Tables[0].Rows[0]["budget"].ToString();
                lbl_location.Text = ds.Tables[0].Rows[0]["location"].ToString();
                lbl_grosssalary.Text = ds.Tables[0].Rows[0]["gross_salary"].ToString();
                lbl_tctc.Text = ds.Tables[0].Rows[0]["ctc"].ToString();
                lbl_shifthours.Text = ds.Tables[0].Rows[0]["shift_hours"].ToString();
                lblQualifiers.Text = ds.Tables[0].Rows[0]["additional_qualifiers"].ToString();
                lbl_industries.Text = ds.Tables[0].Rows[0]["industries_preferred"].ToString();
                lbl_jobdesc.Text = ds.Tables[0].Rows[0]["job_description"].ToString();
                lbl_skills.Text = ds.Tables[0].Rows[0]["skills"].ToString();
                lbl_edu.Text = ds.Tables[0].Rows[0]["educational_qualifications"].ToString();
                lbl_Exp.Text = ds.Tables[0].Rows[0]["experience"].ToString();

            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void btn_Approve_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);

        SqlParameter[] sqlParam = new SqlParameter[3];
        try
        {
            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;

            //sqlParam[1] = new SqlParameter("@total_no_posts", SqlDbType.Int);
            //sqlParam[1].Value = txt_Posts.Text;

            sqlParam[1] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
            sqlParam[1].Value = "A";

            sqlParam[2] = new SqlParameter("@Approvelevel", SqlDbType.VarChar, 1);
            sqlParam[2].Value = "1";

            insertapprovedcomments(id);
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_update_approver1", sqlParam);

           // RecruitmentApprovers objEmail = new RecruitmentApprovers();
         //   string rrfCode = objEmail.GetRRFId(id);
            //SendEmailHRBP(rrfCode);
            //SendEmailMD(rrfCode);

            //if (objEmail.CheckStatusOfHRBPAndMD(rrfCode))
            //{
            SendEmailHRTA(lbl_rrfcode.Text.ToString());
            //}

            Response.Redirect("approver1_RRF.aspx?Approved=RRF" + id);

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

    }

    protected void insertapprovedcomments(int id)
    {
        SqlParameter[] sqlparam = new SqlParameter[6];
        sqlparam[0] = new SqlParameter("@rrf_id", SqlDbType.Int);
        sqlparam[0].Value = id;
        sqlparam[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();
        sqlparam[2] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
        sqlparam[2].Value = "A";
        sqlparam[3] = new SqlParameter("@approverlevel", SqlDbType.VarChar, 1);
        sqlparam[3].Value = "1";
        sqlparam[4] = new SqlParameter("@comments", SqlDbType.VarChar, 8000);
        sqlparam[4].Value = txtComments.Text;
        sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[5].Value = Session["empcode"].ToString();

        int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_approver_comments", sqlparam);

    }

    protected void btn_reject_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlParam = new SqlParameter[4];
        try
        {
            sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
            sqlParam[0].Value = id;

            sqlParam[1] = new SqlParameter("@total_no_posts", SqlDbType.Int);
            sqlParam[1].Value = txt_Posts.Text;

            sqlParam[2] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
            sqlParam[2].Value = "R";

            sqlParam[3] = new SqlParameter("@Approvelevel", SqlDbType.VarChar, 1);
            sqlParam[3].Value = "1";

            insertrejectcomments(id);
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_Reject_approver1", sqlParam);

            RecruitmentApprovers objEmail = new RecruitmentApprovers();
           // SendEmailLM(objEmail.GetRRFId(id));
            SendEmailLMoofRRF(lbl_rrfcode.Text.ToString());
            Response.Redirect("approver1_RRF.aspx?Rejected=RRF" + id);
        }

        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        //string sqlstr = "update tbl_recruitment_requisition_form set approver1_status='R' where id='" + id + "'";
        //DataSet ds = new DataSet();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //Response.Redirect("requisitionFormsList.aspx?Rejected=RRF" + id);
    }

    protected void insertrejectcomments(int id)
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@rrf_id", SqlDbType.Int);
        sqlparam[0].Value = id;
        sqlparam[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();
        sqlparam[2] = new SqlParameter("@approverstatus", SqlDbType.VarChar, 1);
        sqlparam[2].Value = "R";
        sqlparam[3] = new SqlParameter("@approverlevel", SqlDbType.VarChar, 1);
        sqlparam[3].Value = "1";
        sqlparam[4] = new SqlParameter("@comments", SqlDbType.VarChar, 8000);
        sqlparam[4].Value = txtComments.Text;
        sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[5].Value = Session["empcode"].ToString();

        int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_insert_approver_comments", sqlparam);

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("approver1_RRF.aspx");
    }

    protected void grdRRF_PreRender(object sender, EventArgs e)
    {
        if (grdRRF.Rows.Count > 0)
        {
            grdRRF.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bindapproversgrid()
    {
        IBase Lib = null;
        Lib = new Base();

        //string Query = @"

//select 
//F.id, 
//F.rrf_code, 
//A.ApproverCode, 
//isnull(J.emp_fname,'')+''+isnull(J.emp_m_name,'')+''+isnull(J.emp_l_name,'') ApproverName,
//A.Approvelevel,
//case 
//when A.Approvelevel = 1 then 'BH'
//when A.Approvelevel = 2 then 'HR-BP'
//when A.Approvelevel = 3 then 'MD'
//when A.Approvelevel = 4 then 'HR-TA' end ApproverRole
//, 
//case 
//when A.ApproverStatus = 'H' then 'Pending'
//when A.ApproverStatus = 'A' then 'Approved'
//when A.ApproverStatus = 'R' then 'Reject' end ApproverStatus
// from tbl_recruitment_requisition_form F
//  inner join tbl_recruitment_master_approvers A on F.rrf_code = A.rrf_code
//  inner join tbl_intranet_employee_jobDetails J on A.ApproverCode = J.empcode
//   where F.id = " + Request.QueryString["id"].Trim() + " order by A.Approvelevel";

         string Query = @"
        select 
F.id, 
F.rrf_code, 
A.ApproverCode, 
isnull(J.emp_fname,'')+''+isnull(J.emp_m_name,'')+''+isnull(J.emp_l_name,'') ApproverName,
A.Approvelevel,
case 
when A.Approvelevel = 1 then 'BH'
when A.Approvelevel = 2 then 'HR-TA' end ApproverRole
--when A.Approvelevel = 3 then 'MD'
--when A.Approvelevel = 4 then 'HR-TA' end ApproverRole
, 
case 
when A.ApproverStatus = 'H' then 'Pending'
when A.ApproverStatus = 'A' then 'Approved'
when A.ApproverStatus = 'R' then 'Reject' end ApproverStatus
 from tbl_recruitment_requisition_form F
  inner join tbl_recruitment_master_approvers A on F.rrf_code = A.rrf_code
  inner join tbl_intranet_employee_jobDetails J on A.ApproverCode = J.empcode
   where F.id = " + Request.QueryString["id"].Trim() + " order by A.Approvelevel";

        Lib.Bee.WBindGrid(Query, grdapprovers);

    }

    void SendEmailHRBP(string rrfId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedHRBP();
        EmailClient client = new EmailClient(email);
        RecruitmentApprovers objEmail = new RecruitmentApprovers();

        DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

        DataRow rowApp = ds.Tables[0].Rows[1];
        DataRow rowEmp = ds.Tables[1].Rows[0];

        client.toEmailId = rowApp["officialemailid"].ToString().Trim();
        client.empCode = rowApp["empcode"].ToString();
        client.employeeName = rowApp["empname"].ToString().Trim();
        client.requestNumber = rrfId;
        client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
        client.Send();
    }

    void SendEmailMD(string rrfId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedMD();
        EmailClient client = new EmailClient(email);
        RecruitmentApprovers objEmail = new RecruitmentApprovers();

        DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

        DataRow rowApp = ds.Tables[0].Rows[2];
        DataRow rowEmp = ds.Tables[1].Rows[0];

        client.toEmailId = rowApp["officialemailid"].ToString().Trim();
        client.empCode = rowApp["empcode"].ToString();
        client.employeeName = rowApp["empname"].ToString().Trim();
        client.requestNumber = rrfId;
        client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
        client.Send();
    }

    void SendEmailLM(string rrfId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedLM();
        EmailClient client = new EmailClient(email);
        RecruitmentApprovers objEmail = new RecruitmentApprovers();
        DataRow rowEmp = objEmail.GetRecruitmentRaisedEmployee(rrfId);

        client.toEmailId = rowEmp["officialemailid"].ToString().Trim();
        client.empCode = rowEmp["empcode"].ToString();
        client.employeeName = rowEmp["empname"].ToString().Trim();
        client.requestNumber = rrfId;
        client.Send();
    }

    void SendEmailHRTA(string rrfId)
    {
    //    EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedHRTA();
    //    EmailClient client = new EmailClient(email);
     // RecruitmentApprovers objEmail = new RecruitmentApprovers();

    //    DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

    //    DataRow rowApp = ds.Tables[0].Rows[3];
    //    DataRow rowEmp = ds.Tables[1].Rows[0];

    //    client.toEmailId = rowApp["officialemailid"].ToString().Trim();
    //    client.empCode = rowApp["empcode"].ToString();
    //    client.employeeName = rowApp["empname"].ToString().Trim();
    //    client.requestNumber = rrfId;
    //    client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
    //    client.Send();

        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select  app.ApproverCode,job.emp_fname,job.official_email_id from tbl_recruitment_master_approvers app inner join dbo.tbl_intranet_employee_jobDetails job on job.empcode=app.ApproverCode where app.Approvelevel=2 and app.rrf_code='" + rrfId + "'";
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
         string sqlstr1 = @"select empcode,emp_fname,official_email_id from tbl_intranet_employee_jobDetails   where empcode='" + UserCode + "'";
        DataSet ds1= SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);

        if (ds.Tables.Count >= 1 && ds1.Tables.Count >=1)
        {
            if (ds.Tables[0].Rows[0]["official_email_id"].ToString().Trim() != "")
            {
                string msgdetails = " You have a pending RRF Application by ";
                msgdetails += ds1.Tables[0].Rows[0]["emp_fname"].ToString() + " - " + ds1.Tables[0].Rows[0]["empcode"].ToString();
                msgdetails += " to be Initiated";
                sendmail_Template(ds.Tables[0].Rows[0]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["emp_fname"].ToString().Trim(), msgdetails), "RRF Application");
            }
        }
    }
    void SendEmailLMoofRRF(string rrfId)
    {
        //    EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedHRTA();
        //    EmailClient client = new EmailClient(email);
        // RecruitmentApprovers objEmail = new RecruitmentApprovers();

        //    DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

        //    DataRow rowApp = ds.Tables[0].Rows[3];
        //    DataRow rowEmp = ds.Tables[1].Rows[0];

        //    client.toEmailId = rowApp["officialemailid"].ToString().Trim();
        //    client.empCode = rowApp["empcode"].ToString();
        //    client.employeeName = rowApp["empname"].ToString().Trim();
        //    client.requestNumber = rrfId;
        //    client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
        //    client.Send();

        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select  app.createdby,job.emp_fname,job.official_email_id from tbl_recruitment_requisition_form app inner join dbo.tbl_intranet_employee_jobDetails job on job.empcode=app.createdby where app.rrf_code='" + rrfId + "'";
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        string sqlstr1 = @"select empcode,emp_fname,official_email_id from tbl_intranet_employee_jobDetails   where empcode='" + UserCode + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);

        if (ds.Tables.Count >= 1 && ds1.Tables.Count>=1)
        {
            if (ds.Tables[0].Rows[0]["official_email_id"].ToString().Trim() != "")
            {
                string msgdetails = "Your RRF Application has been Rejected by ";
                msgdetails += ds1.Tables[0].Rows[0]["emp_fname"].ToString() ;
                msgdetails += "-";
                msgdetails += ds1.Tables[0].Rows[0]["empcode"].ToString();

                sendmail_Template(ds.Tables[0].Rows[0]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[0]["emp_fname"].ToString().Trim(), msgdetails), "RRF Application Status");
            }
        }
    }
    public bool sendmail_Template(string recievermailid, string bdy, string sub)
    {

        try
        {

            string senderId = "connect@escalon.services"; // Sender EmailID
            string senderPassword = "Escalon2017$"; // Sender Password      

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
            smtpClient.Port = 25;
            smtpClient.Host ="secure.emailsrvr.com";
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
    public string EmailTemplate(string approver,  string msg)
    {
        string appr = approver.ToString();
      
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
                                                            "<p><b>Dear " + appr + @",</b></p>" +
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