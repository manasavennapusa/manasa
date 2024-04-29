using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class Travel_TravelView : System.Web.UI.Page
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
            if (Request.QueryString["travelID"] != null)
            {

                int travelid = Convert.ToInt32(Request.QueryString["travelID"]);
                bindTripList(travelid);
                bindAdvanceList(travelid);
                bindApproversgrid(travelid);
                bindEmpDetails(travelid);
                bindPreviouscomments(travelid);
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
            trkitallowance1.Visible = true;
            trkitallowance2.Visible = true;
        }
        else
        {
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
            lblgrade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            lbllocation.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
            lblmgr.Text = ds.Tables[0].Rows[0]["reporting_mgr"].ToString();
            lblbank.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            txt_travelpurpose.Text = ds.Tables[0].Rows[0]["travelpurpose"].ToString();
            lblAcCode.Text = ds.Tables[0].Rows[0]["accountcode"].ToString();
            lblcostcenter.Text = ds.Tables[0].Rows[0]["cost_center_name"].ToString();
            rbtnl_kitallowance.SelectedValue = ds.Tables[0].Rows[0]["iskitallowancetaken"].ToString().ToLower();
            rbtnl_insurance.SelectedValue = ds.Tables[0].Rows[0]["insurence_need"].ToString().ToLower();
            rbtnl_visa.SelectedValue = ds.Tables[0].Rows[0]["visa_arraged"].ToString().ToLower();
            lblbank_ac_no.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("TravelHistory.aspx");
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