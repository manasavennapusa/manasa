using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class updatetrainingdevelopment : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {

            }
            else Response.Redirect("~/notlogged.aspx");

            binddata();
        }
    }
    protected void binddata()
    {
        sqlstr = "SELECT * FROM TblTrainingDevelopment WHERE id='" + Request.QueryString["id"].ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        //txt_accno.Text = ds.Tables[0].Rows[0]["accountnumber"].ToString();
        txt_title.Text = ds.Tables[0].Rows[0]["Title"].ToString();
        txt_description.Text = ds.Tables[0].Rows[0]["Description"].ToString();
        txt_trainer.Text = ds.Tables[0].Rows[0]["Trainer"].ToString();

        //if (Convert.ToBoolean(ds.Tables[0].Rows[0]["tds"]) == true)
        //{
        //    chktds.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["tds"]);
        //    bsrcode.Visible = true;
        //    txtbsrcode.Text = ds.Tables[0].Rows[0]["bsrcode"].ToString();
        //}
        //else
        //{
        //    chktds.Checked = Convert.ToBoolean(ds.Tables[0].Rows[0]["tds"]);
        //    bsrcode.Visible = false;
        //    txtbsrcode.Text = ds.Tables[0].Rows[0]["bsrcode"].ToString();
        //}

    }


    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_title.Text.Trim().ToString();

        sqlparam[1] = new SqlParameter("@Description", SqlDbType.VarChar, 1000);
        sqlparam[1].Value = txt_description.Text.Trim().ToString();

        sqlparam[2] = new SqlParameter("@Trainer", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_trainer.Text.Trim().ToString();



       

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SpUpdateTrainingDevelopment", sqlparam);

        if (i < 0)
        {
            SmartHr.Common.Alert(" Training information already exists.");

        }
        else
        {
            Response.Redirect("viewtrainingdevelopment.aspx?message=Updated Successfully");
        }

    }

    protected void clear()
    {
        txt_title.Text = "";
        txt_description.Text = "";
        txt_trainer.Text = "";
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("viewtrainingdevelopment.aspx");
    }
 
}