using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using DataAccessLayer;
using querystring;
using System.Security.Cryptography;
using Common.Console;
using Common.Data;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string strsql, Str_1;
    DataActivity activity = new DataActivity();
    SqlConnection _Connection = new SqlConnection();
    static string activationcode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (txtUserName.Text == "")
            {
                txtUserName.Focus();
            }
            if (Request.QueryString["logout"] != null)
            {

                if (Request.QueryString["logout"].ToString() == "true")
                {
                    string msg = "Sucessfully logout at: " + DateTime.Now;
                    Session.RemoveAll();
                    message(msg);
                    //bindCEOMessage();
                    //bindNewsRoom();
                    //bindEvents();
                    //bindAnnouncements();
                    //bindAchievements();
                    //bindmissionandvission();
                }
                else
                {
                    message("logout not sucessfully. please login and logout.");
                    Session.RemoveAll();
                }
            }

            if (Request.QueryString["failed_emp"] != null)
            {
                Output.Show("Mail Id is not register with HRMS");
            }

            if (Request.QueryString["failed_emp2"] != null)
            {
                Output.Show("This mail id is register with more than one employees in HRMS");
            }

            if (Request.QueryString["emailid"] != null)
            {
                //Output.Show("Mail Id is not register with HRMS");
                div_verify_OTP.Visible = true;
                div_OTP.Visible = false; ;
                div_1.Visible = false;
            }

            if (Session["logoupload"] != null)
            {
                Output.Show("Logo Uploaded Successfully");
            }

            Session.Remove("logoupload");
            Session.Remove("UploadedLogo");
            Session.RemoveAll();
            bindLogo();
            bindemailid();
        }
    }

    protected void bindLogo()
    {
        string query = @"select jd.empcode,ul.Logo,ul.createdby,ul.createddate
from tbl_intranet_uploadedLogo ul
INNER JOIN tbl_intranet_employee_jobDetails jd ON jd.empcode=ul.createdby
order by ul.createddate desc";
        DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            string logo = ds_1.Tables[0].Rows[0]["Logo"].ToString();
            if (File.Exists(Server.MapPath("Upload/logo/" + logo + "")))
            {
                Str_1 += "<img src='upload/logo/" + logo + "' class='avatar' style='width:180px;height:55px;' />";
            }
            else
            {
                Str_1 += "<img src='images/sdl_logo_new.png' class='avatar' style='width:220px;height:58px;' />";
            }
        }
        else
        {
            Str_1 += "<img src='images/sdl_logo_new.png' class='avatar' style='width:220px;height:58px;' />";
        }
        ViewState["Logo"] = Str_1;
    }

    protected void bindemailid()
    {
        string query = @"select email from tbl_EmailVerfiyDetails";
        DataSet ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            ViewState["emailid"] = ds_2.Tables[0].Rows[0]["email"].ToString();
        }
    }

    protected void bindCEOMessage()
    {
        string str = "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "CEODESK_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {
            //string str = "";
            str = str + " <div class='ceo_desk_content'>";
            str = str + "<img src='upload/photo/" + ds.Tables[0].Rows[0]["photo"].ToString() + "'/>";
            str = str + "<p>";
            str = str + ds.Tables[0].Rows[0]["message"].ToString();
            str = str + "</p>";
            str = str + "<a href='ceomessageviewmore.aspx'>Read more...</a>";
            str = str + "</div>";

        }
        Session["ceodesk"] = str;
    }

    //-----------------------------Binding NEWS ROOM---------------------------------------------------
    protected void bindNewsRoom()
    {
        string str = "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "NEWSROOM_SP");
        str = str + "<ul style='border-top: 1px solid #1f76c3; margin-top: -10px; padding-top: 10px;text-decoration: none;color: #222;'>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            str = str + " <li>";
            str = str + " <a href='newsroom.aspx?detail=" + ds.Tables[0].Rows[0]["id"].ToString() + "' style='text-decoration: none;color: #222;font-size:14px ' target='_blank'>";
            str = str + ds.Tables[0].Rows[0]["heading"].ToString();
            str += "<small class='achiv_date' style='float:right'>";
            str = str + ds.Tables[0].Rows[0]["posteddate"].ToString();
            str = str + "</small>";
            str = str + "</a>";
            str = str + " </li>";
            //rptnews.DataSource = ds;
            //rptnews.DataBind();
        }

        str = str + "</ul>";
        Session["newsroom"] = str;
    }

    //-----------------------Binding EVENTS-----------------------------------------------------------
    protected void bindEvents()
    {
        string str = "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "COMPANY_EVENTS_SP");
        str = str + "<ul style='border-top: 1px solid #1f76c3; margin-top: -10px; padding-top: 10px;text-decoration: none;color: #222;'>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            str = str + " <li>";
            str = str + " <a href='companyevents.aspx?detail=" + ds.Tables[0].Rows[0]["id"].ToString() + "' style='text-decoration: none;font-size:14px ;color: #222; ' target='_blank'>";
            str = str + ds.Tables[0].Rows[0]["heading"].ToString();
            str += "<small class='achiv_date' style='float:right'>";
            str = str + ds.Tables[0].Rows[0]["posteddate"].ToString();
            str = str + "</small>";
            str = str + "</a>";
            str = str + " </li>";
            // rptevents.DataSource = ds;
            //  rptevents.DataBind();
        }

        str = str + "</ul>";
        Session["events"] = str;
    }

    //------------------------Binding ANNOUNCEMENT--------------------------------------------------
    protected void bindAnnouncements()
    {

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "ANNOUNCEMENTS_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {

            //  rptannouncements.DataSource = ds;
            // rptannouncements.DataBind();
        }
    }

    //----------------------Binding ACHIEVEMENTS----------------------------------------------------
    protected void bindAchievements()
    {
        string str = "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "ACHIEVEMENTS_SP");
        if (ds.Tables[0].Rows.Count > 0)
        {

            str += " <div class='achiv_content'>";
            str += "<p>";

            str += ds.Tables[0].Rows[0]["heading"].ToString();
            str += "<small class='achiv_date' style='float:right'>";
            str += ds.Tables[0].Rows[0]["posteddate"].ToString();
            str += "</small>";

            str += "<a href='achievementsview.aspx' style='float:right;clear:both;color: #222;'>View all</a>";
            str += "</p>";
            str += "</div>";
            // rptachievements.DataSource = ds;
            // rptachievements.DataBind();
        }
        Session["Achivements"] = str;
    }

    //----------------------Binding VISION AND MISSION--------------------------------------------------------------

    protected void bindmissionandvission()
    {
        string str = "";
        string sqlstr = "select * from dbo.tbl_intranet_mission_vission";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {

            str += " <div class='achiv_content'>";
            str += "<p>";
            str += ds.Tables[0].Rows[0]["heading"].ToString();
            str += "<small class='achiv_date' style='float:right'>";
            str += ds.Tables[0].Rows[0]["uploadeddate"].ToString();
            str += "</small>";

            str += "</p>";

            str += "</div>";
            // rptachievements.DataSource = ds;
            // rptachievements.DataBind();
        }
        Session["missionandvision"] = str;


    }

    private void message(string message1)
    {

        // System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + message1 + "')</SCRIPT>");
        // ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert(" + message + ")", true);

        //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
        //       "err_msg",
        //       "alert( "+ message +"  )",
        //       true);
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

    private bool IsAuthenticated(string suppliedUserName, string suppliedPassword)
    {
        bool passwordMatch = false;
        SqlParameter[] newparameter = new SqlParameter[1];
        newparameter[0] = new SqlParameter("@employeeID", SqlDbType.VarChar, 50);
        newparameter[0].Value = suppliedUserName.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "LookupUser", newparameter);
        if (ds.Tables[0].Rows.Count > 0)
        {
            string dbPasswordHash = ds.Tables[0].Rows[0]["pwd"].ToString();
            Session["empcode"] = ds.Tables[0].Rows[0]["empcode"].ToString();
            Session["name"] = ds.Tables[0].Rows[0]["name"].ToString();
            Session["login"] = ds.Tables[0].Rows[0]["login_id"].ToString();
            Session["role"] = ds.Tables[0].Rows[0]["role"].ToString();
            Session["rolename"] = ds.Tables[0].Rows[0]["rolename"].ToString();
            Session["EmployeeRoleName"] = ds.Tables[0].Rows[0]["AdminRoleName"].ToString();
            Session["status"] = ds.Tables[0].Rows[0]["status"].ToString();
            if (ds.Tables[0].Rows[0]["Photo"].ToString() != "")
            {
                Session["photo"] = ds.Tables[0].Rows[0]["Photo"].ToString();
            }
            else
            {
                Session["photo"] = null;
            }
            Session["branch"] = ds.Tables[0].Rows[0]["branch_id"].ToString();
            Session["AdminSection"] = SmartHr.Common.AdminSection(Session["role"].ToString());
            Session["OfficialEmailId"] = ds.Tables[0].Rows[0]["official_email_id"].ToString();
            //Session["UploadedLogo"] = ds.Tables[0].Rows[0]["Logo"].ToString();

            string a = Session["AdminSection"].ToString();
            Session["companyid"] = "2";

            if (ds.Tables[0].Rows[0]["gender"].ToString() == "Male" || ds.Tables[0].Rows[0]["gender"].ToString() == "MALE")
            {
                Session["gender"] = "M";
            }
            else if (ds.Tables[0].Rows[0]["gender"].ToString() == "Female" || ds.Tables[0].Rows[0]["gender"].ToString() == "FEMALE")
            {
                Session["gender"] = "F";
            }


            Session["doa"] = ds.Tables[0].Rows[0]["doa"].ToString();
            Session["email"] = ds.Tables[0].Rows[0]["official_email_id"].ToString();
            int saltSize = 8;
            string salt = dbPasswordHash.Substring(dbPasswordHash.Length - saltSize);//F61AB0B38AAC99B085E8695D951FE00C1E13C96DB
            string hashedPasswordAndSalt = CreatePasswordHash(suppliedPassword, salt);//39CEBFAD161E838026B367A33659E709A3BC8B6B
            passwordMatch = hashedPasswordAndSalt.Equals(dbPasswordHash);
            return passwordMatch;
        }
        else
            return false;

    }
    //=========================CLICKING ON SUBMIT BUTTON=================================================

    protected void btn_logon_Click(object sender, EventArgs e)
    {
        if (IsAuthenticated(txtUserName.Text, txtPassword.Text) == true)
        {
            string query = @"select jd.empcode,ul.Logo,ul.createdby,ul.createddate
from tbl_intranet_uploadedLogo ul
INNER JOIN tbl_intranet_employee_jobDetails jd ON jd.empcode=ul.createdby
order by ul.createddate desc";
            DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
            if (ds_1.Tables[0].Rows.Count > 0)
            {
                Session["UploadedLogo"] = ds_1.Tables[0].Rows[0]["Logo"].ToString();
            }
            int flag = 1;
            //if (!IsPasswordExpired(txtUserName.Value, txtPassword.Value))
            //    return;
            flag = IsFirstLogin(txtUserName.Text, txtPassword.Text);

            if (flag == 2)
                if (Session["role"].ToString() != "16")
                    Response.Redirect("resetdefaultpassword.aspx");
                else
                {
                    login();
                    EmpHistory();
                    Response.Redirect("Home.aspx");
                }
            else if (flag == 1)
            {
                login();
                EmpHistory();
                Response.Redirect("Home.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "xx", "<script> alert('Login time is not Recorded please login once.')</script>", false);
                //lbl_message.Text = "Login time is not Recorded please login once.";
                // Response.Write(@"<script language='javascript'>alert('Login time is not Recorded please login once.');</script>");
            }

        }
        else
        {
            //lbl_message.Text = "Please Enter Correct Login Credentials";
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "xx", "<script> alert('Please Enter Correct Login Credentials.')</script>", false);

            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Please Enter Correct Login Credentials');", true);

            ClientScriptManager cs = Page.ClientScript;
            cs.RegisterStartupScript(this.GetType(), "showalert", "alert('Please Enter Correct Login Credentials')", true);


            //  Response.Write(@"<script language='javascript'>alert('Please Enter Correct Login Credentials');</script>");
        }

    }

    protected void EmpHistory()
    {
        try
        {
            string st = "Select Id From EmpHistory where empcode='" + txtUserName.Text.ToString() + "'";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, st);
            if (ds.Tables[0].Rows.Count <= 0)
            {
                string strq = @"SELECT dbo.tbl_login.role, dbo.tbl_intranet_employee_jobDetails.dept_id,
                                dbo.tbl_intranet_employee_jobDetails.degination_id,dbo.tbl_employee_approvers.app_reportingmanager
                        FROM    dbo.tbl_login INNER JOIN dbo.tbl_intranet_employee_jobDetails ON dbo.tbl_login.empcode = dbo.tbl_intranet_employee_jobDetails.empcode LEFT OUTER JOIN
                                dbo.tbl_employee_approvers ON dbo.tbl_login.empcode = dbo.tbl_employee_approvers.empcode
                        WHERE   (dbo.tbl_login.empcode = '" + txtUserName.Text.ToString() + "')";
                DataSet ds2 = SQLServer.ExecuteDataset(_Connection, CommandType.Text, strq);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    string _desigId = ds2.Tables[0].Rows[0]["degination_id"].ToString();
                    string _DeptId = ds2.Tables[0].Rows[0]["dept_id"].ToString();
                    string _RoleId = ds2.Tables[0].Rows[0]["role"].ToString();
                    string _UpdtBy = ds2.Tables[0].Rows[0]["app_reportingmanager"].ToString();

                    string st1 = "insert into EmpHistory(EmpCode,DesignationId,DepartmentId,EmpRole,UpdatedBy,DateAdded,status)values('" + txtUserName.Text.Trim() + "','" + _desigId.Trim().ToString() + "','" + _DeptId.Trim().ToString() + "','" + _RoleId.Trim().ToString() + "','" + _UpdtBy.Trim().ToString() + "','" + System.DateTime.Today.ToShortDateString() + "',0)";
                    int x = SQLServer.ExecuteNonQuery(_Connection, CommandType.Text, st1);
                }
            }
        }
        catch (Exception)
        {

        }
    }

    private int IsFirstLogin(string empcode, string pwd)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection connection = new SqlConnection();
        try
        {
            connection = Activity.OpenConnection();
            string sqlstr = @"select count(*) as passwordcount from tbl_login_history where empcode='" + empcode + "'";
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["passwordcount"].ToString()) <= 0)
                {
                    return 2;
                }
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {
            Activity.CloseConnection();
        }
        return 1;
    }

    private bool IsPasswordExpired(string username, string password)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection connection = new SqlConnection();
        try
        {
            connection = Activity.OpenConnection();
            string sqlstr = @"SELECT DATEDIFF(day,lastlogin,GETDATE()) AS days from tbl_login where empcode='" + username + "'";
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["days"].ToString()) >= Convert.ToInt32(ConfigurationManager.AppSettings["PasswordExpiryDays"].ToString()))
                {
                    Common.Console.Output.Show("Your Password has been expired.Please contact system Admin.");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {
            Activity.CloseConnection();
        }
        return true;
    }

    protected void Button1_Click2(object sender, EventArgs e)
    {
        int count;
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@name", SqlDbType.VarChar, 100);
        arrParam[0].Value = txtUserName.Text.Trim();

        strsql = @" SELECT coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name,tbl_intranet_employee_personalDetails.empcode,tbl_intranet_employee_personalDetails.email_id from tbl_intranet_employee_personalDetails INNER JOIN tbl_intranet_employee_jobDetails on tbl_intranet_employee_personalDetails.empcode=tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_personalDetails.empcode='" + txtUserName.Text + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["email_id"].ToString().Trim() == "")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "xx", "<script> alert('There is no email id in your personal detail. Please contact to your administrator')</script>", false);
            }
            else
            {
                Mail(ds.Tables[0].Rows[0]["empcode"].ToString(), ds.Tables[0].Rows[0]["email_id"].ToString(), ds.Tables[0].Rows[0]["name"].ToString());

                ScriptManager.RegisterStartupScript(this, this.GetType(), "xx", "<script> alert('A password reset link has sended to your email id')</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "xx", "<script> alert('User does not exist')</script>", false);
        }
    }

    public void Mail(string empcode, string email, string name)
    {
        string resetlink;

        query q = new query();
        string pairs = String.Format("empcode={0}&name={1}&email={2}&date={3}", empcode, name, email, DateTime.Now.ToShortDateString());
        string encoded;
        encoded = q.EncodePairs(pairs);

        MailMessage objEmail = new MailMessage();
        MailAddress toaddress = new MailAddress(email);
        SmtpClient MailObj = new SmtpClient();
        objEmail.From = new MailAddress("admin@SDLindia.com");

        objEmail.To.Add(toaddress);
        //objEmail.From.Address = fromaddress;
        objEmail.Subject = "Reset your company login password";
        objEmail.IsBodyHtml = true;

        objEmail.Body = @"Dear " + name + @",<br>
                        We have received your request to reset your company login password. <br>Please use this secure URL to reset your password.<br>
                        To reset your password, please enter your new password twice <br>on the page that opens.
                        If you cannot access the link above, you can paste<br> the following address into your browser:<br>
                        <a href='http://10.247.2.212/hrm/resetpassword.aspx?q=" + encoded + @"'>http://10.247.2.212/hrm/resetpassword.aspx?q=" + encoded + @"</a>
                        <br>
                        - SDL Team<br>
                        http://www.SDLindia.com";
        try
        {
            //MailObj.Host = "10.247.2.9"
            MailObj.Host = "127.0.0.1";
            MailObj.Send(objEmail);
            MailObj.DeliveryMethod = SmtpDeliveryMethod.Network;
        }
        catch (Exception exc)
        {
            //span_check.InnerHtml = email + " is in our records, we will send a link to reset your password to that address. ";
            Response.Write("Send failure: " + exc.ToString());
        }
    }

    protected void Forget_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ForgetPassword.aspx', null, 'height=400,width=550,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ForgetPassword.aspx', null, 'height=400,width=500,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=30%, left=444px' );", true);
    }

    protected void Registration_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'RegistrartionForm.aspx', null, 'height=600,width=1100,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'RegistrartionForm.aspx', null, 'height=600,width=1100,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=10%, left=130px' );", true);
    }

    protected void login()
    {
        try
        {
            _Connection = activity.OpenConnection();
            SqlParameter[] parm = new SqlParameter[3];
            Output.AssignParameter(parm, 0, "@USERID", "String", 50, txtUserName.Text);
            Output.AssignParameter(parm, 1, "@COMMAND", "Int", 0, "0");
            Output.AssignParameter(parm, 2, "@intime", "DateTime", 0, System.DateTime.Now.ToString());


            ds = SQLServer.ExecuteDataset(_Connection, CommandType.StoredProcedure, "SP_TRACK_USERLOG", parm);

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

    protected void btnmail_Click(object sender, ImageClickEventArgs e)
    {
        div_OTP.Visible = true;
        div_1.Visible = false;
    }

    protected void btn_OTP_Click(object sender, EventArgs e)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection connection = new SqlConnection();

        SqlParameter[] newparameter = new SqlParameter[1];
        newparameter[0] = new SqlParameter("@mailid", SqlDbType.VarChar, 50);
        newparameter[0].Value = txt_login_email.Text;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "LookupUserbyemail", newparameter);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows.Count < 2)
            {
                Random random = new Random();
                activationcode = random.Next(1001, 9999).ToString();
                string query = "Insert into tbl_EmailVerfiyDetails(username,email,status,activationcode) values('" + txt_login_email.Text + "','" + txt_login_email.Text + "','Unverified','" + activationcode + "')";
                string mycon = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                senddata();
                ViewState["mail_id"] = txt_login_email.Text;
                Response.Redirect("Default.aspx?emailid=" + 1);
            }
            else
            {
                Response.Redirect("Default.aspx?failed_emp2=" + 2);
            }
        }
        else
        {
            Response.Redirect("Default.aspx?failed_emp=" + 1);
        }

    }

    private bool senddata()
    {
        try
        {
            string senderId = "connect@escalon.services"; // Sender EmailID
            string senderPassword = "Escalon2017$"; // Sender Password      
            string Template = "Dear your activation code is " + activationcode;
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;
            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(txt_login_email.Text);
            mailMessage.From = new MailAddress(senderId);
            mailMessage.Subject = "Activation Code to verify Email";
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

    protected void btn_verify_OTP_Click(object sender, EventArgs e)
    {
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        SqlConnection connection = new SqlConnection();
        try
        {
            //string emailid = Session["mail_id"].ToString();
            connection = Activity.OpenConnection();
            string sqlstr = @"select activationcode from tbl_EmailVerfiyDetails where email='" + ViewState["emailid"].ToString() + "' order by id desc";
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string code;
                code = ds.Tables[0].Rows[0]["activationcode"].ToString();
                if (code == txt_verify_OTP.Text)
                {
                    SqlParameter[] newparameter = new SqlParameter[1];
                    newparameter[0] = new SqlParameter("@mailid", SqlDbType.VarChar, 50);
                    newparameter[0].Value = ViewState["emailid"].ToString();

                    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "LookupUserbyemail", newparameter);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        string dbPasswordHash = ds.Tables[0].Rows[0]["pwd"].ToString();
                        Session["empcode"] = ds.Tables[0].Rows[0]["empcode"].ToString();
                        Session["name"] = ds.Tables[0].Rows[0]["name"].ToString();
                        Session["login"] = ds.Tables[0].Rows[0]["login_id"].ToString();
                        Session["role"] = ds.Tables[0].Rows[0]["role"].ToString();
                        Session["rolename"] = ds.Tables[0].Rows[0]["rolename"].ToString();
                        Session["status"] = ds.Tables[0].Rows[0]["status"].ToString();
                        Session["photo"] = ds.Tables[0].Rows[0]["Photo"].ToString();
                        Session["branch"] = ds.Tables[0].Rows[0]["branch_id"].ToString();
                        Session["AdminSection"] = SmartHr.Common.AdminSection(Session["role"].ToString());
                        Session["OfficialEmailId"] = ds.Tables[0].Rows[0]["official_email_id"].ToString();

                        string a = Session["AdminSection"].ToString();
                        Session["companyid"] = "2";

                        if (ds.Tables[0].Rows[0]["gender"].ToString() == "Male" || ds.Tables[0].Rows[0]["gender"].ToString() == "MALE")
                        {
                            Session["gender"] = "M";
                        }
                        else if (ds.Tables[0].Rows[0]["gender"].ToString() == "Female" || ds.Tables[0].Rows[0]["gender"].ToString() == "FEMALE")
                        {
                            Session["gender"] = "F";
                        }


                        Session["doa"] = ds.Tables[0].Rows[0]["doa"].ToString();
                        Session["email"] = ds.Tables[0].Rows[0]["official_email_id"].ToString();

                        string query = @"select jd.empcode,ul.Logo,ul.createdby,ul.createddate
from tbl_intranet_uploadedLogo ul
INNER JOIN tbl_intranet_employee_jobDetails jd ON jd.empcode=ul.createdby
order by ul.createddate desc";
                        DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
                        if (ds_1.Tables[0].Rows.Count > 0)
                        {
                            Session["UploadedLogo"] = ds_1.Tables[0].Rows[0]["Logo"].ToString();
                        }
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        Response.Redirect("Default.aspx?failed_emp=" + 1);
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx?failed=" + 1);
                }
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ". " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {
            Activity.CloseConnection();
        }
    }

    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
        string query = @"SELECT l.login_id login_id, l.empcode empcode,l.role role,UPPER(LEFT(er.role,1))+LOWER(SUBSTRING(er.role,2,LEN(er.role))) as rolname,
upper(coalesce(g.emp_fname,' ')+' '+coalesce(g.emp_m_name,' ')+' '+coalesce(g.emp_l_name,' ')) as name,g.photo,
case when er.role='ADMIN LINE '	THEN 'Admin Line' when er.role='USER' THEN 'User' when er.role='SUPER ADMIN' THEN 'Admin' 
when er.role='MANAGING DIRECTOR' THEN 'MD' when er.role='HR-TALENT ACQUISITION' THEN 'HR-TA'
when er.role='FINANCE SPOC' THEN 'Finance' when er.role='ADMIN SPOC' THEN 'Admin SPOC' when er.role='LINE MANAGER' THEN 'Manager'
when er.role='BUSINESS HEAD' THEN 'Business Head' when er.role='HR-BUSINESS PARTNER' THEN 'HR-BP' 
when er.role='NEW EMPLOYEE LOGIN' THEN 'New Employee'
when er.role='HR SPOC' THEN 'HR SPOC' when er.role='HR-C&B' THEN 'HR-C&B'
end [emprolename]
FROM tbl_login l 
INNER JOIN tbl_intranet_employee_jobDetails g ON g.empcode=l.empcode
left Join tbl_intranet_employee_personalDetails p ON g.empcode = p.empcode 
inner join tbl_intranet_role er on er.id=l.role
WHERE g.emp_doleaving is null and l.empcode = '" + txtUserName.Text.Trim() + "'";
        DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            //lbl_emprole.Text = (ds_1.Tables[0].Rows[0]["emprolename"].ToString()) + " " + "Login";
            lbl_emprole.Text = "Welcome" + " " + (ds_1.Tables[0].Rows[0]["name"].ToString());
            Session["img"] = ds_1.Tables[0].Rows[0]["photo"].ToString();
            if (Session["img"].ToString() != null)
            {
                empimage.ImageUrl = "upload/photo/" + Session["img"].ToString() + "";
            }
            else
            {
                empimage.ImageUrl = "images/av_1.png";
            }
            txtPassword.Focus();
        }
        else
        {
            empimage.ImageUrl = "images/av_1.png";
        }
    }

}