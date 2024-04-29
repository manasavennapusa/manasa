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
public partial class Admin_company_empmaster : System.Web.UI.Page
{
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
   
    //=========================================================================================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else
                Response.Redirect("~/notlogged.aspx");
            TabContainer1.ActiveTabIndex = 0;

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

                string emp_code = Request.QueryString["empcode"].ToString();
                bind_job_detail(emp_code);
                bind_contactdetails(emp_code);
                bind_personalinfo(emp_code);
                bind_child(emp_code);
                bind_Education_Qualification(emp_code);
                bind_Professional_Qualification(emp_code);
                bind_Exp_detail(emp_code);
                bind_payrolldetails(emp_code);

                if (Request.QueryString["empcode"] == null)
                    hidd_empcode.Value = Session["empcode"].ToString();
                else
                    hidd_empcode.Value = Request.QueryString["empcode"].ToString().Trim();



                bind_employeePaySturctureDetails(emp_code);
        }
        
    }

    //------------- bind the Job Detail of the emp master ----------------------------------------

    protected void bind_job_detail(string emp_code)
    {
     //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
        string sqlstr = "SELECT tbl_intranet_employee_jobDetails.empcode, tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender,tbl_intranet_employee_jobDetails.emp_fname, tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name,tbl_intranet_employee_status.employeestatus,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END) doj  , tbl_intranet_employee_jobDetails.ext_number,tbl_intranet_employee_jobDetails.Status, tbl_intranet_branch_detail.branch_name, tbl_intranet_grade.gradename, tbl_login.login_id,tbl_intranet_designation.designationname, tbl_intranet_division.division_name, tbl_intranet_role.role,tbl_internate_departmentdetails.department_name,(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doleaving, 101) END)emp_doleaving,tbl_intranet_employee_jobDetails.reason_leaving FROM tbl_internate_departmentdetails INNER JOIN tbl_intranet_grade INNER JOIN tbl_intranet_employee_jobDetails INNER JOIN tbl_login ON tbl_intranet_employee_jobDetails.empcode = tbl_login.empcode INNER JOIN tbl_intranet_role ON tbl_login.role = tbl_intranet_role.id INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id = tbl_intranet_branch_detail.Branch_Id INNER JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id = tbl_intranet_designation.id ON  tbl_intranet_grade.id = tbl_intranet_employee_jobDetails.Grade INNER JOIN tbl_intranet_division ON tbl_intranet_employee_jobDetails.division_id = tbl_intranet_division.ID ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id INNER JOIN tbl_intranet_employee_status ON tbl_intranet_employee_status.id = tbl_intranet_employee_jobDetails.emp_status where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
        
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text ,sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        txt_card_no.Text = ds.Tables[0].Rows[0]["card_no"].ToString();
        lbl_gender.Text = (ds.Tables[0].Rows[0]["emp_gender"].ToString() == "0") ? "---" : ds.Tables[0].Rows[0]["emp_gender"].ToString();
        txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
        txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
        txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
        drpempstatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
        
        lbl_branch_name.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
        lbl_desigination.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        lbl_dept_name.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
        lbl_division_name.Text = ds.Tables[0].Rows[0]["division_name"].ToString();

        lbl_emp_role.Text = ds.Tables[0].Rows[0]["role"].ToString();

        lbl_grade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
        doj.Text = ds.Tables[0].Rows[0]["doj"].ToString();
        txtext.Text = ds.Tables[0].Rows[0]["ext_number"].ToString();
        txt_login_id.Text = ds.Tables[0].Rows[0]["login_id"].ToString();

        txtdol.Text = ds.Tables[0].Rows[0]["emp_doleaving"].ToString();
        txtsalary.Text = ds.Tables[0].Rows[0]["salary_cal_from"].ToString();
        txtreason.Text = ds.Tables[0].Rows[0]["reason_leaving"].ToString();   
      //  drprole.SelectedValue = ds.Tables[0].Rows[0]["role"].ToString();
    }

    //------------Bind Payroll Details of Employee-----------------
    protected void bind_payrolldetails(string empcode)
    {
        string sqlstr = "SELECT empcode,esi_no,esi_disp,pf_no,pf_no_dept,pan_no,ward FROM tbl_intranet_employee_payrollDetails  WHERE empcode = '" + empcode + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
        esidesp.Text = ds.Tables[0].Rows[0]["esi_disp"].ToString();
        pfno.Text = ds.Tables[0].Rows[0]["pf_no"].ToString();
        pfno_dept.Text = ds.Tables[0].Rows[0]["pf_no_dept"].ToString();
        panno.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
        ward.Text = ds.Tables[0].Rows[0]["ward"].ToString();
    }

    protected void bind_contactdetails(string empcode)
    {
        sqlstr = "SELECT pre_add1, pre_Add2, pre_city, pre_state, pre_country, pre_zip, pre_phone, per_add1, per_add2, per_city, per_state, per_country, per_zip, per_phone, empcode,mode,modeoftransport FROM tbl_intranet_employee_contactlist where empcode = '" + empcode + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        txt_pre_add1.Text = ds.Tables[0].Rows[0]["pre_add1"].ToString();       
        txt_pre_add2.Text = ds.Tables[0].Rows[0]["pre_Add2"].ToString();
        txt_pre_city.Text = ds.Tables[0].Rows[0]["pre_city"].ToString();
        txt_pre_state.Text = ds.Tables[0].Rows[0]["pre_state"].ToString();
        txt_pre_country.Text = ds.Tables[0].Rows[0]["pre_country"].ToString();
        txt_pre_zip.Text = ds.Tables[0].Rows[0]["pre_zip"].ToString();
        txt_pre_phone.Text = ds.Tables[0].Rows[0]["pre_phone"].ToString();
        txt_per_add1.Text = ds.Tables[0].Rows[0]["per_add1"].ToString();
        txt_per_add2.Text = ds.Tables[0].Rows[0]["per_add2"].ToString();
        txt_per_city.Text = ds.Tables[0].Rows[0]["per_city"].ToString();
        txt_per_state.Text = ds.Tables[0].Rows[0]["per_state"].ToString();
        txt_per_country.Text = ds.Tables[0].Rows[0]["per_country"].ToString();
        txt_per_zip.Text = ds.Tables[0].Rows[0]["per_zip"].ToString();
        txt_per_phone.Text = ds.Tables[0].Rows[0]["per_phone"].ToString();
        if (ds.Tables[0].Rows[0]["mode"].ToString() == "1")
        {
            
            lblmodeoftransport.Text = "Company Vehicle";
            txtmodeoftransport.Text = ds.Tables[0].Rows[0]["modeoftransport"].ToString();
        }
        else
        {
            lblmodeoftransport.Text = "Own Vehicle";
        }
    }

    protected void bind_personalinfo(string empcode)
    {
        //sqlstr = "SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,(CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dob, 101) END) dob, (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), doa, 101) END) doa, dlno, s_fname, s_mname, s_lname, s_dob, s_gender, no_child, mobile_no, email_id,bank_name,ac_number,passport_number,bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,(case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode FROM tbl_intranet_employee_personalDetails where empcode = '" + empcode + "'";
        sqlstr = @"SELECT empcode, f_fname, f_mname, f_lname, m_fname, m_mname, m_lname, bloodgrp, maritalstatus, religion,
                (CASE WHEN dob = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dob, 101) END) dob, 
                (CASE WHEN doa = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), doa, 101) END) doa, 
                dlno, s_fname, s_mname, s_lname, s_dob, s_gender, no_child, mobile_no, email_id,
                b.bankname bank_name,ac_number,passport_number,b1.bankname bank_name_reimbursement,ac_number_reimbursement,paymentmode as pay,
                (case when paymentmode=0 then 'Bank' else case when paymentmode='1' then 'Cheque' else 'Cash' end end) paymentmode 
                FROM tbl_intranet_employee_personalDetails p

                left outer join tbl_payroll_bank b on 
                p.bank_name=b.branchcode

                left outer join tbl_payroll_bank b1 on
                p.bank_name_reimbursement=b1.branchcode

                where empcode = '" + empcode + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
        {
            paymentmode.Visible = false;
            return;
        }
        txt_f_f_name.Text = ds.Tables[0].Rows[0]["f_fname"].ToString() + ' ' + ds.Tables[0].Rows[0]["f_mname"].ToString() + ' ' + ds.Tables[0].Rows[0]["f_lname"].ToString();
        
        txt_m_fname.Text = ds.Tables[0].Rows[0]["m_fname"].ToString() + ' ' + ds.Tables[0].Rows[0]["m_lname"].ToString() + ' ' + ds.Tables[0].Rows[0]["m_mname"].ToString();
      
        txtbloodgrp.Text = ds.Tables[0].Rows[0]["bloodgrp"].ToString();
        txt_DOB.Text = ds.Tables[0].Rows[0]["dob"].ToString();
        ddlpersonalstatus.Text = (ds.Tables[0].Rows[0]["maritalstatus"].ToString() == "0") ? "----" : ds.Tables[0].Rows[0]["maritalstatus"].ToString();
        
        txtrelg.Text = ds.Tables[0].Rows[0]["religion"].ToString();
        txt_doa.Text = ds.Tables[0].Rows[0]["doa"].ToString();
        txt_dl_no.Text = ds.Tables[0].Rows[0]["dlno"].ToString();
        txt_sp_fname.Text = ds.Tables[0].Rows[0]["s_fname"].ToString() + ' ' + ds.Tables[0].Rows[0]["s_mname"].ToString() + ' ' + ds.Tables[0].Rows[0]["s_lname"].ToString();
    
        txtmobileno.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
        txt_email.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
        txt_bank_name.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
        txt_bank_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
        txt_passportno.Text = ds.Tables[0].Rows[0]["passport_number"].ToString();
        if (ddlpersonalstatus.Text.ToString() == "Married")
        {
            tbl1.Visible = true;
        }
       if (ddlpersonalstatus.Text.ToString() == "Unmarried") 
        {
            tbl1.Visible = false;
        }
        lblpaymentmode.Text = ds.Tables[0].Rows[0]["paymentmode"].ToString();
        txt_bank_name_reimbursement.Text = ds.Tables[0].Rows[0]["bank_name_reimbursement"].ToString();
        txt_bank_ac_reimbursement.Text = ds.Tables[0].Rows[0]["ac_number_reimbursement"].ToString();

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["pay"]) == 0)
        {
            paymentmode.Visible = true;
        }
        else
        {
            paymentmode.Visible = false;
        }
    }

    protected void bind_child(string empcode)
    {
        string sqlstr = "select id,child_name ,(CASE WHEN dob='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), dob, 101) END)child_dob from tbl_intranet_employee_childrendetail where empcode ='" + empcode + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_child.DataSource = ds;
        grid_child.DataBind();
    }

    protected void bind_Education_Qualification(string empcode)
    {
        sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year  FROM tbl_employee_edcationalqualifications  where empcode = '" + empcode + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_edu_education.DataSource = ds;
        grid_edu_education.DataBind();

    }
    protected void bind_Professional_Qualification(string empcode)
    {
        sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year  FROM tbl_employee_professionalqualifications where empcode = '" + empcode + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_Pro_education.DataSource = ds;
       grid_Pro_education.DataBind();

    }
    
    protected void bind_Exp_detail(string empcode)
    {
        sqlstr = "SELECT [id],empcode,[companyname]as comp_name,[location]as location ,[totalexperience] as total_exp ,[yearfrom] as from_year,[yearto]as to_year FROM tbl_employee_experiencedetails where empcode = '" + empcode + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        grid_exp.DataSource = ds;
        grid_exp.DataBind();
    }
    protected void bind_employeePaySturctureDetails(string empcode)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = empcode;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_paystructuredetails_masterview]", sqlparam);

        if (ds.Tables[0].Rows.Count > 0)
        {
            empCode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            empName.Text = ds.Tables[0].Rows[0]["name"].ToString();
            empBranch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            empDepartment.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            empDesignation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_mth_yr.Text = ds.Tables[0].Rows[0]["FROM_MONTH"].ToString() + " " + ds.Tables[0].Rows[0]["FROM_YEAR"].ToString();
            lbl_mth_yr_t.Text = ds.Tables[0].Rows[0]["MONTH_YEAR"].ToString();
            lbl_pf.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["pf"])) ? "Yes" : "No";
            lbl_esi.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["esi"])) ? "Yes" : "No";

            empgrid.DataSource = ds.Tables[1];
            empgrid.DataBind();
        }
    }
}
