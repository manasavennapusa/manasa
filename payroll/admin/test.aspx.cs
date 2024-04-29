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
public partial class payroll_admin_test : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

        }
    }
    protected void bindreport()
    {
        sqlstr = "select distinct empcode from tbl_intranet_employee_jobDetails";
        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text,sqlstr);

        for (int i = 0; i < ds2.Tables[0].Rows.Count; i++)
        {
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[3];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            //sqlparam[0].Value = "96013";
            sqlparam[0].Value = ds2.Tables[0].Rows[i]["empcode"].ToString();

            sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
            sqlparam[1].Value = "jan";

            sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
            sqlparam[2].Value = "2009-2010";

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "payroll_payslip_emp1", sqlparam);
            ds.Tables[0].TableName = "payslip_emp";

            DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction1", sqlparam);
            ds1.Tables[0].TableName = "payslip_emp_deduction";

            CrystalReportViewer1.DisplayGroupTree = false;
            CrystalReportViewer1.HasCrystalLogo = false;

            ReportDocument myReportDocument = new ReportDocument();
            myReportDocument.Load(Server.MapPath(".") + "\\reports\\test.rpt");
            myReportDocument.SetDataSource(ds.Tables["payslip_emp"]);

            myReportDocument.OpenSubreport("test2.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
            //CrystalReportViewer1.ReportSource = myReportDocument;
            //CrystalReportViewer1.DataBind();

            myReportDocument.PrintOptions.PrinterName = "AGFA-AccuSet v52.3";
            //System.Drawing.Printing.PrinterSettings.InstalledPrinters;

            myReportDocument.PrintToPrinter(1, false, 1, 1);
        }
        
        //Stop buffering the response

        //Response.Buffer = false;
        //// Clear the response content and headers
        //Response.ClearContent();
        //Response.ClearHeaders();
        //try
        //{
        //    // Export the Report to Response stream in PDF format and file name Customers
        //    myReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "SDL_Employee_Payslip");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    ex = null;
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        bindreport();
    }
}
