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
using querystring;
using System.IO;

public partial class payroll_admin_Report : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_year();
            bind_month();
            bindDepartment();
        }
       
    }

    protected void bind_month()
    {
        sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }

    protected void bind_year()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void bindgrid()
    {
        string year = dd_year.SelectedItem.Text.ToString();
        string month = dd_month.SelectedValue.ToString();
        string department = dd_designation.SelectedValue.ToString();

        SqlParameter[] sqlParam = new SqlParameter[3];

        sqlParam[0] = new SqlParameter("@year", year);
        sqlParam[1] = new SqlParameter("@month", month);
        sqlParam[2] = new SqlParameter("@dept_id", department);

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payroll_report", sqlParam);
        grdPayrollReport.DataSource = ds;
        grdPayrollReport.DataBind();
    }
    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btnexport_Click(object sender, EventArgs e)
    {
        exportExcell();
    }

    protected void exportExcell()
    {

        string month = dd_month.SelectedValue.ToString();
        string year = dd_year.SelectedItem.Text.ToString();
        string department = dd_designation.SelectedValue.ToString();

        SqlParameter[] sqlparm = new SqlParameter[3];

        sqlparm[0] = new SqlParameter("@year", year);
        sqlparm[1] = new SqlParameter("@dept_id", department);
        sqlparm[2] = new SqlParameter("@month", month);
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionstring"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payroll_report", sqlparm);

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename = PayrollReport.xls";
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
    }

    protected void btnReport_Click(object sender, EventArgs e)
    {
        bindgrid();
        
    }

    protected void bindDepartment()
    {
         sqlstr = "SELECT distinct  [departmentid], department_name  FROM [tbl_internate_departmentdetails]"; ;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_designation.DataTextField = "department_name";
        dd_designation.DataValueField = "departmentid";
        dd_designation.DataSource = ds;
        dd_designation.DataBind();
    }
}