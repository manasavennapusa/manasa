using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;
using DataAccessLayer;

public partial class leave_myleavedetails : System.Web.UI.Page
{
    string strsql = "";
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
          
            if (Request.QueryString["empcode"] == null)
            {
               Common.Console.Output.Show( "No Data Found");
                return;
            }
            try
            {
                fetchemp();
                fetchleavedetail();
            }
            catch (Exception ex)
            {
               // message.InnerHtml = "Problem fetching data";
            }
        }
    }

    protected void fetchemp()
    {
        SqlParameter sqlparm = new SqlParameter("@empcode", Request.QueryString["empcode"].ToString());
        strsql = "select empcode,coalesce(emp_fname,'') + ' ' + coalesce(emp_m_name,'') + ' ' + coalesce(emp_l_name,'') as ename from tbl_intranet_employee_jobDetails where empcode=@empcode";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, sqlparm);
        if (ds.Tables[0].Rows.Count > 0)
        {
            headername.Text = "Leave Details of " + ds.Tables[0].Rows[0]["empcode"].ToString() + "(" + ds.Tables[0].Rows[0]["ename"].ToString() + ")";
        }
        else
           Common.Console.Output.Show( "No data found");

    }
    protected void fetchleavedetail()
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparm[0].Value = Request.QueryString["empcode"].ToString();

        sqlparm[1] = new SqlParameter("@status", SqlDbType.Int, 4);
        sqlparm[1].Value = Request.QueryString["status"].ToString();

        //sqlparm[2] = new SqlParameter("@fromdate", SqlDbType.DateTime, 8);
        //sqlparm[2].Value = Request.QueryString["sdate"].ToString();

        //sqlparm[3] = new SqlParameter("@todate", SqlDbType.DateTime, 8);
        //sqlparm[3].Value = Request.QueryString["edate"].ToString();

        sqlparm[2] = new SqlParameter("@id", SqlDbType.Int, 4);
        sqlparm[2].Value = Request.QueryString["id"].ToString();


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_leave_showempleave", sqlparm);
        grid_leave.DataSource = ds;
        grid_leave.DataBind();
    }
    protected void grid_leave_PreRender(object sender, EventArgs e)
    {
        if (grid_leave.Rows.Count > 0)
            grid_leave.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}