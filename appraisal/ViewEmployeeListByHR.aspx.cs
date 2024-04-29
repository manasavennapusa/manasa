using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using System.IO;
using System.Web;

public partial class appraisal_ViewEmployeeListByHR : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    string EmployeeCode = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        UserCode = Session["empcode"].ToString();
        getActiveCycle();
        if (!IsPostBack)
        {
            if (gveligible.Rows.Count <= 0)
                gveligible.EmptyDataText = "No Records Found!.";
          
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
                bindGoals(EmployeeCode);
                gvGoals_RowDataBound();

                bindtraining(EmployeeCode);
            }


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


    protected void btn_search_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            //Connection = DataActivity.OpenConnection();
            //Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            //Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            //Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, ddl_dept.SelectedValue);

            //DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_listof_EmpforHR", sqlparam);

            string sqlstr = @"select distinct empjob.empcode,empappr.appcycle_id,isnull(emp_fname ,'''')+ ''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,
(
case 
when appast.G1_cycle=1 and appast.G2_cycle=0 then 'Goal cycle Initiated'
when appast.G2_cycle=1 then 'Goal cycle 1 and 2 Initiated'
when appast.freeze=1 then 'Freezed' end 
)as GoalStatus,

(
case when  (appast.trainingdetails is null or behavior_color is null) then 'Employee Rating pending'
when appast.behavior_color='EmpRating_G1' then 'Employee Rating completed'
when appast.behavior_color='ManagerRating_G1' then 'Line Manager Rating Completed'
when appast.behavior_color='BHRating_G1' then 'Business Head Rating Completed'
when appast.behavior_color='EmpRating_G2' then 'Employee Rating completed'
when appast.behavior_color='ManagerRating_G2' then 'Line Manager Rating Completed'
--when appast.behavior_color='BHRating_G2' then 'Business Head Rating Completed'
when appast.behavior_color='BHRating_G2' then 'Rating Completed'
end 
)as RatingStatus,

(
case when  appast.I_cycle=0  then 'Not_Inititated' when appast.I_cycle=1  then 'Inititated' when appast.I_cycle=2  then 'Approved_with_HRD'
when appast.I_cycle=3  then 'Approved_with_MD' when appast.I_cycle=4  then 'Approved' 
when appast.I_cycle=5  then 'Rejected'end 
)as IncreamentStatus,empappr.status,empappr.create_by   
               
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment appast on appast.empcode=empappr.empcode and empappr.appcycle_id=appast.appcycle_id
and appast.APP_year=empappr.APP_year and appast.quater=empappr.quater
left join tbl_appraisal_rating_details_1 rtdtl on rtdtl.empcode=appast.empcode
left join tbl_appraisal_approver_LM_rating_details lm_rtng_dtl on appast.empcode=lm_rtng_dtl.empcode and appast.appcycle_id=lm_rtng_dtl.applycyclid
where 1=1 and empappr.create_by='" + UserCode + "'  and empjob.emp_status in(1,3) and  empappr.isdeleted=0 and appast.status in(1,3) and empjob.empcode='" + txt_employee.Text + "' and empdept.department_name='" + ddl_dept.SelectedItem.Text + "' and empappr.appcycle_id='" + Session["appcycle"] + "'";

            DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            gveligible.DataSource = ds;
            gveligible.DataBind();
            ViewState["Getemp"] = ds;
            txt_employee.Text = "";
            ddl_dept.SelectedValue = "0";
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

    private void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            //            string sqlstr = @"select distinct empjob.empcode,empappr.appcycle_id,isnull(emp_fname ,'''')+ ''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
            //rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
            //convert(varchar(10),empjob.emp_doj,101) as emp_doj,
            //(case 
            //when appast.line_manager_comment is null  then 'Line Manager Review Pending'
            //when appast.line_manager_comment is not null and appast.G1_cycle=0  then 'Goal cycle 1 Not Initiated'
            //when appast.G1_cycle=1 and appast.G2_cycle=0 then 'Goal cycle 1 Initiated'
            //when appast.G2_cycle=1 then 'Goal cycle 1 and 2 Initiated'
            //when appast.freeze=1 then 'Freezed' end )as GoalStatus,
            //
            //(case 
            //when  rtdtl.empcode is not null and lm_rtng_dtl.empcode is null then 'Employee Rating completed'
            //when rtdtl.empcode is null and lm_rtng_dtl.empcode is null then 'Employee Rating Pending'
            //when lm_rtng_dtl.LM_appraiser_cmnt is not null and lm_rtng_dtl.BH_appraiser_cmnt is null  then 'Line Manager Rating Completed'
            //when lm_rtng_dtl.empcode is not null and lm_rtng_dtl.BH_appraiser_cmnt is not null then 'Business Head Rating Completed'
            //when appast.freeze=1 and R_cycle=6 then 'Rating_Cycle_Completed' end )as RatingStatus,
            //
            //(case when  appast.I_cycle=0  then 'Not_Inititated' when appast.I_cycle=1  then 'Inititated' when appast.I_cycle=2  then 'Approved_with_HRD'
            //when appast.I_cycle=3  then 'Approved_with_MD' when appast.I_cycle=4  then 'Approved' 
            //when appast.I_cycle=5  then 'Rejected'end )as IncreamentStatus,empappr.status,empappr.create_by                  
            //from tbl_intranet_employee_jobDetails empjob
            //inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
            //inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
            //inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
            //inner join tbl_appraisal_assessment appast on appast.empcode=empappr.empcode
            //left join tbl_appraisal_rating_details_1 rtdtl on rtdtl.empcode=appast.empcode
            //left join tbl_appraisal_approver_LM_rating_details lm_rtng_dtl on appast.empcode=lm_rtng_dtl.empcode
            //
            //where 1=1 and empappr.create_by='"+UserCode+"'  and empjob.emp_status in(1,3) and  empappr.isdeleted=0 and appast.status in(1,3) order by empjob.empcode";



            string sqlstr = @"select distinct empjob.empcode,empappr.appcycle_id,isnull(emp_fname ,'''')+ ''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,
(
case 
when appast.G1_cycle=1 and appast.G2_cycle=0 then 'Goal cycle Initiated'
when appast.G2_cycle=1 then 'Goal cycle 1 and 2 Initiated'
when appast.freeze=1 then 'Freezed' end 
)as GoalStatus,

(
case when (appast.trainingdetails is null or behavior_color is null) then 'Employee Rating pending'
when appast.behavior_color='EmpRating_G1' then 'Employee Rating completed'
when appast.behavior_color='ManagerRating_G1' then 'Line Manager Rating Completed'
when appast.behavior_color='BHRating_G1' then 'Business Head Rating Completed'
when appast.behavior_color='EmpRating_G2' then 'Employee Rating completed'
when appast.behavior_color='ManagerRating_G2' then 'Line Manager Rating Completed'
--when appast.behavior_color='BHRating_G2' then 'Business Head Rating Completed '
when appast.behavior_color='BHRating_G2' then 'Rating Completed'
end 
)as RatingStatus,

(
case when  appast.I_cycle=0  then 'Not_Inititated' when appast.I_cycle=1  then 'Inititated' when appast.I_cycle=2  then 'Approved_with_HRD'
when appast.I_cycle=3  then 'Approved_with_MD' when appast.I_cycle=4  then 'Approved' 
when appast.I_cycle=5  then 'Rejected'end 
)as IncreamentStatus,empappr.status,empappr.create_by   
               
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment appast on appast.empcode=empappr.empcode and empappr.appcycle_id=appast.appcycle_id 
and appast.APP_year=empappr.APP_year and appast.quater=empappr.quater
left join tbl_appraisal_rating_details_1 rtdtl on rtdtl.empcode=appast.empcode
left join tbl_appraisal_approver_LM_rating_details lm_rtng_dtl on appast.empcode=lm_rtng_dtl.empcode and appast.appcycle_id=lm_rtng_dtl.applycyclid 
where 1=1 and empappr.create_by='" + UserCode + "'  and empjob.emp_status in(1,3) and  empappr.isdeleted=0 and appast.status in(1,3) and empappr.appcycle_id='" + Session["appcycle"] + "' order by empjob.empcode ";

            DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            emplist.Visible = true;
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


    //protected void dd_dpt_DataBound(object sender, EventArgs e)
    //{
    //    dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

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
                lblbuh.Text = dse.Tables[0].Rows[0]["bhu"].ToString();
                txttraining.Text = dse.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblReview.Text = dse.Tables[0].Rows[0]["app_cycle"].ToString();
                //lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
                //if ((dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6"))
                //{
                lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                //}
                //if ((dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6"))
                //{
                    lbempcmts.Text = dse.Tables[0].Rows[0]["G2_emp_comments"].ToString();
                    txtmgrComments.Text = dse.Tables[0].Rows[0]["G2_mgr_comments"].ToString();
                //}
                    lblcyl1intdate.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                lblgol2intdate.Text = dse.Tables[0].Rows[0]["G2_initiateddate"].ToString();
                lblgolfrzdate.Text = dse.Tables[0].Rows[0]["F_initiateddate"].ToString();
                lblratintdate.Text = dse.Tables[0].Rows[0]["R_initiateddate"].ToString();
                cycleclosedate.Text = dse.Tables[0].Rows[0]["Cycle_closeddate"].ToString();
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
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage,approvertype as createdtype from tbl_appraisal_assessment_details aps
                                    inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id   inner join tbl_appraisal_flow f on f.flow_id=aps.flow_id where apt.status=1  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txttraining.Text = ds.Tables[0].Rows[0]["trainingdetails"].ToString();
                if (ds.Tables[0].Rows[0]["emprating"].ToString() != "")
                {
                    gvGoals.Columns[4].Visible = true;
                    gvGoals.Columns[5].Visible = true;
                    troverall1.Visible = true;
                    gvGoals.ShowFooter = true;
                    gvGoals_RowDataBound();
                    //bindtraining();
                }
                else
                {
                    gvGoals.Columns[4].Visible = false;
                    gvGoals.Columns[5].Visible = false;
                    gvGoals.ShowFooter = false;
                    troverall1.Visible = false;
                }
                if (ds.Tables[0].Rows[0]["mgrrating"].ToString() != "")
                {
                    gvGoals.Columns[6].Visible = true;
                    gvGoals.Columns[7].Visible = true;
                    troverall2.Visible = true;
                }
                else
                {
                    gvGoals.Columns[6].Visible = false;
                    gvGoals.Columns[7].Visible = false;
                    troverall2.Visible = false;
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


    protected void bindGoals(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            //string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage,aps.emp_comments,aps.mng_comments  ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.weightage,aps.emp_comments,aps.mng_comments  ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                //if (ds.Tables[0].Rows[0]["emprating"].ToString() != "")
                //{
                //    gvGoals.Columns[4].Visible = true;
                //    gvGoals.Columns[5].Visible = true;
                //    troverall1.Visible = true;
                //    gvGoals.ShowFooter = true;
                //    gvGoals_RowDataBound();
                //}
                //else
                //{
                //    gvGoals.Columns[4].Visible = false;
                //    gvGoals.Columns[5].Visible = false;
                //    gvGoals.ShowFooter = false;
                //    troverall1.Visible = false;
                //}
                //if (ds.Tables[0].Rows[0]["mgrrating"].ToString() != "")
                //{
                //    gvGoals.Columns[6].Visible = true;
                //    gvGoals.Columns[7].Visible = true;
                //    troverall2.Visible = true;
                //}
                //else
                //{
                //    gvGoals.Columns[6].Visible = false;
                //    gvGoals.Columns[7].Visible = false;
                //    troverall2.Visible = false;
                //}
            }
            else { tblTraining1.Visible = false; }
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
                txtMgrOverallComments.Text = ds.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                //if (ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim() != "")
                //    lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml(ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim());
                if (lblOverallRating.Text == "")
                {
                    troverall1.Visible = false;
                    trTraining1.Visible = false;
                    trTraining2.Visible = false;
                }
                else
                {
                    troverall1.Visible = true;
                    trTraining1.Visible = true;
                    trTraining2.Visible = true;
                }

                if (lblMgrOverallRating.Text == "")
                {
                    tdcolor1.Visible = false;
                    tdcolor2.Visible = false;
                    troverall2.Visible = false;
                }
                else
                {
                    tdcolor1.Visible = true;
                    tdcolor2.Visible = true;
                    troverall2.Visible = true;
                }
            }
            else
            {
                troverall2.Visible = false;
                troverall1.Visible = false;
                trTraining1.Visible = false;
                trTraining2.Visible = false;
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

    protected void gvGoals_RowDataBound()
    {

        try
        {

            mgrgrdTotal = 0;
            grdTotal = 0;
            ratingweightagetotal = 0;
            mgrratingweightagetotal = 0;
            foreach (GridViewRow row in gvGoals.Rows)
            {
                Label weightage = (Label)row.FindControl("lblweightage");
                Label rating = (Label)row.FindControl("lblemprating");
                Label mgrrating = (Label)row.FindControl("lblrating");
                decimal rowTotal = 0;
                decimal mgrrowTotal = 0;
                decimal rowrating = 0;
                decimal mgrrowrating = 0;

                if (weightage.Text == "")
                {
                    rowTotal = 0;
                    mgrrowTotal = 0;
                }
                else
                {
                    rowTotal = Convert.ToDecimal(weightage.Text.Trim());
                    mgrrowTotal = Convert.ToDecimal(weightage.Text.Trim());
                }

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
            if (ratingweightagetotal != 0)
            {
                Label lblavgrating = (Label)gvGoals.FooterRow.FindControl("lblGoalsAvgRating");
                lblavgrating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
                GoalAvgRating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
            }
            if (mgrratingweightagetotal != 0)
            {
                Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
                lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
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

    protected void ddl_dept_DataBound(object sender, EventArgs e)
    {
        ddl_dept.Items.Insert(0, new ListItem("----- All -----", "0"));
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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewEmployeeListByHR.aspx");
    }
  
    protected void gveligible_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string id = (string)gveligible.DataKeys[e.RowIndex].Value;
            string appcycleid = Session["appcycle"].ToString();

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, id.Trim());
            Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 0, appcycleid);
            Output.AssignParameter(sqlparam, 2, "@createdby", "String", 50, Session["empcode"].ToString());

            int ins = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_deleteeligibleemployee", sqlparam);
            if (ins > 0)
            {
                bindgrid();
                // sendMailOnDelete(id);
                Output.Show("Record deleted successfully.");
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
    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
       else gveligible.EmptyDataText = "No Records Found";
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }
    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
        {
            gveligible.HeaderRow.Cells[6].Visible = false;
            gveligible.HeaderRow.Cells[8].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gveligible.Rows.Count; i++)
            {
                GridViewRow row = gveligible.Rows[i];
                row.Cells[6].Visible = false;
                row.Cells[8].Visible = false;
                gveligible.Columns[6].Visible = false;
                gveligible.Columns[8].Visible = false;
            }
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Current Appraisal List" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < gveligible.Rows.Count; i++)
            {

                gveligible.Rows[i].Style.Add("width", "150px");
                gveligible.Rows[i].Style.Add("height", "20px");
            }

            gveligible.GridLines = GridLines.Both;
            gveligible.HeaderStyle.Font.Bold = true;
            gveligible.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
    }
}