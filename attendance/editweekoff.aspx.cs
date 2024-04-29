using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class attendance_editweekoff : System.Web.UI.Page
{
    string _companyId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                BindweekOff(Convert.ToInt32(_companyId));
                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Week Off updated successfully.");
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }


    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of View Weekoffs  =============================
    #region Bind Weekoff to grid
    private void BindweekOff(int comapanyId)
    {
        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = " select weekoffid,weekcode,weekname from tbl_leave_weekoff where status=1 and company_id=" + comapanyId;
            DataSet dataset = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            weekoffgrid.DataSource = dataset;
            weekoffgrid.DataBind();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Grid Edit ,Delete and Pageindexchange events
    protected void holidaygrid_RowEditing(object sender, GridViewEditEventArgs e)
    {

        Response.Redirect("UpdateWeekoff.aspx?holidayid=" + Convert.ToInt32(Request.QueryString["weekoffid"]) + "");
    }
    protected void holidaygrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = 0;
        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            var dataKey = weekoffgrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var a = (int)dataKey.Value;
                string query = "delete from  dbo.tbl_leave_weekoff  WHERE weekoffid=" + a + "";
                i = Common.Data.SQLServer.ExecuteNonQuery(connection, CommandType.Text, query);
            }
            BindweekOff(Convert.ToInt32(Session["companyid"].ToString()));
            if (i > 0)
            {
                Common.Console.Output.Show("WeekOff Deleted successfully.");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    protected void holidaygrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var ds = new DataSet();
        weekoffgrid.PageIndex = e.NewPageIndex;
        weekoffgrid.DataSource = ds;
        weekoffgrid.DataBind();
    }
    #endregion

    protected void weekoffgrid_PreRender(object sender, EventArgs e)
    {

        if (weekoffgrid.Rows.Count > 0)
            weekoffgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
