using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using Smart.HR.Common.Mail.Module;
using System.Net.Mail;

public partial class recruitment_requisition_form : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string UserCode;
    DataActivity DataActivity = new DataActivity();
    //string _path;s
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //    Response.Redirect("~/Authenticate.aspx");
        }
        else

            Response.Redirect("~/notlogged.aspx");

        UserCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            bindexpectedCTC();
            bind_location();
            binddepartment();
            bind_costcenter();
            bind_requesttype();
            bind_vacancytype();
            bindapproversgrid();

            ddl_dept.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl_designation.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        //_path = HttpContext.Current.Request.Url.AbsolutePath;
        //bindlabel();
    }

    // protected void bindlabel()
    //{
    // SqlParameter[] sqlparam = new SqlParameter[1];
    // Output.AssignParameter(sqlparam, 0, "@path", "String", 100, _path);
    // DataSet ds = new DataSet();
    // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ToString(), CommandType.StoredProcedure, "sp_getmenulable", sqlparam);
    // if (ds.Tables[0].Rows.Count >= 1)
    //  {
    //     lblheader.Text = ds.Tables[0].Rows[0]["menulist"].ToString();
    // }
    //}

    protected void bindapproversgrid()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        Output.AssignParameter(sqlParam, 0, "@empcode", "String", 50, UserCode);
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_rrf_insert_approvers]", sqlParam);
        grdapprovers.DataSource = ds;
        grdapprovers.DataBind();
    }

    protected void bindexpectedCTC()
    {
        string sqlstr = "select id,expectedCTC from tbl_recruitment_expctc_master";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlexpectCTC.DataTextField = "expectedCTC";
        ddlexpectCTC.DataValueField = "id";
        ddlexpectCTC.DataSource = ds;
        ddlexpectCTC.DataBind();
        ddlexpectCTC.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void binddepartment()
    {
        string sqlstr = "select dd.dept_type_id, dd.dept_type_name from tbl_internate_department_type dd inner join  tbl_intranet_branch_detail bd on bd.branch_id=dd.branch_id where bd.branch_id = " + ddl_location.SelectedValue.Trim() + "";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddldeptype.DataTextField = "dept_type_name";
        ddldeptype.DataValueField = "dept_type_id";
        ddldeptype.DataSource = ds;
        ddldeptype.DataBind();
        ddldeptype.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void binddesignation(int departmentid)
    {
        string sqlstr = "select id,designationname from tbl_intranet_designation where departmentid='" + departmentid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_designation.DataTextField = "designationname";
        ddl_designation.DataValueField = "id";
        ddl_designation.DataSource = ds;
        ddl_designation.DataBind();
        ddl_designation.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        insert_RRF();
    }

    protected void bind_location()
    {
        string sqlstr = "select branch_id, branch_name from tbl_intranet_branch_detail";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_location.DataSource = ds;
        ddl_location.DataTextField = "branch_name";
        ddl_location.DataValueField = "branch_id";
        ddl_location.DataBind();
        ddl_location.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_costcenter()
    {
        string sqlstr = "select id,division_name from tbl_intranet_division ";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_costcenter.DataSource = ds;
        ddl_costcenter.DataTextField = "division_name";
        ddl_costcenter.DataValueField = "id";
        ddl_costcenter.DataBind();
        ddl_costcenter.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_requesttype()
    {
        string sqlstr = "select id,requesttype from tbl_recruitment_requesttype ";
        //DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_request_type.DataSource = ds;
        ddl_request_type.DataTextField = "requesttype";
        ddl_request_type.DataValueField = "id";
        ddl_request_type.DataBind();
        ddl_request_type.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_vacancytype()
    {
        string sqlstr = "select id,vacancytype from tbl_recruitment_vacancytype ";
        // DataSet ds7 = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_vacancy_type.DataSource = ds;
        ddl_vacancy_type.DataTextField = "vacancytype";
        ddl_vacancy_type.DataValueField = "id";
        ddl_vacancy_type.DataBind();
        ddl_vacancy_type.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void insert_RRF()
    {
        int approvers = 0;
        string rrfcode = "";

        foreach (GridViewRow row in grdapprovers.Rows)
        {
            Label approvercode = (Label)row.FindControl("lblempcode");
            Label approverlevel = (Label)row.FindControl("lbllevels");
            if (approvercode.Text != null && approvercode.Text != "")
            {
                approvers++;
            }
        }

        //if (approvers == 2)
        if(approvers <= 2)
        {

            SqlParameter[] sqlParam = new SqlParameter[24];
            SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            try
            {
                Output.AssignParameter(sqlParam, 0, "@departmentid", "Int", 0, ddl_dept.SelectedValue);
                Output.AssignParameter(sqlParam, 1, "@designationid", "Int", 0, ddl_designation.SelectedValue);
                Output.AssignParameter(sqlParam, 2, "@total_no_posts", "Int", 0, txt_Posts.Text);
                Output.AssignParameter(sqlParam, 3, "@costcenterid", "Int", 0, ddl_costcenter.SelectedValue);
                Output.AssignParameter(sqlParam, 4, "@request_typeid", "Int", 0, ddl_request_type.SelectedValue);
                Output.AssignParameter(sqlParam, 5, "@budget", "Bool", 0, rbtn_budget.SelectedValue);
                Output.AssignParameter(sqlParam, 6, "@vacancy_typeid", "Int", 0, ddl_vacancy_type.SelectedValue);
                Output.AssignParameter(sqlParam, 7, "@locationid", "Int", 0, ddl_location.SelectedValue);
                Output.AssignParameter(sqlParam, 8, "@temporary", "Int", 0, txt_temparary.Text);
                Output.AssignParameter(sqlParam, 9, "@gross_salary", "Decimal", 100, txt_grosssalary.Text);
                Output.AssignParameter(sqlParam, 10, "@incentive", "Int", 0, ddlexpectCTC.SelectedValue);
                Output.AssignParameter(sqlParam, 11, "@ctc", "Decimal", 0, txt_tctc.Text);
                Output.AssignParameter(sqlParam, 12, "@working_hours", "String", 50, txt_workinghours.Text);
                Output.AssignParameter(sqlParam, 13, "@shift_hours", "String", 50, txt_shifthours.Text);
                Output.AssignParameter(sqlParam, 14, "@reasons_of_request", "String", 1000, txt_reasons.Text);
                Output.AssignParameter(sqlParam, 15, "@additional_qualifiers", "String", 1000, txt_additionalqualifiers.Text);
                Output.AssignParameter(sqlParam, 16, "@industries_preferred", "String", 1000, txt_IndustriesPreferred.Text);
                Output.AssignParameter(sqlParam, 17, "@job_description", "String", 1000, txt_jobDesc.Text);
                Output.AssignParameter(sqlParam, 18, "@skills", "String", 1000, txt_skills.Text);
                Output.AssignParameter(sqlParam, 19, "@educational_qualifications", "String", 1000, txt_edu_qualification.Text);
                Output.AssignParameter(sqlParam, 20, "@experience", "String", 1000, txt_experience.Text);
                Output.AssignParameter(sqlParam, 21, "@createdby", "String", 50, UserCode);
                Output.AssignParameter(sqlParam, 22, "@deptype", "Int", 0, ddldeptype.SelectedValue);
                sqlParam[23] = new SqlParameter("@rrf_code", SqlDbType.VarChar, 50);
                sqlParam[23].Value = "";
                sqlParam[23].Direction = ParameterDirection.Output;

                Connection = DataActivity.OpenConnection();
                _Transaction = Connection.BeginTransaction();

                int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "[sp_recruitment_insert_requisition_form]", sqlParam);

                if (sqlParam[23].Value != "")
                {
                    rrfcode = sqlParam[23].Value.ToString();
                    //    insertApprover(rrfcode, hf_bhcode.Value.ToString(), "1");
                    //    insertApprover(rrfcode, hf_mdcode.Value.ToString(), "2");
                    //    insertApprover(rrfcode, hf_hrdCode.Value.ToString(), "3");
                    //    insertApprover(rrfcode, hf_hrcode.Value.ToString(), "4");

                    foreach (GridViewRow row in grdapprovers.Rows)
                    {
                        Label approvercode = (Label)row.FindControl("lblempcode");
                        Label approverlevel = (Label)row.FindControl("lbllevels");
                        if (approvercode.Text != null && approvercode.Text != "")
                        {
                            SqlParameter[] Param = new SqlParameter[4];
                            Output.AssignParameter(Param, 0, "@rrf_code", "String", 50, rrfcode);
                            Output.AssignParameter(Param, 1, "@Approvelevel", "String", 1, approverlevel.Text);
                            Output.AssignParameter(Param, 2, "@ApproverCode", "String", 50, approvercode.Text);
                            Output.AssignParameter(Param, 3, "@Createdby", "String", 50, UserCode);

                            int i1 = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_approver_requisition_form]", Param);
                        }
                    }

                }
                _Transaction.Commit();

                if (i < 0)
                {
                    Output.Show("Requisition Form is not Created");
                }
                else
                {
                   SendEmailToLevel(rrfcode);
                    Output.Show("Created Successfully");
                    
                }
            }
            catch (Exception ex)
            {
                _Transaction.Rollback();
                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                DataActivity.CloseConnection();
            }
            cleartext();
        }
        else
        {
            Output.Show("Some of the approvers are not avaliable. Please contact your manager.");
        }

    }

    //protected void insertApprover(string rrfcode, string approvercode, string approverlevel)
    //{
    //    SqlParameter[] Param = new SqlParameter[4];
    //    Output.AssignParameter(Param, 0, "@rrf_code", "String", 50, rrfcode);
    //    Output.AssignParameter(Param, 1, "@Approvelevel", "String", 1, approverlevel);
    //    Output.AssignParameter(Param, 2, "@ApproverCode", "String", 50, approvercode);
    //    Output.AssignParameter(Param, 3, "@Createdby", "String", 50, UserCode);

    //    int i = SQLServer.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_approver_requisition_form]", Param);
    //}

    protected void cleartext()
    {
        ddl_dept.SelectedValue = "0";
        ddl_designation.SelectedValue = "0";
        // txtBH.Text = "";
        txt_Posts.Text = "";
        ddl_costcenter.SelectedValue = "0";
        ddl_request_type.SelectedValue = "0";
        rbtn_budget.SelectedIndex = -1;
        ddl_vacancy_type.SelectedValue = "0";
        ddl_location.SelectedValue = "0";
        txt_temparary.Text = "";
        txt_grosssalary.Text = "";
        ddlexpectCTC.SelectedValue = "0";
        txt_tctc.Text = "";
        txt_workinghours.Text = "";
        txt_shifthours.Text = "";
        txt_reasons.Text = "";
        txt_additionalqualifiers.Text = "";
        txt_IndustriesPreferred.Text = "";
        txt_jobDesc.Text = "";
        txt_skills.Text = "";
        txt_edu_qualification.Text = "";
        txt_experience.Text = "";
        ddldeptype.SelectedValue = "0";
        // txtMD.Text = "";
        //txtHRD.Text = "";
        // txtHR.Text = "";
    }

    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void ddl_dept_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddesignation(Convert.ToInt32(ddl_dept.SelectedValue));
    }

    protected void grdapprovers_PreRender(object sender, EventArgs e)
    {
        if (grdapprovers.Rows.Count > 0)
        {
            grdapprovers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddl_location_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddepartment();
        if (ddl_dept.SelectedValue != "0")
        {
            //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            binddeptmet();
        }
        if (ddl_designation.SelectedValue != "0")
        {
            //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            binddesig();
        }
    }

    void SendEmailToLevel(string rrfId)
    {
        //EmailFactory email = new Smart.HR.Common.Mail.Module.Recruitment.RRFRaisedBH();
        //EmailClient client = new EmailClient(email);
        //RecruitmentApprovers objEmail = new RecruitmentApprovers();

        //DataSet ds = objEmail.GetRecruitmentApprovers(rrfId);

        //DataRow rowApp = ds.Tables[0].Rows[0];
        //DataRow rowEmp = ds.Tables[1].Rows[0];

        //client.toEmailId = rowApp["officialemailid"].ToString().Trim();
        //client.empCode = rowApp["empcode"].ToString();
        //client.employeeName = rowApp["empname"].ToString().Trim();
        //client.requestNumber = rrfId;
        //client.fromDate = rowEmp["empname"].ToString().Trim() + " ( " + rowEmp["empcode"].ToString().Trim() + " ) ";
        //client.Send();

        try
        {
            var activity = new DataActivity();
            SqlConnection connection = activity.OpenConnection();

            SqlDataAdapter sq = new SqlDataAdapter("select distinct app.app_businesshead,job.emp_fname,job.official_email_id from tbl_employee_approvers app inner join dbo.tbl_intranet_employee_jobDetails job on job.empcode=app.app_businesshead where  app.empcode='" + UserCode.ToString() + "'", connection);
            DataTable dt = new DataTable();
            sq.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                if (dt.Rows[0]["official_email_id"].ToString().Trim() != "")
                {

                    sendmail_Template(dt.Rows[0]["official_email_id"].ToString().Trim(), dt.Rows[0]["emp_fname"].ToString().Trim(), Session["name"].ToString().Trim(), UserCode.Trim());
                }

            }

        }
        catch
        {

        }



    }
    public bool sendmail_Template(string recievermailid, string approver, string employee, string empcode)
    {

        try
        {

            string senderId = "connect@escalon.services"; // Sender EmailID
            string senderPassword = "Escalon2017$"; // Sender Password      

            string Template = EmailTemplate(approver, employee, empcode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "RRF Application";
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Thank you for using Smart HR. Your RRF application will submitted to approver for approval.</p>" +

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

    protected void ddldeptype_SelectedIndexChanged(object sender, EventArgs e)
    {
        binddep(Convert.ToInt32(ddldeptype.SelectedValue));
    }
    protected void binddep(int depttypetid)
    {
        string sqlstr = "select dd.departmentid, dd.department_name from tbl_internate_departmentdetails dd inner join  tbl_internate_department_type bd on bd.dept_type_id=dd.dept_type_id where dd.dept_type_id = " + depttypetid + "";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_dept.DataTextField = "department_name";
        ddl_dept.DataValueField = "departmentid";
        ddl_dept.DataSource = ds;
        ddl_dept.DataBind();
        ddl_dept.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void binddeptmet()
    {
        string sqlstr = "select dd.departmentid, dd.department_name from tbl_internate_departmentdetails dd inner join  tbl_internate_department_type bd on bd.dept_type_id=dd.dept_type_id where dd.dept_type_id = " + ddldeptype.SelectedValue + "";
        // DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        
        ddl_dept.DataTextField = "department_name";
        ddl_dept.DataValueField = "departmentid";
        ddl_dept.DataSource = ds;
        ddl_dept.DataBind();
        ddl_dept.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void binddesig()
    {
        string sqlstr = "select id,designationname from tbl_intranet_designation where departmentid='" + ddl_dept.SelectedValue + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_designation.DataTextField = "designationname";
        ddl_designation.DataValueField = "id";
        ddl_designation.DataSource = ds;
        ddl_designation.DataBind();
        ddl_designation.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}