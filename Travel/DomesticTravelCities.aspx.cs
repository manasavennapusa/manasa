using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_DomesticTravelCities : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindtier();
            bindGrid();
            btnSave.Text = "Submit";
            btncancel2.Visible = false;
            create.Visible = true;
            edit.Visible = false;
            bindCountry(ddl_traveltype.SelectedValue);
            bind_state(ddl_country.SelectedItem.Text);
            //ddl_country.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl_state.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl_city.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSave.Attributes.Add("class", "btn btn-primary");
        }
    }

    protected void grdtravelcities_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtravelcities.PageIndex = e.NewPageIndex;
        bindGrid();
    }

    protected void grdtravelcities_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(grdtravelcities.DataKeys[e.RowIndex].Value);

        param[1] = new SqlParameter("@tierID", SqlDbType.Int);
        param[1].Value = ddl_tier.SelectedValue;

        param[2] = new SqlParameter("@cityID", SqlDbType.Int);
        param[2].Value = ddl_city.SelectedValue;

        param[3] = new SqlParameter("@countryid", SqlDbType.Int);
        param[3].Value = ddl_country.SelectedValue;

        param[4] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param[4].Value = ddl_traveltype.SelectedValue;

        param[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[5].Value = Session["empcode"].ToString();

        param[6] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[6].Value = "D";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_domesticCities", param);
        if (i > 0)
        {
            SmartHr.Common.Alert("Domestic City Deleted Successfully.");
            bindGrid();
        }
        else
        {
            SmartHr.Common.Alert("Domestic City Not Deleted Successfully.");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (ViewState["CityTierId"] == "" || ViewState["CityTierId"] == null)
        {
            insertdata();
        }
        else
        {
            updatedata();
        }

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
        if (Request.QueryString["ID"] != null)
        {
            Response.Redirect("DomesticTravelCities.aspx");
        }
    }

    protected void insertdata()
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = 0;

        param[1] = new SqlParameter("@tierID", SqlDbType.Int);
        param[1].Value = ddl_tier.SelectedValue;

        param[2] = new SqlParameter("@cityID", SqlDbType.Int);
        param[2].Value = ddl_city.SelectedValue;

        param[3] = new SqlParameter("@countryid", SqlDbType.Int);
        param[3].Value = ddl_country.SelectedValue;

        param[4] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param[4].Value = ddl_traveltype.SelectedValue;

        param[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[5].Value = Session["empcode"].ToString();

        param[6] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[6].Value = "I";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_domesticCities", param);
        if (i <= 0)
        {
            SmartHr.Common.Alert("Domestic City name already exists, please enter another name.");
        }
        else
        {
            bindGrid();
            clear();
            SmartHr.Common.Alert("Domestic City inserted Successfully.");

        }
    }

    protected void updatedata()
    {
        if (ViewState["CityTierId"] != "" && ViewState["CityTierId"] != null)
        {
            int ID = Convert.ToInt32(ViewState["CityTierId"]);
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@tierID", SqlDbType.Int);
            param[1].Value = ddl_tier.SelectedValue;

            param[2] = new SqlParameter("@cityID", SqlDbType.Int);
            param[2].Value = ddl_city.SelectedValue;

            param[3] = new SqlParameter("@countryid", SqlDbType.Int);
            param[3].Value = ddl_country.SelectedValue;

            param[4] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
            param[4].Value = ddl_traveltype.SelectedValue;

            param[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            param[5].Value = Session["empcode"].ToString();

            param[6] = new SqlParameter("@flag", SqlDbType.Char, 1);
            param[6].Value = "U";

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_domesticCities", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Domestic City name already exists, please enter another name");
            }
            else
            {
                bindGrid();
                clear();
                SmartHr.Common.Alert("Domestic City Updated Successfully.");
            }
        }
    }

    protected void bindGrid()
    {
        btncancel2.Visible = false;
        btnSave.Text = "Submit";
        btnCancel.Visible = true;
        grid1.Visible = true;
        create1.Visible = true;
        create.Visible = true;
        edit1.Visible = false;
        edit.Visible = false;
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_get_domestictravelcities");
        grdtravelcities.DataSource = ds;
        grdtravelcities.DataBind();
    }

    protected void bindData(string ID)
    {
        try
        {
            string sqlstr = "select * from tbl_travel_CityTier where citytierid=" + ID + "";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddl_tier.SelectedValue = ds.Tables[0].Rows[0]["tierID"].ToString();
                ddl_traveltype.SelectedValue = ds.Tables[0].Rows[0]["traveltype"].ToString();
                bindCountry(ddl_traveltype.SelectedValue);
                ddl_country.SelectedValue = ds.Tables[0].Rows[0]["countryid"].ToString();
                bind_state(ddl_country.SelectedItem.Text);


                string sqlstr2 = "select stateid,cid,description from tbl_intranet_city where cid= " + ds.Tables[0].Rows[0]["cityID"].ToString();
                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);
                ddl_state.SelectedValue = ds1.Tables[0].Rows[0]["stateid"].ToString();
                int state_id = Convert.ToInt32(ds1.Tables[0].Rows[0]["stateid"]);
                bindcity(state_id);
                ddl_city.SelectedValue = ds.Tables[0].Rows[0]["cityID"].ToString();
            }
        }
        catch { }
    }

    protected void bindtier()
    {
        try
        {
            string sqlstr = "select tierID,tier from tbl_travel_Tier";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            ddl_tier.DataTextField = "tier";
            ddl_tier.DataValueField = "tierID";
            ddl_tier.DataSource = ds;
            ddl_tier.DataBind();
            ddl_tier.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }
    }

    protected void bindcity(int stateid)
    {
        try
        {
            string sqlstr = "select cid,city from tbl_intranet_city where stateid=" + stateid + "";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            ddl_city.DataTextField = "city";
            ddl_city.DataValueField = "cid";
            ddl_city.DataSource = ds;
            ddl_city.DataBind();
            ddl_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }
    }

    protected void bind_state(string country)
    {
        try
        {
            string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + country + "' ";
            DataSet ds4 = new DataSet();
            ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddl_state.DataTextField = "state";
            ddl_state.DataValueField = "ID";
            ddl_state.DataSource = ds4;
            ddl_state.DataBind();
            ddl_state.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }
    }

    protected void bindCountry(string traveltype)
    {
        try
        {
            string sqlstr = "";
            if (traveltype == "D")
                //sqlstr = "select cid,countryname from tbl_intranet_country_master where cid=98";
                sqlstr = "select cid,countryname from tbl_intranet_country_master";
            else
                sqlstr = "select cid,countryname from tbl_intranet_country_master ";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            ddl_country.DataTextField = "countryname";
            ddl_country.DataValueField = "cid";
            ddl_country.DataSource = ds;
            ddl_country.DataBind();
            ddl_country.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        catch { }
    }

    protected void clear()
    {
        //ddl_traveltype.SelectedValue = "0";
        //ddl_country.SelectedValue = "0";
        ddl_state.SelectedValue = "0";
        ddl_city.SelectedValue = "0";
        //ddl_tier.SelectedValue = "0";
        //btnSave.Text = "Add";
        btnSave.Visible = true;
        btnSave.Attributes.Add("class", "btn btn-primary");
        ViewState["CityTierId"] = "";
    }

    //protected void ddl_traveltype_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //}

    protected void grdtravelcities_PreRender(object sender, EventArgs e)
    {
        if (grdtravelcities.Rows.Count > 0)
        {
            grdtravelcities.UseAccessibleHeader = true;
            grdtravelcities.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    //protected void ddl_country_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //}

    //protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    //{
       
    //}

    protected void grdtravelcities_RowEditing(object sender, GridViewEditEventArgs e)
    {
        btnSave.Text = "Update";
        grid1.Visible = false;
        btnCancel.Visible = false;
        btncancel2.Visible = true;
        create1.Visible = false;
        create.Visible = false;
        edit1.Visible = true;
        edit.Visible = true;
        btnSave.Attributes.Add("class", "btn btn-warning");
        bindData(grdtravelcities.DataKeys[e.NewEditIndex].Value.ToString());
        ViewState["CityTierId"] = grdtravelcities.DataKeys[e.NewEditIndex].Value.ToString();
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/DomesticTravelCities.aspx");
    }
    protected void ddl_country_SelectedIndexChanged1(object sender, EventArgs e)
    {
        bind_state(ddl_country.SelectedItem.Text);
    }
    protected void ddl_country_DataBound(object sender, EventArgs e)
    {

    }
    protected void ddl_traveltype_SelectedIndexChanged1(object sender, EventArgs e)
    {
        bindCountry(ddl_traveltype.SelectedValue);
    }
    protected void ddl_traveltype_DataBound(object sender, EventArgs e)
    {

    }
    protected void ddl_state_SelectedIndexChanged1(object sender, EventArgs e)
    {
        bindcity(Convert.ToInt32(ddl_state.SelectedValue));
    }
}