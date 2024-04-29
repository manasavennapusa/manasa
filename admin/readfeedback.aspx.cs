using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using System.Data.SqlClient;

public partial class admin_readfeedback : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgrid();
        }
    }

    protected void bindgrid()
    {
        sqlstr = @"SELECT es.id,es.subject,es.description description1,substring(es.description,1,20) description,
                (CASE WHEN es.status=0 THEN 'Not Approved' ELSE 'Approved' END)status,es.status status1,
                (CASE WHEN es.posteddate='01/01/1990' THEN '' ELSE CONVERT(CHAR(15), es.posteddate, 106) END)posteddate,postedby,ed.department_name
                FROM tbl_intranet_feedback es INNER JOIN tbl_intranet_employee_jobDetails ej ON ej.empcode=es.empid 
                INNER JOIN tbl_internate_departmentdetails ed ON ed.departmentid=ej.dept_id ORDER BY es.posteddate desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        suggestionsgrid.DataSource = ds;
        suggestionsgrid.DataBind();
    }

    protected void suggestions_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        suggestionsgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    //protected void suggestions_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    suggestionsgrid.EditIndex = e.NewEditIndex;
    //    bindgrid();
    //}
    //protected void suggestions_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    int code = (int)suggestionsgrid.DataKeys[e.RowIndex].Value;
    //    sqlstr = "DELETE FROM tbl_intranet_suggestions WHERE id=" + code;
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    bindgrid();
    //}
    //protected void suggestions_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    string strstatus = ((DropDownList)suggestionsgrid.Rows[e.RowIndex].Cells[4].Controls[1]).SelectedValue;
    //    int code = (int)suggestionsgrid.DataKeys[e.RowIndex].Value;
    //    sqlstr = "UPDATE tbl_intranet_suggestions SET status=" + strstatus + ",approvercode='" + Session["empcode"].ToString() + "',approveddate=getdate() WHERE id=" + code + "";
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    suggestionsgrid.EditIndex = -1;
    //    bindgrid();
    //}
    //protected void suggestions_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    suggestionsgrid.EditIndex = -1;
    //    bindgrid();
    //}
}
