using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using Common.Console;
using Common.Data;
using System.Web.UI.WebControls;
using System.Configuration;


public partial class leave_processleavemonthly : System.Web.UI.Page
{
    string _companyId,sqlstr, _userCode;
    DataActivity activity = new DataActivity();
 
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            if (!IsPostBack)
            {
                ddl_type.Items.Insert(0, new ListItem("--Select Leave--", "0"));
                bind_year();
                bind_policy();
                //bindcompoffentitled();
                GenerateNextMonth();
            }
           
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    }


    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
                conn.Open();

                string sqlstr1 = "  select * from tbl_leave_processleavemonthly where calanderid='" + Convert.ToInt32(ddl_Cal.SelectedValue) + "' and leavemonthid='" + Convert.ToInt32(ddl_months.SelectedValue) + "' and policyid='" + Convert.ToInt32(ddl_policy.SelectedValue) + "' and leaveid='" + Convert.ToInt32(ddl_type.SelectedValue) + "'";
                DataSet ds3 = new DataSet();
                ds3 = SQLServer.ExecuteDataset(conn, CommandType.Text, sqlstr1);
                if (ds3.Tables[0].Rows.Count > 0)
                {
                    SmartHr.Common.Alert("Monthly Process already done in this Period Id, please select another period id.");
                    return;
                }


                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "sp_leave_processleavemonthly";

                    SqlParameter p = new SqlParameter();
                    p.ParameterName = "@calanderid";
                    p.Value = ddl_Cal.SelectedValue; ;
                    p.DbType = DbType.Int32;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter();
                    p.ParameterName = "@policyid";
                    p.Value = ddl_policy.SelectedValue;
                    p.DbType = DbType.Int32;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter();
                    p.ParameterName = "@leaveid";
                    p.Value = ddl_type.SelectedValue;
                    p.DbType = DbType.Int32;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter();
                    p.ParameterName = "@leavemonthid";
                    p.Value = ddl_months.SelectedValue;
                    p.DbType = DbType.Int32;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter();
                    p.ParameterName = "@leavemonth";
                    p.Value = ddl_months.SelectedItem.Text;
                    p.DbType = DbType.String;
                    p.Size = 3;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter();
                    p.ParameterName = "@processby";
                    p.Value = _userCode.ToString();
                    p.DbType = DbType.String;
                    p.Size = 50;
                    cmd.Parameters.Add(p);

                    p = new SqlParameter();
                    p.ParameterName = "@curmonthentitle";

                    //if (ddl_type.SelectedValue == "1")
                    //    p.Value = 1.0;
                    //else if (ddl_type.SelectedValue == "2")
                    //    p.Value = 0.5;
                    //else
                    //{
                    //    p.Value = 0.0;
                    //    return;
                    //}
                    if (txt_days.Text.ToString() != "")
                    {
                        p.Value = txt_days.Text;
                    }
                    else {
                        p.Value = 0.0;
                        return;
                    }
                        p.DbType = DbType.Decimal;
                    p.Precision = 5;
                    p.Scale = 2;
                    cmd.Parameters.Add(p);

                    cmd.ExecuteNonQuery();

                    ddl_Cal.SelectedValue = "0";
                    ddl_policy.SelectedValue = "0";
                    ddl_type.SelectedValue = "0";
                    ddl_months.SelectedValue = "0";

                    System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Leave processed successfully.')", true);
                }
            }
        }
    }

    #region Bind policy
    protected void bind_policy()
    {
        try
        {
            DataSet ds = new DataSet();
            connection = activity.OpenConnection();
            sqlstr = "select distinct policy.policyid,policy.policyname from tbl_leave_createleavepolicy policy inner join tbl_leave_createdefaultrule rul on rul.policyid=policy.policyid where policy.status=1 and rul.Monthly_proce=1";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_policy.DataSource = ds;
                ddl_policy.DataTextField = "policyname";
                ddl_policy.DataValueField = "policyid";
                ddl_policy.DataBind();
            }
            ddl_policy.Items.Insert(0, new ListItem("--Select--", "0"));
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

    protected void bind_year()
    {
        ddl_Cal.Items.Insert(0, new ListItem("Select Year", "0"));

        int fromYear = Convert.ToInt32(ConfigurationManager.AppSettings["FromYear"]);
        int toYear = Convert.ToInt32(ConfigurationManager.AppSettings["ToYear"]);

        for (int i = fromYear; i <= toYear; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            ddl_Cal.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        ddl_Cal.SelectedValue = a.Year.ToString();
    }
    protected void bindcompoffentitled(int policyid)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();

            string query = "select leave.leaveid,leave.leavetype from tbl_leave_createleave leave inner join tbl_leave_createdefaultrule rul on rul.leaveid=leave.leaveid where leave.status=1 and rul.Monthly_proce=1 and rul.policyid=" + policyid + "";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            ddl_type.DataSource = ds;
            ddl_type.DataTextField = "leavetype";
            ddl_type.DataValueField = "leaveid";
            ddl_type.DataBind();
            ddl_type.Items.Insert(0, new ListItem("--Select Leave--", "0"));
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
    protected void bind_Creaditdays()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();

            string query = "select Monthly_Days from tbl_leave_createdefaultrule where policyid=" + ddl_policy.SelectedValue + " and leaveid=" + ddl_type.SelectedValue + " and status=1 and flag=1";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count < 1)
            {
                txt_days.Text = "";
                return;
            }
            if (ds.Tables[0].Rows[0]["Monthly_Days"].ToString() != "")
            {
                txt_days.Text = ds.Tables[0].Rows[0]["Monthly_Days"].ToString();
            }
            //ddl_type.Items.Insert(0, new ListItem("--Select Leave--", "0"));
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
    void GenerateNextMonth()
    {
        string sql = @"
if exists (select 1 
            from tbl_leave_processleavemonthly 
             where calanderid = @calanderid and policyid = @policyid and leaveid = @leaveid)
begin

  select top 1 case when leavemonthid < 12 then leavemonthid + 1 else 0 end nextmonth
   from tbl_leave_processleavemonthly
    where calanderid = @calanderid and policyid = @policyid and leaveid = @leaveid
     order by leavemonthid desc

end
else 
begin

  select 1 as nextmonth

end";

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                SqlParameter p = new SqlParameter();
                p.ParameterName = "@calanderid";
                p.Value = ddl_Cal.SelectedValue;
                p.DbType = DbType.Int32;
                p.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(p);

                p = new SqlParameter();
                p.ParameterName = "@policyid";
                p.Value = ddl_policy.SelectedValue;
                p.DbType = DbType.Int32;
                p.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(p);

                p = new SqlParameter();
                p.ParameterName = "@leaveid";
                p.Value = ddl_type.SelectedValue;
                p.DbType = DbType.Int32;
                p.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(p);

                int monthid = (int)cmd.ExecuteScalar();

                ddl_months.SelectedValue = monthid.ToString();

            }
        }
    }

    protected void ddl_Cal_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenerateNextMonth();
    }
    protected void ddl_policy_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenerateNextMonth();
        bindcompoffentitled(Convert.ToInt32(ddl_policy.SelectedValue));
        bind_Creaditdays();

    }
    protected void ddl_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        GenerateNextMonth();

        bind_Creaditdays();
    }
    //void InsertAtPositionZero(System.Web.UI.WebControls.DropDownList ddl)
    //{
    //    ddl.Items.Insert(0, new ListItem("--Select--", "0"));
    //}
}