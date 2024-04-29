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

public partial class payroll_admin_monthly_tds_challan_payment : System.Web.UI.Page
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

            ddl_bank_name.DataBind();
            challan_no =Convert.ToInt32(Request.QueryString["challan_no"]);
            bindchallaninfo();
            btnpayment.Enabled = false;
        }
    }

    protected void bindchallaninfo()
    {
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@challan_no", challan_no);
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_emp_monthly_tds_fetch_data]", sqlparm);

        if (ds1.Tables.Count > 1)
        {
            if ((ds1.Tables[0].Rows.Count > 0) && (ds1.Tables[1].Rows.Count > 0))
            {
                lblchallanno.Text = ds1.Tables[0].Rows[0]["challan_no"].ToString();
                lblfinancial_year.Text = ds1.Tables[0].Rows[0]["financial_year"].ToString();
                lblcostcenter.Text = ds1.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblbranch.Text = ds1.Tables[0].Rows[0]["branch"].ToString();
                lblmonth.Text = ds1.Tables[0].Rows[0]["month"].ToString();

                txttdsrupees.Text = ds1.Tables[1].Rows[0]["tds_rupees"].ToString();
                txtsurcharge.Text = ds1.Tables[1].Rows[0]["surcharge"].ToString();
                txteducationcess.Text = ds1.Tables[1].Rows[0]["education_cess"].ToString();
                txttotal.Text = ds1.Tables[1].Rows[0]["total_tax"].ToString();
            }
        }
    }

    protected void ddl_bank_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlParameter sqlparm = new SqlParameter("@bankcode", ddl_bank_name.SelectedValue.Trim().ToString());

        sqlstr = "SELECT bsrcode FROM tbl_payroll_bank WHERE branchcode = @bankcode and tds=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);

        txt_bsr.Text = ds.Tables[0].Rows[0]["bsrcode"].ToString();
    }

    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0,new ListItem("---Select Bank name---","0"));
    }

    protected void btnCalculate_Click(object sender, EventArgs e)
    {
        txttotal.Text = (Convert.ToDecimal(txttdsrupees.Text) + Convert.ToDecimal(txtsurcharge.Text) + Convert.ToDecimal(txteducationcess.Text) + Convert.ToDecimal(txtinterest.Text) + Convert.ToDecimal(txtothers.Text) + Convert.ToDecimal(txtaddlamount.Text)).ToString();
        btnpayment.Enabled = true;
    }

    protected void btnpayment_Click(object sender, EventArgs e)
    {
        sqlstr = @"UPDATE tbl_payroll_employee_tdsmonthly_challan SET cheque_dd_number='" + txt_no.Text.Trim().ToString() + "', bankcode='" + ddl_bank_name.SelectedValue + "', bsr_bank_code='" + txt_bsr.Text.Trim().ToString() + "', tax_deposite_date='" + Utilities.Utility.dataformat(txt_date.Text) + "', tranfer_voucher_id_no='" + txt_vou.Text.Trim().ToString() + "', tds_rupees='" + Convert.ToDecimal(txttdsrupees.Text) + "', surcharge='" + Convert.ToDecimal(txtsurcharge.Text) + "', education_cess='" + Convert.ToDecimal(txteducationcess.Text) + "', interest='" + Convert.ToDecimal(txtinterest.Text) + "', others='" + Convert.ToDecimal(txtothers.Text) + "', addl_amount='" + Convert.ToDecimal(txtaddlamount.Text) + "', total_tax='" + Convert.ToDecimal(txttotal.Text) + "', status=0, modifiedby='" + Session["name"].ToString() + "' WHERE challan_no='" + lblchallanno.Text.Trim().ToString() + "' AND financial_year='" + lblfinancial_year.Text.Trim().ToString() + "' AND month='" + lblmonth.Text.Trim().ToString() + "' AND branch='" + lblbranch.Text.Trim().ToString() + "'";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
    }
}
