using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_TravelClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            bindtravelmode();
            bindGrid();
            btncancel2.Visible = false;
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;

            if (Request.QueryString["ID"] == null)
            {
                btnSave.Text = "Submit";
                btnSave.Attributes.Add("class", "btn btn-primary");
            }
            else
            {
                btnSave.Text = "Update";
                btncancel2.Visible = true;
                btnCancel.Visible = false;
                create1.Visible = false;
                create.Visible = false;
                edit1.Visible = true;
                edit.Visible = true;
                grid1.Visible = false;
                btnSave.Attributes.Add("class", "btn btn-warning");
                bindData(Request.QueryString["ID"].ToString());
            }

            if (Request.QueryString["updated"] != null)
            {
                SmartHr.Common.Alert("Travel Class Updated Successfully!!!");
            }

        }
    }
    protected void grdtravelClass_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtravelClass.PageIndex = e.NewPageIndex;
        bindGrid();
    }
    protected void grdtravelClass_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(grdtravelClass.DataKeys[e.RowIndex].Value);

        param[1] = new SqlParameter("@travelmodeID", SqlDbType.Int);
        param[1].Value = 0;

        param[2] = new SqlParameter("@travelclass", SqlDbType.VarChar, 50);
        param[2].Value = 0;

        param[3] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
        param[3].Value = 0;

        param[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[4].Value = "";

        param[5] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[5].Value = "D";

        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_travelclass", param);
        bindGrid();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
        {
            insertdata();
        }
        else
        {
            updatedata();
            Response.Redirect("TravelClass.aspx?updated=true");
        }

    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
        if (Request.QueryString["ID"] != null)
        {
            Response.Redirect("TravelClass.aspx");
        }
    }

    protected void insertdata()
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = 0;

        param[1] = new SqlParameter("@travelmodeID", SqlDbType.Int);
        param[1].Value = ddl_travelmode.SelectedValue;

        param[2] = new SqlParameter("@travelclass", SqlDbType.VarChar, 50);
        param[2].Value = txtTravelClass.Text;

        param[3] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
        param[3].Value = txtDesc.Text;

        param[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[4].Value = Session["empcode"].ToString();

        param[5] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[5].Value = "I";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_travelclass", param);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Travel  Class name already exists, please enter another name");
        }
        else
        {
            SmartHr.Common.Alert("Travel  Class created Successfully!!!");
            bindGrid();
            clear();
        }
    }
    protected void updatedata()
    {
        if (Request.QueryString["ID"] != null)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            SqlParameter[] param = new SqlParameter[6];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@travelmodeID", SqlDbType.Int);
            param[1].Value = ddl_travelmode.SelectedValue;

            param[2] = new SqlParameter("@travelclass", SqlDbType.VarChar, 50);
            param[2].Value = txtTravelClass.Text;

            param[3] = new SqlParameter("@description", SqlDbType.VarChar, 1000);
            param[3].Value = txtDesc.Text;

            param[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            param[4].Value = Session["empcode"].ToString();

            param[5] = new SqlParameter("@flag", SqlDbType.Char, 1);
            param[5].Value = "U";

           int i= DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_travelclass", param);

            if (i <= 0)
            {
                SmartHr.Common.Alert("Travel  Class name already exists, please enter another name");
            }
            else
            {
                SmartHr.Common.Alert("Travel  Class Updated Successfully!!!");
                bindGrid();
                clear();
            }
        }
    }
    protected void bindGrid()
    {
        string sqlstr = "select tc.travelclassid,tc.travelmodeclass,tc.descripetion,tm.travelmode from tbl_travel_TravelModeClass tc inner join tbl_travel_travelmode tm on tc.travelmodeID=tm.travelmodeId";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
        grdtravelClass.DataSource = ds;
        grdtravelClass.DataBind();
    }
    protected void bindData(string ID)
    {
        string sqlstr = "select * from tbl_travel_TravelModeClass where travelclassid=" + ID + "";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_travelmode.SelectedValue = ds.Tables[0].Rows[0]["travelmodeId"].ToString();
            txtTravelClass.Text = ds.Tables[0].Rows[0]["travelmodeclass"].ToString();
            txtDesc.Text = ds.Tables[0].Rows[0]["descripetion"].ToString();
        }
    }
    protected void bindtravelmode()
    {
        string sqlstr = "select travelmodeId,travelmode from tbl_travel_travelmode";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        ddl_travelmode.DataTextField = "travelmode";
        ddl_travelmode.DataValueField = "travelmodeId";
        ddl_travelmode.DataSource = ds;
        ddl_travelmode.DataBind();
        ddl_travelmode.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    
    protected void clear()
    {
        ddl_travelmode.SelectedValue = "0";
        txtTravelClass.Text = "";
        txtDesc.Text = "";
    }
    protected void grdtravelClass_PreRender(object sender, EventArgs e)
    {
        if (grdtravelClass.Rows.Count > 0)
        {
            grdtravelClass.UseAccessibleHeader = true;
            grdtravelClass.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/TravelClass.aspx");
    }
}