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

public partial class payroll_admin_view_employee_arrear_salary_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            
        }
        else Response.Redirect("~/notlogged.aspx");

        binddetail();        
    }
    protected void binddetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["id"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_viewarreardetail", sqlparam);

        lbl_ref.Text = ds.Tables[0].Rows[0]["arrear_ref_no"].ToString();
        lbl_empcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_empname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
        lbl_amnt.Text = ds.Tables[0].Rows[0]["amount"].ToString();
        lbl_detail.Text = ds.Tables[0].Rows[0]["detail"].ToString();

        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["status"]))
            lbl_status.Text = "No Dispersement had been paid";
        else
            lbl_status.Text = "All Dispersements had been paid";

        griddetail.DataSource = ds.Tables[0];
        griddetail.DataBind();
    }
}
