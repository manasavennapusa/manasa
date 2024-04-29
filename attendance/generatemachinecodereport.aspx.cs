using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class attendance_generatemachinecodereport : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId;

    DataSet ds;
    DataActivity DA = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                BindBranch();
            }
        }
        else
        {

        }
    }

    protected void BindBranch()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select branch_id, branch_name from tbl_intranet_branch_detail union select 0 as branch_id, '--All--' as branch_name";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            ddl_branch.DataSource = ds;
            ddl_branch.DataTextField = "branch_name";
            ddl_branch.DataValueField = "branch_id";
            ddl_branch.DataBind();
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

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        ddl_branch.Items.Insert(0, new ListItem("--All--", "0"));
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ReportMachineCode.aspx?Branch=" + ddl_branch.SelectedValue + "&DeptType=0&Dept=0&Empcode=" + txtempcode.Text.Trim().ToString() + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        ddl_branch.SelectedIndex = 0;
        txtempcode.Text = "";

    }

}