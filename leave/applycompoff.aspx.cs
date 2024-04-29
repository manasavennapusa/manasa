using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using Utilities;
using Common.Console;
using Common.Data;
using System.Net.Mail;
public partial class leave_applycompoff : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string message1;
    DataTable dtable = new DataTable();
    int flag = 0;
    public int i, ptr1, ptr2;
    string todate, fromdt;
    private string _companyId, _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null && Session["role"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();

            if (!IsPostBack)
            {
                Session.Remove("aleave");
                bind_empdetail();
                bindcompoffentitled();
            }
        }
        else
            Response.Redirect("~/notlogged.aspx");
    }

    #region
    protected override void OnInit(EventArgs e)
    {
        InitializeComponents();
        base.OnInit(e);
    }

    private void InitializeComponents()
    {

    }

    #endregion
    #region BindCompoff Balance
    protected void bindcompoffentitled()
    {
        var activity = new DataActivity();

        try
        {
            SqlParameter[] sqlparm1 = new SqlParameter[1];
            Output.AssignParameter(sqlparm1, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_leave_entitledcompoff]", sqlparm1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblentitled.Text = ds.Tables[0].Rows[0]["allowcompoff"].ToString();
                lblused.Text = ds.Tables[0].Rows[0]["approvedays"].ToString();
                lblavalible.Text = ds.Tables[0].Rows[0]["avalibledays"].ToString();
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
    #endregion
    #region Bind Employee Details
    protected void bind_empdetail()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["emp_doj"].ToString())
                .ToString("dd - MMM - yyyy");
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
    #region Caluclation of No. days
    protected void btn_calc_Click(object sender, EventArgs e)
    {
        //  if (!validate_dutyroster())
        //     return;
        if (validate_applydate())
        {
            validateapplycompoff();
        }
        else
        {
            return;
        }
    }
    #endregion
    #region Validate the Applied Compoff
    protected void validateapplycompoff()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlParameter[] sqlparm = new SqlParameter[7];

            sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[0].Value = Session["empcode"].ToString();

            sqlparm[1] = new SqlParameter("@halfday", SqlDbType.Bit);
            sqlparm[1].Value = Convert.ToBoolean(rdohalfday.Checked);

            sqlparm[2] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
            sqlparm[3] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);

            if (divfull.Visible == true)
            {
                sqlparm[2].Value = Utility.dataformat(txt_fromdate.Text.Trim().ToString());
                sqlparm[3].Value = Utility.dataformat(txt_todate.Text.Trim().ToString());
            }
            else
            {
                sqlparm[2].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
                sqlparm[3].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
            }

            sqlparm[4] = new SqlParameter("@branch_id", SqlDbType.Int, 4);
            sqlparm[4].Value = Convert.ToInt32(Session["branch"]);

            sqlparm[5] = new SqlParameter("@id", SqlDbType.Int, 4);
            sqlparm[5].Value = 0;

            sqlparm[6] = new SqlParameter("@companyid", SqlDbType.Int, 4);
            sqlparm[6].Value = Session["companyid"];

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_leave_validatecompoff]", sqlparm);

            lbl_no_of_days.Text = ds.Tables[0].Rows[0]["noofdays"].ToString();

            if (lbl_no_of_days.Text == "0.0")
            {
                Common.Console.Output.Show("There is no balance Comp-Off.Please check the Comp-Off Status. ");
            }
            else
            {
                btn_submit.Enabled = true;

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
    #endregion
    #region Validate the duty roster
    protected Boolean validate_dutyroster()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            if (divfull.Visible == true)
            {
                DateTime dt1 = Convert.ToDateTime(txt_fromdate.Text);
                DateTime dt2 = Convert.ToDateTime(txt_todate.Text);
                TimeSpan d1 = Convert.ToDateTime(txt_todate.Text) - Convert.ToDateTime(txt_fromdate.Text);

                if (d1.Days < 0)
                {
                    Common.Console.Output.Show("End date should be greater than start date.");
                    lbl_no_of_days.Text = "0.0";
                    return false;
                }
            }

            //-----------------validate---work roster creation---------------------------------

            DataSet dsdr = new DataSet();

            SqlParameter[] sqlpar = new SqlParameter[3];

            sqlpar[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlpar[0].Value = Session["empcode"].ToString();

            sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

            if (divfull.Visible == true)
            {
                sqlpar[1].Value = txt_fromdate.Text;
                sqlpar[2].Value = txt_todate.Text;
            }
            else
            {
                sqlpar[1].Value = txtdateone.Text;
                sqlpar[2].Value = txtdateone.Text;
            }

            dsdr = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_leave_dutyroster", sqlpar);

            if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) > 0)
            {
                if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) != Convert.ToInt32(dsdr.Tables[1].Rows[0]["applieddays"].ToString()))
                {
                    Common.Console.Output.Show("Your work roster is not created for this date span.Please contact your Manager.");
                    return false;
                }
            }
            else
            {
                Common.Console.Output.Show("Your work roster is not created for this date span.Please contact your Manager.");
                return false;
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
        return true;
    }
    #endregion
    #region Validate The Applied Dates
    protected Boolean validate_applydate()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = Session["empcode"].ToString();

            sqlparam[1] = new SqlParameter("@startdate", SqlDbType.DateTime);

            sqlparam[2] = new SqlParameter("@enddate", SqlDbType.DateTime);


            if (divfull.Visible == true)
            {
                sqlparam[1].Value = Utility.dataformat(txt_fromdate.Text);
                sqlparam[2].Value = Utility.dataformat(txt_todate.Text);
            }
            else
            {
                sqlparam[1].Value = Utility.dataformat(txtdateone.Text);
                sqlparam[2].Value = Utility.dataformat(txtdateone.Text);
            }

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_no_of_days.Text = "0";
                Common.Console.Output.Show("You have already applied for Leave/OD/Comp-Off during this span! Please check application status");
                return false;
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lbl_no_of_days.Text = "0";
                    Common.Console.Output.Show("You have already applied for Comp-Off during this span! Please check application status");

                    return false;
                }
                else
                {
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        lbl_no_of_days.Text = "0";
                        Common.Console.Output.Show("You have already applied for OD during this span! Please check application status");
                        return false;
                    }
                    else
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            lbl_no_of_days.Text = "0";
                            Common.Console.Output.Show("Your leave profile is not created! Please contact to Manager");
                            return false;
                        }
                    }
                }
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
        return true;
    }
    #endregion

    #region Submit Click Event
    protected void btn_submit_Click1(object sender, EventArgs e)
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        SqlTransaction transaction = null;
        try
        {
            Page.Validate("calculate");
            Page.Validate("v");
            // if (!validate_dutyroster())
            //   return;
            if (validate_applydate())
            {

            }
            else
            {
                return;
            }


            ArrayList list = new ArrayList();
            connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            int leaveid = insertapplycompoff(0, connection, transaction);
            transaction.Commit();
            if (leaveid > 0)
                list.Add("Compoff leave applied successfully.");
            if (HiddenField1.Value == "0")
            {
                //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //mailtoapprover(list, leaveid, "c");
                SendMail(leaveid);
                sendmailtoemp(leaveid);
                string str = "";
                for (int i = 0; i < list.Count; i++)
                {
                    str = str + list[i].ToString();
                    str = str + "\\n";
                }

                clear();
                SmartHr.Common.Alert(str);
            }
            else if (HiddenField1.Value == "5")
                Common.Console.Output.Show("Compoff leave save as draft");

            if (flag == 0)
                clear();


        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Comp-off application some problem is their. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion
    #region Insert the Commpoff Details
    protected int insertapplycompoff(int status, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparm = new SqlParameter[13];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();


        sqlparm[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparm[2] = new SqlParameter("@todate", SqlDbType.DateTime);

        if (divfull.Visible == true)
        {
            sqlparm[1].Value = Utility.dataformat(txt_fromdate.Text.Trim().ToString());
            sqlparm[2].Value = Utility.dataformat(txt_todate.Text.Trim().ToString());
        }
        else
        {
            sqlparm[1].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
            sqlparm[2].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
        }

        sqlparm[3] = new SqlParameter("@approval_status", SqlDbType.Int, 4);
        sqlparm[3].Value = 0;

        sqlparm[4] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[4].Value = status;
        HiddenField1.Value = status.ToString();

        sqlparm[5] = new SqlParameter("@reason", SqlDbType.VarChar, 500);
        sqlparm[5].Value = txt_reason.Text.Trim().ToString().Replace("'", "''");

        if (txt_comment.Text != "")
        {
            txt_comment.Text = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        }

        sqlparm[6] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        sqlparm[6].Value = txt_comment.Text.Trim().ToString().Replace("'", "''");

        sqlparm[7] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparm[7].Value = Session["name"].ToString();

        sqlparm[8] = new SqlParameter("@createddate", SqlDbType.DateTime, 8);
        sqlparm[8].Value = DateTime.Now;

        sqlparm[9] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[9].Value = Session["name"].ToString();

        sqlparm[10] = new SqlParameter("@no_of_days", SqlDbType.Decimal);
        sqlparm[10].Value = lbl_no_of_days.Text;

        sqlparm[11] = new SqlParameter("@half", SqlDbType.Bit);
        sqlparm[11].Value = Convert.ToBoolean(rdofullday.Checked);

        sqlparm[12] = new SqlParameter("@companyid", SqlDbType.Int);
        sqlparm[12].Value = Session["companyid"].ToString();
        return Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "sp_leave_applycompoff", sqlparm));

    }
    #endregion
    #region Mail to Approver
    //protected void mailtoapprover(ArrayList list, int leaveid, string type)
    //{
    //    var activity = new DataActivity();
    //    try
    //    {
    //        SqlConnection connection = activity.OpenConnection();

    //        SqlParameter[] sqlparm = new SqlParameter[2];
    //        sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
    //        sqlparm[1] = new SqlParameter("@type", type);

    //        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
    //        if (ds.Tables[0].Rows.Count > 0)
    //        {
    //            int i = ds.Tables[0].Rows.Count;
    //            int j = 0;

    //            while (i != 0)
    //            {
    //                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
    //                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
    //                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
    //                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
    //                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
    //                //query q = new query();
    //                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "CO");
    //                //string encoded;
    //                //encoded = q.EncodePairs(pairs);

    //                string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
    //                string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
    //                string subject = "Compoff Application for Approval";
    //                string bodyContent = "";

    //                if (divfull.Visible == true)
    //                    bodyContent = "A new Compoff request has been submitted by employee " + Session["name"].ToString() + " from " + txt_fromdate.Text + " to " + txt_todate.Text + ". <br/><br/><br/><br/>" + url + "&nbsp;&nbsp;&nbsp;" + url1;
    //                else
    //                    bodyContent = "A new Compoff request has been submitted by employee " + Session["name"].ToString() + " for the date " + txtdateone.Text + ". <br/><br/><br/><br/>" + url + "&nbsp;&nbsp;&nbsp;" + url1;


    //                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);

    //                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
    //                {
    //                    try
    //                    {
    //                        Email.getemail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
    //                    }
    //                    catch
    //                    {
    //                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString() + " due to some technical problem.");
    //                    }
    //                }
    //                else
    //                {
    //                    list.Add("Email is does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString());
    //                }

    //                i--;
    //                j++;
    //            }
    //        }
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
    #endregion
    #region Clear the Textboxes
    protected void clear()
    {
        txt_comment.Text = "";
        txt_fromdate.Text = "";
        lbl_no_of_days.Text = "";
        txt_reason.Text = "";
        txt_todate.Text = "";
        txtdateone.Text = "";

    }
    #endregion
    #region Reset the Button click
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();

    }
    #endregion
    #region Full & Half day Events
    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
        }
    }
    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;

        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;

        }
    }
    #endregion


    private void SendMail(int leaveid)
    {

        fromdt = txt_fromdate.Text;
        todate = txt_todate.Text;


        //-----------------------Sending Mail To Employee---------------------//

        //string empmsg = "Dear " + lbl_emp_name.Text + "," + "\n" + "\n";
        //empmsg += "Thanks for using Smart HR.You have applied " + dd_typeleave.SelectedItem + " for " + txt_nod.Text + " days that is from " + fromdt + "  to  " + todt + "\n";
        //empmsg += "Your application will submitted to Approver for Approval" + "\n" + "\n " + "\n";

        //empmsg += "Regards" + "," + "\n";
        //empmsg += "HR" + "\n";
        //if (Session["OfficialEmailId"].ToString().Trim() != "")
        //{
        //  //  sendmail_Template(Session["OfficialEmailId"].ToString().Trim(), empmsg);
        //}
        //----------------------Sending Mail To Approver ---------------------//

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //SqlParameter[] sqlparm = new SqlParameter[2];
        //Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        //Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "co");


        string query = @"select distinct job.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_employee_approvers app 
inner join dbo.tbl_intranet_employee_jobDetails job 
on job.empcode=app.clr_department
inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager 
where app.empcode='" + Session["empcode"].ToString() + "'";

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //string appmsg = "Dear " + ds.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            //appmsg += " You have a pending Leave Application from " + lbl_emp_name.Text.Trim() + " - " + _userCode.Trim() + "\n" + "\n " + "\n";
            //appmsg += "Regards" + "," + "\n";
            //appmsg += "HR" + "\n";
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["emp_fname"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(), fromdt, todate, ds.Tables[0].Rows[i]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[i]["dlm_mail"].ToString().Trim());
            }
        }


    }

    public bool sendmail_Template(string recievermailid, string approver, string employee, string empcode, string fromdt, string todate, string lm_mail, string dlm_mail)
    {

        try
        {


            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];       

            string Template = EmailTemplate(approver, employee, empcode, fromdt, todate);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Compoff Application";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;

            //if (fileAttachment.HasFile)
            //{
            //    FileName = Path.GetFileName(fileAttachment.PostedFile.FileName);
            //    FileName = "attachments/" + FileName;
            //    fileAttachment.PostedFile.SaveAs(Server.MapPath(FileName));

            //    attachment = new System.Net.Mail.Attachment(Server.MapPath(FileName));
            //    mailMessage.Attachments.Add(attachment);

            //    IsAttachment = true;
            //}

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
    public string EmailTemplate(string approver, string employee, string empcode, string fromdt, string todate)
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
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Compoff request from  " + emp + " - " + empcod + " dated from " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + " - " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + " for Approval / Reject.</p>" +

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

    private void sendmailtoemp(int leaveid)
    {

        fromdt = txt_fromdate.Text;
        todate = txt_todate.Text;


        //-----------------------Sending Mail To Employee---------------------//

        //string empmsg = "Dear " + lbl_emp_name.Text + "," + "\n" + "\n";
        //empmsg += "Thanks for using Smart HR.You have applied " + dd_typeleave.SelectedItem + " for " + txt_nod.Text + " days that is from " + fromdt + "  to  " + todt + "\n";
        //empmsg += "Your application will submitted to Approver for Approval" + "\n" + "\n " + "\n";

        //empmsg += "Regards" + "," + "\n";
        //empmsg += "HR" + "\n";
        //if (Session["OfficialEmailId"].ToString().Trim() != "")
        //{
        //  //  sendmail_Template(Session["OfficialEmailId"].ToString().Trim(), empmsg);
        //}
        //----------------------Sending Mail To Approver ---------------------//

        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //SqlParameter[] sqlparm = new SqlParameter[2];
        //Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        //Output.AssignParameter(sqlparm, 1, "@type", "String", 20, "co");


        string query = @"select distinct jobvh.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_intranet_employee_jobDetails job
 inner join tbl_employee_approvers app on app.empcode=job.empcode
 inner join tbl_intranet_employee_jobDetails jobvh on jobvh.empcode=app.clr_department
 inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
 inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager
 where job.empcode='" + Session["empcode"].ToString() + "'";

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
        activity.CloseConnection();


        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            //string appmsg = "Dear " + ds.Tables[0].Rows[i]["a_name"].ToString().Trim() + "," + "\n" + "\n";
            //appmsg += " You have a pending Leave Application from " + lbl_emp_name.Text.Trim() + " - " + _userCode.Trim() + "\n" + "\n " + "\n";
            //appmsg += "Regards" + "," + "\n";
            //appmsg += "HR" + "\n";
            if (ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim() != "")
            {

                sendmail_Template1(ds.Tables[0].Rows[i]["official_email_id"].ToString().Trim(), ds.Tables[0].Rows[i]["emp_fname"].ToString().Trim(), lbl_emp_name.Text.Trim(), _userCode.Trim(), fromdt, todate, ds.Tables[0].Rows[i]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[i]["dlm_mail"].ToString().Trim());
            }
        }


    }

    public bool sendmail_Template1(string recievermailid, string approver, string employee, string empcode, string fromdt, string todate, string lm_mail, string dlm_mail)
    {

        try
        {


            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];

            string Template = EmailTemplate1(approver, employee, empcode, fromdt, todate);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Compoff Application";
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;

            //if (fileAttachment.HasFile)
            //{
            //    FileName = Path.GetFileName(fileAttachment.PostedFile.FileName);
            //    FileName = "attachments/" + FileName;
            //    fileAttachment.PostedFile.SaveAs(Server.MapPath(FileName));

            //    attachment = new System.Net.Mail.Attachment(Server.MapPath(FileName));
            //    mailMessage.Attachments.Add(attachment);

            //    IsAttachment = true;
            //}

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
    public string EmailTemplate1(string approver, string employee, string empcode, string fromdt, string todate)
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
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "Your comp off application has been submitted successfully to Virtual Head  " + appr + " from dated from " + Convert.ToDateTime(fromdt).ToString("dd-MMM-yyyy") + " - " + Convert.ToDateTime(todate).ToString("dd-MMM-yyyy") + "  for Approval / Reject.</p>" +

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
