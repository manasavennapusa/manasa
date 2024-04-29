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
public partial class admin_costcenteredit : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_ddlCCgroup();
            bind_country();
            bind_information();
        }
    }
    protected void btnEditCostCenter_Click(object sender, EventArgs e)
    {
        edit_costcenter();
         //cleartext();
        // 
    }
    protected void edit_costcenter()
    {
        SqlParameter[] sqlParam = new SqlParameter[11];

        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = Convert.ToInt32(Request.QueryString["id"]);

        sqlParam[1] = new SqlParameter("@cost_center_group_id", SqlDbType.Int);
        sqlParam[1].Value = Convert.ToInt32(ddlCostCenterGroup.SelectedValue);

        sqlParam[2] = new SqlParameter("@cost_center_code", SqlDbType.Int);
        sqlParam[2].Value = Convert.ToInt32(txtCostCenterCode.Text);

        sqlParam[3] = new SqlParameter("@cost_center_name", SqlDbType.VarChar, 100);
        sqlParam[3].Value = txtCostCentrName.Text;

        sqlParam[4] = new SqlParameter("@country", SqlDbType.Int);
        sqlParam[4].Value = Convert.ToInt32(ddlCostCenterCountry.SelectedValue);

        sqlParam[5] = new SqlParameter("@state", SqlDbType.Int);
        sqlParam[5].Value = Convert.ToInt32(ddlCostCenterState.SelectedValue);

        sqlParam[6] = new SqlParameter("@city", SqlDbType.Int);
        sqlParam[6].Value = Convert.ToInt32(ddlCostCenterCity.SelectedValue);

        sqlParam[7] = new SqlParameter("@location", SqlDbType.VarChar, 100);
        sqlParam[7].Value = txtCostCenterLocation.Text;

        sqlParam[8] = new SqlParameter("@modified_by", SqlDbType.VarChar, 10);
        sqlParam[8].Value = Session["empcode"].ToString();


        sqlParam[9] = new SqlParameter("@modified_date", SqlDbType.DateTime);
        sqlParam[9].Value = DateTime.Now;

        sqlParam[10] = new SqlParameter("@message", SqlDbType.VarChar, 200);
        sqlParam[10].Direction = ParameterDirection.Output;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_costcenter]", sqlParam);

        //if (sqlParam[10].Value != DBNull.Value)
        //{
        //}
        

        if (i <= 0)
        {
            message.Text = sqlParam[10].Value.ToString();

        }
        else
        {
            message.Text = sqlParam[10].Value.ToString();
            cleartext();
            Response.Redirect("costcenterview.aspx?updated=true");
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
        DataSet ds_country = new DataSet();
        ds_country = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlCostCenterCountry.DataSource = ds_country;
        ddlCostCenterCountry.DataTextField = "countryname";
        ddlCostCenterCountry.DataValueField = "cid";
        ddlCostCenterCountry.DataBind();
        ddlCostCenterCountry.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void bind_state(string country)
    {
        sqlstr = "select ID,state,Country from tbl_intranet_state_master where Country='" + country + "'";
        DataSet ds_state = new DataSet();
        ds_state = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
       
        ddlCostCenterState.DataSource = ds_state;
        ddlCostCenterState.DataTextField = "state";
        ddlCostCenterState.DataValueField = "ID";
        ddlCostCenterState.DataBind();

        ddlCostCenterState.Items.Insert(0, new ListItem("--Select--", "0"));


    }

    protected void bind_city(int stateid)
    {
        sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        DataSet ds_city = new DataSet();
        ds_city = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        
        ddlCostCenterCity.DataSource = ds_city;
        ddlCostCenterCity.DataTextField = "city";
        ddlCostCenterCity.DataValueField = "cid";
        ddlCostCenterCity.DataBind();

        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));

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

    protected void bind_information()
    {
        if (Request.QueryString["id"] != null)
        {
            string sqlstr = @"select cost_center_group_id,cost_center_code,cost_center_name,country,state,city,location from tbl_intranet_cost_center where id =" + Request.QueryString["id"].ToString();

            try
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                txtCostCenterCode.Text = ds.Tables[0].Rows[0]["cost_center_code"].ToString();
                txtCostCentrName.Text = ds.Tables[0].Rows[0]["cost_center_name"].ToString();
                txtCostCenterLocation.Text = ds.Tables[0].Rows[0]["location"].ToString();
                ddlCostCenterGroup.SelectedValue = ds.Tables[0].Rows[0]["cost_center_group_id"].ToString();
                ddlCostCenterCountry.SelectedValue = ds.Tables[0].Rows[0]["country"].ToString();

                bind_state(ddlCostCenterCountry.SelectedItem.Text);

                ddlCostCenterState.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
                bind_city(Convert.ToInt32(ddlCostCenterState.SelectedValue));
                ddlCostCenterCity.SelectedValue = ds.Tables[0].Rows[0]["city"].ToString();
            }
            catch { }
        }
    }

    protected void ddlCostCenterCountry_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlCostCenterState.Items.Clear();
        ddlCostCenterState.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlCostCenterCity.Items.Clear();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlCostCenterCountry.SelectedValue!="0")
        bind_state(ddlCostCenterCountry.SelectedItem.Text);
        
    }
    protected void ddlCostCenterState_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlCostCenterCity.Items.Clear();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlCostCenterState.SelectedValue != "0")
        bind_city(Convert.ToInt32(ddlCostCenterState.SelectedValue));
        

    }
}
