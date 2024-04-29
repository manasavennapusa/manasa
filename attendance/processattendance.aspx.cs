using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class attendance_processattendance : System.Web.UI.Page
{
    string CompanyId;
    protected void Page_Load(object sender, EventArgs e)
    {
        lblmessage.Text = "";
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            CompanyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindBranch();
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    protected void BindBranch()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select branch_id, branch_name from tbl_intranet_branch_detail union select 0 as branch_id, '--Select--' as branch_name";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            ddlbranch.DataSource = ds;
            ddlbranch.DataTextField = "branch_name";
            ddlbranch.DataValueField = "branch_id";
            ddlbranch.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }

    }

    #region Process Attendence function
    protected void submitbtn_Click(object sender, EventArgs e)
    {
       
        if (Common.Date.Utility.DateFormat(txt_end_date.Text) > DateTime.Now)
        {
            // string message1 = "To date must be lessthan today's Date.";
            lblmessage.Text = "To date must be lessthan or equal to today's Date.";
            //  ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return;
        }
        if (Common.Date.Utility.DateFormat(txt_end_date.Text) < Common.Date.Utility.DateFormat(txt_start_date.Text))
        {
            // string message1 = "To date must be lessthan today's Date.";
            lblmessage.Text = "From Date Should be lessthan To Date.Please select valid dates.";
            //  ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + message1.ToString() + "')</script>", false);
            return;
        }

        SqlTransaction transaction = null;
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            string StartDate = Common.Date.Utility.DateFormat(txt_start_date.Text).ToString("dd-MMM-yyyy");
            string EndDate = Common.Date.Utility.DateFormat(txt_end_date.Text).ToString("dd-MMM-yyyy");
            string sqlstr1 = @"exec processleavebydate '" + StartDate + "','" + EndDate + "'," + CompanyId + "," + ddlbranch.SelectedValue + "";

            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1);
            string sqlstr2 = @"exec sp_job_process_employee_attendance_ondailybasis_daterange '" + StartDate + "','" + EndDate + "'," + CompanyId + "," + ddlbranch.SelectedValue + "";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr2);

            transaction.Commit();
            reset();
            Output.Show("Attendance processed successfully.");
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {

        }

    }

    #endregion


    protected void reset()
    {
        txt_end_date.Text = "";
        txt_start_date.Text = "";
    }
}
