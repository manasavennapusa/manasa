using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class leave_pickproxyapprover : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId = "", Roleedb;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (Request.QueryString["level"].ToString() != null)
            {
                if (Request.QueryString["Level"].ToString() == "1")
                    Roleedb = "13";
                else if (Request.QueryString["Level"].ToString() == "2")
                    Roleedb = "14";
            }
            if (!IsPostBack)
            {
                bindempdetail();
            }
        }

    }

    protected void bindempdetail()
    {
        // if (ddl_branch.SelectedValue != "0" && ddl_branch.SelectedValue != "")
        // {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "sp_leave_fetch_emp_detail2";
            SqlParameter[] p = new SqlParameter[6];
            Common.Console.Output.AssignParameter(p, 0, "@name", "String", 150, "");
            Common.Console.Output.AssignParameter(p, 1, "@desg", "Int", 50, "0");
            Common.Console.Output.AssignParameter(p, 2, "@department", "Int", 0, "0");
            Common.Console.Output.AssignParameter(p, 3, "@status", "String", 50, "All");
            Common.Console.Output.AssignParameter(p, 4, "@branch", "Int", 0, ddl_branch.SelectedValue);
            Common.Console.Output.AssignParameter(p, 5, "@role", "Int", 0, "0"); //Roleedb.ToString());
            //  Common.Console.Output.AssignParameter(p, 5, "@companyId", "Int", 0, CompanyId);
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, query, p);
            empgrid.DataSource = ds;
            empgrid.DataBind();
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
        // }

    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindempdetail();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void empgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //int a = (int)empgrid.DataKeys[e.NewEditIndex].Value;
        //Response.Redirect("createemployeeprofile.aspx?empcode=" + Request.QueryString["empcode"] + "");
    }

    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
