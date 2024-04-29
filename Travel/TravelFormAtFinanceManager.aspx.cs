using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using Smart.HR.Common.Mail.Module;

public partial class Travel_TravelFormAtFinanceManager : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    DataTable dtable = new DataTable();
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
            if (Request.QueryString["travelID"] != null)
            {

                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                bindTripList(travelid);
                bindTripList4(travelid);
                bindAdvanceList(travelid);
                bindApproversgrid(travelid);
                bindApproversgrid4(travelid);
                bindEmpDetails(travelid);
                bindPreviouscomments(travelid);
                bindTravelSummary();
                btn_travelCancel.Visible = false;
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
        //grid_allowancetotal.DataSource = ds;
        //grid_allowancetotal.DataBind();
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
        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
        {
            divKit.Visible = true;
            trkitallowance1.Visible = true;
            trkitallowance2.Visible = true;
        }
        else
        {
            divKit.Visible = false;
            trkitallowance1.Visible = false;
            trkitallowance2.Visible = false;
        }
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
                string sqlstr = "select id,kitallowance from tbl_travel_kitallowance_master where status=1;select top 1 k.travelid,kitallowance,convert(varchar(12),applieddate,106) applieddate,t.accountcode from tbl_travel_kitallowance k inner join tbl_travel_TravelForm t on k.travelid=t.travelid where empcode='" + ds.Tables[0].Rows[0]["empcode"].ToString() + "' and k.status=0 and k.travelid!=" + travelid.ToString() + " order by id desc";
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

    protected void bindTravelSummary()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(Request.QueryString["travelID"]);
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelSummary", param);


        if (ds.Tables.Count > 0)
        {
            gridAdvanceSummary.DataSource = ds.Tables[0];
            gridAdvanceSummary.DataBind();
        }
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
                DateTime dateofdeparture = Convert.ToDateTime(((Label)grid_Trip.Rows[0].FindControl("lbldeptDate")).Text.Substring(0, 11));
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

            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "AmountINR"));
            PreAdvancetotal = PreAdvancetotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lbltotalINRSTD");
            lbl.Text = Math.Round(PreAdvancetotal, 2).ToString();
        }
    }

    void SendEmail(int travelId, int type)
    {
        if (type == 0)
        {
            EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponAdvanceGiven();
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

    protected void btn_SendMail_Click(object sender, EventArgs e)
    {
        if (txtmgrcomments.Text.Trim() != "")
        {
            SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            int Flag = 0;
            try
            {

                if (Request.QueryString["travelID"] != null)
                {
                    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                    Connection = DataActivity.OpenConnection();
                    _Transaction = Connection.BeginTransaction();
                    SqlParameter[] parm = new SqlParameter[4];
                    Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
                    Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "1");
                    Output.AssignParameter(parm, 3, "@approver", "String", 10, "fnmgr");
                    insertTravelComments(travelid, "A", _Transaction, Connection);
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelfrom", parm);

                    _Transaction.Commit();

                   // SendEmail(travelid, 0);

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
            if (Flag > 0)
            {
                Response.Redirect("ApproveTravelFormByManager.aspx?user=fnmgr&send=true");

            }
        }
        else
        {
            SmartHr.Common.Alert("Please enter the comments");
        }
    
      
        
    }


    protected void insertFinalAdvance()
    {
        if (Request.QueryString["travelID"] != null)
        {
            //    int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
            //    SqlParameter[] param = new SqlParameter[7];

            //    param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            //    param[0].Value = travelid;

            //    param[1] = new SqlParameter("@est_currencycode", SqlDbType.Int);
            //    param[1].Value = 98;

            //    param[2] = new SqlParameter("@estimatedamount", SqlDbType.Decimal);
            //    param[2].Value = Convert.ToDecimal(lblEstimation.Text == "" ? "0" : lblEstimation.Text);

            //    param[3] = new SqlParameter("@INRSTD", SqlDbType.Decimal);
            //    param[3].Value = Convert.ToDecimal(txtFinalAmountGiven1.Text == "" ? "0" : txtFinalAmountGiven1.Text);

            //    param[4] = new SqlParameter("@final_currencycode", SqlDbType.Int);
            //    param[4].Value = ddl_finalCurrency.SelectedValue;

            //    param[5] = new SqlParameter("@final_amount", SqlDbType.Decimal);
            //    param[5].Value = Convert.ToDecimal(txtFinalAmountGiven2.Text == "" ? "0" : txtFinalAmountGiven2.Text);

            //    param[6] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
            //    param[6].Value = Session["empcode"].ToString();

            //    int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_insertFinalAdvanceGiven", param);
            //
        }
    }

    protected void btn_travelCancel_Click(object sender, EventArgs e)
    {
        if (txtmgrcomments.Text.Trim() != "")
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
                    //SqlParameter[] param = new SqlParameter[1];
                    //param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                    //param[0].Value = travelid;
                    //ds.Clear();
                    //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
                    //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //{
                    //    sendMail(ds.Tables[0].Rows[i]["approvercode"].ToString());
                    //}

                    sqlstr = "update tbl_travel_TravelForm set istravelcanceled=1 where travelid=" + travelid + "";
                    int k = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                    if (k < 0)
                    {
                        SmartHr.Common.Alert("Travel Form is Not Cancelled");
                    }
                    else
                    {
                        Response.Redirect("ApproveTravelFormByManager.aspx?user=fnmgr&cancelled=true");
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
        }
            else
            {
                SmartHr.Common.Alert("Please enter the comments");

            }

        
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproveTravelFormByManager.aspx?user=fnmgr");
    }

    protected void insertTravelComments(int travelid, string commenttype, SqlTransaction _Transaction, SqlConnection Connection)
    {
        //if (txtmgrcomments.Text.Trim() != "")
        //{
        SqlParameter[] parm = new SqlParameter[7];
        Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
        Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
        Output.AssignParameter(parm, 2, "@approverrole", "String", 50, "Finance Manager");
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

    /// //////////////add approver for finance departments//////////////
    protected void bindApproversgrid4(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
        Grid_Approvers4.DataSource = ds;
        Grid_Approvers4.DataBind();
    }

    protected void bindTripList4(int travelid)
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
            if (Grid_Approvers4.Rows.Count >= 3)
                Grid_Approvers4.Rows[2].Visible = false;

        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
            divKit.Visible = true;
        else
            divKit.Visible = false;
    }

    protected void Grid_Approvers4_PreRender(object sender, EventArgs e)
    {

        if (Grid_Approvers4.Rows.Count > 0)
        {
            Grid_Approvers4.UseAccessibleHeader = true;
            Grid_Approvers4.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}