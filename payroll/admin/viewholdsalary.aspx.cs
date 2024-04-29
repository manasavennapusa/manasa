using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Web;
//using System.Web.Mail;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using NumberToEnglish;
using System.Net.Mail;
using Common.Console;

public partial class payroll_admin_viewholdsalary : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            bind_fyear();
            bindempdetail();
        }
    }

    protected void bind_fyear()
    {

        //int year = DateTime.Now.Year, count = 1;
        //lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        //for (int i = year-1; i < year + 5; i++)
        //{
        //    lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
        //    count++;
        //}
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
            lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }

    protected void btnsendmail_Click(object sender, EventArgs e)
    {
        int counter = 0;
        foreach (GridViewRow GridView in empgrid.Rows)
        {
            CheckBox checkg = (CheckBox)GridView.FindControl("checkg");

            if (checkg.Checked == true)
            {
                string strempcode, strmonth, stryear;
                strempcode = ((Label)empgrid.Rows[counter].FindControl("lblempcodeg")).Text;
                strmonth = dd_month.SelectedItem.Text;
                stryear = lbl_fyear.Text;

                string query1 = @"update tbl_payroll_hold_relesesalary set status=0,rel_month='"+dd_month.SelectedItem.Text+"',rel_month_id='"+dd_month.SelectedValue+"' where empcode='" + strempcode + "' and status= 1";
                DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, query1);
            }
            counter = counter + 1;
        }
    }
    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.UseAccessibleHeader = true;
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bindempdetail()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = @"select emp.empcode,emp.emp_fname,months,year,remarks from dbo.tbl_payroll_hold_relesesalary hd
inner join dbo.tbl_intranet_employee_jobDetails emp 
on hd.empcode = emp.empcode where hd.status = 1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        empgrid.DataSource = ds;
        empgrid.DataBind();
        
    }


    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}