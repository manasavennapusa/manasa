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
using Utilities;
public partial class payroll_admin_update_dutyroaster : System.Web.UI.Page
{
    DataSet ds = new DataSet(); 
  
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
              
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btnsv_Click(object sender, EventArgs e)
    {        
            SqlParameter[] sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@branch", SqlDbType.Int);
            sqlparam[0].Value = drp_comp_name.SelectedValue;

            sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam[1].Value = Session["empcode"].ToString();

            sqlparam[2] = new SqlParameter("@empcodei", SqlDbType.VarChar, 50);
            sqlparam[2].Value = txt_employee.Text.Trim().ToString();

            sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

            sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
            sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();

            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_update_dutyroaster_holiday]", sqlparam);

            message.InnerHtml = "Duty Roaster for Holiday has been successfully updated.";
    }

    protected void drp_comp_name_DataBound(object sender, EventArgs e)
    {
        drp_comp_name.Items.Insert(0, new ListItem("--Select branch--", "0"));
    }

    protected void btnweekoff_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@branch", SqlDbType.Int);
        sqlparam[0].Value = drp_comp_name.SelectedValue;

        sqlparam[1] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Session["empcode"].ToString();

        sqlparam[2] = new SqlParameter("@empcodei", SqlDbType.VarChar, 50);
        sqlparam[2].Value = txt_employee.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlparam[3].Value = Utility.dataformat(txt_sdate.Text.ToString()).ToShortDateString();

        sqlparam[4] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlparam[4].Value = Utility.dataformat(txt_edate.Text.ToString()).ToShortDateString();


        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_update_dutyroaster_weekoff]", sqlparam);

        message.InnerHtml = "Duty Roaster for Weekoff has been successfully updated.";
    }
}
