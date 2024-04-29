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
using DataAccessLayer;

public partial class payroll_admin_viewloanmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
           
        }
        else
            Response.Redirect("~/notlogged.aspx");
        bindpayhead();       
    }
    protected void bindpayhead()
    {
        sqlstr = "SELECT id,loan_name,alias_name,name_inpayslip,interest,loan_acno,eligibility_year,interestSBI FROM tbl_payroll_loan_advances where id=" + Request.QueryString["id"].ToString() + "";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if ((int)ds.Tables[0].Rows.Count < 0)
        {

        }
        else
        {
            lbl_name.Text = ds.Tables[0].Rows[0]["loan_name"].ToString();
            lbl_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
            lbl_nameinpay.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
            lbl_interest.Text = ds.Tables[0].Rows[0]["interest"].ToString();
            lbl_acno.Text = ds.Tables[0].Rows[0]["loan_acno"].ToString();
            lbl_eligibility_year.Text = ds.Tables[0].Rows[0]["eligibility_year"].ToString();
            lbl_interestSBI.Text = ds.Tables[0].Rows[0]["interestSBI"].ToString();
        }
    }
}
