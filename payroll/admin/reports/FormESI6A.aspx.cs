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
using DataAccessLayer;
public partial class payroll_admin_reports_FormESI6A : System.Web.UI.Page
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
        string month = Request.QueryString["month"].ToString();
        string year = Request.QueryString["year"].ToString();
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@month", month);
        sqlparm[1] = new SqlParameter("@fyear", year);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_esi_monthlyreport", sqlparm);
        ds.Tables[0].TableName = "esi_monthly";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("FormESI6A.rpt"));
        myReportDocument.OpenSubreport("esimonthlyreport.rpt").SetDataSource(ds.Tables["esi_monthly"]);
        //myReportDocument.Load(Server.MapPath("esimonthlyreport.rpt"));
        //myReportDocument.SetDataSource(ds.Tables["esi_monthly"]);

        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
}
