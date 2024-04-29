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

public partial class payroll_admin_view_employee_arrear_salary : System.Web.UI.Page
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
            else Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["message"] != null)
            message.InnerHtml = Request.QueryString["message"].ToString();
    }

    protected void bind_arreardetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@arrearrefno", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_arrearrefno.Text;
        
        sqlparam[1] = new SqlParameter("@empname", SqlDbType.VarChar, 150);
        sqlparam[1].Value = txt_employee.Text;

        sqlparam[2] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[3].Value = dd_dept.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_arreardetail", sqlparam);
        griddetail.DataSource = ds;
        griddetail.DataBind();        
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_arreardetail();
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));        
    }
    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
        dd_dept.Items.Insert(0, new ListItem("All", "0"));
        bind_arreardetail();
    }
    protected void griddetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        griddetail.PageIndex = e.NewPageIndex;
        bind_arreardetail();
    }
}
