using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_RejectedExpenseForms : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindGrid();
            if (Request.QueryString["approved"] != null)
            {
                SmartHr.Common.Alert("Travel Form Approved successfully");
            }
            if (Request.QueryString["rejected"] != null)
            {
                SmartHr.Common.Alert("Travel Form Rejected successfully");
            }
            if (Request.QueryString["submit"] != null)
            {
                SmartHr.Common.Alert("Expense Details Submitted Successfully");
            }
        }
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Session["empcode"].ToString();

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_getRejectedTravelExpanse", param);
        grid_Travel.DataSource = ds;
        grid_Travel.DataBind();
    }
}