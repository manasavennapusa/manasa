using Common.Console;
using Common.Data;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leave_leaveperiod1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            if (!IsPostBack)
                BindGrid();
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate("v");
        if (Page.IsValid)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            if (conn.State == ConnectionState.Open)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                if (hdnId.Value.Trim() == "0")
                {
                    cmd.CommandText = @"insert into tbl_leave_leaveperiod (periodname,fromdate,todate,status,createdby,createddate) 
 values (@periodname,@fromdate,@todate,1,@createdby,GETDATE()); select cast(scope_identity() as int)
declare @scp int =0;
select @scp = scope_identity();
declare @i int
set @i=1
while (@i<=12)
begin
DECLARE @date datetime = cast('2019-' + cast(@i as varchar(2)) + '-04' as datetime)
DECLARE @daten varchar(3)
SELECT @daten=DATENAME(MONTH, @date) 
insert into tbl_leave_freez_month  (calenderid,month_id,Month_name,status,flag,freeze,createdby,createddate ) values(@scp,@i,@daten,1,1,1,@createdby,GETDATE())
Set @i=@i+1
end";
                }
                else
                {
                    cmd.CommandText = @"update tbl_leave_leaveperiod 
                                          set periodname = @periodname, fromdate = @fromdate, todate = @todate, updatedby = @createdby, updateddate = getdate()
                                           where id = @id;

                                        select @id";
                }

                SqlParameter p = new SqlParameter();
                p.ParameterName = "@periodname";
                p.Value = txtPeriodName.Text;
                p.DbType = DbType.AnsiString;
                p.Size = 100;
                cmd.Parameters.Add(p);

                p = new SqlParameter();
                p.ParameterName = "@fromdate";
                p.Value = txtFromDate.Text;
                p.DbType = DbType.DateTime;
                cmd.Parameters.Add(p);

                p = new SqlParameter();
                p.ParameterName = "@todate";
                p.Value = txtToDate.Text;
                p.DbType = DbType.DateTime;
                cmd.Parameters.Add(p);

                p = new SqlParameter();
                p.ParameterName = "@createdby";
                p.Value = Session["empcode"].ToString();
                p.DbType = DbType.AnsiString;
                p.Size = 50;
                cmd.Parameters.Add(p);

                p = new SqlParameter();
                p.ParameterName = "@id";
                p.Value = hdnId.Value;
                p.DbType = DbType.Int32;
                cmd.Parameters.Add(p);

                int flag = (int)cmd.ExecuteScalar();

                if (flag > 0)
                {
                    //System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath("cachexml/tbl_leave_leaveperiod.txt"));
                    //file.WriteLine(flag);
                    //file.Close();
                    //file.Dispose();
                    BindGrid();
                    Clear();
                    //System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Record added or updated successfully.')", true);
                    Output.Show("Record added or updated successfully.");
                }
                else
                {
                  //  System.Web.UI.ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Record adding failed. Please try after some time or contact admin.')", true);

                    Output.Show("Record adding failed. Please try after some time or contact admin.");
                }
            }
        }
    }

    void Clear()
    {
        hdnId.Value = "0";
        txtPeriodName.Text = "";
        txtFromDate.Text = "";
        txtToDate.Text = "";
    }

    void BindGrid()
    {
        DataActivity activity = new DataActivity();
        SqlConnection _Connection = new SqlConnection();
        _Connection = activity.OpenConnection();
        DataTable dt = new DataTable();

      DataSet ds=new DataSet();
     string str=@"select id, periodname, convert(varchar(11), fromdate, 103) fromdate, convert(varchar(11), todate, 103 ) todate, status 
                                     from tbl_leave_leaveperiod where status=1 
                                       order by fromdate, todate desc";
     ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, str);

      grid.DataSource = ds;
        grid.DataBind();
        activity.CloseConnection();
    }

    DataTable CreateLeavePeriodCache()
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
                                     from tbl_leave_leaveperiod where status=1 
                                       order by fromdate, todate desc";

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = cmd;

            sda.Fill(dt);

            Cache.Insert("tbl_leave_leaveperiod",
                dt,
                new System.Web.Caching.CacheDependency(Server.MapPath("cachexml/tbl_leave_leaveperiod.txt")),
                System.Web.Caching.Cache.NoAbsoluteExpiration,
                System.Web.Caching.Cache.NoSlidingExpiration,
                System.Web.Caching.CacheItemPriority.Normal,
                new System.Web.Caching.CacheItemRemovedCallback(ReportRemovedCallback));
        }

        return dt;
    }

    public static void ReportRemovedCallback(string key, object value, System.Web.Caching.CacheItemRemovedReason removedReason)
    {
        // Not implemented.
    }

    protected void grid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        int id = (int)grid.DataKeys[e.NewEditIndex].Value;

        if (Cache["tbl_leave_leaveperiod"] == null)
        {
            CreateLeavePeriodCache();
        }

        DataTable dt = (DataTable)Cache["tbl_leave_leaveperiod"];

        DataRow[] rows = dt.Select("id = " + id);

        hdnId.Value = rows[0]["id"].ToString();
        txtPeriodName.Text = rows[0]["periodname"].ToString();
        txtFromDate.Text = Convert.ToDateTime(rows[0]["fromdate"].ToString()).ToString("dd MMM yyyy");
        txtToDate.Text = Convert.ToDateTime(rows[0]["todate"].ToString()).ToString("dd MMM yyyy");
        btnSave.Text = "Update";

    }

    protected void grid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            LinkButton lnkStatus = (LinkButton)e.Row.Cells[6].FindControl("lnkStatus");

            if (lnkStatus.Text.ToLower().Trim() == "true")
            {
                lnkStatus.Text = "Active";
                lnkStatus.Attributes.Add("onclick", "return confirm('Are you sure, you want to make inactive?')");
                lnkStatus.Style.Add("color", "green");
            }
            else
            {
                lnkStatus.Text = "InActive";
                lnkStatus.Attributes.Add("onclick", "return confirm('Are you sure, you want to make active?')");
                lnkStatus.Style.Add("color", "red");
            }

            
        }
    }

    protected void grid_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
    {
        int id = (int)grid.DataKeys[e.RowIndex].Value;
        LinkButton lnkStatus = (LinkButton)grid.Rows[e.RowIndex].Cells[6].FindControl("lnkStatus");

        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        conn.Open();

        SqlTransaction tran = conn.BeginTransaction();

        if (conn.State == ConnectionState.Open)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;

            if (lnkStatus.Text.ToLower() == "inactive")
                cmd.CommandText = @"update tbl_leave_leaveperiod set status = 0 where id = @id;
                                update tbl_leave_leaveperiod set status = 1 where id = @id;";
            else
                cmd.CommandText = @"update tbl_leave_leaveperiod set status = 0 where id = @id;
                                update tbl_leave_leaveperiod set status = 0 where id = @id;";

            cmd.Transaction = tran;

            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.Value = id;
            p.DbType = DbType.Int32;
            cmd.Parameters.Add(p);

            try
            {
                cmd.ExecuteNonQuery();
                //System.IO.StreamWriter file = new System.IO.StreamWriter(Server.MapPath("cachexml/tbl_leave_leaveperiod.txt"));
                //file.WriteLine(id);
                //file.Close();
                //file.Dispose();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw ex;
            }

            tran.Commit();
            BindGrid();
        }
    }


}