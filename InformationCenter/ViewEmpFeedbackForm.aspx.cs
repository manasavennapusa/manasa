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
using DataAccessLayer;
using System.Data.SqlClient;

public partial class InformationCenter_ViewEmpFeedbackForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {


            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindgrid();
            Year();
        }

    }

    private void bindgrid()
    {
        string sqlstr = @"select sno, empcode,overallsatisfaction,IfeelIamvaluedatTriMedx,createddate from tbl_intranet_employeesatisfactionsurvey where year='" + drp_year.SelectedValue + "'and halfyear='" + drphalfyear.SelectedValue + "'";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        suggestionsgrid.DataSource = ds;
        suggestionsgrid.DataBind();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        bindgrid();
    }
    public void Year()
    {
        drp_year.Items.Clear();
        drp_year.Items.Add(new ListItem("Select Year", "0"));

        for (int yr = 2013; yr <= DateTime.Now.Year; yr++)
        {
            drp_year.Items.Add(new ListItem(Convert.ToString(yr), yr.ToString()));
        }
    }

    protected void suggestionsgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        suggestionsgrid.PageIndex = e.NewPageIndex;
        bindgrid();
    }
}