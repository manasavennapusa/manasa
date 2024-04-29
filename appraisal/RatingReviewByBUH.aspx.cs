using System;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;


public partial class appraisal_RatingReviewByBUH : System.Web.UI.Page
{
    string EmployeeCode = "";
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    decimal compmgrratingweightagetotal = 0;
    decimal cmpratingweightagetotal = 0;
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    int totalrating;
    int x, y, z, s, a, b, c, d, e, f;
    int i = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        UserCode = Session["empcode"].ToString();
        //EmployeeCode = Request.QueryString["empcode"].ToString();
        getActiveCycle();
        if (!IsPostBack)
        {
            if (gveligible.Rows.Count <= 0) gveligible.EmptyDataText = "No Records Found";
            bindgrid();
            empsearch.Visible = true;
            if (Request.QueryString["empcode"] != null)
            {
                EmployeeCode = Request.QueryString["empcode"].ToString();
                empdetails.Visible = true;
                empsearch.Visible = false;
                emplist.Visible = false;
                bindEmpDetails(EmployeeCode);
                bindratingrid();
                //bindGoals(EmployeeCode);
                //gvGoals_RowDataBound();
                bindtraining(EmployeeCode);
                if (lblAvgRatingGoals.Text != "")
                {
                    lblMgrOverallRating.Text = Convert.ToString(Math.Round(Convert.ToDouble(lblAvgRatingGoals.Text == "" ? "0" : lblAvgRatingGoals.Text), 0));
                    bindBehaviorgrid();
                }
            }
            
            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Rating Submitted Successfully.");
            }
        }
        calculaterating();
    }

    protected void bindtraining(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,mgr_overall_rating,mgr_overall_cmt,behavior_color from tbl_appraisal_assessment where  status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + empcode + "' ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txttraining.Text = ds.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblOverallRating.Text = ds.Tables[0].Rows[0]["emp_overall_rating"].ToString();
                txtOverallComments.Text = ds.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                lblMgrOverallRating.Text = ds.Tables[0].Rows[0]["mgr_overall_rating"].ToString();
                txtMgroverallcomments.Text = ds.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                //if (ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim() != "")
                // lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml(ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim());
            }
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

    private void getActiveCycle()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1";
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str1);
            if (cnt > 0)
            {
               int cycle = (int)SQLServer.ExecuteScalar(Connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    Session["appcycle"] = cycle;
                }
                else
                {
                    Output.Show("Please Mark Active Appraisal Cycle");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
            }
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

    protected void btn_search_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query1);
            string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
            string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();


            //Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            ////Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            //Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            //Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, ddl_dept.SelectedValue);

            //DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_get_EmpforBUHratings", sqlparam);

            string str = @"select app.appcycle_id,isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,    
empdesg.designationname as designation,
empdept.department_name as dept,app.R_cycle,aprs.app_businesshead
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_assessment app on app.empcode= empjob.empcode
 inner join tbl_appraisal_eligible_employee empappr on app.empcode=empappr.empcode and empappr.appcycle_id=app.appcycle_id 
inner join tbl_employee_approvers aprs on aprs.empcode=app.empcode 
inner join tbl_appraisal_approver_LM_rating_details lm_rtng on empjob.empcode=lm_rtng.empcode and app.APP_year=lm_rtng.APP_year and lm_rtng.quater=app.quater
where 1=1 and app.R_cycle=3 and app.status in(1,3) and empjob.emp_status in(1,3)  
and aprs.app_businesshead='" + UserCode + "' and empjob.empcode='" + txt_employee.Text + "' and empdept.department_name='" + ddl_dept.SelectedItem.Text + "' and rating.quater='" + quater + "' and rating.APP_year='" + APP_year + "' and  lm_rtng.applycyclid=" + Session["appcycle"].ToString() + " order by empjob.empcode ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gveligible.DataSource = ds;
            gveligible.DataBind();
            ViewState["Getemp"] = ds;
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

    protected void ddl_dept_DataBound(object sender, EventArgs e)
    {
        ddl_dept.Items.Insert(0, new ListItem("----- All -----", "0"));
    }

    private void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query1);
            string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
            string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();

            //Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            ////Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
            //Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            //Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");

            //DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_EmpforBUHratings", sqlparam);

            string str = @"select app.appcycle_id,isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,    
empdesg.designationname as designation,
empdept.department_name as dept,app.R_cycle,aprs.app_businesshead
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_assessment app on app.empcode= empjob.empcode
 inner join tbl_appraisal_eligible_employee empappr on app.empcode=empappr.empcode and empappr.appcycle_id=app.appcycle_id 
inner join tbl_employee_approvers aprs on aprs.empcode=app.empcode 
inner join tbl_appraisal_approver_LM_rating_details lm_rtng on empjob.empcode=lm_rtng.empcode and app.APP_year=lm_rtng.APP_year and lm_rtng.quater=app.quater
where 1=1 and app.R_cycle=3 and app.status in(1,3) and empjob.emp_status in(1,3)  
and aprs.app_businesshead='" + UserCode + "' and lm_rtng.quater='" + quater + "' and lm_rtng.APP_year='" + APP_year + "' and  lm_rtng.applycyclid=" + Session["appcycle"].ToString() + " order by empjob.empcode ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text,str);

            gveligible.DataSource = ds;
            gveligible.DataBind();
            ViewState["Getemp"] = ds;
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

    protected void bindEmpDetails(string empcode)
    {
        SqlParameter[] sqlparam1 = new SqlParameter[2];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, empcode);
            Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());

            DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_getEmployeeDetails", sqlparam1);
            if (dse.Tables[0].Rows.Count >= 1)
            {
                lblempname.Text = dse.Tables[0].Rows[0]["name"].ToString();
                lblempcode.Text = dse.Tables[0].Rows[0]["empcode"].ToString();
                lbldept.Text = dse.Tables[0].Rows[0]["dept"].ToString();
                lbldesignation.Text = dse.Tables[0].Rows[0]["designation"].ToString();
                lblrole.Text = dse.Tables[0].Rows[0]["role"].ToString();
                lblmanager.Text = dse.Tables[0].Rows[0]["manager"].ToString();
                txttraining.Text = dse.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblReview.Text = dse.Tables[0].Rows[0]["app_cycle"].ToString();
                //lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
            }

           //string query = @"select * from tbl_appraisal_rating_details_1 where empcode='" + empcode + "'";

            string query = @"select * from tbl_appraisal_rating_details_1 where empcode='" + empcode + "' and applycyclid=" + Session["appcycle"].ToString() + " order by id desc";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

            string query_1 = @"select * from tbl_appraisal_rating_details_1_for_cycle_2 where empcode='" + empcode + "' and applycyclid=" + Session["appcycle"].ToString() + " order by id desc";

            //string query_1 = @"select top 1 * from tbl_appraisal_approver_LM_rating_details_for_cycle_2 where empcode='" + empcode + "' order by id desc";
            DataSet ds_2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query_1);

            if (ds_2.Tables[0].Rows.Count < 1)
            {

                if (ds.Tables[0].Rows.Count > 0)
                {
                    drp_skils.SelectedItem.Text = ds.Tables[0].Rows[0]["fun_skill_rating"].ToString();
                    txt_skill_cmnt.Text = ds.Tables[0].Rows[0]["fun_skill_cmnt"].ToString();
                    drp_quality.SelectedItem.Text = ds.Tables[0].Rows[0]["quality_rating"].ToString();
                    txt_quality_cmnt.Text = ds.Tables[0].Rows[0]["quality_cmnt"].ToString();
                    drp_comm.SelectedItem.Text = ds.Tables[0].Rows[0]["comm_skill_rating"].ToString();
                    txt_comm.Text = ds.Tables[0].Rows[0]["comm_skill_cmnt"].ToString();
                    drp_self.SelectedItem.Text = ds.Tables[0].Rows[0]["self_devlop_rating"].ToString();
                    txt_self.Text = ds.Tables[0].Rows[0]["self_devlop_cmnt"].ToString();
                    drp_pro.SelectedItem.Text = ds.Tables[0].Rows[0]["procs_knowldge_rating"].ToString();
                    txt_pro.Text = ds.Tables[0].Rows[0]["procs_knowldge_cmnt"].ToString();
                    drp_team.SelectedItem.Text = ds.Tables[0].Rows[0]["team_participation_rating"].ToString();
                    txt_team.Text = ds.Tables[0].Rows[0]["team_participation_cmnt"].ToString();
                    drp_commit.SelectedItem.Text = ds.Tables[0].Rows[0]["commitment_rating"].ToString();
                    txt_commit.Text = ds.Tables[0].Rows[0]["commitment_cmnt"].ToString();
                    drp_client.SelectedItem.Text = ds.Tables[0].Rows[0]["clnt_cust_orntion_rating"].ToString();
                    txt_client.Text = ds.Tables[0].Rows[0]["clnt_cust_orntion_cmnt"].ToString();
                    drp_plan.SelectedItem.Text = ds.Tables[0].Rows[0]["team_planing_rating"].ToString();
                    txt_plan.Text = ds.Tables[0].Rows[0]["team_planing_cmnt"].ToString();
                    drp_mentor.SelectedItem.Text = ds.Tables[0].Rows[0]["mentoring_leadrsip_rating"].ToString();
                    txt_mentor.Text = ds.Tables[0].Rows[0]["mentoring_leadrsip_cmnt"].ToString();
                    txtappr.Text = ds.Tables[0].Rows[0]["achievment_of_past_year"].ToString();
                    txt_training.Text = ds.Tables[0].Rows[0]["training_benefits_to_develop"].ToString();
                    txtcmnt_aap.Text = ds.Tables[0].Rows[0]["additional_cmnt"].ToString();

                }
            }
            else
            {
                if (ds_2.Tables[0].Rows.Count > 0)
                {
                    drp_skils.SelectedItem.Text = ds_2.Tables[0].Rows[0]["fun_skill_rating"].ToString();
                    txt_skill_cmnt.Text = ds_2.Tables[0].Rows[0]["fun_skill_cmnt"].ToString();
                    drp_quality.SelectedItem.Text = ds_2.Tables[0].Rows[0]["quality_rating"].ToString();
                    txt_quality_cmnt.Text = ds_2.Tables[0].Rows[0]["quality_cmnt"].ToString();
                    drp_comm.SelectedItem.Text = ds_2.Tables[0].Rows[0]["comm_skill_rating"].ToString();
                    txt_comm.Text = ds_2.Tables[0].Rows[0]["comm_skill_cmnt"].ToString();
                    drp_self.SelectedItem.Text = ds_2.Tables[0].Rows[0]["self_devlop_rating"].ToString();
                    txt_self.Text = ds_2.Tables[0].Rows[0]["self_devlop_cmnt"].ToString();
                    drp_pro.SelectedItem.Text = ds_2.Tables[0].Rows[0]["procs_knowldge_rating"].ToString();
                    txt_pro.Text = ds_2.Tables[0].Rows[0]["procs_knowldge_cmnt"].ToString();
                    drp_team.SelectedItem.Text = ds_2.Tables[0].Rows[0]["team_participation_rating"].ToString();
                    txt_team.Text = ds_2.Tables[0].Rows[0]["team_participation_cmnt"].ToString();
                    drp_commit.SelectedItem.Text = ds_2.Tables[0].Rows[0]["commitment_rating"].ToString();
                    txt_commit.Text = ds_2.Tables[0].Rows[0]["commitment_cmnt"].ToString();
                    drp_client.SelectedItem.Text = ds_2.Tables[0].Rows[0]["clnt_cust_orntion_rating"].ToString();
                    txt_client.Text = ds_2.Tables[0].Rows[0]["clnt_cust_orntion_cmnt"].ToString();
                    drp_plan.SelectedItem.Text = ds_2.Tables[0].Rows[0]["team_planing_rating"].ToString();
                    txt_plan.Text = ds_2.Tables[0].Rows[0]["team_planing_cmnt"].ToString();
                    drp_mentor.SelectedItem.Text = ds_2.Tables[0].Rows[0]["mentoring_leadrsip_rating"].ToString();
                    txt_mentor.Text = ds_2.Tables[0].Rows[0]["mentoring_leadrsip_cmnt"].ToString();
                    txtappr.Text = ds_2.Tables[0].Rows[0]["achievment_of_past_year"].ToString();
                    txt_training.Text = ds_2.Tables[0].Rows[0]["training_benefits_to_develop"].ToString();
                    txtcmnt_aap.Text = ds_2.Tables[0].Rows[0]["additional_cmnt"].ToString();
                    //txt_add_cmnt.Text = ds_2.Tables[0].Rows[0]["additional_cmnt_1"].ToString();

                }
            }

            //string strq = @"select * from tbl_appraisal_approver_LM_rating_details where empcode='" + empcode + "'";
            string strq = @"select * from tbl_appraisal_approver_LM_rating_details where empcode='" + empcode + "'  and applycyclid=" + Session["appcycle"].ToString() + "  order by id desc";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq);

            string strq1 = @"select * from tbl_appraisal_approver_LM_rating_details_for_cycle_2 where empcode='" + empcode + "' and applycyclid=" + Session["appcycle"].ToString() + "  order by id desc";
            DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq1);

            if (ds2.Tables[0].Rows.Count < 1)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
         
                    drp_skils_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_fun_skill_rating"].ToString();
                    txt_skils_app.Text = ds1.Tables[0].Rows[0]["LM_fun_skill_cmnt"].ToString();
                    drp_quality_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_quality_rating"].ToString();
                    txt_quality_app.Text = ds1.Tables[0].Rows[0]["LM_quality_cmnt"].ToString();
                    drp_comm_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_comm_skill_rating"].ToString();
                    txt_comm_app.Text = ds1.Tables[0].Rows[0]["LM_comm_skill_cmnt"].ToString();
                    drp_self_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_self_devlop_rating"].ToString();
                    txt_self_app.Text = ds1.Tables[0].Rows[0]["LM_self_devlop_cmnt"].ToString();
                    drp_pro_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_procs_knowldge_rating"].ToString();
                    txt_pro_app.Text = ds1.Tables[0].Rows[0]["LM_procs_knowldge_cmnt"].ToString();
                    drp_team_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_team_participation_rating"].ToString();
                    txt_team_app.Text = ds1.Tables[0].Rows[0]["LM_team_participation_cmnt"].ToString();
                    drp_commit_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_commitment_rating"].ToString();
                    txt_commit_app.Text = ds1.Tables[0].Rows[0]["LM_commitment_cmnt"].ToString();
                    drp_client_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_clnt_cust_orntion_rating"].ToString();
                    txt_client_app.Text = ds1.Tables[0].Rows[0]["LM_clnt_cust_orntion_cmnt"].ToString();
                    drp_plan_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_team_planing_rating"].ToString();
                    txt_plan_app.Text = ds1.Tables[0].Rows[0]["LM_team_planing_cmnt"].ToString();
                    drp_mentor_app.SelectedValue = ds1.Tables[0].Rows[0]["LM_mentoring_leadrsip_rating"].ToString();
                    txt_mentor_app.Text = ds1.Tables[0].Rows[0]["LM_mentoring_leadrsip_cmnt"].ToString();
                    //txt_LM_comment.Text = ds1.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                    txtcmnt_appr_1.Text = ds1.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                    txt_BH_cmnt.Text = ds1.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                }
            }
            else
            {
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    drp_skils_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_fun_skill_rating"].ToString();
                    txt_skils_app.Text = ds2.Tables[0].Rows[0]["LM_fun_skill_cmnt"].ToString();
                    drp_quality_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_quality_rating"].ToString();
                    txt_quality_app.Text = ds2.Tables[0].Rows[0]["LM_quality_cmnt"].ToString();
                    drp_comm_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_comm_skill_rating"].ToString();
                    txt_comm_app.Text = ds2.Tables[0].Rows[0]["LM_comm_skill_cmnt"].ToString();
                    drp_self_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_self_devlop_rating"].ToString();
                    txt_self_app.Text = ds2.Tables[0].Rows[0]["LM_self_devlop_cmnt"].ToString();
                    drp_pro_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_procs_knowldge_rating"].ToString();
                    txt_pro_app.Text = ds2.Tables[0].Rows[0]["LM_procs_knowldge_cmnt"].ToString();
                    drp_team_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_team_participation_rating"].ToString();
                    txt_team_app.Text = ds2.Tables[0].Rows[0]["LM_team_participation_cmnt"].ToString();
                    drp_commit_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_commitment_rating"].ToString();
                    txt_commit_app.Text = ds2.Tables[0].Rows[0]["LM_commitment_cmnt"].ToString();
                    drp_client_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_clnt_cust_orntion_rating"].ToString();
                    txt_client_app.Text = ds2.Tables[0].Rows[0]["LM_clnt_cust_orntion_cmnt"].ToString();
                    drp_plan_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_team_planing_rating"].ToString();
                    txt_plan_app.Text = ds2.Tables[0].Rows[0]["LM_team_planing_cmnt"].ToString();
                    drp_mentor_app.SelectedValue = ds2.Tables[0].Rows[0]["LM_mentoring_leadrsip_rating"].ToString();
                    txt_mentor_app.Text = ds2.Tables[0].Rows[0]["LM_mentoring_leadrsip_cmnt"].ToString();
                    //txt_LM_comment.Text = ds1.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                    txtcmnt_appr_1.Text = ds2.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                    //txt_BH_cmnt.Text = ds2.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                    txt_BH_cmnt.Text = ds1.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                }
            }
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

    private void bindratingrid()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select rating_id,rating,description from dbo.tbl_appraisal_rating order by rating_id desc";
            gridratings.DataSource = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gridratings.DataBind();

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

//    protected void bindGoals(string empcode)
//    {
//        SqlConnection Connection = null;
//        try
//        {
//            Connection = DataActivity.OpenConnection();
//            //string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage ,sd.empcomments,sd.emprating from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1 and apt.R_cycle=3  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
//            string str = @"select aps.asd_id,aps.role,
//aps.kca,aps.kpi,sd.parameter,aps.weightage,aps.emp_comments,
//aps.mng_comments  ,sd.empcomments,sd.emprating,sd.mgrcomments,
//sd.mgrrating,apt.empcode,apt.R_cycle 
//from tbl_appraisal_assessment_details aps 
//inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id 
//inner join tbl_appraisal_assessment apt on sd.initializeid=apt.assessment_id  where apt.status=1 and apt.R_cycle=3  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
//            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
//            gvGoals.DataSource = ds;
//            gvGoals.DataBind();
//            if (ds.Tables[0].Rows.Count > 0)
//            {
//                if (ds.Tables[0].Rows[0]["mgrrating"].ToString() != "")
//                {
//                    gvGoals.Columns[9].Visible = false;
//                }
//                else
//                {
//                    gvGoals.Columns[9].Visible = false;
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
//            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
//        }
//        finally
//        {
//            DataActivity.CloseConnection();
//        }
//    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string query12 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query12);
            string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
            string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();

            EmployeeCode = Request.QueryString["empcode"].ToString();
          
            //mgr_overall_rating='" + lblMgrOverallRating.Text + "'

            string query_1 = @"select * from tbl_appraisal_approver_LM_rating_details where empcode='" + EmployeeCode + "' and applycyclid=" + Convert.ToInt32(Session["appcycle"]) + " and quater='" + quater + "' and APP_year='" + APP_year + "'";
            DataSet ds_1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query_1);

            string strq1 = @"select * from tbl_appraisal_approver_LM_rating_details_for_cycle_2 where empcode='" + EmployeeCode + "' and applycyclid=" + Convert.ToInt32(Session["appcycle"]) + " order by id desc";
            DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq1);


            //if (ds_1.Tables[0].Rows[0]["updated_by"].ToString() == "")
            //if (ds1.Tables[0].Rows[0]["quater"].ToString() == "Q1")
            if (ds_1.Tables[0].Rows.Count == 1)
            {
                string str = @"update tbl_appraisal_approver_LM_rating_details set LM_fun_skill_rating='" + drp_skils_app.SelectedItem.Text + "',LM_fun_skill_cmnt='" + txt_skils_app.Text + "',LM_quality_rating='" + drp_quality_app.SelectedItem.Text + "',LM_quality_cmnt='" + txt_quality_app.Text + "',LM_comm_skill_rating='" + drp_comm_app.SelectedItem.Text + "',LM_comm_skill_cmnt='" + txt_comm_app.Text + "',LM_self_devlop_rating='" + drp_self_app.SelectedItem.Text + "',LM_self_devlop_cmnt='" + txt_self_app.Text + "',LM_procs_knowldge_rating='" + drp_pro_app.SelectedItem.Text + "',LM_procs_knowldge_cmnt='" + txt_pro_app.Text + "',LM_team_participation_rating='" + drp_team_app.SelectedItem.Text + "',LM_team_participation_cmnt='" + txt_team_app.Text + "',LM_commitment_rating='" + drp_commit_app.SelectedItem.Text + "',LM_commitment_cmnt='" + txt_commit_app.Text + "',LM_clnt_cust_orntion_rating='" + drp_client_app.SelectedItem.Text + "',LM_clnt_cust_orntion_cmnt='" + txt_client_app.Text + "',LM_team_planing_rating='" + drp_plan_app.SelectedItem.Text + "',LM_team_planing_cmnt='" + txt_plan_app.Text + "',LM_mentoring_leadrsip_rating='" + drp_mentor_app.SelectedItem.Text + "',LM_mentoring_leadrsip_cmnt='" + txt_mentor_app.Text + "',BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "',LM_appraiser_cmnt='" + txtcmnt_appr_1.Text + "' where empcode='" + EmployeeCode + "' and applycyclid=" + Convert.ToInt32(Session["appcycle"]) + " and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

                string str5 = @"update tbl_appraisal_assessment set behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str5);

                string str1 = @"update tbl_appraisal_assessment set R_cycle=4,trainingdetails='" + txttraining.Text + "',mgr_overall_rating='" + lblMgrOverallRating.Text + "',mgr_overall_cmt ='" + txtMgroverallcomments.Text + "',behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1  and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);   
            }
            else
            {
                string str6 = @"update tbl_appraisal_assessment set behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str6);

                //string str7 = @"update tbl_appraisal_approver_LM_rating_details_for_cycle_2 set BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "'";
                //SQLServer.ExecuteDataset(Connection, CommandType.Text, str7);

                string str = @"update tbl_appraisal_approver_LM_rating_details set LM_fun_skill_rating='" + drp_skils_app.SelectedItem.Text + "',LM_fun_skill_cmnt='" + txt_skils_app.Text + "',LM_quality_rating='" + drp_quality_app.SelectedItem.Text + "',LM_quality_cmnt='" + txt_quality_app.Text + "',LM_comm_skill_rating='" + drp_comm_app.SelectedItem.Text + "',LM_comm_skill_cmnt='" + txt_comm_app.Text + "',LM_self_devlop_rating='" + drp_self_app.SelectedItem.Text + "',LM_self_devlop_cmnt='" + txt_self_app.Text + "',LM_procs_knowldge_rating='" + drp_pro_app.SelectedItem.Text + "',LM_procs_knowldge_cmnt='" + txt_pro_app.Text + "',LM_team_participation_rating='" + drp_team_app.SelectedItem.Text + "',LM_team_participation_cmnt='" + txt_team_app.Text + "',LM_commitment_rating='" + drp_commit_app.SelectedItem.Text + "',LM_commitment_cmnt='" + txt_commit_app.Text + "',LM_clnt_cust_orntion_rating='" + drp_client_app.SelectedItem.Text + "',LM_clnt_cust_orntion_cmnt='" + txt_client_app.Text + "',LM_team_planing_rating='" + drp_plan_app.SelectedItem.Text + "',LM_team_planing_cmnt='" + txt_plan_app.Text + "',LM_mentoring_leadrsip_rating='" + drp_mentor_app.SelectedItem.Text + "',LM_mentoring_leadrsip_cmnt='" + txt_mentor_app.Text + "',BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "',LM_appraiser_cmnt='" + txtcmnt_appr_1.Text + "' where empcode='" + EmployeeCode + "' and applycyclid=" + Convert.ToInt32(Session["appcycle"]) + " and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

                string str1 = @"update tbl_appraisal_assessment set R_cycle=4,trainingdetails='" + txttraining.Text + "',mgr_overall_cmt ='" + txtMgroverallcomments.Text + "',mgr_overall_rating='" + lblMgrOverallRating.Text + "', behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1  and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);  
            }

            Response.Redirect("RatingReviewByBUH.aspx?updated=true");

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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("RatingReviewByBUH.aspx");
    }

    protected void sendMail(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select a.empcode,a.official_email_id,isnull(a.emp_fname,'''')+' ' +isnull(a.emp_m_name,'''')+' ' +isnull(a.emp_l_name,'''') as empname from tbl_intranet_employee_jobDetails e inner join tbl_intranet_employee_jobDetails a on a.empcode=e.corporatereportingcode  where  e.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
                {
                    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                    string subject = ConfigurationManager.AppSettings["subjectRating"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_RatingMgr2Mgmt"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                }
            }
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

    //protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    gvGoals.EditIndex = e.NewEditIndex;
    //    bindGoals(Request.QueryString["empcode"].ToString());
    //    DropDownList editrating = (DropDownList)gvGoals.Rows[e.NewEditIndex].FindControl("txteditrating");
    //    Label lblrating = (Label)gvGoals.Rows[e.NewEditIndex].FindControl("lblrating1");
    //    if (editrating != null)
    //    {
    //        editrating.DataTextField = "rating";
    //        editrating.DataValueField = "rating_id";
    //        editrating.DataSource = getRatings();
    //        editrating.DataBind();
    //       // editrating.Items.Insert(0, new ListItem("Select", "0"));
    //        editrating.SelectedValue = lblrating.Text;
          
    //    }
    //}

    //protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    gvGoals.EditIndex = -1;
    //    bindGoals(Request.QueryString["empcode"].ToString());
    //    gvGoals_RowDataBound();
    //}

    //protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    try
    //    {
    //        Connection = DataActivity.OpenConnection();
    //        DropDownList rating = (DropDownList)gvGoals.Rows[e.RowIndex].FindControl("txteditrating");
    //        TextBox comments = (TextBox)gvGoals.Rows[e.RowIndex].FindControl("txteditcomments");
    //        string str = @"update tbl_appraisal_rating_details set mgrrating=" + Convert.ToInt32(rating.SelectedValue) + ",mgrcomments='" + comments.Text + "' where asd_id=" + Convert.ToInt32(gvGoals.DataKeys[e.RowIndex].Values[0]) + "";
    //        string str1 = @"update tbl_appraisal_assessment set behavior_color='#000000' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Request.QueryString["empcode"].ToString() + "' and status=1";
    //        DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str + "; " + str1);
    //        gvGoals.EditIndex = -1;
    //        bindGoals(Request.QueryString["empcode"].ToString());
    //        gvGoals_RowDataBound();
    //        lblMgrOverallRating.Text = Convert.ToString(Math.Round(Convert.ToDouble(lblAvgRatingGoals.Text == "" ? "0" : lblAvgRatingGoals.Text), 0));
    //        bindBehaviorgrid();
    //        lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml("#000000");
    //    }
    //    catch (Exception ex)
    //    {
    //        Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        DataActivity.CloseConnection();
    //    }
    //}

    //protected void gvGoals_RowDataBound()
    //{

    //    try
    //    {

    //        mgrgrdTotal = 0;
    //        grdTotal = 0;
    //        ratingweightagetotal = 0;
    //        mgrratingweightagetotal = 0;
    //        if (gvGoals.Rows.Count > 0)
    //        {
    //            foreach (GridViewRow row in gvGoals.Rows)
    //            {
    //                Label weightage = (Label)row.FindControl("lblweightage");
    //                Label rating = (Label)row.FindControl("lblemprating");
    //                Label mgrrating = (Label)row.FindControl("lblrating");
    //                decimal rowTotal = 0;
    //                decimal mgrrowTotal = 0;
    //                decimal rowrating = 0;
    //                decimal mgrrowrating = 0;

    //                if (weightage.Text == "")
    //                {
    //                    rowTotal = 0;
    //                    mgrrowTotal = 0;
    //                }
    //                else
    //                {
    //                    rowTotal = Convert.ToDecimal(weightage.Text.Trim());
    //                    mgrrowTotal = Convert.ToDecimal(weightage.Text.Trim());
    //                }

    //                if (rating.Text == "")
    //                    rowrating = 0;
    //                else
    //                    rowrating = Convert.ToDecimal(rating.Text.Trim());

    //                ratingweightagetotal = ratingweightagetotal + (rowTotal * rowrating);
    //                grdTotal = grdTotal + rowTotal;

    //                //-----------------mgr
    //                if (mgrrating.Text == "")
    //                    mgrrowrating = 0;
    //                else
    //                    mgrrowrating = Convert.ToDecimal(mgrrating.Text.Trim());
    //                mgrratingweightagetotal = mgrratingweightagetotal + (mgrrowTotal * mgrrowrating);

    //                mgrgrdTotal = mgrgrdTotal + mgrrowTotal;

    //            }
    //            Label lblavgrating = (Label)gvGoals.FooterRow.FindControl("lblGoalsAvgRating");
    //            lblavgrating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));

    //            if (mgrratingweightagetotal != 0)
    //            {
    //                Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
    //                lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
    //                lblAvgRatingGoals.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
    //    }

    //}

    protected void gveligible_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Getemp"] != null)
        {
            gveligible.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Getemp"];
            gveligible.DataSource = ds;
            gveligible.DataBind();
        }
    }

    //-------------Behavior Patteren-----//

    protected void bindBehaviorgrid()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];
        SqlConnection Connection = null;
        int Flag = 0;
        try
        {
            string str = @"select * from tbl_appraisal_behaviorpattren; select count(*) from tbl_appraisal_behaviorpattren";
            Connection = DataActivity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            grdcolor.DataSource = ds;
            grdcolor.DataBind();

            int slrow = Convert.ToInt32(Math.Round(Convert.ToDouble(lblMgrOverallRating.Text == "" ? "0" : lblMgrOverallRating.Text)));
            int s = slrow == 5 ? 0 : (slrow == 4 ? 1 : (slrow == 3 ? 2 : (slrow == 2 ? 3 : 4)));
            for (int i = 0; i < 5; i++)
            {
                if (i == s)
                {
                    grdcolor.Rows[i].Enabled = true;
                }
                else
                    grdcolor.Rows[i].Enabled = false;
            }
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

    protected void btn_Unaccetable_Command(object sender, CommandEventArgs e)
    {
        string color = e.CommandArgument.ToString();
        lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml(color);
    }

    protected void gveligible_PreRender(object sender, System.EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }

    protected void gvGoals_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DropDownList rating = (DropDownList)e.Row.FindControl("txtrating");
        //    Label lblrating = (Label)e.Row.FindControl("lblrating");
        //    if (rating != null)
        //    {
        //        if (lblrating.Text.Trim() != "")
        //            rating.Visible = false;
        //        else
        //            rating.Visible = true;
        //    }
        //}

        if (e.Row.RowState == DataControlRowState.Edit)
        {
            DropDownList editrating = (DropDownList)e.Row.FindControl("txteditrating");
            Label lblrating = (Label)e.Row.FindControl("lblrating");
            editrating.DataTextField = "rating";
            editrating.DataValueField = "rating_id";
            editrating.DataSource = getRatings();
            editrating.DataBind();
            editrating.Items.Insert(0, new ListItem("Select", "0"));
        }
    }

    private DataSet getRatings()
    {
        SqlConnection Connection = null;
        DataSet ds3 = new DataSet();
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = "select rating_id,rating  from tbl_appraisal_rating";
            ds3 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

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
        return ds3;
    }

    //protected void drp_skils_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_quality_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_comm_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_self_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_pro_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_team_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_commit_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_client_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_plan_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}
    //protected void drp_mentor_app_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    SqlConnection Connection = null;
    //    Connection = DataActivity.OpenConnection();
    //    EmployeeCode = Request.QueryString["empcode"].ToString();
    //    if (drp_skils_app.SelectedValue != "0" && drp_quality_app.SelectedValue != "0" && drp_comm_app.SelectedValue != "0" && drp_self_app.SelectedValue != "0" && drp_pro_app.SelectedValue != "0" && drp_team_app.SelectedValue != "0" && drp_commit_app.SelectedValue != "0" && drp_client_app.SelectedValue != "0" && drp_plan_app.SelectedValue != "0" && drp_mentor_app.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils_app.SelectedValue) + Convert.ToInt32(drp_quality_app.SelectedValue) + Convert.ToInt32(drp_comm_app.SelectedValue) + Convert.ToInt32(drp_self_app.SelectedValue) + Convert.ToInt32(drp_pro_app.SelectedValue) + Convert.ToInt32(drp_team_app.SelectedValue) + Convert.ToInt32(drp_commit_app.SelectedValue) + Convert.ToInt32(drp_client_app.SelectedValue) + Convert.ToInt32(drp_plan_app.SelectedValue) + Convert.ToInt32(drp_mentor_app.SelectedValue);
    //        lblMgrOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall2.Visible = true;

    //        string str1 = @"update tbl_appraisal_assessment set mgr_overall_rating='" + lblMgrOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
    //        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
    //    }
    //    else
    //    {
    //        troverall2.Visible = false;
    //    }
    //}

    public void calculaterating()
    {

        if (drp_skils_app.SelectedValue != "-1")
        {
            x = Convert.ToInt32(drp_skils_app.SelectedValue);
            i = i + 1;

        }
        if (drp_quality_app.SelectedValue != "-1")
        {
            y = Convert.ToInt32(drp_quality_app.SelectedValue);
            x = x + y;
            i = i + 1;

        }
        if (drp_comm_app.SelectedValue != "-1")
        {
            z = Convert.ToInt32(drp_comm_app.SelectedValue);
            x = x + z;
            i = i + 1;

        }
        if (drp_self_app.SelectedValue != "-1")
        {
            s = Convert.ToInt32(drp_self_app.SelectedValue);
            x = x + s;
            i = i + 1;

        }
        if (drp_pro_app.SelectedValue != "-1")
        {
            a = Convert.ToInt32(drp_pro_app.SelectedValue);
            x = x + a;
            i = i + 1;

        }
        if (drp_team_app.SelectedValue != "-1")
        {
            b = Convert.ToInt32(drp_team_app.SelectedValue);
            x = x + b;
            i = i + 1;

        }
        if (drp_commit_app.SelectedValue != "-1")
        {
            c = Convert.ToInt32(drp_commit_app.SelectedValue);
            x = x + c;
            i = i + 1;

        }
        if (drp_client_app.SelectedValue != "-1")
        {
            d = Convert.ToInt32(drp_client_app.SelectedValue);
            x = x + d;
            i = i + 1;

        }
        if (drp_plan_app.SelectedValue != "-1")
        {
            e = Convert.ToInt32(drp_plan_app.SelectedValue);
            x = x + e;
            i = i + 1;

        }
        if (drp_mentor_app.SelectedValue != "-1")
        {
            f = Convert.ToInt32(drp_mentor_app.SelectedValue);
            x = x + f;
            i = i + 1;

        }

        if (drp_skils_app.SelectedValue != "-1" || drp_quality_app.SelectedValue != "-1" || drp_comm_app.SelectedValue != "-1" || drp_self_app.SelectedValue != "-1" || drp_pro_app.SelectedValue != "-1" || drp_team_app.SelectedValue != "-1" || drp_commit_app.SelectedValue != "-1" || drp_client_app.SelectedValue != "-1" || drp_plan_app.SelectedValue != "-1" || drp_mentor_app.SelectedValue != "-1")
        {
            decimal xx = Convert.ToDecimal(x) / Convert.ToDecimal(i);
            lblMgrOverallRating.Text = xx.ToString();
        }

        if (drp_skils_app.SelectedValue == "-1" && drp_quality_app.SelectedValue == "-1" && drp_comm_app.SelectedValue == "-1" && drp_self_app.SelectedValue == "-1" && drp_pro_app.SelectedValue == "-1" && drp_team_app.SelectedValue == "-1" && drp_commit_app.SelectedValue == "-1" && drp_client_app.SelectedValue == "-1" && drp_plan_app.SelectedValue == "-1" && drp_mentor_app.SelectedValue == "-1")
        {
            lblMgrOverallRating.Text = "";
        }



    }

    protected void btn_chkall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gveligible.Rows)
        {
            CheckBox chk = row.Cells[0].FindControl("chk_empdetails") as CheckBox;
            chk.Checked = true;
        }
    }

    protected void btn_unchkall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gveligible.Rows)
        {
            CheckBox chk = row.Cells[0].FindControl("chk_empdetails") as CheckBox;
            chk.Checked = false;
        }
    }
    protected void btn_submit_all_Click(object sender, System.EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chk_empdetails");

                if (chkRow != null && chkRow.Checked)
                {
                    string query12 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
                    DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query12);
                    string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
                    string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();

                    Label EmployeeCode = (Label)row.FindControl("lblempcode");

                    //EmployeeCode = Request.QueryString["empcode"].ToString();

                    //mgr_overall_rating='" + lblMgrOverallRating.Text + "'

                    string query_1 = @"select * from tbl_appraisal_approver_LM_rating_details where empcode='" + EmployeeCode.Text + "' and applycyclid=" + Convert.ToInt32(Session["appcycle"]) + " and quater='" + quater + "' and APP_year='" + APP_year + "'";
                    DataSet ds_1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query_1);

                    string strq1 = @"select * from tbl_appraisal_approver_LM_rating_details_for_cycle_2 where empcode='" + EmployeeCode.Text + "' and applycyclid=" + Convert.ToInt32(Session["appcycle"]) + " order by id desc";
                    DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq1);


                    //if (ds_1.Tables[0].Rows[0]["updated_by"].ToString() == "")
                    //if (ds1.Tables[0].Rows[0]["quater"].ToString() == "Q1")
                    if (ds_1.Tables[0].Rows.Count == 1)
                    {
                        string str5 = @"update tbl_appraisal_assessment set behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode.Text + "' and quater='" + quater + "' and APP_year='" + APP_year + "'";
                        SQLServer.ExecuteDataset(Connection, CommandType.Text, str5);

                        string str1 = @"update tbl_appraisal_assessment set R_cycle=4,behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode.Text + "' and status=1  and quater='" + quater + "' and APP_year='" + APP_year + "'";
                        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
                    }
                    else
                    {
                        string str6 = @"update tbl_appraisal_assessment set behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode.Text + "' and quater='" + quater + "' and APP_year='" + APP_year + "'";
                        SQLServer.ExecuteDataset(Connection, CommandType.Text, str6);

                        //string str7 = @"update tbl_appraisal_approver_LM_rating_details_for_cycle_2 set BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "'";
                        //SQLServer.ExecuteDataset(Connection, CommandType.Text, str7);


                        string str1 = @"update tbl_appraisal_assessment set R_cycle=4,behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode.Text + "' and status=1  and quater='" + quater + "' and APP_year='" + APP_year + "'";
                        SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
                    }
                }
            }

            Response.Redirect("RatingReviewByBUH.aspx?updated=true");

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
}
