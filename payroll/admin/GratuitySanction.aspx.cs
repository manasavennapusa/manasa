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
public partial class payroll_admin_perquisite_employee_accommodation : System.Web.UI.Page
{
    DataTable dtable = new DataTable();
    string strsql;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            ViewState["edit"] = "0";
            if (Session["role"] != null)
            {
                
            }
            else Response.Redirect("~/notlogged.aspx");

            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;

            if (month <= 3)
                year = year - 1;

            DateTime mindate = new DateTime(year, 4, 1);
            DateTime maxdate = new DateTime(year + 1, 3, 31);
            Range4from.Type = ValidationDataType.Date;

            Range4from.MaximumValue = maxdate.ToString("MM/dd/yyyy");
            Range4from.MinimumValue = mindate.ToString("MM/dd/yyyy");

            bindgrid();
        }
    }
    protected void clear()
    {
        txt_employee.Text = "";
        txtamount.Text = "0.00";
        txtleasefrom.Text = "";
        btnsubmit.Text = "Submit";
        ViewState["edit"] = "0";
    }
    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void bindgrid()
    {
        strsql = "select id,fyear,empcode,convert(varchar,sanction_date,101) sanction_date,month,amount from TBL_PAYROLL_EMPLOYEE_GRATUITY order by fyear desc,empcode";
      grid.DataSource = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strsql);
      grid.DataBind();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    { 
                            
            SqlParameter[] sqlparam1;
            sqlparam1 = new SqlParameter[7];

            
            sqlparam1[0] = new SqlParameter("@id", SqlDbType.VarChar, 50);
            if (ViewState["edit"].ToString() == "0")
                sqlparam1[0].Value = 0;
            else
                sqlparam1[0].Value = ViewState["edit"].ToString();

            sqlparam1[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
            sqlparam1[1].Value = dd_year.SelectedValue;

            sqlparam1[2] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam1[2].Value = txt_employee.Text.Trim().ToString();

            sqlparam1[3] = new SqlParameter("@sanction_date", SqlDbType.DateTime);
            sqlparam1[3].Value = Utilities.Utility.dataformat(txtleasefrom.Text.ToString());

            sqlparam1[4] = new SqlParameter("@month", SqlDbType.VarChar,50);
            sqlparam1[4].Value = dd_month.SelectedValue;

            sqlparam1[5] = new SqlParameter("@amount", SqlDbType.Decimal);
            sqlparam1[5].Value = Convert.ToDecimal(txtamount.Text);

            sqlparam1[6] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam1[6].Value = Session["name"].ToString();


            try
            {
                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_gratuity", sqlparam1);
                message.InnerHtml = "Gratuity Detail Entered Sucessfully";
            }
            catch (Exception ex)
            {
                message.InnerHtml = "Problem Entering Gratuity Detail";
            }
            finally
            {
                bindgrid();
                clear();
            }
            }



    protected void Button1_Click(object sender, EventArgs e)
    {
        clear();
    }


    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ViewState["edit"]=grid.DataKeys[e.RowIndex].Value;
        dd_year.SelectedValue = ((Label)grid.Rows[e.RowIndex].Cells[0].Controls[1]).Text;
        txt_employee.Text=((Label)grid.Rows[e.RowIndex].Cells[1].Controls[1]).Text;
        txtleasefrom.Text=((Label)grid.Rows[e.RowIndex].Cells[2].Controls[1]).Text;
        dd_month.SelectedValue = ((Label)grid.Rows[e.RowIndex].Cells[3].Controls[1]).Text;
        txtamount.Text=((Label)grid.Rows[e.RowIndex].Cells[4].Controls[1]).Text;
        btnsubmit.Text = "Modify";
    }
    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        strsql = "delete from TBL_PAYROLL_EMPLOYEE_GRATUITY where id=" + grid.DataKeys[e.RowIndex].Value;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, strsql);
        bindgrid();
    }
}
