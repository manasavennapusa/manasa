using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

public partial class Default5 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {

            GetBirthdayAnniversaries();
        }
    }
    private void GetBirthdayAnniversaries()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), "demogetbirthdayanniversary");
        StringBuilder str = new StringBuilder();
        str.Append("<ul class='chats'>");

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            str.Append("<li>");
            str.Append("<div class='user pull-left'>");
            if (row["photo"].ToString() != "")
                str.Append("<img src='Upload/photo/" + row["photo"].ToString() + "' alt='user'>");
            else
                str.Append("<img src='upload/photo/image.png' alt='user'>");
            str.Append("</div>");
            str.Append("<div class='info'>");
            str.Append("<h6>");
            str.Append(row["fname"].ToString() + " " + row["lname"].ToString());
            str.Append("</h6>");
            str.Append("<p>");
            str.Append(row["Occasion"].ToString());
            str.Append("</p>");
            str.Append("<small>");
            str.Append(row["dob"].ToString());
            str.Append("</small>");
            str.Append("</div>");
            str.Append("</li>");

        }
        str.Append("</ul>");
        Session["Birthday"] = str.ToString();
    }
}