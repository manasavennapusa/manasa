using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class attendance_editholiday : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, RoleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                Bindalldata();
                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Holiday updated successfully.");
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }


    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of View Holiday  =============================
    #region Bind Holidays
    private void Bindalldata()
    {

        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "SELECT dbo.tbl_leave_holiday.holidayid, isnull(tbl_intranet_branch_detail.branch_name,'All Work Locations') branch_name, dbo.tbl_leave_holiday.year, dbo.tbl_leave_holiday.name, dbo.tbl_leave_holiday.detail,datename(dw,convert(varchar(11),tbl_leave_holiday.date,101)) dayofweek, (CASE WHEN dbo.tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), dbo.tbl_leave_holiday.date, 106) END) date FROM  dbo.tbl_leave_holiday left outer JOIN  tbl_intranet_branch_detail ON dbo.tbl_leave_holiday.branch_id = dbo.tbl_intranet_branch_detail.branch_id  where tbl_leave_holiday.year=year(getdate()) and tbl_leave_holiday.status=1 and tbl_leave_holiday.company_id=" + _companyId + " order by tbl_leave_holiday.year desc,tbl_leave_holiday.date";
            DataSet dataset = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            holidaygrid.DataSource = dataset;
            holidaygrid.DataBind();

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
    protected void ddlbranch_DataBound1(object sender, EventArgs e)
    {
        ddselbranch.Items.Insert(0, new ListItem("--For all WorkLocations--", "0"));
    }
    private void Bindsearchdata()
    {

        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "SELECT dbo.tbl_leave_holiday.holidayid, isnull(dbo.tbl_intranet_branch_detail.branch_name,'" + ddselbranch.SelectedItem.Text + "') branch_name, dbo.tbl_leave_holiday.year, dbo.tbl_leave_holiday.name, dbo.tbl_leave_holiday.detail,datename(dw,convert(varchar(11),tbl_leave_holiday.date,101)) dayofweek, (CASE WHEN dbo.tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(12), dbo.tbl_leave_holiday.date, 106) END) date FROM  dbo.tbl_leave_holiday left outer JOIN dbo.tbl_intranet_branch_detail ON dbo.tbl_leave_holiday.branch_id = dbo.tbl_intranet_branch_detail.branch_id where dbo.tbl_leave_holiday.branch_id in (" + ddselbranch.SelectedValue + ",0) and  tbl_leave_holiday.year=year(getdate()) order by dbo.tbl_leave_holiday.year desc,dbo.tbl_leave_holiday.date";
            DataSet dataSet = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            holidaygrid.DataSource = dataSet;
            holidaygrid.DataBind();

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

    private void Bindholiday()
    {
        if (ddselbranch.SelectedValue == "0")
            Bindalldata();
        else
            Bindsearchdata();
    }
    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindholiday();
    }
    #endregion
    #region Grid Edit ,Delete and Pageindexchange events
    protected void holidaygrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("UpdateHoliday.aspx?holidayid=" + Convert.ToInt32(Request.QueryString["holidayid"]) + "");
    }
    protected void holidaygrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var activity = new Common.Data.DataActivity();
        int i = 0;
        try
        {
            SqlConnection connection = activity.OpenConnection();
            var dataKey = holidaygrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var a = (int)dataKey.Value;
                string query = "delete from  tbl_leave_holiday  WHERE holidayid=" + a + "";
                i = Common.Data.SQLServer.ExecuteNonQuery(connection, CommandType.Text, query);
            }
            Bindholiday();
            if (i > 0)
            {
                Common.Console.Output.Show("Holiday Deleted successfully.");
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
        holidaygrid.PageIndex = e.NewPageIndex;
        holidaygrid.DataSource = ds;
        holidaygrid.DataBind();
    }
    #endregion
    #region Saerch Click
    protected void search_Click(object sender, EventArgs e)
    {

        Bindholiday();
    }
    #endregion

    protected void holidaygrid_PreRender(object sender, EventArgs e)
    {
        if (holidaygrid.Rows.Count > 0)
            holidaygrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void ddselbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindholiday();
    }
    protected void ddselbranch_DataBound(object sender, EventArgs e)
    {

    }
}
