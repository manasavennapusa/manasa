using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Data.SqlTypes;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccessLayer;
using Utilities;

public partial class payroll_admin_pt_slab_master : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                bindptslabs();
            }
            else Response.Redirect("~/notlogged.aspx");
            if (Request.QueryString["id"] != null)
            {
                bindeditptslabes();
            }
        }
    }

    private void bindeditptslabes()
    {
        btnupdate.Visible = true;
        btnsave.Visible = false;
        btnreset.Visible = false;
        SqlParameter[] sqlparam = new SqlParameter[1];
        int id = Convert.ToInt32( Request.QueryString["id"]);
        sqlparam[0] = new SqlParameter("@id", SqlDbType.Int);
        sqlparam[0].Value = id;
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fecth_pt_edit_stateslabdetails", sqlparam);
        ddl_state.SelectedValue = ds.Tables[0].Rows[0]["StateId"].ToString();
        txtfromdate.Text = ds.Tables[0].Rows[0]["FromDate"].ToString();
        txttodate.Text = ds.Tables[0].Rows[0]["ToDate"].ToString();
        txtamountfrom.Text = ds.Tables[0].Rows[0]["Amountfrom"].ToString();
        txtamountto.Text = ds.Tables[0].Rows[0]["AmountTo"].ToString();
        txtrate.Text = ds.Tables[0].Rows[0]["TaxRate"].ToString();
        ddl_state.Enabled = false;
    }

    private void bindptslabs()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fecth_ptslabdetails");
        grd_ptslabs.DataSource = ds;
        grd_ptslabs.DataBind();
    }

    protected void ddl_state_DataBound(object sender, EventArgs e)
    {
        ddl_state.Items.Insert(0,new ListItem("----Select---","0"));
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
       
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[8];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = Session["empcode"].ToString();

            sqlparam[1] = new SqlParameter("@stateid", SqlDbType.Int);
            sqlparam[1].Value = ddl_state.SelectedValue;

            sqlparam[2] = new SqlParameter("@fromamount", SqlDbType.Decimal);
            sqlparam[2].Value =Convert.ToDecimal(txtamountfrom.Text.Trim().ToString());

            sqlparam[3] = new SqlParameter("@toamount", SqlDbType.Decimal);
            sqlparam[3].Value = Convert.ToDecimal(txtamountto.Text.Trim().ToString());

            sqlparam[4] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlparam[4].Value = Utility.dataformat(txtfromdate.Text);

            sqlparam[5] = new SqlParameter("@todate", SqlDbType.DateTime);
            sqlparam[5].Value = Utility.dataformat(txttodate.Text);

            sqlparam[6] = new SqlParameter("@taxrate", SqlDbType.Decimal);
            sqlparam[6].Value = Convert.ToDecimal(txtrate.Text.Trim().ToString());
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_ptslabdetails", sqlparam);
            if (i > 0)
            {
                message.InnerHtml = "Pt Slab Successfully Inserted";
            }
            else
            {
                message.InnerHtml = "Pt Slab not Inserted";
            }
            bindptslabs();
            clear();
        }
        catch (Exception ex) { throw ex; }
    }

    private void clear()
    {
        ddl_state.SelectedIndex = 0;
        txtamountfrom.Text = "";
        txtamountto.Text = "";
        txtfromdate.Text = "";
        txttodate.Text = "";
        txtrate.Text = "";
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        ddl_state.SelectedIndex = 0;
        txtamountfrom.Text = "";
        txtamountto.Text = "";
        txtfromdate.Text = "";
        txttodate.Text = "";
        txtrate.Text = "";
    }
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@satateid", SqlDbType.Int);
        sqlparam[0].Value = ddl_state.SelectedValue;
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fecth_pt_stateslabdetails", sqlparam);
        grd_ptslabs.DataSource = ds;
        grd_ptslabs.DataBind();
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        try
        {
            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
            sqlparam[0].Value = Session["empcode"].ToString();

            sqlparam[1] = new SqlParameter("@id", SqlDbType.Int);
            sqlparam[1].Value = id;

            sqlparam[2] = new SqlParameter("@fromamount", SqlDbType.Decimal);
            sqlparam[2].Value = Convert.ToDecimal(txtamountfrom.Text.Trim().ToString());

            sqlparam[3] = new SqlParameter("@toamount", SqlDbType.Decimal);
            sqlparam[3].Value = Convert.ToDecimal(txtamountto.Text.Trim().ToString());

            sqlparam[4] = new SqlParameter("@fromdate", SqlDbType.DateTime);
            sqlparam[4].Value = Utility.dataformat(txtfromdate.Text);

            sqlparam[5] = new SqlParameter("@todate", SqlDbType.DateTime);
            sqlparam[5].Value = Utility.dataformat(txttodate.Text);

            sqlparam[6] = new SqlParameter("@taxrate", SqlDbType.Decimal);
            sqlparam[6].Value = Convert.ToDecimal(txtrate.Text.Trim().ToString());
            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_update_ptslabdetails", sqlparam);
            if (i > 0)
            {
                message.InnerHtml = "Pt Slab Successfully Updated";
            }
            else
            {
                message.InnerHtml = "Pt Slab not Inserted";
            }
            bindptslabs();
            clear();
            btnupdate.Visible = false;
            btnsave.Visible = true;
            btnreset.Visible = true;
            ddl_state.Enabled = true;
        }
        catch (Exception ex) { throw ex; }
    }
}