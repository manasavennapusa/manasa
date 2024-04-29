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
        message.InnerHtml = "";
        if (Request.QueryString["updated"] != null)
            Common.Console.Output.Show("Updated Successfully");

        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bindinformationaion();
        }
    }
   
    public void btnsv_Click(object sender, EventArgs e)
    {
        Response.Redirect("editcompany.aspx");
    }

    protected void bindinformationaion()
    {
        string sqlstr = "select companyname,comp_type,(CASE WHEN estt_date='01/01/1990' THEN '' ELSE CONVERT(CHAR(10), estt_date, 101) END)estt_date,pan_no,tin_no,reg_no,tan_no,tds_circle,pf_trust,url,logo,corp_add1,corp_add2,corp_city,corp_state,corp_country,corp_zip,corp_phone,cors_add1,cors_add2,cors_city,cors_state,cors_country,cors_zip,cors_phone,comp_engaged,epf_no,epf_dbf_filecode,epf_dbf_ext,esi_no,esi_local_no,resp_person from tbl_intranet_companydetails";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        try
        {
            txtcmpname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();
            drp_type.Text = ds.Tables[0].Rows[0]["comp_type"].ToString();
            txt_est_date.Text = ds.Tables[0].Rows[0]["estt_date"].ToString();
            txtregno.Text = ds.Tables[0].Rows[0]["reg_no"].ToString();
            txt_pan.Text = ds.Tables[0].Rows[0]["pan_no"].ToString();
            txttin.Text = ds.Tables[0].Rows[0]["tin_no"].ToString();
            txtcmpurl.Text = ds.Tables[0].Rows[0]["url"].ToString();

            txt_pre_add1.Text = ds.Tables[0].Rows[0]["corp_add1"].ToString();
            txt_pre_Add2.Text = ds.Tables[0].Rows[0]["corp_add2"].ToString();
            txt_pre_city.Text = ds.Tables[0].Rows[0]["corp_city"].ToString();
            txt_pre_state.Text = ds.Tables[0].Rows[0]["corp_state"].ToString();
            txt_pre_country.Text = ds.Tables[0].Rows[0]["corp_country"].ToString();
            txt_pre_zip.Text = ds.Tables[0].Rows[0]["corp_zip"].ToString();
            txt_pre_phone.Text = ds.Tables[0].Rows[0]["corp_phone"].ToString();
            txt_per_add1.Text = ds.Tables[0].Rows[0]["cors_add1"].ToString();
            txt_per_add2.Text = ds.Tables[0].Rows[0]["cors_add2"].ToString();
            if (ds.Tables[0].Rows[0]["cors_city"].ToString() == "0")
            {
                txt_per_city.Text = "";
            }
            else
            {
                txt_per_city.Text = ds.Tables[0].Rows[0]["cors_city"].ToString();
            }
            if (ds.Tables[0].Rows[0]["cors_state"].ToString() == "0")
            {
                txt_per_state.Text = "";
            }
            else
            {
                txt_per_state.Text = ds.Tables[0].Rows[0]["cors_state"].ToString();
            }
            if (ds.Tables[0].Rows[0]["cors_country"].ToString() == "0")
            {
                txt_per_country.Text = "";
            }
            else
            {
                txt_per_country.Text = ds.Tables[0].Rows[0]["cors_country"].ToString();
            }
            txt_per_zip.Text = ds.Tables[0].Rows[0]["cors_zip"].ToString();
            txt_per_phone.Text = ds.Tables[0].Rows[0]["cors_phone"].ToString();

            txt_tanno.Text = ds.Tables[0].Rows[0]["tan_no"].ToString();
            txt_tds.Text = ds.Tables[0].Rows[0]["tds_circle"].ToString();
            drp_pftrust.Text = ds.Tables[0].Rows[0]["pf_trust"].ToString();

            txt_comp_eng.Text = ds.Tables[0].Rows[0]["comp_engaged"].ToString();
            txt_resppers.Text = ds.Tables[0].Rows[0]["resp_person"].ToString();
            txt_epfno.Text = ds.Tables[0].Rows[0]["epf_no"].ToString();
            txt_dbffile.Text = ds.Tables[0].Rows[0]["epf_dbf_filecode"].ToString();
            txt_fileext.Text = ds.Tables[0].Rows[0]["epf_dbf_ext"].ToString();
            txt_esino.Text = ds.Tables[0].Rows[0]["esi_no"].ToString();
            txt_esilocalno.Text = ds.Tables[0].Rows[0]["esi_local_no"].ToString();            
        }
        catch { 
    }

        btnsv.Text = "Edit";
    }  

    protected void reset()
    {
        txtcmpname.Text = "";
        drp_type.Text = "";
        txt_est_date.Text = "";
        txtregno.Text = "";
        txt_pan.Text ="";
        txttin.Text = "";
        txtcmpurl.Text = "";
        txt_pre_add1.Text = "";
        txt_pre_Add2.Text = "";
        txt_pre_city.Text ="";
        txt_pre_state.Text ="";
        txt_pre_country.Text = "";
        txt_pre_zip.Text = "";
        txt_pre_phone.Text = "";
        txt_per_add1.Text = "";
        txt_per_add2.Text = "";
        txt_per_city.Text = "";
        txt_per_state.Text = "";
        txt_per_country.Text = "";
        txt_per_zip.Text = "";
        txt_per_phone.Text = "";
        txt_tanno.Text = "";
        txt_tds.Text = "";
        drp_pftrust.Text = "";

        txt_comp_eng.Text = "";
        txt_resppers.Text = "";
        txt_epfno.Text = "";
        txt_dbffile.Text = "";
        txt_fileext.Text = "";
        txt_esino.Text = "";
        txt_esilocalno.Text = "";  
    }
    protected void check1_CheckedChanged(object sender, EventArgs e)
    {

    }
}
