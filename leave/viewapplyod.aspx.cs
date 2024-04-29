using Common.Console;
using Common.Data;
using Common.Date;
using Common.Encode;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class leave_viewapplyod : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    private string _companyId, _userCode,emp,comment, sqlstr;
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
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value.ToString());
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
            string str = @"select tbl_leave_apply_od.id,(case when half=0 then 'First Half' else 'Second Half' end) as half,tbl_leave_apply_od.empcode,tbl_leave_apply_od.leavemode,right(convert(varchar(50),tbl_leave_apply_od.intime),7) as intime,right(convert(varchar(50),tbl_leave_apply_od.outtime),7) as  outtime,convert(varchar,tbl_leave_apply_od.date,101)date,convert(varchar,tbl_leave_apply_od.fromtime,101)fromtime,tbl_leave_apply_od.reason,tbl_leave_apply_od.working_hour,tbl_leave_apply_od.comment,tbl_leave_apply_od.Leave_status,tbl_leave_apply_od.status   from tbl_leave_apply_od
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
                fulltime.Visible = false;
            }
            else if (lm == 0)
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                lbl_hdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                lbl_HalfMode.Text = ds.Tables[0].Rows[0]["half"].ToString();
                lbl_OdMode.Text = "Half Day";
                fulltime.Visible = false;
            }
            if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
            {
                btn_cancel.Enabled = false;
                btn_modify.Enabled = false;
                txt_comment.Enabled = false;
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
    protected void btn_cancel_Click(object sender, EventArgs e)
    {

        int status = 0;
        btn_cancel.Enabled = false;
        SqlTransaction _Transaction = null;
        string str = "";
        int leaveid = 0;
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
            Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
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
                    list.Add("OD cancelled successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;

                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 1: try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(1, 0, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD applied for cancellation successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;
                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=" + str);
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
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=OD already cancelled");
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
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=Leave cannot be cancelled,its already in rejected status");
                break;
            case 4: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD cancelled successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;

                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=" + str);
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
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;

                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=" + str);
                break;
            case 6: try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(6, 0, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("OD applied for cancellation successfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    if (_Transaction != null) _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("OD is Not Approved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "l");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;

                Response.Redirect("ViewOdStatus.aspx?leavestatus=10&message=" + str);
                break;
        }

        Response.Redirect("ViewOdStatus.aspx?leavestatus=0&updated=true");
    }
    protected void cancelleave(int leave_status, int status, SqlConnection connection, SqlTransaction _transaction)
    {
        //  SqlConnection connection=activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[5];

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, txt_comment.Text != "" ? "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "<br>" : "");
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 100, _userCode.ToString());
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 100, hidd_leaveapplyid.Value.ToString());
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 100, leave_status.ToString());
        Output.AssignParameter(sqlparm, 4, "@status", "Int", 100, status.ToString());

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_od set comment=isnull(comment,'') +isnull( @comments,''),Leave_status=@leave_status,Approval_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, _transaction, sqlstr, sqlparm);

        }
        else
        {
            sqlstr = "update tbl_leave_apply_od set comment=isnull(comment,'') +isnull( @comments,''),Leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, _transaction, sqlstr, sqlparm);
        }

    }
    protected void mailtocancelapprover(ArrayList list, int leaveid, string type)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 100, leaveid.ToString());
        Output.AssignParameter(sqlparm, 1, "@type", "String", 100, type.ToString());

        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetchmaildetail_employee", sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            int i = ds.Tables[0].Rows.Count;
            int j = 0;

            while (i != 0)
            {

                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                QueryString q = new QueryString();
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "LA");
                string encoded;
                encoded = q.EncodePairs(pairs);

                string url = "";
                string url1 = "";

                // string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                // string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
                string subject = "Leave OD for Approval";

                string bodyContent = "A new OD Cancelation  request has been submitted by employee " + Session["name"].ToString() + " from " + lbl_date.Text + " to " + lbl_todate.Text + ". <br/><br/>  " + url + " " + url1;

                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);
                if (ds.Tables[0].Rows[0]["official_email_id"].ToString() != "")
                {
                    try
                    {
                        Common.Mail.Email.SendEmail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                    }
                    catch
                    {
                        list.Add("OD Cancelation mail is not delivered to the Approver. Due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("OD Cancelation mail is not delivered to the Approver.Approver Email id does not exists.");
                }

                i--;
                j++;
            }
        }
        activity.CloseConnection();
    }
    protected void btn_modify_Click(object sender, EventArgs e)
    {
        QueryString q = new QueryString();
        string pairs = String.Format("leaveapplyid={0}&modify=1", hidd_leaveapplyid.Value);
        string encoded;
        encoded = q.EncodePairs(pairs);
        Response.Redirect("EditApplyOD.aspx?q=" + encoded);
    }
}
