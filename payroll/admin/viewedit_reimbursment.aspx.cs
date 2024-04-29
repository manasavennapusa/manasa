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
using DataAccessLayer;

public partial class payroll_admin_viewedit_reimbursment : System.Web.UI.Page
{
    string sqlstr, _userCode, _companyId;
    DataSet ds = new DataSet();
    SqlParameter[] sqlparam;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else
                Response.Redirect("~/notlogged.aspx");

         
            bind_employee_reimburesment();
        }
        if (Request.QueryString["message"] != null)
        {
            message.InnerHtml = Request.QueryString["message"].ToString();
        }
    }

    protected void bind_employee_reimburesment()
    {

        string query = @"SELECT rtrim(tbl_payroll_employee_reimbursement.empcode) as empcode,
coalesce(tbl_intranet_employee_jobDetails.emp_fname,'''') +  '' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'''') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'''') as empname,
tbl_payroll_employee_reimbursement.reimbursement_id,
tbl_payroll_reimbursement.PAYHEAD_NAME,						
tbl_payroll_employee_reimbursement.reimbursement_ref_no,
tbl_intranet_employee_jobDetails.dept_id,tbl_internate_departmentdetails.department_name,
tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name,
convert(varchar(10),tbl_payroll_employee_reimbursement.sanction_date,101)sanction_date,
tbl_payroll_employee_reimbursement.amount
FROM tbl_payroll_employee_reimbursement
INNER JOIN tbl_intranet_employee_jobDetails ON tbl_intranet_employee_jobDetails.empcode=tbl_payroll_employee_reimbursement.empcode
INNER JOIN tbl_payroll_reimbursement ON tbl_payroll_reimbursement.id=tbl_payroll_employee_reimbursement.reimbursement_id
INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_employee_jobDetails.dept_id=tbl_internate_departmentdetails.departmentid
INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id
inner join tbl_employee_approvers on tbl_employee_approvers.empcode = tbl_intranet_employee_jobDetails.empcode
WHERE 1=1 and app_finance ='" + _userCode + "' and tbl_payroll_employee_reimbursement.month= 'NULL' ";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, query);
        empgrid.DataSource = ds;
        empgrid.DataBind();
    }
   
   
}