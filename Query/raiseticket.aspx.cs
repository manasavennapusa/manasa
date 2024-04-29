using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Query_raiseticket : System.Web.UI.Page
{
    string UserCode, RoleId = "";
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"].ToString() != null && Session["role"].ToString() != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
        }
        else
            Response.Redirect("../LogOut.aspx");
        if (!IsPostBack)
        {
            bindDepartments();
            ddlQueryType.Items.Insert(0, new ListItem("---select---", "0"));
            lblPostedDate.Text = DateTime.Today.ToShortDateString();
            bindRefNo();
            btnUpdate.Visible = false;
            btnSubmit.Visible = true;
            divCreate.Visible = true;
            divEdit.Visible = false;
            if (string.IsNullOrEmpty(Convert.ToString(Request.QueryString["id"])) == false)
            {
                divEdit.Visible = true;
                divCreate.Visible = false;
                bindDetailForUpdate();
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
            }
            if (Request.QueryString["Submit"] != null)
                Common.Console.Output.Show("Query submitted successfully!");
        }
    }

    private void bindDetailForUpdate()
    {
        DataSet dsUpd = new DataSet();
        string qryUpd;
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            //            qryUpd = @"select qt.dept_Id,qt.query_Id,rq.deptName,rq.queryTypeName,rq.description,convert(char(10),rq.posteddate,101)posteddate,rq.refrence_No from tbl_query_raised_queries rq
            //inner join tbl_master_queryType qt on qt.query_name=rq.queryTypeName
            //inner join tbl_master_department dt on dt.department_name=rq.deptName where rq.id=" + Request.QueryString["id"] + " group by qt.dept_Id,qt.query_Id,rq.deptName,rq.queryTypeName,rq.description,rq.posteddate,rq.refrence_No";
            qryUpd = @"select qt.dept_Id,qt.query_Id,rq.deptName,rq.queryTypeName,rq.description,convert(char(10),rq.posteddate,101)posteddate,rq.refrence_No,rq.priority,rq.tickettype,rq.status from tbl_query_raised_queries rq
      inner join tbl_master_queryType qt on qt.query_name=rq.queryTypeName
inner join tbl_master_parent_queryType dt on dt.parntquery_name=rq.deptName where rq.id=" + Request.QueryString["id"] + " group by qt.dept_Id,qt.query_Id,rq.deptName,rq.queryTypeName,rq.description,rq.posteddate,rq.refrence_No,rq.priority,rq.tickettype,rq.status";
            dsUpd = SQLServer.ExecuteDataset(connection, CommandType.Text, qryUpd);
            ddlDeptName.SelectedIndex = Convert.ToInt32(dsUpd.Tables[0].Rows[0]["dept_Id"]);
            ddlQueryType.SelectedItem.Text = dsUpd.Tables[0].Rows[0]["queryTypeName"].ToString();
            string pstdDate = dsUpd.Tables[0].Rows[0]["posteddate"].ToString();
            ddlpriority.SelectedItem.Text = dsUpd.Tables[0].Rows[0]["priority"].ToString();
            lblPostedDate.Text = dsUpd.Tables[0].Rows[0]["posteddate"].ToString();
            lblRefNo.Text = dsUpd.Tables[0].Rows[0]["refrence_No"].ToString();
            txtdescription.Text = dsUpd.Tables[0].Rows[0]["description"].ToString();
            ddlTicketType.SelectedItem.Text = dsUpd.Tables[0].Rows[0]["tickettype"].ToString();

            if (dsUpd.Tables[0].Rows[0]["status"].ToString() == "3" || dsUpd.Tables[0].Rows[0]["status"].ToString() == "1")
            {
                restatus.Visible = true;
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

    private void bindRefNo()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select COUNT(@@ROWCOUNT) AS totalRows from tbl_query_raised_queries";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            int refnNo = Convert.ToInt32(ds.Tables[0].Rows[0]["totalRows"]) + 1;
            lblRefNo.Text = refnNo.ToString();
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

    private void bindDepartments()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select pquery_Id,parntquery_name from tbl_master_parent_queryType where status=1";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlDeptName.DataSource = ds;
                ddlDeptName.DataTextField = "parntquery_name";
                ddlDeptName.DataValueField = "pquery_Id";
                ddlDeptName.DataBind();
                ddlDeptName.Items.Insert(0, new ListItem("---All---", "0"));
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
    protected void ddlDeptName_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selDept = ddlDeptName.SelectedIndex;
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select query_Id,query_name from tbl_master_queryType where dept_Id=" + selDept + " and status=1";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            ddlQueryType.DataTextField = "query_name";
            ddlQueryType.DataValueField = "query_Id";
            ddlQueryType.DataSource = ds;
            ddlQueryType.DataBind();


            ddlQueryType.Items.Insert(0, new ListItem("---select---", "0"));
            // }
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
    protected void btnReset_Click(object sender, EventArgs e)
    {
        ddlDeptName.SelectedIndex = 0;
        ddlQueryType.SelectedIndex = 0;
        txtdescription.Text = "";
        ddlpriority.SelectedIndex = 0;
        ddlTicketType.SelectedIndex = 0;
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (ddlDeptName.SelectedIndex == 0)
        {
            Common.Console.Output.Show("Please select Parent Query name!");
            return;
        }
        else if (ddlQueryType.SelectedIndex == 0)
        {
            Common.Console.Output.Show("Please select Query Type!");
            return;
        }
        else if (ddlTicketType.SelectedIndex == 0)
        {
            Common.Console.Output.Show("Please select Ticket Type!");
            return;
        }
        else if (ddlpriority.SelectedIndex == 0)
        {
            Common.Console.Output.Show("Please select Priority!");
            return;
        }
        else if (txtdescription.Text == "")
        {
            Common.Console.Output.Show("Please enter description!");
            return;
        }
        DataSet dsAppvrEmails = GetAppvrsEmail();
        if (dsAppvrEmails.Tables[1].Rows.Count < 1)
        {
            Common.Console.Output.Show("" + ddlDeptName.SelectedItem.ToString() + "  approver has not been assigned. !!!");
            return;
        }
        bool s = saverecords();

        if (s)
        {
            string from = ConfigurationManager.AppSettings["FromEmail"];

            //string employeeName = dsAppvrEmails.Tables[0].Rows[0]["name"].ToString();
            //string to = dsAppvrEmails.Tables[0].Rows[0]["official_email_id"].ToString();

            string appvrName = dsAppvrEmails.Tables[1].Rows[0]["name"].ToString();
            string toAppvr = dsAppvrEmails.Tables[1].Rows[0]["official_email_id"].ToString();

            //string BH = dsAppvrEmails.Tables[2].Rows[0]["name"].ToString();
            //string to_BH = dsAppvrEmails.Tables[2].Rows[0]["official_email_id"].ToString();

            if (ddlDeptName.SelectedItem.Text == "IT")
            {
                string sqlstr1 = @"SELECT jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name,jd.official_email_id
FROM tbl_intranet_employee_jobDetails jd where jd.empcode = '" + UserCode + "'";

                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string user_email = ds.Tables[0].Rows[0]["official_email_id"].ToString();
                string empname = ds.Tables[0].Rows[0]["name"].ToString();

                string sqlstr2 = @"declare @BH varchar(60)
                                   set @BH=(select app_businesshead  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM tbl_intranet_employee_jobDetails where empcode = @BH";
                DataSet ds_BH = new DataSet();
                ds_BH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                string BH_email = ds_BH.Tables[0].Rows[0]["official_email_id"].ToString();
                //string BH_email = "kiran.n@sdlglobe.com";

                string sqlstr3 = @"DECLARE @HR varchar(60) SET @HR=(select app_hrd  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id where jd.empcode = @HR";
                DataSet ds_HR = new DataSet();
                ds_HR = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
                string HR_email = ds_HR.Tables[0].Rows[0]["official_email_id"].ToString();
                string HR_role = ds_HR.Tables[0].Rows[0]["role"].ToString();

                string sqlstr4 = @"DECLARE @networkadmin varchar(60) SET @networkadmin=(select clr_networkdept  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id where jd.empcode = @networkadmin";
                DataSet ds_net_admin = new DataSet();
                ds_net_admin = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr4);
                string net_admin__email = ds_net_admin.Tables[0].Rows[0]["official_email_id"].ToString();
                string net_admin_name = ds_net_admin.Tables[0].Rows[0]["name"].ToString();

                //string senderId = "connect@escalon.services"; // Sender EmailID
                //string senderPassword = "Escalon2017$"; // Sender Password      
                 string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];   
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                bool IsAttachment = false;
                System.Net.Mail.Attachment attachment = null;
                 string body = @"<html xmlns='http://www.w3.org/1999/xhtml'>" +
                          "<head runat='server'>" +
                          "<title></title>" +
                         "</head>" +
                          "<body>" +
                          "<form id='form1' runat='server'>" +
                          "<div>" +
                          "<table><tr><td><br/></td></tr></table>" +
                          "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                          "<tr>" +
                         "<td><asp:Label ID='lblname' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Dear " + appvrName + " ,</b></asp:Label></td>" +
                         "</tr>" +
                          "<tr><td><br/></td></tr>" +
                         "<tr>" +
                        "<td>" +
                          "<asp:Label ID='lblmessage' runat='server' style='font: 12px arial; color: #333; text-align: justify'>You have a " + ddlDeptName.SelectedItem.Text + " Ticket Raised from " + empname + "- " + UserCode + " for Approval/Reject.</asp:Label>" +
                          "</td>" +
                          "</tr>" +
                        // "<tr>" +
                        //"<td>" +
                        //  "<asp:Label ID='lblmessage_1' runat='server' style='font: 12px arial; color: #333; text-align: justify'>from " + empname + "-" + UserCode + " for Approval/Reject .</asp:Label>" +
                        //  "</td>" +
                        //  "</tr>" +
                          "<tr><td><br/></td></tr>" +
                          "<tr>" +
                          "<td>" +
                          "<asp:Label ID='lblmessage_2' runat='server' style='font: 12px arial; color: #333; text-align: justify'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
                          "</td>" +
                          "</tr>" +
                          "<tr><td><br/></td></tr>" +
                          "</table>" +
                          "<table><tr><td><br/></td></tr></table>" +
                         "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                          "<tbody>" +
                           "<tr>" +
                            "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                           "<hr>" +
                           "<br>" +
                           "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                            "<br>" +
                            //"(1) Call our 24-hour Customer Care or<br>" +
                            // "(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a></b>" +
                            "<br>" +
                           "<hr>" +
                           "<br>" +
                          "</td>" +
                           "</tr>" +
                           "</tbody>" +
                         "</table>" +
                         "</div>" +
                          "</form>" +
                         "</body>" +
                          "</html>";
                // string[] arr = new string[] { "" + net_admin__email + "", "" + BH_email + "", "" + HR_email + "" };    //make as you wish
                //int i = 3;
                //for (int h = 0; h < i; h++)
                //{
                 string strTo = "" + net_admin__email + "";
                 string strCC = "" + BH_email + "," + HR_email + "";
                    try
                    {
                        //mailMessage.To.Add(arr[h]);
                        mailMessage.To.Add(strTo);
                        //Adding multiple CC Addresses
                        foreach (string sCC in strCC.Split(",".ToCharArray()))
                            mailMessage.CC.Add(sCC);

                        mailMessage.From = new MailAddress(senderId);
                        mailMessage.Subject = "Ticket Raised";
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtpClient = new SmtpClient();
                        smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
                        smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                        smtpClient.Host = ConfigurationManager.AppSettings["smtp"];
                        smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                        //SmtpClient smtp = new SmtpClient();
                        //smtp.Host = "secure.emailsrvr.com";
                        //smtp.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
                        //smtp.EnableSsl = true;

                        object userState = mailMessage;

                        try
                        {

                            smtpClient.Send(mailMessage);
                            if (IsAttachment)
                            {
                                attachment.ContentStream.Close();

                            }
                            return;
                        }
                        catch (System.Net.Mail.SmtpException)
                        {
                            return ;
                        }

                    }
                    catch (Exception ex)
                    {
                        //MessageBox("Your Email address is not valid");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Your Email address is not valid');", true);
                    }
                //}

            }

            if (ddlDeptName.SelectedItem.Text == "Facilities")
            {
                string sqlstr1 = @"SELECT jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name,jd.official_email_id
FROM tbl_intranet_employee_jobDetails jd where jd.empcode = '" + UserCode + "'";

                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string user_email = ds.Tables[0].Rows[0]["official_email_id"].ToString();
                string empname = ds.Tables[0].Rows[0]["name"].ToString();

                string sqlstr2 = @"declare @BH varchar(60)
                                   set @BH=(select app_businesshead  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM tbl_intranet_employee_jobDetails where empcode = @BH";
                DataSet ds_BH = new DataSet();
                ds_BH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                string BH_email = ds_BH.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr3 = @"DECLARE @HR varchar(60) SET @HR=(select app_hrd  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id where jd.empcode = @HR";
                DataSet ds_HR = new DataSet();
                ds_HR = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
                string HR_email = ds_HR.Tables[0].Rows[0]["official_email_id"].ToString();
                string HR_role = ds_HR.Tables[0].Rows[0]["role"].ToString();

                string sqlstr4 = @"DECLARE @Admin varchar(60) SET @Admin=(select app_admin  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id where jd.empcode = @Admin";
                DataSet ds_admin = new DataSet();
                ds_admin = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr4);
                string admin_email = ds_admin.Tables[0].Rows[0]["official_email_id"].ToString();
                string admin_name = ds_admin.Tables[0].Rows[0]["official_email_id"].ToString();

                string senderId = "connect@escalon.services"; // Sender EmailID
                string senderPassword = "Escalon2017$"; // Sender Password      
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                string body = @"<html xmlns='http://www.w3.org/1999/xhtml'>" +
                         "<head runat='server'>" +
                         "<title></title>" +
                        "</head>" +
                         "<body>" +
                         "<form id='form1' runat='server'>" +
                         "<div>" +
                         "<table><tr><td><br/></td></tr></table>" +
                         "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                         "<tr>" +
                        "<td><asp:Label ID='lblname' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Dear " + appvrName + " ,</b></asp:Label></td>" +
                        "</tr>" +
                         "<tr><td><br/></td></tr>" +
                        "<tr>" +
                       "<td>" +
                         "<asp:Label ID='lblmessage' runat='server' style='font: 12px arial; color: #333; text-align: justify'>You have a " + ddlDeptName.SelectedItem.Text + " Ticket Raised from " + empname + "- " + UserCode + " for Approval/Reject.</asp:Label>" +
                         "</td>" +
                         "</tr>" +
                       //  "<tr>" +
                       //"<td>" +
                       //  "<asp:Label ID='lblmessage_1' runat='server' style='font: 12px arial; color: #333; text-align: justify'>from " + empname + "-" + UserCode + " for Approval/Reject .</asp:Label>" +
                       //  "</td>" +
                       //  "</tr>" +
                         "<tr><td><br/></td></tr>" +
                         "<tr>" +
                         "<td>" +
                         "<asp:Label ID='lblmessage_2' runat='server' style='font: 12px arial; color: #333; text-align: justify'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
                         "</td>" +
                         "</tr>" +
                         "<tr><td><br/></td></tr>" +
                         "</table>" +
                         "<table><tr><td><br/></td></tr></table>" +
                        "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                         "<tbody>" +
                          "<tr>" +
                           "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                          "<hr>" +
                          "<br>" +
                          "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                           "<br>" +
                           //"(1) Call our 24-hour Customer Care or<br>" +
                           // "(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a></b>" +
                           "<br>" +
                          "<hr>" +
                          "<br>" +
                         "</td>" +
                          "</tr>" +
                          "</tbody>" +
                        "</table>" +
                        "</div>" +
                         "</form>" +
                        "</body>" +
                         "</html>";
                //string[] arr = new string[] { "" + admin_email + "", "" + BH_email + "", "" + HR_email + "" };//make as you wish
                //int i = 3;
                //for (int h = 0; h < i; h++)
                //{
                string strTo = "" + admin_email + "";
                string strCC = "" + BH_email + "," + HR_email + "";
                    try
                    {
                       //mailMessage.To.Add(arr[h]);
                        mailMessage.To.Add(strTo);

                        //Adding multiple CC Addresses
                        foreach (string sCC in strCC.Split(",".ToCharArray()))
                            mailMessage.CC.Add(sCC);

                        mailMessage.From = new MailAddress(senderId);
                        mailMessage.Subject = "Ticket Raised";
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "secure.emailsrvr.com";
                        smtp.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mailMessage);

                    }
                    catch (Exception ex)
                    {
                        //MessageBox("Your Email address is not valid");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Your Email address is not valid');", true);
                    }
               // }
            }

            if (ddlDeptName.SelectedItem.Text == "HR")
            {
                string sqlstr1 = @"SELECT jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name,jd.official_email_id
FROM tbl_intranet_employee_jobDetails jd where jd.empcode = '" + UserCode + "'";

                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string user_email = ds.Tables[0].Rows[0]["official_email_id"].ToString();
                string empname = ds.Tables[0].Rows[0]["name"].ToString();

                string sqlstr2 = @"declare @BH varchar(60)
                                   set @BH=(select app_businesshead  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM tbl_intranet_employee_jobDetails where empcode = @BH";
                DataSet ds_BH = new DataSet();
                ds_BH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                string BH_email = ds_BH.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr3 = @"DECLARE @HR varchar(60) SET @HR=(select app_hrd  from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id where jd.empcode = @HR";
                DataSet ds_HR = new DataSet();
                ds_HR = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
                string HR_email = ds_HR.Tables[0].Rows[0]["official_email_id"].ToString();
                string HR_role = ds_HR.Tables[0].Rows[0]["role"].ToString();

                string senderId = "connect@escalon.services"; // Sender EmailID
                string senderPassword = "Escalon2017$"; // Sender Password      
                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                string body = @"<html xmlns='http://www.w3.org/1999/xhtml'>" +
                         "<head runat='server'>" +
                         "<title></title>" +
                        "</head>" +
                         "<body>" +
                         "<form id='form1' runat='server'>" +
                         "<div>" +
                         "<table><tr><td><br/></td></tr></table>" +
                         "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                         "<tr>" +
                        "<td><asp:Label ID='lblname' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Dear " + appvrName + " ,</b></asp:Label></td>" +
                        "</tr>" +
                         "<tr><td><br/></td></tr>" +
                        "<tr>" +
                       "<td>" +
                         "<asp:Label ID='lblmessage' runat='server' style='font: 12px arial; color: #333; text-align: justify'>You have a " + ddlDeptName.SelectedItem.Text + " Ticket Raised from " + empname + "- " + UserCode + " for Approval/Reject.</asp:Label>" +
                         "</td>" +
                         "</tr>" +
                       //  "<tr>" +
                       //"<td>" +
                       //  "<asp:Label ID='lblmessage_1' runat='server' style='font: 12px arial; color: #333; text-align: justify'>from " + empname + "-" + UserCode + " for Approval/Reject .</asp:Label>" +
                       //  "</td>" +
                       //  "</tr>" +
                         "<tr><td><br/></td></tr>" +
                         "<tr>" +
                         "<td>" +
                         "<asp:Label ID='lblmessage_2' runat='server' style='font: 12px arial; color: #333; text-align: justify'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
                         "</td>" +
                         "</tr>" +
                         "<tr><td><br/></td></tr>" +
                         "</table>" +
                         "<table><tr><td><br/></td></tr></table>" +
                        "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                         "<tbody>" +
                          "<tr>" +
                           "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                          "<hr>" +
                          "<br>" +
                          "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                           "<br>" +
                           //"(1) Call our 24-hour Customer Care or<br>" +
                           // "(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a></b>" +
                           "<br>" +
                          "<hr>" +
                          "<br>" +
                         "</td>" +
                          "</tr>" +
                          "</tbody>" +
                        "</table>" +
                        "</div>" +
                         "</form>" +
                        "</body>" +
                         "</html>";
                //string[] arr = new string[] { "" + BH_email + "" };//make as you wish
                //int i = 1;
                //for (int h = 0; h < i; h++)
                //{
                string strTo = "" + BH_email + "";
                    try
                    {
                        //mailMessage.To.Add(arr[h]);
                        mailMessage.To.Add(strTo);
                        mailMessage.From = new MailAddress(senderId);
                        mailMessage.Subject = "Ticket Raised";
                        mailMessage.Body = body;
                        mailMessage.IsBodyHtml = true;
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "secure.emailsrvr.com";
                        smtp.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
                        smtp.EnableSsl = true;
                        smtp.Send(mailMessage);

                    }
                    catch (Exception ex)
                    {
                        //MessageBox("Your Email address is not valid");
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Your Email address is not valid');", true);
                    }
                //}
            }


            // Common.Console.Output.Show("Query submitted successfully!");
            //reset();
            Response.Redirect("raiseticket.aspx?Submit=true");
        }
    }

    private DataSet GetThomasDetails()
    {
        DataSet dsThomasEmail = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string qryThomasEmail = @"select official_email_id from tbl_intranet_employee_jobDetails where empcode = 'ASIPL0475'";
            dsThomasEmail = SQLServer.ExecuteDataset(connection, CommandType.Text, qryThomasEmail);
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
        return dsThomasEmail;
    }

    private void reset()
    {
        ddlDeptName.SelectedValue = "0";
        ddlQueryType.SelectedValue = "0";


        txtdescription.Text = "";
        Response.Redirect("Query_raiseticket.aspx");
    }

    private bool saverecords()
    {
        var activity = new DataActivity();
        DataSet ds1 = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();

            SqlParameter[] newparameter = new SqlParameter[8];

            newparameter[0] = new SqlParameter("@empCode", SqlDbType.VarChar, 50);
            newparameter[0].Value = UserCode;

            newparameter[1] = new SqlParameter("@deptName", SqlDbType.VarChar, 100);
            newparameter[1].Value = ddlDeptName.SelectedItem.ToString();

            newparameter[2] = new SqlParameter("@queryType", SqlDbType.VarChar, 100);
            newparameter[2].Value = ddlQueryType.SelectedItem.ToString();

            newparameter[3] = new SqlParameter("@refNo", SqlDbType.Int);
            newparameter[3].Value = lblRefNo.Text;

            newparameter[4] = new SqlParameter("@description", SqlDbType.VarChar, 2000);
            newparameter[4].Value = txtdescription.Text;

            newparameter[5] = new SqlParameter("@action", SqlDbType.VarChar, 10);
            newparameter[5].Value = "Insert";

            newparameter[6] = new SqlParameter("@priority", SqlDbType.VarChar, 50);
            newparameter[6].Value = ddlpriority.SelectedItem.ToString();

            newparameter[7] = new SqlParameter("@tickettype", SqlDbType.VarChar, 50);
            newparameter[7].Value = ddlTicketType.SelectedItem.ToString();

            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_query_insertORupdate_raised_query", newparameter);
            bindRefNo();
            return true;
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show("Some database error has been occured!");
            return false;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show("Session has been expired! Please login again.");
            return false;
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        bool s = UpdateRecords();

        if (s)
        {
            //Common.Console.Output.Show("Query Updated successfully!");
            //btnSubmit.Visible = true;
            //btnUpdate.Visible = false;
            //reset();
            Response.Redirect("myquerystatus.aspx?msg=true");
        }
    }

    private bool UpdateRecords()
    {
        var activity = new DataActivity();
        DataSet ds1 = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();

            SqlParameter[] newparameter = new SqlParameter[8];

            newparameter[0] = new SqlParameter("@empCode", SqlDbType.VarChar);
            newparameter[0].Value = UserCode;

            newparameter[1] = new SqlParameter("@deptName", SqlDbType.VarChar, 100);
            newparameter[1].Value = ddlDeptName.SelectedItem.ToString();

            newparameter[2] = new SqlParameter("@queryType", SqlDbType.VarChar, 100);
            newparameter[2].Value = ddlQueryType.SelectedItem.ToString();

            newparameter[3] = new SqlParameter("@refNo", SqlDbType.Int);
            newparameter[3].Value = lblRefNo.Text;

            newparameter[4] = new SqlParameter("@description", SqlDbType.VarChar, 2000);
            newparameter[4].Value = txtdescription.Text;

            newparameter[5] = new SqlParameter("@action", SqlDbType.VarChar, 10);
            newparameter[5].Value = "Update";

            newparameter[6] = new SqlParameter("@priority", SqlDbType.VarChar, 50);
            newparameter[6].Value = ddlpriority.SelectedItem.ToString();

            newparameter[7] = new SqlParameter("@tickettype", SqlDbType.VarChar, 50);
            newparameter[7].Value = ddlTicketType.SelectedItem.ToString();

            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_query_insertORupdate_raised_query", newparameter);

            if (ddlstatus.SelectedValue == "0")
            {
                string query = @"update tbl_query_raised_queries set status=0,approvedDate=NULL,comment=NULL where id='" + Request.QueryString["id"] + "'";
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
            }
            bindRefNo();
            return true;
        }
        catch (SqlException sql)
        {
            Common.Console.Output.Show("Some database error has been occured!");
            return false;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Show("Session has been expired! Please login again.");
            return false;
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private DataSet GetAppvrsEmail()
    {
        string strAllemail;
        DataSet dsAllemail = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            if (ddlDeptName.SelectedItem.ToString().Trim() == "Facilities")
            {
                strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + UserCode + "' DECLARE @appvrCode varchar(50) SET @appvrCode = (select app_admin from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @appvrCode DECLARE @HR varchar(60) SET @HR= (select app_hrd from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @HR ";
                dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
            }
            //            else if (ddlDeptName.SelectedItem.ToString().Trim() == "Finance")
            //            {
            //                strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, 
            //official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + UserCode + "' DECLARE @appvrCode varchar(50) SET @appvrCode = (select app_management from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @appvrCode";
            //                dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
            //            }
            else if (ddlDeptName.SelectedItem.ToString().Trim() == "IT")
            {
                strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + UserCode + "' DECLARE @appvrCode varchar(50) SET @appvrCode = (select clr_networkdept from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @appvrCode DECLARE @BusinessHead varchar(60)SET @BusinessHead=(select app_businesshead from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @BusinessHead";
                dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
            }
            //            else if (ddlDeptName.SelectedItem.ToString().Trim() == "People Department")
            //            {
            //                strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, 
            //official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + UserCode + "' DECLARE @appvrCode varchar(50) SET @appvrCode = (select app_businesshead from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @appvrCode";
            //                dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
            //            }
            else
            {
                strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + UserCode + "' DECLARE @appvrCode varchar(50) SET @appvrCode = (select app_hrd from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @appvrCode DECLARE @BH_1 varchar(60) SET @BH_1=(select app_businesshead from tbl_employee_approvers where empcode = '" + UserCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = @BH_1";
                dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
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
        return dsAllemail;
    }

    public bool sendmail_Template(string recievermailid, string BH, string bdy)
    {

        try
        {
            string senderId = "admin@sdlglobe.com"; // Sender EmailID
            string senderPassword = "Smart@123"; // Sender Password      
            string subject = "Ticket Raised";
            string FileName = string.Empty;
            string body = bdy;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.CC.Add(BH);
            mailMessage.From = new MailAddress(senderId);
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = 25;
            smtpClient.Host = "md-in-59.webhostbox.net";
            smtpClient.EnableSsl = true;
            object userState = mailMessage;


            try
            {
                smtpClient.Send(mailMessage);

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

    public bool sendmail_Template_1(string recievermailid_1, string HR, string bdy_1)
    {
        try
        {
            string senderId = "admin@sdlglobe.com"; // Sender EmailID
            string senderPassword = "Smart@123"; // Sender Password      
            string subject = "Ticket raised";
            string FileName = string.Empty;
            string body = bdy_1;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid_1);
            mailMessage.CC.Add(HR);
            mailMessage.From = new MailAddress(senderId);
            mailMessage.Subject = subject;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            mailMessage.Priority = MailPriority.High;
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = 25;
            smtpClient.Host = "md-in-59.webhostbox.net";
            smtpClient.EnableSsl = true;
            object userState = mailMessage;
            try
            {
                smtpClient.Send(mailMessage);
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

}