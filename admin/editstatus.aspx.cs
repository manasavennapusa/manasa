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
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_status_info();
        }
    }

    protected void bind_status_info()
    {
        string sqlstr = "SELECT id,employeestatus,description FROM tbl_intranet_employee_status WHERE id =" + Request.QueryString["status_id"].ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        txt_status.Text = ds.Tables[0].Rows[0]["employeestatus"].ToString();
        txt_description.Text = ds.Tables[0].Rows[0]["description"].ToString();
    }

    protected void edit_status_info()
    {
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@employeestatus", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_status.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_description.Text;

        sqlparam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[2].Value = Session["name"].ToString();

        sqlparam[3] = new SqlParameter("@status_id", SqlDbType.Int);
        sqlparam[3].Value = Convert.ToInt32(Request.QueryString["status_id"].ToString());

        //ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_status", sqlparam);
        //string str ="<script> alert('Status updated successfully')</script>";
        //Page.RegisterStartupScript("xx", str.ToString());

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_edit_status]", sqlparam);
        if (i < 0)
        {
            SmartHr.Common.Alert("Status is already exist. Try another Status.");
           // message.InnerHtml = "Status is already exist. Try another Status.";
        }
        else
        {
            SmartHr.Common.Alert("Transaction Completed Successfully!!!");
          //  message.InnerHtml = "Status updated successfully";
            reset();

            Response.Redirect("statusview.aspx?updated=true");
        }
    }

    protected void reset()
    {
        txt_status.Text = "";
        txt_description.Text = "";
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {
        edit_status_info();
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("statusview.aspx");
    }
}
