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

public partial class Admin_company_createcompany : System.Web.UI.Page
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
                //    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void insert_employee_status()
    {
        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@employeestatus", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_status.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_description.Text;

        sqlparam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["name"].ToString();

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_status", sqlparam);
        //string str = "<script> alert(' Status inserted successfully')</script>";
        //Page.RegisterStartupScript("xx", str.ToString());

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_status]", sqlparam);
        if (i < 0)
        {
            SmartHr.Common.Alert(" Status is already exist. Try another Status.");
           // message.InnerHtml = "Status is already exist. Try another Status.";
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
            //message.InnerHtml = "Status inserted successfully";

            reset();
        }
    }

    protected void reset()
    {
        txt_status.Text = "";
        txt_description.Text = "";
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {
        insert_employee_status();
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
}
