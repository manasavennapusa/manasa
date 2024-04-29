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

public partial class Admin_adminpanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
               // Response.Redirect("~/Authenticate.aspx");
        }
        else
            Response.Redirect("~/notlogged.aspx");
            
        lblname.Text = Session["name"].ToString();

        if (Session["role"].ToString()=="3")
            superadmin.Visible=true;
    }
    protected void lnkbtnlogout_Click(object sender, EventArgs e)
    {
      //  int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), "sp_login", Session["empcode"].ToString().Trim());

        Session.RemoveAll();
        Response.Redirect("../Default.aspx");   
    }
    protected void lnkbtnHome_Click(object sender, EventArgs e)
    {
        Response.Redirect("../main.aspx");
    }
}
