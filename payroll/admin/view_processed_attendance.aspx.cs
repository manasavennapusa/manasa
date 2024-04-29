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
public partial class payroll_admin_view_processed_attendance : System.Web.UI.Page
{
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

                for (int i = 1; i <= 12; i++)
                {
                    ListItem item = new ListItem();
                    item.Text = new DateTime(1900, i, 1).ToString("MMM");
                    item.Value = i.ToString();
                    dd_year.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
                }
                DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
                dd_year.SelectedValue = a.Month.ToString();
                dd_designation.DataBind();
                dd_branch.DataBind();
                bind_system_lwp();
            }
       
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_system_lwp();
    }


    protected void bind_system_lwp()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text;

        sqlparam[1] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_year.SelectedItem.Text.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_view_systemgenerated_lwp", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_system_lwp();
    }
}
