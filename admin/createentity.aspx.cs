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

public partial class admin_createentity : System.Web.UI.Page
{

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
    protected void btnsv_Click(object sender, EventArgs e)
    {
        insert_entity_detail();
    }
    public void insert_entity_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[6];

        sqlparam[0] = new SqlParameter("@entity", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_entityname.Text;

        sqlparam[1] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam[1].Value = true;

        sqlparam[2] = new SqlParameter("@create_by ", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["empcode"].ToString(); 

        sqlparam[3] = new SqlParameter("@create_date", SqlDbType.DateTime);
        sqlparam[3].Value =DateTime.Now;

        sqlparam[4] = new SqlParameter("@update_by", SqlDbType.VarChar, 50);
        sqlparam[4].Value = System.Data.SqlTypes.SqlString.Null; 

        sqlparam[5] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[5].Value = System.Data.SqlTypes.SqlDateTime.Null;


        int i=DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[insertentity]", sqlparam);

        if (i<=0)
        {
            message.InnerHtml = "Entity name already exists, please enter another name";
        }
        else
            message.InnerHtml = "Entity created successfully";

        reset();
    }
    protected void reset()
    {
        txt_entityname.Text = "";

    }
}
