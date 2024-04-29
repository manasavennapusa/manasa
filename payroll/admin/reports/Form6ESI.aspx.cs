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
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using DataAccessLayer;
public partial class payroll_admin_reports_Form6ESI : System.Web.UI.Page
{
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
            string year = (Request.QueryString["year"] == null) ? "" : Request.QueryString["year"].ToString();
            string month = (Request.QueryString["month"] == null) ? "" : Request.QueryString["month"].ToString();
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@fyear", year);
            sqlparm[1] = new SqlParameter("@half", month);
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_generate_esi_form32", sqlparm);
            
            ds.Tables[0].TableName = "esi_form32";

            CrystalReportViewer1.DisplayGroupTree = false;
            CrystalReportViewer1.HasCrystalLogo = false;
            CrystalReportViewer1.HasDrillUpButton = false;

            ReportDocument myReportDocument = new ReportDocument();
           
                myReportDocument.Load(Server.MapPath("esiform6.rpt"));
           
         
            myReportDocument.SetDataSource(ds.Tables["esi_form32"]);
            myReportDocument.SetParameterValue("half", month);
            myReportDocument.SetParameterValue("year", year);
            myReportDocument.SetParameterValue("month1", (month == "1") ? "Apr" : "Oct");
            myReportDocument.SetParameterValue("month2", (month == "1") ? "May" : "Nov");
            myReportDocument.SetParameterValue("month3", (month == "1") ? "Jun" : "Dec");
            myReportDocument.SetParameterValue("month4", (month == "1") ? "Jul" : "Jan");
            myReportDocument.SetParameterValue("month5", (month == "1") ? "Aug" : "Feb");
            myReportDocument.SetParameterValue("month6", (month == "1") ? "Sep" : "Mar");
           
        CrystalReportViewer1.ReportSource = myReportDocument;
         try
            {
                CrystalReportViewer1.DataBind();
            }
               catch (Exception ex) { throw ex; }
        }
        catch (Exception ex) { throw ex; }

    }
}