using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Globalization;

public partial class attendance_createweekoff : System.Web.UI.Page
{
    string _companyId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                BindWeekDays();
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of Create Weekoff =============================
    #region Bind Week days Function
    private void BindWeekDays()
    {
        if (DateTimeFormatInfo.CurrentInfo != null)
            foreach (var item in DateTimeFormatInfo.CurrentInfo.DayNames)
            {
                var lc = new ListItem { Text = item, Value = item };
                ddlWeekName.Items.Add(lc);
            }
        ddlWeekName.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void ddlWeekName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtWeekCode.Text = ddlWeekName.SelectedIndex.ToString(CultureInfo.InvariantCulture);
    }
    #endregion
    #region Insert weekoff Details
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        var parm = new SqlParameter[3];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@weekname", "String", 20, ddlWeekName.Text);
            Output.AssignParameter(parm, 1, "@company_id", "Int", 0, _companyId);
            Output.AssignParameter(parm, 2, "@weekcode", "Int", 0, txtWeekCode.Text);

            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_create_weekoff", parm);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log(string.Format("During validation: {0}.    {1}", ex.Message, DateTime.Now));
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (flag > 0)
        {

            Output.Show("Week off Created Successfully");
            Reset();
        }
        else
        {
            Output.Show("Week off already exists, try again.");
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
        ddlWeekName.SelectedIndex = 0;
        txtWeekCode.Text = "";
    }
    #endregion

}