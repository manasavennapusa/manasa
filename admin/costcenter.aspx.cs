using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DataAccessLayer;
using System.Data.SqlClient;

public partial class admin_costcenter : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_ddlCCgroup();
            bind_country();
            ddlCostCenterState.Items.Clear();
            ddlCostCenterState.Items.Insert(0, new ListItem("--Select--", "0"));
            ddlCostCenterCity.Items.Clear();
            ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void btnAddCostCenter_Click(object sender, EventArgs e)
    {
        insert_costcenter();
        cleartext();
    }

    protected void insert_costcenter()
    {
        SqlParameter[] sqlParam = new SqlParameter[12];

        sqlParam[0] = new SqlParameter("@cost_center_group_id", SqlDbType.Int);
        sqlParam[0].Value = ddlCostCenterGroup.SelectedValue;

        sqlParam[1] = new SqlParameter("@cost_center_code", SqlDbType.Int);
        sqlParam[1].Value = Convert.ToInt32(txtCostCenterCode.Text);

        sqlParam[2] = new SqlParameter("@cost_center_name", SqlDbType.VarChar, 100);
        sqlParam[2].Value = txtCostCentrName.Text;

        sqlParam[3] = new SqlParameter("@country", SqlDbType.Int);
        sqlParam[3].Value = Convert.ToInt32(ddlCostCenterCountry.SelectedValue);

        sqlParam[4] = new SqlParameter("@state", SqlDbType.Int);
        sqlParam[4].Value = Convert.ToInt32(ddlCostCenterState.SelectedValue);

        sqlParam[5] = new SqlParameter("@city", SqlDbType.Int);
        sqlParam[5].Value = Convert.ToInt32(ddlCostCenterCity.SelectedValue);

        sqlParam[6] = new SqlParameter("@location", SqlDbType.VarChar, 100);
        sqlParam[6].Value = txtCostCenterLocation.Text;

        sqlParam[7] = new SqlParameter("@status", SqlDbType.Bit);
        sqlParam[7].Value = true;

        sqlParam[8] = new SqlParameter("@create_by", SqlDbType.VarChar, 10);
        sqlParam[8].Value = Session["empcode"].ToString();

        sqlParam[9] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlParam[9].Value = DateTime.Now;

        sqlParam[10] = new SqlParameter("@modified_by", SqlDbType.VarChar, 10);
        sqlParam[10].Value = System.Data.SqlTypes.SqlString.Null;

        sqlParam[11] = new SqlParameter("@modified_date", SqlDbType.DateTime);
        sqlParam[11].Value = System.Data.SqlTypes.SqlDateTime.Null;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_cost_center]", sqlParam);
        if (i <= 0)
        {
            message.InnerHtml = "cost center code  already exists, please enter another name";

        }
        else
        {
            message.InnerHtml = "cost center code created successfully";
            cleartext();
            //reset();
        }
    }

    protected void bind_ddlCCgroup()
    {
        sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddlCostCenterGroup.DataSource = ds;
        ddlCostCenterGroup.DataTextField = "cost_center_group_name";
        ddlCostCenterGroup.DataValueField = "id";
        ddlCostCenterGroup.DataBind();
        ddlCostCenterGroup.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_country()
    {
        sqlstr = "select cid,countryname from tbl_intranet_country_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddlCostCenterCountry.DataSource = ds;
        ddlCostCenterCountry.DataTextField = "countryname";
        ddlCostCenterCountry.DataValueField = "cid";
        ddlCostCenterCountry.DataBind();
        ddlCostCenterCountry.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_state(string country)
    {
        sqlstr = "select ID,state,Country from tbl_intranet_state_master where Country='" + country + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddlCostCenterState.DataSource = ds;
        ddlCostCenterState.DataTextField = "state";
        ddlCostCenterState.DataValueField = "ID";
        ddlCostCenterState.DataBind();


       ddlCostCenterState.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_city(int stateid)
    {
        sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddlCostCenterCity.DataSource = ds;
        ddlCostCenterCity.DataTextField = "city";
        ddlCostCenterCity.DataValueField = "cid";
        ddlCostCenterCity.DataBind();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));


    }
    protected void ddlCostCenterCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCostCenterState.Items.Clear();
        ddlCostCenterState.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlCostCenterCity.Items.Clear();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlCostCenterCountry.SelectedValue!="0")
        bind_state(ddlCostCenterCountry.SelectedItem.Text);
        
        
    }
    protected void ddlCostCenterState_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCostCenterCity.Items.Clear();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlCostCenterState.SelectedValue != "0")
        bind_city(Convert.ToInt32(ddlCostCenterState.SelectedValue));
     
    }


    protected void cleartext()
    {
        txtCostCenterCode.Text = "";
        txtCostCentrName.Text = "";
        txtCostCenterLocation.Text = "";
        ddlCostCenterGroup.SelectedValue = "0";
        ddlCostCenterCountry.SelectedValue = "0";
        ddlCostCenterState.SelectedValue = "0";
        ddlCostCenterCity.SelectedValue = "0";

    }
}
