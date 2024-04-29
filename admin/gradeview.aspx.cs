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
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgrid();
            if (Request.QueryString["updated"] != null)
                SmartHr.Common.Alert("Updated Successfully");
        }

    }
    protected void rbtn_gradetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_gradetype.SelectedValue == "A")
        {
            sqlstr = "select * from tbl_intranet_grade where gradetype='" + ddl_gradetype.SelectedValue + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
        }
        else if (ddl_gradetype.SelectedValue == "T")
        {
            sqlstr = "select * from tbl_intranet_grade where gradetype='" + ddl_gradetype.SelectedValue + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();
        }
        else
        {
            bindgrid();
        }


    }


    private void bindgrid()
    {
        sqlstr = "select * from tbl_intranet_grade";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        if (Grid_Emp.Rows.Count > 0)
        {
            Grid_Emp.UseAccessibleHeader = true;
            Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}

