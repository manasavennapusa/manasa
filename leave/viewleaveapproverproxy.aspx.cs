using Common.Console;
using Common.Data;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;


public partial class leave_viewleaveapproverproxy : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr; int error, i;
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
                Session.Remove("adjusttable");
                Common.Encode.QueryString q = new Common.Encode.QueryString();
                hidd_leaveapplyid.Value = (q["leaveapplyid"] != null) ? q["leaveapplyid"] : "0";
                hidd_empcode.Value = (q["empcode"] != null) ? q["empcode"] : "0";
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
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value);
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


                if (ds.Tables[0].Rows[0]["status"].ToString() == "0")
                {
                    btn_approve.Text = "Approve cancellation";
                    btn_backuser.Enabled = false;
                    btn_cancel.Text = "Reject cancellation";
                    btn_approve.CssClass = "btn btn-info pull-right pull-right";
                    btn_cancel.CssClass = "btn btn-info pull-right pull-right";
                }
                if (ds.Tables[0].Rows[0]["status"].ToString() == "2")
                {
                    btn_approve.Text = "Approve modification";
                    btn_backuser.Enabled = false;
                    btn_cancel.Text = "Reject modification";
                    btn_approve.CssClass = "btn btn-info pull-right pull-right";
                    btn_cancel.CssClass = "btn btn-info pull-right pull-right";
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
            //if (ds.Tables[0].Rows[0]["leaveid"].ToString() == ConfigurationManager.AppSettings["FL"].ToString())
            //{
            //    div_Furnelleave.Visible = true;
            //    lblrelation.Text = ds.Tables[0].Rows[0]["relation"].ToString();
            //}
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
    protected void createadjustment()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("leaveid", typeof(int));
        dtable.Columns.Add("leavename", typeof(string));
        dtable.Columns.Add("status", typeof(int));
        dtable.Columns.Add("noofdays", typeof(string));
        Session["adjusttable"] = dtable;
    }

    #endregion
    #region Approve Button Click Event
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
        string str = "";
        ArrayList list = new ArrayList();
        int i, leave_status;
        try
        {

            SqlConnection connection = activity.OpenConnection();
            SqlParameter[] sqlparm = new SqlParameter[2];
            string approverstr = @"select approverid from tbl_leave_employee_hierarchy_proxy where apply_leave_id='" + hidd_leaveapplyid.Value + "' and employeecode='" + hidd_empcode.Value + "' and proxy_approverid='" + _userCode + "'";
            DataSet dsapprover = SQLServer.ExecuteDataset(connection, CommandType.Text, approverstr);
            if (dsapprover.Tables[0].Rows.Count > 0)
            {
                hidd_approverid.Value = dsapprover.Tables[0].Rows[0]["approverid"].ToString();
            }
            Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, hidd_approverid.Value);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
            i = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, "sp_leave_validateleavestatus", sqlparm));
            if (i == 0)
                leave_status = 1;
            else
                leave_status = 0;
            string sqlstr = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
            {
                case "01":
                    if (!validate_staff_leave_balance())
                        break;
                    else
                    {
                        SqlConnection _Connection = activity.OpenConnection();
                        btn_approve.Enabled = false;
                        try
                        {

                            _Transaction = _Connection.BeginTransaction();
                            approveleave(leave_status, 1, _Connection, _Transaction);

                            updatependingleave(_Connection, _Transaction);
                            updateleaveapplication(6, 1, _Connection, _Transaction);
                            updatebackmonth(_Connection, _Transaction);

                            _Transaction.Commit();
                            list.Add("Leave application approved successfully.");
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
                            if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                                mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "A");
                            if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                                mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "A");
                            for (int j = 0; j < list.Count; j++)
                            {
                                str = str + list[j].ToString();
                                str = str + "\\n";
                            }
                            Output.Show(str);
                            // Response.Redirect("leave_status.aspx?leavestatus=0");
                        }

                        btn_approve.Enabled = true;
                        Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                        break;
                    }
                case "11": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave application already approved");
                    break;
                case "21": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave application already cancelled");
                    break;
                case "31": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave application already rejected");
                    break;
                case "61": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave application already approved");
                    break;
                case "10":
                    btn_approve.Enabled = false;
                    try
                    {

                        SqlConnection _Connection = activity.OpenConnection();
                        _Transaction = _Connection.BeginTransaction();
                        approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0, _Connection, _Transaction);
                        //if (ds.Tables[0].Rows[0]["leave_status"].ToString() == approverstatus.ToString())
                        //{
                        updatecancelleave(0, _Connection, _Transaction);
                        updateleaveapplication(2, 1, _Connection, _Transaction);
                        //   }
                        _Transaction.Commit();

                        list.Add("Leave cancellation application approved sucessfully.");
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
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "C");
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "C");
                        for (int k = 0; k < list.Count; k++)
                        {
                            str = str + list[k].ToString();
                            str = str + "\\n";
                        }


                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }

                    btn_approve.Enabled = true;


                    Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave cancellation application approved sucessfully");
                    break;
                case "60": btn_approve.Enabled = false;
                    try
                    {
                        SqlConnection _Connection = activity.OpenConnection();
                        _Transaction = _Connection.BeginTransaction();
                        approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 0, _Connection, _Transaction);
                        //if (ds.Tables[0].Rows[0]["leave_status"].ToString() == approverstatus.ToString())
                        //{
                        updatecancelleave(1, _Connection, _Transaction);
                        updateleaveapplication(2, 1, _Connection, _Transaction);
                        //  }
                        _Transaction.Commit();
                        list.Add("Leave cancellation application approved sucessfully.");
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
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "C");
                        if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                            mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "C");
                        for (int l = 0; l < list.Count; l++)
                        {
                            str = str + list[l].ToString();
                            str = str + "\\n";
                        }
                        Output.Show(str);
                        // Response.Redirect("leave_status.aspx?leavestatus=0");
                    }
                    btn_approve.Enabled = true;
                    Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                    break;
                case "12":
                case "62":
                    if (!validate_staff_leave_balance())
                        break;
                    else
                    {
                        btn_approve.Enabled = false;
                        try
                        {
                            SqlConnection _Connection = activity.OpenConnection();
                            _Transaction = _Connection.BeginTransaction();
                            approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 2, _Connection, _Transaction);
                            //if (ds.Tables[0].Rows[0]["leave_status"].ToString() == approverstatus.ToString())
                            //{
                            updatemodifiedleave(_Connection, _Transaction);
                            updateleaveapplication(6, 1, _Connection, _Transaction);
                            //}
                            _Transaction.Commit();
                            list.Add("Leave modification application approved sucessfully");
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
                            if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                                mailtoemployee(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "U");
                            if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                                mailtohr(list, hidd_empcode.Value, hidd_leaveapplyid.Value, "U");

                            for (int m = 0; m < list.Count; m++)
                            {
                                str = str + list[m].ToString();
                                str = str + "\\n";
                            }
                            Output.Show(str);
                            // Response.Redirect("leave_status.aspx?leavestatus=0");
                        }

                        btn_approve.Enabled = true;
                        Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                        break;
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

    }

    protected void approveleave(int leavestatus, int status, SqlConnection connection, SqlTransaction transaction)
    {

        int approverstatus = 0;
        string sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode";
        SqlParameter[] sqlparm;
        if (leavestatus == 4)
            approverstatus = 0;
        else
        {
            sqlparm = new SqlParameter[2];
            Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, hidd_approverid.Value);
            Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);
            approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.Text, transaction, sqlstr, sqlparm));

        }
        sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,modifiedby=@modifiedby,approvel_status=@approvel_status,status=@status,modifieddate=getdate() where id=@applyleaveid";
        sqlparm = new SqlParameter[6];
        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, (txt_comment.Text != "" ? "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>" : ""));
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm, 4, "@approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm, 5, "@status", "Int", 50, status.ToString());
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparm);

        string sqlstr1 = @"update  tbl_leave_employee_hierarchy set flag=1  where employeecode='" + hidd_empcode.Value + "'";
        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr1);
    }
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
    protected void updateleaveapplication(int leavestatus, int status, SqlConnection connection, SqlTransaction transaction)
    {

        int approverstatus = 0;
        sqlstr = "select approverpriority from tbl_leave_employee_hierarchy where approverid=@approverid and employeecode=@empcode order by 1 desc";
        SqlParameter[] sqlparm;

        sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@approverid", "String", 50, hidd_approverid.Value);
        Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, hidd_empcode.Value);


        approverstatus = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.Text, transaction, sqlstr, sqlparm));



        sqlstr = "update tbl_leave_apply_leave set comments=isnull(comments,'') +isnull( @comments,''),leave_status=@leave_status,status=@status,modifiedby=@modifiedby,modifieddate=getdate(),approvel_status=@approvel_status where id=@applyleaveid";
        sqlparm = new SqlParameter[6];

        Output.AssignParameter(sqlparm, 0, "@comments", "String", 2000, "");
        Output.AssignParameter(sqlparm, 1, "@modifiedby", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 2, "@applyleaveid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 3, "@leave_status", "Int", 50, leavestatus.ToString());
        Output.AssignParameter(sqlparm, 4, "@approvel_status", "Int", 50, approverstatus.ToString());
        Output.AssignParameter(sqlparm, 5, "@status", "Int", 50, status.ToString());

        SQLServer.ExecuteNonQuery(connection, CommandType.Text, transaction, sqlstr, sqlparm);

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
                          (CASE WHEN todate = '01/01/1900' THEN '' ELSE CONVERT(CHAR(10),todate, 101) END) todate,(CASE WHEN hdate= '01/01/1900' THEN '' ELSE CONVERT(CHAR(10), hdate, 101) END) hdate FROM tbl_leave_apply_leave WHERE id=" + hidd_leaveapplyid.Value;

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
    #endregion
    #region Sending Mail To HR & Employee
    private void mailtohr(ArrayList list, string p1, string p2, string a)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname ,approverid from tbl_leave_employee_hierarchy eh inner join tbl_intranet_employee_jobDetails ej on ej.empcode=eh.approverid where  hr=1 and employeecode='" + hidd_empcode.Value + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("10&leaveapplyid={0}&empcode={1}&approvercode={2}&post={3}", p2, p1, ds1.Tables[0].Rows[0]["approverid"].ToString(), "HR");
        string encoded;
        encoded = q.EncodePairs(pairs);
        string url = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "' >Update</a>";
        string url1 = "<a target='content' style='text-decoration:none;color: #fff;background-color: #3968c6;background-image: none;filter: none;-webkit-box-shadow: none;-moz-box-shadow: none;box-shadow: none;padding:7px 13px 7px 13px;;text-shadow: none;font-weight: normal;font-size: 24px;cursor: pointer;border: 1px solid rgba(0,0,0,0.13);-webkit-border-radius: 0;-moz-border-radius: 0;border-radius: 0;position: relative;z-index: 1;-webkit-user-select: none;'  href='" + ConfigurationManager.AppSettings["url"].ToString() + "?m=" + pairs + "'>Reject</a>";
        string subject = "";
        string bodyContent = "";

        if (a == "A")
        {
            subject = "Leave Application Approved By Dotted Line Manager";
            bodyContent = "Leave application is Approved by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + "";//.Please Update the Leave.<br/><br/>" + url + "   " + url1;
        }
        else if (a == "C")
        {
            subject = "Cancelation of Leave Applilcation Approved By Dotted Line Manager";
            bodyContent = "Leave application is Canceled by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + "";
            //.Please Update the Leave.<br/><br/>" + url + "   " + url1;
        }
        else if (a == "U")
        {
            subject = "Modification of Leave Applilcation Approved By Dotted Line Manager";
            bodyContent = "Leave application is Approved by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + "";
            //.Please Update the Leave.<br/><br/>" + url + "   " + url1;
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
                list.Add("Leave Approved Mail is not delivered to the HR: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            list.Add("Leave Approved Mail is not delivered to the HR: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }
        activity.CloseConnection();
    }
    private void mailtoemployee(ArrayList list, string p1, string p2, string a)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + hidd_empcode.Value + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();

        string subject = "";
        string bodyContent = "";

        if (a == "A")
        {
            subject = "Leave Application Approved By Dotted Line Manager";
            bodyContent = "Leave application is Approved by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + ".";
        }
        else if (a == "C")
        {
            subject = "Cancelation  of  Leave Applilcation Approved By Dotted Line Manager";
            bodyContent = "Your Leave application is cancelled by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ".";
        }
        else if (a == "U")
        {
            subject = "Modification of Leave Applilcation Approved By Dotted Line Manager";
            bodyContent = "Leave application is Approved by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + ".";
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
                list.Add("Leave Approved Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            list.Add("Leave Approved Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }
        activity.CloseConnection();
    }
    #endregion
    protected Boolean validate_staff_leave_balance()
    {

        try
        {
            SqlConnection connection = activity.OpenConnection();
            DataSet ds1, ds2, ds3 = new DataSet();
            string str2 = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
            ds2 = SQLServer.ExecuteDataset(connection, CommandType.Text, str2);
            DateTime dt = new DateTime();
            if (divfull.Visible == true)
                dt = Common.Date.Utility.DateFormat(lbl_sdate.Text);
            else
                dt = Common.Date.Utility.DateFormat(lbl_select.Text);

            string str3 = @"select leaveid,days from tbl_leave_adjustment_apply where leaveid<>0 and apply_leave_id=" + hidd_leaveapplyid.Value;
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, str3);

            if (ds3.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
                {
                    SqlParameter[] sqlparm = new SqlParameter[4];
                    Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, hidd_empcode.Value);
                    Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 50, ds3.Tables[0].Rows[i]["leaveid"].ToString());
                    Output.AssignParameter(sqlparm, 2, "@applieddays", "Decimal", 50, ds3.Tables[0].Rows[i]["days"].ToString());
                    Output.AssignParameter(sqlparm, 3, "@id", "Int", 50, (Convert.ToInt32(ds2.Tables[0].Rows[0]["leave_status"].ToString()) == 6) ? hidd_leaveapplyid.Value : "0");
                    ds1 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_leavebalance_approver", sqlparm);
                    //   ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_validate_leavebalance_approver", sqlparm);
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        if (ds1.Tables[0].Rows[0][0].ToString() == "0")
                        {
                            //ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", "<script> alert('" + ds1.Tables[0].Rows[0][1].ToString() + "')</script>", false);
                            Page.RegisterStartupScript("vv", "<script> alert('" + ds1.Tables[0].Rows[0][1].ToString() + "')</script>");
                            return false;
                        }
                    }
                }
            }
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
        return true;
    }
    #region Back To User
    protected void btn_backuser_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        SqlConnection connection = activity.OpenConnection();
        SqlTransaction transaction = connection.BeginTransaction();
        try
        {

            approveleave(4, 1, connection, transaction);
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
        Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave application sent back to employee");
    }
    #endregion
    #region Rejection the Leave Request
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        if (txt_comment.Text.Trim() == "")
        {
            txt_comment.Focus();
            Output.Show("Please enter the comments.");
            return;
        }

        SqlTransaction _Transaction = null;
        int leaveid = 0;
        string str = "";
        ArrayList list = new ArrayList();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select leave_status,status from tbl_leave_apply_leave where id=" + hidd_leaveapplyid.Value;
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
        btn_cancel.Enabled = false;
        switch (ds.Tables[0].Rows[0]["leave_status"].ToString() + ds.Tables[0].Rows[0]["status"].ToString())
        {
            case "01":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(3, 1, _Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave application Rejected successfully.");
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
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        cancelleave(list, "A");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);
                }

                btn_cancel.Enabled = true;
                Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "11": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already approved");
                break;
            case "21": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already cancelled");
                break;
            case "31": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Leave application already rejected");
                break;
            case "61": Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=Activity not allowed,leave already approved");
                break;
            case "10":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    cancelmodification(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave Cancelation application Rejected successfully.");
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
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        cancelleave(list, "C");

                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);

                }

                btn_cancel.Enabled = true;
                Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "60":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    cancelmodification(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave Canceilation application Rejected successfully.");
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
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        cancelleave(list, "C");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);
                }
                btn_cancel.Enabled = true;

                Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "12":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();
                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    cancel_modified_leave(_Connection, _Transaction);
                    cancelmodification(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave modification application rejected sucessfully.");
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
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        cancelleave(list, "U");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }
                    Output.Show(str);
                }

                btn_cancel.Enabled = true;

                Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);
                break;
            case "62":
                try
                {
                    SqlConnection _Connection = activity.OpenConnection();

                    _Transaction = _Connection.BeginTransaction();
                    approveleave(Convert.ToInt32(ds.Tables[0].Rows[0]["leave_status"]), 1, _Connection, _Transaction);
                    approveleave(6, 1, _Connection, _Transaction);
                    cancelmodification(_Connection, _Transaction);
                    cancel_modified_leave(_Connection, _Transaction);
                    _Transaction.Commit();
                    list.Add("Leave modification application Rejected successfully.");
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
                    if (ConfigurationManager.AppSettings["mail"].ToString() == "A")
                        cancelleave(list, "U");
                    for (int i = 0; i < list.Count; i++)
                    {
                        str = str + list[i].ToString();
                        str = str + "\\n";
                    }


                    Output.Show(str);

                }

                btn_cancel.Enabled = true;


                Response.Redirect("leaveapprovalbyproxyapprover.aspx?leavestatus=0&hr=0&message=" + str);

                break;
        }

    }
    #endregion
    #region Rejection Mail to Employee
    private void cancelleave(ArrayList list, string a)
    {
        SqlConnection connection = activity.OpenConnection();
        string sqlstr = @"select empcode,official_email_id,isnull(emp_fname,'')+' ' +isnull(emp_m_name,'')+' ' +isnull(emp_l_name,'') as empname from dbo.tbl_intranet_employee_jobDetails  where empcode='" + hidd_empcode.Value + "'";
        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        // DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
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
            subject = "Rejection of Leave Application  By Dotted Line Manager.";
            bodyContent = "Leave application is Rejected by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + ".";
        }
        else if (a == "C")
        {
            subject = "Rejection of Cancelation  Leave Application By Dotted Line Manager";
            bodyContent = "Your Leave cancelation application is rejected by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + ".";
        }
        else if (a == "U")
        {
            subject = "Rejection of Modification  Leave Applilcation Approved By Dotted Line Manager";
            bodyContent = "Leave modification  application is rejected by " + Session["name"].ToString() + " from " + lbl_sdate.Text + " to " + lbl_edate.Text + "of " + lbl_emp_name.Text + ".";
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
                list.Add("Leave Rejection Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Due to some technical problem.");
            }
        }
        else
        {
            list.Add("Leave Rejection Mail is not delivered to the employee: " + ds1.Tables[0].Rows[0]["empname"].ToString() + ". Email id does not exists.");
        }
        activity.CloseConnection();

    }
    #endregion
    #region cancel  The Modified Leave Request
    protected void cancelmodification(SqlConnection connection, SqlTransaction transaction)
    {

        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 1, "@companyid", "Int", 50, _companyId.ToString());
        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_modification_request", sqlparm);


    }
    #endregion
    #region Reject  The Modified Leave Request
    protected void cancel_modified_leave(SqlConnection connection, SqlTransaction transaction)
    {

        SqlParameter[] sqlparm = new SqlParameter[2];
        Output.AssignParameter(sqlparm, 0, "@leaveapplyid", "Int", 50, hidd_leaveapplyid.Value);
        Output.AssignParameter(sqlparm, 1, "@companyid", "Int", 50, _companyId.ToString());
        SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_reject_leave_modification_request", sqlparm);


    }
    #endregion
    protected void adjustgrid_PreRender(object sender, EventArgs e)
    {
        if (adjustgrid.Rows.Count > 0)
            adjustgrid.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
    }
    protected void approvergrid_PreRender(object sender, EventArgs e)
    {
        if (approvergrid.Rows.Count > 0)
            approvergrid.HeaderRow.TableSection = System.Web.UI.WebControls.TableRowSection.TableHeader;
    }
}
