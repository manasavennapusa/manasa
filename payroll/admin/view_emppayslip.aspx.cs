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
using querystring;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class payroll_admin_view_emppayslip : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string strPop;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               // if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            bind_month();
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);

        sqlstr = @"SELECT count(*) from tbl_payroll_employee_salary where month ='" + dd_month.SelectedItem.Text.ToString() + "' and year='" + dd_year.SelectedItem.Text.ToString() + "' and empcode='" + Session["empcode"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (Convert.ToInt16(ds.Tables[0].Rows[0][0]) > 0)
        {
            //strPop = "<script language='javascript'>window.open('payslip.aspx?empcode=" + txt_employee.Text.ToString() + "&month=" + dd_month.SelectedItem.Text.ToString() + "&year=" + dd_year.SelectedItem.Text.ToString() + "')</script>";
            strPop = encodepayslip(Session["empcode"].ToString(), dd_month.SelectedItem.Text.ToString(), dd_year.SelectedItem.Text.ToString());
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
        }
        else
            message.InnerHtml = "Salary has not been processed";
    }



    protected void bind_month()
    {
        sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }

    protected void bind_year()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }

    protected string encodepayslip(string empcode, string month, string year)
    {
        //payslip.aspx?empcode=" + txt_employee.Text.ToString() + "&month=" + dd_month.SelectedItem.Text.ToString() + "&year=" + dd_year.SelectedItem.Text.ToString() + "
        query q = new query();
        string pairs = String.Format("empcode={0}&month={1}&year={2}", empcode.ToString(), month.ToString(), year.ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<script language='javascript'>window.open('payslip.aspx?q=" + encoded + "')</script>";
    }
    protected void btnprint_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = a.ToString("MMM");
        sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();

        sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[2].Value = dd_year.SelectedItem.Text.ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "generate_payslip_printing", sqlparam);
        ds.Tables[0].TableName = "payslip_emp";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction", sqlparam);
        ds1.Tables[0].TableName = "payslip_emp_deduction";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_earning", sqlparam);
        ds2.Tables[0].TableName = "payslip_emp_earning";

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_tot_earning_deduction", sqlparam);
        ds3.Tables[0].TableName = "payslip_emp_tot_earning_deduction";

        DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fetch_companydetail");
        ds4.Tables[0].TableName = "companydetail";

        //CrystalReportViewer1.DisplayGroupTree = false;
       // CrystalReportViewer1.HasCrystalLogo = false;

       // ReportDocument myReportDocument = new ReportDocument();
       // myReportDocument.Load(Server.MapPath(".") + "\\reports\\payslip.rpt");
       // myReportDocument.SetDataSource(ds.Tables["payslip_emp"]);

       // myReportDocument.OpenSubreport("payslip_emp_deduction.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
      //  myReportDocument.OpenSubreport("payslip_emp_earning.rpt").SetDataSource(ds2.Tables["payslip_emp_earning"]);
       // myReportDocument.OpenSubreport("payslip_total_earn_deduction.rpt").SetDataSource(ds3.Tables["payslip_emp_tot_earning_deduction"]);
      //  myReportDocument.OpenSubreport("payslip_company.rpt").SetDataSource(ds4.Tables["companydetail"]);
      //  myReportDocument.SetParameterValue("month", dd_month.SelectedItem.Text.ToString());
      //  myReportDocument.SetParameterValue("year", dd_year.SelectedItem.Text.ToString());
      //  CrystalReportViewer1.ReportSource = myReportDocument;
       // CrystalReportViewer1.DataBind();

        // Stop buffering the response
        Response.Buffer = false;
        // Clear the response content and headers
        Response.ClearContent();
        Response.ClearHeaders();
        try
        {
            // Export the Report to Response stream in PDF format and file name Customers
           // myReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "SDL_Employee_Payslip");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ex = null;
        }
    }
}
