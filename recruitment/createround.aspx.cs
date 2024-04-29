using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class createround : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");
            bindGrid();

            if (Request.QueryString["id"] != null)
            {
                bindinfomation();
                btnadd.Text = "Update";
                btnclear.Text = "Cancel";
                lblheader.Text = "EDIT ROUND";
            }
            else
            {
                btnadd.Text = "Add";
                btnclear.Text = "Clear";
                lblheader.Text = "CREATE ROUND";
            }
        }

       

        if (Request.QueryString["updated"] != null)
        {
            message.InnerHtml = "Round Name is Updated Successfully.";
        }

    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_recruitment_round_master";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdrounds.DataSource = ds;
        grdrounds.DataBind();

    }




    protected void btnadd_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null)
        {
            update_Round();
        }
        else
        {
            insert_Round();
        }
        bindGrid();
    }
    protected void btnclear_Click(object sender, EventArgs e)
    {
        cleartext();

        if (Request.QueryString["id"] != null)
        {
            Response.Redirect("createround.aspx");
        }


    }

    protected void insert_Round()
    {
        SqlParameter[] sqlParam = new SqlParameter[7];

        sqlParam[0] = new SqlParameter("@round_name", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txt_roundname.Text;

        sqlParam[1] = new SqlParameter("@category", SqlDbType.VarChar, 50);
        sqlParam[1].Value = ddl_category.SelectedValue;

        sqlParam[2] = new SqlParameter("@category_type", SqlDbType.VarChar, 50);
        sqlParam[2].Value = ddl_cat_type.SelectedValue;

        sqlParam[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = Session["empcode"].ToString();

        sqlParam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlParam[4].Value = DateTime.Now;

        sqlParam[5] = new SqlParameter("@status", SqlDbType.TinyInt);
        sqlParam[5].Value = 1;

        sqlParam[6] = new SqlParameter("@flag", SqlDbType.TinyInt);
        sqlParam[6].Value = 1;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_insert_round]", sqlParam);
        if (i < 0)
        {
            message.InnerHtml = "Subject Name is already exists try another name.";
        }
        else
        {
            message.InnerHtml = "Subject Name is insert Successfully.";
            cleartext();
        }
    }

    protected void update_Round()
    {
        SqlParameter[] sqlParam = new SqlParameter[4];

        sqlParam[0] = new SqlParameter("@round_name", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txt_roundname.Text;

        sqlParam[1] = new SqlParameter("@category", SqlDbType.VarChar, 50);
        sqlParam[1].Value = ddl_category.SelectedValue;

        sqlParam[2] = new SqlParameter("@category_type", SqlDbType.VarChar, 50);
        sqlParam[2].Value = ddl_cat_type.SelectedValue;

        sqlParam[3] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[3].Value = Convert.ToInt32(Request.QueryString["id"]);



        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_recruitment_update_round]", sqlParam);
        if (i < 0)
        {
            message.InnerHtml = "Subject Name is already exists try another name.";
        }
        else
        {
            //message.InnerHtml = "Skill Name is Updated Successfully.";
            Response.Redirect("createround.aspx?updated=true");
            cleartext();
        }
    }

    protected void bindinfomation()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        string sqlstr = "select * from tbl_recruitment_round_master where id='" + id + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_roundname.Text = ds.Tables[0].Rows[0]["round_name"].ToString();
        ddl_category.SelectedValue = ds.Tables[0].Rows[0]["category"].ToString();
        ddl_cat_type.SelectedValue = ds.Tables[0].Rows[0]["category_type"].ToString();
    }

    private void cleartext()
    {
        txt_roundname.Text = "";
        ddl_category.SelectedValue = "0";
        ddl_cat_type.SelectedValue = "0";
    }

}