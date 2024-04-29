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
public partial class payroll_admin_reimbursementautocreate : System.Web.UI.Page
{
    string sqlstr;
    int msg;
    DataSet ds=new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
               
            }
            else Response.Redirect("~/notlogged.aspx");
        }
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        clear();
    }

    protected void clear()
    {
        dd_year.SelectedIndex = 0;
        ddlreimbursement.SelectedIndex = 0;
        txtamount.Text = "";
    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam1 = new SqlParameter[2];

        sqlparam1[0] = new SqlParameter("@reimbursementid", SqlDbType.Int);
        sqlparam1[0].Value = ddlreimbursement.SelectedValue;

        sqlparam1[1] = new SqlParameter("@branchid", SqlDbType.Int);
        sqlparam1[1].Value = dd_branch.SelectedValue;

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_reimburesment_selectempcode", sqlparam1);

        for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
        {
            SqlParameter[] sqlparam = new SqlParameter[6];

            sqlparam[0] = new SqlParameter("@financialyear", SqlDbType.VarChar, 50);
            sqlparam[0].Value = dd_year.SelectedValue.ToString();

            sqlparam[1] = new SqlParameter("@reimbursementid", SqlDbType.Int);
            sqlparam[1].Value = ddlreimbursement.SelectedValue;

            sqlparam[2] = new SqlParameter("@amount", SqlDbType.Decimal);
            sqlparam[2].Value = Convert.ToDecimal(txtamount.Text.Trim());

            sqlparam[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            sqlparam[3].Value = Session["name"].ToString();

            sqlparam[4] = new SqlParameter("@createddate", SqlDbType.DateTime);
            sqlparam[4].Value = System.DateTime.Now;

            sqlparam[5] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[5].Value = ds1.Tables[0].Rows[i]["empcode"].ToString();

            msg = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_reimburesment_autocreate", sqlparam);
        }
        if (msg > 0)
        {
            message.InnerHtml = " Reimbursement created successfully ";
            //clear();
            bindgrid();
        }
        else
            message.InnerHtml=" Reimbursement has not been created successfully ";
    } 

    protected void ddlreimbursement_DataBound(object sender, EventArgs e)
    {
        ddlreimbursement.Items.Insert(0, new ListItem("---Select Reimbursement---", "0"));
    }

    protected void bindgrid()
    {
        sqlstr = @"select a.financialyear,a.amount,a.empcode,a.reimbursementid,a.id,r.PAYHEAD_NAME reimbursementname
                    from tbl_payroll_reimbursement_autocreate a
                    left outer join tbl_payroll_reimbursement r
                    on a.reimbursementid=r.id WHERE 1=1";
        if (ddlreimbursement.SelectedIndex != 0)
        {
            sqlstr =sqlstr + "  AND a.reimbursementid=" + ddlreimbursement.SelectedValue;
        }

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
        reimbursementgird.DataSource = ds;
        reimbursementgird.DataBind();
    }

    protected void reimbursementgird_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        reimbursementgird.PageIndex = e.NewPageIndex;
        bindgrid();
    }

    protected void reimbursementgird_RowEditing(object sender, GridViewEditEventArgs e)
    {
        reimbursementgird.EditIndex = e.NewEditIndex;
        bindgrid();
    }

    protected void reimbursementgird_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        decimal amount = Convert.ToDecimal(((TextBox)reimbursementgird.Rows[e.RowIndex].Cells[3].Controls[1]).Text);
        int code = (int)reimbursementgird.DataKeys[e.RowIndex].Value;

        sqlstr = "UPDATE tbl_payroll_reimbursement_autocreate SET amount='" + amount + "' WHERE id=" + code + "";
        DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        reimbursementgird.EditIndex = -1;
        bindgrid();
    }

    protected void reimbursementgird_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        reimbursementgird.EditIndex = -1;
        bindgrid();
    }

    protected void dd_year_DataBound(object sender, EventArgs e)
    {
        dd_year.Items.Insert(0, new ListItem("---Select Financial Year---", "0"));
    }

    protected void ddlreimbursement_SelectedIndexChanged(object sender, EventArgs e)
    {
        bindgrid();
        sqlstr="SELECT taxrebate FROM tbl_payroll_reimbursement WHERE id='" + ddlreimbursement.SelectedValue + "'";
        ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(),CommandType.Text,sqlstr);

        txtamount.Text=ds.Tables[0].Rows[0]["taxrebate"].ToString();
    }

    protected void dd_branch_DataBound(object sender, EventArgs e)
    {
        dd_branch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }
}