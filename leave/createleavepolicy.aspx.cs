using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Common.Console;
using Common.Data;

public partial class leave_createleavepolicy : System.Web.UI.Page
{
    string _companyId, _userCode;
    //================================= Created by Ramu Nunna on 1-Dec-14 purpose of Create Leave Policy  =============//
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

    #region Save Policy Details
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        string filExt = "";
        string fileName = System.IO.Path.GetFileName(fupload.PostedFile.FileName);
        var parm = new SqlParameter[8];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            if (Page.IsValid)
            {
                if (fupload.HasFile)
                {

                    string policyFileName = txt_policy.Text + DateTime.Now.GetHashCode();
                    filExt = System.IO.Path.GetExtension(fupload.PostedFile.FileName);
                    fupload.PostedFile.SaveAs(Server.MapPath("upload/policydockit/" + policyFileName + filExt));
                    ViewState.Add("policy_file_name", policyFileName); 
                    ViewState.Add("policy_file_type", filExt);
                }

                else
                {
                    ViewState.Add("policy_file_name", fileName);
                    ViewState.Add("policy_file_type", filExt);
                }
            }
            else
            {
                ViewState.Add("policy_file_name", fileName);
                ViewState.Add("policy_file_type", filExt);
            }

            Output.AssignParameter(parm, 0, "@policyname", "String", 100, txt_policy.Text);
            Output.AssignParameter(parm, 1, "@policydescription", "String", 2000, txt_policy_desc.Text);
            Output.AssignParameter(parm, 2, "@policy_file_name", "String", 200, ViewState["policy_file_name"].ToString());
            Output.AssignParameter(parm, 3, "@policy_file_type", "String", 100, ViewState["policy_file_type"].ToString());
            //Output.AssignParameter(parm, 4, "@date", "DateTime", 0, DateTime.Today.ToString(CultureInfo.InvariantCulture));
            Output.AssignParameter(parm, 4, "@date", "DateTime", 0, DateTime.Today.ToString("yyyy-MM-dd HH:mm:ss"));
            Output.AssignParameter(parm, 5, "@createdby", "String", 100, _userCode);
            Output.AssignParameter(parm, 6, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(parm, 7, "@companyid", "String", 100, _companyId);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_createleave_policy", parm);
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

            Output.Show("Leave policy created successfully");
            Reset();
        }
        else
        {
            Output.Show("Leave policy name already exists. please try other");
        }

    }
    #endregion

    #region Reset the Values

    private void Reset()
    {
        txt_policy.Text = "";
        txt_policy_desc.Text = "";
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Reset();
    }
    #endregion
}