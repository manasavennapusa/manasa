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
using querystring;
public partial class payroll_admin_reports_perquisite_form12BA : System.Web.UI.Page
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
        //string detail;
        //if (Request.QueryString["detail"] == null)
        //    detail = "1";
        //else
        //    detail = Request.QueryString["detail"].ToString();


        query q = new query();
        string empcode = (q["empcode"] != null) ? q["empcode"] : "0";
        string yearrange = (q["year"] != null) ? q["year"] : "0";

        //string empcode = Request.QueryString["empcode"].ToString();
        //string yearrange = Request.QueryString["yearrange"].ToString();

        sqlparm = new SqlParameter[2];

        sqlparm[0] = new SqlParameter("@empcode", empcode);
        sqlparm[1] = new SqlParameter("@fyear", yearrange);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_12Ba_sum", sqlparm);
        ds1.Tables[0].TableName = "Form12BA";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite_Form12B", sqlparm);
        ds2.Tables[0].TableName = "Form12BA-perquisite";

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        CrystalReportViewer1.HasDrillUpButton = false;

        ReportDocument myReportDocument = new ReportDocument();

        myReportDocument.Load(Server.MapPath("Form12BA.rpt"));
        myReportDocument.SetDataSource(ds1.Tables["Form12BA"]);

        myReportDocument.OpenSubreport("form12BA-Perquisite.rpt").SetDataSource(ds2.Tables["Form12BA-perquisite"]);
        //myReportDocument.SetParameterValue("fromyear", Request.QueryString["yearrange"].ToString());
        //myReportDocument.SetParameterValue("toyear", Request.QueryString["yearrange"].ToString());
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

    }
}

