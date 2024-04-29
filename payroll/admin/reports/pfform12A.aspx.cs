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
using CrystalDecisions.Shared;
using System.Data.SqlClient;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using DataAccessLayer;


public partial class payroll_admin_reports_pfform12 : System.Web.UI.Page
{
    SqlParameter[] sqlparm; SqlParameter[] sqlparm1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

        }
        string year = Request.QueryString["year"].ToString();
        string month = Request.QueryString["month"].ToString();
        string monthyear;
        string monthvalue = Request.QueryString["monthvalue"].ToString();
        
        sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@year", year);
        sqlparm[1] = new SqlParameter("@month", month);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_pfform12A", sqlparm);
        ds1.Tables[0].TableName = "pfform12A";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_pfdetils");
        ds2.Tables[0].TableName = "company";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;


    //**************************************************************************************************

        sqlparm1 = new SqlParameter[5];
        string fromyear = year.Substring(0, 4);
        string toyear = Convert.ToString(Convert.ToInt32(year.Substring(5, 4)) + 1);

        sqlparm1[0] = new SqlParameter("@fromyear", fromyear);
        sqlparm1[1] = new SqlParameter("@toyear", toyear);
        sqlparm1[2] = new SqlParameter("@monthvalue", monthvalue);
        sqlparm1[3] = new SqlParameter("@year", year);
        sqlparm1[4] = new SqlParameter("@month", month);

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_pfform12A_Numbers", sqlparm1);
        ds3.Tables[0].TableName = "Employee";
        //**************************************************************************************************


        ReportDocument myReportDocument = new ReportDocument();

        myReportDocument.Load(Server.MapPath("pfform12A.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["pfform12A"]);

        myReportDocument.OpenSubreport("pfform12A_headerSectionDetails.rpt").SetDataSource(ds2.Tables["company"]);
        myReportDocument.OpenSubreport("pfform12AEmployee.rpt").SetDataSource(ds3.Tables["Employee"]);
        myReportDocument.SetParameterValue("financialyear", Request.QueryString["year"].ToString());


        if (month == "Jan" || month == "Feb" || month == "Mar")
        {
            monthyear = month + "/" + year.Substring(5, 4);
        }
        else
        {
            monthyear = month + "/" + year.Substring(0, 4);
        }
        
        myReportDocument.SetParameterValue("monthyear", monthyear);
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

    }
}
