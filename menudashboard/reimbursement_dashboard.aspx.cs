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

public partial class menudashboard_reimbursement_dashboard : System.Web.UI.Page
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
            bindMyReporteeReimbursementStatus();
            bindMyReimbursementStatus();
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

    #region Binding of PayHead

    [WebMethod]
    public static List<object> PayHeadChart()
    {

        string query = @"select 'Business Reimbursement'[Category],COUNT(*)[Total] from tbl_Rb_PayHead where status=1 and Type=1
union
select 'Miscellaneous Reimbursement'[Category],COUNT(*)[Total] from tbl_Rb_PayHead where status=1 and Type=2";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Category", "Total"
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
                        sdr["Category"], sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Catagory Type

    [WebMethod]
    public static List<object> CatagoryTypeChart()
    {

        string query = @"select case when Type=1 then 'Business Reimbursement' when Type=2 then 'Miscellaneous  Reimbursement' end [Status],
COUNT(*)[Total] from tbl_Rb_Reimbursement group by Type";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Status", "Total"
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
                        sdr["Status"], sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Reimbursement Status

    [WebMethod]
    public static List<object> ReimbursementStatusChart()
    {

        string query = @"select 'Pending'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement trr
inner join tbl_Rb_Reimbursement_Details trd on trr.RID=trd.RID where Freeze=0
union all
select 'Approved'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement trr
inner join tbl_Rb_Reimbursement_Details trd on trr.RID=trd.RID
where trr.Level=5 and trr.Freeze=1 and trr.IsReject=0
union all
select 'Rejected'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement_Details trd
inner join tbl_Rb_Reimbursement tr on trd.RID=tr.RID
where tr.IsReject=1";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Status", "Total"
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
                        sdr["Status"], sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Employee Approver Level

    [WebMethod]
    public static List<object> EmployeeApproverChart()
    {

        string query = @"select 'Line Manager'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr
where rr.Level=1
union all
select 'Admin'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr
where rr.Level=2
union all
select 'Business Head'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr 
where rr.Level=3
union all
select 'Finance SPOC'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr
where rr.Level=4
union all
select 'Approved'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr
where rr.Level=5";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Level", "Total"
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
                        sdr["Level"], sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of My Reportee Reimbursement Status

    protected void bindMyReporteeReimbursementStatus()
    {
        //string sqlstr = @"select 'Line Manager'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr
        //inner join tbl_Rb_Approvers tra on rr.RID=tra.RID  
        //inner join tbl_employee_approvers apvr on rr.Empcode=apvr.empcode
        //where rr.Level=1 and apvr.app_reportingmanager='" + usercode + "' union all select 'Admin'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr inner join tbl_Rb_Approvers tra on rr.RID=tra.RID  inner join tbl_employee_approvers apvr on rr.Empcode=apvr.empcode where rr.Level=2 and apvr.app_reportingmanager='" + usercode + "' union all select 'Business Head'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr inner join tbl_Rb_Approvers tra on rr.RID=tra.RID inner join tbl_employee_approvers apvr on rr.Empcode=apvr.empcode where rr.Level=3 and apvr.app_reportingmanager='" + usercode + "' union all select 'Finance SPOC'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr inner join tbl_Rb_Approvers tra on rr.RID=tra.RID  inner join tbl_employee_approvers apvr on rr.Empcode=apvr.empcode where rr.Level=4 and apvr.app_reportingmanager='" + usercode + "' union all select 'Approved'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr inner join tbl_employee_approvers apvr on rr.Empcode=apvr.empcode where rr.Level=5 and apvr.app_reportingmanager='" + usercode + "'";

        string sqlstr = @"select 'Pending'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement trr
inner join tbl_Rb_Reimbursement_Details trd on trr.RID=trd.RID
inner join tbl_employee_approvers apvr on trr.Empcode=apvr.empcode
where Freeze=0 and apvr.app_reportingmanager='" + usercode + "' union all select 'Approved'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement trr inner join tbl_Rb_Reimbursement_Details trd on trr.RID=trd.RID inner join tbl_employee_approvers apvr on trr.Empcode=apvr.empcode where trr.Level=5 and trr.Freeze=1 and trr.IsReject=0 and apvr.app_reportingmanager='" + usercode + "' union all select 'Rejected'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement_Details trd inner join tbl_Rb_Reimbursement tr on trd.RID=tr.RID inner join tbl_employee_approvers apvr on tr.Empcode=apvr.empcode where tr.IsReject=1 and apvr.app_reportingmanager='" + usercode + "' ";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteeReimPending"] = ds.Tables[0].Rows[0]["Total"].ToString();
            Session["MyReporteeReimApproved"] = ds.Tables[0].Rows[1]["Total"].ToString();
            Session["MyReporteeReimRejected"] = ds.Tables[0].Rows[2]["Total"].ToString();
        }
    }

    #endregion

    #region Binding of My Reimbursement Level Status

    protected void bindMyReimbursementStatus()
    {
        //        string sqlstr = @"select 'Line Manager'[Level],COUNT(*)[Total] 
        //from tbl_Rb_Reimbursement rr where rr.Level=1 and rr.Empcode='" + usercode + "' union all select 'Admin'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr where rr.Level=2 and rr.Empcode='" + usercode + "' union all select 'Business Head'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr where rr.Level=3 and rr.Empcode='" + usercode + "' union all select 'Finance SPOC'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr where rr.Level=4 and rr.Empcode='" + usercode + "' union all select 'Approved'[Level],COUNT(*)[Total] from tbl_Rb_Reimbursement rr where rr.Level=5 and rr.Empcode='" + usercode + "'";

        string sqlstr = @"select 'Pending'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement trr
inner join tbl_Rb_Reimbursement_Details trd on trr.RID=trd.RID where Freeze=0 and 
trr.Empcode='" + usercode + "' union all select 'Approved'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement trr inner join tbl_Rb_Reimbursement_Details trd on trr.RID=trd.RID where trr.Level=5 and trr.Freeze=1 and trr.IsReject=0 and trr.Empcode='" + usercode + "' union all select 'Rejected'[Status],COUNT(*)[Total] from tbl_Rb_Reimbursement_Details trd inner join tbl_Rb_Reimbursement tr on trd.RID=tr.RID where tr.IsReject=1 and tr.Empcode='" + usercode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["MyReimPending"] = ds.Tables[0].Rows[0]["Total"].ToString();
            Session["MyReimApproved"] = ds.Tables[0].Rows[1]["Total"].ToString();
            Session["MyReimRejected"] = ds.Tables[0].Rows[2]["Total"].ToString();
        }
    }

    #endregion

}