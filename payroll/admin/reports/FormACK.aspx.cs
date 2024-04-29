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
        string empcode = (q["empcode"] != null) ? q["empcode"] : "0";
        string year = (q["year"] != null) ? q["year"] : "0";

        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@empcode", empcode);
        sqlparm[1] = new SqlParameter("@fyear", year);
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_ITR_Ack", sqlparm);
        ds.Tables[0].TableName = "sp_payroll_generate_ITR_Ack";
        
        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("incometaxdept-acknowledgement.rpt"));
        myReportDocument.SetDataSource(ds.Tables["sp_payroll_generate_ITR_Ack"]);

        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
}
