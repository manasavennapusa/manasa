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
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menudashboard_employee_dashboard : System.Web.UI.Page
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
            chart_bind();
            AttritionDataOverAll();
            bind_Reportestatus();
            bind_IndirectReportestatus();
        }
        if (roleid == "13")
        {
            row_4.Visible = true;
        }
        else if (roleid == "1")
        {
            Response.Redirect("~/viewProfile.aspx");
        }
        else
        {
            row_dept_loc_headcount.Visible = true;
            row_monthlyjoin_attrition.Visible = true;
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

    #region Binding of DepartmentwiseHeadcountDistribution
    [WebMethod]
    public static List<object> GetChartData()
    {

        string query = @"select dept.department_name,count(*)[TotalEmployee] from tbl_intranet_employee_jobDetails jd 
inner join tbl_internate_departmentdetails dept on dept.departmentid=jd.dept_id 
where jd.emp_doleaving is null and jd.Status=1 group by dept.department_name";

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

    #region Binding of LocationwiseHeadcountDistribution
    [WebMethod]
    public static List<object> GetLocChartData()
    {
        string query = @"select bd.branch_name,count(*)[TotalEmployee] from tbl_intranet_employee_jobDetails jd 
inner join tbl_intranet_branch_detail bd on bd.branch_id=jd.branch_id 
where jd.emp_doleaving is null and jd.Status=1 group by bd.branch_name";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "branch_name","TotalEmployee"
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
                        sdr["branch_name"],sdr["TotalEmployee"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }

    }
    #endregion

    #region Binding of MonthlyJoineeAndResigneeChart

    private DataTable GetData()
    {
        DataTable dt = new DataTable();
        //        string query = @"select top 5 empcode,DATEPART(MONTH,emp_doj)[Month],emp_status,emp_doleaving 
        //from tbl_intranet_employee_jobdetails where emp_doleaving is not null";

        string query = @"
SELECT distinct 'Jan'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='1' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='1' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Feb'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='2' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='2' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Mar'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='3' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='3' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Apr'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='4' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='4' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'May'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='5' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='5' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Jun'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='6' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='6' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Jul'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='7' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='7' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Aug'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='8' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='8' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Sep'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='9' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='9' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Oct'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='10' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='10' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Nov'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='11' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='11' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails

union all

SELECT distinct 'Dec'[Month],
( SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is null
and MONTH(emp_doj)='12' and YEAR(emp_doj)=YEAR(GETDATE())) as JoiningsOfMonth,
(SELECT COUNT(*) FROM tbl_intranet_employee_jobdetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='12' and YEAR(emp_doleaving)=YEAR(GETDATE())) as ResigneesOfMonth
FROM tbl_intranet_employee_jobdetails";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(dt);
                con.Close();
                return dt;
            }
        }
    }

    private void chart_bind()
    {
        DataTable dt = new DataTable();
        StringBuilder str_1 = new StringBuilder();
        try
        {
            dt = GetData();
            str_1.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
            google.setOnLoadCallback(drawChart);
            function drawChart() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'Month');
            data.addColumn('number', 'JoiningsOfMonth');
            data.addColumn('number', 'ResigneesOfMonth');
            data.addRows(" + dt.Rows.Count + ");");

            Int32 i;

            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {
                str_1.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["Month"].ToString() + "');");
                str_1.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["JoiningsOfMonth"].ToString() + ") ;");
                str_1.Append("data.setValue(" + i + "," + 2 + "," + dt.Rows[i]["ResigneesOfMonth"].ToString() + ");");
            }
            str_1.Append(" var chart = new google.visualization.LineChart(document.getElementById('chart_div'));");
            str_1.Append(" chart.draw(data, {width: 500, height: 270, animation: {duration: 2000,easing: 'linear', startup: true},");
            str_1.Append("hAxis: {title: 'Month', titleTextStyle: {color: 'green' , fontSize: '13'}},legend: {position:'top'},");
            str_1.Append("}); }");
            str_1.Append("</script>");
            lt.Text = str_1.ToString().TrimEnd(',').Replace('*', '"');
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
    }

    #endregion

    #region Binding Of Attrition Rate

    private void AttritionDataOverAll()
    {
        GetHires();
        GetExits();
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select COUNT(*)[TotalEmployee] 
from tbl_intranet_employee_jobDetails jd
inner join tbl_intranet_branch_detail bd on jd.branch_id=bd.branch_id
inner join tbl_intranet_companydetails cd on bd.company_id=cd.companyid
where emp_doleaving is null and status=1 group by cd.companyname";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            Session["TotalEmployee"] = ds.Tables[0].Rows[0]["TotalEmployee"].ToString();
            float TotalEmployee = float.Parse(ds.Tables[0].Rows[0]["TotalEmployee"].ToString());

            float NewHirJan = float.Parse(Session["NewHirJan"].ToString());
            float ExitJan = float.Parse(Session["ExitJan"].ToString());

            float totalEmpJan = TotalEmployee - float.Parse(Session["NewHirJan"].ToString()) + float.Parse(Session["ExitJan"].ToString());
            float totalEmpJan_1 = (TotalEmployee + totalEmpJan) / 2;
            float totalEmpJan_2 = float.Parse(Session["ExitJan"].ToString()) / totalEmpJan_1 * 100;
            int jan = Convert.ToInt32(totalEmpJan_2);
            Session["TotalAttrnJan"] = jan.ToString();

            float totalEmpFeb = TotalEmployee - float.Parse(Session["NewHirFeb"].ToString()) + float.Parse(Session["ExitFeb"].ToString());
            float totalEmpFeb_1 = (TotalEmployee + totalEmpFeb) / 2;
            float totalEmpFeb_2 = float.Parse(Session["ExitFeb"].ToString()) / totalEmpFeb_1 * 100;
            int feb = Convert.ToInt32(totalEmpFeb_2);
            Session["TotalAttrnFeb"] = feb.ToString();

            float totalEmpMar = TotalEmployee - float.Parse(Session["NewHirMar"].ToString()) + float.Parse(Session["ExitMar"].ToString());
            float totalEmpMar_1 = (TotalEmployee + totalEmpMar) / 2;
            float totalEmpMar_2 = float.Parse(Session["ExitMar"].ToString()) / totalEmpMar_1 * 100;
            int mar = Convert.ToInt32(totalEmpMar_2);
            Session["TotalAttrnMar"] = mar.ToString();

            float totalEmpApr = TotalEmployee - float.Parse(Session["NewHirApr"].ToString()) + float.Parse(Session["ExitApr"].ToString());
            float totalEmpApr_1 = (TotalEmployee + totalEmpApr) / 2;
            float totalEmpApr_2 = float.Parse(Session["ExitApr"].ToString()) / totalEmpApr_1 * 100;
            int apr = Convert.ToInt32(totalEmpApr_2);
            Session["TotalAttrnApr"] = apr.ToString();

            float totalEmpMay = TotalEmployee - float.Parse(Session["NewHirMay"].ToString()) + float.Parse(Session["ExitMay"].ToString());
            float totalEmpMay_1 = (TotalEmployee + totalEmpMay) / 2;
            float totalEmpMay_2 = float.Parse(Session["ExitMay"].ToString()) / totalEmpMay_1 * 100;
            int may = Convert.ToInt32(totalEmpMay_2);
            Session["TotalAttrnMay"] = may.ToString();

            float totalEmpJun = TotalEmployee - float.Parse(Session["NewHirJun"].ToString()) + float.Parse(Session["ExitJun"].ToString());
            float totalEmpJun_1 = (TotalEmployee + totalEmpJun) / 2;
            float totalEmpJun_2 = float.Parse(Session["ExitJun"].ToString()) / totalEmpJun_1 * 100;
            int jun = Convert.ToInt32(totalEmpJun_2);
            Session["TotalAttrnJun"] = jun.ToString();

            float totalEmpJul = TotalEmployee - float.Parse(Session["NewHirJul"].ToString()) + float.Parse(Session["ExitJul"].ToString());
            float totalEmpJul_1 = (TotalEmployee + totalEmpJul) / 2;
            float totalEmpJul_2 = float.Parse(Session["ExitJul"].ToString()) / totalEmpJul_1 * 100;
            int jul = Convert.ToInt32(totalEmpJul_2);
            Session["TotalAttrnJul"] = jul.ToString();

            float totalEmpAug = TotalEmployee - float.Parse(Session["NewHirAug"].ToString()) + float.Parse(Session["ExitAug"].ToString());
            float totalEmpAug_1 = (TotalEmployee + totalEmpAug) / 2;
            float totalEmpAug_2 = float.Parse(Session["ExitAug"].ToString()) / totalEmpAug_1 * 100;
            int aug = Convert.ToInt32(totalEmpAug_2);
            Session["TotalAttrnAug"] = aug.ToString();

            float totalEmpSep = TotalEmployee - float.Parse(Session["NewHirSep"].ToString()) + float.Parse(Session["ExitSep"].ToString());
            float totalEmpSep_1 = (TotalEmployee + totalEmpSep) / 2;
            float totalEmpSep_2 = float.Parse(Session["ExitSep"].ToString()) / totalEmpSep_1 * 100;
            int sep = Convert.ToInt32(totalEmpSep_2);
            Session["TotalAttrnSep"] = sep.ToString();

            float totalEmpOct = TotalEmployee - float.Parse(Session["NewHirOct"].ToString()) + float.Parse(Session["ExitOct"].ToString());
            float totalEmpOct_1 = (TotalEmployee + totalEmpOct) / 2;
            float totalEmpOct_2 = float.Parse(Session["ExitOct"].ToString()) / totalEmpOct_1 * 100;
            int oct = Convert.ToInt32(totalEmpOct_2);
            Session["TotalAttrnOct"] = oct.ToString();

            float totalEmpNov = TotalEmployee - float.Parse(Session["NewHirNov"].ToString()) + float.Parse(Session["ExitNov"].ToString());
            float totalEmpNov_1 = (TotalEmployee + totalEmpNov) / 2;
            float totalEmpNov_2 = float.Parse(Session["ExitNov"].ToString()) / totalEmpNov_1 * 100;
            int nov = Convert.ToInt32(totalEmpNov_2);
            Session["TotalAttrnNov"] = nov.ToString();

            float totalEmpDec = TotalEmployee - float.Parse(Session["NewHirDec"].ToString()) + float.Parse(Session["ExitDec"].ToString());
            float totalEmpDec_1 = (TotalEmployee + totalEmpDec) / 2;
            float totalEmpDec_2 = float.Parse(Session["ExitDec"].ToString()) / totalEmpDec_1 * 100;
            int dec = Convert.ToInt32(totalEmpDec_2);
            Session["TotalAttrnDec"] = dec.ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void GetExits()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            string queryJan = @"SELECT COUNT(*)[JanExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='1' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsJan = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJan);
            Session["ExitJan"] = dsJan.Tables[0].Rows[0]["JanExit"].ToString();

            string queryFeb = @"SELECT COUNT(*)[FebExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='2' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsFeb = SQLServer.ExecuteDataset(connection, CommandType.Text, queryFeb);
            Session["ExitFeb"] = dsFeb.Tables[0].Rows[0]["FebExit"].ToString();

            string queryMar = @"SELECT COUNT(*)[MarExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='3' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsMar = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMar);
            Session["ExitMar"] = dsMar.Tables[0].Rows[0]["MarExit"].ToString();

            string queryApr = @"SELECT COUNT(*)[AprExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='4' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsApr = SQLServer.ExecuteDataset(connection, CommandType.Text, queryApr);
            Session["ExitApr"] = dsApr.Tables[0].Rows[0]["AprExit"].ToString();

            string queryMay = @"SELECT COUNT(*)[MayExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='5' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsMay = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMay);
            Session["ExitMay"] = dsMay.Tables[0].Rows[0]["MayExit"].ToString();

            string queryJun = @"SELECT COUNT(*)[JunExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='6' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsJun = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJun);
            Session["ExitJun"] = dsJun.Tables[0].Rows[0]["JunExit"].ToString();

            string queryJul = @"SELECT COUNT(*)[JulExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='7' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsJul = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJul);
            Session["ExitJul"] = dsJul.Tables[0].Rows[0]["JulExit"].ToString();

            string queryAug = @"SELECT COUNT(*)[AugExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='8' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsAug = SQLServer.ExecuteDataset(connection, CommandType.Text, queryAug);
            Session["ExitAug"] = dsAug.Tables[0].Rows[0]["AugExit"].ToString();

            string querySep = @"SELECT COUNT(*)[SepExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='9' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsSep = SQLServer.ExecuteDataset(connection, CommandType.Text, querySep);
            Session["ExitSep"] = dsSep.Tables[0].Rows[0]["SepExit"].ToString();

            string queryOct = @"SELECT COUNT(*)[OctExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='10' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsOct = SQLServer.ExecuteDataset(connection, CommandType.Text, queryOct);
            Session["ExitOct"] = dsOct.Tables[0].Rows[0]["OctExit"].ToString();

            string queryNov = @"SELECT COUNT(*)[NovExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='11' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsNov = SQLServer.ExecuteDataset(connection, CommandType.Text, queryNov);
            Session["ExitNov"] = dsNov.Tables[0].Rows[0]["NovExit"].ToString();

            string queryDec = @"SELECT COUNT(*)[DecExit] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is not null
and MONTH(emp_doleaving)='12' and YEAR(emp_doleaving)=YEAR(GETDATE())";
            DataSet dsDec = SQLServer.ExecuteDataset(connection, CommandType.Text, queryDec);
            Session["ExitDec"] = dsDec.Tables[0].Rows[0]["DecExit"].ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            //Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void GetHires()
    {
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            string queryJan = @"SELECT COUNT(*)[JanJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='1' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsJan = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJan);
            Session["NewHirJan"] = dsJan.Tables[0].Rows[0]["JanJoin"].ToString();

            string queryFeb = @"SELECT COUNT(*)[FebJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='2' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsFeb = SQLServer.ExecuteDataset(connection, CommandType.Text, queryFeb);
            Session["NewHirFeb"] = dsFeb.Tables[0].Rows[0]["FebJoin"].ToString();

            string queryMar = @"SELECT COUNT(*)[MarJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='3' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsMar = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMar);
            Session["NewHirMar"] = dsMar.Tables[0].Rows[0]["MarJoin"].ToString();

            string queryApr = @"SELECT COUNT(*)[AprJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='4' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsApr = SQLServer.ExecuteDataset(connection, CommandType.Text, queryApr);
            Session["NewHirApr"] = dsApr.Tables[0].Rows[0]["AprJoin"].ToString();

            string queryMay = @"SELECT COUNT(*)[MayJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='5' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsMay = SQLServer.ExecuteDataset(connection, CommandType.Text, queryMay);
            Session["NewHirMay"] = dsMay.Tables[0].Rows[0]["MayJoin"].ToString();

            string queryJun = @"SELECT COUNT(*)[JunJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='6' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsJun = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJun);
            Session["NewHirJun"] = dsJun.Tables[0].Rows[0]["JunJoin"].ToString();

            string queryJul = @"SELECT COUNT(*)[JulJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='7' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsJul = SQLServer.ExecuteDataset(connection, CommandType.Text, queryJul);
            Session["NewHirJul"] = dsJul.Tables[0].Rows[0]["JulJoin"].ToString();

            string queryAug = @"SELECT COUNT(*)[AugJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='8' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsAug = SQLServer.ExecuteDataset(connection, CommandType.Text, queryAug);
            Session["NewHirAug"] = dsAug.Tables[0].Rows[0]["AugJoin"].ToString();

            string querySep = @"SELECT COUNT(*)[SepJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='9' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsSep = SQLServer.ExecuteDataset(connection, CommandType.Text, querySep);
            Session["NewHirSep"] = dsSep.Tables[0].Rows[0]["SepJoin"].ToString();

            string queryOct = @"SELECT COUNT(*)[OctJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='10' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsOct = SQLServer.ExecuteDataset(connection, CommandType.Text, queryOct);
            Session["NewHirOct"] = dsOct.Tables[0].Rows[0]["OctJoin"].ToString();

            string queryNov = @"SELECT COUNT(*)[NovJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='11' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsNov = SQLServer.ExecuteDataset(connection, CommandType.Text, queryNov);
            Session["NewHirNov"] = dsNov.Tables[0].Rows[0]["NovJoin"].ToString();

            string queryDec = @"SELECT COUNT(*)[DecJoin] FROM tbl_intranet_employee_jobDetails WHERE emp_doleaving is null
and MONTH(emp_doj)='12' and YEAR(emp_doj)=YEAR(GETDATE())";
            DataSet dsDec = SQLServer.ExecuteDataset(connection, CommandType.Text, queryDec);
            Session["NewHirDec"] = dsDec.Tables[0].Rows[0]["DecJoin"].ToString();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            //Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    #endregion

    #region Binding Of Reportee Status

    protected void bind_Reportestatus()
    {
        string sqlstr = @"select ej.empcode empcode,emp_fname as name,designationname,photo,
isnull(mode,'') as mode from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode 
and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null and ej.status=1
and ep.app_reportingmanager='" + usercode + "' order by ej.empcode";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdreportees.DataSource = ds;
        grdreportees.DataBind();
    }

    #endregion

    #region Binding Of Indirect Reportee Status

    protected void bind_IndirectReportestatus()
    {
        string sqlstr = @"select isnull(emp_fname ,'''')+''+isnull( emp_m_name,'''')+ ''+isnull( emp_l_name,'''') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,app.app_reportingmanager,empjob.photo 
from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_employee_approvers app on app.empcode=empjob.empcode
where empjob.emp_status in (1,3) and app.app_reportingmanager in
(
select ej.empcode empcode from tbl_intranet_employee_jobDetails ej 
inner join tbl_employee_approvers ep on ep.empcode=ej.empcode
left join tbl_intranet_designation dg on dg.id=ej.degination_id 
left join tbl_payroll_employee_attendence_detail ea on ea.EMPCODE=ej.empcode 
and DATE=convert(varchar(10),GETDATE(),101) where emp_doleaving is null and ej.status=1
and ep.app_reportingmanager='" + usercode + "') order by empjob.empcode";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            grdindirectreportees.DataSource = ds;
            grdindirectreportees.DataBind();
        }
    }

    #endregion

    #region Gridview PreRender

    protected void grdreportees_PreRender(object sender, EventArgs e)
    {
        if (grdreportees.Rows.Count > 0)
        {
            grdreportees.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void grdindirectreportees_PreRender(object sender, EventArgs e)
    {
        if (grdindirectreportees.Rows.Count > 0)
        {
            grdindirectreportees.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion

}


