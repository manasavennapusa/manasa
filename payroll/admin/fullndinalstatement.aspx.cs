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

public partial class payroll_admin_fullndinalstatement : System.Web.UI.Page
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
                bind_year();
            }
            else
                Response.Redirect("~/notlogged.aspx");

            
        }
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
    protected void tbn_submit_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'fullnfinalreport.aspx?empcode=" + txt_employee.Text + "&month=" + ddl_month.SelectedItem + "&year=" + dd_year.SelectedItem + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }

    
}