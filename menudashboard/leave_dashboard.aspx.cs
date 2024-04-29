using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menudashboard_leave_dashboard : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string companyid, usercode, roleid, rolename, image, gender;

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
            BindAbsentEmployeeChart();
            BindAllLeaveChart();
            GetMyLeaveBalance();
            GetLeaveBalanceReportee();
            BindReporteeDropdownlist();
            BindAnnualLeaveStatusChart();
        }
        if (roleid == "13")
        {
            row_4.Visible = true;
        }
        else if (roleid == "1")
        {
            row_4.Visible = true;
            row_4_col_1.Visible = false;
        }
        else
        {
            row_2.Visible = true;
            row_3.Visible = true;
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

    #region Binding of All Leave Chart

    protected void BindAllLeaveChart()
    {
        string adminCode = Session["empcode"].ToString();
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        string query_6 = @"select * from tbl_intranet_employee_personalDetails where maritalstatus='MARRIED' and empcode='" + adminCode + "'";
        DataSet ds_6 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_6);
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            string maritalstatus = ds_6.Tables[0].Rows[0]["maritalstatus"].ToString();
        }

        try
        {
            string query_1 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS ELbalance,lm.status,JD.emp_status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
inner join tbl_intranet_employee_jobDetails JD on lm.empcode=JD.empcode
where lm.status=1 and lm.empcode='" + adminCode + "' and cl.displayleave='Leaves'";
            //------------------------------------------------------------------------------------------------------------------------------------------
            string query_2 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS PBLbalance,lm.status,JD.emp_status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
inner join tbl_intranet_employee_jobDetails JD on lm.empcode=JD.empcode
where lm.status=1 and lm.empcode='" + adminCode + "' and cl.displayleave='PBL'";
            //------------------------------------------------------------------------------------------------------------------------------------------
            string query_3 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,PD.maritalstatus,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS MLbalance,lm.status,JD.emp_status  
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
inner join tbl_intranet_employee_jobDetails JD on lm.empcode=JD.empcode
inner join tbl_intranet_employee_personalDetails PD on JD.empcode=PD.empcode
where lm.status=1 and lm.empcode='" + adminCode + "' and cl.displayleave='ML'";
            //------------------------------------------------------------------------------------------------------------------------------------------
            string query_4 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,PD.maritalstatus,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS PLbalance,lm.status,JD.emp_status  
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
inner join tbl_intranet_employee_jobDetails JD on lm.empcode=JD.empcode
inner join tbl_intranet_employee_personalDetails PD on JD.empcode=PD.empcode
where lm.status=1 and lm.empcode='" + adminCode + "' and cl.displayleave='PL'";
            //------------------------------------------------------------------------------------------------------------------------------------------


            DataSet ds_1 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_1);
            DataSet ds_2 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_2);
            DataSet ds_3 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_3);
            DataSet ds_4 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_4);

            //ViewState["Status"] = ds_1.Tables[0].Rows[0]["emp_status"].ToString();
            if (ds_1.Tables[0].Rows.Count > 0)
            {
                ViewState["Status"] = ds_1.Tables[0].Rows[0]["emp_status"].ToString();
                if (ds_1.Tables[0].Rows[0]["emp_status"].ToString() == "1")
                {
                    row_Leaves_1.Visible = false;
                    row_Leaves_2.Visible = false;
                    Session["ELbalance"] = ds_1.Tables[0].Rows[0]["ELbalance"].ToString();
                    string Leaves_EL_Bal = Session["ELbalance"].ToString();
                    lbl_leaves.Text = ds_1.Tables[0].Rows[0]["ELbalance"].ToString();
                }
                else
                {
                    row_Leaves_1.Visible = true;
                    row_Leaves_2.Visible = true;
                    Session["ELbalance"] = ds_1.Tables[0].Rows[0]["ELbalance"].ToString();
                    string Leaves_EL_Bal = Session["ELbalance"].ToString();
                    lbl_leaves.Text = ds_1.Tables[0].Rows[0]["ELbalance"].ToString();
                }
            }
            else
            {
                ViewState["Status"] = "";
            }
            if (ds_2.Tables[0].Rows.Count > 0)
            {
                string query_5 = @"select * from tbl_intranet_employee_jobdetails where emp_status=1 and empcode='" + adminCode + "'";
                DataSet ds_5 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_5);
                if (ds_5.Tables[0].Rows.Count > 0)
                {
                    row_PBL_1.Visible = true;
                    row_PBL_2.Visible = true;
                    Session["PBLbalance"] = ds_2.Tables[0].Rows[0]["PBLbalance"].ToString();
                    string PBL_Bal = Session["PBLbalance"].ToString();
                    lbl_PBL.Text = ds_2.Tables[0].Rows[0]["PBLbalance"].ToString();
                }
            }
            if (ds_3.Tables[0].Rows.Count > 0)
            {
                if (gender == "F")
                {
                    if (ds_1.Tables[0].Rows[0]["emp_status"].ToString() == "1")
                    {
                        row_tbl_ML_1.Visible = false;
                        row_tbl_ML_2.Visible = false;
                        Session["MLbalance"] = ds_3.Tables[0].Rows[0]["MLbalance"].ToString();
                        string ML_Bal = Session["MLbalance"].ToString();
                        lbl_tbl_ML.Text = ds_3.Tables[0].Rows[0]["MLbalance"].ToString();
                    }
                    else
                    {
                        if (ds_3.Tables[0].Rows[0]["maritalstatus"].ToString() == "0")
                        {
                            row_tbl_ML_1.Visible = false;
                            row_tbl_ML_2.Visible = false;
                            ViewState["Maritalstatus"] = ds_3.Tables[0].Rows[0]["maritalstatus"].ToString();
                        }
                        else
                        {
                            row_tbl_ML_1.Visible = true;
                            row_tbl_ML_2.Visible = true;
                            Session["MLbalance"] = ds_3.Tables[0].Rows[0]["MLbalance"].ToString();
                            string ML_Bal = Session["MLbalance"].ToString();
                            lbl_tbl_ML.Text = ds_3.Tables[0].Rows[0]["MLbalance"].ToString();
                            ViewState["Maritalstatus"] = ds_3.Tables[0].Rows[0]["maritalstatus"].ToString();
                        }
                    }

                }
            }
            if (ds_4.Tables[0].Rows.Count > 0)
            {
                if (gender == "M")
                {
                    if (ds_1.Tables[0].Rows[0]["emp_status"].ToString() == "1")
                    {
                        row_tbl_PL_1.Visible = false;
                        row_tbl_PL_2.Visible = false;
                        Session["PLbalance"] = ds_4.Tables[0].Rows[0]["PLbalance"].ToString();
                        string PL_Bal = Session["PLbalance"].ToString();
                        lbl_tbl_PL.Text = ds_4.Tables[0].Rows[0]["PLbalance"].ToString();
                    }
                    else
                    {
                        if (ds_4.Tables[0].Rows[0]["maritalstatus"].ToString() == "0")
                        {
                            row_tbl_ML_1.Visible = false;
                            row_tbl_ML_2.Visible = false;
                            ViewState["Maritalstatus"] = ds_4.Tables[0].Rows[0]["maritalstatus"].ToString();
                        }
                        else
                        {
                            row_tbl_PL_1.Visible = true;
                            row_tbl_PL_2.Visible = true;
                            Session["PLbalance"] = ds_4.Tables[0].Rows[0]["PLbalance"].ToString();
                            string PL_Bal = Session["PLbalance"].ToString();
                            lbl_tbl_PL.Text = ds_4.Tables[0].Rows[0]["PLbalance"].ToString();
                            ViewState["Maritalstatus"] = ds_4.Tables[0].Rows[0]["maritalstatus"].ToString();
                        }
                    }
                }
            }
            if (ds_4.Tables[0].Rows.Count <= 0 && ds_3.Tables[0].Rows.Count <= 0)
            {
                ViewState["Maritalstatus"] = "ABC";
            }

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

    #endregion

    #region Binding of Annual Leave Status Chart

    protected void BindAnnualLeaveStatusChart()
    {
        string adminCode = Session["empcode"].ToString();
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            string query_1 = @"select  distinct 'Pending Leaves'[status],COUNT(*)[Total_Pending_Leave]
from tbl_leave_apply_leave T1 inner join (select emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'') as ename,
deg.designationname designation,dep.department_name department,branch.branch_name,
leave.no_of_days nod,leave.leaveid,leave.Applied_leave
from tbl_intranet_employee_jobDetails emp  
inner join tbl_leave_apply_leave_datewise leave on emp.empcode=leave.empcode
left outer join tbl_intranet_branch_detail branch on emp.branch_id=branch.branch_id
left outer join tbl_intranet_designation deg on emp.degination_id=deg.id 
left outer join tbl_internate_departmentdetails dep on emp.dept_id=dep.departmentid
where ((leave.date between convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate()),0), 101) 
and convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate())+1,-1), 101))) and leave.leave_status=0 
group by emp.empcode,emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'')
,deg.designationname,dep.department_name,branch.branch_name,no_of_days,leaveid,Applied_leave)T2 on T1.id= T2.leaveid 
inner join tbl_leave_createleave typ on T2.Applied_leave=typ.leaveid";
            //------------------------------------------------------------------------------------------------------------------------------------------
            string query_2 = @"select distinct 'Approved Leaves'[status],COUNT(*)[Total_Approved_Leave]
from tbl_leave_apply_leave T1 inner join (select emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'') as ename,
deg.designationname designation,dep.department_name department,branch.branch_name,
leave.no_of_days nod,leave.leaveid,leave.Applied_leave
from tbl_intranet_employee_jobDetails emp  
inner join tbl_leave_apply_leave_datewise leave on emp.empcode=leave.empcode
left outer join tbl_intranet_branch_detail branch on emp.branch_id=branch.branch_id
left outer join tbl_intranet_designation deg on emp.degination_id=deg.id 
left outer join tbl_internate_departmentdetails dep on emp.dept_id=dep.departmentid
where ((leave.date between convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate()),0), 101) 
and convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate())+1,-1), 101))) and leave.leave_status=6 
group by emp.empcode,emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'')
,deg.designationname,dep.department_name,branch.branch_name,no_of_days,leaveid,Applied_leave)T2 on T1.id= T2.leaveid 
inner join tbl_leave_createleave typ on T2.Applied_leave=typ.leaveid";
            //------------------------------------------------------------------------------------------------------------------------------------------
            string query_3 = @"select distinct 'Cancelled Leaves'[status],COUNT(*)[Total_Cancel_Leave]
from tbl_leave_apply_leave T1 inner join (select emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'') as ename,
deg.designationname designation,dep.department_name department,branch.branch_name,
leave.no_of_days nod,leave.leaveid,leave.Applied_leave
from tbl_intranet_employee_jobDetails emp  
inner join tbl_leave_apply_leave_datewise leave on emp.empcode=leave.empcode
left outer join tbl_intranet_branch_detail branch on emp.branch_id=branch.branch_id
left outer join tbl_intranet_designation deg on emp.degination_id=deg.id 
left outer join tbl_internate_departmentdetails dep on emp.dept_id=dep.departmentid
where ((leave.date between convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate()),0), 101) 
and convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate())+1,-1), 101))) and leave.leave_status=2 
group by emp.empcode,emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'')
,deg.designationname,dep.department_name,branch.branch_name,no_of_days,leaveid,Applied_leave)T2 on T1.id= T2.leaveid 
inner join tbl_leave_createleave typ on T2.Applied_leave=typ.leaveid";
            //------------------------------------------------------------------------------------------------------------------------------------------
            string query_4 = @"select distinct 'Rejected Leaves'[status],COUNT(*)[Total_Rejected_Leave]
from tbl_leave_apply_leave T1 inner join (select emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'') as ename,
deg.designationname designation,dep.department_name department,branch.branch_name,
leave.no_of_days nod,leave.leaveid,leave.Applied_leave
from tbl_intranet_employee_jobDetails emp  
inner join tbl_leave_apply_leave_datewise leave on emp.empcode=leave.empcode
left outer join tbl_intranet_branch_detail branch on emp.branch_id=branch.branch_id
left outer join tbl_intranet_designation deg on emp.degination_id=deg.id 
left outer join tbl_internate_departmentdetails dep on emp.dept_id=dep.departmentid
where ((leave.date between convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate()),0), 101) 
and convert(datetime, DATEADD(YY,DATEDIFF(yy,0,getdate())+1,-1), 101))) and leave.leave_status=3 
group by emp.empcode,emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'')
,deg.designationname,dep.department_name,branch.branch_name,no_of_days,leaveid,Applied_leave)T2 on T1.id= T2.leaveid 
inner join tbl_leave_createleave typ on T2.Applied_leave=typ.leaveid";
            //------------------------------------------------------------------------------------------------------------------------------------------

            DataSet ds_1 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_1);
            DataSet ds_2 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_2);
            DataSet ds_3 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_3);
            DataSet ds_4 = SQLServer.ExecuteDataset(connection, CommandType.Text, query_4);

            if (ds_1.Tables[0].Rows.Count > 0)
            {
                Session["Tot_Pend_Leave"] = ds_1.Tables[0].Rows[0]["Total_Pending_Leave"].ToString();
                string PENDBal = Session["Tot_Pend_Leave"].ToString();
            }
            if (ds_2.Tables[0].Rows.Count > 0)
            {
                Session["Tot_Apvr_Leave"] = ds_2.Tables[0].Rows[0]["Total_Approved_Leave"].ToString();
                string APVRBal = Session["Tot_Apvr_Leave"].ToString();
            }
            if (ds_3.Tables[0].Rows.Count > 0)
            {
                Session["Tot_Cancel_Leave"] = ds_3.Tables[0].Rows[0]["Total_Cancel_Leave"].ToString();
                string CancelBal = Session["Tot_Cancel_Leave"].ToString();
            }
            if (ds_4.Tables[0].Rows.Count > 0)
            {
                Session["Tot_Rej_Leave"] = ds_4.Tables[0].Rows[0]["Total_Rejected_Leave"].ToString();
                string REJBal = Session["Tot_Rej_Leave"].ToString();
            }
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

    #endregion

    #region Binding of Absent Employees(Previous Month, Current Month,Today)

    protected void BindAbsentEmployeeChart()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();

        try
        {
            string sqlstrShiftId = @"select COUNT(*)[AbsentPreviousMonth] from tbl_payroll_employee_attendence_detail
where MODE in('A') and MONTH(DATE)=MONTH(DATEADD(mm, -1, GETDATE()))
select COUNT(*)[AbsentThisMonth] from tbl_payroll_employee_attendence_detail
where MODE in('A') and MONTH(DATE)=MONTH(GETDATE())
select COUNT(*)[AbsentToday] from tbl_payroll_employee_attendence_detail
where MODE in('A') and DATE=GETDATE()";

            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstrShiftId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Session["PrevMonth"] = ds.Tables[0].Rows[0]["AbsentPreviousMonth"].ToString();
                Session["CurrentMonth"] = ds.Tables[1].Rows[0]["AbsentThisMonth"].ToString();
                Session["Today"] = ds.Tables[2].Rows[0]["AbsentToday"].ToString();
                string prevmonth = Session["PrevMonth"].ToString();
                string currentmonth = Session["CurrentMonth"].ToString();
                string today = Session["Today"].ToString();
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

    #endregion

    #region Binding Of My Reportee Leave Balance , Details Of Dropdown List

    protected void BindReporteeDropdownlist()
    {
        string adminCode = Session["empcode"].ToString();

        string sqlstr = @"select ej.empcode value,isnull(ej.emp_fname ,'')+' '+isnull(ej.emp_m_name,'')+ ' '+isnull(ej.emp_l_name,'') as name
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101) 
where emp_doleaving is null and ej.status=1 and ej.emp_status!='2' and L.role not in ('2') and av.app_reportingmanager='" + adminCode + "' and av.status=1";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddlReportee.DataSource = ds;
            ddlReportee.DataTextField = "name";
            ddlReportee.DataValueField = "value";
            ddlReportee.DataBind();
            ddlReportee.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }

    protected void ddlReportee_SelectedIndexChanged(object sender, EventArgs e)
    {
        string sqlst = "";
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        DataSet ds = new DataSet();
        try
        {
            if (ddlReportee.SelectedValue != "0")
            {
                if (ViewState["Status"] == "1")
                {
                    sqlstr = @"SELECT DISTINCT rtrim(jd.empcode) as empcode,coalesce(jd.emp_fname,'''') + '' + coalesce(jd.emp_m_name,'''') + '' + coalesce(jd.emp_l_name,'''') as name,  
jd.card_no,jd.emp_gender,r.applicable_to,elm.leaveid,l.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,
elm.Used_days as used,isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance,tbl_intranet_grade.gradename grade,    
jd.degination_id,dg.designationname,jd.dept_id,dp.department_name,jd.branch_id,b.branch_name,convert(varchar(10),jd.emp_doj,101)emp_doj,                  
jd.emp_status,tbl_intranet_role.role ,apvr.app_reportingmanager     
FROM tbl_intranet_employee_jobDetails jd
left join tbl_leave_employee_leave_master elm on jd.empcode = elm.empcode
left join tbl_employee_approvers apvr on apvr.empcode=elm.empcode
inner join tbl_leave_createleave l on elm.leaveid=l.leaveid
inner join tbl_leave_createdefaultrule r on r.leaveid=l.leaveid    
INNER JOIN tbl_intranet_designation dg ON jd.degination_id=dg.id    
INNER JOIN tbl_internate_departmentdetails dp ON jd.dept_id=dp.departmentid    
INNER JOIN tbl_intranet_branch_detail b ON jd.branch_id=b.Branch_id    
left outer JOIN tbl_intranet_grade ON jd.grade=tbl_intranet_grade.id
inner join tbl_login on tbl_login.empcode=jd.empcode
left join tbl_intranet_role on tbl_intranet_role.id=tbl_login.role
WHERE elm.leaveid<>0 and not ((jd.emp_gender = 'FEMALE' and r.applicable_to = 'M') or (jd.emp_gender = 'MALE' and r.applicable_to = 'F') ) 
and r.entitle_applicable = 1 and 1=1 and jd.status=1 and jd.emp_doleaving is null and elm.status not in (0)
and apvr.app_reportingmanager='" + usercode.ToString() + "' and jd.empcode='" + ddlReportee.SelectedValue + "'";
                }
                else
                {
                    sqlstr = @"SELECT DISTINCT rtrim(jd.empcode) as empcode,coalesce(jd.emp_fname,'''') + '' + coalesce(jd.emp_m_name,'''') + '' + coalesce(jd.emp_l_name,'''') as name,  
jd.card_no,jd.emp_gender,r.applicable_to,elm.leaveid,l.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,
elm.Used_days as used,isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance,tbl_intranet_grade.gradename grade,    
jd.degination_id,dg.designationname,jd.dept_id,dp.department_name,jd.branch_id,b.branch_name,convert(varchar(10),jd.emp_doj,101)emp_doj,                  
jd.emp_status,tbl_intranet_role.role ,apvr.app_reportingmanager     
FROM tbl_intranet_employee_jobDetails jd
left join tbl_leave_employee_leave_master elm on jd.empcode = elm.empcode
left join tbl_employee_approvers apvr on apvr.empcode=elm.empcode
inner join tbl_leave_createleave l on elm.leaveid=l.leaveid
inner join tbl_leave_createdefaultrule r on r.leaveid=l.leaveid    
INNER JOIN tbl_intranet_designation dg ON jd.degination_id=dg.id    
INNER JOIN tbl_internate_departmentdetails dp ON jd.dept_id=dp.departmentid    
INNER JOIN tbl_intranet_branch_detail b ON jd.branch_id=b.Branch_id    
left outer JOIN tbl_intranet_grade ON jd.grade=tbl_intranet_grade.id
inner join tbl_login on tbl_login.empcode=jd.empcode
left join tbl_intranet_role on tbl_intranet_role.id=tbl_login.role
WHERE elm.leaveid not in (0,3) and not ((jd.emp_gender = 'FEMALE' and r.applicable_to = 'M') or (jd.emp_gender = 'MALE' and r.applicable_to = 'F') ) 
and r.entitle_applicable = 1 and 1=1 and jd.status=1 and jd.emp_doleaving is null and elm.status not in (0)
and apvr.app_reportingmanager='" + usercode.ToString() + "' and jd.empcode='" + ddlReportee.SelectedValue + "'";
                }

                ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    grid_my_reportee_leavebalance.DataSource = ds;
                    grid_my_reportee_leavebalance.DataBind();
                }
            }
            else
            {
                GetLeaveBalanceReportee();
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

    protected void GetLeaveBalanceReportee()
    {
        string sqlstr = "";
        var activityReportee = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            if (ViewState["Status"] == "1")
            {
                sqlstr = @"select ej.empcode,isnull(ej.emp_fname ,'')+' '+isnull(ej.emp_m_name,'')+ ' '+isnull(ej.emp_l_name,'') as name,
elm.leaveid,cl.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,
elm.Used_days as used,isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101)
left join tbl_leave_employee_leave_master elm on ej.empcode = elm.empcode 
inner join tbl_leave_createleave cl on elm.leaveid=cl.leaveid
left join tbl_employee_approvers apvr on apvr.empcode=elm.empcode
inner join tbl_leave_createdefaultrule r on r.leaveid=cl.leaveid 
WHERE elm.leaveid not in (0)and not ((ej.emp_gender = 'FEMALE' and r.applicable_to = 'M') or (ej.emp_gender = 'MALE' and r.applicable_to = 'F') ) 
and r.entitle_applicable = 1 and 1=1 and ej.status=1 and ej.emp_doleaving is null and elm.status not in (0)
and apvr.app_reportingmanager='" + usercode.ToString() + "'";
            }
            else
            {
                sqlstr = @"select ej.empcode,isnull(ej.emp_fname ,'')+' '+isnull(ej.emp_m_name,'')+ ' '+isnull(ej.emp_l_name,'') as name,
elm.leaveid,cl.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,
elm.Used_days as used,isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance
from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers av on av.empcode=ej.empcode  
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
INNER JOIN tbl_login as L on ej.empcode = L.empcode
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode and DATE=convert(varchar(10),GETDATE(),101)
left join tbl_leave_employee_leave_master elm on ej.empcode = elm.empcode 
inner join tbl_leave_createleave cl on elm.leaveid=cl.leaveid
left join tbl_employee_approvers apvr on apvr.empcode=elm.empcode
inner join tbl_leave_createdefaultrule r on r.leaveid=cl.leaveid 
WHERE elm.leaveid not in (0,3)and not ((ej.emp_gender = 'FEMALE' and r.applicable_to = 'M') or (ej.emp_gender = 'MALE' and r.applicable_to = 'F') ) 
and r.entitle_applicable = 1 and 1=1 and ej.status=1 and ej.emp_doleaving is null and elm.status not in (0)
and apvr.app_reportingmanager='" + usercode.ToString() + "'";
            }
            SqlConnection connection = activityReportee.OpenConnection();


            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            if (ds.Tables[0].Rows.Count > 0)
            {
                grid_my_reportee_leavebalance.DataSource = ds;
                grid_my_reportee_leavebalance.DataBind();
            }

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activityReportee.CloseConnection();
        }
    }

    protected void grid_my_reportee_leavebalance_PreRender(object sender, EventArgs e)
    {
        if (grid_my_reportee_leavebalance.Rows.Count > 0)
        {
            grid_my_reportee_leavebalance.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion

    #region Binding Of My Leave Balance
    string sqlstr = "";
    protected void GetMyLeaveBalance()
    {
        string Status;
        if (ViewState["Status"].ToString() != "")
        {
            Status = ViewState["Status"].ToString();
        }
        else
        {
            Status = "";
        }

        var activityReportee = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activityReportee.OpenConnection();

            if (Status == "1")
            {
                string sqlstr = @"select elm.leaveid,l.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,elm.Used_days as used,
isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance from tbl_leave_employee_leave_master elm inner join tbl_leave_createleave l on elm.leaveid=l.leaveid
inner join tbl_leave_createdefaultrule r on r.leaveid=l.leaveid where elm.empcode='" + usercode.ToString() + "' and elm.leaveid not in(0,1,4,5)  and ( applicable_to = 'A' or applicable_to = (select case when emp_gender = 'Male' or emp_gender = 'MALE'  then 'M' when emp_gender = 'FEMALE' or emp_gender = 'Female' then 'F' end from tbl_intranet_employee_jobDetails where empcode = '" + usercode.ToString() + "') ) and r.entitle_applicable = 1 union  select aal.leaveid,'LWP' as leavename,'0' as entitled_days,isnull(sum(days),0) as used, '0' as balance from tbl_leave_adjustment_apply aal  inner join tbl_leave_apply_leave al on al.id=aal.apply_leave_id where al.Empcode='" + usercode.ToString() + "' and al.Leave_status=1 and aal.status=1 and aal.leaveid=0 group by aal.leaveid order by leavename";
                ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            }
            else
            {

                if (ViewState["Maritalstatus"].ToString() == "0".ToString())
                {
                    sqlstr = @"select elm.leaveid,l.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,elm.Used_days as used,
                                  isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance from tbl_leave_employee_leave_master elm
                                  inner join tbl_leave_createleave l on elm.leaveid=l.leaveid inner join tbl_leave_createdefaultrule DF on l.leaveid=DF.leaveid  where  elm.status=1
                                  and l.leaveid not in (3,5,4) and elm.empcode='" + usercode.ToString() + "'" +
                                                   " and ( applicable_to = 'A' or applicable_to = (select case when emp_gender = 'Male' or emp_gender = 'MALE'  then 'M' when emp_gender = 'FEMALE' or emp_gender = 'Female' then 'F' end from tbl_intranet_employee_jobDetails where empcode = '" + usercode.ToString() + "') )";
                }
                else
                {
                    sqlstr = @"select elm.leaveid,l.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,elm.Used_days as used,
                                  isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance from tbl_leave_employee_leave_master elm
                                  inner join tbl_leave_createleave l on elm.leaveid=l.leaveid inner join tbl_leave_createdefaultrule DF on l.leaveid=DF.leaveid  where  elm.status=1
                                  and l.leaveid not in (3) and elm.empcode='" + usercode.ToString() + "'" +
                                    " and ( applicable_to = 'A' or applicable_to = (select case when emp_gender = 'Male' or emp_gender = 'MALE'  then 'M' when emp_gender = 'FEMALE' or emp_gender = 'Female' then 'F' end from tbl_intranet_employee_jobDetails where empcode = '" + usercode.ToString() + "') )";
                }





                //                string sqlstr = @"select elm.leaveid,l.leavetype as leavename,isnull(elm.Entitled_days,0) as entitled_days,elm.Used_days as used,
                //isnull(elm.Entitled_days,0) - isnull(elm.Used_days,0) as balance from tbl_leave_employee_leave_master elm inner join tbl_leave_createleave l on elm.leaveid=l.leaveid
                //inner join tbl_leave_createdefaultrule r on r.leaveid=l.leaveid where elm.empcode='" + usercode.ToString() + "' and elm.leaveid<>0 and ( applicable_to = 'A' or applicable_to = (select case when emp_gender = 'Male' or emp_gender = 'MALE'  then 'M' when emp_gender = 'FEMALE' or emp_gender = 'Female' then 'F' end from tbl_intranet_employee_jobDetails where empcode = '" + usercode.ToString() + "') ) and r.entitle_applicable = 1 union  select aal.leaveid,'LWP' as leavename,'0' as entitled_days,isnull(sum(days),0) as used, '0' as balance from tbl_leave_adjustment_apply aal  inner join tbl_leave_apply_leave al on al.id=aal.apply_leave_id where al.Empcode='" + usercode.ToString() + "' and al.Leave_status=1 and aal.status=1 and aal.leaveid=0 group by aal.leaveid order by leavename";
                ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            }



            if (ds.Tables[0].Rows.Count > 0)
            {
                balancegrid.DataSource = ds;
                balancegrid.DataBind();
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activityReportee.CloseConnection();
        }
    }

    protected void balancegrid_PreRender(object sender, EventArgs e)
    {
        if (balancegrid.Rows.Count > 0)
        {
            balancegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion

}