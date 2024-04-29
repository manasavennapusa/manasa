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
public partial class payroll_admin_reports_Default : System.Web.UI.Page
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

        String strCmd = @"SELECT coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name,
       rtrim(tbl_intranet_employee_jobDetails.empcode) as empcode,
	   tbl_intranet_employee_jobDetails.card_no,
	   tbl_intranet_employee_jobDetails.grade,
	   tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,
       tbl_intranet_employee_jobDetails.dept_id,tbl_internate_departmentdetails.department_name,
       tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name,
       convert(varchar(10),tbl_intranet_employee_jobDetails.emp_doj,101)emp_doj,              
       tbl_intranet_employee_jobDetails.emp_status
       FROM tbl_intranet_employee_jobDetails
	   INNER JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id
       INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_employee_jobDetails.dept_id=tbl_internate_departmentdetails.departmentid
       INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id;SELECT     companyname, comp_type, estt_date, corp_add1, corp_add2, corp_city, corp_state, corp_country, corp_zip, corp_phone, cors_add1, cors_add2, 
                      cors_city, cors_state, cors_country, cors_zip, cors_phone, comp_engaged
                FROM tbl_intranet_companydetails";

       //SqlParameter sqlparm = new SqlParameter("@empcode", "00002");
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranet-finalConnectionString"].ConnectionString.ToString(), CommandType.Text, strCmd);
//        strCmd = @"SELECT     companyname, comp_type, estt_date, corp_add1, corp_add2, corp_city, corp_state, corp_country, corp_zip, corp_phone, cors_add1, cors_add2, 
//                      cors_city, cors_state, cors_country, cors_zip, cors_phone, comp_engaged
//                FROM tbl_intranet_companydetails";
//        ds.Tables["tbl_intranet_companydetails"] = (DataTable)DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranet-finalConnectionString"].ConnectionString.ToString(), CommandType.Text, strCmd);
        ds.Tables[0].TableName = "datatable1";
        ds.Tables[1].TableName = "tbl_intranet_companydetails";
        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;
        
        ReportDocument myReportDocument= new ReportDocument();
        myReportDocument.Load(Server.MapPath("CrystalReport.rpt"));
        //myReportDocument.SetDataSource(ds.Tables["tbl_intranet_companydetails"]);
        myReportDocument.SetDataSource(ds.Tables["datatable1"]);
        myReportDocument.OpenSubreport("Company.rpt").SetDataSource(ds.Tables["tbl_intranet_companydetails"]); 
        
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();
       

    }
}
