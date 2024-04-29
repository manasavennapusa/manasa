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
public partial class admin_editentity : System.Web.UI.Page
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
            bind_Entity();
        }




    }
    public void bind_Entity()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select id, entity from entity where id= " + id;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        try
        {

            txt_entity_name.Text = ds.Tables[0].Rows[0]["entity"].ToString();
            //  txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        catch { }
    }

    public void edit_EntityDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@entity", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_entity_name.Text;


        sqlparam[1] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam[1].Value = true;

        sqlparam[2] = new SqlParameter("@update_by", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["empcode"].ToString();

        sqlparam[3] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[3].Value = DateTime.Now;

        sqlparam[4] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[4].Value = id;

        //ds = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "editentity", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[editentity]", sqlparam);
        if (i <= 0)
        {
            message.InnerHtml = "Entity name already exists, please enter another name";
        }
        else
        {
            message.InnerHtml = "entity updated successfully";
            reset();

            Response.Redirect("viewentity.aspx?updated=true");
        }



    }
    protected void reset()
    {
        txt_entity_name.Text = "";

    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        edit_EntityDetails();
    }
}
