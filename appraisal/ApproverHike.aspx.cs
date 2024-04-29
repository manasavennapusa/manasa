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
//using System.Transactions;
using System.Activities.Statements;

public partial class Appraisal_ApproverHike : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] == null)
            Response.Redirect("~/notlogged.aspx");
        _userCode = Session["empcode"].ToString();
        if (!IsPostBack)
        {
            getActiveCycle();
            LoadAppraisalData();
        }
        if (Request.QueryString["edit"] != null)
        {
            Output.Show("Hike Approved By Virtual Head Successfully");
        }
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

    private void LoadAppraisalData()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                //                cmd.CommandText = @"     
                //select 
                //  a.assessment_id,
                //  a.empcode, 
                //  j.emp_fname,
                //  h.ishike,
                //  h.onhold,
                //  h.reasonforno
                //   from tbl_appraisal_hike h
                //    inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id
                //    inner join tbl_appraisal_approvers r on r.appcycle_id = a.appcycle_id and a.empcode = r.empcode
                //    left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
                //     where  
                //     r.app_reportingmanager = @approvercode and
                //     h.approvalstatus = 1 and
                //     h.hikestatus = 0 and
                //     a.appcycle_id = @appcycleid";

                cmd.CommandText = @"select a.assessment_id,a.empcode, j.emp_fname,h.ishike,h.onhold,h.reasonforno,h.hikestatus,h.APP_year,h.quater
from tbl_appraisal_hike h
inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id
inner join tbl_employee_approvers r on   a.empcode = r.empcode
left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
where r.clr_department = '" + _userCode + "' and h.hikestatus = 'P' and a.appcycle_id = '" + Convert.ToInt32(ViewState["appcycle"]) + "'";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                //cmd.Parameters.Add("@appcycleid", SqlDbType.Int).Value = Convert.ToInt32(ViewState["appcycle"]);
                //cmd.Parameters.Add("@approvercode", SqlDbType.VarChar, 50).Value = Session["empcode"].ToString();

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                grid.DataSource = dt;
                grid.DataBind();

            }
        }
    }

    protected void ddlHike_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.Parent.Parent;
        DropDownList ddlOnHold = (DropDownList)row.FindControl("ddlOnHold");
        TextBox txtReason = (TextBox)row.FindControl("txtReason");

        if (ddl.SelectedValue == "1")
        {
            ddlOnHold.SelectedValue = "2";
            ddlOnHold.Enabled = false;
            txtReason.Enabled = false;
            txtReason.Text = "";
        }
        else if (ddl.SelectedValue == "2")
        {
            ddlOnHold.SelectedValue = "2";
            ddlOnHold.Enabled = false;
            txtReason.Enabled = true;
            txtReason.Focus();
        }
        else
        {
            ddlOnHold.Enabled = true;
            txtReason.Enabled = true;
        }

    }

    protected void ddlOnHold_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        GridViewRow row = (GridViewRow)ddl.Parent.Parent;
        DropDownList ddlHike = (DropDownList)row.FindControl("ddlHike");
        TextBox txtReason = (TextBox)row.FindControl("txtReason");

        if (ddl.SelectedValue == "1")
        {
            ddlHike.SelectedValue = "0";
            ddlHike.Enabled = false;
            txtReason.Enabled = false;
            txtReason.Text = "";
        }
        else
        {
            ddlHike.Enabled = true;
            txtReason.Enabled = true;
        }
    }

    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            int id = (int)grid.DataKeys[e.NewEditIndex].Value;

            DropDownList ddlHike = (DropDownList)grid.Rows[e.NewEditIndex].FindControl("ddlHike");
            DropDownList ddlOnHold = (DropDownList)grid.Rows[e.NewEditIndex].FindControl("ddlOnHold");
            TextBox txtReason = (TextBox)grid.Rows[e.NewEditIndex].FindControl("txtReason");
            TextBox txtComments = (TextBox)grid.Rows[e.NewEditIndex].FindControl("txtComments");
            TextBox txtHikeInPercent = (TextBox)grid.Rows[e.NewEditIndex].FindControl("txtHike");
            Label quater = (Label)grid.Rows[e.NewEditIndex].FindControl("labelquert");
            Label App_year = (Label)grid.Rows[e.NewEditIndex].FindControl("lebelyear");
            Label empCode = (Label)grid.Rows[e.NewEditIndex].FindControl("lblempCode");
            Label empName = (Label)grid.Rows[e.NewEditIndex].FindControl("lblempName");

            int hike = Convert.ToInt32(txtHikeInPercent.Text);

            if (txtHikeInPercent.Text == "")
            {
                Output.Show("Please Enter Hike(%) !!!");
                return;
            }

            if (hike >= 101)
            {
                Output.Show("Hike(%) should be less than or equal to 100(%)");
                return;
            }

            // If Hike == Yes
            if (ddlHike.SelectedValue == "1")
            {
                string str5 = @"update tbl_appraisal_hike
 set ishike ='1',onhold ='2',reasonforno = '" + txtReason.Text + "',approvalstatus = 'VH', hikeInPercent = '" + txtHikeInPercent.Text + "',hikestatus='P1' where assessmentid ='" + id + "' and APP_year='"+ App_year.Text +"'";
                SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                string str6 = @"declare @id int; set @id = (select id from tbl_appraisal_hike where assessmentid = '" + id + "' and status = 1); insert into tbl_appraisal_hike_comments (hikeid,empcode,comments,commentdate,level,status,LM_created_by,appcycle_id,APP_year,quater) values (@id,'" + empCode.Text + "','" + txtComments.Text + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "',1,1,'" + _userCode + "'," + ViewState["appcycle"] + ", '" + App_year.Text + "','" + quater.Text + "')";
                SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                _Transaction.Commit();
                //Output.Show("Hike Approved By Line Manager Successfully");
                //Response.Redirect(Request.RawUrl);

                Response.Redirect("ApproverHike.aspx?edit=true");

                //Update(id, 1, 2, txtReason.Text, 2, txtComments.Text, txtHikeInPercent.Text);
                //Int64 assessmentId, int isHike, int onHold, string reason, int approvalstatus, string comments, string hikePercent
                //DataSet dsEmpAppvrDet = GetAllDetails(empCode.Text);
                //string from = ConfigurationManager.AppSettings["FromEmail"];
                //string[] toBH = { dsEmpAppvrDet.Tables[0].Rows[0]["official_email_id"].ToString() };
                //string userName = empName.Text;

                //string lmName = dsEmpAppvrDet.Tables[0].Rows[0]["name"].ToString();
                //string selEmpCode = empCode.Text;

                //string bodyLM = EmailBodyApprover(from, lmName, userName, selEmpCode);
                ////SendMail(from, "Approve Hike - Pending", bodyLM, toBH);
            }
            // If Hike == No
            else if (ddlHike.SelectedValue == "2")
            {
                if (txtReason.Text.Trim() == "")
                {
                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please enter reason for No hike.');", true);
                    txtReason.Focus();
                    return;
                }
                string str5 = @"update tbl_appraisal_hike
 set ishike ='2',onhold ='2',reasonforno = '" + txtReason.Text + "',approvalstatus = 'VH', hikeInPercent = '" + txtHikeInPercent.Text + "',hikestatus='P1' where assessmentid ='" + id + "' and APP_year='" + App_year.Text + "'";
                SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                string str6 = @"declare @id int; set @id = (select id from tbl_appraisal_hike where assessmentid = '" + id + "' and status = 1); insert into tbl_appraisal_hike_comments (hikeid,empcode,comments,commentdate,level,status,LM_created_by,appcycle_id,APP_year,quater) values (@id,'" + empCode.Text + "','" + txtComments.Text + "','" + DateTime.Today + "',1,1,'" + _userCode + "'," + ViewState["appcycle"] + ", '" + App_year.Text + "','" + quater.Text + "')";
                SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                _Transaction.Commit();
                //Output.Show("Hike Approved By Line Manager Successfully");
                //Response.Redirect(Request.RawUrl);

                Response.Redirect("ApproverHike.aspx?edit=true");

                //Update(id, 2, 2, txtReason.Text, 2, txtComments.Text, txtHikeInPercent.Text);

            }
            // If Hold == Yes
            else if (ddlOnHold.SelectedValue == "1")
            {
                string str5 = @"update tbl_appraisal_hike
 set ishike ='0',onhold ='1',reasonforno = '" + txtReason.Text + "',approvalstatus = 'N', hikeInPercent = '" + txtHikeInPercent.Text + "',hikestatus='P1' where assessmentid ='" + id + "' and APP_year='" + App_year.Text + "'";
                SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                string str6 = @"declare @id int; set @id = (select id from tbl_appraisal_hike where assessmentid = '" + id + "'); insert into tbl_appraisal_hike_comments (hikeid,empcode,comments,commentdate,level,status,LM_created_by,appcycle_id,APP_year,quater) values (@id,'" + empCode.Text + "','" + txtComments.Text + "','" + DateTime.Today.ToString("yyyy-MM-dd") + "',1,1,'" + _userCode + "'," + ViewState["appcycle"] + ", '" + App_year.Text + "','" + quater.Text + "')";
                SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                _Transaction.Commit();
                //Output.Show("Hike Approved By Line Manager Successfully");
                //Response.Redirect(Request.RawUrl);

                Response.Redirect("ApproverHike.aspx?edit=true");

                //Update(id, 0, 1, "", 2, txtComments.Text, txtHikeInPercent.Text);
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

    private void Update(Int64 assessmentId, int isHike, int onHold, string reason, int approvalstatus, string comments, string hikePercent)
    {

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"
update tbl_appraisal_hike
 set ishike = @ishike,
     onhold = @onhold,
     reasonforno = @reasonforno,
     approvalstatus = @approvalstatus,
     hikeInPercent = @hikeInPercent
   where assessmentid = @assessmentid and 
        status = 1;

declare @id bigint;
set @id = (select id from tbl_appraisal_hike where assessmentid = @assessmentid and status = 1);


insert into tbl_appraisal_hike_comments (hikeid,empcode,comments,commentdate,level,status) values (@id,@empcode,@comments,getdate(),@level,1);";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@ishike", SqlDbType.Int).Value = isHike;
                cmd.Parameters.Add("@onhold", SqlDbType.Int).Value = onHold;
                cmd.Parameters.Add("@reasonforno", SqlDbType.VarChar, 1000).Value = reason;
                cmd.Parameters.Add("@approvalstatus", SqlDbType.Int).Value = approvalstatus;
                cmd.Parameters.Add("@assessmentid", SqlDbType.BigInt).Value = assessmentId;

                cmd.Parameters.Add("@empcode", SqlDbType.VarChar, 50).Value = Session["empcode"].ToString();
                cmd.Parameters.Add("@comments", SqlDbType.VarChar, 1000).Value = comments;
                cmd.Parameters.Add("@level", SqlDbType.Int, 1000).Value = 1;
                cmd.Parameters.Add("@hikeInPercent", SqlDbType.VarChar, 10).Value = hikePercent;

                //using (TransactionScope scope = new TransactionScope())
                //{
                if (cmd.ExecuteNonQuery() > 0)
                {
                    LoadAppraisalData();

                    //scope.Complete();
                }
                //}

            }
        }

    }

    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            Label lblOnHold = (Label)e.Row.FindControl("lblOnHold");
            Label lblHike = (Label)e.Row.FindControl("lblHike");

            DropDownList ddlHike = (DropDownList)e.Row.FindControl("ddlHike");
            DropDownList ddlOnHold = (DropDownList)e.Row.FindControl("ddlOnHold");

            TextBox txtReason = (TextBox)e.Row.FindControl("txtReason");

            ddlHike.SelectedValue = lblHike.Text;
            ddlOnHold.SelectedValue = lblOnHold.Text;

            // If Hike == Yes
            if (lblHike.Text.Trim() == "1")
            {
                ddlOnHold.Enabled = false;
                txtReason.Enabled = false;

            }  // If Hike == No
            else if (lblHike.Text.Trim() == "2")
            {
                ddlOnHold.Enabled = false;

            }
            else if (lblOnHold.Text.Trim() == "1")
            {
                ddlHike.Enabled = false;
                txtReason.Enabled = false;
            }

        }
    }

//    private DataSet GetAllDetails(string employeeCode)
//    {
//        string strAllemail;
//        DataSet dsAllemail = new DataSet();
//        var activity = new DataActivity();
//        try
//        {
//            SqlConnection connection = activity.OpenConnection();
//            strAllemail = @"DECLARE @lmCode varchar(50) 
//set @lmCode = (select app_reportingmanager from dbo.tbl_employee_approvers 
//where empcode = '" + employeeCode + "') select jd.official_email_id, jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name from dbo.tbl_intranet_employee_jobDetails jd where jd.empcode = @lmCode";
//            dsAllemail = SQLServer.ExecuteDataset(connection, CommandType.Text, strAllemail);
//        }
//        catch (Exception ex)
//        {
//            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
//            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
//        }
//        finally
//        {
//            activity.CloseConnection();
//        }
//        return dsAllemail;
//    }

//    private string EmailBodyApprover(string from, string approverName, string userName, string userCode)
//    {
//        string s =
//@"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>
//<html lang='en'>
//<head>
//
//    <meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>
//
//    <style type='text/css'>
//        body, td, div, p, a, input
//        {
//            font-family: arial, sans-serif;
//        }
//    </style>
//
//    <meta http-equiv='X-UA-Compatible' content='IE=edge'>
//    <title>Appraisal Hike</title>
//    <style type='text/css'>
//        body, td
//        {
//            font-size: 13px;
//        }
//
//        a:link, a:active
//        {
//            color: #1155CC;
//            text-decoration: none;
//        }
//
//        a:hover
//        {
//            text-decoration: underline;
//            cursor: pointer;
//        }
//
//        a:visited
//        {
//            color: #6611CC;
//        }
//
//        img
//        {
//            border: 0px;
//        }
//
//        pre
//        {
//            white-space: pre;
//            white-space: -moz-pre-wrap;
//            white-space: -o-pre-wrap;
//            white-space: pre-wrap;
//            word-wrap: break-word;
//            max-width: 800px;
//            overflow: auto;
//        }
//
//        .logo
//        {
//            left: -7px;
//            position: relative;
//        }
//    </style>
//</head>
//<body>
//    <div class='bodycontainer'>
//
//
//        <div class='maincontent'>
//
//            <table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>
//                <tr>
//
//                    <tr>
//                        <td colspan='2'><font size='-1' class='recipient'>
//                            <div></div>
//                        </font>
//                            <tr>
//                                <td colspan='2'>
//                                    <table width='100%' cellpadding='12' cellspacing='0' border='0'>
//                                        <tr>
//                                            <td>
//                                                <div style='overflow: hidden;'>
//                                                    <font size='-1'>
//                                                        <div id='leaveid'>
//                                                            <table width='100%'>
//                                                                <tbody>
//                                                                    
//                                                                    <tr>
//                                                                        <td style='border-bottom: 1px solid #ccc; font: 12px arial'>
//                                                                            <div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Appraisal Hike</span></div>
//                                                                        </td>
//                                                                        <td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>
//                                                                    </tr>
//                                                                </tbody>
//                                                            </table>
//                                                            <br>
//                                                            <p><b>Dear " + approverName + @",</b></p>
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>You have a pending hike by " + userName + @" - " + userCode + @".</p>
//
//                                                            <p>Click here - https://aditi.sdlapps.com </p>
//                                                            
//                                                            <p>
//                                                                <b>Regards,<br><br>
//                                                                    People Department<br><br>
//                                                                </b>
//                                                            </p>
//                                                            <br>
//
//                                                            <table width='100%'>
//                                                                <tbody>
//                                                                    <tr>
//                                                                        <td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>
//                                                                            <hr>
//                                                                            <br>
//                                                                            <b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may:
//                                                                            <br>
//                                                                                (1) Call our 24-hour Customer Care or<br>
//                                                                                (2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>
//                                                                            <br>
//                                                                            <hr>
//                                                                            <br>
//                                                                        </td>
//                                                                    </tr>
//                                                                </tbody>
//                                                            </table>
//
//                                                        </div>
//                                                    </font>
//                                                </div>
//                                    </table>
//            </table>
//        </div>
//    </div>
//
//</body>
//</html>";

//        return s;
//    }

}

