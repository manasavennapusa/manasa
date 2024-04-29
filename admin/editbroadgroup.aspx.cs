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
public partial class admin_editbroadgroup : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                ////if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_broadgroup();
        }
    }

    private void bind_broadgroup()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        string sqlstr = "select id,broadgroup_name from tbl_intranet_broadgroup where id=" + id;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {

            txt_Broadgroup.Value = ds.Tables[0].Rows[0]["broadgroup_name"].ToString();
            //  txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
        catch { }
    }


    public void edit_broadgroupDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@broadgroup_name", SqlDbType.VarChar, 100);
        sqlparam[0].Value = txt_Broadgroup.Value;


        sqlparam[1] = new SqlParameter("@status", SqlDbType.Bit);
        sqlparam[1].Value = true;

        sqlparam[2] = new SqlParameter("@update_by", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["empcode"].ToString();

        sqlparam[3] = new SqlParameter("@update_date", SqlDbType.DateTime);
        sqlparam[3].Value = DateTime.Now;
        sqlparam[4] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[4].Value = id;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[editbroadgroup]", sqlparam);
        if (i <= 0)
        {
            SmartHr.Common.Alert("Business Unit name already exists, please enter another name");
            message.InnerHtml = "Business Unit name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Transaction Completed Successfully!!!");
           // message.InnerHtml = "Business Unit updated successfully";

            reset();

            Response.Redirect("viewbroadgroup.aspx?updated=true");
        }

        //  ds = DBTask.ExecuteDataset();



    }
    protected void reset()
    {
        txt_Broadgroup.Value = "";

    }
    protected void btnsv_Click(object sender, EventArgs e)
    {
        edit_broadgroupDetails();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewbroadgroup.aspx?");
    }
}
