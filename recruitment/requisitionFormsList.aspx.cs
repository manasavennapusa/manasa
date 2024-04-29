using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;

public partial class recruitment_requisitionFormsList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_ApprovedRRF();
            bind_RejectedRRF();
            bind_PendingRRF();
            bind_closedRRF();
        }

    }

    protected void bind_ApprovedRRF()
    {
        DataSet ds = new DataSet();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Approved_RRFs");
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_approvedRRFs");
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }
    protected void bind_closedRRF()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_closed_RRFs");
        grdclosedrrf.DataSource = ds;
        grdclosedrrf.DataBind();
    }
    protected void bind_RejectedRRF()
    {
        DataSet ds = new DataSet();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Rejected_RRFs");
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Rejected_RRFs_1");
        grdRejectedRRF.DataSource = ds;
        grdRejectedRRF.DataBind();
    }
    protected void bind_PendingRRF()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Pending_RRFs");
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Pending_RRFs_1");
        grdPendingRRF.DataSource = ds;
        grdPendingRRF.DataBind();
    }
    protected void grdPendingRRF_PreRender(object sender, EventArgs e)
    {
        if (grdPendingRRF.Rows.Count > 0)
        {
            grdPendingRRF.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grdRejectedRRF_PreRender(object sender, EventArgs e)
    {
        if (grdRejectedRRF.Rows.Count > 0)
        {
            grdRejectedRRF.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grdRRF_PreRender(object sender, EventArgs e)
    {
        if (grdRRF.Rows.Count > 0)
        {
            grdRRF.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grdclosedrrf_PreRender(object sender, EventArgs e)
    {
        if (grdclosedrrf.Rows.Count > 0)
        {
            grdclosedrrf.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}