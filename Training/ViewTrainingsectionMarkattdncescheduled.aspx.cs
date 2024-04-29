using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_ViewTrainingsectionMarkattdncescheduled : System.Web.UI.Page
{
    string sqlstr, _userCode, _companyId, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                bind_trainingreq();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["updated"] == "true")
        {
            Common.Console.Output.Show("Submitted Successfully");
        }

    }

    protected void bind_trainingreq()
    {

        string sqlstr = @"select distinct  ts.training_code,ts.id,ts.training_name,ts.createdby,dep.department_name,ts.dept_name,
CONVERT(varchar(40),ts.fromdate,106) as FromDate,CONVERT(varchar(40),ts.todate,106) as ToDate,ts.module_name,
CASE  WHEN ts.faculty LIKE '% %' THEN LEFT(ts.faculty, Charindex(' ', ts.faculty) - 1)
         ELSE ts.faculty
       END as Faculty
from tbl_training_schedul ts
left join tbl_intranet_employee_jobDetails emp on ts.dept_name=emp.dept_id
left join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
where ts.approverstatus='1' and LEFT(ts.faculty, Charindex(' ', ts.faculty) - 1)='" + _userCode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
        {
            return;
        }
        gridtrainingrequest.DataSource = ds;
        gridtrainingrequest.DataBind();
    }


    protected void gridtrainingrequest_PreRender(object sender, EventArgs e)
    {
        if (gridtrainingrequest.Rows.Count > 0)
        {
            gridtrainingrequest.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}