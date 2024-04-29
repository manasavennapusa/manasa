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
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            bind_per_country();
            bind_pre_country();
            bindinformation();
        }
    }

    public void btnsv_Click(object sender, EventArgs e)
   {
        insert_company_detail();

        Response.Redirect("viewcompany.aspx?updated=true");
    }

    protected void bindinformation()
    {
        string sqlstr = "select companyname,comp_type,(CASE WHEN estt_date='01/01/1990' THEN '' ELSE CONVERT(CHAR(10), estt_date, 101)END)estt_date,reg_no,pan_no,tin_no,url,logo,corp_add1,corp_add2,corp_city,corp_state,corp_country,corp_zip,corp_phone,cors_add1,cors_add2,cors_city,cors_state,cors_country,cors_zip,cors_phone,tan_no,tds_circle,pf_trust,comp_engaged,epf_no,epf_dbf_filecode,epf_dbf_ext,esi_no,esi_local_no,resp_person from  tbl_intranet_companydetails ";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {
            txtcmpname.Value = ds.Tables[0].Rows[0]["companyname"].ToString();
            drp_type.SelectedValue = ds.Tables[0].Rows[0]["comp_type"].ToString();
            txt_est_date.Value = ds.Tables[0].Rows[0]["estt_date"].ToString();
            txtregno.Value = ds.Tables[0].Rows[0]["reg_no"].ToString();
            txt_pan.Value = ds.Tables[0].Rows[0]["pan_no"].ToString();
            txttin.Value = ds.Tables[0].Rows[0]["tin_no"].ToString();
            txtcmpurl.Value = ds.Tables[0].Rows[0]["url"].ToString();
            txt_tanno.Value = ds.Tables[0].Rows[0]["tan_no"].ToString();
            txt_tds.Value = ds.Tables[0].Rows[0]["tds_circle"].ToString();
            drp_pftrust.SelectedValue = ds.Tables[0].Rows[0]["pf_trust"].ToString();
            ViewState.Add("Logo", ds.Tables[0].Rows[0]["logo"].ToString());
            txt_pre_add1.Value = ds.Tables[0].Rows[0]["corp_add1"].ToString();
            txt_pre_Add2.Value = ds.Tables[0].Rows[0]["corp_add2"].ToString();

            if ((ds.Tables[0].Rows[0]["corp_country"] == null) || (ds.Tables[0].Rows[0]["corp_country"].ToString() == "") || (ds.Tables[0].Rows[0]["corp_country"].ToString() == "0"))
            {

            }
            else
            {
                ddl_pre_country.SelectedValue = ds.Tables[0].Rows[0]["corp_country"].ToString();
                bind_pre_state(ddl_pre_country.SelectedValue);
            }
            if ((ds.Tables[0].Rows[0]["corp_state"] == null) || (ds.Tables[0].Rows[0]["corp_state"].ToString() == "") || (ds.Tables[0].Rows[0]["corp_state"].ToString() == "0"))
            {
                ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddl_pre_state.SelectedValue = ds.Tables[0].Rows[0]["corp_state"].ToString();
                bind_pre_city(ddl_pre_state.SelectedValue);
            }
            if ((ds.Tables[0].Rows[0]["corp_city"] == null) || (ds.Tables[0].Rows[0]["corp_city"].ToString() == "") || (ds.Tables[0].Rows[0]["corp_city"].ToString() == "0"))
            {
                ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddl_pre_city.SelectedValue = ds.Tables[0].Rows[0]["corp_city"].ToString();
            }

            txt_pre_zip.Value = ds.Tables[0].Rows[0]["corp_zip"].ToString();
            txt_pre_phone.Value = ds.Tables[0].Rows[0]["corp_phone"].ToString().Trim();
            txt_per_add1.Value = ds.Tables[0].Rows[0]["cors_add1"].ToString();
            txt_per_add2.Value = ds.Tables[0].Rows[0]["cors_add2"].ToString();
            if ((ds.Tables[0].Rows[0]["cors_country"] == null) || (ds.Tables[0].Rows[0]["cors_country"].ToString() == "") || (ds.Tables[0].Rows[0]["cors_country"].ToString() == "0"))
            {

            }
            else
            {
                ddl_per_country.SelectedValue = ds.Tables[0].Rows[0]["cors_country"].ToString();
                bind_per_state(ddl_per_country.SelectedValue);

            }
            if ((ds.Tables[0].Rows[0]["cors_state"] == null) || (ds.Tables[0].Rows[0]["cors_state"].ToString() == "") || (ds.Tables[0].Rows[0]["cors_state"].ToString() == "0"))
            {
                ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddl_per_state.SelectedValue = ds.Tables[0].Rows[0]["cors_state"].ToString();
                bind_per_city(ddl_per_state.SelectedValue);
            }

            if ((ds.Tables[0].Rows[0]["cors_city"] == null) || (ds.Tables[0].Rows[0]["cors_city"].ToString() == "") || (ds.Tables[0].Rows[0]["cors_city"].ToString() == "0"))
            {
                ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
            }
            else
            {
                ddl_per_city.SelectedValue = ds.Tables[0].Rows[0]["cors_city"].ToString();
            }
            txt_per_zip.Value = ds.Tables[0].Rows[0]["cors_zip"].ToString();
            txt_per_phone.Text = ds.Tables[0].Rows[0]["cors_phone"].ToString().Trim();

            txt_comp_eng.Value = ds.Tables[0].Rows[0]["comp_engaged"].ToString();
            txt_resppers.Value = ds.Tables[0].Rows[0]["resp_person"].ToString();
            txt_epfno.Value = ds.Tables[0].Rows[0]["epf_no"].ToString();
            txt_dbffile.Value = ds.Tables[0].Rows[0]["epf_dbf_filecode"].ToString();
            txt_fileext.Text = ds.Tables[0].Rows[0]["epf_dbf_ext"].ToString();
            txt_esino.Value = ds.Tables[0].Rows[0]["esi_no"].ToString();
            txt_esilocalno.Value = ds.Tables[0].Rows[0]["esi_local_no"].ToString();
        }
        catch { }
    }

    protected void insert_company_detail()
    {
        string file_name;

        if (Page.IsValid)
        {
            //if (fupload.HasFile.ToString() != "")
            //{
            //    file_name = "insight-logo1.gif";
            //    fupload.PostedFile.SaveAs(Server.MapPath("../upload/logo/" + file_name));
            //    ViewState.Add("Logo", file_name);
            //}
        }
        SqlParameter[] sqlparam = new SqlParameter[33];
        sqlparam[0] = new SqlParameter("@companyname", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txtcmpname.Value.Trim().ToString();
        sqlparam[1] = new SqlParameter("@comp_type", SqlDbType.VarChar, 50);
        sqlparam[1].Value = drp_type.SelectedItem.ToString();
        sqlparam[2] = new SqlParameter("@estt_date", SqlDbType.DateTime);
        sqlparam[2].Value = Utilities.Utility.dataformat(txt_est_date.Value.ToString());
        sqlparam[3] = new SqlParameter("@reg_no", SqlDbType.VarChar, 50);
        sqlparam[3].Value = txtregno.Value;
        sqlparam[4] = new SqlParameter("@pan_no", SqlDbType.VarChar, 50);
        sqlparam[4].Value = txt_pan.Value;
        sqlparam[5] = new SqlParameter("@tin_no", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txttin.Value;
        sqlparam[6] = new SqlParameter("@url", SqlDbType.VarChar, 50);
        sqlparam[6].Value = txtcmpurl.Value;
        //sqlparam[7] = new SqlParameter("@logo", SqlDbType.VarChar, 50);
        //sqlparam[7].Value = ViewState["Logo"].ToString();
        sqlparam[7] = new SqlParameter("@corp_add1", SqlDbType.VarChar, 50);
        sqlparam[7].Value = txt_pre_add1.Value;
        sqlparam[8] = new SqlParameter("@corp_add2", SqlDbType.VarChar, 50);
        sqlparam[8].Value = txt_pre_Add2.Value;
        sqlparam[9] = new SqlParameter("@corp_city", SqlDbType.VarChar, 50);
        sqlparam[9].Value = ddl_pre_city.SelectedValue;
        sqlparam[10] = new SqlParameter("@corp_state", SqlDbType.VarChar, 50);
        sqlparam[10].Value = ddl_pre_state.SelectedValue;
        sqlparam[11] = new SqlParameter("@corp_country", SqlDbType.VarChar, 50);
        sqlparam[11].Value = ddl_pre_country.SelectedValue;
        sqlparam[12] = new SqlParameter("@corp_zip", SqlDbType.VarChar, 50);
        sqlparam[12].Value = txt_pre_zip.Value;
        sqlparam[13] = new SqlParameter("@corp_phone", SqlDbType.VarChar, 50);
        sqlparam[13].Value = txt_pre_phone.Value.Trim().ToString();
        sqlparam[14] = new SqlParameter("@cors_add1", SqlDbType.VarChar, 50);
        sqlparam[14].Value = txt_per_add1.Value;
        sqlparam[15] = new SqlParameter("@cors_add2", SqlDbType.VarChar, 50);
        sqlparam[15].Value = txt_per_add2.Value;
        sqlparam[16] = new SqlParameter("@cors_city", SqlDbType.VarChar, 50);
        sqlparam[16].Value = ddl_per_city.SelectedValue;
        sqlparam[17] = new SqlParameter("@cors_state", SqlDbType.VarChar, 50);
        sqlparam[17].Value = ddl_per_state.SelectedValue;
        sqlparam[18] = new SqlParameter("@cors_country", SqlDbType.VarChar, 50);
        sqlparam[18].Value = ddl_per_country.SelectedValue;
        sqlparam[19] = new SqlParameter("@cors_zip", SqlDbType.VarChar, 50);
        sqlparam[19].Value = txt_per_zip.Value;
        sqlparam[20] = new SqlParameter("@cors_phone", SqlDbType.VarChar, 50);
        sqlparam[20].Value = txt_per_phone.Text.Trim().ToString();
        sqlparam[21] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
        sqlparam[21].Value = Session["name"].ToString();
        sqlparam[22] = new SqlParameter("@updated_by", SqlDbType.VarChar, 50);
        sqlparam[22].Value = Session["name"].ToString();

        sqlparam[23] = new SqlParameter("@tan_no", SqlDbType.VarChar, 50);
        sqlparam[23].Value = txt_tanno.Value.Trim().ToString();
        sqlparam[24] = new SqlParameter("@tds_circle", SqlDbType.VarChar, 50);
        sqlparam[24].Value = txt_tds.Value.Trim().ToString();
        sqlparam[25] = new SqlParameter("@pf_trust", SqlDbType.VarChar, 50);
        sqlparam[25].Value = drp_pftrust.SelectedItem.ToString();

        sqlparam[26] = new SqlParameter("@comp_engaged", SqlDbType.VarChar, 50);
        sqlparam[26].Value = txt_comp_eng.Value.Trim().ToString();
        sqlparam[27] = new SqlParameter("@epf_no", SqlDbType.VarChar, 50);
        sqlparam[27].Value = txt_epfno.Value.Trim().ToString();
        sqlparam[28] = new SqlParameter("@epf_dbf_filecode", SqlDbType.VarChar, 50);
        sqlparam[28].Value = txt_dbffile.Value.Trim().ToString();
        sqlparam[29] = new SqlParameter("@epf_dbf_ext", SqlDbType.VarChar, 50);
        sqlparam[29].Value = txt_fileext.Text.Trim().ToString();
        sqlparam[30] = new SqlParameter("@esi_no", SqlDbType.VarChar, 50);
        sqlparam[30].Value = txt_esino.Value.Trim().ToString();
        sqlparam[31] = new SqlParameter("@esi_local_no", SqlDbType.VarChar, 50);
        sqlparam[31].Value = txt_esilocalno.Value.Trim().ToString();
        sqlparam[32] = new SqlParameter("@resp_person", SqlDbType.VarChar, 100);
        sqlparam[32].Value = txt_resppers.Value.Trim().ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_update_company", sqlparam);

        //string str = "<script> alert('Company Update sucessfully')</script>";
        //Page.RegisterStartupScript("vv", str.ToString());
        //reset();           
    }

    protected void reset()
    {
        txtcmpname.Value = "";
        drp_type.SelectedValue = "0";
        txt_est_date.Value = "";
        txtregno.Value = "";
        txt_pan.Value = "";
        txttin.Value = "";
        txtcmpurl.Value = "";
        txt_pre_add1.Value = "";
        txt_pre_Add2.Value = "";
        //ddl_pre_city.SelectedValue = "0";
        //ddl_pre_state.SelectedValue = "0";
        //ddl_pre_country.SelectedValue = "0";
        txt_pre_zip.Value = "";
        txt_pre_phone.Value = "";
        txt_per_add1.Value = "";
        txt_per_add2.Value = "";
        //ddl_per_city.SelectedValue = "0";
        //ddl_per_state.SelectedValue = "0";
        //ddl_per_country.SelectedValue = "0";
        txt_per_zip.Value = "";
        txt_per_phone.Text = "";
        txt_tanno.Value = "";
        txt_tds.Value = "";
        drp_pftrust.SelectedValue = "0";

        txt_comp_eng.Value = "";
        txt_resppers.Value = "";
        txt_epfno.Value = "";
        txt_dbffile.Value = "";
        txt_fileext.Text = "";
        txt_esino.Value = "";
        txt_esilocalno.Value = "";
    }

    protected void check1_CheckedChanged(object sender, EventArgs e)
    {
        if (check1.Checked == true)
        {
            if ((ddl_pre_country.SelectedValue == "0") || (ddl_pre_state.SelectedValue == "0") || (ddl_pre_city.SelectedValue == "0"))
            {
                ScriptManager.RegisterClientScriptBlock(Page, Page.GetType(), "", "alert('Please Select Country,State and City in Present Address');", true);
                check1.Checked = false;
            }
            else
            {
                txt_per_add1.Value = txt_pre_add1.Value;
                txt_per_add2.Value = txt_pre_Add2.Value;
                ddl_per_country.SelectedValue = ddl_pre_country.SelectedValue;
                bind_per_state(ddl_per_country.SelectedValue);
                ddl_per_state.SelectedValue = ddl_pre_state.SelectedValue;
                bind_per_city(ddl_per_state.SelectedValue);
                ddl_per_city.SelectedValue = ddl_pre_city.SelectedValue;
                txt_per_zip.Value = txt_pre_zip.Value;
                txt_per_phone.Text = txt_pre_phone.Value;
                txt_per_add1.Disabled = true;
                txt_per_add2.Disabled = true;
                ddl_per_city.Enabled = false;
                ddl_per_state.Enabled = false;
                ddl_per_country.Enabled = false;
                txt_per_zip.Disabled = true;
                txt_per_phone.Enabled = false;
            }
        }
        else
        {
            txt_per_add1.Disabled = false;
            txt_per_add2.Disabled = false;
            ddl_per_city.Enabled = true;
            ddl_per_state.Enabled = true;
            ddl_per_country.Enabled = true;
            txt_per_zip.Disabled = false;
            txt_per_phone.Enabled = true;
            txt_per_add1.Value = "";
            txt_per_add2.Value = "";
            ddl_per_country.SelectedValue = "0";
            ddl_per_state.Items.Clear();
            ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
            ddl_per_city.Items.Clear();
            ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
            txt_per_zip.Value = "";
            txt_per_phone.Text = "";
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
        //bindinformation();
    }
    protected void btn_cncl_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewcompany.aspx");
    }

    //-----------------------for corspondance  address--------------
    protected void ddl_per_country_SelectedIndexChanged(object sender, EventArgs e)
    {


        ddl_per_state.Items.Clear();
        ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_per_city.Items.Clear();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_per_country.SelectedValue != "0")
        {
            bind_per_state(ddl_per_country.SelectedValue);
            ddl_per_state.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    protected void ddl_per_state_SelectedIndexChanged(object sender, EventArgs e)
    {

        ddl_per_city.Items.Clear();
        ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_per_state.SelectedValue != "0")
        {
            bind_per_city(ddl_per_state.SelectedValue);
            ddl_per_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_per_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_per_country.DataTextField = "countryname";
        ddl_per_country.DataValueField = "countryname";
        ddl_per_country.DataSource = ds3;
        ddl_per_country.DataBind();
        ddl_per_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bind_per_state(string country)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + country + "' ";
        DataSet ds4 = new DataSet();
        ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_per_state.DataTextField = "state";
        ddl_per_state.DataValueField = "state";
        ddl_per_state.DataSource = ds4;
        ddl_per_state.DataBind();
    }
    protected void bind_per_city(string state)
    {
        string sqlstr1 = "select ID,state from tbl_intranet_state_master where state='" + state + "' ";
        DataSet ds6 = new DataSet();
        ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
        int stateid = Convert.ToInt32(ds6.Tables[0].Rows[0]["ID"]);
        string sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        DataSet ds5 = new DataSet();
        ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_per_city.DataSource = ds5;
        ddl_per_city.DataTextField = "city";
        ddl_per_city.DataValueField = "city";
        ddl_per_city.DataBind();


    }
    //----------------------------------------------



    //-----------------------for corporate  address--------------
    protected void ddl_pre_country_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_pre_state.Items.Clear();
        ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_pre_city.Items.Clear();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));

        if (ddl_pre_country.SelectedValue != "0")
        {
            bind_pre_state(ddl_pre_country.SelectedValue);
            ddl_pre_state.Items.Insert(0, new ListItem("--Select--", "0"));

        }
    }
    protected void ddl_pre_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_pre_city.Items.Clear();
        ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_pre_state.SelectedValue != "0")
        {
            bind_pre_city(ddl_pre_state.SelectedValue);
            ddl_pre_city.Items.Insert(0, new ListItem("--Select--", "0"));
        }
    }
    protected void bind_pre_country()
    {
        string sqlstr = "select cid,countryname  from tbl_intranet_country_master";
        DataSet ds5 = new DataSet();
        ds5 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_pre_country.DataTextField = "countryname";
        ddl_pre_country.DataValueField = "countryname";
        ddl_pre_country.DataSource = ds5;
        ddl_pre_country.DataBind();
        ddl_pre_country.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void bind_pre_state(string country)
    {

        string sqlstr = "select ID,state from tbl_intranet_state_master where Country='" + country + "' ";
        DataSet ds6 = new DataSet();
        ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_pre_state.DataTextField = "state";
        ddl_pre_state.DataValueField = "state";
        ddl_pre_state.DataSource = ds6;
        ddl_pre_state.DataBind();

    }
    protected void bind_pre_city(string state)
    {
        string sqlstr1 = "select ID,state from tbl_intranet_state_master where state='" + state + "' ";
        DataSet ds6 = new DataSet();
        ds6 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr1);
        int stateid = Convert.ToInt32(ds6.Tables[0].Rows[0]["ID"]);
        string sqlstr = "select cid,stateid,city from tbl_intranet_city where stateid='" + stateid + "'";
        DataSet ds7 = new DataSet();
        ds7 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_pre_city.DataSource = ds7;
        ddl_pre_city.DataTextField = "city";
        ddl_pre_city.DataValueField = "city";
        ddl_pre_city.DataBind();


    }
    //----------------------------------------------


}
