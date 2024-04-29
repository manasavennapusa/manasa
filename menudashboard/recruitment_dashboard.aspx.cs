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

public partial class menudashboard_recruitment_dashboard : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string companyid, usercode, roleid, image, rolename, gender;
    StringBuilder str = new StringBuilder();

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
            bind_NoOfJobPosted_NoOfApplicants_TotalHired_Pendingposts();
        }
        if (roleid != "3" && roleid != "9" && roleid != "26")
        {
            row_4.Visible = true;
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

    #region Binding of Number Of Jobs Posted,Number Of Applications,Total Hired,Pending Posts
    protected void bind_NoOfJobPosted_NoOfApplicants_TotalHired_Pendingposts()
    {
        DataSet ds = new DataSet();
        DataSet ds_1 = new DataSet();
        DataSet ds_2 = new DataSet();
        DataSet ds_3 = new DataSet();

        string sqlstr = @"select SUM(total_no_posts)[TotalPost] from tbl_recruitment_requisition_form 
where status=1 ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        lbl_No_of_job_posted.Text = ds.Tables[0].Rows[0]["TotalPost"].ToString();

        string sqlstr_1 = @"select COUNT(*)[TotalApplicantions] from tbl_recruitment_candidate_registration cr 
inner join tbl_recruitment_requisition_form rrf on rrf.id=cr.rrf_id
inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
where rrf.status=1";
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        lbl_no_of_Application.Text = ds_1.Tables[0].Rows[0]["TotalApplicantions"].ToString();

        string sqlstr_2 = @"select COUNT(*)[TotalHired] from tbl_recruitment_candidate_registration cr 
inner join tbl_recruitment_requisition_form rrf on rrf.id=cr.rrf_id
inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
inner join tbl_recruitment_interviewrrating ir on ci.candidateid=ir.Candidate_id
where rrf.status=1 and ir.status='S'";
        ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        lbl_total_hired.Text = ds_2.Tables[0].Rows[0]["TotalHired"].ToString();

        string sqlstr_3 = @"select	COUNT(*)[RejectedApplications]
from tbl_recruitment_candidate_registration cr 
inner join tbl_recruitment_requisition_form rrf on rrf.id=cr.rrf_id
inner join tbl_recruitment_candidate_interview ci on cr.id=ci.candidateid
left join tbl_recruitment_interviewrrating ir on cr.id=ir.Candidate_id
inner join tbl_intranet_designation d on rrf.designationid=d.id
where ci.round_1_status='R' or ci.round_2_status='R' or ir.status='R' and rrf.status=1";
        ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        //int totalpost = Convert.ToInt32(ds_3.Tables[0].Rows[0]["total_no_posts"].ToString());
        //int totalhired = Convert.ToInt32(ds_3.Tables[1].Rows[0]["TotalHired"].ToString());
        //int offeraccepted = totalpost - totalhired;
        //lbl_pending_posts.Text = offeraccepted.ToString();
        lbl_rejected_posts.Text = ds_3.Tables[0].Rows[0]["RejectedApplications"].ToString();
    }
    #endregion

    #region Binding of Applications For Hirings
    [WebMethod]
    public static List<object> HiringApplicationChart()
    {
        // string query = @"select rrf_code,total_no_posts as Total from tbl_recruitment_requisition_form where status=1 
        //union all
        //select rrf.rrf_code,COUNT(*)[Total] from tbl_recruitment_candidate_registration rcr
        //inner join tbl_recruitment_candidate_interview ci on rcr.rrf_id=ci.candidateid
        //inner join tbl_recruitment_interviewrrating ir on ci.candidateid=ir.Candidate_id
        //left join tbl_recruitment_requisition_form rrf on rrf.id=RCR.rrf_id
        //where ci.round_1_status='R' or ci.round_2_status='R' or ir.status='R' group by rrf.rrf_code

        string query = @"select rrf_code,total_no_posts as Total,status from tbl_recruitment_requisition_form where status=1";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "rrf_code","Total"
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
                        sdr["rrf_code"],sdr["Total"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }

    }
    #endregion

    #region Binding of Headcount by Recruite Positions

    [WebMethod]
    public static List<object> GetHeadCountChart()
    {

        string query = @"select rrf.rrf_code,rrf.total_no_posts[TotalPost],COUNT(ir.rrf_code)[FilledPost],(rrf.total_no_posts-COUNT(ir.rrf_code))[PendingPost] 
from tbl_recruitment_requisition_form rrf
inner join tbl_recruitment_interviewrrating	ir on  ir.rrf_code=rrf.rrf_code	where ir.status='S' and rrf.status=1
group by rrf.rrf_code,rrf.total_no_posts";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "rrf_code", "FilledPost"
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
                        sdr["rrf_code"], sdr["FilledPost"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }

        //        string query = @"select rrf.rrf_code,rrf.total_no_posts[TotalPost],COUNT(ir.rrf_code)[FilledPost],(rrf.total_no_posts-COUNT(ir.rrf_code))[PendingPost] 
        //from tbl_recruitment_requisition_form rrf
        //inner join tbl_recruitment_interviewrrating	ir on  ir.rrf_code=rrf.rrf_code	where ir.status='S' and rrf.status=1
        //group by rrf.rrf_code,rrf.total_no_posts";

        //        DataTable dt = GetData(query);

        //        List<object> chartData = new List<object>();

        //        List<string> countries = (from p in dt.AsEnumerable()
        //                                  select p.Field<string>("rrf_code")).Distinct().ToList();

        //        countries.Insert(0, "rrf_code");

        //        chartData.Add(countries.ToArray());

        //        List<int> years = (from p in dt.AsEnumerable()
        //                           select p.Field<int>("TotalPost")).Distinct().ToList();

        //        foreach (int year in years)
        //        {
        //            List<object> totals = (from p in dt.AsEnumerable()
        //                                   where p.Field<int>("TotalPost") == year
        //                                   select p.Field<int>("FilledPost")).Cast<object>().ToList();

        //            totals.Insert(0, year.ToString());

        //            chartData.Add(totals.ToArray());
        //        }
        //        return chartData;
        //    }
        //    private static DataTable GetData(string query)
        //    {
        //        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        //        using (SqlConnection con = new SqlConnection(constr))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter(query, con))
        //            {
        //                DataTable dt = new DataTable();
        //                sda.Fill(dt);
        //                return dt;
        //            }
        //        }
    }

    #endregion

    #region Binding of Recruitment Status
    [WebMethod]
    public static List<object> RecruitmentStatusChart(string empcode)
    {
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "status","Total"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("sp_rec_status_in_recruitment_dashboard_for_admin"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@empcode", empcode);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["status"],sdr["Total"]
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