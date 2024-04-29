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

public partial class attendance_Freezeattendance : System.Web.UI.Page
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
        }
    }

    private void bind_year()
    {
        dd_year.Items.Clear();
        dd_year.Items.Add(new ListItem("--Select Year--", "0"));

        for (int yr = 2014; yr <= DateTime.Now.Year; yr++)
        {
            dd_year.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }

    protected void dd_year_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_month();
    }

    protected void bind_month()
    {
        sqlstr = @"Select distinct DATENAME(month,pay.DATE) as [MONTH],YEAR(pay.DATE)as [YEAR],MONTH(pay.DATE),
   case when f.status is null then 'Unfreezed' when f.status = 'F' then 'Freezed' when f.status = 'U' then 'Unfreezed' end [Status],
    case when f.status is null then 'freeze' when f.status = 'F' then 'unfreeze' when f.status = 'U' then 'freeze' end [free_status]
from tbl_payroll_employee_attendence_detail pay 
left join tbl_freezeattendance f on f.year=YEAR(pay.DATE) and f.month=DATENAME(month,pay.DATE)
where  YEAR(pay.DATE)='" + dd_year.SelectedValue + "' order by MONTH(pay.DATE)";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        gd_encash.DataSource = ds.Tables[0];
        gd_encash.DataBind();

    }

   
    protected void gd_encash_PreRender(object sender, EventArgs e)
    {
        if (gd_encash.Rows.Count > 0)
            gd_encash.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void gd_encash_RowEditing(object sender, GridViewEditEventArgs e)
    {
        foreach (GridViewRow row in gd_encash.Rows)
        {
            if (row.DataItemIndex == e.NewEditIndex)
            {
                Label lblYear = (Label)row.FindControl("lblYear");
                Label lblMonth = (Label)row.FindControl("lblMonth");
                Label lblStatus = (Label)row.FindControl("lblStatus");

                if (lblStatus.Text.Trim() != "Freezed")
                {
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "sp_freezeattendance", lblYear.Text.Trim(), lblMonth.Text.Trim(), Session["empcode"].ToString().Trim(), 'F');
                }
                else
                {
                    DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "sp_unfreezeattendance", lblYear.Text.Trim(), lblMonth.Text.Trim(), Session["empcode"].ToString().Trim(), 'U');
                }
            }
        }
        bind_month();
    }
}