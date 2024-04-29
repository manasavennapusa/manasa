using Common.Console;
using Common.Data;
using Common.Date;
using Common.Mail;
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;


public partial class leave_editapplyod : System.Web.UI.Page
{
    private DataSet _ds = new DataSet();
    private string _companyId, _userCode, comment, sqlstr;
    public int i, k;
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
                bindemployee_detail();
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
    protected void bindemployee_detail()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparm = new SqlParameter[1];
            Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, _userCode);
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
            Output.Show(
                "Record not saved. Please contact system admin. For error details please go through the log file.");
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
            if (lm == 0)
            {
                divfull.Visible = false;
                divhalf.Visible = true;
                txt_select.Text = ds.Tables[0].Rows[0]["hdate"].ToString();
            }
            else if (lm == 1)
            {
                divfull.Visible = true;
                divhalf.Visible = false;
                txt_sdate.Text = ds.Tables[0].Rows[0]["date"].ToString();
                txt_edate.Text = ds.Tables[0].Rows[0]["fromtime"].ToString();
            }
            txtftime.Text = ds.Tables[0].Rows[0]["intime"].ToString();
            txttotime.Text = ds.Tables[0].Rows[0]["outtime"].ToString();
            txt_reason.Text = ds.Tables[0].Rows[0]["reason"].ToString();
            lblcomm.Text = ds.Tables[0].Rows[0]["comment"].ToString();
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
    protected Boolean validate_applydate()
    {
        var activity = new DataActivity();
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[3];
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, _userCode);
            if (divfull.Visible == true)
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, txt_sdate.Text);
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, txt_edate.Text);

            }
            else
            {
                Output.AssignParameter(sqlparam, 1, "@startdate", "DateTime", 10, txt_select.Text);
                Output.AssignParameter(sqlparam, 2, "@enddate", "DateTime", 10, txt_select.Text);

            }
            SqlConnection connection = activity.OpenConnection();
            _ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_validate_applied_date", sqlparam);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                Output.Show("You have already applied leave during this span! Please check application status");
                return false;
            }
            else
            {
                if (_ds.Tables[1].Rows.Count > 0)
                {
                    Output.Show("You have already applied for Compoff during this span! Please check application status");
                    return false;
                }
                else
                {
                    if (_ds.Tables[2].Rows.Count > 0)
                    {
                        Output.Show("You have already applied for OD during this span! Please check application status");
                        return false;
                    }
                    else
                    {
                        //if (_ds.Tables[4].Rows.Count > 0)
                        //{
                        //    Output.Show("You have already applied for Substitute Holiday during this span! Please check application status");
                        //    return false;
                        //}
                        //else
                        //{
                        if (_ds.Tables[3].Rows.Count > 0)
                        {
                            return true;
                        }
                        else
                        {
                            Output.Show("Your leave profile is not created! Please contact your Manager");
                            return false;
                        }
                        //  }
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
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        SqlTransaction transaction = null;
        try
        {
            SqlConnection con = activity.OpenConnection();
            if (!validate_applydate())
                return;
            transaction = con.BeginTransaction();
            i = update_od(con, transaction);
            transaction.Commit();

            if (i <= 0)
            {
                Output.Show("Problem updating OD, try again");
            }
            else
            {
                Output.Show("OD updated successfully");
            }

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
        Response.Redirect("ViewOdStatus.aspx?leavestatus=0&updated=true");
    }

    private int update_od(SqlConnection con, SqlTransaction transaction)
    {
        SqlParameter[] sqlparm = new SqlParameter[13];
        Output.AssignParameter(sqlparm, 0, "@id", "Int", 50, ViewState["id"].ToString());
        Output.AssignParameter(sqlparm, 1, "@empcode", "String", 50, _userCode);
        Output.AssignParameter(sqlparm, 2, "@date", "DateTime", 50, txt_sdate.Text);
        Output.AssignParameter(sqlparm, 3, "@fromtime", "DateTime", 50, txt_edate.Text);
        Output.AssignParameter(sqlparm, 4, "@working_hour", "Decimal", 50, HiddenField1.Value);
        Output.AssignParameter(sqlparm, 5, "@reason", "String", 500, txt_reason.Text);
        Output.AssignParameter(sqlparm, 6, "@Approval_status", "Int", 50, "0");
        Output.AssignParameter(sqlparm, 7, "@Leave_status", "Int", 50, "0");
        Output.AssignParameter(sqlparm, 8, "@flag", "String", 50, "1");
        Output.AssignParameter(sqlparm, 9, "@status", "String", 50, "1");
        string comment = "";
        if (txt_comment.Text != "")
            comment = comment + "<h6><b>Comments added by " + Session["name"].ToString() + " on " + DateTime.Now + " :</b><br>" + txt_comment.Text + "</h6>";
        else
            comment = "";
        Output.AssignParameter(sqlparm, 10, "@comment", "String", 5000, comment);
        Output.AssignParameter(sqlparm, 11, "@modifieddate", "DateTime", 50, DateTime.Now.ToString());
        Output.AssignParameter(sqlparm, 12, "@modifiedby", "String", 50, Session["name"].ToString());
        int j = SQLServer.ExecuteNonQuery(con, CommandType.StoredProcedure, transaction, "sp_leave_updateod", sqlparm);
        return j;
    }
}
