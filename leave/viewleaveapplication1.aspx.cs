using Common.Console;
using Common.Data;
using Common.Encode;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Smart.HR.Common.Mail.Module;

public partial class leave_viewleaveapplication1 : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr; int error;
    //========================== Created By Ramu Nunna on 10-Dec-2014 ==================================================//
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                Common.Encode.QueryString q = new Common.Encode.QueryString();
                hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
                bindemployee_detail();
                fetchleavedata();
            }

        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    #region Bind The Employee Details
    protected void bindemployee_detail()
    {

        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
            adjustgrid.DataSource = null;
            adjustgrid.DataBind();

        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    #region Fetch Leave Details
    protected void fetchleavedata()
    {
        try
        {
            if (hidd_leaveapplyid.Value == "0")
            {
                Output.Show("Problem fetchin leave data,try latter");
                return;
            }
            SqlParameter[] sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, _userCode);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewleaveapply", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_leave.Text = ds.Tables[0].Rows[0]["leavetype"].ToString();
                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["leavemode"]))
                {
                    divfull.Visible = true;
                    divhalf.Visible = false;
                    DateTime lblsdate, lbledate;
                    lbl_sdate.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd - MMM - yyyy");
                    lbl_edate.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd - MMM - yyyy");
                }
                else
                {
                    divfull.Visible = false;
                    divhalf.Visible = true;
                    //commented
                    //DateTime lblselect = Utility.dataformat(ds.Tables[0].Rows[0]["hdate"].ToString());

                    lbl_select.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd - MMM - yyyy");
                    lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
                }

                if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
                {
                    txt_cancel.Enabled = false;
                    btn_modify.Enabled = false;
                    txt_comment.Enabled = false;
                }
                if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "6") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
                {
                    btn_modify.Enabled = false;
                }
                lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
                lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
                lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
                lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a target='_blank' href='Upload/Doc/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
                  "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No existing file found";
            }
            else
            {
                Output.Show("No data available");
                return;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                adjustgrid.DataSource = ds.Tables[1];
                adjustgrid.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                approvergrid.DataSource = ds.Tables[2];
                approvergrid.DataBind();
            }
            if (ds.Tables[0].Rows[0]["leaveid"].ToString() == ConfigurationManager.AppSettings["FL"].ToString())
            {
                divfurnalleave.Visible = true;
                lblrelation.Text = ds.Tables[0].Rows[0]["relation"].ToString();
            }
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
    }

    void SendEmail(int leaveid, string appSenderName)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfCancelRequest();
        EmailClient client = new EmailClient(email);
        client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
        client.empCode = Session["empcode"].ToString();
        client.employeeName = Session["name"].ToString().Trim();
        client.appsendername = appSenderName;
        client.requestNumber = leaveid.ToString();
        client.Send();
    }


    private void Mailtoapprover(ArrayList list, int leaveid, string type)
    {
        var activity = new DataActivity();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 20, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 20, type.ToString());

        SqlConnection connection = activity.OpenConnection();
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
            "sp_leave_fetchmaildetail_employee", sqlparm);

        DataSet dsemp = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure,
            "sp_leave_fetchmaildetail_emp", sqlparm);
        DataRow rowemp = dsemp.Tables[0].Rows[0];

        activity.CloseConnection();

        SendEmail(leaveid, rowemp["a_name"].ToString().Trim());

        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {
                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
                {
                    try
                    {
                        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfCancelRequestApprover();
                        EmailClient client = new EmailClient(email);
                        client.toEmailId = ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim();
                        client.empCode = ds.Tables[0].Rows[j]["approvercode"].ToString().Trim();
                        client.employeeName = ds.Tables[0].Rows[j]["a_name"].ToString().Trim();
                        client.appsendername = rowemp["a_name"].ToString().Trim();
                        client.requestNumber = leaveid.ToString();
                        client.Send();
                    }
                    catch
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"] +
                                 " due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"]);
                }

                i--;
                j++;
            }
        }

    }

    #endregion
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        int status = 0;
        txt_cancel.Enabled = false;
        SqlTransaction _Transaction = null;
        string str = "";
        int leaveid = Convert.ToInt32(hidd_leaveapplyid.Value);
        ArrayList list = new ArrayList();
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[1];
        Output.AssignParameter(sqlparm, 0, "@id", "Int", 0, hidd_leaveapplyid.Value);
        try
        {
            SqlConnection connection = activity.OpenConnection();
            status = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, "sp_leave_validate_confirm_hr", sqlparm));
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

        switch (status)
        {
            case 0:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancelled successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 1: try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(1, 0, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave applied for cancellation successfully.");
                    error++;

                    Mailtoapprover(list, leaveid, "l");


                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;
                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 2:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=Leave already cancelled");
                break;
            case 3:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(3, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=Leave cannot be cancelled,its already in rejected status");
                break;
            case 4: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancelled successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 5: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancelled successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 6: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(6, 0, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave applied for cancellation successfully.");
                    error++;
                    Mailtoapprover(list, leaveid, "l");
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                txt_cancel.Enabled = true;

                Response.Redirect("ViewLeaveStatus.aspx?leavestatus=10&message=" + str);
                break;
        }


    }

    protected void cancelleave(int leave_status, int status, SqlConnection connection, SqlTransaction _transaction)
    {
        //  SqlConnection connection=activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[5];

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, txt_comment.Text != "" ? "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "<br>" : "");
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 100, _userCode.ToString());
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 100, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 100, leave_status.ToString());
        Output.AssignParameter(sqlparm, 4, "@status", "Int", 100, status.ToString());

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,approvel_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, _transaction, sqlstr, sqlparm);

        }
        else
        {
            sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, _transaction, sqlstr, sqlparm);
        }

    }

    protected void btn_modify_Click(object sender, EventArgs e)
    {
        QueryString q = new QueryString();
        string pairs = String.Format("leaveapplyid={0}&modify=1", hidd_leaveapplyid.Value);
        string encoded;
        encoded = q.EncodePairs(pairs);
        Response.Redirect("ModifiedLeave.aspx?q=" + encoded);
    }

    protected void approvergrid_PreRender(object sender, EventArgs e)
    {
        if (approvergrid.Rows.Count > 0)
            approvergrid.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
    }

    protected void adjustgrid_PreRender(object sender, EventArgs e)
    {
        if (adjustgrid.Rows.Count > 0)
            adjustgrid.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
    }
    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("approverleavestatus.aspx");
    }
}
