using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;



public partial class appraisal_ReviewGoalsByBUH : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal grdTotal2 = 0;
    string EmployeeCode = "";
    string sqlstr = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode;


    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        getActiveCycle();
        if (!IsPostBack)
        {
            if (gveligible.Rows.Count <= 0) gveligible.EmptyDataText = "No Records Found";

            bindgrid();
            empsearch.Visible = true;
            Session["comp_status"] = "";
            if (Request.QueryString["empcode"] != null)
            {
                EmployeeCode = Request.QueryString["empcode"].ToString();
                empdetails.Visible = true;
                empsearch.Visible = false;
                emplist.Visible = false;
                btns.Visible = true;
                bindGoals(EmployeeCode);
                bindEmpDetails(EmployeeCode);
                //indRevertDetails(EmployeeCode);
            }
            if (Request.QueryString["updated"] != null)
            {
                Output.Show("Employee goals  has been Submitted successfully!");
            }
            if (Request.QueryString["revert"] != null)
            {
                Output.Show("Employee Appraisal Form is Reverted successfully!");
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

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@name", "String", 150, txt_employee.Text.Trim());
            //Output.AssignParameter(sqlparam, 2, "@grade", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 2, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, ddl_dept.SelectedValue);

            DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_get_empgoalsbymgr", sqlparam);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            gveligible.DataSource = ds;
            gveligible.DataBind();
            gveligible.Visible = true;
            emplist.Visible = true;
            ViewState["Getemp"] = ds;
            //}
            //else
            //{
            //    gveligible.Visible = false;
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
            Output.AssignParameter(sqlparam, 3, "@department", "Int", 0, "0");

            DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_get_empgoalsbybhu", sqlparam);
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

    /*==================================================== Goals Start============================================================================================*/

    protected void bindGoals(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage, G1_cycle,G2_cycle,aps.emp_comments,aps.mng_comments,
            case when cycle_type='1' and G1_cycle='2'  then 'E'
            when cycle_type='2' and G2_cycle='2'  then 'E' else 'NE' end as IsEditable
            from tbl_appraisal_assessment_details aps
            inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id   inner join tbl_appraisal_flow f on f.flow_id=aps.flow_id   where apt.status=1 and (apt.G1_cycle=3 or apt.G2_cycle=3) and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gvGoals.DataSource = ds1;
            gvGoals.DataBind();
            //if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "2" || ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "2")
            //{
            //    btnSubmitToEmp.Visible = false;
            //    gvGoals.Columns[6].Visible = true;
            //}
            //else
            //{
            //    btnSubmitToEmp.Visible = true;
            //    gvGoals.Columns[6].Visible = false;
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

    protected void AddGoals_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (gvGoals.Rows.Count < 10)
            {
                if (gvGoals.Rows.Count == 0)
                {
                    traddGoals.Visible = true;
                    AddGoals.Visible = false;

                    return;
                }
                decimal weightage = 0;
                Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                weightage = Convert.ToDecimal(total.Text);


                if (weightage < 100)
                {
                    traddGoals.Visible = true;
                    AddGoals.Visible = false;

                }
                else
                {
                    Output.Show("Total Weightage Should not be greater than 100.");
                }
            }
            else
            {
                Output.Show("You can add  maximum 10 Goals");

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

    protected void btnSaveGoals_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (Request.QueryString["empcode"] != null)
            {
                decimal weightage = 0;
                if (gvGoals.Rows.Count == 9)
                {

                    Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                    weightage = Convert.ToInt32(total.Text);

                    weightage = weightage + Convert.ToInt32(txtWeightage.Text);
                    if (weightage < 100)
                    {
                        Output.Show("Total Weightage Should  be  100.");
                    }
                    else
                    {
                        addgoals(Request.QueryString["empcode"].ToString());
                    }
                }
                else
                {
                    if (gvGoals.Rows.Count == 0)
                    {
                        addgoals(Request.QueryString["empcode"].ToString());
                        return;
                    }
                    Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                    weightage = Convert.ToDecimal(total.Text);

                    weightage = weightage + Convert.ToDecimal(txtWeightage.Text);
                    if (weightage <= 100)
                    {
                        addgoals(Request.QueryString["empcode"].ToString());
                    }
                    else
                    {
                        Output.Show("Goals Total Weightage Should not be greater than 100.");
                    }

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

    protected void addgoals(string empcode)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {

            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            string str2 = @" select assessment_id,empcode,G1_cycle from tbl_appraisal_assessment where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + empcode + "' ";
            DataSet ds_asID = SQLServer.ExecuteDataset(Connection, CommandType.Text, _Transaction, str2);

            if (ds_asID.Tables[0].Rows.Count >= 1)
            {
                if (ds_asID.Tables[0].Rows[0]["assessment_id"].ToString() != "")
                {
                    string cycletype = ds_asID.Tables[0].Rows[0]["G1_cycle"].ToString() == "2" ? "1" : "2";
                    string assessment_id = ds_asID.Tables[0].Rows[0]["assessment_id"].ToString();
                    SqlParameter[] sqlparam1 = new SqlParameter[8];
                    Output.AssignParameter(sqlparam1, 0, "@assessment_id", "Int", 0, assessment_id);
                    Output.AssignParameter(sqlparam1, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(sqlparam1, 2, "@level", "Int", 0, "2");
                    Output.AssignParameter(sqlparam1, 3, "@flow_status", "String", 1, "P");
                    Output.AssignParameter(sqlparam1, 4, "@approvertype", "String", 5, "BUH");
                    Output.AssignParameter(sqlparam1, 5, "@cycle_type", "String", 5, cycletype);
                    Output.AssignParameter(sqlparam1, 6, "@create_by", "String", 50, Session["empcode"].ToString());
                    sqlparam1[7] = new SqlParameter("@flow_id", SqlDbType.Int);
                    sqlparam1[7].Direction = ParameterDirection.Output;

                    SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_appraisal_insert_workflow", sqlparam1);
                    string flow_id = sqlparam1[7].Value.ToString();

                    SqlParameter[] sqlparam2 = new SqlParameter[8];
                    Output.AssignParameter(sqlparam2, 0, "@assessment_id", "Int", 0, assessment_id);
                    Output.AssignParameter(sqlparam2, 1, "@flow_id", "Int", 0, flow_id);
                    Output.AssignParameter(sqlparam2, 2, "@title", "String", 200, txtTitle.Text);
                    Output.AssignParameter(sqlparam2, 3, "@description", "String", 8000, txtDesc.Text);
                    Output.AssignParameter(sqlparam2, 4, "@weightage", "Decimal", 0, txtWeightage.Text);
                    Output.AssignParameter(sqlparam2, 5, "@create_by", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(sqlparam2, 6, "@mng_comm", "String", 8000, "");
                    Output.AssignParameter(sqlparam2, 7, "@emp_comm", "String", 8000, "");
                    SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "sp_appraisal_insert_assement_details", sqlparam2);

                    _Transaction.Commit();
                    txtTitle.Text = "";
                    txtDesc.Text = "";
                    txtWeightage.Text = "";
                    traddGoals.Visible = false;
                    AddGoals.Visible = true;

                }
            }

        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        bindGoals(empcode);
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        traddGoals.Visible = false;
        AddGoals.Visible = true;
        txtTitle.Text = "";
        txtDesc.Text = "";
        txtWeightage.Text = "";
    }

    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGoals.EditIndex = e.NewEditIndex;
        bindGoals(gvGoals.DataKeys[e.NewEditIndex].Values[1].ToString());
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;
        bindGoals(gvGoals.DataKeys[e.RowIndex].Values[1].ToString());
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlParameter[] parm = new SqlParameter[7];
        SqlConnection Connection = null;
        try
        {
            decimal TW = 0;
            string weightage2 = "";
            Connection = DataActivity.OpenConnection();
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
                Label lblTotalWeightage = (Label)gvGoals.Rows[i].Cells[0].FindControl("lblTotalWeightage");
                TW = TW + Convert.ToDecimal(weightage2);

            }
            if (TW <= 100)
            {
                int id = (int)gvGoals.DataKeys[e.RowIndex].Value;

                string title = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txttitle")).Text;
                string desc = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txtdesc")).Text;
                string weightage = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txtweightage")).Text;
                string mngcomm = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txtmngcomm")).Text;
                string empcomm = ((Label)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("lblcomm")).Text;
                if (title != "")
                {
                    int code = (int)gvGoals.DataKeys[e.RowIndex].Value;

                    Output.AssignParameter(parm, 0, "@asd_id", "Int", 0, gvGoals.DataKeys[e.RowIndex].Values[0].ToString());
                    Output.AssignParameter(parm, 1, "@title", "String", 100, title);
                    Output.AssignParameter(parm, 2, "@description", "String", 8000, desc);
                    Output.AssignParameter(parm, 3, "@weightage", "Decimal", 0, weightage);
                    Output.AssignParameter(parm, 4, "@updatedby", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 5, "@emp_comm", "String", 8000, empcomm);
                    Output.AssignParameter(parm, 6, "@mng_comm", "String", 8000, mngcomm.ToString());
                    int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_updategoals_byuser", parm);

                    if (i > 0)
                    {
                        gvGoals.EditIndex = -1;
                        bindGoals(Request.QueryString["empcode"].ToString());
                        Output.Show("goal has been updated successfully!");
                    }
                }
                else
                {
                    string msg = "Please enter Title !";
                    Output.Show("Please enter Title !");
                }
            }
            else
            {
                Output.Show("Total Weightage should not be greater than 100.");
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
        try
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                decimal rowTotal = Convert.ToDecimal
                            (DataBinder.Eval(e.Row.DataItem, "weightage"));
                grdTotal = grdTotal + rowTotal;
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lbl = (Label)e.Row.FindControl("lblTotalWeightage");
                lbl.Text = grdTotal.ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }

    }

    /*====================================================End Goals============================================================================================*/


    /*===============================================Employee Details===========================================================================================*/

    protected void getemployees()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select empcode,createdby from tbl_appraisal_assessment where status=1 and apc_id=" + Session["appcycle"];
            DataSet ds4 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            if (ds4.Tables[0].Rows.Count > 0)
            {
                //int count = ds4.Tables[0].Rows.Count;
                //while (count != 0)
                //{
                //    sendMailtoEmp(ds4.Tables[0].Rows[count - 1]["empcode"].ToString());
                //    count--;
                //}
                //sendMailtoEmp(ds4.Tables[0].Rows[0]["createdby"].ToString());
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
                lblempname.Text = dse.Tables[0].Rows[0]["name"].ToString();
                lblempcode.Text = dse.Tables[0].Rows[0]["empcode"].ToString();
                lbldept.Text = dse.Tables[0].Rows[0]["dept"].ToString();
                lbldesignation.Text = dse.Tables[0].Rows[0]["designation"].ToString();
                lblrole.Text = dse.Tables[0].Rows[0]["role"].ToString();
                lblmanager.Text = dse.Tables[0].Rows[0]["manager"].ToString();
                lblbuh.Text = dse.Tables[0].Rows[0]["bhu"].ToString();
                lblReview.Text = dse.Tables[0].Rows[0]["app_cycle"].ToString();
                lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
                if (dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "3")
                {
                    tbl_gc1.Visible = true;
                    tr_gc1_heading.Visible = true;
                    tr_gc1_employeecomments.Visible = true;
                    tr_gc1_managercomments.Visible = false;

                    tbl_gc2.Visible = false;
                    tr_gc2_heading.Visible = false;
                    tr_gc2_employeecomments.Visible = false;
                    tr_gc2_managercomments.Visible = false;

                    lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                    txtmgrComments.Text = dse.Tables[0].Rows[0]["G1_mgr_comments"].ToString();

                }
                if (dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "3")
                {
                    lblgoal2empcomm.Text = dse.Tables[0].Rows[0]["G2_emp_comments"].ToString();
                    txtmgrComments.Text = dse.Tables[0].Rows[0]["G2_mgr_comments"].ToString();

                    lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                    lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["G1_mgr_comments"].ToString();
                    tr_gc2_managercomments.Visible = false;
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

    /*===============================================End Employee Details===========================================================================================*/

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (gvGoals.Rows.Count != 0)
            {

                Label goalstotalweightage = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
                sqlstr = @"select G1_cycle,G2_cycle from tbl_appraisal_assessment where appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "' and status=1";
                DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
                if (ds.Tables[0].Rows[0]["G2_cycle"].ToString() == "3")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) == 100)
                    {
                        //sqlstr = "update tbl_appraisal_revert set status=0 where revertbylevel=3 and as_id=(select as_id from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "')";             // updating status and glevel in revert table
                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                        //sqlstr = "update tbl_appraisal_revert set glevel=4 where glevel=3 and status=1 and as_id=(select as_id from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "')";               // updating glevel in revert table
                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                        sqlstr = @"update tbl_appraisal_assessment set G2_cycle=4,G2_mgr_comments='" + txtmgrComments.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "' and status=1";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        //sendMailtoMGMT(Request.QueryString["empcode"].ToString());
                        bindgrid();

                        Response.Redirect("ReviewGoalsByBUH.aspx?updated=true");
                    }
                    else
                    {
                        Output.Show("The Total Weightage of Goals  Should be 100.");
                    }
                }
                else
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) <= 100)
                    {
                        sqlstr = @"update tbl_appraisal_assessment set G1_cycle=4,G1_mgr_comments='" + txtmgrComments.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        //sendMailtoMGMT(Request.QueryString["empcode"].ToString());
                        bindgrid();

                        Response.Redirect("ReviewGoalsByBUH.aspx?updated=true");
                    }
                    else
                    {
                        Output.Show("The Total Weightage of Goals  Should not be more than 100.");
                    }
                }
            }
            else
            {
                Output.Show("Add Atleast One Goal");
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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReviewGoalsByBUH.aspx");
    }

    protected void sendMailtoMGMT(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select e.empcode,j.official_email_id,isnull(j.emp_fname,'')+' ' +isnull(j.emp_m_name,'')+' ' +isnull(j.emp_l_name,'') as mgmtname
                             from  tbl_intranet_employee_jobDetails e left join tbl_intranet_employee_jobDetails j  on j.empcode=e.corporatereportingcode where e.empcode='" + empcode + "'";

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
                    string subject = ConfigurationManager.AppSettings["subject_Emp2Mgr"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_Mgr2Mgmt"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["mgmtname"].ToString(), bodyContent);
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

    protected void sendMailtoEmp(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select empcode,official_email_id,isnull(emp_fname,' ')+' ' +isnull(emp_m_name,' ')+' ' +isnull(emp_l_name,' ') as empname from tbl_intranet_employee_jobDetails
                              where empcode='" + empcode + "'";
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
                    string subject = ConfigurationManager.AppSettings["subject_Compentencies"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_Compententies"].ToString();
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

    //===============================================Start Revert================================
    protected void btnRevert_Click(object sender, EventArgs e)
    {
        //SqlConnection Connection = null;
        //    try
        //    {
        //        Connection = DataActivity.OpenConnection();
        //    if (Request.QueryString["empcode"] != null)
        //    {
        //        string str2 = @" select as_id,empcode from tbl_appraisal_assessment where status=1 and  apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "' ";
        //        DataSet ds_asID = SQLServer.ExecuteDataset(Connection, CommandType.Text, str2);
        //        if (ds_asID.Tables[0].Rows.Count >= 1)
        //        {
        //            if (ds_asID.Tables[0].Rows[0]["as_id"].ToString() != "")
        //            {

        //                SqlParameter[] parm = new SqlParameter[5];

        //                parm[0] = new SqlParameter("@as_id", SqlDbType.Int);
        //                parm[0].Value = ds_asID.Tables[0].Rows[0]["as_id"].ToString();

        //                parm[1] = new SqlParameter("@revertbylevel", SqlDbType.Int);
        //                parm[1].Value = 3;

        //                parm[2] = new SqlParameter("@reverttolevel", SqlDbType.Int);
        //                parm[2].Value = ddl_revertto.SelectedValue;

        //                parm[3] = new SqlParameter("@comments", SqlDbType.VarChar, 8000);
        //                parm[3].Value = txtrevertcomment.Text;

        //                parm[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        //                parm[4].Value = Session["empcode"].ToString();

        //                int flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_insert_revert", parm);
        //                if (flag > 0)
        //                {
        //                    sqlstr = @"update tbl_appraisal_assessment set glevel=" + ddl_revertto.SelectedValue + "  where  status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
        //                    DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
        //                    if (ddl_revertto.SelectedValue == "1")
        //                    {
        //                        sendRevertMail(ds_asID.Tables[0].Rows[0]["empcode"].ToString());
        //                    }
        //                    if (ddl_revertto.SelectedValue == "2")
        //                    {
        //                        sqlstr = @"select supervisorcode from tbl_intranet_employee_jobDetails where empcode='" + ds_asID.Tables[0].Rows[0]["empcode"].ToString() + "'";
        //                        DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
        //                        if (ds.Tables[0].Rows.Count > 0)
        //                        {
        //                            sendRevertMail(ds.Tables[0].Rows[0]["supervisorcode"].ToString());
        //                        }
        //                    }

        //                    Response.Redirect("ApproveGoalsbyManager.aspx?revert=true");
        //                }
        //                else
        //                {
        //                    Output.Show("You Cannot revert the Form More than 2 times");
        //                }
        //            }
        //        }
        //}
        //     }
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

    protected void bindRevertDetails(string empcode)
    {
        //  SqlConnection Connection = null;
        //try
        //{
        //    Connection = DataActivity.OpenConnection();
        //lblComments.Text = "";
        //txtrevertcomment.Text = "";
        //ddl_revertto.SelectedValue = "0";

        //string str2 = @" select as_id,empcode from tbl_appraisal_assessment where  status=1 and  apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + empcode + "' ";
        //DataSet ds_asID = SQLServer.ExecuteDataset(Connection, CommandType.Text, str2);
        //if (ds_asID.Tables[0].Rows.Count > 0)
        //{
        //    SqlParameter[] parm = new SqlParameter[2];

        //    parm[0] = new SqlParameter("@as_id", SqlDbType.Int);
        //    parm[0].Value = ds_asID.Tables[0].Rows[0]["as_id"].ToString();

        //    parm[1] = new SqlParameter("@glevel", SqlDbType.Int);
        //    parm[1].Value = 3;

        //    DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_revertdetails", parm);
        //    if (ds.Tables[0].Rows.Count > 0)
        //    {
        //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //        {
        //            if (ds.Tables[0].Rows[i]["revertbylevel"].ToString() != "3")
        //            {
        //                trRevertComments.Visible = true;
        //                lblComments.Text = ds.Tables[0].Rows[i]["comments"].ToString();

        //                if (ds.Tables[0].Rows[i]["revertbylevel"].ToString() == "4")
        //                    lblcmtsText.Text = "Management Comments";
        //            }
        //            else
        //            {
        //                txtrevertcomment.Text = ds.Tables[0].Rows[i]["comments"].ToString();
        //            }
        //        }
        //    }
        //    else
        //    {
        //        trRevertComments.Visible = false;
        //    }
        //}
        //     }
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

    protected void sendRevertMail(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select empcode,official_email_id,isnull(emp_fname,' ')+' ' +isnull(emp_m_name,' ')+' ' +isnull(emp_l_name,' ') as empname from tbl_intranet_employee_jobDetails
                              where empcode='" + empcode + "'";
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
                    string subject = "Regarding Appraisal";
                    string bodyContent = "Appraisal form is reverted. Please check the details and submit the form.";
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

    //===============================================End Revert================================


    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }
}