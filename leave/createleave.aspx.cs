using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Common.Console;
using Common.Data;

public partial class leave_createleave : System.Web.UI.Page
{
    //================================= Created by Ramu Nunna on 10-11-14 purpose of Create Leave Details =============//
    string _companyId, _userCode;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }
    #endregion
    #region Save Leave Details
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        var parm = new SqlParameter[7];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {

            Output.AssignParameter(parm, 0, "@leavetype", "String", 50, txt_leave_type.Text);
            Output.AssignParameter(parm, 1, "@description", "String", 500, txt_description.Text);
            Output.AssignParameter(parm, 2, "@displayleave", "String", 50, txt_display_name.Text);
            //Output.AssignParameter(parm, 3, "@createddate", "DateTime", 0, DateTime.Now.ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 3, "@createddate", "DateTime", 0, DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss"));
            Output.AssignParameter(parm, 4, "@createdby", "String", 100, _userCode);
            Output.AssignParameter(parm, 5, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(parm, 6, "@companyid", "String", 100, _companyId);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_createleave", parm);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (flag > 0)
        {

            Output.Show("New leave created successfully");
            Clearfield();
        }
        else
        {
            Output.Show("Leave name already exists, please enter another name");
        }


    }
    #endregion
    #region Clear the Fields
    private void Clearfield()
    {
        txt_display_name.Text = "";
        txt_description.Text = "";
        txt_leave_type.Text = "";
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Clearfield();
    }
    #endregion
}