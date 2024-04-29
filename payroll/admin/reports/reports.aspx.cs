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
using DataAccessLayer;
using querystring;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
public partial class payroll_admin_reports_reports : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DateTime Fdate, Todate;
    ReportDocument cryRpt = new ReportDocument();

    protected void Page_Load(object sender, EventArgs e)
    {
        bindform();

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void bindform()
    {
        SqlParameter[] newparameter = new SqlParameter[4];

        newparameter[0] = new SqlParameter("@Fdate", SqlDbType.DateTime);
        newparameter[0].Value = Convert.ToDateTime(Request.QueryString["Fdate"].ToString().Replace("'", ""));

        newparameter[1] = new SqlParameter("@Todate", SqlDbType.DateTime);
        newparameter[1].Value = Convert.ToDateTime(Request.QueryString["todate"].ToString().Replace("'", ""));

        newparameter[2] = new SqlParameter("@PF_Group", SqlDbType.VarChar, 50);
        newparameter[2].Value = Request.QueryString["PF_Group"].ToString();

        newparameter[3] = new SqlParameter("@OrderBy", SqlDbType.VarChar, 150);
        newparameter[3].Value = Request.QueryString["OrderBy"].ToString();

        if (Convert.ToInt32(Request.QueryString["pfform5"]) == 5)
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform5", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\pfform5.rpt");
        }
        else if (Request.QueryString["pfform6A"] == "6A")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\pfform6A.rpt");
        }

        else if (Convert.ToInt32(Request.QueryString["pfform10"]) == 10)
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\pfform10.rpt");
        }

        else if (Request.QueryString["pfform12A"] == "12A")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\pfform12A.rpt");
        }

        else if (Request.QueryString["esiform5"] == "5")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\esiform5.rpt");
        }

        else if (Request.QueryString["esiform6"] == "6")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\esiform6.rpt");
        }

        else if (Request.QueryString["esimonthlyreport"] == "30")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\esimonthlyreport.rpt");
        }

        else if (Request.QueryString["pfmonthlyreport"] == "30")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\pfmonthlyreport.rpt");
        }

        else if (Request.QueryString["esihalfyearlychallan"] == "180")
        {
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_report_pfform10", newparameter);
            cryRpt.Load(Server.MapPath(".") + "\\esihalfyearlychallan.rpt");
        }

        TableLogOnInfos crtableLogoninfos = new TableLogOnInfos();
        TableLogOnInfo crtableLogoninfo = new TableLogOnInfo();
        ConnectionInfo crConnectionInfo = new ConnectionInfo();
        Tables CrTables;

        crConnectionInfo.ServerName = "TEAM-PRAMOD\\TEAMWORKS";
        crConnectionInfo.DatabaseName = "intranet";
        crConnectionInfo.UserID = "pramod";
        crConnectionInfo.Password = "teamworks";

        CrTables = cryRpt.Database.Tables;

        foreach (CrystalDecisions.CrystalReports.Engine.Table CrTable in CrTables)
        {
            crtableLogoninfo = CrTable.LogOnInfo;
            crtableLogoninfo.ConnectionInfo = crConnectionInfo;
            CrTable.ApplyLogOnInfo(crtableLogoninfo);
        }

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        //cryRpt.SetParameterValue("month", Request.QueryString["Month"].ToString()); 

        //cryRpt.SetDataSource(ds.Tables[0]);


        CrystalReportViewer1.ReportSource = cryRpt;
        CrystalReportViewer1.DataBind();
        CrystalReportViewer1.RefreshReport();
    }
}
