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

public partial class menudashboard_Eresignation_dashboard : System.Web.UI.Page
{
    string sqlstr;
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
            bindMyEmpExitStatus();
            bind_employee_exit_status();
        }
        if (roleid == "13")
        {
            row_4.Visible = true;
        }
        else if (roleid == "1")
        {
            row_5.Visible = true;
        }
        else
        {
            row_2.Visible = true;
            //row_3.Visible = true;
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

    #region Binding of Exit Resignation Status

    [WebMethod]
    public static List<object> ExitStatusChart()
    {

        string query = @"select 'Total Exit Alpplied'[status],COUNT(*)[Total] from tbl_exit_Resignation ";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "status", "Total"
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
                        sdr["status"], sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Pending Employee

    [WebMethod]
    public static List<object> PendingEmployeeChart()
    {

        string query = @"select distinct Resign.ResignationId,Resign.EmpCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName
from tbl_exit_Resignation Resign
left join tbl_intranet_employee_jobDetails job on Resign.EmpCode = job.empcode
left join tbl_intranet_employee_status stat on Resign.EmployeeType = stat.id
inner join tbl_exit_ResignationProcess ResignPro on ResignPro.ResignationId = Resign.ResignationId 
inner join tbl_exit_approverdetails A on ResignPro.ApproversCode = A.ApproverCode
where Resign.ResignStatus='U' and Resign.ApplicationId=1 and  Resign.WorkFlowTypeId = 1 and 
A.WorkFlowTypeId = 1 and A.Status = 1 and job.emp_status=3";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "EmpCode", "ResignationId"
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
                        sdr["EmpCode"], sdr["ResignationId"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Approved Resignation Employee

    [WebMethod]
    public static List<object> ApprovedExitEmployeeChart()
    {

        string query = @"select distinct Resign.ResignationId,Resign.EmpCode
from tbl_exit_Resignation Resign
left join tbl_intranet_employee_jobDetails job on Resign.EmpCode = job.empcode
left join tbl_intranet_employee_status stat on Resign.EmployeeType = stat.id
inner join tbl_exit_ResignationProcess ResignPro on ResignPro.ResignationId = Resign.ResignationId and (ResignPro.ApproverStatus='A' or ResignPro.ApproverStatus='I')
inner join tbl_exit_approverdetails A on ResignPro.ApproversCode = A.ApproverCode
where Resign.Status = 1 and ResignPro.Status = 1 and Resign.ResignStatus = 'F'  and Resign.ApplicationId=1 and 
Resign.WorkFlowTypeId = 1 and A.WorkFlowTypeId = 1 and A.Status = 1";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "EmpCode", "ResignationId"
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
                        sdr["EmpCode"], sdr["ResignationId"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Rejected Resignation Employee

    [WebMethod]
    public static List<object> RejectedExitEmployeeChart()
    {

        string query = @"select distinct Resign.ResignationId,Resign.EmpCode
from tbl_exit_Resignation Resign
left join tbl_intranet_employee_jobDetails job on Resign.EmpCode = job.empcode
left join tbl_intranet_employee_status stat on Resign.EmployeeType = stat.id
inner join tbl_exit_ResignationProcess ResignPro on ResignPro.ResignationId = Resign.ResignationId 
inner join tbl_exit_approverdetails A on ResignPro.ApproversCode = A.ApproverCode
where Resign.ResignStatus in ('C','J') and Resign.ApplicationId=1 and 
Resign.WorkFlowTypeId = 1 and A.WorkFlowTypeId = 1 and A.Status = 1";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "EmpCode", "ResignationId"
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
                        sdr["EmpCode"], sdr["ResignationId"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Employee Exit Status

    protected void bind_employee_exit_status()
    {
        string sqlstr_20 = @"select 'Pending Employee'[status],COUNT(*)[Total] from tbl_exit_Resignation where Status = 1 and ResignStatus in ('U') 
select 'Approved Employee'[status],COUNT(*)[Total] from tbl_exit_Resignation where Status = 1 and ResignStatus in ('F')
select 'Rejected Employee'[status],COUNT(*)[Total] from tbl_exit_Resignation where ResignStatus in ('C','J')";
        DataSet ds_20 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_20);
        if (ds_20.Tables[0].Rows.Count > 0)
        {
            Session["ExitPending"] = ds_20.Tables[0].Rows[0]["Total"].ToString();
            Session["ExitApproved"] = ds_20.Tables[1].Rows[0]["Total"].ToString();
            Session["ExitRejected"] = ds_20.Tables[2].Rows[0]["Total"].ToString();
        }
    }

    #endregion

    #region Binding of My Employee Exit Status

    protected void bindMyEmpExitStatus()
    {
        string sqlstr = @"select 'Total Applied'[Status],COUNT(*)[Total] from tbl_exit_Resignation Resign
inner join tbl_employee_approvers apvr on Resign.EmpCode=apvr.empcode 
where  apvr.app_reportingmanager='" + usercode + "'";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["ExitAppliedEmp"] = ds.Tables[0].Rows[0]["Total"].ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_1 = @"select 'Pending'[Status],COUNT(*)[Total] from tbl_exit_Resignation Resign
inner join tbl_employee_approvers apvr on Resign.EmpCode=apvr.empcode 
where Resign.ResignStatus='U' and apvr.app_reportingmanager='" + usercode + "'";
        DataSet ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            Session["ExitPendingEmp"] = ds_1.Tables[0].Rows[0]["Total"].ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_2 = @"select 'Approved'[Status],COUNT(*)[Total] from tbl_exit_Resignation Resign
inner join tbl_employee_approvers apvr on Resign.EmpCode=apvr.empcode 
where Resign.ResignStatus='F' and apvr.app_reportingmanager='" + usercode + "'";
        DataSet ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            Session["ExitApprovedEmp"] = ds_2.Tables[0].Rows[0]["Total"].ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_3 = @"select 'Rejected'[Status],COUNT(*)[Total] from tbl_exit_Resignation Resign
inner join tbl_employee_approvers apvr on Resign.EmpCode=apvr.empcode 
where Resign.ResignStatus in ('C','J') and apvr.app_reportingmanager='" + usercode + "'";
        DataSet ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        if (ds_3.Tables[0].Rows.Count > 0)
        {
            Session["ExitRejectedEmp"] = ds_3.Tables[0].Rows[0]["Total"].ToString();
        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------------------



    }

    #endregion

}