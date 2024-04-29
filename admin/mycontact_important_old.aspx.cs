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

public partial class mycontact_important : System.Web.UI.Page
{
    string sqlstr1,sqlstr2,sqlstr3;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindGridView1();
            bindGridView2();
            bindGridView3();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void bindGridView1()
    {
        sqlstr1 = "select * from contactlist where c_category='Doctor'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }

    protected void bindGridView2()
    {
        sqlstr2 = "select * from contactlist where c_category='Lawyer'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
        GridView2.DataSource = ds;
        GridView2.DataBind();
    }

    protected void bindGridView3()
    {
        sqlstr3 = "select * from contactlist where c_category='Family Advicers'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr3);
        GridView3.DataSource = ds;
        GridView3.DataBind();
    }
}
