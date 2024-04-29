using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Encode;
using Common.Data;
using Common.Console;

public partial class admin_viewemployeepromotionandtransfer : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {              
           // bindempdetail();
        }

        if (Session["role"] != null)
        {

        }
        else
            Response.Redirect("~/notlogged.aspx");
    }
   
   
    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.UseAccessibleHeader = true;
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bindempdetail(string type)
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[1];

            sqlparam[0] = new SqlParameter("@type", SqlDbType.Int);
            sqlparam[0].Value = Convert.ToInt32(type);

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detail_type", sqlparam);
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
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindempdetail(drpbranch.SelectedValue);
    }
}