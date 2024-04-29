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
using DataAccessLayer;
using System.Data.SqlClient;
public partial class payroll_admin_canteenmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            
            }
            else
                Response.Redirect("~/notlogged.aspx");
            binddetails();
        }
    }

    protected void binddetails()
    {
        sqlstr = "SELECT breakfastcost,lunchcost FROM tbl_payroll_canteen_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        txtbrkfstcost.Text = ds.Tables[0].Rows[0]["breakfastcost"].ToString();
        txtlunchcost.Text = ds.Tables[0].Rows[0]["lunchcost"].ToString();
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = "UPDATE tbl_payroll_canteen_master SET breakfastcost=" + Convert.ToDecimal(txtbrkfstcost.Text.Trim()) + " , lunchcost=" + Convert.ToDecimal(txtlunchcost.Text.Trim()) + "";
        int upd = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    }
}
