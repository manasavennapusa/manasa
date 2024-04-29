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

public partial class payroll_admin_view_bonus_master : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            
        }
        else Response.Redirect("~/notlogged.aspx");

        bindpayhead();        
    }
    protected void bindpayhead()
    {
        sqlstr = @"SELECT payhead_name,alias_name,(CASE WHEN payhead_type=0 THEN 'Earnings' WHEN payhead_type=1 THEN 'Deductions' ELSE 'N/A' END)payhead_type,name_inpayslip FROM tbl_payroll_bonus where id =" + Request.QueryString["id"].ToString() + "";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if ((int)ds.Tables[0].Rows.Count < 0)
        {

        }
        else
        {
            lbl_name.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();
            lbl_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
            lbl_payheadtype.Text = ds.Tables[0].Rows[0]["payhead_type"].ToString();
            lbl_nameinpay.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
        }
    }
}
