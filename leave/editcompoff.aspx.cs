using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web.UI;
using Utilities;
using Common.Data;
using Common.Console;


public partial class leave_editcompoff : System.Web.UI.Page
{
    string sqlstr;
    string message1;
    DataSet ds = new DataSet();
    DataTable dtable = new DataTable();
    int flag = 0;
    DataActivity activity = new DataActivity();
    public int i, ptr1, ptr2;
    int error = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            //Session.Remove("workedontable");

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
            SqlConnection connection = activity.OpenConnection();
            SqlParameter sqlparm1 = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm1.Value = Session["empcode"].ToString();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_leave_entitledcompoff]", sqlparm1);


            lblentitled.Text = ds.Tables[0].Rows[0]["allowcompoff"].ToString();
            lblused.Text = ds.Tables[0].Rows[0]["approvedays"].ToString();
            lblavalible.Text = ds.Tables[0].Rows[0]["avalibledays"].ToString();
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
                Common.Console.Output.Show("Problem fetching compoff data,try latter");
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
                    btn_submit.Enabled = false;
                    btn_reset.Enabled = false;
                }

                if (Convert.ToBoolean(ds.Tables[0].Rows[0]["half"]))
                {
                    txt_fromdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
                    txt_todate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["todate"]).ToString("MM/dd/yyyy");
                    rdofullday.Checked = true;
                    divfull.Visible = true;
                    divhalf.Visible = false;
                }
                else
                {
                    txtdateone.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["fromdate"]).ToString("MM/dd/yyyy");
                    rdohalfday.Checked = true;
                    divfull.Visible = false;
                    divhalf.Visible = true;
                }
                lbl_no_of_days.Text = ds.Tables[0].Rows[0]["no_of_days"].ToString();
                txt_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
                lbl_comments.Text = ds.Tables[0].Rows[0]["comment"].ToString();

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


    protected void btn_submit_Click1(object sender, EventArgs e)
    {
        btn_submit.Enabled = false;
        string str = "";
        SqlTransaction _Transaction = null;
        int leaveid = 0;
        ArrayList list = new ArrayList();
        Page.Validate("calculate");
        Page.Validate("v");
        if (!Page.IsValid)
            return;

        if (lbl_no_of_days.Text == "0")
            return;


        int status;
        SqlParameter[] sqlparm;
        sqlparm = new SqlParameter[1];

        sqlparm[0] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[0].Value = hidd_leaveapplyid.Value;

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
                    updateapplyleave(0, 1, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave updated successfully");
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
                        mailtoapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 1:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(1, 2, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave applied for modification successfully");
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
                        mailtoapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;
                Response.Redirect("viewcompoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 2:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(2, 1, _Connection, _Transaction);
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
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=Comp-off leave cannot be modified,its already in cancel status");
                break;
            case 3:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(3, 1, _Connection, _Transaction);
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
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=Comp-off leave cannot be modified,its already in rejected status");
                break;
            case 4:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(0, 1, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave updated successfully");
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
                        mailtoapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;
                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 5:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    updateapplyleave(0, 1, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave updated successfully");
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
                        mailtoapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;


                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 6:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    save_before_updation(_Connection, _Transaction);
                    updateapplyleave(6, 2, _Connection, _Transaction);
                    updateadjustment(_Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off leave applied for modification successfully");
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
                        mailtoapprover(list, Convert.ToInt32(hidd_leaveapplyid.Value), "c");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    SmartHr.Common.Alert(str);
                    // Response.Redirect("leave_status.aspx?leavestatus=0");
                }

                btn_submit.Enabled = true;


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
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "CO");
                //string encoded;
                //encoded = q.EncodePairs(pairs);

                string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
                string subject = "Compoff Updation for Approval";
                string bodyContent = "A new Compoff updation  request has been submitted by employee " + Session["name"].ToString() + " from " + txt_fromdate.Text + " to " + txt_todate.Text + ". <br/><br/> " + url + "&nbsp; &nbsp;&nbsp;" + url1;

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
                string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", ds.Tables[0].Rows[j]["id"].ToString(), ds.Tables[0].Rows[j]["empcode"].ToString(), ds.Tables[0].Rows[j]["approvercode"].ToString(), "CO");
                //string encoded;
                //encoded = q.EncodePairs(pairs);

                string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Approve</a>";
                string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
                string subject = "Compoff Cancelation for Approval";
                string bodyContent = "A new Compoff Cancelition  request has been submitted by employee " + Session["name"].ToString() + " from " + txt_fromdate.Text + " to " + txt_todate.Text + ". <br/><br/>   " + url + " & nbsp; &nbsp; &nbsp; " + url1;

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
    protected void save_before_updation(SqlConnection connection, SqlTransaction transaction)
    {
        sqlstr = "delete from tbl_leave_modify_applied_compoff where apply_co_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

        sqlstr = "insert into tbl_leave_modify_applied_compoff select id,fromdate,todate,no_of_days,reason from tbl_leave_apply_compoff where id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
    }
    protected int updateapplyleave(int compoffstatus, int status, SqlConnection connection, SqlTransaction transaction)
    {
        SqlParameter[] sqlparm = new SqlParameter[12];

        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
        sqlparm[0].Value = Session["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[1].Value = hidd_leaveapplyid.Value;

        sqlparm[2] = new SqlParameter("@fromdate", SqlDbType.DateTime, 8);
        sqlparm[3] = new SqlParameter("@todate", SqlDbType.DateTime, 8);

        if (divfull.Visible == true)
        {
            sqlparm[2].Value = Utility.dataformat(txt_fromdate.Text.ToString());
            sqlparm[3].Value = Utility.dataformat(txt_todate.Text.ToString());
        }
        else
        {
            sqlparm[2].Value = Utility.dataformat(txtdateone.Text.ToString());
            sqlparm[3].Value = Utility.dataformat(txtdateone.Text.ToString());
        }




        sqlparm[4] = new SqlParameter("@no_of_days", SqlDbType.Decimal, 40);
        sqlparm[4].Value = Convert.ToDecimal(lbl_no_of_days.Text.ToString());

        sqlparm[5] = new SqlParameter("@reason", SqlDbType.VarChar, 500);
        sqlparm[5].Value = txt_reason.Text.ToString();


        sqlparm[6] = new SqlParameter("@approval_status", SqlDbType.Int, 4);
        sqlparm[6].Value = 0;

        sqlparm[7] = new SqlParameter("@leave_status", SqlDbType.Int, 4);
        sqlparm[7].Value = Convert.ToInt32(compoffstatus);

        sqlparm[8] = new SqlParameter("@comment", SqlDbType.VarChar, 2000);
        if (txt_comment.Text != "")
            sqlparm[8].Value = "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            sqlparm[8].Value = "";


        sqlparm[9] = new SqlParameter("@modifiedby", SqlDbType.VarChar, 100);
        sqlparm[9].Value = Session["name"].ToString();

        sqlparm[10] = new SqlParameter("@applyleaveid", SqlDbType.Int, 4);
        sqlparm[10].Value = Convert.ToInt32(hidd_leaveapplyid.Value);

        sqlparm[11] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[11].Value = Convert.ToInt32(status);


        return Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "sp_leave_update_apply_compoff", sqlparm));
    }
    protected void updateadjustment(SqlConnection connection, SqlTransaction transaction)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        if (q["modify"] != null)
        {
            sqlstr = "delete from tbl_leave_modify_compoff_adjustment where compoff_id=" + hidd_leaveapplyid.Value;
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);


            sqlstr = "insert into tbl_leave_modify_compoff_adjustment select compoff_id,date,status from tbl_leave_compoff_adjustment where compoff_id=" + hidd_leaveapplyid.Value;
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);
        }

        sqlstr = "delete from tbl_leave_compoff_adjustment where compoff_id=" + hidd_leaveapplyid.Value;
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr);

    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        bindemployee_detail();
        fetchleavedata();
        btn_submit.Enabled = true;
    }

    //************************************************************************************

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        txt_cancel.Enabled = false;
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
        switch (status)
        {
            case 0:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off cancelled successfully");
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

                txt_cancel.Enabled = true;


                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 1:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(1, 0, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off applied for cancellation successfully");
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

                txt_cancel.Enabled = true;


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

                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=Comp-off already cancelled");
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

                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=Comp-off cannot be cancelled,its already in rejected status");
                break;
            case 4:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off cancelled successfully");
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

                txt_cancel.Enabled = true;


                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 5:
                try
                {

                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(2, 1, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Comp-off cancelled successfully");
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

                txt_cancel.Enabled = true;


                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
            case 6:
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    cancelleave(6, 0, _Connection, _Transaction);
                    _Transaction.Commit();

                    list.Add("Compoff applied for cancellation successfully");
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

                txt_cancel.Enabled = true;


                Response.Redirect("compoffstatus.aspx?compoffstatus=10&message=" + str);
                break;
        }

    }


    protected void cancelleave(int leave_status, int status, SqlConnection connection, SqlTransaction trancation)
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
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, trancation, sqlstr, sqlparm);
        }
        else
        {
            sqlstr = "update tbl_leave_apply_compoff set comment=isnull(comment,'') + isnull(@comment,''),leave_status=@leave_status,modifiedby=@modifiedby where id=@applyleaveid";
            SQLServer.ExecuteNonQuery(connection, CommandType.Text, trancation, sqlstr, sqlparm);
        }
    }


    protected void btn_calc_Click(object sender, EventArgs e)
    {
        //if (!validate_dutyroster())
        //     return;
        if (validate_applydate())
        {
            validateapplycompoff();
        }
        else
        {
            return;
        }
    }
    //--------------------------Validation for LEAVE PERIOD & DUTY ROSTER--------------------------------

    //protected Boolean validate_dutyroster()
    //{
    //    if (divfull.Visible == true)
    //    {
    //        DateTime dt1 = Convert.ToDateTime(txt_fromdate.Text);
    //        DateTime dt2 = Convert.ToDateTime(txt_todate.Text);
    //        TimeSpan d1 = Convert.ToDateTime(txt_todate.Text) - Convert.ToDateTime(txt_fromdate.Text);

    //        if (d1.Days < 0)
    //        {
    //            Common.Console.Output.Show("End date should be greater than start date.");
    //            lbl_no_of_days.Text = "0.0";
    //            return false;
    //        }
    //    }
    //    DataSet dsdr = new DataSet();

    //    SqlParameter[] sqlpar = new SqlParameter[3];

    //    sqlpar[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
    //    sqlpar[0].Value = Session["empcode"].ToString();

    //    sqlpar[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
    //    sqlpar[2] = new SqlParameter("@todate", SqlDbType.DateTime);

    //    if (divfull.Visible == true)
    //    {
    //        sqlpar[1].Value = txt_fromdate.Text;
    //        sqlpar[2].Value = txt_todate.Text;
    //    }
    //    else
    //    {
    //        sqlpar[1].Value = txtdateone.Text;
    //        sqlpar[2].Value = txtdateone.Text;
    //    }

    //    dsdr = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_leave_dutyroster", sqlpar);

    //    if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) > 0)
    //    {
    //        if (Convert.ToInt32(dsdr.Tables[0].Rows[0]["drdays"].ToString()) != Convert.ToInt32(dsdr.Tables[1].Rows[0]["applieddays"].ToString()))
    //        {
    //            Common.Console.Output.Show("Your work roster is not created for this date span.Please contact your Manager.");
    //            return false;
    //        }
    //    }
    //    else
    //    {
    //        Common.Console.Output.Show("Your work roster is not created for this date span.Please contact your Manager.");
    //        return false;
    //    }
    //    return true;
    //}

    protected Boolean validate_applydate()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[3];
            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = Session["empcode"].ToString();

            sqlparam[1] = new SqlParameter("@startdate", SqlDbType.DateTime);

            sqlparam[2] = new SqlParameter("@enddate", SqlDbType.DateTime);


            if (divfull.Visible == true)
            {
                sqlparam[1].Value = Utility.dataformat(txt_fromdate.Text);
                sqlparam[2].Value = Utility.dataformat(txt_todate.Text);
            }
            else
            {
                sqlparam[1].Value = Utility.dataformat(txtdateone.Text);
                sqlparam[2].Value = Utility.dataformat(txtdateone.Text);
            }

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lbl_no_of_days.Text = "0";
                Common.Console.Output.Show("You have already applied for Leave/OD/Comp-Off during this span! Please check application status");
                return false;
            }
            else
            {
                if (ds.Tables[1].Rows.Count > 0)
                {
                    lbl_no_of_days.Text = "0";
                    Common.Console.Output.Show("You have already applied for Compoff during this span! Please check application status");
                    return false;
                }
                else
                {
                    if (ds.Tables[2].Rows.Count > 0)
                    {
                        lbl_no_of_days.Text = "0";
                        Common.Console.Output.Show("You have already applied for OD during this span! Please check application status");
                        return false;
                    }
                    else
                    {
                        if (ds.Tables[3].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            lbl_no_of_days.Text = "0";
                            Common.Console.Output.Show("Your leave profile is not created! Please contact to Manager");
                            return false;
                        }
                    }
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
        return true;
    }
    protected void rdofullday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
        }
    }
    protected void rdohalfday_CheckedChanged(object sender, EventArgs e)
    {
        if (rdofullday.Checked == true)
        {
            divhalf.Visible = false;
            divfull.Visible = true;
        }
        else
        {
            divhalf.Visible = true;
            divfull.Visible = false;
        }
    }

    protected void validateapplycompoff()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            SqlParameter[] sqlparm = new SqlParameter[7];

            sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 100);
            sqlparm[0].Value = Session["empcode"].ToString();

            sqlparm[1] = new SqlParameter("@halfday", SqlDbType.Bit);
            sqlparm[1].Value = Convert.ToBoolean(rdohalfday.Checked);

            sqlparm[2] = new SqlParameter("@startdate", SqlDbType.DateTime, 8);
            sqlparm[3] = new SqlParameter("@enddate", SqlDbType.DateTime, 8);

            if (divfull.Visible == true)
            {
                sqlparm[2].Value = Utility.dataformat(txt_fromdate.Text.Trim().ToString());
                sqlparm[3].Value = Utility.dataformat(txt_todate.Text.Trim().ToString());
            }
            else
            {
                sqlparm[2].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
                sqlparm[3].Value = Utility.dataformat(txtdateone.Text.Trim().ToString());
            }

            sqlparm[4] = new SqlParameter("@branch_id", SqlDbType.Int, 4);
            sqlparm[4].Value = Convert.ToInt32(Session["branch"]);

            sqlparm[5] = new SqlParameter("@id", SqlDbType.Int, 4);
            sqlparm[5].Value = hidd_leaveapplyid.Value;

            sqlparm[6] = new SqlParameter("@companyid", SqlDbType.Int, 4);
            sqlparm[6].Value = Session["companyid"];

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_leave_validatecompoff]", sqlparm);

            lbl_no_of_days.Text = ds.Tables[0].Rows[0]["noofdays"].ToString();

            if (lbl_no_of_days.Text == "0.0")
            {
                Common.Console.Output.Show("There is no balance Comp-Off.Please check the Comp-Off Status.");
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
}
