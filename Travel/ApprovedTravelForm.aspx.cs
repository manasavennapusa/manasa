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

public partial class Travel_ApprovedTravelForm : System.Web.UI.Page
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
            if (Request.QueryString["cancelled"] != null)
            {
                SmartHr.Common.Alert("Travel Form is Cancelled successfully");
            }
            bindGrid();
            empdetails.Visible = false;
            traveldetails.Visible = false;
            miscellaneousdetails.Visible = false;
            traveltipdetails.Visible = false;
            ticketdetails.Visible = false;
            approvers.Visible = false;
            DivFinalAdvance.Visible = false;
            divbuttons.Visible = false;
            divpreviouscomment.Visible = false;

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
        bindAdvanceList(travelid);
        bindApproversgrid(travelid);
        bindTripList(travelid);
        bindPreviouscomments(travelid);
        empdetails.Visible = true;
        traveldetails.Visible = true;
        miscellaneousdetails.Visible = true;
        traveltipdetails.Visible = true;
        approvers.Visible = true;
        DivFinalAdvance.Visible = true;
        travelform.Visible = false;
        divbuttons.Visible = true;
        divpreviouscomment.Visible = true;
    }

    protected void bindAdvanceList(int travelid)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@travelid", SqlDbType.Int);
        param[0].Value = travelid;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getMiscellaneous_AllowanceByTravelID", param);
        grid_Advance.DataSource = ds;
        grid_Advance.DataBind();
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

        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelSummary", param);
       
        if (ds.Tables.Count > 5)
            if (ds.Tables[5].Rows.Count > 0)
            {
                grd_estimationtotals.DataSource = ds.Tables[5];
                grd_estimationtotals.DataBind();
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

        DataRow[] dr = ds.Tables[0].Select("triptype='I'");
        if (dr.Length > 0)
            divKit.Visible = true;
        else
            divKit.Visible = false;
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getApprovedTravelForms", param);
        grid_Travel.DataSource = ds;
        grid_Travel.DataBind();

    }

    protected void grid_Trip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int tripid = Convert.ToInt32(grid_Trip.DataKeys[e.NewEditIndex].Value);
        ticketdetails.Visible = true;
        bind_ticketdetails(tripid);

    }

    protected void bind_ticketdetails(int tripid)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@tripid", SqlDbType.Int);
        sqlparam[0].Value = tripid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_TicketdetailsDownload", sqlparam);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblDODeparture.Text = ds.Tables[0].Rows[0]["departuredate"].ToString();
            lblDOArrival.Text = ds.Tables[0].Rows[0]["arrivaldate"].ToString();
            hdTicket.Value = ds.Tables[0].Rows[0]["ticketuploadpath"].ToString();
            if (hdTicket.Value == "")
            {
                tblticketdetails.Visible = false;
                lblticketdowloan.Visible = true;
            }
            else
            {
                tblticketdetails.Visible = true;
                lblticketdowloan.Visible = false;
            }
        }
        else
        {
            tblticketdetails.Visible = false;
            lblticketdowloan.Visible = true;
        }
    }

    //protected void ticketDownload_Command(object sender, CommandEventArgs e)
    //{

    //    string filePath = " ~/Travel/traveluploads/" +e.CommandArgument.ToString();
    //    Response.ContentType = "image/jpg";
    //    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filePath + "\"");
    //    Response.TransmitFile(Server.MapPath(filePath));
    //    Response.End();
    //}

    protected void btnDownloadticket_Click(object sender, EventArgs e)
    {
        if (hdTicket.Value != "")
        {
            string filePath = "traveluploads/" + hdTicket.Value.ToString();
            Response.ContentType = "image/jpg";
            Response.AddHeader("Content-Disposition", "attachment;filename=\"" + hdTicket.Value.ToString() + "\"");
            Response.TransmitFile(Server.MapPath(filePath));
            Response.End();
        }
        else
        {
            SmartHr.Common.Alert("Ticktet Not Found");

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

    protected void grid_Advance_PreRender(object sender, EventArgs e)
    {
        if (grid_Advance.Rows.Count > 0)
        {
            grid_Advance.UseAccessibleHeader = true;
            grid_Advance.HeaderRow.TableSection = TableRowSection.TableHeader;
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

    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ApprovedTravelForm.aspx");
    }

    protected void btnCancelTravel_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            if (Request.QueryString["travelID"] != null)
            {
                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                _Transaction = Connection.BeginTransaction();
                insertTravelComments(travelid, "C", _Transaction, Connection);
                sqlstr = "update tbl_travel_TravelForm set istravelcanceled=1 where travelid=" + travelid + "";
                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, sqlstr);
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
            SmartHr.Common.Alert("Travel Form is Not Cancelled");
        }
        else
        {
            try
            {
                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@travelid", SqlDbType.Int);
                param[0].Value = travelid;
                ds.Clear();
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelApproversbyTravelID", param);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    sendMail(ds.Tables[0].Rows[i]["approvercode"].ToString());
                }
            }
            catch (Exception ex)
            {
                Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                Output.Show(" Please contact system admin. For error details please go through the log file.");
            }
            Response.Redirect("PendingTravelForm.aspx?cancelled=true");
        }
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
                string subject = "Regarding Travel Cancellation";
                string bodyContent = "Please accept my Travel cancellation.Travel Account Code is :" + lblAcCode.Text;
                string completeBody = Email.GetBody(fromName, ds1.Tables[0].Rows[0]["empname"].ToString(), bodyContent);
                Email.getemail(fromEmail, fromPwd, fromName, ds1.Tables[0].Rows[0]["official_email_id"].ToString(), "", subject, completeBody, smtp, emailLogo);
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
            Output.AssignParameter(parm, 2, "@approverrole", "String", 50, "Employee");
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
}