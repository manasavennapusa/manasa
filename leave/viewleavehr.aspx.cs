using Common.Console;
using Common.Data;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
public partial class leave_viewleavehr : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr;
    public int i, error;

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
                hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
                Session.Remove("adjusttable");
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
            if (hidd_empcode.Value == "0")
                return;
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value);
            SqlConnection connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            HiddenField_gender.Value = ds.Tables[0].Rows[0]["emp_gender"].ToString();
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
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion

    #region Fetch Leave Details
    protected void createadjustment()
    {
        dtable = new DataTable();
        dtable.Columns.Add("leaveid", typeof(int));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["leaveid"] };
        dtable.Columns.Add("leavename", typeof(string));
        dtable.Columns.Add("status", typeof(int));
        dtable.Columns.Add("noofdays", typeof(string));
        Session["adjusttable"] = dtable;
    }
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
            Output.AssignParameter(sqlparm, 0, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value.ToString());
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
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
                    lbl_sdate.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["fromdate"].ToString()).ToString("dd - MMM - yyyy");
                    lbl_edate.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["todate"].ToString()).ToString("dd - MMM - yyyy");
                }
                else
                {
                    divfull.Visible = false;
                    divhalf.Visible = true;
                    lbl_select.Text = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString()).ToString("dd - MMM - yyyy");
                    lbl_half.Text = (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"])) ? "First half" : "Second half";
                }


                lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
                lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
                lbl_comments.Text = ds.Tables[0].Rows[0]["comments"].ToString();
                lbl_file.Text = (ds.Tables[0].Rows[0]["file_path"].ToString() != "") ? "<a target='_blank' href='Upload/Doc/" + ds.Tables[0].Rows[0]["file_path"].ToString() +
                  "'>" + ds.Tables[0].Rows[0]["file_path"].ToString() + "</a>" : "No exisitng file found";
            }
            else
            {
                Output.Show("No data available");
                return;
            }
            if (ds.Tables[1].Rows.Count > 0)
            {
                if (Session["adjusttable"] == null)
                    createadjustment();
                DataRow dr;
                DataTable sdata;

                sdata = (DataTable)Session["adjusttable"];
                for (int i = 0; ds.Tables[1].Rows.Count > i; i++)
                {
                    dr = sdata.NewRow();
                    dr["leaveid"] = (ds.Tables[1].Rows[i]["leaveid"] != null) ? Convert.ToInt32(ds.Tables[1].Rows[i]["leaveid"].ToString()) : 0;
                    dr["leavename"] = (ds.Tables[1].Rows[i]["leavename"] != null) ? ds.Tables[1].Rows[i]["leavename"].ToString() : "";
                    dr["noofdays"] = (ds.Tables[1].Rows[i]["noofdays"] != null) ? ds.Tables[1].Rows[i]["noofdays"].ToString() : "";
                    dr["status"] = (Convert.ToBoolean(ds.Tables[1].Rows[i]["status"]) != true) ? 1 : 0;

                    sdata.Rows.Add(dr);
                }
                Session["adjusttable"] = sdata;
                adjustgrid.DataSource = sdata;
                adjustgrid.DataBind();
            }
            if (ds.Tables[2].Rows.Count > 0)
            {
                approvergrid.DataSource = ds.Tables[2];
                approvergrid.DataBind();
            }
            if (ds.Tables[0].Rows[0]["leaveid"].ToString() == ConfigurationManager.AppSettings["FL"].ToString())
            {
                div_Furnelleave.Visible = true;
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
    protected void bindadjustment()
    {
        dtable = (DataTable)Session["adjusttable"];
        adjustgrid.DataSource = dtable;
        adjustgrid.DataBind();
    }
    #endregion
    #region Approve Click Event
    protected void btn_approve_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        SqlTransaction _Transaction = null;
        int leaveid = 0;
        ArrayList list = new ArrayList();
        DataTable sdate;
        string str = "";
        sdate = (DataTable)Session["adjusttable"];
        Single noofdays = 0;
        DataSet ds121;
        btn_approve.Enabled = false;
        SqlConnection connection = activity.OpenConnection();
        try
        {

            for (int i = 0; sdate.Rows.Count > i; i++)
            {
                noofdays = noofdays + Convert.ToSingle(sdate.Rows[i]["noofdays"].ToString());

                SqlParameter[] sqlparm121 = new SqlParameter[3];
                Output.AssignParameter(sqlparm121, 0, "@leaveid", "Int", 50, Convert.ToInt32(sdate.Rows[i]["leaveid"]).ToString());
                Output.AssignParameter(sqlparm121, 1, "@empcode", "String", 50, hidd_empcode.Value);
                Output.AssignParameter(sqlparm121, 2, "@noofdays", "Decimal", 50, Convert.ToSingle(sdate.Rows[i]["noofdays"].ToString()).ToString());
                ds121 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_hr_check", sqlparm121);

                if (Convert.ToInt32(ds121.Tables[0].Rows[0][0]) == 0)
                {
                    Output.Show("Please check leave balance.Leave balance cannot be negative.");
                    return;
                }
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

        sqlstr = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01": Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application is in pending status");
                break;
            case "11":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatependingleave(_Connection, _Transaction);
                    updateleaveapplication(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Leave application updated sucessfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is not updated. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtoemployee(list, "LL");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_approve.Enabled = true;
                Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "21": Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application already cancelled");
                break;
            case "31": Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application already rejected");
                break;
            case "61": Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=Leave application already updated");
                break;
            case "10":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection(); _Transaction = _Connection.BeginTransaction();
                    updatecancelleave(0, _Connection, _Transaction);
                    updateleaveapplication(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancellation application updated sucessfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is not updated. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtoemployee(list, "LC");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);
                }

                btn_approve.Enabled = true;
                Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "60": try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatecancelleave(1, _Connection, _Transaction);
                    updateleaveapplication(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave cancellation application updated sucessfully");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is not updated. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtoemployee(list, "LC");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);

                }

                btn_approve.Enabled = true;
                Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "12": try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatependingleave(_Connection, _Transaction);
                    updateleaveapplication(6, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave modification application updated sucessfully");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is not updated. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }

                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtoemployee(list, "LU");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);

                }

                btn_approve.Enabled = true;

                Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "62":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatemodifiedleave(_Connection, _Transaction);
                    updateleaveapplication(6, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave modification application updated sucessfully");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Leave is not updated. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }

                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtoemployee(list, "LU");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);

                }

                btn_approve.Enabled = true;
                Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
        }

    }
    #endregion

    #region Mail shooted to the Employee
    private void mailtoemployee(ArrayList list, String status)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + hidd_empcode.Value + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        if (ds1.Tables[0].Rows.Count > 0)
        {

            string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
            string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
            string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
            string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
            string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

            string subject = "";
            string bodyContent = "";
            if (status == "LL")
            {
                subject = "Your Leave application  is approved Successuflly ";
                bodyContent = "your Leave application is updated by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ".";

            }

            else if (status == "LC")
            {
                subject = "Your  Leave cancellation application is approved Successfully ";
                bodyContent = "your Leave application is updated by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ".";

            }
            else if (status == "LU")
            {
                subject = "Your Leave modification application is approved ";
                bodyContent = "your Leave  application is   updated by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ".";

            }

            string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
            if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
            {
                try
                {
                    Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                }
                catch
                {
                    list.Add("Leave updation mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
                }
            }
            else
            {
                list.Add("Leave updation mail  is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
            }




        }
        activity.CloseConnection();
    }
    #endregion

    protected void updatependingleave(SqlConnection connection, SqlTransaction transaction)
    {
        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        dtable = (DataTable)Session["adjusttable"];
        for (int i = 0; dtable.Rows.Count > i; i++)
        {
            SqlParameter[] sqlparm121 = new SqlParameter[7];

            Output.AssignParameter(sqlparm121, 0, "@apply_leave_id", "Int", 50, hidd_leaveapplyid.Value);
            Output.AssignParameter(sqlparm121, 1, "@leaveid", "Int", 50, dtable.Rows[i]["leaveid"].ToString());
            Output.AssignParameter(sqlparm121, 2, "@days", "Decimal", 50, dtable.Rows[i]["noofdays"].ToString());
            Output.AssignParameter(sqlparm121, 3, "@status", "Int", 50, "1");
            Output.AssignParameter(sqlparm121, 4, "@leavename", "String", 50, dtable.Rows[i]["leavename"].ToString());
            Output.AssignParameter(sqlparm121, 5, "@empcode", "String", 50, hidd_empcode.Value);
            Output.AssignParameter(sqlparm121, 6, "@companyid", "Int", 50, _companyId.ToString());

            int k = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_leave_saveleaveadjustment_pending]", sqlparm121);
        }

    }

    protected void updatecancelleave(int mode, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparm;
        sqlstr = "update tbl_leave_adjustment_apply set status=0 where apply_leave_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        if (mode == 0)
            return;
        sqlstr = "select apply_leave_id,leaveid,days from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, sqlstr);
        dtable = (DataTable)Session["adjusttable"];
        for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[3];

            Output.AssignParameter(sqlparm, 0, "@leaveid", "Int", 50, ds.Tables[0].Rows[i]["leaveid"].ToString());
            Output.AssignParameter(sqlparm, 1, "@days", "Decimal", 50, ds.Tables[0].Rows[i]["days"].ToString());
            Output.AssignParameter(sqlparm, 2, "@empcode", "String", 50, hidd_empcode.Value);
            SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_saveleaveadjustment_cancellation", sqlparm);

        }

    }

    protected void updatemodifiedleave(SqlConnection connection, SqlTransaction transaction)
    {

        SqlParameter[] sqlparm;
        sqlstr = "delete from tbl_leave_adjustment_apply where apply_leave_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

        dtable = (DataTable)Session["adjusttable"];
        for (int i = 0; dtable.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[6];
            Output.AssignParameter(sqlparm, 0, "@apply_leave_id", "Int", 50, hidd_leaveapplyid.Value);
            Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 50, dtable.Rows[i]["leaveid"].ToString());
            Output.AssignParameter(sqlparm, 2, "@days", "Decimal", 50, dtable.Rows[i]["noofdays"].ToString());
            Output.AssignParameter(sqlparm, 3, "@status", "Int", 50, "1");
            Output.AssignParameter(sqlparm, 4, "@leavename", "String", 50, dtable.Rows[i]["leavename"].ToString());
            Output.AssignParameter(sqlparm, 5, "@companyid", "Int", 50, _companyId.ToString());
            SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_saveleaveadjustment_modification", sqlparm);
        }
        sqlparm = new SqlParameter[1];
        sqlparm[0] = new SqlParameter("@apply_leave_id", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, transaction, "sp_leave_fetchleavechanges", sqlparm);
        for (i = 0; ds.Tables[0].Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[3];
            Output.AssignParameter(sqlparm, 0, "@leaveid", "Int", 50, ds.Tables[0].Rows[i]["leaveid"].ToString());
            Output.AssignParameter(sqlparm, 1, "@days", "Decimal", 50, ds.Tables[0].Rows[i]["days"].ToString());
            Output.AssignParameter(sqlparm, 2, "@empcode", "String", 50, hidd_empcode.Value);
            SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_savemodifiedleave", sqlparm);

        }

    }

    protected void updateleaveapplication(int leavestatus, int status, SqlConnection connection, SqlTransaction transaction)
    {

        int approverstatus = 0;
        sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode order by 1 desc";
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);


        approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.Text, transaction, sqlstr, sqlparm));



        sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,status=@status,modifiedby=@modifiedby,modifieddate=getdate(),approvel_status=@approvel_status where id=@applyleaveid";
        sqlparm = new SqlParameter[6];

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, (txt_comment.Text != "" ? "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>" : ""));
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm, 4, "@approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm, 5, "@status", "Int", 50, status.ToString());

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparm);

    }


    protected void btn_add_Click(object sender, EventArgs e)
    {
        DataRow dr;
        if (Session["adjusttable"] == null)
            createadjustment();
        dtable = (DataTable)Session["adjusttable"];

        DataRow drfind = dtable.Rows.Find(drp_leave.SelectedValue.ToString());
        if (drfind != null)
        {
            Output.Show("Leave type already in queue");
        }
        else
        {
            dr = dtable.NewRow();
            dr["leaveid"] = drp_leave.SelectedValue.ToString();
            dr["leavename"] = drp_leave.SelectedItem.Text.ToString();
            dr["noofdays"] = txt_noofdays.Text;
            dr["status"] = 0;
            dtable.Rows.Add(dr);
        }


        Session["adjusttable"] = dtable;

        bindadjustment();
        drp_leave.SelectedIndex = -1;
        txt_noofdays.Text = "";
    }
    protected void adjustgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        dtable = (DataTable)Session["adjusttable"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(adjustgrid.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.BeginEdit();
            drfind["leaveid"] = ((DropDownList)adjustgrid.Rows[e.RowIndex].Cells[0].Controls[1]).SelectedValue;
            drfind["leavename"] = ((DropDownList)adjustgrid.Rows[e.RowIndex].Cells[0].Controls[1]).SelectedItem.Text;
            drfind["noofdays"] = ((TextBox)adjustgrid.Rows[e.RowIndex].Cells[1].Controls[1]).Text;

            adjustgrid.EditIndex = -1;
            Session["adjusttable"] = dtable;
            bindadjustment();
        }
    }
    protected void adjustgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        adjustgrid.EditIndex = e.NewEditIndex;
        bindadjustment();
    }
    protected void adjustgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["adjusttable"];
        DataRow drfind = dtable.Rows.Find(Convert.ToString(adjustgrid.DataKeys[e.RowIndex].Value));
        if (drfind != null)
        {
            drfind.Delete();
            Session["adjusttable"] = dtable;
            bindadjustment();
        }
    }
    protected void adjustgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        adjustgrid.EditIndex = -1;

        bindadjustment();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Session.Remove("adjusttable");
        fetchleavedata();
    }
    protected void updatebackmonth(SqlConnection connection, SqlTransaction transaction)
    {
        DateTime fromdate, todate;
        string empcode;
        string displayleave;
        string displayleavename;
        int leavemode;
        int leaveid;
        DataSet ds2;
        string str1 = @"SELECT empcode, leavemode, leaveid,(CASE WHEN fromdate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), fromdate, 101) END) fromdate,
                             (CASE WHEN todate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10),todate, 101) END) todate,
                             (CASE WHEN hdate= '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), hdate, 101) END) hdate FROM tbl_leave_apply_leave WHERE id=" + hidd_leaveapplyid.Value;

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, str1);
        if (ds.Tables[0].Rows.Count > 0)
        {
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"]);
            leaveid = Convert.ToInt32(ds.Tables[0].Rows[0]["leaveid"]);
            if (leavemode == 0)
            {
                fromdate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString());
                todate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["hdate"].ToString());
            }
            else
            {
                fromdate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["fromdate"].ToString());
                todate = Common.Date.Utility.DateFormat(ds.Tables[0].Rows[0]["todate"].ToString());
            }
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();

            if (fromdate.Month != DateTime.Now.Month)
            {
                string str2 = "SELECT leaveid, displayleave FROM tbl_leave_createleave WHERE leaveid=" + leaveid;
                ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, transaction, str2);
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    displayleave = ds2.Tables[0].Rows[0]["displayleave"].ToString();
                    if (leavemode == 0)
                    {
                        displayleavename = displayleave + "(HF)";
                    }
                    else
                    {
                        displayleavename = displayleave;
                    }


                    string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='" + displayleavename + "', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                    SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, str4);

                }
            }
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();
            updatecancelleave(0, connection, transaction);
            updateleaveapplication(2, 1, connection, transaction);
            Response.Redirect("LeaveApproval.aspx?leavestatus=1&hr=1&message=Leave cancellation application updated successfully");
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }


    #region Grid PreRender Events
    protected void adjustgrid_PreRender(object sender, EventArgs e)
    {
        if (adjustgrid.Rows.Count > 0)
            adjustgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void approvergrid_PreRender(object sender, EventArgs e)
    {
        if (approvergrid.Rows.Count > 0)
            approvergrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    #endregion
}
