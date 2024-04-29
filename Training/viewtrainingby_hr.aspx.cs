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

public partial class Training_viewtrainingby_hr : System.Web.UI.Page
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

                if (Session["role"] != null)
                {
                }
                else
                {
                    Response.Redirect("~/notlogged.aspx");
                }

                bindtrainingschedule();
                
            }
            if (Request.QueryString["approve"] == "true")
            {
                Output.Show("Approved by HR sucessfully!!!");
            }

        }
    }

    private void bindtrainingschedule()
    {

       // string sqlstr = @"select id,training_name,training_code,department_name,createdby,dept_name from tbl_training_schedul ts
        //                  inner join tbl_internate_departmentdetails dep on ts.dept_name = dep.departmentid where ts.status='0' and ts.approverstatus='0'";


        string sqlstr = @"
select training_code,training_name,bran.branch_name,depty.dept_type_name,dep.department_name,module_name,
month,
(Convert (varchar(10),fromdate,101)) as FromDate,
bachcode,
faculty,
training_type,
training_shortname,
(Convert (varchar(10),todate,101)) as ToDate,
ts.createdby,
ts.id,
app.app_hr as Hr,
year
 from tbl_training_schedul ts
 inner join dbo.tbl_internate_department_type depty on ts.dept_type=depty.dept_type_id
 inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
 inner join dbo.tbl_intranet_branch_detail bran on ts.branch=bran.branch_id
 left join dbo.tbl_employee_approvers app on ts.createdby=app.empcode
 where 
 ts.approverstatus='0' and 
 --ts.id='12' and 
 --ts.createdby='EIN1010' and
 app.app_management='" + _userCode + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 0)
            {
                return;
            }
            gridtraining.DataSource = ds;
            gridtraining.DataBind();
      
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