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
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Common.Encode;

public partial class payroll_admin_detailPerqReport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr, emp_type;
    string strPop;
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
           // Findemptype();
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

    //protected void Findemptype()
    //{
    //    string query = @"select employee_type from dbo.tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text.ToString() + "'";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, query);
    //    if (ds.Tables[0].Rows.Count < 1)
    //        return;
    //    emp_type = ds.Tables[0].Rows[0]["employee_type"].ToString();

    //    if (emp_type == "2")
    //    {
    //        //btnprint.Visible = false;
    //    }
    //}

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        string query = @"     select sd.EMPCODE,job.emp_fname as NAME ,SD.AMOUNT,20000 as credited,2000-SD.AMOUNT as Balance
                              from tbl_payroll_employee_salary S 
                              inner join tbl_payroll_employee_salarydetail SD on S.SALARYID = SD.SALARYID
                              inner join tbl_payroll_payhead H on SD.PAYHEADID = H.id
                              inner join tbl_intranet_employee_jobDetails job on job.empcode =S.EMPCODE 
                              where S.YEAR='" + dd_year.SelectedItem.ToString() + "'  and S.STATUS = 1   and S.MONTH = '" + dd_month .SelectedItem.ToString()+ "' and SD.PAYHEADID = 61" ;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, query);
        //if (ds.Tables[0].Rows.Count < 1)
        //    return;
        adjustgrid.DataSource=ds;
        adjustgrid.DataBind();

    }
    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }

    protected void encodepayslip(string empcode, string month, string year)
    {
        QueryString q = new QueryString();
        string pairs = String.Format("empcode={0}&month={1}&year={2}", empcode.ToString(), month.ToString(), year.ToString());
        string encoded;
        encoded = q.EncodePairs(pairs);
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(780/2);var Mtop = (screen.height/2)-(700/2);window.open( 'PerqItStatement.aspx?q=" + encoded + "', null, 'height=640,width=1200,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        // return "<script language='javascript'>window.open('Playslip.aspx?q=" + encoded + "')</script>";
    }
    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }
}