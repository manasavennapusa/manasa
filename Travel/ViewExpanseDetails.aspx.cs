using System;
using System.Data;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

public partial class Travel_ViewExpanseDetails : System.Web.UI.Page
{
    decimal traveltotal = 0;
    decimal lodgingtotal = 0;
    decimal oopltotal = 0;
    decimal mislineoustotal = 0;
    decimal personalcartotal = 0;
    decimal phonefaxtotal = 0;
    string sqlstr;
    DataSet ds;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Request.QueryString["tripid"] != null)
            {
                int tripid = Convert.ToInt32(Request.QueryString["tripid"]);
                bindExpanseDetails(tripid);
            }
        }
    }

    protected void bindExpanseDetails(int tripid)
    {
        sqlstr = @"select ed.*,td.tripno,ct.currencycode from tbl_travel_ExpenseDetails ed with(nolock)
                        inner join tbl_travel_TripDetails td with(nolock) on ed.tripid=td.tripid
                        left join tbl_intranet_currencycode ct on ct.id=ed.currenceycode
                        where ed.status=1 and ed.tripid=" + tripid.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        DataView ExpanseDV = new DataView(ds.Tables[0]);
        ExpanseDV.RowFilter = "expensetype = 'Travel'";
        
        grdtravel.DataSource = ExpanseDV;
        grdtravel.DataBind();

        ExpanseDV.RowFilter = "expensetype = 'L & C (Stay)'";
        grdlodging.DataSource = ExpanseDV;
        grdlodging.DataBind();

        ExpanseDV.RowFilter = "expensetype = 'OOP'";
        grdoop.DataSource = ExpanseDV; 
        grdoop.DataBind();

        ExpanseDV.RowFilter = "expensetype = 'Miscellaneous'";
        grdmiscillenaous.DataSource = ExpanseDV;
        grdmiscillenaous.DataBind();

        ExpanseDV.RowFilter = "expensetype = 'PersonalCar'";
        grdpersonalcar.DataSource = ExpanseDV;
        grdpersonalcar.DataBind();

        ExpanseDV.RowFilter = "expensetype = 'Telephone'";
        grdtelephone.DataSource = ExpanseDV;
        grdtelephone.DataBind();
    }

    protected void grdtravel_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            traveltotal = traveltotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = traveltotal.ToString();
        }
    }
    
    protected void grdlodging_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            lodgingtotal = lodgingtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = lodgingtotal.ToString();
        }
    }
    
    protected void grdoop_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            oopltotal = oopltotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = oopltotal.ToString();
        }
    }
    
    protected void grdmiscillenaous_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            mislineoustotal = mislineoustotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = mislineoustotal.ToString();
        }
    }
    
    protected void grdpersonalcar_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            personalcartotal = personalcartotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = personalcartotal.ToString();
        }
    }
   
    protected void grdtelephone_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            decimal rowtotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "amount"));
            phonefaxtotal = phonefaxtotal + rowtotal;
        }
        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label lbl = (Label)e.Row.FindControl("lblTotalamount");
            lbl.Text = phonefaxtotal.ToString();
        }
    }

    
}