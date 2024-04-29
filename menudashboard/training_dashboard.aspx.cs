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

public partial class menudashboard_training_dashboard : System.Web.UI.Page
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
            bindAsFacultyTrainEmpStatus();
            bindMyReporteeTrainingStatus();
            bind_MyTrainingstatus();
        }

        if (roleid == "13")
        {
            row_4.Visible = true;
            row_5.Visible = true;
        }
        else if (roleid == "1")
        {
            row_5.Visible = true;
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

    #region Binding of Training Type

    [WebMethod]
    public static List<object> TrainingTypeChart()
    {

        string query = @"select training_name,id from tbl_training_master";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "training_name", "id"
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
                        sdr["training_name"], sdr["id"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Training Type Employee

    [WebMethod]
    public static List<object> TrainingTypeEmployeeChart()
    {

        string query = @"select training_name[status],COUNT(*)[Total] from tbl_training_schedul group by training_name";
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

    #region Binding of Monthwise Training Employees

    [WebMethod]
    public static List<object> MonthwiseTrainingChart()
    {
        //SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul 
        //where year=YEAR(GETDATE()) group by month
        string query = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul group by month order by Month";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Month", "Total"
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
                        sdr["Month"], sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of As Faculty Training Employees

    protected void bindAsFacultyTrainEmpStatus()
    {

        string sqlstr_1 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='January' group by month";
        DataSet ds_1 = new DataSet();
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            Session["january"] = ds_1.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_2 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='February' group by month";
        DataSet ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            Session["february"] = ds_2.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_3 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='March' group by month";
        DataSet ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        if (ds_3.Tables[0].Rows.Count > 0)
        {
            Session["march"] = ds_3.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_4 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='April' group by month";
        DataSet ds_4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_4);
        if (ds_4.Tables[0].Rows.Count > 0)
        {
            Session["april"] = ds_4.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_5 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='May' group by month";
        DataSet ds_5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_5);
        if (ds_5.Tables[0].Rows.Count > 0)
        {
            Session["may"] = ds_5.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------


        string sqlstr_6 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='June' group by month";
        DataSet ds_6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_6);
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            Session["june"] = ds_6.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_7 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='July' group by month";
        DataSet ds_7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_7);
        if (ds_7.Tables[0].Rows.Count > 0)
        {
            Session["july"] = ds_7.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------


        string sqlstr_8 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='August' group by month";
        DataSet ds_8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_8);
        if (ds_8.Tables[0].Rows.Count > 0)
        {
            Session["august"] = ds_8.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_9 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='September' group by month";
        DataSet ds_9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_9);
        if (ds_9.Tables[0].Rows.Count > 0)
        {
            Session["september"] = ds_9.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_10 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='October' group by month";
        DataSet ds_10 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_10);
        if (ds_10.Tables[0].Rows.Count > 0)
        {
            Session["october"] = ds_10.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_11 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='November' group by month";
        DataSet ds_11 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_11);
        if (ds_11.Tables[0].Rows.Count > 0)
        {
            Session["november"] = ds_11.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_12 = @"SELECT DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] 
from tbl_training_schedul where LEFT(faculty,7)='" + usercode + "' and DATENAME(m, str([month]) + '/1/2019')='December' group by month";
        DataSet ds_12 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_12);
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            Session["december"] = ds_12.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

    }

    #endregion

    #region Binding of My Reportee Training Status

    protected void bindMyReporteeTrainingStatus()
    {
        string sqlstr_1 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='January' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_1 = new DataSet();
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteejanuary"] = ds_1.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_2 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='February' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteefebruary"] = ds_2.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_3 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='March' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        if (ds_3.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteemarch"] = ds_3.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_4 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='April' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_4);
        if (ds_4.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteeapril"] = ds_4.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_5 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='May' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_5);
        if (ds_5.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteemay"] = ds_5.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_6 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='June' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_6);
        if (ds_6.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteejune"] = ds_6.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_7 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='July' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_7);
        if (ds_7.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteejuly"] = ds_7.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_8 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='August' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_8 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_8);
        if (ds_8.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteeaugust"] = ds_8.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_9 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='September' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_9);
        if (ds_9.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteeseptember"] = ds_9.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_10 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='October' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_10 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_10);
        if (ds_10.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteeoctober"] = ds_10.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_11 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='November' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_11 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_11);
        if (ds_11.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteenovember"] = ds_11.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

        string sqlstr_12 = @"SELECT distinct DATENAME(m, str([month]) + '/1/2019')[Month],COUNT(*)[Total] from tbl_training_schedul ts 
inner join tbl_intranet_employee_jobDetails jd on ts.dept_name=jd.dept_id
inner join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode
where DATENAME(m, str([month]) + '/1/2019')='December' and apvr.app_reportingmanager='" + usercode + "' group by month";
        DataSet ds_12 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_12);
        if (ds_12.Tables[0].Rows.Count > 0)
        {
            Session["MyReporteedecember"] = ds_12.Tables[0].Rows[0]["Total"].ToString();
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------

    }

    #endregion

    #region Binding Of My Trainings Status

    protected void bind_MyTrainingstatus()
    {
        string sqlstr = @"select distinct  ts.training_code,ts.id,ts.training_name,ts.createdby,dep.department_name,ts.dept_name as deptid,
CONVERT(varchar(40),ts.fromdate,106) as FromDate,CONVERT(varchar(40),ts.todate,106) as ToDate,ts.module_name,
CASE  WHEN ts.faculty LIKE '% %' THEN LEFT(ts.faculty, Charindex(' ', ts.faculty) - 1) ELSE ts.faculty END as Faculty
from tbl_training_schedul ts
left join tbl_intranet_employee_jobDetails emp on ts.dept_name=emp.dept_id
left join dbo.tbl_internate_departmentdetails dep on ts.dept_name=dep.departmentid 
where ts.approverstatus='1' and emp.empcode='" + usercode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdmytrainings.DataSource = ds;
        grdmytrainings.DataBind();
    }

    #endregion

    #region Binding of Grid PreRender

    protected void grdmytrainings_PreRender(object sender, EventArgs e)
    {
        if (grdmytrainings.Rows.Count > 0)
        {
            grdmytrainings.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion

}