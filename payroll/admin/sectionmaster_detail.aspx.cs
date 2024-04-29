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
public partial class payroll_admin_sectionmaster_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3" && Session["role"].ToString() != "4")
                Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        sqlstr = "INSERT INTO tbl_payroll_sectionmaster(sname,description) values('" + txtsectionname.Text.Trim().ToString().Replace("'", "''") + "','" + txtsectdescription.Text.Trim().ToString().Replace("'", "''") + "')";
        int ins=DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text,sqlstr);

        ddlsectionname.DataBind();
        sectiongird.DataBind();
        message.InnerHtml = "Section has been created successfully !";
    }
    protected void btncreatsection_Click(object sender, EventArgs e)
    {
        sqlstr = "INSERT INTO tbl_payroll_sectiondetail(section_name,description,section_detail) values('" + ddlsectionname.SelectedValue.ToString() + "','" + txtsecdetaildesc.Text.Trim().ToString().Replace("'", "''") + "','" + txtsectiondetail.Text.Trim().ToString().Replace("'", "''") + "')";
        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);

        sectiondetailgrid.DataBind();
        message.InnerHtml = "Section Detail has been created successfully !";
    }
}
