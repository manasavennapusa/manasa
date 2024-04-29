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
using querystring;

public partial class payroll_admin_employeepaystructuredetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {        
        if (Session["role"] != null)
        {
            
        }
        else Response.Redirect("~/notlogged.aspx");
       
        string empcode = Request.QueryString["empcode"].ToString();
        int paystructureid = Convert.ToInt32(Request.QueryString["paystructureid"]);

        bind_employeePaySturctureDetails(empcode, paystructureid);

        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
    }

    protected void bind_employeePaySturctureDetails(string empcode, int paystructureid)
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0]=new SqlParameter("@empcode", SqlDbType.VarChar,50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@paystructure_id", SqlDbType.Int);
        sqlparam[1].Value=paystructureid;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_paystructuredetails", sqlparam);

        if (ds.Tables[0].Rows.Count > 0)
        {
            empCode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            empName.Text = ds.Tables[0].Rows[0]["name"].ToString();
            empBranch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            empDepartment.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            empDesignation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_mth_yr.Text = ds.Tables[0].Rows[0]["FROM_MONTH"].ToString() + " " + ds.Tables[0].Rows[0]["FROM_YEAR"].ToString();
            lbl_mth_yr_t.Text = ds.Tables[0].Rows[0]["MONTH_YEAR"].ToString();
            lbl_pf.Text= (Convert.ToBoolean(ds.Tables[0].Rows[0]["pf"]))?"Yes":"No";
            lbl_esi.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["esi"])) ? "Yes" : "No";
            lbl_vpf.Text = ds.Tables[0].Rows[0]["VPF"].ToString();
            lbl_vpf_p.Text = ds.Tables[0].Rows[0]["VPFPer"].ToString();
            lbl_pt.Text = ds.Tables[0].Rows[0]["pt"].ToString();
            empgrid.DataSource = ds.Tables[1];
            empgrid.DataBind();
        }
    }
}
