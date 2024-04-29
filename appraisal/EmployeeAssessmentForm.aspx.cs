using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;


public partial class appraisal_EmployeeAssessmentForm : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;

    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    DataActivity DataActivity = new DataActivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        getActiveCycle();
        if (!IsPostBack)
        {
            bindEmpDetails(Session["empcode"].ToString());
            bindratingrid();
            bindgoals();
            if (hdinccycle.Value == "4")
            {
                tabpreinc.Visible = true;
                tabcurinc.Visible = true;
                bindEmpIncreamentDetails(Session["empcode"].ToString());
                bindHREmpIncreamentDetails(Session["empcode"].ToString());

            }
            else
            {
                tabpreinc.Visible = false;
                tabcurinc.Visible = false;

            }

        }
    }
    private void bindHREmpIncreamentDetails(string EmployeeCode)
    {
        SqlParameter[] sqlparam1 = new SqlParameter[2];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, EmployeeCode);
            Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisalincreament_getEmployeeDetails_approver", sqlparam1);
            if (dse.Tables[0].Rows.Count >= 1)
            {
                lbldoj.Text = dse.Tables[0].Rows[0]["emp_doj"].ToString();
                // lbldept.Text = dse.Tables[0].Rows[0]["dept"].ToString();
                lbldes.Text = dse.Tables[0].Rows[0]["lastdesignation"].ToString();
                lblpregrade.Text = dse.Tables[0].Rows[0]["lastgrade"].ToString();
                lblprectc.Text = dse.Tables[0].Rows[0]["CTC"].ToString();
                lblprehike.Text = dse.Tables[0].Rows[0]["lasthike"].ToString();
                lblprebonus.Text = dse.Tables[0].Rows[0]["lastBonus"].ToString();

                lblrevloc.Text = dse.Tables[0].Rows[0]["curworklocation"].ToString();
                lblrevdept.Text = dse.Tables[0].Rows[0]["curdept"].ToString();
                lblrevdes.Text = dse.Tables[0].Rows[0]["curdesignation"].ToString();
                lblrevgrade.Text = dse.Tables[0].Rows[0]["curgrade"].ToString();
                lblrevcostcenter.Text = dse.Tables[0].Rows[0]["curcostcenter"].ToString();
                lblcurhike.Text = dse.Tables[0].Rows[0]["curhike"].ToString();
                lblincramount.Text = dse.Tables[0].Rows[0]["curbouns"].ToString();
                lblcurctc.Text = dse.Tables[0].Rows[0]["curctc"].ToString();
                lblcurbonus.Text = dse.Tables[0].Rows[0]["curincreasedamount"].ToString();
                lblrevdate.Text = dse.Tables[0].Rows[0]["wefdate"].ToString();
                // lblprecomm.Text = dse.Tables[0].Rows[0]["comments"].ToString();
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
    private void bindEmpIncreamentDetails(string EmployeeCode)
    {

        SqlParameter[] sqlparam1 = new SqlParameter[2];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, EmployeeCode);
            Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisalincreament_getEmployeeDetails", sqlparam1);
            if (dse.Tables[0].Rows.Count >= 1)
            {
                lbldoj.Text = dse.Tables[0].Rows[0]["emp_doj"].ToString();
                // lbldept.Text = dse.Tables[0].Rows[0]["dept"].ToString();
                lbldes.Text = dse.Tables[0].Rows[0]["designation"].ToString();
                lblpregrade.Text = dse.Tables[0].Rows[0]["grade"].ToString();
                lblprectc.Text = dse.Tables[0].Rows[0]["CTC"].ToString();
                lblprehike.Text = dse.Tables[0].Rows[0]["lasthike"].ToString();
                lblprebonus.Text = dse.Tables[0].Rows[0]["lastbouns"].ToString();
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
                hdinccycle.Value = (dse.Tables[0].Rows[0]["I_cycle"].ToString());
                gvGoals.Columns[8].Visible = false;
                gvGoals.Columns[9].Visible = false;
                gvGoals.Columns[5].Visible = false;
                //if ((dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "5")) // goal cycle 1 - employee or hr freeze goals
                //{
                lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["additional_cmnt"].ToString();
                lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                    goalcycle1.Visible = true;
                  
                    lblcyl1intdate.Text = dse.Tables[0].Rows[0]["G1_initiateddate"].ToString();
                    lblgol2intdate.Text = dse.Tables[0].Rows[0]["G2_initiateddate"].ToString();
                    gvGoals.Columns[5].Visible = true;
               // }
                //if ((dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6") &&  ((dse.Tables[0].Rows[0]["G2_cycle"].ToString() != "6") || (dse.Tables[0].Rows[0]["G2_cycle"].ToString() != "5")))// goal cycle 2 - employee or hr freeze goals
                //{
                    gvGoals.Columns[5].Visible = false;
                //}
                //if ((dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "5")) // goal cycle 2 - employee or hr freeze goals
                //{
                    lbempcmts.Text = dse.Tables[0].Rows[0]["additional_cmnt_cycle2"].ToString();
                    txtmgrComments.Text = dse.Tables[0].Rows[0]["LM_appraiser_cmnt_cycle2"].ToString();

                    lblgoal1byBHcmnts.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                    lblgoal1byBHcmntscycle2.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt_cycle2"].ToString();
                    lblgolfrzdatecycle2.Text = dse.Tables[0].Rows[0]["freezecycle2date"].ToString();

                    lblgolfrzdate.Text = dse.Tables[0].Rows[0]["F_initiateddate"].ToString();
                    lblratintdate.Text = dse.Tables[0].Rows[0]["R_initiateddate"].ToString();
                    cycleclosedate.Text = dse.Tables[0].Rows[0]["Cycle_closeddate"].ToString();
                    goalcycle2.Visible = true;
                    gvGoals.Columns[5].Visible = true;
                //}
                //if ((dse.Tables[0].Rows[0]["R_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["R_cycle"].ToString() == "5")) // Rating - employee or hr freeze goals
                //{
                   // rating.Visible = true;
                    trTraining1.Visible = true;
                    gvGoals.Columns[8].Visible = true;
                    gvGoals.Columns[9].Visible = true;

                    //if (dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString() != "")
                    //{
                    //    lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                    //}
                    //if (dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString() != "")
                    //{
                    //    lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                    //}
                    //if (dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString() != "")
                    //{
                    //    lblgoal1byBHcmnts.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                    //}

               // }
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
            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1 ";
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

        SqlParameter[] sqlParam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.weightage,aps.emp_comments,aps.mng_comments  ,apt.trainingdetails,sd.empcomments,sd.emprating,sd.mgrcomments,sd.mgrrating from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1   and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                txttraining.Text = ds.Tables[0].Rows[0]["trainingdetails"].ToString();
                //if (ds.Tables[0].Rows[0]["emprating"].ToString() != "")
                //{
                //gvGoals.Columns[5].Visible = true;
                //gvGoals.Columns[6].Visible = true;
                troverall1.Visible = true;
                gvGoals.ShowFooter = true;
             //   trTraining1.Visible = true;

                gvGoals_RowDataBound();
                bindtraining();
                //}
                //else
                //{
                //    gvGoals.Columns[4].Visible = false;
                //    gvGoals.Columns[5].Visible = false;
                //    gvGoals.ShowFooter = false;

                //    trTraining1.Visible = false;

                //}

            }
            else
            {

                trTraining1.Visible = false;

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
    protected void bindtraining()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,mgr_overall_rating,mgr_overall_cmt,behavior_color from tbl_appraisal_assessment where  status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "' ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txttraining.Text = ds.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblOverallRating.Text = ds.Tables[0].Rows[0]["emp_overall_rating"].ToString();
                txtOverallComments.Text = ds.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                lblMgrOverallRating.Text = ds.Tables[0].Rows[0]["mgr_overall_rating"].ToString();
                txtMgrOverallComments.Text = ds.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
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



    protected void gvGoals_RowDataBound()
    {
        //mgrgrdTotal = 0;
        //grdTotal = 0;
        //ratingweightagetotal = 0;
        //mgrratingweightagetotal = 0;
        //foreach (GridViewRow row in gvGoals.Rows)
        //{
        //    Label weightage = (Label)row.FindControl("lblweightage");
        //    Label rating = (Label)row.FindControl("lblemprating");
        //    Label mgrrating = (Label)row.FindControl("lblrating");
        //    decimal rowTotal = 0;
        //    decimal mgrrowTotal = 0;
        //    decimal rowrating = 0;
        //    decimal mgrrowrating = 0;

        //    if (weightage.Text == "")
        //    {
        //        rowTotal = 0;
        //        mgrrowTotal = 0;
        //    }
        //    else
        //    {
        //        rowTotal = Convert.ToDecimal(weightage.Text.Trim());
        //        mgrrowTotal = Convert.ToDecimal(weightage.Text.Trim());
        //    }


        //    if (rating.Text == "")
        //        rowrating = 0;
        //    else
        //        rowrating = Convert.ToDecimal(rating.Text.Trim());

        //    ratingweightagetotal = ratingweightagetotal + (rowTotal * rowrating);

        //    grdTotal = grdTotal + rowTotal;

        //    //-----------------mgr
        //    if (mgrrating.Text == "")
        //        mgrrowrating = 0;
        //    else
        //        mgrrowrating = Convert.ToDecimal(mgrrating.Text.Trim());
        //    mgrratingweightagetotal = mgrratingweightagetotal + (mgrrowTotal * mgrrowrating);

        //    mgrgrdTotal = mgrgrdTotal + mgrrowTotal;

        //}
        //if (gvGoals.Rows.Count > 0)
        //{
        //    Label lblavgrating = (Label)gvGoals.FooterRow.FindControl("lblGoalsAvgRating");
        //    lblavgrating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
        //    GoalAvgRating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));

        //    if (mgrratingweightagetotal != 0)
        //    {
        //        Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
        //        lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
        //    }
        //}
    }

}