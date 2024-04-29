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
using querystring;
using System.IO;

public partial class payroll_admin_paystructureempview : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_ddlCCgroup();
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");
           
        }
    }
    protected void bind_ddlCCgroup()
    {
        sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddl_cc_groupid.DataSource = ds;
        ddl_cc_groupid.DataTextField = "cost_center_group_name";
        ddl_cc_groupid.DataValueField = "id";
        ddl_cc_groupid.DataBind();
        ddl_cc_groupid.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void ddl_cc_groupid_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_cc_code.Items.Clear();
        //   ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_cc_groupid.SelectedValue != "0")
            bind_cc_code(Convert.ToInt32(ddl_cc_groupid.SelectedValue));

    }
    protected void bind_cc_code(int accgroupid)
    {
        sqlstr = "select id,cost_center_code from tbl_intranet_cost_center where cost_center_group_id='" + accgroupid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddl_cc_code.DataSource = ds;
        ddl_cc_code.DataTextField = "cost_center_code";
        ddl_cc_code.DataValueField = "id";
        ddl_cc_code.DataBind();
        ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void ddl_cc_code_SelectedIndexChanged(object sender, EventArgs e)
    {

    }


    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        dd_designation.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("All", "0"));
    }


    protected void btn_search_Click(object sender, EventArgs e)
    {
        string month=(ddl_month.SelectedValue.ToString()=="None")?"":ddl_month.SelectedValue.ToString();
         string strPop;
        if (rpt_D.Checked)
            strPop = "<script language='javascript'>window.open('reports/SalarySheet.aspx?q=" + encode(dd_designation.SelectedValue.ToString(), dd_branch.SelectedValue.ToString(), month, ddl_year.SelectedValue.ToString(), ddl_cc_groupid.SelectedValue.ToString(), ddl_cc_code.SelectedValue.ToString()) + "')</script>";
        else
            strPop = "<script language='javascript'>window.open('reports/SalarySheetSummarize.aspx?q=" + encode(dd_designation.SelectedValue.ToString(), dd_branch.SelectedValue.ToString(), month, ddl_year.SelectedValue.ToString(), ddl_cc_groupid.SelectedValue.ToString(), ddl_cc_code.SelectedValue.ToString()) + "')</script>";
        ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);

    }
    protected string encode(string branch, string dept, string month, string year,string costgr,string costcode)
    {
        query q = new query();
        string pairs = String.Format("branch={0}&dept={1}&month={2}&year={3}", branch, dept, month, year,costgr,costcode);
        string encoded;
        encoded = q.EncodePairs(pairs);
        return encoded;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparm = new SqlParameter[4];
        sqlparm[0] = new SqlParameter("@branch", dd_designation.SelectedValue);
        sqlparm[1] = new SqlParameter("@dept", dd_branch.SelectedValue);
        sqlparm[2] = new SqlParameter("@month", ddl_month.SelectedValue);
        sqlparm[3] = new SqlParameter("@year", ddl_year.SelectedValue);
        //sqlparm[4] = new SqlParameter("@costcentergroup", ddl_cc_groupid.SelectedValue);
        //sqlparm[5] = new SqlParameter("@costcentercode", ddl_cc_code.SelectedValue);

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_salary_sheet_monthly_export]", sqlparm);
        ds1.Tables[0].TableName = "table";

        Response.Clear(); //this clears the Response of any headers or previous output 
        Response.Charset = "";
        Response.Buffer = true; //make sure that the entire output is rendered simultaneously
        Response.ClearContent();
        Response.ContentType = "application/vnd.ms-excel";
        string filename = "attachment;filename =Salary Sheet.xls";
        //string filename = "attachment;filename =Attendance-1.xls";
        //Response.AddHeader("content-disposition", "attachment;filename =Attendance.xls");// TeamLeaveStatus.xls");
        Response.Write(filename);
        Response.AddHeader("content-disposition", filename);// TeamLeaveStatus.xls");
        StringWriter stringWrite = new StringWriter();
        HtmlTextWriter htmlwrite = new HtmlTextWriter(stringWrite);
        DataGrid dg = new DataGrid();
        dg.DataSource = ds1.Tables[0];
        dg.DataBind();

        //String style = @"<style>.text{mso-number-format:\@;}</style>";
        //HttpContext.Current.Response.Write(style);
        //int colindex = 0;
        //foreach (DataColumn dc in ds1.Tables[0].Columns)
        //{
        //    string valuetype = dc.DataType.ToString();
        //    foreach (DataGridItem i in dg.Items)
        //        i.Cells[colindex].Attributes.Add("class", "text");
        //    colindex++;
        //}

        dg.RenderControl(htmlwrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    
}
