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
public partial class payroll_admin_view_provident_esi : System.Web.UI.Page
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
            else
                Response.Redirect("~/notlogged.aspx");

            bind_pf_details();
            if (Request.QueryString["message"] != null)
            {
                message.InnerHtml = Request.QueryString["message"].ToString();
            }
        }
    }
    protected void bind_pf_details()
    {
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_pfcontribution");

        lbl_emp_max.Text = ds.Tables[0].Rows[0]["maxamount"].ToString();
        lbl_emp_min.Text = ds.Tables[0].Rows[0]["minamount"].ToString();
        lbl_emp_per.Text = ds.Tables[0].Rows[0]["EPF"].ToString();
        lbl_empr_02.Text = ds.Tables[0].Rows[0]["account02"].ToString();
        lbl_empr_21.Text = ds.Tables[0].Rows[0]["account21"].ToString();
        lbl_empr_22.Text = ds.Tables[0].Rows[0]["account22"].ToString();
        lbl_empr_pension.Text = ds.Tables[0].Rows[0]["pension_fund"].ToString();
        lbl_empr_Pf.Text = ds.Tables[0].Rows[0]["EEPF"].ToString();
        lbl_formdate.Text = ds.Tables[0].Rows[0]["effectfrom"].ToString();
        sqlstr = "select * from tbl_payroll_esi where status =1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        lbl_esi_cutoff.Text = ds.Tables[0].Rows[0]["cutoff"].ToString();
        lbl_esi_emp.Text = ds.Tables[0].Rows[0]["employeecontribution"].ToString();
        lbl_esi_empr.Text = ds.Tables[0].Rows[0]["employercontribution"].ToString(); 
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        Response.Redirect("provident_esi_fund.aspx");
    }
    //protected void btn_edit2_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect("provident_esi_fund.aspx");
    //}
}
