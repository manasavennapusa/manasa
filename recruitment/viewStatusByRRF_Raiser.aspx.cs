using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_viewStatusByRRF_Raiser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");
            bind_ApprovedRRF();
            bind_RejectedRRF();
            bind_PendingRRF();
            bind_closedRRF();
        }
        if (Request.QueryString["submit"] != null)
            SmartHr.Common.Alert("Updated Successfully");
        if (Request.QueryString["updated"] != null)
            SmartHr.Common.Alert("Re-Submitted Successfully");
        //message.InnerHtml = "";
    }
    protected void bind_ApprovedRRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Approved_RRFs_byRaiser", sqlparam);
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }
    protected void bind_closedRRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_closed_RRFs_byRaiser", sqlparam);
        grdclosedrrf.DataSource = ds;
        grdclosedrrf.DataBind();
    }
    protected void bind_RejectedRRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Rejected_RRFs_byRaiser", sqlparam);
        grdRejectedRRF.DataSource = ds;
        grdRejectedRRF.DataBind();
    }
    protected void bind_PendingRRF()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Session["empcode"].ToString();
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_Pending_RRFs_byRaiser", sqlparam);
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