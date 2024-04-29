using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using DataAccessLayer;
public partial class payroll_admin_reports_QuaterReport : System.Web.UI.Page
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
        string year = Request.QueryString["year"].ToString();
        int quater = Convert.ToInt32(Request.QueryString["quater"]);
        
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@financial_year", year);
        sqlparm[1] = new SqlParameter("@quater", quater);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_FORM24A1", sqlparm);
        ds.Tables[0].TableName = "SP_PAYROLL_GENERATE_FORM24A1";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_FORM24A2", sqlparm);
        ds1.Tables[0].TableName = "SP_PAYROLL_GENERATE_FORM24A2";

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath("Form27A.rpt"));
        myReportDocument.SetDataSource(ds.Tables["SP_PAYROLL_GENERATE_FORM24A1"]);

        myReportDocument.OpenSubreport("DepositDetail27A").SetDataSource(ds1.Tables["SP_PAYROLL_GENERATE_FORM24A2"]);

        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }
}
