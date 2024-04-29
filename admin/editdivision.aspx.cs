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
            bind_division_information();
        }
    }

    protected void bind_division_information()
    {
        string sqlstr = "SELECT id,division_name, description FROM tbl_intranet_division where id = " + Request.QueryString["departmentid"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {
            txt_branch_name.Text = ds.Tables[0].Rows[0]["division_name"].ToString();
            txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        catch { }
    }


    public void btnsv_Click(object sender, EventArgs e)
    {
        edit_department();
    }

    protected void edit_department()
    {
        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@division_name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_branch_name.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_branch_code.Text;

        sqlparam[2] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[2].Value = Convert.ToInt32(Request.QueryString["departmentid"].ToString());

        // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_interanet_edit_division", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_interanet_edit_division]", sqlparam);


        if (i <= 0)
        {
            message.InnerHtml = "Cost Center  already exists, please enter another Cost Center";
        }
        else
        {
            message.InnerHtml = "Transaction Completed Successfully!!!";

            reset();

            Response.Redirect("divisionview.aspx?updated=true");
        }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("divisionview.aspx");
    }
}
