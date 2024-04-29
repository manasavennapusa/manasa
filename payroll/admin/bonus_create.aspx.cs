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
using System.IO;
using System.Data.SqlClient;

public partial class payroll_admin_bonus_create : System.Web.UI.Page
{
    string sqlstr;
    SqlParameter[] sqlparm;
    DataSet ds = new DataSet();
    DataView dv = new DataView();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
          
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            bind_fyear();
            bindadjustmentview();
        }
    }
    protected void bind_fyear()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dt.Month) >= 4)
            lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }
    //protected void dd_year_DataBound(object sender, EventArgs e)
    //{
    //    dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    //}
    protected void btnsv_Click(object sender, EventArgs e)
    {
        sqlparm = new SqlParameter[5];
        sqlparm[0] = new SqlParameter("@fyear", lbl_fyear.Text.Trim().ToString());
        sqlparm[1] = new SqlParameter("@month", dd_month.SelectedValue);
        sqlparm[2] = new SqlParameter("@interest", txt_bonus_percent.Text.Trim().ToString());
        sqlparm[3] = new SqlParameter("@createdby", Session["name"].ToString());
        sqlparm[4] = new SqlParameter("@modifiedby", Session["name"].ToString());

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bonus_autocreate]", sqlparm);

        bindadjustmentview();
    }
    //protected void bindadjustment()
    //{
    //    sqlparm = new SqlParameter[1];
    //    sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedValue);
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bonus_autocreate]", sqlparm);

    //    if (ViewState["sortExpr"] != null)
    //    {
    //        dv = new DataView(ds.Tables[0]);
    //        dv.Sort = (string)ViewState["sortExpr"];
    //    }
    //    else
    //        dv = ds.Tables[0].DefaultView;

    //    adjustgrid.DataSource = dv;
    //    adjustgrid.DataBind();
    //}
    //protected void adjustgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    //{
    //    adjustgrid.EditIndex = -1;
    //    bindadjustment();
    //}
    //protected void adjustgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    sqlparm = new SqlParameter[2];
    //    sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0]);
    //    sqlparm[1] = new SqlParameter("@fyear", adjustgrid.DataKeys[e.RowIndex][1]);
    //    sqlstr = "delete from tbl_payroll_employee_bonus_detail where empcode=@empcode and fyear=@fyear";
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
    //    bindadjustment();
    //}
    //protected void adjustgrid_RowEditing(object sender, GridViewEditEventArgs e)
    //{
    //    adjustgrid.EditIndex = e.NewEditIndex;
    //    bindadjustment();
    //}
    //protected void adjustgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    //{
    //    sqlparm = new SqlParameter[2];
    //    sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0]);
    //    sqlparm[1] = new SqlParameter("@year", adjustgrid.DataKeys[e.RowIndex][1]);
    //    sqlstr = "update tbl_payroll_employee_bonus_detail set amount=@amount where empcode=@empcode and fyear=@year";
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
    //    adjustgrid.EditIndex = -1;
    //    bindadjustment();
    //}
    //protected void btn_view_Click(object sender, EventArgs e)
    //{
    //    //bindadjustment();
    //}
    //protected void adjustgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    adjustgrid.PageIndex = e.NewPageIndex;
    //    bindadjustment();
    //}
    //protected void adjustgrid_Sorting(object sender, GridViewSortEventArgs e)
    //{
    //    ViewState["sortExpr"] = e.SortExpression;
    //    bindadjustment();
    //}
    //protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bindadjustmentview();
    //}
    protected void bindadjustmentview()
    {
        sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@desg", "0");
        sqlparm[1] = new SqlParameter("@fyear", lbl_fyear.Text.Trim().ToString());
        sqlparm[2] = new SqlParameter("@department", "0");
        sqlparm[3] = new SqlParameter("@name", "");
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bonus_select]", sqlparm);

        if (ViewState["sortExpr"] != null)
        {
            dv = new DataView(ds.Tables[0]);
            dv.Sort = (string)ViewState["sortExpr"];
        }
        else
            dv = ds.Tables[0].DefaultView;

        adjustgridview.DataSource = dv;
        adjustgridview.DataBind();
    }
    protected void adjustgridview_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpr"] = e.SortExpression;
        bindadjustmentview();
    }
    protected void adjustgridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        adjustgridview.PageIndex = e.NewPageIndex;
        bindadjustmentview();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //dd_year.SelectedIndex = 0;
        txt_bonus_percent.Text = "";
        dd_month.SelectedIndex = 0;
    }
}
