using DataAccessLayer;
using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
using Smart.HR.Common.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_company_empview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindgrid();

            if (Session["role"] != null)
            {
                string sPagePath = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
                System.IO.FileInfo oFileInfo = new System.IO.FileInfo(sPagePath);
                //AccessRights Access = NewHrms.Common.GetAccessRights((Container)Session["AccessRights"], oFileInfo.Name);
            }

        }
        if (Request.QueryString["updated"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        //message.InnerHtml = ""; 
    }

    private void bindgrid()
    {
        DataSet ds = null;
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();


        string query = @"SELECT id,employeestatus,description FROM tbl_intranet_employee_status";


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        Grid_Emp.DataSource = ds;
        Grid_Emp.DataBind();
      
    }


    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        Grid_Emp.UseAccessibleHeader = true;
        Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void Grid_Emp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            //DataActivity.OpenConnection();

            int ChildMenu = (int)Grid_Emp.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete tbl_intranet_employee_status where id=" + ChildMenu;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString, CommandType.Text, sqlchildmenu);
                Output.Show("Deleted Successfully");
                bindgrid();

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
            //DataActivity.CloseConnection();
        }
    }
    }

