using System;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;


public partial class appraisal_LineMangerRatingView : System.Web.UI.Page
{
    string EmployeeCode = "";
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    decimal compmgrratingweightagetotal = 0;
    decimal cmpratingweightagetotal = 0;
    DataActivity DataActivity = new DataActivity();
    string UserCode, backbuton,appcycle_id;
    int totalrating;
    int x, y, z, s, a, b, c, d, e, f;
    int i = 0 ;
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
                appcycle_id = Request.QueryString["appcycle_id"].ToString();
                empdetails.Visible = true;
                empsearch.Visible = false;
                emplist.Visible = false;
                backbuton = Request.QueryString["back"].ToString();
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
                if (backbuton.ToString() == "0")
                {
                    btn_back.Visible = false;
                }
                if (backbuton.ToString() == "1")
                {
                    btnBack.Visible = false;
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
inner join tbl_employee_approvers aprs on aprs.empcode=app.empcode 
where 1=1 and app.R_cycle=3 and app.status in(1,3) and empjob.emp_status in(1,3)  
and aprs.app_businesshead='" + UserCode + "' and empjob.empcode='" + txt_employee.Text + "' and empdept.department_name='" + ddl_dept.SelectedItem.Text + "' order by empjob.empcode ";
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
inner join tbl_employee_approvers aprs on aprs.empcode=app.empcode 
where 1=1 and app.R_cycle=3 and app.status in(1,3) and empjob.emp_status in(1,3)  
and aprs.app_businesshead='" + UserCode + "'  order by empjob.empcode";
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

            string query = @"select top 1 * from tbl_appraisal_rating_details_1 where empcode='" + empcode + "' order by id desc";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

            string query_1 = @"select top 1 * from tbl_appraisal_rating_details_1_for_cycle_2 where empcode='" + empcode + "' order by id desc";

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
            string strq = @"select top 1* from tbl_appraisal_approver_LM_rating_details where empcode='" + empcode + "' order by id desc";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq);

            string strq1 = @"select top 1* from tbl_appraisal_approver_LM_rating_details_for_cycle_2 where empcode='" + empcode + "' order by id desc";
            DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq1);

            if (ds2.Tables[0].Rows.Count < 1)
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    drp_skils_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_fun_skill_rating"].ToString();
                    txt_skils_app.Text = ds1.Tables[0].Rows[0]["LM_fun_skill_cmnt"].ToString();
                    drp_quality_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_quality_rating"].ToString();
                    txt_quality_app.Text = ds1.Tables[0].Rows[0]["LM_quality_cmnt"].ToString();
                    drp_comm_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_comm_skill_rating"].ToString();
                    txt_comm_app.Text = ds1.Tables[0].Rows[0]["LM_comm_skill_cmnt"].ToString();
                    drp_self_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_self_devlop_rating"].ToString();
                    txt_self_app.Text = ds1.Tables[0].Rows[0]["LM_self_devlop_cmnt"].ToString();
                    drp_pro_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_procs_knowldge_rating"].ToString();
                    txt_pro_app.Text = ds1.Tables[0].Rows[0]["LM_procs_knowldge_cmnt"].ToString();
                    drp_team_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_team_participation_rating"].ToString();
                    txt_team_app.Text = ds1.Tables[0].Rows[0]["LM_team_participation_cmnt"].ToString();
                    drp_commit_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_commitment_rating"].ToString();
                    txt_commit_app.Text = ds1.Tables[0].Rows[0]["LM_commitment_cmnt"].ToString();
                    drp_client_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_clnt_cust_orntion_rating"].ToString();
                    txt_client_app.Text = ds1.Tables[0].Rows[0]["LM_clnt_cust_orntion_cmnt"].ToString();
                    drp_plan_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_team_planing_rating"].ToString();
                    txt_plan_app.Text = ds1.Tables[0].Rows[0]["LM_team_planing_cmnt"].ToString();
                    drp_mentor_app.SelectedItem.Text = ds1.Tables[0].Rows[0]["LM_mentoring_leadrsip_rating"].ToString();
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
                    drp_skils_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_fun_skill_rating"].ToString();
                    txt_skils_app.Text = ds2.Tables[0].Rows[0]["LM_fun_skill_cmnt"].ToString();
                    drp_quality_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_quality_rating"].ToString();
                    txt_quality_app.Text = ds2.Tables[0].Rows[0]["LM_quality_cmnt"].ToString();
                    drp_comm_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_comm_skill_rating"].ToString();
                    txt_comm_app.Text = ds2.Tables[0].Rows[0]["LM_comm_skill_cmnt"].ToString();
                    drp_self_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_self_devlop_rating"].ToString();
                    txt_self_app.Text = ds2.Tables[0].Rows[0]["LM_self_devlop_cmnt"].ToString();
                    drp_pro_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_procs_knowldge_rating"].ToString();
                    txt_pro_app.Text = ds2.Tables[0].Rows[0]["LM_procs_knowldge_cmnt"].ToString();
                    drp_team_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_team_participation_rating"].ToString();
                    txt_team_app.Text = ds2.Tables[0].Rows[0]["LM_team_participation_cmnt"].ToString();
                    drp_commit_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_commitment_rating"].ToString();
                    txt_commit_app.Text = ds2.Tables[0].Rows[0]["LM_commitment_cmnt"].ToString();
                    drp_client_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_clnt_cust_orntion_rating"].ToString();
                    txt_client_app.Text = ds2.Tables[0].Rows[0]["LM_clnt_cust_orntion_cmnt"].ToString();
                    drp_plan_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_team_planing_rating"].ToString();
                    txt_plan_app.Text = ds2.Tables[0].Rows[0]["LM_team_planing_cmnt"].ToString();
                    drp_mentor_app.SelectedItem.Text = ds2.Tables[0].Rows[0]["LM_mentoring_leadrsip_rating"].ToString();
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

   
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            EmployeeCode = Request.QueryString["empcode"].ToString();
            string str1 = @"update tbl_appraisal_assessment set R_cycle=4,trainingdetails='" + txttraining.Text + "',mgr_overall_cmt ='" + txtMgroverallcomments.Text + "',mgr_overall_rating='" + lblMgrOverallRating.Text + "',behavior_color='BHRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "' and status=1";
            SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);

            string query_1 = @"select * from tbl_appraisal_approver_LM_rating_details where empcode='" + EmployeeCode + "'";
            DataSet ds_1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query_1);

            string strq1 = @"select top 1* from tbl_appraisal_approver_LM_rating_details_for_cycle_2 where empcode='" + EmployeeCode + "' order by id desc";
            DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.Text, strq1);


            //if (ds_1.Tables[0].Rows[0]["updated_by"].ToString() == "")
            if (ds_1.Tables[0].Rows.Count < 1)
            {
                string str = @"update tbl_appraisal_approver_LM_rating_details set LM_fun_skill_rating='" + drp_skils_app.SelectedValue + "',LM_fun_skill_cmnt='" + txt_skils_app.Text + "',LM_quality_rating='" + drp_quality_app.SelectedValue + "',LM_quality_cmnt='" + txt_quality_app.Text + "',LM_comm_skill_rating='" + drp_comm_app.SelectedValue + "',LM_comm_skill_cmnt='" + txt_comm_app.Text + "',LM_self_devlop_rating='" + drp_self_app.SelectedValue + "',LM_self_devlop_cmnt='" + txt_self_app.Text + "',LM_procs_knowldge_rating='" + drp_pro_app.SelectedValue + "',LM_procs_knowldge_cmnt='" + txt_pro_app.Text + "',LM_team_participation_rating='" + drp_team_app.SelectedValue + "',LM_team_participation_cmnt='" + txt_team_app.Text + "',LM_commitment_rating='" + drp_commit_app.SelectedValue + "',LM_commitment_cmnt='" + txt_commit_app.Text + "',LM_clnt_cust_orntion_rating='" + drp_client_app.SelectedValue + "',LM_clnt_cust_orntion_cmnt='" + txt_client_app.Text + "',LM_team_planing_rating='" + drp_plan_app.SelectedValue + "',LM_team_planing_cmnt='" + txt_plan_app.Text + "',LM_mentoring_leadrsip_rating='" + drp_mentor_app.SelectedValue + "',LM_mentoring_leadrsip_cmnt='" + txt_mentor_app.Text + "',BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "',LM_appraiser_cmnt='" + txtcmnt_appr_1.Text + "' where empcode='" + EmployeeCode + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

                string str5 = @"update tbl_appraisal_assessment set behavior_color='ManagerRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str5);
            }
            else
            {
                string str6 = @"update tbl_appraisal_assessment set behavior_color='ManagerRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str6);

                //string str7 = @"update tbl_appraisal_approver_LM_rating_details_for_cycle_2 set BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "'";
                //SQLServer.ExecuteDataset(Connection, CommandType.Text, str7);

                string str = @"update tbl_appraisal_approver_LM_rating_details set LM_fun_skill_rating='" + drp_skils_app.SelectedValue + "',LM_fun_skill_cmnt='" + txt_skils_app.Text + "',LM_quality_rating='" + drp_quality_app.SelectedValue + "',LM_quality_cmnt='" + txt_quality_app.Text + "',LM_comm_skill_rating='" + drp_comm_app.SelectedValue + "',LM_comm_skill_cmnt='" + txt_comm_app.Text + "',LM_self_devlop_rating='" + drp_self_app.SelectedValue + "',LM_self_devlop_cmnt='" + txt_self_app.Text + "',LM_procs_knowldge_rating='" + drp_pro_app.SelectedValue + "',LM_procs_knowldge_cmnt='" + txt_pro_app.Text + "',LM_team_participation_rating='" + drp_team_app.SelectedValue + "',LM_team_participation_cmnt='" + txt_team_app.Text + "',LM_commitment_rating='" + drp_commit_app.SelectedValue + "',LM_commitment_cmnt='" + txt_commit_app.Text + "',LM_clnt_cust_orntion_rating='" + drp_client_app.SelectedValue + "',LM_clnt_cust_orntion_cmnt='" + txt_client_app.Text + "',LM_team_planing_rating='" + drp_plan_app.SelectedValue + "',LM_team_planing_cmnt='" + txt_plan_app.Text + "',LM_mentoring_leadrsip_rating='" + drp_mentor_app.SelectedValue + "',LM_mentoring_leadrsip_cmnt='" + txt_mentor_app.Text + "',BH_appraiser_cmnt='" + txt_BH_cmnt.Text + "',LM_appraiser_cmnt='" + txtcmnt_appr_1.Text + "' where empcode='" + EmployeeCode + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

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
        Response.Redirect("ViewEmployeelistByManager.aspx");
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

  
    public void calculaterating()
    {

        if (drp_skils_app.SelectedValue != "0")
        {
            x = Convert.ToInt32(drp_skils_app.SelectedItem.Text);
            i = i + 1;

        }
        if (drp_quality_app.SelectedValue != "0")
        {
            y = Convert.ToInt32(drp_quality_app.SelectedItem.Text);
            x = x + y;
            i = i + 1;

        }
        if (drp_comm_app.SelectedValue != "0")
        {
            z = Convert.ToInt32(drp_comm_app.SelectedItem.Text);
            x = x + z;
            i = i + 1;

        }
        if (drp_self_app.SelectedValue != "0")
        {
            s = Convert.ToInt32(drp_self_app.SelectedItem.Text);
            x = x + s;
            i = i + 1;

        }
        if (drp_pro_app.SelectedValue != "0")
        {
            a = Convert.ToInt32(drp_pro_app.SelectedItem.Text);
            x = x + a;
            i = i + 1;

        }
        if (drp_team_app.SelectedValue != "0")
        {
            b = Convert.ToInt32(drp_team_app.SelectedItem.Text);
            x = x + b;
            i = i + 1;

        }
        if (drp_commit_app.SelectedValue != "0")
        {
            c = Convert.ToInt32(drp_commit_app.SelectedItem.Text);
            x = x + c;
            i = i + 1;

        }
        if (drp_client_app.SelectedValue != "0")
        {
            d = Convert.ToInt32(drp_client_app.SelectedItem.Text);
            x = x + d;
            i = i + 1;

        }
        if (drp_plan_app.SelectedValue != "0")
        {
            e = Convert.ToInt32(drp_plan_app.SelectedItem.Text);
            x = x + e;
            i = i + 1;

        }
        if (drp_mentor_app.SelectedValue != "0")
        {
            f = Convert.ToInt32(drp_mentor_app.SelectedItem.Text);
            x = x + f;
            i = i + 1;

        }

        if (drp_skils_app.SelectedValue != "0" || drp_quality_app.SelectedValue != "0" || drp_comm_app.SelectedValue != "0" || drp_self_app.SelectedValue != "0" || drp_pro_app.SelectedValue != "0" || drp_team_app.SelectedValue != "0" || drp_commit_app.SelectedValue != "0" || drp_client_app.SelectedValue != "0" || drp_plan_app.SelectedValue != "0" || drp_mentor_app.SelectedValue != "0")
        {
            int xx = x / i;
            lblMgrOverallRating.Text = xx.ToString();
        }

        if (drp_skils_app.SelectedValue == "0" && drp_quality_app.SelectedValue == "0" && drp_comm_app.SelectedValue == "0" && drp_self_app.SelectedValue == "0" && drp_pro_app.SelectedValue == "0" && drp_team_app.SelectedValue == "0" && drp_commit_app.SelectedValue == "0" && drp_client_app.SelectedValue == "0" && drp_plan_app.SelectedValue == "0" && drp_mentor_app.SelectedValue == "0")
        {
            lblMgrOverallRating.Text = "";
        }

    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEmployeelistByManager.aspx");
    }
    protected void btn_back_Click(object sender, EventArgs e)
    {
        //Response.Redirect("viewbyHR_addparticipent.aspx");
        Response.Redirect("ViewEmployeelistByBusinessHead.aspx");
    }
}
