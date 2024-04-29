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
                ////if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                //   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    public void btnsv_Click(object sender, EventArgs e)
    {
        insert_department_detail();
    }

    protected void insert_department_detail()
    {
        SqlParameter[] sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@division_name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_branch_name.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_branch_code.Text;

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_interanet_insert_division", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_interanet_insert_division]", sqlparam);


        if (i <= 0)
        {
            SmartHr.Common.Alert("Cost Center  already exists, please enter another Cost Center.");
           // message.InnerHtml = "Cost Center  already exists, please enter another Cost Center";
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
           // message.InnerHtml = "Cost Center created successfully";

            reset();
        }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        reset();
    }
}
