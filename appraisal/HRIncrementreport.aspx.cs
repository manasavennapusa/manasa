using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Web.UI;

public partial class appraisal_HRIncrementreport : System.Web.UI.Page
{
    decimal grdTotal = 0;
    decimal ratingweightagetotal = 0;
    decimal mgrgrdTotal = 0;
    decimal mgrratingweightagetotal = 0;
    string EmployeeCode = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode, sqlstr;
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    DataActivity activity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
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
                bindEmpIncreamentDetails(EmployeeCode);
                //  bind_job_detail(EmployeeCode);
                bindratingrid();
                bindGoals(EmployeeCode);
                gvGoals_RowDataBound();
                bindtraining(EmployeeCode);
                bindHREmpIncreamentDetails(EmployeeCode);
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
                //lblpregrade.Text = dse.Tables[0].Rows[0]["lastgrade"].ToString();
                lblprectc.Text = dse.Tables[0].Rows[0]["CTC"].ToString();
                lblprehike.Text = dse.Tables[0].Rows[0]["lasthike"].ToString();
                lblprebonus.Text = dse.Tables[0].Rows[0]["lastBonus"].ToString();

                lblrevloc.Text = dse.Tables[0].Rows[0]["curworklocation"].ToString();
                //lblrevdept.Text = dse.Tables[0].Rows[0]["curdept"].ToString();
                lblrevdes.Text = dse.Tables[0].Rows[0]["curdesignation"].ToString();
                //lblrevgrade.Text = dse.Tables[0].Rows[0]["curgrade"].ToString();
                lblrevcostcenter.Text = dse.Tables[0].Rows[0]["curcostcenter"].ToString();
                lblcurhike.Text = dse.Tables[0].Rows[0]["curhike"].ToString();
                lblincramount.Text = dse.Tables[0].Rows[0]["curbouns"].ToString();
                lblcurctc.Text = dse.Tables[0].Rows[0]["curctc"].ToString();
                lblcurbonus.Text = dse.Tables[0].Rows[0]["curincreasedamount"].ToString();
                lblrevdate.Text = (string.IsNullOrEmpty(dse.Tables[0].Rows[0]["wefdate"].ToString()) != true) ? Convert.ToDateTime(dse.Tables[0].Rows[0]["wefdate"].ToString()).ToString("dd/MMM/yyyy") : "";
                lblprecomm.Text = dse.Tables[0].Rows[0]["comments"].ToString();
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
                lbldept.Text = dse.Tables[0].Rows[0]["dept"].ToString();
                lbldes.Text = dse.Tables[0].Rows[0]["designation"].ToString();
                lblpregrade.Text = dse.Tables[0].Rows[0]["grade"].ToString();
                lblprectc.Text = dse.Tables[0].Rows[0]["CTC"].ToString();
                // lblprehike.Text = dse.Tables[0].Rows[0]["grade"].ToString();
                // lblprebonus.Text = dse.Tables[0].Rows[0]["grade"].ToString();
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
    //protected void bind_job_detail(string emp_code)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string sqlstr = "SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name, emp.emp_status, emp.dept_id, emp.division_id,emp.degination_id, emp.Grade, emp.branch_id,(CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,emp.reason_leaving,emp.salutation ,emp.official_email_id,emp.official_mob_no,emp.cost_center_group_id,emp.cost_center_code,emp.country,emp.state,emp.city,emp.location,emp.add_cost_center_group_id,emp.add_cost_center_code,emp.add_country,emp.add_state,emp.add_city,emp.add_location,emp.subgroupid,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";

    //        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds.Tables[0].Rows.Count < 1)
    //            return;


    //        if ((ds.Tables[0].Rows[0]["branch_id"].ToString() != "") && (ds.Tables[0].Rows[0]["branch_id"].ToString() != "0"))
    //        {
    //            drpbranch.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
    //            bind_departmnt(Convert.ToInt16(ds.Tables[0].Rows[0]["branch_id"]));
    //        }
    //        if ((ds.Tables[0].Rows[0]["dept_id"].ToString() != "") && (ds.Tables[0].Rows[0]["dept_id"].ToString() != "0"))
    //        {
    //            drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["dept_id"].ToString();
    //            BindDesignation(ds.Tables[0].Rows[0]["dept_id"].ToString());
    //        }
    //        if ((ds.Tables[0].Rows[0]["division_id"].ToString() != "0") && (ds.Tables[0].Rows[0]["division_id"].ToString() != ""))
    //        {
    //            drpdivision.SelectedValue = ds.Tables[0].Rows[0]["division_id"].ToString();
    //        }
    //        if ((ds.Tables[0].Rows[0]["degination_id"].ToString() != "0") && (ds.Tables[0].Rows[0]["degination_id"].ToString() != ""))
    //        {
    //            drpdegination.SelectedValue = ds.Tables[0].Rows[0]["degination_id"].ToString();
    //        }

    //        if ((ds.Tables[0].Rows[0]["Grade"].ToString() != "0") && (ds.Tables[0].Rows[0]["Grade"].ToString() != ""))
    //        {
    //            drpgrade.SelectedValue = ds.Tables[0].Rows[0]["Grade"].ToString();
    //        }


    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}
    //protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    //}
    //protected void bind_departmnt(int branchid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' ";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpdepartment.DataTextField = "department_name";
    //        drpdepartment.DataValueField = "departmentid";
    //        drpdepartment.DataSource = ds1;
    //        drpdepartment.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}
    //protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    BindDesignation(drpdepartment.SelectedValue);
    //}

    //private void BindDesignation(string deptid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid;
    //        DataSet desids = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (desids.Tables[0].Rows.Count > 0)
    //        {
    //            drpdegination.DataSource = desids;
    //            drpdegination.DataTextField = "designationname";
    //            drpdegination.DataValueField = "id";
    //            drpdegination.DataBind();
    //        }
    //        // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}
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

            DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_appraisal_listof_EmpforHR", sqlparam);

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


            DataSet ds = SQLServer.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_appraisal_listofIncreatement_hr]", sqlparam);
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

    protected void dd_dpt_DataBound(object sender, EventArgs e)
    {
        dd_dpt.Items.Insert(0, new ListItem("----- All -----", "0"));
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
                txttraining.Text = dse.Tables[0].Rows[0]["trainingdetails"].ToString();
                lblReview.Text = dse.Tables[0].Rows[0]["app_cycle"].ToString();
                lblcostcenter.Text = dse.Tables[0].Rows[0]["cost_center_name"].ToString();
                lblLocation.Text = dse.Tables[0].Rows[0]["location"].ToString();
                if ((dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G1_cycle"].ToString() == "6"))
                {
                    lblgoal1empcomm.Text = dse.Tables[0].Rows[0]["G1_emp_comments"].ToString();
                    lblgoal1mngcomm.Text = dse.Tables[0].Rows[0]["G1_mgr_comments"].ToString();
                }
                if ((dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6") || (dse.Tables[0].Rows[0]["G2_cycle"].ToString() == "6"))
                {
                    lbempcmts.Text = dse.Tables[0].Rows[0]["G2_emp_comments"].ToString();
                    txtmgrComments.Text = dse.Tables[0].Rows[0]["G2_mgr_comments"].ToString();
                }
                lblcyl1intdate.Text = dse.Tables[0].Rows[0]["G1_initiateddate"].ToString();
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
            //gridratings.DataSource = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            //gridratings.DataBind();
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
            string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.title,aps.description,aps.weightage,aps.emp_comments,aps.mng_comments  ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status=1  and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + empcode + "'";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            gvGoals.DataSource = ds;
            gvGoals.DataBind();
            if (ds.Tables[0].Rows.Count >= 1)
            {
                hdnassid.Value = ds.Tables[0].Rows[0]["assessment_id"].ToString();
                if (ds.Tables[0].Rows[0]["emprating"].ToString() != "")
                {
                    gvGoals.Columns[4].Visible = true;
                    gvGoals.Columns[5].Visible = true;
                    troverall1.Visible = true;
                    gvGoals.ShowFooter = true;
                    gvGoals_RowDataBound();
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
                if (ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim() != "")
                    lblBehavior.BackColor = System.Drawing.ColorTranslator.FromHtml(ds.Tables[0].Rows[0]["behavior_color"].ToString().Trim());
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
        Response.Redirect("ApproverIncreamentDetails.aspx");
    }
    protected void gveligible_PreRender(object sender, EventArgs e)
    {
        if (gveligible.Rows.Count > 0)
            gveligible.HeaderRow.TableSection = TableRowSection.TableHeader;
        else gveligible.EmptyDataText = "No Records Found";
    }

    private void InsertIncrementStatus(SqlConnection Connection, SqlTransaction _transaction, int status)
    {
        //string str1 = "";
        //str1 = @"update tbl_appraisal_assessment set I_cycle='" + status + "' where assessment_id= " + Convert.ToInt32(hdnassid.Value) + "";
        //SQLServer.ExecuteDataset(Connection, CommandType.Text, _transaction, str1);

        //if (txtcomm.Text != "")
        //{
        //    txtcomm.Text = "<h6><b>Comments added by " + Session["name"] + " on " + DateTime.Now +
        //                       " :</b><br>" + txtcomm.Text + "</h6>";
        //}
        //else txtcomm.Text = "";

        //string str2 = @"update tbl_appraisal_increament_details set  comments=isnull(comments,'')+'" + txtcomm.Text.ToString() + "' where assessment_id= " + Convert.ToInt32(hdnassid.Value) + "";

        //SQLServer.ExecuteDataset(Connection, CommandType.Text, _transaction, str1);

    }
    //protected void insertIncreamenetDetails(SqlConnection Connection, SqlTransaction _transaction)
    //{
    //    SqlParameter[] sqlparam1 = new SqlParameter[21];
    //    Output.AssignParameter(sqlparam1, 0, "@assessment_id ", "Int", 50, hdnassid.Value.ToString());
    //    Output.AssignParameter(sqlparam1, 1, "@lastworklocation", "Int", 0, "0");
    //    Output.AssignParameter(sqlparam1, 2, "@lastdept", "String", 50, "0");
    //    Output.AssignParameter(sqlparam1, 3, "@lastdesignation", "Int", 0, lbldes.Text);
    //    Output.AssignParameter(sqlparam1, 4, "@lastgrade", "String", 50, lblpregrade.Text);
    //    Output.AssignParameter(sqlparam1, 5, "@lastcostcenter", "Int", 0, "0");
    //    Output.AssignParameter(sqlparam1, 6, "@lasthike", "String", 50, lblprehike.Text);
    //    Output.AssignParameter(sqlparam1, 7, "@lastctc", "Int", 0, lblprectc.Text);
    //    Output.AssignParameter(sqlparam1, 8, "@curworklocation", "String", 50, drpbranch.SelectedValue);
    //    Output.AssignParameter(sqlparam1, 9, "@curdept", "Int", 0, drpdepartment.SelectedValue);
    //    Output.AssignParameter(sqlparam1, 10, "@curdesignation", "String", 50, drpdegination.SelectedValue);
    //    Output.AssignParameter(sqlparam1, 11, "@curgrade", "Int", 0, drpgrade.SelectedValue);
    //    Output.AssignParameter(sqlparam1, 12, "@curcostcenter", "String", 50, drpdivision.SelectedValue);
    //    Output.AssignParameter(sqlparam1, 13, "@curhike", "Int", 0, txtcurhike.Text);
    //    Output.AssignParameter(sqlparam1, 14, "@curincreasedamount", "String", 50, txtincramount.Text);
    //    Output.AssignParameter(sqlparam1, 15, "@curctc", "Int", 0, txtcurctc.Text);
    //    Output.AssignParameter(sqlparam1, 16, "@curbouns", "String", 50, txtcurbonus.Text);
    //    Output.AssignParameter(sqlparam1, 17, "@wefdate", "Int", 0, txtrevdate.Text);
    //    Output.AssignParameter(sqlparam1, 18, "@comments", "Int", 0, txtcomm.Text);
    //    Output.AssignParameter(sqlparam1, 19, "@createdby", "String", 50, Session["empcode"].ToString());
    //    Output.AssignParameter(sqlparam1, 20, "@empcode", "String", 50, Request.QueryString["empcode"].ToString());

    //    int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _transaction, "sp_appraisal_insert_increament_details", sqlparam1);

    //}
    protected void btnapprove_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam1 = new SqlParameter[2];
        string I_cycle = "0";
        SqlConnection Connection = null;
        SqlTransaction _transaction = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            Output.AssignParameter(sqlparam1, 0, "@empcode", "String", 50, Request.QueryString["empcode"].ToString());
            Output.AssignParameter(sqlparam1, 1, "@appcycleid", "Int", 0, Session["appcycle"].ToString());
            DataSet dse = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_appraisal_getEmployeeDetails", sqlparam1);
            if (dse.Tables[0].Rows.Count >= 1)
            {
                I_cycle = dse.Tables[0].Rows[0]["I_cycle"].ToString();
            }
            _transaction = Connection.BeginTransaction();
            if (I_cycle.ToString() == "1")
                InsertIncrementStatus(Connection, _transaction, 2);
            else if (I_cycle.ToString() == "3")
                InsertIncrementStatus(Connection, _transaction, 4);
            _transaction.Commit();
            //  bindgrid();
        }
        catch (Exception ex)
        {
            _transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        Response.Redirect("HRIncrementreport.aspx");
    }
    protected void btnreject_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _transaction = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            _transaction = Connection.BeginTransaction();
            //   insertIncreamenetDetails(Connection, _transaction);
            InsertIncrementStatus(Connection, _transaction, 5);
            _transaction.Commit();
        }
        catch (Exception ex)
        {
            _transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    protected void btnBack_Click1(object sender, EventArgs e)
    {
        Response.Redirect("ViewEmployeeListByHR.aspx");
    }
}