using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Query_ViewqueryDetail : System.Web.UI.Page
{
    string UserCode, RoleId = "";
    string sqlstr;
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"].ToString() != null && Session["role"].ToString() != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
        }
        else
            Response.Redirect("../LogOut.aspx");
        string receivPage = Request.QueryString["page"];
        if (!IsPostBack)
        {
            if (RoleId != "SuperAdmin" && receivPage == "myPage")
            {
                bindQueryDetail();
                divAdmin.Visible = false;
                adminqryDetail.Visible = false;
                divEmp.Visible = true;
                empqryDetail.Visible = true;
            }
            else if (RoleId == "SuperAdmin" && receivPage == "myPage")
            {
                bindQueryDetail();
                divAdmin.Visible = false;
                adminqryDetail.Visible = false;
                divEmp.Visible = true;
                empqryDetail.Visible = true;
            }
            else
            {
                bindQueryDetailbyAdmin();
                empqryDetail.Visible = false;
                divEmp.Visible = false;
                divAdmin.Visible = true;
                adminqryDetail.Visible = true;
            }
        }
    }

    private void bindQueryDetailbyAdmin()
    {
        DataSet dsadmin = new DataSet();
        string qryadmin;
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            qryadmin = "select id,empCode,postedby,deptName,queryTypeName,description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate from tbl_query_raised_queries WHERE id=" + Request.QueryString["id"].ToString() + "";
            dsadmin = SQLServer.ExecuteDataset(connection, CommandType.Text, qryadmin);

            if (dsadmin.Tables[0].Rows.Count > 0)
            {
                lblPostedONby.Text ="Posted Date   :     " + dsadmin.Tables[0].Rows[0]["posteddate"].ToString() +
               ", " + "Posted By  :      " + dsadmin.Tables[0].Rows[0]["postedby"].ToString();

                 lblqrytypeAdmin.Text ="Query Type :     "+ dsadmin.Tables[0].Rows[0]["queryTypeName"].ToString();
                lblqryDetailAdmin.Text ="Description :     "+ dsadmin.Tables[0].Rows[0]["description"].ToString();
            }
            else
            {
                divAdmin.Visible = false;
            }
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

    private void bindQueryDetail()
    {
        sqlstr = "select id,queryTypeName,description,postedby,(CASE WHEN posteddate='01/01/1900' THEN '' ELSE CONVERT(CHAR(15), posteddate, 106) END) posteddate from tbl_query_raised_queries WHERE id=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblPostedOn.Text = "Posted Date :    " + ds.Tables[0].Rows[0]["posteddate"].ToString();
            lblQueryType.Text = "Query Type :     " + ds.Tables[0].Rows[0]["queryTypeName"].ToString();
            lblQueryDetail.Text ="Description :  " + ds.Tables[0].Rows[0]["description"].ToString();
        }
        else
        {
            divEmp.Visible = false;
        }
    }
    protected void lnkbtnback_Click(object sender, EventArgs e)
    {
        Server.Transfer("myquerystatus.aspx");
    }
    protected void lnkbtnbackbyAdmin_Click(object sender, EventArgs e)
    {
        Server.Transfer("AllqueryStatus.aspx");
    }
}