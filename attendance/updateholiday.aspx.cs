using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class attendance_updateholiday : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    public int i;
    string CompanyId, UserCode, RoleId = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null && Session["companyid"] != null && Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
            //ddbranch_id.Items.Insert(0, new ListItem("--For All Branchs--", "0"));
            if (!IsPostBack)
            {
                Year();
                bindholiday();
            }

        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }
    //====================  Created by Ramu nunna on 17-9-2014 Purpose of Update Holiday rule  =============================
    #region Bind Year
    public void Year()
    {
        ddlyear.Items.Clear();
        ddlyear.Items.Add(new ListItem("--Select--", "0"));

        for (int yr = 2014; yr <= DateTime.Now.Year + 1; yr++)
        {
            ddlyear.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }
    #endregion

    #region Bind Holiday
    public void bindholiday()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "SELECT tbl_leave_holiday.holidayid,tbl_leave_holiday.year,tbl_leave_holiday.branch_id,tbl_leave_holiday.name,tbl_leave_holiday.detail, (CASE WHEN tbl_leave_holiday.date='01/01/1990' THEN '' ELSE CONVERT(CHAR(10), tbl_leave_holiday.date, 101) END)date,tbl_leave_holiday.shiftid FROM tbl_leave_holiday left join tbl_leave_shift on tbl_leave_shift.shiftid=tbl_leave_holiday.shiftid WHERE tbl_leave_holiday.holidayid=" + Request.QueryString["holidayid"].ToString() + "";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddlyear.SelectedValue = ds.Tables[0].Rows[0]["year"].ToString();
            ddbranch_id.SelectedValue = ds.Tables[0].Rows[0]["branch_id"].ToString();
            txtholiday.Text = ds.Tables[0].Rows[0]["name"].ToString();
            txtdetail.Text = ds.Tables[0].Rows[0]["detail"].ToString();
            txtdate.Text = ds.Tables[0].Rows[0]["date"].ToString();

            bindshift(ds.Tables[0].Rows[0]["branch_id"].ToString());
            ddl_shift.SelectedValue= ds.Tables[0].Rows[0]["shiftid"].ToString();
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
    #region Update and Reset the Holiday master
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["holidayid"]);
        SqlParameter[] parm = new SqlParameter[8];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        int Flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@year", "String", 10, ddlyear.Text.ToString());
            Output.AssignParameter(parm, 1, "@holidayid", "Int", 0, id.ToString());
            Output.AssignParameter(parm, 2, "@branch_id", "Int", 0, ddbranch_id.SelectedValue.ToString());
            Output.AssignParameter(parm, 3, "@name", "String", 100, txtholiday.Text.ToString());
            Output.AssignParameter(parm, 4, "@detail", "String", 200, txtdetail.Text.ToString());
            if (txtdate.Text != "")
                Output.AssignParameter(parm, 5, "@date", "DateTime", 0, Common.Date.Utility.DateFormat(txtdate.Text.ToString()).ToString());
            else
                Output.AssignParameter(parm, 5, "@date", "DateTime", 0, "");
            Output.AssignParameter(parm, 6, "@modifiedby", "String", 100, UserCode);
            Output.AssignParameter(parm, 7, "@shiftid", "Int", 0, ddl_shift.SelectedValue);

            Connection = Activity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_leave_updateholiday", parm);
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
            Response.Redirect("createholiday.aspx?updated=true");
            Output.Show("Holiday Created Successfully");
            clearfield();
        }
        else
        {
            Output.Show("Holiday already exists, try again.");
        }

    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Response.Redirect("EditHoliday.aspx");
    }
    protected void clearfield()
    {
        ddlyear.SelectedIndex = 0;
        ddbranch_id.SelectedIndex = 0;
        txtholiday.Text = "";
        txtdetail.Text = "";
        txtdate.Text = "";
    }
    #endregion
    //protected void ddlbranch_DataBound(object sender, EventArgs e)
    //{
    //    ddbranch_id.Items.Insert(0, new ListItem("--For All Branchs--", "0"));

    //}
    protected void ddbranch_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindshift(ddbranch_id.SelectedValue);
    }

    protected void bindshift(string branch)
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string query = "select shiftid,shiftname as shiftname from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1 and tbl_leave_shift.branch_id=" + branch + "";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            ddl_shift.DataTextField = "shiftname";
            ddl_shift.DataValueField = "shiftid";
            ddl_shift.DataSource = ds;
            ddl_shift.DataBind();

            ddl_shift.Items.Insert(0, new ListItem("--Select-- ", "0"));
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
    protected void ddl_shift_DataBound(object sender, EventArgs e)
    {

    }
}
