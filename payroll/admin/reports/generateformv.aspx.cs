using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using DataAccessLayer;
using System.IO;
using System.Data.SqlClient;

public partial class payroll_admin_reports_generateformv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindFinYear();
        }
    }

    protected void BindFinYear()
    {
        string sql = "SELECT financial_year year FROM tbl_payroll_tax_master order by id desc";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sql);
        ddlFinYear.DataTextField = "year";
        ddlFinYear.DataValueField = "year";
        ddlFinYear.DataSource = ds;
        ddlFinYear.DataBind();
    }

    protected void btnSalSheet_Click(object sender, EventArgs e)
    {
        
        Page.Validate("c");
        if (!Page.IsValid)
            return;

        string qs = "b=" + ddlBranch.SelectedValue + "&f=" + ddlFinYear.SelectedValue + "&m=" + ddlMonth.SelectedValue;
        string script = "window.open('salarysheetnew.aspx?" + qs + "','_blank','width=1200, height=600')";

        Page.ClientScript.RegisterStartupScript(GetType(), "newwindow", script, true); 

    }
   

    private void GetData()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();

        try
        {
            Connection = Activity.OpenConnection();

            DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, "select * from tbl_payroll_payhead where status=1");
            Session["payrollsheet"] = ds;
            
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            Activity.CloseConnection();
        }

    }
}