using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class attendance_editshift : System.Web.UI.Page
{
    DataSet _ds = new DataSet();
    string _companyId;
    SqlConnection _connection;
    Common.Data.DataActivity Activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                BindShifts(Convert.ToInt32(_companyId));
                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Shift updated successfully.");
            }
        }
        else {Response.Redirect("~/notlogged.aspx"); }


    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of View Shifts  =============================
    #region Bind All Shifts

    private void BindShifts(int companyId)
    {
        try
        {
            _connection = Activity.OpenConnection();
            string query = "select shiftid,shiftname,branch_name, right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1";
            _ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, query);
            shiftgrid.DataSource = _ds;
            shiftgrid.DataBind();

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
    #region Grid Editing,Delteting
    protected void shiftgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("Updateshift.aspx?shiftid=" + Convert.ToInt32(Request.QueryString["shiftid"]) + "");
    }

    protected void shiftgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        shiftgrid.PageIndex = e.NewPageIndex;
        shiftgrid.DataSource = _ds;
        shiftgrid.DataBind();
    }

    protected void shiftgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = 0;
        try
        {
            _connection = Activity.OpenConnection();
            var dataKey = shiftgrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                int a = (int)dataKey.Value;
                string query = "UPDATE tbl_leave_shift SET status='0' where shiftid=" + a + "";
                i = Common.Data.SQLServer.ExecuteNonQuery(_connection, CommandType.Text, query);
            }
            BindShifts(Convert.ToInt32(Session["companyid"].ToString()));
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
            Common.Console.Output.Show("Shift Deleted successfully.");
        }


    }
    #endregion
    #region Bind Selection Shifts

    private void Bindshift(int branchid)
    {

        try
        {
            _connection = Activity.OpenConnection();
            string query = "";
            if (branchid == 0)
                query = "select shiftid,shiftname,branch_name, right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1";
            else
                query = "select shiftid,shiftname,branch_name, right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1 and tbl_intranet_branch_detail.branch_id='" + branchid + "'";
            _ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, query);
            shiftgrid.DataSource = _ds;
            shiftgrid.DataBind();

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

    protected void shiftgrid_PreRender(object sender, EventArgs e)
    {

        if (shiftgrid.Rows.Count > 0)
            shiftgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void ddselbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindshift(Convert.ToInt32(ddselbranch.SelectedValue));
    }
    protected void ddselbranch_DataBound(object sender, EventArgs e)
    {
        ddselbranch.Items.Insert(0, new ListItem("For all WorkLocations", "0"));
    }
}
