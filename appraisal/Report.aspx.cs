using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using System.Web;
using System.IO;
using DataAccessLayer;

public partial class appraisal_Report : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }

        if (!IsPostBack)
        {
            bindddl_appraisal_cycle();
        }
        BindReports();
    }

    protected void bindddl_appraisal_cycle()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string strsql = "select appcycle_id,APP_year from tbl_appraisal_cycle WHERE quater='Q2' AND status=1";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, strsql);
            ddl_appraisal_cycle.DataTextField = "APP_year";
            ddl_appraisal_cycle.DataValueField = "appcycle_id";
            ddl_appraisal_cycle.DataSource = ds;
            ddl_appraisal_cycle.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void ddl_appraisal_cycle_DataBound(object sender, EventArgs e)
    {

        ddl_appraisal_cycle.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void BindReports()
    {
        string sqlstr = @"select jd.empcode as [Employee Code],
COALESCE(jd.emp_fname,'')+''+COALESCE(jd.emp_m_name,'')+''+COALESCE(jd.emp_l_name,'') as [Employee Name],
app.emp_overall_rating as  [Employee Overall Rating],
app.emp_overall_cmt as [Employee Overall Comment],
jd2.empcode as [Manager Code],
COALESCE(jd2.emp_fname,'')+''+COALESCE(jd2.emp_m_name,'')+''+COALESCE(jd2.emp_l_name,'') as [Manager Name],
app.mgr_overall_rating as  [Manager Overall Rating],
app.mgr_overall_cmt as  [Manager Overall Comment],
jd3.empcode as [Business Head Code],
COALESCE(jd3.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Business Head Name],
jd3.empcode as [Virtual Head Code],
COALESCE(jd4.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Virtual Head Name],
branch.branch_name as Branch,dept.department_name as Department,div.division_name as Division,
desig.designationname as Designation,grade.gradename as Grade,st.employeestatus As [Employee Status],
cc.cost_center_name as [Cost Center],cg.cost_center_group_name as [Cost Center Group],app.hike_status as[Hike status],
app.promotion_status as [Promotion Status],app.APP_year
from tbl_intranet_employee_jobDetails jd
inner join tbl_appraisal_assessment app on  app.empcode=jd.empcode
inner JOIN tbl_intranet_designation desig ON jd.degination_id=desig.id    
inner JOIN tbl_internate_departmentdetails dept ON jd.dept_id=dept.departmentid    
inner JOIN tbl_intranet_branch_detail branch ON jd.branch_id=branch.Branch_id    
left JOIN tbl_intranet_grade grade ON jd.grade=grade.id 
left join tbl_intranet_division div on div.ID=jd.division_id  
inner join tbl_intranet_employee_status st on st.id=jd.emp_status
inner join tbl_employee_approvers appr on appr.empcode=jd.empcode
inner join tbl_intranet_employee_jobDetails jd2 on jd2.empcode= appr.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jd3 on jd3.empcode= appr.app_businesshead
inner join tbl_intranet_employee_jobDetails jd4 on jd4.empcode= appr.clr_department
left join tbl_intranet_cost_center_group cg on cg.id=jd.cost_center_group_id
left join tbl_intranet_cost_center cc on jd.cost_center_code=cc.id
where app.hike_status='Approved' and app.promotion_status='Approved'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        gvReport.DataSource = ds;
        gvReport.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
            string sqlstr = @"select jd.empcode as [Employee Code],
COALESCE(jd.emp_fname,'')+''+COALESCE(jd.emp_m_name,'')+''+COALESCE(jd.emp_l_name,'') as [Employee Name],
app.emp_overall_rating as  [Employee Overall Rating],
app.emp_overall_cmt as [Employee Overall Comment],
jd2.empcode as [Manager Code],
COALESCE(jd2.emp_fname,'')+''+COALESCE(jd2.emp_m_name,'')+''+COALESCE(jd2.emp_l_name,'') as [Manager Name],
app.mgr_overall_rating as  [Manager Overall Rating],
app.mgr_overall_cmt as  [Manager Overall Comment],
jd3.empcode as [Business Head Code],
COALESCE(jd3.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Business Head Name],
jd3.empcode as [Virtual Head Code],
COALESCE(jd4.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Virtual Head Name],
branch.branch_name as Branch,dept.department_name as Department,div.division_name as Division,
desig.designationname as Designation,grade.gradename as Grade,st.employeestatus As [Employee Status],
cc.cost_center_name as [Cost Center],cg.cost_center_group_name as [Cost Center Group],app.hike_status as[Hike status],
app.promotion_status as [Promotion Status],app.APP_year
from tbl_intranet_employee_jobDetails jd
inner join tbl_appraisal_assessment app on  app.empcode=jd.empcode
inner JOIN tbl_intranet_designation desig ON jd.degination_id=desig.id    
inner JOIN tbl_internate_departmentdetails dept ON jd.dept_id=dept.departmentid    
inner JOIN tbl_intranet_branch_detail branch ON jd.branch_id=branch.Branch_id    
left JOIN tbl_intranet_grade grade ON jd.grade=grade.id 
left join tbl_intranet_division div on div.ID=jd.division_id  
inner join tbl_intranet_employee_status st on st.id=jd.emp_status
inner join tbl_employee_approvers appr on appr.empcode=jd.empcode
inner join tbl_intranet_employee_jobDetails jd2 on jd2.empcode= appr.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jd3 on jd3.empcode= appr.app_businesshead
inner join tbl_intranet_employee_jobDetails jd4 on jd4.empcode= appr.clr_department
left join tbl_intranet_cost_center_group cg on cg.id=jd.cost_center_group_id
left join tbl_intranet_cost_center cc on jd.cost_center_code=cc.id
where app.hike_status='Approved' and app.promotion_status='Approved' 
and jd.empcode='" + txt_employee.Text + "' and dept.department_name='" + ddl_dept .SelectedItem.Text+ "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            gvReport.DataSource = ds;
            gvReport.DataBind();
            txt_employee.Text = "";
            ddl_dept.SelectedValue = "0";
    }

    //protected void btnExport_Click(object sender, EventArgs e)
    //{
    //    exportexcel();
    //}

    protected void exportexcel()
    {

        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@apc_id", "Int", 0, ddl_appraisal_cycle.SelectedValue);
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            // Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 2, "@department", "Int", 0, ddl_dept.SelectedValue);

            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_report", sqlparam);

            //Response.Clear(); //this clears the Response of any headers or previous output 
            //Response.Charset = "";
            //Response.Buffer = true; //make sure that the entire output is rendered simultaneously
            //Response.ClearContent();
            //Response.ContentType = "application/vnd.ms-excel";

            //string filename = "filename =AppraisalReport.xls";
            //Response.Write(filename);
            //Response.AddHeader("content-disposition", filename);

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=AppraisalReport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";


            StringWriter stringWrite = new StringWriter();
            HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
            DataGrid dg = new DataGrid();
            dg.DataSource = ds.Tables[0];
            dg.DataBind();

            String style = @"<style>.text{mso-number-format:\@;}</style>";
            HttpContext.Current.Response.Write(style);
            int colindex = 0;
            foreach (DataColumn dc in ds.Tables[0].Columns)
            {
                string valuetype = dc.DataType.ToString();
                foreach (DataGridItem i in dg.Items)
                    i.Cells[colindex].Attributes.Add("class", "text");
                colindex++;
            }

            dg.RenderControl(htmlwrite);
            Response.Write(stringWrite.ToString());
            Response.End();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }

    }

    //protected void dd_dpt_DataBound(object sender, EventArgs e)
    //{
    //    dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

    protected void ddl_dept_DataBound(object sender, EventArgs e)
    {
        ddl_dept.Items.Insert(0, new ListItem("----- All -----", "0"));
    }

    protected void ddl_appraisal_cycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_appraisal_cycle.SelectedValue != "0")
        {
            string sqlstr = @"select jd.empcode as [Employee Code],
COALESCE(jd.emp_fname,'')+''+COALESCE(jd.emp_m_name,'')+''+COALESCE(jd.emp_l_name,'') as [Employee Name],
app.emp_overall_rating as  [Employee Overall Rating],
app.emp_overall_cmt as [Employee Overall Comment],
jd2.empcode as [Manager Code],
COALESCE(jd2.emp_fname,'')+''+COALESCE(jd2.emp_m_name,'')+''+COALESCE(jd2.emp_l_name,'') as [Manager Name],
app.mgr_overall_rating as  [Manager Overall Rating],
app.mgr_overall_cmt as  [Manager Overall Comment],
jd3.empcode as [Business Head Code],
COALESCE(jd3.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Business Head Name],
jd3.empcode as [Virtual Head Code],
COALESCE(jd4.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Virtual Head Name],
branch.branch_name as Branch,dept.department_name as Department,div.division_name as Division,
desig.designationname as Designation,grade.gradename as Grade,st.employeestatus As [Employee Status],
cc.cost_center_name as [Cost Center],cg.cost_center_group_name as [Cost Center Group],app.hike_status as[Hike status],
app.promotion_status as [Promotion Status],app.APP_year
from tbl_intranet_employee_jobDetails jd
inner join tbl_appraisal_assessment app on  app.empcode=jd.empcode
inner JOIN tbl_intranet_designation desig ON jd.degination_id=desig.id    
inner JOIN tbl_internate_departmentdetails dept ON jd.dept_id=dept.departmentid    
inner JOIN tbl_intranet_branch_detail branch ON jd.branch_id=branch.Branch_id    
left JOIN tbl_intranet_grade grade ON jd.grade=grade.id 
left join tbl_intranet_division div on div.ID=jd.division_id  
inner join tbl_intranet_employee_status st on st.id=jd.emp_status
inner join tbl_employee_approvers appr on appr.empcode=jd.empcode
inner join tbl_intranet_employee_jobDetails jd2 on jd2.empcode= appr.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jd3 on jd3.empcode= appr.app_businesshead
inner join tbl_intranet_employee_jobDetails jd4 on jd4.empcode= appr.clr_department
left join tbl_intranet_cost_center_group cg on cg.id=jd.cost_center_group_id
left join tbl_intranet_cost_center cc on jd.cost_center_code=cc.id
where app.hike_status='Approved' and app.promotion_status='Approved' and app.appcycle_id='" + ddl_appraisal_cycle.SelectedValue + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            gvReport.DataSource = ds;
            gvReport.DataBind();
        }
        else
        {
            BindReports();
        }
    }

}