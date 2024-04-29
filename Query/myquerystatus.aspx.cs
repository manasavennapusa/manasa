using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Query_myquerystatus : System.Web.UI.Page
{
    string UserCode, RoleId = "";
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"].ToString() != null && Session["role"].ToString() != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
        }
        else
            Response.Redirect("../LogOut.aspx");
        if (!IsPostBack)
        {
            bindgrid();
            if (Request.QueryString["msg"] == "true")
            {
                Common.Console.Output.Show("Query Updated successfully!");
            }
        }
    }

    private void bindgrid()
    {
//        sqlstr = @"SELECT rq.id,rq.queryTypeName,rq.description description1,substring(rq.description,1,20) description,
//(CASE WHEN rq.status=0 THEN 'Pending' when rq.status=1 then 'Approved'  ELSE 'Pending'  END)status,
//rq.status status1,
//(CASE WHEN rq.posteddate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.posteddate, 106) END)posteddate,
//postedby,rq.deptName,rq.approverCode,(CASE WHEN rq.approvedDate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.approvedDate, 106) END)approvedDate
//FROM tbl_query_raised_queries rq INNER JOIN tbl_employee_jobDetails ej ON ej.empcode=rq.empCode 
//INNER JOIN dbo.tbl_master_department ed ON ed.id=ej.dept_id where rq.empCode='" + UserCode + "'";
        sqlstr= @"SELECT 
rq.id,
rq.queryTypeName,
rq.description description1,
substring(rq.description,1,20) description,
(CASE WHEN rq.status=0 THEN 'Open' when rq.status=1 then 'Closed' when rq.status=2 then 'Under Review' when rq.status=3 then 'Scrapped' ELSE 'Opened'  END)status,
rq.status status1,
(CASE WHEN rq.posteddate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.posteddate, 106) END)posteddate,
postedby,
rq.deptName,
rq.approverCode,
rq.priority,
rq.comment,
rq.tickettype,
ej.emp_fname,
(CASE WHEN rq.approvedDate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), rq.approvedDate, 106) END)approvedDate
FROM tbl_query_raised_queries rq 
INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=rq.approverCode 
INNER JOIN dbo.tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id 
where rq.empCode='" + UserCode + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ds.Tables[0].Columns.Add("Other");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            ds.Tables[0].Rows[i]["Other"] = "myPage";
        }
        suggestionsgrid.DataSource = ds;
        suggestionsgrid.DataBind();
    }

    protected void suggestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        suggestionsgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
}