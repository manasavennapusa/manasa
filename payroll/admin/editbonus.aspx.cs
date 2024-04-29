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
public partial class payroll_admin_editbonus : System.Web.UI.Page
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

        }
    }
    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    }
    protected void bindadjustment()
    {
        sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@desg", dd_designation.SelectedValue);
        sqlparm[1] = new SqlParameter("@fyear", dd_year.SelectedValue);
        sqlparm[2] = new SqlParameter("@department", dd_branch.SelectedValue);
        sqlparm[3] = new SqlParameter("@name", txt_employee.Text.Trim().ToString());
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bonus_select]", sqlparm);

        if (ViewState["sortExpr"] != null)
        {
            dv = new DataView(ds.Tables[0]);
            dv.Sort = (string)ViewState["sortExpr"];
        }
        else
            dv = ds.Tables[0].DefaultView;

        adjustgrid.DataSource = dv;
        adjustgrid.DataBind();
    }
    protected void adjustgrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        adjustgrid.EditIndex = -1;
        bindadjustment();
    }
    //protected void adjustgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    //{
    //    sqlparm = new SqlParameter[2];
    //    sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0]);
    //    sqlparm[1] = new SqlParameter("@fyear", adjustgrid.DataKeys[e.RowIndex][1]);
    //    sqlstr = "delete from tbl_payroll_employee_bonus_detail where empcode=@empcode and fyear=@fyear";
    //    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
    //    bindadjustment();
    //}
    protected void adjustgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        adjustgrid.EditIndex = e.NewEditIndex;
        bindadjustment();
    }
    protected void adjustgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@empcode", adjustgrid.DataKeys[e.RowIndex][0].ToString().Replace("'", ""));
        sqlparm[1] = new SqlParameter("@year", adjustgrid.DataKeys[e.RowIndex][1]);
        sqlparm[2] = new SqlParameter("@amount", ((TextBox)adjustgrid.Rows[e.RowIndex].Cells[5].Controls[1]).Text);
        sqlparm[3] = new SqlParameter("@month", ((DropDownList)adjustgrid.Rows[e.RowIndex].Cells[6].Controls[1]).SelectedItem.Text);
        sqlstr = "update tbl_payroll_employee_bonus_detail set amount=@amount , month=@month where empcode=@empcode and year=@year";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparm);
        adjustgrid.EditIndex = -1;
        bindadjustment();
    }
    
    protected void adjustgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        adjustgrid.PageIndex = e.NewPageIndex;
        bindadjustment();
    }
    protected void adjustgrid_Sorting(object sender, GridViewSortEventArgs e)
    {
        ViewState["sortExpr"] = e.SortExpression;
        bindadjustment();
    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        bindadjustment();
    }

    protected void exportexcel()
    {
        //try
        //{
        sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@fyear", dd_year.SelectedValue);
        sqlparm[1] = new SqlParameter("@desg", dd_designation.SelectedValue);
        sqlparm[2] = new SqlParameter("@department", dd_branch.SelectedValue);
        sqlparm[3] = new SqlParameter("@name", txt_employee.Text.Trim().ToString());
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_bonus_select]", sqlparm);
        
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =BONUS.xls";
        //string filename = "attachment;filename =Attendance-1.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds.Tables[0];
        dg.DataBind();

        String style = @"<style>.text{mso-number-format:\@;}</style>";
        HttpContext.Current.Response.Write(style);
        int colindex = 0;
        foreach (DataColumn dc in ds.Tables[0].Columns)
        {
            string valuetype = dc.DataType.ToString();
            foreach (DataGridItem i in dg.Items)
                i.Cells[colindex].Attributes.Add("class", "text");
            colindex++;
        }

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
        //}
        //catch
        //{
        //    message.InnerHtml = "Monthly TDS Detail Can not be exported";
        //}
    }
    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportexcel();
    }
    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
        //bindempdetail();
    }
    
}
