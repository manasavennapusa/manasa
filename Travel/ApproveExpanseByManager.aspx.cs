using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;


public partial class Travel_ApproveExpanseByManager : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;
    decimal grdtotal = 0;

    DataTable dtable = new DataTable();
    DataActivity DataActivity = new DataActivity();

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
            divbuttons.Visible = false;
            divpreviouscomment.Visible = false;
            divExpenseTally.Visible = false;
            approvers.Visible = false;

            if (Request.QueryString["approved"] != null)
            {
                SmartHr.Common.Alert("Travel Expense Approved successfully");
            }
            if (Request.QueryString["rejected"] != null)
            {
                SmartHr.Common.Alert("Travel Expense Rejected successfully");
            }
        }
    }

    protected void bindtravels(int travelid)
    {
        bindexpensetally(travelid);
        bindEmpDetails(travelid);
        bindTripList(travelid);
        bindExpanseSummary(travelid);
        bindTravelSummary(travelid);
        bindPreviouscomments(travelid);
        bindApproversgrid7(travelid);
        bindTripList7(travelid);
        empdetails.Visible = true;
        traveldetails.Visible = true;
        miscellaneousdetails.Visible = true;
        tripdetails.Visible = true;
        approverdetails.Visible = true;
        grid_Travel.Visible = false;
        travelform.Visible = false;
        divbuttons.Visible = true;
        divpreviouscomment.Visible = true;
        divExpenseTally.Visible = true;
        approvers.Visible = true;
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@approvercode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();
        param[1] = new SqlParameter("@approverlevel", SqlDbType.Int);
        param[1].Value = 2;

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getExpanseForApprove", param);
        grid_Travel.DataSource = ds;
        grid_Travel.DataBind();
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
            lblsubmitteddate.Text = ds.Tables[0].Rows[0]["createddate"].ToString();
            lblempstatus.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
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
        if (ds.Tables.Count > 0)
        {

            DataRow[] dr = ds.Tables[0].Select("triptype='I'");
            if (dr.Length > 0)
            {
                triptype = "I";
                trkitallowance1.Visible = true;
                trkitallowance2.Visible = true;
                divKit.Visible = true;
            }
            else
            {
                triptype = "D";
                trkitallowance1.Visible = false;
                trkitallowance2.Visible = false;
                divKit.Visible = false;
            }
        }
        ViewState["triptype"] = triptype;
    }


    //=================================================Appprove Reject Back ============================================

    protected void btnSumitForm_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        int travelid = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (ViewState["travelid"] != null)
            {
                travelid = Convert.ToInt32(ViewState["travelid"]);

                _Transaction = Connection.BeginTransaction();
                SqlParameter[] parm = new SqlParameter[3];
                Output.AssignParameter(parm, 0, "@travelid", "Int", 0, travelid.ToString());
                Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "1");

                insertTravelComments(travelid, "A", _Transaction, Connection);
                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelExpanseBymgr", parm);
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
        if (Flag <= 0)
        {
            SmartHr.Common.Alert("Travel Form Not Approved");
        }
        else
        {
            int travel_id = Convert.ToInt32(ViewState["travelid"]);
            SendEmail(travelid, 1);
            Response.Redirect("ApproveExpanseByManager.aspx?user=mgr&approved=true");
        }
    }

    protected void btnRejecct_Click(object sender, EventArgs e)
    {
        if (txtmgrcomments.Text.Trim() != "")
        {
            SqlConnection Connection = null;
            SqlTransaction _Transaction = null;
            int Flag = 0;
            int travelid = 0;
            try
            {
                Connection = DataActivity.OpenConnection();
                if (ViewState["travelid"] != null)
                {
                    travelid = Convert.ToInt32(ViewState["travelid"]);
                    _Transaction = Connection.BeginTransaction();
                    SqlParameter[] parm = new SqlParameter[3];
                    Output.AssignParameter(parm, 0, "@travelid", "Int", 0, travelid.ToString());
                    Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
                    Output.AssignParameter(parm, 2, "@approverstatus", "Int", 0, "2");

                    insertTravelComments(travelid, "R", _Transaction, Connection);
                    Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_approver_reject_travelExpanseBymgr", parm);
                    _Transaction.Commit();
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
            if (Flag <= 0)
            {
                SmartHr.Common.Alert("Travel Form Not Rejected Successfully");
            }
            else
            {
                SendEmail(travelid, 0);
                Response.Redirect("ApproveExpanseByManager.aspx?user=mgr&rejected=true");
            }
        }
        else
        {
            SmartHr.Common.Alert("Please enter the comments");
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApproveExpanseByManager.aspx?user=mgr");
    }

    //=============================================End===================================
    protected void grid_Travel_RowEditing(object sender, GridViewEditEventArgs e)
    {

        int travelid = Convert.ToInt32(grid_Travel.DataKeys[e.NewEditIndex].Value);

        bindtravels(travelid);

        ViewState["travelid"] = travelid;

    }

    protected void btnException_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            string approvercode = "";
            //if (Grid_Approvers.Rows.Count > 0)
            //{
            //    approvercode = ((Label)Grid_Approvers.Rows[1].FindControl("lblcode")).Text;
            //}

            if (Request.QueryString["travelID"] != null)
            {

                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                _Transaction = Connection.BeginTransaction();
                SqlParameter[] parm = new SqlParameter[1];
                Output.AssignParameter(parm, 0, "@travelid", "Int", 0, travelid.ToString());

                insertTravelComments(travelid, "C", _Transaction, Connection);
                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_sentTravelExpanseForExceptionTomgmt", parm);
                _Transaction.Commit();

            }
            //if (Flag > 0)
            //{
            //    sendMail(approvercode);
            //}
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
        if (Flag <= 0)
        {
            SmartHr.Common.Alert("Travel Exception not sent.");
        }
        else
        {
            Response.Redirect("ApproveExpanseByManager.aspx?exception=true");
        }
    }

    void SendEmail(int travelId, int type)
    {
        if (type == 0)
        {
            Approvers.Travel.Approvers approver = new Approvers.Travel.Approvers();

            DataRow rowemp = approver.GetTravelEmployeeInfo(travelId);

            DataTable dt = approver.GetApprovers(travelId, 2);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["official_email_id"].ToString() != "")
                    {
                        try
                        {
                            EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponRejectOfExpenseRequestByLineManager();
                            EmailClient client = new EmailClient(email);
                            client.toEmailId = row["official_email_id"].ToString().Trim();
                            client.empCode = row["approvercode"].ToString().Trim();
                            client.employeeName = row["name"].ToString().Trim();
                            client.appsendername = rowemp["name"].ToString();
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
        else
            if (type == 1)
            {


                Approvers.Travel.Approvers approver = new Approvers.Travel.Approvers();
                DataRow rowemp = approver.GetTravelEmployeeInfo(travelId);

                DataTable dt = approver.GetApprovers(travelId, 4);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["official_email_id"].ToString() != "")
                        {
                            try
                            {
                                EmailFactory email = new Smart.HR.Common.Mail.Module.Travel.UponApprovalOfExpenseRequestByLineManager();
                                EmailClient client = new EmailClient(email);
                                client.toEmailId = row["official_email_id"].ToString().Trim();
                                client.empCode = row["approvercode"].ToString().Trim();
                                client.employeeName = row["name"].ToString().Trim();
                                client.appsendername = rowemp["name"].ToString();
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

    protected void grid_Travel_PreRender(object sender, EventArgs e)
    {
        if (grid_Travel.Rows.Count > 0)
        {
            grid_Travel.UseAccessibleHeader = true;
            grid_Travel.HeaderRow.TableSection = TableRowSection.TableHeader;
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



    protected void bindExpanseSummary(int travelid)
    {


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
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

    protected void bindTravelSummary(int travelid)
    {

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds = new DataSet();
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

    protected void bindexpensetally(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_advance_expance_tally", param);
        GridTally.DataSource = ds;
        GridTally.DataBind();
    }

    protected void insertTravelComments(int travelid, string commenttype, SqlTransaction _Transaction, SqlConnection Connection)
    {
        //if (txtmgrcomments.Text.Trim() != "")
        //{
        SqlParameter[] parm = new SqlParameter[7];
        Output.AssignParameter(parm, 0, "@travelid", "String", 50, travelid.ToString());
        Output.AssignParameter(parm, 1, "@approvercode", "String", 50, Session["empcode"].ToString());
        Output.AssignParameter(parm, 2, "@approverrole", "String", 50, "Manager");
        Output.AssignParameter(parm, 3, "@travelflow", "String", 10, "Expense");
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

    /////////////add approver for manager//////////
    protected void bindApproversgrid7(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
        Grid_Approvers7.DataSource = ds;
        Grid_Approvers7.DataBind();
    }

    protected void bindTripList7(int travelid)
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
            if (Grid_Approvers7.Rows.Count >= 3)
                Grid_Approvers7.Rows[2].Visible = false;

        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
            divKit.Visible = true;
        else
            divKit.Visible = false;
    }

    protected void Grid_Approvers7_PreRender(object sender, EventArgs e)
    {
        if (Grid_Approvers7.Rows.Count > 0)
        {
            Grid_Approvers7.UseAccessibleHeader = true;
            Grid_Approvers7.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}