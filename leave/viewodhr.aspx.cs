using Common.Console;
using Common.Data;
using Common.Date;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


public partial class leave_viewodhr : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    private string _companyId, _userCode, comment, sqlstr;
    public int i, k, error;
    DataActivity activity = new DataActivity();
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
                bind_empdetail();
                bind_od_detail();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

    }
    #endregion
    #region Bind The Employee Details
    protected void bind_empdetail()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value);
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            lbl_emp_name.Text = _ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = _ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = _ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = _ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = _ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = _ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = _ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Utility.DateFormat(_ds.Tables[0].Rows[0]["emp_doj"].ToString()).ToString("dd - MMM - yyyy");
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
    protected void bind_od_detail()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string str = @"select tbl_leave_apply_od.id,(case when half=0 then 'First Half' else 'Second Half' end) as half,tbl_leave_apply_od.empcode,tbl_leave_apply_od.leavemode,right(convert(varchar(50),tbl_leave_apply_od.intime),7) as intime,right(convert(varchar(50),tbl_leave_apply_od.outtime),7) as  outtime,convert(varchar,tbl_leave_apply_od.date,101)date,convert(varchar,tbl_leave_apply_od.fromtime,101)fromtime,tbl_leave_apply_od.reason,tbl_leave_apply_od.working_hour,tbl_leave_apply_od.comment,tbl_leave_apply_od.Leave_status   from tbl_leave_apply_od 
                                where id='" + hidd_leaveapplyid.Value + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, str);
            int id = Convert.ToInt32(ds.Tables[0].Rows[0]["id"]);
            ViewState["id"] = id;
            int lm = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"].ToString());
            if (lm == 1)
            {
                divfull.Visible = true;
                lbl_date.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lbl_todate.Text = ds.Tables[0].Rows[0]["fromtime"].ToString();
                lbl_OdMode.Text = "Full Day";
            }
            else if (lm == 0)
            {
                divhalf.Visible = true;
                lbl_hdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lbl_HalfMode.Text = ds.Tables[0].Rows[0]["half"].ToString();
                lbl_OdMode.Text = "Half Day";
            }
            lbl_Ftime.Text = ds.Tables[0].Rows[0]["intime"].ToString();
            lbl_Ttime.Text = ds.Tables[0].Rows[0]["outtime"].ToString();
            lbl_work_Hours.Text = ds.Tables[0].Rows[0]["working_hour"].ToString();
            lbl_Comment.Text = ds.Tables[0].Rows[0]["comment"].ToString();
            lbl_Reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
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

    protected void btn_update_Click(object sender, EventArgs e)
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

        Single noofdays = 0;
        DataSet ds121;
        btn_update.Enabled = false;
        SqlConnection connection = activity.OpenConnection();
        sqlstr = "select leave_status,status from tbl_leave_apply_od where id=" + hidd_leaveapplyid.Value;
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01": Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application is in pending status");
                break;
            case "11":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    UpdateOd(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("OD application updated sucessfully.");
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

                btn_update.Enabled = true;
                Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "21": Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application already cancelled");
                break;
            case "31": Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=Activity Not allowed,Leave application already rejected");
                break;
            case "61": Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=Leave application already updated");
                break;
            case "10":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection(); _Transaction = _Connection.BeginTransaction();
                    UpdateOd(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD cancellation application updated sucessfully.");
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

                btn_update.Enabled = true;
                Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "60": try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    UpdateOd(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD cancellation application updated sucessfully");
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

                btn_update.Enabled = true;
                Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "12": try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    UpdateOd(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD modification application updated sucessfully");
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

                btn_update.Enabled = true;

                Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
            case "62":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    UpdateOd(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD modification application updated sucessfully");
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

                btn_update.Enabled = true;
                Response.Redirect("OdApproval.aspx?leavestatus=1&hr=1&message=" + str);
                break;
        }

    }
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
                subject = "Your OD application  is approved Successuflly ";
                bodyContent = "your OD application is updated by " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + ".";

            }

            else if (status == "LC")
            {
                subject = "Your  OD cancellation application is approved Successfully ";
                bodyContent = "your OD application is updated by " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + ".";

            }
            else if (status == "LU")
            {
                subject = "Your OD modification application is approved ";
                bodyContent = "your OD  application is   updated by " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + ".";

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
                    list.Add("OD updation mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
                }
            }
            else
            {
                list.Add("OD updation mail  is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
            }




        }
        activity.CloseConnection();
    }
    #endregion
    private void UpdateOd(int leavestatus, int status, SqlConnection _Connection, SqlTransaction _Transaction)
    {
        int approverstatus = 0;
        string sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode";
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
        approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(_Connection, CommandType.Text, _Transaction, sqlstr, sqlparm));


        SqlParameter[] sqlparm1 = new SqlParameter[6];
        Output.AssignParameter(sqlparm1, 0, "@id", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm1, 1, "@comment", "String", 5000, txt_comment.Text != "" ? "<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>" : "");
        Output.AssignParameter(sqlparm1, 2, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm1, 3, "@status", "Int", 50, status.ToString());
        Output.AssignParameter(sqlparm1, 4, "@Approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm1, 5, "@modifiedby", "String", 50, _userCode);

        string str1 = "update tbl_leave_apply_od set Leave_status=@leave_status,modifiedby=@modifiedby,comment=isnull(comment,'') +isnull( @comment,''),Approval_status=@Approvel_status,status=@status,modifieddate=getdate() where id=@id";
        SQLServer.ExecuteNonQuery(_Connection, CommandType.Text, _Transaction, str1, sqlparm1);

    }
    protected void updatebackmonth(SqlConnection _Connection, SqlTransaction _Transaction)
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode, leavemode;
        string empcode;
        DataSet ds2, ds3;
        string str1 = "SELECT empcode, date, fromtime,leavemode FROM tbl_leave_apply_od WHERE id=" + hidd_leaveapplyid.Value;
        DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, _Transaction, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["date"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromtime"]);
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["leavemode"].ToString());
            if (fromdate.Month != DateTime.Now.Month)
            {

                //intime = Utility.DateFormat(ds3.Tables[0].Rows[0]["starttime"].ToString());
                //outtime = Utility.DateFormat(ds3.Tables[0].Rows[0]["endtime"].ToString());
                string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='P', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                SQLServer.ExecuteNonQuery(_Connection, CommandType.Text, _Transaction, str4);


            }
        }
    }
}
