using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


public partial class appraisal_ViewEmpgoalstatusHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetDetails();
            LoadAppraisalQuarterData();
        }
    }
    void GetDetails()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
  select 
a.empcode, 
j.emp_fname,
convert(varchar(11),j.emp_doj,101) emp_doj,
j.emp_gender,
stat.employeestatus,
b.branch_name,
g.designationname,
a.APP_year,
c.from_month,
c.from_year,
c.to_month,
c.to_year,
case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze

from tbl_appraisal_assessment a 
inner join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
inner join tbl_intranet_designation g on g.id = j.degination_id
inner join tbl_intranet_branch_detail b on b.branch_id = j.branch_id
inner join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
inner join tbl_appraisal_eligible_employee empelg on empelg.empcode=a.empcode 
and a.appcycle_id =empelg.appcycle_id AND a.APP_year=empelg.APP_year
inner join tbl_intranet_employee_status stat on stat.id=j.emp_status
  
  where a.assessment_id = @assessmentid";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["assessment_id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    lblDOJ.Text = r["emp_doj"].ToString();
                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    //lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze"].ToString();
                }

            }
        }
    }

    private void LoadAppraisalQuarterData()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @" select q.empcode,
q.assessment_id, 
q.quater, 
q.create_by,
j.emp_fname,
convert(varchar(10),emp.create_date, 105) as create_date,
case when q.freeze = 0 then 'Unfreezed' when q.freeze = 1 then 'Freezed' end freeze, 
case when q.R_cycle = 0 then 'Pending in Employee' 
     when q.R_cycle = 2 then 'Pending in LM'
     when q.R_cycle = 3 then 'Pending in BH'
     when q.R_cycle = 4 then 'Approved by BH' end approvalstatus
    

 from tbl_appraisal_assessment q
 inner join tbl_appraisal_eligible_employee emp on emp.empcode=q.empcode
 inner join tbl_appraisal_cycle c on c.appcycle_id = q.appcycle_id
 AND q.APP_year=emp.APP_year and q.quater=emp.quater
 left join tbl_intranet_employee_jobDetails j on emp.empcode = j.empcode 
 where q.empcode = @empcode";





   
////select
////q.quaterid, 
////q.quatername, 
////q.initiatedby,
////j.emp_fname,
////q.initiateddate, 
////case when q.freeze = 0 then 'Unfreezed' when q.freeze = 6 then 'Freezed' end freeze, 
////case when q.approvalstatus = 0 then 'Pending in Employee' 
////     when q.approvalstatus = 1 then 'Pending in LM'
////     when q.approvalstatus = 3 then 'Approved by LM' end approvalstatus
////
//// from tbl_appraisal_assessment_quarter q
//// left join tbl_employee_jobDetails j on q.initiatedby = j.empcode
////  where assessmentid = @assessmentid";



                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = Convert.ToString(Request.QueryString["empcode"]);

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                string str = "";
                double average = 0;
                double total = 0;

                foreach (DataRow r in dt.Rows)
                {
                    cmd.Parameters.Clear();

                    //cmd.CommandText = "select * from tbl_appraisal_emp_goal_cycle1 where quater = @quater";
                    cmd.CommandText=@"select * from tbl_appraisal_emp_goal_cycle1 ap  
                                       inner join tbl_appraisal_eligible_employee emp on emp.empcode=ap.empcode
                                       inner join tbl_intranet_employee_jobDetails j on j.empcode=ap.empcode
                                       AND ap.APP_year=emp.APP_year and ap.quater=emp.quater and ap.applycyclid = emp.appcycle_id
                                         where ap.empcode=@empcode  and ap.quater=@quater";

                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = r["empcode"].ToString();
                    cmd.Parameters.Add("@quater", SqlDbType.VarChar, 50).Value = r["quater"].ToString();

                    sda = new SqlDataAdapter(cmd);
                    DataTable dtq = new DataTable();

                    sda.Fill(dtq);


                    str += @"<div class='alert alert-block alert-info fade in no-margin' style='border-bottom: 0px;'><h4 class='alert-heading'>" + r["quater"] + @"</h4><p> </p></div>";
                    str += "<table class='table'>";
                    str += @"          <tr>
                                                <td><b>Quarter Name</b></td>
                                                <td>" + r["quater"] + @"</td>
                                                <td><b>Initiated By</b></td>
                                                <td>" + r["emp_fname"] + @"</td>
                                                <td><b>Initiated Date</b></td>
                                                <td>" + r["create_date"] + @"</td>
                                            </tr>
                                                <tr>
                                                <td><b>Status</b></td>
                                                <td><label class='label label-success'>" + r["freeze"] + @"</label></td>
                                                <td><b>Approval Status</b></td>
                                                <td><label class='label label-success'>" + r["approvalstatus"] + @"</label></td>
                                                <td></td>
                                                <td></td>
                                            </tr>";
                    str += "</table>";
                    str += "<table class='table table-condensed table-bordered'>";
                    str += @"<tr>
                                                <td style='text-align: center;'><b>Sl#</b></td>
                                                <td style='text-align: center;'><b>Name of the Goal</b></td>
                                                <td style='text-align: center;'><b>Desired outcome/Impact</b></td>
                                                <td style='text-align: center;'><b>Milestone to check improvement</b></td>
                                                <td style='text-align: center;'><b>Timeline and support required.</b></td>
                                            </tr>";

                    int sum = 0;
                    int slno = 1;
                    foreach (DataRow rq in dtq.Rows)
                    {

                        str += @"<tr>
                                                <td style='text-align: center;'>" + slno + @"</td>
                                                <td>" + rq["role_name_of_the_goal"] + @"</td>
                                                <td>" + rq["kca_kra_desired_outcome_impact"] + @"</td>
                                                <td>" + rq["kpi_milestone_to_check_improvement"] + @"</td>
                                                <td>" + rq["weightage_timeline_and_support_required"] + @"</td>
                                            </tr>";

                        //if (rq["weightage"] != DBNull.Value)
                        //{
                        //    sum += Convert.ToInt32(rq["weightage"]);
                        //}

                        slno++;

                    }
                   // str += "<tr><td></td><td></td><td></td><td><b>Total Weightage: </b></td><td style='text-align:right;'>" + sum + "</td></tr>";
                    str += "</table>";

//                    cmd.CommandText = @"select ap.assessment_id , ap.empcode , j.emp_fname, emp_overall_cmt, mgr_overall_cmt, emp_overall_rating,
//                                      mgr_overall_rating from tbl_appraisal_assessment ap  inner join tbl_intranet_employee_jobDetails j on 
//                                       ap.empcode = j.empcode where ap.quater= @quater";


                    cmd.CommandText = @"select ap.assessment_id , ap.empcode , j.emp_fname, emp_overall_cmt, mgr_overall_cmt, emp_overall_rating,
                                      mgr_overall_rating from tbl_appraisal_assessment ap  
                                       inner join tbl_appraisal_eligible_employee emp on emp.empcode=ap.empcode
                                       inner join tbl_intranet_employee_jobDetails j on j.empcode=ap.empcode
                                       AND ap.APP_year=emp.APP_year and ap.quater=emp.quater and ap.appcycle_id = emp.appcycle_id
                                     where ap.empcode=@empcode  and ap.quater=@quater";
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = r["empcode"].ToString();
                    cmd.Parameters.Add("@quater", SqlDbType.VarChar, 50).Value = r["quater"].ToString();

                    sda = new SqlDataAdapter(cmd);
                    dt = new DataTable();

                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow rc in dt.Rows)
                        {
                            str += @"<div class='alert alert-block alert-info fade in no-margin' style='border:0px'>
                                                 <p  style='color: #428bca; font-size: 14px; font-weight: 400;'>" + rc["emp_fname"] + " Comments  :  <span style='color: #1a1a1a;font-size: 11px;font-weight: 400;'>" + rc["emp_overall_cmt"] + " </span></div><br/>";
                            str += @"<div class='alert alert-block alert-info fade in no-margin' style='border:0px'><p  style='color: #428bca; font-size: 14px; font-weight: 400;'>Approver Comments :</p><p><b> " + rc["mgr_overall_cmt"] + " </b></p></div><br/>";



                            str += @"<div class='alert alert-block alert-info fade in no-margin' ><h4 class='alert-heading'>Emp Average rating :</h4><p><b> " + rc["emp_overall_rating"] + " </b></p></div>";
                            str += @"<div class='alert alert-block alert-info fade in no-margin'><h4 class='alert-heading'>Manager Average rating :</h4><p><b> " + rc["mgr_overall_rating"] + " </b></p></div><br/>";

                            //if (rc["emp_overall_rating"] != DBNull.Value)
                            //{
                            //    sum += Convert.ToInt32(rc["emp_overall_rating"]);
                            //}
                            //if (rc["emp_overall_rating"] != DBNull.Value)
                            //{
                            //    sum += Convert.ToInt32(rc["emp_overall_rating"]);
                            //}


                        }
                    }


                    //total += sum;

                }


                //average = total / 2.0;

                //str += @"<div class='alert alert-block alert-info fade in no-margin'><h4 class='alert-heading'>Average rating :</h4><p><b> " + average + " </b></p></div>";

                result.InnerHtml = str;

            }
        }
    }
}