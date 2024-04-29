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


public partial class admin_viewentity : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message1.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["updated"] != null)
            message1.InnerHtml = "entity detail updated successfully";
        bind_Entitydetails();
    }

    public void bind_Entitydetails()
    {
        string sqlstr = "select id,entity from entity";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        int id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString());
        Session["entity_id"] = id.ToString();
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
}
