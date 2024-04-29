using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class leave_compoffstatus : System.Web.UI.Page
{
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind();
            if (Request.QueryString["compoffstatus"] != null)
            {
                if (Request.QueryString["compoffstatus"].ToString() == "0")
                    Label1.Text = "View Pending Comp-off";
                else if (Request.QueryString["compoffstatus"].ToString() == "1")
                    Label1.Text = "View Approved Comp-off";

                else if (Request.QueryString["compoffstatus"].ToString() == "2")
                    Label1.Text = "View Cancelled Comp-off";

                else if (Request.QueryString["compoffstatus"].ToString() == "3")
                    Label1.Text = "View Rejected Comp-off";

                else if (Request.QueryString["compoffstatus"].ToString() == "5")
                    Label1.Text = "View Draft Comp-off";

            }
            if (Request.QueryString["message"] != null)
                SmartHr.Common.Alert(Request.QueryString["message"]);
        }

    }

    protected string linkleave(string empcode, string leavename, int id, int approvalstatus)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (approvalstatus == 0)
            return "<a href='viewcompoff.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
        else
            return "<a href='viewcompoff.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";
    }
    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void drp_leavestatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind();
    }
    protected void bind()
    {
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@compoffstatus", "Int", 2, drp_leavestatus.SelectedValue.ToString());
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, Session["empcode"].ToString());
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchcompoff_summary_user", sqlparm);
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