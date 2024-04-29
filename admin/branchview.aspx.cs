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
using Common.Data;
using DataAccessLayer;
using Common.Console;

public partial class Admin_company_empview : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
      DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] != null)
        {
            ////if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //   // Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~@otlogged.aspx");
        if (Request.QueryString["updated"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        if (!IsPostBack)
        {
            BindGrid();
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

    protected void BindGrid()
    {
        string query = @"select bd.branch_id,cd.companyname,bd.branch_name,bd.branch_code,bd.region,bd.add1 
from tbl_intranet_branch_detail bd
left join tbl_intranet_companydetails cd on bd.company_id=cd.companyid";
       DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
    }

    protected void Grid_Emp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
          try
        {
            DataActivity.OpenConnection();

            int id = (int)Grid_Emp.DataKeys[(int)e.RowIndex].Value;
            if (id != 0)
            {
                string sqlchildmenu = "Delete  from tbl_intranet_branch_detail  where branch_id="+id;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
                BindGrid();

            }
            else
            {
                Output.Show("Please select the record...");
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    
   
}
