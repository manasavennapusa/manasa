using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
public partial class attendance_updateattendancerule : System.Web.UI.Page
{
    string CompanyId, UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                bindshifts(Convert.ToInt32(CompanyId));
                bindattendencerule(Convert.ToInt32(CompanyId));
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of Update Attendance rule  =============================
    #region Bind the Shifts
    protected void bindshifts(int companyId)
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select shiftid,shiftname from tbl_leave_shift ";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
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

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }

    }
    #endregion
    #region Bind Attendencerule to fields
    protected void bindattendencerule(int company_Id)
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select ls.shiftname,ar.shiftid,ar.earlyin,ar.latein,ar.earlyout,ar.lateout from  tbl_leave_attendance_rule ar inner join tbl_leave_shift ls on ls.shiftid=ar.shiftid where slno=" + Request.QueryString["id"] + " and ar.company_id=" + company_Id;
            DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dd_shift.SelectedValue = ds.Tables[0].Rows[0]["shiftid"].ToString();
                txt_early_in_time.Text = ds.Tables[0].Rows[0]["earlyin"].ToString();
                txt_earlyout_time.Text = ds.Tables[0].Rows[0]["earlyout"].ToString();
                txt_latein_time.Text = ds.Tables[0].Rows[0]["latein"].ToString();
                txt_lateout_time.Text = ds.Tables[0].Rows[0]["lateout"].ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("No Data Found. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }



    }
    #endregion
    #region Update Attendence Rule to Database
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        insertattendencerule();
    }
    private void insertattendencerule()
    {
        SqlParameter[] parm = new SqlParameter[8];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        int Flag = 0;
        try
        {
            int id = Convert.ToInt32(Request.QueryString["id"].ToString());
            Output.AssignParameter(parm, 0, "@shiftid", "Int", 0, dd_shift.SelectedValue);
            Output.AssignParameter(parm, 1, "@slno", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 2, "@earlyin", "String", 0, txt_early_in_time.Text.ToString());
            Output.AssignParameter(parm, 3, "@latein", "String", 100, txt_latein_time.Text.ToString());
            Output.AssignParameter(parm, 4, "@earlyout", "String", 200, txt_earlyout_time.Text.ToString());
            Output.AssignParameter(parm, 5, "@lateout", "String", 0, txt_lateout_time.Text.ToString());
            Output.AssignParameter(parm, 6, "@update_date", "DateTime", 0, "");
            Output.AssignParameter(parm, 7, "@update_by", "String", 100, UserCode);



            Connection = Activity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_leave_update_attendencerule", parm);
            _Transaction.Commit();


        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        if (Flag > 0)
        {
            Response.Redirect("createattendancerule.aspx?updated=true");

        }
        else
        {
            Output.Show("AttendanceRule already exists, try again.");
        }

    }
    #endregion

}
