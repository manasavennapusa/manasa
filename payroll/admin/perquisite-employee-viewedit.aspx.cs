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
public partial class payroll_admin_perquisite_employee_viewedit : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] != null)
        {
         
        }
        else
            Response.Redirect("~/notlogged.aspx");

        
    }
    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[4].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_emp_detail_perquisite", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
        bindempdetail();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }
    
    
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    
}
