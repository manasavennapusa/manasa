using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class attendance_editattendancerule : System.Web.UI.Page
{
    string _companyId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                BindAttendence(Convert.ToInt32(_companyId));
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }
        if (Request.QueryString["updated"] != null)
            Common.Console.Output.Show("Attendance Rule updated successfully.");
    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of View Attendance Rule =============================
    #region BindShifts

    #endregion
    #region Bind Attendence rule to Grid

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
    #endregion

    protected void rulegrid_PreRender(object sender, EventArgs e)
    {
        if (rulegrid.Rows.Count > 0)
            rulegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
