using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Globalization;

public partial class attendance_updateweekoff : System.Web.UI.Page
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
                BindWeekDays();
                BindWeekoffData();

            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }

    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of Update Weekoff =============================
    #region Bind Weekoff data to fields
    private void BindWeekoffData()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select weekoffid,weekcode,weekname from tbl_leave_weekoff where weekoffid=" + Request.QueryString["weekoffid"].ToString() + "";
            DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlWeekName.SelectedValue = ds.Tables[0].Rows[0]["weekname"].ToString();
                txtWeekCode.Text = ds.Tables[0].Rows[0]["weekcode"].ToString();
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
    #region Bind Week days to Dropdown list
    private void BindWeekDays()
    {
        ListItem lc;
        foreach (var item in DateTimeFormatInfo.CurrentInfo.DayNames)
        {
            lc = new ListItem();
            lc.Text = item;
            lc.Value = item;
            ddlWeekName.Items.Add(lc);
        }
        ddlWeekName.Items.Insert(0, new ListItem("Select", "0"));
    }
    protected void ddlWeekName_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtWeekCode.Text = ddlWeekName.SelectedIndex.ToString();
    }
    #endregion
    #region Update Weekoff details to Databaase
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["weekoffid"].ToString());
        SqlParameter[] parm = new SqlParameter[3];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@weekname", "String", 20, ddlWeekName.Text.ToString());
            Output.AssignParameter(parm, 1, "@weekoffid", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 2, "@weekcode", "Int", 0, txtWeekCode.Text.ToString());
            Connection = Activity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_leave_update_weekoff", parm);
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
            Response.Redirect("EditWeekoff.aspx?updated=true");
            reset();
        }
        else
        {
            Output.Show("Weekoff already exists, try again.");
        }

    }
    #endregion
    #region Reset the values
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    private void reset()
    {
        ddlWeekName.SelectedIndex = 0;
        txtWeekCode.Text = "";
    }
    #endregion

}
