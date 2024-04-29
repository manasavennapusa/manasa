using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class attendance_CreateWeekOffMaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string _companyId, _userCode, RoleId = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                BindDropDownBranch();
                WeekOffDay();
                BindWeekOffGrid();
                
            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }

    private void WeekOffDay()
    {
        ddlweekoff.Items.Clear();
        ddlweekoff.Items.Add(new ListItem("--Select Week Off--", "0"));
        ddlweekoff.Items.Add(new ListItem("Sunday", "1"));
        ddlweekoff.Items.Add(new ListItem("Monday", "2"));
        ddlweekoff.Items.Add(new ListItem("Tuesday", "3"));
        ddlweekoff.Items.Add(new ListItem("Wednesday", "4"));
        ddlweekoff.Items.Add(new ListItem("Thrusday", "5"));
        ddlweekoff.Items.Add(new ListItem("Friday", "6"));
        ddlweekoff.Items.Add(new ListItem("Saturday", "7"));

      
    }
   
    protected void btnsbmit_Click(object sender, EventArgs e)
    {

        if (ddbranch_id.SelectedValue.Trim() == "0" || ddbranch_id.SelectedValue.Trim() == "")
        {
            Output.Show("Please select the Branch.");
            return;
        }

        if (ddlweekoff.SelectedValue.Trim() == "0" || ddlweekoff.SelectedValue.Trim() == "")
        {
            Output.Show("Please select the Week");
            return;
        }

        var parm = new SqlParameter[4];
        var activity = new DataActivity();
        int flag = 0;
        try
        {         
            Output.AssignParameter(parm, 0, "@company_id", "Int", 0, _companyId);
            Output.AssignParameter(parm, 1, "@branchid", "Int", 0, ddbranch_id.SelectedValue);
            Output.AssignParameter(parm, 2, "@weekcode", "String", 10, ddlweekoff.SelectedValue);
            Output.AssignParameter(parm, 3, "@weekname", "String", 10, ddlweekoff.SelectedItem.Text);

            string q = @"if not exists(select 1 from tbl_leave_weekoff where weekcode  = @weekcode and branchid=@branchid  AND status=1)

INSERT INTO tbl_leave_weekoff(company_id,weekcode,weekname,status,branchid)
VALUES(@company_id,@weekcode,@weekname,1,@branchid)";

            SqlConnection connection = activity.OpenConnection();

            flag = SQLServer.ExecuteNonQuery(connection, CommandType.Text, q, parm);
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (flag > 0)
        {
            BindWeekOffGrid();
            Output.Show(" Week Off Created Successfully");           
        }
        else
        {
            Output.Show("Week Off already exists");
        }
    }

    private void BindWeekOffGrid()
    {

        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "";
            if (ddbranch_id.SelectedValue=="0")
            {
                query = "select bd.branch_name,lwoff.weekcode,lwoff.weekname,lwoff.weekoffid from tbl_intranet_branch_detail bd Inner Join tbl_leave_weekoff lwoff on  bd.branch_id=lwoff.branchid";
            }
            else
                query = "select bd.branch_name,lwoff.weekcode,lwoff.weekname,lwoff.weekoffid from tbl_intranet_branch_detail bd Inner Join tbl_leave_weekoff lwoff on  bd.branch_id=lwoff.branchid where lwoff.branchid= " + ddbranch_id.SelectedValue+ "";
               
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            weekoffgrid.DataSource = ds;
            weekoffgrid.DataBind();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("There is some error in the grid.");
        }
        finally
        {
            activity.CloseConnection();
        }


    }
    
    protected void weekoffgrid_PreRender(object sender, EventArgs e)
    {
        if (weekoffgrid.Rows.Count > 0)
            weekoffgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void weekoffgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        var activity = new Common.Data.DataActivity();
        int i = 0;
        try
        {
            SqlConnection connection = activity.OpenConnection();
            var dataKey = weekoffgrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                var a = (int)dataKey.Value;
                string query = "delete from  tbl_leave_weekoff  WHERE weekoffid=" + a + "";
                i = Common.Data.SQLServer.ExecuteNonQuery(connection, CommandType.Text, query);
            }
         
            if (i > 0)
            {
                BindWeekOffGrid();
                Common.Console.Output.Show("Week Off Deleted successfully.");
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

    protected void ddbranch_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindWeekOffGrid();
    }

    private void BindDropDownBranch()
    {

        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "";
            query = "select * from ( SELECT '0' as [branch_id], '--Select Branch--' as [branch_name] union SELECT [branch_id], [branch_name] FROM [tbl_intranet_branch_detail] ) t order by branch_id";               
            ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            ddbranch_id.DataSource = ds;
            ddbranch_id.DataTextField="branch_name";
            ddbranch_id.DataValueField = "branch_id";
            ddbranch_id.DataBind();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("There is some error in the grid.");
        }
        finally
        {
            activity.CloseConnection();
        }


    }

    
}