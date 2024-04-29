using System.Data;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System;
using Common.Data;
using Common.Console;
using System.Configuration;
using System.Net.Mail;
public partial class admin_createtemplogin : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr, UserCode, CompanyId;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    #region Pageload
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            CompanyId = Session["companyid"].ToString();
            UserCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                if (Request.QueryString["password"] != null)
                    SmartHr.Common.Alert("No such employee exists");
                if (Request.QueryString["passwordreset"] != null)
                    SmartHr.Common.Alert("Reset Successfully");
                if (Session["role"] != null)
                {
                    //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    // Response.Redirect("~/Authenticate.aspx");
                }
                else
                    Response.Redirect("~/notlogged.aspx");

                if (!IsPostBack)
                {
                    Bind();
                }
            }
        }
        else
            Response.Redirect("~/notlogged.aspx");
    }
    #endregion

    #region Submit Click
    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (Save() > 0)
            {
                DataSet dsTempEmpCode = GetEmpCode();
                string tEmpCode = dsTempEmpCode.Tables[0].Rows[0]["empcode"].ToString();
                txtempcode.Text = tEmpCode.ToString();
                string pWord = "Reset@123";



                connection = activity.OpenConnection();
                string file_name = "";


                if (duplicate_emp_code() && duplicate_loginID())
                {
                    transaction = connection.BeginTransaction();
                    insert_Job_Details(connection, transaction);
                    insert_Personal_Details(connection, transaction);
                    insert_Log_in_detail(connection, transaction);
                    insert_candidate_gemail_sended_detail(connection, transaction);
                    transaction.Commit();

                    if (txtEmailId.Text.ToString() != "")
                    {

                       // sendmail_Template(txtEmailId.Text.ToString().Trim(), appmsg);

                        string senderId = ConfigurationManager.AppSettings["fromEmail"];  // Sender EmailID
                        string senderPassword = ConfigurationManager.AppSettings["pwd"]; // Sender Password      
                        System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                        string body =@"<html xmlns='http://www.w3.org/1999/xhtml'>" +
                    "<head runat='server'>" +
                    "<title></title>" +
                   "</head>" +
                    "<body>" +
                    "<form id='form1' runat='server'>" +
                    "<div>" +
                    "<table style='width: 90%;margin-left:20px' border='0' cellspacing='0' cellpadding='0'>" +
                    "<tr>" +
                   "<td><asp:Label ID='lblname' runat='server' style='font-family:Georgia;font-weight:600'>Dear " + txtEmployeeName.Text.ToString().Trim() + ",</asp:Label></td>" +
                   "</tr>" +
                    "<tr><td><br/></td></tr>" +
                   "<tr>" +
                  "<td>" +
                    "<asp:Label ID='lblmessage' runat='server'>Your Login Cerenditals are , Employee Code is <l style='font-style:Georgia'>" + tEmpCode + "</l> and Password is <l style='font-style:Georgia'>" + pWord + "</l>.</asp:Label>" +
                    "</td>" +
                    "</tr>" +
                    "<tr>" +
                    "<td>" +
                    "<asp:Label ID='lblmessage_1' runat='server'>Kindly use it and fill the details.</asp:Label>" +
                    "</td>" +
                    "</tr>" +
                    "<tr><td><br/></td></tr>" +
                    "<tr>" +
                    "<td>" +
                    "<asp:Label ID='lblmessage_1' runat='server'>Click Here - <a href='https://escalon.sdlapps.com'>https://escalon.sdlapps.com</a></asp:Label>" +
                    "</td>" +
                    "</tr>" +
                    "<tr><td><br/></td></tr>" +
                  "<tr>" +
                  "<td>" +
                  "<asp:Label ID='lblmessage_2' runat='server'></a></asp:Label>" +
                  "</td>" +
                  "</tr>" +
                    "<tr><td><br/></td></tr>" +
                    "<tr>" +
                    "<td>" +
                    "<b><asp:Label ID='lbl_regards' runat='server' style='font-family:Georgia;font-weight:600'>Regards,</asp:Label></b>" +
                    "</td>" +
                    "</tr>" +
                    "<tr><td><br/></td></tr>" +
                    "<tr>" +
                    "<td>" +
                    "<b><asp:Label ID='lblhr' runat='server' style='font-family:Georgia;font-weight:600'>HR</asp:Label></b>" +
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
                        try
                        {
                            mailMessage.To.Add(txtEmailId.Text.Trim());
                            mailMessage.From = new MailAddress(senderId);
                            mailMessage.Subject = "OnBoarding Status";
                            mailMessage.Body = body;
                            mailMessage.IsBodyHtml = true;
                            SmtpClient smtp = new SmtpClient();
                            smtp.Host = ConfigurationManager.AppSettings["smtp"];
                            smtp.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
                            smtp.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
                            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                            smtp.Send(mailMessage);

                         
                            
                        

                        }
                        catch (Exception ex)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Your Email address is not valid');", true);
                        }

                    }

                    Reset();
                    //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                    string str = "<script> alert('Created Successfully')</script>";
                    Page.RegisterStartupScript("Employee", str.ToString());
                    //TabContainer1.ActiveTabIndex = 0;
                    Bind();
                }

                else
                {
                    string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
                    Page.RegisterStartupScript("Employee", str.ToString());

                }
            }

        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    public int Save()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "sp_onboarding_savetemplogin";

        SqlParameter p = new SqlParameter();
        p.ParameterName = "@companyid";
        p.Value = CompanyId;
        p.DbType = DbType.Int32;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        int saltSize = 5;
        string salt = CreateSalt(saltSize);
        string passwordHash = CreatePasswordHash("Reset@123", salt);

        p = new SqlParameter();
        p.ParameterName = "@password";
        p.Value = passwordHash;
        p.DbType = DbType.String;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        p = new SqlParameter();
        p.ParameterName = "@empname";
        p.Value = txtEmployeeName.Text.Trim();
        p.DbType = DbType.String;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        p = new SqlParameter();
        p.ParameterName = "@emailid";
        p.Value = txtEmailId.Text.Trim();
        p.DbType = DbType.String;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        p = new SqlParameter();
        p.ParameterName = "@createdby";
        p.Value = UserCode;
        p.DbType = DbType.String;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        p = new SqlParameter();
        p.ParameterName = "@dob";

        if (String.IsNullOrEmpty(txtDOB.Text))
        {
            p.Value = DBNull.Value;
        }
        else
        {
            p.Value = Convert.ToDateTime(txtDOB.Text.Trim());
        }
        p.DbType = DbType.DateTime;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        return cmd.ExecuteNonQuery();
    }

    private void insert_Personal_Details(SqlConnection connection, SqlTransaction transaction)
    {
        sqlstr = @"insert into tbl_intranet_employee_jobDetails(empcode,status,emp_fname) values('" + txtempcode.Text.ToString() + "',0,'" + txtEmployeeName.Text.ToString() + "')";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
    }

    private void insert_Job_Details(SqlConnection connection, SqlTransaction transaction)
    {
        sqlstr = @"insert into tbl_intranet_employee_personalDetails(empcode,dob,email_id) values('" + txtempcode.Text.ToString() + "','" + txtDOB.Text.ToString() + "','" + txtEmailId.Text.ToString() + "')";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
    }
    #endregion

    #region Job Login Details
    protected void insert_Log_in_detail(SqlConnection connection, SqlTransaction transaction)
    {
        int saltSize = 5;
        string salt = CreateSalt(saltSize);
        string passwordHash = CreatePasswordHash("Reset@123", salt);

        SqlParameter[] sqlparam1 = new SqlParameter[4];

        sqlparam1[0] = new SqlParameter("@loginid", SqlDbType.VarChar, 50);
        sqlparam1[0].Value = txtempcode.Text.Trim().ToString();

        sqlparam1[1] = new SqlParameter("@pwd", SqlDbType.VarChar, 50);
        sqlparam1[1].Value = passwordHash.Trim().ToString();

        sqlparam1[2] = new SqlParameter("@role", SqlDbType.TinyInt);
        sqlparam1[2].Value = "16";

        sqlparam1[3] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam1[3].Value = txtempcode.Text.Trim().ToString();

        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_employee_login", sqlparam1);

    }
    private static string CreateSalt(int size)
    {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        byte[] buff = new byte[size];
        rng.GetBytes(buff);
        return Convert.ToBase64String(buff);
    }
    private static string CreatePasswordHash(string pwd, string salt)
    {
        string saltAndPwd = String.Concat(pwd, salt);
        string hashedPwd = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd, "SHA1");
        hashedPwd = String.Concat(hashedPwd, salt);
        return hashedPwd;
    }
    #endregion

    #region Validate Dupllicate Login & Empcode Function
    public Boolean duplicate_loginID()
    {
        int count;

        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@login_ID", txtempcode.Text.Trim());

        sqlstr = "select count(Login_ID) from tbl_login where Login_ID= @login_ID";
        count = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            // lbl_msg.Text = "Employee Loging ID allready existes Please change Login ID.";
            string sqlstr1 = @"update tbl_onboarding_templogin set submitstatus='E' where empcode='" + txtempcode.Text.ToString() + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1);
            string str = "<script> alert('Loging ID already exists in auto genrate ,Please click on Submit again.')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());
            return false;

        }
        else
        {
            return true;
        }
    }
    private DataSet GetEmpCode()
    {
        string empCode;
        DataSet dsempCode = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            empCode = @"select empcode from tbl_onboarding_templogin where id = (select top 1 id from tbl_onboarding_templogin order by id desc)";
            dsempCode = SQLServer.ExecuteDataset(connection, CommandType.Text, empCode);
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
        return dsempCode;
    }

    public Boolean duplicate_emp_code()
    {
        int count;

        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@emp_code", txtempcode.Text.Trim());

        sqlstr = "select count(empcode) from tbl_intranet_employee_jobDetails where empcode= @emp_code";
        count = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            //  lbl_msg.Text = "Employee Code allready existes Please change Emplyee Code.";
            string sqlstr1 = @"update tbl_onboarding_templogin set submitstatus='E' where empcode='" + txtempcode.Text.ToString() + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1);
            string str = "<script> alert('Employee Code already exists in auto genrate empcode,Please click on Submit again.')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion

    public bool sendmail_Template(string recievermailid, string bdy)
    {

        try
        {
            string senderId = "admin@sdlglobe.com"; // Sender EmailID
            string senderPassword = "Smart@123"; // Sender Password      
            string subject = "Temporary Login";
            string FileName = string.Empty;
            string body = bdy;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
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

    protected void grid_PreRender(object sender, EventArgs e)
    {
        if (grid.Rows.Count > 0)
        {
            grid.UseAccessibleHeader = true;
            grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    private void Bind()
    {
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = @"
select T.id,
T.empcode, 
case when T.submitstatus = 'P' then '<span class=''label label-important''>Pending</span>' else
case when T.submitstatus = 'S' then '<span class=''label label-warning''>Submitted by Employee</span>' else
case when T.submitstatus = 'A' then '<span class=''label label-success''>Approved</span>' end end end submitstatus,
J.emp_fname,P.email_id,convert(varchar(11), P.dob, 101) dob

 from tbl_onboarding_templogin T
 inner join tbl_intranet_employee_jobDetails J on T.empcode = J.empcode 
inner join tbl_intranet_employee_personalDetails P on P.empcode = J.empcode
 where T.createdby=@createdby and T.companyid = @companyid AND T.submitstatus !='R'";

        SqlParameter p = new SqlParameter();
        p.ParameterName = "@companyid";
        p.Value = CompanyId;
        p.DbType = DbType.Int32;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        p = new SqlParameter();
        p.ParameterName = "@createdby";
        p.Value = UserCode;
        p.DbType = DbType.String;
        p.Direction = ParameterDirection.Input;
        cmd.Parameters.Add(p);

        DataTable dt = new DataTable();
        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        sda.Fill(dt);

        grid.DataSource = dt;
        grid.DataBind();

    }

    protected void getcandidt_Click(object sender, EventArgs e)
    {
        connection = activity.OpenConnection();
        sqlstr = "select distinct cr.rrf_id,rrf.locationid,ci.candidateid,d.designationname,cr.candidate_name,cr.dob,cr.mobile,cr.emailid,cr.phone,cr.Qualification,cr.skills,cr.experience,cr.joinstatus,cr.expectedsalary,cr.rrf_id,ci.round_1_status,ci.round_1_marks,ci.round_2_status,rrf.rrf_code,ir.Candidate_id,ir.status from tbl_recruitment_candidate_registration cr inner join tbl_recruitment_requisition_form rrf on rrf.id=cr.rrf_id inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid inner join tbl_recruitment_interviewrrating ir on ci.candidateid=ir.Candidate_id inner join tbl_intranet_designation d on rrf.designationid=d.id where ir.status='S' and cr.id ='" + txtcandidatid.Text.ToString() + "'";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        txtEmployeeName.Text = ds.Tables[0].Rows[0]["candidate_name"].ToString();
        txtEmailId.Text = ds.Tables[0].Rows[0]["emailid"].ToString();
        if (ds.Tables[0].Rows[0]["dob"].ToString() != "")
        {
            txtDOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"].ToString()).ToString("dd-MMM-yyyy");
        }
    }

    protected void insert_candidate_gemail_sended_detail(SqlConnection connection, SqlTransaction transaction)
    {
        sqlstr = @"insert into tbl_onboarding_mail_Deails(candidate_id,candidate_name,candidate_dob,candidate_email,CreatedBy,Status) values('" + txtcandidatid.Text.ToString() + "','" + txtEmployeeName.Text.ToString() + "','" + txtDOB.Text.ToString() + "','" + txtEmailId.Text.ToString() + "','" + UserCode.ToString() + "',1)";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

    }

    protected void Reset()
    {
        txtempcode.Text = "";
        txtpwd.Text = "";
        txtcandidatid.Text = "";
        txtEmployeeName.Text = "";
        txtEmailId.Text = "";
        txtDOB.Text = "";
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    //protected void btndelete_Click(object sender, EventArgs e)
    //{
    //    sqlstr = @" update  tbl_onboarding_mail_Deails set";
    //    SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
    //}
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            var dataKey = grid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var a = (int)dataKey.Value;
                string query = "update tbl_onboarding_templogin set submitstatus='R' WHERE id=" + a + "";
                Common.Data.SQLServer.ExecuteNonQuery(connection, CommandType.Text, query);
            }

            Bind();
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
            string str = "<script> alert('Deleted Successfully')</script>";
        }
    }
}
