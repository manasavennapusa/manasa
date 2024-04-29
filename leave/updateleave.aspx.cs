using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using Common.Console;
using Common.Data;

public partial class leave_updateleave : System.Web.UI.Page
{
    string _sqlstr;
    DataSet _ds = new DataSet();
    string _companyId, _userCode;
    //================================= Created by Ramu Nunna on 10-11-14 purpose of Update Leave Details =============//
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                BindData(Convert.ToInt32(_companyId));
            }

        }
        else { Response.Redirect("~/notlogged.aspx"); }

    }
    #endregion
    #region Bind Leave Data
    private void BindData(int companyId)
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            _sqlstr = "SELECT * FROM tbl_leave_createleave WHERE leaveid=" + Request.QueryString["leaveid"] + " and company_id=" + companyId;
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, _sqlstr);
            if (_ds.Tables[0].Rows.Count < 1)
                return;
            txt_leave_type.Text = _ds.Tables[0].Rows[0]["leavetype"].ToString();
            txt_description.Text = _ds.Tables[0].Rows[0]["description"].ToString();
            txt_display_name.Text = _ds.Tables[0].Rows[0]["displayleave"].ToString();

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
    #region Update Leave Details
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        var parm = new SqlParameter[5];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {

            Output.AssignParameter(parm, 0, "@leavetype", "String", 100, txt_leave_type.Text);
            Output.AssignParameter(parm, 1, "@description", "String", 500, txt_description.Text);
            Output.AssignParameter(parm, 2, "@displayleave", "String", 100, txt_display_name.Text);
            Output.AssignParameter(parm, 3, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(parm, 4, "@leaveid", "Int", 100, Request.QueryString["leaveid"]);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_updateleave", parm);
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

            Output.Show("New leave created successfully");
            Response.Redirect("editleave.aspx?updated=true");
        }
        else
        {
            Output.Show("Leave name already exists, please enter another name");


        }
    }
    #endregion
    #region  Cancel the Leave Updation
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("editleave.aspx");
    }
    #endregion
    protected void btnreset_Click(object sender, EventArgs e)
    {
        //txt_leave_type.Text = "";
        //txt_display_name.Text = "";
        //txt_description.Text = "";
        Response.Redirect("editleave.aspx");
    }
}