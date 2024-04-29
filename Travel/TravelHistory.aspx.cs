using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_TravelHistory : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    decimal grdtotal = 0;
    decimal Prebookingtotal = 0;
    decimal PreAdvancetotal = 0;
    decimal PreAllowancetotal = 0;
    decimal Posttraveltotal = 0;
    DataTable dtable = new DataTable();

  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindGrid();
            empdetails.Visible = false;
            traveldetails.Visible = false;
            miscellaneousdetails.Visible = false;
            tripdetails.Visible = false;
            approverdetails.Visible = false;

            if (Request.QueryString["cancelled"] != null)
            {
                SmartHr.Common.Alert("Travel Form is Cancelled successfully");
            }
            if (Request.QueryString["travelID"] != null)
            {
                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);

                bindtravels(travelid);
            }

        }
    }

    protected void bindtravels(int travelid)
    {
        bindEmpDetails(travelid);
        //bindAdvanceList(travelid);
        bindApproversgrid(travelid);
        bindTripList(travelid);
        empdetails.Visible = true;
        traveldetails.Visible = true;
        miscellaneousdetails.Visible = true;
        tripdetails.Visible = true;
        approverdetails.Visible = true;
        grid_Travel.Visible = false;
        travelform.Visible = false;
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@appprovercode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();

        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelsHistorybyApprover", param);
        grid_Travel.DataSource = ds;
        grid_Travel.DataBind();

        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getClosedTravelsHistory", param);
        grd_ClosedTravels.DataSource = ds;
        grd_ClosedTravels.DataBind();
    }

    //protected void bindAdvanceList(int travelid)
    //{
    //    SqlParameter[] param = new SqlParameter[1];

    //    param[0] = new SqlParameter("@travelid", SqlDbType.Int);
    //    param[0].Value = travelid;

    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getMiscellaneous_AllowanceByTravelID", param);
    //    grid_Advance.DataSource = ds;
    //    grid_Advance.DataBind();

    //}

    protected void bindEmpDetails(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelDetailsbyTravelID", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lblempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            lblempname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
            lbldept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            lbldesingantion.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            lblgrade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            //lbllocation.Text=ds.Tables[0].Rows[0][].ToString();
            lblmgr.Text = ds.Tables[0].Rows[0]["reporting_mgr"].ToString();
            lblbank.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            lblTravelPurpose.Text = ds.Tables[0].Rows[0]["travelpurpose"].ToString();
            lblAcCode.Text = ds.Tables[0].Rows[0]["accountcode"].ToString();
        }
    }

    protected void bindTripList(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTripsByTravelID", param);
        grid_Trip.DataSource = ds;
        grid_Trip.DataBind();
        int cnt = 0;
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            if (ds.Tables[0].Rows[i]["triptype"].ToString() == "I")
                cnt++;
        }
        if (cnt == 0)
            if (Grid_Approvers.Rows.Count >= 3)
                Grid_Approvers.Rows[2].Visible = false;
    }

    protected void bindApproversgrid(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
        Grid_Approvers.DataSource = ds;
        Grid_Approvers.DataBind();
    }

    protected void grid_Travel_PreRender(object sender, EventArgs e)
    {
        if (grid_Travel.Rows.Count > 0)
        {
            grid_Travel.UseAccessibleHeader = true;
            grid_Travel.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void grid_Advance_PreRender(object sender, EventArgs e)
    {
        //if (grid_Advance.Rows.Count > 0)
        //{
        //    grid_Advance.UseAccessibleHeader = true;
        //    grid_Advance.HeaderRow.TableSection = TableRowSection.TableHeader;
        //}
    }

    protected void grid_Trip_PreRender(object sender, EventArgs e)
    {
        if (grid_Trip.Rows.Count > 0)
        {
            grid_Trip.UseAccessibleHeader = true;
            grid_Trip.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void Grid_Approvers_PreRender(object sender, EventArgs e)
    {
        if (Grid_Approvers.Rows.Count > 0)
        {
            Grid_Approvers.UseAccessibleHeader = true;
            Grid_Approvers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("TravelHistory.aspx");
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
    }

    protected void grd_prebooked_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void grdposttravel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void grid_allowancetotal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void gridAdvanceSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void grid_Expanse_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void grid_Trip_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    protected void grid_Travel_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    protected void grd_ClosedTravels_PreRender(object sender, EventArgs e)
    {
        if (grd_ClosedTravels.Rows.Count > 0)
        {
            grd_ClosedTravels.UseAccessibleHeader = true;
            grd_ClosedTravels.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}