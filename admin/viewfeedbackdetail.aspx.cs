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

public partial class admin_viewfeedbackdetail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

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

            bindnews();
        }
    }

    protected void bindnews()
    {
        sqlstr = "select id,subject,description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate from tbl_intranet_feedback WHERE id=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        lbldate.Text = "Posted On : " + ds.Tables[0].Rows[0]["posteddate"].ToString() + ", ";
        lblname.Text = "By : " + ds.Tables[0].Rows[0]["postedby"].ToString();
        lblheading.Text = ds.Tables[0].Rows[0]["subject"].ToString();
        lbldetails.Text = ds.Tables[0].Rows[0]["description"].ToString();
    }
}