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
using System.IO;


public partial class Travel_TravelForm : System.Web.UI.Page
{
    string filepath;
    string sqlstr, _userCode;
    DataSet ds = new DataSet();
    public int i;
    int c;
    DataTable dtable = new DataTable();
    DataView dview;
    DataActivity DataActivity = new DataActivity();
    //DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
           
            this.imgdepttime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtdeparttime'))");
            this.imgarrivaltime.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtArvlTime'))");
            Session.Remove("Advance");
            bind_city();
            bind_Country();
            bind_Currency();
            bind_StayType();
            bindApproversgrid();
            bindTripList();
        }
       
        // CompareValidator2.ValueToCompare = DateTime.Now.ToShortDateString();
    }

    protected void btnSumitForm_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            if (grid_Trip.Rows.Count > 0)
            {
                if (Grid_Approvers.Rows.Count < 4)
                {
                    SmartHr.Common.Alert("Approvers for Travel are not set.Please Contact your Manager.");
                    return;
                }
                int travelID = insertTravel(Connection, _Transaction);
                if (travelID > 0)
                {
                    insertApprovers(travelID, Connection, _Transaction);
                    insertAllTrips(travelID, Connection, _Transaction);
                    generateTravelcode(travelID, Connection, _Transaction);
                    _Transaction.Commit();
                    //SendEmail(travelID, 0);
                    //SendEmail(travelID, 1);
                    clearTrips();
                    clearAlloance();
                    SmartHr.Common.Alert("Travel Form Submitted Successfully.");
                }
                else
                {
                    SmartHr.Common.Alert("Travel form Not Submitted");
                }
            }
            else
            {
                SmartHr.Common.Alert("Please Add Trips for this Travel");
            }
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }

    }

    void SendEmail(int travelId, int type)
    {
        if (type == 0)
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponSubmissionOfRequestFactory();
            EmailClient client = new EmailClient(email);
            Approvers.Travel.Approvers appovers = new Approvers.Travel.Approvers();
            
            client.toEmailId = Session["OfficialEmailId"].ToString().Trim();
            client.empCode = Session["empcode"].ToString();
            client.appsendername = Session["name"].ToString().Trim();
            client.employeeName = Session["name"].ToString().Trim();
            client.requestNumber = appovers.TravelDetail(travelId)["accountcode"].ToString();
            client.Send();
        }
        else if (type == 1)
        {
            Approvers.Travel.Approvers approver = new Approvers.Travel.Approvers();

            DataTable dt = approver.GetApprovers(travelId, 1);

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow row in dt.Rows)
                {
                    if (row["official_email_id"].ToString() != "")
                    {
                        try
                        {
                            EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponSubmissionOfRequestApprover();
                            EmailClient client = new EmailClient(email);
                            client.toEmailId = row["official_email_id"].ToString().Trim();
                            client.empCode = row["approvercode"].ToString().Trim();
                            client.employeeName = row["name"].ToString().Trim();
                            client.appsendername = Session["name"].ToString().Trim();
                            client.requestNumber = row["accountcode"].ToString().Trim();
                            client.Send();
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
    //=================================================Miscellaneous Allowance Start===================================                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         
    #region Allowance
    protected void create_Advance_Table(string filelocation1)
    {
        dtable = new DataTable();
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        //dtable.Columns.Add(new DataColumn("Desc", typeof(string )));
        dtable.Columns.Add(new DataColumn("CurrencyId", typeof(string)));
        dtable.Columns.Add("fileName", typeof(string));
        dtable.Columns.Add("Currency", typeof(string));
        dtable.Columns.Add("Amount", typeof(string));

        Session["Advance"] = dtable;
    }
    protected void bindAdvanceList()
    {
        dtable = (DataTable)Session["Advance"];
        dview = new DataView(dtable);
        dview.Sort = "autoID";
        grid_Advance.DataSource = dview;
        grid_Advance.DataBind();
    }

    protected void insert_Advance(string fileName)
    {
        DataRow dr;
        if (Session["Advance"] == null)
        {
            create_Advance_Table(fileName);
        }
        dtable = (DataTable)Session["Advance"];

        //object[] keyArrary = new object[1];
        //keyArrary[0] = txtAdvanceDesc.Text;


        //DataRow drfind = dtable.Rows.Find(keyArrary);
        //if (drfind != null)
        //{
        //    SmartHr.Common.Alert("Advance already added.");
        //}
        //else
        //{
        dr = dtable.NewRow();
        dr["fileName"] = fileName;
        dr["CurrencyId"] = ddlCurrecny.SelectedValue;
        dr["Currency"] = ddlCurrecny.SelectedItem.Text;
        dr["Amount"] = txtAdvanceAmount.Text.Trim();

        dtable.Rows.Add(dr);
        // }

        Session["Advance"] = dtable;

        bindAdvanceList();
    }
    protected void btnAddAdvance_Click(object sender, EventArgs e)
    {
       
        string defaultUpload1 = "";
        string fileName="";

        if (File_UploadDft1.HasFile)
        {
            fileName = Path.GetFileName(File_UploadDft1.PostedFile.FileName);
            try
            {
                File_UploadDft1.PostedFile.SaveAs(Server.MapPath("~/Travel/voucher/" + fileName));
                filepath = "Travel/voucher/" + fileName;
            }
            catch (Exception exc)
            {

            }
        }
        else
        {
            defaultUpload1 = "";
        }
        insert_Advance(fileName);

        //txtAdvanceDesc.Text = "";
        ddlCurrecny.SelectedValue = "0";
        txtAdvanceAmount.Text = "";
    }
    protected void grid_Advance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["Advance"];
        DataRow drfind_Trip = dtable.Rows.Find(Convert.ToString(grid_Advance.DataKeys[e.RowIndex].Value));
        if (drfind_Trip != null)
        {
            drfind_Trip.Delete();
            Session["Advance"] = dtable;
            bindAdvanceList();
        }
    }


    protected void insertMiscellaneousAllowance(int travelid)
    {
        if (Session["Advance"] != null)
        {
            dtable = (DataTable)Session["Advance"];

            for (int k = 0; k < dtable.Rows.Count; k++)
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param[0].Value = travelid;

                param[1] = new SqlParameter("@advance_desc", SqlDbType.VarChar, 1000);
                param[1].Value = dtable.Rows[k]["Desc"].ToString();

                param[2] = new SqlParameter("@currencytype", SqlDbType.Int);
                param[2].Value = Convert.ToInt32(dtable.Rows[k]["CurrencyId"]);

                param[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                param[3].Value = Convert.ToDecimal(dtable.Rows[k]["Amount"]);

                param[4] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                param[4].Value = Session["empcode"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_Miscellaneous_Allowance", param);
            }
        }
    }
    #endregion Allowance
    //=================================================Miscellaneous Allowance End===================================

    //=================================================Trip Details Start============================================
    #region Trip
    protected void bindTripList()
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_get_trips_temp", param);
        grid_Trip.DataSource = ds;
        grid_Trip.DataBind();

        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
            divKit.Visible = true;
        else
            divKit.Visible = true;
    }

    protected void insert_Trip()
    {
        //SqlParameter[] param = new SqlParameter[1];
        //param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        //param[0].Value = Session["empcode"].ToString();
        ////ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_get_trips_temp", param);
        ////grid_Trip.DataSource = ds;
        ////grid_Trip.DataBind();

        ////connection = activity.OpenConnection();
        //sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type WHERE branch_id='" + branchid + "' order by dept_type_name";
        //DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);


        if (txtdepartdate.Text != "")
        {
            DateTime deptdate = Convert.ToDateTime(txtdepartdate.Text);
            if (deptdate.Date >= DateTime.Now.Date)
            {
                SqlParameter[] param = new SqlParameter[20];
                param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                param[0].Value = Session["empcode"].ToString();

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
                param[12].Value = txtEmpCommets.Text;

                param[13] = new SqlParameter("@PTD", SqlDbType.VarChar, 30);
                param[13].Value = "";

                param[14] = new SqlParameter("@GL_Code", SqlDbType.VarChar, 30);
                param[14].Value = System.Data.SqlTypes.SqlChars.Null;

                param[15] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                param[15].Value = Session["empcode"].ToString();

                param[16] = new SqlParameter("@isairlinemembership", SqlDbType.Bit);
                param[16].Value = rbtnl_airlinems.SelectedValue;

                param[17] = new SqlParameter("@airlinemembershipdetails", SqlDbType.VarChar, 8000);
                param[17].Value = txtairlinedetails.Text;

                param[18] = new SqlParameter("@ishotelmembership", SqlDbType.Bit);
                param[18].Value = rbtnl_hotelms.SelectedValue;

                param[19] = new SqlParameter("@hotelmembershipdetails", SqlDbType.VarChar, 8000);
                param[19].Value = txthoteldetails.Text;

                int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_trip_temp", param);
                if (flag > 0)
                {
                    bindTripList();
                    clearfields();
                    SmartHr.Common.Alert("Trip Added Successfully");
                }
                else
                {
                    SmartHr.Common.Alert("Trip Not Added Successfully");
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

    protected void updatetrip()
    {

        if (ViewState["tripid"] != null)
        {
            SqlParameter[] param = new SqlParameter[20];

            param[0] = new SqlParameter("@tripid", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(ViewState["tripid"]);

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
            param[13].Value = "";//txtPTD.Text;

            param[14] = new SqlParameter("@GL_Code", SqlDbType.VarChar, 30);
            param[14].Value = System.Data.SqlTypes.SqlChars.Null;

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

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_trip_temp]", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Trip Not Updated Successfully");

            }
            else
            {
                SmartHr.Common.Alert("Trip Updated successfully");

                clearfields();
                bindTripList();
            }
        }
    }

    protected void clearfields()
    {
        ddl_traveltype.SelectedValue = "0";
        // txtPTD.Text = "";
        txtdepartdate.Text = "";
        txtarvlDate.Text = "";
        txtArvlTime.Text = "";
        txtdeparttime.Text = "";
        ddl_source.SelectedValue = "0";
        ddl_Fromcountry.SelectedValue = "0";
        txtEmpCommets.Text = "";
        ddl_destination.SelectedValue = "0";
        ddl_destinationCountry.SelectedValue = "0";
        ddl_stayType.SelectedValue = "0";
        txtairlinedetails.Text = "";
        txthoteldetails.Text = "";
        txtairlinedetails.Visible = false;
        txthoteldetails.Visible = false;
        rbtnl_airlinems.SelectedValue = "false";
        rbtnl_hotelms.SelectedValue = "false";
        hfkitallowanceid.Value = "";
        ViewState["tripid"] = null;
        btnAdd.Text = "Add";
    }

    protected void btnAddTrip_Click(object sender, EventArgs e)
    {
        DateTime fromdate = new DateTime();
        DateTime todate = new DateTime();
        DateTime fromtime = new DateTime();
        DateTime totime = new DateTime();
        fromdate = Convert.ToDateTime(txtdepartdate.Text);
        todate = Convert.ToDateTime(txtarvlDate.Text);
        fromtime = Convert.ToDateTime(txtdeparttime.Text);
        totime = Convert.ToDateTime(txtArvlTime.Text);
        TimeSpan diffhrs = TimeSpan.FromHours(2);
        if (fromdate == todate)
        {
            if (fromtime > totime)
            {
                Output.Show("Time Of Arrival Must be Greater than Time Of Departure");
                return;
            }
        }



        if (ViewState["tripid"] == null)
        {
            SqlParameter[] sqlparam = new SqlParameter[2];
            Output.AssignParameter(sqlparam, 0, "@empcode", "String", 50, _userCode);
            Output.AssignParameter(sqlparam, 1, "@fromdate", "DateTime", 10, txtdepartdate.Text);
            //Output.AssignParameter(sqlparam, 2, "@todate", "DateTime", 10, txtarvlDate.Text);
          
            SqlConnection connection = activity.OpenConnection();
            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "[sp_travel_validate_applied_date]", sqlparam);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Output.Show("Travel Form Already Approved");
                return;
            }
          
            insert_Trip();
        }
        else
        {
            updatetrip();
        }
    }
    protected void grid_Trip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int tripid = Convert.ToInt32(grid_Trip.DataKeys[e.NewEditIndex].Value);
        bindTripByTripID(tripid);
    }

    protected void bindTripByTripID(int tripid)
    {
        sqlstr = @"select * from tbl_travel_TripDetails_Temp where tripid=" + tripid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (ds.Tables[0].Rows.Count > 0)
        {
            ViewState["tripid"] = ds.Tables[0].Rows[0]["tripid"].ToString();
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
            if (ds.Tables[0].Rows[0]["isairlinemembership"].ToString().ToLower() != "")
                rbtnl_airlinems.SelectedValue = ds.Tables[0].Rows[0]["isairlinemembership"].ToString().ToLower();
            if (ds.Tables[0].Rows[0]["ishotelmembership"].ToString().ToLower() != "")
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
            btnAdd.Text = "Update";
        }
    }
    protected void grid_Trip_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_TripDetails_Temp where tripid=" + grid_Trip.DataKeys[e.RowIndex].Value;

        int flag = 0;
        flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        if (flag > 0)
        {
            bindTripList();
            SmartHr.Common.Alert("Trip  Deleted Successfully");
        }
        else
        {
            SmartHr.Common.Alert("Trip Not Deleted Successfully");
        }
    }
    protected void insertAllTrips(int travelid, SqlConnection Connection, SqlTransaction _transaction)
    {
        sqlstr = @"select * from tbl_travel_TripDetails_Temp where empcode='" + Session["empcode"].ToString()+"'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {


            for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
            {
                SqlParameter[] param = new SqlParameter[20];

                param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param[0].Value = travelid;

                if (ds.Tables[0].Rows[k]["triptype"].ToString() == "I")
                {
                    param[1] = new SqlParameter("@fromsourcecountry", SqlDbType.Int);
                    param[1].Value = ds.Tables[0].Rows[k]["fromsourcecountry"].ToString();

                    param[2] = new SqlParameter("@fromsourcecode", SqlDbType.Int);
                    param[2].Value = System.Data.SqlTypes.SqlInt32.Null;

                    param[3] = new SqlParameter("@todestinationcountry", SqlDbType.Int);
                    param[3].Value = ds.Tables[0].Rows[k]["todestinationcountry"].ToString();

                    param[4] = new SqlParameter("@todestinationcode", SqlDbType.Int);
                    param[4].Value = System.Data.SqlTypes.SqlInt32.Null;
                }
                else
                {
                    param[1] = new SqlParameter("@fromsourcecountry", SqlDbType.Int);
                    param[1].Value = System.Data.SqlTypes.SqlInt32.Null;

                    param[2] = new SqlParameter("@fromsourcecode", SqlDbType.Int);
                    param[2].Value = ds.Tables[0].Rows[k]["fromsourcecode"].ToString();

                    param[3] = new SqlParameter("@todestinationcountry", SqlDbType.Int);
                    param[3].Value = System.Data.SqlTypes.SqlInt32.Null;

                    param[4] = new SqlParameter("@todestinationcode", SqlDbType.Int);
                    param[4].Value = ds.Tables[0].Rows[k]["todestinationcode"].ToString();
                }

                param[5] = new SqlParameter("@departuredate", SqlDbType.DateTime);
                param[5].Value = ds.Tables[0].Rows[k]["departuredate"].ToString();

                param[6] = new SqlParameter("@arrivaldate", SqlDbType.DateTime);
                param[6].Value = ds.Tables[0].Rows[k]["arrivaldate"].ToString();

                param[7] = new SqlParameter("@departuretime", SqlDbType.VarChar, 10);
                param[7].Value = ds.Tables[0].Rows[k]["departuretime"].ToString();

                param[8] = new SqlParameter("@arrivaltime", SqlDbType.VarChar, 10);
                param[8].Value = ds.Tables[0].Rows[k]["arrivaltime"].ToString();

                param[9] = new SqlParameter("@triptype", SqlDbType.VarChar, 1);
                param[9].Value = ds.Tables[0].Rows[k]["triptype"].ToString();

                param[10] = new SqlParameter("@staytype", SqlDbType.Int);
                param[10].Value = ds.Tables[0].Rows[k]["staytype"].ToString();

                param[11] = new SqlParameter("@noofdays", SqlDbType.Decimal);
                param[11].Value = System.Data.SqlTypes.SqlDecimal.Null;

                param[12] = new SqlParameter("@empcomments", SqlDbType.VarChar, 200);
                param[12].Value = ds.Tables[0].Rows[k]["empcomments"].ToString();

                param[13] = new SqlParameter("@PTD", SqlDbType.VarChar, 30);
                param[13].Value = "";//ds.Tables[0].Rows[k]["ptd"].ToString();

                param[14] = new SqlParameter("@GL_Code", SqlDbType.VarChar, 30);
                param[14].Value = System.Data.SqlTypes.SqlChars.Null;

                param[15] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                param[15].Value = Session["empcode"].ToString();

                param[16] = new SqlParameter("@isairlinemembership", SqlDbType.Bit);
                param[16].Value = ds.Tables[0].Rows[k]["isairlinemembership"].ToString();

                param[17] = new SqlParameter("@airlinemembershipdetails", SqlDbType.VarChar, 8000);
                param[17].Value = ds.Tables[0].Rows[k]["airlinemembershipdetails"].ToString();

                param[18] = new SqlParameter("@ishotelmembership", SqlDbType.Bit);
                param[18].Value = ds.Tables[0].Rows[k]["ishotelmembership"].ToString();

                param[19] = new SqlParameter("@hotelmembershipdetails", SqlDbType.VarChar, 8000);
                param[19].Value = ds.Tables[0].Rows[k]["hotelmembershipdetails"].ToString();

                int flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _transaction, "sp_travel_insert_trip", param);
                if (flag > 0)
                {
                    sqlstr = @"delete from tbl_travel_TripDetails_Temp where tripid=" + ds.Tables[0].Rows[k]["tripid"].ToString();

                    SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _transaction, sqlstr);
                }
            }
        }
    }
    protected void generateTravelcode(int travelid, SqlConnection Connection, SqlTransaction _transaction)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _transaction, "sp_travel_genrate_travelcode", param);
    }
    protected void insertKitAllowance(int travelid)
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

        DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_kitallowance", param);
    }

    #endregion Trip
    //=================================================Trip Details End===========================================================================

    protected int insertTravel(SqlConnection Connection, SqlTransaction _transaction)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();

        param[1] = new SqlParameter("@travelpurpose", SqlDbType.VarChar, 100);
        param[1].Value = txt_travelpurpose.Text;

        param[2] = new SqlParameter("@accpac_code", SqlDbType.VarChar, 50);
        param[2].Value = System.Data.SqlTypes.SqlChars.Null;

        param[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        param[3].Value = Session["empcode"].ToString();

        param[4] = new SqlParameter("@travelid", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        param[5] = new SqlParameter("@iskitallowancetaken", SqlDbType.Bit);
        param[5].Value = rbtnl_kitallowance.SelectedValue;

        param[6] = new SqlParameter("@insurence_need", SqlDbType.Bit);
        param[6].Value = rbtnl_insurance.SelectedValue;
        if (rbtnl_visa.SelectedValue == "true")
        {

            param[7] = new SqlParameter("@visa_arraged", SqlDbType.Bit);
            param[7].Value = rbtnl_visa.SelectedValue;
        }
        else
        {
            param[7] = new SqlParameter("@visa_arraged", SqlDbType.Bit);
            param[7].Value = rbtnl_visa.SelectedValue;
        }

        int i = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _transaction, "sp_travel_insert_travelform", param);
        if (i > 0)
        {
            return Convert.ToInt32(param[4].Value);
        }
        else
            return 0;
    }

    protected void insertApprovers(int travelid, SqlConnection Connection, SqlTransaction _transaction)
    {
        string triptype = "";
        SqlParameter[] par = new SqlParameter[1];
        par[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        par[0].Value = Session["empcode"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_get_trips_temp", par);
        DataRow[] dr = ds.Tables[0].Select("triptype='I'");

        if (dr.Length > 0)
            triptype = "I";
        else
            triptype = "D";


        //  -----------------------------------Insert Travel Form Approvers------------------------------
        ds = getapprovers(triptype, "Travel");

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param[0].Value = travelid;

                param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
                param[1].Value = ds.Tables[0].Rows[i]["approvercode"].ToString();

                param[2] = new SqlParameter("@approverlevel", SqlDbType.Int);
                param[2].Value = ds.Tables[0].Rows[i]["level"].ToString();

                param[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                param[3].Value = Session["empcode"].ToString();

                param[4] = new SqlParameter("@approverrole", SqlDbType.VarChar, 50);
                param[4].Value = ds.Tables[0].Rows[i]["approverrole"].ToString();

                SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _transaction, "sp_travel_insert_travelformApporvers", param);

            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                try
                {
                    if (ds.Tables[0].Rows[i]["level"].ToString() == "2")
                    {
                        if (triptype == "I")
                        {

                        }
                    }

                    if (ds.Tables[0].Rows[i]["level"].ToString() == "1")
                    {
                        // Send Mail
                    }
                }
                catch
                { }
            }
        }

        //  -----------------------------------Insert Travel Expanse Approvers------------------------------
        ds = getapprovers(triptype, "Expense");

        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param[0].Value = travelid;

                param[1] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
                param[1].Value = ds.Tables[0].Rows[i]["approvercode"].ToString();

                param[2] = new SqlParameter("@approverlevel", SqlDbType.Int);
                param[2].Value = ds.Tables[0].Rows[i]["level"].ToString();

                param[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                param[3].Value = Session["empcode"].ToString();

                param[4] = new SqlParameter("@approverrole", SqlDbType.VarChar, 50);
                param[4].Value = ds.Tables[0].Rows[i]["approverrole"].ToString();

                SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _transaction, "sp_travel_insert_travelExpanseApporvers", param);
            }
        }
    }

    protected DataSet getapprovers(string triptype, string Workflow)
    {
        SqlParameter[] param1 = new SqlParameter[3];

        param1[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param1[0].Value = Session["empcode"].ToString();

        param1[1] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param1[1].Value = triptype;

        param1[2] = new SqlParameter("@workflow", SqlDbType.VarChar, 30);
        param1[2].Value = Workflow;

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApprovers", param1);
        return ds;
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

    protected void bind_city()
    {
        sqlstr = "select cid,city from tbl_intranet_city order by city";
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
        string sqlstr = "select currencycode,id from dbo.tbl_intranet_currencycode";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlCurrecny.DataTextField = "currencycode";
        ddlCurrecny.DataValueField = "id";
        ddlCurrecny.DataSource = ds3;
        ddlCurrecny.DataBind();
        ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
       // ddlCurrecny.SelectedValue = "98";
        //var itemIndex = ddlCurrecny.SelectedIndex;
        //var item = ddlCurrecny.Items[itemIndex];
        //ddlCurrecny.Items.RemoveAt(itemIndex);
        //ddlCurrecny.Items.Insert(1, new ListItem(item.Text, item.Value));
    }

    protected void clearTrips()
    {
        txt_travelpurpose.Text = "";

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
        // txtPTD.Text = "";
        Session.Remove("Trip");
        grid_Trip.DataSource = null;
        grid_Trip.DataBind();
        txtairlinedetails.Text = "";
        txthoteldetails.Text = "";
        txtairlinedetails.Visible = false;
        txthoteldetails.Visible = false;
        divKit.Visible = false;
        lblKitallowanceamount.Text = "";
        lblprvkitallownace.Text = "";
        rbtnl_kitallowance.SelectedValue = "false";
        rbtnl_insurance.SelectedValue = "false";
        rbtnl_visa.SelectedValue = "false";
        rbtnl_airlinems.SelectedValue = "false";
        rbtnl_hotelms.SelectedValue = "false";
        trkitamount.Visible = false;
        trprvkit.Visible = false;
        hfkitallowanceid.Value = "";
    }

    protected void clearAlloance()
    {
        txtAdvanceAmount.Text = "";
        ddlCurrecny.SelectedValue = "0";
        //txtAdvanceDesc.Text = "";
        Session.Remove("Advance");
        grid_Advance.DataSource = null;
        grid_Advance.DataBind();
    }

    protected void bindApproversgrid()
    {
        //string sqlstr = "select ap.empcode,coalesce(jd.emp_fname,'')+' '+coalesce(jd.emp_m_name,'')+' '+coalesce (jd.emp_l_name,'') as name,approvercode,level,traveltype,workflow  from tbl_travel_ApproverHirarchy ap inner join tbl_intranet_employee_jobDetails jd on jd.empcode=ap.approvercode where ap.empcode='" + Session["empcode"].ToString() + "'";
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();
        DataSet ds3 = new DataSet();
        //ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insert_approvers_from_EDB", param);
        Grid_Approvers.DataSource = ds3;
        Grid_Approvers.DataBind();
        if (ds3.Tables[0].Rows.Count != 4)
        {
            SmartHr.Common.Alert("You are not able to submit Travel Form. Because of Approvers for Your Travel are not set.Please Contact your Manager");
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

    protected void grid_Trip_PreRender(object sender, EventArgs e)
    {
        if (grid_Trip.Rows.Count > 0)
        {
            grid_Trip.UseAccessibleHeader = true;
            grid_Trip.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        }
        else
        {
            lblKitallowanceamount.Text = "";
            lblprvkitallownace.Text = "";
            hfkitallowanceid.Value = "";
            trkitamount.Visible = false;
            trprvkit.Visible = false;
        }
    }

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

    protected void btnClear_Click(object sender, EventArgs e)
    {
        clearfields();
    }

    protected void txtArvlTime_TextChanged(object sender, EventArgs e)
    {
        if (txtArvlTime.Text != "")
        {
            if (txtdepartdate.Text == "")
            {
                SmartHr.Common.Alert("Please Enter the Date of Departure.");

            }
        }
    }

    protected void txtdeparttime_TextChanged(object sender, EventArgs e)
    {
        if (txtdeparttime.Text != "")
        {
            if (txtarvlDate.Text == "")
            {
                SmartHr.Common.Alert("Please Enter the Date of arrival.");
            }
        }
    }

    protected void rbtnl_visa_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbtnl_visa.SelectedValue == "true")
        {
            SmartHr.Common.Alert(" Minimum Time Required For Visa Is 1 Month");
        }
    }

}