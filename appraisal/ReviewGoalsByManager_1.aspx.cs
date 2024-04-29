using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using DataAccessLayer;
public partial class appraisal_ReviewGoalsByManager_1 : System.Web.UI.Page
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
        UserCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            empsearch.Visible = true;
            Session["comp_status"] = "";
            if (Request.QueryString["upd"] != null)
            {
                EmployeeCode = Session["Employeecd"].ToString();
                empdetails.Visible = true;
                tr_goals.Visible = true;
                empsearch.Visible = false;
                btns.Visible = true;
                bindGoals();
                bindEmpDetails(EmployeeCode);
                Output.Show("Updated Successfully");
            }
            if (Request.QueryString["empcode"] != null)
            {
                EmployeeCode = Request.QueryString["empcode"].ToString();
                Session["Employeecd"] = EmployeeCode.ToString();
                empdetails.Visible = true;
                tr_goals.Visible = true;
                empsearch.Visible = false;
                btns.Visible = true;
                bindGoals();
                bindEmpDetails(EmployeeCode);
                //indRevertDetails(EmployeeCode);
            }
        }
        getActiveCycle();

        if (Request.QueryString["updated"] != null)
        {
            Output.Show("Employee goals  has been Submitted successfully!");
        }
        if (Request.QueryString["revert"] != null)
        {
            Output.Show("Employee Appraisal Form is Reverted successfully!");
        }
        if (Request.QueryString["submit"] != null)
        {
            Output.Show("Submitted Successfully");
            return;
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

    /*==================================================== Goals Start============================================================================================*/
    protected void bindGoals_1()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str = @"select asd.empcode,asd.asd_id,assessment_id,asd.flow_id,asd.role,asd.kca,asd.kpi,asd.weightage,asd.create_by  
from tbl_appraisal_assessment_details asd
inner join tbl_intranet_employee_jobDetails jd on jd.empcode=asd.empcode";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gvGoals.DataSource = ds1;
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

    protected void bindGoals()
    {
        //string empcode = Request.QueryString["empcode"].ToString();

        string empcode = Session["Employeecd"].ToString();
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str = @"select asd.empcode,asd.asd_id,assessment_id,asd.flow_id,asd.role,asd.kca,asd.kpi,asd.weightage,asd.create_by  
from tbl_appraisal_assessment_details asd
inner join tbl_intranet_employee_jobDetails jd on jd.empcode=asd.empcode where asd.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gvGoals.DataSource = ds1;
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

    protected void bindGoals_11()
    {
        string empcode = lblempcode.Text;
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str = @"select asd.empcode,asd.asd_id,assessment_id,asd.flow_id,asd.role,asd.kca,asd.kpi,asd.weightage,asd.create_by  
from tbl_appraisal_assessment_details asd
inner join tbl_intranet_employee_jobDetails jd on jd.empcode=asd.empcode where asd.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

            gvGoals.DataSource = ds1;
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
                    Output.AssignParameter(sqlparam1, 4, "@approvertype", "String", 5, "Mgr");
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
                    Output.AssignParameter(sqlparam2, 6, "@mng_comm", "String", 8000, txtgoalcomm.Text.ToString());
                    Output.AssignParameter(sqlparam2, 7, "@emp_comm", "String", 8000, "");
                    SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "sp_appraisal_insert_assement_details", sqlparam2);

                    _Transaction.Commit();
                    txtTitle.Text = "";
                    txtDesc.Text = "";
                    txtWeightage.Text = "";
                    txtgoalcomm.Text = "";
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
        //bindGoals(empcode);
        bindGoals();
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
        //bindGoals(gvGoals.DataKeys[e.NewEditIndex].Values[1].ToString());
        bindGoals();
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;
        //bindGoals(gvGoals.DataKeys[e.RowIndex].Values[1].ToString());
        bindGoals();
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = 0;
        SqlParameter[] parm = new SqlParameter[7];
        SqlConnection Connection = null;
        try
        {
            //DataRow dr;
            int a = e.RowIndex;
            int asd_id = (int)gvGoals.DataKeys[e.RowIndex].Value;
            TextBox textrole = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text1");
            TextBox textkca = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text2");
            TextBox textkpi = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text3");
            TextBox textweight = (TextBox)gvGoals.Rows[(int)e.RowIndex].FindControl("text4");


            string sqlstr = @"Update tbl_appraisal_assessment_details set 
role='" + textrole.Text + "',kca='" + textkca.Text + "',kpi='" + textkpi.Text + "',weightage='" + textweight.Text + "' where asd_id='" + asd_id + "'";

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            bindGoals();
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
                Response.Redirect("ReviewGoalsByManager.aspx?upd=true");
            }
        }

    }

    protected void gvGoals_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        try
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
        SqlConnection Connection = null;
        //string sqls = @"select empcode,G2_cycle from tbl_appraisal_assessment where G2_cycle=1 and empcode='" + empcode + "'";
        string sqls = @"select empcode,G2_cycle from tbl_appraisal_assessment where freeze=1 and empcode='" + empcode + "'";
        DataSet dse_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqls);

        if (dse_1.Tables[0].Rows.Count < 1)
        {
            Output.Show("You have not freezed goals for Cycle 1");
            cycle2.Visible = false;
            return;
        }
        else
        {
            SqlParameter[] sqlparam1 = new SqlParameter[2];

            try
            {
                Connection = DataActivity.OpenConnection();
                Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, empcode);
                Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());

                //DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_getEmployeeDetails", sqlparam1);
                DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_getEmployeeDetails_1", sqlparam1);
                if (dse.Tables[0].Rows.Count >= 1)
                {
                    lblempname.Text = dse.Tables[0].Rows[0]["EmployeeName"].ToString();
                    lblempcode.Text = dse.Tables[0].Rows[0]["Empcode"].ToString();
                    lbldept.Text = dse.Tables[0].Rows[0]["Department"].ToString();
                    lbldesignation.Text = dse.Tables[0].Rows[0]["Designation"].ToString();
                    lblrole.Text = dse.Tables[0].Rows[0]["role"].ToString();
                    lblmanager.Text = dse.Tables[0].Rows[0]["Line_Manager"].ToString();
                    lblbuh.Text = dse.Tables[0].Rows[0]["Business_Head"].ToString();
                    lblReview.Text = dse.Tables[0].Rows[0]["app_cycle_period"].ToString();
                    lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                    lblLocation.Text = dse.Tables[0].Rows[0]["Location"].ToString();

                    if (dse.Tables[0].Rows[0]["line_manager_comment_for_cycle_2"].ToString() != "")
                    {
                        txtmgrComments.Text = dse.Tables[0].Rows[0]["line_manager_comment_for_cycle_2"].ToString();
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


                if (ds.Tables[0].Rows[0]["G2_cycle"].ToString() == "4")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) == 100)
                    {
                        //sqlstr = "update tbl_appraisal_revert set status=0 where revertbylevel=3 and as_id=(select as_id from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "')";             // updating status and glevel in revert table
                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                        //sqlstr = "update tbl_appraisal_revert set glevel=4 where glevel=3 and status=1 and as_id=(select as_id from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "')";               // updating glevel in revert table
                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                        sqlstr = @"update tbl_appraisal_assessment set G2_cycle=3,G2_mgr_comments='" + lblgoal2mngcomm.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
                    }
                    else
                    {
                        Output.Show("The Total Weightage of Goals  Should be 100.");
                    }
                }
                else if (ds.Tables[0].Rows[0]["G2_cycle"].ToString() == "2")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) == 100)
                    {
                        //sqlstr = "update tbl_appraisal_revert set status=0 where revertbylevel=3 and as_id=(select as_id from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "')";             // updating status and glevel in revert table
                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                        //sqlstr = "update tbl_appraisal_revert set glevel=4 where glevel=3 and status=1 and as_id=(select as_id from tbl_appraisal_assessment where status=1 and apc_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "')";               // updating glevel in revert table
                        //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                        sqlstr = @"update tbl_appraisal_assessment set G2_cycle=3,G2_mgr_comments='" + txtmgrComments.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
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
                        sqlstr = @"update tbl_appraisal_assessment set G1_cycle=3,G1_mgr_comments='" + txtmgrComments.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
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
        Response.Redirect("ReviewGoalsByManager.aspx");
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

    protected void btnSubmitToEmp_Click(object sender, EventArgs e)
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

                if (ds.Tables[0].Rows[0]["G2_cycle"].ToString() == "4")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) == 100)
                    {
                        sqlstr = @"update tbl_appraisal_assessment set G2_cycle=5,G2_mgr_comments='" + lblgoal2mngcomm.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
                    }
                    else
                    {
                        Output.Show("The Total Weightage of Goals  Should be 100.");
                    }
                }
                else if (ds.Tables[0].Rows[0]["G2_cycle"].ToString() == "2")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) == 100)
                    {
                        sqlstr = @"update tbl_appraisal_assessment set G2_cycle=5,G2_mgr_comments='" + txtmgrComments.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
                    }
                    else
                    {
                        Output.Show("The Total Weightage of Goals  Should be 100.");
                    }
                }
                else if (ds.Tables[0].Rows[0]["G1_cycle"].ToString() == "4")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) <= 100)
                    {
                        sqlstr = @"update tbl_appraisal_assessment set G1_cycle=5,G1_mgr_comments='" + lblgoal1mngcomm.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
                    }
                    else
                    {
                        Output.Show("The Total Weightage of Goals  Should not be more than 100.");
                    }
                }
                else if (ds.Tables[0].Rows[0]["G1_cycle"].ToString() == "2")
                {
                    if (Convert.ToDecimal(goalstotalweightage.Text.Trim()) <= 100)
                    {
                        sqlstr = @"update tbl_appraisal_assessment set G1_cycle=5,G1_mgr_comments='" + txtmgrComments.Text + "' where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Request.QueryString["empcode"].ToString() + "'";
                        DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

                        Response.Redirect("ReviewGoalsByManager.aspx?updated=true");
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

    protected void btn_submit_LM_review_Click(object sender, EventArgs e)
    {
        int i = 0;
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            sqlstr = @"update tbl_appraisal_assessment set line_manager_comment_for_cycle_2='" + txtmgrComments.Text.Trim() + "' where empcode='" + lblempcode.Text + "'";
            //DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
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
                Response.Redirect("ReviewGoalsByManager.aspx?submit=true");
            }
        }
    }

}