using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_editemployeeleaveprofile : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                bindempdetail();
                if (Request.QueryString["updated1"] != null)
                    Common.Console.Output.Show("There is no leave profile for this employee");
                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Employee profile updated successfully");
            }

        }
        else { Response.Redirect("~/LogOut.aspx"); }
    }

    protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void empgird_PreRender(object sender, EventArgs e)
    {
        if (empgird.Rows.Count > 0)
            empgird.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public void bindempdetail()
    {
        //  if (ddl_branch.SelectedValue != "0" && ddl_branch.SelectedValue != "")
        //  {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        DataSet ds = null;
        try
        {
            Connection = Activity.OpenConnection();
            _Transaction = Connection.BeginTransaction();

            SqlParameter[] a = new SqlParameter[5];

            Common.Console.Output.AssignParameter(a, 0, "@name", "String", 50, "");
            Common.Console.Output.AssignParameter(a, 1, "@desg", "Int", 0, "0");
            Common.Console.Output.AssignParameter(a, 2, "@department", "Int", 0, "0");
            Common.Console.Output.AssignParameter(a, 3, "@status", "String", 50, "All");
            Common.Console.Output.AssignParameter(a, 4, "@branch", "Int", 0, ddl_branch.SelectedValue);
            // Common.Console.Output.AssignParameter(a, 5, "@companyId", "Int", 0, CompanyId);
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "[sp_leave_fetch_emp_detail]", a);
            empgird.DataSource = ds;
            empgird.DataBind();

        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {
            Activity.CloseConnection();
        }
        //  }
    }
    protected void ddl_branch_DataBound(object sender, EventArgs e)
    {
        ddl_branch.Items.Insert(0, new ListItem("--All--", "0"));
    }
}
