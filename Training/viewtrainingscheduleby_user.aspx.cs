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

public partial class Training_viewtrainingscheduleby_user : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string bodyContent;
    string sqlstr, _userCode, _companyId, RoleId, tid, training_scheduleby;
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

            tid = Request.QueryString["id"].ToString();

            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {
                    //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    // Response.Redirect("~/Authenticate.aspx");
                }
                else
                    Response.Redirect("~/notlogged.aspx");

                bindtriningschedule(tid);
                //Aternominee();
            }
        }
    }

    private void Aternominee()
    {
        string sqlstr = @"select ";

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //trigrid.DataSource = ds;
        //trigrid.DataBind();
    }

    private void bindtriningschedule(string tid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select id,training_code,training_name, ts.createdby,
bd.branch_name,dep.department_name,dt.dept_type_name,
module_name,descriptions,month,bachcode,
CONVERT (varchar(10),fromdate,101) as Fromdate,
CONVERT (varchar(10),todate,101) as Todate,
training_type,training_shortname,year,trainer,faculty,
noofhours,source_internal,
effectiveness_to_be_cond,feedback_to_be_cond,action_plan_to_be_cond,
program,faculty_description,any_other 
from dbo.tbl_training_schedul ts
inner join tbl_intranet_branch_detail bd on ts.branch=bd.branch_id
inner join tbl_internate_department_type dt on ts.dept_type=dt.dept_type_id
inner join tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid
where id = '" + tid + "'";

            DataSet ds1 = new DataSet();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddltrainingcode.Text = ds.Tables[0].Rows[0]["training_code"].ToString();
            txttrainingname.Text = ds.Tables[0].Rows[0]["training_name"].ToString();
            ddl_department.Text = ds.Tables[0].Rows[0]["dept_type_name"].ToString();
            ddl_branch_id.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            //training_scheduleby = ds.Tables[0].Rows[0]["createdby"].ToString();
            ViewState["training_scheduleby"] = ds.Tables[0].Rows[0]["createdby"].ToString();
            //ddl_department.Text;
            lst_deptname.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            txt_module_name.Text = ds.Tables[0].Rows[0]["module_name"].ToString();
            txt_description.Text = ds.Tables[0].Rows[0]["descriptions"].ToString();
            ddl_month.Text = ds.Tables[0].Rows[0]["month"].ToString();
            txt_fromdate.Text = ds.Tables[0].Rows[0]["Fromdate"].ToString();
            txt_bachcode.Text = ds.Tables[0].Rows[0]["bachcode"].ToString();
            ddl_trainingtype.Text = ds.Tables[0].Rows[0]["training_type"].ToString();
            txt_training_short_name.Text = ds.Tables[0].Rows[0]["training_shortname"].ToString();
            ddlyear.Text = ds.Tables[0].Rows[0]["year"].ToString();
            txt_todate.Text = ds.Tables[0].Rows[0]["Todate"].ToString();
            txt_time_of_training.Text = ds.Tables[0].Rows[0]["trainer"].ToString();
            txt_faculty.Text = ds.Tables[0].Rows[0]["faculty"].ToString();
            txt_noofhours.Text = ds.Tables[0].Rows[0]["noofhours"].ToString();
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
    protected void btnsv_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[8];

        sqlparam[0] = new SqlParameter("@training_code", SqlDbType.VarChar, 10);
        sqlparam[0].Value =ddltrainingcode.Text ;

        sqlparam[1] = new SqlParameter("@training_name", SqlDbType.VarChar, 50);
        sqlparam[1].Value =txttrainingname.Text;

        sqlparam[2] = new SqlParameter("@training_id", SqlDbType.Int);
        sqlparam[2].Value = tid;

        sqlparam[3] = new SqlParameter("@branch", SqlDbType.VarChar, (50));
        sqlparam[3].Value =ddl_branch_id.Text;

        sqlparam[4] = new SqlParameter("@dept_type", SqlDbType.VarChar, (50));
        sqlparam[4].Value =ddl_department.Text;

        sqlparam[5] = new SqlParameter("@dept_name", SqlDbType.VarChar, (50));
        sqlparam[5].Value =lst_deptname.Text;

        sqlparam[6] = new SqlParameter("@training_schedule", SqlDbType.VarChar, 20);
        sqlparam[6].Value = ViewState["training_scheduleby"];

        sqlparam[7] = new SqlParameter("@createdby", SqlDbType.VarChar, 20);
        sqlparam[7].Value =_userCode;            

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_department", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_training_Insert_nominee]", sqlparam);


        if (i <= 0)
        {
            SmartHr.Common.Alert("Department name already exists, please enter another name.");
            // message.InnerHtml = "Department name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Nominee Created Successfully!!!");
            btnsv.Visible = false;
            // message.InnerHtml = "Department created successfully";
            // reset();
        }
    }
}