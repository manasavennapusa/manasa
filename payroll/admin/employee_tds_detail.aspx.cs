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

public partial class payroll_admin_employee_tds_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
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

    protected void insert_tds_details()
    {
        sqlparam = new SqlParameter[13];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.ToString().Trim();

        sqlparam[1] = new SqlParameter("@tds_rupees", SqlDbType.Decimal);
        sqlparam[1].Value = Convert.ToDecimal(txt_tds_amnt.Text.ToString());

        sqlparam[2] = new SqlParameter("@surcharge", SqlDbType.Decimal);
        sqlparam[2].Value = Convert.ToDecimal(txt_srchrg.Text.ToString());

        sqlparam[3] = new SqlParameter("@education_cess",SqlDbType.Decimal);
        sqlparam[3].Value = Convert.ToDecimal(txt_education_cess.Text.ToString());

        sqlparam[4] = new SqlParameter("@cheque_dd_number", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_chk_no.Text.ToString();

        sqlparam[5] = new SqlParameter("@bsr_bank_code", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txt_bsr.Text.ToString();

        sqlparam[6] = new SqlParameter("@tax_deposite_date", SqlDbType.DateTime);
        sqlparam[6].Value = Convert.ToDateTime(txt_deposite.Text.ToString());

        sqlparam[7] = new SqlParameter("@tranfer_voucher_id_no", SqlDbType.VarChar, 50);
        sqlparam[7].Value = txt_transfer_boucher.Text.ToString();

        sqlparam[8] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[8].Value = Session["name"];

        sqlparam[9] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[9].Value = System.DateTime.Now;

        sqlparam[10] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
        sqlparam[10].Value = dd_year.SelectedItem.Text.ToString();

        sqlparam[11] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[11].Value = dd_month.SelectedItem.Text.ToString();

        sqlparam[12] = new SqlParameter("@total_tax", SqlDbType.Decimal);
        sqlparam[12].Value = Convert.ToDecimal(txt_education_cess.Text.ToString()) + Convert.ToDecimal(txt_tds_amnt.Text.ToString()) + Convert.ToDecimal( txt_srchrg.Text.ToString());

      int a =Convert.ToInt16(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure,"[sp_payroll_employee_tds_details]",sqlparam));
      if (a > 0)
      {
          lbl_message.Text = "Tds detail updated successfully";
          clear();
      }
      else
      {
          lbl_message.Text = "Tds for selected month already exist";
      }
    }

    protected void clear()
    {
        txt_bsr.Text = "";
        txt_chk_no.Text = "";
        txt_deposite.Text = "";
        txt_education_cess.Text = "";
        txt_employee.Text = "";
        txt_srchrg.Text = "";
        txt_tds_amnt.Text = "";
        txt_transfer_boucher.Text = "";
        dd_month.SelectedIndex = -1;
        dd_year.SelectedIndex = -1;
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        insert_tds_details();
       
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
        lbl_message.Text = "";
    }
}
