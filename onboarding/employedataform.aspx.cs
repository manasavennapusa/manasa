using System;
using System.Data;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;

public partial class onboarding_employedataform : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
       

    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {

        string emp_code = txt_employee.Text.ToString().Trim();
        bind_job_detail(emp_code);
        //bind_contactdetails(emp_code);
        //bind_personalinfo(emp_code);
        //bind_child(emp_code);
        bind_Training_detail(emp_code);
        bind_Education_Qualification(emp_code);
        bind_Exp_detail(emp_code);
        //bind_payrolldetails(emp_code);
        //bind_Professional_Qualification(emp_code);
        BindEmgContactDetails(emp_code);

    }
    protected void bind_Training_detail(string empcode)
    {
        try
        {
            connection = activity.OpenConnection(); sqlstr = "SELECT trainingname,personname,(CASE WHEN fromdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(11), fromdate, 106) END)fromdate ,(CASE WHEN todate='01/01/1900' THEN '' ELSE CONVERT(CHAR(11), todate, 106) END) todate,remarks  FROM tbl_intranet_employee_trainingdetail where empcode = '" + empcode + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            GridTraning.DataSource = ds;
            GridTraning.DataBind();
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

    private void bind_Exp_detail(string emp_code)
    {

        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT [id],empcode,[companyname]as comp_name,[location]as location ,[totalexperience] as total_exp ,[yearfrom] as from_year,[yearto]as to_year,designation FROM tbl_employee_experiencedetails where empcode = '" + txt_employee.Text.ToString() + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            grid_exp.DataSource = ds;
            grid_exp.DataBind();
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



        //throw new NotImplementedException();
    }

    private void create_exp_table()
    {
        throw new NotImplementedException();
    }

    private void BindList_exp()
    {
        throw new NotImplementedException();
    }

    private void BindEmgContactDetails(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "select * from tbl_intranet_employee_emgcontact_details where empcode ='" + emp_code + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            gvemgcontact.DataSource = ds;
            gvemgcontact.DataBind();
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




        //throw new NotImplementedException();
    }

    private void create_emg_contact_table()
    {
        throw new NotImplementedException();
    }

    private void BindList_Emg_Contact()
    {
        throw new NotImplementedException();
    }

    private void bind_Education_Qualification(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT id,empcode,education,school,percentage,yearfrom as from_year,yearto as to_year,specialization  FROM tbl_employee_edcationalqualifications  where empcode = '" + txt_employee.Text.ToString() + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            grid_edu_education.DataSource = ds;
            grid_edu_education.DataBind();
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





       // throw new NotImplementedException();
    }

    private void BindList_acc_edu()
    {
        throw new NotImplementedException();
    }

    private void create_acc_edu_table()
    {
        throw new NotImplementedException();
    }
    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
            string sqlstr = @"SELECT DISTINCT tbl_login_1.empcode, 
emp.uid,emp.card_no, emp.emp_gender, 
emp.emp_fname,emp.emp_m_name, 
emp.emp_l_name, emp.emp_status, 
emp.dept_id,emp.degination_id,EC.pre_add1,EC.per_add1,
desi.designationname,DEPT.department_name,BD.branch_name,
per.dob,per.doa,per.passport_number,per.passportexpiraydate,per.passportissuedate,per.bloodgrp,per.mobile_no,per.maritalstatus,per.email_id,per.no_child,per.f_fname,per.f_mname,per.s_fname,
 emp.Grade, emp.branch_id,
 (CASE WHEN emp.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doj, 101) END)emp_doj, 
 emp.ext_number, emp.photo,emp.Status, tbl_login_1.login_id,tbl_login_1.role,
 (CASE WHEN emp.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.salary_cal_from, 101) END)salary_cal_from,
 (CASE WHEN emp.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), emp.emp_doleaving, 101) END)emp_doleaving,
 emp.reason_leaving,emp.salutation ,emp.employee_type,emp.sub_emp_type,emp.official_email_id,emp.official_mob_no,
 emp.broadgroupid,emp.entityid,emp.supervisorcode,emp.hodcode,emp.corporatereportingcode,emp.probationperiod,
 emp.probationenddate,emp.deputationstartdate,emp.deputationenddate,emp.gradetype,emp.noticeperiod,
 emp.confirmationdate,emp.employee_type,emp.dep_type_id  FROM tbl_login AS tbl_login_1 
  INNER JOIN tbl_intranet_employee_jobDetails emp ON tbl_login_1.empcode = emp.empcode 
  INNER JOIN tbl_intranet_employee_personalDetails   per ON emp.empcode= per.empcode
  INNER JOIN tbl_internate_departmentdetails DEPT ON DEPT.departmentid=emp.dept_id
  INNER JOIN tbl_intranet_branch_detail BD ON emp.branch_id=BD.branch_id
  INNER JOIN tbl_intranet_employee_contactlist EC ON emp.empcode=EC.empcode
   INNER JOIN tbl_intranet_designation desi ON emp.degination_id=desi.id   where emp.empcode = '" + emp_code + "'";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_em.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_jbtitle.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            //lbl_grade.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString() + " " + ds.Tables[0].Rows[0]["emp_m_name"].ToString() + "" + ds.Tables[0].Rows[0]["emp_l_name"].ToString();

            //lbl_dept.Text = ds.Tables[0].Rows[0]["branch_name"].ToString() + " " + ds.Tables[0].Rows[0]["emp_m_name"].ToString() + "" + ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            lbl_bg.Text = ds.Tables[0].Rows[0]["bloodgrp"].ToString() + " " + ds.Tables[0].Rows[0]["emp_m_name"].ToString() + "" + ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            //lbl_doi.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
           // lbl_doe.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString() + " " + ds.Tables[0].Rows[0]["emp_m_name"].ToString() + "" + ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            lbl_location.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_position.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_dob.Text = ds.Tables[0].Rows[0]["dob"].ToString();
            lbl_anniv.Text = ds.Tables[0].Rows[0]["doa"].ToString();
            lbl_pn.Text = ds.Tables[0].Rows[0]["passport_number"].ToString();
            lbl_cha.Text = ds.Tables[0].Rows[0]["pre_add1"].ToString();
            lbl_phd.Text = ds.Tables[0].Rows[0]["pre_Add1"].ToString();

            lbl_emid.Text = ds.Tables[0].Rows[0]["email_id"].ToString();
            lbl_cn.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_ms.Text = ds.Tables[0].Rows[0]["maritalstatus"].ToString();
            lbl_sn.Text = ds.Tables[0].Rows[0]["s_fname"].ToString();
            lbl_noc.Text = ds.Tables[0].Rows[0]["no_child"].ToString();
            lbl_fn.Text = ds.Tables[0].Rows[0]["f_fname"].ToString();
            lbl_mn.Text = ds.Tables[0].Rows[0]["f_mname"].ToString();

           

             DateTime dateTime = DateTime.UtcNow.Date;
             lbldatetime.Text = dateTime.ToString("dd/MM/yyyy");


            //lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd/MMM/yyyy");
            //lbl_doi.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportissuedate"].ToString()).ToString("dd/MMM/yyyy");
            //lbl_doe.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportexpiraydate"].ToString()).ToString("dd/MMM/yyyy");

           if (ds.Tables[0].Rows[0]["emp_doj"].ToString() != "")
            {
                lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd/MMM/yyyy");
          }
            
           if(ds.Tables[0].Rows[0]["passportissuedate"].ToString()!="")
           {

               lbl_doi.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportissuedate"].ToString()).ToString("dd/MMM/yyyy");

          }

        if (ds.Tables[0].Rows[0]["passportexpiraydate"].ToString()!="")
        {
            lbl_doe.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["passportexpiraydate"].ToString()).ToString("dd/MMM/yyyy");
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
}