using Common.Console;
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
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menudashboard_attendance_dashboard : System.Web.UI.Page
{
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string companyid, usercode, roleid, rolename, image, dept_value, gender;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        roleid = Session["role"].ToString();
        rolename = Session["rolename"].ToString();
        usercode = Session["empcode"].ToString();
        companyid = Session["companyid"].ToString();
        image = Session["PerEmpPhoto"].ToString();
        gender = Session["gender"].ToString();

        if (!IsPostBack)
        {
            bind_EL_CLSL_ML_PL();
            BindNumberOfReportees();
            BindNumberOfReporteesPresent();
            BindIntoColumnChartTotal();
            BindIntoColumnChartPresent();
            BindDept();
            GetAttendance();
            BindIntoEmpPieChartData1();
            BindIntoEmpPieChartData2();
            BindIntoEmpPieChartData3();
            BindMyCompOff();
            BindMyHolidayWork();

            BindMyAbsentEmpAttendance();
            BindAbsentEmpAttendance();
            BindIntoColumnChartDepartment1AttendanceTotal();
            BindIntoColumnChartDepartment1AttendancePresent();

            BindIntoColumnChartDepartment1AttendanceAbsent();
            bind_EmployeeMonthwise_Attendance();

            bind_Intime();
            bind_Outtime();
        }
        if (roleid == "13")
        {
            row_5.Visible = true;
        }
        else if (roleid == "1")
        {
            row_5.Visible = true;
            row_5_col_1.Visible = false;
        }
        else
        {
            row_2.Visible = true;
            row_3.Visible = true;
            row_4.Visible = true;
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

    #region Binding Of My Reportee Balance

    protected void BindNumberOfReportees()
    {
        string adminCode = Session["empcode"].ToString();
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode)
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2') and av.app_reportingmanager='" + adminCode + "' AND av.status=1";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmpReportee"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpReportee"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            //Response.Redirect("../Error.aspx");
            Output.Show("Error occured while fetching reportees!");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindNumberOfReporteesPresent()
    {
        int totlEmployees;
        string adminCode = Session["empcode"].ToString();
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode)
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101)
where
ea.MODE in ('P', 'MM', 'A/P') and av.app_reportingmanager= '" + adminCode + "' and av.status=1";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmpReporteePresent"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpReporteePresent"]).ToString();

            int totlPresnt = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);
            Session["prsntEmployee2"] = totlPresnt;
            string totlEmpls = (string)Session["totalEmpReportee"];
            if (Convert.ToInt32(totlEmpls) > 0)
                totlEmployees = Convert.ToInt32(totlEmpls);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresnt) / totlEmployees) * 100;
            Session["totlPrsntinDeciRep"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeciRep"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            Session["totalPresentEmpRep"] = totlPrsntinPrcnt;
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Error occured while fetching reportees!");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindMyAbsentEmpAttendance()
    {
        decimal value1 = decimal.Parse(Session["totalEmpReportee"].ToString());
        int value1_1 = Convert.ToInt32(value1);

        decimal value2 = decimal.Parse(Session["totalEmpReporteePresent"].ToString());
        int value2_1 = Convert.ToInt32(value2);

        decimal value3 = decimal.Parse(Session["totlPrsntinDeciRep"].ToString());
        int value3_1 = Convert.ToInt32(value3);


        int result_1 = value1_1 - value2_1;
        int result_2 = 100 - value3_1;

        absentEmployeeReportee.Text = result_1.ToString();
        absentEmployeeReporteePrcnt.Text = result_2.ToString() + "%";
    }

    #endregion

    #region Binding Of Attendance

    protected void BindIntoColumnChartTotal()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode) from  dbo.tbl_intranet_employee_jobDetails ej 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["totalEmp"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmp"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindIntoColumnChartPresent()
    {
        int totlEmployees;
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select count(ej.empcode) from tbl_intranet_employee_jobDetails ej 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) where ea.MODE in ('P', 'MM', 'A/P')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            int totlPresnt = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);
            Session["prsntEmployee1"] = totlPresnt;
            string totlEmpls = (string)Session["totalEmp"];
            if (Convert.ToInt32(totlEmpls) > 0)
                totlEmployees = Convert.ToInt32(totlEmpls);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresnt) / totlEmployees) * 100;
            Session["totlPrsntinDeci"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeci"];
            string totlPrsntinPrcnt = d.ToString() + "%";
            Session["totalPresentEmp"] = totlPrsntinPrcnt;
            string test = (Session["totalPresentEmp"]).ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindAbsentEmpAttendance()
    {
        decimal value1 = decimal.Parse(Session["totalEmp"].ToString());
        int value1_1 = Convert.ToInt32(value1);

        decimal value2 = decimal.Parse(Session["prsntEmployee1"].ToString());
        int value2_1 = Convert.ToInt32(value2);

        decimal value3 = decimal.Parse(Session["totlPrsntInDeci"].ToString());
        int value3_1 = Convert.ToInt32(value3);

        int result_1 = 100 - value3_1;
        int result_2 = value1_1 - value2_1;

        lblAbsentEmpInPrcnt.Text = result_1.ToString() + "%";
        absentEmployee.Text = result_2.ToString();
    }

    #endregion

    #region  Binding Of Department wise Attendance

    private void BindDept()
    {
        DataSet ds_dept = null;
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        string query = @"select departmentid,department_name from tbl_internate_departmentdetails";
        ds_dept = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        if (ds_dept.Tables[0].Rows.Count < 1)
            return;
        ddl_department.DataSource = ds_dept;
        ddl_department.DataTextField = "department_name";
        ddl_department.DataValueField = "departmentid";
        ddl_department.DataBind();
        ddl_department.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_department.SelectedValue = ds_dept.Tables[0].Rows[0]["departmentid"].ToString();
    }

    protected void ddl_department_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindIntoColumnChartDepartment1AttendanceTotal();
        BindIntoColumnChartDepartment1AttendancePresent();
        BindIntoColumnChartDepartment1AttendanceAbsent();
    }

    protected void BindIntoColumnChartDepartment1AttendanceTotal()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        if (ddl_department.SelectedValue == "0")
        {
            dept_value = "4";
        }
        else
        {
            dept_value = ddl_department.SelectedValue;
        }
        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d on d.departmentid = jd.dept_id
INNER JOIN tbl_login as L on jd.empcode = L.empcode

where emp_doleaving is null and jd.status=1 and jd.emp_status!='2' and L.role not in ('2') and jd.dept_id='" + dept_value.Trim() + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            string qry_deptName = @"select department_name from tbl_internate_departmentdetails where departmentid = '" + dept_value.Trim() + "'";
            DataSet ds_deptName = SQLServer.ExecuteDataset(connection, CommandType.Text, qry_deptName);
            if (ds_deptName.Tables[0].Rows.Count < 1 || ds.Tables[0].Rows.Count < 1)
                return;
            Session["dept_name"] = ds_deptName.Tables[0].Rows[0]["department_name"].ToString();

            Session["totalEmpDept1"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["totalEmpDept1"]).ToString();
            if (ds.Tables[0].Rows[0]["column1"].ToString() == "0")
            {
                //tdRecruitment.Visible = false;
                //tdRecruitment0.Visible = true;
            }
            else
            {
                //tdRecruitment.Visible = true;
                //tdRecruitment0.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void BindIntoColumnChartDepartment1AttendancePresent()
    {
        int totlEmployees;
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(jd.empcode) from dbo.tbl_intranet_employee_jobDetails jd 
inner join dbo.tbl_internate_departmentdetails d
on d.departmentid = jd.dept_id
inner join dbo.tbl_payroll_employee_attendence_detail at
on at.empcode = jd.empcode
where jd.dept_id='" + dept_value.Trim() + "' and CONVERT(varchar(10),at.date,102) = CONVERT(varchar(10),getdate(),102) AND at.MODE in ('P', 'MM', 'A/P')";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            int totlPresntDept1 = Convert.ToInt32(ds.Tables[0].Rows[0]["column1"]);

            Session["prsntEmployee01"] = totlPresntDept1;
            string totlEmplsDept1 = (string)Session["totalEmpDept1"];
            if (Convert.ToInt32(totlEmplsDept1) > 0)
                totlEmployees = Convert.ToInt32(totlEmplsDept1);
            else
                totlEmployees = 1;
            double totlPrsntinDeciml = ((double)(totlPresntDept1) / totlEmployees) * 100;
            Session["totlPrsntinDeciDept1"] = Math.Round(totlPrsntinDeciml, 2);
            double d = (double)Session["totlPrsntinDeciDept1"];
            Session["presentempdept"] = d.ToString();
            string totlPrsntinPrcnt = d.ToString() + "%";
            //Session["totalPresentEmp"] = totlPrsntinPrcnt;

            Session["totalPresentEmpDept1"] = totlPrsntinPrcnt;
            string test = (Session["totalPresentEmpDept1"]).ToString();

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    protected void BindIntoColumnChartDepartment1AttendanceAbsent()
    {
        int percpres, percabs;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            float total = float.Parse(Session["totalEmpDept1"].ToString());
            float present = float.Parse(Session["prsntEmployee01"].ToString());
            float absent = total - present;
            int result = Convert.ToInt32(absent);
            string result_1 = result.ToString();
            Session["deptwiseabsentemp"] = result_1.ToString();

            float percpresent = (present / total) * 100;
            if (percpresent.ToString() != "NaN")
            {
                percpres = Convert.ToInt32(percpresent);
            }
            else
            {
                percpres = 0;
            }
            Session["presentpercnt"] = percpres.ToString() + "%";

            float perabsent = (absent / total) * 100;
            if (perabsent.ToString() != "NaN")
            {
                percabs = Convert.ToInt32(perabsent);
            }
            else
            {
                percabs = 0;
            }
            Session["absentpercnt"] = percabs.ToString() + "%";
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    #endregion

    #region  Binding Of Team Attendance

    private void GetAttendance()
    {
        try
        {
            connection = activity.OpenConnection();
            //            string sqlstr = @"select ej.empcode empcode,CONVERT(VARCHAR(8),ea.INTIME,108) AS INTIME,CONVERT(VARCHAR(8),ea.OUTTIME,108) AS OUTTIME,CAST((DATEDIFF(MI,ea.INTIME, ea.OUTTIME)/60.0) as decimal(18,2)) AS MinuteDiff 
            //from tbl_intranet_employee_jobDetails ej 
            //inner join tbl_employee_approvers ep on ep.empcode=ej.empcode  
            //left join tbl_intranet_designation dg on dg.id=ej.degination_id 
            //INNER JOIN tbl_login as L on ej.empcode = L.empcode
            //left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
            //where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2') and ep.app_reportingmanager='" + usercode + "' and ep.status=1 order by emp_fname";

            string sqlstr = @"select distinct ej.empcode,RIGHT(Convert(VARCHAR(20), atd.INTIME,100),7) AS INTIME,
RIGHT(Convert(VARCHAR(20), atd.OUTTIME,100),7) AS OUTTIME,
Convert(time(0),(Convert(datetime,atd.OUTTIME) - Convert(datetime,atd.INTIME)),8)[TotalHours]
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode  
left join tbl_payroll_employee_attendence_detail atd on atd.EMPCODE=ej.empcode 
where emp_doleaving is null and ep.app_reportingmanager='" + usercode + "' and ep.status=1 and YEAR(DATE)=YEAR(GETDATE()) and MONTH(DATE)=MONTH(GETDATE()) and DAY(DATE)=DAY(GETDATE())";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            Session["teamReportees"] = ds;
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<table class='width-100'>");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    str.Append("<tr>");
                    str.Append("<td class='width-25 text-center p-3px pl-10px'><span>" + row["empcode"].ToString() + "</span></td>");
                    str.Append("<td class='width-25 text-center p-3px pl-15px'><span>" + row["INTIME"].ToString() + "</span></td>");
                    str.Append("<td class='width-25 text-center p-3px'><span>" + row["OUTTIME"].ToString() + "</span></td>");
                    str.Append("<td class='width-25 text-center p-3px'><span>" + row["TotalHours"].ToString() + "</span></td>");
                    str.Append("</tr>");
                }
            }
            str.Append("</table>");
            Session["TA"] = str.ToString();
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

    #region  Binding Of My Attendance(Month-Wise)

    protected void BindIntoEmpPieChartData1()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            string sqlstrShiftId = @"select count(ad.intime) from tbl_payroll_employee_attendence_detail ad 
LEFT join tbl_attendance_employeecyclemapping am on am.empcode = ad.EMPCODE 
inner join tbl_leave_attendance_rule ar on ar.company_id = ad.company_id 
inner join tbl_leave_shift sft on sft.shiftid = ar.shiftid 
where CONVERT(varchar(20), ad.intime, 108) is not null 
and ad.empcode='" + usercode.ToString().Trim() + "' and datepart(Month, ad.DATE) = datepart(month,getdate()) and convert(varchar(20), (ad.intime - ar.latein), 108) <= sft.starttime";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstrShiftId);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            Session["Emp_log1"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["Emp_log1"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void BindIntoEmpPieChartData2()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(ad.intime) from tbl_payroll_employee_attendence_detail ad 
LEFT join tbl_attendance_employeecyclemapping am on am.empcode = ad.EMPCODE 
inner join tbl_leave_attendance_rule ar on ar.company_id = ad.company_id 
inner join tbl_leave_shift sft on sft.shiftid = ar.shiftid 
where CONVERT(varchar(20), ad.intime, 108) is not null 
and ad.empcode='" + usercode.ToString().Trim() + "' and datepart(Month, ad.DATE) = datepart(month,getdate()) and convert(varchar(20), (ad.intime), 108) >= sft.starttime + ar.latein and convert(varchar(20), ad.intime - (sft.starttime + ar.latein), 108) >= '00:15:00'";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["Emp_log2"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["Emp_log2"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    protected void BindIntoEmpPieChartData3()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            query = @"select count(ad.intime) from tbl_payroll_employee_attendence_detail ad 
LEFT join tbl_attendance_employeecyclemapping am on am.empcode = ad.EMPCODE 
inner join tbl_leave_attendance_rule ar on ar.company_id = ad.company_id 
inner join tbl_leave_shift sft on sft.shiftid = ar.shiftid 
where CONVERT(varchar(20), ad.intime, 108) is not null 
and ad.empcode='" + usercode.ToString().Trim() + "' and datepart(Month, ad.DATE) = datepart(month,getdate()) and convert(varchar(20), (ad.intime), 108) >= sft.starttime + ar.latein and convert(varchar(20), ad.intime - (sft.starttime + ar.latein), 108) >= '00:30:00'";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            Session["Emp_log3"] = ds.Tables[0].Rows[0]["column1"].ToString();
            string test = (Session["Emp_log3"]).ToString();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    #endregion

    #region Log-In Button Click

    protected void btn_loging_Click(object sender, EventArgs e)     ////////////////// Chat gpt Code 
    {
        DataSet ds = new DataSet();
        string gettime = "select dateadd(MI,-270,getdate())";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, gettime);
        SqlConnection connection = activity.OpenConnection();

        string sqlstr = @"select ar.app_hrd , rm.official_email_id,rm.emp_fname+' ' +rm.emp_m_name+' ' +rm.emp_l_name as HR_Name
       from tbl_employee_approvers ar left join tbl_intranet_employee_jobDetails rm on ar.app_hrd = rm.empcode where ar.empcode='" + usercode + "'";
        DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        if (ds2.Tables.Count > 0 && ds2.Tables[0].Rows.Count > 0)
        {
            string Hremail = ds2.Tables[0].Rows[0]["official_email_id"].ToString();
            string Hrname = ds2.Tables[0].Rows[0]["HR_Name"].ToString();

            string sqlstr1 = @"select rm.empcode, rm.emp_fname+' ' +rm.emp_m_name+' ' +rm.emp_l_name as empname from 
                        tbl_intranet_employee_jobDetails rm where rm.empcode='" + usercode + "'";
            DataSet ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);

            if (ds3.Tables.Count > 0 && ds3.Tables[0].Rows.Count > 0)
            {
                string empname = ds3.Tables[0].Rows[0]["empname"].ToString();
                string empcode = ds3.Tables[0].Rows[0]["empcode"].ToString();

                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["Column1"].ToString()) > Convert.ToDateTime("08:30:00"))
                {
                    // mailtoHR(Hremail, Hrname, empname, empcode);
                    //Output.Show("U came late more then 30 minutes");
                }

                try
                {
                    connection = activity.OpenConnection();
                    string employeecode = usercode.ToString();
                    employeecode = employeecode.Substring(3, employeecode.Length - 3);
                    string query = @"insert into tbl_attendance_log(company_id,ip,enrollno,date)
                values('" + companyid + "','192.168.1.192','" + employeecode + "',GETDATE())";
                    int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

                    string query_1 = @"insert into tbl_attendance_login_logout(companyid,empcode,exactdate,intime,outtime)
                values('" + companyid + "','" + usercode.ToString() + "',GETDATE(),GETDATE(),null)";
                    int i_1 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query_1);
                }
                catch (Exception ex)
                {
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                    Output.Show("Login successfully!!");
                    BindIntoEmpPieChartData1();
                    BindIntoEmpPieChartData2();
                    BindIntoEmpPieChartData3();
                    bind_Intime();
                    btn_logout.Enabled = true;
                    bind_EmployeeMonthwise_Attendance();
                }
            }
        }
    }




    //    protected void btn_loging_Click(object sender, EventArgs e)      ////////////////////// original code 
    //    {
    //        DataSet ds = new DataSet();
    //        string gettime = "select dateadd(MI,-270,getdate())";
    //        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, gettime);
    //        SqlConnection connection = activity.OpenConnection();

    //        string sqlstr = @"select ar.app_hrd , rm.official_email_id,rm.emp_fname+' ' +rm.emp_m_name+' ' +rm.emp_l_name as HR_Name
    //       from tbl_employee_approvers ar left join tbl_intranet_employee_jobDetails rm on ar.app_hrd = rm.empcode where ar.empcode='" + usercode + "'";
    //        DataSet ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
    //        string Hremail = ds2.Tables[0].Rows[0]["official_email_id"].ToString();
    //        string Hrname = ds2.Tables[0].Rows[0]["HR_Name"].ToString();

    //        string sqlstr1 = @"select rm.empcode, rm.emp_fname+' ' +rm.emp_m_name+' ' +rm.emp_l_name as empname from 
    //                            tbl_intranet_employee_jobDetails rm where rm.empcode='" + usercode + "'";
    //        DataSet ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr1);

    //        string empname = ds3.Tables[0].Rows[0]["empname"].ToString();
    //        string empcode = ds3.Tables[0].Rows[0]["empcode"].ToString();
    //        if (Convert.ToDateTime(ds.Tables[0].Rows[0]["Column1"].ToString()) > Convert.ToDateTime("08:30:00"))
    //        {
    //            // mailtoHR(Hremail, Hrname, empname, empcode);
    //            //Output.Show("U came late more then 30 minutes");
    //        }
    //        try
    //        {
    //            connection = activity.OpenConnection();
    //            string employeecode = usercode.ToString();
    //            employeecode = employeecode.Substring(3, employeecode.Length - 3);
    //            string query = @"insert into tbl_attendance_log(company_id,ip,enrollno,date)
    //values('" + companyid + "','192.168.1.192','" + employeecode + "',GETDATE())";
    //            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

    //            string query_1 = @"insert into tbl_attendance_login_logout(companyid,empcode,exactdate,intime,outtime)
    //values('" + companyid + "','" + usercode.ToString() + "',GETDATE(),GETDATE(),null)";
    //            int i_1 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query_1);
    //        }
    //        catch (Exception ex)
    //        {
    //            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //        }
    //        finally
    //        {
    //            activity.CloseConnection();
    //            Output.Show("Login successfully!!");
    //            BindIntoEmpPieChartData1();
    //            BindIntoEmpPieChartData2();
    //            BindIntoEmpPieChartData3();
    //            bind_Intime();
    //            btn_logout.Enabled = true;
    //            bind_EmployeeMonthwise_Attendance();
    //        }
    //    }

    #endregion

    #region Log-Out Button Click

    protected void btn_logout_Click(object sender, EventArgs e)
    {
        DataSet ds = new DataSet();
        string gettime = "select dateadd(MI,-270,getdate())";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, gettime);
        try
        {
            connection = activity.OpenConnection();
            string employeecode = usercode.ToString();
            employeecode = employeecode.Substring(3, employeecode.Length - 3);
            string query = @"insert into tbl_attendance_log(company_id,ip,enrollno,date)
values('" + companyid + "','192.168.1.192','" + employeecode + "',GETDATE())";
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

            string query_1 = @"update tbl_attendance_login_logout set outtime=GETDATE() where DAY(exactdate)=DAY(GETDATE()) and empcode='" + usercode.ToString() + "'";
            int i_1 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query_1);
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            Output.Show("Logout successfully!!");
            bind_Outtime();
            bind_EmployeeMonthwise_Attendance();
        }
    }

    #endregion

    #region binding of InTime And OutTime

    protected void bind_Intime()
    {
        string employeecode = usercode.ToString();
        employeecode = employeecode.Substring(3, employeecode.Length - 3);
        string sqlstr = @"select RIGHT(Convert(VARCHAR(20), intime,100),7) as [ClockIn],
RIGHT(Convert(VARCHAR(20), outtime,100),7) as [ClockOut] from tbl_attendance_login_logout 
where empcode = '" + usercode.ToString() + "' and CONVERT(varchar(20),exactdate,106) = CONVERT(varchar(20),GETDATE(),106)";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ClockIn"].ToString() != "")
            {
                lbl_cloakintime.Text = ds.Tables[0].Rows[0]["ClockIn"].ToString();
                btn_loging.Visible = false;
                btn_logout.Visible = true;
            }
            else
            {
                btn_loging.Visible = true;
                btn_logout.Visible = false;
            }
        }
        else
        {
            btn_logout.Visible = false;
        }
    }

    protected void bind_Outtime()
    {
        string employeecode = usercode.ToString();
        employeecode = employeecode.Substring(3, employeecode.Length - 3);
        string sqlstr = @"select RIGHT(Convert(VARCHAR(20), intime,100),7) as [ClockIn],
RIGHT(Convert(VARCHAR(20), outtime,100),7) as [ClockOut] from tbl_attendance_login_logout 
where empcode = '" + usercode.ToString() + "' and CONVERT(varchar(20),exactdate,106) = CONVERT(varchar(20),GETDATE(),106)";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["ClockOut"].ToString() != "")
            {
                lbl_cloakouttime.Text = ds.Tables[0].Rows[0]["ClockOut"].ToString();
                if (Convert.ToDateTime(ds.Tables[0].Rows[0]["ClockIn"].ToString()) == Convert.ToDateTime(ds.Tables[0].Rows[0]["ClockOut"].ToString()))
                {
                    btn_logout.Visible = true;
                }
                else
                {
                    btn_logout.Visible = false;
                }
            }
        }
    }

    #endregion

    #region  Binding Of My CompOff

    protected void BindMyCompOff()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            string sqlstrShiftId = @"set nocount on;
declare @allowcompoff decimal(4,1);
declare @approvedays decimal(4,1);
select @approvedays =(select isnull(sum(no_of_days),0) from tbl_leave_apply_compoff 
where empcode='" + usercode.ToString().Trim() + "' and (leave_status=6 or (leave_status=1 and status=1))) select @allowcompoff=(select isnull(sum(day),0) from tbl_leave_employee_compoff where empcode='" + usercode.ToString().Trim() + "' and hide_status=1) select @approvedays approvedays,@allowcompoff allowcompoff,case when @approvedays < @allowcompoff then (isnull(@allowcompoff,0.0)-isnull(@approvedays,0.0))  else 0.0 end as avalibledays";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstrShiftId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["approvedcompoff"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                Session["allowedcompoff"] = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                Session["compoffbalance"] = ds.Tables[0].Rows[0].ItemArray[2].ToString();

                string a = Session["approvedcompoff"].ToString();
                string b = Session["allowedcompoff"].ToString();
                string c = Session["compoffbalance"].ToString();
            }
            else
                return;
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    #endregion

    #region  Binding Of My Holiday Work

    protected void BindMyHolidayWork()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            string sqlstr = @"select 'Approved'[status],COUNT(*)[total] from tbl_leave_approve_compoff where approval_status=1 and empcode='" + usercode.ToString().Trim() + "' union select 'Pending'[status],COUNT(*)[total] from tbl_leave_approve_compoff where approval_status=0 and empcode='" + usercode.ToString().Trim() + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["ApprovedHW"] = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                Session["PendingHW"] = ds.Tables[0].Rows[1].ItemArray[1].ToString();

                string d = Session["ApprovedHW"].ToString();
                string e = Session["PendingHW"].ToString();
            }
            else
                return;
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }

    #endregion

    #region Binding Of Employee Monthwise Attendance Status

    protected void bind_EmployeeMonthwise_Attendance()
    {
        string sqlstr = @"Select distinct CONVERT(varchar(50),atd_in_out.exactdate,106)[DateList],RIGHT(Convert(VARCHAR(20), atd_in_out.intime,100),7) as [InTime],
RIGHT(Convert(VARCHAR(20), atd_in_out.outtime,100),7) as [OutTime],
Convert(time(0),(Convert(datetime,atd_in_out.outtime) - Convert(datetime,atd_in_out.intime)),8)[TotalHours],
Convert(time(0),(Convert(datetime,atd_in_out.break_out) - Convert(datetime,atd_in_out.break_in)),8)[TotalBreakHours]
from tbl_attendance_login_logout atd_in_out
where MONTH(atd_in_out.exactdate)=MONTH(GETDATE()) and YEAR(atd_in_out.exactdate)=YEAR(GETDATE()) 
and atd_in_out.empcode = '" + usercode.ToString() + "' group by atd_in_out.exactdate,atd_in_out.intime,atd_in_out.outtime,atd_in_out.break_in,atd_in_out.break_out";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdempatndnce.DataSource = ds;
        grdempatndnce.DataBind();
    }

    protected void grdempatndnce_PreRender(object sender, EventArgs e)
    {
        if (grdempatndnce.Rows.Count > 0)
        {
            grdempatndnce.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion

}