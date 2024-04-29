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



public partial class payroll_admin_freezepayroll : System.Web.UI.Page
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
        }
    }

    #region
    protected override void OnInit(EventArgs e)
    {
        InitializeComponents();
        base.OnInit(e);
    }

    private void InitializeComponents()
    {
        gd_encash.RowEditing += gd_encash_RowEditing;
    }

   
    #endregion

    protected void bind_year()
    {
        sqlstr = "SELECT financial_year year FROM tbl_payroll_tax_master  order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void bind_month()
    {
        sqlstr = "select distinct s.month,s.YEAR, case when f.status is null then 'Unfreezed' when f.status = 'F' then 'Freezed' when f.status = 'U' then 'Unfreezed' end status,fromdate from tbl_payroll_employee_salary s left join tbl_freezepayroll f on s.YEAR = f.finyear and s.MONTH = f.month  where s.YEAR='" + dd_year.SelectedValue + "' order by fromdate";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        gd_encash.DataSource = ds.Tables[0];
        gd_encash.DataBind();
        
    }



    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }


    void gd_encash_RowEditing(object sender, GridViewEditEventArgs e)
    {

        foreach (GridViewRow row in gd_encash .Rows )
        {
            if (row.DataItemIndex == e.NewEditIndex)
            {
                Label lblYear = (Label)row.FindControl("lblYear");
                Label lblMonth = (Label)row.FindControl("lblMonth");
                Label lblStatus = (Label)row.FindControl("lblStatus");

                if (lblStatus.Text.Trim() != "Freezed")
                {
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "sp_freezepayroll", lblYear.Text.Trim(), lblMonth.Text.Trim(), Session["empcode"].ToString().Trim());
                }
            }
        }

        bind_month();

    }

    
}