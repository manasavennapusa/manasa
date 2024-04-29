using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_currencymaster : System.Web.UI.Page
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
            else
                Response.Redirect("~/notlogged.aspx");
            bindddl_currencyfrom();
            bindddl_currencyto();
            bindGrid2();

            if (Request.QueryString["slno"] == null)
            {
                btncurrency.Text = "Save";
                //lblhead.Text = "Create State";
                if (Request.QueryString["updated"] == "true")
                {
                    SmartHr.Common.Alert("Updated successfully");
                }
            }
            else
            {
                btncurrency.Text = "Update";
                //lblhead.Text = "Edit State";
                BindTbl();

            }

        }

    }

    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        grdState.UseAccessibleHeader = true;
        grdState.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
    protected void btncurrency_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["slno"] == null)
        {
            insertcurrency();
        }
        else
        {
            editcurrency();
        }
    }

    protected void insertcurrency()
    {
        SqlParameter[] sqlParam = new SqlParameter[9];

        sqlParam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlParam[0].Value = txtFromdate.Text;

        sqlParam[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlParam[1].Value = txtTodate.Text;

        sqlParam[2] = new SqlParameter("@fromcurrency", SqlDbType.VarChar, 3);
        sqlParam[2].Value = ddl_currencyfrom.SelectedValue;

        sqlParam[3] = new SqlParameter("@tocurrency", SqlDbType.VarChar, 3);
        sqlParam[3].Value = ddl_currencyTo.SelectedValue;

        sqlParam[4] = new SqlParameter("@fromrate", SqlDbType.Int);
        sqlParam[4].Value = txtConversionfrom.Text;

        sqlParam[5] = new SqlParameter("@torate", SqlDbType.Decimal, 8);
        sqlParam[5].Precision = 8;
        sqlParam[5].Scale = 4;
        sqlParam[5].Value = txtCoversionto.Text;

        sqlParam[6] = new SqlParameter("@rev_fromrate", SqlDbType.Decimal, 8);
        sqlParam[6].Precision = 8;
        sqlParam[6].Scale = 4;
        sqlParam[6].Value = txtRevConversionfrom.Text;

        sqlParam[7] = new SqlParameter("@rev_torate", SqlDbType.Int);
        sqlParam[7].Value = txtRevconvesionto.Text;

        sqlParam[8] = new SqlParameter("@status", SqlDbType.Bit);
        sqlParam[8].Value = true;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_insert_currency]", sqlParam);

        if (i <= 0)
        {

        }
        else
        {
            SmartHr.Common.Alert("Data Save Successfully");
            cleartext();
            bindGrid2();
        }
    }


    //protected void bindGrid(string country)
    //{
    //    sqlstr = "select * from tbl_intranet_state_master  where  Country='" + country + "'";
    //    ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
    //    grdState.DataSource = ds;
    //    grdState.DataBind();
    //}

    protected void bindGrid2()
    {

        sqlstr = "select * from tbl_currency_master";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdState.DataSource = ds;
        grdState.DataBind();
    }

    protected void BindTbl()
    {
        if (Request.QueryString["slno"] != null)
        {

            int ID = Convert.ToInt32(Request.QueryString["slno"]);
            sqlstr = "select * from tbl_currency_master where slno='" + ID + "'";
            ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            txtFromdate.Text = ds.Tables[0].Rows[0]["fromdate"].ToString();
            txtTodate.Text = ds.Tables[0].Rows[0]["todate"].ToString();
            ddl_currencyfrom.SelectedValue = ds.Tables[0].Rows[0]["fromcurrency"].ToString();
            ddl_currencyTo.SelectedValue = ds.Tables[0].Rows[0]["tocurrency"].ToString();
            txtConversionfrom.Text = ds.Tables[0].Rows[0]["fromrate"].ToString();
            txtCoversionto.Text = ds.Tables[0].Rows[0]["torate"].ToString();
            txtRevConversionfrom.Text = ds.Tables[0].Rows[0]["rev_fromrate"].ToString();
            txtRevconvesionto.Text = ds.Tables[0].Rows[0]["rev_torate"].ToString();
        }
        else
        {
            bindGrid2();
        }
    }
    protected void bindddl_currencyfrom()
    {
        sqlstr = "select distinct(currencycode) from tbl_intranet_country_master where currencycode!=''";//where status=1
        DataSet ds_country = new DataSet();
        ds_country = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_currencyfrom.DataSource = ds_country;
        ddl_currencyfrom.DataTextField = "currencycode";
        ddl_currencyfrom.DataValueField = "currencycode";
        ddl_currencyfrom.DataBind();
        ddl_currencyfrom.Items.Insert(0, new ListItem("--Select--", "0"));
        ddl_currencyfrom.SelectedValue = "INR";
        var itemIndex = ddl_currencyfrom.SelectedIndex;
        var item = ddl_currencyfrom.Items[itemIndex];
        ddl_currencyfrom.Items.RemoveAt(itemIndex);
        ddl_currencyfrom.Items.Insert(1, new ListItem(item.Text, item.Value));
    }
    protected void bindddl_currencyto()
    {
        sqlstr = "select distinct(currencycode) from tbl_intranet_country_master where currencycode!='' ";// where status=1
        DataSet ds_country = new DataSet();
        ds_country = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //if (ds.Tables[0].Rows.Count < 1)
        //  return;
        ddl_currencyTo.DataSource = ds_country;
        ddl_currencyTo.DataTextField = "currencycode";
        ddl_currencyTo.DataValueField = "currencycode";
        ddl_currencyTo.DataBind();
        ddl_currencyTo.Items.Insert(0, new ListItem("--Select--", "0"));


        //ddlcountry. = Request.QueryString["country"].ToString();
    }
    //protected void ddl_currencyTo_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (ddlcountry.SelectedValue != "0")
    //        bindGrid(ddlcountry.SelectedValue);
    //}

    protected void editcurrency()
    {
        int ID = Convert.ToInt32(Request.QueryString["slno"]);
        SqlParameter[] sqlParam = new SqlParameter[9];

        sqlParam[0] = new SqlParameter("@fromdate", SqlDbType.DateTime);
        sqlParam[0].Value = txtFromdate.Text;

        sqlParam[1] = new SqlParameter("@todate", SqlDbType.DateTime);
        sqlParam[1].Value = txtTodate.Text;

        sqlParam[2] = new SqlParameter("@fromcurrency", SqlDbType.VarChar, 3);
        sqlParam[2].Value = ddl_currencyfrom.SelectedValue;

        sqlParam[3] = new SqlParameter("@tocurrency", SqlDbType.VarChar, 3);
        sqlParam[3].Value = ddl_currencyTo.SelectedValue;

        sqlParam[4] = new SqlParameter("@fromrate", SqlDbType.Int);
        sqlParam[4].Value = txtConversionfrom.Text;

        sqlParam[5] = new SqlParameter("@torate", SqlDbType.Decimal, 8);
        sqlParam[5].Precision = 8;
        sqlParam[5].Scale = 4;
        sqlParam[5].Value = txtCoversionto.Text;

        sqlParam[6] = new SqlParameter("@rev_fromrate", SqlDbType.Decimal, 8);
        sqlParam[6].Precision = 8;
        sqlParam[6].Scale = 4;
        sqlParam[6].Value = txtRevConversionfrom.Text;

        sqlParam[7] = new SqlParameter("@rev_torate", SqlDbType.Int);
        sqlParam[7].Value = txtRevconvesionto.Text;

        sqlParam[8] = new SqlParameter("@slno", SqlDbType.Int);
        sqlParam[8].Value = ID;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_update_currency]", sqlParam);

        if (i <= 0)
        {
            //message.InnerHtml = "State name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Created successfully");
            cleartext();
            bindGrid2();
            Response.Redirect("currencymaster.aspx?updated=true");
        }
    }


    protected void lbnt_Active_click(object sender, CommandEventArgs e)
    {
        int cid = Convert.ToInt32(e.CommandArgument);
        sqlstr = "select status from tbl_currency_master  where slno='" + cid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows[0]["status"].ToString() == "True")
        {
            sqlstr = "update tbl_currency_master set status=0 where slno='" + cid + "'";
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }
        else
        {
            sqlstr = "update tbl_currency_master set status=1 where slno='" + cid + "'";
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }
        bindGrid2();
    }

    protected void cleartext()
    {
        txtFromdate.Text = "";
        txtTodate.Text = "";
        txtCoversionto.Text = "";
        txtRevConversionfrom.Text = "";
        txtRevconvesionto.Text = "";
        ddl_currencyfrom.SelectedValue = "0";
        ddl_currencyTo.SelectedValue = "0";
    }

    protected void ddl_currencyfrom_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        sqlstr = "select distinct(currencycode) from tbl_intranet_country_master where  currencycode!='" + ddl_currencyfrom.SelectedValue + "' and currencycode!='' ";// where status=1
        DataSet ds_country = new DataSet();
        ds_country = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        //if (ds.Tables[0].Rows.Count < 1)
        //  return;
        ddl_currencyTo.Items.Clear();
        ddl_currencyTo.DataSource = ds_country;
        ddl_currencyTo.DataTextField = "currencycode";
        ddl_currencyTo.DataValueField = "currencycode";
        ddl_currencyTo.DataBind();
        ddl_currencyTo.Items.Insert(0, new ListItem("--Select--", "0"));
        if (ddl_currencyfrom.SelectedValue != "INR")
        {
            ddl_currencyTo.SelectedValue = "INR";
            var itemIndex = ddl_currencyTo.SelectedIndex;
            var item = ddl_currencyTo.Items[itemIndex];
            ddl_currencyTo.Items.RemoveAt(itemIndex);
            ddl_currencyTo.Items.Insert(1, new ListItem(item.Text, item.Value));
        }
    }

}