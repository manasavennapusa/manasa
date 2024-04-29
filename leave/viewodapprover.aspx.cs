using Common.Console;
using Common.Data;
using Common.Date;
using Smart.HR.Common.Mail.Module;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;


public partial class leave_viewodapprover : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    private string _companyId, _userCode, comment, sqlstr;
    public int i, k, error;
    DataActivity activity = new DataActivity();
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                Common.Encode.QueryString q = new Common.Encode.QueryString();
                hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
                hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
                bind_empdetail();
                bind_od_detail();
            }


        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    #region Bind The Employee Details
    protected void bind_empdetail()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value);
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = _ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = _ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = _ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = _ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = _ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = _ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = _ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Utility.DateFormat(_ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
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
    #endregion
    protected void bind_od_detail()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string str = @"select tbl_leave_apply_od.id,(case when half=0 then 'First Half' else 'Second Half' end) as half,tbl_leave_apply_od.empcode,tbl_leave_apply_od.leavemode,right(convert(varchar(50),tbl_leave_apply_od.intime),7) as intime,right(convert(varchar(50),tbl_leave_apply_od.outtime),7) as  outtime,convert(varchar,tbl_leave_apply_od.date,101)date,convert(varchar,tbl_leave_apply_od.fromtime,101)fromtime,tbl_leave_apply_od.reason,tbl_leave_apply_od.working_hour,tbl_leave_apply_od.comment,tbl_leave_apply_od.Leave_status   from tbl_leave_apply_od
                                where id='" + hidd_leaveapplyid.Value + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, str);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            ViewState["id"] = id;
            int lm = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"].ToString());
            if (lm == 1)
            {
                divfull.Visible = true;
                lbl_date.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lbl_todate.Text = ds.Tables[0].Rows[0]["fromtime"].ToString();
                lbl_OdMode.Text = "Full Day";
                fulltime.Visible = false;

                lbl_Ftime.Text = ds.Tables[0].Rows[0]["intime"].ToString();
                lbl_Ttime.Text = ds.Tables[0].Rows[0]["outtime"].ToString();
            }
            else if (lm == 0)
            {
                divhalf.Visible = true;
                divfull.Visible = false;
                lbl_hdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lbl_HalfMode.Text = ds.Tables[0].Rows[0]["half"].ToString();
                lbl_OdMode.Text = "Half Day";
                fulltime.Visible = false;
            }

            lbl_work_Hours.Text = ds.Tables[0].Rows[0]["working_hour"].ToString();
            lbl_Comment.Text = ds.Tables[0].Rows[0]["comment"].ToString();
            lbl_Reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
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
    #region Approve Button Click Event
    protected void btn_approve_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        SqlTransaction _Transaction = null;
        int leaveid = 0;
        string str = "";
        ArrayList list = new ArrayList();
        int i, leave_status;
        try
        {

            SqlConnection connection = activity.OpenConnection();
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, _userCode);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
            i = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, "sp_leave_validateleavestatus", sqlparm));
            if (i == 0)
                leave_status = 1;
            else
                leave_status = 0;

            string sqlstr = "select leave_status,status,CONVERT(varchar(10),date,101) as fromdate,CONVERT(varchar(10),fromtime,101) as todate from tbl_leave_apply_od where id=" + hidd_leaveapplyid.Value;
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
            {
                case "01":
                    SqlConnection _Connection = activity.OpenConnection();
                    btn_approve.Enabled = false;
                    try
                    {

                        _Transaction = _Connection.BeginTransaction();
                        ApproveOd(leave_status, 1, _Connection, _Transaction);
                        UpdateOd(6, 1, _Connection, _Transaction);
                        updatebackmonth(_Connection, _Transaction);
                        _Transaction.Commit();

                        MailtoEmployee(list, "A", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                        list.Add("OD application approved successfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                    }
                    finally
                    {
                        activity.CloseConnection();
                    }



                    if (error > 0)
                    {

                        for (int j = 0; j < list.Count; j++)
                        {
                            str = str + list[j].ToString();
                            str = str + "\\n";
                        }
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    btn_approve.Enabled = true;
                    Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                    break;

                case "11": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Leave application already approved");
                    break;
                case "21": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Leave application already cancelled");
                    break;
                case "31": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Leave application already rejected");
                    break;
                case "61": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Leave application already approved");
                    break;
                case "10":
                    btn_approve.Enabled = false;
                    try
                    {

                        SqlConnection con = activity.OpenConnection();
                        _Transaction = con.BeginTransaction();
                        ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0, con, _Transaction);
                        UpdateOd(6, 1, con, _Transaction);
                        updatebackmonth(con, _Transaction);
                        _Transaction.Commit();

                        list.Add("OD cancellation application approved sucessfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");

                    }
                    finally
                    {
                        activity.CloseConnection();
                    }


                    if (error > 0)
                    {

                        for (int k = 0; k < list.Count; k++)
                        {
                            str = str + list[k].ToString();
                            str = str + "\\n";
                        }


                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    btn_approve.Enabled = true;


                    Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Leave cancellation application approved sucessfully");
                    break;
                case "60": btn_approve.Enabled = false;
                    try
                    {
                        SqlConnection con = activity.OpenConnection();
                        _Transaction = con.BeginTransaction();
                        ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0, con, _Transaction);
                        UpdateOd(6, 1, con, _Transaction);
                        updatebackmonth(con, _Transaction);
                        _Transaction.Commit();
                        list.Add("OD cancellation application approved sucessfully.");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");

                    }
                    finally
                    {
                        activity.CloseConnection();
                    }

                    if (error > 0)
                    {

                        for (int l = 0; l < list.Count; l++)
                        {
                            str = str + list[l].ToString();
                            str = str + "\\n";
                        }

                        Output.Show(str);

                        //Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    btn_approve.Enabled = true;
                    Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                    break;
                case "12":
                case "62":
                    btn_approve.Enabled = false;
                    try
                    {
                        SqlConnection con = activity.OpenConnection();
                        _Transaction = con.BeginTransaction();
                        ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 2, con, _Transaction);
                        UpdateOd(6, 1, con, _Transaction);
                        updatebackmonth(con, _Transaction);
                        _Transaction.Commit();
                        list.Add("OD modification application approved sucessfully");
                        error++;
                    }
                    catch (Exception ex)
                    {
                        if (_Transaction != null) _Transaction.Rollback();
                        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                        Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");

                    }
                    finally
                    {
                        activity.CloseConnection();
                    }

                    if (error > 0)
                    {


                        for (int m = 0; m < list.Count; m++)
                        {
                            str = str + list[m].ToString();
                            str = str + "\\n";
                        }
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    btn_approve.Enabled = true;
                    Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                    break;

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
    private void UpdateOd(int leavestatus, int status, SqlConnection _Connection, SqlTransaction _Transaction)
    {
        int approverstatus = 0;
        string sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode";
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
        approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(_Connection, CommandType.Text, _Transaction, sqlstr, sqlparm));


        SqlParameter[] sqlparm1 = new SqlParameter[6];
        Output.AssignParameter(sqlparm1, 0, "@id", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm1, 1, "@comment", "String", 5000, "");
        Output.AssignParameter(sqlparm1, 2, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm1, 3, "@status", "Int", 50, status.ToString());
        Output.AssignParameter(sqlparm1, 4, "@Approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm1, 5, "@modifiedby", "String", 50, _userCode);

        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,modifiedby=@modifiedby,comment=isnull(comment,'') +isnull( @comment,''),Approval_status=@Approvel_status,status=@status,modifieddate=getdate() where id=@id";
        SQLServer.ExecuteNonQuery(_Connection, CommandType.Text, _Transaction, str1, sqlparm1);

    }
    protected void updatebackmonth(SqlConnection _Connection, SqlTransaction _Transaction)
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode, leavemode;
        string empcode;
        DataSet ds2, ds3;
        string str1 = "SELECT empcode, date, fromtime,leavemode FROM tbl_leave_apply_od WHERE id=" + hidd_leaveapplyid.Value;
        DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, _Transaction, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromtime"]);
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"].ToString());
            if (fromdate.Month != DateTime.Now.Month)
            {

                //intime = Utility.DateFormat(ds3.Tables[0].Rows[0]["starttime"].ToString());
                //outtime = Utility.DateFormat(ds3.Tables[0].Rows[0]["endtime"].ToString());
                string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='P', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                SQLServer.ExecuteNonQuery(_Connection, CommandType.Text, _Transaction, str4);


            }
        }
    }
    #endregion

    void SendEmail(int leaveid)
    {
        //
    }

    private void MailtoEmployee(ArrayList list, string a, string empcode, string fromdate, string todate)
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
                                string msgdetails = "Your OD";
                                msgdetails += " has been Rejected by Line Manager " + Session["name"].ToString().Trim() + " from dated from " + fromdate + " - " + todate + ".";
                                sendmail_Template(ds.Tables[0].Rows[j]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[j]["emp_fname"].ToString().Trim(), msgdetails), "OD Application Status", ds.Tables[0].Rows[j]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[j]["dlm_mail"].ToString().Trim());

                            }
                        }
                        else if (a == "A")
                        {
                            if (ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim() != "")
                            {
                                string msgdetails = "Your OD";
                                msgdetails += " has been Approved successfully by Line Manager " + Session["name"].ToString().Trim() + " from dated from " + fromdate + " - " + todate + ".";
                                sendmail_Template(ds.Tables[0].Rows[j]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[j]["emp_fname"].ToString().Trim(), msgdetails), "OD Application Status", ds.Tables[0].Rows[j]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[j]["dlm_mail"].ToString().Trim());

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
           // mailMessage.CC.Add(lm_mail);
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

    private void ApproveOd(int leavestatus, int status, SqlConnection _Connection, SqlTransaction _Transaction)
    {
        int approverstatus = 0;
        string sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode";
        SqlParameter[] sqlparm;
        if (leavestatus == 4)
            approverstatus = 0;
        else
        {
            sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, _userCode);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
            approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(_Connection, CommandType.Text, _Transaction, sqlstr, sqlparm));

        }

        SqlParameter[] sqlparm1 = new SqlParameter[6];
        Output.AssignParameter(sqlparm1, 0, "@id", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm1, 1, "@comment", "String", 2000, txt_comment.Text != "" ? "<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>" : "");
        Output.AssignParameter(sqlparm1, 2, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm1, 3, "@status", "Int", 50, status.ToString());
        Output.AssignParameter(sqlparm1, 4, "@Approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm1, 5, "@modifiedby", "String", 50, _userCode);

        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,modifiedby=@modifiedby,comment=isnull(comment,'') +isnull( @comment,''),Approval_status=@Approvel_status,status=@status,modifieddate=getdate() where id=@id";
        SQLServer.ExecuteNonQuery(_Connection, CommandType.Text, _Transaction, str1, sqlparm1);

    }
    //private void mailtoemployee(ArrayList list, string a)
    //{
    //    SqlConnection con = activity.OpenConnection();
    //    string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + lbl_emp_code.Text + "'";
    //    DataSet ds1 = SQLServer.ExecuteDataset(con.CommandType.Text, sqlstr);
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
    //            subject = "Your OD Application Approved Sucessfully. ";
    //            bodyContent = "Your Od Application Approved By " + Session["name"].ToString() + " from " + lbl_department.Text + ".";
    //        }
    //        else if (a == "C")
    //        {

    //            subject = "Cancelation of OD Application. ";
    //            bodyContent = "Your Od Application Cancled By " + Session["name"].ToString() + " from " + lbl_department.Text + ".";
    //        }
    //        string completeBody = Common.Mail.Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
    //        if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
    //        {
    //            try
    //            {
    //                Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
    //            }
    //            catch
    //            {
    //                list.Add("OD Application  is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
    //            }
    //        }
    //        else
    //        {
    //            list.Add("OD Application mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
    //        }


    //    }
    //    activity.CloseConnection();
    //}

    #region Rejection the Leave Request
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        SqlTransaction _Transaction = null;
        int leaveid = 0;
        string str = "";
        ArrayList list = new ArrayList();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select leave_status,status,CONVERT(varchar(10),date,101) as fromdate,CONVERT(varchar(10),fromtime,101) as todate from tbl_leave_apply_od where id=" + hidd_leaveapplyid.Value;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
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
        btn_cancel.Enabled = false;
        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    ApproveOd(3, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD application Rejected successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");

                }
                finally
                {
                    activity.CloseConnection();
                }
                if (error > 0)
                {
                    MailtoEmployee(list, "C", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);
                }

                btn_cancel.Enabled = true;
                Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "11": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already approved");
                break;
            case "21": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already cancelled");
                break;
            case "31": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Leave application already rejected");
                break;
            case "61": Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already approved");
                break;
            case "10":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD Cancelation application Rejected successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");

                }
                finally
                {
                    activity.CloseConnection();
                }
                if (error > 0)
                {
                    MailtoEmployee(list, "C", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);

                }

                btn_cancel.Enabled = true;
                Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "60":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave Canceilation application Rejected successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");

                }
                finally
                {
                    activity.CloseConnection();
                }
                if (error > 0)
                {
                    MailtoEmployee(list, "C", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);

                }

                btn_cancel.Enabled = true;

                Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "12":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD modification application rejected sucessfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");

                }
                finally
                {
                    activity.CloseConnection();
                }
                if (error > 0)
                {
                    MailtoEmployee(list, "C", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    Output.Show(str);

                }

                btn_cancel.Enabled = true;

                Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "62":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();

                    _Transaction = _Connection.BeginTransaction();
                    ApproveOd(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD modification application Rejected successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");

                }
                finally
                {
                    activity.CloseConnection();
                }
                if (error > 0)
                {
                    MailtoEmployee(list, "C", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);

                }

                btn_cancel.Enabled = true;


                Response.Redirect("OdApproval.aspx?leavestatus=0&hr=0&message=" + str);

                break;
        }

    }
    #endregion
    #region Rejection Mail to Employee
    private void cancelleave(ArrayList list, string a)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + hidd_empcode.Value + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, sqlstr);
        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

        string subject = "";
        string bodyContent = "";

        if (a == "A")
        {
            subject = "Rejection of OD Application  By Manager";
            bodyContent = "OD application is Rejected by " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + "of " + lbl_emp_name.Text + ".";
        }
        else if (a == "C")
        {
            subject = "Rejection of Cancelation  OD Application By Manager";
            bodyContent = "your OD cancelation application is rejected by " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + ".";
        }
        else if (a == "U")
        {
            subject = "Rejection of Modification  OD Applilcation Approved By Manager";
            bodyContent = "OD modification  application is rejected by " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + "of " + lbl_emp_name.Text + ".";
        }


        string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
        if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
        {
            try
            {
                Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
            }
            catch
            {
                list.Add("OD Rejection Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            list.Add("OD Rejection Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }
        activity.CloseConnection();

    }
    #endregion
    //protected void btn_cancel_Click(object sender, EventArgs e)
    //{
    //    btn_reject.Enabled = false;
    //    string str = "";
    //    SqlTransaction _Transaction = null;

    //    int leaveid = 0;
    //    ArrayList list = new ArrayList();
    //    try
    //    {

    //        SqlConnection _Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString());
    //        _Connection.Open();

    //        _Transaction = _Connection.BeginTransaction();


    //        SqlParameter[] sqlparm = new SqlParameter[4];
    //        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
    //        sqlparm[0].Value = hidd_leaveapplyid.Value;

    //        sqlparm[1] = new SqlParameter("@comment", SqlDbType.VarChar, 500);
    //        if (txt_comment.Text != "")

    //            sqlparm[1].Value = "<h6><b>Comment added by " + Session["empcode"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
    //        else
    //            sqlparm[1].Value = "";

    //        sqlparm[2] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
    //        sqlparm[2].Value = 3;

    //        sqlparm[3] = new SqlParameter("@Approval_status", SqlDbType.Int, 4);
    //        sqlparm[3].Value = 0;
    //        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,comment=comment + @comment,Approval_status=@Approval_status where id=@id";
    //        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, str1, sqlparm);
    //        bind_od_detail();
    //        _Transaction.Commit();

    //        list.Add("OD application cancelled sucessfully.");
    //        error++;
    //    }
    //    catch
    //    {
    //        _Transaction.Rollback();
    //    }


    //    if (error > 0)
    //    {
    //        mailtoemployee(list, "C");

    //        for (int i = 0; i < list.Count; i++)
    //        {
    //            str = str + list[i].ToString();
    //            str = str + "\\n";
    //        }


    //        Output.Show(str);
    //        // Response.Redirect("leave_status.aspx?leavestatus=0");
    //    }

    //    btn_reject.Enabled = true;
    //    Response.Redirect("view_approverod.aspx?updated=true&message=" + str);
    //}

    protected void btn_back_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        SqlTransaction _Transaction = null;
        try
        {
            SqlConnection con = activity.OpenConnection();
            SqlParameter[] sqlparm = new SqlParameter[4];
            sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@comment", SqlDbType.VarChar, 500);
            if (txt_comment.Text != "")

                sqlparm[1].Value = "<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
            else
                sqlparm[1].Value = "";

            sqlparm[2] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
            sqlparm[2].Value = 4;

            sqlparm[3] = new SqlParameter("@Approval_status", SqlDbType.Int, 4);
            sqlparm[3].Value = 0;

            string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,comment=comment + @comment,Approval_status=@Approval_status where id=@id";
            _Transaction = con.BeginTransaction();
            SQLServer.ExecuteNonQuery(con, CommandType.Text, str1, sqlparm);
            _Transaction.Commit();
            //bind_od_detail();
            Response.Redirect("view_approverod.aspx?updated=true");
        }
        catch (Exception ex)
        {
            if (_Transaction != null) _Transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
}

