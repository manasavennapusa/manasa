using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using Common.Data;
using Common.Console;

public partial class leave_viewcompoff : System.Web.UI.Page
{
    string sqlstr;
    string message1;
    DataSet ds = new DataSet();
    public int i, ptr1, ptr2;
    int error = 0;
    DataActivity activity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            Common.Encode.QueryString q = new Common.Encode.QueryString();
            hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
            bindemployee_detail();
            fetchleavedata();
            bindcompoffentitled();
        }
    }

    protected void bindcompoffentitled()
    {
        try
        {
            SqlParameter sqlparm1 = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm1.Value = Session["empcode"].ToString();
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
            sqlparm[0] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
            sqlparm[0].Value = hidd_leaveapplyid.Value;

            sqlparm[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[1].Value = Session["empcode"].ToString();

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewcompoffapply", sqlparm);
            if (ds.Tables[0].Rows.Count > 0)
            {

                if ((ds.Tables[0].Rows[0]["leave_status"].ToString() == "3" || ds.Tables[0].Rows[0]["leave_status"].ToString() == "2") && (ds.Tables[0].Rows[0]["status"].ToString() == "1"))
                {
                    txt_cancel.Enabled = false;
                    btn_modify.Enabled = false;

                }
                lbl_sdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
                lbl_edate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("MM/dd/yyyy");

                lbl_nod.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
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
            //    workedon_grid.DataSource = ds.Tables[1];
            //    workedon_grid.DataBind();
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
            SqlParameter sqlparm = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm.Value = Session["empcode"].ToString();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_viewempdetail", sqlparm);
            lbl_emp_name.Text = ds.Tables[0].Rows[0]["name"].ToString();
            lbl_emp_code.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lbl_gender.Text = ds.Tables[0].Rows[0]["emp_gender"].ToString();
            lbl_emp_status.Text = ds.Tables[0].Rows[0]["status"].ToString();
            lbl_department.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lbl_designation.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lbl_doj.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"]).ToString("dd - MMM - yyyy");
            //workedon_grid.DataSource = null;
            //workedon_grid.DataBind();
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


    protected void btn_modify_Click(object sender, EventArgs e)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&modify=1", hidd_leaveapplyid.Value);
        string encoded;
        encoded = q.EncodePairs(pairs);
        Response.Redirect("editcompoff.aspx?q=" + encoded);
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        btn_modify.Enabled = false;
        string str = "";
        SqlTransaction _Transaction = null;
        int leaveid = 0;
        ArrayList list = new ArrayList();
        int status;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;
        //try
        //{
        SqlConnection conn = activity.OpenConnection();
        status = Convert.ToInt32(SQLServer.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_leave_validate_confirmcompoff_hr", sqlparm));
        activity.CloseConnection();
        switch (status)
        {
            case 0:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave cancelled successfully.");
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
                        mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_modify.Enabled = true;
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 1:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(1, 0, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave applied for cancellation successfully");
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
                        mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_modify.Enabled = true;
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);

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
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=Comp-off leave already cancelled");
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
                    _Transaction.Rollback();
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    activity.CloseConnection();
                }
                Response.Redirect("compoffstatus.aspx?leavestatus=10&message=Comp-off leave cannot be cancelled,its already in rejected status");
                break;
            case 4:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave cancelled Successfully");
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
                        mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_modify.Enabled = true;
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 5:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave cancelled Successfully");
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
                        mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_modify.Enabled = true;


                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 6:

                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(6, 0, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave applied for cancellation successfully");
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
                        mailtocancelapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_modify.Enabled = true;

                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
        }

    }
    protected void mailtoapprover(ArrayList list, int leaveid, string type)
    {
        SqlConnection connection = activity.OpenConnection();
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
        sqlparm[1] = new SqlParameter("@type", type);
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
                string subject = "Compoff Updation for Approval";
                string bodyContent = "A new Compoff updation  request has been submitted by employee " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ". <br/><br/>  Kindly login to the leave module to view the request:<br/><br/> <a  href='" + ConfigurationManager.AppSettings["url"].ToString() + "' >Login</a>";

                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);

                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
                {
                    try
                    {

                        Email.getemail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                    }
                    catch
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString() + " due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Email is does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString());
                }

                i--;
                j++;
            }
        }
        activity.CloseConnection();
    }
    protected void mailtocancelapprover(ArrayList list, int leaveid, string type)
    {
        SqlConnection connection = activity.OpenConnection();

        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@leaveapplyid", leaveid);
        sqlparm[1] = new SqlParameter("@type", type);
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
                Common.Encode.QueryString q = new Common.Encode.QueryString();
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "LA");
                string encoded;
                encoded = q.EncodePairs(pairs);

                string url = "";
                string url1 = "";

                //string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                //string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
                string subject = "Compoff Cancelation for Approval";
                string bodyContent = "A new Compoff Cancelition  request has been submitted by employee " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ". <br/><br/> " + url + " " + url1;

                string completeBody = Email.GetBody(fromName, ds.Tables[0].Rows[j]["a_name"].ToString(), bodyContent);
                if (ds.Tables[0].Rows[j]["official_email_id"].ToString() != "")
                {
                    try
                    {


                        Email.getemail(fromEmail, fromPwd, fromName, ds.Tables[0].Rows[j]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
                    }
                    catch
                    {
                        list.Add("Email is not delivered to the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString() + " due to some technical problem.");
                    }
                }
                else
                {
                    list.Add("Email is does not exists fot the employee: " + ds.Tables[0].Rows[j]["a_name"].ToString());
                }

                i--;
                j++;
            }
        }
        activity.CloseConnection();
    }
    protected void cancelleave(int leave_status, int status, SqlConnection connection, SqlTransaction transaction)
    {

        SqlParameter[] sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[0].Value = "<b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "<br>";
        else
            sqlparm[0].Value = "";

        sqlparm[1] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[1].Value = Session["name"].ToString();

        sqlparm[2] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[2].Value = hidd_leaveapplyid.Value;

        sqlparm[3] = new SqlParameter("@Leave_status", SqlDbType.Int, 4);
        sqlparm[3].Value = leave_status;

        sqlparm[4] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[4].Value = status;

        if (leave_status == 1 || leave_status == 6)
        {
            sqlstr = "update tbl_leave_apply_compoff set comment=isnull(comment,'') + isnull(@comment,''),leave_status=@leave_status,approval_status=0,status=@status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text,transaction, sqlstr, sqlparm);
        }
        else
        {
            sqlstr = "update tbl_leave_apply_compoff set comment=isnull(comment,'') +isnull(@comment,''),leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text,transaction, sqlstr, sqlparm);
        }

    }
}