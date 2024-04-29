using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Common.Mail.Module;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Web.UI;

public partial class appraisal_EmployeeRating : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    string EmployeeCode = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    int rating;
    int totalrating;
    int x, y, z, s, a, b, c, d, e, f;
    int i = 1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        UserCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {

            bindrating();
            getActiveCycle();
            gvGoals_bindRatingddl();
            bindData();
           // btnSubmit.Visible = false;
            //ratingself.Visible = false;
        }

        calculaterating();
    }


    //protected void parametersdata()
    //{
    //     SqlConnection Connection = null;
    //    try
    //    {
    //        Connection = DataActivity.OpenConnection();
    //        string sqlstr = "  select [Designation],[Functionall] from [tbl_apprasal_desgnationwise] where [Designation]="'+ +'";";
    //        DataSet ds3 = new DataSet();
    //        ds3 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

    //        foreach (GridViewRow row in gvGoals.Rows)
    //        {
    //            DropDownList rating = (DropDownList)row.FindControl("txtrating");
    //            Label lblrating = (Label)row.FindControl("lblrating");
    //            ddlpara.DataTextField = "rating";
    //            ddlpara.DataValueField = "rating_id";
    //            ddlpara.DataSource = ds3;
    //            ddlpara.DataBind();
    //            ddlpara.Items.Insert(0, new ListItem("Select", "0"));

    //        }
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

    protected void bindrating()
    {
        SqlParameter[] sqlparam1 = new SqlParameter[2];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string query = @"select * from tbl_appraisal_rating_details_1 where empcode='" + UserCode + "' and  applycyclid= '"+Session["appcycle"]+"'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

            if (ds.Tables[0].Rows.Count >  0)
            {
                string applycyid = ds.Tables[0].Rows[0]["applycyclid"].ToString();
                string empcode = ds.Tables[0].Rows[0]["empcode"].ToString();
                string cycle = Session["appcycle"].ToString();

                if ((applycyid == cycle) && (empcode == UserCode))
                {
                    btnSubmit.Visible = false;
                    btnReset.Visible = false;
                }
                else
                {
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                }
            }
            else
            {
                btnSubmit.Visible = true;
                btnReset.Visible = true;
            }




            //drp_skils.SelectedValue = ds.Tables[0].Rows[0]["fun_skill_rating"].ToString();
            //txt_skill_cmnt.Text = ds.Tables[0].Rows[0]["fun_skill_cmnt"].ToString();
            //drp_quality.SelectedValue = ds.Tables[0].Rows[0]["quality_rating"].ToString();
            //txt_quality_cmnt.Text = ds.Tables[0].Rows[0]["quality_cmnt"].ToString();
            //drp_comm.SelectedValue = ds.Tables[0].Rows[0]["comm_skill_rating"].ToString();
            //txt_comm.Text = ds.Tables[0].Rows[0]["comm_skill_cmnt"].ToString();
            //drp_self.SelectedValue = ds.Tables[0].Rows[0]["self_devlop_rating"].ToString();
            //txt_self.Text = ds.Tables[0].Rows[0]["self_devlop_cmnt"].ToString();
            //drp_pro.SelectedValue = ds.Tables[0].Rows[0]["procs_knowldge_rating"].ToString();
            //txt_pro.Text = ds.Tables[0].Rows[0]["procs_knowldge_cmnt"].ToString();
            //drp_team.SelectedValue = ds.Tables[0].Rows[0]["team_participation_rating"].ToString();
            //txt_team.Text = ds.Tables[0].Rows[0]["team_participation_cmnt"].ToString();
            //drp_commit.SelectedValue = ds.Tables[0].Rows[0]["commitment_rating"].ToString();
            //txt_commit.Text = ds.Tables[0].Rows[0]["commitment_cmnt"].ToString();
            //drp_client.SelectedValue = ds.Tables[0].Rows[0]["clnt_cust_orntion_rating"].ToString();
            //txt_client.Text = ds.Tables[0].Rows[0]["clnt_cust_orntion_cmnt"].ToString();
            //drp_plan.SelectedValue = ds.Tables[0].Rows[0]["team_planing_rating"].ToString();
            //txt_plan.Text = ds.Tables[0].Rows[0]["team_planing_cmnt"].ToString();
            //drp_mentor.SelectedValue = ds.Tables[0].Rows[0]["mentoring_leadrsip_rating"].ToString();
            //txt_mentor.Text = ds.Tables[0].Rows[0]["mentoring_leadrsip_cmnt"].ToString();
            //txtappr.Text = ds.Tables[0].Rows[0]["achievment_of_past_year"].ToString();
            //txt_training.Text = ds.Tables[0].Rows[0]["training_benefits_to_develop"].ToString();
            //txtcmnt_aap.Text = ds.Tables[0].Rows[0]["additional_cmnt"].ToString();
            //txtcmnt_appr.Text = ds.Tables[0].Rows[0]["additional_cmnt_1"].ToString();


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

    protected void bindData()
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select empcode,R_cycle from tbl_appraisal_assessment where status=1   and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
            

            bindgoals();

            // bindtraining();
            bindparameter();
            //gvGoals_bindRatingddl();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["R_cycle"].ToString() == "5")
                {
                    btnSubmitBUH.Visible = true;
                    btnSubmitHR.Visible = true;
                    btnSubmit.Visible = true;
                    btnReset.Visible = true;
                    btnsave.Visible = false;
                    btnCancel.Visible = false;
                    btnSubmitBUH.Text = "Resend to Manager";
                    btnSubmitBUH.CssClass = "btn btn-danger";
                }

                if (ds1.Tables[0].Rows[0]["R_cycle"].ToString() == "1" || ds1.Tables[0].Rows[0]["R_cycle"].ToString() == "5")
                {
                    bindratingrid();
                    if (ds1.Tables[0].Rows[0]["R_cycle"].ToString() == "5")
                    {
                        //gvGoals.Columns[6].Visible = false;
                        //gvGoals.Columns[7].Visible = false;
                        //gvGoals.Columns[10].Visible = false;
                        troverall2.Visible = true;
                        tdcolor1.Visible = true;
                        tdcolor2.Visible = true;
                        txtOverallComments.Enabled = false;
                        txttraining.Enabled = false;

                    }
                    else
                    {

                        //gvGoals.Columns[6].Visible = true;
                        //gvGoals.Columns[7].Visible = true;
                        //gvGoals.Columns[10].Visible = false;                       
                        troverall2.Visible = false;
                        tdcolor1.Visible = false;
                        tdcolor2.Visible = false;
                        appr_div1.Visible = true;
                        appr_div.Visible = false;
                    }

                }
                //else
                //{
                //    if ((ds1.Tables[0].Rows[0]["R_cycle"].ToString() == "2") || (ds1.Tables[0].Rows[0]["R_cycle"].ToString() == "5"))
                //        //Output.Show("You have already Submitted the rating for this Appraisal Cycle");
                //}
            }
            else
            {
                btnSubmit.Visible = false;
                btnReset.Visible = false;
                Output.Show(" You are not initiated for this Appraisal Cycle");
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

    private void bindparameter()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = "select rating_id,rating  from tbl_appraisal_rating order by rating_id desc";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            foreach (GridViewRow row in gvGoals.Rows)
            {
                DropDownList rating = (DropDownList)row.FindControl("txtrating");
                Label lblrating = (Label)row.FindControl("lblrating");
                rating.DataTextField = "rating";
                rating.DataValueField = "rating_id";
                rating.DataSource = ds3;
                rating.DataBind();
                rating.Items.Insert(0, new ListItem("Select", "0"));

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
        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze=0 ";
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

    private void bindratingrid()
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select rating_id,rating,description from dbo.tbl_appraisal_rating";
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

    private void bindgoals()
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            // string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.kca,aps.weightage,aps.emp_comments,sd.parameter,aps.mng_comments ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status in(1,3) and (apt.R_cycle=1 or R_cycle=5) and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
            string str = @"select apt.assessment_id as initializeid,aps.asd_id,aps.flow_id,aps.assessment_id,apt.empcode,aps.kca,aps.weightage,aps.emp_comments,aps.mng_comments,aps.desigid  
from tbl_appraisal_assessment_details aps 

inner join tbl_appraisal_assessment apt on aps.desigid=apt.desigid

where apt.status in(1,3) and (apt.R_cycle=1 or R_cycle=5) and
apt.appcycle_id= '" + Convert.ToInt32(Session["appcycle"]) + "' and  apt.empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            //if (ds.Tables[0].Rows.Count < 1)
            //{
            //    trtraining.Visible = false;
            //    trbuttons.Visible = false;
            //    troverall.Visible = false;
            //}
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    if (ds.Tables[0].Rows[0]["emprating"].ToString() != "")
            //    {
            //        gvGoals.Columns[7].Visible = true;
            //        btnsave.Visible = false;
            //        btnCancel.Visible = false;
            //        btnSubmit.Visible = true;
            //        if (!IsPostBack)
            //        {
            //            gvGoals_RowDataBound();
            //        }
            //    }
            //    else
            //    {
            //        gvGoals.Columns[9].Visible = false;
            //        btnsave.Visible = true;
            //        btnCancel.Visible = true;
            //        btnSubmit.Visible = false;
            //    }
            //}
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

    protected void bindtraining()
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,mgr_overall_cmt,mgr_overall_rating,behavior_color from tbl_appraisal_assessment where status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "' ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txttraining.Text = ds.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblOverallRating.Text = ds.Tables[0].Rows[0]["emp_overall_rating"].ToString();
                txtOverallComments.Text = ds.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                txtMgrOverallComments.Text = ds.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                lblMgrOverallRating.Text = ds.Tables[0].Rows[0]["mgr_overall_rating"].ToString();
                if (ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim() != "")
                    lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml(ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim());
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

    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        SqlConnection Connection = null;
        int flag = 0;

        try
        {
            Connection = DataActivity.OpenConnection();

            string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query1);
            string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
            string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();

            string funskill = txt_skill_cmnt.Text;
            string empcode = Session["empcode"].ToString();
            string query = @"select assessment_id,empcode from dbo.tbl_appraisal_assessment where empcode='" + empcode + "' and appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and quater='" + quater + "' and APP_year='" + APP_year + "' ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            string ass_id = ds.Tables[0].Rows[0]["assessment_id"].ToString();

            //string str = @"If Exists(select empcode from tbl_appraisal_rating_details_1) Update tbl_appraisal_rating_details_1 Set assessment_id='" + ass_id + "',fun_skill_rating ='" + drp_skils.SelectedItem.Text + "',fun_skill_cmnt ='" + txt_skill_cmnt.Text + "',quality_rating ='" + drp_quality.SelectedItem.Text + "',quality_cmnt='" + txt_quality_cmnt.Text + "',comm_skill_rating='" + drp_comm.SelectedItem.Text + "',comm_skill_cmnt='" + txt_comm.Text + "',self_devlop_rating ='" + drp_self.SelectedItem.Text + "',self_devlop_cmnt ='" + txt_self.Text + "',procs_knowldge_rating='" + drp_pro.SelectedItem.Text + "',procs_knowldge_cmnt ='" + txt_pro.Text + "',team_participation_rating ='" + drp_team.SelectedItem.Text + "',team_participation_cmnt='" + txt_team.Text + "',commitment_rating='" + drp_commit.SelectedItem.Text + "',commitment_cmnt='" + txt_commit.Text + "',clnt_cust_orntion_rating ='" + drp_client.SelectedItem.Text + "',clnt_cust_orntion_cmnt='" + txt_client.Text + "',team_planing_rating ='" + drp_plan.SelectedItem.Text + "',team_planing_cmnt='" + txt_plan.Text + "',mentoring_leadrsip_rating ='" + drp_mentor.SelectedItem.Text + "',mentoring_leadrsip_cmnt ='" + txt_mentor.Text + "',achievment_of_past_year='" + txtappr.Text + "',training_benefits_to_develop ='" + txt_training.Text + "',additional_cmnt ='" + txtcmnt_aap.Text + "',additional_cmnt_1='" + txtcmnt_appr.Text + "',updated_by='" + UserCode + "',updated_date='" + DateTime.Today + "' where empcode='" + UserCode + "' Else Insert Into tbl_appraisal_rating_details_1(assessment_id,empcode,fun_skill_rating,fun_skill_cmnt,quality_rating,quality_cmnt,comm_skill_rating,comm_skill_cmnt,self_devlop_rating,self_devlop_cmnt,procs_knowldge_rating,procs_knowldge_cmnt,team_participation_rating,team_participation_cmnt,commitment_rating,commitment_cmnt,clnt_cust_orntion_rating,clnt_cust_orntion_cmnt,team_planing_rating,team_planing_cmnt,mentoring_leadrsip_rating,mentoring_leadrsip_cmnt,achievment_of_past_year,training_benefits_to_develop,additional_cmnt,additional_cmnt_1,created_by,created_date,status) values('" + ass_id + "','" + UserCode + "','" + drp_skils.SelectedItem.Text + "','" + txt_skill_cmnt.Text + "','" + drp_quality.SelectedItem.Text + "','" + txt_quality_cmnt.Text + "','" + drp_comm.SelectedItem.Text + "','" + txt_comm.Text + "','" + drp_self.SelectedItem.Text + "','" + txt_self.Text + "','" + drp_pro.SelectedItem.Text + "','" + txt_pro.Text + "','" + drp_team.SelectedItem.Text + "','" + txt_team.Text + "','" + drp_commit.SelectedItem.Text + "','" + txt_commit.Text + "','" + drp_client.SelectedItem.Text + "','" + txt_client.Text + "','" + drp_plan.SelectedItem.Text + "','" + txt_plan.Text + "','" + drp_mentor.SelectedItem.Text + "','" + txt_mentor.Text + "','" + txtappr.Text + "','" + txt_training.Text + "','" + txtcmnt_aap.Text + "','" + txtcmnt_appr.Text + "','" + UserCode + "','" + DateTime.Today + "','1')";
            //SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            string query_1 = @"select * from tbl_appraisal_rating_details_1 where empcode='" + empcode + "' and applycyclid= " + Convert.ToInt32(Session["appcycle"]) + " and quater='" + quater + "' and APP_year='" + APP_year + "'";
            DataSet ds_1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, query_1);
            if (ds_1.Tables[0].Rows.Count<1)
            {
                string str = @"Insert Into tbl_appraisal_rating_details_1(assessment_id,empcode,fun_skill_rating,fun_skill_cmnt,quality_rating,quality_cmnt,comm_skill_rating,comm_skill_cmnt,self_devlop_rating,self_devlop_cmnt,procs_knowldge_rating,procs_knowldge_cmnt,team_participation_rating,team_participation_cmnt,commitment_rating,commitment_cmnt,clnt_cust_orntion_rating,clnt_cust_orntion_cmnt,team_planing_rating,team_planing_cmnt,mentoring_leadrsip_rating,mentoring_leadrsip_cmnt,achievment_of_past_year,training_benefits_to_develop,additional_cmnt,additional_cmnt_1,created_by,created_date,status, applycyclid,APP_year,quater ) values('" + ass_id + "','" + UserCode + "','" + drp_skils.SelectedItem.Text + "','" + funskill.ToString() + "','" + drp_quality.SelectedItem.Text + "','" + txt_quality_cmnt.Text + "','" + drp_comm.SelectedItem.Text + "','" + txt_comm.Text + "','" + drp_self.SelectedItem.Text + "','" + txt_self.Text + "','" + drp_pro.SelectedItem.Text + "','" + txt_pro.Text + "','" + drp_team.SelectedItem.Text + "','" + txt_team.Text + "','" + drp_commit.SelectedItem.Text + "','" + txt_commit.Text + "','" + drp_client.SelectedItem.Text + "','" + txt_client.Text + "','" + drp_plan.SelectedItem.Text + "','" + txt_plan.Text + "','" + drp_mentor.SelectedItem.Text + "','" + txt_mentor.Text + "','" + txtappr.Text + "','" + txt_training.Text + "','" + txtcmnt_aap.Text + "','" + txtcmnt_appr.Text + "','" + UserCode + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','1'," + Convert.ToInt32(Session["appcycle"]) + ",'" + APP_year + "','" + quater + "')";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

                string str4 = @"update tbl_appraisal_assessment set behavior_color='EmpRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + UserCode + "' and quater='" + quater + "' and APP_year= '" + APP_year + "' ";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str4);
            }
            else
            {
                string str = @"Insert Into tbl_appraisal_rating_details_1(assessment_id,empcode,fun_skill_rating,fun_skill_cmnt,quality_rating,quality_cmnt,comm_skill_rating,comm_skill_cmnt,self_devlop_rating,self_devlop_cmnt,procs_knowldge_rating,procs_knowldge_cmnt,team_participation_rating,team_participation_cmnt,commitment_rating,commitment_cmnt,clnt_cust_orntion_rating,clnt_cust_orntion_cmnt,team_planing_rating,team_planing_cmnt,mentoring_leadrsip_rating,mentoring_leadrsip_cmnt,achievment_of_past_year,training_benefits_to_develop,additional_cmnt,additional_cmnt_1,created_by,created_date,status, applycyclid,APP_year,quater ) values('" + ass_id + "','" + UserCode + "','" + drp_skils.SelectedItem.Text + "','" + funskill.ToString() + "','" + drp_quality.SelectedItem.Text + "','" + txt_quality_cmnt.Text + "','" + drp_comm.SelectedItem.Text + "','" + txt_comm.Text + "','" + drp_self.SelectedItem.Text + "','" + txt_self.Text + "','" + drp_pro.SelectedItem.Text + "','" + txt_pro.Text + "','" + drp_team.SelectedItem.Text + "','" + txt_team.Text + "','" + drp_commit.SelectedItem.Text + "','" + txt_commit.Text + "','" + drp_client.SelectedItem.Text + "','" + txt_client.Text + "','" + drp_plan.SelectedItem.Text + "','" + txt_plan.Text + "','" + drp_mentor.SelectedItem.Text + "','" + txt_mentor.Text + "','" + txtappr.Text + "','" + txt_training.Text + "','" + txtcmnt_aap.Text + "','" + txtcmnt_appr.Text + "','" + UserCode + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','1'," + Convert.ToInt32(Session["appcycle"]) + ",'" + APP_year + "','" + quater + "')";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

                //string str_1 = @"Update tbl_appraisal_rating_details_1 Set assessment_id='" + ass_id + "',fun_skill_rating ='" + drp_skils.SelectedItem.Text + "',fun_skill_cmnt ='" + txt_skill_cmnt.Text + "',quality_rating ='" + drp_quality.SelectedItem.Text + "',quality_cmnt='" + txt_quality_cmnt.Text + "',comm_skill_rating='" + drp_comm.SelectedItem.Text + "',comm_skill_cmnt='" + txt_comm.Text + "',self_devlop_rating ='" + drp_self.SelectedItem.Text + "',self_devlop_cmnt ='" + txt_self.Text + "',procs_knowldge_rating='" + drp_pro.SelectedItem.Text + "',procs_knowldge_cmnt ='" + txt_pro.Text + "',team_participation_rating ='" + drp_team.SelectedItem.Text + "',team_participation_cmnt='" + txt_team.Text + "',commitment_rating='" + drp_commit.SelectedItem.Text + "',commitment_cmnt='" + txt_commit.Text + "',clnt_cust_orntion_rating ='" + drp_client.SelectedItem.Text + "',clnt_cust_orntion_cmnt='" + txt_client.Text + "',team_planing_rating ='" + drp_plan.SelectedItem.Text + "',team_planing_cmnt='" + txt_plan.Text + "',mentoring_leadrsip_rating ='" + drp_mentor.SelectedItem.Text + "',mentoring_leadrsip_cmnt ='" + txt_mentor.Text + "',achievment_of_past_year='" + txtappr.Text + "',training_benefits_to_develop ='" + txt_training.Text + "',additional_cmnt ='" + txtcmnt_aap.Text + "',additional_cmnt_1='" + txtcmnt_appr.Text + "',updated_by='" + UserCode + "',updated_date='" + DateTime.Today + "' where empcode='" + UserCode + "'";
                //SQLServer.ExecuteDataset(Connection, CommandType.Text, str_1);

                string str5 = @"update tbl_appraisal_assessment set behavior_color='EmpRating_G1' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + UserCode + "' and quater='" + quater + "' and APP_year='" + APP_year + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str5);
            }


            bindgoals();

            string str1 = @"update tbl_appraisal_assessment set  trainingdetails='" + txt_training.Text + "',emp_overall_cmt ='" + txtcmnt_aap.Text + "',emp_overall_rating='" + lblOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + UserCode + "' and quater='" + quater + "' and APP_year='" + APP_year + "'";
            SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);

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


        try
        {
            Connection = DataActivity.OpenConnection();
            if (lblOverallRating.Text != "")
            {
                string str1 = @"update tbl_appraisal_assessment set R_cycle=2, trainingdetails='" + txt_training.Text + "',emp_overall_cmt ='" + txtcmnt_aap.Text + "' where status=1 and appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
                flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, str1);
            }
            if (flag > 0)
            {   // sendMail(Session["empcode"].ToString());
                trtraining.Visible = false;
                trbuttons.Visible = false;
                troverall.Visible = false;
                gvGoals.Visible = false;
                gridratings.Visible = false;
                reset();
                Output.Show("Rating Submitted Successfully.");
            }
            else
            {
                Output.Show("Rating is not submitted Successfully");
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

    private void reset()
    {
        drp_skils.SelectedValue = "-1";
        drp_quality.SelectedValue = "-1";
        drp_comm.SelectedValue = "-1";
        drp_self.SelectedValue = "-1";
        drp_pro.SelectedValue = "-1";
        drp_team.SelectedValue = "-1";
        drp_commit.SelectedValue = "-1";
        drp_client.SelectedValue = "-1";
        drp_plan.SelectedValue = "-1";
        drp_mentor.SelectedValue = "-1";
        txt_skill_cmnt.Text = "";
        txt_quality_cmnt.Text = "";
        txt_comm.Text = "";
        txt_self.Text = "";
        txt_pro.Text = "";
        txt_team.Text = "";
        txt_commit.Text = "";
        txt_client.Text = "";
        txt_plan.Text = "";
        txt_mentor.Text = "";
        txtappr.Text = "";
        lblOverallRating.Text = "";
        txt_training.Text = "";
        txtcmnt_aap.Text = "";
        txtcmnt_appr.Text = "";
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmployeeRating.aspx");
    }

    protected void sendMail(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select e.empcode,e.official_email_id,isnull(e.emp_fname,'''')+' ' +isnull(e.emp_m_name,'''')+' ' +isnull(e.emp_l_name,'''') as empname,j.emp_fname+' ' +j.emp_m_name+' ' +j.emp_l_name as supvrname,j.empcode as supvrcode,j.official_email_id as supvrid from tbl_intranet_employee_jobDetails e,
                            tbl_intranet_employee_jobDetails j  where e.supervisorcode=j.empcode and e.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["supvrid"].ToString() != "")
                {
                    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                    string subject = ConfigurationManager.AppSettings["subjectRating"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_RatingEmp2Mgr"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["supvrname"].ToString(), bodyContent);
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["supvrid"].ToString(), "", subject, completeBody, smtp, emailLogo);
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

    protected void btnsave_Click(object sender, EventArgs e)
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            foreach (GridViewRow row in gvGoals.Rows)
            {
                DropDownList parameter = (DropDownList)row.FindControl("ddlpara");
                DropDownList rating = (DropDownList)row.FindControl("txtrating");
                TextBox comments = (TextBox)row.FindControl("txtcomments");
                string str = @"update tbl_appraisal_rating_details set emprating=" + Convert.ToInt32(rating.SelectedValue) + ",empcode='" + Session["empcode"].ToString() + "',parameter='" + parameter.SelectedItem + "',empcomments='" + comments.Text + "' where asd_id=" + Convert.ToInt32(gvGoals.DataKeys[row.RowIndex].Values[0]) + "";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            }

            bindgoals();
            //gvGoals_RowDataBound();
            lblOverallRating.Text = Convert.ToString(Math.Round(Convert.ToDouble(GoalAvgRating.Text == "" ? "0" : GoalAvgRating.Text), 0));
            if (lblOverallRating.Text != "")
            {
                string str1 = @"update tbl_appraisal_assessment set  trainingdetails='" + txttraining.Text + "',emp_overall_cmt ='" + txtOverallComments.Text + "',emp_overall_rating='" + lblOverallRating.Text + "' where appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
            }
            // bindtraining();
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

    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGoals.EditIndex = e.NewEditIndex;
        bindgoals();
        DropDownList editrating = (DropDownList)gvGoals.Rows[e.NewEditIndex].FindControl("txteditrating");
        Label lblrating = (Label)gvGoals.Rows[e.NewEditIndex].FindControl("lblrating1");
        if (editrating != null)
        {
            editrating.DataTextField = "rating";
            editrating.DataValueField = "rating_id";
            editrating.DataSource = getRatings();
            editrating.DataBind();
            //  editrating.Items.Insert(0, new ListItem("Select", "0"));
            editrating.SelectedValue = lblrating.Text;
        }
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;
        bindgoals();
        gvGoals_RowDataBound();

    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            DropDownList rating = (DropDownList)gvGoals.Rows[e.RowIndex].FindControl("txteditrating");
            TextBox comments = (TextBox)gvGoals.Rows[e.RowIndex].FindControl("txteditcomments");
            string str = @"update tbl_appraisal_rating_details set emprating=" + Convert.ToInt32(rating.SelectedValue) + ",empcomments='" + comments.Text + "' where asd_id=" + Convert.ToInt32(gvGoals.DataKeys[e.RowIndex].Values[0]) + "";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.EditIndex = -1;
            bindgoals();
            gvGoals_RowDataBound();
            lblOverallRating.Text = Convert.ToString(Math.Round(Convert.ToDouble(GoalAvgRating.Text == "" ? "0" : GoalAvgRating.Text), 0));
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

    protected void gvGoals_RowDataBound()
    {

        try
        {
            grdTotal = 0;
            ratingweightagetotal = 0;
            decimal mgrrowTotal = 0;
            decimal mgrrowrating = 0;
            foreach (GridViewRow row in gvGoals.Rows)
            {
                Label weightage = (Label)row.FindControl("lblweightage");
                Label rating = (Label)row.FindControl("lblrating");
                Label mgrrating = (Label)row.FindControl("lblmgrrating");
                decimal rowTotal = 0;
                if (weightage.Text == "")
                    rowTotal = 0;
                else
                {
                    rowTotal = Convert.ToDecimal(weightage.Text.Trim());
                    mgrrowTotal = Convert.ToDecimal(weightage.Text.Trim());
                }
                decimal rowrating = 0;
                if (rating.Text == "")
                    rowrating = 0;
                else
                    rowrating = Convert.ToDecimal(rating.Text.Trim());

                ratingweightagetotal = ratingweightagetotal + (rowTotal * rowrating);
                grdTotal = grdTotal + rowTotal;
                //-----------------mgr
                if (mgrrating.Text == "")
                    mgrrowrating = 0;
                else
                    mgrrowrating = Convert.ToDecimal(mgrrating.Text.Trim());
                mgrratingweightagetotal = mgrratingweightagetotal + (mgrrowTotal * mgrrowrating);

                mgrgrdTotal = mgrgrdTotal + mgrrowTotal;

            }
            Label lblavgrating = (Label)gvGoals.FooterRow.FindControl("lblGoalsAvgRating");
            lblavgrating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
            GoalAvgRating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
            if (mgrratingweightagetotal != 0)
            {
                Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
                lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(". Please contact system admin. For error details please go through the log file.");
        }
    }

    protected void btnSubmitHR_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (lblOverallRating.Text != "")
            {
                string str1 = @"update tbl_appraisal_assessment set R_cycle=6,I_cycle=0, trainingdetails='" + txttraining.Text + "',emp_overall_cmt ='" + txtOverallComments.Text + "',emp_overall_rating='" + lblOverallRating.Text + "',Cycle_closeddate=getdate() where status=1 and appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
                //SendEmailCycle1(Session["empcode"].ToString(), Convert.ToInt32(Session["appcycle"]));
            }

            Response.Redirect("EmployeeRating.aspx?updated=true");
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

    void SendEmailCycle1(string empcode, int appraisalId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Appraisal.SubmittingToHRRating1();
        EmailClient client = new EmailClient(email);
        Approvers.Appraisal.Approvers appovers = new Approvers.Appraisal.Approvers();

        DataRow row = appovers.GetApprovers(empcode, appraisalId);

        ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)    // Code given By Siddharth to avoid "The remote certificate is invalid according to the validation procedure"
        {
            return true;
        };
        client.toEmailId = row["hremailid"].ToString().Trim();
        client.empCode = row["app_hr"].ToString();
        client.employeeName = row["hrname"].ToString().Trim();
        client.requestNumber = row["emp_fname"].ToString() + " (" + row["empcode"].ToString() + ") ";
        client.Send();
    }

    protected void btnSubmitBUH_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (lblOverallRating.Text != "")
            {
                string str1 = @"update tbl_appraisal_assessment set R_cycle=2, trainingdetails='" + txttraining.Text + "',emp_overall_cmt ='" + txtOverallComments.Text + "',emp_overall_rating='" + lblOverallRating.Text + "' where status=1 and appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
                SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
            }
            //sendMail(Session["empcode"].ToString());
            Response.Redirect("EmployeeRating.aspx?updated=true");
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

    protected void gvGoals_bindRatingddl()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = "select rating_id,rating  from tbl_appraisal_rating order by rating_id desc";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            foreach (GridViewRow row in gvGoals.Rows)
            {
                DropDownList rating = (DropDownList)row.FindControl("txtrating");
                Label lblrating = (Label)row.FindControl("lblrating");
                rating.DataTextField = "rating";
                rating.DataValueField = "rating_id";
                rating.DataSource = ds3;
                rating.DataBind();
                rating.Items.Insert(0, new ListItem("Select", "0"));

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

    protected void gvGoals_RowDataBound1(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    DropDownList rating = (DropDownList)e.Row.FindControl("txtrating");
        //   // Label lblrating = (Label)e.Row.FindControl("lblrating");
        //    if (rating != null)
        //    {
        //        if (rating.Text.Trim() != "")
        //            rating.Visible = false;
        //        else
        //            rating.Visible = true;
        //    }
        //}

        //if (e.Row.RowState == DataControlRowState.Edit)
        //{
        //    DropDownList editrating = (DropDownList)e.Row.FindControl("txtrating");
        //    Label lblrating = (Label)e.Row.FindControl("lblrating");
        //    editrating.DataTextField = "rating";
        //    editrating.DataValueField = "rating_id";
        //    editrating.DataSource = getRatings();
        //    editrating.DataBind();
        //    editrating.Items.Insert(0, new ListItem("Select", "0"));
        //}
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

    protected void gvGoals_SelectedIndexChanged(object sender, EventArgs e)
    {
        AverageRatingCalculation();
    }

    private void AverageRatingCalculation()
    {

    }

    protected void txtrating_SelectedIndexChanged(object sender, EventArgs e)
    {
        int totalrating = 0;
        decimal res;
        GridViewRow grow = (GridViewRow)((Control)sender).NamingContainer;
        int index = grow.RowIndex;


        for (int i = 0; i < gvGoals.Rows.Count; i++)
        {

            var ddl = gvGoals.Rows[i].FindControl("txtrating") as DropDownList;
            string text = ddl.SelectedItem.Text;
            int value = Convert.ToInt32(ddl.SelectedItem.Value);

            totalrating = totalrating + value;
            res = Convert.ToDecimal(totalrating) / gvGoals.Rows.Count;
            lblOverallRating.Text = res.ToString();
        }
        //var ddlhalf = grdpaper.Rows[index].FindControl("ddltype") as DropDownList;
        //string halfdayvalue = ddlhalf.SelectedValue;
        //ddlhalf.Items[3].Enabled = false;
        //if (value == "1")
        //{
        //    DropDownList halfday = (DropDownList)grow.FindControl("ddltype");
        //    halfday.Visible = false;
        //    ddlhalf.Items[0].Enabled = true;
        //    ddlhalf.SelectedValue = "0";
        //}
        //if (value == "2" || value == "0")
        //{
        //    DropDownList halfday = (DropDownList)grow.FindControl("ddltype");
        //    halfday.Visible = true;
        //    ddlhalf.SelectedValue = "1";
        //    ddlhalf.Items[0].Enabled = false;

        //}
        //txt_nod.Text = "0";
    }

    //protected void drp_skils_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }

    //}
    //protected void drp_quality_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_comm_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_self_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_pro_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_team_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_commit_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_client_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_plan_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}
    //protected void drp_mentor_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (drp_skils.SelectedValue != "0" && drp_quality.SelectedValue != "0" && drp_comm.SelectedValue != "0" && drp_self.SelectedValue != "0" && drp_pro.SelectedValue != "0" && drp_team.SelectedValue != "0" && drp_commit.SelectedValue != "0" && drp_client.SelectedValue != "0" && drp_plan.SelectedValue != "0" && drp_mentor.SelectedValue != "0")
    //    {
    //        totalrating = Convert.ToInt32(drp_skils.SelectedValue) + Convert.ToInt32(drp_quality.SelectedValue) + Convert.ToInt32(drp_comm.SelectedValue) + Convert.ToInt32(drp_self.SelectedValue) + Convert.ToInt32(drp_pro.SelectedValue) + Convert.ToInt32(drp_team.SelectedValue) + Convert.ToInt32(drp_commit.SelectedValue) + Convert.ToInt32(drp_client.SelectedValue) + Convert.ToInt32(drp_plan.SelectedValue) + Convert.ToInt32(drp_mentor.SelectedValue);
    //        lblOverallRating.Text = Convert.ToString(totalrating / 10);
    //        troverall.Visible = true;
    //    }
    //    else
    //    {
    //        troverall.Visible = false;
    //    }
    //}

    public void calculaterating()
    {

        if (drp_skils.SelectedValue != "-1")
        {
            x = Convert.ToInt32(drp_skils.SelectedValue);
            i = 1;

        }
        if (drp_quality.SelectedValue != "-1")
        {
            y = Convert.ToInt32(drp_quality.SelectedValue);
            x = x + y;
            i = i + 1;

        }
        if (drp_comm.SelectedValue != "-1")
        {
            z = Convert.ToInt32(drp_comm.SelectedValue);
            x = x + z;
            i = i + 1;

        }
        if (drp_self.SelectedValue != "-1")
        {
            s = Convert.ToInt32(drp_self.SelectedValue);
            x = x + s;
            i = i + 1;

        }
        if (drp_pro.SelectedValue != "-1")
        {
            a = Convert.ToInt32(drp_pro.SelectedValue);
            x = x + a;
            i = i + 1;

        }
        if (drp_team.SelectedValue != "-1")
        {
            b = Convert.ToInt32(drp_team.SelectedValue);
            x = x + b;
            i = i + 1;

        }
        if (drp_commit.SelectedValue != "-1")
        {
            c = Convert.ToInt32(drp_commit.SelectedValue);
            x = x + c;
            i = i + 1;

        }
        if (drp_client.SelectedValue != "-1")
        {
            d = Convert.ToInt32(drp_client.SelectedValue);
            x = x + d;
            i = i + 1;

        }
        if (drp_plan.SelectedValue != "-1")
        {
            e = Convert.ToInt32(drp_plan.SelectedValue);
            x = x + e;
            i = i + 1;

        }
        if (drp_mentor.SelectedValue != "-1")
        {
            f = Convert.ToInt32(drp_mentor.SelectedValue);
            x = x + f;
            i = i + 1;

        }

        decimal xx = Convert.ToDecimal(x) / Convert.ToDecimal(i);
        lblOverallRating.Text = xx.ToString();//


    }

    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void Dropappcycle_id_DataBound(object sender, EventArgs e)
    {
        Dropappcycle_id.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void Dropappcycle_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Session["Dropappcycle_id"] = Dropappcycle_id.SelectedValue.ToString();

    }
}