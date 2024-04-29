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

public partial class recruitment_Pickrecruiter : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");

            bindempdetail();
        }
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = "";

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = "0";

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = "0";

        sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "All";

        sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[4].Value = 0;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_fetch_emp_detail", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }

  
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void empgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a = (int)empgrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("createemployeeprofile.aspx?empcode=" + Request.QueryString["empcode"] + "");
    }
    protected void btnaddnew_Click(object sender, EventArgs e)
    {
        string selectedemployee = "", selectedemployeenames = "";
        foreach (GridViewRow row in empgrid.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkselect");
            Label empcode = (Label)row.FindControl("lblempcode");
            Label empname = (Label)row.FindControl("lblname");
            if (ChkBoxRows.Checked == true)
            {
                selectedemployee = selectedemployee + empcode.Text.Trim() + ",";
                selectedemployeenames = selectedemployeenames + empname.Text.Trim() + ", ";
            }
        }
        if (selectedemployee != "")
        {
            selectedemployee = selectedemployee.Substring(0, selectedemployee.Length - 1);
        }
        if (selectedemployeenames != "")
        {
            selectedemployeenames = selectedemployeenames.Substring(0, selectedemployeenames.Length - 2);
        }
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "Script", "returnempcode('" + selectedemployee + "','" + selectedemployeenames + "');", true);
    }

    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}