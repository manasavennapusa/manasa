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
public partial class payroll_admin_perquisite_employee_create : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds;
    DataTable dtable = new DataTable();
    DataView dview;
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");
            Session.Remove("perquisite");
            btnsubmit.Enabled = false;
        }
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }

    protected void ddlperquisitedetail_DataBound(object sender, EventArgs e)
    {
        ddlperquisitedetail.Items.Insert(0, new ListItem("---Select Perquisite details---", "0"));
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
    
    protected void clear()
    {
        txtperquisiteamt.Text = "";
        txtperquisiteamtreceived.Text = "";
        ddlperquisitedetail.SelectedIndex = 0;
    }

    protected void grid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["perquisite"];

        object[] keyArrary = new object[1];
        keyArrary[0] = grid.DataKeys[e.RowIndex][0].ToString();

        DataRow drfind_id = dtable.Rows.Find(keyArrary);
        if (drfind_id != null)
        {
            drfind_id.Delete();
            Session["perquisite"] = dtable;
            bindgrid();
        }
    }

    protected void grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        dtable = (DataTable)Session["perquisite"];

        object[] keyArrary = new object[1];
        keyArrary[0] = grid.DataKeys[e.RowIndex][0].ToString();
       
        DataRow drfind = dtable.Rows.Find(keyArrary);
        if (drfind != null)
        {
            drfind.BeginEdit();
            drfind["amountreceived"] = ((TextBox)grid.Rows[e.RowIndex].FindControl("txtperquisiteamtreceivedg")).Text;
            grid.EditIndex = -1;
            Session["perquisite"] = dtable;
            bindgrid();
        }
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

    protected void btnadd_Click(object sender, EventArgs e)
    {
        DataRow dr;
        if (Session["perquisite"] == null)
        {
            create_perquisite_table();
        }
        dtable = (DataTable)Session["perquisite"];

        object[] keyArrary = new object[1];
        keyArrary[0] = ddlperquisitedetail.SelectedValue;
        
        DataRow drfind = dtable.Rows.Find(keyArrary);
        if (drfind != null)
        {
            message.InnerHtml = "You can not add same peruisite detail.";
        }
        else
        {
            dr = dtable.NewRow();
            dr["perquisitedetail"] = ddlperquisitedetail.SelectedItem.Text;
            dr["perquisitedetail-id"] = ddlperquisitedetail.SelectedValue;

            if (ddlperquisitedetail.SelectedValue=="20")
                dr["amount"] = txtperquisiteamt.Text;
            else
                dr["amount"] = Convert.ToDecimal(txtperquisiteamt.Text) * Convert.ToInt16(DropDownList1.SelectedValue) ;
            dr["amountreceived"] = txtperquisiteamtreceived.Text;
            dtable.Rows.Add(dr);
            clear();
            btnsubmit.Enabled = true;
        }
        
        Session["perquisite"] = dtable;
        bindgrid();
    }

    //----------------------------------------creating table-----------------------------------------
    protected void create_perquisite_table()
    {
        dtable = new DataTable();
        dtable.Columns.Add("perquisitedetail", typeof(string));
        dtable.Columns.Add("perquisitedetail-id", typeof(string));
        dtable.Columns.Add("amount", typeof(string));
        dtable.Columns.Add("amountreceived", typeof(string));
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["perquisitedetail-id"] };
        Session["perquisite"] = dtable;
    }

    //----------------------------------Binding------------------------------------------
    protected void bindgrid()
    {
        if (Session["perquisite"] == null)
        {
            dview = new DataView(null);
        }
        else
        {
            dtable = (DataTable)Session["perquisite"];
            dview = new DataView(dtable);
            dview.Sort = "perquisitedetail";
        }
        grid.DataSource = dview;
        grid.DataBind();
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        if ((Session["perquisite"] != null) && (Session["name"] != null))
        {
            dtable = (DataTable)Session["perquisite"];
            for (int i = 0; i < dtable.Rows.Count; i++)
            {
                SqlParameter[] sqlparam;
                sqlparam = new SqlParameter[6];

                sqlparam[0] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
                sqlparam[0].Value = dd_year.SelectedValue;

                sqlparam[1] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                sqlparam[1].Value = txt_employee.Text.Trim().ToString();

                sqlparam[2] = new SqlParameter("@perqusite_id", SqlDbType.Int);
                sqlparam[2].Value = Convert.ToInt32(dtable.Rows[i]["perquisitedetail-id"].ToString());

                sqlparam[3] = new SqlParameter("@amount", SqlDbType.Decimal);
                sqlparam[3].Value = Convert.ToDecimal(dtable.Rows[i]["amount"]);

                sqlparam[4] = new SqlParameter("@amount_received", SqlDbType.Decimal);
                sqlparam[4].Value = Convert.ToDecimal(dtable.Rows[i]["amountreceived"]);

                sqlparam[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
                sqlparam[5].Value = Session["name"].ToString();

                DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ToString(), CommandType.StoredProcedure, "sp_payroll_employee_perquisite", sqlparam);
            }
            message.InnerHtml = " Perquisite for Employee has been created successfully";
        }
    }
}
