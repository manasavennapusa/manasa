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

public partial class admin_editcostcentergroup : System.Web.UI.Page
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
            bind_costcentergroup();
        }




    }
    public void bind_costcentergroup()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        //string id = Session["empcode"].ToString();
        string sqlstr = "select id,cost_center_group_name from tbl_intranet_cost_center_group where id= " + id;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {

            txt_Cost_Center_Group.Text = ds.Tables[0].Rows[0]["cost_center_group_name"].ToString();
            //  txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        catch { }
    }

    public void edit_costcentergroup()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@cost_center_group_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_Cost_Center_Group.Text;


        sqlparam[1] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam[1].Value = true;

        sqlparam[2] = new SqlParameter("@update_by", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["empcode"].ToString();

        sqlparam[3] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[3].Value = DateTime.Now;
        sqlparam[4] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[4].Value = id;



        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[editcostcentergroup]", sqlparam);


        if (i <= 0)
        {
            message.InnerHtml = "cost center group Name already exists, please enter another name";
        }
        else
        {
            message.InnerHtml = "cost center group  updated successfully";

            reset();

            Response.Redirect("viewcostcentergroup.aspx?updated=true");

        }

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[editcostcentergroup]", sqlparam);



    }
    protected void reset()
    {
        txt_Cost_Center_Group.Text = "";

    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        edit_costcentergroup();
    }
}
