using System;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using Smart.HR.Common.Mail.Module;
using System.Net.Mail;
using System.Configuration;

public partial class Reimbursement_AddReimbursementDetails : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    string Usercode; decimal total = 0;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity DataActivity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            Usercode = Session["empcode"].ToString();
            //  CompareValidator1.ValueToCompare = DateTime.Now.ToString("MM/dd/yyyy");
            if (!IsPostBack)
            {
                if (Session["Reimbursement"] != null)
                    Session.Remove("Reimbursement");
                //Session["type"] = ddlcategory.SelectedValue.ToString();
                ddlpayhead.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }
        else
        {
            Response.Redirect("~/Default.aspx");
        }
    }

    //private void BindApprovers()
    //{
    //    SqlParameter[] parm = new SqlParameter[2];
    //    SqlConnection Connection = null;
    //    try
    //    {
    //        Output.AssignParameter(parm, 0, "@empcode", "String", 50, Usercode);
    //        Output.AssignParameter(parm, 1, "@type", "Int", 0, ddlcategory.SelectedValue);
    //        Connection = DataActivity.OpenConnection();
    //        ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_getemp_Approvers", parm);

    //        if (ddlcategory.SelectedValue.ToString() == "1")
    //        {
    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows[0]["empcode"].ToString() == "")
    //                {
    //                    Output.Show("Please Assign Line Manager in EDB");
    //                    btnsubmit.Enabled = false;
    //                }

    //                else if (ds.Tables[0].Rows[1]["empcode"].ToString() == "")
    //                {
    //                    Output.Show("Please Assign Finance Manager in EDB");
    //                    btnsubmit.Enabled = false;
    //                }
    //                else
    //                {
    //                    grdapprovers.DataSource = ds;
    //                    grdapprovers.DataBind();
    //                    btnsubmit.Enabled = true;

    //                }
    //            }
    //            else
    //            {
    //                Output.Show("No Approvers. please Assign Approvers in EBD");
    //                btnsubmit.Enabled = false;
    //            }
    //        }
    //        else
    //        {

    //            if (ds.Tables[0].Rows.Count > 0)
    //            {
    //                if (ds.Tables[0].Rows[0]["empcode"].ToString() == "")
    //                {
    //                    Output.Show("Please Assign HR-C&B in EDB");
    //                    btnsubmit.Enabled = false;
    //                }
    //                else if (ds.Tables[0].Rows[1]["empcode"].ToString() == "")
    //                {
    //                    Output.Show("Please Assign Finance Manager in EDB");
    //                    btnsubmit.Enabled = false;
    //                }
    //                else
    //                {
    //                    grdapprovers.DataSource = ds;
    //                    grdapprovers.DataBind();
    //                    btnsubmit.Enabled = true;

    //                }
    //            }
    //            else
    //            {
    //                Output.Show("No Approvers. please Assign Approvers in EBD");
    //                btnsubmit.Enabled = false;
    //            }
    //        }

    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //    finally
    //    {
    //        DataActivity.CloseConnection();
    //    }
    //}

    private void BindApprovers()
    {
        SqlParameter[] parm = new SqlParameter[2];
        SqlConnection Connection = null;
        try
        {
            Output.AssignParameter(parm, 0, "@empcode", "String", 50, Usercode);
            Output.AssignParameter(parm, 1, "@type", "Int", 0, ddlcategory.SelectedValue);
            Connection = DataActivity.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_Rb_getemp_Approvers", parm);

                        grdapprovers.DataSource = ds;
                        grdapprovers.DataBind();
                        btnsubmit.Enabled = true;


        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    private void BindGrid()
    {
        DataSet ds = new DataSet();
        string str = "select * from tbl_Rb_PayHead where status=1 and Type=" + ddlcategory.SelectedValue + "";
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            ddlpayhead.DataValueField = "PID";
            ddlpayhead.DataTextField = "Name";
            ddlpayhead.DataSource = ds;
            ddlpayhead.DataBind();
            ddlpayhead.Items.Insert(0, new ListItem("--Select--", "0"));

        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (txtdate.Text != "")
        {
            if (Convert.ToDateTime(txtdate.Text) > DateTime.Now)
            {
                Output.Show("Please Enter the Valid Date");
                return;
            }
        }
        if (IsAttchament() == true)
        {
            DataRow dr;
            if (Session["Reimbursement"] == null)
            {
                create_Reimbursement_table();
            }
            dtable = (DataTable)Session["Reimbursement"];

            DataRow drfind = dtable.Rows.Find(ddlpayhead.SelectedValue);
            if (drfind != null)
            {
                dr = dtable.NewRow();
                dr["Cid"] = ddlpayhead.SelectedValue;
                dr["CompName"] = ddlpayhead.SelectedItem.ToString();
                dr["Date"] = txtdate.Text;
                dr["Units"] = txtunits.Text;
                dr["Ammount"] = txtammount.Text;
                string defaultUpload1 = "";
                if (fpattachment.HasFile)
                {
                    string strFileName;
                    string file_name = ddlpayhead.SelectedItem + System.DateTime.Now.GetHashCode().ToString();
                    strFileName = fpattachment.FileName;
                    try
                    {
                        fpattachment.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                        defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                        dr["Attachment"] = defaultUpload1;
                    }
                    catch (Exception exc)
                    {
                    }
                }
                else
                {
                    defaultUpload1 = "";
                    dr["Attachment"] = defaultUpload1;
                }
                dr["Comments"] = txt_comments.Text;

                dtable.Rows.Add(dr);
            }
            else
            {
                dr = dtable.NewRow();
                dr["Cid"] = ddlpayhead.SelectedValue;
                dr["CompName"] = ddlpayhead.SelectedItem.ToString();
                dr["Date"] = txtdate.Text;
                dr["Units"] = txtunits.Text;
                dr["Ammount"] = txtammount.Text;
                string defaultUpload1 = "";
                if (fpattachment.HasFile)
                {
                    string strFileName;
                    string file_name = ddlpayhead.SelectedItem + System.DateTime.Now.GetHashCode().ToString();
                    strFileName = fpattachment.FileName;
                    try
                    {
                        fpattachment.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                        defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                        dr["Attachment"] = defaultUpload1;
                    }
                    catch (Exception exc)
                    {
                    }
                }
                else
                {
                    defaultUpload1 = "nofile.html";
                    dr["Attachment"] = defaultUpload1;
                }
                dr["Comments"] = txt_comments.Text;

                dtable.Rows.Add(dr);
            }
            Session["Reimbursement"] = dtable;
            BindReimbursement();
            gridreim.Visible = true;
            claerdata();
            hdvalue.Value = "";
        }
        else
        {
            Output.Show("Please Upload Attachment.");
        }
    }

    private bool IsAttchament()
    {
        if (hdvalue.Value == "1")
        {
            if (fpattachment.HasFile)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    private void claerdata()
    {
        txtammount.Text = "";
        txtunits.Text = "";
        ddlpayhead.SelectedValue = "0";
        hdvalue.Value = "";
        lblmanadatory.Text = "";
        txt_comments.Text = "";
    }

    private void BindReimbursement()
    {

        if (Session["Reimbursement"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Reimbursement"];
            dview = new DataView(dtable);
        }
        grd.DataSource = dview;
        grd.DataBind();
    }

    private void create_Reimbursement_table()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("Cid", typeof(Int32));
        dtable.Columns.Add("CompName", typeof(string));
        dtable.Columns.Add("Date", typeof(string));
        dtable.Columns.Add("Units", typeof(string));
        dtable.Columns.Add("Ammount", typeof(string));
        dtable.Columns.Add("Attachment", typeof(string));
        dtable.Columns.Add("Comments", typeof(string));
        Session["Reimbursement"] = dtable;
    }

    protected void grd_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Reimbursement"];
        DataRow drfind_Training = dtable.Rows.Find(Convert.ToString(grd.DataKeys[e.RowIndex].Value));
        if (drfind_Training != null)
        {
            drfind_Training.Delete();
            Session["Reimbursement"] = dtable;
            BindReimbursement();
        }
    }

    protected void grd_PreRender(object sender, EventArgs e)
    {
        if (grd.Rows.Count > 0)
        {
            grd.UseAccessibleHeader = true;
            grd.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnsubmit_Click(object sender, System.EventArgs e)
    {
        SqlParameter[] parm = new SqlParameter[4];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0, Flag1 = 0;
        Label lblammount = grd.FooterRow.FindControl("lblammount") as Label;
        try
        {
            Output.AssignParameter(parm, 0, "@empcode", "String", 50, Usercode);
            Output.AssignParameter(parm, 1, "@type", "Int", 0, ddlcategory.SelectedValue);
            Output.AssignParameter(parm, 2, "@ammount", "Decimal", 0, lblammount.Text);
            parm[3] = new SqlParameter("@rid", SqlDbType.Int);
            parm[3].Value = 0;
            parm[3].Direction = ParameterDirection.Output;
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_Insert_reimbursement", parm);
            int refid = Convert.ToInt32(parm[3].Value);


            if (refid != null)
            {
                foreach (GridViewRow row in grd.Rows)
                {

                    Label cid = (Label)row.FindControl("lbcid");
                    Label date = (Label)row.FindControl("lbldate");
                    Label units = (Label)row.FindControl("lblUnits");
                    Label ammount = (Label)row.FindControl("lblammt");
                    Label attcahment = (Label)row.FindControl("lblAttachment");
                    Label comments = (Label)row.FindControl("lblcomments");

                    SqlParameter[] parm1 = new SqlParameter[8];
                    Output.AssignParameter(parm1, 0, "@rid", "Int", 0, refid.ToString());
                    Output.AssignParameter(parm1, 1, "@cid", "Int", 0, cid.Text);
                    Output.AssignParameter(parm1, 2, "@date", "String", 50, date.Text);
                    Output.AssignParameter(parm1, 3, "@units", "String", 50, units.Text);
                    Output.AssignParameter(parm1, 4, "@ammount", "Decimal", 0, ammount.Text);
                    Output.AssignParameter(parm1, 5, "@attachments", "String", 50, attcahment.Text);
                    Output.AssignParameter(parm1, 6, "@createdby", "String", 50, Usercode);
                    Output.AssignParameter(parm1, 7, "@comments", "String", 2000, comments.Text);
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_Insert_reimbursement_Details", parm1);

                }
            }


            if (refid != null)
            {
                foreach (GridViewRow row in grdapprovers.Rows)
                {

                    Label approvercode = (Label)row.FindControl("lblempcode");
                    Label level = (Label)row.FindControl("lbllevels");
                    if (approvercode.Text != null || approvercode.Text != "")
                    {
                        SqlParameter[] parm2 = new SqlParameter[5];
                        Output.AssignParameter(parm2, 0, "@rid", "Int", 0, refid.ToString());
                        Output.AssignParameter(parm2, 1, "@approvercode", "String", 50, approvercode.Text);
                        Output.AssignParameter(parm2, 2, "@level", "Int", 0, level.Text);
                        Output.AssignParameter(parm2, 3, "@employeecode", "String", 50, Usercode);
                        Output.AssignParameter(parm2, 4, "@createdby", "String", 50, Usercode);

                        Flag1 = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_Rb_CreateApprovers", parm2);
                    }
                }
            }

            _Transaction.Commit();

            SqlConnection connection = new SqlConnection();

            DataSet dsAppvrEmails = GetAppvrsEmail(connection);
            if (dsAppvrEmails.Tables[0].Rows.Count < 1)
            {
                Common.Console.Output.Show("Approver has not been assigned. !!!");
                return;
            }
            sendmail(dsAppvrEmails);

           // SendEmail(refid);
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
            Output.Show("Submitted Successfully");
            Clear();

        }
    }

    private DataSet GetAppvrsEmail(SqlConnection conn)
    {

        string strAllemail;
        DataSet dsAllemail = new DataSet();
        DataSet ds3 = new DataSet();
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        //transaction = connection.BeginTransaction();
        Label empcode = (Label)grdapprovers.Rows[0].FindControl("lblempcode");
        try
        {
            strAllemail = @"SELECT emp_fname+ ' ' + isnull(emp_m_name,'') + ' ' + isnull(emp_l_name,'') as name,empcode, 
official_email_id FROM dbo.tbl_intranet_employee_jobDetails where empcode = '" + empcode.Text.Trim() + "' select emp_fname,official_email_id from tbl_intranet_employee_jobDetails where empcode='"+Usercode+"'";
            dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
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

    public void sendmail(DataSet ds)
    {
        string email = ds.Tables[0].Rows[0]["official_email_id"].ToString().Trim();
        //DataSet daEmpName = (DataSet)ViewState["employeeName"];
        string empName = ds.Tables[1].Rows[0]["emp_fname"].ToString().Trim();
        string appvrName = ds.Tables[0].Rows[0]["name"].ToString().Trim();
        if (email != "")
        {
            sendmail_Template(email, appvrName, empName);
        }
    }

    public bool sendmail_Template(string recievermailid, string approver, string employee)
    {
        try
        {
            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];      

            string Template = EmailTemplate(approver, employee, Usercode);
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = "Reimbursement Request";
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
    "<title>Resignation Request</title>" +
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
                                                            "<p><b>Dear " + appr + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + "You have a Reimbursement Request from  " + emp + " - " + empcod + " for Approval / Reject.</p>" +

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

    void SendEmail(int reimbursementId)
    {
        if (ddlcategory.SelectedValue == "1")
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Reimbursement.CreatingBusinessReimbursementEmp();
            EmailClient client = new EmailClient(email);
            Reimbursement appovers = new Reimbursement();
            DataRow row = appovers.GetEmployeeInfo(reimbursementId);

            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["Empcode"].ToString();
            client.employeeName = row["emp_fname"].ToString().Trim();
            client.fromDate = reimbursementId.ToString();
            client.Send();

            email = new Smart.HR.Common.Mail.Module.Reimbursement.CreatingBusinessReimbursementLM();
            client = new EmailClient(email);
            appovers = new Reimbursement();

            row = appovers.GetApprovers(reimbursementId, 1);
            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["Approvercode"].ToString();
            client.employeeName = row["emp_fname"].ToString().Trim();
            row = appovers.GetEmployeeInfo(reimbursementId);
            client.requestNumber = row["emp_fname"].ToString() + " (" + row["empcode"].ToString() + ") ";
            client.fromDate = reimbursementId.ToString();
            client.Send();

            email = new Smart.HR.Common.Mail.Module.Reimbursement.CreatingBusinessReimbursementFIN();
            client = new EmailClient(email);
            appovers = new Reimbursement();
            row = appovers.GetApprovers(reimbursementId, 2);
            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["Approvercode"].ToString();
            client.employeeName = row["emp_fname"].ToString().Trim();
            row = appovers.GetEmployeeInfo(reimbursementId);
            client.requestNumber = row["emp_fname"].ToString() + " (" + row["empcode"].ToString() + ") ";
            client.fromDate = reimbursementId.ToString();
            client.Send();


        }
        else if (ddlcategory.SelectedValue == "2")
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Reimbursement.CreatingMiscReimbursementEmp();
            EmailClient client = new EmailClient(email);
            Reimbursement appovers = new Reimbursement();
            DataRow row = appovers.GetEmployeeInfo(reimbursementId);

            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["Empcode"].ToString();
            client.employeeName = row["emp_fname"].ToString().Trim();
            client.fromDate = reimbursementId.ToString();
            client.Send();

            email = new Smart.HR.Common.Mail.Module.Reimbursement.CreatingMiscReimbursementHRCB();
            client = new EmailClient(email);
            appovers = new Reimbursement();

            row = appovers.GetApprovers(reimbursementId, 1);
            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["Approvercode"].ToString();
            client.employeeName = row["emp_fname"].ToString().Trim();
            row = appovers.GetEmployeeInfo(reimbursementId);
            client.requestNumber = row["emp_fname"].ToString() + " (" + row["empcode"].ToString() + ") ";
            client.fromDate = reimbursementId.ToString();
            client.Send();

            email = new Smart.HR.Common.Mail.Module.Reimbursement.CreatingMiscReimbursementFIN();
            client = new EmailClient(email);
            appovers = new Reimbursement();
            row = appovers.GetApprovers(reimbursementId, 2);
            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["Approvercode"].ToString();
            client.employeeName = row["emp_fname"].ToString().Trim();
            row = appovers.GetEmployeeInfo(reimbursementId);
            client.requestNumber = row["emp_fname"].ToString() + " (" + row["empcode"].ToString() + ") ";
            client.fromDate = reimbursementId.ToString();
            client.Send();
        }

        

    }

    private void Clear()
    {
        ddlcategory.Enabled = true;
        txtdate.Text = "";
        txtunits.Text = "";
        ddlpayhead.SelectedValue = "0";
        txtammount.Text = "";
        fpattachment = null;
        Session.Remove("Reimbursement");
        BindReimbursement();
    }

    protected void grdapprovers_PreRender(object sender, System.EventArgs e)
    {
        if (grdapprovers.Rows.Count > 0)
        {
            //grdapprovers.UseAccessibleHeader = true;
            grdapprovers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
        BindApprovers();
        ddlcategory.Enabled = false;
    }

    protected void grd_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblAttachment = (Label)e.Row.FindControl("lblAttachment");
        //    Label aViewFile = (Label)e.Row.FindControl("aViewFile");

        //    if (lblAttachment.Text.Trim() == "nofile.html")
        //    {
        //        lblAttachment.Text = "No File";
        //        lblAttachment.Visible = false;
        //    }
        //    else
        //        aViewFile.Text = "View File";
        //    lblAttachment.Visible = true;

        //    total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ammount"));
        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    Label lblammount = (Label)e.Row.FindControl("lblammount");
        //    lblammount.Text = total.ToString();
        //    lblammount.Font.Bold = true;
        //}
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblAttachment = (Label)e.Row.FindControl("lblAttachment");
            Label aViewFile = (Label)e.Row.FindControl("aViewFile");

            if (lblAttachment.Text.Trim() == "nofile.html")
            {
                lblAttachment.Text = "No File";
                lblAttachment.Visible = false;
            }
            else
                aViewFile.Text = "View File";
            lblAttachment.Visible = false;
            //if (lblAttachment.Text.Trim() == "nofile.html")
            //{
            //    aViewFile.Text = "No File";
            //    aViewFile.Visible = false;
            //}
            //else
            //    lblAttachment.Text = "View File";
            //lblAttachment.Visible = false;


            total += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Ammount"));
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lblammount = (Label)e.Row.FindControl("lblammount");
            lblammount.Text = total.ToString();
            lblammount.Font.Bold = true;
        }





    }

    protected void ddlpayhead_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string str = "select IsAttach from tbl_Rb_PayHead where status=1 and PID=" + ddlpayhead.SelectedValue + "";
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            if (ds.Tables[0].Rows[0]["IsAttach"].ToString() == "1")
            {
                lblmanadatory.Text = "Attachment Manadatory";
                lblmanadatory.ForeColor = System.Drawing.Color.Red;
                hdvalue.Value = "1";
            }
            else
            {
                lblmanadatory.Text = "";
                hdvalue.Value = "";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            DataActivity.CloseConnection();
        }

    }

    protected void btnreset_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddReimbursementDetails.aspx");

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddReimbursementDetails.aspx?");
    }

}