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

public partial class payroll_admin_edit_employee_tds_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
        dd_year.DataBind();
        Session["name"] = "Anshul";

        if (!IsPostBack)
        {
            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {

                }
                else Response.Redirect("~/notlogged.aspx");

            }
            bind_month();
            bind_tds_details();
        }
    }

    protected void bind_month()
    {
        for (int i = 1; i <= Convert.ToInt16(DateTime.Now.Month); i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
            DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
            dd_month.SelectedValue = a.Month.ToString();
        }
    }

    protected void bind_tds_details()
    {
        sqlstr = "select *,convert(varchar(10),tax_deposite_date,101)txt_deposite_date from tbl_payroll_employee_tax_deduction_detail where id=" + Request.QueryString["id"].ToString() + "";
       ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
       txt_bsr.Text = ds.Tables[0].Rows[0]["bsr_bank_code"].ToString();
       txt_chk_no.Text = ds.Tables[0].Rows[0]["cheque_dd_number"].ToString();
       txt_deposite.Text = ds.Tables[0].Rows[0]["txt_deposite_date"].ToString();
       txt_education_cess.Text = ds.Tables[0].Rows[0]["education_cess"].ToString();
       txt_srchrg.Text = ds.Tables[0].Rows[0]["surcharge"].ToString();
       txt_tds_amnt.Text = ds.Tables[0].Rows[0]["tds_rupees"].ToString();
       txt_transfer_boucher.Text = ds.Tables[0].Rows[0]["tranfer_voucher_id_no"].ToString();
       dd_month.SelectedValue = ds.Tables[0].Rows[0]["month"].ToString();
       dd_year.SelectedValue = ds.Tables[0].Rows[0]["financial_year"].ToString();
        lbl_emp.Text  = ds.Tables[0].Rows[0]["empcode"].ToString();
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        update_tds_detail();

    }
    protected void update_tds_detail()
    {
        try
        {
            sqlparam = new SqlParameter[14];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = lbl_emp.Text.ToString();

            sqlparam[1] = new SqlParameter("@tds_rupees", SqlDbType.Decimal);
            sqlparam[1].Value = Convert.ToDecimal(txt_tds_amnt.Text.ToString());

            sqlparam[2] = new SqlParameter("@surcharge", SqlDbType.Decimal);
            sqlparam[2].Value = Convert.ToDecimal(txt_srchrg.Text.ToString());

            sqlparam[3] = new SqlParameter("@education_cess", SqlDbType.Decimal);
            sqlparam[3].Value = Convert.ToDecimal(txt_education_cess.Text.ToString());

            sqlparam[4] = new SqlParameter("@cheque_dd_number", SqlDbType.VarChar, 50);
            sqlparam[4].Value = txt_chk_no.Text.ToString();

            sqlparam[5] = new SqlParameter("@bsr_bank_code", SqlDbType.VarChar, 50);
            sqlparam[5].Value = txt_bsr.Text.ToString();

            sqlparam[6] = new SqlParameter("@tax_deposite_date", SqlDbType.DateTime);
            sqlparam[6].Value = Convert.ToDateTime(txt_deposite.Text.ToString());

            sqlparam[7] = new SqlParameter("@tranfer_voucher_id_no", SqlDbType.VarChar, 50);
            sqlparam[7].Value = txt_transfer_boucher.Text.ToString();

            sqlparam[8] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 50);
            sqlparam[8].Value = Session["name"];

            sqlparam[9] = new SqlParameter("@modifieddate", SqlDbType.DateTime);
            sqlparam[9].Value = System.DateTime.Now;

            sqlparam[10] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
            sqlparam[10].Value = dd_year.SelectedItem.Text.ToString();

            sqlparam[11] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            sqlparam[11].Value = dd_month.SelectedItem.Text.ToString();

            sqlparam[12] = new SqlParameter("@total_tax", SqlDbType.Decimal);
            sqlparam[12].Value = Convert.ToDecimal(txt_education_cess.Text.ToString()) + Convert.ToDecimal(txt_tds_amnt.Text.ToString()) + Convert.ToDecimal(txt_srchrg.Text.ToString());

            sqlparam[13] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[13].Value = Request.QueryString["id"].ToString();

            DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_update_employee_tds_details]", sqlparam);
            Response.Redirect("view_employee_tds.aspx");
        }
        catch (Exception ex)
        {
            lbl_message.Text = "There is some problem while updating tds record";
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        bind_tds_details();
    }
}
