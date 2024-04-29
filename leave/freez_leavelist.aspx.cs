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
using System.Data.SqlClient;
using DataAccessLayer;
using Common.Data;
using Common.Console;

public partial class leave_freez_leavelist : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
   
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            ddlLeavePeriod.Items.Insert(0, new ListItem("--Select--", "0"));
            //bind_month();
        }
    }

  

    protected void bind_year()
    {
        sqlstr = "select id ,periodname from tbl_leave_leaveperiod where status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        ddlLeavePeriod.DataTextField = "periodname";
        ddlLeavePeriod.DataValueField = "id";
        ddlLeavePeriod.DataSource = ds;
        ddlLeavePeriod.DataBind();
    }

    //protected void bind_month()
    //{
    //    sqlstr = "select distinct s.month,s.YEAR, case when f.status is null then 'Unfreezed' when f.status = 'F' then 'Freezed' when f.status = 'U' then 'Unfreezed' end status,fromdate from tbl_payroll_employee_salary s left join tbl_freezepayroll f on s.YEAR = f.finyear and s.MONTH = f.month  where s.YEAR='" + dd_year.SelectedValue + "' order by fromdate";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    gd_encash.DataSource = ds.Tables[0];
    //    gd_encash.DataBind();

    //}




    protected void ddlLeavePeriod_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindGrid();
    }
    protected void BindGrid()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"
select per.periodname,per.id,freez.month_id,freez.Month_name,case when freez.freeze=1 then 'Unfreezed' else 'Freezed' end as status  from tbl_leave_freez_month freez inner join tbl_leave_leaveperiod per on per.id=freez.calenderid where  per.id='" + ddlLeavePeriod.SelectedValue + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

            Grid_Emp.DataSource = ds;
            Grid_Emp.DataBind();

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
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        if (Grid_Emp.Rows.Count > 0)
        {
            Grid_Emp.UseAccessibleHeader = true;
            Grid_Emp.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        GridViewRow grdrow = (GridViewRow)((LinkButton)sender).NamingContainer;
        string year = grdrow.Cells[1].Text;

        string month = grdrow.Cells[2].Text;
        string calenderid = grdrow.Cells[0].Text;
      //  string branch_id = grdrow.Cells[3].Text;


        try
        {
            connection = activity.OpenConnection();
            DataSet ds10 = new DataSet();
            SqlParameter[] sqlParam4 = new SqlParameter[2];
            sqlParam4[0] = new SqlParameter("@periodid", SqlDbType.Int);
            sqlParam4[0].Value = calenderid;
            sqlParam4[1] = new SqlParameter("@month", SqlDbType.VarChar);
            sqlParam4[1].Value = month;
            ds10 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_freeze_checking", sqlParam4);
            if (ds10.Tables.Count.ToString() == "0" || ds10.Tables.Count.ToString() == null)
            {
                string sqlstr = @"update tbl_leave_freez_month set freeze = 0 where Month_name='" + month + "' and calenderid='" + calenderid + "'";
                SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr);
            }
            else if (ds10.Tables[0].Rows[0][0].ToString() == "0")
            {

                Output.Show(ds10.Tables[0].Rows[0][1].ToString());

                return;
            }

          
          
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