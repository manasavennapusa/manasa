using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class leave_CmpoffApprovalStatus : System.Web.UI.Page
{
    string _companyId, _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
      
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            if (Request.QueryString["message"] != null)
            {
                SmartHr.Common.Alert(Request.QueryString["message"].ToString());
            }

        } 
        bindgrid();

    }
    protected void bindgrid()
    {
        DataSet ds = null;
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();

        string query = @"select
		applyl.id id, 
		empmaster.empcode,
		coalesce(empmaster.emp_fname,'') + ' ' + coalesce(empmaster.emp_m_name,'') + ' ' + coalesce(empmaster.emp_l_name,'') as empname,
		'Comp-Off' leavename,
		dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
		convert(varchar,applyl.fromdate,101) fromdate,
		convert(varchar,applyl.todate,101)  todate,
		applyl.no_of_days nod ,applyl.laps_status,
		eh.hr
		from tbl_leave_apply_compoff applyl inner join 
		tbl_Compoff_employee_hierarchy eh on
		applyl.empcode=eh.employeecode 
--and eh.approverpriority>applyl.approval_status
		inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
		where eh.approverid='" + _userCode.ToString() + "'  and eh.hr=0 and laps_status=1 ";
       


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
        leave_approval_grid.DataSource = ds;
        leave_approval_grid.DataBind();

    }
    protected string linkleave(string empcode, string leavename, int id)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='viewcompoffapproverstatus.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + "</a>";

        else
            return "<a href='viewcompoffapproverstatus.aspx?q=" + encoded + "' title='view detail' class='link05'>" + leavename + " </a>";

    }
    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}