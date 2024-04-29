using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_ApproveTravelFormByManager : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindGrid();
            if (Request.QueryString["approved"] != null)
            {
                SmartHr.Common.Alert("Travel Form Approved successfully");
            }
            if (Request.QueryString["rejected"] != null)
            {
                SmartHr.Common.Alert("Travel Form Rejected successfully");
            }
            if (Request.QueryString["exception"] != null)
            {
                SmartHr.Common.Alert("Travel Exception Sent successfully");
            }
            if (Request.QueryString["send"] != null)
            {
                SmartHr.Common.Alert("Travel Form sent successfully");
            }
            if (Request.QueryString["cancelled"] != null)
            {
                SmartHr.Common.Alert("Travel Form Cancelled successfully");
            }
        }

    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@appprovercode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();



        if (Request.QueryString["user"] != null)
        {
            if (Request.QueryString["user"].ToString() == "fnmgr")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getApprovedTravelformsbyAccMgr", param);
            }
            if (Request.QueryString["user"].ToString() == "mgmt")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelsForExceptionApprove", param);
            }
            if (Request.QueryString["user"].ToString() == "admin")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelsForApprovebyadmin", param);
            }
            if (Request.QueryString["user"].ToString() == "mgr")
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelsbyForApprove", param);
            }
            grid_Travel.DataSource = ds;
            grid_Travel.DataBind();


            //if (Request.QueryString["user"].ToString() == "mgmt")
            //    grid_Travel.Columns[8].Visible = false;
            //else
                grid_Travel.Columns[8].Visible = false;
            divExcepion.Visible = false;

            //if (Request.QueryString["user"].ToString() == "admin")
            //{
            //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getApproved_Rejected_Exception", param);
            //    divExcepion.Visible = true;
            //    grdException.DataSource = ds;
            //    grdException.DataBind();
            //}
        }

    }

    protected void grid_Travel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Request.QueryString["user"] != null)
        {

            string user = Request.QueryString["user"].ToString();
            if (user == "mgr")
            {
                Response.Redirect("TravelFormAtManager.aspx?travelID=" + grid_Travel.DataKeys[e.NewEditIndex].Value.ToString());
            }

            if (user == "mgmt")
            {
                string exception = ((Label)grid_Travel.Rows[e.NewEditIndex].FindControl("lblexemption")).Text;
                if (exception == "0")
                    Response.Redirect("TravelFormAtManagement.aspx?travelID=" + grid_Travel.DataKeys[e.NewEditIndex].Value.ToString());
                else
                    Response.Redirect("ApproveTravelExceptionByManagement.aspx?travelID=" + grid_Travel.DataKeys[e.NewEditIndex].Value.ToString());

            }

            if (user == "admin")
            {
                Response.Redirect("ReviewTravelFormByAdmin.aspx?travelID=" + grid_Travel.DataKeys[e.NewEditIndex].Value.ToString());
            }

            if (user == "fnmgr")
            {
                Response.Redirect("TravelFormAtFinanceManager.aspx?travelID=" + grid_Travel.DataKeys[e.NewEditIndex].Value.ToString());
            }
        }
    }
    protected void grdException_RowEditing(object sender, GridViewEditEventArgs e)
    {
        if (Request.QueryString["user"] != null)
        {
            string user = Request.QueryString["user"].ToString();

            if (user == "admin")
            {
                Response.Redirect("ReviewTravelFormByAdmin.aspx?travelID=" + grdException.DataKeys[e.NewEditIndex].Value.ToString() + "&type=excp");
            }
        }
    }
    protected void grid_Travel_PreRender(object sender, EventArgs e)
    {
        if (grid_Travel.Rows.Count > 0)
        {
            grid_Travel.UseAccessibleHeader = true;
            grid_Travel.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grdException_PreRender(object sender, EventArgs e)
    {
        if (grdException.Rows.Count > 0)
        {
            grdException.UseAccessibleHeader = true;
            grdException.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }



}


