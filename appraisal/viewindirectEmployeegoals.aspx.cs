using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Common.Mail.Module;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using DataAccessLayer;

public partial class appraisal_viewindirectEmployeegoals : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DataActivity = new DataActivity();
    string UserCode, empcode, appcycle_id;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        UserCode = Session["empcode"].ToString();
       empcode= Request.QueryString["empcode"].ToString();
       appcycle_id = Request.QueryString["appcycle_id"].ToString();
       
        if (!IsPostBack)
        {
            bindgrid();
        }
    }
    private void bindgrid()
    {
        empcode = Request.QueryString["empcode"].ToString();
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr_1 = @" select empcode, role_name_of_the_goal,kca_kra_desired_outcome_impact,kpi_milestone_to_check_improvement,weightage_timeline_and_support_required,
designationid from tbl_appraisal_emp_goal_cycle1  where applycyclid='" + appcycle_id + "' and  empcode='" + empcode + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr_1);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    protected void gvGoals_PreRender(object sender, EventArgs e)
    {
        if (gvGoals.Rows.Count > 0)
        {
            gvGoals.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("LineMangerSetEmployeeGoals.aspx");
    }
}