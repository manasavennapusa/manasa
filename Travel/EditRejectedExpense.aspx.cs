using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;


public partial class Travel_EditRejectedExpense : System.Web.UI.Page
{
    decimal grdtotal = 0;
    string sqlstr;
    DataSet ds;
    DataView dview;
    DataRow dr;
    DataTable dtable = new DataTable();
    DataActivity DataActivity = new DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }

        Page.Form.Attributes.Add("enctype", "multipart/form-data");

        if (!IsPostBack)
        {
            bind_ddltrip();
            bind_Currency();
            bindTravelSummary();
            BindList_Travel();
            BindList_OOP();
            BindList_lodging();
            BindList_miscellaneous();
            BindList_PersonalCar();
            BindList_telephonedetails();
            bindTripList();
            bindEmpDetails();
            bindPreviouscomments();
        }
    }

    protected void bindEmpDetails()
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;
            ds.Clear();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelDetailsbyTravelID", param);

            if (ds.Tables[0].Rows.Count > 0)
            {

                rbtnl_insurance.SelectedValue = ds.Tables[0].Rows[0]["insurence_need"].ToString().ToLower();
                rbtnl_visa.SelectedValue = ds.Tables[0].Rows[0]["visa_arraged"].ToString().ToLower();
                rbtnl_kitallowance.SelectedValue = ds.Tables[0].Rows[0]["iskitallowancetaken"].ToString().ToLower();
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
            }
        }
    }

    protected void bindTripList()
    {
        if (Request.QueryString["travelID"] != null)
        {
            int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = travelid;
            ds.Clear();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTripsByTravelID", param);
            grid_Trip.DataSource = ds;
            grid_Trip.DataBind();
            DataRow[] dr = ds.Tables[0].Select("triptype='I'");
            if (dr.Length > 0)
            {
                trkitallowance1.Visible = true;
                trkitallowance2.Visible = true;
                divKit.Visible = true;
            }
            else
            {
                trkitallowance1.Visible = false;
                trkitallowance2.Visible = false;
                divKit.Visible = false;
            }
        }
    }

    private void bind_ddltrip()
    {
        int ID = Convert.ToInt32(Request.QueryString["travelid"]);

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = ID;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTripID", param);

        ddlTrip.DataSource = ds;
        ddlTrip.DataTextField = "Trip";
        ddlTrip.DataValueField = "tripid";
        ddlTrip.DataBind();
        ddlTrip.Items.Insert(0, new ListItem("--Select--", "0"));

        ddllodingtrip.DataSource = ds;
        ddllodingtrip.DataTextField = "Trip";
        ddllodingtrip.DataValueField = "tripid";
        ddllodingtrip.DataBind();
        ddllodingtrip.Items.Insert(0, new ListItem("--Select--", "0"));

        ddlooptrip.DataSource = ds;
        ddlooptrip.DataTextField = "Trip";
        ddlooptrip.DataValueField = "tripid";
        ddlooptrip.DataBind();
        ddlooptrip.Items.Insert(0, new ListItem("--Select--", "0"));

        ddlmisceTrip.DataSource = ds;
        ddlmisceTrip.DataTextField = "Trip";
        ddlmisceTrip.DataValueField = "tripid";
        ddlmisceTrip.DataBind();
        ddlmisceTrip.Items.Insert(0, new ListItem("--Select--", "0"));

        ddlperCartrip.DataSource = ds;
        ddlperCartrip.DataTextField = "Trip";
        ddlperCartrip.DataValueField = "tripid";
        ddlperCartrip.DataBind();
        ddlperCartrip.Items.Insert(0, new ListItem("--Select--", "0"));

        ddlphonetrip.DataSource = ds;
        ddlphonetrip.DataTextField = "Trip";
        ddlphonetrip.DataValueField = "tripid";
        ddlphonetrip.DataBind();
        ddlphonetrip.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_Currency()
    {
        try
        {
            string sqlstr = "select id,currencycode from tbl_intranet_currencycode order by currencycode";
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddlTravelCurrecny.DataTextField = "currencycode";
            ddlTravelCurrecny.DataValueField = "id";
            ddlTravelCurrecny.DataSource = ds3;
            ddlTravelCurrecny.DataBind();
            ddlTravelCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlTravelCurrecny.SelectedValue = "1";
            var itemIndex = ddlTravelCurrecny.SelectedIndex;
            var item = ddlTravelCurrecny.Items[itemIndex];
            ddlTravelCurrecny.Items.RemoveAt(itemIndex);
            ddlTravelCurrecny.Items.Insert(1, new ListItem(item.Text, item.Value));

            ddlLodgeCurrency.DataTextField = "currencycode";
            ddlLodgeCurrency.DataValueField = "id";
            ddlLodgeCurrency.DataSource = ds3;
            ddlLodgeCurrency.DataBind();
            ddlLodgeCurrency.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlLodgeCurrency.SelectedValue = "1";
            var itemIndex2 = ddlLodgeCurrency.SelectedIndex;
            var item2 = ddlLodgeCurrency.Items[itemIndex2];
            ddlLodgeCurrency.Items.RemoveAt(itemIndex2);
            ddlLodgeCurrency.Items.Insert(1, new ListItem(item2.Text, item2.Value));

            ddlOOPCurrecny.DataTextField = "currencycode";
            ddlOOPCurrecny.DataValueField = "id";
            ddlOOPCurrecny.DataSource = ds3;
            ddlOOPCurrecny.DataBind();
            ddlOOPCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlOOPCurrecny.SelectedValue = "1";
            var itemIndex3 = ddlOOPCurrecny.SelectedIndex;
            var item3 = ddlOOPCurrecny.Items[itemIndex3];
            ddlOOPCurrecny.Items.RemoveAt(itemIndex3);
            ddlOOPCurrecny.Items.Insert(1, new ListItem(item3.Text, item3.Value));

            ddlMiscCurrency.DataTextField = "currencycode";
            ddlMiscCurrency.DataValueField = "id";
            ddlMiscCurrency.DataSource = ds3;
            ddlMiscCurrency.DataBind();
            ddlMiscCurrency.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlMiscCurrency.SelectedValue = "1";
            var itemIndex4 = ddlMiscCurrency.SelectedIndex;
            var item4 = ddlMiscCurrency.Items[itemIndex3];
            ddlMiscCurrency.Items.RemoveAt(itemIndex3);
            ddlMiscCurrency.Items.Insert(1, new ListItem(item4.Text, item4.Value));

            ddlPersonalcarCurrency.DataTextField = "currencycode";
            ddlPersonalcarCurrency.DataValueField = "id";
            ddlPersonalcarCurrency.DataSource = ds3;
            ddlPersonalcarCurrency.DataBind();
            ddlPersonalcarCurrency.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlPersonalcarCurrency.SelectedValue = "1";
            var itemIndex5 = ddlPersonalcarCurrency.SelectedIndex;
            var item5 = ddlPersonalcarCurrency.Items[itemIndex5];
            ddlPersonalcarCurrency.Items.RemoveAt(itemIndex5);
            ddlPersonalcarCurrency.Items.Insert(1, new ListItem(item5.Text, item5.Value));

            ddlPhoneCurrency.DataTextField = "currencycode";
            ddlPhoneCurrency.DataValueField = "id";
            ddlPhoneCurrency.DataSource = ds3;
            ddlPhoneCurrency.DataBind();
            ddlPhoneCurrency.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlPhoneCurrency.SelectedValue = "1";
            var itemIndex6 = ddlPhoneCurrency.SelectedIndex;
            var item6 = ddlPhoneCurrency.Items[itemIndex6];
            ddlPhoneCurrency.Items.RemoveAt(itemIndex6);
            ddlPhoneCurrency.Items.Insert(1, new ListItem(item6.Text, item6.Value));
        }
        catch { }
    }

    protected void bindTravelSummary()
    {
        if (Request.QueryString["travelID"] != null)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(Request.QueryString["travelID"]);
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelSummary", param);


            //if (ds.Tables.Count > 0)
            //{
            //    gridAdvanceSummary.DataSource = ds.Tables[0];
            //    gridAdvanceSummary.DataBind();
            //}
            if (ds.Tables.Count > 1)
            {
                grd_prebooked.DataSource = ds.Tables[1];
                grd_prebooked.DataBind();
            }
            if (ds.Tables.Count > 2)
            {
                grid_allowancetotal.DataSource = ds.Tables[2];
                grid_allowancetotal.DataBind();
            }
            if (ds.Tables.Count > 3)
            {
                grd_kitallowancedetials.DataSource = ds.Tables[3];
                grd_kitallowancedetials.DataBind();
            }
            if (ds.Tables.Count > 4)
            {
                grd_pretraveltotals.DataSource = ds.Tables[4];
                grd_pretraveltotals.DataBind();

            }
            if (ds.Tables.Count > 5)
            {
                grd_estimationtotals.DataSource = ds.Tables[5];
                grd_estimationtotals.DataBind();
            }
        }
    }

    protected void bindExpanseSummary()
    {
        if (Request.QueryString["travelID"] != null)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(Request.QueryString["travelID"]);
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getExpanseSummary", param);
            if (ds.Tables.Count > 0)
            {
                grdExpenseSummary.DataSource = ds.Tables[0];
                grdExpenseSummary.DataBind();
            }
            if (ds.Tables.Count > 1)
            {
                grdTotalExpanse.DataSource = ds.Tables[1];
                grdTotalExpanse.DataBind();
            }
        }
    }

    //Insert and Display Travel Details-------------------------

    protected void btnTravelAdd_Click(object sender, EventArgs e)
    {
        if (ViewState["travel"] == null)
        {
            Insert_travel_details();
        }
        else
        {
            Update_Travel_Details();
        }
    }

    private void BindList_Travel()
    {

        if (Request.QueryString["travelID"] != null)
        {
            sqlstr = @"select ed.*,td.tripno,ct.currencycode  from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where ed.status=1 and  ed.expensetype='Travel' and td.travelid= " + Request.QueryString["travelID"].ToString();
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            grdtravel.DataSource = ds;
            grdtravel.DataBind();
            bindExpanseSummary();
            UpdatePanelSummary.Update();
        }
    }

    protected void Insert_travel_details()
    {
        int count = 0;
        if (Request.QueryString["travelid"] != null)
        {
            string travelbill = "";

            if (File_UploadDft1.HasFile)
            {
                string strFileName;
                string file_name = "travel" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft1.FileName;
                try
                {
                    File_UploadDft1.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    travelbill = file_name + "_" + strFileName;

                }
                catch (Exception exc)
                {
                }
            }

            int ID = Convert.ToInt32(Request.QueryString["travelid"]);

            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlTrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtReceiptNumber.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtDate.Text;

            sqlParam[3] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[3].Value = txtAmount.Text == "" ? "0" : txtAmount.Text;

            sqlParam[4] = new SqlParameter("@travelby", SqlDbType.VarChar, 100);
            sqlParam[4].Value = txtTravelby.Text;

            sqlParam[5] = new SqlParameter("@travelfrom", SqlDbType.VarChar, 50);
            sqlParam[5].Value = txtFrom.Text;

            sqlParam[6] = new SqlParameter("@travelto", SqlDbType.VarChar, 50);
            sqlParam[6].Value = txtTo.Text;

            sqlParam[7] = new SqlParameter("@exptype", SqlDbType.VarChar, 50);
            sqlParam[7].Value = "Travel";

            sqlParam[8] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[8].Value = travelbill;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlTravelCurrecny.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_travelbill.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txttravelcomment.Text;

            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_insert_TravelExpanses]", sqlParam);
            if (count > 0)
            {
                cleartravel();
                BindList_Travel();
                Page.ClientScript.RegisterClientScriptBlock(btnTravelAdd.GetType(), "OnClick", "<script>window.scroll(0,0); </script>");
                SmartHr.Common.Alert("Travel Details Added Successfully");
            }
            else
            {
                SmartHr.Common.Alert("Travel Details Not Added Successfully");
            }

        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        cleartravel();
    }

    protected void grdtravel_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ViewState["travel"] = grdtravel.DataKeys[e.NewEditIndex].Value.ToString();
        sqlstr = "select * from dbo.tbl_travel_ExpenseDetails where expenseid=" + grdtravel.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlTravelCurrecny.SelectedValue = ds.Tables[0].Rows[0]["currenceycode"].ToString();
                ddlTrip.SelectedValue = ds.Tables[0].Rows[0]["tripid"].ToString();
                txtReceiptNumber.Text = ds.Tables[0].Rows[0]["receiptno"].ToString();
                txtDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["traveldate"]).ToString("MM/dd/yyyy");
                txtTravelby.Text = ds.Tables[0].Rows[0]["travelby"].ToString();
                txtFrom.Text = ds.Tables[0].Rows[0]["travelfrom"].ToString();
                txtTo.Text = ds.Tables[0].Rows[0]["travelto"].ToString();
                txtAmount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                txttravelcomment.Text = ds.Tables[0].Rows[0]["billdetails"].ToString();
                rbtnl_travelbill.SelectedValue = ds.Tables[0].Rows[0]["having_bill"].ToString().ToLower();
                if (rbtnl_travelbill.SelectedValue == "true")
                {
                    divtravllbiillcoments.Visible = true;
                    divtravllbiillupload.Visible = true;
                }
                else
                {
                    divtravllbiillcoments.Visible = true;
                }
                btnTravelAdd.Text = "Update";
            }
    }

    protected void Update_Travel_Details()
    {
        if (ViewState["travel"] != null)
        {
            int count = 0;
            string travelbill = "";

            if (File_UploadDft1.HasFile)
            {
                string strFileName;
                string file_name = "travel" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft1.FileName;
                try
                {
                    File_UploadDft1.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    travelbill = file_name + "_" + strFileName;

                }
                catch (Exception exc)
                {
                }
            }


            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlTrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtReceiptNumber.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtDate.Text;

            sqlParam[3] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[3].Value = txtAmount.Text == "" ? "0" : txtAmount.Text;

            sqlParam[4] = new SqlParameter("@travelby", SqlDbType.VarChar, 100);
            sqlParam[4].Value = txtTravelby.Text;

            sqlParam[5] = new SqlParameter("@travelfrom", SqlDbType.VarChar, 50);
            sqlParam[5].Value = txtFrom.Text;

            sqlParam[6] = new SqlParameter("@travelto", SqlDbType.VarChar, 50);
            sqlParam[6].Value = txtTo.Text;

            sqlParam[7] = new SqlParameter("@expenseid", SqlDbType.Int);
            sqlParam[7].Value = ViewState["travel"].ToString();

            sqlParam[8] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[8].Value = travelbill;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlTravelCurrecny.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_travelbill.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txttravelcomment.Text;


            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_TravelExpanses]", sqlParam);
            if (count > 0)
            {
                cleartravel();
                BindList_Travel();
                Page.ClientScript.RegisterClientScriptBlock(btnTravelAdd.GetType(), "OnClick", "<script>window.scroll(0,0); </script>");
                SmartHr.Common.Alert("Travel Details Updated Successfully");
            }
            else
            {
                SmartHr.Common.Alert("Travel Details Not Updated Successfully");
            }

        }
    }

    protected void cleartravel()
    {
        ddlTravelCurrecny.SelectedValue = "0";
        ddlTrip.SelectedValue = "0";
        txtReceiptNumber.Text = "";
        txtDate.Text = "";
        txtTravelby.Text = "";
        txtFrom.Text = "";
        txtTo.Text = "";
        txtAmount.Text = "";
        txttravelcomment.Text = "";
        rbtnl_travelbill.SelectedIndex = -1;
        divtravllbiillcoments.Visible = false;
        divtravllbiillupload.Visible = false;
        ViewState["travel"] = null;
        btnTravelAdd.Text = "Add";
    }

    protected void grdtravel_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_ExpenseDetails where expenseid=" + grdtravel.DataKeys[e.RowIndex].Value.ToString();
        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (flag > 0)
        {
            SmartHr.Common.Alert("Travel Expense Record is deleted Successfully");
            BindList_Travel();
        }
        else
        {
            SmartHr.Common.Alert("Record is not deleted Successfully");
        }

    }

    protected void rbtnl_travelbill_SelectedIndexChanged(object sender, EventArgs e)
    {
        txttravelcomment.Text = "";
        if (rbtnl_travelbill.SelectedValue == "true")
        {
            divtravllbiillupload.Visible = true;
            divtravllbiillcoments.Visible = true;
            re_travalfileupload.Enabled = true;
            re_travelcommment.Enabled = true;
            rq_travalfileupload.Enabled = true;
            rq_travelcomment.Enabled = false;
        }
        else
        {
            divtravllbiillupload.Visible = false;
            divtravllbiillcoments.Visible = true;
            re_travalfileupload.Enabled = false;
            re_travelcommment.Enabled = true;
            rq_travalfileupload.Enabled = false;
            rq_travelcomment.Enabled = true;
        }

    }

    //Insert and Display Lodging Details-------------------------

    protected void btnLodging_Click(object sender, EventArgs e)
    {
        if (ViewState["lodge"] == null)
        {
            Insert_lodging_details();
        }
        else
        {
            Update_lodging_details();
        }
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "scrollWintop", "scrollWintop();", true);
    }

    private void BindList_lodging()
    {
        if (Request.QueryString["travelID"] != null)
        {
            sqlstr = @"select ed.*,td.tripno,ct.currencycode from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where  ed.expensetype='L & C (Stay)' and td.travelid= " + Request.QueryString["travelID"].ToString();
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            grdlodging.DataSource = ds;
            grdlodging.DataBind();
            bindExpanseSummary();
            UpdatePanelSummary.Update();
        }
    }

    protected void grdlodging_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_ExpenseDetails where expenseid=" + grdlodging.DataKeys[e.RowIndex].Value.ToString();
        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (flag > 0)
        {
            SmartHr.Common.Alert("Lodging Expense Record is deleted Successfully");
            BindList_lodging();
        }
        else
        {
            SmartHr.Common.Alert("Record is not deleted Successfully");
        }
    }

    protected void grdlodging_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            grdtotal = grdtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = grdtotal.ToString();
        }
    }

    protected void rbtnl_lodge_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtlodgingbilldetails.Text = "";
        if (rbtnl_lodge.SelectedValue == "true")
        {
            divlodgebillupload.Visible = true;
            divlodgecomment.Visible = true;
            re_lodgebillupload.Enabled = true;
            re_lodgebilldetails.Enabled = true;
            rq_lodgebillupload.Enabled = true;
            rq_lodgebilldetails.Enabled = false;
        }
        else
        {
            divlodgebillupload.Visible = false;
            divlodgecomment.Visible = true;
            re_lodgebillupload.Enabled = false;
            re_lodgebilldetails.Enabled = true;
            rq_lodgebillupload.Enabled = false;
            rq_lodgebilldetails.Enabled = true;
        }
    }

    protected void grdlodging_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ViewState["lodge"] = grdlodging.DataKeys[e.NewEditIndex].Value.ToString();
        sqlstr = "select * from dbo.tbl_travel_ExpenseDetails where expenseid=" + grdlodging.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtLodgingReceiptno.Text = ds.Tables[0].Rows[0]["receiptno"].ToString();
                txtStartdate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["lodgingStartdate"]).ToString("MM/dd/yyyy");
                txtEnddate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["lodgingEnddate"]).ToString("MM/dd/yyyy");
                txtNoofdays.Text = Convert.ToInt32(ds.Tables[0].Rows[0]["noofdays"]).ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["details"].ToString();
                txtLodgingamount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                ddllodingtrip.SelectedValue = ds.Tables[0].Rows[0]["tripid"].ToString();
                ddlLodgeCurrency.SelectedValue = ds.Tables[0].Rows[0]["currenceycode"].ToString();
                txtlodgingbilldetails.Text = ds.Tables[0].Rows[0]["billdetails"].ToString();
                rbtnl_lodge.SelectedValue = ds.Tables[0].Rows[0]["having_bill"].ToString().ToLower();
                if (rbtnl_lodge.SelectedValue == "true")
                {
                    divlodgecomment.Visible = true;
                    divlodgebillupload.Visible = true;
                }
                else
                {
                    divlodgecomment.Visible = true;
                }
                btnLodging.Text = "Update";
            }
    }

    protected void Insert_lodging_details()
    {
        int count = 0;
        if (Request.QueryString["travelid"] != null)
        {

            string lodgingbill = "";
            if (File_UploadDft2.HasFile)
            {
                string strFileName;
                string file_name = "OOP" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft2.FileName;
                try
                {
                    File_UploadDft2.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    lodgingbill = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }

            int ID = Convert.ToInt32(Request.QueryString["travelid"]);

            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddllodingtrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtLodgingReceiptno.Text;

            sqlParam[2] = new SqlParameter("@lodgingstartdate", SqlDbType.VarChar, 150);
            sqlParam[2].Value = txtStartdate.Text;

            sqlParam[3] = new SqlParameter("@lodgingenddate", SqlDbType.VarChar, 150);
            sqlParam[3].Value = txtEnddate.Text;

            sqlParam[4] = new SqlParameter("@noofdays", SqlDbType.VarChar, 50);
            sqlParam[4].Value = txtNoofdays.Text;

            sqlParam[5] = new SqlParameter("@amount", SqlDbType.VarChar, 50);
            sqlParam[5].Value = txtLodgingamount.Text == "" ? "0" : txtLodgingamount.Text;

            sqlParam[6] = new SqlParameter("@exptype", SqlDbType.VarChar, 50);
            sqlParam[6].Value = "L & C (Stay)";

            sqlParam[7] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[7].Value = lodgingbill;

            sqlParam[8] = new SqlParameter("@details", SqlDbType.VarChar, 500);
            sqlParam[8].Value = txtDescription.Text;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlLodgeCurrency.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_lodge.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txtlodgingbilldetails.Text;

            count = count + DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_insert_LodgingExpanses]", sqlParam);

            if (count > 0)
            {
                SmartHr.Common.Alert("L & C (Stay) Details Added Successfully");
                BindList_lodging();
                clearlodging();
            }
            else
            {
                SmartHr.Common.Alert("L & C (Stay) Details Not Added Successfully");
            }
        }

    }

    protected void btnLodgeCancel_Click(object sender, EventArgs e)
    {

        clearlodging();
    }

    protected void Update_lodging_details()
    {
        if (ViewState["lodge"] != null)
        {
            if (1 == 1)
            {
                int count = 0;
                if (Request.QueryString["travelid"] != null)
                {

                    string lodgingbill = "";
                    if (File_UploadDft2.HasFile)
                    {
                        string strFileName;
                        string file_name = "OOP" + System.DateTime.Now.GetHashCode().ToString();

                        strFileName = File_UploadDft2.FileName;
                        try
                        {
                            File_UploadDft2.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                            lodgingbill = file_name + "_" + strFileName;
                        }
                        catch (Exception exc)
                        {
                        }
                    }

                    int ID = Convert.ToInt32(Request.QueryString["travelid"]);

                    SqlParameter[] sqlParam = new SqlParameter[12];

                    sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
                    sqlParam[0].Value = ddllodingtrip.SelectedValue;

                    sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
                    sqlParam[1].Value = txtLodgingReceiptno.Text;

                    sqlParam[2] = new SqlParameter("@lodgingstartdate", SqlDbType.VarChar, 150);
                    sqlParam[2].Value = txtStartdate.Text;

                    sqlParam[3] = new SqlParameter("@lodgingenddate", SqlDbType.VarChar, 150);
                    sqlParam[3].Value = txtEnddate.Text;

                    sqlParam[4] = new SqlParameter("@noofdays", SqlDbType.VarChar, 50);
                    sqlParam[4].Value = txtNoofdays.Text;

                    sqlParam[5] = new SqlParameter("@amount", SqlDbType.VarChar, 50);
                    sqlParam[5].Value = txtLodgingamount.Text == "" ? "0" : txtLodgingamount.Text;

                    sqlParam[6] = new SqlParameter("@expenseid", SqlDbType.Int);
                    sqlParam[6].Value = ViewState["lodge"].ToString();

                    sqlParam[7] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
                    sqlParam[7].Value = lodgingbill;

                    sqlParam[8] = new SqlParameter("@details", SqlDbType.VarChar, 500);
                    sqlParam[8].Value = txtDescription.Text;

                    sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
                    sqlParam[9].Value = ddlLodgeCurrency.SelectedValue;

                    sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
                    sqlParam[10].Value = rbtnl_lodge.SelectedValue;

                    sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
                    sqlParam[11].Value = txtlodgingbilldetails.Text;

                    count = count + DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_LodgingExpanses]", sqlParam);

                    if (count > 0)
                    {
                        SmartHr.Common.Alert("L & C (Stay) Details Updated Successfully");
                        BindList_lodging();
                        clearlodging();
                    }
                    else
                    {
                        SmartHr.Common.Alert("L & C (Stay) Details Not Updated Successfully");
                    }
                }
            }
        }

    }

    protected void clearlodging()
    {
        txtLodgingReceiptno.Text = "";
        txtStartdate.Text = "";
        txtEnddate.Text = "";
        txtNoofdays.Text = "";
        txtDescription.Text = "";
        txtLodgingamount.Text = "";
        ddllodingtrip.SelectedValue = "0";
        ddlLodgeCurrency.SelectedValue = "0";
        txtlodgingbilldetails.Text = "";
        rbtnl_lodge.SelectedIndex = -1;
        ViewState["lodge"] = null;
        divlodgecomment.Visible = false;
        divlodgebillupload.Visible = false;
        btnLodging.Text = "Add";
    }

    //Insert and Display OOP Details-------------------------

    protected void btnOOP_Click(object sender, EventArgs e)
    {
        if (ViewState["OOP"] == null)
        {
            Insert_oop_details();
        }
        else
        {
            Update_oop_details();
        }
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "scrollWintop", "scrollWintop();", true);
    }

    private void BindList_OOP()
    {
        if (Request.QueryString["travelID"] != null)
        {
            sqlstr = @"select ed.*,td.tripno ,ct.currencycode from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where  ed.expensetype='OOP' and td.travelid= " + Request.QueryString["travelID"].ToString();
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            grdoop.DataSource = ds;
            grdoop.DataBind();
            bindExpanseSummary();
            UpdatePanelSummary.Update();
        }

    }

    protected void grdoop_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_ExpenseDetails where expenseid=" + grdoop.DataKeys[e.RowIndex].Value.ToString();
        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (flag > 0)
        {
            SmartHr.Common.Alert("OOP Expense Record is deleted Successfully");
            BindList_OOP();
        }
        else
        {
            SmartHr.Common.Alert("Record is not deleted Successfully");
        }
    }

    protected void grdoop_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            grdtotal = grdtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = grdtotal.ToString();
        }
    }

    protected void rbtnl_oopbill_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtoopbilldetails.Text = "";
        if (rbtnl_oopbill.SelectedValue == "true")
        {
            divoopbill.Visible = true;
            divoopbilldetails.Visible = true;
            re_oopbillupload.Enabled = true;
            re_oopbilldetails.Enabled = true;
            rq_oopbillupload.Enabled = true;
            rq_oopbilldetails.Enabled = false;
        }
        else
        {
            divoopbill.Visible = false;
            divoopbilldetails.Visible = true;
            re_oopbillupload.Enabled = false;
            re_oopbilldetails.Enabled = true;
            rq_oopbillupload.Enabled = false;
            rq_oopbilldetails.Enabled = true;
        }
    }

    protected void grdoop_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ViewState["OOP"] = grdoop.DataKeys[e.NewEditIndex].Value.ToString();
        sqlstr = "select * from dbo.tbl_travel_ExpenseDetails where expenseid=" + grdoop.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtOOPReceiptNo.Text = ds.Tables[0].Rows[0]["receiptno"].ToString();
                txtOOPDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["traveldate"]).ToString("MM/dd/yyyy");
                txtOOPAmount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                txtOOPDetails.Text = ds.Tables[0].Rows[0]["details"].ToString();
                ddlOOPCurrecny.SelectedValue = ds.Tables[0].Rows[0]["currenceycode"].ToString();
                ddlooptrip.SelectedValue = ds.Tables[0].Rows[0]["tripid"].ToString();
                txtoopbilldetails.Text = ds.Tables[0].Rows[0]["billdetails"].ToString();
                rbtnl_oopbill.SelectedValue = ds.Tables[0].Rows[0]["having_bill"].ToString().ToLower();
                if (rbtnl_oopbill.SelectedValue == "true")
                {
                    divoopbill.Visible = true;
                    divoopbilldetails.Visible = true;
                }
                else
                {
                    divoopbill.Visible = false;
                    divoopbilldetails.Visible = true;
                }
                btnOOP.Text = "Update";
            }
    }

    protected void Insert_oop_details()
    {
        int count = 0;
        if (Request.QueryString["travelid"] != null)
        {

            string OOPbill = "";

            if (File_UploadDft4.HasFile)
            {
                string strFileName;
                string file_name = "OOP" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft4.FileName;
                try
                {
                    File_UploadDft4.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    OOPbill = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }

            int ID = Convert.ToInt32(Request.QueryString["travelid"]);


            SqlParameter[] sqlParam = new SqlParameter[10];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlooptrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtOOPReceiptNo.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtOOPDate.Text;

            sqlParam[3] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[3].Value = txtOOPAmount.Text;

            sqlParam[4] = new SqlParameter("@exptype", SqlDbType.VarChar, 50);
            sqlParam[4].Value = "OOP";

            sqlParam[5] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[5].Value = OOPbill;

            sqlParam[6] = new SqlParameter("@details", SqlDbType.VarChar, 500);
            sqlParam[6].Value = txtOOPDetails.Text;

            sqlParam[7] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[7].Value = ddlOOPCurrecny.SelectedValue;

            sqlParam[8] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[8].Value = rbtnl_oopbill.SelectedValue;

            sqlParam[9] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[9].Value = txtoopbilldetails.Text;

            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_insert_OOPExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("OOP Details Added Successfully");

                BindList_OOP();
            }
            else
            {
                SmartHr.Common.Alert("OOP Details Not Added Successfully");
            }
        }

    }

    protected void clearOOP()
    {
        txtOOPReceiptNo.Text = "";
        txtOOPDate.Text = "";
        txtOOPAmount.Text = "";
        txtOOPDetails.Text = "";
        ddlOOPCurrecny.SelectedValue = "0";
        ddlooptrip.SelectedValue = "0";
        txtoopbilldetails.Text = "";
        rbtnl_oopbill.SelectedIndex = -1;
        divoopbill.Visible = false;
        divoopbilldetails.Visible = false;
        ViewState["OOP"] = null;
        btnOOP.Text = "Add";
    }

    protected void btnOOPCancel_Click(object sender, EventArgs e)
    {
        clearOOP();
    }

    protected void Update_oop_details()
    {
        if (ViewState["OOP"] != null)
        {
            int count = 0;
            if (Request.QueryString["travelid"] != null)
            {

                string OOPbill = "";

                if (File_UploadDft4.HasFile)
                {
                    string strFileName;
                    string file_name = "OOP" + System.DateTime.Now.GetHashCode().ToString();

                    strFileName = File_UploadDft4.FileName;
                    try
                    {
                        File_UploadDft4.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                        OOPbill = file_name + "_" + strFileName;
                    }
                    catch (Exception exc)
                    {
                    }
                }

                int ID = Convert.ToInt32(Request.QueryString["travelid"]);


                SqlParameter[] sqlParam = new SqlParameter[10];

                sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
                sqlParam[0].Value = ddlooptrip.SelectedValue;

                sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
                sqlParam[1].Value = txtOOPReceiptNo.Text;

                sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
                sqlParam[2].Value = txtOOPDate.Text;

                sqlParam[3] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
                sqlParam[3].Value = txtOOPAmount.Text;

                sqlParam[4] = new SqlParameter("@expenseid", SqlDbType.Int);
                sqlParam[4].Value = ViewState["OOP"].ToString();

                sqlParam[5] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
                sqlParam[5].Value = OOPbill;

                sqlParam[6] = new SqlParameter("@details", SqlDbType.VarChar, 500);
                sqlParam[6].Value = txtOOPDetails.Text;

                sqlParam[7] = new SqlParameter("@currencycode", SqlDbType.Int);
                sqlParam[7].Value = ddlOOPCurrecny.SelectedValue;

                sqlParam[8] = new SqlParameter("@having_bill", SqlDbType.Bit);
                sqlParam[8].Value = rbtnl_oopbill.SelectedValue;

                sqlParam[9] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
                sqlParam[9].Value = txtoopbilldetails.Text;

                count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_OOPExpanses]", sqlParam);
                if (count > 0)
                {
                    SmartHr.Common.Alert("OOP Details Updated Successfully");

                    BindList_OOP();
                }
                else
                {
                    SmartHr.Common.Alert("OOP Details Not Updated Successfully");
                }
            }
        }
    }

    //Insert and Display Miscellanous Details-------------------------

    protected void btnMiscellaneous_Click(object sender, EventArgs e)
    {
        if (ViewState["MIS"] == null)
        {
            Insert_Miscellaneous_details();
        }
        else
        {
            Update_Miscellaneous_details();
        }
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "scrollWintop", "scrollWintop();", true);
    }

    private void BindList_miscellaneous()
    {
        if (Request.QueryString["travelID"] != null)
        {
            sqlstr = @"select ed.*,td.tripno,ct.currencycode from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where  ed.expensetype='Miscellaneous' and td.travelid= " + Request.QueryString["travelID"].ToString();
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            grdmiscillenaous.DataSource = ds;
            grdmiscillenaous.DataBind();
            bindExpanseSummary();
            UpdatePanelSummary.Update();
        }
    }

    protected void grdmiscillenaous_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_ExpenseDetails where expenseid=" + grdmiscillenaous.DataKeys[e.RowIndex].Value.ToString();
        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (flag > 0)
        {
            SmartHr.Common.Alert("Miscellaneous Expense Record is deleted Successfully");
            BindList_miscellaneous();
        }
        else
        {
            SmartHr.Common.Alert("Record is not deleted Successfully");
        }
    }

    protected void grdmiscillenaous_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            grdtotal = grdtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = grdtotal.ToString();
        }
    }

    protected void grdmiscillenaous_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ViewState["MIS"] = grdmiscillenaous.DataKeys[e.NewEditIndex].Value.ToString();
        sqlstr = "select * from dbo.tbl_travel_ExpenseDetails where expenseid=" + grdmiscillenaous.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtMiscReceipt.Text = ds.Tables[0].Rows[0]["receiptno"].ToString();
                txtMiscDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["traveldate"]).ToString("MM/dd/yyyy");
                txtMiscAmount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                txtMiscDetails.Text = ds.Tables[0].Rows[0]["details"].ToString();
                ddlMiscCurrency.SelectedValue = ds.Tables[0].Rows[0]["currenceycode"].ToString();
                ddlmisceTrip.SelectedValue = ds.Tables[0].Rows[0]["tripid"].ToString();
                txtMiscbilldetails.Text = ds.Tables[0].Rows[0]["billdetails"].ToString();
                rbtnl_miscbill.SelectedValue = ds.Tables[0].Rows[0]["having_bill"].ToString().ToLower();
                if (rbtnl_miscbill.SelectedValue == "true")
                {
                    divmiscbillupload.Visible = true;
                    divmiscbilldetails.Visible = true;
                }
                else
                {
                    divmiscbillupload.Visible = false;
                    divmiscbilldetails.Visible = true;
                }
                btnMiscellaneous.Text = "Update";
            }
    }

    protected void rbtnl_miscbill_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtMiscbilldetails.Text = "";
        if (rbtnl_miscbill.SelectedValue == "true")
        {
            divmiscbillupload.Visible = true;
            divmiscbilldetails.Visible = true;
            re_miscbillupload.Enabled = true;
            re_miscbilldetails.Enabled = true;
            rq_miscbillupload.Enabled = true;
            rq_miscbilldetails.Enabled = false;
        }
        else
        {
            divmiscbillupload.Visible = false;
            divmiscbilldetails.Visible = true;
            re_miscbillupload.Enabled = false;
            re_miscbilldetails.Enabled = true;
            rq_miscbillupload.Enabled = false;
            rq_miscbilldetails.Enabled = true;
        }
    }

    protected void Insert_Miscellaneous_details()
    {
        int count = 0;
        if (Request.QueryString["travelid"] != null)
        {
            string Miscellaneousbill = "";

            if (File_UploadDft5.HasFile)
            {
                string strFileName;
                string file_name = "Miscellaneous" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft5.FileName;
                try
                {
                    File_UploadDft5.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    Miscellaneousbill = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }
            int ID = Convert.ToInt32(Request.QueryString["travelid"]);

            SqlParameter[] sqlParam = new SqlParameter[10];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlmisceTrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtMiscReceipt.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtMiscDate.Text;

            sqlParam[3] = new SqlParameter("@details", SqlDbType.VarChar, 500);
            sqlParam[3].Value = txtMiscDetails.Text;

            sqlParam[4] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[4].Value = txtMiscAmount.Text == "" ? "0" : txtMiscAmount.Text;

            sqlParam[5] = new SqlParameter("@exptype", SqlDbType.VarChar, 50);
            sqlParam[5].Value = "Miscellaneous";

            sqlParam[6] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[6].Value = Miscellaneousbill;

            sqlParam[7] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[7].Value = ddlMiscCurrency.SelectedValue;

            sqlParam[8] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[8].Value = rbtnl_miscbill.SelectedValue;

            sqlParam[9] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[9].Value = txtMiscbilldetails.Text;

            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_insert_MiscellaneousExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("Miscellaneous Details Added Successfully");
                BindList_miscellaneous();
                clearMiscellaneous();
            }
            else
            { SmartHr.Common.Alert("Miscellaneous Details Not Added Successfully"); }
        }
    }

    protected void Update_Miscellaneous_details()
    {
        if (ViewState["MIS"] != null)
        {
            int count = 0;
            string Miscellaneousbill = "";

            if (File_UploadDft5.HasFile)
            {
                string strFileName;
                string file_name = "Miscellaneous" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft5.FileName;
                try
                {
                    File_UploadDft5.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    Miscellaneousbill = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }

            SqlParameter[] sqlParam = new SqlParameter[10];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlmisceTrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtMiscReceipt.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtMiscDate.Text;

            sqlParam[3] = new SqlParameter("@details", SqlDbType.VarChar, 500);
            sqlParam[3].Value = txtMiscDetails.Text;

            sqlParam[4] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[4].Value = txtMiscAmount.Text == "" ? "0" : txtMiscAmount.Text;

            sqlParam[5] = new SqlParameter("@expenseid", SqlDbType.Int);
            sqlParam[5].Value = ViewState["MIS"].ToString();

            sqlParam[6] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[6].Value = Miscellaneousbill;

            sqlParam[7] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[7].Value = ddlMiscCurrency.SelectedValue;

            sqlParam[8] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[8].Value = rbtnl_miscbill.SelectedValue;

            sqlParam[9] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[9].Value = txtMiscbilldetails.Text;

            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_MiscellaneousExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("Miscellaneous Details Updated Successfully");
                BindList_miscellaneous();
                clearMiscellaneous();
            }
            else
            { SmartHr.Common.Alert("Miscellaneous Details Not Updated Successfully"); }
        }
    }

    protected void btnMiscellaneousCancel_Click(object sender, EventArgs e)
    {
        clearMiscellaneous();
    }

    protected void clearMiscellaneous()
    {
        txtMiscReceipt.Text = "";
        txtMiscDate.Text = "";
        txtMiscAmount.Text = "";
        txtMiscDetails.Text = "";
        ddlMiscCurrency.SelectedValue = "0";
        ddlmisceTrip.SelectedValue = "0";
        txtMiscbilldetails.Text = "";
        rbtnl_miscbill.SelectedIndex = -1;
        divmiscbillupload.Visible = false;
        divmiscbilldetails.Visible = false;
        ViewState["MIS"] = null;
        btnMiscellaneous.Text = "Add";
    }

    //Insert and Display Personalcar Details-------------------------

    protected void btnpersonalcar_Click(object sender, EventArgs e)
    {
        if (ViewState["CAR"] == null)
        {
            Insert_Personalcar_details();
        }
        else
        {
            Update_Personalcar_details();
        }
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "scrollWintop", "scrollWintop();", true);
    }

    private void BindList_PersonalCar()
    {
        if (Request.QueryString["travelID"] != null)
        {
            sqlstr = @"select ed.*,td.tripno,ct.currencycode from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where  ed.expensetype='PersonalCar' and td.travelid= " + Request.QueryString["travelID"].ToString();
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            grdpersonalcar.DataSource = ds;
            grdpersonalcar.DataBind();
            bindExpanseSummary();
            UpdatePanelSummary.Update();
        }
    }

    protected void grdpersonalcar_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_ExpenseDetails where expenseid=" + grdpersonalcar.DataKeys[e.RowIndex].Value.ToString();
        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (flag > 0)
        {
            SmartHr.Common.Alert("Personal Car Expense Record is deleted Successfully");
            BindList_PersonalCar();
        }
        else
        {
            SmartHr.Common.Alert("Record is not deleted Successfully");
        }
    }

    protected void grdpersonalcar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            grdtotal = grdtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = grdtotal.ToString();
        }
    }

    protected void rbtnl_personalcar_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtphonebilldetails.Text = "";
        if (rbtnl_personalcar.SelectedValue == "true")
        {
            divPersonalcarbilldetails.Visible = true;
            divPersonalcarbillupload.Visible = true;
            re_personalcarbillupload.Enabled = true;
            re_personalcarbilldetails.Enabled = true;
            rq_personalcarbillupload.Enabled = true;
            rq_personalcarbilldetails.Enabled = false;
        }
        else
        {
            divPersonalcarbilldetails.Visible = true;
            divPersonalcarbillupload.Visible = false;
            re_personalcarbillupload.Enabled = false;
            re_personalcarbilldetails.Enabled = true;
            rq_personalcarbillupload.Enabled = false;
            rq_personalcarbilldetails.Enabled = true;
        }
    }

    protected void grdpersonalcar_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ViewState["CAR"] = grdpersonalcar.DataKeys[e.NewEditIndex].Value.ToString();
        sqlstr = "select * from dbo.tbl_travel_ExpenseDetails where expenseid=" + grdpersonalcar.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtPersonalReceipt.Text = ds.Tables[0].Rows[0]["receiptno"].ToString();
                txtPersonalAmount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                txtPersonalCarDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["traveldate"]).ToString("MM/dd/yyyy");
                txtPersonalFrom.Text = ds.Tables[0].Rows[0]["travelfrom"].ToString();
                txtPersonalTo.Text = ds.Tables[0].Rows[0]["travelto"].ToString();
                txtPersonalDistance.Text = ds.Tables[0].Rows[0]["approxdispance"].ToString();
                ddlPersonalcarCurrency.SelectedValue = ds.Tables[0].Rows[0]["currenceycode"].ToString();
                ddlperCartrip.SelectedValue = ds.Tables[0].Rows[0]["tripid"].ToString();
                txtphonebilldetails.Text = ds.Tables[0].Rows[0]["billdetails"].ToString();
                rbtnl_personalcar.SelectedValue = ds.Tables[0].Rows[0]["having_bill"].ToString().ToLower();
                if (rbtnl_personalcar.SelectedValue == "true")
                {
                    divPersonalcarbilldetails.Visible = true;
                    divPersonalcarbillupload.Visible = true;
                }
                else
                {
                    divPersonalcarbilldetails.Visible = true;
                    divPersonalcarbillupload.Visible = false;
                }

                btnpersonalcar.Text = "Update";
            }
    }

    protected void Insert_Personalcar_details()
    {
        int count = 0;
        if (Request.QueryString["travelid"] != null)
        {

            string PersonalCarbill = "";
            if (File_UploadDft6.HasFile)
            {
                string strFileName;
                string file_name = "personalcar" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft6.FileName;
                try
                {
                    File_UploadDft6.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    PersonalCarbill = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }
            int ID = Convert.ToInt32(Request.QueryString["travelid"]);

            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlperCartrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtPersonalReceipt.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtPersonalCarDate.Text;

            sqlParam[3] = new SqlParameter("@travelfrom", SqlDbType.VarChar, 50);
            sqlParam[3].Value = txtPersonalFrom.Text;

            sqlParam[4] = new SqlParameter("@travelto", SqlDbType.VarChar, 50);
            sqlParam[4].Value = txtPersonalTo.Text;

            sqlParam[5] = new SqlParameter("@approxdispance", SqlDbType.VarChar, 10);
            sqlParam[5].Value = txtPersonalDistance.Text;

            sqlParam[6] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[6].Value = txtPersonalAmount.Text == "" ? "0" : txtPersonalAmount.Text;

            sqlParam[7] = new SqlParameter("@exptype", SqlDbType.VarChar, 50);
            sqlParam[7].Value = "PersonalCar";

            sqlParam[8] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[8].Value = PersonalCarbill;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlPersonalcarCurrency.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_personalcar.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txt_personalcarbilldetails.Text;

            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_insert_PersonalcarExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("Personal Car Details Added Successfully");
                clearPresonalCar();
                BindList_PersonalCar();
            }
            else
            { SmartHr.Common.Alert("Personal Car Details Not Added Successfully"); }
        }

    }

    protected void Update_Personalcar_details()
    {
        if (ViewState["CAR"] != null)
        {
            int count = 0;

            string PersonalCarbill = "";
            if (File_UploadDft6.HasFile)
            {
                string strFileName;
                string file_name = "personalcar" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft6.FileName;
                try
                {
                    File_UploadDft6.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    PersonalCarbill = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }

            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlperCartrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtPersonalReceipt.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtPersonalCarDate.Text;

            sqlParam[3] = new SqlParameter("@travelfrom", SqlDbType.VarChar, 50);
            sqlParam[3].Value = txtPersonalFrom.Text;

            sqlParam[4] = new SqlParameter("@travelto", SqlDbType.VarChar, 50);
            sqlParam[4].Value = txtPersonalTo.Text;

            sqlParam[5] = new SqlParameter("@approxdispance", SqlDbType.VarChar, 10);
            sqlParam[5].Value = txtPersonalDistance.Text;

            sqlParam[6] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[6].Value = txtPersonalAmount.Text == "" ? "0" : txtPersonalAmount.Text;

            sqlParam[7] = new SqlParameter("@expenseid", SqlDbType.Int);
            sqlParam[7].Value = ViewState["CAR"].ToString();

            sqlParam[8] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[8].Value = PersonalCarbill;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlPersonalcarCurrency.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_personalcar.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txt_personalcarbilldetails.Text;

            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_PersonalcarExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("Personal Car Details Updated Successfully");
                clearPresonalCar();
                BindList_PersonalCar();
            }
            else
            {
                SmartHr.Common.Alert("Personal Car Details Not Updated Successfully");
            }
        }
    }

    protected void btnPersonalCarCancel_Click(object sender, EventArgs e)
    {
        clearPresonalCar();
    }

    protected void clearPresonalCar()
    {
        txtPersonalReceipt.Text = "";
        txtPersonalAmount.Text = "";
        txtPersonalCarDate.Text = "";
        txtPersonalFrom.Text = "";
        txtPersonalTo.Text = "";
        txtPersonalDistance.Text = "";
        ddlPersonalcarCurrency.SelectedValue = "0";
        ddlperCartrip.SelectedValue = "0";
        txtphonebilldetails.Text = "";
        rbtnl_personalcar.SelectedIndex = -1;
        divPersonalcarbilldetails.Visible = false;
        divPersonalcarbillupload.Visible = false;
        ViewState["CAR"] = null;
        btnpersonalcar.Text = "Add";
    }

    //Insert and Display Telephone Details-------------------------

    protected void btnTelephone_Click(object sender, EventArgs e)
    {
        if (ViewState["FAX"] == null)
        {
            Insert_Telephone_details();
        }
        else
        {
            Update_Telephone_details();
        }
        ScriptManager.RegisterStartupScript(Page, this.GetType(), "scrollWintop", "scrollWintop();", true);
    }

    private void BindList_telephonedetails()
    {
        if (Request.QueryString["travelID"] != null)
        {
            sqlstr = @"select ed.*,td.tripno,ct.currencycode from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where  ed.expensetype='Telephone' and td.travelid= " + Request.QueryString["travelID"].ToString();
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            grdtelephone.DataSource = ds;
            grdtelephone.DataBind();
            bindExpanseSummary();
            UpdatePanelSummary.Update();
        }
    }

    protected void grdtelephone_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        sqlstr = @"delete from tbl_travel_ExpenseDetails where expenseid=" + grdtelephone.DataKeys[e.RowIndex].Value.ToString();
        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (flag > 0)
        {
            SmartHr.Common.Alert("Telephone/Fax Expense Record is deleted Successfully");
            BindList_telephonedetails();
        }
        else
        {
            SmartHr.Common.Alert("Record is not deleted Successfully");
        }
    }

    protected void grdtelephone_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            grdtotal = grdtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = grdtotal.ToString();
        }
    }

    protected void rbtnl_phonebill_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtphonebilldetails.Text = "";
        if (rbtnl_phonebill.SelectedValue == "true")
        {
            divfaxbillupload.Visible = true;
            divfaxbilldetails.Visible = true;
            re_faxbillupload.Enabled = true;
            re_faxbilldetails.Enabled = true;
            rq_faxbillupload.Enabled = true;
            rq_faxbilldetails.Enabled = false;
        }
        else
        {
            divfaxbillupload.Visible = false;
            divfaxbilldetails.Visible = true;
            re_faxbillupload.Enabled = false;
            re_faxbilldetails.Enabled = true;
            rq_faxbillupload.Enabled = false;
            rq_faxbilldetails.Enabled = true;
        }
    }

    protected void grdtelephone_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ViewState["FAX"] = grdtelephone.DataKeys[e.NewEditIndex].Value.ToString();
        sqlstr = "select * from dbo.tbl_travel_ExpenseDetails where expenseid=" + grdtelephone.DataKeys[e.NewEditIndex].Value.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
            if (ds.Tables[0].Rows.Count > 0)
            {

                txtPhoneReceipt.Text = ds.Tables[0].Rows[0]["receiptno"].ToString();
                txtPhoneDate.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["traveldate"]).ToString("MM/dd/yyyy");
                txtphoneDetails.Text = ds.Tables[0].Rows[0]["details"].ToString();
                txtPhoneNumber.Text = ds.Tables[0].Rows[0]["phonenumber"].ToString();
                txtPhoneamount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
                rbtn_telephone.SelectedValue = ds.Tables[0].Rows[0]["phonetype"].ToString();
                ddlPhoneCurrency.SelectedValue = ds.Tables[0].Rows[0]["currenceycode"].ToString();
                ddlphonetrip.SelectedValue = ds.Tables[0].Rows[0]["tripid"].ToString();
                txtphonebilldetails.Text = ds.Tables[0].Rows[0]["billdetails"].ToString();
                rbtnl_phonebill.SelectedValue = ds.Tables[0].Rows[0]["having_bill"].ToString().ToLower();
                if (rbtnl_phonebill.SelectedValue == "true")
                {
                    divfaxbilldetails.Visible = true;
                    divfaxbillupload.Visible = true;
                }
                else
                {
                    divfaxbilldetails.Visible = true;
                    divfaxbillupload.Visible = false;
                }
                btnTelephone.Text = "Update";
            }
    }

    protected void Insert_Telephone_details()
    {
        int count = 0;
        if (Request.QueryString["travelid"] != null)
        {
            int ID = Convert.ToInt32(Request.QueryString["travelid"]);
            string telephonebills = "";


            if (File_UploadDft7.HasFile)
            {
                string strFileName;
                string file_name = "telephonedetails" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft7.FileName;
                try
                {
                    File_UploadDft7.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    telephonebills = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }

            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlphonetrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtPhoneReceipt.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtPhoneDate.Text;

            sqlParam[3] = new SqlParameter("@details", SqlDbType.VarChar, 500);
            sqlParam[3].Value = txtphoneDetails.Text;

            sqlParam[4] = new SqlParameter("@phonenumber", SqlDbType.VarChar, 20);
            sqlParam[4].Value = txtPhoneNumber.Text;

            sqlParam[5] = new SqlParameter("@phonetype", SqlDbType.VarChar, 20);
            sqlParam[5].Value = rbtn_telephone.SelectedValue;

            sqlParam[6] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[6].Value = txtPhoneamount.Text == "" ? "0" : txtPhoneamount.Text;

            sqlParam[7] = new SqlParameter("@exptype", SqlDbType.VarChar, 50);
            sqlParam[7].Value = "Telephone";

            sqlParam[8] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[8].Value = telephonebills;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlPhoneCurrency.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_phonebill.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txtphonebilldetails.Text;


            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_insert_telephoneExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("Telephone Details Added Successfully");
                clearTelephone();
                BindList_telephonedetails();
            }
            else { SmartHr.Common.Alert("Telephone Details not Added Successfully"); }
        }

    }

    protected void Update_Telephone_details()
    {
        int count = 0;
        if (ViewState["FAX"] != null)
        {

            string telephonebills = "";


            if (File_UploadDft7.HasFile)
            {
                string strFileName;
                string file_name = "telephonedetails" + System.DateTime.Now.GetHashCode().ToString();

                strFileName = File_UploadDft7.FileName;
                try
                {
                    File_UploadDft7.PostedFile.SaveAs(Server.MapPath("~/Travel/Upload/" + file_name + "_" + strFileName));
                    telephonebills = file_name + "_" + strFileName;
                }
                catch (Exception exc)
                {
                }
            }

            SqlParameter[] sqlParam = new SqlParameter[12];

            sqlParam[0] = new SqlParameter("@tripid", SqlDbType.Int);
            sqlParam[0].Value = ddlphonetrip.SelectedValue;

            sqlParam[1] = new SqlParameter("@receiptno", SqlDbType.VarChar, 50);
            sqlParam[1].Value = txtPhoneReceipt.Text;

            sqlParam[2] = new SqlParameter("@traveldate", SqlDbType.DateTime);
            sqlParam[2].Value = txtPhoneDate.Text;

            sqlParam[3] = new SqlParameter("@details", SqlDbType.VarChar, 500);
            sqlParam[3].Value = txtphoneDetails.Text;

            sqlParam[4] = new SqlParameter("@phonenumber", SqlDbType.VarChar, 20);
            sqlParam[4].Value = txtPhoneNumber.Text;

            sqlParam[5] = new SqlParameter("@phonetype", SqlDbType.VarChar, 20);
            sqlParam[5].Value = rbtn_telephone.SelectedValue;

            sqlParam[6] = new SqlParameter("@amount", SqlDbType.Decimal, 20);
            sqlParam[6].Value = txtPhoneamount.Text == "" ? "0" : txtPhoneamount.Text;

            sqlParam[7] = new SqlParameter("@expenseid", SqlDbType.Int);
            sqlParam[7].Value = ViewState["FAX"].ToString();

            sqlParam[8] = new SqlParameter("@uploadbill", SqlDbType.VarChar, 50);
            sqlParam[8].Value = telephonebills;

            sqlParam[9] = new SqlParameter("@currencycode", SqlDbType.Int);
            sqlParam[9].Value = ddlPhoneCurrency.SelectedValue;

            sqlParam[10] = new SqlParameter("@having_bill", SqlDbType.Bit);
            sqlParam[10].Value = rbtnl_phonebill.SelectedValue;

            sqlParam[11] = new SqlParameter("@billdetails", SqlDbType.VarChar, 8000);
            sqlParam[11].Value = txtphonebilldetails.Text;


            count = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_travel_update_telephoneExpanses]", sqlParam);
            if (count > 0)
            {
                SmartHr.Common.Alert("Telephone Details Updated Successfully");
                clearTelephone();
                BindList_telephonedetails();
            }
            else { SmartHr.Common.Alert("Telephone Details not Updated Successfully"); }
        }

    }

    protected void btnTelephoneCancel_Click(object sender, EventArgs e)
    {
        clearTelephone();
    }

    protected void clearTelephone()
    {
        txtPhoneReceipt.Text = "";
        txtPhoneDate.Text = "";
        txtphoneDetails.Text = "";
        txtPhoneNumber.Text = "";
        txtPhoneamount.Text = "";
        rbtn_telephone.SelectedIndex = -1;
        ddlPhoneCurrency.SelectedValue = "0";
        ddlphonetrip.SelectedValue = "0";
        txtphonebilldetails.Text = "";
        rbtnl_phonebill.SelectedIndex = -1;
        divfaxbilldetails.Visible = false;
        divfaxbillupload.Visible = false;
        btnTelephone.Text = "Add";
        ViewState["FAX"] = null;
    }

    //Adding Forms------------

    protected void btngeneralsubmit_Click(object sender, EventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["travelid"]);
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = ID;

        int flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_submit_expense", param);
        if (flag > 0)
        {
            Response.Redirect("RejectedExpenseForms.aspx?submit=true");
        }
        else
        {
            SmartHr.Common.Alert("Expense Details Not Submitted Successfully");
        }
    }

    protected void resetexpensedetails()
    {
        grdtravel.DataSource = "";
        grdtravel.DataBind();

        grdlodging.DataSource = "";
        grdlodging.DataBind();

        grdmiscillenaous.DataSource = "";
        grdmiscillenaous.DataBind();

        grdoop.DataSource = "";
        grdoop.DataBind();

        grdpersonalcar.DataSource = "";
        grdpersonalcar.DataBind();

        grdtelephone.DataSource = "";
        grdtelephone.DataBind();
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("RejectedExpenseForms.aspx");
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
                string subject = "Regarding Travel Expense";
                string bodyContent = "A new Travel Application request has been submitted by employee " + Session["name"].ToString() + ".";
                string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
            }
        }
    }
    protected void bindPreviouscomments()
    {
        
       
        SqlConnection Connection = null;
        try
        {
            if (Request.QueryString["travelID"] != null)
            {
                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                Connection = DataActivity.OpenConnection();
                SqlParameter[] parm = new SqlParameter[2];
                Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
                Output.AssignParameter(parm, 1, "@travelflow", "String", 10, "Expense");
                ds.Clear();
                ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_travel_get_comments", parm);
                if (ds.Tables.Count > 0)
                {
                    Gridcomments.DataSource = ds;
                    Gridcomments.DataBind();
                }
                Connection = DataActivity.OpenConnection();
                SqlParameter[] param = new SqlParameter[2];
                Output.AssignParameter(param, 0, "@travelid", "String", 50, travelid.ToString());
                Output.AssignParameter(param, 1, "@travelflow", "String", 10, "Travel");
                ds.Clear();
                ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_travel_get_comments", param);
                if (ds.Tables.Count > 0)
                {
                    GridTravelComments.DataSource = ds;
                    GridTravelComments.DataBind();
                }
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

}

