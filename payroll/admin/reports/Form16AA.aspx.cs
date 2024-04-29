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
using querystring;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using DataAccessLayer;
public partial class payroll_admin_reports_Form16 : System.Web.UI.Page
{
    SqlParameter [] sqlparm;
    string strcmd = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

        }
        try
        {
            query q = new query();
            string empcode = (q["empcode"] != null) ? q["empcode"] : "0";
            string year = (q["year"] != null) ? q["year"] : "0";

            sqlparm = new SqlParameter[1];
            sqlparm[0] = new SqlParameter("@fyear", year);
            DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_company_ack_form16", sqlparm);
            ds2.Tables[0].TableName = "Companydetail";

            sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@empcode", empcode);
            sqlparm[1] = new SqlParameter("@fyear", year);

            strcmd = "select * from tbl_payroll_employee_section10_detail where empcode=@empcode and year=@fyear";

            DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_form16", sqlparm);
            ds1.Tables[0].TableName = "Form16";

            DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_crystal_form19EmpDetail", sqlparm);
            ds3.Tables[0].TableName = "EmployeePan";

            DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_tds_detail", sqlparm);
            ds4.Tables[0].TableName = "tds_detail";

            DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd, sqlparm);
            ds5.Tables[0].TableName = "section10";

            DataSet ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_80C_detail", sqlparm);
            ds6.Tables[0].TableName = "80C";

            strcmd = "select isnull(sum(total_tax),0.00) from tbl_payroll_employee_tax_deduction_detail where empcode='" + empcode + "' and financial_year='" + year + "'";
            decimal taxpaid = Convert.ToDecimal(DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd));

            strcmd = "select rempname,fempname,designation,raddress3 from tbl_payroll_tax_payer_detail";
            DataSet ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strcmd);

            DataSet ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_form16_ochapter6a", sqlparm);
            ds9.Tables[0].TableName = "sp_payroll_employee_form16_ochapter6a";

            CrystalReportViewer1.DisplayGroupTree = false;
            CrystalReportViewer1.HasCrystalLogo = false;

            ReportDocument myReportDocument = new ReportDocument();
            myReportDocument.Load(Server.MapPath("Form16AA.rpt"));
            myReportDocument.SetDataSource(ds1.Tables["Form16"]);

            myReportDocument.OpenSubreport("Form16AACompany.rpt").SetDataSource(ds2.Tables["Companydetail"]);
            myReportDocument.OpenSubreport("Form16AAEmployee.rpt").SetDataSource(ds3.Tables["EmployeePan"]);
            myReportDocument.OpenSubreport("Form16TaxDeducted.rpt").SetDataSource(ds4.Tables["tds_detail"]);
            myReportDocument.OpenSubreport("Form16-Section10.rpt").SetDataSource(ds5.Tables["section10"]);
            myReportDocument.OpenSubreport("Form16-80C.rpt").SetDataSource(ds6.Tables["80C"]);

            myReportDocument.OpenSubreport("Form16-Ochapter6A.rpt").SetDataSource(ds9.Tables["sp_payroll_employee_form16_ochapter6a"]);

            if (ds7.Tables[0].Rows.Count < 1)
            {

            }
            else
            {
                myReportDocument.SetParameterValue("TAXPAID", taxpaid);
                myReportDocument.SetParameterValue("emp", ds7.Tables[0].Rows[0]["rempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("femp", ds7.Tables[0].Rows[0]["fempname"].ToString().ToUpper());
                myReportDocument.SetParameterValue("desg", ds7.Tables[0].Rows[0]["designation"].ToString().ToUpper());
                myReportDocument.SetParameterValue("place", ds7.Tables[0].Rows[0]["raddress3"].ToString().ToUpper());
            }
            CrystalReportViewer1.ReportSource = myReportDocument;
            CrystalReportViewer1.DataBind();
        }
        catch (Exception ex) { Response.Write("NO Data Found"); }
    }
}
