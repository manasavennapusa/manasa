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
public partial class payroll_admin_other_source_income : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
           
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txtothrsrcinc.Text.Trim().ToString();
        string qry = "select incomesource from tbl_payroll_income_source_master where incomesource=@name";
        string res = (string)DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, qry, sqlparam);
        if (res == null)
        {
            sqlstr = "INSERT INTO tbl_payroll_income_source_master(incomesource) values(@name)";
            int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr, sqlparam);

            //ddlperquistename.DataBind();
            othrsrcincgird.DataBind();
            txtothrsrcinc.Text = "";
            message.InnerHtml = "Other Source Income has been added successfully";
        }
        else
        {
            message.InnerHtml = "Same Income Source is Already Created";
        }
    }

    protected void othrsrcincgird_RowUpdating(object sender, GridViewUpdateEventArgs e)
     {
        int id = (int)othrsrcincgird.DataKeys[e.RowIndex].Value;

        string strname = ((TextBox)othrsrcincgird.Rows[e.RowIndex].Cells[0].FindControl("txtothrsrcincg")).Text;

        SqlParameter[] sqlparam = new SqlParameter[2];

        if (strname != "")
        {
            sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            sqlparam[0].Value = strname.Trim().ToString();

            sqlparam[1] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[1].Value = id;


            //sqlstr = "update tbl_payroll_income_source_master set incomesource=@name where id=@id and incomesource !=(select incomesource from tbl_payroll_income_source_master where incomesource=@name)";
            int ins = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_update_icomesource", sqlparam);
            if (ins > 0)
            {

                 Response.Redirect("other-source-income.aspx");
            }
            else
            {
                e.Cancel = true;
                message.InnerHtml = "Same Income Source is Already Present";
                //Response.Redirect("other-source-income.aspx");
            }
            //ddlperquistename.DataBind();
            //othrsrcincgird.EditIndex = -1;
            //othrsrcincgird.DataSourceID = "SqlDataSource1";

            //    othrsrcincgird.DataBind();
            //txtothrsrcinc.Text = "";
            //message.InnerHtml = "Other Source Income has been added successfully !";

        }
        else
        {
            e.Cancel = true;
            message.InnerHtml = "Please enter Other source income";
        }
    }
}