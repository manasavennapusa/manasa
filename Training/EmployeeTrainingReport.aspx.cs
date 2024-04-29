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
public partial class Training_EmployeeTrainingReport : System.Web.UI.Page
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
        //if (Request.QueryString["updated"] == "true")
        //{
        //    Common.Console.Output.Show("Submitted Successfully");
        //}

    }

    protected void bind_trainingreq()
    {

        string sqlstr = @"select distinct ts.createdby, ts.id, db.department_name,ts.dept_name,
el_emp.designationname,el_emp.training_code,el_emp.training_name,el_emp.trining_id,el_emp.status,
(Convert (varchar(40),el_emp.fromdate,106)) as FromDate,(Convert (varchar(40),el_emp.todate,106)) as ToDate,ts.module_name,
CASE  WHEN ts.faculty LIKE '% %' THEN LEFT(ts.faculty, Charindex(' ', ts.faculty) - 1)
         ELSE ts.faculty
       END as Faculty
from tbl_training_elegible_emp el_emp
inner join tbl_training_schedul ts on ts.training_code=el_emp.training_code  and el_emp.modulename=ts.module_name
inner join tbl_internate_departmentdetails db on db.departmentid=ts.dept_name  and el_emp.department_name=db.department_name
and ts.fromdate=el_emp.fromdate
where ts.approverstatus='1' and el_emp.empcode='" + _userCode + "'";
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