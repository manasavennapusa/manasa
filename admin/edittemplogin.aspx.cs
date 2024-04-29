using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Data.SqlClient;
using System.Security.Cryptography;
using Utilities;
using Common.Console;
using Common.Data;
public partial class admin_edittemplogin : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    //=========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {

        lbl_msg.Text = "";
        string emp_code = Session["empcode"].ToString();

        if (!IsPostBack)
        {

            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            if (!ValidateTempEmployee())
                return;

            if (Session["Child"] != null)
            {
                Session.Remove("Child");
            }
            if (Session["acc_education"] != null)
            {
                Session.Remove("acc_education");
            }
            if (Session["Pro_education"] != null)
            {
                Session.Remove("Pro_education");
            }
            if (Session["exp"] != null)
            {
                Session.Remove("exp");
            }

            // doj.Text = System.DateTime.Now.ToShortDateString();
            bind_ddlCCgroup();
            bind_ddl_aCCgroup();
            bind_per_country();
            bind_pre_country();
            bind_Emergency_country();
            //bind_Entity();
            //bind_subgroup();
            bind_broadgroup();
            bind_emp();
            bind_emp_doc(emp_code);
            bind_job_detail(emp_code);
            bind_contactdetails(emp_code);
            bind_personalinfo(emp_code);
            bind_child(emp_code);
            bind_Education_Qualification(emp_code);
            bind_Professional_Qualification(emp_code);
            bind_Exp_detail(emp_code);
            bind_Training_detail(emp_code);
            bind_payrolldetails(emp_code);


            Getdefaultlable();


        }
    }

    private bool ValidateTempEmployee()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select * from dbo.tbl_intranet_employee_templogin_details where empcode='" + Session["empcode"].ToString() + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                hdnstatus.Value = ds.Tables[0].Rows[0]["status"].ToString();
                if (ds.Tables[0].Rows[0]["status"].ToString() == "1")
                {
                    div.Visible = false;
                    SmartHr.Common.Alert("Your are alreday submited details to HR.");
                    return false;
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() == "2")
                {
                    if ((ds.Tables[0].Rows[0]["comments"].ToString() != null) || (ds.Tables[0].Rows[0]["status"].ToString() != ""))
                    {
                        comment.Visible = true;
                        txtcomments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        return true;
    }


    protected void ddlSalutation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlSalutation.SelectedValue == "Ms") || (ddlSalutation.SelectedValue == "Mrs"))
        {
            drpgender.SelectedValue = "Female";
        }
        else
        {
            drpgender.SelectedValue = "Male";
        }
    }
    protected void drpgender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((drpgender.SelectedValue == "Female"))
        {
            ddlSalutation.SelectedValue = "Ms";
        }
        else
        {
            ddlSalutation.SelectedValue = "Mr";
        }
    }

    //------------- bind the Job Detail of the emp master ----------------------------------------

    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name, emp.emp_status, emp.dept_id, emp.division_id,emp.degination_id, emp.Grade, emp.branch_id,(CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,emp.reason_leaving,emp.salutation ,emp.official_email_id,emp.official_mob_no,emp.cost_center_group_id,emp.cost_center_code,emp.country,emp.state,emp.city,emp.location,emp.add_cost_center_group_id,emp.add_cost_center_code,emp.add_country,emp.add_state,emp.add_city,emp.add_location,emp.subgroupid,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            txt_card_no.Text = ds.Tables[0].Rows[0]["card_no"].ToString();
            //if (ds.Tables[0].Rows[0]["emp_gender"].ToString() == "MALE")
            //{
            //    drpgender.SelectedItem.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            //    drpgender.Items.Insert(0, new ListItem("FEMALE", "Male"));
            //}
            //else
            //{
            //    drpgender.SelectedItem.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            //    drpgender.Items.Insert(0, new ListItem("FEMALE", "Female"));
            //}
            txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
            txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
            txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            if ((ds.Tables[0].Rows[0]["branch_id"].ToString() != "") && (ds.Tables[0].Rows[0]["branch_id"].ToString() != "0"))
            {
                drpbranch.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
                bind_departmnt(Convert.ToInt16(ds.Tables[0].Rows[0]["branch_id"]));
            }
            drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["dept_id"].ToString();
            if ((ds.Tables[0].Rows[0]["division_id"].ToString() != "0") && (ds.Tables[0].Rows[0]["division_id"].ToString() != ""))
            {
                drpdivision.SelectedValue = ds.Tables[0].Rows[0]["division_id"].ToString();
            }
            if ((ds.Tables[0].Rows[0]["degination_id"].ToString() != "0") && (ds.Tables[0].Rows[0]["degination_id"].ToString() != ""))
            {
                drpdegination.SelectedValue = ds.Tables[0].Rows[0]["degination_id"].ToString();
            }
            if (ds.Tables[0].Rows[0]["emp_doj"].ToString() != "")
                doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
            else doj.Text = "";
            txtext.Text = ds.Tables[0].Rows[0]["ext_number"].ToString();
            //txt_login_id.Text = ds.Tables[0].Rows[0]["login_id"].ToString();
            ViewState.Add("Photo", ds.Tables[0].Rows[0]["branch_id"].ToString());
            drprole.SelectedValue = ds.Tables[0].Rows[0]["role"].ToString();

            txtsalary.Text = ds.Tables[0].Rows[0]["salary_cal_from"].ToString();
            txtdol.Text = ds.Tables[0].Rows[0]["emp_doleaving"].ToString();
            txtreason.Text = ds.Tables[0].Rows[0]["reason_leaving"].ToString();

            //============added on 16-12-13======
            bind_empstatus();
            ddlSalutation.SelectedValue = ds.Tables[0].Rows[0]["salutation"].ToString();
            drpempstatus.SelectedValue = ds.Tables[0].Rows[0]["emp_status"].ToString();
            if (drpempstatus.SelectedItem.Text == "Probation")
            {
                trprobationperiod.Visible = true;
                trprobationdate.Visible = true;

                trprobationdate2.Visible = true;
                trprobationdate3.Visible = true;
                REg_probation_date.Enabled = true;
                REg_probationdate2.Enabled = true;
                txt_probationperiod.Text = ds.Tables[0].Rows[0]["probationperiod"].ToString();
                txt_probation_date.Text = ds.Tables[0].Rows[0]["probationenddate"].ToString();
                trduptstart.Visible = false;
                trduptenddate.Visible = false;
                RFV_probation_date.Enabled = true;
                RFV_probationperiod.Enabled = true;
                RFV_deput_start_date.Enabled = false;
                RFV_deput_end_date.Enabled = false;
                RFV_DOL.Enabled = false;
                trDOL.Visible = false;
                trReasonL.Visible = false;
            }
            else
                if (drpempstatus.SelectedItem.Text == "Contractual")
                {
                    trprobationperiod.Visible = false;
                    trprobationdate.Visible = false;
                    trduptstart.Visible = true;
                    trduptenddate.Visible = true;

                    trDOL.Visible = false;
                    trReasonL.Visible = false;

                    trprobationdate2.Visible = false;
                    trprobationdate3.Visible = false;
                    REg_probation_date.Enabled = false;
                    REg_probationdate2.Enabled = false;
                    if (ds.Tables[0].Rows[0]["deputationstartdate"] != "")

                        txt_deput_start_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["deputationstartdate"]).ToString("dd-MMM-yyyy");

                    else txt_deput_start_date.Text = "";
                    if (ds.Tables[0].Rows[0]["deputationenddate"] != "")
                        txt_deput_end_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["deputationenddate"]).ToString("dd-MMM-yyyy");
                    else txt_deput_end_date.Text = "";
                    RFV_probation_date.Enabled = false;
                    RFV_probationperiod.Enabled = false;
                    RFV_deput_start_date.Enabled = true;
                    RFV_deput_end_date.Enabled = true;
                }
                else
                    if (drpempstatus.SelectedItem.Text == "Resigned")
                    {
                        trprobationperiod.Visible = false;
                        trprobationdate.Visible = false;
                        trprobationdate2.Visible = false;
                        trprobationdate3.Visible = false;
                        REg_probation_date.Enabled = false;
                        REg_probationdate2.Enabled = false;
                        trduptstart.Visible = false;
                        trduptenddate.Visible = false;
                        RFV_probation_date.Enabled = false;
                        RFV_probationperiod.Enabled = false;
                        RFV_deput_start_date.Enabled = false;
                        RFV_deput_end_date.Enabled = false;
                        RFV_DOL.Enabled = true;
                        trDOL.Visible = true;
                        trReasonL.Visible = true;

                    }
                    else
                    {
                        trprobationperiod.Visible = false;
                        trprobationdate.Visible = false;
                        trduptstart.Visible = false;
                        trduptenddate.Visible = false;
                        RFV_probation_date.Enabled = false;
                        RFV_probationperiod.Enabled = false;
                        RFV_deput_start_date.Enabled = false;
                        RFV_deput_end_date.Enabled = false;
                        trprobationdate2.Visible = false;
                        trprobationdate3.Visible = false;
                        REg_probation_date.Enabled = false;
                        REg_probationdate2.Enabled = false;
                        trDOL.Visible = false;
                        trReasonL.Visible = false;

                    }
            if (ds.Tables[0].Rows[0]["confirmationdate"].ToString() == "")
            {
                txt_confirmationdate.Text = "";
            }
            else
            {
                txt_confirmationdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["confirmationdate"]).ToString("dd-MMM-yyyy");
            }
            if ((ds.Tables[0].Rows[0]["noticeperiod"].ToString() == "0") || (ds.Tables[0].Rows[0]["noticeperiod"].ToString() == ""))
            {
                txt_noticePeriod.Text = "";
            }
            else
            {
                txt_noticePeriod.Text = ds.Tables[0].Rows[0]["noticeperiod"].ToString();
            }
            txtoff_mobileno.Text = ds.Tables[0].Rows[0]["official_mob_no"].ToString();
            txt_officialemail.Text = ds.Tables[0].Rows[0]["official_email_id"].ToString();
            //if ((ds.Tables[0].Rows[0]["subgroupid"].ToString() == "0") || (ds.Tables[0].Rows[0]["subgroupid"].ToString() == "") || (ds.Tables[0].Rows[0]["subgroupid"] == null))
            //{
            //    ddl_subgroup.SelectedValue = "0";
            //}
            //else
            //{
            //    ddl_subgroup.SelectedValue = ds.Tables[0].Rows[0]["subgroupid"].ToString();
            //}
            if ((ds.Tables[0].Rows[0]["broadgroupid"].ToString() == "0") || (ds.Tables[0].Rows[0]["broadgroupid"].ToString() == "") || (ds.Tables[0].Rows[0]["broadgroupid"] == null))
            {
                ddl_broadgroup.SelectedValue = "0";
            }
            else
            {
                ddl_broadgroup.SelectedValue = ds.Tables[0].Rows[0]["broadgroupid"].ToString();
            }
            //if ((ds.Tables[0].Rows[0]["entityid"].ToString() == "0") || (ds.Tables[0].Rows[0]["entityid"].ToString() == "") || (ds.Tables[0].Rows[0]["entityid"] == null))
            //{
            //    ddl_entity.SelectedValue = "0";
            //}
            //else
            //{
            //    ddl_entity.SelectedValue = ds.Tables[0].Rows[0]["entityid"].ToString();
            //}

            ddl_gradetype.SelectedValue = ds.Tables[0].Rows[0]["gradetype"].ToString();
            //bind_grade();
            if ((ds.Tables[0].Rows[0]["Grade"].ToString() != "0") && (ds.Tables[0].Rows[0]["Grade"].ToString() != ""))
            {
                drpgrade.SelectedValue = ds.Tables[0].Rows[0]["Grade"].ToString();
            }
            ddl_supervisor.SelectedValue = ds.Tables[0].Rows[0]["supervisorcode"].ToString();
            ddl_hod.SelectedValue = ds.Tables[0].Rows[0]["hodcode"].ToString();
            ddl_corp_report_name.SelectedValue = ds.Tables[0].Rows[0]["corporatereportingcode"].ToString();


            if ((ds.Tables[0].Rows[0]["cost_center_group_id"] == null) || (ds.Tables[0].Rows[0]["cost_center_group_id"].ToString() == "0") || (ds.Tables[0].Rows[0]["cost_center_group_id"].ToString() == ""))
            {
                ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_country.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_state.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_city.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_cc_location.Items.Insert(0, new ListItem("--Select--", "0"));

            }
            else
            {
                ddl_cc_groupid.SelectedValue = ds.Tables[0].Rows[0]["cost_center_group_id"].ToString();
                if ((ds.Tables[0].Rows[0]["cost_center_code"] == null) || (ds.Tables[0].Rows[0]["cost_center_code"].ToString() == "0") || (ds.Tables[0].Rows[0]["cost_center_code"].ToString() == ""))
                {
                    trcc.Visible = false;
                }
                else
                {
                    bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));
                    ddl_cc_code.SelectedValue = ds.Tables[0].Rows[0]["cost_center_code"].ToString();
                    bind_cc(Convert.ToInt32(ds.Tables[0].Rows[0]["cost_center_code"]));
                    trcc.Visible = true;
                    //bind_cc_country(Convert.ToInt32(ds.Tables[0].Rows[0]["cost_center_code"]));
                    //ddl_cc_country.SelectedValue = ds.Tables[0].Rows[0]["country"].ToString();
                    //ddl_cc_state.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
                    //ddl_cc_city.SelectedValue = ds.Tables[0].Rows[0]["city"].ToString();
                    //ddl_cc_location.SelectedValue = ds.Tables[0].Rows[0]["location"].ToString();
                }
            }

            if ((ds.Tables[0].Rows[0]["add_cost_center_group_id"] == null) || (ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString() == ""))
            {
                ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_country.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_state.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_city.Items.Insert(0, new ListItem("--Select--", "0"));
                //ddl_acc_location.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddl_acc_groupid.SelectedValue = ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString();
                if ((ds.Tables[0].Rows[0]["add_cost_center_code"] == null) || (ds.Tables[0].Rows[0]["add_cost_center_code"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_cost_center_code"].ToString() == ""))
                {
                    traddcc.Visible = false;
                }
                else
                {
                    bind_ddl_acc_code(Convert.ToInt32(ddl_acc_groupid.SelectedValue));
                    ddl_acc_code.SelectedValue = ds.Tables[0].Rows[0]["add_cost_center_code"].ToString();
                    bind_acc(Convert.ToInt32(ds.Tables[0].Rows[0]["add_cost_center_code"]));
                    traddcc.Visible = true;
                    //bind_acc_country(Convert.ToInt32(ds.Tables[0].Rows[0]["add_cost_center_code"]));
                    //ddl_acc_country.SelectedValue = ds.Tables[0].Rows[0]["add_country"].ToString();
                    //ddl_acc_state.SelectedValue = ds.Tables[0].Rows[0]["add_state"].ToString();
                    //ddl_acc_city.SelectedValue = ds.Tables[0].Rows[0]["add_city"].ToString();
                    //ddl_acc_location.SelectedValue = ds.Tables[0].Rows[0]["add_location"].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' ";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartment.DataTextField = "department_name";
            drpdepartment.DataValueField = "departmentid";
            drpdepartment.DataSource = ds1;
            drpdepartment.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    //------------Bind Payroll Details of Employee-----------------
    protected void bind_payrolldetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "SELECT empcode,esi_no,esi_disp,pf_no,pf_no_dept,pan_no,ward,ptno FROM tbl_intranet_employee_payrollDetails  WHERE empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
            esidesp.Text = ds.Tables[0].Rows[0]["esi_disp"].ToString();
            pfno.Text = ds.Tables[0].Rows[0]["pf_no"].ToString();
            pfno_dept.Text = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();
            panno.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
            ward.Text = ds.Tables[0].Rows[0]["ward"].ToString();
            txt_ptno.Text = ds.Tables[0].Rows[0]["ptno"].ToString();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_contactdetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "SELECT pre_add1, pre_Add2, pre_city, pre_state, pre_country, pre_zip, pre_phone, per_add1, per_add2, per_city, per_state, per_country, per_zip, per_phone, empcode,mode,modeoftransport,emergency_contact_no,emergency_name,emergency_relation,emergency_address1,emergency_address2,emergency_city,emergency_state,emergency_country,emergency_zip FROM tbl_intranet_employee_contactlist where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
            {
                ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                txt_pre_add1.Text = ds.Tables[0].Rows[0]["pre_add1"].ToString();
                txt_pre_Add2.Text = ds.Tables[0].Rows[0]["pre_Add2"].ToString();
                if ((ds.Tables[0].Rows[0]["pre_country"] == null) || (ds.Tables[0].Rows[0]["pre_country"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_country"].ToString() == "0"))
                {

                }
                else
                {
                    ddl_pre_country.SelectedValue = ds.Tables[0].Rows[0]["pre_country"].ToString();
                    bind_pre_state(ddl_pre_country.SelectedValue);

                    if ((ds.Tables[0].Rows[0]["pre_state"] == null) || (ds.Tables[0].Rows[0]["pre_state"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_state"].ToString() == "0"))
                    {
                        ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddl_pre_state.SelectedValue = ds.Tables[0].Rows[0]["pre_state"].ToString();
                        bind_pre_city(Convert.ToInt32(ddl_pre_state.SelectedValue));
                    }
                    if ((ds.Tables[0].Rows[0]["pre_city"] == null) || (ds.Tables[0].Rows[0]["pre_city"].ToString() == "") || (ds.Tables[0].Rows[0]["pre_city"].ToString() == "0"))
                    {
                        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddl_pre_city.SelectedValue = ds.Tables[0].Rows[0]["pre_city"].ToString();
                    }
                }
                txt_pre_zip.Text = ds.Tables[0].Rows[0]["pre_zip"].ToString();
                txt_pre_phone.Text = ds.Tables[0].Rows[0]["pre_phone"].ToString();
                txt_per_add1.Text = ds.Tables[0].Rows[0]["per_add1"].ToString();
                txt_per_add2.Text = ds.Tables[0].Rows[0]["per_add2"].ToString();
                if ((ds.Tables[0].Rows[0]["per_country"] == null) || (ds.Tables[0].Rows[0]["per_country"].ToString() == "") || (ds.Tables[0].Rows[0]["per_country"].ToString() == "0"))
                {
                    ddl_per_country.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_per_country.SelectedValue = ds.Tables[0].Rows[0]["per_country"].ToString();
                    bind_per_state(ddl_per_country.SelectedValue);

                }
                if ((ds.Tables[0].Rows[0]["per_state"] == null) || (ds.Tables[0].Rows[0]["per_state"].ToString() == "") || (ds.Tables[0].Rows[0]["per_state"].ToString() == "0"))
                {
                    ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_per_state.SelectedValue = ds.Tables[0].Rows[0]["per_state"].ToString();
                    bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
                }

                if ((ds.Tables[0].Rows[0]["per_city"] == null) || (ds.Tables[0].Rows[0]["per_city"].ToString() == "") || (ds.Tables[0].Rows[0]["per_city"].ToString() == "0"))
                {
                    ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_per_city.SelectedValue = ds.Tables[0].Rows[0]["per_city"].ToString();
                }
                txt_per_zip.Text = ds.Tables[0].Rows[0]["per_zip"].ToString();
                txt_per_phone.Text = ds.Tables[0].Rows[0]["per_phone"].ToString();

                if (ds.Tables[0].Rows[0]["mode"].ToString() == "1")
                {
                    optcompany.Checked = true;
                    txtmodeoftransport.Text = ds.Tables[0].Rows[0]["modeoftransport"].ToString();
                    txtmodeoftransport.Visible = true;
                }
                else
                {
                    optown.Checked = true;
                    txtmodeoftransport.Text = "";
                    txtmodeoftransport.Visible = false;
                }
                txt_emergency_contactno.Text = ds.Tables[0].Rows[0]["emergency_contact_no"].ToString();
                txt_emergency_name.Text = ds.Tables[0].Rows[0]["emergency_name"].ToString();
                txt_emergency_relation.Text = ds.Tables[0].Rows[0]["emergency_relation"].ToString();
                txt_emergency_address.Text = ds.Tables[0].Rows[0]["emergency_address1"].ToString();
                txt_emergency_address2.Text = ds.Tables[0].Rows[0]["emergency_address2"].ToString();
                if ((ds.Tables[0].Rows[0]["emergency_country"] == null) || (ds.Tables[0].Rows[0]["emergency_country"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_country"].ToString() == "0"))
                {
                }
                else
                {
                    ddl_emergency_country.SelectedValue = ds.Tables[0].Rows[0]["emergency_country"].ToString();
                    bind_Emergency_state(ddl_emergency_country.SelectedValue);
                }
                if (ds.Tables[0].Rows[0]["emergency_state"].ToString() != "")
                {

                    if ((ds.Tables[0].Rows[0]["emergency_state"] == null) || (ds.Tables[0].Rows[0]["emergency_state"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_state"].ToString() == "0"))
                    {
                        ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
                    }
                    else
                    {
                        ddl_emergency_state.SelectedValue = ds.Tables[0].Rows[0]["emergency_state"].ToString();
                        bind_Emergency_city(Convert.ToInt32(ddl_emergency_state.SelectedValue));
                    }
                }
                if ((ds.Tables[0].Rows[0]["emergency_city"] == null) || (ds.Tables[0].Rows[0]["emergency_city"].ToString() == "") || (ds.Tables[0].Rows[0]["emergency_city"].ToString() == "0"))
                {
                    ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
                }
                else
                {
                    ddl_emergency_city.SelectedValue = ds.Tables[0].Rows[0]["emergency_city"].ToString();
                }
                txt_emergency_zipcode.Text = ds.Tables[0].Rows[0]["emergency_zip"].ToString();

            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_personalinfo(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,bankbranch,ifsc,passportissuedate,passportexpiraydate,(CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dob, 101) END) dob, (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), doa, 101) END) doa, dlno, s_fname, s_mname, s_lname,(CASE WHEN s_dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), s_dob, 101) END) s_dob, s_gender, no_child, mobile_no, email_id,bank_name,ac_number,passport_number,paymentmode,bank_name_reimbursement,ac_number_reimbursement FROM tbl_intranet_employee_personalDetails where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count < 1)
                return;
            // created by ramu i am not creating any columns in db.i just add to empfathermiddlename and empfatherlastname why because we not using these col's. 
            ddl_ShirtSize.SelectedValue = ds.Tables[0].Rows[0]["f_lname"].ToString();
            ddl_Tshirt.SelectedValue = ds.Tables[0].Rows[0]["f_mname"].ToString();
            txt_f_mname.Text = "";
            txt_f_l_name.Text = "";
            //---- end 
            txt_f_f_name.Text = ds.Tables[0].Rows[0]["f_fname"].ToString();

            txt_m_fname.Text = ds.Tables[0].Rows[0]["m_fname"].ToString();
            txt_m_l_name.Text = ds.Tables[0].Rows[0]["m_lname"].ToString();
            txt_m_mname.Text = ds.Tables[0].Rows[0]["m_mname"].ToString();
            ddlbloodgrp.SelectedValue = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
            ddlpersonalstatus.SelectedValue = ds.Tables[0].Rows[0]["maritalstatus"].ToString();
            txtrelg.Text = ds.Tables[0].Rows[0]["religion"].ToString();
            if (ds.Tables[0].Rows[0]["doa"].ToString() != "")
                txt_doa.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["doa"].ToString()).ToString("dd-MMM-yyyy");
            else txt_doa.Text = "";
            txt_dl_no.Text = ds.Tables[0].Rows[0]["dlno"].ToString();
            txt_sp_fname.Text = ds.Tables[0].Rows[0]["s_fname"].ToString();
            txt_sp_mname.Text = ds.Tables[0].Rows[0]["s_mname"].ToString();
            txt_sp_lname.Text = ds.Tables[0].Rows[0]["s_lname"].ToString();
            if (ds.Tables[0].Rows[0]["s_dob"].ToString() != "")
                txt_s_DOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["s_dob"].ToString()).ToString("dd-MMM-yyyy");
            else txt_s_DOB.Text = "";
            ddl_s_gender.SelectedValue = ds.Tables[0].Rows[0]["s_gender"].ToString();
            if (ds.Tables[0].Rows[0]["dob"].ToString() != "")
                txt_DOB.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["dob"].ToString()).ToString("dd-MMM-yyyy");
            else txt_DOB.Text = "";
            txtmobileno.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            txt_email.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
            //txt_bank_name.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
            //txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
            txt_passportno.Text = ds.Tables[0].Rows[0]["passport_number"].ToString();
            if (ddlpersonalstatus.SelectedValue.ToString() == "Married")
            {
                tbl1.Visible = true;
            }
            if ((ddlpersonalstatus.SelectedValue.ToString() == "Unmarried") || (ddlpersonalstatus.SelectedValue == "0"))
            {
                tbl1.Visible = false;
            }

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["paymentmode"]) == 0)
            {
                rbtnbank.Checked = true;
                rbtncheque.Checked = false;
                rbtncash.Checked = false;

                paymentmode.Visible = true;

                if ((ds.Tables[0].Rows[0]["bank_name"].ToString() != "") && (ds.Tables[0].Rows[0]["bank_name"].ToString() != "0"))
                {
                    ddl_bank_name.SelectedValue = ds.Tables[0].Rows[0]["bank_name"].ToString();
                }
                txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();

                ddl_bank_name_reimbursement.SelectedValue = ds.Tables[0].Rows[0]["bank_name_reimbursement"].ToString();
                txt_bank_ac_reimbursement.Text = ds.Tables[0].Rows[0]["ac_number_reimbursement"].ToString();
            }
            else
            {
                if (Convert.ToInt32(ds.Tables[0].Rows[0]["paymentmode"]) == 1)
                {
                    rbtnbank.Checked = false;
                    rbtncheque.Checked = true;
                    rbtncash.Checked = false;
                    paymentmode.Visible = false;
                }
                else
                {
                    rbtnbank.Checked = false;
                    rbtncheque.Checked = false;
                    rbtncash.Checked = true;
                    paymentmode.Visible = false;
                }
            }

            txt_bankbrachname.Text = ds.Tables[0].Rows[0]["bankbranch"].ToString();
            txt_ifsc.Text = ds.Tables[0].Rows[0]["ifsc"].ToString();
            if (ds.Tables[0].Rows[0]["passportissuedate"].ToString() == "")
            {
                txt_passportissueddate.Text = "";
            }
            else
            {
                txt_passportissueddate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportissuedate"]).ToString("dd-MMM-yyyy");
            }
            if (ds.Tables[0].Rows[0]["passportexpiraydate"].ToString() == "")
            {
                txt_passportexpdate.Text = "";
            }
            else
            {
                txt_passportexpdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportexpiraydate"]).ToString("dd-MMM-yyyy");
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_child(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select id,child_name,gender ,(CASE WHEN childdob='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), childdob, 101) END)child_dob from tbl_intranet_employee_childrendetail where empcode ='" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["acc_education"] == null)
            {
                create_child_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["child"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();


                dr["child_name"] = ds.Tables[0].Rows[i]["child_name"].ToString();
                dr["child_dob"] = ds.Tables[0].Rows[i]["child_dob"].ToString();
                dr["gender"] = ds.Tables[0].Rows[i]["gender"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["child"] = dtable;
            BindList_child();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void bind_Professional_Qualification(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  FROM tbl_employee_professionalqualifications where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);


            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (Session["Pro_education"] == null)
            {
                create_Pro_edu_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["Pro_education"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["education"] = ds.Tables[0].Rows[i]["education"].ToString();
                dr["school"] = ds.Tables[0].Rows[i]["school"].ToString();
                dr["percentage"] = ds.Tables[0].Rows[i]["percentage"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();
                dr["specialization"] = ds.Tables[0].Rows[i]["specialization"].ToString();

                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["Pro_education"] = dtable;
            BindList_pro_edu();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    //
    protected void bind_Exp_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT [id],empcode,[companyname]as comp_name,[location]as location ,[totalexperience] as total_exp ,[yearfrom] as from_year,[yearto]as to_year,designation FROM tbl_employee_experiencedetails where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["exp"] == null)
            {
                create_exp_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["exp"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["comp_name"] = ds.Tables[0].Rows[i]["comp_name"].ToString();
                dr["location"] = ds.Tables[0].Rows[i]["location"].ToString();
                dr["total_exp"] = ds.Tables[0].Rows[i]["total_exp"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();
                dr["designation"] = ds.Tables[0].Rows[i]["designation"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";

                dtable.Rows.Add(dr);
            }
            Session["exp"] = dtable;
            BindList_exp();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }


    //-----------------------------------------Bind Training Details-------------------------------------
    protected void bind_Training_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "SELECT trainingname,personname,(CASE WHEN fromdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), fromdate, 101) END)fromdate,(CASE WHEN todate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), todate, 101) END)todate,remarks  FROM tbl_intranet_employee_trainingdetail where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["training"] == null)
            {
                create_Training_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["training"];
            dtable.Clear();
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();
                dr["trainingname"] = ds.Tables[0].Rows[i]["trainingname"].ToString();
                dr["personname"] = ds.Tables[0].Rows[i]["personname"].ToString();
                dr["fromdate"] = ds.Tables[0].Rows[i]["fromdate"].ToString();
                dr["todate"] = ds.Tables[0].Rows[i]["todate"].ToString();
                dr["remarks"] = ds.Tables[0].Rows[i]["remarks"].ToString();
                dtable.Rows.Add(dr);
            }
            Session["training"] = dtable;
            BindList_Training();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    //-------------------------------------------End------------------------------------------------------

    //------------------------------------- Bind Education Qualifications-------------------------------
    protected void bind_Education_Qualification(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  FROM tbl_employee_edcationalqualifications  where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            if (Session["acc_education"] == null)
            {
                create_acc_edu_table();
            }
            DataRow dr;
            DataTable dtable;

            dtable = (DataTable)Session["acc_education"];
            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();

                dr["education"] = ds.Tables[0].Rows[i]["education"].ToString();
                dr["school"] = ds.Tables[0].Rows[i]["school"].ToString();
                dr["percentage"] = ds.Tables[0].Rows[i]["percentage"].ToString();
                dr["from_year"] = ds.Tables[0].Rows[i]["from_year"].ToString();
                dr["to_year"] = ds.Tables[0].Rows[i]["to_year"].ToString();
                dr["specialization"] = ds.Tables[0].Rows[i]["specialization"].ToString();


                //  dr["aleaveid"] = (ds.Tables[1].Rows[i]["adjust_leave"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["adjust_leave"].ToString()) : 0;
                //  dr["aleavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";



                dtable.Rows.Add(dr);
            }
            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    //--------------------------------------------------------------------------------------------------


    //--------------------insert the job detail and login details -----------------------


    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            string file_name = "";

            //if (Page.IsValid)
            //{
            if (f_upload_rep1.GotFile)
            {
                file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
                f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/photo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
                file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

                ViewState.Add("Photo", file_name);

            }
            else
                ViewState.Add("Photo", file_name);
            //}
            //else
            //    ViewState.Add("Photo", file_name);

            string emp_code = Session["empcode"].ToString();
            transaction = connection.BeginTransaction();
            edit_Job_detail(emp_code, connection, transaction);
            edit_login_role(emp_code, connection, transaction);
            //  insert_Log_in_detail();
            Session.Add("Inserted_Emp_code", txtempcode.Text);

            Edit_Educational_Qualification(emp_code, connection, transaction);
            edit_Professional_Qualification(emp_code, connection, transaction);
            edit_Expriece_detail(emp_code, connection, transaction);
            edit_personal_detail(emp_code, connection, transaction);
            edit_Children_detail(emp_code, connection, transaction);
            edit_contact_detail(emp_code, connection, transaction);
            edit_payroll_detail(emp_code, connection, transaction);
            edit_emp_documents(emp_code, connection, transaction);
            edit_Training_details(emp_code, connection, transaction);
            resetcontact();
            resetPersonalDetails();
            reset_professional_detail();
            resetjobdetails();
            BindTempLoginDetails(emp_code, connection, transaction);
            transaction.Commit();
            //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
            string str = "<script> alert('Employee Detail has sucessfully Updated')</script>";
            Page.RegisterStartupScript("Employee", str.ToString());
            div.Visible = false;
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }


        // Response.Redirect("empview.aspx?updated=true");
    }
    protected void edit_Job_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[46];
        sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.NChar, 20);
        sqlparam[0].Value = emp_code;

        sqlparam[1] = new SqlParameter("@card_no", SqlDbType.VarChar, 100);
        sqlparam[1].Value = txt_card_no.Text;

        sqlparam[2] = new SqlParameter("@emp_gender", SqlDbType.VarChar, 10);
        sqlparam[2].Value = drpgender.SelectedItem.ToString();

        sqlparam[3] = new SqlParameter("@emp_fname", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txtfirstname.Text;

        sqlparam[4] = new SqlParameter("@emp_m_name", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txtmiddlename.Text;

        sqlparam[5] = new SqlParameter("@emp_l_name", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txtlastname.Text;

        sqlparam[6] = new SqlParameter("@emp_status", SqlDbType.Int);
        if (((drpempstatus.SelectedValue == "0") || (drpempstatus.SelectedValue == " ") || (drpempstatus.SelectedValue == null)))
        {
            sqlparam[6].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else sqlparam[6].Value = drpempstatus.SelectedValue;

        sqlparam[7] = new SqlParameter("@dept_id", SqlDbType.Int);
        if ((drpdepartment.SelectedValue == "0") || (drpdepartment.SelectedValue == " ") || (drpdepartment.SelectedValue == null))
            sqlparam[7].Value = System.Data.SqlTypes.SqlInt32.Null;
        else sqlparam[7].Value = drpdepartment.SelectedValue;// drpdepartment.SelectedValue;

        sqlparam[8] = new SqlParameter("@division_id", SqlDbType.Int);
        if ((drpdivision.SelectedValue == "0") || (drpdivision.SelectedValue == " ") || (drpdivision.SelectedValue == null))
            sqlparam[8].Value = System.Data.SqlTypes.SqlInt32.Null;
        else sqlparam[8].Value = drpdivision.SelectedValue;// drpdivision.SelectedValue;

        sqlparam[9] = new SqlParameter("@degination_id", SqlDbType.Int);
        if ((drpdegination.SelectedValue == "0") || (drpdegination.SelectedValue == " ") || (drpdegination.SelectedValue == null))
            sqlparam[9].Value = System.Data.SqlTypes.SqlInt32.Null;
        else
            sqlparam[9].Value = drpdegination.SelectedValue;

        sqlparam[10] = new SqlParameter("@Grade", SqlDbType.Int);
        if ((drpgrade.SelectedValue == "0") || (drpgrade.SelectedValue == " ") || (drpgrade.SelectedValue == null))
            sqlparam[10].Value = System.Data.SqlTypes.SqlInt32.Null;
        else sqlparam[10].Value = drpgrade.SelectedValue; //drpgrade.SelectedValue;

        sqlparam[11] = new SqlParameter("@branch_id", SqlDbType.Int);
        if ((drpbranch.SelectedValue == "0") || (drpbranch.SelectedValue == " ") || (drpbranch.SelectedValue == null))
            sqlparam[11].Value = System.Data.SqlTypes.SqlInt32.Null;
        else sqlparam[11].Value = drpbranch.SelectedValue;// drpbranch.SelectedValue;

        sqlparam[12] = new SqlParameter("@emp_doj", SqlDbType.DateTime);
        if (doj.Text == "")
            sqlparam[12].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[12].Value = doj.Text;//Utility.dataformat(doj.Text);

        sqlparam[13] = new SqlParameter("@ext_number", SqlDbType.VarChar, 50);
        sqlparam[13].Value = txtext.Text;

        sqlparam[14] = new SqlParameter("@photo", SqlDbType.VarChar, 100);
        sqlparam[14].Value = ViewState["Photo"].ToString();

        sqlparam[15] = new SqlParameter("@salary_cal_from", SqlDbType.DateTime);
        if (txtsalary.Text == "")
            sqlparam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[15].Value = txtsalary.Text;// Utility.dataformat(txtsalary.Text);

        sqlparam[16] = new SqlParameter("@emp_doleaving", SqlDbType.DateTime);
        if (txtdol.Text == "")
            sqlparam[16].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[16].Value = txtdol.Text;// Utility.dataformat(txtdol.Text);

        sqlparam[17] = new SqlParameter("@reason_leaving", SqlDbType.VarChar, 200);
        sqlparam[17].Value = txtreason.Text;


        sqlparam[18] = new SqlParameter("@salutation", SqlDbType.VarChar, 3);
        sqlparam[18].Value = ddlSalutation.SelectedValue;


        sqlparam[19] = new SqlParameter("@probationperiod", SqlDbType.Int);
        sqlparam[20] = new SqlParameter("@probationenddate", SqlDbType.Int);
        if (drpempstatus.SelectedItem.Text == "Probation")
        {
            sqlparam[19].Value = Convert.ToInt32(txt_probationperiod.Text);
            sqlparam[20].Value = txt_probation_date.Text;
        }
        else
        {
            sqlparam[19].Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlparam[20].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }


        sqlparam[21] = new SqlParameter("@deputationstartdate", SqlDbType.DateTime);
        sqlparam[22] = new SqlParameter("@deputationenddate", SqlDbType.DateTime);
        if (drpempstatus.SelectedItem.Text == "Contractual")
        {
            sqlparam[21].Value = txt_deput_start_date.Text;
            sqlparam[22].Value = txt_deput_end_date.Text;
        }
        else
        {
            sqlparam[21].Value = System.Data.SqlTypes.SqlDateTime.Null;
            sqlparam[22].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }

        sqlparam[23] = new SqlParameter("@subgroupid", SqlDbType.Int);
        //if ((ddl_subgroup.SelectedValue == "0") || (ddl_subgroup.SelectedValue == ""))
        //{
        sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
        //}
        //else
        //{
        //    sqlparam[23].Value = ddl_subgroup.SelectedValue;
        //}

        sqlparam[24] = new SqlParameter("@broadgroupid", SqlDbType.Int);
        if ((ddl_broadgroup.SelectedValue == "0") || (ddl_broadgroup.SelectedValue == ""))
        {
            sqlparam[24].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[24].Value = ddl_broadgroup.SelectedValue;
        }

        sqlparam[25] = new SqlParameter("@entityid", SqlDbType.Int);
        //if ((ddl_entity.SelectedValue == "0") || (ddl_entity.SelectedValue == ""))
        //{
        sqlparam[25].Value = System.Data.SqlTypes.SqlInt32.Null;
        //}
        //else
        //{
        //    sqlparam[25].Value = ddl_entity.SelectedValue;
        //}

        sqlparam[26] = new SqlParameter("@gradetype", SqlDbType.VarChar, 1);
        if ((ddl_gradetype.SelectedValue == "0") || (ddl_gradetype.SelectedValue == ""))
        {
            sqlparam[26].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[26].Value = ddl_gradetype.SelectedValue;
        }
        sqlparam[27] = new SqlParameter("@official_mob_no", SqlDbType.VarChar, 50);
        sqlparam[27].Value = txtoff_mobileno.Text;

        sqlparam[28] = new SqlParameter("@official_email_id", SqlDbType.VarChar, 50);
        sqlparam[28].Value = txt_officialemail.Text;

        sqlparam[29] = new SqlParameter("@supervisorcode", SqlDbType.VarChar, 50);
        if ((ddl_supervisor.SelectedValue == "0") || (ddl_supervisor.SelectedValue == ""))
        {
            sqlparam[29].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[29].Value = ddl_supervisor.SelectedValue;
        }

        sqlparam[30] = new SqlParameter("@hodcode", SqlDbType.VarChar, 50);
        if ((ddl_hod.SelectedValue == "0") || (ddl_hod.SelectedValue == ""))
        {
            sqlparam[30].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[30].Value = ddl_hod.SelectedValue;
        }

        sqlparam[31] = new SqlParameter("@corporatereportingcode", SqlDbType.VarChar, 50);
        if ((ddl_corp_report_name.SelectedValue == "0") || (ddl_corp_report_name.SelectedValue == ""))
        {
            sqlparam[31].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[31].Value = ddl_corp_report_name.SelectedValue;
        }

        sqlparam[32] = new SqlParameter("@cost_center_group_id", SqlDbType.Int);
        if ((ddl_cc_groupid.SelectedValue == "0") || (ddl_cc_groupid.SelectedValue == ""))
        {
            sqlparam[32].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[32].Value = Convert.ToInt32(ddl_cc_groupid.SelectedValue);
        }
        sqlparam[33] = new SqlParameter("@cost_center_code", SqlDbType.Int);
        if ((ddl_cc_code.SelectedValue == "0") || (ddl_cc_code.SelectedValue == ""))
        {
            sqlparam[33].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[33].Value = Convert.ToInt32(ddl_cc_code.SelectedValue);
        }

        sqlparam[34] = new SqlParameter("@country", SqlDbType.Int);
        if ((hf_ccountry.Value == "0") || (hf_ccountry.Value == ""))
        {
            sqlparam[34].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[34].Value = Convert.ToInt32(hf_ccountry.Value);
        }

        sqlparam[35] = new SqlParameter("@state", SqlDbType.Int);
        if ((hf_cstate.Value == "0") || (hf_cstate.Value == ""))
        {
            sqlparam[35].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[35].Value = Convert.ToInt32(hf_cstate.Value);
        }
        sqlparam[36] = new SqlParameter("@city", SqlDbType.Int);
        if ((hf_ccity.Value == "0") || (hf_ccity.Value == ""))
        {
            sqlparam[36].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[36].Value = Convert.ToInt32(hf_ccity.Value);
        }

        sqlparam[37] = new SqlParameter("@location", SqlDbType.VarChar, 100);
        if ((lbl_cc_location.Text == "0") || (lbl_cc_location.Text == ""))
        {
            sqlparam[37].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[37].Value = lbl_cc_location.Text;
        }

        sqlparam[38] = new SqlParameter("@add_cost_center_group_id", SqlDbType.Int);
        if ((ddl_acc_groupid.SelectedValue == "0") || (ddl_acc_groupid.SelectedValue == ""))
        {
            sqlparam[38].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[38].Value = Convert.ToInt32(ddl_acc_groupid.SelectedValue);
        }
        sqlparam[39] = new SqlParameter("@add_cost_center_code", SqlDbType.Int);
        if ((ddl_acc_code.SelectedValue == "0") || (ddl_acc_code.SelectedValue == ""))
        {
            sqlparam[39].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[39].Value = Convert.ToInt32(ddl_acc_code.SelectedValue);
        }
        sqlparam[40] = new SqlParameter("@add_country", SqlDbType.Int);
        if ((hf_accountry.Value == "0") || (hf_accountry.Value == ""))
        {
            sqlparam[40].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[40].Value = Convert.ToInt32(hf_accountry.Value);
        }

        sqlparam[41] = new SqlParameter("@add_state", SqlDbType.Int);
        if ((hf_acstate.Value == "0") || (hf_acstate.Value == ""))
        {
            sqlparam[41].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[41].Value = Convert.ToInt32(hf_acstate.Value);
        }

        sqlparam[42] = new SqlParameter("@add_city", SqlDbType.Int);
        if ((hf_accity.Value == "0") || (hf_accity.Value == ""))
        {
            sqlparam[42].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[42].Value = Convert.ToInt32(hf_accity.Value);
        }

        sqlparam[43] = new SqlParameter("@add_location", SqlDbType.VarChar, 100);
        if ((lbl_acc_location.Text == "0") || (lbl_acc_location.Text == ""))
        {
            sqlparam[43].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[43].Value = lbl_acc_location.Text;
        }

        sqlparam[44] = new SqlParameter("@confirmationdate", SqlDbType.DateTime);
        if (txt_confirmationdate.Text == "")
        {
            sqlparam[44].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlparam[44].Value = txt_confirmationdate.Text;
        }

        sqlparam[45] = new SqlParameter("@noticeperiod", SqlDbType.Int);
        if (txt_noticePeriod.Text == "")
        {
            sqlparam[45].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[45].Value = Convert.ToInt32(txt_noticePeriod.Text);
        }
        int i = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_intranet_edit_jobdetails_for_temp", sqlparam);

    }

    protected void edit_login_role(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.NChar, 20);
        sqlparam[0].Value = emp_code;

        sqlparam[1] = new SqlParameter("@role", SqlDbType.TinyInt);
        sqlparam[1].Value = drprole.SelectedValue;

        string sqlstr = "UPDATE tbl_login SET role=@role WHERE empcode=@emp_code";
        int i=SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparam);
    }



    protected void edit_payroll_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[8];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        sqlparam[1] = new SqlParameter("@esi_no", SqlDbType.VarChar, 50);
        sqlparam[1].Value = esino.Text;

        sqlparam[2] = new SqlParameter("@esi_disp", SqlDbType.VarChar, 100);
        sqlparam[2].Value = esidesp.Text;

        sqlparam[3] = new SqlParameter("@pf_no", SqlDbType.VarChar, 50);
        sqlparam[3].Value = pfno.Text;

        sqlparam[4] = new SqlParameter("@pf_no_dept", SqlDbType.VarChar, 50);
        sqlparam[4].Value = pfno_dept.Text;

        sqlparam[5] = new SqlParameter("@pan_no", SqlDbType.VarChar, 50);
        sqlparam[5].Value = panno.Text;

        sqlparam[6] = new SqlParameter("@ward", SqlDbType.VarChar, 100);
        sqlparam[6].Value = ward.Text;

        sqlparam[7] = new SqlParameter("@ptno", SqlDbType.VarChar, 50);
        sqlparam[7].Value = txt_ptno.Text.Trim().ToString();

        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_edit_payrolldetails", sqlparam);
    }


    private void BindTempLoginDetails(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {

        if (hdnstatus.Value == "0")
        {
            sqlstr = @"insert into dbo.tbl_intranet_employee_templogin_details(empcode,createdby,createddate,status) values('" + emp_code + "','" + emp_code + "',getdate(),1)";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        }
        else if (hdnstatus.Value == "2")
        {
            sqlstr = @"update tbl_intranet_employee_templogin_details set status=1 where empcode='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        }
    }



    //=========================================================================================================================================
    protected void resetcontact()
    {
        txt_pre_add1.Text = "";
        txt_pre_Add2.Text = "";

        //ddl_pre_city.SelectedValue = "0";
        //ddl_pre_state.SelectedValue = "0";
        //ddl_pre_country.SelectedValue = "0";
        txt_pre_zip.Text = "";
        txt_pre_phone.Text = "";
        txt_per_add1.Text = "";
        txt_per_add2.Text = "";
        //ddl_per_city.SelectedValue = "0";
        //ddl_per_state.SelectedValue = "0";
        //ddl_per_country.SelectedValue = "0";
        txt_per_zip.Text = "";
        txt_per_phone.Text = "";

    }

    //===================================================================================================================================


    //=====================================================================================================================================
    protected void resetPersonalDetails()
    {

        txt_DOB.Text = "";
        txt_passportno.Text = "";
        txt_dl_no.Text = "";
        txt_email.Text = "";
        //txt_bank_name.Text = "";
        txt_bank_ac.Text = "";
        ddlbloodgrp.SelectedValue = "0";
        txtrelg.Text = "";
        txtmobileno.Text = "";
        txt_f_f_name.Text = "";
        txt_f_mname.Text = "";
        txt_f_l_name.Text = "";
        txt_m_fname.Text = "";
        txt_m_mname.Text = "";
        txt_m_l_name.Text = "";
        ddlpersonalstatus.SelectedValue = "0";
        tbl1.Visible = false;
        txt_s_DOB.Text = "";
        ddl_s_gender.SelectedValue = "0";
        txt_sp_fname.Text = "";
        txt_sp_mname.Text = "";
        txt_doa.Text = "";
        txt_sp_lname.Text = "";
        txt_child_name.Text = "";
        txt_child_Dob.Text = "";
        Session.Remove("Child");
        grid_child.DataSource = "";
        grid_child.DataBind();
    }

    protected void resetjobdetails()
    {
        txt_card_no.Text = "";

        drpgender.SelectedValue = "0";
        txtfirstname.Text = "";
        txtmiddlename.Text = "";
        txtlastname.Text = "";
        drpempstatus.SelectedValue = "0";
        drprole.SelectedValue = "0";
        drpbranch.SelectedValue = "0";
        drpdivision.SelectedValue = "0";
        drpdegination.SelectedValue = "0";
        ddl_broadgroup.SelectedValue = "0";
        drpgrade.SelectedValue = "0";
        ddl_gradetype.SelectedValue = "0";
        drpdepartment.SelectedValue = "0";
        txt_noticePeriod.Text = "";
        txtsalary.Text = "";
        drpempstatus.SelectedValue = "0";
        ddl_corp_report_name.SelectedValue = "0";
        ddl_hod.SelectedValue = "0";
        //ddl_entity.SelectedValue = "0";
        //ddl_subgroup.SelectedValue = "0";
        ddl_supervisor.SelectedValue = "0";
        txt_confirmationdate.Text = "";
        txt_officialemail.Text = "";
        txtoff_mobileno.Text = "";


        ddl_cc_code.Items.Clear();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_acc_code.Items.Clear();
        ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));




        ddl_acc_groupid.SelectedValue = "0";
        traddcc.Visible = false;
        //ddl_acc_country.SelectedValue = "0";
        //ddl_acc_location.SelectedValue = "0";
        //ddl_acc_state.SelectedValue = "0";
        //ddl_acc_code.SelectedValue = "0";
        //ddl_acc_city.SelectedValue = "0";
        //ddl_broadgroup.SelectedValue = "0";

        ddl_cc_groupid.SelectedValue = "0";
        trcc.Visible = false;
        //ddl_cc_city.SelectedValue = "0";
        //ddl_cc_code.SelectedValue = "0";
        //ddl_cc_country.SelectedValue = "0";
        //ddl_cc_location.SelectedValue = "0";
        //ddl_cc_state.SelectedValue = "0";


        txtdol.Text = "";
        txtreason.Text = "";
        txtext.Text = "";
        doj.Text = "";
        txtempcode.Text = "";

        txt_ptno.Text = "";
        esino.Text = "";
        esidesp.Text = "";
        pfno.Text = "";
        panno.Text = "";
        pfno_dept.Text = "";
        ward.Text = "";

    }

    //=======================================insert Professional details ==================================================================

    //=====================================================================================================================================
    protected void reset_professional_detail()
    {
        Session.Remove("acc_education");
        Session.Remove("Pro_education");
        Session.Remove("exp");
        Session.Remove("training");

        GridTraning.DataSource = "";
        GridTraning.DataBind();

        grid_edu_education.DataSource = "";
        grid_edu_education.DataBind();

        grid_Pro_education.DataSource = "";
        grid_Pro_education.DataBind();

        grid_exp.DataSource = "";
        grid_exp.DataBind();
        ddlpersonalstatus.SelectedValue = "0";
    }

    //=====================================================================================================================================
    protected void resetprofessionaldetails()
    {
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";
    }

    //=====================================================================================================================================
    protected void resetexperiencedetails()
    {
        txtcomp1.Text = "";
        txt_total_exp.Text = "";
        txt_exp_from.Text = "";
        txt_exp_to.Text = "";
    }

    //====================================================================================================================================


    protected void ddlpersonalstatus_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlpersonalstatus.SelectedValue.ToString() == "Unmarried") || (ddlpersonalstatus.SelectedValue == "0"))
        {
            tbl1.Visible = false;
            // cv_s_dob.Enabled = false;
        }
        else
        {
            tbl1.Visible = true;
            //  cv_s_dob.Enabled = true;
        }
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
        if (CheckBox1.Checked == true)
        {
            //if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_state.SelectedValue == "0") || (ddl_pre_city.SelectedValue == "0"))
            //{
            //    ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please Select Country,State and City in Present Address');", true);
            //    CheckBox1.Checked = false;
            //}
            //else
            //{
            txt_per_add1.Text = txt_pre_add1.Text;
            //txt_per_add2.Text = txt_pre_Add2.Text;
            //ddl_per_country.SelectedValue = ddl_pre_country.SelectedValue;
            //bind_per_state(ddl_per_country.SelectedValue);
            //ddl_per_state.SelectedValue = ddl_pre_state.SelectedValue;
            //bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            //ddl_per_city.SelectedValue = ddl_pre_city.SelectedValue;
            //txt_per_zip.Text = txt_pre_zip.Text;
            //txt_per_phone.Text = txt_pre_phone.Text;
            txt_per_add1.Enabled = false;
            txt_per_add2.Enabled = false;
            ddl_per_city.Enabled = false;
            ddl_per_state.Enabled = false;
            ddl_per_country.Enabled = false;
            txt_per_zip.Enabled = false;
            txt_per_phone.Enabled = false;
            // }
        }
        else
        {
            txt_per_add1.Enabled = true;
            txt_per_add2.Enabled = true;
            ddl_per_city.Enabled = true;
            ddl_per_state.Enabled = true;
            ddl_per_country.Enabled = true;
            txt_per_zip.Enabled = true;
            txt_per_phone.Enabled = true;
            txt_per_add1.Text = "";
            txt_per_add2.Text = "";
            ddl_per_country.SelectedValue = "0";
            ddl_per_state.DataSource = "";
            ddl_per_state.DataBind();
            ddl_per_city.DataSource = "";
            ddl_per_city.DataBind();
            txt_per_zip.Text = "";
            txt_per_phone.Text = "";
        }
    }

    protected void btn_child_Add_Click(object sender, EventArgs e)
    {
        if (txt_child_Dob.Text != "" && txt_s_DOB.Text != "")
        {

            if (Convert.ToDateTime(txt_child_Dob.Text) < Convert.ToDateTime(txt_s_DOB.Text))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please enter valid date(should be Greater than spouse Date of birth)');", true);
            }
            else
            {
                Child_grid();
                txt_child_name.Text = "";
                txt_child_Dob.Text = "";
            }
        }
        else
        {
            ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please enter spouse Date of birth date');", true);
        }
    }
    //------------------insert the children detail-----------------------------
    protected void Child_grid()
    {
        DataRow dr;
        if (Session["child"] == null)
        {
            create_child_table();
        }
        dtable = (DataTable)Session["child"];

        DataRow drfind = dtable.Rows.Find(txt_child_name.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["child_name"] = txt_child_name.Text;
            dr["gender"] = ddl_child_gender.SelectedValue;
            dr["child_dob"] = txt_child_Dob.Text;

            dtable.Rows.Add(dr);
        }
        Session["child"] = dtable;
        BindList_child();
    }
    protected void BindList_child()
    {
        if (Session["child"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["child"];
            dview = new DataView(dtable);
            dview.Sort = "Child_name";
        }
        grid_child.DataSource = dview;
        grid_child.DataBind();
    }
    protected void create_child_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("child_name", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["child_name"] };
        dtable.Columns.Add("gender", typeof(string));
        dtable.Columns.Add(new DataColumn("child_DOB", typeof(string)));
        Session["child"] = dtable;
    }
    //................. delete item from children detail---------------------------
    protected void grid_child_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["child"];
        DataRow drfind_child = dtable.Rows.Find(Convert.ToString(grid_child.DataKeys[e.RowIndex].Value));
        if (drfind_child != null)
        {
            drfind_child.Delete();
            Session["child"] = dtable;
            BindList_child();
        }
    }

    //---------------------end insert child detail-------------------------

    protected void btn_pro_qual_add_Click(object sender, EventArgs e)
    {
        Ins_Pro_edu();
        txteduc1.Text = "";
        txtsch1.Text = "";
        txtper1.Text = "";
        txtfrm1.Text = "";
        txtto1.Text = "";
        txtpro_specilazation.Text = "";
    }
    //------------------------ Insert the Professional Qualification Data---------------------------
    protected void Ins_Pro_edu()
    {
        DataRow dr;
        if (Session["Pro_education"] == null)
        {
            create_Pro_edu_table();
        }
        dtable = (DataTable)Session["Pro_education"];

        DataRow drfind = dtable.Rows.Find(txteduc1.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["education"] = txteduc1.Text;
            dr["school"] = txtsch1.Text;
            dr["percentage"] = txtper1.Text;
            dr["from_year"] = txtfrm1.Text;
            dr["to_year"] = txtto1.Text;
            dr["specialization"] = txtpro_specilazation.Text;

            dtable.Rows.Add(dr);
        }
        Session["Pro_education"] = dtable;
        BindList_pro_edu();
    }
    protected void BindList_pro_edu()
    {
        if (Session["Pro_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["Pro_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_Pro_education.DataSource = dview;
        grid_Pro_education.DataBind();
    }
    protected void create_Pro_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("specialization", typeof(string)));

        Session["Pro_education"] = dtable;
    }

    protected void grid_Pro_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Pro_education"];
        DataRow drfind_pro_edu = dtable.Rows.Find(Convert.ToString(grid_Pro_education.DataKeys[e.RowIndex].Value));
        if (drfind_pro_edu != null)
        {
            drfind_pro_edu.Delete();
            Session["Pro_education"] = dtable;
            BindList_pro_edu();
        }
    }

    //------------------------------ End of Insertion of professiona qualification ---------------------

    protected void btn_exp_add_Click(object sender, EventArgs e)
    {
        Ins_exp();
        txtcomp1.Text = "";
        txt_com_local.Text = "";
        txt_total_exp.Text = "";
        txt_exp_from.Text = "";
        txt_exp_to.Text = "";
        txt_EXp_designation.Text = "";
    }
    //--------------- Insert the  exprience detail------------------------------

    protected void Ins_exp()
    {
        DataRow dr;
        if (Session["exp"] == null)
        {
            create_exp_table();
        }
        dtable = (DataTable)Session["exp"];

        //DataRow drfind = dtable.Rows.Find(txtcomp1.Text);
        //if (drfind != null)
        //{
        //}
        //else
        //{
        dr = dtable.NewRow();


        dr["comp_name"] = txtcomp1.Text;
        dr["location"] = txt_com_local.Text;
        dr["total_exp"] = txt_total_exp.Text;
        dr["from_year"] = txt_exp_from.Text;
        dr["to_year"] = txt_exp_to.Text;
        dr["designation"] = txt_EXp_designation.Text;
        dtable.Rows.Add(dr);
        //}
        Session["exp"] = dtable;
        BindList_exp();
    }
    protected void BindList_exp()
    {
        if (Session["exp"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["exp"];
            dview = new DataView(dtable);
            dview.Sort = "from_year";
        }
        grid_exp.DataSource = dview;
        grid_exp.DataBind();
    }
    protected void create_exp_table()
    {



        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("comp_name", typeof(string));
        dtable.Columns.Add(new DataColumn("location", typeof(string)));
        dtable.Columns.Add(new DataColumn("total_exp", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("designation", typeof(string)));


        Session["exp"] = dtable;
    }
    protected void grid_exp_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["exp"];
        DataRow drfind_exp = dtable.Rows.Find(Convert.ToString(grid_exp.DataKeys[e.RowIndex].Value));
        if (drfind_exp != null)
        {
            drfind_exp.Delete();
            Session["exp"] = dtable;
            BindList_exp();
        }
    }
    //--------------------------------- End Insetion of Experience Detail--------------------------
    //------------------------ Insert the Educational Qualification Data---------------------------
    protected void Ins_acc_edu()
    {
        DataRow dr;
        if (Session["acc_education"] == null)
        {
            create_acc_edu_table();
        }
        dtable = (DataTable)Session["acc_education"];

        DataRow drfind = dtable.Rows.Find(drp_edu_qualification.SelectedItem.ToString());
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["education"] = drp_edu_qualification.SelectedItem.ToString();
            dr["school"] = txtedush.Text;
            dr["percentage"] = txteduper.Text;
            dr["from_year"] = txtedufrom.Text;
            dr["to_year"] = txteduto.Text;
            dr["specialization"] = txtedu_specilazation.Text;
            dtable.Rows.Add(dr);
        }
        Session["acc_education"] = dtable;
        BindList_acc_edu();
    }
    protected void BindList_acc_edu()
    {
        if (Session["acc_education"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["acc_education"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        grid_edu_education.DataSource = dview;
        grid_edu_education.DataBind();
    }
    protected void create_acc_edu_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("education", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["education"] };
        dtable.Columns.Add(new DataColumn("school", typeof(string)));
        dtable.Columns.Add(new DataColumn("percentage", typeof(string)));
        dtable.Columns.Add(new DataColumn("from_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("to_year", typeof(string)));
        dtable.Columns.Add(new DataColumn("specialization", typeof(string)));


        Session["acc_education"] = dtable;
    }

    protected void grid_edu_education_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["acc_education"];
        DataRow drfind_acc_edu = dtable.Rows.Find(Convert.ToString(grid_edu_education.DataKeys[e.RowIndex].Value));
        if (drfind_acc_edu != null)
        {
            drfind_acc_edu.Delete();
            Session["acc_education"] = dtable;
            BindList_acc_edu();
        }

    }
    protected void btn_quali_add_Click(object sender, EventArgs e)
    {
        Ins_acc_edu();
        drp_edu_qualification.SelectedValue = "0";
        txtedush.Text = "";
        txteduper.Text = "";
        txtedufrom.Text = "";
        txteduto.Text = "";
        txtedu_specilazation.Text = "";
    }
    //------------------------------ End of Insertion of Educational qualification ---------------------


    //----------------------------- insert Training detail------------------------------
    protected void btn_Training_add_Click(object sender, EventArgs e)
    {
        add_Training();
        txt_TrProgram.Text = "";
        txt_TrConductedBy.Text = "";
        txtFromdate.Text = "";
        txtToDate.Text = "";
        txtTrRemarks.Text = "";
    }
    protected void add_Training()
    {
        DataRow dr;
        if (Session["training"] == null)
        {
            create_Training_table();
        }
        dtable = (DataTable)Session["training"];

        DataRow drfind = dtable.Rows.Find(txt_TrProgram.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();

            dr["trainingname"] = txt_TrProgram.Text;
            dr["personname"] = txt_TrConductedBy.Text;
            dr["fromdate"] = txtFromdate.Text;
            dr["todate"] = txtToDate.Text;
            dr["remarks"] = txtTrRemarks.Text;
            dtable.Rows.Add(dr);
        }
        Session["training"] = dtable;
        BindList_Training();
    }
    protected void BindList_Training()
    {
        if (Session["training"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["training"];
            dview = new DataView(dtable);
            // dview.Sort = "Training";
        }
        GridTraning.DataSource = dview;
        GridTraning.DataBind();
    }
    protected void create_Training_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("trainingname", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["trainingname"] };
        dtable.Columns.Add(new DataColumn("personname", typeof(string)));
        dtable.Columns.Add(new DataColumn("fromdate", typeof(string)));
        dtable.Columns.Add(new DataColumn("todate", typeof(string)));
        dtable.Columns.Add(new DataColumn("remarks", typeof(string)));
        Session["training"] = dtable;
    }
    protected void GridTraning_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["training"];
        DataRow drfind_Training = dtable.Rows.Find(Convert.ToString(GridTraning.DataKeys[e.RowIndex].Value));
        if (drfind_Training != null)
        {
            drfind_Training.Delete();
            Session["training"] = dtable;
            BindList_Training();
        }
    }




    //---------------------------------End----------------------------------------------

    //------------------------------ set the by default values in the drop down list-----------
    protected void drpempstatus_DataBound(object sender, EventArgs e)
    {
        drpempstatus.Items.Insert(0, new ListItem("---Select Status---", "0"));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }
    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("---Select Department---", "0"));
    }
    protected void drpgrade_DataBound(object sender, EventArgs e)
    {
        drpgrade.Items.Insert(0, new ListItem("---Select Grade---", "0"));
    }
    protected void drpdegination_DataBound(object sender, EventArgs e)
    {
        drpdegination.Items.Insert(0, new ListItem("---Select Designation---", "0"));
    }
    protected void drpdivision_DataBound(object sender, EventArgs e)
    {
        drpdivision.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void drprole_DataBound(object sender, EventArgs e)
    {
        drprole.Items.Insert(0, new ListItem("---Select Role---", "0"));
    }
    //----------------- End ------------------------------------------------------------

    //------------------------------- Insert the Educational qualification -------------------- 
    protected void Edit_Educational_Qualification(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["acc_education"] != null)
        {
            sqlstr = "delete  from tbl_employee_edcationalqualifications where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            dtable = (DataTable)Session["acc_education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["education"].ToString();

                sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["school"].ToString();

                sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["percentage"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                sqlParam[6].Value = dtable.Rows[i]["specialization"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_educationqualification]", sqlParam);
            }
        }
    }
    //------------------------------- End-----------------------------------------
    //------------------------------ insert Professional Qualification in the data base---------------------
    protected void edit_Professional_Qualification(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["Pro_education"] != null)
        {
            sqlstr = "delete from tbl_employee_professionalqualifications where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            dtable = (DataTable)Session["Pro_education"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@education", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["education"].ToString();

                sqlParam[2] = new SqlParameter("@school", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["school"].ToString();

                sqlParam[3] = new SqlParameter("@percentage", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["percentage"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@specialization", SqlDbType.VarChar, 100);
                sqlParam[6].Value = dtable.Rows[i]["specialization"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_professionalqualification]", sqlParam);
            }
        }
    }
    //--------------------------------------- end ----------------------------
    //------------------------------ insert Exprience Detail in the data base---------------------
    protected void edit_Expriece_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["exp"] != null)
        {
            sqlstr = "delete from tbl_employee_experiencedetails where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

            dtable = (DataTable)Session["exp"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlParam = new SqlParameter[7];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@companyname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["comp_name"].ToString();

                sqlParam[2] = new SqlParameter("@location", SqlDbType.VarChar, 150);
                sqlParam[2].Value = dtable.Rows[i]["location"].ToString();

                sqlParam[3] = new SqlParameter("@totalexperience", SqlDbType.VarChar, 50);
                sqlParam[3].Value = dtable.Rows[i]["total_exp"].ToString();

                sqlParam[4] = new SqlParameter("@yearfrom", SqlDbType.VarChar, 20);
                sqlParam[4].Value = dtable.Rows[i]["from_year"].ToString();

                sqlParam[5] = new SqlParameter("@yearto", SqlDbType.VarChar, 20);
                sqlParam[5].Value = dtable.Rows[i]["to_year"].ToString();

                sqlParam[6] = new SqlParameter("@designation", SqlDbType.VarChar, 50);
                sqlParam[6].Value = dtable.Rows[i]["designation"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_employee_insert_experiencedetails]", sqlParam);
            }
        }
    }
    //--------------------------------------- end ----------------------------
    //----------------------------------------edit Training details----------------------------------
    protected void edit_Training_details(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        if (Session["training"] != null)
        {
            sqlstr = "delete from tbl_intranet_employee_trainingdetail where empcode ='" + emp_code + "'";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
            dtable = (DataTable)Session["training"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {

                SqlParameter[] sqlParam = new SqlParameter[6];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@trainingname", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["trainingname"].ToString();

                sqlParam[2] = new SqlParameter("@personname", SqlDbType.VarChar, 50);
                sqlParam[2].Value = dtable.Rows[i]["personname"].ToString();

                sqlParam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
                sqlParam[3].Value = dtable.Rows[i]["fromdate"].ToString();

                sqlParam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
                sqlParam[4].Value = dtable.Rows[i]["todate"].ToString();

                sqlParam[5] = new SqlParameter("@remarks", SqlDbType.VarChar, 500);
                sqlParam[5].Value = dtable.Rows[i]["remarks"].ToString();



                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_insert_emp_training]", sqlParam);
            }
        }

    }

    //--------------------------------------- end ----------------------------

    //------------------------------ insert children Detail in the data base---------------------
    protected void edit_Children_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {

        sqlstr = "delete from tbl_intranet_employee_childrendetail where empcode ='" + emp_code + "'";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

        if (Session["child"] != null)
        {
            dtable = (DataTable)Session["child"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                DateTime dob;
                if (dtable.Rows[i]["child_dob"].ToString() != "")
                {
                    dob = Convert.ToDateTime(dtable.Rows[i]["child_dob"]);
                }
                else
                    dob = Convert.ToDateTime("01/01/1900");
                //System.Data.SqlTypes.SqlDateTime.Null;

                SqlParameter[] sqlParam = new SqlParameter[4];

                sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlParam[0].Value = emp_code;

                sqlParam[1] = new SqlParameter("@child_name", SqlDbType.VarChar, 50);
                sqlParam[1].Value = dtable.Rows[i]["child_name"].ToString();

                sqlParam[2] = new SqlParameter("@childdob", SqlDbType.DateTime);
                sqlParam[2].Value = dob;

                sqlParam[3] = new SqlParameter("@gender", SqlDbType.VarChar, 10);
                sqlParam[3].Value = dtable.Rows[i]["gender"].ToString();

                SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_insert_childrendetail]", sqlParam);
            }
        }
    }
    //--------------------------------------- end ----------------------------
    //--------------------------------------- Insert the Personal Details ----------------------------------
    protected void edit_personal_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {

        int paymentmode = 0;
        SqlParameter[] sqlParam = new SqlParameter[31];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;
        sqlParam[1] = new SqlParameter("@f_fname", SqlDbType.VarChar, 50);
        sqlParam[1].Value = txt_f_f_name.Text;
        sqlParam[2] = new SqlParameter("@f_mname", SqlDbType.VarChar, 50);
        //---------changes by ramu nunna for update shirt and t-shirt Details
        sqlParam[2].Value = ddl_Tshirt.SelectedValue;//txt_f_mname.Text;
        sqlParam[3] = new SqlParameter("@f_lname", SqlDbType.VarChar, 50);
        sqlParam[3].Value = ddl_ShirtSize.SelectedValue;// txt_f_l_name.Text;
        //end --------------------------------------------
        sqlParam[4] = new SqlParameter("@m_fname", SqlDbType.VarChar, 50);
        sqlParam[4].Value = txt_m_fname.Text;
        sqlParam[5] = new SqlParameter("@m_lname", SqlDbType.VarChar, 50);
        sqlParam[5].Value = txt_m_l_name.Text;
        sqlParam[6] = new SqlParameter("@m_mname", SqlDbType.VarChar, 50);
        sqlParam[6].Value = txt_m_mname.Text;
        sqlParam[7] = new SqlParameter("@bloodgrp", SqlDbType.VarChar, 50);
        sqlParam[7].Value = ddlbloodgrp.SelectedValue;
        sqlParam[8] = new SqlParameter("@maritalstatus", SqlDbType.VarChar, 50);
        sqlParam[8].Value = ddlpersonalstatus.SelectedValue;
        sqlParam[9] = new SqlParameter("@religion", SqlDbType.VarChar, 50);
        sqlParam[9].Value = txtrelg.Text;
        sqlParam[10] = new SqlParameter("@doa", SqlDbType.DateTime);
        if (txt_doa.Text == "")
            sqlParam[10].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[10].Value = txt_doa.Text; // Utility.dataformat(txt_doa.Text);
        sqlParam[11] = new SqlParameter("@dlno", SqlDbType.VarChar, 50);
        sqlParam[11].Value = txt_dl_no.Text;
        sqlParam[12] = new SqlParameter("@s_fname", SqlDbType.VarChar, 50);
        sqlParam[12].Value = txt_sp_fname.Text;
        sqlParam[13] = new SqlParameter("@s_mname", SqlDbType.VarChar, 50);
        sqlParam[13].Value = txt_sp_mname.Text;
        sqlParam[14] = new SqlParameter("@s_lname", SqlDbType.VarChar, 50);
        sqlParam[14].Value = txt_sp_lname.Text;
        sqlParam[15] = new SqlParameter("@s_dob", SqlDbType.DateTime);
        if (txt_s_DOB.Text == "")

            sqlParam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[15].Value = txt_s_DOB.Text; //Utility.dataformat(txt_s_DOB.Text);

        sqlParam[16] = new SqlParameter("@s_gender", SqlDbType.VarChar, 50);
        sqlParam[16].Value = ddl_s_gender.SelectedValue;
        sqlParam[17] = new SqlParameter("@no_child", SqlDbType.Int);
        sqlParam[17].Value = 3;
        sqlParam[18] = new SqlParameter("@mobile_no", SqlDbType.VarChar, 50);
        sqlParam[18].Value = txtmobileno.Text;
        sqlParam[19] = new SqlParameter("@email_id", SqlDbType.VarChar, 50);
        sqlParam[19].Value = txt_email.Text;

        sqlParam[20] = new SqlParameter("@bank_name", SqlDbType.VarChar, 50);
        sqlParam[20].Value = (ddl_bank_name.SelectedValue == "0") || (ddl_bank_name.SelectedValue == "") || (ddl_bank_name.SelectedValue == null) ? "0" : ddl_bank_name.SelectedValue;
        sqlParam[21] = new SqlParameter("@ac_number", SqlDbType.VarChar, 50);
        sqlParam[21].Value = txt_bank_ac.Text;
        sqlParam[22] = new SqlParameter("@passport_number", SqlDbType.VarChar, 50);
        sqlParam[22].Value = txt_passportno.Text;

        sqlParam[23] = new SqlParameter("@DOB", SqlDbType.DateTime);
        if (txt_DOB.Text == "")
            sqlParam[23].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlParam[23].Value = txt_DOB.Text;// Utility.dataformat(txt_DOB.Text);

        if (rbtnbank.Checked)
            paymentmode = 0;

        if (rbtncheque.Checked)
            paymentmode = 1;

        if (rbtncash.Checked)
            paymentmode = 2;

        sqlParam[24] = new SqlParameter("@paymentmode", SqlDbType.Int);
        sqlParam[24].Value = paymentmode;

        sqlParam[25] = new SqlParameter("@bank_name_reimbursement", SqlDbType.VarChar, 50);
        sqlParam[25].Value = ddl_bank_name_reimbursement.SelectedValue;
        sqlParam[26] = new SqlParameter("@ac_number_reimbursement", SqlDbType.VarChar, 50);
        sqlParam[26].Value = txt_bank_ac_reimbursement.Text.Trim();

        sqlParam[27] = new SqlParameter("@bankbranch", SqlDbType.VarChar, 50);
        sqlParam[27].Value = txt_bankbrachname.Text;
        sqlParam[28] = new SqlParameter("@ifsc", SqlDbType.VarChar, 50);
        sqlParam[28].Value = txt_ifsc.Text;
        sqlParam[29] = new SqlParameter("@passportissuedate", SqlDbType.DateTime);
        if (txt_passportissueddate.Text == "")
        {
            sqlParam[29].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[29].Value = txt_passportissueddate.Text;
        }
        sqlParam[30] = new SqlParameter("@passportexpiraydate", SqlDbType.DateTime);
        if (txt_passportexpdate.Text == "")
        {
            sqlParam[30].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            sqlParam[30].Value = txt_passportexpdate.Text;
        }

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_Edit_personaldetails]", sqlParam);
    }
    //----------------------------- insert the contact detail------------------------------

    protected void edit_contact_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlParam = new SqlParameter[26];

        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;
        sqlParam[1] = new SqlParameter("@pre_add1", SqlDbType.VarChar, 500);
        sqlParam[1].Value = txt_pre_add1.Text;
        sqlParam[2] = new SqlParameter("@pre_Add2", SqlDbType.VarChar, 500);
        sqlParam[2].Value = txt_pre_Add2.Text;
        sqlParam[3] = new SqlParameter("@pre_city", SqlDbType.VarChar, 100);
        if ((ddl_pre_city.SelectedValue == "0") || (ddl_pre_city.SelectedValue == ""))
        {
            sqlParam[3].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[3].Value = ddl_pre_city.SelectedValue;
        }
        sqlParam[4] = new SqlParameter("@pre_state", SqlDbType.VarChar, 50);
        if ((ddl_pre_state.SelectedValue == "0") || (ddl_pre_state.SelectedValue == ""))
        {
            sqlParam[4].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[4].Value = ddl_pre_state.SelectedValue;
        }
        sqlParam[5] = new SqlParameter("@pre_country", SqlDbType.VarChar, 50);
        if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_country.SelectedValue == ""))
        {
            sqlParam[5].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[5].Value = ddl_pre_country.SelectedValue;
        }
        sqlParam[6] = new SqlParameter("@pre_zip", SqlDbType.VarChar, 50);
        sqlParam[6].Value = txt_pre_zip.Text;
        sqlParam[7] = new SqlParameter("@pre_phone", SqlDbType.VarChar, 50);
        sqlParam[7].Value = txt_pre_phone.Text;
        sqlParam[8] = new SqlParameter("@per_add1", SqlDbType.VarChar, 500);
        sqlParam[8].Value = txt_per_add1.Text;
        sqlParam[9] = new SqlParameter("@per_add2", SqlDbType.VarChar, 500);
        sqlParam[9].Value = txt_per_add2.Text;
        sqlParam[10] = new SqlParameter("@per_city", SqlDbType.VarChar, 100);
        if ((ddl_per_city.SelectedValue == "0") || (ddl_per_city.SelectedValue == ""))
        {
            sqlParam[10].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[10].Value = ddl_per_city.SelectedValue;
        }
        sqlParam[11] = new SqlParameter("@per_state", SqlDbType.VarChar, 50);
        if ((ddl_per_state.SelectedValue == "0") || (ddl_per_state.SelectedValue == ""))
        {
            sqlParam[11].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[11].Value = ddl_per_state.SelectedValue;
        }
        sqlParam[12] = new SqlParameter("@per_country", SqlDbType.VarChar, 50);
        if ((ddl_per_country.SelectedValue == "0") || (ddl_per_country.SelectedValue == ""))
        {
            sqlParam[12].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[12].Value = ddl_per_country.SelectedValue;
        }
        sqlParam[13] = new SqlParameter("@per_zip", SqlDbType.VarChar, 50);
        sqlParam[13].Value = txt_per_zip.Text;
        sqlParam[14] = new SqlParameter("@per_phone", SqlDbType.VarChar, 50);
        sqlParam[14].Value = txt_per_phone.Text;
        sqlParam[15] = new SqlParameter("@mode", SqlDbType.TinyInt);

        if (optcompany.Checked)
        {
            sqlParam[15].Value = 1;
        }

        if (optown.Checked)
        {
            sqlParam[15].Value = 0;
        }

        sqlParam[16] = new SqlParameter("@modeoftransport", SqlDbType.VarChar, 50);
        sqlParam[16].Value = txtmodeoftransport.Text;

        sqlParam[17] = new SqlParameter("@emergency_contact_no", SqlDbType.VarChar, 50);
        sqlParam[17].Value = txt_emergency_contactno.Text;

        sqlParam[18] = new SqlParameter("@emergency_name", SqlDbType.VarChar, 50);
        sqlParam[18].Value = txt_emergency_name.Text;

        sqlParam[19] = new SqlParameter("@emergency_relation", SqlDbType.VarChar, 50);
        sqlParam[19].Value = txt_emergency_relation.Text;

        sqlParam[20] = new SqlParameter("@emergency_address1", SqlDbType.VarChar, 500);
        sqlParam[20].Value = txt_emergency_address.Text;

        sqlParam[21] = new SqlParameter("@emergency_address2", SqlDbType.VarChar, 500);
        sqlParam[21].Value = txt_emergency_address2.Text;

        sqlParam[22] = new SqlParameter("@emergency_city", SqlDbType.Int);
        if ((ddl_emergency_city.SelectedValue == "0") || (ddl_emergency_city.SelectedValue == ""))
        {
            sqlParam[22].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlParam[22].Value = Convert.ToInt32(ddl_emergency_city.SelectedValue);
        }

        sqlParam[23] = new SqlParameter("@emergency_state", SqlDbType.Int);
        if ((ddl_emergency_state.SelectedValue == "0") || (ddl_emergency_state.SelectedValue == ""))
        {
            sqlParam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlParam[23].Value = Convert.ToInt32(ddl_emergency_state.SelectedValue);
        }
        sqlParam[24] = new SqlParameter("@emergency_country", SqlDbType.VarChar, 50);
        if ((ddl_emergency_country.SelectedValue == "0") || (ddl_emergency_country.SelectedValue == ""))
        {
            sqlParam[24].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlParam[24].Value = ddl_emergency_country.SelectedValue;
        }

        sqlParam[25] = new SqlParameter("@emergency_zip", SqlDbType.VarChar, 50);
        sqlParam[25].Value = txt_emergency_zipcode.Text;

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_intranet_EDIT_contactdetails]", sqlParam);
    }
    //---------------------------------End-----------------------------------------------
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }

    protected void optown_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = false;
        lblpickuppoint.Visible = false;
    }
    protected void optcompany_CheckedChanged(object sender, EventArgs e)
    {
        txtmodeoftransport.Visible = true;
        lblpickuppoint.Visible = true;
    }

    protected void rbtnbank_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = true;
    }

    protected void rbtncheque_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }

    protected void rbtncash_CheckedChanged(object sender, EventArgs e)
    {
        paymentmode.Visible = false;
    }



    protected void ddl_bank_name_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }

    protected void img_close_Click(object sender, ImageClickEventArgs e)
    {
        paymentmode.Visible = false;
    }



    protected void ddl_bank_name_reimbursement_DataBound(object sender, EventArgs e)
    {
        ddl_bank_name_reimbursement.Items.Insert(0, new ListItem("---Select Bank Name---", "0"));
    }
    //----------------------Add defult lables for employee upload doc.......--------------------------
    private void Getdefaultlable()
    {
        //  string sqlstr = "select id, labelname from staticlabel";
        // ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        string sqlstr = "select labelname from staticlabel";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        lbl_Default1.Text = ds.Tables[0].Rows[0]["labelname"].ToString();
        lbl_Default2.Text = ds.Tables[0].Rows[1]["labelname"].ToString();
        lbl_Default3.Text = ds.Tables[0].Rows[2]["labelname"].ToString();
        lbl_Default4.Text = ds.Tables[0].Rows[3]["labelname"].ToString();
        lbl_Default5.Text = ds.Tables[0].Rows[4]["labelname"].ToString();
        lbl_Default6.Text = ds.Tables[0].Rows[5]["labelname"].ToString();
        lbl_Default7.Text = ds.Tables[0].Rows[6]["labelname"].ToString();
        lbl_Default8.Text = ds.Tables[0].Rows[7]["labelname"].ToString();
        lbl_Default9.Text = ds.Tables[0].Rows[8]["labelname"].ToString();
        lbl_Default10.Text = ds.Tables[0].Rows[9]["labelname"].ToString();
    }

    //----------------------------------EDIT Upload Documents--------------------------------

    protected void bind_emp_doc(string empcode)
    {

        sqlstr = "SELECT empcode,default1,default2,default3,default4,default5,default6,default7,default8,default9,default10 FROM tbl_intranet_employee_docupload where empcode = '" + empcode + "'";


        try
        {
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            //Session["rowID"] = ds.Tables[0].Rows[0]["id"].ToString();
            lbl_file1.Text = (ds.Tables[0].Rows[0]["default1"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default1"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default1"].ToString() + "</a>" : "No exisitng file found";

            lbl_file2.Text = (ds.Tables[0].Rows[0]["default2"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default2"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default2"].ToString() + "</a>" : "No exisitng file found";
            lbl_file3.Text = (ds.Tables[0].Rows[0]["default3"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default3"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default3"].ToString() + "</a>" : "No exisitng file found";
            lbl_file4.Text = (ds.Tables[0].Rows[0]["default4"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default4"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default4"].ToString() + "</a>" : "No exisitng file found";
            lbl_file5.Text = (ds.Tables[0].Rows[0]["default5"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default5"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default5"].ToString() + "</a>" : "No exisitng file found";
            lbl_file6.Text = (ds.Tables[0].Rows[0]["default6"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default6"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default6"].ToString() + "</a>" : "No exisitng file found";
            lbl_file7.Text = (ds.Tables[0].Rows[0]["default7"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default7"].ToString() +
                "'>" + ds.Tables[0].Rows[0]["default7"].ToString() + "</a>" : "No exisitng file found";
            lbl_file8.Text = (ds.Tables[0].Rows[0]["default8"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default8"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default8"].ToString() + "</a>" : "No exisitng file found";
            lbl_file9.Text = (ds.Tables[0].Rows[0]["default9"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default9"].ToString() +
                "' target='_blank'>" + ds.Tables[0].Rows[0]["default9"].ToString() + "</a>" : "No exisitng file found";
            lbl_file10.Text = (ds.Tables[0].Rows[0]["default10"].ToString() != "") ? "<a href='../upload/employeedocuments/" + ds.Tables[0].Rows[0]["default10"].ToString() +
             "' target='_blank'>" + ds.Tables[0].Rows[0]["default10"].ToString() + "</a>" : "No exisitng file found";


        }
        catch (Exception ex)
        {
            //message.InnerHtml = "";
            //Utilities.LogError(ex);
        }
    }


    protected void edit_emp_documents(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        string defaultUpload1 = "";
        string defaultUpload2 = "";
        string defaultUpload3 = "";
        string defaultUpload4 = "";
        string defaultUpload5 = "";
        string defaultUpload6 = "";
        string defaultUpload7 = "";
        string defaultUpload8 = "";
        string defaultUpload9 = "";
        string defaultUpload10 = "";


        sqlstr = "SELECT empcode,default1,default2,default3,default4,default5,default6,default7,default8,default9,default10 FROM tbl_intranet_employee_docupload where empcode = '" + empcode + "'";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);


        SqlParameter[] sqlParam = new SqlParameter[11];
        sqlParam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlParam[0].Value = empcode;

        sqlParam[1] = new SqlParameter("@default1", SqlDbType.VarChar, 100);



        if (fu_dft1.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft1.FileName;
            try
            {
                fu_dft1.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[1].Value = defaultUpload1;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[1].Value = "";
            }
            else
            {
                sqlParam[1].Value = ds.Tables[0].Rows[0]["default1"].ToString();
            }

        }

        sqlParam[2] = new SqlParameter("@default2", SqlDbType.VarChar, 100);

        if (fu_dft2.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft2.FileName;
            try
            {
                fu_dft2.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload2 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[2].Value = defaultUpload2;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[2].Value = "";
            }
            else
            {
                sqlParam[2].Value = ds.Tables[0].Rows[0]["default2"].ToString();
            }

        }


        sqlParam[3] = new SqlParameter("@default3", SqlDbType.VarChar, 100);

        if (fu_dft3.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft3.FileName;
            try
            {
                fu_dft3.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload3 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[3].Value = defaultUpload2;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[3].Value = "";
            }
            else
            {
                sqlParam[3].Value = ds.Tables[0].Rows[0]["default3"].ToString();
            }

        }


        sqlParam[4] = new SqlParameter("@default4", SqlDbType.VarChar, 100);

        if (fu_dft4.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft4.FileName;
            try
            {
                fu_dft4.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload4 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[4].Value = defaultUpload4;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[4].Value = "";
            }
            else
            {
                sqlParam[4].Value = ds.Tables[0].Rows[0]["default4"].ToString();
            }

        }



        sqlParam[5] = new SqlParameter("@default5", SqlDbType.VarChar, 100);

        if (fu_dft5.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft5.FileName;
            try
            {
                fu_dft5.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload5 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[5].Value = defaultUpload5;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[5].Value = "";
            }
            else
            {
                sqlParam[5].Value = ds.Tables[0].Rows[0]["default5"].ToString();
            }

        }

        sqlParam[6] = new SqlParameter("@default6", SqlDbType.VarChar, 100);

        if (fu_dft6.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft6.FileName;
            try
            {
                fu_dft6.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload6 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[6].Value = defaultUpload6;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[6].Value = "";
            }
            else
            {
                sqlParam[6].Value = ds.Tables[0].Rows[0]["default6"].ToString();
            }

        }

        sqlParam[7] = new SqlParameter("@default7", SqlDbType.VarChar, 100);

        if (fu_dft7.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft7.FileName;
            try
            {
                fu_dft7.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload7 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[7].Value = defaultUpload7;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[7].Value = "";
            }
            else
            {
                sqlParam[7].Value = ds.Tables[0].Rows[0]["default7"].ToString();
            }

        }


        sqlParam[8] = new SqlParameter("@default8", SqlDbType.VarChar, 100);

        if (fu_dft8.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft8.FileName;
            try
            {
                fu_dft8.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload8 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[8].Value = defaultUpload8;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[8].Value = "";
            }
            else
            {
                sqlParam[8].Value = ds.Tables[0].Rows[0]["default8"].ToString();
            }

        }


        sqlParam[9] = new SqlParameter("@default9", SqlDbType.VarChar, 100);

        if (fu_dft9.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft9.FileName;
            try
            {
                fu_dft9.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload9 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[9].Value = defaultUpload9;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[9].Value = "";
            }
            else
            {
                sqlParam[9].Value = ds.Tables[0].Rows[0]["default9"].ToString();
            }

        }


        sqlParam[10] = new SqlParameter("@default10", SqlDbType.VarChar, 100);

        if (fu_dft10.HasFile)
        {
            string strFileName;
            string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            strFileName = fu_dft10.FileName;
            try
            {
                fu_dft10.PostedFile.SaveAs(Server.MapPath("~/upload/employeedocuments/" + file_name + "_" + strFileName));
                defaultUpload10 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
                sqlParam[10].Value = defaultUpload10;

            }
            catch (Exception exc)
            {
                //lblMsg.Text = exc.Message;
            }
        }
        else
        {
            if (ds.Tables[0].Rows.Count < 1)
            {
                sqlParam[10].Value = "";
            }
            else
            {
                sqlParam[10].Value = ds.Tables[0].Rows[0]["default10"].ToString();
            }

        }

        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_update_emp_doc_upload", sqlParam);


    }

    //==================================code add on 16-12-13===================================
    protected void ddl_gradetype_SelectedIndexChanged(object sender, EventArgs e)
    {
        // bind_grade();
    }

    //protected void bind_grade()
    //{
    //    if (ddl_gradetype.SelectedValue == "A")
    //    {
    //        sqlstr = "select * from tbl_intranet_grade where gradetype='" + ddl_gradetype.SelectedValue + "'";
    //        DataSet ds_A = new DataSet();
    //        ds_A = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        drpgrade.DataSource = ds_A;
    //        drpgrade.DataValueField = "id";
    //        drpgrade.DataTextField = "gradename";
    //        drpgrade.DataBind();
    //        drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));

    //    }
    //    else if (ddl_gradetype.SelectedValue == "T")
    //    {
    //        sqlstr = "select * from tbl_intranet_grade where gradetype='" + ddl_gradetype.SelectedValue + "'";
    //        DataSet ds_T = new DataSet();
    //        ds_T = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        drpgrade.DataSource = ds_T;
    //        drpgrade.DataValueField = "id";
    //        drpgrade.DataTextField = "gradename";
    //        drpgrade.DataBind();
    //        drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));
    //    }
    //    else
    //    {
    //        drpgrade.DataSource = "";
    //        drpgrade.DataBind();
    //        drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));
    //    }
    //}

    protected void bind_empstatus()
    {

        sqlstr = "select id,employeestatus from tbl_intranet_employee_status ";
        DataSet ds_empstat = new DataSet();
        ds_empstat = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        drpempstatus.DataSource = ds_empstat;
        drpempstatus.DataValueField = "id";
        drpempstatus.DataTextField = "employeestatus";
        drpempstatus.DataBind();
        drpempstatus.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void drpempstatus_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedItem.Text == "Probation")
        {
            trprobationperiod.Visible = true;
            trprobationdate.Visible = true;
            trprobationdate2.Visible = true;
            trprobationdate3.Visible = true;
            REg_probation_date.Enabled = true;
            REg_probationdate2.Enabled = true;
            trduptstart.Visible = false;
            trduptenddate.Visible = false;
            RFV_probation_date.Enabled = true;
            RFV_probationperiod.Enabled = true;
            RFV_deput_start_date.Enabled = false;
            RFV_deput_end_date.Enabled = false;
            RFV_DOL.Enabled = false;
            trDOL.Visible = false;
            trReasonL.Visible = false;
        }
        else
            if (drpempstatus.SelectedItem.Text == "Contractual")
            {
                trprobationperiod.Visible = false;
                trprobationdate.Visible = false;
                trprobationdate2.Visible = false;
                trprobationdate3.Visible = false;
                REg_probation_date.Enabled = false;
                REg_probationdate2.Enabled = false;
                trduptstart.Visible = true;
                trduptenddate.Visible = true;
                RFV_probation_date.Enabled = false;
                RFV_probationperiod.Enabled = false;
                RFV_deput_start_date.Enabled = true;
                RFV_deput_end_date.Enabled = true;
                RFV_DOL.Enabled = false;
                trDOL.Visible = false;
                trReasonL.Visible = false;

            }
            else
                if (drpempstatus.SelectedItem.Text == "Resigned")
                {
                    trprobationperiod.Visible = false;
                    trprobationdate.Visible = false;
                    trprobationdate2.Visible = false;
                    trprobationdate3.Visible = false;
                    REg_probation_date.Enabled = false;
                    REg_probationdate2.Enabled = false;
                    trduptstart.Visible = false;
                    trduptenddate.Visible = false;
                    RFV_probation_date.Enabled = false;
                    RFV_probationperiod.Enabled = false;
                    RFV_deput_start_date.Enabled = false;
                    RFV_deput_end_date.Enabled = false;
                    RFV_DOL.Enabled = true;
                    trDOL.Visible = true;
                    trReasonL.Visible = true;

                }
                else
                {
                    trprobationperiod.Visible = false;
                    trprobationdate.Visible = false;
                    trprobationdate2.Visible = false;
                    trprobationdate3.Visible = false;
                    REg_probation_date.Enabled = false;
                    REg_probationdate2.Enabled = false;
                    trduptstart.Visible = false;
                    trduptenddate.Visible = false;
                    RFV_probation_date.Enabled = false;
                    RFV_probationperiod.Enabled = false;
                    RFV_deput_start_date.Enabled = false;
                    RFV_deput_end_date.Enabled = false;
                    RFV_DOL.Enabled = false;
                    trDOL.Visible = false;
                    trReasonL.Visible = false;

                }
    }




    //-----------------------for cost center--------------

    protected void ddl_cc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_cc_code.Items.Clear();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
        trcc.Visible = false;
        if (ddl_cc_groupid.SelectedValue != "0")
            bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));

    }
    protected void ddl_cc_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        trcc.Visible = false;
        if (ddl_cc_code.SelectedValue != "0")
        {
            trcc.Visible = true;
            bind_cc(Convert.ToInt32(ddl_cc_code.SelectedValue));
        }

        //bind_cc_country(Convert.ToInt32(ddl_cc_code.SelectedValue));
        //ddl_cc_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }


    protected void bind_ddlCCgroup()
    {
        sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
        DataSet ds_ccg = new DataSet();
        ds_ccg = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (ds_ccg.Tables[0].Rows.Count < 1)
            return;
        ddl_cc_groupid.DataSource = ds_ccg;
        ddl_cc_groupid.DataTextField = "cost_center_group_name";
        ddl_cc_groupid.DataValueField = "id";
        ddl_cc_groupid.DataBind();
        ddl_cc_groupid.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void bind_cc_code(int accgroupid)
    {
        sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
        DataSet dset = new DataSet();
        dset = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (dset.Tables[0].Rows.Count < 1)
            return;
        ddl_cc_code.DataSource = dset;
        ddl_cc_code.DataTextField = "cost_center_code";
        ddl_cc_code.DataValueField = "id";
        ddl_cc_code.DataBind();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_cc(int cc_id)
    {
        string sqlstr1 = "select id, country,state,city, location from tbl_intranet_cost_center where id='" + cc_id + "'";
        DataSet dset3 = new DataSet();
        dset3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
        int cid = Convert.ToInt32(dset3.Tables[0].Rows[0]["country"]);
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
        DataSet ds3 = new DataSet();
        ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        hf_ccountry.Value = dset3.Tables[0].Rows[0]["country"].ToString();
        hf_cstate.Value = dset3.Tables[0].Rows[0]["state"].ToString();
        hf_ccity.Value = dset3.Tables[0].Rows[0]["city"].ToString();
        lbl_cc_country.Text = ds3.Tables[0].Rows[0]["countryname"].ToString();

        string sqlstr2 = "select ID,state from tbl_intranet_state_master where ID='" + Convert.ToInt32(dset3.Tables[0].Rows[0]["state"]) + "' ";
        DataSet ds4 = new DataSet();
        ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr2);
        lbl_cc_state.Text = ds4.Tables[0].Rows[0]["state"].ToString();


        string sqlstr3 = "select cid,stateid,city from tbl_intranet_city where cid='" + Convert.ToInt32(dset3.Tables[0].Rows[0]["city"]) + "'";
        DataSet ds5 = new DataSet();
        ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr3);
        lbl_cc_city.Text = ds5.Tables[0].Rows[0]["city"].ToString();

        lbl_cc_location.Text = dset3.Tables[0].Rows[0]["location"].ToString();
    }
    //protected void bind_cc_country(int cc_id)
    //{
    //    if (cc_id == 0)
    //        return;
    //    string sqlstr1 = "select * from tbl_intranet_cost_center where cost_center_code='" + cc_id + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
    //    int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["country"]);
    //    string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
    //    DataSet ds3 = new DataSet();
    //    ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_cc_country.DataTextField = "countryname";
    //    ddl_cc_country.DataValueField = "cid";
    //    ddl_cc_country.DataSource = ds3;
    //    ddl_cc_country.DataBind();
    //    bind_cc_state(Convert.ToInt32(ds.Tables[0].Rows[0]["state"]));
    //    bind_cc_city(Convert.ToInt32(ds.Tables[0].Rows[0]["city"]));
    //    bind_cc_location(ds.Tables[0].Rows[0]["location"].ToString());
    //}
    //protected void bind_cc_state(int stateid)
    //{

    //    string sqlstr = "select ID,state from tbl_intranet_state_master where ID='" + stateid + "' ";
    //    DataSet ds4 = new DataSet();
    //    ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_cc_state.DataTextField = "state";
    //    ddl_cc_state.DataValueField = "ID";
    //    ddl_cc_state.DataSource = ds4;
    //    ddl_cc_state.DataBind();
    //}
    //protected void bind_cc_city(int cityid)
    //{
    //    sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + cityid + "'";
    //    DataSet ds5 = new DataSet();
    //    ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    ddl_cc_city.DataSource = ds5;
    //    ddl_cc_city.DataTextField = "city";
    //    ddl_cc_city.DataValueField = "cid";
    //    ddl_cc_city.DataBind();


    //}
    //protected void bind_cc_location(string location)
    //{
    //    sqlstr = "select location from tbl_intranet_cost_center where location='" + location + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    ddl_cc_location.DataSource = ds;
    //    ddl_cc_location.DataTextField = "location";
    //    ddl_cc_location.DataValueField = "location";
    //    ddl_cc_location.DataBind();
    //    //ddl_cc_location.Items.Insert(0, new ListItem("--Select--", "0"));

    //}


    //------------------------End----------------------



    //-----------------------for additional cost center--------------


    protected void ddl_acc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_acc_code.Items.Clear();
        ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
        traddcc.Visible = false;
        if (ddl_acc_groupid.SelectedValue != "0")
            bind_ddl_acc_code(Convert.ToInt32(ddl_acc_groupid.SelectedValue));
        //ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddl_acc_code_SelectedIndexChanged(object sender, EventArgs e)
    {
        traddcc.Visible = false;
        if (ddl_acc_code.SelectedValue != "0")
        {
            bind_acc(Convert.ToInt32(ddl_acc_code.SelectedValue));
            traddcc.Visible = true;
        }
        //bind_acc_country(Convert.ToInt32(ddl_acc_code.SelectedValue));
        //ddl_acc_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_ddl_aCCgroup()
    {
        sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
        DataSet dset5 = new DataSet();
        dset5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (dset5.Tables[0].Rows.Count < 1)
            return;
        ddl_acc_groupid.DataSource = dset5;
        ddl_acc_groupid.DataTextField = "cost_center_group_name";
        ddl_acc_groupid.DataValueField = "id";
        ddl_acc_groupid.DataBind();
        ddl_acc_groupid.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void bind_ddl_acc_code(int accgroupid)
    {
        sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
        DataSet dset4 = new DataSet();
        dset4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (dset4.Tables[0].Rows.Count < 1)
            return;
        ddl_acc_code.DataSource = dset4;
        ddl_acc_code.DataTextField = "cost_center_code";
        ddl_acc_code.DataValueField = "id";
        ddl_acc_code.DataBind();
        ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));

    }


    protected void bind_acc(int acc_id)
    {
        string sqlstr1 = "select id,country,state,city, location from tbl_intranet_cost_center where id='" + acc_id + "'";
        DataSet dset2 = new DataSet();
        dset2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
        int cid = Convert.ToInt32(dset2.Tables[0].Rows[0]["country"]);
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
        DataSet ds3 = new DataSet();
        ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        hf_accountry.Value = dset2.Tables[0].Rows[0]["country"].ToString();
        hf_acstate.Value = dset2.Tables[0].Rows[0]["state"].ToString();
        hf_accity.Value = dset2.Tables[0].Rows[0]["city"].ToString();

        lbl_acc_country.Text = ds3.Tables[0].Rows[0]["countryname"].ToString();

        string sqlstr2 = "select ID,state from tbl_intranet_state_master where ID='" + Convert.ToInt32(dset2.Tables[0].Rows[0]["state"]) + "' ";
        DataSet ds4 = new DataSet();
        ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr2);
        lbl_acc_state.Text = ds4.Tables[0].Rows[0]["state"].ToString();


        string sqlstr3 = "select cid,stateid,city from tbl_intranet_city where cid='" + Convert.ToInt32(dset2.Tables[0].Rows[0]["city"]) + "'";
        DataSet ds5 = new DataSet();
        ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr3);
        lbl_acc_city.Text = ds5.Tables[0].Rows[0]["city"].ToString();

        lbl_acc_location.Text = dset2.Tables[0].Rows[0]["location"].ToString();
    }
    //protected void bind_acc_country(int acc_id)
    //{
    //    if (acc_id == 0)
    //        return;
    //    string sqlstr1 = "select * from tbl_intranet_cost_center where cost_center_code='" + acc_id + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
    //    int cid = Convert.ToInt32(ds.Tables[0].Rows[0]["country"]);
    //    string sqlstr = "select cid,countryname  from tbl_intranet_country_master where cid='" + cid + "'";
    //    DataSet ds3 = new DataSet();
    //    ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_acc_country.DataTextField = "countryname";
    //    ddl_acc_country.DataValueField = "cid";
    //    ddl_acc_country.DataSource = ds3;
    //    ddl_acc_country.DataBind();
    //    bind_acc_state(Convert.ToInt32(ds.Tables[0].Rows[0]["state"]));
    //    bind_acc_city(Convert.ToInt32(ds.Tables[0].Rows[0]["city"]));
    //    bind_acc_location(ds.Tables[0].Rows[0]["location"].ToString());

    //}
    //protected void bind_acc_state(int stateid)
    //{

    //    string sqlstr = "select ID,state from tbl_intranet_state_master where ID='" + stateid + "' ";
    //    DataSet ds4 = new DataSet();
    //    ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //    ddl_acc_state.DataTextField = "state";
    //    ddl_acc_state.DataValueField = "ID";
    //    ddl_acc_state.DataSource = ds4;
    //    ddl_acc_state.DataBind();
    //}
    //protected void bind_acc_city(int cityid)
    //{
    //    sqlstr = "select cid,stateid,city from tbl_intranet_city where cid='" + cityid + "'";
    //    DataSet ds5 = new DataSet();
    //    ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    ddl_acc_city.DataSource = ds5;
    //    ddl_acc_city.DataTextField = "city";
    //    ddl_acc_city.DataValueField = "cid";
    //    ddl_acc_city.DataBind();


    //}


    //protected void bind_acc_location(string location)
    //{
    //    sqlstr = "select location from tbl_intranet_cost_center where location='" + location + "'";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    ddl_acc_location.DataSource = ds;
    //    ddl_acc_location.DataTextField = "location";
    //    ddl_acc_location.DataValueField = "location";
    //    ddl_acc_location.DataBind();


    //}
    //----------------------------------------------





    //-----------------------for Permanent address--------------

    protected void ddl_per_country_SelectedIndexChanged(object sender, EventArgs e)
    {


        ddl_per_state.Items.Clear();
        ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_per_city.Items.Clear();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_per_country.SelectedValue != "0")
        {
            bind_per_state(ddl_per_country.SelectedValue);
            ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    protected void ddl_per_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_per_city.Items.Clear();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_per_state.SelectedValue != "0")
        {
            bind_per_city(Convert.ToInt32(ddl_per_state.SelectedValue));
            ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_per_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        ddl_per_country.DataTextField = "countryname";
        ddl_per_country.DataValueField = "countryname";
        ddl_per_country.DataSource = ds3;
        ddl_per_country.DataBind();
        ddl_per_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bind_per_state(string stateid)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
        DataSet ds4 = new DataSet();
        ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        ddl_per_state.DataTextField = "state";
        ddl_per_state.DataValueField = "ID";
        ddl_per_state.DataSource = ds4;
        ddl_per_state.DataBind();
    }
    protected void bind_per_city(int stateid)
    {
        sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        DataSet ds5 = new DataSet();
        ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        ddl_per_city.DataSource = ds5;
        ddl_per_city.DataTextField = "city";
        ddl_per_city.DataValueField = "cid";
        ddl_per_city.DataBind();


    }
    //----------------------------------------------



    //-----------------------for Present address--------------
    protected void ddl_pre_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_pre_state.Items.Clear();
        ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_pre_city.Items.Clear();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_pre_country.SelectedValue != "0")
        {
            bind_pre_state(ddl_pre_country.SelectedValue);
            ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void ddl_pre_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_pre_city.Items.Clear();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_pre_state.SelectedValue != "0")
        {
            bind_pre_city(Convert.ToInt32(ddl_pre_state.SelectedValue));
            ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_pre_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        ddl_pre_country.DataTextField = "countryname";
        ddl_pre_country.DataValueField = "countryname";
        ddl_pre_country.DataSource = ds3;
        ddl_pre_country.DataBind();
        ddl_pre_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bind_pre_state(string stateid)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
        DataSet ds4 = new DataSet();
        ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        ddl_pre_state.DataTextField = "state";
        ddl_pre_state.DataValueField = "ID";
        ddl_pre_state.DataSource = ds4;
        ddl_pre_state.DataBind();

    }
    protected void bind_pre_city(int stateid)
    {
        sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        DataSet ds5 = new DataSet();
        ds5 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        ddl_pre_city.DataSource = ds5;
        ddl_pre_city.DataTextField = "city";
        ddl_pre_city.DataValueField = "cid";
        ddl_pre_city.DataBind();


    }
    //----------------------------------------------



    //-----------------------for Emergency address--------------

    protected void ddl_emergency_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_emergency_state.Items.Clear();
        ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_emergency_city.Items.Clear();
        ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_emergency_country.SelectedValue != "0")
        {
            bind_Emergency_state(ddl_emergency_country.SelectedValue);
            ddl_emergency_state.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void ddl_emergency_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_emergency_city.Items.Clear();
        ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_emergency_state.SelectedValue != "0")
        {
            bind_Emergency_city(Convert.ToInt32(ddl_emergency_state.SelectedValue));
            ddl_emergency_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_Emergency_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        ddl_emergency_country.DataTextField = "countryname";
        ddl_emergency_country.DataValueField = "countryname";
        ddl_emergency_country.DataSource = ds3;
        ddl_emergency_country.DataBind();
        ddl_emergency_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bind_Emergency_state(string stateid)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
        DataSet ds4 = new DataSet();
        ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        ddl_emergency_state.DataTextField = "state";
        ddl_emergency_state.DataValueField = "ID";
        ddl_emergency_state.DataSource = ds4;
        ddl_emergency_state.DataBind();
    }
    protected void bind_Emergency_city(int stateid)
    {
        sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        DataSet ds_emg = new DataSet();
        ds_emg = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        ddl_emergency_city.DataSource = ds_emg;
        ddl_emergency_city.DataTextField = "city";
        ddl_emergency_city.DataValueField = "cid";
        ddl_emergency_city.DataBind();


    }
    //-------------------End---------------------------


    //---------------------Bind Entity-------------------
    //protected void bind_Entity()
    //{
    //    string sqlstr_entity = "select id,entity from entity";
    //    DataSet ds_entity = new DataSet();
    //    ds_entity = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_entity);
    //    ddl_entity.DataSource = ds_entity;
    //    ddl_entity.DataTextField = "entity";
    //    ddl_entity.DataValueField = "id";
    //    ddl_entity.DataBind();
    //    ddl_entity.Items.Insert(0, new ListItem("--Select--", "0"));
    //}
    //-----------------------------------------

    //---------------------Bind Subgroup-------------------
    //protected void bind_subgroup()
    //{
    //    string sqlstr_entity = "select id,subgroup_name from tbl_intranet_subgroup";
    //    ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_entity);
    //    ddl_subgroup.DataSource = ds;
    //    ddl_subgroup.DataTextField = "subgroup_name";
    //    ddl_subgroup.DataValueField = "id";
    //    ddl_subgroup.DataBind();
    //    ddl_subgroup.Items.Insert(0, new ListItem("--Select--", "0"));
    //}
    //-----------------------------------------


    //---------------------Bind Broadgroup-------------------
    protected void bind_broadgroup()
    {
        sqlstr = "select id,broadgroup_name from tbl_intranet_broadgroup";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        ddl_broadgroup.DataSource = ds;
        ddl_broadgroup.DataTextField = "broadgroup_name";
        ddl_broadgroup.DataValueField = "id";
        ddl_broadgroup.DataBind();
        ddl_broadgroup.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    //-----------------------------------------


    protected void txt_probationperiod_TextChanged(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedItem.Text == "Probation")
        {
            if ((doj.Text == "") || (txt_probationperiod.Text == ""))
            {
                txt_confirmationdate.Text = "";
                //txt_probationperiod.Text = "";
            }
            else
            {
                int probitionpriod = Convert.ToInt32(txt_probationperiod.Text);

                txt_confirmationdate.Text = (Convert.ToDateTime(doj.Text).AddMonths(probitionpriod)).ToString("dd-MMM-yyyy");
                //DateTime.Now.AddMonths(probitionpriod).ToString("dd/MMM/yyyy");
            }
        }
    }
    protected void doj_TextChanged(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedItem.Text == "Probation")
        {
            if ((doj.Text == "") || (txt_probationperiod.Text == ""))
            {
                txt_confirmationdate.Text = "";
            }
            else
            {
                int probitionpriod = Convert.ToInt32(txt_probationperiod.Text);
                txt_confirmationdate.Text = (Convert.ToDateTime(doj.Text).AddMonths(probitionpriod)).ToString("dd-MMM-yyyy");
                //DateTime.Now.AddMonths(probitionpriod).ToString("dd/MMM/yyyy");
            }
        }
    }

    protected void bind_emp()
    {
        string sqlstr_entity = "select empcode,empcode+'->'+emp_fname as emp_fname   from tbl_intranet_employee_jobDetails where emp_status!='4'";
        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr_entity);

        ddl_supervisor.DataSource = ds;
        ddl_supervisor.DataValueField = "empcode";
        ddl_supervisor.DataTextField = "emp_fname";
        ddl_supervisor.DataBind();
        ddl_supervisor.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_hod.DataSource = ds;
        ddl_hod.DataValueField = "empcode";
        ddl_hod.DataTextField = "emp_fname";
        ddl_hod.DataBind();
        ddl_hod.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_corp_report_name.DataSource = ds;
        ddl_corp_report_name.DataValueField = "empcode";
        ddl_corp_report_name.DataTextField = "emp_fname";
        ddl_corp_report_name.DataBind();
        ddl_corp_report_name.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void txt_dob_changed(object sender, EventArgs e)
    {
        if (doj.Text != "" && txt_DOB.Text != "")
            if (Convert.ToDateTime(txt_DOB.Text) >= Convert.ToDateTime(doj.Text))
            {
                imgerror.Visible = true;
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Date of Birth should be less than Date of Joining');", true);

                //Response.Write("<script> alert('Please enter valid date(should be less than date of join)')</script>");
            }
            else
            {
                imgerror.Visible = false;
            }
    }



}
