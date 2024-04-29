using Common.Data;
using Smart.HR.Common.Console;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_HolidayWorkStatusApprover : System.Web.UI.Page
{
    string _companyId;
    #region PageLoad 
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                bind();
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    #endregion
    #region Link of Leave Details
    protected string linkleave(string empcode, int id, int approvalstatus)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a href='ViewApplyOd.aspx?q=" + encoded + "' title='view detail' class='link05'>View</a>";
    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void bind()
    {
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            //Output.AssignParameter(sqlparm, 0, "@Leavestatus", "Int", 2, drp_od_staus.SelectedValue.ToString());
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_compoff_attendance_holiday_status", sqlparm);
            if (ds.Tables.Count > 0)
            {
                leave_approval_grid.DataSource = ds;
                leave_approval_grid.DataBind();

            }
            else
            {
                leave_approval_grid.DataSource = null;
                leave_approval_grid.DataBind();

                return;

            }


        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
}