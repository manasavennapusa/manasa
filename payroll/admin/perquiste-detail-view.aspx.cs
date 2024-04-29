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
public partial class payroll_admin_perquiste_detail_view : System.Web.UI.Page
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

    protected void btncreatsection_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam1 = new SqlParameter[3];

        sqlparam1[0] = new SqlParameter("@perquiste_id", SqlDbType.VarChar, 50);
        sqlparam1[0].Value = ddlperquistename.SelectedValue;

        sqlparam1[1] = new SqlParameter("@name", SqlDbType.VarChar, 50);
        sqlparam1[1].Value = txtperquistedetail.Text.Trim().ToString();

        sqlparam1[2] = new SqlParameter("@amount", SqlDbType.VarChar, 50);
        sqlparam1[2].Value = txtamount.Text.Trim().ToString();

        sqlstr = "INSERT INTO tbl_payroll_perquiste_detail(head_id,name,amount) values(@perquiste_id,@name,@amount)";
        int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam1);

        perquistedetailgrid.DataBind();
        message.InnerHtml = "Perquistion Detail has been created successfully !";

        ddlperquistename.SelectedIndex = 0;
        txtperquistedetail.Text = "";
        txtamount.Text = "";
    }
    protected void perquistedetailgrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string strheadid = ((DropDownList)perquistedetailgrid.Rows[e.RowIndex].Cells[0].FindControl("ddlnameg")).SelectedValue;
        string strname = ((TextBox)perquistedetailgrid.Rows[e.RowIndex].Cells[1].FindControl("txtperquistedetailg")).Text;
        string stramount = ((TextBox)perquistedetailgrid.Rows[e.RowIndex].Cells[2].FindControl("txtamountg")).Text;

        SqlDataSource2.UpdateParameters["head_id"].DefaultValue = strheadid;
        SqlDataSource2.UpdateParameters["name"].DefaultValue = strname;
        SqlDataSource2.UpdateParameters["amount"].DefaultValue = stramount;
        SqlDataSource2.Update();
    }
}
