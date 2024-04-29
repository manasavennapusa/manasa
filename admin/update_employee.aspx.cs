using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_update_employee : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr, emp_code;
    string qry;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null)
        {
            emp_code = Request.QueryString["empcode"].ToString();

            if (!IsPostBack)
            {
                if (Session["role"] != null)
                {
                 
                }
                else
                    Response.Redirect("~/notlogged.aspx");
                bind_ddlCCgroup();
                bind_branch();
                bind_ddl_aCCgroup();
                bind_departmnt();
                bind_broadgroup();
                Bind_stafftype();
                bind_employeesubtype();
                bind_departmenttype();
                bind_emp();
                bind_job_detail(emp_code);
                //bind_payrolldetails(emp_code);
            }
        }
        else
            Response.Redirect("~/notlogged.aspx");
    }

    private void bind_branch()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"SELECT branch_id,branch_name FROM tbl_intranet_branch_detail";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpbranch.DataSource = ds;
                drpbranch.DataTextField = "branch_name";
                drpbranch.DataValueField = "branch_id";
                drpbranch.DataBind();
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
    private void Bind_stafftype()
    {
        try
        {
            connection = activity.OpenConnection();
            //sqlstr = "select emp_type_code,emp_subtype_name from tbl_internate_employee_subtype where emp_type_code=" + emp_type_code + " order by emp_subtype_name";
            sqlstr = "select distinct emp_subtype_id,emp_subtype_name from tbl_internate_employee_subtype";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList5.DataSource = ds;
                DropDownList5.DataTextField = "emp_subtype_name";
                DropDownList5.DataValueField = "emp_subtype_id";
                DropDownList5.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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


    protected void bind_departmenttype1(string ss)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type where branch_id='" + ss + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            DropDownList6.DataTextField = "dept_type_name";
            DropDownList6.DataValueField = "dept_type_id";
            DropDownList6.DataSource = ds1;
            DropDownList6.DataBind();
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

    #region set the by default values in the drop down list
    protected void drpempstatus_DataBound(object sender, EventArgs e)
    {
        drpempstatus.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    
    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void drpgrade_DataBound(object sender, EventArgs e)
    {
       // drpgrade.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void drpdegination_DataBound(object sender, EventArgs e)
    {
        drpdegination.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void drpdivision_DataBound(object sender, EventArgs e)
    {
        drpdivision.Items.Insert(0, new ListItem("---Select---", "0"));
    }
    protected void drprole_DataBound(object sender, EventArgs e)
    {
        drprole.Items.Insert(0, new ListItem("---Select Role---", "0"));
    }
    #endregion
    #region Bind Employee Details
    protected void ddlSalutation_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((ddlSalutation.SelectedValue == "Ms") || (ddlSalutation.SelectedValue == "Mrs"))
        {
            drpgender.SelectedValue = "FEMALE";
        }
        else
        {
            drpgender.SelectedValue = "MALE";
        }
    }
    protected void drpgender_SelectedIndexChanged(object sender, EventArgs e)
    {
        if ((drpgender.SelectedValue == "FEMALE"))
        {
            ddlSalutation.SelectedValue = "Ms";
        }
        else
        {
            ddlSalutation.SelectedValue = "Mr";
        }
    }

    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name, emp.emp_status, emp.dept_id,emp.division_id,emp.degination_id, emp.Grade as grd, emp.branch_id,emp.emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(20), emp.salary_cal_from, 106) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(20), emp.emp_doleaving, 106) END)emp_doleaving,emp.employee_type,emp.reason_leaving,emp.salutation ,emp.employee_type,emp.sub_emp_type,emp.official_email_id,emp.official_mob_no,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate,emp.employee_type,emp.dep_type_id  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";

            // string qry = "SELECT tbl_login_1.empcode, emp.uid,emp.card_no, emp.emp_gender, emp.emp_fname,emp.emp_m_name, emp.emp_l_name,emp.emp_status, emp.dept_id,emp.division_id,emp.degination_id, emp.Grade, emp.branch_id,(CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,(CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,emp.reason_leaving,emp.salutation,emp.employee_type,emp.sub_emp_type,emp.official_email_id,emp.official_mob_no,emp.cost_center_group_id,emp.cost_center_code,emp.country,emp.state,emp.city,emp.location,emp.add_cost_center_group_id,emp.add_cost_center_code,emp.add_country,emp.add_state,emp.add_city,emp.add_location,emp.subgroupid,emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,emp.confirmationdate,emp.employee_type,emp.dep_type_id,emp.sub_emp_type FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode where emp.empcode = '" + emp_code + "'";
            DataSet ds1 = new DataSet();
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            //TextBox170.Text = ds.Tables[0].Rows[0]["alias"].ToString();

           // TextBox171.Text = ds.Tables[0].Rows[0]["suffix1"].ToString();
            txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            //txt_card_no.Text = ds.Tables[0].Rows[0]["card_no"].ToString();
            if (ds.Tables[0].Rows[0]["emp_gender"].ToString() == "MALE")
            {
                txt_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
                //drpgender.Items.Insert(0, new ListItem("FEMALE", "Male"));
            }
            else if (ds.Tables[0].Rows[0]["emp_gender"].ToString() == "FEMALE")
            {
                txt_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();

            }
            txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
            txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
            txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            drpbranch.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
            if ((ds.Tables[0].Rows[0]["dep_type_id"].ToString() != "") && (ds.Tables[0].Rows[0]["dep_type_id"].ToString() != "0"))
            {

                DropDownList6.SelectedValue = ds.Tables[0].Rows[0]["dep_type_id"].ToString();
            }

            if ((ds.Tables[0].Rows[0]["dept_id"].ToString() != "") && (ds.Tables[0].Rows[0]["dept_id"].ToString() != "0"))
            {
                drpdepartmenttype.SelectedValue = ds.Tables[0].Rows[0]["dept_id"].ToString();

                BindDesignation(ds.Tables[0].Rows[0]["dept_id"].ToString());
            }
            if ((ds.Tables[0].Rows[0]["degination_id"].ToString() != "0") && (ds.Tables[0].Rows[0]["degination_id"].ToString() != ""))
            {
                drpdegination.SelectedValue = ds.Tables[0].Rows[0]["degination_id"].ToString();
                //Bind_grade(Convert.ToInt32(ds.Tables[0].Rows[0]["degination_id"].ToString()));
            }
            if (ds.Tables[0].Rows[0]["emp_doj"].ToString() != "")
                doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
            else doj.Text = "";
            string offmobno1 = ds.Tables[0].Rows[0]["ext_number"].ToString();
            if (offmobno1 != "")
            {
                string[] mob = offmobno1.Split('-');
                if (mob.Length <= 1)
                {
                    txtextccode.Text = "";
                    txtextstdcode.Text = "";
                    txtext.Text = mob[0].ToString();
                }
                else
                {
                    txtextccode.Text = mob[0].ToString();
                    txtextstdcode.Text = mob[1].ToString();
                    txtext.Text = mob[2].ToString();
                }
            }
            else
            {
                txtextccode.Text = "";
                txtextstdcode.Text = "";
                txtext.Text = "";
            }


            ViewState.Add("Photo", ds.Tables[0].Rows[0]["photo"].ToString());
            //hdnphoto.Value = ds.Tables[0].Rows[0]["photo"].ToString();
            //lblphoto.Text = (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["photo"].ToString()) != true) ? "<a href='../upload/photo/" + ds.Tables[0].Rows[0]["photo"].ToString() +
            //       "' target='_blank'>" + ds.Tables[0].Rows[0]["photo"].ToString() + "</a>" : "No photo found";
            drprole.SelectedValue = ds.Tables[0].Rows[0]["role"].ToString();

            txtsalary.Text = ds.Tables[0].Rows[0]["salary_cal_from"].ToString();
            txtdol.Text = ds.Tables[0].Rows[0]["emp_doleaving"].ToString();
            txtreason.Text = ds.Tables[0].Rows[0]["reason_leaving"].ToString();

            //============added on 16-12-13======
            bind_empstatus();
           txt_salutaion.Text = ds.Tables[0].Rows[0]["salutation"].ToString();
            drpempstatus.SelectedValue = ds.Tables[0].Rows[0]["emp_status"].ToString();
            if (drpempstatus.SelectedValue.Trim() == "1")
            {
                lblprob.Text = "Probation End date";
                //trprobationperiod.Visible = true;
                //trprobationdate.Visible = true;
                //trprobationdate2.Visible = true;
                trprobationdate3.Visible = true;

                //trduptstart.Visible = false;
                //trduptenddate.Visible = false;

                txtdol.Text = "";
                trDOL.Visible = false;
                trReasonL.Visible = false;
                if (ds.Tables[0].Rows[0]["probationenddate"].ToString() == "")
                {
                    txt_confirmationdate.Text = "";
                }
                else
                {
                    txt_confirmationdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["probationenddate"]).ToString("dd-MMM-yyyy");
                }

            }
            else
                if (drpempstatus.SelectedValue.Trim() == "3")
                {
                    lblprob.Text = "Confirmation Date";
                    //trprobationperiod.Visible = true;
                    //trprobationdate.Visible = true;
                    //trprobationdate2.Visible = true;
                    trprobationdate3.Visible = true;

                    //trduptstart.Visible = false;
                    //trduptenddate.Visible = false;

                    txtdol.Text = "";
                    trDOL.Visible = false;
                    trReasonL.Visible = false;
                    if (ds.Tables[0].Rows[0]["confirmationdate"].ToString() == "")
                    {
                        txt_confirmationdate.Text = "";
                    }
                    else
                    {
                        txt_confirmationdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["confirmationdate"]).ToString("dd-MMM-yyyy");
                    }
                }
                else
                    if (drpempstatus.SelectedValue.Trim() == "2")
                    {
                        lblprob.Text = "Probation Extended Date";
                        //trprobationperiod.Visible = true;
                        //trprobationdate.Visible = true;
                        //trprobationdate2.Visible = true;
                        trprobationdate3.Visible = true;

                        //trduptstart.Visible = false;
                        //trduptenddate.Visible = false;

                        txtdol.Text = "";
                        trDOL.Visible = false;
                        trReasonL.Visible = false;
                    }
                    else
                        if (drpempstatus.SelectedValue.Trim() == "6" || drpempstatus.SelectedValue.Trim() == "7" || drpempstatus.SelectedValue.Trim() == "8")
                        {
                            trprobationperiod.Visible = false;
                            trprobationdate.Visible = false;
                            trprobationdate2.Visible = false;
                            trprobationdate3.Visible = false;
                            trduptstart.Visible = false;
                            trduptenddate.Visible = false;
                            trReasonL.Visible = true;
                            trDOL.Visible = true;
                        }
                        else if (drpempstatus.SelectedValue.Trim() == "4")
                        {
                            lblprob.Text = "Notice Period Start Date";
                            //trprobationperiod.Visible = true;
                            //trprobationdate.Visible = true;
                            //trprobationdate2.Visible = true;
                            trprobationdate3.Visible = true;

                            //trduptstart.Visible = false;
                            //trduptenddate.Visible = false;

                            txtdol.Text = "";
                            trDOL.Visible = false;
                            trReasonL.Visible = false;

                        }
                        else if (drpempstatus.SelectedValue.Trim() == "5")
                        {
                            lblprob.Text = "Extension Start Date";
                            //trprobationperiod.Visible = true;
                            //trprobationdate.Visible = true;
                            //trprobationdate2.Visible = true;
                            trprobationdate3.Visible = true;

                            //trduptstart.Visible = false;
                            //trduptenddate.Visible = false;

                            txtdol.Text = "";
                            trDOL.Visible = false;
                            trReasonL.Visible = false;
                        }
           
            if ((ds.Tables[0].Rows[0]["noticeperiod"].ToString() == "0") || (ds.Tables[0].Rows[0]["noticeperiod"].ToString() == ""))
            {
                txt_noticePeriod.Text = "";
            }
            else
            {
                txt_noticePeriod.Text = ds.Tables[0].Rows[0]["noticeperiod"].ToString();
            }
            string offmobno = ds.Tables[0].Rows[0]["official_mob_no"].ToString();
            if (offmobno != "")
            {
                string[] mob = offmobno.Split('-');
                if (mob.Length <= 1)
                {
                    txtcountrycode.Text = "";
                    txtoff_mobileno.Text = mob[0].ToString();
                }
                else
                {
                    txtcountrycode.Text = mob[0].ToString();
                    txtoff_mobileno.Text = mob[1].ToString();
                }
            }


            txt_officialemail.Text = ds.Tables[0].Rows[0]["official_email_id"].ToString();
            //if ((ds.Tables[0].Rows[0]["subgroupid"].ToString() == "0") || (ds.Tables[0].Rows[0]["subgroupid"].ToString() == "") || (ds.Tables[0].Rows[0]["subgroupid"] == null))
            //{
            //    ddl_subgroup.SelectedValue = "0";
            //}
            //else
            //{
            //    ddl_subgroup.SelectedValue = ds.Tables[0].Rows[0]["subgroupid"].ToString();
            //}

            if ((ds.Tables[0].Rows[0]["employee_type"].ToString() != "0") && (ds.Tables[0].Rows[0]["employee_type"].ToString() != ""))
            {
                ddl_emp_type.SelectedValue = ds.Tables[0].Rows[0]["employee_type"].ToString();
            }

            if ((ds.Tables[0].Rows[0]["sub_emp_type"].ToString() != "0") && (ds.Tables[0].Rows[0]["sub_emp_type"].ToString() != ""))
            {
                DropDownList5.SelectedValue = ds.Tables[0].Rows[0]["sub_emp_type"].ToString();
            }

            //if ((ds.Tables[0].Rows[0]["employee_type"].ToString() != "") && (ds.Tables[0].Rows[0]["employee_type"].ToString() != "0"))
            //{
            //    ddl_emp_type.SelectedValue = ds.Tables[0].Rows[0]["employee_type"].ToString();
            //    //ddl_semp_type.SelectedValue = ds.Tables[0].Rows[0]["employee_type"].ToString();
            //    bind_employeesubtype(Convert.ToInt16(ds.Tables[0].Rows[0]["employee_type"]));
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

            //drpgrade.SelectedValue = ds.Tables[0].Rows[0]["Grade"].ToString();
            //bind_grade();
            if ((ds.Tables[0].Rows[0]["grd"].ToString() != "0") && (ds.Tables[0].Rows[0]["grd"].ToString() != ""))
            {
                drpgrade.SelectedValue = ds.Tables[0].Rows[0]["grd"].ToString();
                // BindDesignation(ds.Tables[0].Rows[0]["grd"].ToString());
            }
            ddl_supervisor.SelectedValue = ds.Tables[0].Rows[0]["supervisorcode"].ToString();
            ddl_hod.SelectedValue = ds.Tables[0].Rows[0]["hodcode"].ToString();
            ddl_corp_report_name.SelectedValue = ds.Tables[0].Rows[0]["corporatereportingcode"].ToString();


            //if ((ds.Tables[0].Rows[0]["cost_center_group_id"] == null) || (ds.Tables[0].Rows[0]["cost_center_group_id"].ToString() == "0") || (ds.Tables[0].Rows[0]["cost_center_group_id"].ToString() == ""))
            //{
            //    ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_cc_country.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_cc_state.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_cc_city.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_cc_location.Items.Insert(0, new ListItem("--Select--", "0"));

            //}
            //else
            //{
            //    ddl_cc_groupid.SelectedValue = ds.Tables[0].Rows[0]["cost_center_group_id"].ToString();
            //    if ((ds.Tables[0].Rows[0]["cost_center_code"] == null) || (ds.Tables[0].Rows[0]["cost_center_code"].ToString() == "0") || (ds.Tables[0].Rows[0]["cost_center_code"].ToString() == ""))
            //    {
            //        trcc.Visible = false;
            //    }
            //    else
            //    {
            //        bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));
            //        ddl_cc_code.SelectedValue = ds.Tables[0].Rows[0]["cost_center_code"].ToString();
            //        bind_cc(Convert.ToInt32(ds.Tables[0].Rows[0]["cost_center_code"]));
            //        trcc.Visible = true;
            //        //bind_cc_country(Convert.ToInt32(ds.Tables[0].Rows[0]["cost_center_code"]));
            //        //ddl_cc_country.SelectedValue = ds.Tables[0].Rows[0]["country"].ToString();
            //        //ddl_cc_state.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
            //        //ddl_cc_city.SelectedValue = ds.Tables[0].Rows[0]["city"].ToString();
            //        //ddl_cc_location.SelectedValue = ds.Tables[0].Rows[0]["location"].ToString();
            //    }
            //}

            //if ((ds.Tables[0].Rows[0]["add_cost_center_group_id"] == null) || (ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString() == ""))
            //{
            //    ddl_acc_code.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_acc_country.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_acc_state.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_acc_city.Items.Insert(0, new ListItem("--Select--", "0"));
            //    //ddl_acc_location.Items.Insert(0, new ListItem("--Select--", "0"));
            //}
            //else
            //{
            //    ddl_acc_groupid.SelectedValue = ds.Tables[0].Rows[0]["add_cost_center_group_id"].ToString();
            //    if ((ds.Tables[0].Rows[0]["add_cost_center_code"] == null) || (ds.Tables[0].Rows[0]["add_cost_center_code"].ToString() == "0") || (ds.Tables[0].Rows[0]["add_cost_center_code"].ToString() == ""))
            //    {
            //        traddcc.Visible = false;
            //    }
            //    else
            //    {
            //        bind_ddl_acc_code(Convert.ToInt32(ddl_acc_groupid.SelectedValue));
            //        ddl_acc_code.SelectedValue = ds.Tables[0].Rows[0]["add_cost_center_code"].ToString();
            //        bind_acc(Convert.ToInt32(ds.Tables[0].Rows[0]["add_cost_center_code"]));
            //        traddcc.Visible = true;
            //        //bind_acc_country(Convert.ToInt32(ds.Tables[0].Rows[0]["add_cost_center_code"]));
            //        //ddl_acc_country.SelectedValue = ds.Tables[0].Rows[0]["add_country"].ToString();
            //        //ddl_acc_state.SelectedValue = ds.Tables[0].Rows[0]["add_state"].ToString();
            //        //ddl_acc_city.SelectedValue = ds.Tables[0].Rows[0]["add_city"].ToString();
            //        //ddl_acc_location.SelectedValue = ds.Tables[0].Rows[0]["add_location"].ToString();
            //    }
            //}
        }
        catch (Exception ex)
        {
            Output.Log("During Job Details: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void bind_departmnt()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartmenttype.DataTextField = "department_name";
            drpdepartmenttype.DataValueField = "departmentid";
            drpdepartmenttype.DataSource = ds1;
            drpdepartmenttype.DataBind();
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
    protected void bind_departmnt1(string depttype)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails where dept_type_id='"+depttype+"'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartmenttype.DataTextField = "department_name";
            drpdepartmenttype.DataValueField = "departmentid";
            drpdepartmenttype.DataSource = ds1;
            drpdepartmenttype.DataBind();
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

    //protected void bind_payrolldetails(string empcode)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "SELECT * FROM tbl_intranet_employee_payrollDetails  WHERE empcode = '" + empcode + "'";
    //        ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        if (ds.Tables[0].Rows.Count < 1)
    //            return;

    //        //if (ds.Tables[0].Rows[0]["Payroll_Process"].ToString() == "Rupee")
    //        //{
    //        //    DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["Payroll_Process"].ToString();

    //        //}
    //        //else if (ds.Tables[0].Rows[0]["Payroll_Process"].ToString() == "Doller")
    //        //{
    //        //    DropDownList1.SelectedValue = ds.Tables[0].Rows[0]["Payroll_Process"].ToString();

    //        //}
    //        //TextBox29.Text = ds.Tables[0].Rows[0]["Salary_Ac"].ToString();
    //       // TextBox30.Text = ds.Tables[0].Rows[0]["Ifsc_Code"].ToString();
    //        TextBox19.Text = ds.Tables[0].Rows[0]["Account_Type"].ToString();
    //        TextBox20.Text = ds.Tables[0].Rows[0]["Bank_Name"].ToString();
    //        TextBox21.Text = ds.Tables[0].Rows[0]["Bankbranch_Name"].ToString();
    //        TextBox5.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
    //        if (TextBox5.Text != "")
    //        {
    //            RadioButtonList1.SelectedValue = "Yes";
    //            TextBox5.Visible = true;
    //        }
    //        else
    //        {
    //            RadioButtonList1.SelectedValue = "No";
    //            TextBox5.Visible = false;
    //        }
    //        TextBox22.Text = ds.Tables[0].Rows[0]["Adhar_No"].ToString();
    //        if (TextBox22.Text != "")
    //        {
    //            RadioButtonList2.SelectedValue = "Yes";
    //            TextBox22.Visible = true;
    //        }
    //        else
    //        {
    //            RadioButtonList2.SelectedValue = "No";
    //            TextBox22.Visible = false;
    //        }
    //        //TextBox23.Text = ds.Tables[0].Rows[0]["Graduity_Year"].ToString();
    //        //if (TextBox23.Text != "")
    //        //{
    //        //    RadioButtonList3.SelectedValue = "Yes";
    //        //}
    //        //else
    //        //{
    //        //    RadioButtonList3.SelectedValue = "No";
    //        //}
    //        esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
    //        esidesp.Text = ds.Tables[0].Rows[0]["esi_disp"].ToString();
    //        pfno.Text = ds.Tables[0].Rows[0]["pf_no"].ToString();
    //        pfno_dept.Text = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();


    //        if (ds.Tables[0].Rows[0]["Payment_Mode"].ToString() == "Cash")
    //        {
    //            DropDownList2.SelectedValue = ds.Tables[0].Rows[0]["Payment_Mode"].ToString();

    //        }
    //        else if (ds.Tables[0].Rows[0]["Payment_Mode"].ToString() == "Credit Card")
    //        {
    //            DropDownList2.SelectedValue = ds.Tables[0].Rows[0]["Payment_Mode"].ToString();

    //        }
    //        else if (ds.Tables[0].Rows[0]["Payment_Mode"].ToString() == "Debit Card")
    //        {
    //            DropDownList2.SelectedValue = ds.Tables[0].Rows[0]["Payment_Mode"].ToString();

    //        }
    //        ward.Text = ds.Tables[0].Rows[0]["ward"].ToString();
    //        //txt_ptno.Text = ds.Tables[0].Rows[0]["ptno"].ToString();
    //        txt_uan.Text = ds.Tables[0].Rows[0]["uan"].ToString();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During payroll: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    protected string get_country(int countrtyid)
    {
        string Country = "";
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select cid,countryname from tbl_intranet_country_master  where cid='" + countrtyid + "'";
            DataSet ds_country = new DataSet();

            ds_country = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds_country.Tables[0].Rows.Count < 1)
                Country = "";
            else
                Country = ds_country.Tables[0].Rows[0]["countryname"].ToString();
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
        return Country;

    }

    #endregion

    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedValue.Trim() == "4" || drpempstatus.SelectedValue.Trim() == "5" || drpempstatus.SelectedValue.Trim() == "6")
        {
            if (txtdol.Text == "")
            {
                string str11 = "<script> alert('Please enter date of leaving.')</script>";
                ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str11, false);
                txtdol.Focus();
                return;
            }
        }




        string emp_code = Request.QueryString["empcode"].ToString();
        try
        {
            connection = activity.OpenConnection();
            string file_name = "";

            //if (Page.IsValid)
            //{
            //if (f_upload_rep1.GotFile)
            //{
            //    file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
            //    f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/photo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
            //    file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

            //    ViewState.Add("Photo", file_name);

            //}
            //else
            //    ViewState.Add("Photo", file_name);
            //}
            //else
            //    ViewState.Add("Photo", file_name);


            transaction = connection.BeginTransaction();
            edit_Job_detail(emp_code, connection, transaction);
            edit_login_role(emp_code, connection, transaction);
            //  insert_Log_in_detail();
            Session.Add("Inserted_Emp_code", txtempcode.Text);


            transaction.Commit();

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
        //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
        string str = "<script> alert('Employee Details Save sucessfully!!!')</script>";
        Page.RegisterStartupScript("Employee", str.ToString());

        Response.Redirect("empview.aspx?updated=" + emp_code);
    }

    protected void edit_Job_detail(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[58];
        sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.VarChar, 50);
        if (txtempcode.Text == "")
        {
            sqlparam[0].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[0].Value = txtempcode.Text;
        }


        sqlparam[1] = new SqlParameter("@card_no", SqlDbType.VarChar, 100);
        //if (txt_card_no.Text == "")
        //{
        sqlparam[1].Value = System.Data.SqlTypes.SqlString.Null;
        //}
        //else
        //{
        //    sqlparam[1].Value = txt_card_no.Text;
        //}


        sqlparam[2] = new SqlParameter("@emp_gender", SqlDbType.VarChar, 10);
        if (txt_gender.Text == "")
        {
            sqlparam[2].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[2].Value = txt_gender.Text;
        }
        sqlparam[3] = new SqlParameter("@emp_fname", SqlDbType.VarChar, 200);
        if (txtfirstname.Text == "")
        {
            sqlparam[3].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[3].Value = txtfirstname.Text;
        }


        sqlparam[4] = new SqlParameter("@emp_m_name", SqlDbType.VarChar, 50);
        if (txtmiddlename.Text == "")
        {
            sqlparam[4].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[4].Value = txtmiddlename.Text;
        }


        sqlparam[5] = new SqlParameter("@emp_l_name", SqlDbType.VarChar, 50);
        if (txtlastname.Text == "")
        {
            sqlparam[5].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam[5].Value = txtlastname.Text;
        }
        sqlparam[6] = new SqlParameter("@emp_status", SqlDbType.Int);
        if (drpempstatus.SelectedValue == "0")
        {
            sqlparam[6].Value = System.Data.SqlTypes.SqlInt16.Null;
        }
        else
        {
            sqlparam[6].Value = Convert.ToInt32(drpempstatus.SelectedValue);
        }
        sqlparam[7] = new SqlParameter("@dept_id", SqlDbType.Int);
        if (drpdepartmenttype.SelectedValue == "0")
        {
            sqlparam[7].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[7].Value = Convert.ToInt32(drpdepartmenttype.SelectedValue);
        }

        sqlparam[8] = new SqlParameter("@division_id", SqlDbType.Int);
        sqlparam[8].Value = Convert.ToInt32(drpdivision.SelectedValue);
        sqlparam[9] = new SqlParameter("@degination_id", SqlDbType.Int);
        if ((drpdegination.SelectedValue == "0") || (drpdegination.SelectedValue == ""))
        {
            sqlparam[9].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[9].Value = Convert.ToInt32(drpdegination.SelectedValue);
        }



        sqlparam[10] = new SqlParameter("@Grade", SqlDbType.Int);
        if ((drpgrade.SelectedValue == "0") || (drpgrade.SelectedValue == ""))
        {
            sqlparam[10].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[10].Value = Convert.ToInt32(drpgrade.SelectedValue);
        }

        sqlparam[11] = new SqlParameter("@branch_id", SqlDbType.Int);
        if ((drpbranch.SelectedValue == "0") || (drpbranch.SelectedValue == ""))
        {
            sqlparam[11].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[11].Value = Convert.ToInt32(drpbranch.SelectedValue);
        }

        sqlparam[12] = new SqlParameter("@emp_doj", SqlDbType.DateTime);
        if (doj.Text == "")
            sqlparam[12].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[12].Value = doj.Text;
        // sqlparam[12].Value = Convert.ToDateTime((doj.Text.Trim()=="")? "1/1/1900" : doj.Text.Trim());

        sqlparam[13] = new SqlParameter("@ext_number", SqlDbType.VarChar, 50);
        if ((txtextstdcode.Text != "") && (txtext.Text != ""))
        {
            sqlparam[13].Value = txtextccode.Text + "-" + txtextstdcode.Text + "-" + txtext.Text;
        }
        else sqlparam[13].Value = "";

        sqlparam[14] = new SqlParameter("@photo", SqlDbType.VarChar, 100);
        sqlparam[14].Value = "";
        //{
        //    try
        //    {
        //        string strFileName;
        //        string file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
        //        strFileName = flphoto.FileName;
        //        flphoto.PostedFile.SaveAs(Server.MapPath("~/upload/photo/" + file_name + "_" + strFileName));
        //        sqlparam[14].Value = file_name + "_" + strFileName;
        //    }
        //    catch (Exception exc)
        //    {
        //        //lblMsg.Text = exc.Message;
        //    }
        //}
        //else sqlparam[14].Value = "";

        sqlparam[15] = new SqlParameter("@salary_cal_from", SqlDbType.DateTime);
        if (txtsalary.Text == "")
            sqlparam[15].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[15].Value = Convert.ToDateTime(txtsalary.Text);

        sqlparam[16] = new SqlParameter("@emp_doleaving", SqlDbType.DateTime);
        if (txtdol.Text == "")
            sqlparam[16].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            sqlparam[16].Value = Convert.ToDateTime(txtdol.Text);

        sqlparam[17] = new SqlParameter("@reason_leaving", SqlDbType.VarChar, 200);
        sqlparam[17].Value = txtreason.Text;

        sqlparam[18] = new SqlParameter("@salutation", SqlDbType.VarChar, 3);
        sqlparam[18].Value = txt_salutaion.Text;


        sqlparam[19] = new SqlParameter("@probationperiod", SqlDbType.Int);
        sqlparam[20] = new SqlParameter("@probationenddate", SqlDbType.DateTime);
        if (drpempstatus.SelectedItem.Text == "Probation")
        {
            sqlparam[19].Value = System.Data.SqlTypes.SqlInt32.Null;
            sqlparam[20].Value = txt_confirmationdate.Text;
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
        //    sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;
        //}
        //else
        //{
        sqlparam[23].Value = System.Data.SqlTypes.SqlInt32.Null;// ddl_subgroup.SelectedValue;
        //}

        sqlparam[24] = new SqlParameter("@broadgroupid", SqlDbType.Int);
        if ((ddl_broadgroup.SelectedValue == "0") || (ddl_broadgroup.SelectedValue == ""))
        {
            sqlparam[24].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[24].Value = Convert.ToInt32(ddl_broadgroup.SelectedValue);
        }

        sqlparam[25] = new SqlParameter("@entityid", SqlDbType.Int);
        // if ((ddl_entity.SelectedValue == "0") || (ddl_entity.SelectedValue == ""))
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
            sqlparam[26].Value = Convert.ToInt32(ddl_gradetype.SelectedValue);
        }
        sqlparam[27] = new SqlParameter("@official_mob_no", SqlDbType.VarChar, 50);
        if ((txtcountrycode.Text != "") || (txtoff_mobileno.Text != ""))
        {
            sqlparam[27].Value = txtcountrycode.Text + "-" + txtoff_mobileno.Text;
        }
        else sqlparam[27].Value = "";
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

        sqlparam[46] = new SqlParameter("@employee_type", SqlDbType.Int);
        sqlparam[46].Value = Convert.ToInt32(ddl_emp_type.SelectedValue);
        sqlparam[47] = new SqlParameter("@sub_emp_type", SqlDbType.Int);
        if (DropDownList5.SelectedValue != "")
        {
            sqlparam[47].Value = DropDownList5.SelectedValue;
        }
        else
        {
            sqlparam[47].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        sqlparam[48] = new SqlParameter("@dep_type_id", SqlDbType.Int);
        sqlparam[48].Value = Convert.ToInt32(DropDownList6.SelectedValue);
        sqlparam[49] = new SqlParameter("@Landno", SqlDbType.VarChar, 50);
        if ((TextBox17.Text != "") && (TextBox18.Text != ""))
        {
            sqlparam[49].Value = TextBox16.Text + "-" + TextBox17.Text + "-" + TextBox18.Text;
        }
        else sqlparam[49].Value = System.Data.SqlTypes.SqlString.Null;

        sqlparam[50] = new SqlParameter("@alias", SqlDbType.VarChar, 100);
        sqlparam[50].Value = TextBox170.Text;

        sqlparam[51] = new SqlParameter("@suffix1", SqlDbType.VarChar, 100);
        sqlparam[51].Value = TextBox171.Text;

        sqlparam[52] = new SqlParameter("@suffix2", SqlDbType.VarChar, 100);
        sqlparam[52].Value = TextBox172.Text;

        sqlparam[53] = new SqlParameter("@suffix3", SqlDbType.VarChar, 100);
        sqlparam[53].Value = TextBox173.Text;

        sqlparam[54] = new SqlParameter("@effective_formdate", SqlDbType.DateTime);
        if (txt_effectivedate.Text != "")
        {
            sqlparam[54].Value = txt_effectivedate.Text;
        }
        else if (drpempstatus.SelectedValue == "2" || drpempstatus.SelectedValue == "3" || drpempstatus.SelectedValue == "4" || drpempstatus.SelectedValue == "5")
        {
            sqlparam[54].Value = txt_confirmationdate.Text;
        }
        else
        {
            sqlparam[54].Value = txtdol.Text;
        }

        sqlparam[55] = new SqlParameter("@staff_type", SqlDbType.VarChar, 50);
        if ((DropDownList5.SelectedValue == "0") || (DropDownList5.SelectedValue == ""))
        {
            sqlparam[55].Value = System.Data.SqlTypes.SqlInt32.Null;
        }
        else
        {
            sqlparam[55].Value = Convert.ToInt32(DropDownList5.SelectedValue);
        }

        sqlparam[56] = new SqlParameter("@type", SqlDbType.VarChar, 50);
        sqlparam[56].Value = Convert.ToInt32(ddlType.SelectedValue);
      

        sqlparam[57] = new SqlParameter("@remark", SqlDbType.VarChar, 50);
        sqlparam[57].Value = txt_remarks.Text;
       

       // ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_edit_jobdetails", sqlparam);
        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_edit_jobdetails_history", sqlparam);

    }

    protected void edit_login_role(string emp_code, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam = new SqlParameter[2];
        sqlparam[0] = new SqlParameter("@emp_code", SqlDbType.NChar, 20);
        sqlparam[0].Value = emp_code;

        sqlparam[1] = new SqlParameter("@role", SqlDbType.TinyInt);
        sqlparam[1].Value = drprole.SelectedValue;

        string sqlstr = "UPDATE tbl_login SET role=@role WHERE empcode=@emp_code";
        SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr, sqlparam);
    }
    protected void edit_payroll_detail(string empcode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparam2 = new SqlParameter[18];
        sqlparam2[0] = new SqlParameter("@emp_code", SqlDbType.VarChar, 50);
        sqlparam2[0].Value = empcode;
        sqlparam2[1] = new SqlParameter("@Payroll_Process", SqlDbType.VarChar, 50);
        if (DropDownList1.SelectedItem.Text == "")
        {
            sqlparam2[1].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[1].Value = DropDownList1.SelectedItem.Text.Trim().ToString();
        }
        sqlparam2[2] = new SqlParameter("@payment_Mode", SqlDbType.VarChar, 50);
        if (DropDownList2.SelectedItem.Text == "")
        {
            sqlparam2[2].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[2].Value = DropDownList2.SelectedItem.Text.Trim().ToString();
        }
        sqlparam2[3] = new SqlParameter("@salary", SqlDbType.VarChar, 50);
        if (TextBox29.Text == "")
        {
            sqlparam2[3].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[3].Value = TextBox29.Text.Trim().ToString();
        }

        sqlparam2[4] = new SqlParameter("@Ifce", SqlDbType.VarChar, 50);
        if (TextBox30.Text == "")
        {
            sqlparam2[4].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[4].Value = TextBox30.Text.Trim().ToString();
        }

        sqlparam2[5] = new SqlParameter("@Acoount_type", SqlDbType.VarChar, 50);
        if (TextBox19.Text == "")
        {
            sqlparam2[5].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[5].Value = TextBox19.Text.Trim().ToString();
        }

        sqlparam2[6] = new SqlParameter("@Bank_Name", SqlDbType.VarChar, 50);
        if (TextBox20.Text == "")
        {
            sqlparam2[6].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[6].Value = TextBox20.Text.Trim().ToString();
        }

        sqlparam2[7] = new SqlParameter("@BankBranch_Name", SqlDbType.VarChar, 50);
        if (TextBox21.Text == "")
        {
            sqlparam2[7].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[7].Value = TextBox21.Text.Trim().ToString();
        }

        sqlparam2[8] = new SqlParameter("@ward", SqlDbType.VarChar, 50);
        if (ward.Text == "")
        {
            sqlparam2[8].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[8].Value = ward.Text.Trim().ToString();
        }

        sqlparam2[9] = new SqlParameter("@pf_no", SqlDbType.VarChar, 50);
        if (pfno.Text == "")
        {
            sqlparam2[9].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[9].Value = pfno.Text.Trim().ToString();
        }

        sqlparam2[10] = new SqlParameter("@uano", SqlDbType.VarChar, 50);
        if (txt_uan.Text == "")
        {
            sqlparam2[10].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[10].Value = txt_uan.Text.Trim().ToString();
        }

        sqlparam2[11] = new SqlParameter("@pan_no", SqlDbType.VarChar, 50);
        if (panno.Text == "")
        {
            sqlparam2[11].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[11].Value = panno.Text.Trim().ToString();
        }

        sqlparam2[12] = new SqlParameter("@Adhar_no", SqlDbType.VarChar, 50);
        if (TextBox22.Text == "")
        {
            sqlparam2[12].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[12].Value = TextBox22.Text.Trim().ToString();
        }

        sqlparam2[13] = new SqlParameter("@Eligible_year", SqlDbType.VarChar, 50);
        //if (TextBox23.Text == "")
        //{
        sqlparam2[13].Value = System.Data.SqlTypes.SqlString.Null;
        //}
        //else
        //{
        //    sqlparam2[13].Value = TextBox23.Text.Trim().ToString();
        //}



        sqlparam2[14] = new SqlParameter("@p_Mode", SqlDbType.VarChar, 50);
        sqlparam2[14].Value = System.Data.SqlTypes.SqlString.Null;
        sqlparam2[15] = new SqlParameter("@esi_disp", SqlDbType.VarChar, 50);
        if (esidesp.Text == "")
        {
            sqlparam2[15].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[15].Value = esidesp.Text.Trim().ToString();
        }

        sqlparam2[16] = new SqlParameter("@pf_no_dept", SqlDbType.VarChar, 50);
        if (pfno_dept.Text == "")
        {
            sqlparam2[16].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[16].Value = pfno_dept.Text.Trim().ToString();
        }

        sqlparam2[17] = new SqlParameter("@esi_no", SqlDbType.VarChar, 50);
        if (esino.Text == "")
        {
            sqlparam2[17].Value = System.Data.SqlTypes.SqlString.Null;
        }
        else
        {
            sqlparam2[17].Value = esino.Text.Trim().ToString();
        }


        ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_intranet_payrolldetails", sqlparam2);
    }

    protected void resetjobdetails()
    {
        //txt_card_no.Text = "";
        drpgender.SelectedValue = "0";
        txtfirstname.Text = "";
        txtmiddlename.Text = "";
        txtlastname.Text = "";
        drpempstatus.SelectedValue = "0";
        drprole.SelectedValue = "0";
        drpbranch.SelectedValue = "0";
        drpdivision.SelectedValue = "0";
        //drpdegination.SelectedValue = "0";
        // ddl_broadgroup.SelectedValue = "0";
        drpgrade.SelectedValue = "0";
        ddl_gradetype.SelectedValue = "0";
        // drpdepartment.SelectedValue = "0";
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

    protected void bind_empstatus()
    {

        sqlstr = "select id,employeestatus from tbl_intranet_employee_status";
        DataSet ds_empstat = new DataSet();
        ds_empstat = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        drpempstatus.DataSource = ds_empstat;
        drpempstatus.DataValueField = "id";
        drpempstatus.DataTextField = "employeestatus";
        drpempstatus.DataBind();
        //  drpempstatus.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void drpempstatus_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedValue.Trim() == "1")
        {
            lblprob.Text = "Probation End date";
            //trprobationperiod.Visible = true;
            //trprobationdate.Visible = true;
            //trprobationdate2.Visible = true;
            trprobationdate3.Visible = true;
            txt_confirmationdate.Text = ViewState["PDATE"].ToString();
            //trduptstart.Visible = false;
            //trduptenddate.Visible = false;


            trDOL.Visible = false;
            trReasonL.Visible = false;
            txtdol.Text = "";
        }
        else
            if (drpempstatus.SelectedValue.Trim() == "2")
            {
                lblprob.Text = "Probation Extended Date";
                trprobationdate3.Visible = true;
               // endDate = endDate.AddDays(addedDays);
                txt_confirmationdate.Text = (Convert.ToDateTime(ViewState["PDATE"]).AddDays(1)).ToString("dd-MMM-yyyy");
                txtdol.Text = "";
                trDOL.Visible = false;
                trReasonL.Visible = false;
            }
            else
                if (drpempstatus.SelectedValue.Trim() == "3")
                {
                    lblprob.Text = "Confirmed Date";
                    trprobationdate3.Visible = true;
                    txt_confirmationdate.Text = (Convert.ToDateTime(ViewState["PDATE"]).AddDays(1)).ToString("dd-MMM-yyyy");
                    txtdol.Text = "";
                    trDOL.Visible = false;
                    trReasonL.Visible = false;

                   
                }
                else
                    if (drpempstatus.SelectedValue.Trim() == "6" || drpempstatus.SelectedValue.Trim() == "7" || drpempstatus.SelectedValue.Trim() == "8")
                    {
                        trprobationperiod.Visible = false;
                        trprobationdate.Visible = false;
                        trprobationdate2.Visible = false;
                        trprobationdate3.Visible = false;
                        trduptstart.Visible = false;
                        trduptenddate.Visible = false;
                        trReasonL.Visible = true;
                        trDOL.Visible = true;
                    }
                    else if (drpempstatus.SelectedValue.Trim() == "4")
                    {
                        lblprob.Text = "Notice Period Start Date";
                        trprobationdate3.Visible = true;
                        txtdol.Text = "";
                        trDOL.Visible = false;
                        trReasonL.Visible = false;
                    }
                    else
                    {
                        lblprob.Text = "Extension Start Date";
                        trprobationdate3.Visible = true;
                        txtdol.Text = "";
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
        try
        {
            connection = activity.OpenConnection();
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
    protected void bind_cc_code(int accgroupid)
    {
        try
        {
            connection = activity.OpenConnection();
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

    protected void bind_cc(int cc_id)
    {
        try
        {
            connection = activity.OpenConnection();
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
        try
        {
            connection = activity.OpenConnection();
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
    protected void bind_ddl_acc_code(int accgroupid)
    {
        try
        {
            connection = activity.OpenConnection();
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

    protected void bind_acc(int acc_id)
    {
        try
        {
            connection = activity.OpenConnection();
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

    protected void txt_probationperiod_TextChanged(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedValue.Trim() == "2")
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
        //if (!CheckDOJ())
        //    return;
        if (drpempstatus.SelectedValue.Trim() == "2")
        {
            if ((doj.Text == "") || (txt_probationperiod.Text == ""))
            {
                txt_confirmationdate.Text = "";
            }
            else
            {
                int probitionpriod = Convert.ToInt32(txt_probationperiod.Text);
                txt_confirmationdate.Text = (Convert.ToDateTime(doj.Text).AddMonths(probitionpriod)).ToString("MM/dd/yyyy");
                //DateTime.Now.AddMonths(probitionpriod).ToString("dd/MMM/yyyy");
            }
        }
    }

    protected void bind_emp()
    {
        try
        {
            connection = activity.OpenConnection();
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
    //protected void bind_departmenttype()
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select departmentid, department_name from tbl_internate_departmentdetails";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpdepartmenttype.DataTextField = "department_name";
    //        drpdepartmenttype.DataValueField = "departmentid";
    //        drpdepartmenttype.DataSource = ds1;
    //        drpdepartmenttype.DataBind();
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
    //private void bind_grade()
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        sqlstr = "select id,gradename,gradetypeid from tbl_intranet_grade_type";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpgrade.DataTextField = "gradename";
    //        drpgrade.DataValueField = "id";
    //        drpgrade.DataSource = ds1;
    //        drpgrade.DataBind();
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
    #region Bind BroadGroup
    protected void bind_broadgroup()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select id,broadgroup_name from tbl_intranet_broadgroup order by broadgroup_name";
            DataSet bsunitds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (bsunitds.Tables[0].Rows.Count > 0)
            {
                ddl_broadgroup.DataSource = bsunitds;
                ddl_broadgroup.DataTextField = "broadgroup_name";
                ddl_broadgroup.DataValueField = "id";
                ddl_broadgroup.DataBind();
            }
            // ddl_broadgroup.Items.Insert(0, new ListItem("--Select--", "0"));
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
    #endregion

    private void BindDesignation(string deptid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid + " order by designationname";
            DataSet desids = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (desids.Tables[0].Rows.Count > 0)
            {
                drpdegination.DataSource = desids;
                drpdegination.DataTextField = "designationname";
                drpdegination.DataValueField = "id";
                drpdegination.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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

    protected void btnjob_Click(object sender, EventArgs e)
    {
        if (drpempstatus.SelectedItem.Text == "2" || drpempstatus.SelectedItem.Text == "5" || drpempstatus.SelectedItem.Text == "6")
        {
            if (txtdol.Text == "")
            {
                string str = "<script> alert('Please enter date of leaving.')</script>";
                ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str, false);
                txtdol.Focus();
                return;
            }
        }


        if (ddlType.SelectedValue == "0")
        {
             string str = "<script> alert('Please select the Type.')</script>";
             ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str, false);
             ddlType.Focus();
             return;
            
        }


        try
        {
            connection = activity.OpenConnection();
            string file_name = "";

            if (Page.IsValid)
            {
                if (f_upload_rep1.GotFile)
                {
                    file_name = txtempcode.Text + System.DateTime.Now.GetHashCode().ToString();
                    f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/photo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
                    file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();

                    ViewState.Add("Photo", file_name);

                }
                else
                    ViewState.Add("Photo", file_name);
            }
            else
                ViewState.Add("Photo", file_name);
            Session.Add("Inserted_Emp_code", txtempcode.Text);


            //if (duplicate_emp_code() && duplicate_loginID())
            //{
            // if (!CheckDOJ())
            //     return;
            transaction = connection.BeginTransaction();
            edit_Job_detail(txtempcode.Text, connection, transaction);
            edit_login_role(txtempcode.Text, connection, transaction);
            //update_audit_log();
            string _Desig_Hist, _Deprt_Hist, _Role_Hist;
            string st2 = "Select Top 1 * from EmpHistory where EmpCode='" + emp_code + "' order by DateAdded desc";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, st2);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                _Desig_Hist = ds1.Tables[0].Rows[0]["DesignationId"].ToString();
                _Deprt_Hist = ds1.Tables[0].Rows[0]["DepartmentId"].ToString();
                _Role_Hist = ds1.Tables[0].Rows[0]["EmpRole"].ToString();

                if (drpdegination.SelectedValue != _Desig_Hist || drpdepartmenttype.SelectedValue != _Deprt_Hist || drprole.SelectedValue != _Role_Hist)
                {
                    string st = "insert into EmpHistory(EmpCode,DesignationId,DepartmentId,EmpRole,UpdatedBy,DateAdded,status)values('" + txtempcode.Text.Trim() + "','" + drpdegination.SelectedValue.Trim().ToString() + "','" + drpdepartmenttype.SelectedValue.Trim().ToString() + "','" + drprole.SelectedValue.Trim().ToString() + "','" + Session["empcode"].ToString() + "','" + System.DateTime.Today.ToShortDateString() + "',0)";
                    int x = SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, st);
                }
            }

            if (Session["Inserted_Emp_code"] != null)
            {
                string emplyee_Code = Session["Inserted_Emp_code"].ToString();

                //edit_payroll_detail(emplyee_Code, connection, transaction);
                transaction.Commit();
                //  Common.Console.Output.Show("Employee Job Detail has been successfully Saved");
                // resetjobdetails();
                //lbl_msg.Text = "Employee Detail has sucessfully Inserted";
                string str = "<script> alert('Employee Job Detail Saved Successfully!!!')</script>";
                ScriptManager.RegisterStartupScript(dd, dd.GetType(), "xx", str, false);
                //TabContainer1.ActiveTabIndex = 0;

            }
            //}

            //else
            //{
            //    string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
            //    Page.RegisterStartupScript("Employee", str.ToString());
            //}
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
    }
    #region Validate Dupllicate Login & Empcode Function
    public Boolean duplicate_loginID()
    {
        int count;
        connection = activity.OpenConnection();
        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@login_ID", txtempcode.Text.Trim());

        sqlstr = "select count(Login_ID) from tbl_login where Login_ID= @login_ID";
        count = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            // lbl_msg.Text = "Employee Loging ID allready existes Please change Login ID.";

            string str = "<script> alert('Employee Loging ID already exists, Please change Login ID.')</script>";
            ScriptManager.RegisterStartupScript(upempcode, upempcode.GetType(), "xx", str, false);
            return false;

        }
        else
        {
            return true;
        }
    }
    public Boolean duplicate_emp_code()
    {
        int count;

        SqlParameter[] arrParam = new SqlParameter[1];
        arrParam[0] = new SqlParameter("@emp_code", txtempcode.Text.Trim());
        connection = activity.OpenConnection();
        sqlstr = "select count(empcode) from tbl_intranet_employee_jobDetails where empcode= @emp_code";
        count = (int)SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr, arrParam);
        if (count > 0)
        {
            //  lbl_msg.Text = "Employee Code allready existes Please change Emplyee Code.";

            string str = "<script> alert('Employee Code already exists, Please change Employee Code.')</script>";
            // Common.Console.Output.Show("'Employee Code already exists, Please change Employee Code.");

            ScriptManager.RegisterStartupScript(upempcode, upempcode.GetType(), "xx", str, false);
            return false;
        }
        else
        {
            return true;
        }
    }
    #endregion
    //private bool CheckDOJ()
    //{
    //    if (Convert.ToDateTime(doj.Text) < Convert.ToDateTime(DateTime.Now.ToString("dd-MMM-yyyy")))
    //    {
    //        btnjob.Enabled = false;
    //        string str = "<script> alert('DOJ Should not be less than Current Date.')</script>";
    //        ScriptManager.RegisterStartupScript(upl, upl.GetType(), "xx", str, false);
    //        return false;
    //    }
    //    else
    //    {
    //        btnjob.Enabled = true;
    //        return true;
    //    }
    //}
    protected void txtempcode_TextChanged(object sender, EventArgs e)
    {
        //if (duplicate_emp_code() && duplicate_loginID())
        //{
        //}
        //else
        //{

        string str = "<script> alert('Error : Please Enter Employee Code in Job Detail Tab of Employee Master.')</script>";
        Page.RegisterStartupScript("Employee", str.ToString());

        //lbl_msg.Text = "Error : Please Enter Employee Code in Job Detail Tab of Employee Master.";

        //}
    }
    protected void drpdepartmenttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bind_Designation(Convert.ToInt16(drpdepartmenttype.SelectedValue));
    }
    protected void drpdepartmenttype_DataBound(object sender, EventArgs e)
    {
        drpdepartmenttype.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void ddl_emp_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_employeesubtype();
    }
    private void bind_employeesubtype()
    {
        try
        {
            connection = activity.OpenConnection();
            //sqlstr = "select emp_type_code,emp_subtype_name from tbl_internate_employee_subtype where emp_type_code=" + emp_type_code + " order by emp_subtype_name";
            sqlstr = "select distinct emp_subtype_id,emp_subtype_name from tbl_internate_employee_subtype";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                DropDownList5.DataSource = ds;
                DropDownList5.DataTextField = "emp_subtype_name";
                DropDownList5.DataValueField = "emp_subtype_id";
                DropDownList5.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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
    protected void ddl_emp_type_DataBound(object sender, EventArgs e)
    {
        ddl_emp_type.Items.Insert(0, new ListItem("---Select Department---", "0"));
    }
    protected void ddl_semp_type_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_semp_type_DataBound(object sender, EventArgs e)
    {

    }
    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "Yes")
        {
            TextBox5.Visible = true;
        }
        else if (RadioButtonList1.SelectedValue == "No")
        {
            TextBox5.Visible = false;
        }
        else
        {
            TextBox5.Visible = true;
        }
    }
    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonList2.SelectedValue == "Yes")
        {
            TextBox22.Visible = true;
        }
        else if (RadioButtonList2.SelectedValue == "No")
        {
            TextBox22.Visible = false;
        }
        else
        {
            TextBox22.Visible = true;
        }
    }
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmenttype1(drpbranch.SelectedValue);
    }
    protected void drpgrade_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void ddl_gradetype_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    private void Bind_Designation(int deptId)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select id, designationname from tbl_intranet_designation where departmentid = " + deptId + "";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdegination.DataTextField = "designationname";
            drpdegination.DataValueField = "id";
            drpdegination.DataSource = ds1;
            drpdegination.DataBind();

            // drpgrade.Items.Insert(0, new ListItem("--Select--", "0"));
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
    protected void drpdegination_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Bind_grade(Convert.ToInt32(drpdegination.SelectedValue));
    }


    protected void update_audit_log()
    {

        string IPAdd = string.Empty;
        IPAdd = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
        if (string.IsNullOrEmpty(IPAdd))
            IPAdd = Request.ServerVariables["REMOTE_ADDR"];

        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@ip_address", SqlDbType.VarChar, 50);
        sqlparam[1].Value = IPAdd;

        sqlparam[2] = new SqlParameter("@Roles", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["role"].ToString();

        sqlparam[3] = new SqlParameter("@types", SqlDbType.VarChar, 50);
        sqlparam[3].Value = "User Action";

        sqlparam[4] = new SqlParameter("@actions", SqlDbType.VarChar, 150);
        sqlparam[4].Value = "Updated Employee History Manually -" +' '+"Empcode"+' '+ txtempcode.Text;
         
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_audit_log]", sqlparam);

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt1(DropDownList6.SelectedValue);
    }
    protected void bind_departmenttype()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            DropDownList6.DataTextField = "dept_type_name";
            DropDownList6.DataValueField = "dept_type_id";
            DropDownList6.DataSource = ds1;
            DropDownList6.DataBind();
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
    protected void DropDownList6_DataBound(object sender, EventArgs e)
    {
        DropDownList6.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}