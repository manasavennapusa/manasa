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

public partial class payroll_admin_monthly_tds_challan_view : System.Web.UI.Page
{

    DataSet ds = new DataSet();
    string sqlstr;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            bind_year();
            bind_month();
            drp_comp_name.DataBind();
            grid();
        }
    }

    protected void payheadgird_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            int challan_no = (int)payheadgird.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            Response.Redirect("monthly_tds_challan_payment_edit.aspx?challan_no=" + challan_no);
        }

        if (e.CommandName == "Payment")
        {
            int challan_no = (int)payheadgird.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            Response.Redirect("monthly_tds_challan_payment.aspx?challan_no=" + challan_no);
        }

        if (e.CommandName == "Paymentview")
        {
            int challan_no = (int)payheadgird.DataKeys[int.Parse(e.CommandArgument.ToString())].Value;
            Response.Redirect("monthly_tds_challan_payment_view.aspx?challan_no=" + challan_no);
        }
    }

    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }
    
    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("--Select Cost Center--", "0"));
    }

    protected void bind_year()
    {
        sqlstr = "select [financial_year] as year from tbl_payroll_tax_master order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void bind_month()
    {
        sqlstr = "select distinct month,fromdate from tbl_payroll_employee_salary where year='" + dd_year.SelectedValue + "' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds;
        dd_month.DataBind();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        grid();
    }

    protected void grid()
    {
        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@financialYear", SqlDbType.VarChar, 50);
        if ((dd_year.SelectedIndex == 0) || (dd_year.SelectedIndex == -1))
        {
            sqlparam[0].Value = 0;
        }
        else
        {
            sqlparam[0].Value = dd_year.SelectedValue;
        }

        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        if ((dd_month.SelectedIndex == 0) || (dd_month.SelectedIndex == -1))
        {
            sqlparam[1].Value = 0;
        }
        else
        {
            sqlparam[1].Value = dd_month.SelectedItem.Text.ToString();
        }

        sqlparam[2] = new SqlParameter("@costCenter", SqlDbType.VarChar, 50);
        if ((drp_comp_name.SelectedIndex == 0) || (drp_comp_name.SelectedIndex == -1))
        {
            sqlparam[2].Value = 0;
        }
        else
        {
            sqlparam[2].Value = drp_comp_name.SelectedValue;
        }
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_search_fetch_challan]", sqlparam);

        payheadgird.DataSource = ds;
        payheadgird.DataBind();
    }
    protected void payheadgird_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        payheadgird.PageIndex = e.NewPageIndex;
        grid();
    }
    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }
    protected void dd_month_DataBound(object sender, EventArgs e)
    {
        dd_month.Items.Insert(0, new ListItem("---Select Month---", "0"));
    }
}