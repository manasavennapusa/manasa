using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menudashboard_onboarding_dashboard : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string companyid, usercode, roleid, image, gender;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        roleid = Session["rolename"].ToString();
        usercode = Session["empcode"].ToString();
        companyid = Session["companyid"].ToString();
        image = Session["PerEmpPhoto"].ToString();
        gender = Session["gender"].ToString();

        if (!IsPostBack)
        {
            bind_EL_CLSL_ML_PL();
            bind_OnBoarded_InProgressEmployee_SubmitToHR_OnBoardCompleted();
        }
    }

    #region Binding of Earned Leave, Maternity Leave,Paternity Leave
    protected void bind_EL_CLSL_ML_PL()
    {
        string sqlstr_11 = @"select  jd.empcode,jd.emp_status,es.id,es.employeestatus  from tbl_intranet_employee_status es
inner join tbl_intranet_employee_jobDetails jd on jd.emp_status=es.id where jd.empcode='" + usercode + "'";
        DataSet ds_11 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_11);
        if (ds_11.Tables[0].Rows.Count > 0)
        {
            if (ds_11.Tables[0].Rows[0]["emp_status"] != "")
            {
                Session["employeestatus"] = ds_11.Tables[0].Rows[0]["emp_status"].ToString();
            }
        }

        DataSet ds = new DataSet();
        DataSet ds_1 = new DataSet();
        DataSet ds_2 = new DataSet();
        DataSet ds_3 = new DataSet();

        string sqlstr = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='EL'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_EL.Text = ds.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_EL.Text = "!!";
        }

        string sqlstr_1 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='PBL'";
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            lbl_ProbL.Text = ds_1.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_ProbL.Text = "!!";
        }

        string sqlstr_2 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='ML'";
        ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            lbl_ML.Text = ds_2.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_ML.Text = "!!";
        }

        string sqlstr_3 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='PL'";
        ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        if (ds_3.Tables[0].Rows.Count > 0)
        {
            lbl_PL.Text = ds_3.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_PL.Text = "!!";
        }


        if (gender == "M")
        {
            row_PL_1.Visible = true;
            row_PL_2.Visible = true;
        }
        else if (gender == "F")
        {
            row_ML_1.Visible = true;
            row_ML_2.Visible = true;
        }
        else
        {
            row_PL_1.Visible = false;
            row_PL_2.Visible = false;
            row_ML_1.Visible = false;
            row_ML_2.Visible = false;
        }

        if (Session["employeestatus"].ToString() == "1")
        {
            row_ProbLev_1.Visible = true;
            row_ProbLev_2.Visible = true;
        }
        else
        {
            row_EarnedLev_1.Attributes.Add("class", "col-md-8 align-right");
            row_EarnedLev_1.Style.Add("text-align", "right");
            row_EarnedLev_2.Attributes.Add("class", "col-md-8");
            row_circle_EarnedLev_1.Style.Add("margin-left", "170px");
            lbl_earned_leave_name.Style.Add("margin-left", "130px");
        }

    }
    #endregion

    #region Binding of OnBoardedEmployees,InProgressEmployees,SubmittedToHR,OnBoardingCompleted
    protected void bind_OnBoarded_InProgressEmployee_SubmitToHR_OnBoardCompleted()
    {
        DataSet ds = new DataSet();
        DataSet ds_1 = new DataSet();
        DataSet ds_2 = new DataSet();
        DataSet ds_3 = new DataSet();

        string sqlstr = @"select COUNT(*)[Onboarded] from tbl_onboarding_templogin";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        lbl_on_boarded_emp.Text = ds.Tables[0].Rows[0]["Onboarded"].ToString();

        string sqlstr_1 = @"select COUNT(*)[InProgress] from tbl_onboarding_templogin where submitstatus='P'";
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        lbl_in_progress_emp.Text = ds_1.Tables[0].Rows[0]["InProgress"].ToString();

        string sqlstr_2 = @"select COUNT(*)[SubmittedToHR] from tbl_onboarding_templogin where submitstatus='S'";
        ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        lbl_sumitted_to_HR.Text = ds_2.Tables[0].Rows[0]["SubmittedToHR"].ToString();

        string sqlstr_3 = @"select COUNT(*)[OnboardCompleted] from tbl_onboarding_templogin  tl
left join tbl_intranet_employee_jobDetails jd on tl.empcode=jd.empcode where jd.card_no is not null";
        ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        lbl_onboarding_completed.Text = ds_3.Tables[0].Rows[0]["OnboardCompleted"].ToString();
    }
    #endregion

    #region Binding of Monthwise Employee Onboard

    [WebMethod]
    public static List<object> GetChartData()
    {
        string query = @"select 'Jan'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=1

union all

select 'Feb'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=2

union all

select 'Mar'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=3

union all

select 'Apr'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=4

union all

select 'May'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=5

union all

select 'Jun'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=6

union all

select 'Jul'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=7

union all

select 'Aug'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=8

union all

select 'Sep'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=9

union all

select 'Oct'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=10

union all

select 'Nov'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=11

union all

select 'Dec'[month],COUNT(*)[total] from tbl_intranet_employee_jobDetails
where YEAR(emp_doj)=YEAR(GETDATE()) and emp_doleaving is null
and MONTH(emp_doj)=12";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "month", "total"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["month"], sdr["total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of OnBoarded Employee Departmentwise
    [WebMethod]
    public static List<object> OnBoardEmpChart()
    {

        string query = @"select distinct dept.department_name,COUNT(*)[TotalEmployee] from tbl_intranet_employee_jobDetails jd
inner join tbl_internate_departmentdetails dept on jd.dept_id=dept.departmentid
where jd.card_no is not null and YEAR(jd.emp_doj)=YEAR(GETDATE()) and jd.emp_doleaving is null 
group by dept.department_name";

        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "department_name","TotalEmployee"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["department_name"],sdr["TotalEmployee"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }

    }
    #endregion

}