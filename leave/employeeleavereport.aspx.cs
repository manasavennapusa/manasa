using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leave_employeeleavereport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        this.Load += Page_Load;
    }

    void BindGrid()
    {
        DataTable dt = new DataTable();

        if (Cache["tbl_leave_leaveperiod"] == null)
        {
            dt = CreateLeavePeriodCache();
        }
        else
        {
            dt = (DataTable)Cache["tbl_leave_leaveperiod"];
        }

        ddlLeavePeriod.DataSource = dt;
        ddlLeavePeriod.DataTextField = "periodname";
        ddlLeavePeriod.DataValueField = "id";
        ddlLeavePeriod.DataBind();
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
                                     from tbl_leave_leaveperiod 
                                       order by fromdate, todate desc";

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = cmd;

            sda.Fill(dt);

            Cache.Insert(
                "tbl_leave_leaveperiod",
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
        // Not implemented
    }

    protected void btnSearch_Click(object sender, EventArgs e)
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

            cmd.CommandText = @"
select 
h.periodid,
lp.periodname,
convert(varchar(11),lp.fromdate,103) fromdate,
convert(varchar(11),lp.todate,103) todate,
lh.policyid,
p.policyname,
lh.leaveid,
cl.displayleave,
lh.empcode,
j.emp_fname,
rle.entitled_days,lh.caryfwrdeddays,
lh.Entitled_days

,lh.Used_days,(lh.Entitled_days-lh.Used_days)as Balance,(case when (lh.carryforward_applicable=1 and ((lh.Entitled_days-lh.Used_days)-lh.carryforward_maximum_days)>=0 )then
                cast((lh.carryforward_maximum_days) as decimal(5,2))   else case when (lh.carryforward_applicable=1 and ((lh.Entitled_days-lh.Used_days)-lh.carryforward_maximum_days)<0) then cast((lh.Entitled_days-lh.Used_days) as decimal(4,1)) else 0.0 end end) carryforward,lh.encashmentdays,lh.cur_encashed
  ,mster.Entitled_days as curEntitledays,mster.Used_days as curUseddays,(mster.Entitled_days-mster.Used_days)as curBalance,lh.elapsed
 
 from tbl_leave_history h
 inner join tbl_leave_emp_leave_history lh on h.id = lh.leavehistoryid
 inner join tbl_leave_leaveperiod lp on h.periodid = lp.id
 inner join tbl_leave_createleave cl on cl.leaveid = lh.leaveid
 left join tbl_leave_createleavepolicy p on p.policyid = lh.policyid
 inner join tbl_leave_createdefaultrule rle on cl.leaveid=rle.leaveid
 inner join tbl_leave_employee_leave_master mster on lh.empcode=mster.empcode and  mster.leaveid=cl.leaveid
 left join tbl_intranet_employee_jobDetails j on j.empcode = lh.empcode where h.periodid = @id  and lh.leaveid not in (0) order by lh.empcode";


            SqlParameter p = new SqlParameter();
            p.ParameterName = "@id";
            p.Value = ddlLeavePeriod.SelectedValue;
            p.DbType = DbType.Int32;
            cmd.Parameters.Add(p);

            SqlDataAdapter sda = new SqlDataAdapter();

            sda.SelectCommand = cmd;

            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                grid.DataSource = dt;
                grid.DataBind();
            }
            else
            {
                grid.DataSource = null;
                grid.DataBind();
            }
        }

    }

    protected void ddlLeavePeriod_DataBound(object sender, EventArgs e)
    {
        ddlLeavePeriod.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (grid.Rows.Count > 0)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Leave Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            grid.GridLines = GridLines.Both;
            grid.HeaderStyle.Font.Bold = true;
            grid.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }
    protected void grid_PreRender(object sender, EventArgs e)
    {
        if (grid.Rows.Count > 0)
            grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}