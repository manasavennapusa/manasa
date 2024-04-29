using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_StayTariff : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {

           // bindgrade();
            bindGrid();
            bindtier();
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;
            ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));

            if (Request.QueryString["ID"] == null)
            {
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btncancel2.Visible = false;
               
            }
            else
            {
                btnSave.Visible = false;
                btnUpdate.Visible = true;
                btncancel2.Visible = true;
                btnCancel.Visible = false;
                create1.Visible = false;
                create.Visible = false;
                edit1.Visible = true;
                edit.Visible = true;
                grid1.Visible = false;
                bindData(Request.QueryString["ID"].ToString());
            }
        }
    }

    protected void grdtravelTariff_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtravelTariff.PageIndex = e.NewPageIndex;
        bindGrid();
    }

    protected void grdtravelTariff_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(grdtravelTariff.DataKeys[e.RowIndex].Value);

        param[1] = new SqlParameter("@gradeID", SqlDbType.Int);
        param[1].Value = 0;

        param[2] = new SqlParameter("@tierID", SqlDbType.Int);
        param[2].Value = 0;

        param[3] = new SqlParameter("@taiff", SqlDbType.Decimal);
        param[3].Value = 0;

        param[4] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param[4].Value = "";

        param[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[5].Value = "";

        param[6] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[6].Value = "D";

        param[7] = new SqlParameter("@currencycode", SqlDbType.Int);
        param[7].Value = 0;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_StayTariffLimits", param);

        if (i <= 0)
        {
            SmartHr.Common.Alert("L & C / Stay Tariff Not Deleted Successfully");
        }
        else
        {
            SmartHr.Common.Alert("L & C / Stay Tariff Deleted successfully");
            bindGrid();
        }

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        insertdata();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        updatedata();
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
        if (Request.QueryString["ID"] != null)
        {
            Response.Redirect("StayTariff.aspx");
        }
    }

    protected void insertdata()
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = 0;

        param[1] = new SqlParameter("@gradeID", SqlDbType.Int);
        if (ddl_grade.SelectedValue == "0")
        {
            param[1].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            param[1].Value = DBNull.Value;
        }

        param[2] = new SqlParameter("@tierID", SqlDbType.Int);
        //if (ddl_tier.SelectedValue == "0")
        //{
        //    param[1].Value = System.Data.SqlTypes.SqlDateTime.Null;
        //}
        //else
        //{
            param[2].Value = ddl_tier.SelectedValue;
        //}

        param[3] = new SqlParameter("@taiff", SqlDbType.Decimal);
        param[3].Value = txtTariff.Text;

        param[4] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param[4].Value = ddl_traveltype.SelectedValue;

        param[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[5].Value = Session["empcode"].ToString();

        param[6] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[6].Value = "I";

        param[7] = new SqlParameter("@currencycode", SqlDbType.Int);
        if (ddlCurrecny.SelectedValue == "0")
        {
            param[7].Value = System.Data.SqlTypes.SqlDateTime.Null;
        }
        else
        {
            param[7].Value = ddlCurrecny.SelectedValue;
        }

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_StayTariffLimits", param);

        if (i <= 0)
        {
            SmartHr.Common.Alert("L & C / Stay Tariff Not Inserted Successfully.L & C / Stay Tariff is already exists, please try another");
        }
        else
        {
            bindGrid();
             clear();
            SmartHr.Common.Alert("L & C / Stay Tariff Inserted successfully");
        }
    }

    protected void updatedata()
    {
        if (Request.QueryString["ID"] != null)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            SqlParameter[] param = new SqlParameter[8];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@gradeID", SqlDbType.Int);
            if (ddl_grade.SelectedValue == "0")
            {
                param[1].Value = System.Data.SqlTypes.SqlDateTime.Null;
            }
            else
            {
                param[1].Value = DBNull.Value;
            }

            param[2] = new SqlParameter("@tierID", SqlDbType.Int);
            param[2].Value = ddl_tier.SelectedValue;

            param[3] = new SqlParameter("@taiff", SqlDbType.Decimal);
            param[3].Value = txtTariff.Text;

            param[4] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
            param[4].Value = ddl_traveltype.SelectedValue;

            param[5] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            param[5].Value = "";

            param[6] = new SqlParameter("@flag", SqlDbType.Char, 1);
            param[6].Value = "U";

            param[7] = new SqlParameter("@currencycode", SqlDbType.Int);
            param[7].Value = ddlCurrecny.SelectedValue;

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_StayTariffLimits", param);

            if (i > 0)
            {
                bindGrid();
                //clear();
                btnSave.Visible = true;
                btnUpdate.Visible = false;
                btnCancel.Visible = true;
                btncancel2.Visible = false;
                create1.Visible = true;
                create.Visible = true;
                edit1.Visible = false;
                edit.Visible = false;
                grid1.Visible = true;
                SmartHr.Common.Alert("L & C / Stay Tariff Updated successfully");
            }
            else
            {
                SmartHr.Common.Alert("L & C / Stay Tariff is already exists, please try another");
            }

        }
    }

    protected void bindGrid()
    {
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_get_traveltariff");
        grdtravelTariff.DataSource = ds;
        grdtravelTariff.DataBind();
    }

    protected void bindData(string ID)
    {
        string sqlstr = @"select st.*,c.currencycode as currency,ctry.countryname from  tbl_travel_StayTariff st left join tbl_intranet_country_master ctry on ctry.cid=st.currencycode
                            left join tbl_intranet_currencycode c on c.id=ctry.currencycode where st.staytafiffid=" + ID + "";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_grade.SelectedValue = ds.Tables[0].Rows[0]["gradeid"].ToString();
            ddl_tier.SelectedValue = ds.Tables[0].Rows[0]["citytierid"].ToString();
            txtTariff.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
            ddl_traveltype.SelectedValue = ds.Tables[0].Rows[0]["traveltype"].ToString();
            bind_Currency();
            ddlCurrecny.SelectedValue = ds.Tables[0].Rows[0]["currencycode"].ToString();
            lblcurrenycode.Text = ds.Tables[0].Rows[0]["currency"].ToString();
            if (ddl_traveltype.SelectedValue == "I")
                divtier.Visible = false;
            else
                divtier.Visible = true;
        }
    }

    protected void bindgrade()
    {
        string sqlstr = "select id,gradename  from tbl_intranet_grade";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        ddl_grade.DataTextField = "gradename";
        ddl_grade.DataValueField = "id";
        ddl_grade.DataSource = ds3;
        ddl_grade.DataBind();
        ddl_grade.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void bindtier()
    {
        string sqlstr = "select tierID,tier from tbl_travel_Tier";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_tier.DataTextField = "tier";
        ddl_tier.DataValueField = "tierid";
        ddl_tier.DataSource = ds;
        ddl_tier.DataBind();
        ddl_tier.Items.Insert(0, new ListItem("--Select--", "0"));
    }

    protected void clear()
    {

        ddl_grade.SelectedValue = "0";
        ddl_tier.SelectedValue = "0";
        txtTariff.Text = "";
        ddl_traveltype.SelectedValue = "0";
        ddlCurrecny.Items.Clear();
        ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
        lblcurrenycode.Text = "";
    }

    protected void ddl_traveltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_traveltype.SelectedValue == "I")
            divtier.Visible = false;
        else
            divtier.Visible = true;
        bind_Currency();
        ddl_grade.SelectedValue = "0";
        txtTariff.Text = "";
        ddl_tier.SelectedValue = "0";
    }

    protected void grdtravelTariff_PreRender(object sender, EventArgs e)
    {
        if (grdtravelTariff.Rows.Count > 0)
        {
            grdtravelTariff.UseAccessibleHeader = true;
            grdtravelTariff.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void bind_Currency()
    {
        if (ddl_traveltype.SelectedValue == "D")
        {
            string sqlstr = "select cid,countryname from tbl_intranet_country_master";
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddlCurrecny.DataTextField = "countryname";
            ddlCurrecny.DataValueField = "cid";
            ddlCurrecny.DataSource = ds3;
            ddlCurrecny.DataBind();

            string sqlstr2 = "select distinct id,cc.currencycode  from tbl_intranet_country_master ctry inner join  tbl_intranet_currencycode cc on cc.id =ctry.currencycode where ctry.cid=" + ddlCurrecny.SelectedValue;
            DataSet ds4 = new DataSet();
            ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr2);

            lblcurrenycode.Text = " " + ds4.Tables[0].Rows[0]["currencycode"].ToString();
        }
        else
        {
            string sqlstr = "select cid,countryname from tbl_intranet_country_master";
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            ddlCurrecny.DataTextField = "countryname";
            ddlCurrecny.DataValueField = "cid";
            ddlCurrecny.DataSource = ds3;
            ddlCurrecny.DataBind();
           // ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
            //ddlCurrecny.SelectedValue = "98";
            var itemIndex = ddlCurrecny.SelectedIndex;
            var item = ddlCurrecny.Items[itemIndex];
            ddlCurrecny.Items.RemoveAt(itemIndex);
            ddlCurrecny.Items.Insert(1, new ListItem(item.Text, item.Value));
            lblcurrenycode.Text = "";
        }

    }

    protected void ddlCurrecny_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCurrecny.SelectedValue != "0")
        {
            string sqlstr = "select distinct id,cc.currencycode  from tbl_intranet_country_master ctry inner join  tbl_intranet_currencycode cc on cc.id =ctry.currencycode where ctry.cid=" + ddlCurrecny.SelectedValue;
            DataSet ds3 = new DataSet();
            ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

            lblcurrenycode.Text = " " + ds3.Tables[0].Rows[0]["currencycode"].ToString();
        }
        else
        { lblcurrenycode.Text = ""; }
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/StayTariff.aspx");
    }
}