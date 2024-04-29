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
public partial class payroll_admin_provident_esi_fund : System.Web.UI.Page
{
    string _companyId;
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
     _companyId = Session["companyid"].ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

            bind_pf_details();
        }
    }

    protected void bind_pf_details()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_pfcontribution");
        txt_emp_max.Text = ds.Tables[0].Rows[0]["maxamount"].ToString();
        txt_emp_min.Text = ds.Tables[0].Rows[0]["minamount"].ToString();
        txt_emp_percentage.Text = ds.Tables[0].Rows[0]["EPF"].ToString();
        txt_emr_pfcontri.Text = ds.Tables[0].Rows[0]["EEPF"].ToString();
        txt_emprpf.Text = ds.Tables[0].Rows[0]["pension_fund"].ToString();
        txt_empr_02.Text = ds.Tables[0].Rows[0]["account02"].ToString();
        txt_empr_21.Text = ds.Tables[0].Rows[0]["account21"].ToString();
        txt_empr_22.Text = ds.Tables[0].Rows[0]["account22"].ToString();

        sqlstr = "select * from tbl_payroll_esi where status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        txt_esi_cutoff.Text = ds.Tables[0].Rows[0]["cutoff"].ToString();
        txt_esi_emp.Text = ds.Tables[0].Rows[0]["employeecontribution"].ToString();
        txt_esi_emr.Text = ds.Tables[0].Rows[0]["employercontribution"].ToString();
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[13];

        sqlparam[0] = new SqlParameter("@emp_min", SqlDbType.Decimal);
        if (txt_emp_min.Text == "")
            sqlparam[0].Value = 0;
        else
            sqlparam[0].Value = txt_emp_min.Text.ToString().Trim();

        sqlparam[1] = new SqlParameter("@emp_max", SqlDbType.Decimal);
        if (txt_emp_max.Text == "")
            sqlparam[1].Value = 0;
        else
            sqlparam[1].Value = txt_emp_max.Text.ToString().Trim();

        sqlparam[2] = new SqlParameter("@emp_per", SqlDbType.Decimal);
        sqlparam[2].Value = txt_emp_percentage.Text.ToString().Trim();

        sqlparam[3] = new SqlParameter("@empr_PF", SqlDbType.Decimal);
        sqlparam[3].Value = txt_emr_pfcontri.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@empr_pension", SqlDbType.Decimal);
        sqlparam[4].Value = txt_emprpf.Text.ToString().Trim();

        sqlparam[5] = new SqlParameter("@empr_02", SqlDbType.Decimal);
        sqlparam[5].Value = txt_empr_02.Text.ToString().Trim();

        sqlparam[6] = new SqlParameter("@empr_21", SqlDbType.Decimal);
        sqlparam[6].Value = txt_empr_21.Text.ToString().Trim();

        sqlparam[7] = new SqlParameter("@empr_22", SqlDbType.Decimal);
        sqlparam[7].Value = txt_empr_22.Text.ToString().Trim();

        sqlparam[8] = new SqlParameter("@esi_emp", SqlDbType.Decimal);
        sqlparam[8].Value = txt_esi_emp.Text.ToString().Trim();

        sqlparam[9] = new SqlParameter("@esi_empr", SqlDbType.Decimal);
        sqlparam[9].Value = txt_esi_emr.Text.ToString().Trim();

        sqlparam[10] = new SqlParameter("@esi_cut", SqlDbType.Decimal);
        if (txt_esi_cutoff.Text == "")
            sqlparam[10].Value = 0;
        else
            sqlparam[10].Value = txt_esi_cutoff.Text.ToString().Trim();

        sqlparam[11] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparam[11].Value = Session["name"].ToString();

        sqlparam[12] = new SqlParameter("@effectfrom", SqlDbType.VarChar, 100);
        sqlparam[12].Value = Convert.ToDateTime(txt_formdate.Text);

        //sqlparam[13] = new SqlParameter("@company_id", SqlDbType.VarChar, 100);
        //sqlparam[13].Value = Convert.ToInt32(_companyId.ToString());

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_pf_esi_update", sqlparam);
        Response.Redirect("view_provident_esi.aspx?message=PF/ESI record updated successfully");

    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_provident_esi.aspx");
    }
}
