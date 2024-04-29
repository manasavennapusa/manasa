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

public partial class payroll_admin_salaryreport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
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
        }
    }

    protected void bindpayrollgrid()
    {
        string strmonth = dd_month.SelectedItem.Text;
        string stryear = dd_year.SelectedItem.Text;
        string strempcode = txt_employee.Text.Trim().ToString();
        int currentyear, currentmonth = 0;
        if (strmonth.ToLower() == "jan")
        {
            currentmonth = 1;
        }
        if (strmonth.ToLower() == "feb")
        {
            currentmonth = 2;
        }
        if (strmonth.ToLower() == "mar")
        {
            currentmonth = 3;
        }
        if (strmonth.ToLower() == "apr")
        {
            currentmonth = 4;
        }
        if (strmonth.ToLower() == "may")
        {
            currentmonth = 5;
        }
        if (strmonth.ToLower() == "jun")
        {
            currentmonth = 6;
        }
        if (strmonth.ToLower() == "jul")
        {
            currentmonth = 7;
        }
        if (strmonth.ToLower() == "aug")
        {
            currentmonth = 8;
        }
        if (strmonth.ToLower() == "sep")
        {
            currentmonth = 9;
        }
        if (strmonth.ToLower() == "oct")
        {
            currentmonth = 10;
        }
        if (strmonth.ToLower() == "nov")
        {
            currentmonth = 11;
        }
        if (strmonth.ToLower() == "dec")
        {
            currentmonth = 12;
        }
        //currentmonth = Convert.ToInt32(strmonthn);
        currentyear = Convert.ToInt32(stryear.Substring(0, 4));

        if (currentmonth == 1)
        {
            currentyear = currentyear + 1;
        }
        DateTime fromdate, todate;
        fromdate = Convert.ToDateTime("04/24/" + currentyear);
        todate = Convert.ToDateTime(currentmonth + "/24/" + currentyear);

        sqlstr = @"select isnull(sum(gtotal),0.00) GrandTotal,
                    isnull(sum(dtotal),0.00) DeductionTotal,
                    isnull(sum(REIMNTOTAL),0.00) ReimbursementTotal,isnull(sum(NTOTAL),0.00) NetTotal ,coalesce(emp_fname,'') +' '+ coalesce(emp_m_name,'') +' '+ coalesce(emp_l_name,'') empname,job.empcode 
                    from tbl_payroll_employee_salary sal
                    right outer join tbl_intranet_employee_jobDetails job
                    on sal.empcode=job.empcode
                    where TODATE between '" + fromdate + "' and '" + todate + "'  group by coalesce(emp_fname,'') +' '+ coalesce(emp_m_name,'') +' '+ coalesce(emp_l_name,'') , job.empcode having  job.empcode='" + strempcode.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        payrollgrid.DataSource = ds;
        payrollgrid.DataBind();
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        bindpayrollgrid();
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        txt_employee.Text = "";
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
        sqlstr = "select distinct year from tbl_payroll_employee_salary";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }
    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }

    protected void payrollgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        payrollgrid.PageIndex = e.NewPageIndex;
        bindpayrollgrid();
    }
}
