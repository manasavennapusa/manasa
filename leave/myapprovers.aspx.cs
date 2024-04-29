using System;
using System.Data;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
public partial class leave_myapprovers : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection conn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        headtext.Text = "Approver List for " + Request.QueryString["name"].ToString() + ' ' + '(' + ' ' + Request.QueryString["empcode"].ToString() + ')';
        bindapprover();
    }

    public void bindapprover()
    {
        try
        {
            conn = activity.OpenConnection();
            sqlstr = @"select approverid as empcode, coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as approvername,
                   case when eh.hr=0 then 'Level ' + cast(approverpriority as varchar(10)) else 'HR' end as levels
                   from tbl_leave_employee_hierarchy eh inner join 
                   tbl_intranet_employee_jobDetails ed
                   on eh.approverid=ed.empcode 
                   where emp_doleaving is null and eh.employeecode= '" + Request.QueryString["empcode"].ToString() + "' order by approverpriority";

            ds = SQLServer.ExecuteDataset(conn, CommandType.Text, sqlstr);
            approvergrid.DataSource = ds;
            approvergrid.DataBind();
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
    protected void balancegrid_PreRender(object sender, EventArgs e)
    {

    }
}