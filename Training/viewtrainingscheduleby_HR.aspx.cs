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

public partial class Training_viewtrainingscheduleby_HR : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    string bodyContent;
    string sqlstr, _userCode, _companyId, RoleId, tid,trainingcode,fromdate,todate,modulename;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();

            //tid = Request.QueryString["id"].ToString();

            if (Request.QueryString["trainingcode"].ToString() != null)
            {
                trainingcode = Request.QueryString["trainingcode"].ToString();
                fromdate = Request.QueryString["FromDate"].ToString();
                todate = Request.QueryString["ToDate"].ToString();
                modulename = Request.QueryString["modulename"].ToString();
            }

            if (!IsPostBack)
            {
                bindtriningschedule(tid);
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }

    private void bindtriningschedule(string tid)
    {
        try
        {
            connection = activity.OpenConnection();
            //            string sqlstr = @"select id,training_code,training_name,
            //bd.branch_name,dep.department_name,dt.dept_type_name, ts.tds,
            //module_name,descriptions,month,bachcode,
            //CONVERT (varchar(10),fromdate,101) as Fromdate,
            //CONVERT (varchar(10),todate,101) as Todate,
            //training_type,training_shortname,year,trainer,faculty,
            //noofhours,source_internal,
            //effectiveness_to_be_cond,feedback_to_be_cond,action_plan_to_be_cond,
            //program,faculty_description,any_other 
            //from dbo.tbl_training_schedul ts
            //inner join tbl_intranet_branch_detail bd on ts.branch=bd.branch_id
            //inner join tbl_internate_department_type dt on ts.dept_type=dt.dept_type_id
            //inner join tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
            //where id = '" + tid + "'";

            string sqlstr = @"select ts.training_code,ts.training_name,
bd.branch_name,dep.department_name,dt.dept_type_name, ts.tds,
ts.module_name,ts.descriptions,ts.month,ts.bachcode,
CONVERT (varchar(40),ts.fromdate,106) as Fromdate,
CONVERT (varchar(40),ts.todate,106) as Todate,
ts.training_type,ts.training_shortname,ts.year,ts.trainer,ts.faculty,
ts.noofhours,ts.source_internal,
ts.effectiveness_to_be_cond,ts.feedback_to_be_cond,ts.action_plan_to_be_cond,
ts.program,ts.faculty_description,ts.any_other 
from dbo.tbl_training_schedul ts
inner join tbl_intranet_branch_detail bd on ts.branch=bd.branch_id
inner join tbl_internate_department_type dt on ts.dept_type=dt.dept_type_id
inner join tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
where ts.training_code='" + trainingcode + "' and CONVERT (varchar(40),ts.fromdate,106)='" + fromdate + "' and CONVERT (varchar(40),ts.todate,106)='" + todate + "'";

            DataSet ds1 = new DataSet();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
            {
                return;
            }
            ddltrainingcode.Text = ds.Tables[0].Rows[0]["training_code"].ToString();
            txttrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
            ddl_department.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString();
            ddl_branch_id.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            //ddl_department.Text;
            lst_deptname.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            txt_module_name.Text = ds.Tables[0].Rows[0]["module_name"].ToString();
            txt_description.Text = ds.Tables[0].Rows[0]["descriptions"].ToString();
            if (ds.Tables[0].Rows[0]["month"].ToString() == "1")
            {
                ddl_month.Text = "Jan";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "2")
            {
                ddl_month.Text = "Feb";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "3")
            {
                ddl_month.Text = "Mar";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "4")
            {
                ddl_month.Text = "Apr";

            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "5")
            {
                ddl_month.Text = "May";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "6")
            {
                ddl_month.Text = "Jun";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "7")
            {
                ddl_month.Text = "Jul";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "8")
            {
                ddl_month.Text = "Aug";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "9")
            {
                ddl_month.Text = "Sep";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "10")
            {
                ddl_month.Text = "Oct";
            }

            if (ds.Tables[0].Rows[0]["month"].ToString() == "11")
            {
                ddl_month.Text = "Nov";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == "12")
            {
                ddl_month.Text = "Dec";
            }
            if (ds.Tables[0].Rows[0]["month"].ToString() == null)
            {
                ddl_month.Text = "";
            }
            txt_fromdate.Text = ds.Tables[0].Rows[0]["Fromdate"].ToString();
            txt_bachcode.Text = ds.Tables[0].Rows[0]["bachcode"].ToString();
            ddl_trainingtype.Text = ds.Tables[0].Rows[0]["training_type"].ToString();
            txt_training_short_name.Text = ds.Tables[0].Rows[0]["training_shortname"].ToString();
            ddlyear.Text = ds.Tables[0].Rows[0]["year"].ToString();
            txt_todate.Text = ds.Tables[0].Rows[0]["Todate"].ToString();
            txt_time_of_training.Text = ds.Tables[0].Rows[0]["trainer"].ToString();
            txt_faculty.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
            txt_noofhours.Text = ds.Tables[0].Rows[0]["noofhours"].ToString();
            //lbltds.Text = ds.Tables[0].Rows[0]["tds"].ToString();
            if (ds.Tables[0].Rows[0]["source_internal"].ToString() == "1")
            {
                rd_internal.Text = "Internal";
            }
            else if (ds.Tables[0].Rows[0]["source_internal"].ToString() == "2")
            {
                rd_internal.Text = "External";
                //rd_internal.Checked = false;
                //rd_external.Checked = true;
            }
            else
            {
                rd_internal.Text = "Null";
                //rd_internal.Checked = false;
                //rd_external.Checked = false;
            }


            if (ds.Tables[0].Rows[0]["effectiveness_to_be_cond"].ToString() == "1")
            {
                rd_training_effectiveness_yes.Text = "Yes";
                //rd_training_effectiveness_yes.Checked = true;
                //rd_training_effectiveness_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["effectiveness_to_be_cond"].ToString() == "2")
            {
                rd_training_effectiveness_yes.Text = "No";
                //rd_training_effectiveness_yes.Checked = false;
                //rd_training_effectiveness_no.Checked = true;
            }
            else
            {
                rd_training_effectiveness_yes.Text = "Null";
                //rd_training_effectiveness_yes.Checked = false;
                //rd_training_effectiveness_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["feedback_to_be_cond"].ToString() == "1")
            {
                rd_training_feedback_yes.Text = "Yes";
                //rd_training_feedback_yes.Checked = true;
                //rd_training_feedback_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["feedback_to_be_cond"].ToString() == "2")
            {
                rd_training_feedback_yes.Text = "No";
                //rd_training_feedback_yes.Checked = false;
                //rd_training_feedback_no.Checked = true;
            }
            else
            {
                rd_training_feedback_yes.Text = "Null";
                //rd_training_feedback_yes.Checked = false;
                //rd_training_feedback_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["action_plan_to_be_cond"].ToString() == "1")
            {
                rd_participants_action_yes.Text = "Yes";
                //rd_participants_action_yes.Checked = true;
                //rd_participants_action_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["action_plan_to_be_cond"].ToString() == "2")
            {
                rd_participants_action_yes.Text = "No";
                //rd_participants_action_yes.Checked = false;
                //rd_participants_action_no.Checked = true;
            }
            else
            {
                rd_participants_action_yes.Text = "Null";
                //rd_participants_action_yes.Checked = false;
                //rd_participants_action_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["program"].ToString() == "1")
            {
                programe_yes.Text = "Yes";
                //programe_yes.Checked = true;
                //programe_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["program"].ToString() == "2")
            {
                programe_yes.Text = "No";
                //programe_yes.Checked = false;
                //programe_no.Checked = true;
            }
            else
            {
                programe_yes.Text = "Null";
                //programe_yes.Checked = false;
                //programe_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["faculty_description"].ToString() == "1")
            {
                facultydescription_yes.Text = "Yes";
                //facultydescription_yes.Checked = true;
                //facultydescription_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["faculty_description"].ToString() == "2")
            {
                facultydescription_yes.Text = "No";
                //facultydescription_yes.Checked = false;
                //facultydescription_no.Checked = true;
            }
            else
            {
                facultydescription_yes.Text = "Null";
                //facultydescription_yes.Checked = false;
                //facultydescription_no.Checked = false;
            }

            if (ds.Tables[0].Rows[0]["any_other"].ToString() == "1")
            {
                anyother_yes.Text = "Yes";
                //anyother_yes.Checked = true;
                //anyother_no.Checked = false;
            }
            else if (ds.Tables[0].Rows[0]["any_other"].ToString() == "2")
            {
                anyother_yes.Text = "No";
                //anyother_yes.Checked = false;
                //anyother_no.Checked = true;
            }
            else
            {
                anyother_yes.Text = "Null";
                //anyother_yes.Checked = false;
                //anyother_no.Checked = false;
            }


        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void ddltrainingcode_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void rd_internal_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void rd_external_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void btnsv_Click(object sender, EventArgs e)
    {

    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewtrainingschedule.aspx");
    }

}