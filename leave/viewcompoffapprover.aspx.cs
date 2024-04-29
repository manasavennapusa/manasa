using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using DataAccessLayer;
using querystring;
using Common.Console;
using Common.Data;
using System.Net.Mail;

public partial class leave_viewcompoffapprover : System.Web.UI.Page
{
    string sqlstr;
    string message1;
    DataSet ds = new DataSet();
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i, ptr1, ptr2;
    DataActivity activity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {


        //dd_typeleave.Attributes.Add("onchange", "disablesubmit();");
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            query q = new query();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
            bind_empdetail();
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
        var activity = new DataActivity();

        try
        {
            if (hidd_leaveapplyid.Value == "0")
            {
                Common.Console.Output.Show("Problem fetchin comp-off leave data,try latter");
                return;
            }
            SqlParameter[] sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.VarChar, 100);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[1].Value = hidd_empcode.Value;// Session["empcode"].ToString();

            //("@applyleaveid", Request.QueryString["leaveapplyid"].ToString());
            //@empcode
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewcompoffapply", sqlparm);
            if (ds.Tables[0].Rows.Count > 0)
            {

                lbl_fromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
                lbl_todate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("MM/dd/yyyy");

                if (ds.Tables[0].Rows[0]["status"].ToString() == "0")
                {
                    btn_approve.Text = "Approve Cancellation";
                    btn_backuser.Enabled = false;
                    btn_cancel.Text = "Reject Cancellation";
                    btn_approve.CssClass = "btn btn-success pull-right";
                    btn_cancel.CssClass = "btn btn-danger pull-right";
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() == "2")
                {
                    btn_approve.Text = "Approve Modification";
                    btn_backuser.Enabled = false;
                    btn_cancel.Text = "Reject Modification";
                    btn_approve.CssClass = "btn btn-success pull-right";
                    btn_cancel.CssClass = "btn btn-danger pull-right";
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
    protected void bind_empdetail()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm.Value = hidd_empcode.Value;
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);

            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_dept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = ds.Tables[0].Rows[0]["emp_doj"].ToString();
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

    protected void approveleave(int leavestatus, int status, SqlConnection connection, SqlTransaction transaction)
    {

        int approverstatus;
        sqlstr = "select approverpriority from tbl_Compoff_employee_hierarchy where approverid=@approverid and employeecode=@empcode";
        SqlParameter[] sqlparm;
        if (leavestatus == 4)
            approverstatus = 0;
        else
        {
            sqlparm = new SqlParameter[2];
            sqlparm[0] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
            sqlparm[0].Value = Session["empcode"].ToString();

            sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[1].Value = hidd_empcode.Value;

            approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.Text, transaction, sqlstr, sqlparm));

        }
        sqlstr = "update tbl_leave_apply_compoff set comment=isnull(comment,'') +isnull(@comment,''),leave_status=@leave_status,modifiedby=@modifiedby,approval_status=@approval_status,status=@status,modifieddate=getdate() where id=@applyleaveid";
        sqlparm = new SqlParameter[6];
        sqlparm[0] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
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
        int i, leave_status = 0;
        string str = "";
        SqlTransaction _Transaction = null;
        int error = 0;
        ArrayList list = new ArrayList();
        btn_approve.Enabled = false;
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@approverid", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[1].Value = hidd_empcode.Value;
        try
        {
            SqlConnection connection1 = activity.OpenConnection();
            i = Convert.ToInt32(SQLServer.ExecuteScalar(connection1, CommandType.StoredProcedure, "sp_leave_validatecompoffstatus", sqlparm));
            if (i == 0)
                leave_status = 1;
            else
                leave_status = 0;
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


        //try
        //{
        try
        {
            SqlConnection conn = activity.OpenConnection();
            sqlstr = "select leave_status,status,CONVERT(varchar(10),fromdate,101) as fromdate,CONVERT(varchar(10),todate,101) as todate from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
            ds = SQLServer.ExecuteDataset(conn, CommandType.Text, sqlstr);
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
            case "01":
                try
                {

                    SqlConnection connection = activity.OpenConnection();
                    _Transaction = connection.BeginTransaction();

                    approveleave(leave_status, 1, connection, _Transaction);

                    _Transaction.Commit();

                    list.Add("Comp-Off application approved successfully.");
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
                    //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //    mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "A");
                    //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //    mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "A");
                    MailtoEmployee(list, "A", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());

                    for (int j = 0; j < list.Count; j++)
                    {
                        str = str + list[j].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_approve.Enabled = true;
                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
            //}
            case "11": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already approved");
                break;
            case "21": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already cancelled");
                break;
            case "31": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already rejected");
                break;
            case "61": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already approved");
                break;
            case "10":
                try
                {
                    SqlConnection connection = activity.OpenConnection();
                    _Transaction = connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0, connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave cancellation application approved sucessfully.");
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
                    //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //    mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "C");
                    //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //    mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "C");


                    for (int k = 0; k < list.Count; k++)
                    {
                        str = str + list[k].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_approve.Enabled = true;
                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;

            case "60":
                try
                {

                    SqlConnection connection = activity.OpenConnection();
                    _Transaction = connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0, connection, _Transaction);
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

                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave cancellation application approved sucessfully");
                break;
            case "12":
            case "62":
               
                try
                {

                    SqlConnection connection = activity.OpenConnection();
                    _Transaction = connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 2, connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave modification application approved sucessfully.");
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
                    //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //    mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "U");
                    //if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                    //    mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "U");


                    for (int l = 0; l < list.Count; l++)
                    {
                        str = str + list[l].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_approve.Enabled = true;
                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
            
        }
       
    }


    //private void mailtohr(ArrayList list, string p1, string p2, string a)
    //{
    //    SqlConnection conn = activity.OpenConnection();
    //    string sqlstr = @"select official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname ,approverid from tbl_leave_employee_hierarchy eh inner join tbl_intranet_employee_jobDetails ej on ej.empcode=eh.approverid where  hr=1 and employeecode='" + hidd_empcode.Value + "'";

    //    DataSet ds1 = DBTask.ExecuteDataset(conn, CommandType.Text, sqlstr);
    //    // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, sqlstr);


    //    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
    //    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
    //    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
    //    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
    //    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

    //    query q = new query();
    //    string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", p2, p1, ds1.Tables[0].Rows[0]["approverid"].ToString(), "CHR");
    //    string encoded;
    //    encoded = q.EncodePairs(pairs);
    //    string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Update</a>";
    //    string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";

    //    string subject = "";
    //    string bodyContent = "";

    //    if (a == "A")
    //    {
    //        subject = "Compoff Application Approved By Manager";
    //        bodyContent = "Compoff application is Approved by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + "of " + lbl_emp_name.Text + ".Please  update the Compoff.<br/><br/>" + url + "   " + url1;


    //    }
    //    else if (a == "C")
    //    {
    //        subject = "Compoff Cancelation  Application Approved By Manager";
    //        bodyContent = "Compoff cancelation application is Approved by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + "of " + lbl_emp_name.Text + ".Please  update the Compoff.<br/><br/>" + url + "   " + url1;

    //    }
    //    else if (a == "U")
    //    {
    //        subject = "Compoff modification  Applilcation Approved By Manager";
    //        bodyContent = "Compoff cancelation application is Approved by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + "of " + lbl_emp_name.Text + ".Please  update the Compoff.<br/><br/>" + url + "   " + url1;
    //    }


    //    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
    //    if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
    //    {
    //        try
    //        {
    //            Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
    //        }
    //        catch
    //        {
    //            list.Add("Comp-off mail  is not delivered to the HR: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
    //        }
    //    }
    //    else
    //    {
    //        list.Add("Comp-off mail  is not delivered to the HR: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
    //    }
    //    activity.CloseConnection();

    //}

    //private void mailtoemployee(ArrayList list, string p1, string p2, string a)
    //{
    //    SqlConnection conn = activity.OpenConnection();
    //    string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + hidd_empcode.Value + "'";

    //    DataSet ds1 = DBTask.ExecuteDataset(conn, CommandType.Text, sqlstr);
    //    // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, sqlstr);


    //    string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
    //    string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
    //    string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
    //    string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
    //    string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

    //    string subject = "";
    //    string bodyContent = "";

    //    if (a == "A")
    //    {
    //        subject = "Compoff Application Approved By Manager";
    //        bodyContent = "your Compoff application is Approved by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";


    //    }
    //    else if (a == "C")
    //    {
    //        subject = "Cancellation Compoff Application Approved By Manager";
    //        bodyContent = "your Compoff application is Approved by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";

    //    }
    //    else if (a == "U")
    //    {
    //        subject = "Modifaiction Compoff modification  Applilcation Approved By Manager";
    //        bodyContent = "your Compoff application is Approved by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";


    //    }



    //    string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
    //    if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
    //    {
    //        try
    //        {
    //            Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
    //        }
    //        catch
    //        {
    //            list.Add("Comp-off mail  is not delivered to the Employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
    //        }
    //    }
    //    else
    //    {
    //        list.Add("Comp-off mail  is not delivered to the Employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
    //    }

    //    activity.CloseConnection();

    //}

    protected void btn_backuser_Click(object sender, EventArgs e)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlTransaction tran = null;
        try
        {
            tran = connection.BeginTransaction();
            approveleave(4, 1, connection, tran);
            tran.Commit();
        }
        catch (Exception ex)
        {
            tran.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application sent back to employee");

    }


    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        int i, leave_status;
        string str = "";
        SqlTransaction _Transaction = null;
        int error = 0;
        ArrayList list = new ArrayList();
        btn_cancel.Enabled = false;
        try
        {
            SqlConnection con = activity.OpenConnection();
            sqlstr = "select leave_status,status,CONVERT(varchar(10),fromdate,101) as fromdate,CONVERT(varchar(10),todate,101) as todate from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
            ds = SQLServer.ExecuteDataset(con, CommandType.Text, sqlstr);
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
            case "01":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(3, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave application rejected Sucessfully.");
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
                    MailtoEmployee(list, "C", hidd_empcode.Value, ds.Tables[0].Rows[0]["fromdate"].ToString(), ds.Tables[0].Rows[0]["todate"].ToString());
                    for (int l = 0; l < list.Count; l++)
                    {
                        str = str + list[l].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;

                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
            case "11": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Activity not allowed,comp-off leave already approved");
                break;
            case "21": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Activity not allowed,comp-off leave already cancelled");
                break;
            case "31": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Comp-off leave application already rejected");
                break;
            case "61": Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=Activity not allowed,comp-off leave already approved");
                break;
            case "10":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    cancelmodification(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave cancellation application rejected sucessfully.");
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
                        cancelleave(list, "A");
                    for (int l = 0; l < list.Count; l++)
                    {
                        str = str + list[l].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;
                //cancel_modified_leave();
                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
            case "60":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off Request for cancellation rejected.");
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
                        cancelleave(list, "C");
                    for (int l = 0; l < list.Count; l++)
                    {
                        str = str + list[l].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;
                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
            case "12":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    cancel_modified_leave(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave modification application rejected sucessfully.");
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
                        cancelleave(list, "U");
                    for (int l = 0; l < list.Count; l++)
                    {
                        str = str + list[l].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;


                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
            case "62":
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(6, 1, _Connection, _Transaction);
                    cancelmodification(_Connection, _Transaction);
                    cancel_modified_leave(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off Leave modification application rejected sucessfully.");
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
                        cancelleave(list, "U");
                    for (int l = 0; l < list.Count; l++)
                    {
                        str = str + list[l].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_cancel.Enabled = true;
                Response.Redirect("compoffapproval.aspx?compoffstatus=0&hr=0&message=" + str);
                break;
        }
    }

    private void cancelleave(ArrayList list, string a)
    {
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + hidd_empcode.Value + "'";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, sqlstr);


        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

        string subject = "";
        string bodyContent = "";

        if (a == "A")
        {
            subject = "Cancellation of Compoff Application By Manager";
            bodyContent = "your Compoff application is Rejected by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";
        }
        else if (a == "C")
        {
            subject = "Rejection of Cancelation of Compoff Application By Manager";
            bodyContent = "your Compoff application is Rejected by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";

        }
        else if (a == "U")
        {
            subject = "Rejection of Modification  Compoff Applilcation Approved By Manager";
            bodyContent = "your Compoff application is Rejected by " + Session["name"].ToString() + " from " + lbl_fromdate.Text + " to " + lbl_todate.Text + ".";

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
                list.Add("Comp-Off Rejection mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            list.Add("Comp-Off mail Rejection is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }

    }

    protected void cancelmodification(SqlConnection conn, SqlTransaction tran)
    {

        SqlParameter sqlparm = new SqlParameter("@leaveapplyid", hidd_leaveapplyid.Value);
        SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, tran, "sp_leave_compoffmodification_request", sqlparm);

    }

    protected void cancel_modified_leave(SqlConnection conn, SqlTransaction tran)
    {

        SqlParameter sqlparm = new SqlParameter("@leaveapplyid", hidd_leaveapplyid.Value);
        SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, tran, "sp_leave_reject_compoff_modification_request", sqlparm);


    }

    private void MailtoEmployee(ArrayList list, string a, string empcode,string fromdate,string todate)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select distinct job.emp_fname,job.official_email_id,joblm.empcode,joblm.official_email_id as lm_mail,jobdlm.empcode,jobdlm.official_email_id as dlm_mail
from tbl_intranet_employee_jobDetails job
 inner join tbl_employee_approvers app on app.empcode=job.empcode
 inner join tbl_intranet_employee_jobDetails joblm on joblm.empcode=app.app_reportingmanager
 inner join tbl_intranet_employee_jobDetails jobdlm on jobdlm.empcode=app.app_dotted_linemanager
 where job.empcode='" + empcode + "'";
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

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


                        //EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponApprovalOfRequestFinalStep();
                        //EmailClient client = new EmailClient(email);
                        //client.toEmailId = ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim();
                        //client.employeeName = ds.Tables[0].Rows[j]["empname"].ToString().Trim();
                        //client.requestNumber = leaveid.ToString();
                        //client.Send();
                        //string empAprvemsg = "Dear " + ds.Tables[0].Rows[j]["empname"].ToString().Trim() + "," + "\n" + "\n";
                        //empAprvemsg += "Your Leave Application has been successfully Approved by " + Session["name"].ToString().Trim() + " - " + Session["empcode"].ToString() + "\n" + "\n " + "\n";
                        //empAprvemsg += "Regards" + "," + "\n";
                        //empAprvemsg += "HR" + "\n";
                        if (a == "C")
                        {
                            if (ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim() != "")
                            {
                                string msgdetails = "Your holiday comp off";
                                msgdetails += " has been Rejected by Virtual Head " + Session["name"].ToString().Trim() + " from dated from " + fromdate + " - " + todate + ".";
                                sendmail_Template(ds.Tables[0].Rows[j]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[j]["emp_fname"].ToString().Trim(), msgdetails), "Compoff Application Status", ds.Tables[0].Rows[j]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[j]["dlm_mail"].ToString().Trim());

                            }
                        }
                        else if (a == "A")
                        {
                            if (ds.Tables[0].Rows[j]["official_email_id"].ToString().Trim() != "")
                            {
                                string msgdetails = "Your holiday comp off";
                                msgdetails += " has been Approved successfully by Virtual Head " + Session["name"].ToString().Trim() + " from dated from "+fromdate+" - "+todate+".";
                                sendmail_Template(ds.Tables[0].Rows[j]["official_email_id"].ToString(), EmailTemplate(ds.Tables[0].Rows[j]["emp_fname"].ToString().Trim(), msgdetails), "Compoff Application Status", ds.Tables[0].Rows[j]["lm_mail"].ToString().Trim(), ds.Tables[0].Rows[j]["dlm_mail"].ToString().Trim());

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["empname"] +
                                 " due to some technical problem.");
                        throw ex;
                    }
                }
                else
                {
                    list.Add("Email Id does not exists fot the employee: " + ds.Tables[0].Rows[j]["empname"]);
                }

                i--;
                j++;
            }
        }

    }
    public bool sendmail_Template(string recievermailid, string bdy, string sub, string lm_mail, string dlm_mail)
    {

        try
        {

            string senderId = ConfigurationManager.AppSettings["fromEmail"];
            string senderPassword = ConfigurationManager.AppSettings["pwd"];     

            string Template = bdy;
            bool IsAttachment = false;
            string FileName = string.Empty;
            System.Net.Mail.Attachment attachment = null;

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.To.Add(recievermailid);
            mailMessage.CC.Add(lm_mail);
            mailMessage.CC.Add(dlm_mail);
            mailMessage.From = new MailAddress(senderId);

            mailMessage.Subject = sub;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;

            mailMessage.Body = Template;
            mailMessage.IsBodyHtml = true;


            mailMessage.Priority = MailPriority.High;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new System.Net.NetworkCredential(senderId, senderPassword);
            smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["Port"]);
            smtpClient.Host = ConfigurationManager.AppSettings["smtp"];
            smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

            object userState = mailMessage;

            try
            {
                smtpClient.Send(mailMessage);
                if (IsAttachment)
                {
                    attachment.ContentStream.Close();

                }
                return true;
            }
            catch (System.Net.Mail.SmtpException)
            {
                return false;
            }
        }


        catch (Exception)
        {
            return false;
        }
    }
    public string EmailTemplate(string employee, string msg)
    {

        string emp = employee.ToString();

        string EmailFormat =
        @"<!DOCTYPE html PUBLIC '-//W3C//DTD HTML 4.01//EN' 'https://www.w3.org/TR/html4/strict.dtd'>" +
                    "<html lang='en'>" +
"<head>" +

    "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8'>" +

    "<style type='text/css'>" +
        "body, td, div, p, a, input" +
        "{" +
            "font-family: arial, sans-serif;" +
        "}" +
    "</style>" +

    "<meta http-equiv='X-UA-Compatible' content='IE=edge'>" +
    "<title>OD Application</title>" +
    "<style type='text/css'>" +
        "body, td" +
        "{" +
            "font-size: 13px;" +
        "}" +

        "a:link, a:active" +
        "{" +
            "color: #1155CC;" +
            "text-decoration: none;" +
        "}" +

        "a:hover" +
       "{" +
            "text-decoration: underline;" +
            "cursor: pointer;" +
        "}" +

        "a:visited" +
        "{" +
            "color: #6611CC;" +
        "}" +

        "img" +
        "{" +
            "border: 0px;" +
        "}" +

        "pre" +
        "{" +
            "white-space: pre;" +
            "white-space: -moz-pre-wrap;" +
            "white-space: -o-pre-wrap;" +
            "white-space: pre-wrap;" +
           "word-wrap: break-word;" +
           "max-width: 800px;" +
            "overflow: auto;" +
        "}" +

        ".logo" +
        "{" +
            "left: -7px;" +
            "position: relative;" +
        "}" +
    "</style>" +
"</head>" +
"<body>" +
    "<div class='bodycontainer'>" +


        "<div class='maincontent'>" +

            "<table width='100%' cellpadding='0' cellspacing='0' border='0' class='message'>" +
                "<tr>" +

                    "<tr>" +
                        "<td colspan='2'><font size='-1' class='recipient'>" +
                            "<div></div>" +
                        "</font>" +
                           " <tr>" +
                                "<td colspan='2'>" +
                                    "<table width='100%' cellpadding='12' cellspacing='0' border='0'>" +
                                        "<tr>" +
                                            "<td>" +
                                                "<div style='overflow: hidden;'>" +
                                                    "<font size='-1'>" +
                                                        "<div id='leaveid'>" +
            //"<table width='100%'>" +
            //    "<tbody>" +

                                                            //        "<tr>" +
            //            "<td style='border-bottom: 1px solid #ccc; font: 12px arial'>" +
            //                "<div style='font: bold 14px arial; color: #0099ff; margin: 0; padding: 0'><span>Holiday Work Application</span></div>" +
            //            "</td>" +
            //            "<td style='font: bold 14px arial; color: #0099ff; border-bottom: 1px solid #ccc'>" +
            //        "</tr>" +
            //    "</tbody>" +
            //"</table>" +
            //"<br>" +
                                                            "<p><b>Dear " + emp + @",</b></p>" +
                                                            "<p style='text-align: justify; color: #000000; text-align: justify'> " + msg + "</p>" +

                                                            "<p>Click here - https://escalon.sdlapps.com </p>" +

                                                            "<p>" +
                                                                "<b>Regards,<br><br>" +
                                                                    "HR<br><br>" +
                                                                "</b>" +
                                                            "</p>" +
                                                            "<br>" +

                                                            "<table width='100%'>" +
                                                                "<tbody>" +
                                                                    "<tr>" +
                                                                        "<td colspan='2' style='font: 12px arial; color: #333; text-align: justify'>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                            "<b>This is a system generated mail. Please do not reply to this email ID. If you have a query or need any clarification you may contact HR." +
                                                                            "<br>" +
            //"(1) Call our 24-hour Customer Care or<br>" +
            //"(2) Email Us <a href='" + ConfigurationManager.AppSettings[""] + @"' target='_blank'>" + ConfigurationManager.AppSettings[""] + @"</a> </b>" +
                                                                            "<br>" +
                                                                            "<hr>" +
                                                                            "<br>" +
                                                                        "</td>" +
                                                                    "</tr>" +
                                                                "</tbody>" +
                                                            "</table>" +

                                                        "</div>" +
                                                    "</font>" +
                                                "</div>" +
                                    "</table>" +
            "</table>" +
        "</div>" +
    "</div>" +

"</body>" +
"</html>";

        return EmailFormat;
    }


}