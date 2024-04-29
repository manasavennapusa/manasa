using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;

public partial class appraisal_EditAppraisal : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal grdTotal2 = 0;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity DataActivity = new DataActivity();
    string sqlstr;
    DataSet ds;
    string EmployeeCode = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        getActiveCycle();

        if (!IsPostBack)
        {
            bindempgrid2();
        }
    }

    private void getActiveCycle()
    {
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
    /*------------------------------ for Goals----------------------*/

    protected void bindGoals(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select aps.assessment_id,aps.asd_id,aps.flow_id,aps.title,aps.description,aps.weightage,aps.create_by from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id where apt.status=1 and  apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"].ToString()) + " and  apt.empcode='" + empcode + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gvGoals.DataSource = ds;
            gvGoals.DataBind();
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
        if (!IsEmployeeGoalInitiated(lblempcode.Text.Trim(), Session["appcycle"].ToString().Trim()))
        {

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
        else
        {
            Output.Show("Goal cycle already initiated. You are not allowed to add any further goals");
        }
    }

    protected void btnSaveGoals_Click(object sender, EventArgs e)
    {
        if (ViewState["Empcode"] != null)
        {
            decimal weightage = 0;

            if (gvGoals.Rows.Count == 0)
            {
                addgoals(ViewState["Empcode"].ToString());
                return;
            }
            Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
            weightage = Convert.ToDecimal(total.Text);

            weightage = weightage + Convert.ToDecimal(txtWeightage.Text);
            if (weightage <= 100)
            {
                addgoals(ViewState["Empcode"].ToString());
            }
            else
            {
                Output.Show("Goals Total Weightage Should not be greater than 100.");
            }
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

    protected void addgoals(string empcode)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {

            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            string str2 = @" select assessment_id,empcode from tbl_appraisal_assessment where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"].ToString()) + " and empcode='" + empcode + "' ";
            DataSet ds_asID = SQLServer.ExecuteDataset(Connection, CommandType.Text, _Transaction, str2);

            if (ds_asID.Tables[0].Rows.Count >= 1)
            {
                if (ds_asID.Tables[0].Rows[0]["assessment_id"].ToString() != "")
                {
                    string assessment_id = ds_asID.Tables[0].Rows[0]["assessment_id"].ToString();
                    SqlParameter[] sqlparam1 = new SqlParameter[8];
                    Output.AssignParameter(sqlparam1, 0, "@assessment_id", "Int", 0, assessment_id);
                    Output.AssignParameter(sqlparam1, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(sqlparam1, 2, "@level", "Int", 0, "1");
                    Output.AssignParameter(sqlparam1, 3, "@flow_status", "String", 1, "P");
                    Output.AssignParameter(sqlparam1, 4, "@approvertype", "String", 5, "HR");
                    Output.AssignParameter(sqlparam1, 5, "@cycle_type", "String", 5, "1");
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
                    Output.AssignParameter(sqlparam2, 6, "@emp_comm", "String", 8000, "");
                    Output.AssignParameter(sqlparam2, 7, "@mng_comm", "String", 8000, "");
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
        bindGoals(ViewState["Empcode"].ToString());
    }

    protected void gvGoals_RowDataBound(object sender, GridViewRowEventArgs e)
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

    protected void gvGoals_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView gvGoals = (GridView)gveligible.Rows[0].FindControl("gvGoals");
        gvGoals.PageIndex = e.NewPageIndex;
        bindGoals(ViewState["Empcode"].ToString());
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;
        bindGoals(ViewState["Empcode"].ToString());
    }

    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (!IsEmployeeGoalInitiated(lblempcode.Text.Trim(), Session["appcycle"].ToString().Trim()))
        {
            gvGoals.EditIndex = e.NewEditIndex;
            bindGoals(ViewState["Empcode"].ToString());
        }
        else
        {
            Output.Show("Goal cycle already initiated. You are not allowed to edit any goals");
        }
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        if (!IsEmployeeGoalInitiated(lblempcode.Text.Trim(), Session["appcycle"].ToString().Trim()))
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

                    if (title != "")
                    {
                        int code = (int)gvGoals.DataKeys[e.RowIndex].Value;

                        Output.AssignParameter(parm, 0, "@asd_id", "Int", 0, gvGoals.DataKeys[e.RowIndex].Values[0].ToString());
                        Output.AssignParameter(parm, 1, "@title", "String", 100, title);
                        Output.AssignParameter(parm, 2, "@description", "String", 8000, desc);
                        Output.AssignParameter(parm, 3, "@weightage", "Decimal", 0, weightage);
                        Output.AssignParameter(parm, 4, "@updatedby", "String", 50, Session["empcode"].ToString());
                        Output.AssignParameter(parm, 5, "@emp_comm", "String", 8000, "");
                        Output.AssignParameter(parm, 6, "@mng_comm", "String", 8000, "");
                        int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_updategoals_byuser", parm);

                        if (i > 0)
                        {
                            gvGoals.EditIndex = -1;
                            bindGoals(ViewState["Empcode"].ToString());
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
        else
        {
            Output.Show("Goal cycle already initiated. You are not allowed to update goals");
        }
    }

    protected void view_Command(object sender, CommandEventArgs e)
    {
        EmployeeCode = e.CommandArgument.ToString();
        ViewState["Empcode"] = EmployeeCode;
        empgoals.Visible = true;
        bindGoals(EmployeeCode);
        bindEmpDetails(EmployeeCode);
    }

    /*------------------------------ End Goals----------------------*/


    /*------------------------------Employee Details------------------------*/
    protected void getemployees()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str = @"select empcode,createdby from tbl_appraisal_assessment where  status=1 and apc_id=" + Session["appcycle"].ToString();
            DataSet ds4 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            if (ds4.Tables[0].Rows.Count > 0)
            {
                int count = ds4.Tables[0].Rows.Count;
                while (count != 0)
                {
                    sendMailtoEmp(ds4.Tables[0].Rows[count - 1]["empcode"].ToString());
                    count--;
                }
                sendMailtoEmp(ds4.Tables[0].Rows[0]["createdby"].ToString());
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

    protected void sendMailtoMGMT(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select e.empcode,j.official_email_id,isnull(e.emp_fname,'')+' ' +isnull(e.emp_m_name,'')+' ' +isnull(e.emp_l_name,'') as empname,
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

    protected void sendMailtoEmp(string empcode)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails
                              where empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            if (ds1.Tables[0].Rows.Count > 0)
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
        empgoals.Visible = false;
        bindempgrid();
    }

    protected void bindempgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {

            Output.AssignParameter(sqlparam, 0, "@HRempcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@empcode", "String", 50, txt_employee.Text);
            Output.AssignParameter(sqlparam, 2, "@dept", "Int", 0, dd_dpt.SelectedValue);
            Output.AssignParameter(sqlparam, 3, "@grade", "Int", 0, dd_grade.SelectedValue);
            Output.AssignParameter(sqlparam, 4, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Connection = DataActivity.OpenConnection();
            DataSet ds = new DataSet();

            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_emp_for_editgoals", sqlparam);

            if (ds.Tables.Count > 0)
            {
                gveligible.DataSource = ds;
                gveligible.DataBind();
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


    protected void bindempgrid2()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {

            Output.AssignParameter(sqlparam, 0, "@HRempcode", "String", 50, Session["empcode"].ToString());
            Output.AssignParameter(sqlparam, 1, "@empcode", "String", 50, "");
            Output.AssignParameter(sqlparam, 2, "@dept", "Int", 0, "0");
            Output.AssignParameter(sqlparam, 3, "@grade", "Int", 0, "0");
            Output.AssignParameter(sqlparam, 4, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Connection = DataActivity.OpenConnection();
            DataSet ds = new DataSet();

            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_get_emp_for_editgoals", sqlparam);

            gveligible.DataSource = ds;
            gveligible.DataBind();

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
            Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, empcode);
            Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            Connection = DataActivity.OpenConnection();
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
                lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
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

    protected void gveligible_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[3];
        SqlConnection Connection = null;
        try
        {
            string id = (string)gveligible.DataKeys[e.RowIndex].Value;
            string appcycleid = Session["appcycle"].ToString().ToString();

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, id.Trim().ToString());
            Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 0, appcycleid);
            Output.AssignParameter(sqlparam, 2, "@createdby", "String", 50, Session["empcode"].ToString());

            Connection = DataActivity.OpenConnection();
            string str = @"select COUNT(*) from tbl_appraisal_eligibilitylist where isdeleted=0 empcode=" + id + " and appcycleid=" + Convert.ToInt32(Session["appcycle"].ToString()) + " and initiate=1";
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str);

            if (cnt == 0)
            {
                int ins = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_deleteeligibleemployee", sqlparam);
                if (ins > 0)
                {
                    Output.Show("Record deleted successfully.");
                    bindempgrid();
                }
            }
            else
            {
                //Output.Show("You are not allowed to delete record.Appraisal is initiated for this employee.");
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
        gveligible.PageIndex = e.NewPageIndex;
        bindempgrid();
    }

    protected void dd_grade_DataBound(object sender, EventArgs e)
    {
        dd_grade.Items.Insert(0, new ListItem("All", "0"));
    }

    private bool IsEmployeeGoalInitiated(string empcode, string appcycleid)
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        SqlConnection Connection = null;
        bool Flag = true;
        string Query = "select count(*) from tbl_appraisal_assessment where G1_cycle <> 0 and empcode = @empcode and appcycle_id=@appcycleid";
        try
        {

            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, empcode);
            Output.AssignParameter(sqlparam, 1, "@appcycleid", "Int", 50, appcycleid);

            Connection = DataActivity.OpenConnection();
            DataSet ds = new DataSet();

            int Count = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, Query, sqlparam);

            if (Count > 0)
                Flag = true;
            else
                Flag = false;
        }
        catch
        {

        }
        finally
        {
            DataActivity.CloseConnection();
        }

        return Flag;
    }






    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
