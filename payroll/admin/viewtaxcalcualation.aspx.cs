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
using DataAccessLayer;
using System.Data.SqlClient;

public partial class payroll_admin_viewtaxcalcualation : System.Web.UI.Page
{
    string sqlstr,_companyId,_userCode;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
        if (Session["role"] != null)
        {

        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (Request.QueryString["message"] != null)
            message.InnerHtml = Request.QueryString["message"].ToString();

        
        bind_emp_declaration();
    }


    protected void bind_emp_declaration()
    {
            string sqlparam = @"SELECT tbl_payroll_employee_declaration.ref_no,  
 tbl_payroll_employee_declaration.financialyr,  
 rtrim(tbl_payroll_employee_declaration.empcode) as empcode,  
 coalesce(tbl_intranet_employee_jobDetails.emp_fname,'''') +  '' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'''') +  '' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'''') as empname,  
 tbl_intranet_branch_detail.branch_name,  
 tbl_internate_departmentdetails.department_name,  
 (case when tbl_payroll_employee_declaration.status=0 then 'Pending' else 'Approved' end) dstatus,  
 1 visibility  
 FROM tbl_payroll_employee_declaration  
 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_intranet_employee_jobDetails.empcode=tbl_payroll_employee_declaration.empcode  
 INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id  
 INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_employee_jobDetails.dept_id=tbl_internate_departmentdetails.departmentid  
 WHERE  tbl_payroll_employee_declaration.empcode='" + _userCode + "'";
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlparam);

        griddetail.DataSource = ds;
        griddetail.DataBind();
    }

    protected string linkviewdedit(string empcode, string visiblity)
    {
        if (visiblity == "1")
        {
            return @"<a class='link05'   href='viewdeclarationdetail.aspx?empcode=" + empcode + @"' target='_self'>View</a>";
        }
        else
            return "No Links";
    }

    
}