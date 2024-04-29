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
        message.InnerHtml = "";

        if (!IsPostBack)
        {
            bindgrid();

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

    private void bindgrid()
    {

        DataSet ds = null;
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();

        //string query = @"SELECT tbl_internate_departmentdetails.departmentid, tbl_internate_departmentdetails.department_name,tbl_internate_departmentdetails.department_code, tbl_internate_departmentdetails.estt_date, tbl_intranet_branch_detail.branch_name FROM tbl_intranet_branch_detail INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_branch_detail.Branch_Id = tbl_internate_departmentdetails.branchid";
//        string query = @"select tbl_intranet_designation.id,tbl_intranet_designation.departmentid,department_name,branch_name,tbl_internate_departmentdetails.branchid id,designationname,description FROM tbl_intranet_designation
// inner join dbo.tbl_internate_departmentdetails on dbo.tbl_internate_departmentdetails.departmentid=tbl_intranet_designation.departmentid 
//inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid";

        string query = @"select 
tbl_intranet_designation.id,
tbl_intranet_designation.designationname,
tbl_internate_departmentdetails.department_name
from tbl_intranet_designation
inner join tbl_internate_departmentdetails 
on tbl_internate_departmentdetails.departmentid=tbl_intranet_designation.departmentid";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
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
    //     protected void DropDownList1_DataBound(object sender, EventArgs e)
    //{
    //    Grid_Emp.Items.Insert(0, new ListItem("--Select--", "0"));
    //}
    //protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    //bind_departmnt(Convert.ToInt16(DropDownList1.SelectedValue));
    //}
    protected void Grid_Emp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            DataActivity.OpenConnection();

            int ChildMenu = (int)Grid_Emp.DataKeys[(int)e.RowIndex].Value;
            if (ChildMenu != 0)
            {
                string sqlchildmenu = "Delete tbl_intranet_designation where id=" + ChildMenu;
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
            DataActivity.CloseConnection();
        }
    }
    }


