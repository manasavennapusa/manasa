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
using System.IO;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class payroll_admin_costofemployeereport : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");
            bind_year();
            bind_month();
           
            dd_branch.DataBind();
            dd_designation.DataBind();            
        }
        report();
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
        sqlstr = "select distinct year from tbl_payroll_employee_salary";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }

    
    protected void btnreport_Click(object sender, EventArgs e)
    {
        report();
    }

    

    protected void report()
    {
        SqlParameter[] sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar,10);
        sqlparam[0].Value = dd_month.SelectedItem.Text;

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@name", SqlDbType.VarChar);
        sqlparam[2].Value = "";

        sqlparam[3] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[3].Value = dd_branch.SelectedValue;

        sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar);
        sqlparam[4].Value = dd_year.SelectedItem.Text.Trim();

        sqlparam[5] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[5].Value = 0;

        sqlparam[6] = new SqlParameter("@status", SqlDbType.Int);
        sqlparam[6].Value = 3;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_payheads]", sqlparam);
        ds.Tables[0].TableName = "costofemployee";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath(".") + "\\reports\\costofemployee.rpt");
        myReportDocument.SetDataSource(ds.Tables["costofemployee"]);

        //myReportDocument.OpenSubreport("payslip_emp_deduction.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
        //myReportDocument.OpenSubreport("payslip_emp_earning.rpt").SetDataSource(ds2.Tables["payslip_emp_earning"]);
        //myReportDocument.OpenSubreport("payslip_total_earn_deduction.rpt").SetDataSource(ds3.Tables["payslip_emp_tot_earning_deduction"]);
        //myReportDocument.OpenSubreport("payslip_company.rpt").SetDataSource(ds4.Tables["companydetail"]);
        //myReportDocument.SetParameterValue("month", "jan");
        //myReportDocument.SetParameterValue("year", "2009-2010");
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

        //// Stop buffering the response
        //Response.Buffer = false;
        //// Clear the response content and headers
        //Response.ClearContent();
        //Response.ClearHeaders();
        //try
        //{
        //    // Export the Report to Response stream in PDF format and file name Customers
        //    myReportDocument.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "Employee_Cost_Report");
        //}
        //catch (Exception ex)
        //{
        //    Console.WriteLine(ex.Message);
        //    ex = null;
        //}
    }
}
