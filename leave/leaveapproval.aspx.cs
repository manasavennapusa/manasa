
using DataAccessLayer;
using Microsoft.Office.Interop.Word;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class leave_leaveapproval : System.Web.UI.Page
{
    string _companyId, _userCode;
    #region PageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
             _userCode = Session["empcode"].ToString();
           _companyId = Session["companyid"].ToString();
           if (!IsPostBack)
           {
               if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
                   lbltitle.Text = "Leave Approval";
               else
                   lbltitle.Text = "Leave Updation";
           }

            bindgrid();
        }
        else { Response.Redirect("~/notlogged.aspx"); }
        if (Request.QueryString["message"] != null)
        {
            Common.Console.Output.Show(Request.QueryString["message"].ToString());
        }
    }
    #endregion
    #region Approve Link of Leave Details
    protected string linkleave(string empcode, string leavename, int id)
    {
        Common.Encode.QueryString q = new Common.Encode.QueryString();
        string pairs = String.Format("leaveapplyid={0}&empcode={1}", id, empcode.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        if (Convert.ToInt32(Request.QueryString["hr"]) != 1)
            return "<a href='ViewLeaveApprover.aspx?q=" + encoded + "' title='view detail' class='lable lable-info'>View</a>";

        else
            return "<a href='ViewLeaveHR.aspx?q=" + encoded + "' title='view detail' class='lable lable-info'>View</a>";

    }
    #endregion

    protected void leave_approval_grid_PreRender(object sender, EventArgs e)
    {
        if (leave_approval_grid.Rows.Count > 0)
            leave_approval_grid.HeaderRow.TableSection = TableRowSection.TableHeader;
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
  leavem.leavetype leavename,
  dbo.getleavestatus(applyl.leave_status,applyl.status) leavestatus,
  case when applyl.leavemode=1 then convert(varchar,applyl.fromdate,101) else convert(varchar,applyl.hdate,101) end  fromdate,
  case when applyl.leavemode=1 then convert(varchar,applyl.todate,101) else convert(varchar,applyl.hdate,101) end  todate,
  applyl.no_of_days nod ,
  eh.hr
  from tbl_leave_apply_leave applyl 
  inner join tbl_leave_employee_hierarchy eh on applyl.empcode=eh.employeecode and eh.approverpriority=applyl.approvel_status+1 and eh.flag=1
  inner join tbl_intranet_employee_jobDetails empmaster on empmaster.empcode=applyl.empcode
  inner join tbl_leave_createleave leavem on leavem.leaveid=applyl.leaveid
  where eh.approverid='" + _userCode.ToString() + "'  and  not ((applyl.leave_status=6 and applyl.status=1) or (applyl.leave_status=2 and applyl.status=1) or (applyl.leave_status=3 and applyl.status=1) or (applyl.leave_status=4 and applyl.status=1 ) or (applyl.leave_status=5 and applyl.status=1))"; 
 

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
            leave_approval_grid.DataSource = ds;
            leave_approval_grid.DataBind();

    }

}