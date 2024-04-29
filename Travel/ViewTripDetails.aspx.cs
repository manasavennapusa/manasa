using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Travel_ViewTripDetails : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    public int i;

    DataTable dtable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
           
            if (Request.QueryString["tripid"] != null)
            {
                int tripid = Convert.ToInt32(Request.QueryString["tripid"]);
                bindTripByTripID(tripid);
                
            }

        }
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
            lblairlinedetails.Text = ds.Tables[0].Rows[0]["airlinemembershipdetails"].ToString()!=""?("<br/><b>Details :- </b>" + ds.Tables[0].Rows[0]["airlinemembershipdetails"].ToString()):"";
            lblhoteldetails.Text =ds.Tables[0].Rows[0]["hotelmembershipdetails"].ToString()!=""?("<br/><b>Details :- </b>" + ds.Tables[0].Rows[0]["hotelmembershipdetails"].ToString()):"";
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
    

    
}