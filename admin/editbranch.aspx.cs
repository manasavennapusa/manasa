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
    string strsql;
    string sqlstr;

    protected void Page_Load(object sender, EventArgs e)
    {
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
            //  bindpf();
            //  bindpt();
            //  bindesi();
            bind_information();
            //bind_country();
        }
        bind_information();
    }

    protected void bindpf()
    {
        // strsql = "select id,group_name from tbl_payroll_pfgroup_details where status=1";
        // drp_pf.DataTextField = "group_name";
        // drp_pf.DataValueField = "id";
        //  drp_pf.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql);
        //  drp_pf.DataBind();

    }

    protected void bindpt()
    {
        // strsql = "select id,ptgrp_name from tbl_payroll_ptgroup_details where status =1";
        // drp_pt.DataTextField = "ptgrp_name";
        //  drp_pt.DataValueField = "id";
        //  drp_pt.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql);
        //  drp_pt.DataBind();
    }

    protected void bindesi()
    {
        //strsql = "select id,esigrp_name from tbl_payroll_esigroup_details where status =1";
        //drp_esi.DataTextField = "esigrp_name";
        //drp_esi.DataValueField = "id";
        //drp_esi.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, strsql);
        //drp_esi.DataBind();
    }

    //public void btnsv_Click(object sender, EventArgs e)
    //{
    //    

    //}

    protected void bind_information()
    {
        if (Request.QueryString["branch_id"] != null)
        {
            string sqlstr = @"SELECT tbl_intranet_companydetails.companyid,tbl_intranet_companydetails.companyname, tbl_intranet_branch_detail.branch_name, tbl_intranet_branch_detail.Branch_Id,tbl_intranet_branch_detail.branch_code,(CASE WHEN tbl_intranet_branch_detail.esstt_date='01/01/1990' THEN '' ELSE CONVERT(varchar(12), tbl_intranet_branch_detail.esstt_date, 106) END)esstt_date,tbl_intranet_branch_detail.region, tbl_intranet_branch_detail.add1,tbl_intranet_branch_detail.city, tbl_intranet_branch_detail.state, tbl_intranet_branch_detail.country, tbl_intranet_branch_detail.zipcode, tbl_intranet_branch_detail.pf_group, tbl_intranet_branch_detail.pt_group, tbl_intranet_branch_detail.esi_group,tbl_intranet_branch_detail.pf_group,
tbl_intranet_branch_detail.pt_group,esi_group,tbl_intranet_branch_detail.ptcircle,
tbl_intranet_branch_detail.esilocalno,tbl_intranet_branch_detail.esibranchoffice,
tbl_intranet_branch_detail.esiphoneno,tbl_intranet_branch_detail.epfoffice
,tbl_intranet_branch_detail.epfofficeadd,tbl_intranet_branch_detail.pfphoneno,tbl_intranet_branch_detail.panno FROM tbl_intranet_branch_detail left JOIN tbl_intranet_companydetails ON tbl_intranet_branch_detail.Company_id = tbl_intranet_companydetails.companyid where branch_id =" + Request.QueryString["branch_id"].ToString();

            try
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                drp_comp_name.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
                txt_branch_name.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
                txt_branch_code.Text = ds.Tables[0].Rows[0]["branch_code"].ToString();
                //txt_est_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["esstt_date"].ToString()).ToString("dd-MMM-yyyy");
                if (ds.Tables[0].Rows[0]["esstt_date"].ToString() != "")
                    txt_est_date.Text = Convert.ToDateTime(ds.Tables[0].Rows[0]["esstt_date"].ToString()).ToString("dd-MMM-yyyy");
                else txt_est_date.Text = "";
                drp_region.SelectedValue = ds.Tables[0].Rows[0]["region"].ToString();
                txt_pre_add1.Text = ds.Tables[0].Rows[0]["add1"].ToString();

                ddlCostCenterCountry.SelectedValue = ds.Tables[0].Rows[0]["country"].ToString();
                ddlCostCenterState.SelectedValue = ds.Tables[0].Rows[0]["state"].ToString();
              

                txt_pre_zip.Text = ds.Tables[0].Rows[0]["zipcode"].ToString();

                bind_country();
                ddlCostCenterCountry.SelectedValue = ds.Tables[0].Rows[0]["country"].ToString();

                bind_state(ddlCostCenterCountry.SelectedValue);
                string sqlstr1 = "select ID,state from tbl_intranet_state_master where state='" + ds.Tables[0].Rows[0]["state"].ToString() + "' ";
                DataSet ds10 = new DataSet();
                ds10 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
                ddlCostCenterState.SelectedValue = ds10.Tables[0].Rows[0]["ID"].ToString();


                bind_city(Convert.ToInt32(ddlCostCenterState.SelectedValue));

                string sqlstr2 = "select cid,stateid,city from tbl_intranet_city where city='" + ds.Tables[0].Rows[0]["city"].ToString() + "'";
                DataSet ds9 = new DataSet();
                ds9 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);

               // ddlCostCenterCity.SelectedValue = ds9.Tables[0].Rows[0]["city"].ToString();

                ddlCostCenterCity.SelectedValue = ds.Tables[0].Rows[0]["city"].ToString();

                //  drp_pf.SelectedValue = ds.Tables[0].Rows[0]["pf_group"].ToString();
                // drp_pt.SelectedValue = ds.Tables[0].Rows[0]["pt_group"].ToString();
                // drp_esi.SelectedValue = ds.Tables[0].Rows[0]["esi_group"].ToString();
                txt_esi_local_no.Text = ds.Tables[0].Rows[0]["esilocalno"].ToString();
                txt_esibranchoffice.Text = ds.Tables[0].Rows[0]["esibranchoffice"].ToString();
                txt_Pfphoneno.Text = ds.Tables[0].Rows[0]["pfphoneno"].ToString();
                txt_Esiphno.Text = ds.Tables[0].Rows[0]["esiphoneno"].ToString();
                txt_PtCircle.Text = ds.Tables[0].Rows[0]["ptcircle"].ToString();
                txt_Epfoffadd.Text = ds.Tables[0].Rows[0]["epfofficeadd"].ToString();
                txt_Epfoffice.Text = ds.Tables[0].Rows[0]["epfoffice"].ToString();
                txt_Panno.Text = ds.Tables[0].Rows[0]["panno"].ToString();

            }
            catch { }
        }
    }

    protected void insert_branch_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[22];

        sqlparam[0] = new SqlParameter("@branch_code", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_branch_code.Text;

        sqlparam[1] = new SqlParameter("@branch_name", SqlDbType.VarChar, 50);
        sqlparam[1].Value = txt_branch_name.Text;

        sqlparam[2] = new SqlParameter("@region", SqlDbType.VarChar, 50);
        sqlparam[2].Value = drp_region.SelectedItem.ToString();

        sqlparam[3] = new SqlParameter("@add1", SqlDbType.VarChar, 100);
        sqlparam[3].Value = txt_pre_add1.Text;

        sqlparam[4] = new SqlParameter("@city", SqlDbType.VarChar, 50);
      
        if (ddlCostCenterCity.Text == "")
            sqlparam[4].Value = System.Data.SqlTypes.SqlString.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[4].Value = ddlCostCenterCity.SelectedItem.Text;

        sqlparam[5] = new SqlParameter("@state", SqlDbType.VarChar, 50);
        //sqlparam[5].Value = ddlCostCenterState.SelectedItem.Text;
        if (ddlCostCenterState.Text == "")
            sqlparam[5].Value = System.Data.SqlTypes.SqlString.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[5].Value = ddlCostCenterState.SelectedItem.Text;
        sqlparam[6] = new SqlParameter("@country", SqlDbType.VarChar, 50);
        //sqlparam[6].Value = ddlCostCenterCountry.SelectedValue;
        if (ddlCostCenterCountry.Text == "")
            sqlparam[6].Value = System.Data.SqlTypes.SqlString.Null;
        else
            //sqlparam[9].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
            sqlparam[6].Value = ddlCostCenterCountry.SelectedItem.Text;

        sqlparam[7] = new SqlParameter("@zipcode", SqlDbType.VarChar, 50);
        sqlparam[7].Value = txt_pre_zip.Text;

        sqlparam[8] = new SqlParameter("@esstt_date", SqlDbType.DateTime);
        if (txt_est_date.Text == "")
            sqlparam[8].Value = System.Data.SqlTypes.SqlDateTime.Null;
        else
           // sqlparam[8].Value = Utilities.Utility.dataformat(txt_est_date.Text.ToString());
           sqlparam[8].Value = Convert.ToDateTime(txt_est_date.Text.ToString());
        sqlparam[9] = new SqlParameter("@branch_id", SqlDbType.Int);
        sqlparam[9].Value = Convert.ToInt32(Request.QueryString["branch_id"].ToString());

        sqlparam[10] = new SqlParameter("@pf_group", SqlDbType.Int);
        sqlparam[10].Value = 0;

        sqlparam[11] = new SqlParameter("@pt_group", SqlDbType.Int);
        sqlparam[11].Value = 0;

        sqlparam[12] = new SqlParameter("@esi_group", SqlDbType.Int);
        sqlparam[12].Value = 0;

        sqlparam[13] = new SqlParameter("@esilocalno", SqlDbType.VarChar, 50);
        sqlparam[13].Value = txt_esi_local_no.Text;

        sqlparam[14] = new SqlParameter("@esibranchoffice", SqlDbType.VarChar, 50);
        sqlparam[14].Value = txt_esibranchoffice.Text;

        sqlparam[15] = new SqlParameter("@pfphoneno", SqlDbType.VarChar, 50);
        sqlparam[15].Value = txt_Pfphoneno.Text;

        sqlparam[16] = new SqlParameter("@esiphoneno", SqlDbType.VarChar, 50);
        sqlparam[16].Value = txt_Esiphno.Text;

        sqlparam[17] = new SqlParameter("@panno", SqlDbType.VarChar, 50);
        sqlparam[17].Value = txt_Panno.Text;

        sqlparam[18] = new SqlParameter("@epfoffice", SqlDbType.VarChar, 50);
        sqlparam[18].Value = txt_Epfoffice.Text;

        sqlparam[19] = new SqlParameter("@epfofficeadd", SqlDbType.VarChar, 50);
        sqlparam[19].Value = txt_Epfoffadd.Text;

        sqlparam[20] = new SqlParameter("@ptcircle", SqlDbType.VarChar, 50);
        sqlparam[20].Value = txt_PtCircle.Text;
        sqlparam[21] = new SqlParameter("@Company_id", SqlDbType.Int);
        if (drp_comp_name.Text == "")
        {
            sqlparam[21].Value = 0;

        }
        else
        {
            //sqlparam[21].Value = drp_comp_name.Text;
            sqlparam[21].Value = 2;
        }

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_branch", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_edit_branch]", sqlparam);
        if (i <= 0)
        {
            message.InnerHtml = "Work Location code already exists, please enter another Work Location";
        }
        else
        {
        

            Response.Redirect("branchview.aspx?updated=true");
            reset();

        }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
        txt_pre_add1.Text = "";
        txt_pre_zip.Text = "";
        txt_pre_zip.Text = "";
        drp_region.SelectedValue = "0";
        // drp_pf.SelectedValue = "0";
        // drp_pt.SelectedValue = "0";
        // drp_esi.SelectedValue = "0";
        txt_est_date.Text = "";
        txt_esi_local_no.Text = "";
        txt_esibranchoffice.Text = "";
        txt_Pfphoneno.Text = "";
        txt_Esiphno.Text = "";
        txt_PtCircle.Text = "";
        txt_Epfoffadd.Text = "";
        txt_Epfoffice.Text = "";
        txt_Panno.Text = "";
    }

    protected void drp_pf_DataBound(object sender, EventArgs e)
    {
        //   drp_pf.Items.Insert(0, new ListItem("Select Group", "0"));
    }

    protected void drp_pt_DataBound(object sender, EventArgs e)
    {
        // drp_pt.Items.Insert(0, new ListItem("Select Group", "0"));
    }

    protected void drp_esi_DataBound(object sender, EventArgs e)
    {
        // drp_esi.Items.Insert(0, new ListItem("Select Group", "0"));
    }

    protected void bind_country()
    {
        sqlstr = "select cid,countryname from tbl_intranet_country_master";
        DataSet ds_country = new DataSet();
        ds_country = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddlCostCenterCountry.DataSource = ds_country;
        ddlCostCenterCountry.DataTextField = "countryname";
        ddlCostCenterCountry.DataValueField = "countryname";
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
        //ddlCostCenterState.DataValueField = "ID";
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

    protected void ddlCostCenterCountry_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlCostCenterState.Items.Clear();
        ddlCostCenterState.Items.Insert(0, new ListItem("--Select--", "0"));
        ddlCostCenterCity.Items.Clear();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlCostCenterCountry.SelectedItem.Text!="0")
        bind_state(ddlCostCenterCountry.SelectedItem.Text);
        
    }

    protected void ddlCostCenterState_SelectedIndexChanged1(object sender, EventArgs e)
    {
        ddlCostCenterCity.Items.Clear();
        ddlCostCenterCity.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddlCostCenterState.SelectedItem.Text != "0")
        bind_city(Convert.ToInt32(ddlCostCenterState.SelectedValue));
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

        Response.Redirect("branchview.aspx");
    }

    protected void btnsv1_Click(object sender, EventArgs e)
    {
        insert_branch_detail();
    }

}
