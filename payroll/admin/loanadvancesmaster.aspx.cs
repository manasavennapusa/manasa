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

public partial class payroll_admin_loanadvancesmaster : System.Web.UI.Page
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
        SqlParameter[] sqlparam = new SqlParameter[9];

        sqlparam[0] = new SqlParameter("@loan_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_name.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@alias_name", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_alias.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@name_inpayslip", SqlDbType.VarChar, 100);
        sqlparam[2].Value = txt_payslip.Text.ToString().Trim();
                
        sqlparam[3] = new SqlParameter("@interest", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txt_interest.Text.Trim().ToString();

        sqlparam[4] = new SqlParameter("@loan_acno", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_loan_acno.Text.Trim().ToString();
       
        sqlparam[5] = new SqlParameter("@created_date", SqlDbType.DateTime);
        sqlparam[5].Value = System.DateTime.Now;

        sqlparam[6] = new SqlParameter("@created_by", SqlDbType.VarChar, 100);
        sqlparam[6].Value = Session["name"].ToString();

        sqlparam[7] = new SqlParameter("@eligibility_year", SqlDbType.Decimal,12);
        sqlparam[7].Value = Convert.ToDecimal(txt_eligibility_yr.Text);

        sqlparam[8] = new SqlParameter("@interestSBI", SqlDbType.Decimal, 12);
        sqlparam[8].Value = txt_taxSBI.Text;
        
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_createloanadvances", sqlparam);
        message.InnerHtml = " Loan/Advances created successfully ";
        clear();
    }
    protected void clear()
    {
        txt_alias.Text = "";
        txt_name.Text = "";
        txt_payslip.Text = "";
        txt_interest.Text = "0.0";
        txt_loan_acno.Text = "";
        txt_eligibility_yr.Text = "";
        txt_taxSBI.Text = "0.0";
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        clear();
        message.InnerHtml = "";
    }

    //------------------------------------------- Check for Loan/Advances Name ---------------------------------------------//

    protected void txt_name_TextChanged(object sender, EventArgs e)
    {
        validate_name();
    }

    protected void validate_name()
    {
        sqlstr = @"SELECT count(loan_name) FROM tbl_payroll_loan_advances WHERE loan_name='" + txt_name.Text.Trim().ToString() + "'";
        int i = (int)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (i > 0)
        {
            string message1 = "This Loan/Advances name already exists.Please enter some other name.";
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            txt_name.Text = "";
        }
    }
}
