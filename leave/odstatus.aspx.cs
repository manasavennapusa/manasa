using Common.Data;
using Smart.HR.Common.Console;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class leave_odstatus : System.Web.UI.Page
{
    //================================= Created by Ramu Nunna on 10-11-14 purpose of View Leave Details =============//

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
                if (Request.QueryString["leavestatus"] != null)
                {
                    if (Request.QueryString["leavestatus"].ToString() == "0")
                        Label1.Text = "View Pending OD";
                    else if (Request.QueryString["leavestatus"].ToString() == "1")
                        Label1.Text = "View Approved OD";

                    else if (Request.QueryString["leavestatus"].ToString() == "2")
                        Label1.Text = "View Cancelled OD";

                    else if (Request.QueryString["leavestatus"].ToString() == "3")
                        Label1.Text = "View Rejected OD";

                    else if (Request.QueryString["leavestatus"].ToString() == "5")
                        Label1.Text = "View Draft OD";

                }
                if (Request.QueryString["message"] != null)
                {
                    Common.Console.Output.Show(Request.QueryString["message"].ToString());
                }
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
        if (approvalstatus == 0)
            return "<a href='ViewApplyOd.aspx?q=" + encoded + "' title='view detail' class='link05'>View</a>";
        else
            return "<a href='ViewApplyOd.aspx?q=" + encoded + "' title='view detail' class='link05'>View</a>";
    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void drp_od_staus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
    protected void bind()
    {
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@leavestatus", "Int", 2, drp_od_staus.SelectedValue.ToString());
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, Session["empcode"].ToString());
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchodsummary_user", sqlparm);
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