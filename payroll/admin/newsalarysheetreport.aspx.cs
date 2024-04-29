using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Globalization;
using System.IO;
using System.Web;
using Common.Console;
using Common.Data;

public partial class payroll_admin_newsalarysheetreport : System.Web.UI.Page
{
    string _companyId;
    DataSet ds, ds1 = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
                bind_company_detail();
                bind_job_detail();
                lblMonths.Text = Page.Request.QueryString["m"] + ' ' + Page.Request.QueryString[1];
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {

    }

    protected void bind_job_detail()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {

            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            Connection.Open();

            SqlCommand cmd1 = new SqlCommand("sp_payroll_generate_form5_report_full", Connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("@FYear", SqlDbType.VarChar, 50).Value = Page.Request.QueryString[1];
            cmd1.Parameters.Add("@Month", SqlDbType.VarChar, 50).Value = Page.Request.QueryString["m"];
            cmd1.Parameters.Add("@Branch", SqlDbType.Int).Value = Page.Request.QueryString["b"];

            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            DataSet dsCumulative = new DataSet();

            sda1.Fill(dsCumulative);
            Session["payrollsheet"] = dsCumulative;


            leave_approval_grid.DataSource = dsCumulative;
            leave_approval_grid.DataBind();

        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            connection.Close();
        }
    }


    protected void bind_company_detail()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {

            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
            Connection.Open();
        
            string queryCompany = @"select * from tbl_intranet_companydetails";

            SqlCommand cmd = new SqlCommand(queryCompany, Connection);
            cmd.CommandType = CommandType.Text;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet dsCompany = new DataSet();
            sda.Fill(dsCompany);

            lbl_company.Text = dsCompany.Tables[0].Rows[0]["companyname"].ToString() +' '+ '&' +' ' + dsCompany.Tables[0].Rows[0]["corp_add1"].ToString();

        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            connection.Close();
        }
    }
}