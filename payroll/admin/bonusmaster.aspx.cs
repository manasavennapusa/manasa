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
public partial class payroll_admin_bonusmaster : System.Web.UI.Page
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
        SqlParameter[] sqlparam = new SqlParameter[6];

        try
        {

            sqlparam[0] = new SqlParameter("@payhead_name", SqlDbType.VarChar, 100);
            sqlparam[0].Value = txt_name.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
            sqlparam[1].Value = txt_alias.Text.Trim().ToString();

            sqlparam[2] = new SqlParameter("@payhead_type", SqlDbType.Int);
            sqlparam[2].Value = dd_payheadtype.SelectedValue;

            sqlparam[3] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
            sqlparam[3].Value = txt_payslip.Text.ToString().Trim();

            sqlparam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
            sqlparam[4].Value = Session["name"].ToString();

            sqlparam[5] = new SqlParameter("@createddate", SqlDbType.DateTime);
            sqlparam[5].Value = System.DateTime.Now;

           DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_bonus_master", sqlparam);

              message.InnerHtml = " Bonus created successfully ";
               clear();
        
        }
        catch (Exception ex)
        {
           
        }
          
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }

    protected void clear()
    {
        txt_alias.Text = "";
        txt_name.Text = "";
        txt_payslip.Text = "";
        dd_payheadtype.SelectedIndex = -1;
    }
 
    //------------------------------------------- Check for Payhead Name ---------------------------------------------//

    protected void txt_name_TextChanged(object sender, EventArgs e)
    {
        validate_name();
    }
  
    protected void validate_name()
    {
        sqlstr = @"SELECT count(payhead_name) FROM tbl_payroll_bonus WHERE payhead_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Bonus name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
        }
    }
}
