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
using System.Data.SqlClient;

public partial class payroll_admin_settleloanadvances : System.Web.UI.Page
{
    string sqlstr, sqlstr1, sqlstr2, sqlstr3;
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
        message.InnerHtml = "";
        divloan.Visible = false;
        divpaid.Visible = false;
        divunpaid.Visible = false;
        divamnt.Visible = false;
    }
    protected void bindloandetail()
    {
        sqlstr = "SELECT ea.empcode,coalesce(ej.emp_fname,' ') + ' ' + coalesce(ej.emp_m_name,' ') + ' ' + coalesce(ej.emp_l_name,' ') as empname,el.loan_name,ea.loan_amount,convert(varchar(10),ea.sanction_date,101) sanction_date FROM tbl_payroll_employee_loanmaster ea INNER JOIN tbl_payroll_loan_advances el ON el.id=ea.loan_name_id INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=ea.empcode WHERE ea.loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if ((int)ds.Tables[0].Rows.Count > 0)
        {
            lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
            lbl_loanname.Text = ds.Tables[0].Rows[0]["loan_name"].ToString();
            lbl_laonamnt.Text = ds.Tables[0].Rows[0]["loan_amount"].ToString();
            lbl_sdate.Text = ds.Tables[0].Rows[0]["sanction_date"].ToString();
        }            
    }
    
    protected void bind_paid_installments()
    {
        sqlstr = "SELECT d.month_year,d.pinst_amount,d.beginningbalance,d.interestpayment,d.principalpayment,d.endingbalance,d.totalprincipal,d.totalinterest FROM tbl_payroll_employee_loandetail d INNER JOIN tbl_payroll_employee_loanmaster m ON d.loan_id=m.loan_id WHERE d.status=0 and m.loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        paidgrid.DataSource = ds;
        paidgrid.DataBind();
    }

    protected void bind_nonpaid_installments()
    {
        sqlstr = "SELECT d.month_year,d.pinst_amount,d.beginningbalance,d.interestpayment,d.principalpayment,d.endingbalance,d.totalprincipal,d.totalinterest FROM tbl_payroll_employee_loandetail d INNER JOIN tbl_payroll_employee_loanmaster m ON d.loan_id=m.loan_id WHERE d.status=1 and m.loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        unpaidgrid.DataSource = ds;
        unpaidgrid.DataBind();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        divloan.Visible = true;        
        divpaid.Visible = true;
        divunpaid.Visible = true;
        divamnt.Visible = true;
        bindloandetail();
        bind_paid_installments();
        bind_nonpaid_installments();

        calculate_total_amount();
    }

    //------------------------------------- Calculate Total Unpaid Installment Amount--------------------------------------
    protected decimal calculate_total_amount()
    {
        decimal amount = 0;
        sqlstr = "select isnull(sum(d.pinst_amount),0.00) as amnt from tbl_payroll_employee_loandetail d inner join tbl_payroll_employee_loanmaster m on m.loan_id=d.loan_id where d.status=1 and m.loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if ((int)ds.Tables[0].Rows.Count < 0)
        {

        }
        else
        {
           if (Convert.ToDecimal(ds.Tables[0].Rows[0]["amnt"]) == 0)
           {
               divunpaid.Visible = false;
               divamnt.Visible = false;
               message.InnerHtml = "All installments had been already paid";
           }
           else
           {
               amount = Convert.ToDecimal(ds.Tables[0].Rows[0]["amnt"].ToString());
               lbl_tinstamnt.Text = ds.Tables[0].Rows[0]["amnt"].ToString();
           }
        }
        return amount;
    }

    protected void submit_settledetail()
    {
        decimal amnt = calculate_total_amount();

        sqlstr2 = "SELECT loan_name_id FROM tbl_payroll_employee_loanmaster WHERE loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);

        SqlParameter[] sqlpar = new SqlParameter[5];

        sqlpar[0] = new SqlParameter("@loan_reference", SqlDbType.VarChar, 50);
        sqlpar[0].Value = txt_loanref.Text.ToString().Trim();

        sqlpar[1] = new SqlParameter("@loan_name", SqlDbType.Int);
        sqlpar[1].Value = ds.Tables[0].Rows[0]["loan_name_id"].ToString();

        sqlpar[2] = new SqlParameter("@settle_date", SqlDbType.DateTime);
        sqlpar[2].Value = Convert.ToDateTime(txt_sdate.Text);

        sqlpar[3] = new SqlParameter("@settle_amount", SqlDbType.Decimal);
        sqlpar[3].Value = amnt;

        sqlpar[4] = new SqlParameter("@settle_detail", SqlDbType.VarChar, 200);
        sqlpar[4].Value = txt_detail.Text;

        sqlstr3 = "INSERT INTO tbl_payroll_employee_settleloan(loan_reference_no,loan_name_id,settle_date,settle_amount,settle_detail) VALUES(@loan_reference,@loan_name,@settle_date,@settle_amount,@settle_detail)";

        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3, sqlpar);  
    }

    protected void btnpaid_Click(object sender, EventArgs e)
    {
        submit_settledetail();

        sqlstr = "UPDATE tbl_payroll_employee_loandetail SET status=0 WHERE  status=1 and loan_id=(select loan_id from tbl_payroll_employee_loanmaster where loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "')";
        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        sqlstr1 = "UPDATE tbl_payroll_employee_loanmaster SET status=0 WHERE status=1 and loan_ref_id='" + txt_loanref.Text.ToString().Trim() + "'";
        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                
        message.InnerHtml = "All unpaid installments have been paid";
    }    
}
