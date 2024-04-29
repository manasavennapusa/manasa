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
    public Bl_Nevigation bl_navigation = new Bl_Nevigation();
    public int i,ptr1,ptr2;
    DataSet ds = new DataSet();
   

    protected void Page_Load(object sender, EventArgs e)
    {

        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }

    }
   
    public void btnsv_Click(object sender, EventArgs e)
    {
        insert_company_detail();     
    }

    protected void insert_company_detail()
    {
        string  file_name;

        if (Page.IsValid)
        {
            if (f_upload_rep1.GotFile)
            {
                file_name = txtcmpname.Text + System.DateTime.Now.GetHashCode().ToString();
                f_upload_rep1.FilePost.SaveAs(Server.MapPath("../upload/logo/" + file_name + "." + f_upload_rep1.FileExt.ToLower()));
                file_name = file_name + "." + f_upload_rep1.FileExt.ToLower();
             
                SqlParameter[] sqlparam = new SqlParameter[34];
                sqlparam[0] = new SqlParameter("@companyname", SqlDbType.VarChar,100);
                sqlparam[0].Value = txtcmpname.Text.Trim().ToString();
                sqlparam[1] = new SqlParameter("@comp_type", SqlDbType.VarChar, 50);
                sqlparam[1].Value = drp_type.SelectedItem.ToString();
                sqlparam[2] = new SqlParameter("@estt_date", SqlDbType.DateTime);
                sqlparam[2].Value =  Utilities.Utility.dataformat(txt_est_date.Text.ToString());
                sqlparam[3] = new SqlParameter("@reg_no", SqlDbType.VarChar, 50);
                sqlparam[3].Value = txtregno.Text;
                sqlparam[4] = new SqlParameter("@pan_no", SqlDbType.VarChar, 50);
                sqlparam[4].Value = txt_pan.Text;
                sqlparam[5] = new SqlParameter("@tin_no", SqlDbType.VarChar, 50);
                sqlparam[5].Value = txttin.Text;
                sqlparam[6] = new SqlParameter("@url", SqlDbType.VarChar, 50);
                sqlparam[6].Value = txtcmpurl.Text;
                sqlparam[7] = new SqlParameter("@logo", SqlDbType.VarChar, 50);
                sqlparam[7].Value = file_name;
                sqlparam[8] = new SqlParameter("@corp_add1", SqlDbType.VarChar, 50);
                sqlparam[8].Value = txt_pre_add1.Text;
                sqlparam[9] = new SqlParameter("@corp_add2", SqlDbType.VarChar, 50);
                sqlparam[9].Value = txt_pre_Add2.Text;
                sqlparam[10] = new SqlParameter("@corp_city", SqlDbType.VarChar, 50);
                sqlparam[10].Value = txt_pre_city.Text;
                sqlparam[11] = new SqlParameter("@corp_state", SqlDbType.VarChar, 50);
                sqlparam[11].Value = txt_pre_state.Text;
                sqlparam[12] = new SqlParameter("@corp_country", SqlDbType.VarChar, 50);
                sqlparam[12].Value = txt_pre_country.Text;
                sqlparam[13] = new SqlParameter("@corp_zip", SqlDbType.VarChar, 50);
                sqlparam[13].Value = txt_pre_zip.Text;
                sqlparam[14] = new SqlParameter("@corp_phone", SqlDbType.VarChar, 50);
                sqlparam[14].Value = txt_pre_phone.Text;
                sqlparam[15] = new SqlParameter("@cors_add1", SqlDbType.VarChar, 50);
                sqlparam[15].Value = txt_per_add1.Text;
                sqlparam[16] = new SqlParameter("@cors_add2", SqlDbType.VarChar, 50);
                sqlparam[16].Value = txt_per_add2.Text;
                sqlparam[17] = new SqlParameter("@cors_city", SqlDbType.VarChar, 50);
                sqlparam[17].Value = txt_per_city.Text;
                sqlparam[18] = new SqlParameter("@cors_state", SqlDbType.VarChar, 50);
                sqlparam[18].Value = txt_per_state.Text;
                sqlparam[19] = new SqlParameter("@cors_country", SqlDbType.VarChar, 50);
                sqlparam[19].Value = txt_per_country.Text;
                sqlparam[20] = new SqlParameter("@cors_zip", SqlDbType.VarChar, 50);
                sqlparam[20].Value = txt_per_zip.Text;
                sqlparam[21] = new SqlParameter("@cors_phone", SqlDbType.VarChar, 50);
                sqlparam[21].Value = txt_per_phone.Text;
                sqlparam[22] = new SqlParameter("@create_by", SqlDbType.VarChar, 50);
                sqlparam[22].Value = Session["name"].ToString();
                sqlparam[23] = new SqlParameter("@updated_by", SqlDbType.VarChar, 50);
                sqlparam[23].Value = Session["name"].ToString();

                sqlparam[24] = new SqlParameter("@tan_no", SqlDbType.VarChar, 50);
                sqlparam[24].Value = txt_tanno.Text.Trim().ToString();
                sqlparam[25] = new SqlParameter("@tds_circle", SqlDbType.VarChar, 50);
                sqlparam[25].Value = txt_tds.Text.Trim().ToString();
                sqlparam[26] = new SqlParameter("@pf_trust", SqlDbType.VarChar, 50);
                sqlparam[26].Value = drp_pftrust.SelectedItem.ToString();

                sqlparam[27] = new SqlParameter("@comp_engaged", SqlDbType.VarChar, 50);
                sqlparam[27].Value = txt_comp_eng.Text.Trim().ToString();
                sqlparam[28] = new SqlParameter("@epf_no", SqlDbType.VarChar, 50);
                sqlparam[28].Value = txt_epfno.Text.Trim().ToString();
                sqlparam[29] = new SqlParameter("@epf_dbf_filecode", SqlDbType.VarChar, 50);
                sqlparam[29].Value = txt_dbffile.Text.Trim().ToString();
                sqlparam[30] = new SqlParameter("@epf_dbf_ext", SqlDbType.VarChar, 50);
                sqlparam[30].Value = txt_fileext.Text.Trim().ToString();
                sqlparam[31] = new SqlParameter("@esi_no", SqlDbType.VarChar, 50);
                sqlparam[31].Value = txt_esino.Text.Trim().ToString();
                sqlparam[32] = new SqlParameter("@esi_local_no", SqlDbType.VarChar, 50);
                sqlparam[32].Value = txt_esilocalno.Text.Trim().ToString();
                sqlparam[33] = new SqlParameter("@resp_person", SqlDbType.VarChar, 100);
                sqlparam[33].Value = txt_resppers.Text.Trim().ToString();

                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_create_company", sqlparam);

                //string str = "<script> alert('Company created sucessfully')</script>";
                //Page.RegisterStartupScript("vv", str.ToString());

                SmartHr.Common.Alert(" Company created successfully.");
               // message.InnerHtml = "";
                reset();
            }
        }
    }

    protected void reset()
    {

        txtcmpname.Text = "";
        drp_type.SelectedValue = "0";
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
        check1.Checked = false;
        txt_tanno.Text = "";
        txt_tds.Text = "";
        drp_pftrust.SelectedValue = "0";

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
        if (check1.Checked == true)
        {
            txt_per_add1.Text = txt_pre_add1.Text;
            txt_per_add2.Text = txt_pre_Add2.Text;
            txt_per_city.Text = txt_pre_city.Text;
            txt_per_state.Text = txt_pre_state.Text;
            txt_per_country.Text = txt_pre_country.Text;
            txt_per_zip.Text = txt_pre_zip.Text;
            txt_per_phone.Text = txt_pre_phone.Text;
            txt_per_add1.Enabled = false;
            txt_per_add2.Enabled = false;
            txt_per_city.Enabled = false;
            txt_per_state.Enabled = false;
            txt_per_country.Enabled = false;
            txt_per_zip.Enabled = false;
            txt_per_phone.Enabled = false;
        }
        else
        {
            txt_per_add1.Enabled = true;
            txt_per_add2.Enabled = true;
            txt_per_city.Enabled = true;
            txt_per_state.Enabled = true;
            txt_per_country.Enabled = true;
            txt_per_zip.Enabled = true;
            txt_per_phone.Enabled = true;
            txt_per_add1.Text = "";
            txt_per_add2.Text = "";
            txt_per_city.Text = "";
            txt_per_state.Text = "";
            txt_per_country.Text = "";
            txt_per_zip.Text = "";
            txt_per_phone.Text = "";
        }
    }
}
