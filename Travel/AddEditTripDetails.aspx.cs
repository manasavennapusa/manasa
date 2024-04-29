using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_AddEditTripDetails : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
   

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            SmartHr.Common.Alert("session expaired."); 
            ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
        }
        
        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        if (!IsPostBack)
        {
            this.imgdepttime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtdeparttime'))");
           this.imgarrivaltime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtArvlTime'))");
            bind_city();
            bind_Country();
            bind_Currency();
            bind_StayType();
            bind_Tier();
            ddl_mode.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl_modeClass.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");

            if (Request.QueryString["tripid"] != null)  ///////////////enable =false of hotel,comment,departure,arrival///////////
            {
                int tripid = Convert.ToInt32(Request.QueryString["tripid"]);
                grid_Trip(tripid);
                ddl_destination.Enabled = false;
                ddl_destinationCountry.Enabled = false;
                ddl_traveltype.Enabled = false;
                ddl_source.Enabled = false;
                ddl_Fromcountry.Enabled = false;
                txtdepartdate.Enabled = false;
                txtarvlDate.Enabled = false;
                ddl_stayType.Enabled = false;
                rbtnl_hotelms.Enabled = false;
                imgDeprtDate.Visible = false;
                Image1.Visible = false;
                txtEmpCommets.Enabled = false;
                rbtnl_airlinems.Enabled = false;
                txtairlinedetails.Enabled = false;
                txthoteldetails.Enabled = false;

                lblheader.Text = "View/Edit Trip Details";
            }
            else
            {
                ddl_destination.Enabled = true;
                ddl_destinationCountry.Enabled = true;
                ddl_traveltype.Enabled = true;
                ddl_source.Enabled = true;
                ddl_Fromcountry.Enabled = true;
                lblheader.Text = "Add Trip Details";
            }
            if (Request.QueryString["ttype"] != null)
            {
                if (Request.QueryString["ttype"].ToString() == "I")
                {
                    ddl_traveltype.SelectedValue = "D";
                    var itemindx= ddl_traveltype.SelectedIndex;
                    ddl_traveltype.Items.RemoveAt(itemindx);
                 }
                else
                    if (Request.QueryString["ttype"].ToString() == "D")
                    {
                        ddl_traveltype.SelectedValue = "I";
                        var itemindx = ddl_traveltype.SelectedIndex;
                        ddl_traveltype.Items.RemoveAt(itemindx);
                    }

            }
        }
    }


    //=================================================Trip Details Start============================================
    #region Trip

    protected int insertTrips()
    {

        int flag = 0;
        if (Request.QueryString["travelid"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelid"]);

            SqlParameter[] param = new SqlParameter[21];

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

            param[15] = new SqlParameter("@isairlinemembership", SqlDbType.Bit);
            param[15].Value = rbtnl_airlinems.SelectedValue;

            param[16] = new SqlParameter("@airlinemembershipdetails", SqlDbType.VarChar, 8000);
            param[16].Value = txtairlinedetails.Text;

            param[17] = new SqlParameter("@ishotelmembership", SqlDbType.Bit);
            param[17].Value = rbtnl_hotelms.SelectedValue;

            param[18] = new SqlParameter("@hotelmembershipdetails", SqlDbType.VarChar, 8000);
            param[18].Value =txthoteldetails.Text;

            param[19] = new SqlParameter("@arrivaltime", SqlDbType.VarChar, 10);
            param[19].Value = txtArvlTime.Text;

            param[20] = new SqlParameter("@departuretime", SqlDbType.VarChar, 10);
            param[20].Value = txtdeparttime.Text;

             flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_trip_outputTripid", param);
            if (flag > 0)
            
            {
                insert_ticketdetails(Convert.ToInt32(param[14].Value));
                SmartHr.Common.Alert("Trip Saved successfully");
            }
        }
        return flag;
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
            trticket6.Visible = true;
        }
        else
        {
            trFromcountry.Visible = false;
            trFromcity.Visible = true;
            trToCountry.Visible = false;
            trToCity.Visible = true;
            trticket1.Visible = true;
            trticket6.Visible = false;
        }
        bind_Mode(ddl_traveltype.SelectedValue);
    }

    protected void btnSaveTripDetails_Click(object sender, EventArgs e)
    {
        if (txtdepartdate.Text != "")
        {
            DateTime deptdate = Convert.ToDateTime(txtdepartdate.Text);
            if (deptdate.Date >= DateTime.Now.Date)
            {
        int flag = 0;
       
            if (hftripid.Value != "")
            {
                flag = updatetrip();
                insert_ticketdetails(Convert.ToInt32(hftripid.Value));
                hftripid.Value = "";
                btnSaveTripDetails.Text = "Save";
                btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
            }
            else
            {
              flag=  insertTrips();

            }
           
            if (flag > 0)
            {
                SmartHr.Common.Alert("Trip saved successfully");
                clearTrips();
                clearExpansedetails();
                ScriptManager.RegisterStartupScript(this, GetType(), "RefreshParent", "RefreshParent();", true);
            }
            else
            {
                SmartHr.Common.Alert("Trip not saved successfully"); 
            }
            }
            else
            {
                SmartHr.Common.Alert("Please Check the Date of Departure.");
            }
        }
        else
        {
            SmartHr.Common.Alert("Please Enter the Date of Departure.");
        }
    }
   
    protected void btnCancelTripDetails_Click(object sender, EventArgs e)
    {
        divTrip.Visible = false;
      
        clearTrips();
        clearExpansedetails();
        hftripid.Value = "";
        btnSaveTripDetails.Text = "Save";
        btnSaveTripDetails.Attributes.Add("class", "btn btn-primary");
        ScriptManager.RegisterStartupScript(this, GetType(), "ClosePopup", "ClosePopup();", true);  
    }

    protected void grid_Trip(int tripid)
    {

        DateTime todate = Convert.ToDateTime("01/01/1900");
        DateTime fromdate = Convert.ToDateTime("01/01/1900");
       // divTrip.Visible = true;
       // btnAddTrip.Visible = false;
        btnSaveTripDetails.Text = "Update";
        btnSaveTripDetails.Attributes.Add("class", "btn btn-warning");
       // int tripid = Convert.ToInt32(grid_Trip.DataKeys[e.NewEditIndex].Value);
        clearTrips();
        bindTripByTripID(tripid);
        bind_ticketdetails(tripid);
        //for (int i = 0; i < grid_Trip.Rows.Count; i++)
        //    /grid_Trip.Rows[i].ForeColor = System.Drawing.Color.Black;

        //grid_Trip.Rows[e.NewEditIndex].ForeColor = System.Drawing.Color.Blue;

        //fromdate = Convert.ToDateTime(((Label)grid_Trip.Rows[e.NewEditIndex].FindControl("lbldeptDate")).Text.Substring(0, 11));
        //if ((e.NewEditIndex + 1) < grid_Trip.Rows.Count)
        //{
        //    todate = Convert.ToDateTime(((Label)grid_Trip.Rows[e.NewEditIndex + 1].FindControl("lbldeptDate")).Text.Substring(0, 11));
        //}
        //else { todate = Convert.ToDateTime("01/01/1900"); }
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
        //bindperDayAllowances(tripid);
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
            rbtnl_airlinems.SelectedValue = ds.Tables[0].Rows[0]["isairlinemembership"].ToString().ToLower();
            rbtnl_hotelms.SelectedValue = ds.Tables[0].Rows[0]["ishotelmembership"].ToString().ToLower();
            txtairlinedetails.Text = ds.Tables[0].Rows[0]["airlinemembershipdetails"].ToString();
            txthoteldetails.Text = ds.Tables[0].Rows[0]["hotelmembershipdetails"].ToString();
           
            if (rbtnl_airlinems.SelectedValue == "true")
            {
                txtairlinedetails.Visible = true;
            }
            else
            { txtairlinedetails.Visible = false; }

            if (rbtnl_hotelms.SelectedValue == "true")
            {
                txthoteldetails.Visible = true;
            }
            else
            { txthoteldetails.Visible = false; }
        }
    }

    protected int updatetrip()  
    {
        int flag=0;
        if (hftripid.Value != "")
        {
            SqlParameter[] param = new SqlParameter[20];

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

            param[16] = new SqlParameter("@isairlinemembership", SqlDbType.Bit);
            param[16].Value = rbtnl_airlinems.SelectedValue;

            param[17] = new SqlParameter("@airlinemembershipdetails", SqlDbType.VarChar, 8000);
            param[17].Value = txtairlinedetails.Text;

            param[18] = new SqlParameter("@ishotelmembership", SqlDbType.Bit);
            param[18].Value = rbtnl_hotelms.SelectedValue;

            param[19] = new SqlParameter("@hotelmembershipdetails", SqlDbType.VarChar, 8000);
            param[19].Value = txthoteldetails.Text;

            flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_trip]", param);
        }
        return flag;
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
                insert_ticketdetails(Convert.ToInt32(param[14].Value));//, ticketfarecurrency, traveladvancecurrency, staycurrency
                SmartHr.Common.Alert("Trip Saved successfully");
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
        txtlodgefare.Text = "";
        txtLodgeAddress.Text = "";
        if (rbtnl_lodge.SelectedIndex == 0)
        {
            trlodge.Visible = true;
            trlodge2.Visible = true;
            //trlodgeAdv.Visible = false;
           // txt_lodgeAdv.Enabled = false;
        }
        else
        {
            trlodge.Visible = false;
            trlodge2.Visible = false;
            //trlodgeAdv.Visible = true;
            //txt_lodgeAdv.Enabled = true;
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
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master order by countryname";
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
            string sqlstr = "select id,currencycode from tbl_intranet_currencycode order by currencycode";
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddl_fareCurrecny.DataTextField = "currencycode";
            ddl_fareCurrecny.DataValueField = "id";
            ddl_fareCurrecny.DataSource = ds3;
            ddl_fareCurrecny.DataBind();
            ddl_fareCurrecny.SelectedValue = "1";
            var itemIndex2 = ddl_fareCurrecny.SelectedIndex;
            var item2 = ddl_fareCurrecny.Items[itemIndex2];
            ddl_fareCurrecny.Items.RemoveAt(itemIndex2);
            ddl_fareCurrecny.Items.Insert(0, new ListItem(item2.Text, item2.Value));

            ddl_stayCurrency.DataTextField = "currencycode";
            ddl_stayCurrency.DataValueField = "id";
            ddl_stayCurrency.DataSource = ds3;
            ddl_stayCurrency.DataBind();
            ddl_stayCurrency.SelectedValue = "1";
            var itemIndex3 = ddl_stayCurrency.SelectedIndex;
            var item3 = ddl_stayCurrency.Items[itemIndex3];
            ddl_stayCurrency.Items.RemoveAt(itemIndex3);
            ddl_stayCurrency.Items.Insert(0, new ListItem(item3.Text, item3.Value));

            ddlticketAdv.DataTextField = "currencycode";
            ddlticketAdv.DataValueField = "id";
            ddlticketAdv.DataSource = ds3;
            ddlticketAdv.DataBind();
            ddlticketAdv.SelectedValue = "1";
            var itemIndex4 = ddlticketAdv.SelectedIndex;
            var item4 = ddlticketAdv.Items[itemIndex4];
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

    //======================================================End=========================================================

    //=================================================Expanse Details Start============================================
    protected void ddl_mode_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_ModeClass(Convert.ToInt32(ddl_mode.SelectedValue));
    }

    protected void insert_ticketdetails(int tripid) //, decimal ticketfarecurrency, decimal traveladvancecurrency, decimal staycurrency
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
                param[7].Value = hfticket.Value.ToString(); 
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
            param[39].Value = System.Data.SqlTypes.SqlDecimal.Null; //Convert.ToDecimal(txtticketfair.Text.Trim() == "" ? "0" : txtticketfair.Text) * ticketfarecurrency;

            param[40] = new SqlParameter("@traveladvanceamount_INR", SqlDbType.Decimal);
            param[40].Value = System.Data.SqlTypes.SqlDecimal.Null;// Convert.ToDecimal(txtticketAdv.Text.Trim() == "" ? "0" : txtticketAdv.Text) * traveladvancecurrency;

            param[41] = new SqlParameter("@stay_fare_INR", SqlDbType.Decimal);
            param[41].Value = System.Data.SqlTypes.SqlDecimal.Null; //Convert.ToDecimal(txtlodgefare.Text.Trim() == "" ? "0" : txtlodgefare.Text) * staycurrency;

            param[42] = new SqlParameter("@stayadvanceamount_INR", SqlDbType.Decimal);
            param[42].Value = System.Data.SqlTypes.SqlDecimal.Null; //Convert.ToDecimal(txt_lodgeAdv.Text.Trim() == "" ? "0" : txt_lodgeAdv.Text) * staycurrency;

            param[43] = new SqlParameter("@converadvanceamount_INR", SqlDbType.Decimal);
            param[43].Value = System.Data.SqlTypes.SqlDecimal.Null; //Convert.ToDecimal(txtconvAdvance.Text.Trim() == "" ? "0" : txtconvAdvance.Text) * staycurrency;

            param[44] = new SqlParameter("@oopadvanceamount_INR", SqlDbType.Decimal);
            param[44].Value = System.Data.SqlTypes.SqlDecimal.Null; //Convert.ToDecimal(txtoopAdv.Text.Trim() == "" ? "0" : txtoopAdv.Text) * staycurrency;

            param[45] = new SqlParameter("@mealsadvanceamount_INR", SqlDbType.Decimal);
            param[45].Value = System.Data.SqlTypes.SqlDecimal.Null; //Convert.ToDecimal(txtFoodAdv.Text.Trim() == "" ? "0" : txtFoodAdv.Text) * staycurrency;

            param[46] = new SqlParameter("@traveladvance_currencycode", SqlDbType.Int);
            param[46].Value = ddlticketAdv.SelectedValue;



            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insertORupdate_TicketDetails", param);
            int ticketid = 0;
            if (i > 0)
            {
                ticketid = Convert.ToInt32(param[38].Value);
                if (chkException.Checked == true)
                {
                    //insertException(ticketid);
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
            txtticketAdv.Text = ds.Tables[0].Rows[0]["traveladvanceamount"].ToString();
            ddlticketAdv.SelectedValue = ds.Tables[0].Rows[0]["traveladvance_currencycode"].ToString();
            //    trticketadv.Visible = true;
            //}
            //else
            //{
            //    trticketadv.Visible = false;
            //}
            //=============================Stay===============================================
             rbtnl_lodge.SelectedValue = ds.Tables[0].Rows[0]["isstaybooked"].ToString();
            ddl_stayCurrency.SelectedValue = ds.Tables[0].Rows[0]["stay_currencycode"].ToString();
            if (ds.Tables[0].Rows[0]["isstaybooked"].ToString() == "True")
            {

                txtlodgefare.Text = ds.Tables[0].Rows[0]["stay_fare"].ToString();
                txtLodgeAddress.Text = ds.Tables[0].Rows[0]["stay_address"].ToString();
                trlodge.Visible = true;
                trlodge2.Visible = true;
               // trlodgeAdv.Visible = false;
            }
            else
            {
                trlodge.Visible = false;
                trlodge2.Visible = false;
               // trlodgeAdv.Visible = true;
            }

            //rbtnl_lodgeAdv.SelectedValue = ds.Tables[0].Rows[0]["stayadvancegiven"].ToString();

            //if (ds.Tables[0].Rows[0]["stayadvancegiven"].ToString() == "True")
            //{
            //txt_lodgeAdv.Text = ds.Tables[0].Rows[0]["stayadvanceamount"].ToString();
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

            hfticket.Value = ds.Tables[0].Rows[0]["ticketuploadpath"].ToString();
            if (hfticket.Value.ToString()!="")
            {
                ticketlink.Visible = true;
                ticketlink.HRef = "~/Travel/Upload/" + hfticket.Value.ToString();
            }
            else
            {
                hfticket.Value = "";
                ticketlink.Visible = false;
            }
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
                fupTicket.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
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

    //protected void insertException(int ticketid)
    //{
    //    string approvercode = "";
    //    if (Grid_Approvers.Rows.Count > 0)
    //    {
    //        approvercode = ((Label)Grid_Approvers.Rows[1].FindControl("lblcode")).Text;
    //    }
    //    SqlParameter[] param = new SqlParameter[4];

    //    param[0] = new SqlParameter("@ticketid", SqlDbType.Int);
    //    param[0].Value = ticketid;

    //    param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
    //    param[1].Value = approvercode;

    //    param[2] = new SqlParameter("@approverlevel", SqlDbType.Int);
    //    param[2].Value = 2;

    //    param[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
    //    param[3].Value = Session["empcode"].ToString();

    //    int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insertTravelTicketException", param);

    //}

    protected void rbtnl_airlinems_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtairlinedetails.Text = "";
        if (rbtnl_airlinems.SelectedValue == "true")
            txtairlinedetails.Visible = true;
        else
            txtairlinedetails.Visible = false;

    }

    protected void rbtnl_hotelms_SelectedIndexChanged(object sender, EventArgs e)
    {
        txthoteldetails.Text = "";
        if (rbtnl_hotelms.SelectedValue == "true")
            txthoteldetails.Visible = true;
        else
            txthoteldetails.Visible = false;
    }

    protected void btn_ticketupload_Click(object sender, EventArgs e)
    {
            string filepath = uploadticket();
            if (filepath != "")
            {
                hfticket.Value = filepath;
                ticketlink.Visible = true;
                ticketlink.HRef="~/Travel/Upload/" + hfticket.Value.ToString();
            }
            else
            {
                hfticket.Value = "";
                ticketlink.Visible = false;
            }
    }
}