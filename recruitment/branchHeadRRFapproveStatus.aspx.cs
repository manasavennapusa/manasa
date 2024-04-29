using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_branchHeadRRFapproveStatus : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_ApprovedRRF();
            bind_RejectedRRF();
            bind_PendingRRF();
        }
    }
    protected void bind_ApprovedRRF()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Approver2_Approved_RRF");
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }
    protected void bind_RejectedRRF()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Approver2_Rejected_RRF");
        grdRejectedRRF.DataSource = ds;
        grdRejectedRRF.DataBind();
    }
    protected void bind_PendingRRF()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Approver2_Pending_RRF");
        grdPendingRRF.DataSource = ds;
        grdPendingRRF.DataBind();
    }
}