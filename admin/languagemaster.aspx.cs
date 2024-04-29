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
public partial class admin_languagemaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnlanguage_Click(object sender, EventArgs e)
    {
        addlanguage();
        txtLanguage.Text = "";
    }

    protected void addlanguage()
    {
        SqlParameter[] sqlParam = new SqlParameter[1];

        sqlParam[0] = new SqlParameter("@language", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txtLanguage.Text;


        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_language_master]", sqlParam);
        if (i <= 0)
        {
            message.InnerHtml = "Language already exists, please enter Language name";
        }
        else
        {
            message.InnerHtml = "New Language created successfully";
        }

       
    }
}
