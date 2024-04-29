using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Query_AllqueryStatus : System.Web.UI.Page
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
            bindgrid();
        }
    }

    private void bindgrid()
    {
//        sqlstr = @"SELECT rq.id,rq.postedby,rq.queryTypeName,rq.description description1,substring(rq.description,1,20) description,
//(CASE WHEN rq.status=0 THEN 'Pending' when rq.status=1 then 'Approved'  ELSE 'Pending'  END)status,
//rq.status status1,
//(CASE WHEN rq.posteddate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.posteddate, 106) END)posteddate,
//postedby,rq.deptName,rq.approverCode,
//(CASE WHEN rq.approvedDate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.approvedDate, 106) END)approvedDate
//FROM tbl_query_raised_queries rq INNER JOIN tbl_employee_jobDetails ej ON ej.empcode=rq.empCode 
//INNER JOIN dbo.tbl_master_department ed ON ed.id=ej.dept_id where rq.approverCode='" + UserCode + "' ORDER BY rq.posteddate desc";
        sqlstr = @"SELECT 
rq.id, rq.empCode,
rq.postedby,
rq.queryTypeName,
rq.description description1,
rq.priority,
rq.tickettype,
substring(rq.description,1,20) description,
(CASE WHEN rq.status=0 THEN 'Open' when rq.status=1 then 'Closed' when rq.status=2 then 'Under Review' when rq.status=3 then 'Scrapped' ELSE 'Opened'  END)status,
rq.status status1,
rq.comment,
(CASE WHEN rq.posteddate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.posteddate, 106) END)posteddate,
postedby,rq.deptName,rq.approverCode,ej.emp_fname,
(CASE WHEN rq.approvedDate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.approvedDate, 106) END)approvedDate
FROM tbl_query_raised_queries rq 
INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=rq.approverCode
INNER JOIN dbo.tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id 
where rq.approverCode='" + UserCode + "' ORDER BY rq.posteddate desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        suggestionsgrid.DataSource = ds;
        suggestionsgrid.DataBind();
    }

    protected void suggestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        suggestionsgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void suggestionsgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        suggestionsgrid.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void suggestionsgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)suggestionsgrid.DataKeys[e.RowIndex].Value;
        sqlstr = "delete from tbl_query_raised_queries where id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }
    protected void suggestionsgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        suggestionsgrid.EditIndex = -1;
        bindgrid();
    }
    protected void suggestionsgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strstatus = ((DropDownList)suggestionsgrid.Rows[e.RowIndex].Cells[7].Controls[1]).SelectedValue;
        string txtcomment = ((TextBox)suggestionsgrid.Rows[e.RowIndex].Cells[11].Controls[1]).Text;
        int code = (int)suggestionsgrid.DataKeys[e.RowIndex].Value;

        if (strstatus.Trim() == "1" || strstatus.Trim() == "3")
        {
            sqlstr = "UPDATE tbl_query_raised_queries SET status=" + strstatus + ",approverCode='" + UserCode + "',approvedDate=getdate(),comment='" + txtcomment + "' WHERE id=" + code + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            suggestionsgrid.EditIndex = -1;
        }
        else if (strstatus.Trim() == "2")
        {
            sqlstr = "UPDATE tbl_query_raised_queries SET status=" + strstatus + ",approverCode='" + UserCode + "',comment='" + txtcomment + "' WHERE id=" + code + "";
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            suggestionsgrid.EditIndex = -1;
        }

        Label lblemplCode = (Label)suggestionsgrid.Rows[e.RowIndex].FindControl("lblEmpCode");
        string employeeCode = lblemplCode.Text;

        Label lblAppvrCode = (Label)suggestionsgrid.Rows[e.RowIndex].FindControl("lblAppvrCode");
        Label lblAppvrName = (Label)suggestionsgrid.Rows[e.RowIndex].FindControl("lblAppvrName");
        Label lbl_dept = (Label)suggestionsgrid.Rows[e.RowIndex].FindControl("lbldept");
        if (strstatus.Trim() == "1")
        {
            DataSet dsEmpDet = GetEmpDet(employeeCode);
            string from = ConfigurationManager.AppSettings["FromEmail"];

            string employeeName = dsEmpDet.Tables[0].Rows[0]["name"].ToString();
            //string[] to = { dsEmpDet.Tables[0].Rows[0]["official_email_id"].ToString() };
            string to = dsEmpDet.Tables[0].Rows[0]["official_email_id"].ToString();

            //  DataSet dsThomas = GetThomasDetails();
            //  string[] thomasEmail_id = { dsThomas.Tables[0].Rows[0]["official_email_id"].ToString().Trim() };

            string appvrName = lblAppvrName.Text;
            string appvrCode = lblAppvrCode.Text;

            if (lbl_dept.Text == "HR")
            {

                string sqlstr1 = @"SELECT jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name,jd.official_email_id
FROM tbl_intranet_employee_jobDetails jd where jd.empcode = '" + employeeCode + "'";
                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string user_email = ds.Tables[0].Rows[0]["official_email_id"].ToString();
                string username = ds.Tables[0].Rows[0]["name"].ToString();

                string sqlstr2 = @"declare @BH varchar(60)
                                   set @BH=(select app_businesshead  from tbl_employee_approvers where empcode = '" + employeeCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM tbl_intranet_employee_jobDetails where empcode = @BH";
                DataSet ds_BH = new DataSet();
                ds_BH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                string BH_email = ds_BH.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr3 = @"DECLARE @HR varchar(60) SET @HR=(select app_hrd from tbl_employee_approvers where empcode = '" + employeeCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role,role.role as roll_name FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id inner join tbl_intranet_role role on ln.role=role.id where jd.empcode = @HR";
                DataSet ds_HR = new DataSet();
                ds_HR = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
                string HR_email = ds_HR.Tables[0].Rows[0]["official_email_id"].ToString();
                string HR_role = ds_HR.Tables[0].Rows[0]["role"].ToString();
                string HR_role_name = ds_HR.Tables[0].Rows[0]["roll_name"].ToString();

                string sqlstr6 = @"select logn.empcode,logn.role,rol.role as rolename from tbl_login logn
                         inner join tbl_intranet_employee_jobDetails jd on logn.empcode=jd.empcode
                         inner join tbl_intranet_role rol on logn.role=rol.id where logn.empcode='" + UserCode + "'";
                DataSet ds_appvr = new DataSet();
                ds_appvr = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr6);
                string appvr_role = ds_appvr.Tables[0].Rows[0]["rolename"].ToString();


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
      "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0' style='font-family: arial, sans-serif;'>" +
      "<tr>" +
     "<td><asp:Label ID='lblname' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Dear " + employeeName + ",</b></asp:Label></td>" +
     "</tr>" +
      "<tr><td><br/></td></tr>" +
     "<tr>" +
    "<td>" +
      "<asp:Label ID='lblmessage' runat='server' style='font: 12px arial; color: #333; text-align: justify'>" + appvr_role + "-" + appvrName + " has Approved the " + lbl_dept.Text + " Ticket.</asp:Label>" +
      "</td>" +
      "</tr>" +
      "<tr><td><br/></td></tr>" +
      "<tr>" +
      "<td>" +
      "<asp:Label ID='lblmessage_2' runat='server' style='font: 12px arial; color: #333; text-align: justify'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
      "</td>" +
      "</tr>" +
      "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<b><asp:Label ID='lbl_regards' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Regards,</b></asp:Label></b>" +
                  "</td>" +
                  "</tr>" +
                  "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<b><asp:Label ID='lblhr' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>" + appvr_role + "</b></asp:Label></b>" +
                  "</td>" +
                  "</tr>" +
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
                //string[] arr = new string[] { "" + user_email + "", "" + BH_email + "" };//make as you wish
                //int i = 2;
                //for (int h = 0; h < i; h++)
                //{
                string strTo = "" + user_email + "";
                string strCC = "" + BH_email + "";
                    try
                    {
                        //mailMessage.To.Add(arr[h]);
                        mailMessage.To.Add(strTo);
                        mailMessage.CC.Add(strCC);
                        mailMessage.From = new MailAddress(senderId);
                        mailMessage.Subject = "Ticket Status";
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

            if (lbl_dept.Text == "IT")
            {

                string sqlstr1 = @"SELECT jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name,jd.official_email_id
FROM tbl_intranet_employee_jobDetails jd where jd.empcode = '" + employeeCode + "'";

                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string user_email = ds.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr2 = @"declare @BH varchar(60)
                                   set @BH=(select app_businesshead  from tbl_employee_approvers where empcode = '" + employeeCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM tbl_intranet_employee_jobDetails where empcode = @BH";
                DataSet ds_BH = new DataSet();
                ds_BH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                string BH_email = ds_BH.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr3 = @"DECLARE @HR varchar(60) SET @HR=(select app_hrd  from tbl_employee_approvers where empcode = '" + employeeCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role,role.role as roll_name FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id inner join tbl_intranet_role role on ln.role=role.id where jd.empcode = @HR";
                DataSet ds_HR = new DataSet();
                ds_HR = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
                string HR_email = ds_HR.Tables[0].Rows[0]["official_email_id"].ToString();
                string HR_role = ds_HR.Tables[0].Rows[0]["role"].ToString();
                string HR_role_name = ds_HR.Tables[0].Rows[0]["roll_name"].ToString();

                string sqlstr6 = @"select logn.empcode,logn.role,rol.role as rolename from tbl_login logn
                         inner join tbl_intranet_employee_jobDetails jd on logn.empcode=jd.empcode
                         inner join tbl_intranet_role rol on logn.role=rol.id where logn.empcode='" + UserCode + "'";
                DataSet ds_appvr = new DataSet();
                ds_appvr = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr6);
                string appvr_role = ds_appvr.Tables[0].Rows[0]["rolename"].ToString();


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
      "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0' style='font-family: arial, sans-serif;'>" +
      "<tr>" +
     "<td><asp:Label ID='lblname' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Dear " + employeeName + ",</b></asp:Label></td>" +
     "</tr>" +
      "<tr><td><br/></td></tr>" +
     "<tr>" +
    "<td>" +
      "<asp:Label ID='lblmessage' runat='server' style='font: 12px arial; color: #333; text-align: justify'>" + appvr_role + "-" + appvrName + " has Approved the " + lbl_dept.Text + " Ticket.</asp:Label>" +
      "</td>" +
      "</tr>" +
      "<tr><td><br/></td></tr>" +
      "<tr>" +
      "<td>" +
      "<asp:Label ID='lblmessage_2' runat='server' style='font: 12px arial; color: #333; text-align: justify'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
      "</td>" +
      "</tr>" +
      "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<b><asp:Label ID='lbl_regards' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Regards,</b></asp:Label></b>" +
                  "</td>" +
                  "</tr>" +
                  "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<b><asp:Label ID='lblhr' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>" + appvr_role + "</b></asp:Label></b>" +
                  "</td>" +
                  "</tr>" +
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
                //string[] arr = new string[] { "" + user_email + "", "" + BH_email + "", "" + HR_email + "" };//make as you wish
                //int i = 3;
                //for (int h = 0; h < i; h++)
                //{
                string strTo = "" + user_email + "";
                string strCC = "" + BH_email + "," + HR_email + "";
                    try
                    {
                        //mailMessage.To.Add(arr[h]);
                        mailMessage.To.Add(user_email);
                        foreach (string sCC in strCC.Split(",".ToCharArray()))
                        mailMessage.CC.Add(sCC);
                        mailMessage.From = new MailAddress(senderId);
                        mailMessage.Subject = "Ticket Status";
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

            if (lbl_dept.Text == "Facilities")
            {
                string sqlstr1 = @"SELECT jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name,jd.official_email_id
FROM tbl_intranet_employee_jobDetails jd where jd.empcode = '" + employeeCode + "'";

                DataSet ds = new DataSet();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                string user_email = ds.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr2 = @"declare @BH varchar(60)
                                   set @BH=(select app_businesshead  from tbl_employee_approvers where empcode = '" + employeeCode + "') SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, official_email_id FROM tbl_intranet_employee_jobDetails where empcode = @BH";
                DataSet ds_BH = new DataSet();
                ds_BH = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                string BH_email = ds_BH.Tables[0].Rows[0]["official_email_id"].ToString();

                string sqlstr3 = @"DECLARE @HR varchar(60) SET @HR=(select app_hrd  from tbl_employee_approvers where empcode = '" + employeeCode + "') SELECT jd.empcode,jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name, jd.official_email_id,ln.login_id,ln.role,role.role as roll_name FROM tbl_intranet_employee_jobDetails jd inner join tbl_login ln on jd.empcode=ln.login_id inner join tbl_intranet_role role on ln.role=role.id where jd.empcode = @HR";
                DataSet ds_HR = new DataSet();
                ds_HR = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
                string HR_email = ds_HR.Tables[0].Rows[0]["official_email_id"].ToString();
                string HR_role = ds_HR.Tables[0].Rows[0]["role"].ToString();
                string HR_role_name = ds_HR.Tables[0].Rows[0]["roll_name"].ToString();

                string sqlstr6 = @"select logn.empcode,logn.role,rol.role as rolename from tbl_login logn
                         inner join tbl_intranet_employee_jobDetails jd on logn.empcode=jd.empcode
                         inner join tbl_intranet_role rol on logn.role=rol.id where logn.empcode='" + UserCode + "'";
                DataSet ds_appvr = new DataSet();
                ds_appvr = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr6);
                string appvr_role = ds_appvr.Tables[0].Rows[0]["rolename"].ToString();


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
      "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0' style='font-family: arial, sans-serif;'>" +
      "<tr>" +
     "<td><asp:Label ID='lblname' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Dear " + employeeName + ",</b></asp:Label></td>" +
     "</tr>" +
      "<tr><td><br/></td></tr>" +
     "<tr>" +
    "<td>" +
      "<asp:Label ID='lblmessage' runat='server' style='font: 12px arial; color: #333; text-align: justify'>" + appvr_role + "-" + appvrName + " has Approved the " + lbl_dept.Text + " Ticket.</asp:Label>" +
      "</td>" +
      "</tr>" +
      "<tr><td><br/></td></tr>" +
      "<tr>" +
      "<td>" +
      "<asp:Label ID='lblmessage_2' runat='server' style='font: 12px arial; color: #333; text-align: justify'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
      "</td>" +
      "</tr>" +
      "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<b><asp:Label ID='lbl_regards' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>Regards,</b></asp:Label></b>" +
                  "</td>" +
                  "</tr>" +
                  "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<b><asp:Label ID='lblhr' runat='server' style='font: 12px arial; color: #333; text-align: justify'><b>" + appvr_role + "</b></asp:Label></b>" +
                  "</td>" +
                  "</tr>" +
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
                //string[] arr = new string[] { "" + user_email + "", "" + BH_email + "", "" + HR_email + "" };//make as you wish
                //int i = 3;
                //for (int h = 0; h < i; h++)
                //{
                string strTo = "" + user_email + "";
                string strCC = "" + BH_email + "," + HR_email + "";
                    try
                    {
                        //mailMessage.To.Add(arr[h]);
                        mailMessage.To.Add(strTo);
                        foreach (string sCC in strCC.Split(",".ToCharArray()))
                            mailMessage.CC.Add(sCC);
                        mailMessage.From = new MailAddress(senderId);
                        mailMessage.Subject = "Ticket Status";
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

                // string body = EmailBody(from, employeeName, appvrCode, appvrName);
                //SendMail(from, "Query Application - Approved", body, to);

                //string mailBodyThomas = EmailBodyThomasChandy(employeeName, appvrName);
                //SendMail(from, "Query Application - Approved", mailBodyThomas, thomasEmail_id);
            }

            bindgrid();
        }
        bindgrid();
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

    private DataSet GetEmpDet(string empCode)
    {
        string strEmpemail;
        DataSet dsEmpInfo = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            strEmpemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name, 
official_email_id FROM tbl_intranet_employee_jobDetails where empcode = '" + empCode + "'";
            dsEmpInfo = SQLServer.ExecuteDataset(connection, CommandType.Text, strEmpemail);
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
        return dsEmpInfo;
    }

//    private string EmailBody(string from, string userName, string lmCode, string lmName)
//    {
//        string s =
//@"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>
//<html lang='en'>
//<head>
//
//    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
//
//    <style type='text/css'>
//        body, td, div, p, a, input
//        {
//            font-family: arial, sans-serif;
//        }
//    </style>
//
//    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
//    <title>Query Application</title>
//    <style type='text/css'>
//        body, td
//        {
//            font-size: 13px;
//        }
//
//        a:link, a:active
//        {
//            color: #1155CC;
//            text-decoration: none;
//        }
//
//        a:hover
//        {
//            text-decoration: underline;
//            cursor: pointer;
//        }
//
//        a:visited
//        {
//            color: #6611CC;
//        }
//
//        img
//        {
//            border: 0px;
//        }
//
//        pre
//        {
//            white-space: pre;
//            white-space: -moz-pre-wrap;
//            white-space: -o-pre-wrap;
//            white-space: pre-wrap;
//            word-wrap: break-word;
//            max-width: 800px;
//            overflow: auto;
//        }
//
//        .logo
//        {
//            left: -7px;
//            position: relative;
//        }
//    </style>
//</head>
//<body>
//    <div class='bodycontainer'>
//
//
//        <div class='maincontent'>
//
//            <table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>
//                <tr>
//                    
//                    <tr>
//                        <td colspan='2'><font size='-1' class='recipient'>
//                            <div></div>
//                        </font>
//                            <tr>
//                                <td colspan='2'>
//                                    <table width='100%' cellpadding='12' cellspacing='0' border='0'>
//                                        <tr>
//                                            <td>
//                                                <div style='overflow: hidden;'>
//                                                    <font size='-1'>
//                                                        <div id='leaveid'>
//                                                            <table width='100%'>
//                                                                <tbody>
//                                                                    
//                                                                    <tr>
//                                                                        <td style='border-bottom: 1px solid #ccc; font: 12px arial'>
//                                                                            <div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Query Application</span></div>
//                                                                        </td>
//                                                                        <td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>
//                                                                    </tr>
//                                                                </tbody>
//                                                            </table>
//                                                            <br>
//                                                            <p><b>Dear " + userName + @",</b></p>
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>Your Query has been successfully approved by " + lmName + @" - " + lmCode + @".</p>
//
//                                                            <p>Click here - https://aditi.sdlapps.com </p>
//                                                            
//                                                            <p>
//                                                                <b>Regards,<br><br>
//                                                                    People Department<br><br>
//                                                                </b>
//                                                            </p>
//                                                            <br>
//
//                                                            <table width='100%'>
//                                                                <tbody>
//                                                                    <tr>
//                                                                        <td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>
//                                                                            <hr>
//                                                                            <br>
//                                                                            <b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may:
//                                                                            <br>
//                                                                                (1) Call our 24-hour Customer Care or<br>
//                                                                                (2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>
//                                                                            <br>
//                                                                            <hr>
//                                                                            <br>
//                                                                        </td>
//                                                                    </tr>
//                                                                </tbody>
//                                                            </table>
//
//                                                        </div>
//                                                    </font>
//                                                </div>
//                                    </table>
//            </table>
//        </div>
//    </div>
//
//</body>
//</html>";

//        return s;
//    }
//    private string EmailBodyThomasChandy(string empName, string approverName)
//    {
//        string s =
//@"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>
//<html lang='en'>
//<head>
//
//    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
//
//    <style type='text/css'>
//        body, td, div, p, a, input
//        {
//            font-family: arial, sans-serif;
//        }
//    </style>
//
//    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
//    <title>Query Application</title>
//    <style type='text/css'>
//        body, td
//        {
//            font-size: 13px;
//        }
//
//        a:link, a:active
//        {
//            color: #1155CC;
//            text-decoration: none;
//        }
//
//        a:hover
//        {
//            text-decoration: underline;
//            cursor: pointer;
//        }
//
//        a:visited
//        {
//            color: #6611CC;
//        }
//
//        img
//        {
//            border: 0px;
//        }
//
//        pre
//        {
//            white-space: pre;
//            white-space: -moz-pre-wrap;
//            white-space: -o-pre-wrap;
//            white-space: pre-wrap;
//            word-wrap: break-word;
//            max-width: 800px;
//            overflow: auto;
//        }
//
//        .logo
//        {
//            left: -7px;
//            position: relative;
//        }
//    </style>
//</head>
//<body>
//    <div class='bodycontainer'>
//
//
//        <div class='maincontent'>
//
//            <table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>
//                <tr>
//                    
//                    <tr>
//                        <td colspan='2'><font size='-1' class='recipient'>
//                            <div></div>
//                        </font>
//                            <tr>
//                                <td colspan='2'>
//                                    <table width='100%' cellpadding='12' cellspacing='0' border='0'>
//                                        <tr>
//                                            <td>
//                                                <div style='overflow: hidden;'>
//                                                    <font size='-1'>
//                                                        <div id='leaveid'>
//                                                            <table width='100%'>
//                                                                <tbody>
//                                                                    
//                                                                    <tr>
//                                                                        <td style='border-bottom: 1px solid #ccc; font: 12px arial'>
//                                                                            <div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Query Application</span></div>
//                                                                        </td>
//                                                                        <td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>
//                                                                    </tr>
//                                                                </tbody>
//                                                            </table>
//                                                            <br>
//                                                            <p><b>Dear THOMAS CHANDY,</b></p>
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>Query application of " + empName + @" - " + UserCode + @" has been approved and closed by approver - " + approverName + @"</p>
//
//                                                            <p>Click here - https://aditi.sdlapps.com </p>
//                                                            
//                                                            <p>
//                                                                <b>Regards,<br><br>
//                                                                    People Department<br><br>
//                                                                </b>
//                                                            </p>
//                                                            <br>
//
//                                                            <table width='100%'>
//                                                                <tbody>
//                                                                    <tr>
//                                                                        <td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>
//                                                                            <hr>
//                                                                            <br>
//                                                                            <b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may:
//                                                                            <br>
//                                                                                (1) Call our 24-hour Customer Care or<br>
//                                                                                (2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>
//                                                                            <br>
//                                                                            <hr>
//                                                                            <br>
//                                                                        </td>
//                                                                    </tr>
//                                                                </tbody>
//                                                            </table>
//                                                            
//                                                        </div>
//                                                    </font>
//                                                </div>
//                                    </table>
//            </table>
//        </div>
//    </div>
//
//</body>
//</html>";

//        return s;
//    }

}