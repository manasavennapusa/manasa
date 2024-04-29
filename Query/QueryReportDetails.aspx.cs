using Common.Console;
using Common.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Query_QueryReportDetails : System.Web.UI.Page
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
            bindQueryReportDetail();
        }
        ViewState["pageName"] = receivPage;
    }

    private void bindQueryReportDetail()
    {
        var activity = new DataActivity();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = "select id,empCode,postedby,queryTypeName,posteddate,refrence_No,approvedDate,approverCode,description,priority,tickettype from tbl_query_raised_queries where id=" + Request.QueryString["id"] + "";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            lblEmpCode.Text = ds.Tables[0].Rows[0]["empCode"].ToString();
            lblEmpName.Text = ds.Tables[0].Rows[0]["postedby"].ToString();
            lblQueryType.Text = ds.Tables[0].Rows[0]["queryTypeName"].ToString();
            lblPostedDate.Text = ds.Tables[0].Rows[0]["posteddate"].ToString();
            lblRefNo.Text = ds.Tables[0].Rows[0]["refrence_No"].ToString();
            lblDescription.Text = ds.Tables[0].Rows[0]["description"].ToString();
            lblApprovedDate.Text = ds.Tables[0].Rows[0]["approvedDate"].ToString();
            lblApprovedby.Text = ds.Tables[0].Rows[0]["approverCode"].ToString();
            lblpriority.Text = ds.Tables[0].Rows[0]["priority"].ToString();
            lbltickettype.Text = ds.Tables[0].Rows[0]["tickettype"].ToString();
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
    protected void btnBack_Click(object sender, EventArgs e)
    {
        string pagename = (string)ViewState["pageName"];
        if (pagename == "myPage")
        {
            ViewState["pageName"] = null;
            Server.Transfer("QTreportDateWise.aspx?page=Back");
        }
        else
        {
            Server.Transfer("DepartmentwiseorQTreport.aspx?page=Back");
        }
    }
}