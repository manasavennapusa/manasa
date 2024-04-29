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

public partial class admin_country : System.Web.UI.Page
{
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
    }

    protected void btncountry_Click(object sender, EventArgs e)
    {
        insertcountry();
    }

    protected void insertcountry()
    {
        SqlParameter[] sqlParam = new SqlParameter[7];

        sqlParam[0] = new SqlParameter("@countryname", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txtcountry.Text;

        sqlParam[1] = new SqlParameter("@description", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txtcountryDes.Text;

        sqlParam[2] = new SqlParameter("@ISO31663CCodes", SqlDbType.VarChar, 3);
        sqlParam[2].Value = txt_iso_3c.Text;

        sqlParam[3] = new SqlParameter("@capital", SqlDbType.VarChar, 100);
        sqlParam[3].Value = txtCapital.Text;

        sqlParam[4] = new SqlParameter("@currencyname", SqlDbType.VarChar, 100);
        sqlParam[4].Value = txtCurrName.Text;

        sqlParam[5] = new SqlParameter("@currencycode", SqlDbType.VarChar, 50);
        sqlParam[5].Value = ddlCurrCode.SelectedValue;

        sqlParam[6] = new SqlParameter("@status", SqlDbType.Bit);
        sqlParam[6].Value = true;



        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_insert_country]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Country name already exists, please enter another name.");
            //message.InnerHtml = "Country name already exists, please enter another name";
        }
        else
        {
            SmartHr.Common.Alert("Created Successfully");
           // message.InnerHtml = "Country created successfully";

            txtcountry.Text = "";
            txtcountryDes.Text = "";
        }
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
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        txt_iso_3c.Text = "";
        txtcountry.Text="";
        txtCapital.Text = "";
        txtCurrName.Text = "";
        txtcountryDes.Text = "";
        ddlCurrCode.SelectedValue = "0";
        txtcountryDes.Text = "";
        txtCurrName.Text = "";
    }

}
