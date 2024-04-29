using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Encode;
using Common.Console;


public partial class admin_viewtempemployeedetails : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {

        if (!IsPostBack)
        {
           
        }
        if (Request.QueryString["updated"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        if (Request.QueryString["rejected"] != null)
            SmartHr.Common.Alert("Sent Successfully");
        message.InnerHtml = "";
   


        }
        else
            Response.Redirect("~/notlogged.aspx");


    }

    protected void bindempdetail()
    {
        try
        {
            connection = activity.OpenConnection();
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

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detailbytemplogin", sqlparam);
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
        catch (Exception ex)
        {
           
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
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
    protected void empgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a = (int)empgrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("createemployeeprofile.aspx?approvercode=" + Request.QueryString["approvercode"] + "");

    }
    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected string linkreset(string id)
    {
       QueryString  q = new QueryString();
        string pairs = String.Format("empcode={0}", id.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' title='Reset Password'>Reset</a>";
    }

    protected void empgrid_PreRender2(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.UseAccessibleHeader = true;
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void empgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            var dataKey = empgrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                string empcode = (string)dataKey.Value;
                //var a = (int)dataKey.Value;
                string query = @"update tbl_intranet_employee_templogin_details set status='0' WHERE empcode='" + empcode + "'";
                Common.Data.SQLServer.ExecuteNonQuery(connection, CommandType.Text, query);
            }

            bindempdetail();
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
            string str = "<script> alert('Deleted Successfully')</script>";
        }
    }
}
