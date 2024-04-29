using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_StayType : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            bindGrid();
            btnupdate.Visible = false;
            btnsave.Visible = true;
            btncancel2.Visible = false;
            create.Visible = true;
            create1.Visible = true;
            edit.Visible = false;
            edit1.Visible = false;
            if (Request.QueryString["ID"] != null)
            {
                btnsave.Visible = false;
                btnupdate.Visible = true;
                btncancel2.Visible = true;
                btncancel.Visible = false;
                create.Visible = false;
                create1.Visible = false;
                edit.Visible = true;
                edit1.Visible = true;
                grid1.Visible = false;
                bindData(Request.QueryString["ID"].ToString());
            }
            if (Request.QueryString["updated"] != null)
            {
                SmartHr.Common.Alert("Stay Type Created Successfully!!!");
            }
        }
    }

    protected void grdstaytype_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@id", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(grdstaytype.DataKeys[e.RowIndex].Value);

        param[1] = new SqlParameter("@staytype", SqlDbType.VarChar, 50);
        param[1].Value = "";

        param[2] = new SqlParameter("@description", SqlDbType.VarChar, 200);
        param[2].Value = "";

        param[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[3].Value = "";

        param[4] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[4].Value = "D";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_StayType", param);
        if (i > 0)
        {
            bindGrid();
            SmartHr.Common.Alert("Stay Type is Deleted Successfully!!!");
        }
        else
        {
            SmartHr.Common.Alert("Stay Type is Not Deleted Successfully!!!");
        }
    }
    
    protected void btnsave_Click(object sender, EventArgs e)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@id", SqlDbType.Int);
        param[0].Value = 0;

        param[1] = new SqlParameter("@staytype", SqlDbType.VarChar,50);
        param[1].Value = txtStayType.Text;

        param[2] = new SqlParameter("@description", SqlDbType.VarChar,200);
        param[2].Value = txtstayDes.Text;

        param[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[3].Value = Session["empcode"].ToString();

        param[4] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[4].Value = "I";

        int i= DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_StayType", param);
        if (i <= 0)
        {
            SmartHr.Common.Alert("Stay Type is already exists, try another");
        }
        else
        {
            SmartHr.Common.Alert("Stay Type Created Successfully!!!");
            bindGrid();
            clear();
        }
    }
    
    protected void btnupdate_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            SqlParameter[] param = new SqlParameter[5];

            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@staytype", SqlDbType.VarChar, 50);
            param[1].Value = txtStayType.Text;

            param[2] = new SqlParameter("@description", SqlDbType.VarChar, 200);
            param[2].Value = txtstayDes.Text;

            param[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            param[3].Value = Session["empcode"].ToString();

            param[4] = new SqlParameter("@flag", SqlDbType.Char, 1);
            param[4].Value = "U";

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_StayType", param);
            if (i <= 0)
            {
                SmartHr.Common.Alert("Stay Type is already exists, try another");
            }
            else
            {
                bindGrid();
                clear();
                btnsave.Visible = true;
                btnupdate.Visible = false;
                btncancel2.Visible = false;
                btncancel.Visible = true;
                create.Visible = true;
                create1.Visible = true;
                edit.Visible = false;
                edit1.Visible = false;
                grid1.Visible = true;
                SmartHr.Common.Alert("Stay Type Updated Successfully!!!");
            }
        }
    }
    
    protected void btncancel_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] != null)
        {
            Response.Redirect("StayType.aspx");
        }
        else
        {
            clear();
        }
    }

    protected void bindGrid()
    {
        string sqlstr = "select * from tbl_travel_staytype";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdstaytype.DataSource = ds;
        grdstaytype.DataBind();
    }
    
    protected void bindData(string id)
    {
        string sqlstr = "select * from tbl_travel_staytype where id="+id+"";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtStayType.Text = ds.Tables[0].Rows[0]["staytype"].ToString();
            txtstayDes.Text = ds.Tables[0].Rows[0]["description"].ToString();
        }
    }
    
    protected void clear()
    {
        txtStayType.Text = "";
        txtstayDes.Text = "";
    }
    
    protected void grdstaytype_PreRender(object sender, EventArgs e)
    {
        if (grdstaytype.Rows.Count > 0)
        {
            grdstaytype.UseAccessibleHeader = true;
            grdstaytype.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/StayType.aspx");
    }
}