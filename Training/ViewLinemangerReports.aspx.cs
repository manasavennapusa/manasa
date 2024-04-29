using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Training_ViewLinemangerReports : System.Web.UI.Page
{
    string _userCode, _companyId, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

        if (!IsPostBack)
        {
            bindtrainingschedule();
        }
        if (Request.QueryString["upd"] != null)
        {
            SmartHr.Common.Alert("Updated Successfully");
        }
        if (Request.QueryString["notupd"] != null)
        {
            SmartHr.Common.Alert("Not Updated ");
        }

    }

    private void bindtrainingschedule()
    {
            

        string sqlstr = @"select distinct ts.id, ts.training_code as trainingcode,ts.training_name,ts.branch,ts.dept_type,ts.dept_name as dept_id,dept.department_name,
ts.module_name as modulename,ts.descriptions,ts.month,CONVERT(varchar(40), ts.fromdate, 106) as FromDate,
CONVERT(varchar(40), ts.todate, 106) as ToDate,ts.bachcode,ts.training_type,ts.training_shortname,ts.year,
ts.todate,ts.trainer,ts.faculty,ts.noofhours,ts.source_internal,ts.source_external,ts.effectiveness_to_be_cond,
ts.feedback_to_be_cond,ts.action_plan_to_be_cond,ts.program,ts.faculty_description,ts.any_other,ts.createdby,
ts.createddate,ts.status,ts.approverstatus,ts.tds
from tbl_training_schedul ts
left join tbl_internate_departmentdetails dept on dept.departmentid=ts.dept_name";
        //where ts.createdby='" + _userCode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 0)
        {
            return;
        }
        trigrid.DataSource = ds;
        trigrid.DataBind();
    }

    protected void trigrid_PreRender(object sender, EventArgs e)
    {

        if (trigrid.Rows.Count > 0)
        {
            trigrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}