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

public partial class payroll_admin_editloanmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                
            }
            else Response.Redirect("~/notlogged.aspx");

            binddata();
        }
    }
    protected void binddata()
    {
        sqlstr = "SELECT distinct * FROM tbl_payroll_loan_advances WHERE id=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
        txt_name.Text = ds.Tables[0].Rows[0]["loan_name"].ToString();
        txt_payslip.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
        txt_interest.Text = ds.Tables[0].Rows[0]["interest"].ToString();
        txt_loan_acno.Text = ds.Tables[0].Rows[0]["loan_acno"].ToString();
        HiddenField1.Value = ds.Tables[0].Rows[0]["loan_name"].ToString();
        txt_eligibility_yr.Text = ds.Tables[0].Rows[0]["eligibility_year"].ToString();
        txt_taxSBI.Text = ds.Tables[0].Rows[0]["interestSBI"].ToString();
    }

    protected void submit()
    {
        SqlParameter[] sqlparam = new SqlParameter[10];

        sqlparam[0] = new SqlParameter("@loan_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        sqlparam[2].Value = txt_payslip.Text.ToString().Trim();

        sqlparam[3] = new SqlParameter("@interest", SqlDbType.Decimal);
        sqlparam[3].Value = txt_interest.Text.Trim().ToString();

        sqlparam[4] = new SqlParameter("@loan_acno", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_loan_acno.Text.Trim().ToString();

        sqlparam[5] = new SqlParameter("@modified_date", SqlDbType.DateTime);
        sqlparam[5].Value = System.DateTime.Now;

        sqlparam[6] = new SqlParameter("@modified_by", SqlDbType.VarChar, 100);
        sqlparam[6].Value = Session["name"].ToString();

        sqlparam[7] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[7].Value = Request.QueryString["id"];

        sqlparam[8] = new SqlParameter("@eligibility_year", SqlDbType.Decimal,12);
        sqlparam[8].Value = Convert.ToDecimal(txt_eligibility_yr.Text);

        sqlparam[9] = new SqlParameter("@interestSBI", SqlDbType.Decimal);
        sqlparam[9].Value = txt_taxSBI.Text;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_editlaonadvances", sqlparam);

        Response.Redirect("viewloanadvances.aspx?message=Loan/Advances updated successfully");
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if (txt_name.Text == HiddenField1.Value)
            submit();
        else
        {
            if (validate_name())
                submit();
        }
    }
    protected void btncncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewloanadvances.aspx");
    }

    //------------------------------------------- Check for Loan/Advances Name ---------------------------------------------//

    protected Boolean validate_name()
    {
        sqlstr = @"SELECT count(loan_name) FROM tbl_payroll_loan_advances WHERE loan_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Loan/Advances name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
            return false;
        }
        return true;
    }
}
