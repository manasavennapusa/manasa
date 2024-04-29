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
using System.Data.SqlClient;
using DataAccessLayer;

public partial class admin_langugemaster_edit : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind_information();
        }
    }
    protected void btnlanguage_Click(object sender, EventArgs e)
    {
        addlanguage();
        txtLanguage.Text = "";
        Response.Redirect("languagemaster_view.aspx");
    }

    protected void addlanguage()
    {
        SqlParameter[] sqlParam = new SqlParameter[2];
        sqlParam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[0].Value = Convert.ToInt32(Request.QueryString["id"]);

        sqlParam[1] = new SqlParameter("@language", SqlDbType.VarChar, 50);
        sqlParam[1].Value = txtLanguage.Text;

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_language_master]", sqlParam);


    }

    protected void bind_information()
    {
        if (Request.QueryString["id"] != null)
        {
            string sqlstr = @"select id,language from tbl_intranet_language_master  where id =" + Request.QueryString["id"].ToString();

            try
            {
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

                txtLanguage.Text = ds.Tables[0].Rows[0]["language"].ToString();
            }
            catch { }
        }
    }


}
