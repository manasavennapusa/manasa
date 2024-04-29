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

public partial class admin_Defaultlable : System.Web.UI.Page
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

            bind_Citydetails();
            if (Request.QueryString["id"] != null)
            {
                bind_city();
            }
        }
        if (Request.QueryString["id"] != null)
        {
            btncity.Text = "Update";
            trlbl.Visible = true;
            trbtn.Visible = true;
            lblhead.Text = "Edit Lable ";
        }
        else
        {
            trlbl.Visible = false;
            trbtn.Visible = false;
            btncity.Text = "Add";

            lblhead.Text = "View Lable ";
        }
        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "lable updated successfully";
        }
    }





    protected void btncity_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            edit_CityDetails();
        }
        else
        {
            insert_city_detail();
            bind_Citydetails();
        }
    }
    protected void insert_city_detail()
    {

        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@lblname", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_label.Text;




        string sqlstr = @"insert into staticlabel(lablename) values( @lblname) ";
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr );


        //if (i <= 0)
        //{
        //    message.InnerHtml = "lable name already exists, please enter another name";
        //}
        //else
        //{
        message.InnerHtml = "lable created successfully";
        reset();

        //}
    }

    protected void reset()
    {
        txt_label.Text = "";

    }

    private void bind_city()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());
        string sqlstr = "select id,labelname from staticlabel where slno= " + id;
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        try
        {
            txt_label.Text = ds.Tables[0].Rows[0]["labelname"].ToString();


        }
        catch { }
    }


    public void edit_CityDetails()
    {
        int id = Convert.ToInt32(Request.QueryString["id"].ToString());

        SqlParameter[] sqlParam = new SqlParameter[2];

        sqlParam[0] = new SqlParameter("@labelName", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txt_label.Text;

        sqlParam[1] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[1].Value = id;

        //sqlParam[2] = new SqlParameter("@cid", SqlDbType.Int);
        //sqlParam[2].Value = id;
        //DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_city]", sqlParam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "UpdateLabel", sqlParam);



        reset();

        Response.Redirect("Defaultlable.aspx?updated=true");


    }


    private void bind_Citydetails()
    {
        string sqlstr = "select id,labelname from staticlabel";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        int id = Convert.ToInt16(ds.Tables[0].Rows[0]["id"].ToString());
        Session["city_id"] = id.ToString();
        grdcity.DataSource = ds;
        grdcity.DataBind();
    }




}