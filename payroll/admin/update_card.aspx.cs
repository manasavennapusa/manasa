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

public partial class payroll_admin_update_card : System.Web.UI.Page
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
        } 
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[4];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = txtempcode.Text.ToString().Trim();

            sqlparam[1] = new SqlParameter("@oldcardno", SqlDbType.VarChar, 500);
            sqlparam[1].Value = txtoldcardno.Text.ToString().Trim();

            sqlparam[2] = new SqlParameter("@cardno", SqlDbType.VarChar, 50);
            sqlparam[2].Value = txtnewcardno.Text.ToString().Trim();

            sqlparam[3] = new SqlParameter("@updatedby", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["empcode"].ToString();


            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "update_card_master", sqlparam);
            message.InnerHtml = " Card information has been updated successfully";
        }
        else Response.Redirect("~/notlogged.aspx");
        //clear();
    }
}
