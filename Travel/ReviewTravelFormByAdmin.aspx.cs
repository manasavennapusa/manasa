using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using Smart.HR.Common.Mail.Module;

public partial class Travel_ReviewTravelFormByAdmin : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
    DataView dview;
    decimal Prebookingtotal = 0;
    decimal PreAdvancetotal = 0;
    decimal PreAllowancetotal = 0;
    DataActivity DataActivity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            if (Session["adv"] != null)
            {
                Session.Remove("adv");
            }
            Session.Remove("kit");
            bind_city();
            bind_Country();
            bind_Currency();
            bind_Advance_Currency();
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
                bindTripList3(travelid);
                bindAdvanceList(travelid);
                bindApproversgrid(travelid);
                bindApproversgrid3(travelid);
                bindPreviouscomments(travelid);
                bindTravelSummary();
                bindEmpDetails(travelid);
            }
        }
    }

    //=================================================Miscellaneous Allowance Start===================================
    #region Allowance

    protected void bindAdvanceList(int travelid)
    {
        //SqlParameter[] param = new SqlParameter[1];

        //param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        //param[0].Value = travelid;

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getMiscellaneous_AllowanceByTravelID", param);
        //grid_Advance.DataSource = ds;
        //grid_Advance.DataBind();
        //grid_allowancetotal.DataSource = ds;
        //grid_allowancetotal.DataBind();

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
        if (Request.QueryString["type"] != null)
        {
            grid_Trip.Columns[7].Visible = true;
            grid_Trip.Columns[8].Visible = true;
        }
        else
        {
            grid_Trip.Columns[7].Visible = false;
            grid_Trip.Columns[8].Visible = false;
        }
        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
        {
            divKit.Visible = true;
            trkitallowance1.Visible = true;
            trkitallowance2.Visible = true;
        }
        else
        {
            divKit.Visible = true;
            trkitallowance1.Visible = false;
            trkitallowance2.Visible = false;
        }
    }

    protected void btnAddTrip_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["travelID"] != null)
        {
            string traveltype = "";
            string travelid = Request.QueryString["travelID"].ToString();
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;
            ds.Clear();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelDetailsbyTravelID", param);

            if (ds.Tables[0].Rows.Count > 0)
            {

                if (ds.Tables[0].Rows[0]["accountcode"].ToString().Contains("DI"))
                {
                    traveltype = "ID";
                }
                else
                    if (ds.Tables[0].Rows[0]["accountcode"].ToString().Contains("D"))
                        traveltype = "D";
                    else
                        traveltype = "I";

                ScriptManager.RegisterStartupScript(this, GetType(), "Addtrip", "javascript:void(window.open('AddEditTripDetails.aspx?ttype=" + traveltype + "&travelid=" + travelid + "','title','height=550,width=1100,left=100,top=30'));", true);
            }
        }
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

    protected void insertTrips(decimal ticketfarecurrency, decimal traveladvancecurrency, decimal staycurrency)
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
                insert_ticketdetails(Convert.ToInt32(param[14].Value), ticketfarecurrency, traveladvancecurrency, staycurrency);
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

        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@traveldeptdate", SqlDbType.DateTime);
        param[0].Value = txtdepartdate.Text;
        param[1] = new SqlParameter("@travelticketfarecurrency", SqlDbType.Int);
        param[1].Value = ddl_fareCurrecny.SelectedValue;
        param[2] = new SqlParameter("@travelticketadvcurrncy", SqlDbType.Int);
        param[2].Value = ddlticketAdv.SelectedValue;
        param[3] = new SqlParameter("@stayadvcurrency", SqlDbType.Int);
        param[3].Value = ddl_stayCurrency.SelectedValue;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_check_currency", param);
        string currencyerror = "";
        if (rbtnl.SelectedValue == "True")
        {
            if (ds.Tables[0].Rows[0]["ticketfarecur_rate"].ToString().Trim() == "0.0000")
                currencyerror = "Travel ticket fare Currency";
        }
        else if (ds.Tables[0].Rows[0]["ticketadvancecur_rate"].ToString().Trim() == "0.0000")
        {
            if (txtticketAdv.Text.Trim() != "")
                currencyerror = "Travel ticket Advance Currency ";
        }

        if (ds.Tables[0].Rows[0]["staycur_rate"].ToString().Trim() == "0.0000")
        {
            if (currencyerror.Trim() != "")
                currencyerror = currencyerror + ",";
            currencyerror = currencyerror + " Stay Advance Currency";

        }
        if (currencyerror.Trim() != "")
        {
            SmartHr.Common.Alert(currencyerror + " details for this Trip date is not in Masters.Please Check");
        }
        else
        {
            decimal ticketfarecurrency = Convert.ToDecimal(ds.Tables[0].Rows[0]["ticketfarecur_rate"].ToString().Trim());
            decimal traveladvancecurrency = Convert.ToDecimal(ds.Tables[0].Rows[0]["ticketadvancecur_rate"].ToString().Trim());
            decimal staycurrency = Convert.ToDecimal(ds.Tables[0].Rows[0]["staycur_rate"].ToString().Trim());
            if (hftripid.Value != "")
            {
                updatetrip();
                insert_ticketdetails(Convert.ToInt32(hftripid.Value), ticketfarecurrency, traveladvancecurrency, staycurrency);
                SmartHr.Common.Alert("Trip Updated successfully");
                hftripid.Value = "";
                divTrip.Visible = false;
                btnAddTrip.Visible = true;
                btnSaveTripDetails.Text = "Save";
                btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
            }
            else
            {
                insertTrips(ticketfarecurrency, traveladvancecurrency, staycurrency);
                divTrip.Visible = false;
                btnAddTrip.Visible = true;
            }
            clearTrips();
            clearExpansedetails();
            bindTripList(Convert.ToInt32(Request.QueryString["travelID"]));
            bindTravelSummary();
        }
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
        clearTrips();
        bindTripByTripID(tripid);
        bind_ticketdetails(tripid);
        for (int i = 0; i < grid_Trip.Rows.Count; i++)
            grid_Trip.Rows[i].ForeColor = System.Drawing.Color.Black;

        grid_Trip.Rows[e.NewEditIndex].ForeColor = System.Drawing.Color.Blue;

        fromdate = Convert.ToDateTime(((Label)grid_Trip.Rows[e.NewEditIndex].FindControl("lbldeptDate")).Text.Substring(0, 11));
        if ((e.NewEditIndex + 1) < grid_Trip.Rows.Count)
        {
            todate = Convert.ToDateTime(((Label)grid_Trip.Rows[e.NewEditIndex + 1].FindControl("lbldeptDate")).Text.Substring(0, 11));
        }
        else { todate = Convert.ToDateTime("01/01/1900"); }
        string date = todate.ToString("MM/dd/yyyy");

        if ((fromdate.ToString("MM/dd/yyyy") != "01/01/1900") && (todate.ToString("MM/dd/yyyy") != "01/01/1900") && (fromdate.ToString("MM-dd-yyyy") != "01-01-1900") && (todate.ToString("MM-dd-yyyy") != "01-01-1900"))
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
        txtticketAdv.Text = "";
        //ddlticketAdv.SelectedValue = "0";
        if (rbtnl.SelectedIndex == 0)
        {
            if (ddl_traveltype.SelectedValue == "I")
            {
                trticket1.Visible = false;
                trticket6.Visible = true;
            }
            else
            {
                trticket1.Visible = true;
                trticket6.Visible = false;
            }

            trticket2.Visible = true;
            trticket3.Visible = true;
            trticket4.Visible = true;
            trticket5.Visible = true;
            txtticketAdv.Enabled = false;
            ddlticketAdv.Enabled = false;
        }
        else
        {
            trticket1.Visible = false;
            trticket2.Visible = false;
            trticket3.Visible = false;
            trticket4.Visible = false;
            trticket5.Visible = false;
            txtticketAdv.Enabled = true;
            ddlticketAdv.Enabled = true;
        }
    }

    protected void rbtnl_lodge_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_lodgeAdv.Text = "";
        if (rbtnl_lodge.SelectedIndex == 0)
        {
            trlodge.Visible = true;
            trlodge2.Visible = true;
            txt_lodgeAdv.Enabled = false;
        }
        else
        {
            trlodge.Visible = false;
            trlodge2.Visible = false;
            txt_lodgeAdv.Enabled = true;
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
            //lblgrade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            lbllocation.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lblmgr.Text = ds.Tables[0].Rows[0]["reporting_mgr"].ToString();
            lblmobileno.Text = ds.Tables[0].Rows[0]["mobile_no"].ToString();
            txt_travelpurpose.Text = ds.Tables[0].Rows[0]["travelpurpose"].ToString();
            lblAcCode.Text = ds.Tables[0].Rows[0]["accountcode"].ToString();
            lblcostcenter.Text = ds.Tables[0].Rows[0]["cost_center_name"].ToString();
            rbtnl_kitallowance.SelectedValue = ds.Tables[0].Rows[0]["iskitallowancetaken"].ToString().ToLower();
            rbtnl_insurance.SelectedValue = ds.Tables[0].Rows[0]["insurence_need"].ToString().ToLower();
            rbtnl_visa.SelectedValue = ds.Tables[0].Rows[0]["visa_arraged"].ToString().ToLower();
            lblsubmitteddate.Text = ds.Tables[0].Rows[0]["createddate"].ToString();
            lblempstatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
            if (ds.Tables[0].Rows[0]["iskitallowancetaken"].ToString() == "True")
            {
                trkitamount.Visible = true;
                trprvkit.Visible = true;
                string sqlstr = "select id,kitallowance from tbl_travel_kitallowance_master where status=1;select k.travelid,kitallowance,convert(varchar(12),applieddate,106) applieddate,t.accountcode from tbl_travel_kitallowance k inner join tbl_travel_TravelForm t on k.travelid=t.travelid where empcode='" + ds.Tables[0].Rows[0]["empcode"].ToString() + "' and k.status=1";
                DataSet ds3 = new DataSet();
                ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                if (ds3.Tables[0].Rows.Count > 0)
                {
                    lblKitallowanceamount.Text = ds3.Tables[0].Rows[0]["kitallowance"].ToString();
                    hfkitallowanceid.Value = ds3.Tables[0].Rows[0]["id"].ToString();
                }
                if (ds3.Tables[1].Rows.Count > 0)
                    lblprvkitallownace.Text = "<b>Travel ID :</b>" + ds3.Tables[1].Rows[0]["accountcode"].ToString() + " <br><b>Kit Allowance Amount :</b>" + ds3.Tables[1].Rows[0]["kitallowance"].ToString() + " <br><b>Date :</b>" + ds3.Tables[1].Rows[0]["applieddate"].ToString();
                else
                    lblprvkitallownace.Text = "No Data!";

                Ins_kit();
            }
            else
            {
                trkitamount.Visible = false;
                trprvkit.Visible = false;
            }
        }
    }

    //================================================= Travel Details End ============================================

    //============================================= Bind dropdown Controls ===================================

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
        try
        {
           // string sqlstr = "select distinct cid,currencycode+' - '+ countryname as currencycode from tbl_intranet_country_master order by currencycode";
            string sqlstr = "select distinct cid,currencycode,''+''+countryname as currencycode from tbl_intranet_country_master";
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

            ddlticketAdv.DataTextField = "currencycode";
            ddlticketAdv.DataValueField = "cid";
            ddlticketAdv.DataSource = ds3;
            ddlticketAdv.DataBind();
            ddlticketAdv.SelectedValue = "98";
            var itemIndex4 = ddlticketAdv.SelectedIndex;
            var item4 = ddlticketAdv.Items[itemIndex3];
            ddlticketAdv.Items.RemoveAt(itemIndex3);
            ddlticketAdv.Items.Insert(0, new ListItem(item4.Text, item4.Value));
        }
        catch { }
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

    //========================================================= End =====================================================

    //================================================= Expanse Details Start ============================================
    protected void ddl_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_ModeClass(Convert.ToInt32(ddl_mode.SelectedValue));
    }

    protected void insert_ticketdetails(int tripid, decimal ticketfarecurrency, decimal traveladvancecurrency, decimal staycurrency)
    {
        if (tripid != 0)
        {

            SqlParameter[] param = new SqlParameter[47];

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
                param[6].Value = Convert.ToDecimal(txtticketfair.Text.Trim() == "" ? "0" : txtticketfair.Text);

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
            param[8].Value = System.Data.SqlTypes.SqlBoolean.Null; //rbtnl_ticketAdv.SelectedValue;

            //if (rbtnl_ticketAdv.SelectedValue == "True")
            //{
            param[9] = new SqlParameter("@traveladvanceamount", SqlDbType.Decimal);
            param[9].Value = Convert.ToDecimal(txtticketAdv.Text.Trim() == "" ? "0" : txtticketAdv.Text);
            //}
            //else
            //{
            //    param[9] = new SqlParameter("@traveladvanceamount", SqlDbType.Decimal);
            //    param[9].Value = System.Data.SqlTypes.SqlDecimal.Null;
            //}
            //=============================Stay===============================================
            param[10] = new SqlParameter("@isstaybooked", SqlDbType.Bit);
            param[10].Value = rbtnl_lodge.SelectedValue;

            param[11] = new SqlParameter("@stay_currencycode", SqlDbType.Int);
            param[11].Value = ddl_stayCurrency.SelectedValue;

            if (rbtnl_lodge.SelectedValue == "True")
            {
                param[12] = new SqlParameter("@stay_fare", SqlDbType.Decimal);
                param[12].Value = Convert.ToDecimal(txtlodgefare.Text.Trim() == "" ? "0" : txtlodgefare.Text);

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
            param[14].Value = System.Data.SqlTypes.SqlBoolean.Null;

            //if (rbtnl_lodgeAdv.SelectedValue == "True")
            //{
            param[15] = new SqlParameter("@stayadvanceamount", SqlDbType.Decimal);
            param[15].Value = Convert.ToDecimal(txt_lodgeAdv.Text.Trim() == "" ? "0" : txt_lodgeAdv.Text);
            //}
            //else
            //{
            //    param[15] = new SqlParameter("@stayadvanceamount", SqlDbType.Decimal);
            //    param[15].Value = System.Data.SqlTypes.SqlDecimal.Null;
            //}

            param[16] = new SqlParameter("@staytotalfair_actual", SqlDbType.Decimal);
            param[16].Value = Convert.ToDecimal(lbllodgetotal.Text.Trim() == "" ? "0" : lbllodgetotal.Text);

            param[17] = new SqlParameter("@stayperdayfair_actual", SqlDbType.Decimal);
            param[17].Value = Convert.ToDecimal(lbllodge.Text.Trim() == "" ? "0" : lbllodge.Text);

            param[18] = new SqlParameter("@staynoofdays", SqlDbType.Decimal);
            param[18].Value = Convert.ToDecimal(lbllodgedays.Text.Trim() == "" ? "0" : lbllodgedays.Text);

            //=============================Conveyance===============================================
            param[19] = new SqlParameter("@conveyadvancegiven", SqlDbType.Bit);
            param[19].Value = System.Data.SqlTypes.SqlBoolean.Null;

            //if (rbtnl_conv.SelectedValue == "True")
            //{
            param[20] = new SqlParameter("@converadvanceamount", SqlDbType.Decimal);
            param[20].Value = Convert.ToDecimal(txtconvAdvance.Text.Trim() == "" ? "0" : txtconvAdvance.Text);
            //}
            //else
            //{
            //    param[20] = new SqlParameter("@converadvanceamount", SqlDbType.Decimal);
            //    param[20].Value = System.Data.SqlTypes.SqlDecimal.Null;
            //}

            param[21] = new SqlParameter("@convey_no_of_days", SqlDbType.Decimal);
            param[21].Value = Convert.ToDecimal(lbl_ConvDays.Text.Trim() == "" ? "0" : lbl_ConvDays.Text);

            param[22] = new SqlParameter("@convey_amount", SqlDbType.Decimal);
            param[22].Value = Convert.ToDecimal(txtconvAdvance.Text.Trim() == "" ? "0" : txtconvAdvance.Text);

            //=============================OOP===============================================

            param[23] = new SqlParameter("@oopadvancegiven", SqlDbType.Bit);
            param[23].Value = System.Data.SqlTypes.SqlBoolean.Null;

            //if (rbtnl_oop.SelectedValue == "True")
            //{
            param[24] = new SqlParameter("@oopadvanceamount", SqlDbType.Decimal);
            param[24].Value = Convert.ToDecimal(txtoopAdv.Text.Trim() == "" ? "0" : txtoopAdv.Text);
            //}
            //else
            //{
            //    param[24] = new SqlParameter("@oopadvanceamount", SqlDbType.Decimal);
            //    param[24].Value = System.Data.SqlTypes.SqlDecimal.Null;
            //}

            param[25] = new SqlParameter("@ooptotalfair_actual", SqlDbType.Decimal);
            param[25].Value = Convert.ToDecimal(lblopptotal.Text.Trim() == "" ? "0" : lblopptotal.Text);

            param[26] = new SqlParameter("@oop_no_of_days", SqlDbType.Decimal);
            param[26].Value = Convert.ToDecimal(lbloppDays.Text.Trim() == "" ? "0" : lbloppDays.Text);

            param[27] = new SqlParameter("@oopperdayfair_actual", SqlDbType.Decimal);
            param[27].Value = Convert.ToDecimal(lbloop.Text.Trim() == "" ? "0" : lbloop.Text);

            //=============================FOOD===============================================
            param[28] = new SqlParameter("@mealsadvancegiven", SqlDbType.Bit);
            param[28].Value = System.Data.SqlTypes.SqlBoolean.Null;

            //if (rbtnl_food.SelectedValue == "True")
            //{
            param[29] = new SqlParameter("@mealsadvanceamount", SqlDbType.Decimal);
            param[29].Value = Convert.ToDecimal(txtFoodAdv.Text.Trim() == "" ? "0" : txtFoodAdv.Text);
            //}
            //else
            //{
            //    param[29] = new SqlParameter("@mealsadvanceamount", SqlDbType.Decimal);
            //    param[29].Value = System.Data.SqlTypes.SqlDecimal.Null;
            //}


            param[30] = new SqlParameter("@mealstotalfair_actual", SqlDbType.Decimal);
            param[30].Value = Convert.ToDecimal(lblfoodtotal.Text.Trim() == "" ? "0" : lblfoodtotal.Text);

            param[31] = new SqlParameter("@meals_no_of_days", SqlDbType.Decimal);
            param[31].Value = Convert.ToDecimal(lblfoodDays.Text.Trim() == "" ? "0" : lblfoodDays.Text);

            param[32] = new SqlParameter("@mealsperdayfair_actual", SqlDbType.Decimal);
            param[32].Value = Convert.ToDecimal(lblfood.Text.Trim() == "" ? "0" : lblfood.Text);

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

            param[39] = new SqlParameter("@travel_fare_INR", SqlDbType.Decimal);
            param[39].Value = Convert.ToDecimal(txtticketfair.Text.Trim() == "" ? "0" : txtticketfair.Text) * ticketfarecurrency;

            param[40] = new SqlParameter("@traveladvanceamount_INR", SqlDbType.Decimal);
            param[40].Value = Convert.ToDecimal(txtticketAdv.Text.Trim() == "" ? "0" : txtticketAdv.Text) * traveladvancecurrency;

            param[41] = new SqlParameter("@stay_fare_INR", SqlDbType.Decimal);
            param[41].Value = Convert.ToDecimal(txtlodgefare.Text.Trim() == "" ? "0" : txtlodgefare.Text) * staycurrency;

            param[42] = new SqlParameter("@stayadvanceamount_INR", SqlDbType.Decimal);
            param[42].Value = Convert.ToDecimal(txt_lodgeAdv.Text.Trim() == "" ? "0" : txt_lodgeAdv.Text) * staycurrency;

            param[43] = new SqlParameter("@converadvanceamount_INR", SqlDbType.Decimal);
            param[43].Value = Convert.ToDecimal(txtconvAdvance.Text.Trim() == "" ? "0" : txtconvAdvance.Text) * staycurrency;

            param[44] = new SqlParameter("@oopadvanceamount_INR", SqlDbType.Decimal);
            param[44].Value = Convert.ToDecimal(txtoopAdv.Text.Trim() == "" ? "0" : txtoopAdv.Text) * staycurrency;

            param[45] = new SqlParameter("@mealsadvanceamount_INR", SqlDbType.Decimal);
            param[45].Value = Convert.ToDecimal(txtFoodAdv.Text.Trim() == "" ? "0" : txtFoodAdv.Text) * staycurrency;

            param[46] = new SqlParameter("@traveladvance_currencycode", SqlDbType.Int);
            param[46].Value = ddlticketAdv.SelectedValue;



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
                txtticketAdv.Enabled = false;
                ddlticketAdv.Enabled = false;
            }
            else
            {
                trticket1.Visible = false;
                trticket2.Visible = false;
                trticket3.Visible = false;
                trticket4.Visible = false;
                trticket5.Visible = false;
                txtticketAdv.Enabled = true;
                ddlticketAdv.Enabled = true;
            }

            //rbtnl_ticketAdv.SelectedValue = ds.Tables[0].Rows[0]["traveladvancegiven"].ToString();

            //if (ds.Tables[0].Rows[0]["traveladvancegiven"].ToString() == "True")
            //{
            //    txtticketAdv.Text = ds.Tables[0].Rows[0]["traveladvanceamount"].ToString();
            //    trticketadv.Visible = true;
            //}
            //else
            //{
            //    trticketadv.Visible = false;
            //}
            //=============================Stay===============================================
            // rbtnl_lodge.SelectedValue = ds.Tables[0].Rows[0]["isstaybooked"].ToString();
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

            //rbtnl_lodgeAdv.SelectedValue = ds.Tables[0].Rows[0]["stayadvancegiven"].ToString();

            //if (ds.Tables[0].Rows[0]["stayadvancegiven"].ToString() == "True")
            //{
            txt_lodgeAdv.Text = ds.Tables[0].Rows[0]["stayadvanceamount"].ToString();
            //    trlodgeAdv.Visible = true;
            //}
            //else
            //{
            //    trlodgeAdv.Visible = false;
            //}
            lbllodgetotal.Text = ds.Tables[0].Rows[0]["staytotalfair_actual"].ToString();
            lbllodge.Text = ds.Tables[0].Rows[0]["stayperdayfair_actual"].ToString();
            lbllodgedays.Text = ds.Tables[0].Rows[0]["staynoofdays"].ToString();


            //=============================Conveyance===============================================
            //rbtnl_conv.SelectedValue = ds.Tables[0].Rows[0]["conveyadvancegiven"].ToString();

            //if (ds.Tables[0].Rows[0]["conveyadvancegiven"].ToString() == "True")
            //{
            txtconvAdvance.Text = ds.Tables[0].Rows[0]["converadvanceamount"].ToString();
            //    trconv.Visible = true;
            //}
            //else
            //{
            //    trconv.Visible = false;
            //}
            lbl_ConvDays.Text = ds.Tables[0].Rows[0]["convey_no_of_days"].ToString();
            txtconvAdvance.Text = ds.Tables[0].Rows[0]["convey_amount"].ToString();

            //=============================OOP===============================================

            //rbtnl_oop.SelectedValue = ds.Tables[0].Rows[0]["oopadvancegiven"].ToString();


            //if (ds.Tables[0].Rows[0]["oopadvancegiven"].ToString() == "True")
            //{
            txtoopAdv.Text = ds.Tables[0].Rows[0]["oopadvanceamount"].ToString();

            //    troop.Visible = true;
            //}
            //else
            //{
            //    troop.Visible = false;
            //}
            lblopptotal.Text = ds.Tables[0].Rows[0]["ooptotalfair_actual"].ToString();
            lbloppDays.Text = ds.Tables[0].Rows[0]["oop_no_of_days"].ToString();
            lbloop.Text = ds.Tables[0].Rows[0]["oopperdayfair_actual"].ToString();

            //=============================FOOD===============================================
            //rbtnl_food.SelectedValue = ds.Tables[0].Rows[0]["mealsadvancegiven"].ToString();

            //if (ds.Tables[0].Rows[0]["mealsadvancegiven"].ToString() == "True")
            //{
            txtFoodAdv.Text = ds.Tables[0].Rows[0]["mealsadvanceamount"].ToString();
            //    trfood.Visible = true;
            //}
            //else
            //{
            //    trfood.Visible = false;
            //}

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
        try
        {
            rbtnl.SelectedIndex = 1;
            ddl_tier.SelectedValue = "0";
            ddl_mode.SelectedValue = "0";
            ddl_modeClass.SelectedValue = "0";
            ddl_fareCurrecny.SelectedIndex = 0;
            txtticketfair.Text = "";
            rbtnl_ticketAdv.SelectedIndex = 1;
            rbtnl_lodge.SelectedIndex = 1;
            ddl_stayCurrency.SelectedIndex = 0;
            txtlodgefare.Text = "";
            txtLodgeAddress.Text = "";
            rbtnl_lodgeAdv.SelectedIndex = 1;
            txt_lodgeAdv.Text = "";
            lbllodgetotal.Text = "";
            lbllodge.Text = "";
            lbllodgedays.Text = "";
            rbtnl_conv.SelectedIndex = 1;
            txtconvAdvance.Text = "";
            lbl_ConvDays.Text = "";
            txtconvAdvance.Text = "";
            rbtnl_oop.SelectedIndex = 1;
            txtoopAdv.Text = "";
            lblopptotal.Text = "";
            lbloppDays.Text = "";
            lbloop.Text = "";
            rbtnl_food.SelectedIndex = 1;
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

            //trticketadv.Visible = false;
            trlodge.Visible = false;
            trlodge2.Visible = false;
            // trlodgeAdv.Visible = false;
            // trconv.Visible = false;
            //troop.Visible = false;
            //  trfood.Visible = false;
        }
        catch { }
    }

    //================================================= Expanse Details End ============================================

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
        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getEstimationallowancebytravelid", param);
        if (ds2.Tables.Count > 0)
        {
            gridAdvanceSummary.DataSource = ds2.Tables[0];
            gridAdvanceSummary.DataBind();
        }
        if (ds2.Tables.Count > 1)
        {
            grd_prebooked.DataSource = ds2.Tables[1];
            grd_prebooked.DataBind();
        }
        if (ds2.Tables.Count > 2)
        {
            grid_allowancetotal.DataSource = ds2.Tables[2];
            grid_allowancetotal.DataBind();
        }
        if (ds2.Tables.Count > 3)
        {
            grd_kitallowancedetials.DataSource = ds2.Tables[3];
            grd_kitallowancedetials.DataBind();
        }
        if (ds2.Tables.Count > 4)
        {
            grd_estimationtotals.DataSource = ds2.Tables[4];
            grd_estimationtotals.DataBind();
        }
        if (ds2.Tables.Count > 5)
        {
            grd_pretraveltotals.DataSource = ds2.Tables[5];
            grd_pretraveltotals.DataBind();
        }

    }

    protected void bindperDayAllowances(int tripid)
    {
        //SqlParameter[] param = new SqlParameter[1];

        //param[0] = new SqlParameter("@tripid", SqlDbType.Int);
        //param[0].Value = tripid;


        //ds.Clear();
        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getperDayAllowances", param);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    lbllodge.Text = ds.Tables[0].Rows[0]["Stay"].ToString();
        //    lblfood.Text = ds.Tables[0].Rows[0]["Meals"].ToString();
        //    lbloop.Text = ds.Tables[0].Rows[0]["OOP"].ToString();
        //    if (lbllodge.Text == "")
        //        lbllodge.Text = "0";
        //    if (lblfood.Text == "")
        //        lblfood.Text = "0";
        //    if (lbloop.Text == "")
        //        lbloop.Text = "0";
        //}

        //lbllodgetotal.Text = Math.Round(Convert.ToDecimal(lbllodgedays.Text) * Convert.ToDecimal(lbllodge.Text), 2).ToString();
        //lblfoodtotal.Text = Math.Round(Convert.ToDecimal(lblfoodDays.Text) * Convert.ToDecimal(lblfood.Text), 2).ToString();
        //lblopptotal.Text = Math.Round(Convert.ToDecimal(lbloppDays.Text) * Convert.ToDecimal(lbloop.Text), 2).ToString();

    }

    protected void grd_prebooked_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountINR"));
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
                string date = ((Label)grid_Trip.Rows[0].FindControl("lbldeptDate")).Text;
                date = date.Substring(0, 11);
                DateTime dateofdeparture = Convert.ToDateTime(date);
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
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "totalcost"));
            PreAdvancetotal = PreAdvancetotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbltotalINRSTD");
            lbl.Text = Math.Round(PreAdvancetotal, 2).ToString();
        }
    }

    //================================================= Appprove Reject Back ============================================

    protected void btnSumitForm_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        string approvercode = "";
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();

            if (Request.QueryString["travelID"] != null)
            {
                if (grid_Trip.Rows.Count > 0)
                {

                    if (Grid_Approvers.Rows.Count > 0)
                    {
                        approvercode = ((Label)Grid_Approvers.Rows[0].FindControl("lblcode")).Text;
                    }
                    _Transaction = Connection.BeginTransaction();
                    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                    SqlParameter[] parm = new SqlParameter[4];
                    Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
                    Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "1");
                    Output.AssignParameter(parm, 3, "@approver", "String", 10, "admin");
                    insertTravelComments(travelid, "A", _Transaction, Connection);
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelfrom", parm);

                    insertEstimatedAllowances(_Transaction, Connection);
                    insertFinalAdvance(_Transaction, Connection);
                    if (rbtnl_kitallowance.SelectedValue == "true")
                    {
                        sqlstr = "update tbl_travel_TravelForm set iskitallowancetaken=1 where travelid=" + travelid.ToString();
                        insertKitAllowance(travelid, _Transaction, Connection);
                    }
                    else
                    {
                        sqlstr = "update tbl_travel_TravelForm set iskitallowancetaken=0 where travelid=" + travelid.ToString();
                    }
                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, sqlstr);
                    _Transaction.Commit();
                }
                else
                {
                    SmartHr.Common.Alert("Atleat one travel trip should be present");
                }
            }
        }
        catch (Exception ex)
        {
            Flag = 0;
            _Transaction.Rollback();

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag > 0)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
           // SendEmail(travelid, 0);


            Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&approved=true");
        }
        else
        {
            SmartHr.Common.Alert("Travel Form Not Approved");
        }
    }

    protected void btnRejecct_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            if (Request.QueryString["travelID"] != null)
            {
                if (grid_Trip.Rows.Count > 0)
                {
                    Connection = DataActivity.OpenConnection();
                    _Transaction = Connection.BeginTransaction();
                    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                    SqlParameter[] parm = new SqlParameter[4];
                    Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
                    Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "2");
                    Output.AssignParameter(parm, 3, "@approver", "String", 10, "admin");
                    insertTravelComments(travelid, "R", _Transaction, Connection);
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelfrom", parm);
                    _Transaction.Commit();
                }
                else
                {
                    SmartHr.Common.Alert("Atleat one travel trip should be present");
                }
            }
        }
        catch (Exception ex)
        {
            Flag = 0;
            _Transaction.Rollback();

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
        if (Flag <= 0)
        {
            SmartHr.Common.Alert("Travel Form Not Rejected");
        }
        else
        {
            Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&rejected=true");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproveTravelFormByManager.aspx?user=admin");
    }

    //===================================================== End ===========================================================

    protected void insertFinalAdvance(SqlTransaction _Transaction, SqlConnection Connection)
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[6];
            foreach (GridViewRow row in grd_estimationtotals.Rows)
            {
                Label lblcurrencyid = (Label)row.FindControl("lblcurrencyid");
                Label lblamount = (Label)row.FindControl("lblamount");
                TextBox txtgiven = (TextBox)row.FindControl("txtgiven");

                param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param[0].Value = travelid;

                param[1] = new SqlParameter("@est_currencycode", SqlDbType.Int);
                param[1].Value = Convert.ToInt32(lblcurrencyid.Text == "" ? "0" : lblcurrencyid.Text);

                param[2] = new SqlParameter("@estimatedamount", SqlDbType.Decimal);
                param[2].Value = Convert.ToDecimal(lblamount.Text == "" ? "0" : lblamount.Text);

                param[3] = new SqlParameter("@final_amount", SqlDbType.Decimal);
                param[3].Value = Convert.ToDecimal(txtgiven.Text == "" ? "0" : txtgiven.Text);

                param[4] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                param[4].Value = Session["empcode"].ToString();

                param[5] = new SqlParameter("@advancetype", SqlDbType.Char, 1);
                param[5].Value = "E";

                SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_insertFinalAdvanceGiven", param);
            }

            SqlParameter[] parm = new SqlParameter[6];
            foreach (GridViewRow row in grd_pretraveltotals.Rows)
            {
                Label lblcurrencycode = (Label)row.FindControl("lblcurrencyid");
                Label lblpretravelamount = (Label)row.FindControl("lblamount");

                parm[0] = new SqlParameter("@travelid", SqlDbType.Int);
                parm[0].Value = travelid;

                parm[1] = new SqlParameter("@est_currencycode", SqlDbType.Int);
                parm[1].Value = Convert.ToInt32(lblcurrencycode.Text == "" ? "0" : lblcurrencycode.Text);

                parm[2] = new SqlParameter("@estimatedamount", SqlDbType.Decimal);
                parm[2].Value = Convert.ToDecimal(lblpretravelamount.Text == "" ? "0" : lblpretravelamount.Text);

                parm[3] = new SqlParameter("@final_amount", SqlDbType.Decimal);
                parm[3].Value = Convert.ToDecimal("0");

                parm[4] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                parm[4].Value = Session["empcode"].ToString();

                parm[5] = new SqlParameter("@advancetype", SqlDbType.Char, 1);
                parm[5].Value = "P";

                SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_insertFinalAdvanceGiven", parm);
            }

            if (Session["adv"] != null)
            {

                dtable = (DataTable)Session["adv"];
                for (int i = 0; i < dtable.Rows.Count; i++)
                {
                    param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                    param[0].Value = travelid;

                    param[1] = new SqlParameter("@est_currencycode", SqlDbType.Int);
                    param[1].Value = dtable.Rows[i]["Currencyid"].ToString();

                    param[2] = new SqlParameter("@estimatedamount", SqlDbType.Decimal);
                    param[2].Value = Convert.ToDecimal("0");

                    param[3] = new SqlParameter("@final_amount", SqlDbType.Decimal);
                    param[3].Value = Convert.ToDecimal(dtable.Rows[i]["Amount"].ToString().Trim());

                    param[4] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                    param[4].Value = Session["empcode"].ToString();

                    param[5] = new SqlParameter("@advancetype", SqlDbType.Char, 1);
                    param[5].Value = "E";

                    SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_insertFinalAdvanceGiven", param);
                }
            }
        }
    }

    protected void insertEstimatedAllowances(SqlTransaction _Transaction, SqlConnection Connection)
    {
        foreach (GridViewRow row in gridAdvanceSummary.Rows)
        {
            Label lbltripid = (Label)row.FindControl("lbltripid");
            Label lbltripno = (Label)row.FindControl("lbltripno");
            Label lblDetails = (Label)row.FindControl("lblDetails");
            Label lblcurrencyid = (Label)row.FindControl("lblcurrencyid");
            Label lblperdaycost = (Label)row.FindControl("lblperdaycost");
            Label lbldays = (Label)row.FindControl("lbldays");
            Label lblamount = (Label)row.FindControl("lblamount");


            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@tripid", SqlDbType.Int);
            param[0].Value = lbltripid.Text;

            param[1] = new SqlParameter("@advance_desc", SqlDbType.VarChar, 50);
            param[1].Value = lblDetails.Text;

            int curid = 0;
            int.TryParse(lblcurrencyid.Text.ToString(), out curid);
            param[2] = new SqlParameter("@currencytype", SqlDbType.Int);
            param[2].Value = curid;

            param[3] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[3].Value = Convert.ToDecimal(lblamount.Text == "" ? "0" : lblamount.Text);

            param[4] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            param[4].Value = Session["empcode"].ToString();

            param[5] = new SqlParameter("@noofdays", SqlDbType.Int);
            param[5].Value = Convert.ToInt32(lbldays.Text == "" ? "0" : lbldays.Text);

            param[6] = new SqlParameter("@perdayallowance", SqlDbType.Decimal);
            param[6].Value = Convert.ToDecimal(lblperdaycost.Text == "" ? "0" : lblperdaycost.Text);

            param[7] = new SqlParameter("@tripno", SqlDbType.Int);
            param[7].Value = Convert.ToInt32(lbltripno.Text == "" ? "0" : lbltripno.Text);
            SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_insert_advanceAmount", param);

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
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_sentTravelForException", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Travel Exception not sent.");
            }
            else
            {
                // insertFinalAdvance();
                Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&exception=true");
            }
        }


    }

    protected void insertKitAllowance(int travelid, SqlTransaction _Transaction, SqlConnection Connection)
    {
        string applieddate = "";
        if (grid_Trip.Rows.Count > 0)
            applieddate = ((Label)grid_Trip.Rows[0].FindControl("lbldeptDate")).Text;
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;

        param[1] = new SqlParameter("@kitallowanceid", SqlDbType.Int);
        param[1].Value = hfkitallowanceid.Value == "" ? "0" : hfkitallowanceid.Value;

        param[2] = new SqlParameter("@kitallowance", SqlDbType.Decimal);
        param[2].Value = lblKitallowanceamount.Text == "" ? "0" : lblKitallowanceamount.Text;

        param[3] = new SqlParameter("@applieddate", SqlDbType.DateTime);
        param[3].Value = applieddate != "" ? Convert.ToDateTime(applieddate) : System.Data.SqlTypes.SqlDateTime.Null;

        param[4] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
        param[4].Value = Session["empcode"].ToString();

        SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_insert_kitallowance", param);
    }

    void SendEmail(int travelId, int type)
    {
        if (type == 0)
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponApprovalOfRequestFinalStepApprover();
            EmailClient client = new EmailClient(email);
            Approvers.Travel.Approvers appovers = new Approvers.Travel.Approvers();
            DataRow rowemp = appovers.GetTravelEmployeeInfo(travelId);
            DataTable dt = appovers.GetApprovers(travelId, 4);

            foreach (DataRow row in dt.Rows)
            {
                client.toEmailId = row["official_email_id"].ToString().Trim();
                client.empCode = row["approvercode"].ToString();
                client.employeeName = row["name"].ToString().Trim();
                client.appsendername = rowemp["name"].ToString().Trim();
                client.requestNumber = row["accountcode"].ToString();
                client.Send();
            }
        }
    }

    void SendRejectEmail(int travelId, int type)
    {
        if (type == 0)
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponCancellationOfRequestFinalStepApprover();
            EmailClient client = new EmailClient(email);

            Approvers.Travel.Approvers appovers = new Approvers.Travel.Approvers();
            DataRow rowemp = appovers.GetTravelEmployeeInfo(travelId);

            DataRow row = appovers.GetTravelEmployeeInfo(travelId);

            client.toEmailId = row["official_email_id"].ToString().Trim();
            client.empCode = row["empcode"].ToString();
            client.employeeName = row["name"].ToString().Trim();
            client.appsendername = rowemp["name"].ToString().Trim();
            client.requestNumber = row["accountcode"].ToString();
            client.Send();

        }
    }

    protected void rbtnl_kitallowance_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_kitallowance.SelectedValue == "true")
        {
            trkitamount.Visible = true;
            trprvkit.Visible = true;
            string sqlstr = "select id,kitallowance from tbl_travel_kitallowance_master where status=1;select k.travelid,kitallowance,convert(varchar(12),applieddate,106) applieddate,t.accountcode from tbl_travel_kitallowance k inner join tbl_travel_TravelForm t on k.travelid=t.travelid where empcode='" + Session["empcode"].ToString() + "' and k.status=1";
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            if (ds3.Tables[0].Rows.Count > 0)
            {
                lblKitallowanceamount.Text = ds3.Tables[0].Rows[0]["kitallowance"].ToString();
                hfkitallowanceid.Value = ds3.Tables[0].Rows[0]["id"].ToString();
            }
            if (ds3.Tables[1].Rows.Count > 0)
                lblprvkitallownace.Text = "<b>Travel ID :</b>" + ds3.Tables[1].Rows[0]["accountcode"].ToString() + " <br><b>Kit Allowance Amount :</b>" + ds3.Tables[1].Rows[0]["kitallowance"].ToString() + " <br><b>Date :</b>" + ds3.Tables[1].Rows[0]["applieddate"].ToString();
            else
                lblprvkitallownace.Text = "No Data!";
            Ins_kit();
        }
        else
        {
            lblKitallowanceamount.Text = "";
            lblprvkitallownace.Text = "";
            hfkitallowanceid.Value = "";
            trkitamount.Visible = false;
            trprvkit.Visible = false;
            Session["kit"] = null;
            BindList_kit();

        }
        if (Request.QueryString["travelID"] != null)
        {

            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            if (rbtnl_kitallowance.SelectedValue == "true")
            {
                sqlstr = "update tbl_travel_TravelForm set iskitallowancetaken=1 where travelid=" + travelid.ToString();

            }
            else
            {
                sqlstr = "update tbl_travel_TravelForm set iskitallowancetaken=0 where travelid=" + travelid.ToString();
            }
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }
    }

    protected void Ins_kit()
    {
        DataRow dr;
        if (Session["kit"] == null)
        {
            create_kitallaoance_table();
        }
        dtable = (DataTable)Session["kit"];

        DataRow drfind = dtable.Rows.Find(lblKitallowanceamount.Text);
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["currencycode"] = "INR";
            dr["kitallowance"] = lblKitallowanceamount.Text;

            dtable.Rows.Add(dr);
        }
        Session["kit"] = dtable;
        BindList_kit();
    }

    protected void BindList_kit()
    {
        if (Session["kit"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["kit"];
            dview = new DataView(dtable);
        }
        grd_kitallowancedetials.DataSource = dview;
        grd_kitallowancedetials.DataBind();
    }

    protected void create_kitallaoance_table()
    {

        dtable = new DataTable();
        dtable.Columns.Add(new DataColumn("currencycode", typeof(string)));
        dtable.Columns.Add(new DataColumn("kitallowance", typeof(string)));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["kitallowance"] };
        Session["kit"] = dtable;
    }

    protected void rbtnl_airlinems_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txtairlinedetails.Text = "";
        //if (rbtnl_airlinems.SelectedValue == "true")
        //    txtairlinedetails.Visible = true;
        //else
        //    txtairlinedetails.Visible = false;

    }

    protected void rbtnl_hotelms_SelectedIndexChanged(object sender, EventArgs e)
    {
        //txthoteldetails.Text = "";
        //if (rbtnl_hotelms.SelectedValue == "true")
        //    txthoteldetails.Visible = true;
        //else
        //    txthoteldetails.Visible = false;
    }

    protected void btn_travelCancel_Click(object sender, EventArgs e)
    {
        if (txtmgrcomments.Text.Trim() == "")
        {
            SmartHr.Common.Alert("Please Enter The Comments");
        }
        else
        {

            if (Request.QueryString["travelID"] != null)
            {
                SqlConnection Connection = null;
                SqlTransaction _Transaction = null;
                int Flag = 0;
                try
                {
                    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);

                    Connection = DataActivity.OpenConnection();
                    _Transaction = Connection.BeginTransaction();
                    insertTravelComments(travelid, "C", _Transaction, Connection);
                    sqlstr = "update tbl_travel_TravelForm set istravelcanceled=1 where travelid=" + travelid + "";
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, sqlstr);
                    _Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Flag = 0;
                    _Transaction.Rollback();

                    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                    Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
                }
                finally
                {
                    DataActivity.CloseConnection();

                }
                if (Flag < 0)
                {
                    SmartHr.Common.Alert("Travel Form is Not Cancelled");
                }
                else
                {
                    int travelId = Convert.ToInt32(Request.QueryString["travelID"].ToString());
                    SendRejectEmail(travelId, 0);
                    Response.Redirect("ApproveTravelFormByManager.aspx?user=admin&cancelled=true");
                }
            }
        }

    }


    protected void insertTravelComments(int travelid, string commenttype, SqlTransaction _Transaction, SqlConnection Connection)
    {
        //if (txtmgrcomments.Text.Trim() != "")
        //{
        SqlParameter[] parm = new SqlParameter[7];
        Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
        Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
        Output.AssignParameter(parm, 2, "@approverrole", "String", 50, "Admin");
        Output.AssignParameter(parm, 3, "@travelflow", "String", 10, "Travel");
        Output.AssignParameter(parm, 4, "@commenttype", "String", 1, commenttype);
        Output.AssignParameter(parm, 5, "@comments", "String", 8000, txtmgrcomments.Text);
        Output.AssignParameter(parm, 6, "@createdby", "String", 50, Session["empcode"].ToString());

        int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_insert_travelcomments", parm);
        //}
    }

    protected void bindPreviouscomments(int travelid)
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            SqlParameter[] parm = new SqlParameter[2];
            Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
            Output.AssignParameter(parm, 1, "@travelflow", "String", 10, "Travel");
            ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_travel_get_comments", parm);
            if (ds.Tables.Count > 0)
            {
                Gridcomments.DataSource = ds;
                Gridcomments.DataBind();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }

    }

    protected void InsertAdvance()
    {
        DataRow dr;
        if (Session["adv"] == null)
        {
            create_advance_table();
        }
        dtable = (DataTable)Session["adv"];

        DataRow drfind = dtable.Rows.Find(ddl_advancecurrency.SelectedValue.ToString());
        if (drfind != null)
        {
        }
        else
        {
            dr = dtable.NewRow();
            dr["Currencyid"] = ddl_advancecurrency.SelectedValue;
            dr["currencycode"] = ddl_advancecurrency.SelectedItem.ToString();
            dr["Amount"] = txtAdvancegiving.Text;

            dtable.Rows.Add(dr);
        }
        Session["adv"] = dtable;
        BindList_adv();
    }

    protected void btnBindList_acc_edu()
    {
        if (Session["adv"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["adv"];
            dview = new DataView(dtable);
            dview.Sort = "education";
        }
        GridAdvancegiving.DataSource = dview;
        GridAdvancegiving.DataBind();
    }

    protected void create_advance_table()
    {
        //child_name 
        //child_DOB

        dtable = new DataTable();
        dtable.Columns.Add("Currencyid", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["Currencyid"] };
        dtable.Columns.Add(new DataColumn("currencycode", typeof(string)));
        dtable.Columns.Add(new DataColumn("Amount", typeof(string)));



        Session["adv"] = dtable;
    }

    protected void BindList_adv()
    {
        if (Session["adv"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["adv"];
            dview = new DataView(dtable);
            dview.Sort = "currencycode";
        }
        GridAdvancegiving.DataSource = dview;
        GridAdvancegiving.DataBind();
    }

    protected void GridAdvancegiving_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["adv"];
        DataRow drfind_adv = dtable.Rows.Find(Convert.ToString(GridAdvancegiving.DataKeys[e.RowIndex].Value));
        if (drfind_adv != null)
        {
            drfind_adv.Delete();
            Session["adv"] = dtable;
            BindList_adv();
        }

    }

    protected void btnAddAdvanceAmount_Click(object sender, EventArgs e)
    {
        InsertAdvance();
        ddl_advancecurrency.SelectedValue = "0";
        txtAdvancegiving.Text = "";
    }

    protected void bind_Advance_Currency()
    {

        string sqlstr = "select id,currencycode from tbl_intranet_currencycode order by currencycode";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_advancecurrency.DataTextField = "currencycode";
        ddl_advancecurrency.DataValueField = "id";
        ddl_advancecurrency.DataSource = ds3;
        ddl_advancecurrency.DataBind();
        ddl_advancecurrency.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_advancecurrency.SelectedValue = "1";
        var itemIndex2 = ddl_advancecurrency.SelectedIndex;
        var item2 = ddl_advancecurrency.Items[itemIndex2];
        ddl_advancecurrency.Items.RemoveAt(itemIndex2);
        ddl_advancecurrency.Items.Insert(1, new ListItem(item2.Text, item2.Value));
    }

    /// ///////////add approver for admin//////////////

    protected void bindApproversgrid3(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
        Grid_Approvers3.DataSource = ds;
        Grid_Approvers3.DataBind();
    }

    protected void bindTripList3(int travelid)
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
            if (Grid_Approvers3.Rows.Count >= 3)
                Grid_Approvers3.Rows[2].Visible = false;

        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
            divKit.Visible = true;
        else
            divKit.Visible = true;
    }

    protected void Grid_Approvers3_PreRender(object sender, EventArgs e)
    {

        if (Grid_Approvers3.Rows.Count > 0)
        {
            Grid_Approvers3.UseAccessibleHeader = true;
            Grid_Approvers3.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}