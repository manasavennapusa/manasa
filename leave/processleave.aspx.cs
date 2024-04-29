using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class leave_processleave : System.Web.UI.Page
{
    DataTable dt = null;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string _companyId, _userCode;
    protected override void OnInit(EventArgs e)
    {
        this.Load += Page_Load;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();

            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {  BindLeavePeriod();
               bind_latestperiodid();
               BindPolicy();
            }
        }
        else { Response.Redirect("~/notlogged.aspx"); }
    
          
    }

    void BindLeavePeriod()
    {
        //if (Cache["tbl_leave_leaveperiod"] == null)
        //{
        //    dt = GetLeavePeriod();
        //}
        //else
        //{
        //    dt = (DataTable)Cache["tbl_leave_leaveperiod"];
        //}
        connection = activity.OpenConnection();
        string sqlstr = "select id, periodname, convert(varchar(11), fromdate, 103) fromdate, convert(varchar(11), todate, 103 ) todate, status  from tbl_leave_leaveperiod  where status=0";
        DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

        //if (dt.Rows.Count < 1)
        //    return;
        //DataTable dt1 = dt.Select("status = 1").CopyToDataTable();
        //ddlLeavePeriod.DataSource = dt1;
        ddlLeavePeriod.DataSource = ds;
        ddlLeavePeriod.DataTextField = "periodname";
        ddlLeavePeriod.DataValueField = "id";
        ddlLeavePeriod.DataBind();
    }

    DataTable GetLeavePeriod()
    {
        DataTable dt = new DataTable();

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        if (conn.State == ConnectionState.Open)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select id, periodname, convert(varchar(11), fromdate, 103) fromdate, convert(varchar(11), todate, 103 ) todate, status 
                                     from tbl_leave_leaveperiod 
                                       where status=0 order by fromdate, todate desc ";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);

            Cache.Insert(
                "tbl_leave_leaveperiod",
                dt,
                new System.Web.Caching.CacheDependency(Server.MapPath("cachexml/tbl_leave_leaveperiod.txt")),
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.High,
                new System.Web.Caching.CacheItemRemovedCallback(ReportRemovedCallback));

        }

        return dt;
    }

    DataTable GetEmployeeLeaveDetails()
    {
        DataTable dt = new DataTable();

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        if (conn.State == ConnectionState.Open)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = @"select id, periodname, convert(varchar(11), fromdate, 103) fromdate, convert(varchar(11), todate, 103 ) todate, status 
                                     from tbl_leave_leaveperiod 
                                       order by fromdate, todate desc ";
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            sda.Fill(dt);

            Cache.Insert(
                "tbl_leave_leaveperiod",
                dt,
                new System.Web.Caching.CacheDependency(Server.MapPath("cachexml/tbl_leave_leaveperiod.txt")),
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.High,
                new System.Web.Caching.CacheItemRemovedCallback(ReportRemovedCallback));

        }

        return dt;
    }

    public static void ReportRemovedCallback(string key, object value, System.Web.Caching.CacheItemRemovedReason removedReason)
    {

    }

    protected void btnProcess_Click(object sender, EventArgs e)
    {
        int flag = 0;
        try
        {

            SqlConnection connection = activity.OpenConnection();
            DataSet ds10 = new DataSet();
            SqlParameter[] sqlParam4 = new SqlParameter[1];
            sqlParam4[0] = new SqlParameter("@periodid", SqlDbType.Int);
            sqlParam4[0].Value = ddlLeavePeriod.SelectedValue;

            ds10 = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_final_process_checking", sqlParam4);
            if (ds10.Tables.Count.ToString() == "0" || ds10.Tables.Count.ToString() == null)
            {
            }
            else if (ds10.Tables[0].Rows[0][0].ToString() == "0")
            {

                Output.Show(ds10.Tables[0].Rows[0][1].ToString());

                return;
            }
    
            Cache.Remove("tbl_leave_leaveperiod");
        if (ddlLeavePeriod.SelectedValue.Trim() == "")
            return;
        

      //   Taking Backup
        SqlParameter[] sqlParam = new SqlParameter[2];
        sqlParam[0] = new SqlParameter("@periodid", SqlDbType.Int);
        sqlParam[0].Value = ddlLeavePeriod.SelectedValue;
        sqlParam[1] = new SqlParameter("@usercode", SqlDbType.VarChar, 50);
        sqlParam[1].Value = Session["empcode"].ToString();
        transaction = connection.BeginTransaction();
        flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_final_process", sqlParam);
        transaction.Commit();

      //  int i = Convert.ToInt32(SQLServer.ExecuteScalar(connection, CommandType.StoredProcedure, transaction, "sp_leave_final_process", sqlParam));
      //  int i = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_final_process", sqlParam);
      //int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_final_process]", sqlParam);
        

        if (flag <= 0)
        {
            SmartHr.Common.Alert("Process  already exists in this Period Id, please select another period id.");
            // message.InnerHtml = "Department name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Process Completed Successfully!!!");
            // message.InnerHtml = "Department created successfully";
           //bind_latestperiodid();
        }
        }
         catch (Exception ex)
        {
            transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Problem Processing Leave. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
         
        } 
    }

    protected void bind_latestperiodid()
    {
        try
        {
            SqlConnection connection = new SqlConnection();
            connection = activity.OpenConnection();
            string sqlstr = "select id,periodname  from tbl_leave_leaveperiod where status=1";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddlperiodid.DataTextField = "periodname";
            ddlperiodid.DataValueField = "id";
            ddlperiodid.DataSource = ds3;
            ddlperiodid.DataBind();
            ddlperiodid.Items.Insert(0, new ListItem("--Select--", "0"));
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
    protected void BindPolicy()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = new SqlConnection();
            connection = activity.OpenConnection();
            string sqlstr = "select  policyid,policyname from  tbl_leave_createleavepolicy where status=1 order by policyid";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddlpolicy.DataTextField = "policyname";
            ddlpolicy.DataValueField = "policyid";
            ddlpolicy.DataSource = ds3;
            ddlpolicy.DataBind();
            ddlpolicy.Items.Insert(0, new ListItem("--Select--", "0"));
          

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
    protected void btnapply_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlLeavePeriod.SelectedValue.Trim() == "")
                return;

            connection = activity.OpenConnection();
            string sqlstr3 = "SELECT  periodid from  tbl_leave_emp_leave_history where status = 0 and  periodid='" + ddlLeavePeriod.SelectedValue + "'";
          

            DataSet ds3 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr3);
            if (ds3.Tables[0].Rows.Count >0)
            {
                SmartHr.Common.Alert("Update Process already done in this Period Id, please select another period id.");
                return;
            }

            string sqlstr4 = "SELECT  his.periodid from  tbl_leave_emp_leave_history his inner join tbl_leave_leaveperiod per on his.status = 1 and  per.status=1 where  his.periodid='" + ddlperiodid.SelectedValue + "' or per.id='" + ddlLeavePeriod.SelectedValue + "'";


            DataSet ds4 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr4);
            if (ds4.Tables[0].Rows.Count > 0)
            {
                SmartHr.Common.Alert(" please create New Financial Period Id or select previous Financial perid and Inactive previouse Financial year");
                return;
            }
              

            string sqlstr = "SELECT * from  tbl_intranet_employee_jobDetails where Status = 1";

            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 1)
                return;

            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                try
                {
                    if (ds1.Tables[0].Rows[i]["empcode"].ToString().Trim() != "")
                    {

                        string sqlstr1 = @" insert into tbl_leave_employee_leave_master (PolicyId,leaveid,empcode,Entitled_days,Used_days,status,flag,modifiedby,modifieddate,createdby,createddate)  
                        select def.policyid,def.leaveid,'" + ds1.Tables[0].Rows[i]["empcode"].ToString() + "',def.entitled_days,0.00,1,1,+'" + Session["empcode"].ToString() + "','" + DateTime.Now + "','" + Session["empcode"].ToString() + "','" + DateTime.Now + "' from tbl_leave_createdefaultrule def";

                        int Flag1 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);


                    }
                }
                catch (Exception ex)
                {
                    Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

                }
            }
   

            string sqlstr10 = @"update tbl_leave_emp_leave_history set CaryfwrdedStatus = 0,
elapsed = (case when mastr.Entitled_days + hist.carryforward_maximum_days > 60 then (mastr.Entitled_days + hist.carryforward_maximum_days) - 60 
else 0.0 end) 
from tbl_leave_emp_leave_history hist 
inner join tbl_leave_employee_leave_master mastr on mastr.leaveid=hist.leaveid and mastr.PolicyId=hist.policyid and hist.empcode=mastr.empcode 
inner join tbl_leave_leaveperiod per on per.id!=hist.periodid where hist.periodid='" + ddlLeavePeriod.SelectedValue + "' and hist.empcode=mastr.empcode and hist.leaveid = 13 ";

            string sqlstr11 = @"update tbl_leave_emp_leave_history set encashmentdays = carryforward_maximum_days - caryfwrdeddays where leaveid = 13 and approvalstaus = 0";

            string sqlstr12 = @"update tbl_leave_emp_leave_history set status = 0 where periodid = '" + ddlLeavePeriod.SelectedValue + "'";

            string sqlstr2 = @" update tbl_leave_employee_leave_master 
set Entitled_days=(case when mastr.Entitled_days + hist.caryfwrdeddays > 60 then 60.0 
else case when mastr.Entitled_days + hist.caryfwrdeddays < 30 then (mastr.Entitled_days + hist.caryfwrdeddays)
else mastr.Entitled_days + hist.caryfwrdeddays end end) 
from tbl_leave_emp_leave_history hist 
inner join tbl_leave_employee_leave_master mastr on mastr.leaveid=hist.leaveid and mastr.PolicyId=hist.policyid and hist.empcode=mastr.empcode 
inner join tbl_leave_leaveperiod per on per.id!=hist.periodid where hist.periodid='" + ddlLeavePeriod.SelectedValue + "' and hist.empcode=mastr.empcode and per.id='" + ddlperiodid.SelectedValue + "' and per.status=1 and hist.leaveid = 13 ";


            int Flag10 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr10);

            int Flag11 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr11);

            int Flag12 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr12);
            int Flag2 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
            /*    //   Taking Backup
                SqlParameter[] sqlParam = new SqlParameter[5];
                sqlParam[0] = new SqlParameter("@periodid", SqlDbType.Int);
                sqlParam[0].Value = ddlLeavePeriod.SelectedValue;
                sqlParam[1] = new SqlParameter("@newperiodid", SqlDbType.Int);
                sqlParam[1].Value = ddlLeavePeriod.SelectedValue;
                sqlParam[2] = new SqlParameter("@policiid", SqlDbType.Int);
                sqlParam[2].Value = ddlperiodid.SelectedValue;
                sqlParam[3] = new SqlParameter("@companyid", SqlDbType.Int);
                sqlParam[3].Value = Convert.ToInt32(Session["empcode"].ToString());
                sqlParam[4] = new SqlParameter("@usercode", SqlDbType.VarChar, 50);
                sqlParam[4].Value = Session["empcode"].ToString();

        
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_leave_carryforward_insertion]", sqlParam);
            */
            string sqlstr5 = @" update tbl_leave_emp_leave_history set status=0 where periodid='" + ddlLeavePeriod.SelectedValue + "'";

            int Flag5 = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr5);

            if (Flag2 <= 0)
            {
                SmartHr.Common.Alert("Process  already exists in this Period Id, please select another period id.");
                // message.InnerHtml = "Department name already exists, please enter another name";
            }
            else
            {
                SmartHr.Common.Alert("Updation is Completed Successfully!!!");
                // message.InnerHtml = "Department created successfully";
                //bind_latestperiodid();
            }
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


}