using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;

public partial class appraisal_ViewApprovedRating : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    string EmployeeCode = "";
    DataActivity DataActivity = new DataActivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        getActiveCycle();
        if (!IsPostBack)
        {
            bindgrid();
            empsearch.Visible = true;
            emplist.Visible = true;
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
            if (Request.QueryString["update"] != null)
            {
                Output.Show("Data Saved Successfully");
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

    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 3, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 4, "@department", "Int", 0, ddl_dept.SelectedValue);

            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_EmpRatingByHR", sqlparam);

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
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, "0");
            Output.AssignParameter(sqlparam, 3, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 4, "@department", "Int", 0, "0");
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_EmpRatingByHR", sqlparam);

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
                lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
                //if (dse.Tables[0].Rows[0]["allow_supervisor_rating"].ToString() == "True")
                //{
                //    btn_AllowMgremmts.Enabled = false;
                //    btn_AllowMgremmts.Text = "Rating Notified";
                //    btn_AllowMgremmts.ToolTip = "Rating is already notified.";
                //}
                //else
                //{
                //    btn_AllowMgremmts.Enabled = true;
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


    protected void bindGoals(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            //string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage,,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_assessment_subdetails sd on sd.asd_id=aps.asd_id where apt.status=1  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage ,sd.empcomments,sd.emprating,sd.mgrcomments,sd.mgrrating from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1 and apt.R_cycle=5  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode+ "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            gvGoals.Columns[8].Visible = false;
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
            string str1 = @"update tbl_appraisal_assessment set trainingdetails='" + txttraining.Text + "' ,mgr_overall_cmt ='" + txtMgrOverallComments.Text + "',mgr_overall_rating='" + lblMgrOverallRating.Text + "' where status=1 and appcycle_id= " + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + EmployeeCode + "'";
            int flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, str1);
            if (flag > 0)
                Response.Redirect("ViewApprovedRating.aspx?update=true");
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
        Response.Redirect("ViewApprovedRating.aspx");
    }


    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGoals.EditIndex = e.NewEditIndex;
        bindGoals(Request.QueryString["empcode"].ToString());
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;
        bindGoals(Request.QueryString["empcode"].ToString());
        gvGoals_RowDataBound();
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            TextBox rating = (TextBox)gvGoals.Rows[e.RowIndex].FindControl("txtmanagerating");
            TextBox comments = (TextBox)gvGoals.Rows[e.RowIndex].FindControl("txtmanagercments");
            string str = @"update tbl_appraisal_rating_details set mgrrating=" + Convert.ToInt32(rating.Text) + ",mgrcomments='" + comments.Text + "' where asd_id=" + Convert.ToInt32(gvGoals.DataKeys[e.RowIndex].Values[0]) + "";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.EditIndex = -1;
            bindGoals(Request.QueryString["empcode"].ToString());
            gvGoals_RowDataBound();

            lblMgrOverallRating.Text = Convert.ToString(Math.Round( Convert.ToDouble(lblAvgRatingGoals.Text == "" ? "0" : lblAvgRatingGoals.Text), 0));
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

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewApprovedRating.aspx");
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

                if (mgrratingweightagetotal != 0)
                {
                    Label lblmgrAvgRating = (Label)gvGoals.FooterRow.FindControl("lblmgrAvgRating");
                    lblmgrAvgRating.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
                    lblAvgRatingGoals.Text = Convert.ToString(Math.Round((decimal)(mgrratingweightagetotal / mgrgrdTotal), 0));
                }
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

    }

    protected void bindtraining(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select trainingdetails,emp_overall_rating,emp_overall_cmt,mgr_overall_rating,mgr_overall_cmt,behavior_color from tbl_appraisal_assessment where   appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + empcode + "' ";
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

    protected void btn_AllowMgremmts_Click(object sender, EventArgs e)
    {
        //SqlConnection Connection = null;
        //try
        //{
        //    Connection = DataActivity.OpenConnection();
        //    if (Request.QueryString["empcode"] != null)
        //    {
        //        string empcode = Request.QueryString["empcode"].ToString();
        //        string str = @"update tbl_appraisal_assessment set allow_supervisor_rating=1 where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + empcode + "' ";
        //        int i = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, str);
        //        if (i > 0)
        //        {
        //            btn_AllowMgremmts.Enabled = false;
        //            btn_AllowMgremmts.Text = "Rating Notified";
        //            Output.Show("Supervisor Rating is Allowed");
        //        }
        //    }
        //}
        //catch (Exception ex)
        //{
        //    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
        //    Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        //}
        //finally
        //{
        //    DataActivity.CloseConnection();
        //}
    }

}