using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using DataAccessLayer;

public partial class appraisal_ViewEmployeelistByBusinessHead : System.Web.UI.Page
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
                bindGoals(EmployeeCode);
                gvGoals_RowDataBound();
                bindtraining(EmployeeCode);
                if (hdinccycle.Value == "4")
                {
                    tabpreinc.Visible = true;
                    tabcurinc.Visible = true;
                    bindEmpIncreamentDetails(Request.QueryString["empcode"].ToString());
                    bindHREmpIncreamentDetails(Request.QueryString["empcode"].ToString());
                }
                else
                {
                    tabpreinc.Visible = false;
                    tabcurinc.Visible = false;
                }
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
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, ddl_dept.SelectedValue);

            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_listof_EmpforManagement", sqlparam);

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

    private void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");


            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_listof_EmpforManagement", sqlparam);
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
                hdinccycle.Value = (dse.Tables[0].Rows[0]["I_cycle"].ToString());
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
                    lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["additional_cmnt"].ToString();
                    lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                    lblbhcmntcycle1.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                    lblbhcmntcycle2.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt_cycle2"].ToString();
                    lblgolfrzdatecycle2.Text = dse.Tables[0].Rows[0]["freezecycle2date"].ToString();
                //}
                //if ((dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6"))
                //{
                   // lbempcmtscycle2.Text = dse.Tables[0].Rows[0]["additional_cmnt_cycle2"].ToString();
                   // txtmgrCommentscycle2.Text = dse.Tables[0].Rows[0]["LM_appraiser_cmnt_cycle2"].ToString();
               // }
                lblcyl1intdate.Text = dse.Tables[0].Rows[0]["G1_initiateddate"].ToString();
                lblgol2intdate.Text = dse.Tables[0].Rows[0]["G2_initiateddate"].ToString();
                lblgolfrzdatecycle1.Text = dse.Tables[0].Rows[0]["F_initiateddate"].ToString();
                lblratintdate.Text = dse.Tables[0].Rows[0]["R_initiateddate"].ToString();
                cycleclosedate.Text = dse.Tables[0].Rows[0]["Cycle_closeddate"].ToString();
                //lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                //lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
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
            string str = @"select apt.as_id,aps.asd_id,apt.empcode,apt.trainingdetails,aps.title,aps.description,aps.weightage,aps.createdtype ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments  from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.as_id=apt.as_id inner join tbl_appraisal_assessment_subdetails sd on sd.asd_id=aps.asd_id where apt.status=1 and aps.type='G' and apt.apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and  aps.empcode='" + Session["empcode"].ToString() + "'";
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
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.weightage,aps.emp_comments,aps.mng_comments ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
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
                if (ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim() != "")
                    //lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml(ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim());

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

                if (lblMgrOverallRating.Text.Trim() == "")
                {
                    troverall2.Visible = false;
                    tdcolor1.Visible = false;
                    tdcolor2.Visible = false;
                }
                else
                {
                    troverall2.Visible = true;
                    tdcolor1.Visible = true;
                    tdcolor2.Visible = true;
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
        //SqlConnection Connection = null;
        //try
        //{
        //    Connection = DataActivity.OpenConnection();

        //    mgrgrdTotal = 0;
        //    grdTotal = 0;
        //    ratingweightagetotal = 0;
        //    mgrratingweightagetotal = 0;
        //    foreach (GridViewRow row in gvGoals.Rows)
        //    {
        //        Label weightage = (Label)row.FindControl("lblweightage");
        //        Label rating = (Label)row.FindControl("lblemprating");
        //        Label mgrrating = (Label)row.FindControl("lblrating");
        //        decimal rowTotal = 0;
        //        decimal mgrrowTotal = 0;
        //        decimal rowrating = 0;
        //        decimal mgrrowrating = 0;

        //        if (weightage.Text == "")
        //        {
        //            rowTotal = 0;
        //            mgrrowTotal = 0;
        //        }
        //        else
        //        {
        //            rowTotal = Convert.ToDecimal(weightage.Text.Trim());
        //            mgrrowTotal = Convert.ToDecimal(weightage.Text.Trim());
        //        }


        //        if (rating.Text == "")
        //            rowrating = 0;
        //        else
        //            rowrating = Convert.ToDecimal(rating.Text.Trim());

        //        ratingweightagetotal = ratingweightagetotal + (rowTotal * rowrating);

        //        grdTotal = grdTotal + rowTotal;

        //        //-----------------mgr
        //        if (mgrrating.Text == "")
        //            mgrrowrating = 0;
        //        else
        //            mgrrowrating = Convert.ToDecimal(mgrrating.Text.Trim());
        //        mgrratingweightagetotal = mgrratingweightagetotal + (mgrrowTotal * mgrrowrating);

        //        mgrgrdTotal = mgrgrdTotal + mgrrowTotal;

        //    }
        //    if (ratingweightagetotal != 0)
        //    {
        //        Label lblavgrating = (Label)gvGoals.FooterRow.FindControl("lblGoalsAvgRating");
        //        lblavgrating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
        //        GoalAvgRating.Text = Convert.ToString(Math.Round((decimal)(ratingweightagetotal / grdTotal), 0));
        //    }
        //    if (mgrratingweightagetotal != 0)
        //    {
        //        Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
        //        lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //    Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        //}

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
        Response.Redirect("ViewEmployeelistByBusinessHead.aspx");
    }
    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }
    protected void Dropappcycle_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        string usercode= Request.QueryString["empcode"].ToString();
         string empcode = Session["empcode"].ToString();


         string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where appcycle_id='" + Dropappcycle_id.SelectedValue.ToString() + "'";

         DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query1);
         string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
         string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();

        try
        {
            string sqlstr = @"select distinct lm_rtng.empcode, app.appcycle_id,empjob.empcode,
lm_rtng.LM_appraiser_cmnt,lm_rtng.BH_appraiser_cmnt,
emprating1.additional_cmnt,emprating1.additional_cmnt_1

from tbl_intranet_employee_jobDetails empjob
inner  join tbl_appraisal_assessment app on app.empcode= empjob.empcode 
inner join tbl_appraisal_cycle apc on apc.appcycle_id=app.appcycle_id  
inner join tbl_employee_approvers appapp on empjob.empcode= appapp.empcode
inner join tbl_appraisal_eligible_employee empelg on empelg.empcode=app.empcode and app.appcycle_id =empelg.appcycle_id 
inner  join tbl_intranet_employee_jobDetails e on e.empcode=appapp.app_reportingmanager
inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=empjob.branch_id
inner join tbl_appraisal_approver_LM_rating_details lm_rtng on empjob.empcode=lm_rtng.empcode
inner  join tbl_appraisal_rating_details_1 emprating1 on empjob.empcode=emprating1.empcode 
and lm_rtng.applycyclid=emprating1.applycyclid and app.APP_year=lm_rtng.APP_year and lm_rtng.quater=app.quater 
where app.appcycle_id='" + Dropappcycle_id.SelectedValue.ToString() + "' and app.empcode='" + usercode.Trim() + "' and app.status in (1,3) and empjob.emp_status in (1,3) and appapp.app_businesshead='" + empcode.Trim() + "'";

            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
          
            if (ds.Tables.Count > 0)
            {

                GridView1.DataSource = ds;
                GridView1.DataBind();
                
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
    
    protected void Dropappcycle_id_DataBound(object sender, EventArgs e)
    {
        Dropappcycle_id.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}