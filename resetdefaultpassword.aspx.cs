using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using querystring;
using System.Security.Cryptography;
using Common.Data;

public partial class resetdefaultpassword : System.Web.UI.Page
{
    string strsql;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindempdetail();
        }
    }

    protected void bindempdetail()
    {
        string str = Session["empcode"].ToString();
        if (existence(str))
        {
            SqlParameter[] arrParam = new SqlParameter[1];
            arrParam[0] = new SqlParameter("@id", str);
            strsql = "SELECT  rtrim(tbl_intranet_employee_jobDetails.empcode) as empcode, coalesce(tbl_intranet_employee_jobDetails.emp_fname,'''') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'''') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'''') as name FROM tbl_intranet_employee_jobDetails WHERE empcode=@id";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
            lblcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lblname.Text = ds.Tables[0].Rows[0]["name"].ToString();
        }

    }
    public Boolean existence(string str)
    {
        int count;
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@id", str);
        strsql = "select count(empcode) from tbl_login where empcode=@id";
        count = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, arrParam);
        if (count > 0)
        {
            return true;
        }
        else
        {
            Common.Console.Output.Show("User Doesnot Exist");
            return false;
        }
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
    protected void btnsv_Click(object sender, EventArgs e)
    {
        int i = 0;
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            string str = Session["empcode"].ToString();
            int saltSize = 5;
            string salt = CreateSalt(saltSize);
            string passwordHash = CreatePasswordHash(txt_password.Text.Trim(), salt);
            Connection = Activity.OpenConnection();
            if (!ValidatePassword(str, txt_password.Text.Trim()))
                return;
            _Transaction = Connection.BeginTransaction();
            strsql = @"insert into tbl_login_history( login_id,pwd,empcode,role,status,createddate,updateddate,lastlogin)
                                 select login_id,pwd,empcode,role,status,createddate,updateddate,lastlogin from  tbl_login where empcode='" + str + "'";
            i = Common.Data.SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, strsql);

            strsql = "update tbl_login set pwd='" + passwordHash + "' ,lastlogin=GETDATE()  where empcode= '" + str + "' and status = 1";
            i += Common.Data.SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, strsql);
            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {
            Activity.CloseConnection();
        }
        if (i > 0)
        {
            Common.Console.Output.Show("Password changed sucessfully.");
            Response.Redirect("Home.aspx");
        }

    }
    private bool ValidatePassword(string UserCode, string suppliedPassword)
    {
        bool passwordMatch = true;
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            string dbPasswordHash = "", salt = "";
            Connection = Activity.OpenConnection();
            strsql = @"select pwd from tbl_login where empcode='" + UserCode + "'";
            ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, strsql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    dbPasswordHash = row["pwd"].ToString();
                    int saltSize = 8;
                    salt = dbPasswordHash.Substring(dbPasswordHash.Length - saltSize);
                    string hashedPasswordAndSalt = CreatePasswordHash(suppliedPassword, salt);
                    passwordMatch = hashedPasswordAndSalt.Equals(dbPasswordHash);
                    if (passwordMatch == true)
                    {
                        Common.Console.Output.Show("Last five used passwords cannot be the New Password");
                        return false;
                    }

                }
            }
            string dbPasswordHash1 = "", salt1 = "";
            strsql = @"select top 4 * from tbl_login_history where empcode='" + UserCode + "' order by lastlogin desc ";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strsql);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds1.Tables[0].Rows)
                {
                    dbPasswordHash1 = row["pwd"].ToString();
                    int saltSize = 8;
                    salt1 = dbPasswordHash1.Substring(dbPasswordHash1.Length - saltSize);
                    string hashedPasswordAndSalt1 = CreatePasswordHash1(suppliedPassword, salt1);
                    passwordMatch = hashedPasswordAndSalt1.Equals(dbPasswordHash1);
                    if (passwordMatch == true)
                    {
                        Common.Console.Output.Show("Last five used passwords cannot be the New Password");
                        return false;
                    }

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
    private string CreatePasswordHash1(string suppliedPassword, string salt1)
    {
        string saltAndPwd1 = String.Concat(suppliedPassword, salt1);
        string hashedPwd1 = FormsAuthentication.HashPasswordForStoringInConfigFile(saltAndPwd1, "SHA1");
        hashedPwd1 = String.Concat(hashedPwd1, salt1);
        return hashedPwd1;
    }
}
