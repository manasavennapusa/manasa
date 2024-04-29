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

public partial class Appraisal_ApproverHikeBH : System.Web.UI.Page
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
        if (Request.QueryString["update"] != null)
        {
            Output.Show("Hike Approved By Business Head Successfully");
        }
        if (Request.QueryString["edit"] != null)
        {
            Output.Show("Hike Rejected By Business Head Successfully");
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
                //  case when h.ishike = 0 then 'Select'
                //       when h.ishike = 1 then 'Yes'
                //       when h.ishike = 2 then 'No' end ishike,
                //
                //  case when h.onhold = 0 then 'Select'
                //       when h.onhold = 1 then 'Yes'
                //       when h.onhold = 2 then 'No' end onhold,
                // 
                //  h.reasonforno, h.hikeInPercent
                //
                //   from tbl_appraisal_hike h
                //    inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id
                //    inner join tbl_appraisal_approvers r on r.appcycle_id = a.appcycle_id and a.empcode = r.empcode
                //    left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
                //     where 
                //     r.app_businesshead = @approvercode and
                //     h.approvalstatus = 2 and
                //     h.hikestatus = 0 and
                //     a.appcycle_id = @appcycleid";

                cmd.CommandText = @"select h.id,a.assessment_id,a.empcode, j.emp_fname,case when h.ishike = 0 then 'Select' when h.ishike = 1 then 'Yes'
when h.ishike = 2 then 'No' end ishike,case when h.onhold = 0 then 'Select' when h.onhold = 1 then 'Yes'
when h.onhold = 2 then 'No' end onhold,h.reasonforno, h.hikeInPercent,h.APP_year,h.quater
from tbl_appraisal_hike h
inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id
inner join tbl_employee_approvers r on  a.empcode = r.empcode
left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
where r.app_businesshead = '" + _userCode + "' and h.hikestatus = 'P1' and a.appcycle_id = '" + Convert.ToInt32(ViewState["appcycle"]) + "'";

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

    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            int id = (int)grid.DataKeys[e.NewEditIndex].Value;
            TextBox txtComments = (TextBox)grid.Rows[e.NewEditIndex].FindControl("txtComments");

            Label empCode = (Label)grid.Rows[e.NewEditIndex].FindControl("lblempCode");
            Label empName = (Label)grid.Rows[e.NewEditIndex].FindControl("lblempName");
            Label id_1 = (Label)grid.Rows[e.NewEditIndex].FindControl("lbl_id");
            Label quater = (Label)grid.Rows[e.NewEditIndex].FindControl("labelquert");
            Label App_year = (Label)grid.Rows[e.NewEditIndex].FindControl("lebelyear");

            string str5 = @"update tbl_appraisal_hike set approvalstatus = 'R',hikestatus='P1_R' where assessmentid = '" + id + "' and status = 1 and APP_year='"+ App_year.Text +"'";
            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

            string str6 = @"update tbl_appraisal_hike_comments set BH_comment='" + txtComments.Text + "',status=0,BH_created_by='" + _userCode + "',BH_created_date='" + DateTime.Today.ToString("yyyy-MM-dd") + "'  where hikeid = '" + id_1.Text + "' and APP_year='"+ App_year.Text +"'";
            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

            string str7 = @"update tbl_appraisal_assessment set hike_status='Rejected'  where assessment_id = '" + id + "' and APP_year='" + App_year.Text + "'";
            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str7);

            _Transaction.Commit();
            //Output.Show("Hike Rejected By Business Head Successfully");
            //Response.Redirect(Request.RawUrl);
            Response.Redirect("ApproverHikeBH.aspx?edit=true");
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

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            int id = (int)grid.DataKeys[e.RowIndex].Value;
            TextBox txtComments = (TextBox)grid.Rows[e.RowIndex].FindControl("txtComments");
            Label quater = (Label)grid.Rows[e.RowIndex].FindControl("labelquert");
            Label App_year = (Label)grid.Rows[e.RowIndex].FindControl("lebelyear");
            Label empCode = (Label)grid.Rows[e.RowIndex].FindControl("lblempCode");
            Label empName = (Label)grid.Rows[e.RowIndex].FindControl("lblempName");
            Label id_1 = (Label)grid.Rows[e.RowIndex].FindControl("lbl_id");

            string str5 = @"update tbl_appraisal_hike set approvalstatus = 'S',hikestatus='P1_S' where assessmentid = '" + id + "' and status = 1 and APP_year='" + App_year.Text + "'";
            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

            string str6 = @"update tbl_appraisal_hike_comments set BH_comment='" + txtComments.Text + "',status=2,BH_created_by='" + _userCode + "',BH_created_date='" + DateTime.Today.ToString("yyyy-MM-dd") + "'  where hikeid = '" + id_1.Text + "' and APP_year='" + App_year.Text + "'";
            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

            string str7 = @"update tbl_appraisal_assessment set hike_status='Approved'  where assessment_id = '" + id + "' and APP_year='" + App_year.Text + "'";
            SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str7);

            _Transaction.Commit();
            //Output.Show("Hike Approved By Business Head Successfully");
            //Response.Redirect(Request.RawUrl);
            Response.Redirect("ApproverHikeBH.aspx?update=true");
        }
        catch (Exception ex)
        {
           // _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
     
    }

//    private DataSet GetAllDetails(string selEmpCode)
//    {
//        string strAllemail;
//        DataSet dsAllemail = new DataSet();
//        var activity = new DataActivity();
//        try
//        {
//            SqlConnection connection = activity.OpenConnection();
//            strAllemail = @"DECLARE @hrCode varchar(50)
//
//select jd.official_email_id, ea.app_hr, jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as name 
//from tbl_intranet_employee_jobDetails jd inner join tbl_employee_approvers ea on ea.empcode = jd.empcode
//where jd.empcode = '" + selEmpCode + "' set @hrCode = (select app_hr from tbl_employee_approvers where empcode = '" + selEmpCode + "') select jd.official_email_id, jd.emp_fname+ ' ' + isnull(jd.emp_m_name,'') + ' ' + isnull(jd.emp_l_name,'') as hrname from tbl_intranet_employee_jobDetails jd where jd.empcode = @hrCode";
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

//    private string EmailBody(string from, string userName, string lmCode, string lmName)
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
//                                                            <p><b>Dear " + userName + @",</b></p>
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>Your hike form has been successfully approved by all the level of approvers " + lmName + @" - " + lmCode + @".</p>
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

//    private string EmailBodyApprover(string from, string emp_Code, string userName, string approverName)
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
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>Hike of " + userName + @" - " + emp_Code + @" has been approved successfully.</p>
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

//    private string EmailBodyRej(string from, string userName, string lmCode, string lmName)
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
//                                                            <p><b>Dear " + userName + @",</b></p>
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>Your hike form has been rejected by " + lmName + @" - " + lmCode + @".</p>
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

//    private string EmailBodyApproverRej(string from, string emp_Code, string userName, string approverName)
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
//                                                            <p style='text-align: justify; color: #000000; text-align: justify'>Hike of " + userName + @" - " + emp_Code + @" has been Rejected.</p>
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

    protected void btn_approve_all_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chk_empdetails");

                if (chkRow != null && chkRow.Checked)
                {
                    Connection = DataActivity.OpenConnection();
                    _Transaction = Connection.BeginTransaction();
                    //int id = (int)grid.DataKeys[e.RowIndex].Value;
                    //TextBox txtComments = (TextBox)grid.Rows[e.RowIndex].FindControl("txtComments");
                    //Label quater = (Label)grid.Rows[e.RowIndex].FindControl("labelquert");
                    //Label App_year = (Label)grid.Rows[e.RowIndex].FindControl("lebelyear");
                    //Label empCode = (Label)grid.Rows[e.RowIndex].FindControl("lblempCode");
                    //Label empName = (Label)grid.Rows[e.RowIndex].FindControl("lblempName");
                    //Label id_1 = (Label)grid.Rows[e.RowIndex].FindControl("lbl_id");

                    Label id = (Label)row.FindControl("lbl_asses");
                    TextBox txtComments = (TextBox)row.FindControl("txtComments");
                    Label empCode = (Label)row.FindControl("lblempCode");
                    Label empName = (Label)row.FindControl("lblempName");
                    Label id_1 = (Label)row.FindControl("lbl_id");
                    Label quater = (Label)row.FindControl("labelquert");
                    Label App_year = (Label)row.FindControl("lebelyear");

                    string str5 = @"update tbl_appraisal_hike set approvalstatus = 'S',hikestatus='P1_S' where assessmentid = '" + id.Text + "' and status = 1 and APP_year='" + App_year.Text + "'";
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                    string str6 = @"update tbl_appraisal_hike_comments set BH_comment='" + txtComments.Text + "',status=2,BH_created_by='" + _userCode + "',BH_created_date='" + DateTime.Today.ToString("yyyy-MM-dd") + "'  where hikeid = '" + id_1.Text + "' and APP_year='" + App_year.Text + "'";
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                    string str7 = @"update tbl_appraisal_assessment set hike_status='Approved'  where assessment_id = '" + id.Text + "' and APP_year='" + App_year.Text + "'";
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str7);

                    _Transaction.Commit();
                    //Output.Show("Hike Approved By Business Head Successfully");
                    //Response.Redirect(Request.RawUrl);
                }
            }
            Response.Redirect("ApproverHikeBH.aspx?update=true");
        }
        catch (Exception ex)
        {
            // _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
     
    }
    protected void btn_reject_all_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        try
        {
            foreach (GridViewRow row in grid.Rows)
            {
                CheckBox chkRow = (CheckBox)row.FindControl("chk_empdetails");

                if (chkRow != null && chkRow.Checked)
                {
                    Connection = DataActivity.OpenConnection();
                    _Transaction = Connection.BeginTransaction();
                    //int id = (int)grid.DataKeys[e.NewEditIndex].Value;
                    //TextBox txtComments = (TextBox)grid.Rows[e.NewEditIndex].FindControl("txtComments");

                    //Label empCode = (Label)grid.Rows[e.NewEditIndex].FindControl("lblempCode");
                    //Label empName = (Label)grid.Rows[e.NewEditIndex].FindControl("lblempName");
                    //Label id_1 = (Label)grid.Rows[e.NewEditIndex].FindControl("lbl_id");
                    //Label quater = (Label)grid.Rows[e.NewEditIndex].FindControl("labelquert");
                    //Label App_year = (Label)grid.Rows[e.NewEditIndex].FindControl("lebelyear");

                    Label id = (Label)row.FindControl("lbl_asses");
                    TextBox txtComments = (TextBox)row.FindControl("txtComments");
                    Label empCode = (Label)row.FindControl("lblempCode");
                    Label empName = (Label)row.FindControl("lblempName");
                    Label id_1 = (Label)row.FindControl("lbl_id");
                    Label quater = (Label)row.FindControl("labelquert");
                    Label App_year = (Label)row.FindControl("lebelyear");

                    string str5 = @"update tbl_appraisal_hike set approvalstatus = 'R',hikestatus='P1_R' where assessmentid = '" + id.Text + "' and status = 1 and APP_year='" + App_year.Text + "'";
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);

                    string str6 = @"update tbl_appraisal_hike_comments set BH_comment='" + txtComments.Text + "',status=0,BH_created_by='" + _userCode + "',BH_created_date='" + DateTime.Today.ToString("yyyy-MM-dd") + "'  where hikeid = '" + id_1.Text + "' and APP_year='" + App_year.Text + "'";
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str6);

                    string str7 = @"update tbl_appraisal_assessment set hike_status='Rejected'  where assessment_id = '" + id.Text + "' and APP_year='" + App_year.Text + "'";
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str7);

                    _Transaction.Commit();
                }
            }
            //Output.Show("Hike Rejected By Business Head Successfully");
            //Response.Redirect(Request.RawUrl);
            Response.Redirect("ApproverHikeBH.aspx?edit=true");
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

    protected void btn_chkall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid.Rows)
        {
            CheckBox chk = row.Cells[0].FindControl("chk_empdetails") as CheckBox;
            chk.Checked = true;
        }
    }

    protected void btn_unchkall_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid.Rows)
        {
            CheckBox chk = row.Cells[0].FindControl("chk_empdetails") as CheckBox;
            chk.Checked = false;
        }
    }
}

