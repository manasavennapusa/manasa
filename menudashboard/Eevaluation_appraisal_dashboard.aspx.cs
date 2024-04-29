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

public partial class menudashboard_Eevaluation_appraisal_dashboard : System.Web.UI.Page
{
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string companyid, usercode, roleid, rolename, image, app_cycleid, gender;

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
            bind_FromToAppraisal();
            app_cycleid = Session["cycleid"].ToString();
            bindFreze_UnFreze_Status();
            bindMyReporteeApprailsaStatus();
            bindMyApprailsaStatus();
        }
        app_cycleid = Session["cycleid"].ToString();

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

    #region Binding of Appraisal From-To

    protected void bind_FromToAppraisal()
    {
        DataSet ds = new DataSet();
        string sqlstr = @"select appcycle_id,from_year,from_month,to_year,to_month,freeze,create_by,create_date,update_by,update_date,status 
from tbl_appraisal_cycle order by appcycle_id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["cycleid"] = ds.Tables[0].Rows[0]["appcycle_id"].ToString();

            lbl_from_month.Text = ds.Tables[0].Rows[0]["from_month"].ToString();
            lbl_from_year.Text = ds.Tables[0].Rows[0]["from_year"].ToString();

            lbl_to_month.Text = ds.Tables[0].Rows[0]["to_month"].ToString();
            lbl_to_year.Text = ds.Tables[0].Rows[0]["to_year"].ToString();
        }
    }

    #endregion

    #region Binding of Freeze / UnFreeze Status For Appraisal

    protected void bindFreze_UnFreze_Status()
    {

        string sqlstr = @"select COUNT(*)[status] from tbl_appraisal_assessment a 
left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
where c.freeze = 1 and a.appcycle_id='" + app_cycleid + "' select COUNT(*)[status] from tbl_appraisal_assessment a left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id where c.freeze = 0 and a.appcycle_id='" + app_cycleid + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["Freezed"] = ds.Tables[0].Rows[0]["status"].ToString();
            Session["UnFreezed"] = ds.Tables[1].Rows[0]["status"].ToString();

            string tot_1 = Session["Freezed"].ToString();
            string tot_2 = Session["UnFreezed"].ToString();
        }
    }

    #endregion

    #region Binding of Promotion And Hike Status

    [WebMethod]
    public static List<object> HikePromotionStatusChart()
    {

        string query = @"select 'Hike'[status],COUNT(*)[Total] from tbl_appraisal_hike h
inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id    
left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
union
select 'Promotion'[status],COUNT(*)[Total]
from tbl_appraisal_promotion h
inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id
left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode";
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

    #region Binding My Reportee Appraisal Status

    protected void bindMyReporteeApprailsaStatus()
    {
        string sqlstr = @"select 'Total Employees'[Details],COUNT(*)[Total] from tbl_intranet_employee_jobDetails jd inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode  where jd.emp_doleaving is null and jd.Status=1 
and apvr.app_reportingmanager='" + usercode + "' union all select 'Total Eligible Employees'[Details],COUNT(*)[Total] from tbl_appraisal_eligible_employee elgemp inner join tbl_employee_approvers apvr on elgemp.empcode=apvr.empcode where apvr.app_reportingmanager='" + usercode + "' and appcycle_id='" + app_cycleid + "' union all select 'Not Eligible Employees'[Details], (select COUNT(*)[Total] from tbl_intranet_employee_jobDetails jd inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode where jd.emp_doleaving is null and jd.Status=1 and apvr.app_reportingmanager='" + usercode + "') - (select COUNT(*)[Total] from tbl_appraisal_eligible_employee elgemp inner join tbl_employee_approvers apvr on elgemp.empcode=apvr.empcode where apvr.app_reportingmanager='" + usercode + "')[Total]";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["TotEmployee"] = ds.Tables[0].Rows[0]["Details"].ToString();
            Session["TotEmployeeCount"] = ds.Tables[0].Rows[0]["Total"].ToString();

            Session["TotEmployee1"] = ds.Tables[0].Rows[1]["Details"].ToString();
            Session["TotEmployeeCount1"] = ds.Tables[0].Rows[1]["Total"].ToString();

            Session["TotEmployee2"] = ds.Tables[0].Rows[2]["Details"].ToString();
            Session["TotEmployeeCount2"] = ds.Tables[0].Rows[2]["Total"].ToString();
        }

    }

    #endregion

    #region Binding My Appraisal Status

    protected void bindMyApprailsaStatus()
    {
        //        string sqlstr = @"declare @manager varchar(50) set @manager=(select apvr.app_reportingmanager from tbl_appraisal_eligible_employee  elgemp inner join tbl_employee_approvers apvr on elgemp.empcode=apvr.empcode
        //where apvr.empcode='" + usercode + "') select 'Total Employees'[Details],COUNT(*)[Total]  from tbl_intranet_employee_jobDetails jd inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode where jd.emp_doleaving is null and jd.Status=1 and apvr.app_reportingmanager=@manager union all select 'Total Eligible Employees'[Details],COUNT(*)[Total] from tbl_appraisal_eligible_employee elgemp inner join tbl_employee_approvers apvr on elgemp.empcode=apvr.empcode where apvr.app_reportingmanager=@manager union all select 'Not Eligible Employees'[Details],(select COUNT(*)[Total] from tbl_intranet_employee_jobDetails jd inner join tbl_employee_approvers apvr on jd.empcode=apvr.empcode where jd.emp_doleaving is null and jd.Status=1 and apvr.app_reportingmanager=@manager) - (select COUNT(*)[Total] from tbl_appraisal_eligible_employee elgemp inner join tbl_employee_approvers apvr on elgemp.empcode=apvr.empcode where apvr.app_reportingmanager=@manager)[Total]";

        string sqlstr = @"select empappr.appcycle_id,isnull(emp_fname ,'')+'' +isnull( emp_m_name,'')+ '' +isnull( emp_l_name,'') as name,
rtrim(empjob.empcode) as empcode,empdesg.designationname as designation,empdept.department_name as dept,
convert(varchar(10),empjob.emp_doj,101) as emp_doj,(case when appast.G1_cycle='0' then 'Not Inititated' 
when appast.G1_cycle='1' then 'Initiated' end )as GoalStatus,
(case when R_cycle='0' then 'Pending' when appast.R_cycle='1'  then 'Pending' when   R_cycle='2' then 'Pending at LM'
when   R_cycle='3' then 'Pending at BH' when   R_cycle='4' then 'Rating Completed' end )as RatingStatus,
(case when  appast.I_cycle=0  then 'Not Inititated' when appast.I_cycle=1  then 'Inititated' end )as IncreamentStatus,
empappr.status from tbl_intranet_employee_jobDetails empjob
inner join tbl_intranet_designation empdesg on empjob.degination_id=empdesg.id
inner join tbl_internate_departmentdetails empdept on empjob.dept_id=empdept.departmentid
inner join tbl_appraisal_eligible_employee empappr on empjob.empcode=empappr.empcode
inner join tbl_appraisal_assessment appast on appast.empcode=empappr.empcode
inner join tbl_appraisal_rating_details_1 rating on rating.empcode=appast.empcode and empappr.appcycle_id =appast.appcycle_id
where 1=1 AND rating.empcode='" + usercode + "'and empappr.appcycle_id='" + app_cycleid.ToString() + "'";

        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            GrdMyAppraisalStatus.DataSource = ds;
            GrdMyAppraisalStatus.DataBind();
        }

    }

    #endregion

    #region Binding Grid PreRender

    protected void GrdMyAppraisalStatus_PreRender(object sender, EventArgs e)
    {
        if (GrdMyAppraisalStatus.Rows.Count > 0)
        {
            GrdMyAppraisalStatus.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    #endregion

}