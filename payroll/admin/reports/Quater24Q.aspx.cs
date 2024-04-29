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
        

        ///////////////1 Form///////////////////////////////////////////////////////////////
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@financial_year", year);
        sqlparm[1] = new SqlParameter("@quater", quater);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_FORM24A1", sqlparm);
        ds.Tables[0].TableName = "SP_PAYROLL_GENERATE_FORM24A1";
        ///////////////Challan Detail////////////////////////////////////////////////////////
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_CD_DETAIL", sqlparm);
        ds1.Tables[0].TableName = "SP_PAYROLL_GENERATE_CD_DETAIL";


        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        string[] months = getmonths(quater);

        ////////////////////////////////MONTH 1/////////////////////////////////////////////////////////////////////////////////////////////
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@financial_year", year);
        sqlparm[1] = new SqlParameter("@MONTH", months[0]);
        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_Annexure1", sqlparm);
        ds2.Tables[0].TableName = "SP_PAYROLL_GENERATE_Annexure1";

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL", sqlparm);
        ds3.Tables[0].TableName = "SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL";


        ////////////////////////////////MONTH 2/////////////////////////////////////////////////////////////////////////////////////////////
        
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@financial_year", year);
        sqlparm[1] = new SqlParameter("@MONTH", months[1]);

        DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_Annexure1", sqlparm);
        ds4.Tables[0].TableName = "SP_PAYROLL_GENERATE_Annexure1";

        DataSet ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL", sqlparm);
        ds5.Tables[0].TableName = "SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL";

        ////////////////////////////////MONTH 3/////////////////////////////////////////////////////////////////////////////////////////////
       
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@financial_year", year);
        sqlparm[1] = new SqlParameter("@MONTH", months[1]);

        DataSet ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_Annexure1", sqlparm);
        ds6.Tables[0].TableName = "SP_PAYROLL_GENERATE_Annexure1";

        DataSet ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL", sqlparm);
        ds7.Tables[0].TableName = "SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL";

        ReportDocument myReportDocument = new ReportDocument();
        if (quater != 4)
            myReportDocument.Load(Server.MapPath("Form24Q1-3.rpt"));
        else
              myReportDocument.Load(Server.MapPath("Form24Q4.rpt"));

        myReportDocument.SetDataSource(ds.Tables["SP_PAYROLL_GENERATE_FORM24A1"]);
        myReportDocument.OpenSubreport("ChallanDetail").SetDataSource(ds1.Tables["SP_PAYROLL_GENERATE_CD_DETAIL"]);
        myReportDocument.OpenSubreport("Annexure.rpt").SetDataSource(ds2.Tables["SP_PAYROLL_GENERATE_Annexure1"]);
        myReportDocument.OpenSubreport("Annexure_detail.rpt").SetDataSource(ds3.Tables["SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL"]);
        myReportDocument.OpenSubreport("Annexure.rpt - 01").SetDataSource(ds4.Tables["SP_PAYROLL_GENERATE_Annexure1"]);
        myReportDocument.OpenSubreport("Annexure_detail.rpt - 01").SetDataSource(ds5.Tables["SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL"]);
        myReportDocument.OpenSubreport("Annexure.rpt - 02").SetDataSource(ds6.Tables["SP_PAYROLL_GENERATE_Annexure1"]);
        myReportDocument.OpenSubreport("Annexure_detail.rpt - 02").SetDataSource(ds7.Tables["SP_PAYROLL_GENERATE_ANNEXURE1_DETAIL"]);
             
        if (quater == 4)
        {
            /////////////////////////////////Annexure II ///////////////////////////////////////////////////////////////////////////////////////////////

       
            sqlparm = new SqlParameter[1];
            sqlparm[0] = new SqlParameter("@financial_year", year);
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_FUV_SD_DETAIL", sqlparm);

            ///////////////////////////////Annexure II A//////////////////////////////////////////////////////////////////////
            DataSet ds8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_ANNEXURE2_1_DETAIL");
            ds8.Tables[0].TableName = "SP_PAYROLL_GENERATE_ANNEXURE2_1_DETAIL";

            ///////////////////////////////Annexure II B//////////////////////////////////////////////////////////////////////
            DataSet ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_GENERATE_ANNEXURE2_2_DETAIL");
            ds9.Tables[0].TableName = "SP_PAYROLL_GENERATE_ANNEXURE2_2_DETAIL";

            myReportDocument.OpenSubreport("SalaryDetail").SetDataSource(ds8.Tables["SP_PAYROLL_GENERATE_ANNEXURE2_1_DETAIL"]);
            myReportDocument.OpenSubreport("SalaryDetail2").SetDataSource(ds9.Tables["SP_PAYROLL_GENERATE_ANNEXURE2_2_DETAIL"]); 
                
        }
        
        
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
    }


    protected string[] getmonths(int quater)
    {
        int i;
        if (quater == 1)
            i = 4;
        else if (quater == 2)
            i = 7;
        else if (quater == 3)
            i = 10;
        else if (quater == 4)
            i = 1;
        else
            i = 1;
        string[] months = new string[3];
        months[0] = monthname(i);
        months[1] = monthname(i + 1);
        months[2] = monthname(i + 2);
        return months;
    }
    protected string monthname(int month)
    {
        switch (month)
        {
            case 1: return "Jan";
            case 2: return "Feb";
            case 3: return "Mar";
            case 4: return "Apr";
            case 5: return "May";
            case 6: return "Jun";
            case 7: return "Jul";
            case 8: return "Aug";
            case 9: return "Sep";
            case 10: return "Oct";
            case 11: return "Nov";
            case 12: return "Dec";
            default: return "Apr";
        }
    }
}