using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class leave_PickMangeremployee : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            if (!IsPostBack)
            {
                //bindempdetail();
                bindempdetailmanagerdetails();

            }
        }

    }

    protected void bindempdetail()
    {
        // if (ddl_branch.SelectedValue != "0" && ddl_branch.SelectedValue != "")
        // {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "sp_leave_fetch_emp_detail5";
            SqlParameter[] p = new SqlParameter[5];
            Common.Console.Output.AssignParameter(p, 0, "@name", "String", 150, "");
            Common.Console.Output.AssignParameter(p, 1, "@desg", "Int", 50, "0");
            Common.Console.Output.AssignParameter(p, 2, "@department", "Int", 0, "0");
            Common.Console.Output.AssignParameter(p, 3, "@status", "String", 50, "All");
            Common.Console.Output.AssignParameter(p, 4, "@branch", "Int", 0, ddl_branch.SelectedValue);

            //  Common.Console.Output.AssignParameter(p, 5, "@companyId", "Int", 0, CompanyId);
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, query, p);
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        // }

    }


    protected void bindempdetailmanagerdetails()
    {
        // if (ddl_branch.SelectedValue != "0" && ddl_branch.SelectedValue != "")
        // {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"SELECT DISTINCT rtrim(tbl_intranet_employee_jobDetails.empcode) as empcode, coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ''  + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + '' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name,  
tbl_intranet_employee_jobDetails.card_no,    
tbl_intranet_grade.gradename grade,    
tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,    
tbl_intranet_employee_jobDetails.dept_id,tbl_internate_departmentdetails.department_name,    
tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name,    
convert(varchar(10),tbl_intranet_employee_jobDetails.emp_doj,101)emp_doj,    
tbl_intranet_role.role,              
tbl_intranet_employee_jobDetails.emp_status    
FROM tbl_intranet_employee_jobDetails  
inner join tbl_employee_approvers app on tbl_intranet_employee_jobDetails.empcode=app.empcode  
left JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id    
left JOIN tbl_internate_departmentdetails ON tbl_intranet_employee_jobDetails.dept_id=tbl_internate_departmentdetails.departmentid    
left JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id    
left outer JOIN tbl_intranet_grade ON tbl_intranet_employee_jobDetails.grade=tbl_intranet_grade.id
inner join tbl_login on tbl_login.empcode=tbl_intranet_employee_jobDetails.empcode
left join tbl_intranet_role on tbl_intranet_role.id=tbl_login.role

WHERE app.app_reportingmanager='"+ UserCode.Trim() +"'";
          

            //  Common.Console.Output.AssignParameter(p, 5, "@companyId", "Int", 0, CompanyId);
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            empgrid.DataSource = ds;
            empgrid.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        // }

    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindempdetail();
    }
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void empgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        //int a = (int)empgrid.DataKeys[e.NewEditIndex].Value;
        //Response.Redirect("createemployeeprofile.aspx?empcode=" + Request.QueryString["empcode"] + "");
    }

    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
