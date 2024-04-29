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
using CrystalDecisions.CrystalReports.Engine;

public partial class payroll_admin_reports_projectedtaxdetailview : System.Web.UI.Page
{
    SqlParameter[] sqlparm;
    string strcmd = "";
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
        query q = new query();
        string strempcode = (q["empcode"] != null) ? q["empcode"] : Session["empcode"].ToString();

        sqlstr = "SELECT financial_year FROM tbl_payroll_tax_master ORDER BY id DESC";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
        string financialyear = ds.Tables[0].Rows[0][0].ToString();

        string empcode = strempcode.Trim().ToString();
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@empcode", empcode);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_projectedtax_master", sqlparm);
        ds1.Tables[0].TableName = "payroll_employee_projectedtax_master";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_grosssalary_projectedtax_detail", sqlparm);
        ds2.Tables[0].TableName = "payroll_employee_grosssalary_projectedtax_detail";

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_exemption_us10_projectedtax_detail", sqlparm);
        ds3.Tables[0].TableName = "payroll_employee_exemption_us10_projectedtax_detail";

        DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_otherincomesource_projectedtax_detail", sqlparm);
        ds4.Tables[0].TableName = "payroll_employee_otherincomesource_projectedtax_detail";

        DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_gross_total_income_projectedtax_detail", sqlparm);
        ds5.Tables[0].TableName = "payroll_employee_gross_total_income_projectedtax_detail";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("incometaxprojected.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["payroll_employee_projectedtax_master"]);

        myReportDocument.OpenSubreport("gross_salary_projectedreport.rpt").SetDataSource(ds2.Tables["payroll_employee_grosssalary_projectedtax_detail"]);
        myReportDocument.OpenSubreport("exempution_us10_projectedreport.rpt").SetDataSource(ds3.Tables["payroll_employee_exemption_us10_projectedtax_detail"]);
        myReportDocument.OpenSubreport("gross_total_income_projectedreport.rpt").SetDataSource(ds5.Tables["payroll_employee_gross_total_income_projectedtax_detail"]);
        //myReportDocument.OpenSubreport("exempution_us10_projectedreport.rpt").SetDataSource(ds2.Tables["payroll_employee_grosssalary_projectedtax_detail"]);
        //myReportDocument.SetParameterValue("fromyear", Request.QueryString["year"].ToString());
        myReportDocument.SetParameterValue("financialyear", financialyear);
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
}