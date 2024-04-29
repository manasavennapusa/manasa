using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Data;

public partial class attendance_downloadattendancelog : System.Web.UI.Page
{
    string CompanyId, RoleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                BindBranch();
                diverror.InnerHtml = "";
            }
        }
        else { Response.Redirect("../LogOut.aspx"); }
    }

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void BindBranch()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select branch_id, branch_name from tbl_intranet_branch_detail";
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

    private void BindIps()
    {
        SqlConnection Connection = null;
        DataActivity DA = new DataActivity();
        string Query = "";
        try
        {
            Connection = DA.OpenConnection();
            SqlParameter[] parm = new SqlParameter[1];

            Common.Console.Output.AssignParameter(parm, 0, "@branchid", "Int", 0, ddlbranch.SelectedValue.ToString());

            Query = @"select deviceips IP
                           from tbl_attendance_ip ip
                            where ip.branchid = @branchid and ip.status = 1 and ip.companyid = " + CompanyId + "";

            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, Query, parm);
            ipgrid.DataSource = ds;
            ipgrid.DataBind();

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }

    protected void ipgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        string ip = (string)ipgrid.DataKeys[(int)e.NewEditIndex].Value;
        Command.CMD CMD = new Command.CMD();
        diverror.InnerHtml = CMD.DownloadAttendanceLog(ip.Trim());
    }

    protected void ddlbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindIps();
        diverror.InnerHtml = "";
    }

  
}
