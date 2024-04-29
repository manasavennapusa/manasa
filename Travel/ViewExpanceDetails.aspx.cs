using DataAccessLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;

public partial class Travel_ViewExpanceDetails : System.Web.UI.Page
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
            //empdetails.Visible = false;
            traveldetails.Visible = false;
            miscellaneousdetails.Visible = false;
            tripdetails.Visible = false;
            approverdetails.Visible = false;
            divExpenseTally.Visible = false;
            divpreviouscomment.Visible = false;
            if (Request.QueryString["approved"] != null)
            {
                SmartHr.Common.Alert("Travel Form Approved successfully");
            }
            if (Request.QueryString["rejected"] != null)
            {
                SmartHr.Common.Alert("Travel Form Rejected successfully");
            }
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
        bindTripList(travelid);
        bindPreviouscomments(travelid);
        bindexpensetally(travelid);
        bindExpanseSummary();
        bindTravelSummary();
        // empdetails.Visible = true;
        traveldetails.Visible = true;
        miscellaneousdetails.Visible = true;
        tripdetails.Visible = true;
        approverdetails.Visible = true;
        grid_Travel.Visible = false;
        travelform.Visible = false;
        divExpenseTally.Visible = true;
        divpreviouscomment.Visible = true;
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_gettravekExpanseStatus", param);
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
            //lblempcode.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
            //lblempname.Text = ds.Tables[0].Rows[0]["empname"].ToString();
            //lbldept.Text = ds.Tables[0].Rows[0]["department_name"].ToString();
            //lbldesingantion.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
            //lblgrade.Text = ds.Tables[0].Rows[0]["gradename"].ToString();
            //lbllocation.Text=ds.Tables[0].Rows[0][].ToString();
            //lblmgr.Text = ds.Tables[0].Rows[0]["reporting_mgr"].ToString();
            //lblbank.Text = ds.Tables[0].Rows[0]["bankname"].ToString();
            lblTravelPurpose.Text = ds.Tables[0].Rows[0]["travelpurpose"].ToString();
            lblAcCode.Text = ds.Tables[0].Rows[0]["accountcode"].ToString();
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

   

    protected void grid_Trip_RowEditing(object sender, GridViewEditEventArgs e)
    {
        tbl_tripDetails.Visible = true;
        int tripid = Convert.ToInt32(grid_Trip.DataKeys[e.NewEditIndex].Value);
        bindtripexpanse(tripid);
    }

    protected void bindtripexpanse(int tripid)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@tripid", SqlDbType.Int);
        param[0].Value = tripid;
        ds.Clear();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getAllExpanseDetailsbyTripID", param);
        gridExpanse.DataSource = ds;
        gridExpanse.DataBind();
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

    protected void gridExpanse_PreRender(object sender, EventArgs e)
    {
        if (gridExpanse.Rows.Count > 0)
        {
            gridExpanse.UseAccessibleHeader = true;
            gridExpanse.HeaderRow.TableSection = TableRowSection.TableHeader;
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

    protected void bindTravelSummary()
    {
        if (Request.QueryString["travelID"] != null)
        {
            SqlParameter[] param = new SqlParameter[1];

            param[0] = new SqlParameter("@travelid", SqlDbType.Int);
            param[0].Value = Convert.ToInt32(Request.QueryString["travelID"]);
            ds = new DataSet();
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getTravelSummary", param);



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
    protected void btnClose_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewExpanceDetails.aspx");
    }

    protected void btnPrint_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'ExpenseViewPrint.aspx?travelID=" + Request.QueryString["travelID"].Trim() + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }
}