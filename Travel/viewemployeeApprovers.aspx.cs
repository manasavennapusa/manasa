using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_view_employee_Approvers : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");

            if (Request.QueryString["empcode"] != null)
            {
                bindGrid();
            }
        }
    }

    protected void bindGrid()
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        param[0].Value = Request.QueryString["empcode"].ToString();

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_viewApproveDetails", param);
        empgird.DataSource = ds;
        empgird.DataBind();
    }

    protected void empgird_PreRender(object sender, EventArgs e)
    {
        if (empgird.Rows.Count > 0)
        {
            empgird.UseAccessibleHeader = true;
            empgird.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}