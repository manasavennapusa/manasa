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

public partial class payroll_admin_view_bonus : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");

            dd_reimb.DataBind();
            dd_dept.DataBind();
            dd_branch.DataBind();
            bind_employee_reimburesment();
        }
    }
    protected void bind_employee_reimburesment()
    {
        sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empname", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.ToString();

        sqlparam[1] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[1].Value = dd_branch.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_dept.SelectedValue;

        sqlparam[3] = new SqlParameter("@bonus_ref_no", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txt_ref.Text.ToString();

        sqlparam[4] = new SqlParameter("@bonus_name", SqlDbType.Int);
        sqlparam[4].Value = dd_reimb.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_bonus_detail", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_employee_reimburesment();
        message.InnerHtml = "";
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_employee_reimburesment();
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void dd_dept_DataBound(object sender, EventArgs e)
    {
        dd_dept.Items.Insert(0, new ListItem("Select dept.", "0"));
    }
    protected void dd_reimb_DataBound(object sender, EventArgs e)
    {
        dd_reimb.Items.Insert(0, new ListItem("Select", "0"));
    }
}
