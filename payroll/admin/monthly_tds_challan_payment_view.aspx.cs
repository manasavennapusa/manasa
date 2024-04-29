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
using Utilities;
using System.IO;

public partial class payroll_admin_monthly_tds_challan_payment_view : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    int challan_no;
    SqlParameter[] sqlparm;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            
            challan_no = Convert.ToInt32(Request.QueryString["challan_no"]);
            bindchallaninfo();
            
        }
    }

    protected void bindchallaninfo()
    {
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@challan_no", challan_no);
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_emp_monthly_tds_fetch_data_view]", sqlparm);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblchallanno.Text = ds1.Tables[0].Rows[0]["challan_no"].ToString();
                lblfinancial_year.Text = ds1.Tables[0].Rows[0]["financial_year"].ToString();
                lblcostcenter.Text = ds1.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblbranch.Text = ds1.Tables[0].Rows[0]["branch"].ToString();
                lblmonth.Text = ds1.Tables[0].Rows[0]["month"].ToString();

                lblBankName.Text = ds1.Tables[0].Rows[0]["bankcode"].ToString();
                txt_bsr.Text = ds1.Tables[0].Rows[0]["bsr_bank_code"].ToString();
                txt_no.Text = ds1.Tables[0].Rows[0]["cheque_dd_number"].ToString();
                txt_vou.Text = ds1.Tables[0].Rows[0]["tranfer_voucher_id_no"].ToString();
                txt_date.Text = ds1.Tables[0].Rows[0]["tax_deposite_date"].ToString();

                txttdsrupees.Text = ds1.Tables[0].Rows[0]["tds_rupees"].ToString();
                txtsurcharge.Text = ds1.Tables[0].Rows[0]["surcharge"].ToString();
                txteducationcess.Text = ds1.Tables[0].Rows[0]["education_cess"].ToString();
                txttotal.Text = ds1.Tables[0].Rows[0]["total_tax"].ToString();
                
            }
        
    }
}
