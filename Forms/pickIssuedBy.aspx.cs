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

public partial class recruitment_pickIssuedBy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bindempdetail();
        }
    }

    protected void bindempdetail()
    {  
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            string sqlstr = @"SELECT DISTINCT rtrim(tbl_intranet_employee_jobDetails.empcode) as empcode, 
coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name,  
tbl_intranet_employee_jobDetails.card_no,    
tbl_intranet_grade.gradename grade,    
tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,    
tbl_intranet_employee_jobDetails.dept_id,tbl_internate_departmentdetails.department_name,    
tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name,    
convert(varchar(10),tbl_intranet_employee_jobDetails.emp_doj,101)emp_doj,    
tbl_intranet_role.role,              
tbl_intranet_employee_jobDetails.emp_status    
FROM tbl_intranet_employee_jobDetails    
INNER JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id    
INNER JOIN tbl_internate_departmentdetails ON tbl_intranet_employee_jobDetails.dept_id=tbl_internate_departmentdetails.departmentid    
INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id    
left outer JOIN tbl_intranet_grade ON tbl_intranet_employee_jobDetails.grade=tbl_intranet_grade.id
inner join tbl_login on tbl_login.empcode=tbl_intranet_employee_jobDetails.empcode
left join tbl_intranet_role on tbl_intranet_role.id=tbl_login.role
WHERE 1=1 and tbl_intranet_employee_jobDetails.status=1";

            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void empgrid_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

}