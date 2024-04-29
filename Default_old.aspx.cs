using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Net.Mail;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using System.Security.Cryptography;

public partial class _Default : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    string strsql;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        if (IsAuthenticated(txtUserName.Value, txtPassword.Value) == true)
        {
            int flag = 1;
            //if (!IsPasswordExpired(txtUserName.Value, txtPassword.Value))
            //    return;
            flag = IsFirstLogin(txtUserName.Value, txtPassword.Value);

            if (flag == 2)
                if (Session["role"].ToString() != "16")
                    Response.Redirect("resetdefaultpassword.aspx");
                else Response.Redirect("Home.aspx");
            else if (flag == 1)
                Response.Redirect("Home.aspx");
            else
            {
                ScriptManager.RegisterStartupScript(updatePannel1, updatePannel1.GetType(), "xx", "<script> alert('Login time is not Recorded please login once.')</script>", false);
                //lbl_message.Text = "Login time is not Recorded please login once.";
                // Response.Write(@"<script language='javascript'>alert('Login time is not Recorded please login once.');</script>");
            }

        }
        else
        {
            //lbl_message.Text = "Please Enter Correct Login Credentials";
            ScriptManager.RegisterStartupScript(updatePannel1, updatePannel1.GetType(), "xx", "<script> alert('Please Enter Correct Login Credentials.')</script>", false);

            //  Response.Write(@"<script language='javascript'>alert('Please Enter Correct Login Credentials');</script>");
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
        arrParam[0].Value = txtUserName.Value.Trim();

        strsql = @" SELECT coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name,tbl_intranet_employee_personalDetails.empcode,tbl_intranet_employee_personalDetails.email_id from tbl_intranet_employee_personalDetails INNER JOIN tbl_intranet_employee_jobDetails on tbl_intranet_employee_personalDetails.empcode=tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_personalDetails.empcode='" + txtUserName.Value + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["email_id"].ToString().Trim() == "")
            {
                ScriptManager.RegisterStartupScript(updatePannel1, updatePannel1.GetType(), "xx", "<script> alert('There is no email id in your personal detail. Please contact to your administrator')</script>", false);
            }
            else
            {
                Mail(ds.Tables[0].Rows[0]["empcode"].ToString(), ds.Tables[0].Rows[0]["email_id"].ToString(), ds.Tables[0].Rows[0]["name"].ToString());

                ScriptManager.RegisterStartupScript(updatePannel1, updatePannel1.GetType(), "xx", "<script> alert('A password reset link has sended to your email id')</script>", false);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(updatePannel1, updatePannel1.GetType(), "xx", "<script> alert('User does not exist')</script>", false);
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
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ForgetPassword.aspx', null, 'height=300,width=400,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
}