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

public partial class Admin_company_empview : System.Web.UI.Page
{
    string RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        RoleId = Session["role"].ToString();
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            bind_Grid();
            if (Session["role"] != null)
            {

                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            if (Request.QueryString["updated"] != null)
                SmartHr.Common.Alert("Updated Successfully");
        }

    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        if (Grid_Emp.Rows.Count > 0)
        {
            Grid_Emp.UseAccessibleHeader = true;
            Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bind_Grid()
    {
        if (RoleId == "30")
        {
            string sqlstr = "select * from tbl_intranet_role";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
        }
        else
        {
            string sqlstr = "select * from tbl_intranet_role where id != 30";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
        }
    }
}
