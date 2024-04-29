using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Configuration;
using DataAccessLayer;

public partial class Appraisal_InitiateHike : System.Web.UI.Page
{
    string sqlstr = "";
    DataActivity DataActivity = new DataActivity();
    string UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] == null)
            Response.Redirect("~/notlogged.aspx");
        UserCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            getActiveCycle();
            //LoadAppraisalData();
            bindempforHike();
        }
        if (Request.QueryString["edit"] != null)
        {
            Output.Show("Hike Initiated Successfully");
        }

        // btnInitiate.Attributes.Add("onclick", "javascript:" + btnInitiate.ClientID + ".disabled=true;" + ClientScript.GetPostBackEventReference(btnInitiate, ""));
    }

    protected void grid_PreRender(object sender, EventArgs e)
    {
        if (grid.Rows.Count > 0)
            grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        else grid.EmptyDataText = "No Records Found";
    }

    private void getActiveCycle()
    {
        SqlParameter[] sqlParam = new SqlParameter[5];

        SqlConnection Connection = null;
        try
        {

            Connection = DataActivity.OpenConnection();

            string str1 = @"select count(*) from tbl_appraisal_cycle where freeze!=1 ";
            int cnt = (int)SQLServer.ExecuteScalar(Connection, CommandType.Text, str1);
            if (cnt > 0)
            {
                int cycle = (int)SQLServer.ExecuteScalar(Connection, CommandType.StoredProcedure, "sp_appraisal_getapprisalcycle");
                if (cycle != 0)
                {
                    ViewState["appcycle"] = cycle;
                }
                else
                {
                    Output.Show("Please Mark Active Appraisal Cycle");
                }
            }
            else
            {
                Output.Show("Please Create Appraisal Cycle");
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

//    private void LoadAppraisalData()
//    {
//        using (SqlConnection conn = new SqlConnection())
//        {
//            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
//            conn.Open();

//            using (SqlCommand cmd = new SqlCommand())
//            {
//                //                cmd.CommandText = @"select 
//                //a.assessment_id,
//                //a.empcode, 
//                //j.emp_fname,
//                //convert(varchar(11),j.emp_doj,101) emp_doj,
//                //j.emp_gender,
//                //j.emp_status,
//                //g.designationname,
//                //case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze
//                // from tbl_appraisal_assessment a
//                //  left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
//                //  left join dbo.tbl_intranet_designation g on g.id = a.desigid
//                //  left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
//                //  where a.appcycle_id = '" + Convert.ToInt32(Session["appcycle"]) + "' and a.status = 1 and a.assessment_id not in ( select assessmentid from tbl_appraisal_hike where status = 1)";

////                cmd.CommandText = @"select a.assessment_id,a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,j.emp_status,
////g.designationname,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze
////from tbl_appraisal_assessment a
////left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
////left join dbo.tbl_intranet_designation g on g.id = a.desigid
////left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
////where a.appcycle_id = '" + Convert.ToInt32(ViewState["appcycle"]) + "' and a.status = 1 and a.R_cycle=4 and a.hike_status is null";

//                cmd.CommandText = @"
//select a.assessment_id,a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,j.emp_status,
//g.designationname,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,
//a.G1_cycle,a.G2_cycle,a.appcycle_id,a.status,a.R_cycle
//from tbl_appraisal_assessment a
//left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
//left join dbo.tbl_intranet_designation g on g.id = a.desigid
//left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
//where a.G1_cycle=1 and a.G2_cycle=1 and a.appcycle_id = '" + Convert.ToInt32(ViewState["appcycle"]) + "' and a.status = 1 and a.freeze=2 and a.hike_status is null";

//                cmd.CommandType = CommandType.Text;
//                cmd.Connection = conn;

//                //cmd.Parameters.Add("@appcycleid", SqlDbType.Int).Value = Convert.ToInt32(ViewState["appcycle"]);

//                DataTable dt = new DataTable();

//                SqlDataAdapter sda = new SqlDataAdapter(cmd);
//                sda.Fill(dt);


//                grid.DataSource = dt;
//                grid.DataBind();

//            }
//        }
//    }


    protected void bindempforHike()
    {
        try
        {
//            string sqlstr = @"select a.assessment_id,a.empcode, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,j.emp_status,
//            g.designationname,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,
//            a.G1_cycle,a.G2_cycle,a.appcycle_id,a.status,a.R_cycle,a.hike_status
//            from tbl_appraisal_assessment a
//            left join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
//            left join dbo.tbl_intranet_designation g on g.id = a.desigid
//            left join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
//            where a.G1_cycle=1 and a.G2_cycle=1 and a.appcycle_id = '" + Convert.ToInt32(ViewState["appcycle"]) + "' and a.status = 1 and a.freeze=2 and a.hike_status is null";
            string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
            DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query1);
            string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
            string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();

            string sqlstr = @"
select distinct a.empcode,a.assessment_id, j.emp_fname,convert(varchar(11),j.emp_doj,101) emp_doj,j.emp_gender,j.emp_status,
                        g.designationname,case when c.freeze = 0 then 'Unfreezed' when c.freeze = 1 then 'Freezed' end freeze,
                        a.G1_cycle,a.G2_cycle,a.appcycle_id,a.status,a.R_cycle,a.hike_status,a.APP_year,a.quater
                        from tbl_appraisal_assessment a
                        inner join tbl_appraisal_eligible_employee emp on emp.empcode=a.empcode
                        inner join dbo.tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
                        inner join dbo.tbl_intranet_designation g on g.id = j.degination_id
                        inner join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
                        where emp.create_by='" + UserCode + "' and  a.G1_cycle=1 and a.R_cycle=4  and a.status = 1 and a.freeze=0 and a.hike_status is null and a.quater in ('Q2') and c.status=1 and a.APP_year='" + APP_year + "'";
            DataSet ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
            grid.DataSource = ds;
            grid.DataBind();

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }

    }

    protected void chkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkAll = (CheckBox)grid.HeaderRow.FindControl("chkAll");

        if (chkAll.Checked)
        {
            foreach (GridViewRow r in grid.Rows)
            {
                CheckBox chk = (CheckBox)r.FindControl("chk");

                if (chk != null)
                {
                    if (chk.Checked == false)
                    {
                        chk.Checked = true;
                    }
                }
            }
        }
        else
        {
            foreach (GridViewRow r in grid.Rows)
            {
                CheckBox chk = (CheckBox)r.FindControl("chk");

                if (chk != null)
                {
                    if (chk.Checked == true)
                    {
                        chk.Checked = false;
                    }
                }
            }
        }
    }

    private DataTable CreateTable()
    {
        DataTable dt = new DataTable();

        DataColumn dc = new DataColumn();
        dc.ColumnName = "assessment";
        dc.DataType = Type.GetType("System.Int64");

        dt.Columns.Add(dc);

        return dt;
    }

    //protected void btnInitiate_Click(object sender, EventArgs e)
    //{
    //    DataTable dt = CreateTable();

    //    foreach (GridViewRow r in grid.Rows)
    //    {
    //        CheckBox chk = (CheckBox)r.FindControl("chk");

    //        if (chk != null)
    //        {
    //            if (chk.Checked == true)
    //            {
    //                Label lblAssessmentId = (Label)r.FindControl("lblAssessmentId");

    //                if (lblAssessmentId != null)
    //                {
    //                    DataRow row = dt.NewRow();
    //                    row["assessment"] = lblAssessmentId.Text;

    //                    dt.Rows.Add(row);
    //                }
    //                ViewState["selEmps"] = dt;
    //            }
    //        }
    //    }

    //    DataTable dtSel = new DataTable();
    //    foreach (GridViewRow gr in grid.Rows)
    //    {
    //        CheckBox chk = (CheckBox)gr.FindControl("chk");

    //        if (chk != null)
    //        {
    //            if (chk.Checked == true)
    //            {
    //                Label lblAssessmentId = (Label)gr.FindControl("lblAssessmentId");
    //                string cell_1_Value = grid.Rows[gr.RowIndex].Cells[2].Text;
    //                string cell_2_Value = grid.Rows[gr.RowIndex].Cells[3].Text;

    //                if (dtSel.Columns.Count == 0)
    //                {
    //                    dtSel.Columns.Add("empCode", typeof(string));
    //                    dtSel.Columns.Add("empName", typeof(string));
    //                }
    //                if (lblAssessmentId != null)
    //                {
    //                    DataRow row = dtSel.NewRow();
    //                    //row["assessment"] = lblAssessmentId.Text;
    //                    row["empCode"] = cell_1_Value;
    //                    row["empName"] = cell_2_Value;
    //                    dtSel.Rows.Add(row);
    //                }
    //                return;
    //            }
    //            else
    //            {
    //                Output.Show("Please Select Employee");
    //            }
    //        }
    //    }
    //    if (dt.Rows.Count > 0)
    //    {
    //        using (SqlConnection conn = new SqlConnection())
    //        {
    //            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
    //            conn.Open();

    //            using (SqlCommand cmd = new SqlCommand())
    //            {
    //                cmd.CommandText = "sp_appraisal_initiatehike";
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Connection = conn;

    //                SqlParameter p = new SqlParameter();
    //                p.ParameterName = "@dt";
    //                p.Value = dt;
    //                p.TypeName = "empassessmentid";
    //                cmd.Parameters.Add(p);

    //                p = new SqlParameter();
    //                p.ParameterName = "@initiateby";
    //                p.Value = Session["empcode"].ToString();
    //                p.SqlDbType = SqlDbType.VarChar;
    //                p.Size = 50;
    //                cmd.Parameters.Add(p);


    //                if (cmd.ExecuteNonQuery() > 0)
    //                {
    //                    for (int i = 0; i < dtSel.Rows.Count; i++)
    //                    {
    //                        DataSet dsEmpAppvrDet = GetAllDetails(dtSel.Rows[i]["empcode"].ToString());
    //                        string from = ConfigurationManager.AppSettings["FromEmail"];
    //                        string[] tolm = { dsEmpAppvrDet.Tables[0].Rows[0]["official_email_id"].ToString() };
    //                        string userName = dtSel.Rows[i]["empName"].ToString();

    //                        string lmName = dsEmpAppvrDet.Tables[0].Rows[0]["name"].ToString();
    //                        string selEmpCode = dtSel.Rows[i]["empcode"].ToString();

    //                        string bodyLM = EmailBodyApprover(from, lmName, userName, selEmpCode);
    //                        //SendMail(from, "Approve Hike - Pending", bodyLM, tolm);
    //                    }

    //                    LoadAppraisalData();
    //                }
    //            }
    //        }
    //    }
    //}

    private DataSet GetAllDetails(string employeeCode)
    {
        string strAllemail;
        DataSet dsAllemail = new DataSet();
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            strAllemail = @"DECLARE @lmCode varchar(50) 
set @lmCode = (select app_reportingmanager from dbo.tbl_employee_approvers 
where empcode = '" + employeeCode + "') select jd.official_email_id, jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name from dbo.tbl_intranet_employee_jobDetails jd where jd.empcode = @lmCode";
            dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
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
        return dsAllemail;
    }

    private string EmailBodyApprover(string from, string approverName, string userName, string userCode)
    {
        string s =
@"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>
<html lang='en'>
<head>

    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>

    <style type='text/css'>
        body, td, div, p, a, input
        {
            font-family: arial, sans-serif;
        }
    </style>

    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
    <title>Hike Initiation</title>
    <style type='text/css'>
        body, td
        {
            font-size: 13px;
        }

        a:link, a:active
        {
            color: #1155CC;
            text-decoration: none;
        }

        a:hover
        {
            text-decoration: underline;
            cursor: pointer;
        }

        a:visited
        {
            color: #6611CC;
        }

        img
        {
            border: 0px;
        }

        pre
        {
            white-space: pre;
            white-space: -moz-pre-wrap;
            white-space: -o-pre-wrap;
            white-space: pre-wrap;
            word-wrap: break-word;
            max-width: 800px;
            overflow: auto;
        }

        .logo
        {
            left: -7px;
            position: relative;
        }
    </style>
</head>
<body>
    <div class='bodycontainer'>


        <div class='maincontent'>

            <table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>
                <tr>

                    <tr>
                        <td colspan='2'><font size='-1' class='recipient'>
                            <div></div>
                        </font>
                            <tr>
                                <td colspan='2'>
                                    <table width='100%' cellpadding='12' cellspacing='0' border='0'>
                                        <tr>
                                            <td>
                                                <div style='overflow: hidden;'>
                                                    <font size='-1'>
                                                        <div id='leaveid'>
                                                            <table width='100%'>
                                                                <tbody>
                                                                    
                                                                    <tr>
                                                                        <td style='border-bottom: 1px solid #ccc; font: 12px arial'>
                                                                            <div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Hike Initiation</span></div>
                                                                        </td>
                                                                        <td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <br>
                                                            <p><b>Dear " + approverName + @",</b></p>
                                                            <p style='text-align: justify; color: #000000; text-align: justify'>You have a pending hike by " + userName + @" - " + userCode + @".</p>

                                                            <p>Click here - https://aditi.sdlapps.com </p>
                                                            
                                                            <p>
                                                                <b>Regards,<br><br>
                                                                    People Department<br><br>
                                                                </b>
                                                            </p>
                                                            <br>

                                                            <table width='100%'>
                                                                <tbody>
                                                                    <tr>
                                                                        <td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>
                                                                            <hr>
                                                                            <br>
                                                                            <b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may:
                                                                            <br>
                                                                                (1) Call our 24-hour Customer Care or<br>
                                                                                (2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>
                                                                            <br>
                                                                            <hr>
                                                                            <br>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>

                                                        </div>
                                                    </font>
                                                </div>
                                    </table>
            </table>
        </div>
    </div>

</body>
</html>";

        return s;
    }

    protected void btncheckall_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow r in grid.Rows)
        {
            CheckBox chk = (CheckBox)r.FindControl("chk");

            if (chk != null)
            {
                if (chk.Checked == false)
                {
                    chk.Checked = true;
                }
            }
        }
    }

    protected void btn_initiate_hike_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            if (grid.Rows.Count > 0)
            {
                foreach (GridViewRow row in grid.Rows)
                {
                    int count = 0;
                    CheckBox chk = (CheckBox)row.FindControl("chk");
                    if (chk.Checked)
                    {
                        Label assessment_id = (Label)row.FindControl("lblAssessmentId");
                        Label emp_code = (Label)row.FindControl("lblempcode");
                        Label emp_name = (Label)row.FindControl("lblempname");
                        Label quater = (Label)row.FindControl("lblempstatus");
                        Label App_year = (Label)row.FindControl("lblaprstatus");
                        count = count + 1;

                        string str5 = @"insert into tbl_appraisal_hike(assessmentid,initiateby,initiateddate,approvalstatus,hikestatus,status,empcode,appcycle_id,APP_year,quater)
values('" + assessment_id.Text + "','" + UserCode + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "','0','P','1','" + emp_code.Text + "'," + ViewState["appcycle"] + ",'" + App_year.Text.ToString() + "','" + quater.Text + "')";
                        SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                        string str6 = @"update tbl_appraisal_assessment set hike_status='Initiated' where empcode='" + emp_code.Text + "' and appcycle_id=" + ViewState["appcycle"] + " and APP_year='" + App_year.Text.ToString() + "' and quater='" + quater.Text + "'";
                        SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                        _Transaction.Commit();
                        //Output.Show("Hike Initiated Successfully");
                        //Response.Redirect(Request.RawUrl);
                        //return;
                        Response.Redirect("InitiateHike.aspx?edit=true");
                    }
                    else
                    {
                        Output.Show("Please Select Employee");
                       // return;
                    }
                }
            }

        }
        catch (Exception ex)
        {
            //_Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

}