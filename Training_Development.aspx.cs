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

public partial class Training_Development : System.Web.UI.Page
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
            else Response.Redirect("~@otlogged.aspx");
        }
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@Title", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_title.Text.ToString().Trim();

        sqlparam[1] = new SqlParameter("@Description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_description.Text.ToString().Trim();

        sqlparam[2] = new SqlParameter("@Trainer", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_trainer.Text.ToString().Trim();


        //sqlparam[3] = new SqlParameter("@createddate", SqlDbType.DateTime);
        //sqlparam[3].Value = System.DateTime.Now;

        //sqlparam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        //sqlparam[4].Value = Session["name"].ToString();

      



        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "SpInsertTrainingDevelopment", sqlparam);
        if (i <= 0)
        {
            SmartHr.Common.Alert(" Training information already exists.");

        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
            clear();
        }
    }
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();

    }
    protected void clear()
    {
        //txt_accno.Text = "";
        txt_title.Text = "";
        txt_description.Text = "";
        txt_trainer.Text = "";
     
    }
}