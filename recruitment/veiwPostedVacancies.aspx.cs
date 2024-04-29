using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_veiwPostedVacancies : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    //Response.Redirect("~/Authenticate.aspx");
            }
            else

                Response.Redirect("~/notlogged.aspx");
            bindgrid();
        }
    }
    protected void bindgrid()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_recruitment_get_RRF");
        grdRRF.DataSource = ds;
        grdRRF.DataBind();
    }

}