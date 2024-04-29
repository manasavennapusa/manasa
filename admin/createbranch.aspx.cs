using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Admin_Company_createcompany : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        //drp_comp_name.Text = "Escalon";
        drp_comp_name.ReadOnly = true;
        drp_comp_name.BackColor = System.Drawing.SystemColors.Window;
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                ////if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //   // Response.Redirect("~/Authenticate.aspx");
            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }
            //drp_pf.DataBind();
            bind_country();
            bindCompany();
            ddlstate.Items.Clear();
            ddlstate.Items.Insert(0, new ListItem("---Select---", "0"));
            ddlCity.Items.Clear();
            ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    public void btnsv_Click(object sender, EventArgs e)
    {
       
        insert_branch_detail();
    }

    protected void insert_branch_detail()
    {
        string company_id;
        string sqlstr = "select companyid,companyname from tbl_intranet_companydetails where companyname='" + drp_comp_name.Text + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        company_id = ds.Tables[0].Rows[0]["companyid"].ToString();

        //@Company_id int,
        //    @branch_name varchar(50),
        //    @branch_code varchar(50),
        //    @esstt_date datetime,
        //    @region varchar(50),
        //    @add1 varchar(100),
        //    @city varchar(50),
        //    @state varchar(50),
        //    @country varchar(50),
        //    @zipcode varchar(50)       

        SqlParameter[] sqlparam = new SqlParameter[21];

        sqlparam[0] = new SqlParameter("@Company_id", SqlDbType.Int);
        if (drp_comp_name.Text == "")
        {
            sqlparam[0].Value = 0;
          
        }
        else
        {
            //sqlparam[0].Value = drp_comp_name.Text;
            //sqlparam[0].Value = 2;
            sqlparam[0].Value = company_id.ToString();
        }

        sqlparam[1] = new SqlParameter("@branch_code", SqlDbType.VarChar, 50);
        sqlparam[1].Value = txt_branch_code.Value;

        sqlparam[2] = new SqlParameter("@branch_name", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_branch_name.Value.ToString();

        sqlparam[3] = new SqlParameter("@region", SqlDbType.VarChar, 50);
        sqlparam[3].Value = drp_region.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@add1", SqlDbType.VarChar, 100);
        sqlparam[4].Value = txt_pre_add1.Value.ToString();

        sqlparam[5] = new SqlParameter("@city", SqlDbType.VarChar, 50);
        //sqlparam[5].Value = ddlCity.SelectedItem.Text;
        if (ddlCity.Text == "")
            sqlparam[5].Value = System.Data.SqlTypes.SqlString.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[5].Value = ddlCity.SelectedItem.Text;

        sqlparam[6] = new SqlParameter("@state", SqlDbType.VarChar, 50);
        //sqlparam[6].Value = ddlstate.SelectedItem.Text;
        if (ddlstate.Text == "")
            sqlparam[6].Value = System.Data.SqlTypes.SqlString.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[6].Value = ddlstate.SelectedItem.Text;

        sqlparam[7] = new SqlParameter("@country", SqlDbType.VarChar, 50);

        if (ddlCity.Text == "")
            sqlparam[7].Value = System.Data.SqlTypes.SqlString.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[7].Value = ddlcountry.SelectedItem.Text;

        sqlparam[8] = new SqlParameter("@zipcode", SqlDbType.VarChar, 50);
        sqlparam[8].Value = txt_pre_zip.Value;

        sqlparam[9] = new SqlParameter("@esstt_date", SqlDbType.DateTime);
        if (txt_est_date.Text == "")
            sqlparam[9].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[9].Value = Convert.ToDateTime(txt_est_date.Text.ToString());

        sqlparam[10] = new SqlParameter("@pf_group", SqlDbType.Int);
        sqlparam[10].Value = 0;

        sqlparam[11] = new SqlParameter("@pt_group", SqlDbType.Int);
        sqlparam[11].Value = 0;

        sqlparam[12] = new SqlParameter("@esi_group", SqlDbType.Int);
        sqlparam[12].Value = 0;

        sqlparam[13] = new SqlParameter("@esilocalno", SqlDbType.VarChar, 50);
        sqlparam[13].Value = txt_esi_local_no.Value;

        sqlparam[14] = new SqlParameter("@esibranchoffice", SqlDbType.VarChar, 50);
        sqlparam[14].Value = txt_esibranchoffice.Value;

        sqlparam[15] = new SqlParameter("@pfphoneno", SqlDbType.VarChar, 50);
        sqlparam[15].Value = txt_Pfphoneno.Value;

        sqlparam[16] = new SqlParameter("@esiphoneno", SqlDbType.VarChar, 50);
        sqlparam[16].Value = txt_Esiphno.Value;

        sqlparam[17] = new SqlParameter("@panno", SqlDbType.VarChar, 50);
        sqlparam[17].Value = txt_Panno.Value;

        sqlparam[18] = new SqlParameter("@epfoffice", SqlDbType.VarChar, 50);
        sqlparam[18].Value = txt_Epfoffice.Value;

        sqlparam[19] = new SqlParameter("@epfofficeadd", SqlDbType.VarChar, 50);
        sqlparam[19].Value = txt_Epfoffadd.Value;

        sqlparam[20] = new SqlParameter("@ptcircle", SqlDbType.VarChar, 50);
        sqlparam[20].Value = txt_PtCircle.Value;

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_create_branch", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_create_branch", sqlparam);


        if (i <= 0)
        {
            SmartHr.Common.Alert("Work Location code already exists, please enter another Work Location");
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
            reset();
        }
    }

    protected void bindCompany()
    {
        string sqlstr = "select companyid,companyname from tbl_intranet_companydetails";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {
            drp_comp_name.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
            //txtcmpname.Value = ds.Tables[0].Rows[0]["companyname"].ToString();
            //drp_type.SelectedValue = ds.Tables[0].Rows[0]["comp_type"].ToString();
            //txt_est_date.Value = ds.Tables[0].Rows[0]["estt_date"].ToString();
            //txtregno.Value = ds.Tables[0].Rows[0]["reg_no"].ToString();
        }
        catch 
        { 
        }
    }

    protected void reset()
    {
        txt_branch_code.Value = "";
        txt_branch_name.Value = "";
        txt_pre_add1.Value = "";
        ddlCity.SelectedValue = "0";
        ddlcountry.SelectedValue = "0";
        ddlstate.SelectedValue = "0";
        txt_pre_zip.Value = "";
        drp_region.SelectedValue = "0";
        //   drp_pf.SelectedValue = "0";
        //  drp_pt.SelectedValue = "0";
        //  drp_esi.SelectedValue = "0";
        txt_est_date.Text = "";
        txt_esi_local_no.Value = "";
        txt_esibranchoffice.Value = "";
        txt_Pfphoneno.Value = "";
        txt_Esiphno.Value = "";
        txt_PtCircle.Value = "";
        txt_Epfoffadd.Value = "";
        txt_Epfoffice.Value = "";
        txt_Panno.Value = "";


    }
    protected void drp_pf_DataBound(object sender, EventArgs e)
    {
        // drp_pf.Items.Insert(0, new ListItem("Select Group", "0"));
    }
    protected void drp_pt_DataBound(object sender, EventArgs e)
    {
        // drp_pt.Items.Insert(0, new ListItem("Select Group", "0"));
    }
    protected void drp_esi_DataBound(object sender, EventArgs e)
    {
        //drp_esi.Items.Insert(0, new ListItem("Select Group", "0"));
    }
    
    
    protected void ddlcountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlstate.Items.Clear();
        ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlCity.Items.Clear();
        ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlcountry.SelectedItem.Text!="0")
        bind_state(ddlcountry.SelectedItem.Text);
    }

    protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCity.Items.Clear();
        ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddlstate.SelectedItem.Text != "0")
        bind_city(Convert.ToInt32(ddlstate.SelectedValue));

    }

    protected void bind_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlcountry.DataTextField = "countryname";
        ddlcountry.DataValueField = "countryname";
        ddlcountry.DataSource = ds;
        ddlcountry.DataBind();
        ddlcountry.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_state(string stateid)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + stateid + "' ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlstate.DataTextField = "state";
        ddlstate.DataValueField = "ID";
        ddlstate.DataSource = ds;
        ddlstate.DataBind();
        ddlstate.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bind_city(int stateid)
    {
        string sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        ddlCity.DataSource = ds;
        ddlCity.DataTextField = "city";
        ddlCity.DataValueField = "cid";
        ddlCity.DataBind();
        ddlCity.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
}
