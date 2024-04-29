using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class attendance_createattendancerule : System.Web.UI.Page
{
    string _companyId;
    string _userCode;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                Bindshifts(Convert.ToInt32(_companyId));
                BindAttendence(Convert.ToInt32(_companyId));

                if (Request.QueryString["save"] != null)
                    Common.Console.Output.Show("Attendence rule Created Successfully.");
                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Attendance Rule updated successfully.");
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }
    //====================  Created by Ramu nunna on 16-9-2014 Purpose of Create Attendence rule =============================
    #region Bind the Shifts

    private void Bindshifts(int companyId)
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "select shiftid,shiftname+'  -  '+branch_name as shiftname from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            dd_shift.DataTextField = "shiftname";
            dd_shift.DataValueField = "shiftid";
            dd_shift.DataSource = ds;
            dd_shift.DataBind();

            dd_shift.Items.Insert(0, new ListItem("--Select-- ", "0"));
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
    #region Insert Attendence Rule to Database
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        Insertattendencerule();
    }
    private void Insertattendencerule()
    {
        var parm = new SqlParameter[8];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@shiftid", "Int", 0, dd_shift.SelectedValue);
            Output.AssignParameter(parm, 1, "@company_id", "Int", 0, _companyId);
            Output.AssignParameter(parm, 2, "@earlyin", "String", 0, txt_early_in_time.Text);
            Output.AssignParameter(parm, 3, "@latein", "String", 100, txt_latein_time.Text);
            Output.AssignParameter(parm, 4, "@earlyout", "String", 200, txt_earlyout_time.Text);
            Output.AssignParameter(parm, 5, "@lateout", "String", 0, txt_lateout_time.Text);
            Output.AssignParameter(parm, 6, "@create_date", "DateTime", 0, DateTime.Now.ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 7, "@create_by", "String", 100, _userCode);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_insert_attendencerule", parm);
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
        if (flag > 0)
        {

            //Output.Show("Attendence rule Created Successfully");
            Reset();
            Response.Redirect("createattendancerule.aspx?save=true");
        }
        else
        {
            Output.Show("Attendence rule already exists, try again.");
        }

    }
    #endregion
    #region Reset the Values
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }

    private void Reset()
    {
        dd_shift.SelectedValue = "0";
        txt_early_in_time.Text = "00:00:00";
        txt_earlyout_time.Text = "00:00:00";
        txt_latein_time.Text = "00:00:00";
        txt_lateout_time.Text = "00:00:00";
    }
    #endregion

    protected void rulegrid_PreRender(object sender, EventArgs e)
    {
        if (rulegrid.Rows.Count > 0)
            rulegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    private void BindAttendence(int companyId)
    {
        var activity = new Common.Data.DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "select shiftname+'  -  '+branch_name as shiftname,ar.slno,ar.earlyin,ar.latein,ar.earlyout,ar.lateout from  dbo.tbl_leave_attendance_rule ar inner join tbl_leave_shift ls on ls.shiftid=ar.shiftid inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=ls.branch_id where ls.status=1 and  ar.company_id=" + companyId;
            DataSet ds = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            rulegrid.DataSource = ds;
            rulegrid.DataBind();

        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
}
