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

public partial class payroll_admin_reports_pfform3A : System.Web.UI.Page
{
    SqlParameter[] sqlparm;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

        }
        
        string empcode = Request.QueryString["empcode"].ToString();
        string yearrange = Request.QueryString["yearrange"].ToString();

        sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@empcode", empcode);
        sqlparm[1] = new SqlParameter("@yearrange", yearrange);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_pfform3A", sqlparm);
        ds1.Tables[0].TableName = "pfform3A";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_employee_pfform3A_headerdetails", sqlparm);
        ds2.Tables[0].TableName = "company";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        ReportDocument myReportDocument = new ReportDocument();

        myReportDocument.Load(Server.MapPath("pfform3A.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["pfform3A"]);

        myReportDocument.OpenSubreport("pfform3A_headerSectionDetails.rpt").SetDataSource(ds2.Tables["company"]);
        myReportDocument.SetParameterValue("fromyear", Request.QueryString["yearrange"].ToString());
        myReportDocument.SetParameterValue("toyear", Request.QueryString["yearrange"].ToString()); 
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

    }
}
