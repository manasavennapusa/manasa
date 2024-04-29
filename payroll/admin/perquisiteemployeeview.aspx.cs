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
public partial class payroll_admin_perquisiteemployeeview : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");
            bindgrid();
        }
    }
    
    protected void bindgrid()
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[2];

        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = Request.QueryString["empcode"].ToString();

        sqlparam[1] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[1].Value = Request.QueryString["fyear"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetconnectionString"].ToString(), CommandType.StoredProcedure, "[sp_payroll_employee_perquisite_select]",sqlparam);

        grid.DataSource = ds;
        grid.DataBind();
        if (ds.Tables[0].Rows.Count > 0)
        {
            lblempcode.Text = Convert.ToString(ds.Tables[0].Rows[0]["empcode"]);
            lblempname.Text = Convert.ToString(ds.Tables[0].Rows[0]["empname"]);
            lblfyear.Text = Convert.ToString(ds.Tables[0].Rows[0]["fyear"]);
        }
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int code = (int)grid.DataKeys[e.RowIndex].Value;
        sqlstr = "DELETE FROM tbl_payroll_employee_perquisite WHERE id=" + code;
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        bindgrid();
    }

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //TextBox txtName = (TextBox)grid.Rows[e.RowIndex].FindControl("txtperquisiteamtreceivedg");
        // decimal perquisiteamtreceived = Convert.ToDecimal(((TextBox)grid.Rows[e.RowIndex].Cells[3].FindControl("txtperquisiteamtreceivedg")).Text);
        decimal perquisiteamtreceived = Convert.ToDecimal(((TextBox)grid.Rows[e.RowIndex].FindControl("txtperquisiteamtreceivedg")).Text);
        decimal perquisit = Convert.ToDecimal(((TextBox)grid.Rows[e.RowIndex].FindControl("txtperquisiteamt")).Text);

        int code = (int)grid.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_payroll_employee_perquisite SET amount=" + perquisit + ",amount_received=" + perquisiteamtreceived + " WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grid.EditIndex = -1;
        bindgrid();
    }

    protected void grid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        grid.EditIndex = e.NewEditIndex;
        bindgrid();
    }

    protected void grid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        grid.EditIndex = -1;
        bindgrid();
    }

    protected void clear()
    {
        txtperquisiteamt.Text = "";
        txtperquisiteamtreceived.Text = "";
        ddlperquisitedetail.SelectedIndex = 0;
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        if (Session["name"] != null)
        {
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[6];

            sqlparam[0] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
            sqlparam[0].Value = lblfyear.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[1].Value = lblempcode.Text.Trim().ToString();

            sqlparam[2] = new SqlParameter("@perqusite_id", SqlDbType.Int);
            sqlparam[2].Value = Convert.ToInt32(ddlperquisitedetail.SelectedValue);

            sqlparam[3] = new SqlParameter("@amount", SqlDbType.Decimal);
            
            if (ddlperquisitedetail.SelectedValue == "20")
                sqlparam[3].Value = Convert.ToDecimal(txtperquisiteamt.Text.Trim());
            else
                sqlparam[3].Value = Convert.ToDecimal(txtperquisiteamt.Text) * Convert.ToInt16(DropDownList1.SelectedValue);

           
            

            sqlparam[4] = new SqlParameter("@amount_received", SqlDbType.Decimal);
            sqlparam[4].Value = Convert.ToDecimal(txtperquisiteamtreceived.Text.Trim());

            sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam[5].Value = Session["name"].ToString();

            DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite", sqlparam);
            message.InnerHtml = " Perquisite for Employee has been created successfully";
            clear();
            bindgrid();
        }
        else
            Response.Redirect("~/notlogged.aspx");
    }

    protected void ddlperquisitedetail_SelectedIndexChanged(object sender, EventArgs e)
    {
        sqlstr = "SELECT amount FROM tbl_payroll_perquiste_detail WHERE id=" + ddlperquisitedetail.SelectedValue + "";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.Text, sqlstr);

        if (ddlperquisitedetail.SelectedValue == "20")
        {
            txtperquisiteamt.Text = Convert.ToString(Convert.ToDecimal(ds.Tables[0].Rows[0]["amount"]) * (decimal)0.1);
            month.Visible = false;

        }
        else
        {
            txtperquisiteamt.Text = ds.Tables[0].Rows[0]["amount"].ToString();
            month.Visible = true;
        }
        txtperquisiteamtreceived.Text = "0.00";

    }

    protected void ddlperquisitedetail_DataBound(object sender, EventArgs e)
    {
        ddlperquisitedetail.Items.Insert(0, new ListItem("---Select Perquisite details---", "0"));
    }
}