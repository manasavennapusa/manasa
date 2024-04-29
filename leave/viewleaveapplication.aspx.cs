using Common.Console;
using Common.Data;
using Common.Encode;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Smart.HR.Common.Mail.Module;
using System.Net.Mail;

public partial class leave_viewleaveapplication : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr; int error;
    int leav;
    private string leavetype;
    //========================== Created By Ramu Nunna on 10-Dec-2014 ==================================================//
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
                bindemployee_detail();
                fetchleavedata();
            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    #region Bind The Employee Details
    protected void bindemployee_detail()
    {

        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Fetch Leave Details
    protected void fetchleavedata()
    {
        try
        {
            if (hidd_leaveapplyid.Value == "0")
            {
                Output.Show("Problem fetchin leave data,try latter");
                return;
            }
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
                leav = Convert.ToInt32(ds.Tables[0].Rows[0]["leaveid"].ToString());
                if (leav == 1)
                {
                    leavetype = "EL";
                }
                if (leav == 2)
                {
                    leavetype = "CL/SL";
                }
                if (leav == 3)
                {
                    leavetype = "PBL";
                }
                if (leav == 4)
                {
                    leavetype = "ML";
                }
                if (leav == 5)
                {
                    leavetype = "PL";
                }
                ViewState["leavetp"] = leavetype;
  
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
                {
                    divfull.Visible = true;
                    divhalf.Visible = false;
                    DateTime lblsdate, lbledate;
                    lbl_sdate.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd - MMM - yyyy");
                    lbl_edate.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd - MMM - yyyy");


                }
                else
                {
                    divfull.Visible = false;
                    divhalf.Visible = true;
                    //commented
                    //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                    lbl_select.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd - MMM - yyyy");
                    lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
                }

                if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
                {
                    txt_cancel.Enabled = false;
                    btn_modify.Enabled = false;
                    txt_comment.Enabled = false;
                }
                if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "6") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
                {
                    btn_modify.Enabled = false;
                }
                lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
                lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
                lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
                lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a target='_blank' href='Upload/Doc/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
                  "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No existing file found";
            }
            else
            {
                Output.Show("No data available");
                return;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                adjustgrid.DataSource = ds.Tables[1];
                adjustgrid.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                approvergrid.DataSource = ds.Tables[2];
                approvergrid.DataBind();
            }
            if (ds.Tables[0].Rows[0]["leaveid"].ToString() == ConfigurationManager.AppSettings["FL"].ToString())
            {
                divfurnalleave.Visible = true;
                lblrelation.Text = ds.Tables[0].Rows[0]["relation"].ToString();
            }
            //if (lbl_select.Text != "")
            //{
            //    if (Convert.ToDateTime(lbl_select.Text).Date < System.DateTime.Today.Date)
            //    {
            //        txt_comment.Visible = false;
            //        txt_cancel.Visible = false;
            //    }
            //}
            //if (lbl_sdate.Text != "")
            //{
            //    if (Convert.ToDateTime(lbl_sdate.Text).Date < System.DateTime.Today.Date)
            //    {
            //        txt_comment.Visible = false;
            //        txt_cancel.Visible = false;
            //    }
            //}
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

    void SendEmail(int leaveid, string appSenderName)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfCancelRequest();
        EmailClient client = new EmailClient(email);
        client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
        client.empCode = Session["empcode"].ToString();
        client.employeeName = Session["name"].ToString().Trim();
        client.appsendername = appSenderName;
        client.requestNumber = leaveid.ToString();
        client.Send();
    }


    private void Mailtoapprover(ArrayList list, int leaveid, string type)
    {
        //var activity = new DataActivity();
        //SqlParameter[] sqlparm = new SqlParameter[2];
        //Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        //Output.AssignParameter(sqlparm, 1, "@type", "String", 20, type.ToString());

        //SqlConnection connection = activity.OpenConnection();
        //DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
        //    "sp_leave_fetchmaildetail_employee", sqlparm);

        //DataSet dsemp = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
        //    "sp_leave_fetchmaildetail_emp", sqlparm);
        //DataRow rowemp = dsemp.Tables[0].Rows[0];

        //activity.CloseConnection();

        //SendEmail(leaveid, rowemp["a_name"].ToString().Trim());

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    int i = ds.Tables[0].Rows.Count;
        //    int j = 0;

        //    while (i != 0)
        //    {
        //        if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
        //        {
        //            try
        //            {
        //                EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfCancelRequestApprover();
        //                EmailClient client = new EmailClient(email);
        //                client.toEmailId = ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim();
        //                client.empCode = ds.Tables[0].Rows[j]["approvercode"].ToString().Trim();
        //                client.employeeName = ds.Tables[0].Rows[j]["a_name"].ToString().Trim();
        //                client.appsendername = rowemp["a_name"].ToString().Trim();
        //                client.requestNumber = leaveid.ToString();
        //                client.Send();
        //            }
        //            catch
        //            {
        //                list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"] +
        //                         " due to some technical problem.");
        //            }
        //        }
        //        else
        //        {
        //            list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"]);
        //        }

        //        i--;
        //        j++;
        //    }
        //}
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "l");
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        activity.CloseConnection();

        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //string appmsg = "Dear " + ds.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            //appmsg += " You have a pending Leave Application from " + lbl_emp_name.Text.Trim() + " - " + _userCode.Trim() + "\n" + "\n " + "\n";
            //appmsg += "Regards" + "," + "\n";
            //appmsg += "HR" + "\n";
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["a_name"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim());
            }
        }




    }
    public bool sendmail_Template(string recievermailid, string approver, string employee, string empcode)
    {

        try
        {
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];  
            string Template = EmailTemplate(approver, employee, empcode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Leave Application Cancel";
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


//    public string EmailTemplate(string approver, string employee, string empcode)
//    {
//        string leave;
      
//        string appr = approver.ToString();
//        string emp = employee.ToString();
//        string empcod = empcode.ToString();
//        string EmailFormat = @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
//                    "<html lang='en'>" +
//"<head>" +

//    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +

//    "<style type='text/css'>" +
//        "body, td, div, p, a, input" +
//        "{" +
//            "font-family: arial, sans-serif;" +
//        "}" +
//    "</style>" +

//    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
//    "<title>OD Application</title>" +
//    "<style type='text/css'>" +
//        "body, td" +
//        "{" +
//            "font-size: 13px;" +
//        "}" +

//        "a:link, a:active" +
//        "{" +
//            "color: #1155CC;" +
//            "text-decoration: none;" +
//        "}" +

//        "a:hover" +
//       "{" +
//            "text-decoration: underline;" +
//            "cursor: pointer;" +
//        "}" +

//        "a:visited" +
//        "{" +
//            "color: #6611CC;" +
//        "}" +

//        "img" +
//        "{" +
//            "border: 0px;" +
//        "}" +

//        "pre" +
//        "{" +
//            "white-space: pre;" +
//            "white-space: -moz-pre-wrap;" +
//            "white-space: -o-pre-wrap;" +
//            "white-space: pre-wrap;" +
//           "word-wrap: break-word;" +
//           "max-width: 800px;" +
//            "overflow: auto;" +
//        "}" +

//        ".logo" +
//        "{" +
//            "left: -7px;" +
//            "position: relative;" +
//        "}" +
//    "</style>" +
//"</head>" +
//"<body>" +
//    "<div class='bodycontainer'>" +


//        "<div class='maincontent'>" +

//            "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>" +
//                "<tr>" +

//                    "<tr>" +
//                        "<td colspan='2'><font size='-1' class='recipient'>" +
//                            "<div></div>" +
//                        "</font>" +
//                           " <tr>" +
//                                "<td colspan='2'>" +
//                                    "<table width='100%' cellpadding='12' cellspacing='0' border='0'>" +
//                                        "<tr>" +
//                                            "<td>" +
//                                                "<div style='overflow: hidden;'>" +
//                                                    "<font size='-1'>" +
//                                                        "<div id='leaveid'>" +
//            //"<table width='100%'>" +
//            //    "<tbody>" +

//                                                            //        "<tr>" +
//            //            "<td style='border-bottom: 1px solid #ccc; font: 12px arial'>" +
//            //                "<div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Holiday Work Application</span></div>" +
//            //            "</td>" +
//            //            "<td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>" +
//            //        "</tr>" +
//            //    "</tbody>" +
//            //"</table>" +
//            //"<br>" +
//                                                            "<p><b>Dear " + appr + @",</b></p>" +
//                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Leave Application(" + ViewState["leavetp"].ToString() + ") cancel request from  " + emp + " - " + empcod + " for Approval.</p>" +

    //                                                            "<p>Click here - " + ConfigurationManager.AppSettings["EmailLink"] + "</p>" +

//                                                            "<p>" +
//                                                                "<b>Regards,<br><br>" +
//                                                                    "HR<br><br>" +
//                                                                "</b>" +
//                                                            "</p>" +
//                                                            "<br>" +

//                                                            "<table width='100%'>" +
//                                                                "<tbody>" +
//                                                                    "<tr>" +
//                                                                        "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
//                                                                            "<hr>" +
//                                                                            "<br>" +
//                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may:" +
//                                                                            "<br>" +
//                                                                                "(1) Call our 24-hour Customer Care or<br>" +
//                                                                                "(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>" +
//                                                                            "<br>" +
//                                                                            "<hr>" +
//                                                                            "<br>" +
//                                                                        "</td>" +
//                                                                    "</tr>" +
//                                                                "</tbody>" +
//                                                            "</table>" +

//                                                        "</div>" +
//                                                    "</font>" +
//                                                "</div>" +
//                                    "</table>" +
//            "</table>" +
//        "</div>" +
//    "</div>" +

//"</body>" +
//"</html>";

//        return EmailFormat;
//    }
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Leave Application(" + ViewState["leavetp"].ToString() + ") cancel request from  " + emp + " - " + empcod + " for Approval.</p>" +

                                                            "<p>Click here - " + ConfigurationManager.AppSettings["EmailLink"] + "</p>" +

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
    #endregion

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm2;

        sqlparm2 = new SqlParameter[2];
        Output.AssignParameter(sqlparm2, 0, "@applyleaveid", "Int", 0, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm2, 1, "@empcode", "String", 50, _userCode);
        try
        {
            SqlConnection connection = activity.OpenConnection();
            DataSet _ds6 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_freeze", sqlparm2);

            if (_ds6.Tables.Count < 1)
            {

            }
            else
            {
                Output.Show(_ds6.Tables[0].Rows[0][1].ToString());
                return;
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        int status = 0;
        txt_cancel.Enabled = false;
        SqlTransaction _Transaction = null;
        string str = "";
        int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
        ArrayList list = new ArrayList();
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[1];
        Output.AssignParameter(sqlparm, 0, "@id", "Int", 0, hidd_leaveapplyid.Value);
        try
        {
            SqlConnection connection = activity.OpenConnection();
            status = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, "sp_leave_validate_confirm_hr", sqlparm));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

        switch (status)
        {
            case 0:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    CancelDatewise(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancelled successfully.");
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
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 1: try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(1, 0, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave applied for cancellation successfully.");
                    error++;

                    Mailtoapprover(list, leaveid, "l");


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
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;
                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 2:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
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
                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=Leave already cancelled");
                break;
            case 3:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(3, 1, _Connection, _Transaction);
                    _Transaction.Commit();
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
                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=Leave cannot be cancelled,its already in rejected status");
                break;
            case 4: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancelled successfully.");
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
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 5: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancelled successfully.");
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

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 6: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(6, 0, _Connection, _Transaction);
                    ApprovedCancelDatewise(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave applied for cancellation successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
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
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
        }


    }

    protected void cancelleave(int leave_status, int status, SqlConnection connection, SqlTransaction _transaction)
    {
        //  SqlConnection connection=activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[5];

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, txt_comment.Text != "" ? "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "<br>" : "");
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 100, _userCode.ToString());
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 100, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 100, leave_status.ToString());
        Output.AssignParameter(sqlparm, 4, "@status", "Int", 100, status.ToString());

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,approvel_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, _transaction, sqlstr, sqlparm);

        }
        else
        {
            sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, _transaction, sqlstr, sqlparm);
        }

    }

    protected void btn_modify_Click(object sender, EventArgs e)
    {
        QueryString q = new QueryString();
        string pairs = String.Format("leaveapplyid={0}&modify=1", hidd_leaveapplyid.Value);
        string encoded;
        encoded = q.EncodePairs(pairs);
        Response.Redirect("ModifiedLeave.aspx?q=" + encoded);
    }

    protected void approvergrid_PreRender(object sender, EventArgs e)
    {
        if (approvergrid.Rows.Count > 0)
            approvergrid.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
    }

    protected void adjustgrid_PreRender(object sender, EventArgs e)
    {
        if (adjustgrid.Rows.Count > 0)
            adjustgrid.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
    }
    protected void CancelDatewise(SqlConnection connection, SqlTransaction transaction)
    {
        //DataSet ds1 = new DataSet();
        //sqlstr = "select * from tbl_leave_apply_leave_datewise where leaveid='" + hidd_leaveapplyid.Value + "' and leave_status=0";
        //ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);
        //if (ds1.Tables[0].Rows.Count > 1)
        //{
        SqlParameter[] sqlparm;
        string sqlstr1 = "update tbl_leave_apply_leave_datewise set leave_status=@leave_status,status=1,aproverlevel=@approver_level where leaveid=@applyleaveid";
        sqlparm = new SqlParameter[3];

        Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 1, "@leave_status", "Int", 50, "2");


        Output.AssignParameter(sqlparm, 2, "@approver_level", "Int", 50, "0");

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1, sqlparm);

        //}
    }
    protected void ApprovedCancelDatewise(SqlConnection connection, SqlTransaction transaction)
    {
        //DataSet ds1 = new DataSet();
        //sqlstr = "select * from tbl_leave_apply_leave_datewise where leaveid='" + hidd_leaveapplyid.Value + "' and leave_status=6";
        //ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);
        //if (ds1.Tables[0].Rows.Count > 1)
        //{
        SqlParameter[] sqlparm;
        string sqlstr1 = "update tbl_leave_apply_leave_datewise set leave_status=@leave_status,status=0,aproverlevel=@approver_level where leaveid=@applyleaveid";
        sqlparm = new SqlParameter[3];

        Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 1, "@leave_status", "Int", 50, "6");


        Output.AssignParameter(sqlparm, 2, "@approver_level", "Int", 50, "0");

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1, sqlparm);

        //}
    }
}
