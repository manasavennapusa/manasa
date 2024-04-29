using System;
using System.Data;
using System.Configuration;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;

public partial class leave_myemployees : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection conn = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "List of Employees under " + Request.QueryString["name"].ToString() + ' ' + '(' + ' ' + Request.QueryString["empcode"].ToString() + ')';
        bindapprover();
    }

    public void bindapprover()
    {
        try
        {
            conn = activity.OpenConnection();
            sqlstr = @"select distinct eh.employeecode as subempcode, coalesce(ed.emp_fname,'') + ' ' + coalesce(ed.emp_m_name,'') + ' ' + coalesce(ed.emp_l_name,'') as subempname                   
                   from tbl_leave_employee_hierarchy eh inner join 
                   tbl_intranet_employee_jobDetails ed
                   on ed.empcode = eh.employeecode
                   where emp_doleaving is null and eh.approverid= '" + Request.QueryString["empcode"].ToString() + "' order by eh.employeecode";


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

    protected void approvergrid_PreRender(object sender, EventArgs e)
    {

    }
}