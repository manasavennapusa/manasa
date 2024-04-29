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
using querystring;

public partial class payroll_admin_projectedtaxmasterview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            dd_designation.DataBind();
            dd_branch.DataBind();
            //bind_month();
            bindempdetail();
        }
    }

    protected void bindempdetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

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

        sqlparam[4] = new SqlParameter("@status", SqlDbType.VarChar);
        sqlparam[4].Value = "3";


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_projectedtax_master_view]", sqlparam);
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

    //protected void dd_year_DataBound(object sender, EventArgs e)
    //{
    //    dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    //}

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
        string filename = "attachment;PROJECTED INCOMETAX REPORT";
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

    protected string encodeempcode(string empcode)
    {
        
        query q = new query();
        string pairs = String.Format("empcode={0}", empcode.ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);
        //return "<script language='javascript'>window.open('reports/projectedtaxdetailview.aspx?q=" + encoded + "')</script>";
        return "<a class='link05' href='reports/projectedtaxdetailview.aspx?q=" + encoded + "' target='_blank' title='Click here to view detail of projected income-tax of an employee'>View Details</a>";
    }
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        //[SP_PAYROLL_GENERATE_TAX_PROJECTION]
        //parameter->@fyear

        DateTime dt = DateTime.Now;
        string fyear;
        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dt.Month) >= 4)
             fyear= dt.Year + "-" + dt.AddYears(1).Year;
        else
             fyear= dt.AddYears(-1).Year + "-" + dt.Year;
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@fyear", SqlDbType.VarChar,12);
        sqlparam[0].Value = fyear.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[SP_PAYROLL_GENERATE_TAX_PROJECTION]", sqlparam);
    }
}
