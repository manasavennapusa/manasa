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
using CrystalDecisions.Shared;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using DataAccessLayer;

public partial class payroll_admin_reports_esiform5 : System.Web.UI.Page
{
    SqlParameter[] sqlparm;
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
        string year = Request.QueryString["year"].ToString();
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@year", year);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_form6A", sqlparm);
        ds1.Tables[0].TableName = "form6A";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_fetch_pfdetils");
        ds2.Tables[0].TableName = "company";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("pfform6A.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["form6A"]);

      

        myReportDocument.OpenSubreport("pfform6ADetails.rpt").SetDataSource(ds2.Tables["company"]);
        myReportDocument.SetParameterValue("fromyear", Request.QueryString["year"].ToString());
        myReportDocument.SetParameterValue("toyear", Request.QueryString["year"].ToString());
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
        
        
    }
}
