using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Console;
using System.Data.SqlClient;
using Common.Data;

public partial class payroll_admin_payrollfreeze : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetYear();
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }

    protected void GetYear()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select distinct s.YEAR from tbl_payroll_employee_salary s
inner join tbl_payroll_employee_salarydetail sd on s.SALARYID = sd.SALARYID";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

            dd_branch.DataSource = ds;
            dd_branch.DataTextField = "YEAR";
            dd_branch.DataValueField = "YEAR";
              dd_branch.DataBind();

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
    }

    protected void BindGrid()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"
select distinct MONTH,YEAR,b.branch_name,s.branch_id,case when s.flag=1 then 'Unfreezed' else 'Freezed' end as status  from tbl_payroll_employee_salary s
inner join dbo.tbl_intranet_branch_detail b 
on b.branch_id = s.branch_id where YEAR='" + dd_branch.SelectedValue + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

            payheadgird.DataSource = ds;
            payheadgird.DataBind();

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
    }
    
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string year = grdrow.Cells[0].Text;
        string month = grdrow.Cells[1].Text;
        string branch_id = grdrow.Cells[3].Text;


        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"update tbl_payroll_employee_salary set FLAG = 0 where MONTH='" + month + "' and YEAR='" + year + "'and branch_id='" + branch_id + "'";
            SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            BindGrid();
        }
    }
    protected void payheadgird_PageIndexChanged(object sender, EventArgs e)
    {

    }
    protected void lnknunfreez_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string year = grdrow.Cells[0].Text;
        string month = grdrow.Cells[1].Text;
        string branch_id = grdrow.Cells[3].Text;


        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"update tbl_payroll_employee_salary set FLAG = 1 where MONTH='" + month + "' and YEAR='" + year + "'and branch_id='" + branch_id + "'";
            SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            BindGrid();
        }
    }
}