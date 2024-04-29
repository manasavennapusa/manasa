using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Travel_ViewFullTripDetails : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            if (Request.QueryString["tripid"] != null)
            {
                int tripid = Convert.ToInt32(Request.QueryString["tripid"]);
                grid_Trip(tripid);
                lblheader.Text = "View/Edit Trip Details";
            }
        }
    }


    //=================================================Trip Details Start============================================
    #region Trip







    protected void btnCancelTripDetails_Click(object sender, EventArgs e)
    {

        ScriptManager.RegisterStartupScript(this, GetType(), "ClosePopup", "ClosePopup();", true);
    }

    protected void grid_Trip(int tripid)
    {
        bindTripByTripID(tripid);
        bind_ticketdetails(tripid);
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


            lbldepartdate.Text = String.Format("{0:dd MMM yyyy}", Convert.ToDateTime(ds.Tables[0].Rows[0]["departuredate"]));
            lbldeparttime.Text = ds.Tables[0].Rows[0]["departuretime"].ToString();
            if (ds.Tables[0].Rows[0]["triptype"].ToString() == "I")
            {
                lbl_source.Text = ds.Tables[0].Rows[0]["fromsourcecountryname"].ToString();
                lbl_destination.Text = ds.Tables[0].Rows[0]["todestinationcountryname"].ToString();

            }
            else
            {
                lbl_source.Text = ds.Tables[0].Rows[0]["fromsourcename"].ToString();
                lbl_destination.Text = ds.Tables[0].Rows[0]["todestinationname"].ToString();
            }
            ddl_traveltype.Text = ds.Tables[0].Rows[0]["triptypename"].ToString();
            lblarvlDate.Text = String.Format("{0:dd MMM yyyy}", Convert.ToDateTime(ds.Tables[0].Rows[0]["arrivaldate"]));
            lblArvlTime.Text = ds.Tables[0].Rows[0]["arrivaltime"].ToString();
            lbl_stayType.Text = ds.Tables[0].Rows[0]["staytypename"].ToString();
            lblEmpCommets.Text = ds.Tables[0].Rows[0]["empcomments"].ToString();
            rbtnl_airlinems.SelectedValue = ds.Tables[0].Rows[0]["isairlinemembership"].ToString().ToLower();
            rbtnl_hotelms.SelectedValue = ds.Tables[0].Rows[0]["ishotelmembership"].ToString().ToLower();
            lblairlinedetails.Text = ds.Tables[0].Rows[0]["airlinemembershipdetails"].ToString() != "" ? ("<br/><b>Details :- </b>" + ds.Tables[0].Rows[0]["airlinemembershipdetails"].ToString()) : "";
            lblhoteldetails.Text = ds.Tables[0].Rows[0]["hotelmembershipdetails"].ToString() != "" ? ("<br/><b>Details :- </b>" + ds.Tables[0].Rows[0]["hotelmembershipdetails"].ToString()) : "";
            if (rbtnl_airlinems.SelectedValue == "true")
            {
                lblairlinedetails.Visible = true;
            }
            else
            { lblairlinedetails.Visible = false; }

            if (rbtnl_hotelms.SelectedValue == "true")
            {
                lblhoteldetails.Visible = true;
            }
            else
            { lblhoteldetails.Visible = false; }
        }
    }


    #endregion Trip

    //=================================================Trip Details End============================================


  

    //=================================================Expanse Details Start============================================
   
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
            if (ds.Tables[0].Rows[0]["istickedbooked"].ToString() == "True")
            {
                if (ddl_traveltype.Text == "Domestic")
                {
                    trticket1.Visible = true;
                    trticket6.Visible = false;
                    ddl_tier.Text = ds.Tables[0].Rows[0]["tier"].ToString();
                }
                else
                {
                    trticket1.Visible = false;
                    trticket6.Visible = true;
                }
                ddl_mode.Text = ds.Tables[0].Rows[0]["travelmode"].ToString();
                ddl_modeClass.Text = ds.Tables[0].Rows[0]["travelmodeclass"].ToString();
                lbl_fareCurrecny.Text = ds.Tables[0].Rows[0]["ticketcurrency"].ToString();
                txtticketfair.Text = ds.Tables[0].Rows[0]["travel_fare"].ToString();
                hrefticket.HRef = ds.Tables[0].Rows[0]["ticketuploadpath"].ToString().Trim() != "" ? "~/Travel/Upload/" + ds.Tables[0].Rows[0]["ticketuploadpath"].ToString() : "";
                hrefticket.Target = "content";
                lblviewticket.Text = ds.Tables[0].Rows[0]["ticketuploadpath"].ToString().Trim() != "" ? "View Ticket" : "No Ticket";
                trticket2.Visible = true;
                trticket3.Visible = true;
                trticket4.Visible = true;
                trticket5.Visible = true;
                trticketadv.Visible = false;
            }
            else
            {
                trticket1.Visible = false;
                trticket2.Visible = false;
                trticket3.Visible = false;
                trticket4.Visible = false;
                trticket5.Visible = false;
                trticketadv.Visible = true;
            }

           
            //=============================Stay===============================================
            txtticketAdv.Text = ds.Tables[0].Rows[0]["traveladvanceamount"].ToString();
            lblticketAdvcurrency.Text = ds.Tables[0].Rows[0]["trvladv_currency"].ToString();
            rbtnl_lodge.SelectedValue = ds.Tables[0].Rows[0]["isstaybooked"].ToString();
            ddl_stayCurrency.Text = ds.Tables[0].Rows[0]["staycurrency"].ToString();
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
            txt_lodgeAdv.Text = ds.Tables[0].Rows[0]["stayadvanceamount"].ToString();
            chkException.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["exemption_raised"]);
            chkpass.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["boardingpasscollected"]);
            txtAdminComments.Text = ds.Tables[0].Rows[0]["admin_comments"].ToString();
            
        }
    }
}