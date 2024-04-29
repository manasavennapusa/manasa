using DataAccessLayer;
using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
using Smart.HR.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_viewEffectiveLinemagerfeed : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string bodyContent;
    string sqlstr, _userCode, _companyId, RoleId, employee, backbuton;
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
            backbuton = Request.QueryString["back"].ToString();
            employee = Request.QueryString["empcode"].ToString();


            if (backbuton.ToString() == "0")
            {
                btn_back.Visible = false;
            }
            if (backbuton.ToString() == "1")
            {
                btnBack.Visible = false;
            }
            if (!IsPostBack)
            {
                bindtriningschedule();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["stat1"] != null)
        {
            Output.Show("Effectivefeedback Form Submitted Successfully");
        }
       
    }

    protected void bindtriningschedule()
    {
        try
        {
            connection = activity.OpenConnection();
            //            string sqlstr = @"select distinct ts .id,ts.training_code,elg_emp.trining_id,ts.training_name,ts.module_name,
            //CONVERT(varchar(60),ts.fromdate,106) as FromDate,CONVERT(varchar(60),ts.todate,106) as ToDate,elg_emp.empcode,elg_emp.emp_fname,
            //elg_emp.department_name,ts.trainer,elg_emp.department_name,ts.faculty
            //from tbl_training_schedul ts 
            //inner join tbl_training_mark_attendance trn_mrk_atndnc on ts.training_code=trn_mrk_atndnc.training_code
            //inner join tbl_training_elegible_emp elg_emp on ts.training_code=elg_emp.training_code
            //inner join tbl_training_participants_feedback_form feed_form on ts.training_name=feed_form.training_name where elg_emp.empcode='" + employee + "'";


            string sqlstr = @"select distinct ts .id,ts.training_code,elg_emp.trining_id,ts.training_name,ts.module_name,
CONVERT(varchar(60),elg_emp.fromdate,106) as FromDate,CONVERT(varchar(60),elg_emp.todate,106) as ToDate,elg_emp.empcode,elg_emp.emp_fname,
elg_emp.department_name,ts.trainer,elg_emp.department_name,ts.faculty,implm.empname,implm.approverstatus,implm.Lmcomments,
implm.rating_before_prog,implm.rating_after_prog,implm.area_of_improvement_1,implm.area_of_improvement_2,
implm.area_of_improvement_3,implm.area_of_improvement_4,implm.area_of_improvement_5,implm.meets_current_reqirement_1,
implm.meets_current_reqirement_2,implm.meets_current_reqirement_3,implm.meets_current_reqirement_4,implm.meets_current_reqirement_5,
implm.needs_improvement_1,implm.needs_improvement_2,implm.needs_improvement_3,needs_improvement_4,implm.needs_improvement_5,
implm.significant_improvement_1,implm.significant_improvement_2,implm.significant_improvement_3,implm.significant_improvement_4,
implm.significant_improvement_5,implm.meets_current_requirement_1,implm.meets_current_requirement_2,implm.meets_current_requirement_3,
implm.meets_current_requirement_4,implm.meets_current_requirement_5,implm.supervisor,implm.remarks_by_supervisor,implm.need_to_improve
from tbl_training_schedul ts 
inner join tbl_training_mark_attendance trn_mrk_atndnc on ts.training_code=trn_mrk_atndnc.training_code
inner join tbl_training_elegible_emp elg_emp on ts.training_code=elg_emp.training_code
inner join tbl_training_participants_feedback_form feed_form on ts.training_name=feed_form.training_name
inner join tbl_training_effectivefeedback_for_improvement implm on implm.empcode=elg_emp.empcode
where elg_emp.empcode='" + employee + "'";


            DataSet ds1 = new DataSet();
            ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 0)
            {
                return;
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["training_name"].ToString() != "")
                {
                    txtcmpname.Text = ds1.Tables[0].Rows[0]["training_name"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["empcode"].ToString() != "")
                {
                    txt_empcode.Text = ds1.Tables[0].Rows[0]["empcode"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["trainer"].ToString() != "")
                {
                    txtvenue.Text = ds1.Tables[0].Rows[0]["trainer"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["department_name"].ToString() != "")
                {
                    txt_dept.Text = ds1.Tables[0].Rows[0]["department_name"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["FromDate"].ToString() != "")
                {
                    txt_frm_date.Text = ds1.Tables[0].Rows[0]["FromDate"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["emp_fname"].ToString() != "")
                {
                    txt_emp_name.Text = ds1.Tables[0].Rows[0]["emp_fname"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["faculty"].ToString() != "")
                {
                    txt_conducted_by.Text = ds1.Tables[0].Rows[0]["faculty"].ToString();
                }
                if (ds1.Tables[0].Rows[0]["ToDate"].ToString() != "")
                {
                    Label1.Text = ds1.Tables[0].Rows[0]["ToDate"].ToString();
                }

            }
            txt_rt_before_prog.Text = ds1.Tables[0].Rows[0]["rating_before_prog"].ToString();
            txt_rt_after_prog.Text = ds1.Tables[0].Rows[0]["rating_after_prog"].ToString();
            txt_area_of_improvement_1.Text = ds1.Tables[0].Rows[0]["area_of_improvement_1"].ToString();
            txt_meets_current_recuiremnt_1.Text = ds1.Tables[0].Rows[0]["meets_current_reqirement_1"].ToString();
            txt_need_improvement_1.Text = ds1.Tables[0].Rows[0]["needs_improvement_1"].ToString();
            txt_significant_imprvemnt_1.Text = ds1.Tables[0].Rows[0]["significant_improvement_1"].ToString();
            txt_current_requirement_1.Text = ds1.Tables[0].Rows[0]["meets_current_requirement_1"].ToString();
            txt_area_of_improvement_2.Text = ds1.Tables[0].Rows[0]["area_of_improvement_2"].ToString();
            txt_meets_current_recuiremnt_2.Text = ds1.Tables[0].Rows[0]["meets_current_reqirement_2"].ToString();
            txt_need_improvement_2.Text = ds1.Tables[0].Rows[0]["needs_improvement_2"].ToString();
            txt_significant_imprvemnt_2.Text = ds1.Tables[0].Rows[0]["significant_improvement_2"].ToString();
            txt_current_requirement_2.Text = ds1.Tables[0].Rows[0]["meets_current_requirement_2"].ToString();
            txt_area_of_improvement_3.Text = ds1.Tables[0].Rows[0]["area_of_improvement_3"].ToString();
            txt_meets_current_recuiremnt_3.Text = ds1.Tables[0].Rows[0]["meets_current_reqirement_3"].ToString();
            txt_need_improvement_3.Text = ds1.Tables[0].Rows[0]["needs_improvement_3"].ToString();
            txt_significant_imprvemnt_3.Text = ds1.Tables[0].Rows[0]["significant_improvement_3"].ToString();
            txt_current_requirement_3.Text = ds1.Tables[0].Rows[0]["meets_current_requirement_3"].ToString();
            txt_area_of_improvement_4.Text = ds1.Tables[0].Rows[0]["area_of_improvement_4"].ToString();
            txt_meets_current_recuiremnt_4.Text = ds1.Tables[0].Rows[0]["meets_current_reqirement_4"].ToString();
            txt_need_improvement_4.Text = ds1.Tables[0].Rows[0]["needs_improvement_4"].ToString();
            txt_significant_imprvemnt_4.Text = ds1.Tables[0].Rows[0]["significant_improvement_4"].ToString();
            txt_current_requirement_4.Text = ds1.Tables[0].Rows[0]["meets_current_requirement_4"].ToString();
            txt_area_of_improvement_5.Text = ds1.Tables[0].Rows[0]["area_of_improvement_5"].ToString();
            txt_meets_current_recuiremnt_5.Text = ds1.Tables[0].Rows[0]["meets_current_reqirement_5"].ToString();
            txt_need_improvement_5.Text = ds1.Tables[0].Rows[0]["needs_improvement_5"].ToString();
            txt_significant_imprvemnt_5.Text = ds1.Tables[0].Rows[0]["significant_improvement_5"].ToString();
            txt_current_requirement_5.Text = ds1.Tables[0].Rows[0]["meets_current_requirement_5"].ToString();
            txt_employee_name.Text = ds1.Tables[0].Rows[0]["empname"].ToString();
            txt_supervisor.Text = ds1.Tables[0].Rows[0]["supervisor"].ToString();
            txt_remarks_by_supervisor.Text = ds1.Tables[0].Rows[0]["remarks_by_supervisor"].ToString();
            txt_need_to_improve.Text = ds1.Tables[0].Rows[0]["need_to_improve"].ToString();
            if (ds1.Tables[0].Rows[0]["approverstatus"].ToString() == "1")
            {
                btn_submit.Visible = false;
                //btn_reset.Visible = false;
                txtcomments.Text = ds1.Tables[0].Rows[0]["Lmcomments"].ToString();
                txtcomments.Enabled = false;
            }
            else
            {
                btn_submit.Visible = true;
                //btn_reset.Visible = true;
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

    protected void Reset()
    {
        txt_rt_before_prog.Text = "";
        txt_rt_after_prog.Text = "";
        txt_area_of_improvement_1.Text = "";
        txt_meets_current_recuiremnt_1.Text = "";
        txt_need_improvement_1.Text = "";
        txt_significant_imprvemnt_1.Text = "";
        txt_current_requirement_1.Text = "";
        txt_area_of_improvement_2.Text = "";
        txt_meets_current_recuiremnt_2.Text = "";
        txt_need_improvement_2.Text = "";
        txt_significant_imprvemnt_2.Text = "";
        txt_current_requirement_2.Text = "";
        txt_area_of_improvement_3.Text = "";
        txt_meets_current_recuiremnt_3.Text = "";
        txt_need_improvement_3.Text = "";
        txt_significant_imprvemnt_3.Text = "";
        txt_current_requirement_3.Text = "";
        txt_area_of_improvement_4.Text = "";
        txt_meets_current_recuiremnt_4.Text = "";
        txt_need_improvement_4.Text = "";
        txt_significant_imprvemnt_4.Text = "";
        txt_current_requirement_4.Text = "";
        txt_area_of_improvement_5.Text = "";
        txt_meets_current_recuiremnt_5.Text = "";
        txt_need_improvement_5.Text = "";
        txt_significant_imprvemnt_5.Text = "";
        txt_current_requirement_5.Text = "";
        txt_employee_name.Text = "";
        txt_supervisor.Text = "";
        txt_remarks_by_supervisor.Text = "";
        txt_need_to_improve.Text = "";

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        int i = 0;
        try
        {
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 60, txt_empcode.Text);
            Output.AssignParameter(sqlparam, 1, "@lmcomments", "String", 500, txtcomments.Text);
            //Output.AssignParameter(sqlparam, 2, "@rating_before_prog", "String", 500, txt_rt_before_prog.Text);
            //Output.AssignParameter(sqlparam, 3, "@rating_after_prog", "String", 500, txt_rt_after_prog.Text);

            //Output.AssignParameter(sqlparam, 4, "@area_of_improvement_1", "String", 500, txt_area_of_improvement_1.Text);
            //Output.AssignParameter(sqlparam, 5, "@area_of_improvement_2", "String", 500, txt_area_of_improvement_2.Text);
            //Output.AssignParameter(sqlparam, 6, "@area_of_improvement_3", "String", 500, txt_area_of_improvement_3.Text);
            //Output.AssignParameter(sqlparam, 7, "@area_of_improvement_4", "String", 500, txt_area_of_improvement_4.Text);
            //Output.AssignParameter(sqlparam, 8, "@area_of_improvement_5", "String", 500, txt_area_of_improvement_5.Text);

            //Output.AssignParameter(sqlparam, 9, "@meets_current_reqirement_1", "String", 500, txt_meets_current_recuiremnt_1.Text);
            //Output.AssignParameter(sqlparam, 10, "@meets_current_reqirement_2", "String", 500, txt_meets_current_recuiremnt_2.Text);
            //Output.AssignParameter(sqlparam, 11, "@meets_current_reqirement_3", "String", 500, txt_meets_current_recuiremnt_3.Text);
            //Output.AssignParameter(sqlparam, 12, "@meets_current_reqirement_4", "String", 500, txt_meets_current_recuiremnt_4.Text);
            //Output.AssignParameter(sqlparam, 13, "@meets_current_reqirement_5", "String", 500, txt_meets_current_recuiremnt_5.Text);

            //Output.AssignParameter(sqlparam, 14, "@needs_improvement_1", "String", 500, txt_need_improvement_1.Text);
            //Output.AssignParameter(sqlparam, 15, "@needs_improvement_2", "String", 500, txt_need_improvement_2.Text);
            //Output.AssignParameter(sqlparam, 16, "@needs_improvement_3", "String", 500, txt_need_improvement_3.Text);
            //Output.AssignParameter(sqlparam, 17, "@needs_improvement_4", "String", 500, txt_need_improvement_4.Text);
            //Output.AssignParameter(sqlparam, 18, "@needs_improvement_5", "String", 500, txt_need_improvement_5.Text);

            //Output.AssignParameter(sqlparam, 19, "@significant_improvement_1", "String", 500, txt_significant_imprvemnt_1.Text);
            //Output.AssignParameter(sqlparam, 20, "@significant_improvement_2", "String", 500, txt_significant_imprvemnt_2.Text);
            //Output.AssignParameter(sqlparam, 21, "@significant_improvement_3", "String", 500, txt_significant_imprvemnt_3.Text);
            //Output.AssignParameter(sqlparam, 22, "@significant_improvement_4", "String", 500, txt_significant_imprvemnt_4.Text);
            //Output.AssignParameter(sqlparam, 23, "@significant_improvement_5", "String", 500, txt_significant_imprvemnt_5.Text);

            //Output.AssignParameter(sqlparam, 24, "@meets_current_requirement_1", "String", 500, txt_current_requirement_1.Text);
            //Output.AssignParameter(sqlparam, 25, "@meets_current_requirement_2", "String", 500, txt_current_requirement_2.Text);
            //Output.AssignParameter(sqlparam, 26, "@meets_current_requirement_3", "String", 500, txt_current_requirement_3.Text);
            //Output.AssignParameter(sqlparam, 27, "@meets_current_requirement_4", "String", 500, txt_current_requirement_4.Text);
            //Output.AssignParameter(sqlparam, 28, "@meets_current_requirement_5", "String", 500, txt_current_requirement_5.Text);

            //Output.AssignParameter(sqlparam, 29, "@supervisor", "String", 500, txt_supervisor.Text);
            //Output.AssignParameter(sqlparam, 30, "@remarks_by_supervisor", "String", 500, txt_remarks_by_supervisor.Text);
            //Output.AssignParameter(sqlparam, 31, "@need_to_improve", "String", 500, txt_need_to_improve.Text);
            //Output.AssignParameter(sqlparam, 32, "@created_by", "String", 60, _userCode);
            //Output.AssignParameter(sqlparam, 1, "@lmcomments", "string", 500, txtcomments.Text.Trim().ToString());
            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_effectivefeedback_for_improvement_lmcomments]", sqlparam);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (i > 0)
            {
                Response.Redirect("linemangereffectiveFeedback.aspx?stat1=true");
            }
        }

    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Training/linemangereffectiveFeedback.aspx");
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("viewbyHR_addparticipent.aspx");
        Response.Redirect("~/Training/TraineeView_Effectivefeed.aspx");
    }
}
