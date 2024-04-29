using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Encode;
using Common.Data;
using Common.Console;

public partial class admin_SubEmployeeList : System.Web.UI.Page
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
            bindempdetail();
        }

        if (Session["role"] != null)
        {

        }
        else
            Response.Redirect("~/notlogged.aspx");


    }
    
    protected void bindempdetail()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select ej.empcode,emp_fname as name,designationname,photo,isnull(mode,'N/A') as mode from tbl_intranet_employee_jobDetails ej inner join tbl_employee_approvers ep on ep.empcode=ej.empcode and ep.app_reportingmanager='" + Session["empcode"].ToString() + "' left join tbl_intranet_designation dg on dg.id=ej.degination_id left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where  ej.emp_doleaving is null and ej.status=1  order by emp_fname";
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
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
   
    protected void empgrid_PreRender2(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.UseAccessibleHeader = true;
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}
