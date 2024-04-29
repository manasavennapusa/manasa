using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class admin_countryedit : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
        }
        else
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            bindcurrencycode();
        }
        if (Request.QueryString["Id"] == null)
        {
            btncountry.Text = "Submit";
            bindGrid();
        }
         else
        {
            btncountry.Text = "Update";
            if (!IsPostBack)
            {
                Session["countryid"] = Request.QueryString["id"].ToString();
                tblcountry.Visible = true;
                grdCountry.Visible = false;
                BindTbl();
                grujj.Visible = false;
            }
        }
        if (Request.QueryString["Updated"] != null)
            SmartHr.Common.Alert("Updated Successfully");
    }

    protected void bindcurrencycode()
    {
        string sqlstr = "select * from tbl_intranet_currencycode where status=1 ";
        DataSet ds_cur = new DataSet();
        ds_cur = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddlCurrCode.DataSource = ds_cur;
        ddlCurrCode.DataTextField = "currencycode";
        ddlCurrCode.DataValueField = "id";
        ddlCurrCode.DataBind();
        ddlCurrCode.Items.Insert(0, new ListItem("--Select--", "0"));

    }
    
    protected void btncountry_Click(object sender, EventArgs e)
    {
        edittcountry();
    }
    protected void edittcountry()
    {
        int cid = Convert.ToInt32(Session["countryid"]);
        sqlstr = "select * from tbl_intranet_country_master where cid='" + cid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
        {
            cid = 0;
        }
        SqlParameter[] sqlParam = new SqlParameter[7];

        sqlParam[0] = new SqlParameter("@countryname", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txtcountry.Text;

        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txtcountryDes.Text;

        sqlParam[2] = new SqlParameter("@cid", SqlDbType.Int);
        sqlParam[2].Value = cid;

        sqlParam[3] = new SqlParameter("@ISO31663CCodes", SqlDbType.VarChar, 3);
        sqlParam[3].Value = txt_iso_3c.Text;

        sqlParam[4] = new SqlParameter("@capital", SqlDbType.VarChar, 100);
        sqlParam[4].Value = txtCapital.Text;

        sqlParam[5] = new SqlParameter("@currencyname", SqlDbType.VarChar, 100);
        sqlParam[5].Value = txtCurrName.Text;

        sqlParam[6] = new SqlParameter("@currencycode", SqlDbType.VarChar, 50);
        sqlParam[6].Value = ddlCurrCode.SelectedValue;

        int i=DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_update_country]", sqlParam);
        if (i <= 0)
        {
           SmartHr.Common.Alert("Country name already exists, please enter another name");
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");

           txtcountry.Text = "";
           Response.Redirect("countryedit.aspx?Updated=true");
        }
        
    }

    protected void bindGrid()
    {
        sqlstr = "select ctry.*,cc.currencycode as currency from tbl_intranet_country_master ctry inner join tbl_intranet_currencycode cc on ctry.currencycode=cast(cc.id as varchar(10))";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        tblcountry.Visible = false;
        grdCountry.Visible = true;
        grdCountry.DataSource = ds;
        grdCountry.DataBind();
        lblhead.Text = "View";
    }
    protected void Grid_Emp_PreRender(object sender, EventArgs e)
    {
        if (grdCountry.Rows.Count > 0)
        {
            grdCountry.UseAccessibleHeader = true;
            grdCountry.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void BindTbl()
    {
        lblhead.Text = "Edit";
        int cid = Convert.ToInt32(Session["countryid"]);
        sqlstr = "select * from tbl_intranet_country_master where cid='" + cid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 1)
            return;
        tblcountry.Visible = true;
        grdCountry.Visible = false;
        txtcountry.Text = ds.Tables[0].Rows[0]["countryname"].ToString();
        txt_iso_3c.Text = ds.Tables[0].Rows[0]["ISO31663CCodes"].ToString();
        txtCapital.Text = ds.Tables[0].Rows[0]["capital"].ToString();
        txtCurrName.Text = ds.Tables[0].Rows[0]["currencyname"].ToString();
        ddlCurrCode.SelectedValue = ds.Tables[0].Rows[0]["currencycode"].ToString();
        txtcountryDes.Text = ds.Tables[0].Rows[0]["description"].ToString();
    }
    protected void lbnt_Active_click(object sender, CommandEventArgs e)
    {
        int cid = Convert.ToInt32( e.CommandArgument);
        sqlstr = "select status from tbl_intranet_country_master  where cid='" + cid + "'";
        ds=DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows[0]["status"].ToString() == "True")
        {
            sqlstr = "update tbl_intranet_country_master set status=0 where cid='" + cid + "'";
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }
        else 
        {
            sqlstr = "update tbl_intranet_country_master set status=1 where cid='" + cid + "'";
            DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }
        bindGrid();
    }


    protected void ddlCurrCode_SelectedIndexChanged(object sender, EventArgs e)
    {
         if (ddlCurrCode.SelectedValue == "0")
        {
            txtCurrName.Text = "";
        }
        else
        {
            string sqlstr = "select description from tbl_intranet_currencycode where  id=" + ddlCurrCode.SelectedValue;
            DataSet ds_cur = new DataSet();
            ds_cur = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
            txtCurrName.Text = ds_cur.Tables[0].Rows[0]["description"].ToString();
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("countryedit.aspx");
    }
}
