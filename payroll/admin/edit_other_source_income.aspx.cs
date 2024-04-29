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
public partial class payroll_admin_edit_other_source_income : System.Web.UI.Page
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

            bind_other_source_income();
        }
    }

    protected void bind_other_source_income()
    {
        sqlstr = "SELECT empcode,fyear,incomesourceid,amount,createdby,createddate from tbl_payroll_other_source_income where id=" + Convert.ToInt32(Request.QueryString["id"]);
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txt_employee.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        dd_year.SelectedValue = ds.Tables[0].Rows[0]["fyear"].ToString();
        ddlincomesource.SelectedValue = ds.Tables[0].Rows[0]["incomesourceid"].ToString();
        txtamount.Text = ds.Tables[0].Rows[0]["amount"].ToString();
    }

    protected void bind_year()
    {
        sqlstr = "select distinct year from tbl_payroll_employee_salary";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);
        dd_year.DataTextField = "year";
        dd_year.DataValueField = "year";
        dd_year.DataSource = ds;
        dd_year.DataBind();
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[7];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_employee.Text.ToString().Trim();

        sqlparam[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 12);
        sqlparam[1].Value = dd_year.SelectedItem.Text;

        sqlparam[2] = new SqlParameter("@incomesourceid", SqlDbType.Int);
        sqlparam[2].Value = ddlincomesource.SelectedValue.ToString();

        sqlparam[3] = new SqlParameter("@amount", SqlDbType.Decimal);
        sqlparam[3].Value = txtamount.Text.ToString().Trim();

        sqlparam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
        sqlparam[4].Value = System.DateTime.Now;

        sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 100);
        sqlparam[5].Value = Session["name"].ToString();

        sqlparam[6] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[6].Value = Convert.ToInt32(Request.QueryString["id"]);

        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_other_source_income_update", sqlparam);
        message.InnerHtml = " Other source of income has been updated successfully";
    }
   
    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Years---", "0"));
    }
}
