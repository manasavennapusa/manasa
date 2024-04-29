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

public partial class mycontactlist : System.Web.UI.Page
{   
    String sqlstr;
    private DataSet ds = new DataSet();   

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
            bindContactGrid();          
        }
    }

    protected void ContactGrid_SelectedIndexChanged(object sender, EventArgs e)
    {

    }   
   
   //Binding Contact List of User 
    protected void bindContactGrid()
    {        
        sqlstr = "select * from contactlist";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);     
        ContactGrid.DataSource = ds;
        ContactGrid.DataBind();
    }          

}
