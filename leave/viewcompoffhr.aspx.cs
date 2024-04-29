using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Common.Console;
using Common.Data;

public partial class leave_viewcompoffhr : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    DataActivity activity = new DataActivity();
    public int i, ptr1, ptr2;
    int error = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            Common.Encode.QueryString q = new Common.Encode.QueryString();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
            Session.Remove("adjusttable");
            //configurecontrol();
            bindemployee_detail();
            fetchleavedata();
            bindcompoffentitled();
        }

    }

    #region BindCompoff Balance
    protected void bindcompoffentitled()
    {
        var activity = new DataActivity();

        try
        {
            SqlParameter[] sqlparm1 = new SqlParameter[1];
            Output.AssignParameter(sqlparm1, 0, "@empcode", "String", 50, hidd_empcode.Value.ToString());
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_leave_entitledcompoff]", sqlparm1);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblentitled.Text = ds.Tables[0].Rows[0]["allowcompoff"].ToString();
                lblused.Text = ds.Tables[0].Rows[0]["approvedays"].ToString();
                lblavalible.Text = ds.Tables[0].Rows[0]["avalibledays"].ToString();
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
    #endregion
    protected void fetchleavedata()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            if (hidd_leaveapplyid.Value == "0")
            {
                Common.Console.Output.Show("Problem fetchin leave data,try latter");
                return;
            }
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.VarChar, 100);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[1].Value = hidd_empcode.Value;// Session["empcode"].ToString();

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewcompoffapply", sqlparm);
            if (ds.Tables[0].Rows.Count > 0)
            {

                lbl_fromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
                lbl_todate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("MM/dd/yyyy");

                if (ds.Tables[0].Rows[0]["status"].ToString() == "0")
                {
                    btn_approve.Text = "Update Cancellation";
                    btn_cancel.Text = "Reset";
                    btn_approve.CssClass = "btn btn-success pull-right";
                    btn_cancel.CssClass = "btn btn-btn-danger pull-right";
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() == "2")
                {
                    btn_approve.Text = "Update Modification";
                    btn_cancel.Text = "Reset";
                    btn_approve.CssClass = "btn btn-success pull-right";
                    btn_cancel.CssClass = "btn btn-btn-danger pull-right";
                }
                lbl_nodays.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();

                lbl_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
                lbl_comments.Text = ds.Tables[0].Rows[0]["comment"].ToString();

            }
            else
            {
                Common.Console.Output.Show("No data available");
                return;
            }
            //if (ds.Tables[1].Rows.Count > 0)
            //{
            //    grid_workedon.DataSource = ds.Tables[1];
            //    grid_workedon.DataBind();
            //}

            if (ds.Tables[1].Rows.Count > 0)
            {
                approvergrid.DataSource = ds.Tables[1];
                approvergrid.DataBind();
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


    protected void bindemployee_detail()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            if (hidd_empcode.Value == "0")
                return;
            SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm.Value = hidd_empcode.Value;
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"]).ToString("dd - MMM - yyyy");
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



    //**************************************** Update modified compoff leave ********************************************//

    protected void updatependingleave(SqlConnection connection, SqlTransaction transaction)
    {

        SqlParameter[] sqlparm;

        sqlstr = "delete from tbl_leave_compoff_adjustment where compoff_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);


        dtable = (DataTable)Session["workedontable"];
        for (int i = 0; dtable.Rows.Count > i; i++)
        {
            sqlparm = new SqlParameter[6];

            sqlparm[0] = new SqlParameter("@compoff_id", SqlDbType.Int, 4);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@status", SqlDbType.Int, 4);
            sqlparm[1].Value = 1;

            sqlparm[2] = new SqlParameter("@date", SqlDbType.DateTime);
            sqlparm[2].Value = dtable.Rows[i]["date"].ToString();

            SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "[sp_leave_savecompoffadjustment_pending]", sqlparm);
        }

    }


    //*************************************** Update cancelled compoff leave *********************************//

    protected void updatecancelleave(int mode, SqlConnection connection, SqlTransaction transaction)
    {

        sqlstr = "update tbl_leave_compoff_adjustment set status=0 where compoff_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

    }


    //************************************** Update applied compoff leave ***************************************//

    protected void updateleaveapplication(int leavestatus, int status, SqlConnection connection, SqlTransaction transaction)
    {
        int approverstatus;
        sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode order by 1 desc";
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;

        approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.Text, transaction, sqlstr, sqlparm));


        sqlstr = "update tbl_leave_apply_compoff set comment=isnull(comment,'') + isnull(@comment,''),leave_status=@leave_status,status=@status,modifiedby=@modifiedby,modifieddate=getdate(),approval_status=@approval_status where id=@applyleaveid";
        sqlparm = new SqlParameter[6];
        sqlparm[0] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<h6><b>Comment added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[0].Value = "";

        sqlparm[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["name"].ToString();

        sqlparm[2] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[2].Value = hidd_leaveapplyid.Value;

        sqlparm[3] = new SqlParameter("@Leave_status", SqlDbType.Int, 4);
        sqlparm[3].Value = leavestatus;

        sqlparm[4] = new SqlParameter("@approval_status", SqlDbType.Int, 4);
        sqlparm[4].Value = approverstatus;

        sqlparm[5] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[5].Value = status;

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparm);

    }

    protected void btn_approve_Click(object sender, EventArgs e)
    {

        SqlTransaction _Transaction = null;
        int leaveid = 0;
        string str = "";
        ArrayList list = new ArrayList();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select leave_status,status from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
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
        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01": Response.Redirect("leave_approval.aspx?compoffstatus=1&hr=1&message=Activity not allowed,comp-off leave application is in pending status");
                break;
            case "11": //updatependingleave();

                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateleaveapplication(6, 1, _Connection, _Transaction);
                    updatebackmonth(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave application updated sucessfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        mailtoemployee(list, "CL");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }


                Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=" + str);
                break;
            case "21": Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=Activity not allowed,comp-off leave application already cancelled");
                break;
            case "31": Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=Activity not allowed,comp-off leave application already rejected");
                break;
            case "61": Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=Comp-off leave application already updated");
                break;
            case "10":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatecancelleave(0, _Connection, _Transaction);
                    updateleaveapplication(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                }
                catch (Exception ex)
                {
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=Comp-off leave cancellation application updated sucessfully");
                break;
            case "60":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatecancelleave(1, _Connection, _Transaction);
                    updateleaveapplication(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                }
                catch (Exception ex)
                {
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=Comp-off leave cancellation application updated sucessfully");
                break;
            case "12":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updatependingleave(_Connection, _Transaction);
                    updateleaveapplication(6, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave modification application updated sucessfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        mailtoemployee(list, "CC");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }


                Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=" + str);
                break;
            case "62":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateleaveapplication(6, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Comp-off leave modification application updated sucessfully.");
                    error++;
                }
                catch (Exception ex)
                {
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }


                if (error > 0)
                {
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        mailtoemployee(list, "CU");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }

                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }



                Response.Redirect("compoffapproval.aspx?compoffstatus=1&hr=1&message=" + str);
                break;
        }

    }
    private void mailtoemployee(ArrayList list, string status)
    {
        SqlConnection conn = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + hidd_empcode.Value + "'";

        DataSet ds1 = SQLServer.ExecuteDataset(conn, CommandType.Text, sqlstr);
        // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, sqlstr);
        if (ds1.Tables[0].Rows.Count > 0)
        {

            string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
            string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
            string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
            string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
            string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
            string subject = "";
            string bodyContent = "";
            if (status == "CL")
            {
                subject = "Your Comp-off leave application  is approved Successfully ";
                bodyContent = "your Compoff application is updated by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";

            }

            else if (status == "CC")
            {
                subject = "Your Comp-off leave cancellation  is approved Successuflly ";
                bodyContent = "your Compoff application is updated by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";

            }
            else if (status == "CU")
            {
                subject = "Your Comp-off modification application is approved ";
                bodyContent = "your Compoff application is not  updated by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";

            }
            string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
            if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
            {
                try
                {
                    Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                }
                catch
                {
                    list.Add("Comp-Off Updated mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
                }
            }
            else
            {
                list.Add("Comp-Off Updated  mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
            }



        }
    }

    protected void updatebackmonth(SqlConnection conn, SqlTransaction tran)
    {
        DateTime fromdate, todate, intime, outtime;
        int empshiftcode;
        string empcode;
        string displayleave;
        string displayleavename;
        int leavemode;

        DataSet ds2, ds3;
        string str1 = "SELECT empcode, half, fromdate, todate FROM tbl_leave_apply_compoff WHERE id=" + hidd_leaveapplyid.Value;
        ds = SQLServer.ExecuteDataset(conn, CommandType.Text, tran, str1);

        if (ds.Tables[0].Rows.Count > 0)
        {
            fromdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]);
            todate = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]);
            empcode = ds.Tables[0].Rows[0]["empcode"].ToString();
            leavemode = Convert.ToInt32(ds.Tables[0].Rows[0]["half"]);

            if (fromdate.Month != DateTime.Now.Month)
            {
                //string str2 = "SELECT empshiftcode FROM tbl_leave_dutyroster WHERE empcode='" + empcode + "' and date='" + fromdate + "'";
                //ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, str2);

                //if (ds2.Tables[0].Rows.Count > 0)
                //{
                if (leavemode == 0)
                {
                    displayleavename = "CO(HF)";
                }
                else
                {
                    displayleavename = "CO";
                }
                //empshiftcode = Convert.ToInt32(ds2.Tables[0].Rows[0]["empshiftcode"]);

                //string str3 = "SELECT starttime,endtime FROM tbl_leave_shift WHERE shiftid=" + empshiftcode;
                //ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, str3);

                //if (ds3.Tables[0].Rows.Count > 0)
                //{
                //    intime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["starttime"]);
                //    outtime = Convert.ToDateTime(ds3.Tables[0].Rows[0]["endtime"]);

                string str4 = "UPDATE tbl_payroll_employee_attendence_detail SET mode='" + displayleavename + "', flag=1 WHERE empcode='" + empcode + "' AND date BETWEEN '" + fromdate + "' AND '" + todate + "'";
                SQLServer.ExecuteNonQuery(conn, CommandType.Text, tran, str4);
                //}
                //}
            }
        }
    }
}

