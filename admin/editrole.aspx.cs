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
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_role();
        }        
    }
   
    public void btnsv_Click(object sender, EventArgs e)
    {
       edit_Role_detail();
    }

    protected void bind_role()
    {
        string sqlstr = "SELECT id,role,description FROM tbl_intranet_role where Id  =" + Request.QueryString["role_id"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        try
        {
            txt_branch_name.Text = ds.Tables[0].Rows[0]["role"].ToString();
            txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        catch { }
    }

    protected void edit_Role_detail()
    {
                SqlParameter[] sqlparam = new SqlParameter[4];

                sqlparam[0] = new SqlParameter("@rolename", SqlDbType.VarChar, 50);
                sqlparam[0].Value = txt_branch_name.Text;

                sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
                sqlparam[1].Value = txt_branch_code.Text;

                sqlparam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                sqlparam[2].Value = Session["name"].ToString();

                sqlparam[3] = new SqlParameter("@role_id", SqlDbType.Int );
                sqlparam[3].Value = Convert.ToInt32(Request.QueryString["role_id"].ToString());

               // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_role", sqlparam);
                int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_edit_role]", sqlparam);


                    if (i <= 0)
                    {
                        message.InnerHtml = "Role  already exists, please enter another Role";
                    }
                    else
                    {
                        message.InnerHtml = "Transaction Completed Successfully!!!";

                        reset();

                        Response.Redirect("roleview.aspx?updated=true");
                    }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("roleview.aspx");
    }
}
