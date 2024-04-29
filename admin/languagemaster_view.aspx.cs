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

public partial class admin_languagemaster_view : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        bind_information();
    }

    protected void bind_information()
    {
             sqlstr = "select id,language from tbl_intranet_language_master" ;
                ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
                if (ds.Tables[0].Rows.Count < 0)
                    return;
                grid_language.DataSource = ds;
                grid_language.DataBind();
    }
}
