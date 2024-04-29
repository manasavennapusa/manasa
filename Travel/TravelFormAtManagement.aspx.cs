using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class Travel_TravelFormAtManagement : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;

    DataTable dtable = new DataTable();
    DataActivity DataActivity = new DataActivity();
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
            btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
            btnAllowaceSave.Attributes.Add("class", "btn btn-primary");
            if (Request.QueryString["travelID"] != null)
            {
                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                bindTripList(travelid);
                bindTripList2(travelid);
                bindAdvanceList(travelid);
                bindApproversgrid(travelid);
                bindApproversgrid2(travelid);
                bindEmpDetails(travelid);
                bindPreviouscomments(travelid);
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
        string triptype = "";
        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
        {
            divKit.Visible = true;
            triptype = "I";
        }
        else
        {
            divKit.Visible = true;
            triptype = "D";
        }

        //string triptype = "";
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    int trip = 0;
        //    for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
        //    {
        //        if (ds.Tables[0].Rows[k]["triptype"].ToString() == "I")
        //        {
        //            trip = trip + 1;
        //        }
        //    }
        //    if (trip > 0)
        //        triptype = "I";
        //    else
        //        triptype = "D";

        //}
        ViewState["triptype"] = triptype;
    }

    protected void btnAddTrip_Click(object sender, EventArgs e)
    {
        tbltrip.Visible = true;
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

            SqlParameter[] param = new SqlParameter[16];

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
            param[12].Value = System.Data.SqlTypes.SqlChars.Null;

            param[13] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            param[13].Value = Session["empcode"].ToString();

            param[14] = new SqlParameter("@departuretime", SqlDbType.VarChar, 10);
            param[14].Value = txtdeparttime.Text;

            param[15] = new SqlParameter("@arrivaltime", SqlDbType.VarChar, 10);
            param[15].Value = txtArvlTime.Text;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_trip", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Trip Not Saved.");

            }
            else
            {
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
        }
        else
        {
            trFromcountry.Visible = false;
            trFromcity.Visible = true;
            trToCountry.Visible = false;
            trToCity.Visible = true;
        }
    }

    protected void btnSaveTripDetails_Click(object sender, EventArgs e)
    {

        if (hftripid.Value != "")
        {
            updatetrip();
        }
        else
        {
            insertTrips();
            tbltrip.Visible = false;
            btnAddTrip.Visible = true;
        }
        bindTripList(Convert.ToInt32(Request.QueryString["travelID"]));
    }

    protected void btnCancelTripDetails_Click(object sender, EventArgs e)
    {
        tbltrip.Visible = false;
        btnAddTrip.Visible = true;
        clearTrips();
        clearTrips();
        hftripid.Value = "";
        btnSaveTripDetails.Text = "Save";
        btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
    }

    protected void grid_Trip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        tbltrip.Visible = true;
        btnAddTrip.Visible = false;
        btnSaveTripDetails.Text = "Update";
        btnSaveTripDetails.Attributes.Add("class", "btn btn-warning");
        bindTripByTripID(Convert.ToInt32(grid_Trip.DataKeys[e.NewEditIndex].Value));
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
            param[14].Value = System.Data.SqlTypes.SqlChars.Null;

            param[15] = new SqlParameter("@updateby", SqlDbType.VarChar, 50);
            param[15].Value = Session["empcode"].ToString();

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_trip]", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Trip Not Updated Successfully");

            }
            else
            {
                SmartHr.Common.Alert("Trip Updated successfully");

                clearTrips();
                hftripid.Value = "";
                tbltrip.Visible = false;
                btnAddTrip.Visible = true;
                btnSaveTripDetails.Text = "Save";
                btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");

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
    }

    #endregion Trip
    //=================================================Trip Details End============================================

    //=================================================Travel Details Start============================================


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
            lblTravelPurpose.Text = ds.Tables[0].Rows[0]["travelpurpose"].ToString();
            lblAcCode.Text = ds.Tables[0].Rows[0]["accountcode"].ToString();
            lblCostcenter.Text = ds.Tables[0].Rows[0]["cost_center_name"].ToString();
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
            }
            else
            {
                trkitamount.Visible = false;
                trprvkit.Visible = false;
            }
        }
    }

    //=================================================Travel Details End============================================

    //=============================================Bind Controls===================================
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
        ddl_Fromcountry.Items.Insert(0, new ListItem("--Select--", "0"));

        ddl_destinationCountry.DataTextField = "countryname";
        ddl_destinationCountry.DataValueField = "cid";
        ddl_destinationCountry.DataSource = ds3;
        ddl_destinationCountry.DataBind();
        ddl_destinationCountry.Items.Insert(0, new ListItem("--Select--", "0"));
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
    }
    //=============================================End=============================================



    //=================================================Appprove Reject Back ============================================

    protected void btnSumitForm_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            if (Request.QueryString["travelID"] != null)
            {
                Connection = DataActivity.OpenConnection();
                _Transaction = Connection.BeginTransaction();
                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                SqlParameter[] parm = new SqlParameter[4];
                Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
                Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "1");
                Output.AssignParameter(parm, 3, "@approver", "String", 10, "mgmt");
                insertTravelComments(travelid, "A", _Transaction, Connection);
                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelfrom", parm);
                _Transaction.Commit();


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
            if (Request.QueryString["travelID"] != null)
            {

                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                SqlParameter[] param1 = new SqlParameter[1];
                param1[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param1[0].Value = travelid;
                ds.Clear();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getExpanseApproversbyTravelID", param1);
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {

                    if (ViewState["triptype"] != null)
                        if (ViewState["triptype"].ToString() == "I")
                        {
                            if (ds.Tables[0].Rows[k]["approverlevel"].ToString() == "3")
                            {
                                sendMail(ds.Tables[0].Rows[k]["approvercode"].ToString());
                            }
                        }
                        else
                            if (ds.Tables[0].Rows[k]["approverlevel"].ToString() == "2")
                                sendMail(ds.Tables[0].Rows[k]["approvercode"].ToString());
                }
            }
            Response.Redirect("ApproveTravelFormByManager.aspx?user=mgmt&approved=true");
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
                Connection = DataActivity.OpenConnection();
                _Transaction = Connection.BeginTransaction();
                if (Request.QueryString["travelID"] != null)
                {
                    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                    SqlParameter[] parm = new SqlParameter[4];
                    Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
                    Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "2");
                    Output.AssignParameter(parm, 3, "@approver", "String", 10, "mgmt");
                    insertTravelComments(travelid, "R", _Transaction, Connection);
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelfrom", parm);
                    _Transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                _Transaction.Rollback();
                Flag = 0;
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

                Response.Redirect("ApproveTravelFormByManager.aspx?user=mgmt&rejected=true");
            }
        }
        
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproveTravelFormByManager.aspx?user=mgmt");
    }

    //=============================================End===================================


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

    protected void Grid_Approvers_PreRender(object sender, EventArgs e)
    {
        if (Grid_Approvers.Rows.Count > 0)
        {
            Grid_Approvers.UseAccessibleHeader = true;
            Grid_Approvers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void sendMail(string empcode)
    {
        //string sqlstr = @"select empcode,official_email_id,emp_fname+' ' +emp_m_name+' ' +emp_l_name as empname from tbl_intranet_employee_jobDetails where empcode='" + empcode + "'";

        //DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        //if (ds1.Tables[0].Rows.Count > 0)
        //{
        //    if (ds1.Tables[0].Rows[0]["official_email_id"].ToString() != "")
        //    {
        //        string fromEmail = ConfigurationManager.AppSettings["fromEmail"].ToString();
        //        string fromPwd = ConfigurationManager.AppSettings["pwd"].ToString();
        //        string fromName = ConfigurationManager.AppSettings["fromName"].ToString();
        //        string smtp = ConfigurationManager.AppSettings["smtp"].ToString();
        //        string emailLogo = ConfigurationManager.AppSettings["emailLogo"].ToString();
        //        string subject = "Regarding Travel Request";
        //        string bodyContent = "A Travel Application (Account Code: " + lblAcCode.Text + ") request has been approved by " + Session["name"].ToString() + ".";
        //        string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
        //        Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
        //    }
        //}
    }

    protected void btn_travelCancel_Click(object sender, EventArgs e)
    {
           SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            int Flag = 0;
            try
            {
                if (Request.QueryString["travelID"] != null)
                {

                    Connection = DataActivity.OpenConnection();
                    _Transaction = Connection.BeginTransaction();

                    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);

                    insertTravelComments(travelid, "C", _Transaction, Connection);
                    sqlstr = "update tbl_travel_TravelForm set istravelcanceled=1 where travelid=" + travelid + "";
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, sqlstr);
                    _Transaction.Commit();
                    //SqlParameter[] param = new SqlParameter[1];
                    //param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                    //param[0].Value = travelid;
                    //ds.Clear();
                    //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    sendMail(ds.Tables[0].Rows[i]["approvercode"].ToString());
                    //}
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
            if (Flag < 0)
            {
                SmartHr.Common.Alert("Travel Form is Not Cancelled");
            }
            else
            {
                Response.Redirect("ApproveTravelFormByManager.aspx?user=mgmt&cancelled=true");
            }
        }

    protected void insertTravelComments(int travelid, string commenttype, SqlTransaction _Transaction, SqlConnection Connection)
    {
        //if (txtmgrcomments.Text.Trim() != "")
        //{
        SqlParameter[] parm = new SqlParameter[7];
        Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
        Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
        Output.AssignParameter(parm, 2, "@approverrole", "String", 50, "Management");
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
  
    /// /////////////////////////add approver list for management////////

    protected void bindApproversgrid2(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
        Grid_Approvers2.DataSource = ds;
        Grid_Approvers2.DataBind();
    }

    protected void bindTripList2(int travelid)
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
            if (Grid_Approvers2.Rows.Count >= 3)
                Grid_Approvers2.Rows[2].Visible = false;

        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
            divKit.Visible = true;
        else
            divKit.Visible = true;
    }

    protected void Grid_Approvers2_PreRender(object sender, EventArgs e)
    {
        if (Grid_Approvers2.Rows.Count > 0)
        {
            Grid_Approvers2.UseAccessibleHeader = true;
            Grid_Approvers2.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}