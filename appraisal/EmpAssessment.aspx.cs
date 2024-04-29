using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;
using DataAccessLayer;
using Smart.HR.Common.Mail.Module;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;


public partial class appraisal_EmpAssessment : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal grdTotal2 = 0;
    DataActivity DataActivity = new DataActivity();

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
            bindgrid();
            //bindRevertDetails();
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        int flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select G1_cycle,G2_cycle from tbl_appraisal_assessment where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);
            string sqlstr = "";

            if (ds1.Tables[0].Rows.Count > 0)
            {

                if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "1")
                {
                    sqlstr = @"update tbl_appraisal_assessment set G1_cycle=2,G1_emp_comments='" + txtComments.Text + "' where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "'";
                }

                if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "5")
                {
                    sqlstr = @"update tbl_appraisal_assessment set G1_cycle=4,G1_emp_comments='" + lblgoal1empcomm.Text + "' where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "'";
                }

                if (ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "1")
                {
                    sqlstr = @"update tbl_appraisal_assessment set G2_cycle=2,G2_emp_comments='" + txtComments.Text + "' where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "'";
                }

                if (ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "5")
                {
                    sqlstr = @"update tbl_appraisal_assessment set G2_cycle=4,G2_emp_comments='" + lblgoal1empcomm.Text + "' where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "'";
                }


                flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);
            }

            if (flag > 0)
            {
                Output.Show("goal has been Submitted successfully!");
                //sqlstr = "update tbl_appraisal_revert set glevel=2 where glevel=1 and status=1 and as_id=(select as_id from tbl_appraisal_assessment where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "')";               // updating glevel in revert table
                //SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);

                bindgrid();
                //sendMail(Session["empcode"].ToString());
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

    /*--------------------------------Start Goals--------------------------*/

    protected void AddGoals_Click(object sender, EventArgs e)
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

    protected void btnSaveGoals_Click(object sender, EventArgs e)
    {
        decimal weightage = 0;

        if (gvGoals.Rows.Count == 0)
        {
            addgoals();
            return;
        }
        Label total = (Label)gvGoals.FooterRow.FindControl("lblTotalWeightage");
        weightage = Convert.ToDecimal(total.Text);

        weightage = weightage + Convert.ToDecimal(txtWeightage.Text);
        if (weightage <= 100)
        {
            addgoals();
        }
        else
        {
            Output.Show("Total Weightage Should not be greater than 100.");
        }
    }

    protected void addgoals()
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {

            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            string str2 = @" select assessment_id,empcode,G1_cycle,G2_cycle from tbl_appraisal_assessment where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "' ";
            DataSet ds_asID = SQLServer.ExecuteDataset(Connection, CommandType.Text, _Transaction, str2);

            if (ds_asID.Tables[0].Rows.Count >= 1)
            {
                if (ds_asID.Tables[0].Rows[0]["assessment_id"].ToString() != "")
                {
                    string cycletype = ds_asID.Tables[0].Rows[0]["G1_cycle"].ToString() == "1" ? "1" : "2";
                    string assessment_id = ds_asID.Tables[0].Rows[0]["assessment_id"].ToString();
                    SqlParameter[] sqlparam1 = new SqlParameter[8];
                    Output.AssignParameter(sqlparam1, 0, "@assessment_id", "Int", 0, assessment_id);
                    Output.AssignParameter(sqlparam1, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(sqlparam1, 2, "@level", "Int", 0, "2");
                    Output.AssignParameter(sqlparam1, 3, "@flow_status", "String", 1, "P");
                    Output.AssignParameter(sqlparam1, 4, "@approvertype", "String", 5, "E");
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
                    Output.AssignParameter(sqlparam2, 6, "@emp_comm", "String", 8000, txtgoalcomm.Text.ToString());
                    Output.AssignParameter(sqlparam2, 7, "@mng_comm", "String", 8000, "");
                    SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, "sp_appraisal_insert_assement_details", sqlparam2);

                    _Transaction.Commit();
                    txtTitle.Text = "";
                    txtDesc.Text = "";
                    txtWeightage.Text = "";
                    txtgoalcomm.Text = "";
                    traddGoals.Visible = false;
                    AddGoals.Visible = true;
                    bindgrid();

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
        bindgrid();
    }


    protected void gvGoals_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvGoals.EditIndex = e.NewEditIndex;
        bindgrid();
    }

    protected void gvGoals_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvGoals.EditIndex = -1;
        bindgrid();
    }

    protected void gvGoals_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlParameter[] parm = new SqlParameter[7];
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
                string comm = ((TextBox)gvGoals.Rows[e.RowIndex].Cells[1].FindControl("txtcomm")).Text;

                if (title != "")
                {
                    int code = (int)gvGoals.DataKeys[e.RowIndex].Value;

                    Output.AssignParameter(parm, 0, "@asd_id", "Int", 0, gvGoals.DataKeys[e.RowIndex].Values[0].ToString());
                    Output.AssignParameter(parm, 1, "@title", "String", 100, title);
                    Output.AssignParameter(parm, 2, "@description", "String", 8000, desc);
                    Output.AssignParameter(parm, 3, "@weightage", "Decimal", 0, weightage);
                    Output.AssignParameter(parm, 4, "@updatedby", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 5, "@emp_comm", "String", 8000, comm);
                    Output.AssignParameter(parm, 6, "@mng_comm", "String", 8000, "");
                    int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, "sp_appraisal_updategoals_byuser", parm);
                    if (i > 0)
                    {
                        gvGoals.EditIndex = -1;
                        bindgrid();
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        traddGoals.Visible = false;
        AddGoals.Visible = true;
        txtTitle.Text = "";
        txtDesc.Text = "";
        txtWeightage.Text = "";
    }

    /*--------------------------------End Goals----------------------------*/


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

    private void bindgrid()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select G1_cycle,G2_cycle,G1_emp_comments,G1_mgr_comments ,G2_emp_comments ,G2_mgr_comments from tbl_appraisal_assessment where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                if ((ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "1" || ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "5") || (ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "1" || ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "5"))
                {
                    string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage, emp_comments,mng_comments,
case when cycle_type='1' and G1_cycle='1' and approvertype='E' then 'E' when cycle_type='2' and G2_cycle='1' and approvertype='E' then 'E' else 'NE' end as IsEditable
from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id   inner join tbl_appraisal_flow f on f.flow_id=aps.flow_id  where apt.status=1 and ( (apt.G1_cycle=1 or apt.G1_cycle=5)or(apt.G2_cycle=1 or apt.G2_cycle=5)) and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
                    DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
                    grdTotal = 0;
                    grdTotal2 = 0;
                    gvGoals.DataSource = ds;
                    gvGoals.DataBind();
                    trbtns.Visible = true;
                    btns.Visible = true;
                    btnSubmit.Visible = true;


                    if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "1")
                    {
                        btn_SendToHR.Visible = false;
                        trbtns.Visible = true;
                        gvGoals.Columns[6].Visible = true;

                        tbl_gc1.Visible = true;
                        tr_gc1_heading.Visible = true;
                        tr_gc1_employeecomments.Visible = false;
                        tr_gc1_managercomments.Visible = false;

                        tbl_gc2.Visible = false;
                        tr_gc2_heading.Visible = false;
                        tr_gc2_employeecomments.Visible = false;
                        tr_gc2_managercomments.Visible = false;

                        Output.Show("Click on Add Goals Button to Add Goals");
                        btnSubmit.Text = "Submit To Manager";
                        btnSubmit.CssClass = "btn btn-success";
                    }
                    else if (ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "1")
                    {
                        btn_SendToHR.Visible = false;
                        trbtns.Visible = true;
                        gvGoals.Columns[6].Visible = true;

                        tbl_gc1.Visible = true;
                        tr_gc1_heading.Visible = true;
                        tr_gc1_employeecomments.Visible = true;
                        tr_gc1_managercomments.Visible = true;

                        tbl_gc2.Visible = true;
                        tr_gc2_heading.Visible = true;
                        tr_gc2_employeecomments.Visible = false;
                        tr_gc2_managercomments.Visible = false;

                        lblgoal1empcomm.Text = ds1.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                        lblgoal1mngcomm.Text = ds1.Tables[0].Rows[0]["G1_mgr_comments"].ToString();

                        Output.Show("Click on Add Goals Button to Add Goals");
                        btnSubmit.Text = "Submit To Manager";
                        btnSubmit.CssClass = "btn btn-success";
                    }
                    else if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "5")
                    {
                        AddGoals.Visible = false;
                        tbl_gc1.Visible = true;
                        tr_gc1_heading.Visible = true;
                        tr_gc1_employeecomments.Visible = true;
                        tr_gc1_managercomments.Visible = true;

                        tbl_gc2.Visible = false;
                        tr_gc2_heading.Visible = false;
                        tr_gc2_employeecomments.Visible = false;
                        tr_gc2_managercomments.Visible = false;

                        lblgoal1empcomm.Text = ds1.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                        lblgoal1mngcomm.Text = ds1.Tables[0].Rows[0]["G1_mgr_comments"].ToString();

                        tbl_overallcomments.Visible = false;
                    }
                    else if (ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "5")
                    {
                        AddGoals.Visible = false;
                        tbl_gc1.Visible = true;
                        tr_gc1_heading.Visible = true;
                        tr_gc1_employeecomments.Visible = true;
                        tr_gc1_managercomments.Visible = true;

                        tbl_gc2.Visible = true;
                        tr_gc2_heading.Visible = true;
                        tr_gc2_employeecomments.Visible = true;
                        tr_gc2_managercomments.Visible = true;

                        lblgoal1empcomm.Text = ds1.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                        lblgoal1mngcomm.Text = ds1.Tables[0].Rows[0]["G1_mgr_comments"].ToString();

                        lblgoal2empcomm.Text = ds1.Tables[0].Rows[0]["G2_emp_comments"].ToString();
                        lblgoal2mngcomm.Text = ds1.Tables[0].Rows[0]["G2_mgr_comments"].ToString();

                        tbl_overallcomments.Visible = false;
                    }
                    else
                    {
                        AddGoals.Visible = false;
                        btnSubmit.Text = "Resend To Manager";
                        btnSubmit.CssClass = "btn btn-danger";
                        txtComments.Enabled = false;
                        if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "5")
                        {
                            txtComments.Text = ds1.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                            lblgoal2mngcomm.Text = ds1.Tables[0].Rows[0]["G1_mgr_comments"].ToString();
                            trgoal1.Visible = false;

                        }
                        if ((ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "5"))
                        {
                            txtComments.Text = ds1.Tables[0].Rows[0]["G2_emp_comments"].ToString();
                            lblgoal2mngcomm.Text = ds1.Tables[0].Rows[0]["G2_mgr_comments"].ToString();
                        }
                        btn_SendToHR.Visible = true;
                        AddGoals.Visible = false;
                        trbtns.Visible = false;
                        gvGoals.Columns[6].Visible = false;
                    }


                }
                else
                {
                    trbtns.Visible = false;
                    //Output.Show("You have already Submitted the goals for this Appraisal Cycle");

                    gvGoals.DataSource = null;
                    gvGoals.DataBind();
                    btns.Visible = false;
                    btnSubmit.Visible = false;

                    tbl_gc1.Visible = false;
                    tbl_gc2.Visible = false;
                    tbl_overallcomments.Visible = false;
                    table.Visible = false;

                }
            }
            else
            {
                Output.Show("You are not initiated for this Appraisal Cycle");

                trbtns.Visible = false;
                btns.Visible = false;
                btnSubmit.Visible = false;
                tbl_gc1.Visible = false;
                tbl_gc2.Visible = false;
                tbl_overallcomments.Visible = false;
                table.Visible = false;
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

    protected void sendMail(string empcode)
    {

        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            string sqlstr = @"select e.empcode,e.official_email_id,isnull(e.emp_fname,' ')+' ' +isnull(e.emp_m_name,' ')+' ' +isnull(e.emp_l_name,' ') as empname,
                           isnull(j.emp_fname,' ')+' ' +isnull(j.emp_m_name,' ')+' ' +isnull(j.emp_l_name,' ') as supervisorname,j.empcode as supervisorcode,j.official_email_id as supervisorEmail from 
                            tbl_intranet_employee_jobDetails e left join tbl_intranet_employee_jobDetails j  on j.empcode=e.supervisorcode where e.empcode='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["supervisorEmail"].ToString() != "")
                {
                    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                    string subject = ConfigurationManager.AppSettings["subject_Emp2Mgr"].ToString();
                    string bodyContent = ConfigurationManager.AppSettings["bodyContent_Emp2Mgr"].ToString();
                    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["supervisorname"].ToString(), bodyContent);
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["supervisorEmail"].ToString(), "", subject, completeBody, smtp, emailLogo);
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


    /*--------------------------------Start Compentencies--------------------------*/

    private void bindcomgrid()
    {
        //SqlParameter[] sqlparam = new SqlParameter[5];
        //SqlConnection Connection = null;
        //try
        //{
        //     Connection = DataActivity.OpenConnection();
        //    string str = @"select * from tbl_appraisal_compentencies where apc_id=" + Convert.ToInt32(Session["appcycle"]) + "";
        //    DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);

        //    gv_comp.DataSource = ds;
        //    gv_comp.DataBind();
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

    protected void gvcompentencies_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        decimal rowTotal2 = Convert.ToDecimal
        //                    (DataBinder.Eval(e.Row.DataItem, "weightage"));
        //        grdTotal2 = grdTotal2 + rowTotal2;
        //    }
        //    if (e.Row.RowType == DataControlRowType.Footer)
        //    {
        //        Label lbl = (Label)e.Row.FindControl("lblTotalWeightage");
        //        lbl.Text = grdTotal2.ToString();
        //    }
    }

    /*--------------------------------End Compentencies--------------------------*/

    protected void btn_SendToHR_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];
        SqlConnection Connection = null;
        int flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            string str1 = @"select G1_cycle,G2_cycle from tbl_appraisal_assessment where status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  empcode='" + Session["empcode"].ToString() + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(Connection, CommandType.Text, str1);

            if (ds1.Tables[0].Rows.Count > 0)
            {
                if (ds1.Tables[0].Rows[0]["G1_cycle"].ToString() == "5")
                {
                    string sqlstr = @"update tbl_appraisal_assessment set G1_cycle=6, G1_emp_comments='" + lblgoal1empcomm.Text + "' where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "'";
                    flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);
                   // if (flag > 0)
                       // SendEmailCycle1(Session["empcode"].ToString(), Convert.ToInt32(Session["appcycle"]));
                }
                if (ds1.Tables[0].Rows[0]["G2_cycle"].ToString() == "5")
                {
                    string sqlstr = @"update tbl_appraisal_assessment set G2_cycle=6,G2_emp_comments='" + lblgoal2empcomm.Text + "' where  status=1 and  appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and empcode='" + Session["empcode"].ToString() + "'";
                    flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, sqlstr);
                    //if (flag > 0)
                        //SendEmailCycle2(Session["empcode"].ToString(), Convert.ToInt32(Session["appcycle"]));
                }
            }
            if (flag > 0)
            {
                Output.Show("goal has been Submitted successfully!");
                trRevertComments.Visible = false;
                trgoal1.Visible = false;
                bindgrid();

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

    void SendEmailCycle1(string empcode, int appraisalId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Appraisal.SubmittingToHRCycleI();
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

    void SendEmailCycle2(string empcode, int appraisalId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Appraisal.SubmittingToHRCycleII();
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
}