using System;
using System.Data;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;


public partial class onboarding_employeeidcard : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string emp_code = txt_employee.Text.ToString();
        bind_job_detail(emp_code);
        bind_personalinfo(emp_code);
        bind_contactdetails(emp_code);
        BindEmgContactDetails(emp_code);


    }
    protected void BindEmgContactDetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr1 = "select top 1 (emg_contactno+' , '+emg_name+' & '+emg_relation) as emgContact from tbl_intranet_employee_emgcontact_details where empcode ='" + empcode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);
            if (ds1.Tables[0].Rows.Count > 0)
            {
                lblemgcontact.Text = ds1.Tables[0].Rows[0]["emgContact"].ToString();
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
    protected void bind_contactdetails(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "SELECT pre_add1, pre_Add2, pre_city, pre_state, pre_country, pre_zip, pre_phone, per_add1, per_add2, per_city, per_state, per_country, per_zip, per_phone, empcode,mode,modeoftransport,emergency_contact_no,emergency_name,emergency_relation,emergency_address1,emergency_address2,emergency_city,emergency_state,emergency_country,emergency_zip FROM tbl_intranet_employee_contactlist where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txt_pre_add1.Text = ds.Tables[0].Rows[0]["pre_add1"].ToString();
            //txt_emergency_contactno.Text = ds.Tables[0].Rows[0]["emergency_contact_no"].ToString();
            //txt_emergency_name.Text = ds.Tables[0].Rows[0]["emergency_name"].ToString();
            //txt_emergency_relation.Text = ds.Tables[0].Rows[0]["emergency_relation"].ToString();
            //  txt_per_add.Text = ds.Tables[0].Rows[0]["per_add1"].ToString();

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
            //sqlstr = "SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,(CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dob, 101) END) dob, (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), doa, 101) END) doa, dlno, s_fname, s_mname, s_lname, s_dob, s_gender, no_child, mobile_no, email_id,bank_name,ac_number,passport_number,bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,(case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode FROM tbl_intranet_employee_personalDetails where empcode = '" + empcode + "'";
            sqlstr = @"SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,
                (CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), dob, 101) END) dob, 
                (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), doa, 101) END) doa, 
                dlno, s_fname, s_mname, s_lname, (CASE WHEN s_dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), s_dob, 101) END) s_dob, s_gender, no_child, mobile_no, email_id,bankbranch,ifsc, (CASE WHEN passportissuedate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11), passportissuedate, 101) END) passportissuedate ,(CASE WHEN passportexpiraydate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(11),passportexpiraydate, 101) END) passportexpiraydate ,
                b.bankname bank_name,ac_number,passport_number,b1.bankname bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,
                (case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode 
                FROM tbl_intranet_employee_personalDetails p

                left outer join tbl_payroll_bank b on 
                p.bank_name=b.branchcode

                left outer join tbl_payroll_bank b1 on
                p.bank_name_reimbursement=b1.branchcode

                where empcode = '" + empcode + "'";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows[0]["bloodgrp"].ToString() == "0" || ds.Tables[0].Rows[0]["bloodgrp"].ToString() == "")
                txtbloodgrp.Text = "";
            else
                txtbloodgrp.Text = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
            //  txtmobileno.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            //txt_bank_name.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
            //txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
            //txt_bankbrachname.Text = ds.Tables[0].Rows[0]["bankbranch"].ToString();
            //txt_ifsc.Text = ds.Tables[0].Rows[0]["ifsc"].ToString();
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
    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
            string sqlstr = "SELECT tbl_intranet_employee_jobDetails.empcode, tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender,tbl_intranet_employee_jobDetails.emp_fname, tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name,tbl_intranet_employee_status.employeestatus,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(12), tbl_intranet_employee_jobDetails.emp_doj, 106) END) doj  , tbl_intranet_employee_jobDetails.ext_number,tbl_intranet_employee_jobDetails.Status, tbl_intranet_branch_detail.branch_name, tbl_intranet_grade.gradename, tbl_login.login_id,tbl_intranet_designation.designationname, tbl_intranet_division.division_name, tbl_intranet_role.role,tbl_internate_departmentdetails.department_name,(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(11), tbl_intranet_employee_jobDetails.emp_doleaving, 106) END)emp_doleaving,tbl_intranet_employee_jobDetails.reason_leaving,tbl_intranet_employee_jobDetails.salutation ,tbl_intranet_employee_jobDetails.official_email_id,tbl_intranet_employee_jobDetails.official_mob_no,tbl_intranet_employee_jobDetails.cost_center_group_id,tbl_intranet_employee_jobDetails.cost_center_code,tbl_intranet_employee_jobDetails.country,tbl_intranet_employee_jobDetails.state,tbl_intranet_employee_jobDetails.city,tbl_intranet_employee_jobDetails.location,tbl_intranet_employee_jobDetails.add_cost_center_group_id,tbl_intranet_employee_jobDetails.add_cost_center_code,tbl_intranet_employee_jobDetails.add_country,tbl_intranet_employee_jobDetails.add_state,tbl_intranet_employee_jobDetails.add_city,tbl_intranet_employee_jobDetails.add_location,tbl_intranet_employee_jobDetails.subgroupid,tbl_intranet_employee_jobDetails.broadgroupid,tbl_intranet_employee_jobDetails.entityid,tbl_intranet_employee_jobDetails.supervisorcode,tbl_intranet_employee_jobDetails.hodcode,tbl_intranet_employee_jobDetails.corporatereportingcode,tbl_intranet_employee_jobDetails.probationperiod, tbl_intranet_employee_jobDetails.probationenddate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationstartdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.deputationstartdate, 101) END)deputationstartdate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationenddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.deputationenddate, 101) END)deputationenddate ,tbl_intranet_employee_jobDetails.gradetype,tbl_intranet_employee_jobDetails.noticeperiod,(CASE WHEN tbl_intranet_employee_jobDetails.confirmationdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.confirmationdate, 101) END)confirmationdate   FROM tbl_internate_departmentdetails INNER JOIN tbl_intranet_grade INNER JOIN tbl_intranet_employee_jobDetails INNER JOIN tbl_login ON tbl_intranet_employee_jobDetails.empcode = tbl_login.empcode INNER JOIN tbl_intranet_role ON tbl_login.role = tbl_intranet_role.id INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id = tbl_intranet_branch_detail.Branch_Id INNER JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id = tbl_intranet_designation.id ON  tbl_intranet_grade.id = tbl_intranet_employee_jobDetails.Grade INNER JOIN tbl_intranet_division ON tbl_intranet_employee_jobDetails.division_id = tbl_intranet_division.ID ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id INNER JOIN tbl_intranet_employee_status ON tbl_intranet_employee_status.id = tbl_intranet_employee_jobDetails.emp_status where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";


            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();

            txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
            // txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
            // txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
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


    protected void btnprint_Click(object sender, EventArgs e)
    {
        Session["ctrl"] = pnl1;
        ClientScript.RegisterStartupScript(this.GetType(), "onclick", "<script language=javascript>window.open('Print.aspx','PrintMe','height=1000px,width=1000px,scrollbars=1');</script>");
    }
}