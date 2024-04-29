using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;

public partial class payroll_admin_employee_overtime : System.Web.UI.Page
{
    string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            }
            else Response.Redirect("~/notlogged.aspx");

            bind_month();
            bind_year();
            bindgrid();
        }
    }
    protected void grid_overtimedetail_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[3];
        strsql = "update tbl_payroll_employee_overtime set overtime=@overtime,overtime_h=@overtime_h where id=@id";
        sqlparm[0] = new SqlParameter("@overtime", SqlDbType.Int);
        sqlparm[0].Value = ((TextBox)grid_overtimedetail.Rows[e.RowIndex].Cells[2].Controls[1]).Text;

        sqlparm[1] = new SqlParameter("@overtime_h", SqlDbType.Int);
        sqlparm[1].Value = ((TextBox)grid_overtimedetail.Rows[e.RowIndex].Cells[3].Controls[1]).Text;

        sqlparm[2] = new SqlParameter("@id", SqlDbType.Int);
        sqlparm[2].Value = (int)grid_overtimedetail.DataKeys[e.RowIndex].Value;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, sqlparm);
        message.InnerHtml = "Overtime entry updated successfully";
        grid_overtimedetail.EditIndex = -1;
        bindgrid();
    }
    protected void grid_overtimedetail_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid_overtimedetail.EditIndex = e.NewEditIndex;
        bindgrid();
    }
    protected void grid_overtimedetail_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strsql = "DELETE FROM tbl_payroll_employee_overtime WHERE id=@id";
        SqlParameter sqlparm = new SqlParameter("@id",(int)grid_overtimedetail.DataKeys[e.RowIndex].Value);

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql, sqlparm);
        message.InnerHtml = "Overtime Entry deleted successfully";
        bindgrid();
    }
    protected void grid_overtimedetail_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid_overtimedetail.EditIndex = -1;
        bindgrid();
    }
    protected void grid_overtimedetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid_overtimedetail.PageIndex = e.NewPageIndex;
        bindgrid();
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        strsql = "insert into tbl_payroll_employee_overtime (empcode,month,year,overtime,overtime_h) values (@empcode,@month,@year,@overtime,@overtime_h)";
        SqlParameter[] sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparm[0].Value = txt_employee.Text.Trim();

        sqlparm[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparm[1].Value = dd_month_f.SelectedItem.Text;

        sqlparm[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparm[2].Value = dd_year_f.SelectedItem.Text;

        sqlparm[3] = new SqlParameter("@overtime", SqlDbType.Int);
        sqlparm[3].Value = txt_ot.Text;

        sqlparm[4] = new SqlParameter("@overtime_h", SqlDbType.Int);
        sqlparm[4].Value = txt_oth.Text;
        try
        {
            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strsql, sqlparm);
            message.InnerHtml = "Overtime Entry saved successfully";
            bindgrid();

        }
        catch
        {
            message.InnerHtml = "Duplicate Entries are not allowed";
        }
        finally
        {
            txt_employee.Text = "";
            txt_ot.Text = "";
            txt_oth.Text = "";
        }

    }
    protected void bind_month()
    {
        dd_month_f.Items.Insert(0, new ListItem("Select Month", "0"));
        for (int i = 1; i <= Convert.ToInt16(DateTime.Now.Month); i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(1900, i, 1).ToString("MMM");
            item.Value = i.ToString();
            dd_month_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        dd_month_f.SelectedValue = a.Month.ToString();
    }

    protected void bind_year()
    {
        dd_year_f.Items.Insert(0, new ListItem("Select Year", "0"));
        for (int i = 1997; i <= DateTime.Now.Year + 1; i++)
        {
            ListItem item = new ListItem();
            item.Text = new DateTime(i, 1, 1).ToString("yyyy");
            item.Value = i.ToString();
            dd_year_f.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
        }
        DateTime a = new DateTime(System.DateTime.Now.Year, 1, 1);
        dd_year_f.SelectedValue = a.Year.ToString();
       
    }
    protected void bindgrid()
    {
        SqlParameter[] sqlparm = new SqlParameter[2];
        sqlparm[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparm[0].Value = dd_month_f.SelectedItem.Text;

        sqlparm[1] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparm[1].Value = dd_year_f.SelectedItem.Text;

        grid_overtimedetail.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_ot_detail", sqlparm);
        grid_overtimedetail.DataBind();
    }
    protected void dd_month_f_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void dd_year_f_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
    }
}
