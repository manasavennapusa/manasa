using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Travel_ApproveTravelExceptionByManagement : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
    decimal Prebookingtotal = 0;
    decimal PreAdvancetotal = 0;
    decimal PreAllowancetotal = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bind_city();
            bind_Country();
            bind_Currency();
            bind_StayType();
            bind_Tier();
            ddl_mode.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl_modeClass.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
            btnAllowaceSave.Attributes.Add("class", "btn btn-primary");
            if (Request.QueryString["travelID"] != null)
            {

                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                bindTripList(travelid);
                bindAdvanceList(travelid);
                bindApproversgrid(travelid);
                bindEmpDetails(travelid);
                bindTravelSummary();
            }
        }

    }

    //=================================================Miscellaneous Allowance Start===================================
    #region Allowance

    protected void bindAdvanceList(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getMiscellaneous_AllowanceByTravelID", param);
        grid_Advance.DataSource = ds;
        grid_Advance.DataBind();
        grid_allowancetotal.DataSource = ds;
        grid_allowancetotal.DataBind();
    }

    protected void btnAddAdvance_Click(object sender, EventArgs e)
    {
        tblAllowance.Visible = true;
        btnAddAdvance.Visible = false;
    }

    protected void grid_Advance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = "delete from tbl_travel_Miscellaneous_Allowance where id=" + grid_Advance.DataKeys[e.RowIndex].Value + "";
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (i <= 0)
        {
            SmartHr.Common.Alert("Allowance Not Deleted");

        }
        else
        {
            SmartHr.Common.Alert("Allowance Deleted successfully");
        }
        bindAdvanceList(Convert.ToInt32(Request.QueryString["travelID"]));
    }

    protected void insertMiscellaneousAllowance()
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);

            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            param[1] = new SqlParameter("@advance_desc", SqlDbType.VarChar, 1000);
            param[1].Value = txtAdvanceDesc.Text;

            param[2] = new SqlParameter("@currencytype", SqlDbType.Int);
            param[2].Value = Convert.ToInt32(ddlCurrecny.SelectedValue);

            param[3] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[3].Value = Convert.ToDecimal(txtAdvanceAmount.Text);

            param[4] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            param[4].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_Miscellaneous_Allowance", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Allowance Not Saved.");

            }
            else
            {
                SmartHr.Common.Alert("Allowance Saved successfully");
                tblAllowance.Visible = false;
                btnAddAdvance.Visible = true;
            }

        }
    }

    protected void updateMiscellaneousAllowance()
    {
        if (hfAllownaceID.Value != "")
        {
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(hfAllownaceID.Value);

            param[1] = new SqlParameter("@advance_desc", SqlDbType.VarChar, 1000);
            param[1].Value = txtAdvanceDesc.Text;

            param[2] = new SqlParameter("@currencytype", SqlDbType.Int);
            param[2].Value = Convert.ToInt32(ddlCurrecny.SelectedValue);

            param[3] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[3].Value = Convert.ToDecimal(txtAdvanceAmount.Text);

            param[4] = new SqlParameter("@updateby", SqlDbType.VarChar, 50);
            param[4].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_update_Miscellaneous_Allowance", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Allowance Not Updated.");
            }
            else
            {
                SmartHr.Common.Alert("Allowance Updated successfully");
                clearAlloance();
                hfAllownaceID.Value = "";
                tblAllowance.Visible = false;
                btnAddAdvance.Visible = true;
                btnAllowaceSave.Text = "Save";
                btnAllowaceSave.Attributes.Add("class", "btn btn-primary");
            }
        }
    }

    protected void btnAllowaceCancel_Click(object sender, EventArgs e)
    {
        tblAllowance.Visible = false;
        btnAddAdvance.Visible = true;
        clearAlloance();
        hfAllownaceID.Value = "";
        btnAllowaceSave.Text = "Save";
        btnAllowaceSave.Attributes.Add("class", "btn btn-primary");
    }

    protected void btnAllowaceSave_Click(object sender, EventArgs e)
    {

        if (hfAllownaceID.Value != "")
        {
            updateMiscellaneousAllowance();

        }
        else
        {
            insertMiscellaneousAllowance();

        }
        bindAdvanceList(Convert.ToInt32(Request.QueryString["travelID"]));
    }

    protected void grid_Advance_RowEditing(object sender, GridViewEditEventArgs e)
    {
        tblAllowance.Visible = true;
        btnAddAdvance.Visible = false;
        btnAllowaceSave.Text = "Update";
        btnAllowaceSave.Attributes.Add("class", "btn btn-warning");
        bindAllowancebyID(Convert.ToInt32(grid_Advance.DataKeys[e.NewEditIndex].Value));
    }

    protected void bindAllowancebyID(int id)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@id", SqlDbType.Int);
        param[0].Value = id;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getMiscellaneous_AllowanceByID", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            hfAllownaceID.Value = ds.Tables[0].Rows[0]["id"].ToString();
            txtAdvanceAmount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
            ddlCurrecny.SelectedValue = ds.Tables[0].Rows[0]["currencytype"].ToString();
            txtAdvanceDesc.Text = ds.Tables[0].Rows[0]["Advance_desc"].ToString();
        }
    }

    protected void clearAlloance()
    {
        txtAdvanceAmount.Text = "";
        ddlCurrecny.SelectedValue = "0";
        txtAdvanceDesc.Text = "";
    }

    #endregion Allowance
    //=================================================Miscellaneous Allowance End===================================


    //=================================================Trip Details Start============================================
    #region Trip

    protected void bindTripList(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTripsByTravelID", param);
        grid_Trip.DataSource = ds;
        grid_Trip.DataBind();
    }

    protected void btnAddTrip_Click(object sender, EventArgs e)
    {
        divTrip.Visible = true;
        btnAddTrip.Visible = false;
    }

    protected void grid_Trip_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = "delete from tbl_travel_TripDetails where tripid=" + grid_Trip.DataKeys[e.RowIndex].Value + "";
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (i <= 0)
        {
            SmartHr.Common.Alert("Trip Not Deleted");

        }
        else
        {
            SmartHr.Common.Alert("Trip Deleted successfully");
        }
        bindTripList(Convert.ToInt32(Request.QueryString["travelID"]));

    }

    protected void insertTrips()
    {

        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);

            SqlParameter[] param = new SqlParameter[15];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            if (ddl_traveltype.SelectedValue == "I")
            {
                param[1] = new SqlParameter("@fromsourcecountry", SqlDbType.Int);
                param[1].Value = Convert.ToInt32(ddl_Fromcountry.SelectedValue);

                param[2] = new SqlParameter("@fromsourcecode", SqlDbType.Int);
                param[2].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[3] = new SqlParameter("@todestinationcountry", SqlDbType.Int);
                param[3].Value = Convert.ToInt32(ddl_destinationCountry.SelectedValue);

                param[4] = new SqlParameter("@todestinationcode", SqlDbType.Int);
                param[4].Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                param[1] = new SqlParameter("@fromsourcecountry", SqlDbType.Int);
                param[1].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[2] = new SqlParameter("@fromsourcecode", SqlDbType.Int);
                param[2].Value = Convert.ToInt32(ddl_source.SelectedValue);

                param[3] = new SqlParameter("@todestinationcountry", SqlDbType.Int);
                param[3].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[4] = new SqlParameter("@todestinationcode", SqlDbType.Int);
                param[4].Value = Convert.ToInt32(ddl_destination.SelectedValue);
            }

            param[5] = new SqlParameter("@departuredate", SqlDbType.DateTime);
            param[5].Value = txtdepartdate.Text;

            param[6] = new SqlParameter("@arrivaldate", SqlDbType.DateTime);
            param[6].Value = txtarvlDate.Text;

            param[7] = new SqlParameter("@triptype", SqlDbType.VarChar, 1);
            param[7].Value = ddl_traveltype.SelectedValue;

            param[8] = new SqlParameter("@staytype", SqlDbType.Int);
            param[8].Value = Convert.ToInt32(ddl_stayType.SelectedValue);

            param[9] = new SqlParameter("@noofdays", SqlDbType.Decimal);
            param[9].Value = System.Data.SqlTypes.SqlDecimal.Null;

            param[10] = new SqlParameter("@empcomments", SqlDbType.VarChar, 200);
            param[10].Value = txtEmpCommets.Text;

            param[11] = new SqlParameter("@PTD", SqlDbType.VarChar, 30);
            param[11].Value = txtPTD.Text;

            param[12] = new SqlParameter("@GL_Code", SqlDbType.VarChar, 30);
            param[12].Value = txtGLCode.Text;

            param[13] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            param[13].Value = Session["empcode"].ToString();

            param[14] = new SqlParameter("@tripid", SqlDbType.Int);
            param[14].Direction = ParameterDirection.Output;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_trip_outputTripid", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Trip Not Saved.");

            }
            else
            {
                insert_ticketdetails(Convert.ToInt32(param[14].Value));
                SmartHr.Common.Alert("Trip Saved successfully");
            }
        }
    }

    protected void ddl_traveltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_traveltype.SelectedValue == "I")
        {
            trFromcountry.Visible = true;
            trFromcity.Visible = false;
            trToCountry.Visible = true;
            trToCity.Visible = false;
            trticket1.Visible = false;
        }
        else
        {
            trFromcountry.Visible = false;
            trFromcity.Visible = true;
            trToCountry.Visible = false;
            trToCity.Visible = true;
            trticket1.Visible = true;
        }
        bind_Mode(ddl_traveltype.SelectedValue);
    }

    protected void btnSaveTripDetails_Click(object sender, EventArgs e)
    {

        if (hftripid.Value != "")
        {
            updatetrip();
            insert_ticketdetails(Convert.ToInt32(hftripid.Value));
            SmartHr.Common.Alert("Trip Updated successfully");


            //hftripid.Value = "";
            //divTrip.Visible = false;
            //btnAddTrip.Visible = true;
            //btnSaveTripDetails.Text = "Save";
            //btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
        }
        else
        {
            //insertTrips();
            //divTrip.Visible = false;
            //btnAddTrip.Visible = true;
        }
        // clearTrips();
        //clearExpansedetails();
        bindTripList(Convert.ToInt32(Request.QueryString["travelID"]));
        bindTravelSummary();
    }

    protected void btnCancelTripDetails_Click(object sender, EventArgs e)
    {
        divTrip.Visible = false;
        btnAddTrip.Visible = true;
        clearTrips();
        clearExpansedetails();
        hftripid.Value = "";
        btnSaveTripDetails.Text = "Save";
        btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
    }

    protected void grid_Trip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        DateTime todate = Convert.ToDateTime("01/01/1900");
        DateTime fromdate = Convert.ToDateTime("01/01/1900");
        divTrip.Visible = true;
        btnAddTrip.Visible = false;
        btnSaveTripDetails.Text = "Update";
        btnSaveTripDetails.Attributes.Add("class", "btn btn-warning");
        int tripid = Convert.ToInt32(grid_Trip.DataKeys[e.NewEditIndex].Value);
        bindTripByTripID(tripid);
        bind_ticketdetails(tripid);
        for (int i = 0; i < grid_Trip.Rows.Count; i++)
            grid_Trip.Rows[i].ForeColor = System.Drawing.Color.Black;

        grid_Trip.Rows[e.NewEditIndex].ForeColor = System.Drawing.Color.Blue;

        fromdate = Convert.ToDateTime(((Label)grid_Trip.Rows[e.NewEditIndex].FindControl("lbldeptDate")).Text);
        if ((e.NewEditIndex + 1) < grid_Trip.Rows.Count)
        {
            todate = Convert.ToDateTime(((Label)grid_Trip.Rows[e.NewEditIndex + 1].FindControl("lbldeptDate")).Text);
        }
        string date = todate.ToString("MM/dd/yyyy");
        if ((fromdate.ToString("MM/dd/yyyy") != "01/01/1900") && (todate.ToString("MM/dd/yyyy") != "01/01/1900"))
        {
            TimeSpan timesp = (todate - fromdate);
            double day = Math.Truncate(timesp.TotalDays);
            double hours = timesp.TotalHours % 24;
            if (hours >= 12)
            {
                hours = 0;
                day = day + 1;
            }
            else
            {
                hours = 5;
            }
            lbllodgedays.Text = day.ToString() + "." + hours.ToString();
            lbl_ConvDays.Text = day.ToString() + "." + hours.ToString();
            lblfoodDays.Text = day.ToString() + "." + hours.ToString();
            lbloppDays.Text = day.ToString() + "." + hours.ToString();
        }
        else
        {
            lbllodgedays.Text = "0";
            lbl_ConvDays.Text = "0";
            lblfoodDays.Text = "0";
            lbloppDays.Text = "0";
        }
        bindperDayAllowances(tripid);

        string exception = ((Label)grid_Trip.Rows[e.NewEditIndex].FindControl("lblexemption")).Text;
        if (exception == "True")
        {
            btnAproveExceptionm.Visible = true;
            btnRejectExceptionm.Visible = true;
        }
        else
        {
            btnAproveExceptionm.Visible = false;
            btnRejectExceptionm.Visible = false;
        }
    }

    protected void bindTripByTripID(int tripid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@tripid", SqlDbType.Int);
        param[0].Value = tripid;
        ds.Clear();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTripByTripID", param);
        if (ds.Tables[0].Rows.Count > 0)
        {
            hftripid.Value = ds.Tables[0].Rows[0]["tripid"].ToString();
            txtdepartdate.Text = String.Format("{0:dd MMM yyyy}", Convert.ToDateTime(ds.Tables[0].Rows[0]["departuredate"]));
            txtdeparttime.Text = ds.Tables[0].Rows[0]["departuretime"].ToString();
            if (ds.Tables[0].Rows[0]["triptype"].ToString() == "I")
            {
                ddl_Fromcountry.SelectedValue = ds.Tables[0].Rows[0]["fromsourcecountry"].ToString();
                ddl_destinationCountry.SelectedValue = ds.Tables[0].Rows[0]["todestinationcountry"].ToString();
                trFromcountry.Visible = true;
                trFromcity.Visible = false;
                trToCountry.Visible = true;
                trToCity.Visible = false;
            }
            else
            {
                ddl_source.SelectedValue = ds.Tables[0].Rows[0]["fromsourcecode"].ToString();
                ddl_destination.SelectedValue = ds.Tables[0].Rows[0]["todestinationcode"].ToString();
                trFromcountry.Visible = false;
                trFromcity.Visible = true;
                trToCountry.Visible = false;
                trToCity.Visible = true;
            }

            ddl_traveltype.SelectedValue = ds.Tables[0].Rows[0]["triptype"].ToString();
            txtarvlDate.Text = String.Format("{0:dd MMM yyyy}", Convert.ToDateTime(ds.Tables[0].Rows[0]["arrivaldate"]));
            txtArvlTime.Text = ds.Tables[0].Rows[0]["arrivaltime"].ToString();
            ddl_stayType.SelectedValue = ds.Tables[0].Rows[0]["staytype"].ToString();
            txtEmpCommets.Text = ds.Tables[0].Rows[0]["empcomments"].ToString();
            txtPTD.Text = ds.Tables[0].Rows[0]["PTD"].ToString();
            txtGLCode.Text = ds.Tables[0].Rows[0]["GL_Code"].ToString();
            bind_Mode(ds.Tables[0].Rows[0]["triptype"].ToString());
        }
    }

    protected void updatetrip()
    {

        if (hftripid.Value != "")
        {
            SqlParameter[] param = new SqlParameter[16];

            param[0] = new SqlParameter("@tripid", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(hftripid.Value);

            if (ddl_traveltype.SelectedValue == "I")
            {
                param[1] = new SqlParameter("@fromsourcecountry", SqlDbType.Int);
                param[1].Value = ddl_Fromcountry.SelectedValue;

                param[2] = new SqlParameter("@fromsourcecode", SqlDbType.Int);
                param[2].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[3] = new SqlParameter("@todestinationcountry", SqlDbType.Int);
                param[3].Value = ddl_destinationCountry.SelectedValue;

                param[4] = new SqlParameter("@todestinationcode", SqlDbType.Int);
                param[4].Value = System.Data.SqlTypes.SqlInt32.Null;
            }
            else
            {
                param[1] = new SqlParameter("@fromsourcecountry", SqlDbType.Int);
                param[1].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[2] = new SqlParameter("@fromsourcecode", SqlDbType.Int);
                param[2].Value = ddl_source.SelectedValue;

                param[3] = new SqlParameter("@todestinationcountry", SqlDbType.Int);
                param[3].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[4] = new SqlParameter("@todestinationcode", SqlDbType.Int);
                param[4].Value = ddl_destination.SelectedValue;
            }

            param[5] = new SqlParameter("@departuredate", SqlDbType.DateTime);
            param[5].Value = txtdepartdate.Text;

            param[6] = new SqlParameter("@arrivaldate", SqlDbType.DateTime);
            param[6].Value = txtarvlDate.Text;

            param[7] = new SqlParameter("@departuretime", SqlDbType.VarChar, 10);
            param[7].Value = txtdeparttime.Text;

            param[8] = new SqlParameter("@arrivaltime", SqlDbType.VarChar, 10);
            param[8].Value = txtArvlTime.Text;

            param[9] = new SqlParameter("@triptype", SqlDbType.VarChar, 1);
            param[9].Value = ddl_traveltype.SelectedValue;

            param[10] = new SqlParameter("@staytype", SqlDbType.Int);
            param[10].Value = ddl_stayType.SelectedValue;

            param[11] = new SqlParameter("@noofdays", SqlDbType.Decimal);
            param[11].Value = System.Data.SqlTypes.SqlDecimal.Null;

            param[12] = new SqlParameter("@empcomments", SqlDbType.VarChar, 200);
            param[12].Value = txtEmpCommets.Text; ;

            param[13] = new SqlParameter("@PTD", SqlDbType.VarChar, 30);
            param[13].Value = txtPTD.Text;

            param[14] = new SqlParameter("@GL_Code", SqlDbType.VarChar, 30);
            param[14].Value = txtGLCode.Text;

            param[15] = new SqlParameter("@updateby", SqlDbType.VarChar, 50);
            param[15].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_trip]", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Trip Not Updated Successfully");

            }
            else
            {


            }

        }
    }

    protected void clearTrips()
    {

        txtdepartdate.Text = "";
        txtdeparttime.Text = "";
        ddl_Fromcountry.SelectedValue = "0";
        ddl_destinationCountry.SelectedValue = "0";
        ddl_source.SelectedValue = "0";
        ddl_destination.SelectedValue = "0";
        ddl_traveltype.SelectedValue = "0";
        txtarvlDate.Text = "";
        txtArvlTime.Text = "";
        ddl_stayType.SelectedValue = "0";
        txtEmpCommets.Text = "";
        txtPTD.Text = "";
        txtGLCode.Text = "";
    }

    protected void rbtnl_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl.SelectedIndex == 0)
        {
            if (ddl_traveltype.SelectedValue == "I")
                trticket1.Visible = false;
            else
                trticket1.Visible = true;

            trticket2.Visible = true;
            trticket3.Visible = true;
            trticket4.Visible = true;
            trticket5.Visible = true;
            trticket6.Visible = true;
        }
        else
        {
            trticket1.Visible = false;
            trticket2.Visible = false;
            trticket3.Visible = false;
            trticket4.Visible = false;
            trticket5.Visible = false;
            trticket6.Visible = false;
        }

    }

    protected void rbtnl_ticketAdv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_ticketAdv.SelectedIndex == 0)
        {
            trticketadv.Visible = true;
        }
        else
        {
            trticketadv.Visible = false;
        }
    }

    protected void rbtnl_lodge_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_lodge.SelectedIndex == 0)
        {
            trlodge.Visible = true;
            trlodge2.Visible = true;
        }
        else
        {
            trlodge.Visible = false;
            trlodge2.Visible = false;
        }
    }

    protected void rbtnl_lodgeAdv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_lodgeAdv.SelectedIndex == 0)
        {
            trlodgeAdv.Visible = true;
        }
        else
        {
            trlodgeAdv.Visible = false;
        }
    }

    protected void rbtnl_conv_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_conv.SelectedIndex == 0)
        {
            trconv.Visible = true;
        }
        else
        {
            trconv.Visible = false;
        }
    }

    protected void rbtnl_oop_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_oop.SelectedIndex == 0)
        {
            troop.Visible = true;
        }
        else
        {
            troop.Visible = false;
        }
    }

    protected void rbtnl_food_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_food.SelectedIndex == 0)
        {

            trfood.Visible = true;
        }
        else
        {
            trfood.Visible = false;
        }
    }

    #endregion Trip
    //=================================================Trip Details End============================================


    //=================================================Travel Details Start============================================

    protected void btnEditTravel_Click(object sender, EventArgs e)
    {
        txt_travelpurpose.Enabled = true;
        btnTravelCancel.Visible = true;
        btnupdateTravel.Visible = true;
        btnEditTravel.Visible = false;
    }

    protected void btnTravelCancel_Click(object sender, EventArgs e)
    {
        txt_travelpurpose.Enabled = false;
        btnTravelCancel.Visible = false;
        btnupdateTravel.Visible = false;
        btnEditTravel.Visible = true;
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            bindEmpDetails(travelid);
        }
    }

    protected void btnupdateTravel_Click(object sender, EventArgs e)
    {
        updateTravelPurpose();

    }

    protected void updateTravelPurpose()
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            param[1] = new SqlParameter("@travelpurpose", SqlDbType.VarChar, 100);
            param[1].Value = txt_travelpurpose.Text;

            param[2] = new SqlParameter("@updatedby", SqlDbType.VarChar, 50);
            param[2].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_updateTravlpurpose", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Not Updated");
            }
            else
            {
                SmartHr.Common.Alert("Updated successfully");
                txt_travelpurpose.Enabled = false;
                btnTravelCancel.Visible = false;
                btnupdateTravel.Visible = false;
                btnEditTravel.Visible = true;
                bindEmpDetails(travelid);
            }
        }
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
            lbllocation.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lblmgr.Text = ds.Tables[0].Rows[0]["reporting_mgr"].ToString();
            lblbank.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            txt_travelpurpose.Text = ds.Tables[0].Rows[0]["travelpurpose"].ToString();
            lblAcCode.Text = ds.Tables[0].Rows[0]["accountcode"].ToString();
            lblcostcenter.Text = ds.Tables[0].Rows[0]["cost_center_name"].ToString();
            lblbank_ac_no.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
        }
    }

    //=================================================Travel Details End============================================


    //=============================================Bind dropdown Controls===================================
    protected void bind_city()
    {
        sqlstr = "select cid,city from tbl_intranet_city ";
        DataSet ds5 = new DataSet();
        ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_source.DataSource = ds5;
        ddl_source.DataTextField = "city";
        ddl_source.DataValueField = "cid";
        ddl_source.DataBind();
        ddl_source.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_destination.DataSource = ds5;
        ddl_destination.DataTextField = "city";
        ddl_destination.DataValueField = "cid";
        ddl_destination.DataBind();
        ddl_destination.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_Country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_Fromcountry.DataTextField = "countryname";
        ddl_Fromcountry.DataValueField = "cid";
        ddl_Fromcountry.DataSource = ds3;
        ddl_Fromcountry.DataBind();
        ddl_Fromcountry.Items.Insert(0, new ListItem("--select--", "0"));

        ddl_destinationCountry.DataTextField = "countryname";
        ddl_destinationCountry.DataValueField = "cid";
        ddl_destinationCountry.DataSource = ds3;
        ddl_destinationCountry.DataBind();
        ddl_destinationCountry.Items.Insert(0, new ListItem("--select--", "0"));
    }

    protected void bind_StayType()
    {
        string sqlstr = "select id,staytype  from tbl_travel_staytype   ";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_stayType.DataTextField = "staytype";
        ddl_stayType.DataValueField = "id";
        ddl_stayType.DataSource = ds3;
        ddl_stayType.DataBind();
        ddl_stayType.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_Currency()
    {
        string sqlstr = "select distinct cid,currencycode  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlCurrecny.DataTextField = "currencycode";
        ddlCurrecny.DataValueField = "cid";
        ddlCurrecny.DataSource = ds3;
        ddlCurrecny.DataBind();
        ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlCurrecny.SelectedValue = "98";
        var itemIndex = ddlCurrecny.SelectedIndex;
        var item = ddlCurrecny.Items[itemIndex];
        ddlCurrecny.Items.RemoveAt(itemIndex);
        ddlCurrecny.Items.Insert(1, new ListItem(item.Text, item.Value));

        ddl_fareCurrecny.DataTextField = "currencycode";
        ddl_fareCurrecny.DataValueField = "cid";
        ddl_fareCurrecny.DataSource = ds3;
        ddl_fareCurrecny.DataBind();
        ddl_fareCurrecny.SelectedValue = "98";
        var itemIndex2 = ddl_fareCurrecny.SelectedIndex;
        var item2 = ddl_fareCurrecny.Items[itemIndex2];
        ddl_fareCurrecny.Items.RemoveAt(itemIndex2);
        ddl_fareCurrecny.Items.Insert(0, new ListItem(item2.Text, item2.Value));

        ddl_stayCurrency.DataTextField = "currencycode";
        ddl_stayCurrency.DataValueField = "cid";
        ddl_stayCurrency.DataSource = ds3;
        ddl_stayCurrency.DataBind();
        ddl_stayCurrency.SelectedValue = "98";
        var itemIndex3 = ddl_stayCurrency.SelectedIndex;
        var item3 = ddl_stayCurrency.Items[itemIndex3];
        ddl_stayCurrency.Items.RemoveAt(itemIndex3);
        ddl_stayCurrency.Items.Insert(0, new ListItem(item3.Text, item3.Value));

    }

    protected void bind_Tier()
    {
        string sqlstr = "select tierid,tier  from tbl_travel_Tier   ";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_tier.DataTextField = "tier";
        ddl_tier.DataValueField = "tierid";
        ddl_tier.DataSource = ds3;
        ddl_tier.DataBind();
        ddl_tier.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_Mode(string traveltype)
    {
        string sqlstr = "select travelmodeId,travelmode  from tbl_travel_travelmode where traveltype='" + traveltype + "'";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_mode.DataTextField = "travelmode";
        ddl_mode.DataValueField = "travelmodeId";
        ddl_mode.DataSource = ds3;
        ddl_mode.DataBind();
        ddl_mode.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_ModeClass(int mode)
    {
        string sqlstr = "select travelclassid,travelmodeclass  from tbl_travel_TravelModeClass where travelmodeId=" + mode + "";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_modeClass.DataTextField = "travelmodeclass";
        ddl_modeClass.DataValueField = "travelclassid";
        ddl_modeClass.DataSource = ds3;
        ddl_modeClass.DataBind();
        ddl_modeClass.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    //=============================================End=============================================

    //=================================================Expanse Details Start============================================
    protected void ddl_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_ModeClass(Convert.ToInt32(ddl_mode.SelectedValue));
    }

    protected void insert_ticketdetails(int tripid)
    {
        if (tripid != 0)
        {

            SqlParameter[] param = new SqlParameter[39];

            param[0] = new SqlParameter("@tripid", SqlDbType.Int);
            param[0].Value = tripid;
            //=============================Ticket===============================================
            param[1] = new SqlParameter("@istickedbooked", SqlDbType.Bit);
            param[1].Value = rbtnl.SelectedValue;

            if (rbtnl.SelectedValue == "True")
            {
                if (ddl_traveltype.SelectedValue == "D")
                {
                    param[2] = new SqlParameter("@tierid", SqlDbType.Int);
                    param[2].Value = Convert.ToInt32(ddl_tier.SelectedValue);
                }
                else
                {
                    param[2] = new SqlParameter("@tierid", SqlDbType.Int);
                    param[2].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                param[3] = new SqlParameter("@travelmodeId", SqlDbType.Int);
                param[3].Value = Convert.ToInt32(ddl_mode.SelectedValue);

                param[4] = new SqlParameter("@travelclassid", SqlDbType.Int);
                param[4].Value = Convert.ToInt32(ddl_modeClass.SelectedValue);

                param[5] = new SqlParameter("@travel_currencycode", SqlDbType.Int);
                param[5].Value = Convert.ToInt32(ddl_fareCurrecny.SelectedValue);

                param[6] = new SqlParameter("@travel_fare", SqlDbType.Decimal);
                param[6].Value = Convert.ToDecimal(txtticketfair.Text == "" ? "0" : txtticketfair.Text);

                param[7] = new SqlParameter("@ticketuploadpath", SqlDbType.VarChar, 100);
                param[7].Value = uploadticket();
            }
            else
            {
                param[2] = new SqlParameter("@tierid", SqlDbType.Int);
                param[2].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[3] = new SqlParameter("@travelmodeId", SqlDbType.Int);
                param[3].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[4] = new SqlParameter("@travelclassid", SqlDbType.Int);
                param[4].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[5] = new SqlParameter("@travel_currencycode", SqlDbType.Int);
                param[5].Value = System.Data.SqlTypes.SqlInt32.Null;

                param[6] = new SqlParameter("@travel_fare", SqlDbType.Decimal);
                param[6].Value = System.Data.SqlTypes.SqlDecimal.Null;

                param[7] = new SqlParameter("@ticketuploadpath", SqlDbType.VarChar, 100);
                param[7].Value = System.Data.SqlTypes.SqlChars.Null;
            }

            param[8] = new SqlParameter("@traveladvancegiven", SqlDbType.Bit);
            param[8].Value = rbtnl_ticketAdv.SelectedValue;

            if (rbtnl_ticketAdv.SelectedValue == "True")
            {
                param[9] = new SqlParameter("@traveladvanceamount", SqlDbType.Decimal);
                param[9].Value = Convert.ToDecimal(txtticketAdv.Text == "" ? "0" : txtticketAdv.Text);
            }
            else
            {
                param[9] = new SqlParameter("@traveladvanceamount", SqlDbType.Decimal);
                param[9].Value = System.Data.SqlTypes.SqlDecimal.Null;
            }
            //=============================Stay===============================================
            param[10] = new SqlParameter("@isstaybooked", SqlDbType.Bit);
            param[10].Value = rbtnl_lodge.SelectedValue;

            param[11] = new SqlParameter("@stay_currencycode", SqlDbType.Int);
            param[11].Value = ddl_stayCurrency.SelectedValue;

            if (rbtnl_lodge.SelectedValue == "True")
            {
                param[12] = new SqlParameter("@stay_fare", SqlDbType.Decimal);
                param[12].Value = Convert.ToDecimal(txtlodgefare.Text == "" ? "0" : txtlodgefare.Text);

                param[13] = new SqlParameter("@stay_address", SqlDbType.VarChar, 1000);
                param[13].Value = txtLodgeAddress.Text;

            }
            else
            {
                param[12] = new SqlParameter("@stay_fare", SqlDbType.Decimal);
                param[12].Value = System.Data.SqlTypes.SqlDecimal.Null;

                param[13] = new SqlParameter("@stay_address", SqlDbType.VarChar, 1000);
                param[13].Value = System.Data.SqlTypes.SqlChars.Null;
            }


            param[14] = new SqlParameter("@stayadvancegiven", SqlDbType.Bit);
            param[14].Value = rbtnl_lodgeAdv.SelectedValue;

            if (rbtnl_lodgeAdv.SelectedValue == "True")
            {
                param[15] = new SqlParameter("@stayadvanceamount", SqlDbType.Decimal);
                param[15].Value = Convert.ToDecimal(txt_lodgeAdv.Text == "" ? "0" : txt_lodgeAdv.Text);
            }
            else
            {
                param[15] = new SqlParameter("@stayadvanceamount", SqlDbType.Decimal);
                param[15].Value = System.Data.SqlTypes.SqlDecimal.Null;
            }

            param[16] = new SqlParameter("@staytotalfair_actual", SqlDbType.Decimal);
            param[16].Value = Convert.ToDecimal(lbllodgetotal.Text == "" ? "0" : lbllodgetotal.Text);

            param[17] = new SqlParameter("@stayperdayfair_actual", SqlDbType.Decimal);
            param[17].Value = Convert.ToDecimal(lbllodge.Text == "" ? "0" : lbllodge.Text);

            param[18] = new SqlParameter("@staynoofdays", SqlDbType.Decimal);
            param[18].Value = Convert.ToDecimal(lbllodgedays.Text == "" ? "0" : lbllodgedays.Text);

            //=============================Conveyance===============================================
            param[19] = new SqlParameter("@conveyadvancegiven", SqlDbType.Bit);
            param[19].Value = rbtnl_conv.SelectedValue;

            if (rbtnl_conv.SelectedValue == "True")
            {
                param[20] = new SqlParameter("@converadvanceamount", SqlDbType.Decimal);
                param[20].Value = Convert.ToDecimal(txtconvAdvance.Text == "" ? "0" : txtconvAdvance.Text);
            }
            else
            {
                param[20] = new SqlParameter("@converadvanceamount", SqlDbType.Decimal);
                param[20].Value = System.Data.SqlTypes.SqlDecimal.Null;
            }

            param[21] = new SqlParameter("@convey_no_of_days", SqlDbType.Decimal);
            param[21].Value = Convert.ToDecimal(lbl_ConvDays.Text == "" ? "0" : lbl_ConvDays.Text);

            param[22] = new SqlParameter("@convey_amount", SqlDbType.Decimal);
            param[22].Value = Convert.ToDecimal(txtconvAdvance.Text == "" ? "0" : txtconvAdvance.Text);

            //=============================OOP===============================================

            param[23] = new SqlParameter("@oopadvancegiven", SqlDbType.Bit);
            param[23].Value = rbtnl_oop.SelectedValue;

            if (rbtnl_oop.SelectedValue == "True")
            {
                param[24] = new SqlParameter("@oopadvanceamount", SqlDbType.Decimal);
                param[24].Value = Convert.ToDecimal(txtoopAdv.Text == "" ? "0" : txtoopAdv.Text);
            }
            else
            {
                param[24] = new SqlParameter("@oopadvanceamount", SqlDbType.Decimal);
                param[24].Value = System.Data.SqlTypes.SqlDecimal.Null;
            }

            param[25] = new SqlParameter("@ooptotalfair_actual", SqlDbType.Decimal);
            param[25].Value = Convert.ToDecimal(lblopptotal.Text == "" ? "0" : lblopptotal.Text);

            param[26] = new SqlParameter("@oop_no_of_days", SqlDbType.Decimal);
            param[26].Value = Convert.ToDecimal(lbloppDays.Text == "" ? "0" : lbloppDays.Text);

            param[27] = new SqlParameter("@oopperdayfair_actual", SqlDbType.Decimal);
            param[27].Value = Convert.ToDecimal(lbloop.Text == "" ? "0" : lbloop.Text);

            //=============================FOOD===============================================
            param[28] = new SqlParameter("@mealsadvancegiven", SqlDbType.Bit);
            param[28].Value = rbtnl_food.SelectedValue;

            if (rbtnl_food.SelectedValue == "True")
            {
                param[29] = new SqlParameter("@mealsadvanceamount", SqlDbType.Decimal);
                param[29].Value = Convert.ToDecimal(txtFoodAdv.Text == "" ? "0" : txtFoodAdv.Text);
            }
            else
            {
                param[29] = new SqlParameter("@mealsadvanceamount", SqlDbType.Decimal);
                param[29].Value = System.Data.SqlTypes.SqlDecimal.Null;
            }


            param[30] = new SqlParameter("@mealstotalfair_actual", SqlDbType.Decimal);
            param[30].Value = Convert.ToDecimal(lblfoodtotal.Text == "" ? "0" : lblfoodtotal.Text);

            param[31] = new SqlParameter("@meals_no_of_days", SqlDbType.Decimal);
            param[31].Value = Convert.ToDecimal(lblfoodDays.Text == "" ? "0" : lblfoodDays.Text);

            param[32] = new SqlParameter("@mealsperdayfair_actual", SqlDbType.Decimal);
            param[32].Value = Convert.ToDecimal(lblfood.Text == "" ? "0" : lblfood.Text);

            //=============================comments===============================================
            param[33] = new SqlParameter("@exemption_raised", SqlDbType.Bit);
            param[33].Value = chkException.Checked;

            param[34] = new SqlParameter("@admin_comments", SqlDbType.VarChar, 200);
            param[34].Value = txtAdminComments.Text;

            param[35] = new SqlParameter("@management_comments", SqlDbType.VarChar, 200);
            param[35].Value = txt_mgmtComments.Text;

            param[36] = new SqlParameter("@boardingpasscollected", SqlDbType.Bit);
            param[36].Value = chkpass.Checked;

            param[37] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            param[37].Value = Session["empcode"].ToString();

            param[38] = new SqlParameter("@ticketid", SqlDbType.Int);
            param[38].Direction = ParameterDirection.Output;


            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insertORupdate_TicketDetails", param);
            int ticketid = 0;
            if (i > 0)
            {
                ticketid = Convert.ToInt32(param[38].Value);
                if (chkException.Checked == true)
                {
                    insertException(ticketid);
                }

            }

            //if (i <= 0)
            //{
            //    SmartHr.Common.Alert("Trip Not Saved.");
            //}
            //else
            //{
            //    SmartHr.Common.Alert("Trip Saved successfully");
            //}
        }
    }

    protected void bind_ticketdetails(int tripid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@tripid", SqlDbType.Int);
        param[0].Value = tripid;

        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTicketDetailsbytripid", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            hftickerid.Value = ds.Tables[0].Rows[0]["ticketid"].ToString();
            rbtnl.SelectedValue = ds.Tables[0].Rows[0]["istickedbooked"].ToString();
            bind_Mode(ddl_traveltype.SelectedValue);
            if (ds.Tables[0].Rows[0]["istickedbooked"].ToString() == "True")
            {
                if (ddl_traveltype.SelectedValue == "D")
                {
                    trticket1.Visible = true;
                    trticket6.Visible = false;
                    ddl_tier.SelectedValue = ds.Tables[0].Rows[0]["tierid"].ToString();

                }
                else
                {
                    trticket1.Visible = false;
                    trticket6.Visible = true;
                }
                ddl_mode.SelectedValue = ds.Tables[0].Rows[0]["travelmodeId"].ToString();
                bind_ModeClass(Convert.ToInt32(ddl_mode.SelectedValue));
                ddl_modeClass.SelectedValue = ds.Tables[0].Rows[0]["travelclassid"].ToString();
                ddl_fareCurrecny.SelectedValue = ds.Tables[0].Rows[0]["travel_currencycode"].ToString();
                txtticketfair.Text = ds.Tables[0].Rows[0]["travel_fare"].ToString();
                trticket2.Visible = true;
                trticket3.Visible = true;
                trticket4.Visible = true;
                trticket5.Visible = true;
            }
            else
            {
                trticket1.Visible = false;
                trticket2.Visible = false;
                trticket3.Visible = false;
                trticket4.Visible = false;
                trticket5.Visible = false;
            }

            rbtnl_ticketAdv.SelectedValue = ds.Tables[0].Rows[0]["traveladvancegiven"].ToString();

            if (ds.Tables[0].Rows[0]["traveladvancegiven"].ToString() == "True")
            {
                txtticketAdv.Text = ds.Tables[0].Rows[0]["traveladvanceamount"].ToString();
                trticketadv.Visible = true;
            }
            else
            {
                trticketadv.Visible = false;
            }
            //=============================Stay===============================================
            rbtnl_lodge.SelectedValue = ds.Tables[0].Rows[0]["isstaybooked"].ToString();
            ddl_stayCurrency.SelectedValue = ds.Tables[0].Rows[0]["stay_currencycode"].ToString();
            if (ds.Tables[0].Rows[0]["isstaybooked"].ToString() == "True")
            {

                txtlodgefare.Text = ds.Tables[0].Rows[0]["stay_fare"].ToString();
                txtLodgeAddress.Text = ds.Tables[0].Rows[0]["stay_address"].ToString();
                trlodge.Visible = true;
                trlodge2.Visible = true;
            }
            else
            {
                trlodge.Visible = false;
                trlodge2.Visible = false;
            }

            rbtnl_lodgeAdv.SelectedValue = ds.Tables[0].Rows[0]["stayadvancegiven"].ToString();

            if (ds.Tables[0].Rows[0]["stayadvancegiven"].ToString() == "True")
            {
                txt_lodgeAdv.Text = ds.Tables[0].Rows[0]["stayadvanceamount"].ToString();
                trlodgeAdv.Visible = true;
            }
            else
            {
                trlodgeAdv.Visible = false;
            }
            lbllodgetotal.Text = ds.Tables[0].Rows[0]["staytotalfair_actual"].ToString();
            lbllodge.Text = ds.Tables[0].Rows[0]["stayperdayfair_actual"].ToString();
            lbllodgedays.Text = ds.Tables[0].Rows[0]["staynoofdays"].ToString();


            //=============================Conveyance===============================================
            rbtnl_conv.SelectedValue = ds.Tables[0].Rows[0]["conveyadvancegiven"].ToString();

            if (ds.Tables[0].Rows[0]["conveyadvancegiven"].ToString() == "True")
            {
                txtconvAdvance.Text = ds.Tables[0].Rows[0]["converadvanceamount"].ToString();
                trconv.Visible = true;
            }
            else
            {
                trconv.Visible = false;
            }
            lbl_ConvDays.Text = ds.Tables[0].Rows[0]["convey_no_of_days"].ToString();
            txtconvAdvance.Text = ds.Tables[0].Rows[0]["convey_amount"].ToString();

            //=============================OOP===============================================

            rbtnl_oop.SelectedValue = ds.Tables[0].Rows[0]["oopadvancegiven"].ToString();


            if (ds.Tables[0].Rows[0]["oopadvancegiven"].ToString() == "True")
            {
                txtoopAdv.Text = ds.Tables[0].Rows[0]["oopadvanceamount"].ToString();

                troop.Visible = true;
            }
            else
            {
                troop.Visible = false;
            }
            lblopptotal.Text = ds.Tables[0].Rows[0]["ooptotalfair_actual"].ToString();
            lbloppDays.Text = ds.Tables[0].Rows[0]["oop_no_of_days"].ToString();
            lbloop.Text = ds.Tables[0].Rows[0]["oopperdayfair_actual"].ToString();

            //=============================FOOD===============================================
            rbtnl_food.SelectedValue = ds.Tables[0].Rows[0]["mealsadvancegiven"].ToString();

            if (ds.Tables[0].Rows[0]["mealsadvancegiven"].ToString() == "True")
            {
                txtFoodAdv.Text = ds.Tables[0].Rows[0]["mealsadvanceamount"].ToString();
                trfood.Visible = true;
            }
            else
            {
                trfood.Visible = false;
            }

            lblfoodtotal.Text = ds.Tables[0].Rows[0]["mealstotalfair_actual"].ToString();
            lblfoodDays.Text = ds.Tables[0].Rows[0]["meals_no_of_days"].ToString();
            lblfood.Text = ds.Tables[0].Rows[0]["mealsperdayfair_actual"].ToString();

            //=============================Comments===============================================
            chkException.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["exemption_raised"]);
            chkpass.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["boardingpasscollected"]);
            txtAdminComments.Text = ds.Tables[0].Rows[0]["admin_comments"].ToString();
            txt_mgmtComments.Text = ds.Tables[0].Rows[0]["management_comments"].ToString();

        }
        else
        {
            clearExpansedetails();
        }

    }

    protected string uploadticket()
    {
        string defaultUpload1 = "";
        if (fupTicket.HasFile)
        {

            string strFileName;
            string file_name = System.DateTime.Now.GetHashCode().ToString();
            strFileName = fupTicket.FileName;
            try
            {
                fupTicket.PostedFile.SaveAs(Server.MapPath("~/Travel/traveluploads/" + file_name + "_" + strFileName));
                defaultUpload1 = file_name + "_" + strFileName;//Server.MapPath("~//upload//employeedocuments//" + strFileName);
            }
            catch (Exception exc)
            {
            }
            return defaultUpload1;
        }
        else
        {
            defaultUpload1 = "";
            return defaultUpload1;
        }

    }

    protected void clearExpansedetails()
    {
        rbtnl.SelectedIndex = -1;
        ddl_tier.SelectedValue = "0";
        ddl_mode.SelectedValue = "0";
        ddl_modeClass.SelectedValue = "0";
        ddl_fareCurrecny.SelectedIndex = 0;
        txtticketfair.Text = "";
        rbtnl_ticketAdv.SelectedIndex = -1;
        rbtnl_lodge.SelectedIndex = -1;
        ddl_stayCurrency.SelectedIndex = 0;
        txtlodgefare.Text = "";
        txtLodgeAddress.Text = "";
        rbtnl_lodgeAdv.SelectedIndex = -1;
        txt_lodgeAdv.Text = "";
        lbllodgetotal.Text = "";
        lbllodge.Text = "";
        lbllodgedays.Text = "";
        rbtnl_conv.SelectedIndex = -1;
        txtconvAdvance.Text = "";
        lbl_ConvDays.Text = "";
        txtconvAdvance.Text = "";
        rbtnl_oop.SelectedIndex = 1;
        txtoopAdv.Text = "";
        lblopptotal.Text = "";
        lbloppDays.Text = "";
        lbloop.Text = "";
        rbtnl_oop.SelectedIndex = -1;
        txtFoodAdv.Text = "";
        lblfoodtotal.Text = "";
        lblfoodDays.Text = "";
        lblfood.Text = "";
        chkException.Checked = false;
        chkpass.Checked = false;
        txtAdminComments.Text = "";
        txt_mgmtComments.Text = "";
        trticket1.Visible = false;
        trticket1.Visible = false;
        trticket2.Visible = false;
        trticket3.Visible = false;
        trticket4.Visible = false;
        trticket5.Visible = false;
        trticket6.Visible = false;

        trticketadv.Visible = false;
        trlodge.Visible = false;
        trlodge2.Visible = false;
        trlodgeAdv.Visible = false;
        trconv.Visible = false;
        troop.Visible = false;
        trfood.Visible = false;
    }

    //=================================================Expanse Details End============================================

    protected void btnCalculateSummary_Click(object sender, EventArgs e)
    {
        bindTravelSummary();
    }

    protected void bindTravelSummary()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(Request.QueryString["travelID"]);
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelSummary", param);
        if (ds.Tables.Count > 0)
            gridAdvanceSummary.DataSource = ds.Tables[0];
        gridAdvanceSummary.DataBind();

        if (ds.Tables.Count > 1)
            grd_prebooked.DataSource = ds.Tables[1];
        grd_prebooked.DataBind();

        decimal Prebooking = 0;
        decimal PreAdvance = 0;
        decimal PreAllowance = 0;
        if (grd_prebooked.Rows.Count > 0)
        {
            Prebooking = Convert.ToDecimal(((Label)grd_prebooked.FooterRow.FindControl("lbltotalINRSTD")).Text);
        }
        if (gridAdvanceSummary.Rows.Count > 0)
        {
            PreAdvance = Convert.ToDecimal(((Label)gridAdvanceSummary.FooterRow.FindControl("lbltotalINRSTD")).Text);
        }
        if (grid_allowancetotal.Rows.Count > 0)
        {
            PreAllowance = Convert.ToDecimal(((Label)grid_allowancetotal.FooterRow.FindControl("lbltotalINRSTD")).Text);
        }
        txtEstimation.Text = Math.Round((Prebooking + PreAdvance + PreAllowance), 2).ToString();
        if (ds.Tables.Count == 3)
            if (ds.Tables[2].Rows.Count > 0)
            {
                txtFinalAmountGiven1.Text = ds.Tables[2].Rows[0]["INRSTD"].ToString();
                ddl_finalCurrency.SelectedValue = ds.Tables[2].Rows[0]["final_currencycode"].ToString();
                txtFinalAmountGiven2.Text = ds.Tables[2].Rows[0]["final_amount"].ToString();
            }

    }

    protected void bindperDayAllowances(int tripid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@tripid", SqlDbType.Int);
        param[0].Value = tripid;


        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getperDayAllowances", param);

        if (ds.Tables[0].Rows.Count > 0)
        {
            lbllodge.Text = ds.Tables[0].Rows[0]["Stay"].ToString();
            lblfood.Text = ds.Tables[0].Rows[0]["Meals"].ToString();
            lbloop.Text = ds.Tables[0].Rows[0]["OOP"].ToString();
            if (lbllodge.Text == "")
                lbllodge.Text = "0";
            if (lblfood.Text == "")
                lblfood.Text = "0";
            if (lbloop.Text == "")
                lbloop.Text = "0";
        }
        lbllodgetotal.Text = Math.Round(Convert.ToDecimal(lbllodgedays.Text) * Convert.ToDecimal(lbllodge.Text), 2).ToString();
        lblfoodtotal.Text = Math.Round(Convert.ToDecimal(lblfoodDays.Text) * Convert.ToDecimal(lblfood.Text), 2).ToString();
        lblopptotal.Text = Math.Round(Convert.ToDecimal(lbloppDays.Text) * Convert.ToDecimal(lbloop.Text), 2).ToString();

    }

    protected void grd_prebooked_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            Prebookingtotal = Prebookingtotal + rowtotal;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbltotalINRSTD");
            lbl.Text = Math.Round(Prebookingtotal, 2).ToString();
        }
    }

    protected decimal getCurrecnyRate(int currencycode, DateTime traveldate)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@traveldate", SqlDbType.Date);
        param[0].Value = traveldate;

        param[1] = new SqlParameter("@currecnycode", SqlDbType.Int);
        param[1].Value = currencycode;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getCurrencyRate", param);
        if (ds.Tables[0].Rows.Count > 0)
            return Convert.ToDecimal(ds.Tables[0].Rows[0]["torate"]);
        else
            return 1;
    }

    protected void grid_allowancetotal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblcurreccy = (Label)e.Row.FindControl("lblINR");
            int currencycode = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "currencytype"));
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            if (lblcurreccy.Text != "INR")
            {
                DateTime dateofdeparture = Convert.ToDateTime(((Label)grid_Trip.Rows[0].FindControl("lbldeptDate")).Text);
                decimal rate = getCurrecnyRate(currencycode, dateofdeparture);
                rowtotal = rowtotal * rate;
            }

            Label lbl = (Label)e.Row.FindControl("lblINRSTD");
            lbl.Text = Math.Round(rowtotal, 2).ToString();
            PreAllowancetotal = PreAllowancetotal + rowtotal;

        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbltotalINRSTD");
            lbl.Text = Math.Round(PreAllowancetotal, 2).ToString();
        }
    }

    protected void gridAdvanceSummary_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Amount"));
            PreAdvancetotal = PreAdvancetotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbltotalINRSTD");
            lbl.Text = Math.Round(PreAdvancetotal, 2).ToString();
        }
    }

    //=================================================Appprove Reject Back ============================================

    protected void btnSumitForm_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
            param[1].Value = Session["empcode"].ToString();

            param[2] = new SqlParameter("@approverstatus", SqlDbType.Int);
            param[2].Value = 1;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_approver_reject_travelfrom", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Travel Form Not Approved");
            }
            else
            {
                insertFinalAdvance();
                sqlstr = "update tbl_travel_TravelForm set travelworkflowstatus=1 where travelid=" + travelid + "";
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&approved=true");
            }
        }
    }

    protected void btnRejecct_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
            param[1].Value = Session["empcode"].ToString();

            param[2] = new SqlParameter("@approverstatus", SqlDbType.Int);
            param[2].Value = 2;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_approver_reject_travelfrom", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Travel Form Not Rejected");
            }
            else
            {
                Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&rejected=true");
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproveTravelFormByManager.aspx?user=mgmt");
    }

    //=============================================End===================================

    protected void insertFinalAdvance()
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            param[1] = new SqlParameter("@est_currencycode", SqlDbType.Int);
            param[1].Value = 98;

            param[2] = new SqlParameter("@estimatedamount", SqlDbType.Decimal);
            param[2].Value = Convert.ToDecimal(txtEstimation.Text == "" ? "0" : txtEstimation.Text);

            param[3] = new SqlParameter("@INRSTD", SqlDbType.Decimal);
            param[3].Value = Convert.ToDecimal(txtFinalAmountGiven1.Text == "" ? "0" : txtFinalAmountGiven1.Text);

            param[4] = new SqlParameter("@final_currencycode", SqlDbType.Int);
            param[4].Value = ddl_finalCurrency.SelectedValue;

            param[5] = new SqlParameter("@final_amount", SqlDbType.Decimal);
            param[5].Value = Convert.ToDecimal(txtFinalAmountGiven2.Text == "" ? "0" : txtFinalAmountGiven2.Text);

            param[6] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            param[6].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insertFinalAdvanceGiven", param);
        }
    }

    protected void insertException(int ticketid)
    {
        string approvercode = "";
        if (Grid_Approvers.Rows.Count > 0)
        {
            approvercode = ((Label)Grid_Approvers.Rows[1].FindControl("lblcode")).Text;
        }
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@ticketid", SqlDbType.Int);
        param[0].Value = ticketid;

        param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        param[1].Value = approvercode;

        param[2] = new SqlParameter("@approverlevel", SqlDbType.Int);
        param[2].Value = 2;

        param[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        param[3].Value = Session["empcode"].ToString();

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insertTravelTicketException", param);

    }
    protected void btnException_Click(object sender, EventArgs e)
    {
        string approvercode = "";
        if (Grid_Approvers.Rows.Count > 0)
        {
            approvercode = ((Label)Grid_Approvers.Rows[1].FindControl("lblcode")).Text;
        }

        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
            param[1].Value = Session["empcode"].ToString();

            param[2] = new SqlParameter("@approverstatus", SqlDbType.Int);
            param[2].Value = 1;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_approver_reject_travelfrom", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Travel Form Not Approved");
            }
            else
            {
                insertFinalAdvance();

                Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&approved=true");
            }
        }

        sendMail(approvercode);
    }

    protected void sendMail(string empcode)
    {
        string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
            {
                string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
                string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
                string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
                string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
                string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
                string subject = "Regarding Travel Request";
                string bodyContent = "A new Travel Application request has been submitted by employee " + Session["name"].ToString() + "  for " + txt_travelpurpose.Text + ".";
                string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
            }
        }
    }

    protected void btnAproveExceptionm_Click(object sender, EventArgs e)
    {
        if (hftickerid.Value != "")
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ticketid", SqlDbType.Int);
            param[0].Value = hftickerid.Value;

            param[1] = new SqlParameter("@flag", SqlDbType.VarChar, 1);
            param[1].Value = "A";


            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_approveTicketException]", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Exception Not Approved");
            }
            else
            {
                SmartHr.Common.Alert("Exception  Approved");
            }

        }
    }

    protected void btnRejectExceptionm_Click(object sender, EventArgs e)
    {
        if (hftickerid.Value != "")
        {
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@ticketid", SqlDbType.Int);
            param[0].Value = hftickerid.Value;

            param[1] = new SqlParameter("@flag", SqlDbType.VarChar, 1);
            param[1].Value = "R";


            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_approveTicketException]", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Exception Not Rejected");
            }
            else
            {
                SmartHr.Common.Alert("Exception  Rejected");
            }

        }
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        insertFinalAdvance();
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;


            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_sendApproveExceptionbymgmt]", param);
            if (i > 0)
            {
                string approvercode = "";
                if (Grid_Approvers.Rows.Count > 0)
                {
                    approvercode = ((Label)Grid_Approvers.Rows[1].FindControl("lblcode")).Text;
                    sendMail(approvercode);
                }
                Response.Redirect("ApproveTravelFormByManager.aspx?user=mgmt&exception=true");
            }
        }
    }
    protected void grid_Advance_PreRender(object sender, EventArgs e)
    {
        if (grid_Advance.Rows.Count > 0)
        {
            grid_Advance.UseAccessibleHeader = true;
            grid_Advance.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grid_Trip_PreRender(object sender, EventArgs e)
    {
        if (grid_Trip.Rows.Count > 0)
        {
            grid_Trip.UseAccessibleHeader = true;
            grid_Trip.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void grd_prebooked_PreRender(object sender, EventArgs e)
    {
        if (grd_prebooked.Rows.Count > 0)
        {
            grd_prebooked.UseAccessibleHeader = true;
            grd_prebooked.HeaderRow.TableSection = TableRowSection.TableHeader;
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
}
