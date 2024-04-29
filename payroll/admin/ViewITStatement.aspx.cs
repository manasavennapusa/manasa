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

public partial class payroll_admin_ViewITStatement : System.Web.UI.Page
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
            Findemptype();
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

    protected void Findemptype()
    {
        string query = @"select employee_type from dbo.tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, query);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        emp_type = ds.Tables[0].Rows[0]["employee_type"].ToString();

        if (emp_type == "2")
        {
            //btnprint.Visible = false;
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        DateTime a = new DateTime(1900, System.DateTime.Now.Month, 1);
        encodepayslip(txt_employee.Text.ToString(), dd_month.SelectedItem.Text.ToString(), dd_year.SelectedItem.Text.ToString());
        //   ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), "xx", strPop, false);
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
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(780/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ITStatement.aspx?q=" + encoded + "', null, 'height=640,width=1200,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
        // return "<script language='javascript'>window.open('Playslip.aspx?q=" + encoded + "')</script>";
    }

}