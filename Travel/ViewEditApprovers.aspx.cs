using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_ViewEditApprovers : System.Web.UI.Page
{
    DataSet ds=new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindgrid();
        }
    }

    protected void bindgrid()
    {
        ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(),CommandType.StoredProcedure,"[sp_travel_getEmployeeApprovers]");
        empgird.DataSource = ds;
        empgird.DataBind();
    }

    protected void empgird_PreRender(object sender, EventArgs e)
    {
        if (empgird.Rows.Count > 0)
        {
            empgird.UseAccessibleHeader = true;
            empgird.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    //protected void bindApproversgrid()
    //{
    //    string sqlstr = "select ap.empcode,coalesce(jd.emp_fname,'')+' '+coalesce(jd.emp_m_name,'')+' '+coalesce (jd.emp_l_name,'') as name,approvercode,level,traveltype,workflow  from tbl_travel_ApproverHirarchy ap inner join tbl_intranet_employee_jobDetails jd on jd.empcode=ap.approvercode where ap.empcode='" + Session["empcode"].ToString() + "'";
    //    DataSet ds3 = new DataSet();
    //    ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    Grid_Approvers.DataSource = ds3;
    //    Grid_Approvers.DataBind();
    //    if (ds3.Tables[0].Rows.Count == 0)
    //    {
    //        SmartHr.Common.Alert("You are not able to submit Travel Form. Because of Approvers for Your Travel are not set.Please Contact your Manager");
    //    }
    //}
}