using System;
using System.Web.UI.WebControls;
using Common.Console;
using System.Data.SqlClient;
using System.Data;
public partial class leave_editleave : System.Web.UI.Page
{
    //================================= Created by Ramu Nunna on 10-11-14 purpose of View Leave Details =============//
    DataSet _ds = new DataSet();
    string _companyId;
    SqlConnection _connection;
    Common.Data.DataActivity Activity = new Common.Data.DataActivity();
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindLeaveDetails(Convert.ToInt32(_companyId));
                if (Request.QueryString["updated"] != null)
                    Output.Show("Leave type updated successfully.");
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    #endregion
    #region BindLeave Details
    private void BindLeaveDetails(int companyId)
    {
        try
        {
            _connection = Activity.OpenConnection();
            string query = "SELECT leaveid, leavetype, displayleave, description FROM tbl_leave_createleave WHERE (status = 1) AND (leaveid!=0) and company_id=" + companyId;
            _ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, query);
            leavegird.DataSource = _ds;
            leavegird.DataBind();

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

    #endregion

    #region Grid Editing,Delteting & PreRender Events
    protected void shiftgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("updateleave.aspx?leaveid=" + Convert.ToInt32(Request.QueryString["leaveid"]) + "");
    }
    protected void shiftgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = 0;
        try
        {
            _connection = Activity.OpenConnection();
            var dataKey = leavegird.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                int a = (int)dataKey.Value;
                string query = "UPDATE tbl_leave_createleave SET status = 0 WHERE (leaveid = " + a + ")";
                i = Common.Data.SQLServer.ExecuteNonQuery(_connection, CommandType.Text, query);
            }
            BindLeaveDetails(Convert.ToInt32(_companyId));
            //bindshift();

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
        if (i > 0)
        {
            Common.Console.Output.Show("Leave deleted successfully.");
        }


    }

    protected void leavegird_PreRender(object sender, EventArgs e)
    {
        if (leavegird.Rows.Count > 0)
            leavegird.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    #endregion
}