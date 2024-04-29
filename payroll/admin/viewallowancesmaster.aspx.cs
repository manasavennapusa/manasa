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
public partial class payroll_admin_viewallowancesmaster : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
           
        }
        else
            Response.Redirect("~/notlogged.aspx");
        bindpayhead();
        bindgrade();
    }
    protected void bindpayhead()
    {
        sqlstr = "SELECT payhead_name,alias_name,(CASE WHEN payhead_type=0 THEN 'Earnings' WHEN payhead_type=1 THEN 'Deductions' ELSE 'N/A' END)payhead_type, appear_inpayslip, name_inpayslip, use_ingratuity,taxrebate  FROM tbl_payroll_payhead WHERE id=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if ((int)ds.Tables[0].Rows.Count < 0)
        {

        }
        else
        {
            lbl_name.Text = ds.Tables[0].Rows[0]["payhead_name"].ToString();
            lbl_alias.Text = ds.Tables[0].Rows[0]["alias_name"].ToString();
            lbl_payheadtype.Text = ds.Tables[0].Rows[0]["payhead_type"].ToString();

            if (Convert.ToInt32(ds.Tables[0].Rows[0]["appear_inpayslip"]) == 0)
            {
                lbl_appear.Text = "No";
            }
            else
            {
                lbl_appear.Text = "Yes";
            }
            lbl_nameinpay.Text = ds.Tables[0].Rows[0]["name_inpayslip"].ToString();
            lbl_taxrebate.Text = ds.Tables[0].Rows[0]["taxrebate"].ToString();
        }
    }

    protected void bindgrade()
    {
        sqlstr = @"select g.gradename from tbl_payroll_payhead_grade p 
                    INNER JOIN tbl_intranet_grade g 
                    ON p.grade=g.id where p.payheadid=" + Request.QueryString["id"].ToString() + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grade.DataSource = ds;
        grade.DataBind();
    }
}