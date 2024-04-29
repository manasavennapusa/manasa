using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using DataAccessLayer;

public partial class appraisal_FreezeGoalsByHR : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal grdTotal2 = 0;
    string EmployeeCode = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        getActiveCycle();
        if (!IsPostBack)
        {

            if (Request.QueryString["empcode"] == null || Request.QueryString["NA_empcode"] == null)
            {

                bindgrid();
                empsearch.Visible = true;
            }
            if (Request.QueryString["empcode"] != null)
            {
                EmployeeCode = Request.QueryString["empcode"].ToString();
                empdetails.Visible = true;
                bindGoals(EmployeeCode);
                bindEmpDetails(EmployeeCode);
                // trbtns.Visible = true;
                empsearch.Visible = false;
                empApprovedlist.Visible = false;
                //empNotApprovedlist.Visible = false;
            }
            if (Request.QueryString["NA_empcode"] != null)
            {
                EmployeeCode = Request.QueryString["NA_empcode"].ToString();
                empdetails.Visible = true;
                bindGoals2(EmployeeCode);
                bindEmpDetails(EmployeeCode);
                // trbtns.Visible = true;
                empsearch.Visible = false;
                empApprovedlist.Visible = false;
                //empNotApprovedlist.Visible = false;
            }
            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Goals Freezed Successfully");
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

    //protected void dd_grade_DataBound(object sender, EventArgs e)
    //{
    //    dd_grade.Items.Insert(0, new ListItem("----- All -----", "0"));
    //}

    protected void btn_search_Click(object sender, EventArgs e)
    {

        SqlParameter[] sqlparam = new SqlParameter[4];

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_grade.SelectedValue);
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@dept", "Int", 0, dd_dpt.SelectedValue);


            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_empgoalsbyHr", sqlparam);
            if (ds.Tables.Count > 0)
            {
                gveligible.DataSource = ds;
                gveligible.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["Getemp"] = ds;
                    btnFreezeSelected.Visible = true;
                }
                else
                {
                    btnFreezeSelected.Visible = false;
                }
            }

            //DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_notapprved_empgoalsbyHr", sqlparam);
            //if (ds2.Tables.Count > 0)
            //{
            //    grd_notApprovedEmp.DataSource = ds2;
            //    grd_notApprovedEmp.DataBind();
            //    ViewState["Getemp2"] = ds2;
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
            Output.AssignParameter(sqlparam, 3, "@dept", "Int", 0, "0");


            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_empgoalsbyHr", sqlparam);

            empApprovedlist.Visible = true;
            // empNotApprovedlist.Visible = true;
            if (ds.Tables.Count > 0)
            {
                gveligible.DataSource = ds;
                gveligible.DataBind();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    ViewState["Getemp"] = ds;
                    btnFreezeSelected.Visible = true;
                }
                else
                {
                    btnFreezeSelected.Visible = false;
                }
            }

            //DataSet ds2 = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_notapprved_empgoalsbyHr", sqlparam);
            //if (ds2.Tables.Count > 0)
            //{
            //    grd_notApprovedEmp.DataSource = ds2;
            //    grd_notApprovedEmp.DataBind();
            //    ViewState["Getemp2"] = ds2;
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

    //==================================================== Goals Start============================================================================================

    protected void bindGoals(string empcode)
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

//            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage,aps.emp_comments,aps.mng_comments,approvertype as createdtype from tbl_appraisal_assessment_details aps
//                                    inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id   inner join tbl_appraisal_flow f on f.flow_id=aps.flow_id   where apt.status=1 and apt.G1_cycle=6 and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";

            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.weightage,aps.emp_comments,
aps.mng_comments,approvertype as createdtype,apt.appcycle_id,aps.role,apt.line_manager_comment  
from tbl_appraisal_assessment_details aps
inner join tbl_appraisal_assessment apt on aps.empcode=apt.empcode   
inner join tbl_appraisal_flow f on f.flow_id=aps.flow_id   
where apt.status=1 and apt.appcycle_id='" + Convert.ToInt32(Session["appcycle"]) + "' and  apt.empcode='" + empcode + "'";

            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            if (ds.Tables.Count > 0)
            {
                gvGoals.DataSource = ds;
                gvGoals.DataBind();
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

    protected void bindGoals2(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage,approvertype as createdtype from tbl_appraisal_assessment_details aps
                                    inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id   inner join tbl_appraisal_flow f on f.flow_id=aps.flow_id   where apt.status=1 and  apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            if (ds.Tables.Count > 0)
            {
                gvGoals.DataSource = ds;
                gvGoals.DataBind();
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

    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGoals.EditIndex = e.NewEditIndex;
        if (Request.QueryString["empcode"] != null)
            bindGoals(gvGoals.DataKeys[e.NewEditIndex].Values[1].ToString());
        if (Request.QueryString["NA_empcode"] != null)
            bindGoals2(gvGoals.DataKeys[e.NewEditIndex].Values[1].ToString());
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;

        if (Request.QueryString["empcode"] != null)
            bindGoals(gvGoals.DataKeys[e.RowIndex].Values[1].ToString());
        if (Request.QueryString["NA_empcode"] != null)
            bindGoals2(gvGoals.DataKeys[e.RowIndex].Values[1].ToString());
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[7];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            decimal TW = 0;
            string weightage2 = "";
            for (int i = 0; i < gvGoals.Rows.Count; i++)
            {
                if (i == e.RowIndex)
                {
                    TextBox txtweightage = (TextBox)gvGoals.Rows[i].Cells[0].FindControl("txtweightage");
                    weightage2 = txtweightage.Text;
                }
                else
                {
                    Label lblweightage = (Label)gvGoals.Rows[i].Cells[0].FindControl("lblweightage");
                    weightage2 = lblweightage.Text;
                }
                TW = TW + Convert.ToDecimal(weightage2);
            }
            if (TW <= 100)
            {
                int id = (int)gvGoals.DataKeys[e.RowIndex].Value;

                string title = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txttitle")).Text;
                string desc = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txtdesc")).Text;
                string weightage = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txtweightage")).Text;

                if (title != "")
                {

                    int code = (int)gvGoals.DataKeys[e.RowIndex].Value;
                    SqlParameter[] parm = new SqlParameter[5];

                    parm[0] = new SqlParameter("@asd_id", SqlDbType.Int);
                    parm[0].Value = Convert.ToInt32(gvGoals.DataKeys[e.RowIndex].Values[0]);

                    parm[1] = new SqlParameter("@title", SqlDbType.VarChar, 100);
                    parm[1].Value = title;

                    parm[2] = new SqlParameter("@description", SqlDbType.VarChar, 8000);
                    parm[2].Value = desc;

                    parm[3] = new SqlParameter("@weightage", SqlDbType.Decimal);
                    parm[3].Value = Convert.ToDecimal(weightage);

                    parm[4] = new SqlParameter("@updatedby", SqlDbType.VarChar, 50);
                    parm[4].Value = Session["empcode"].ToString();

                    Output.AssignParameter(parm, 5, "@emp_comm", "String", 8000, "");
                    Output.AssignParameter(parm, 6, "@mng_comm", "String", 8000, "");

                    int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_updategoals_byuser", parm);
                    if (i > 0)
                    {
                        gvGoals.EditIndex = -1;
                        if (Request.QueryString["empcode"] != null)
                            bindGoals(gvGoals.DataKeys[e.RowIndex].Values[1].ToString());
                        if (Request.QueryString["NA_empcode"] != null)
                            bindGoals2(gvGoals.DataKeys[e.RowIndex].Values[1].ToString());
                        Output.Show("goal has been updated successfully!");
                    }
                }
            }
            else
            {
                Output.Show("Total Weightage Should not be greater than 100.");
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

    protected void gvGoals_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    decimal rowTotal = Convert.ToDecimal
        //                (DataBinder.Eval(e.Row.DataItem, "weightage"));
        //    grdTotal = grdTotal + rowTotal;
        //}
        //if (e.Row.RowType == DataControlRowType.Footer)
        //{
        //    Label lbl = (Label)e.Row.FindControl("lblTotalWeightage");
        //    lbl.Text = grdTotal.ToString();
        //}

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string rowTotal = DataBinder.Eval(e.Row.DataItem, "weightage").ToString();
            
        }
    }

    /*====================================================End Goals============================================================================================*/

    /*===============================================Employee Details===========================================================================================*/

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
                lblReview.Text = dse.Tables[0].Rows[0]["app_cycle"].ToString();
                //lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
                //if ((dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6"))
                //{
                lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["additional_cmnt"].ToString();
                lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["LM_appraiser_cmnt"].ToString();
                lblgoalBHcomm.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
                lblbhcmntcycle2.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt_cycle2"].ToString();
                lblgolfrzdatecycle2.Text = dse.Tables[0].Rows[0]["freezecycle2date"].ToString();
                //}
                //if ((dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6"))
                //{
                    //lbempcmts.Text = dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                   // txtmgrComments.Text = dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                //}
                lblcyl1intdate.Text = dse.Tables[0].Rows[0]["G1_initiateddate"].ToString();
                lblgol2intdate.Text = dse.Tables[0].Rows[0]["G2_initiateddate"].ToString();
                lblgolfrzdate.Text = dse.Tables[0].Rows[0]["F_initiateddate"].ToString();
                lblratintdate.Text = dse.Tables[0].Rows[0]["R_initiateddate"].ToString();
                cycleclosedate.Text = dse.Tables[0].Rows[0]["Cycle_closeddate"].ToString();

                //if (dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString() != "")
                //{
                //    lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["emp_overall_cmt"].ToString();
                //}
                //if (dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString() != "")
                //{
                //    lblgoal1mngcomm.Text=  dse.Tables[0].Rows[0]["mgr_overall_cmt"].ToString();
                //}
                //if (dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString() != "")
                //{
                //    lblgoalBHcomm.Text = dse.Tables[0].Rows[0]["BH_appraiser_cmnt"].ToString();
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

    //===============================================End Employee Details===========================================================================================

    protected void sendMail(string empcode)
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string sqlstr = @"select e.empcode,e.official_email_id,e.emp_fname+' ' +e.emp_m_name+' ' +e.emp_l_name as empname,j.emp_fname+' ' +j.emp_m_name+' ' +j.emp_l_name as mgrname,j.empcode as mgrcode,j.official_email_id as mgrid from tbl_intranet_employee_jobDetails e,
                            tbl_intranet_employee_jobDetails j  where e.corporatereportingcode=j.empcode and e.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["mgrid"].ToString() != "")
                {
                    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                    string subject = ConfigurationManager.AppSettings["subject_Emp2Mgr"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_Emp2Mgr"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["mgrname"].ToString(), bodyContent);
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["mgrid"].ToString(), "", subject, completeBody, smtp, emailLogo);
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

    //===============================================Freeze Goals===========================================================================================

    protected void btnFreeze_Click(object sender, EventArgs e)
    {
        int i = 0;
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            if (gvGoals.Rows.Count > 0)
            {
                //Label goalstotalweightage = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");


                //if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) == 100)
                //{
                    string empcode = "";
                    if (Request.QueryString["empcode"] != null)
                    {
                        empcode = Request.QueryString["empcode"].ToString();
                        string sqlstr = @"update tbl_appraisal_assessment set freeze=1,F_initiateddate=getdate() where status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + empcode + "'";
                        //DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
                        //bindgrid();
                        i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                    }
                    if (Request.QueryString["NA_empcode"] != null)
                    {
                        empcode = Request.QueryString["NA_empcode"].ToString();
                        string sqlstr = @"update tbl_appraisal_assessment set freeze=1,G1_cycle=4,F_initiateddate=getdate() where status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + empcode + "'";
                        //DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
                        //bindgrid();
                         i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                    }
                   
                //}
                //else
                //{
                //    Output.Show("The Total Weightage of Goals and Compentencies Should be 100.");
                //}
            }
            else
            {
                Output.Show("The Total Weightage of Goals and Compentencies Should be 100.");
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
            if (i > 0)
            {
                Response.Redirect("FreezeGoalsByHR.aspx?updated=true");
            }
        }
    }

    protected void chkall_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gveligible.HeaderRow.FindControl("chkall");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chk");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chk");
                chkselect.Checked = false;
            }
        }
    }

    protected void btnFreezeSelected_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            int cnt = 0;
            foreach (GridViewRow row in gveligible.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chk");
                if (chkselect.Checked)
                {
                    Label emp = (Label)row.FindControl("lblempcode");
                    string sqlstr = @"update tbl_appraisal_assessment set freeze=1,F_initiateddate=getdate() where status=1 and appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + emp.Text.Trim() + "'";
                    cnt += SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                }
            }
            bindgrid();
            if (cnt > 0)
                Output.Show("goals has been Freezed successfully!");
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

    protected void AddGoals_Click(object sender, EventArgs e)
    {
        //if (gvGoals.Rows.Count < 10)
        //{
        //    if (gvGoals.Rows.Count == 0)
        //    {
        //        traddGoals.Visible = true;
        //        AddGoals.Visible = false;
        //        return;
        //    }
        //    decimal weightage = 0;
        //    Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
        //    weightage = Convert.ToDecimal(total.Text);

        //    if (weightage < 100)
        //    {
        //        traddGoals.Visible = true;
        //        AddGoals.Visible = false;
        //    }
        //    else
        //    {
        //        Output.Show("Total Weightage Should not be greater than 100.");
        //    }
        //}
        //else
        //{
        //    Output.Show("You can add  maximum 10 Goals");
        //}
    }

    protected void btnSaveGoals_Click(object sender, EventArgs e)
    {
        try
        {
            if ((Request.QueryString["NA_empcode"] != null) || (Request.QueryString["empcode"] != null))
            {
                string empcode = "";
                if (Request.QueryString["NA_empcode"] != null)
                {
                    empcode = Request.QueryString["NA_empcode"].ToString();
                }

                if (Request.QueryString["empcode"] != null)
                {
                    empcode = Request.QueryString["empcode"].ToString();
                }

                decimal weightage = 0;
                //if (gvGoals.Rows.Count == 9)
                //{

                //    Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                //    weightage = Convert.ToInt32(total.Text);

                //    weightage = weightage + Convert.ToInt32(txtWeightage.Text);
                //    if (weightage < 100)
                //    {
                //        message.InnerHtml = "Total Weightage Should  be  100.";
                //    }
                //    else
                //    {
                //        addgoals(Request.QueryString["empcode"].ToString());
                //    }
                //}
                //else
                //{
                if (gvGoals.Rows.Count == 0)
                {
                    addgoals(empcode);
                    return;
                }
                Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                weightage = Convert.ToDecimal(total.Text);

                weightage = weightage + Convert.ToDecimal(txtWeightage.Text);
                if (weightage <= 100)
                {
                    addgoals(empcode);
                }
                else
                {
                    Output.Show("Goals Total Weightage Should not be greater than 100.");
                }

                //}


            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

    }

    protected void addgoals(string empcode)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str2 = @" select as_id,empcode from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + empcode + "' ";
            DataSet ds_asID = SQLServer.ExecuteDataset(Connection, CommandType.Text, str2);
            if (ds_asID.Tables[0].Rows.Count >= 1)
            {
                if (ds_asID.Tables[0].Rows[0]["as_id"].ToString() != "")
                {
                    SqlParameter[] sqlparam1 = new SqlParameter[9];

                    sqlparam1[0] = new SqlParameter("@assmentid", SqlDbType.Int);
                    sqlparam1[0].Value = Convert.ToInt32(ds_asID.Tables[0].Rows[0]["as_id"]);

                    sqlparam1[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                    sqlparam1[1].Value = empcode;

                    sqlparam1[2] = new SqlParameter("@type", SqlDbType.Char, 1);
                    sqlparam1[2].Value = "G";

                    sqlparam1[3] = new SqlParameter("@c_id", SqlDbType.Int);
                    sqlparam1[3].Value = System.Data.SqlTypes.SqlInt32.Null;

                    sqlparam1[4] = new SqlParameter("@title", SqlDbType.VarChar, 100);
                    sqlparam1[4].Value = txtTitle.Text;

                    sqlparam1[5] = new SqlParameter("@description", SqlDbType.VarChar, 100);
                    sqlparam1[5].Value = txtDesc.Text;

                    sqlparam1[6] = new SqlParameter("@weightage", SqlDbType.Decimal);
                    sqlparam1[6].Value = Convert.ToDecimal(txtWeightage.Text);

                    sqlparam1[7] = new SqlParameter("@createdtype", SqlDbType.Char, 1);
                    sqlparam1[7].Value = "0";

                    sqlparam1[8] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                    sqlparam1[8].Value = Session["empcode"].ToString();

                    SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_assement_details", sqlparam1);

                    txtTitle.Text = "";
                    txtDesc.Text = "";
                    txtWeightage.Text = "";
                    traddGoals.Visible = false;
                    AddGoals.Visible = true;
                    bindGoals2(empcode);
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        traddGoals.Visible = false;
        AddGoals.Visible = true;
        txtTitle.Text = "";
        txtDesc.Text = "";
        txtWeightage.Text = "";
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("FreezeGoalsByHR.aspx");
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

    protected void grd_notApprovedEmp_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        if (ViewState["Getemp2"] != null)
        {
            grd_notApprovedEmp.PageIndex = e.NewPageIndex;
            DataSet ds = (DataSet)ViewState["Getemp2"];
            grd_notApprovedEmp.DataSource = ds;
            grd_notApprovedEmp.DataBind();
        }
    }

    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found.";
    }

}