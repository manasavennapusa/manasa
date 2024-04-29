using System;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Configuration;
using DataAccessLayer;

public partial class admin_viewpromtiondetails : System.Web.UI.Page
{
    public int i;
    DataSet ds = new DataSet();
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string emp_code;
    DataTable dtable = new DataTable();
    DataView dview;
    protected void Page_Load(object sender, EventArgs e)
    {
        emp_code = Request.QueryString["empcode"].ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {    
            }
            else
                Response.Redirect("~/notlogged.aspx");
           
            bind_job_detail(emp_code);
            bind_job_detailOld(emp_code);
        }

    }

    protected void bind_job_detail(string emp_code)
    {
        try
        {
            connection = activity.OpenConnection();
            //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
            string sqlstr = @"SELECT tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.salutation ,tbl_internate_employee_subtype.emp_subtype_name,tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender,tbl_intranet_employee_jobDetails.emp_fname, tbl_intranet_employee_jobDetails.emp_m_name,tbl_intranet_employee_jobDetails.emp_l_name,tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_doj as doj  , tbl_intranet_employee_jobDetails.ext_number,tbl_intranet_employee_jobDetails.Status, tbl_intranet_branch_detail.branch_name, tbl_login.login_id,tbl_intranet_designation.designationname, tbl_intranet_division.division_name, tbl_intranet_role.role,tbl_internate_departmentdetails.department_name,(CASE WHEN tbl_intranet_employee_jobDetails.salary_cal_from='01/01/1900' THEN '' ELSE CONVERT(CHAR(10),tbl_intranet_employee_jobDetails.salary_cal_from, 101) END)salary_cal_from,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doleaving='01/01/1900' THEN '' ELSE CONVERT(CHAR(11), tbl_intranet_employee_jobDetails.emp_doleaving, 106) END)emp_doleaving,tbl_intranet_employee_jobDetails.reason_leaving,tbl_intranet_employee_jobDetails.official_email_id,tbl_intranet_employee_jobDetails.official_mob_no,tbl_internate_employee_subtype.emp_subtype_name,tbl_internate_employee_type.emp_type_name,tbl_internate_department_type.dept_type_name,
  tbl_intranet_employee_jobDetails.cost_center_group_id,tbl_intranet_employee_jobDetails.cost_center_code,tbl_intranet_employee_jobDetails.country,
  tbl_intranet_employee_jobDetails.state,tbl_intranet_employee_jobDetails.city,tbl_intranet_employee_jobDetails.location,
  tbl_intranet_employee_jobDetails.add_cost_center_group_id,tbl_intranet_employee_jobDetails.add_cost_center_code,
  tbl_intranet_employee_jobDetails.add_country,tbl_intranet_employee_jobDetails.add_state,tbl_intranet_employee_jobDetails.add_city,
  tbl_intranet_employee_jobDetails.add_location,tbl_intranet_employee_jobDetails.subgroupid,tbl_intranet_employee_jobDetails.broadgroupid,
  tbl_intranet_employee_jobDetails.entityid,tbl_intranet_employee_jobDetails.supervisorcode,tbl_intranet_employee_jobDetails.hodcode,
  tbl_intranet_employee_jobDetails.corporatereportingcode,tbl_intranet_employee_jobDetails.probationperiod, tbl_intranet_employee_jobDetails.probationenddate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationstartdate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.deputationstartdate, 101) END)deputationstartdate,(CASE WHEN tbl_intranet_employee_jobDetails.deputationenddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.deputationenddate, 106) END)deputationenddate ,tbl_intranet_employee_jobDetails.gradetype,tbl_intranet_employee_jobDetails.noticeperiod,tbl_intranet_employee_jobDetails.confirmationdate as confirmationdate
  FROM  tbl_intranet_employee_jobDetails
  INNER JOIN tbl_login ON tbl_intranet_employee_jobDetails.empcode = tbl_login.empcode 
  INNER JOIN tbl_intranet_role ON tbl_login.role = tbl_intranet_role.id 
  left JOIN tbl_intranet_branch_detail ON tbl_intranet_employee_jobDetails.branch_id = tbl_intranet_branch_detail.Branch_Id 
  left JOIN tbl_intranet_designation ON tbl_intranet_employee_jobDetails.degination_id = tbl_intranet_designation.id 
  left JOIN tbl_intranet_division ON tbl_intranet_employee_jobDetails.division_id = tbl_intranet_division.ID 
  left join tbl_internate_departmentdetails ON tbl_internate_departmentdetails.departmentid = tbl_intranet_employee_jobDetails.dept_id 
  left JOIN tbl_intranet_employee_status ON tbl_intranet_employee_status.id = tbl_intranet_employee_jobDetails.emp_status
  left join tbl_internate_employee_subtype on tbl_internate_employee_subtype.emp_subtype_id=tbl_intranet_employee_jobDetails.sub_emp_type 
  left join tbl_internate_employee_type on tbl_internate_employee_type.emp_type_id=tbl_intranet_employee_jobDetails.employee_type
  left join tbl_internate_department_type on tbl_internate_department_type.dept_type_id=tbl_intranet_employee_jobDetails.dep_type_id
      where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";


            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            txt_card_no.Text = ds.Tables[0].Rows[0]["card_no"].ToString();
            lbl_gender.Text = (ds.Tables[0].Rows[0]["emp_gender"].ToString() == "0") ? "---" : ds.Tables[0].Rows[0]["emp_gender"].ToString();
            txtfirstname.Text = ds.Tables[0].Rows[0]["emp_fname"].ToString();
            txtmiddlename.Text = ds.Tables[0].Rows[0]["emp_m_name"].ToString();
            txtlastname.Text = ds.Tables[0].Rows[0]["emp_l_name"].ToString();
            drpempstatus.Text = ds.Tables[0].Rows[0]["emp_status"].ToString();
            //lbl_alias_name.Text = ds.Tables[0].Rows[0]["alias"].ToString();
            //lbl_suffix1.Text = ds.Tables[0].Rows[0]["suffix1"].ToString().ToUpper();
            //lbl_suffix2.Text = ds.Tables[0].Rows[0]["suffix2"].ToString();
            //lbl_suffix3.Text = ds.Tables[0].Rows[0]["suffix3"].ToString();

            if (drpempstatus.Text.ToString() == "1")
            {
                drpempstatus.Text = "Probation";
            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "2")
            {
                drpempstatus.Text = "Extended Probation";
            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "3")
            {
                drpempstatus.Text = "Confirmed";

            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "4")
            {
                drpempstatus.Text = "Notice Period";
            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "5")
            {
                drpempstatus.Text = "Extension Granted";
            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "6")
            {
                drpempstatus.Text = "Resigned";
            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "7")
            {
                drpempstatus.Text = "Retired";
            }
            if (ds.Tables[0].Rows[0]["emp_status"].ToString() == "8")
            {
                drpempstatus.Text = "Terminated";
            }
            lbl_branch_name.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_desigination.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_dept_type.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_division_name.Text = ds.Tables[0].Rows[0]["division_name"].ToString();
          

            //lbl_grade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            if (ds.Tables[0].Rows[0]["doj"].ToString() != "")
                doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["doj"].ToString()).ToString("dd-MMM-yyyy");
            else doj.Text = "";
           
            txt_login_id.Text = ds.Tables[0].Rows[0]["login_id"].ToString();
            if (ds.Tables[0].Rows[0]["emp_doleaving"].ToString() != "")
                txtdol.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doleaving"].ToString()).ToString("dd-MMM-yyyy");
            if (ds.Tables[0].Rows[0]["salary_cal_from"].ToString() != "")
                txtsalary.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["salary_cal_from"].ToString()).ToString("dd-MMM-yyyy");

            txtreason.Text = ds.Tables[0].Rows[0]["reason_leaving"].ToString();
            //  drprole.SelectedValue = ds.Tables[0].Rows[0]["role"].ToString();
            //============added on 17-12-13======
            lblSalutation.Text = ds.Tables[0].Rows[0]["salutation"].ToString();
            //drpempstatus.Text = ds.Tables[0].Rows[0]["emp_status"].ToString();
            
            txremployee_type.Text = ds.Tables[0].Rows[0]["emp_type_name"].ToString();

            txtstafftype.Text = ds.Tables[0].Rows[0]["emp_subtype_name"].ToString();
     
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


    protected void bind_job_detailOld(string emp_code)
    {
        try
        {

            string sqlstr1 = "select top(1) id from EmpHistory where empcode = '" + emp_code + "' order by id desc";
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
            string id = ds3.Tables[0].Rows[0]["id"].ToString();

            connection = activity.OpenConnection();
            //   string sqlstr = "SELECT tbl_login_1.empcode, tbl_intranet_employee_jobDetails.uid,tbl_intranet_employee_jobDetails.card_no, tbl_intranet_employee_jobDetails.emp_gender, tbl_intranet_employee_jobDetails.emp_fname,tbl_intranet_employee_jobDetails.emp_m_name, tbl_intranet_employee_jobDetails.emp_l_name, tbl_intranet_employee_jobDetails.emp_status,tbl_intranet_employee_jobDetails.emp_roll, tbl_intranet_employee_jobDetails.dept_id, tbl_intranet_employee_jobDetails.division_id,tbl_intranet_employee_jobDetails.degination_id, tbl_intranet_employee_jobDetails.Grade, tbl_intranet_employee_jobDetails.branch_id,(CASE WHEN tbl_intranet_employee_jobDetails.emp_doj='01/01/1900' THEN '' ELSE CONVERT(CHAR(10), tbl_intranet_employee_jobDetails.emp_doj, 101) END)emp_doj, tbl_intranet_employee_jobDetails.ext_number, tbl_intranet_employee_jobDetails.photo,tbl_intranet_employee_jobDetails.Status, tbl_login_1.login_id,tbl_login_1.role  FROM tbl_login AS tbl_login_1 INNER JOIN tbl_intranet_employee_jobDetails ON tbl_login_1.empcode = tbl_intranet_employee_jobDetails.empcode where tbl_intranet_employee_jobDetails.empcode = '" + emp_code + "'";
            string sqlstr = @"select Top 1 EmpHistory.empcode,CONVERT(varchar(20), tbl_intranet_employee_jobDetails.emp_doj, 106) as emp_doj,DateAdded,
COALESCE (dbo.tbl_intranet_employee_jobDetails.emp_fname, '')
+ COALESCE (dbo.tbl_intranet_employee_jobDetails.emp_m_name, '') 
+ COALESCE (dbo.tbl_intranet_employee_jobDetails.emp_l_name, '') AS Name,
tbl_intranet_designation.designationname,
tbl_internate_departmentdetails.department_name,
tbl_intranet_branch_detail.branch_name,
tbl_intranet_employee_status.employeestatus,
tbl_internate_employee_subtype.emp_subtype_name,
convert(varchar(20),tbl_intranet_employee_jobDetails_history.effective_formdate,106)effective_formdate,
ET.emp_type_name
from tbl_intranet_employee_jobDetails 
inner join EmpHistory on EmpHistory.EmpCode=tbl_intranet_employee_jobDetails.empcode
left join tbl_intranet_designation on EmpHistory.DesignationId=tbl_intranet_designation.id
left join tbl_internate_departmentdetails on EmpHistory.DepartmentId=tbl_internate_departmentdetails.departmentid
left join tbl_login on tbl_login.empcode=tbl_intranet_employee_jobDetails.empcode
left join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id = tbl_intranet_employee_jobDetails.branch_id
left join tbl_intranet_employee_status on tbl_intranet_employee_status.id = tbl_intranet_employee_jobDetails.emp_status
left join tbl_internate_employee_type ET on ET.emp_type_id = tbl_intranet_employee_jobDetails.employee_type
left join tbl_internate_employee_subtype on tbl_internate_employee_subtype.emp_subtype_id=tbl_intranet_employee_jobDetails.sub_emp_type
left  join tbl_intranet_employee_jobDetails_history on tbl_intranet_employee_jobDetails_history.empcode=tbl_intranet_employee_jobDetails.empcode
where EmpHistory.EmpCode='" + emp_code + "' and  EmpHistory.id < '" + id + "' order by EmpHistory.Id Desc";


            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            lbl_old_Employeestatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
            lbl_old_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_old_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_old_Department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            //lbl_old_Grade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            lbl_effective_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["effective_formdate"].ToString()).ToString("dd-MMM-yyyy");
            lbl_old_Employee.Text = ds.Tables[0].Rows[0]["emp_type_name"].ToString();
           // lbl_old_Grade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();

            lbl_old_StaffType.Text = ds.Tables[0].Rows[0]["emp_subtype_name"].ToString();

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