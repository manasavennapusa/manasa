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
public partial class payroll_admin_perquiste_master_detail : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txtperquistename.Text.Trim().ToString();

        sqlstr = "INSERT INTO tbl_payroll_perquisite_head(name) values(@name)";
        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text,sqlstr,sqlparam);

        //ddlperquistename.DataBind(); 
        perquistegird.DataBind();
        txtperquistename.Text = "";
        message.InnerHtml = "Perquisition has been created successfully !";
    }

    protected void perquistegird_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
            string strname = ((TextBox)perquistegird.Rows[e.RowIndex].Cells[0].FindControl("txtperquistenameg")).Text;
            SqlDataSource1.UpdateParameters["name"].DefaultValue= strname;            
            SqlDataSource1.Update();
    }
}