using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Appraisal_ViewAllGoalStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["id"] != null)
            {
                GetDetails();
                btnBack.Visible = true;
            }

            if (Request.QueryString["id_1"] != null)
            {
                GetDetails_1();
                btn_Back_1.Visible = true;
            }

            if (Request.QueryString["id_2"] != null)
            {
                GetDetails_2();
                btn_Back_2.Visible = true;
            }

            if (Request.QueryString["id_3"] != null)
            {
                GetDetails_3();
                btn_Back_3.Visible = true;
            }

            if (Request.QueryString["id_4"] != null)
            {
                GetDetails_4();
                btn_Back_4.Visible = true;
            }

            if (Request.QueryString["id_5"] != null)
            {
                GetDetails_5();
                btn_Back_5.Visible = true;
            }

            if (Request.QueryString["id_6"] != null)
            {
                GetDetails_6();
                btn_Back_6.Visible = true;
            }

            if (Request.QueryString["id_7"] != null)
            {
                GetDetails_7();
                btn_Back_7.Visible = true;
            }

            //LoadAppraisalQuarterData();
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
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    if (dt.Rows[0]["emp_doj"].ToString() != "")
                    {
                        lblDOJ.Text = Convert.ToDateTime(r["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        lblDOJ.Text = "";
                    }

                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_1()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_1"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    if (dt.Rows[0]["emp_doj"].ToString() != "")
                    {
                        lblDOJ.Text = Convert.ToDateTime(r["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        lblDOJ.Text = "";
                    }

                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_2()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_2"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    lblDOJ.Text = Convert.ToDateTime(r["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_3()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_3"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    lblDOJ.Text = Convert.ToDateTime(r["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_4()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_4"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

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
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_5()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_5"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

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
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_6()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_6"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    lblDOJ.Text = Convert.ToDateTime(r["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    void GetDetails_7()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,emp.employeestatus,g.designationname,c.from_month,
c.from_year,c.to_month,c.to_year,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,bd.branch_name,
case when a.freeze = 0 then 'Unfreezed' when a.freeze = 1 then 'Freezed' end freeze_1
from tbl_appraisal_assessment a
left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
left join dbo.tbl_intranet_designation g on g.id = j.degination_id
left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
left join dbo.tbl_intranet_employee_status emp on emp.id=j.emp_status
left join tbl_intranet_branch_detail bd on j.branch_id=bd.branch_id  where a.assessment_id = '" + Convert.ToInt32(Request.QueryString["id_7"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                foreach (DataRow r in dt.Rows)
                {
                    lblEmployeeCode.Text = r["empcode"].ToString();
                    lblEmployeeName.Text = r["emp_fname"].ToString();
                    lblDOJ.Text = Convert.ToDateTime(r["emp_doj"].ToString()).ToString("dd-MMM-yyyy");
                    lblBranch.Text = r["branch_name"].ToString();
                    lblDesignation.Text = r["designationname"].ToString();
                    // lblGrade.Text = r["gradename"].ToString();
                    lblGender.Text = r["emp_gender"].ToString();
                    lblEmployeeStatus.Text = r["employeestatus"].ToString();
                    lblAppraisalCycle.Text = r["from_month"].ToString() + "-" + r["from_year"].ToString() + " to " + r["to_month"].ToString() + "-" + r["to_year"].ToString();
                    lblAppraisalStatus.Text = r["freeze_1"].ToString();
                }

            }
        }
    }

    //    private void LoadAppraisalQuarterData()
    //    {
    //        using (SqlConnection conn = new SqlConnection())
    //        {
    //            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    //            conn.Open();

    //            using (SqlCommand cmd = new SqlCommand())
    //            {
    //                cmd.CommandText = @"     
    //select
    //q.quaterid, 
    //q.quatername, 
    //q.initiatedby,
    //j.emp_fname,
    //q.initiateddate, 
    //case when q.freeze = 0 then 'Unfreezed' when q.freeze = 6 then 'Freezed' end freeze, 
    //case when q.approvalstatus = 0 then 'Pending in Employee' 
    //     when q.approvalstatus = 1 then 'Pending in LM'
    //     when q.approvalstatus = 3 then 'Approved by LM' end approvalstatus
    //
    // from tbl_appraisal_assessment_quarter q
    // left join tbl_intranet_employee_jobDetails j on q.initiatedby = j.empcode
    //  where assessmentid = '" + Convert.ToInt32(Request.QueryString["id"]) + "'";

    //                cmd.CommandType = CommandType.Text;
    //                cmd.Connection = conn;

    //                //cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = Convert.ToInt32(Request.QueryString["id"]);

    //                DataTable dt = new DataTable();

    //                SqlDataAdapter sda = new SqlDataAdapter(cmd);
    //                sda.Fill(dt);

    //                string str = "";
    //                double average = 0;
    //                double total = 0;

    //                foreach (DataRow r in dt.Rows)
    //                {
    //                    cmd.Parameters.Clear();

    //                    cmd.CommandText = "select * from tbl_appraisal_assessment_goals where status = 1 and quarterid = @quarterid";
    //                    cmd.Parameters.Add("@quarterid", SqlDbType.BigInt).Value = r["quaterid"].ToString();

    //                    sda = new SqlDataAdapter(cmd);
    //                    DataTable dtq = new DataTable();

    //                    sda.Fill(dtq);


    //                    str += @"<div class='alert alert-block alert-info fade in no-margin' style='border-bottom: 0px;'><h4 class='alert-heading'>" + r["quatername"] + @"</h4><p> </p></div>";
    //                    str += "<table class='table'>";
    //                    str += @"          <tr>
    //                                                <td><b>Quarter Name</b></td>
    //                                                <td>" + r["quatername"] + @"</td>
    //                                                <td><b>Initiated By</b></td>
    //                                                <td>" + r["emp_fname"] + @"</td>
    //                                                <td><b>Initiated Date</b></td>
    //                                                <td>" + r["initiateddate"] + @"</td>
    //                                            </tr>
    //                                                <tr>
    //                                                <td><b>Status</b></td>
    //                                                <td><label class='label label-success'>" + r["freeze"] + @"</label></td>
    //                                                <td><b>Approval Status</b></td>
    //                                                <td><label class='label label-success'>" + r["approvalstatus"] + @"</label></td>
    //                                                <td></td>
    //                                                <td></td>
    //                                            </tr>";
    //                    str += "</table>";
    //                    str += "<table class='table table-condensed table-bordered'>";
    //                    str += @"<tr>
    //                                                <td style='text-align: center;'><b>Sl#</b></td>
    //                                                <td style='text-align: center;'><b>Objective Measurement(s)/Metric(s)</b></td>
    //                                                <td style='text-align: center;'><b>Target</b></td>
    //                                                <td style='text-align: center;'><b>Actual Completion</b></td>
    //                                                <td style='text-align: center;'><b>Weightage</b></td>
    //                                            </tr>";

    //                    int sum = 0;
    //                    int slno = 1;
    //                    foreach (DataRow rq in dtq.Rows)
    //                    {

    //                        str += @"<tr>
    //                                                <td style='text-align: center;'>" + slno + @"</td>
    //                                                <td>" + rq["goal"] + @"</td>
    //                                                <td>" + rq["goaltarget"] + @"</td>
    //                                                <td>" + rq["actualcompletion"] + @"</td>
    //                                                <td style='width: 120px; text-align:right;'>" + rq["weightage"] + @"</td>
    //                                            </tr>";

    //                        if (rq["weightage"] != DBNull.Value)
    //                        {
    //                            sum += Convert.ToInt32(rq["weightage"]);
    //                        }

    //                        slno++;

    //                    }
    //                    str += "<tr><td></td><td></td><td></td><td><b>Total Weightage: </b></td><td style='text-align:right;'>" + sum + "</td></tr>";
    //                    str += "</table>";

    //                    cmd.CommandText = @"select c.id,c.quarterid,c.empcode, c.comments, c.commentdate, c.level, c.status,j.emp_fname from tbl_appraisal_comments c  inner join tbl_employee_jobDetails j on c.empcode = j.empcode where c.quarterid = @quarterid order by c.id";
    //                    cmd.CommandType = CommandType.Text;
    //                    cmd.Parameters.Clear();
    //                    cmd.Parameters.Add("@quarterid", SqlDbType.BigInt).Value = r["quaterid"].ToString();

    //                    sda = new SqlDataAdapter(cmd);
    //                    dt = new DataTable();

    //                    sda.Fill(dt);

    //                    if (dt.Rows.Count > 0)
    //                    {
    //                        foreach (DataRow rc in dt.Rows)
    //                        {
    //                            str += @"<div class='alert alert-block alert-info fade in no-margin' style='border:0px'>
    //                                                 <p style='color: #428bca; font-size: 13px; font-weight: 400;'>" + rc["emp_fname"] + " at <span style='color: #1a1a1a;font-size: 11px;font-weight: 400;'>" + rc["commentdate"] + " </span></p><br/><br/><p style='color: #4d4d4d;'> " + rc["comments"] + @" </p></div><br/>";
    //                        }
    //                    }


    //                    total += sum;

    //                }


    //                average = total / 4.0;

    //                str += @"<div class='alert alert-block alert-info fade in no-margin'><h4 class='alert-heading'>Average Weightage :</h4><p><b> " + average + " </b></p></div>";

    //                result.InnerHtml = str;

    //            }
    //        }
    //    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("InitiateHike.aspx");
    }

    protected void btn_Back_1_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproverHike.aspx");
    }

    protected void btn_Back_2_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproverHikeBH.aspx");
    }

    protected void btn_Back_3_Click(object sender, EventArgs e)
    {
        Response.Redirect("HikeStatus.aspx");
    }

    protected void btn_Back_4_Click(object sender, EventArgs e)
    {
        Response.Redirect("InitiatePromotion.aspx");
    }

    protected void btn_Back_5_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproverPromotion.aspx");
    }

    protected void btn_Back_6_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproverPromotionBH.aspx");
    }

    protected void btn_Back_7_Click(object sender, EventArgs e)
    {
        Response.Redirect("PromotionStatus.aspx");
    }

}