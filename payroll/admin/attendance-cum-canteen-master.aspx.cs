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

public partial class payroll_admin_attendance_cum_canteen_master : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgriddetails();
        }
    }

    protected void bindgriddetails()
    {
        sqlstr = "SELECT id,code,usedfor,status FROM  tbl_payroll_attendance_cum_canteen_map";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        grid.DataSource = ds;
        grid.DataBind();
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgriddetails();
    }
    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid.EditIndex = -1;
        bindgriddetails();
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = (int)grid.DataKeys[e.RowIndex].Value;

        sqlstr = "DELETE FROM tbl_payroll_attendance_cum_canteen_map where id=" + id + "";
        int del = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgriddetails();
    }
    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.EditIndex = e.NewEditIndex;
        bindgriddetails();
    }
    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int id = (int)grid.DataKeys[e.RowIndex].Value;
        string usedfor = ((DropDownList)grid.Rows[e.RowIndex].Cells[1].Controls[1]).SelectedValue;

        sqlstr = "UPDATE tbl_payroll_attendance_cum_canteen_map SET usedfor='" + usedfor.Trim().ToString() + "' WHERE id=" + id + "";
        int upd = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        grid.EditIndex = -1;
        bindgriddetails();
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        txt_name.Text = "";
        ddlusedfor.SelectedIndex = 0;
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = @"INSERT INTO tbl_payroll_attendance_cum_canteen_map(code,usedfor,status,createdby,modifiedby)
        VALUES ('" + txt_name.Text.Trim().ToString() + "','" + ddlusedfor.SelectedValue + "',0,'" + Session["empcode"].ToString() + "','" + Session["empcode"].ToString() + "')";

        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ins > 0)
        {
            message.InnerHtml = "Records has been inserted successfully";
            txt_name.Text = "";
            ddlusedfor.SelectedIndex = 0;
            bindgriddetails();
        }
        else
        {
            message.InnerHtml = "Records has not been inserted successfully";
        }
    }
}
