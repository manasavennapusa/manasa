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
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DataAccessLayer;

public partial class payroll_admin_reports_paslipprintout : System.Web.UI.Page
{
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

        }
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = "00042";
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = a.ToString("MMM");
        sqlparam[1].Value = "Jan";

        sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[2].Value = "2009-2010";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "payroll_payslip_emp", sqlparam);
        ds.Tables[0].TableName = "payslip_emp";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction", sqlparam);
        ds1.Tables[0].TableName = "payslip_emp_deduction";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_earning", sqlparam);
        ds2.Tables[0].TableName = "payslip_emp_earning";

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_tot_earning_deduction", sqlparam);
        ds3.Tables[0].TableName = "payslip_emp_tot_earning_deduction";

        DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fetch_companydetail");
        ds4.Tables[0].TableName = "companydetail";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("payslip.rpt"));
        myReportDocument.SetDataSource(ds.Tables["payslip_emp"]);

        myReportDocument.OpenSubreport("payslip_emp_deduction.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
        myReportDocument.OpenSubreport("payslip_emp_earning.rpt").SetDataSource(ds2.Tables["payslip_emp_earning"]);
        myReportDocument.OpenSubreport("payslip_total_earn_deduction.rpt").SetDataSource(ds3.Tables["payslip_emp_tot_earning_deduction"]);
        myReportDocument.OpenSubreport("payslip_company.rpt").SetDataSource(ds4.Tables["companydetail"]);
        myReportDocument.SetParameterValue("month", "jan");
        myReportDocument.SetParameterValue("year", "2009-2010");
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

        // Stop buffering the response
        Response.Buffer = false;
        // Clear the response content and headers
        Response.ClearContent();
        Response.ClearHeaders();
        try
        {
            // Export the Report to Response stream in PDF format and file name Customers
            myReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "Customers");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ex = null;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
}