using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Data;
using System;
using System.Configuration;

public partial class training_trainingtypemaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["empcode"] != null)
            {

            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }

        }

    }
   

    protected void insert_trainingtypemaster()
    {
        SqlParameter[] sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@training_type_id", SqlDbType.VarChar, 10);
        sqlparam[0].Value = txt_trainingid.Value;

        sqlparam[1] = new SqlParameter("@training_name", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_training_name.Value;

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_interanet_insert_division", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_training_master]", sqlparam);


        if (i <= 0)
        {
            Common.Console.Output.Show("Training Type Code already exists, please enter another training type code");
            //message.InnerHtml = "Training Type Code already exists, please enter another training type code";
        }
        else
        {
            Common.Console.Output.Show("Training Type created successfully");
            //message.InnerHtml = "Training Type created successfully";
          
        }

    }
  
    protected void btn_save_Click(object sender, EventArgs e)
    {
        insert_trainingtypemaster();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        txt_trainingid.Value = "";
        txt_training_name.Value = "";

    }
    protected void btn_back_Click(object sender, EventArgs e)
    {

    }
}