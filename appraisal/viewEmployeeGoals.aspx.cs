using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;

public partial class appraisal_viewEmployeeGoals : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;

    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        getActiveCycle();

        if (!IsPostBack)
        {
            bindratingrid();
            bindgoals();
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
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,apt.trainingdetails,aps.title,aps.description,aps.weightage ,aps.emp_comments,aps.mng_comments,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments  from tbl_appraisal_assessment_details aps 
                            inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1 and   apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
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
                    trTraining1.Visible = true;
                    trTraining2.Visible = true;
                    gvGoals_RowDataBound();
                    bindtraining();
                }
                else
                {
                    gvGoals.Columns[4].Visible = false;
                    gvGoals.Columns[5].Visible = false;
                    gvGoals.ShowFooter = false;
                    troverall1.Visible = false;
                    trTraining1.Visible = false;
                    trTraining2.Visible = false;
                }
                if (ds.Tables[0].Rows[0]["allow_supervisor_rating"].ToString() == "True")
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
            else
            {
                troverall.Visible = false;
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
    protected void bindtraining()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,supervisor_overall_rating,supervisor_overall_cmt,behavior_color from tbl_appraisal_assessment where  status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "' ";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txttraining.Text = ds.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblOverallRating.Text = ds.Tables[0].Rows[0]["emp_overall_rating"].ToString();
                txtOverallComments.Text = ds.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                lblMgrOverallRating.Text = ds.Tables[0].Rows[0]["supervisor_overall_rating"].ToString();
                txtMgrOverallComments.Text = ds.Tables[0].Rows[0]["supervisor_overall_cmt"].ToString();
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
            if (gvGoals.Rows.Count > 0)
            {
                Label lblavgrating = (Label)gvGoals.FooterRow.FindControl("lblGoalsAvgRating");
                lblavgrating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
                GoalAvgRating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));

                if (mgrratingweightagetotal != 0)
                {
                    Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
                    lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
                }
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

    }

}