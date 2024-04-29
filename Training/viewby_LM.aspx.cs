using Common.Console;
using Common.Data;
using Common.Encode;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Smart.HR.Common.Mail.Module;
using DataAccessLayer;
using System.Web.UI.WebControls;

public partial class Training_viewby_LM : System.Web.UI.Page
{
    string sqlstr, _userCode, _companyId, RoleId;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                bindtrainingschedule();
            }
            if (Request.QueryString["approve"] == "true")
            {
                Output.Show("Approved by HR sucessfully!!!");
            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void bindtrainingschedule()
    {

        //        string sqlstr = @"select id,training_name,training_code,department_name,createdby,dept_name from tbl_training_schedul ts
        //                          inner join tbl_internate_departmentdetails dep on ts.dept_name = dep.departmentid where ts.status='0' and ts.approverstatus='1'";

        //        string sqlstr = @"
        //select training_code,training_name,bran.branch_name,depty.dept_type_name,dep.department_name,module_name,ts.id,
        //month,
        //(Convert (varchar(10),fromdate,101)) as FromDate,
        //bachcode,
        //faculty,
        //training_type,
        //training_shortname,
        //(Convert (varchar(10),todate,101)) as ToDate,
        //ts.createdby,
        //ts.dept_name,
        //app.app_reportingmanager as LM,
        //app.app_dotted_linemanager as DLM,
        //app.app_admin as BH,
        //app.app_finance as FM,
        //ts.approverstatus,
        //year
        // from tbl_training_schedul ts
        // inner join dbo.tbl_internate_department_type depty on ts.dept_type=depty.dept_type_id
        // inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
        // inner join dbo.tbl_intranet_branch_detail bran on ts.branch=bran.branch_id
        // left join dbo.tbl_employee_approvers app on ts.createdby=app.empcode
        // where 
        // ts.approverstatus='1' and 
        // app.app_reportingmanager='" + _userCode + "'"; 
        //or app.app_dotted_linemanager='" + _userCode + "'
        //or app.app_businesshead='" + _userCode + "' or app.app_finance='" + _userCode + "')";

        //app.app_reportingmanager='" + _userCode + "'";


//        string sqlstr = @"select distinct training_code,training_name,bran.branch_name,depty.dept_type_name,dep.department_name,ts.module_name,
//month,(Convert (varchar(40),fromdate,106)) as FromDate,bachcode,faculty,training_type,training_shortname,
//(Convert (varchar(40),todate,106)) as ToDate,ts.createdby,ts.dept_name,app.app_reportingmanager as LM,
//app.app_dotted_linemanager as DLM,app.app_admin as BH,app.app_finance as FM,ts.approverstatus,year
//from tbl_training_schedul ts
//inner join dbo.tbl_internate_department_type depty on ts.dept_type=depty.dept_type_id
//inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
//inner join dbo.tbl_intranet_branch_detail bran on ts.branch=bran.branch_id
//inner join dbo.tbl_employee_approvers app on app.app_reportingmanager
//where ts.approverstatus='1' and app.app_reportingmanager='" + _userCode + "'";
        string sqlstr = @"select distinct t2.training_code ,t2.id ,t2.dept_name ,t2.training_name ,(Convert (varchar(40),t2.todate,106)) as ToDate,t2.createdby,
t2.module_name,(Convert (varchar(40),t2.fromdate,106)) as FromDate,t2.status ,t2.branch,dep.department_name,
CASE
         WHEN t2.faculty LIKE '% %' THEN LEFT(t2.faculty, Charindex(' ', t2.faculty) - 1)
         ELSE t2.faculty
       END as Faculty

from tbl_training_schedul t2
inner join tbl_intranet_employee_jobDetails job on job.dept_id=t2.dept_name
inner join tbl_internate_departmentdetails dep on dep.departmentid=job.dept_id
inner join tbl_employee_approvers app on app.app_reportingmanager='" + _userCode+"'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 0)
        {
            return;
        }
        gridtraining.DataSource = ds;
        gridtraining.DataBind();

        //Session["module"]=
    }
    protected void gridtraining_PreRender(object sender, EventArgs e)
    {
        if (gridtraining.Rows.Count > 0)
        {
            gridtraining.UseAccessibleHeader = true;
            gridtraining.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}