using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_PerDiem : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            bindgride();
            bindcurrencycode();
            btnupdate.Visible = false;
            btncancel2.Visible = false;
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;

            if (Request.QueryString["Id"] != null)
            {

                bindperdiem();
                btnsave.Visible = false;
                btnupdate.Visible = true;
                btncancel2.Visible = true;
                btncancel.Visible = false;
                create1.Visible = false;
                create.Visible = false;
                edit1.Visible = true;
                edit.Visible = true;
                grid1.Visible = false;
            }

           
        }
    }

    private void bindperdiem()
    {
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);
        sqlstr = "select currencycode,piediem from tbl_travel_perdiem where status=1 and perdiemId='" + Tid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        dll_currencycode.SelectedItem.Text = ds.Tables[0].Rows[0]["currencycode"].ToString();
        txtperdiem.Text = ds.Tables[0].Rows[0]["piediem"].ToString();
    }

    private void bindgride()
    {
        sqlstr = "select perdiemId,currencycode,piediem from tbl_travel_perdiem";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdtravelper.DataSource = ds;
        grdtravelper.DataBind();
    }

    private void bindcurrencycode()
    {
        //int Tid = Convert.ToInt32(Request.QueryString["Id"]);
        sqlstr = "select id,currencycode from tbl_intranet_currencycode";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["IntranetConnectionString"].ConnectionString.ToString(),CommandType.Text,sqlstr);       
        dll_currencycode.DataTextField = "currencycode";
        dll_currencycode.DataValueField = "id";
        dll_currencycode.DataSource = ds;
       // dll_currencycode.Items.Insert(0, new ListItem("------Select------", "0"));
        dll_currencycode.DataBind();
       
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        string empcode = Session["empcode"].ToString();

        SqlParameter[] sqlParam = new SqlParameter[5];

        sqlParam[0] = new SqlParameter("@currencycode", SqlDbType.VarChar, 30);
        sqlParam[0].Value = dll_currencycode.SelectedItem.Text;

        sqlParam[1] = new SqlParameter("@piediem", SqlDbType.Decimal);
        sqlParam[1].Value = txtperdiem.Text;

        sqlParam[2] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[2].Value = "I";

        sqlParam[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = empcode;

        sqlParam[4] = new SqlParameter("@perdiemId", SqlDbType.Int);
        sqlParam[4].Value = 0;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Travel_insert_perdiem", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Travel Mode name already exists, please enter another name");

        }
        else
        {
            SmartHr.Common.Alert("Travel Mode Created Successfully!!!");
            bindgride();                           
            clear();
            
        }
    }
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);
        string empcode = Session["empcode"].ToString();

        SqlParameter[] sqlParam = new SqlParameter[5];

        sqlParam[0] = new SqlParameter("@currencycode", SqlDbType.VarChar, 30);
        sqlParam[0].Value = dll_currencycode.SelectedItem.Text;

        sqlParam[1] = new SqlParameter("@piediem", SqlDbType.Decimal);
        sqlParam[1].Value = txtperdiem.Text;

        sqlParam[2] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[2].Value = "U";

        sqlParam[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = empcode;

        sqlParam[4] = new SqlParameter("@perdiemId", SqlDbType.Int);
        sqlParam[4].Value = Tid;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Travel_insert_perdiem", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Travel Mode already exists, please enter another name");
            bindgride();
        }
        else
        {
            SmartHr.Common.Alert("Travel Mode Updated Successfully!!!");
            clear();
            bindgride();
            btnsave.Visible = true;
            btncancel.Visible = true;
            btnupdate.Visible = false;
            btncancel2.Visible = false;
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;
            grid1.Visible = true;
        }

    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
    }

    private void clear()
    {
        dll_currencycode.SelectedItem.Text = "";
        txtperdiem.Text = "";
    }
    protected void grdtravelper_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        int Tid = Convert.ToInt32(grdtravelper.DataKeys[e.RowIndex].Value);
        string empcode = Session["empcode"].ToString();

        SqlParameter[] sqlParam = new SqlParameter[5];

        sqlParam[0] = new SqlParameter("@currencycode", SqlDbType.VarChar, 30);
        sqlParam[0].Value = 0;

        sqlParam[1] = new SqlParameter("@piediem", SqlDbType.Decimal);
        sqlParam[1].Value = 0;

        sqlParam[2] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[2].Value = "D";

        sqlParam[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = empcode;

        sqlParam[4] = new SqlParameter("@perdiemId", SqlDbType.Int);
        sqlParam[4].Value = Convert.ToInt32(grdtravelper.DataKeys[e.RowIndex].Value); ;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Travel_insert_perdiem", sqlParam);
        SmartHr.Common.Alert("Travel Mode Deleted Successfully!!!");
        bindgride();

        btnsave.Visible = true;
        btnupdate.Visible = false;

    }
    protected void grdtravelper_PreRender(object sender, EventArgs e)
    {
        if (grdtravelper.Rows.Count > 0)
        {
            grdtravelper.UseAccessibleHeader = true;
            grdtravelper.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    //protected void dll_currencycode_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bindcurrencycode();
    //}
    //protected void dll_currencycode_DataBound(object sender, EventArgs e)
    //{
    //    dll_currencycode.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    //}
    protected void dll_currencycode_DataBound(object sender, EventArgs e)
    {
        dll_currencycode.Items.Insert(0, new ListItem("---Select CurrencyCode---", "0"));
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/PerDiem.aspx");
    }
}