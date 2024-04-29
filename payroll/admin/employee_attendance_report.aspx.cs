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
using System.Data.SqlClient;
using DataAccessLayer;
using System.IO;

public partial class payroll_admin_employee_attendance_report : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
        sqlparam[0].Value = txt_employee.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
        sqlparam[1].Value = dd_designation.SelectedValue;

        sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
        sqlparam[2].Value = dd_branch.SelectedValue;

        //sqlparam[3] = new SqlParameter("@declaration", SqlDbType.VarChar,25);
        //sqlparam[3].Value = ddldeclaration.SelectedValue;

        sqlparam[3] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[3].Value = 0;

        sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[4].Value = dd_year.SelectedValue;

        sqlparam[5] = new SqlParameter("@month", SqlDbType.VarChar, 25);
        sqlparam[5].Value = dd_month.SelectedValue;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_tax_variance_report]", sqlparam);
        empgrid.DataSource = ds;
        empgrid.DataBind();
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
    //protected void bind_month()
    //{
    //    sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
    //    dd_month.DataTextField = "month";
    //    dd_month.DataValueField = "month";
    //    dd_month.DataSource = ds;
    //    dd_month.DataBind();
    //}
    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bindempdetail();
    }

    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempdetail();
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }

    //protected void ddldeclaration_DataBound(object sender, EventArgs e)
    //{
    //    ddldeclaration.Items.Insert(0, new ListItem("---Select Declaration---", "0"));
    //}

    protected void exportexcel()
    {
        //try
        //{
        //SqlParameter[] sqlparam = new SqlParameter[2];

        //sqlparam[0] = new SqlParameter("@financial_year", SqlDbType.VarChar, 50);
        //sqlparam[0].Value = dd_year.SelectedValue;

        //sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_fetch_tds_detail]", sqlparam);
        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =TAXVARIANCE.xls";
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
        bindempdetail();
        exportexcel();
    }
}
