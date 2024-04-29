using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class payroll_admin_bankmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {

        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[8];

        sqlparam[0] = new SqlParameter("@branchcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_bankcode.Text.ToString().Trim();

        sqlparam[1] = new SqlParameter("@bankname", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_bankname.Text.ToString().Trim();

        sqlparam[2] = new SqlParameter("@accountnumber", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_accno.Text.ToString().Trim();

        sqlparam[3] = new SqlParameter("@address", SqlDbType.VarChar, 1000);
        sqlparam[3].Value = txt_bankaddr.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[4].Value = System.DateTime.Now;

        sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[5].Value = Session["name"].ToString();

        sqlparam[6] = new SqlParameter("@tds", SqlDbType.TinyInt);
        if (chktds.Checked)
        {
            sqlparam[6].Value = 1;
        }
        else
        {
            sqlparam[6].Value = 0;
        }

        sqlparam[7] = new SqlParameter("@bsrcode", SqlDbType.VarChar, 25);
        sqlparam[7].Value = txtbsrcode.Text.Trim().ToString();

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_bankmaster", sqlparam);
        if (i <= 0)
        {
            message.InnerHtml = " Bank information already exists.";

        }
        else
        {
            message.InnerHtml = " Bank information created successfully";
            clear();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }
    protected void clear()
    {
        txt_accno.Text = "";
        txt_bankaddr.Text = "";
        txt_bankcode.Text = "";
        txt_bankname.Text = "";
        chktds.Checked = false;
        txtbsrcode.Text = "";
    }
    protected void chktds_CheckedChanged(object sender, EventArgs e)
    {
        if (chktds.Checked == true)
        {
            bsrcode.Visible = true;
        }
        else {
            bsrcode.Visible = false;
        
        }
    }
}
