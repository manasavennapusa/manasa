using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Travel_OOPExpense : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {

           // bindgrade();
            bindGrid();
            btncancel2.Visible = false;
            create1.Visible = true;
            create.Visible = true;
            edit1.Visible = false;
            edit.Visible = false;
            ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
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
                SmartHr.Common.Alert("OOP Expense Tariff Updated Successfully!!!");
            }
        }
       
    }

    protected void bind_Currency()
    {
        if (ddl_traveltype.SelectedValue == "D")
        {
            //string sqlstr = "select cid,countryname from tbl_intranet_country_master where cid=98";
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
            ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
           // ddlCurrecny.SelectedValue = "98";
            var itemIndex = ddlCurrecny.SelectedIndex;
            var item = ddlCurrecny.Items[itemIndex];
            ddlCurrecny.Items.RemoveAt(itemIndex);
            ddlCurrecny.Items.Insert(1, new ListItem(item.Text, item.Value));
            lblcurrenycode.Text = "";
        }

    }
    
    protected void grdtravelExpanse_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grdtravelExpanse.PageIndex = e.NewPageIndex;
        bindGrid();
    }
    
    protected void grdtravelExpanse_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = Convert.ToInt32(Request.QueryString["ID"]);
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = Convert.ToInt32(grdtravelExpanse.DataKeys[e.RowIndex].Value);

        param[1] = new SqlParameter("@gradeID", SqlDbType.Int);
        param[1].Value = 0;

        param[2] = new SqlParameter("@amount", SqlDbType.Decimal);
        param[2].Value = 0;

        param[3] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param[3].Value = "";

        param[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[4].Value = "";

        param[5] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[5].Value = "D";
        param[6] = new SqlParameter("@currencycode", SqlDbType.Int);
        param[6].Value = 0;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_OOPExpanse", param);

        if (i <= 0)
        {
            SmartHr.Common.Alert("OOP Expense Tariff Not Deleted Successfully!!!");
        }
        else
        {
            SmartHr.Common.Alert("OOP Expense  Tariff Deleted Successfully!!!");
            bindGrid();
        }

    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["ID"] == null)
        {
            insertdata();
            bindGrid();
            //clear();
        }
        else
        {
            updatedata();
           // bindGrid();
            Response.Redirect("OOPExpense.aspx?updated=true");
        }
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clear();
        if (Request.QueryString["ID"] != null)
        {
            Response.Redirect("OOPExpense.aspx");
        }
    }

    protected void insertdata()
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@ID", SqlDbType.Int);
        param[0].Value = 0;

        param[1] = new SqlParameter("@gradeID", SqlDbType.Int);
        param[1].Value = DBNull.Value;

        param[2] = new SqlParameter("@amount", SqlDbType.Decimal);
        param[2].Value = txtTariff.Text;

        param[3] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
        param[3].Value = ddl_traveltype.SelectedValue;

        param[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        param[4].Value = Session["empcode"].ToString();

        param[5] = new SqlParameter("@flag", SqlDbType.Char, 1);
        param[5].Value = "I";

        param[6] = new SqlParameter("@currencycode", SqlDbType.Int);
        param[6].Value = ddlCurrecny.SelectedValue;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_OOPExpanse", param);

        if (i <0)
        {
            SmartHr.Common.Alert("OOP Expense Tariff Not Inserted Successfully");
        }
        else
        {
            bindGrid();
            //clear();
            SmartHr.Common.Alert("OOP Expense Tariff Created Successfully!!!");
        }
    }
    
    protected void updatedata()
    {
        if (Request.QueryString["ID"] != null)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"]);
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = ID;

            param[1] = new SqlParameter("@gradeID", SqlDbType.Int);
            param[1].Value = DBNull.Value;

            param[2] = new SqlParameter("@amount", SqlDbType.Decimal);
            param[2].Value = txtTariff.Text;

            param[3] = new SqlParameter("@traveltype", SqlDbType.VarChar, 1);
            param[3].Value = ddl_traveltype.SelectedValue;

            param[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            param[4].Value = "";

            param[5] = new SqlParameter("@flag", SqlDbType.Char, 1);
            param[5].Value = "U";
            param[6] = new SqlParameter("@currencycode", SqlDbType.Int);
            param[6].Value = ddlCurrecny.SelectedValue;

            int flag=DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_travel_ins_upd_delete_OOPExpanse", param);
        }
    }
    
    protected void bindGrid()
    {

//        string sqlstr = @"select st.id,st.Amount,gd.gradename,st.traveltype,ctry.countryname,c.currencycode from  tbl_travel_OOPExpense st 
//                            inner join tbl_intranet_grade gd on gd.id=st.gradeID
//                            left join tbl_intranet_country_master ctry on ctry.cid=st.currencycode
//                            left join tbl_intranet_currencycode c on c.id=ctry.currencycode";
        string sqlstr = @"select st.id,
st.Amount,
--gd.gradename,
st.traveltype,
ctry.countryname,
c.currencycode from  tbl_travel_OOPExpense st 
--inner join tbl_intranet_grade gd on gd.id=st.gradeID
left join tbl_intranet_country_master ctry on ctry.cid=st.currencycode
left join tbl_intranet_currencycode c on c.id=ctry.currencycode";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdtravelExpanse.DataSource = ds;
        grdtravelExpanse.DataBind();
    }
    
    protected void bindData(string ID)
    {
        string sqlstr = @"select oop.*,c.currencycode as currency from tbl_travel_OOPExpense oop inner join tbl_intranet_country_master ctry on ctry.cid=oop.currencycode
                            left join tbl_intranet_currencycode c on c.id=ctry.currencycode where oop.id=" + ID + "";
        DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            ddl_grade.SelectedValue = ds.Tables[0].Rows[0]["gradeid"].ToString();
            txtTariff.Text = ds.Tables[0].Rows[0]["Amount"].ToString();
            ddl_traveltype.SelectedValue = ds.Tables[0].Rows[0]["traveltype"].ToString();
            bind_Currency();
            ddlCurrecny.SelectedValue = ds.Tables[0].Rows[0]["currencycode"].ToString();
            lblcurrenycode.Text = ds.Tables[0].Rows[0]["currency"].ToString();
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
       
    protected void clear()
    {
        ddl_grade.SelectedValue = "0";
        txtTariff.Text = "";
        ddl_traveltype.SelectedValue = "0";
        ddlCurrecny.Items.Clear();
        ddlCurrecny.Items.Insert(0, new ListItem("--Select--", "0"));
         lblcurrenycode.Text = "";
    }
    
    protected void grdtravelExpanse_PreRender(object sender, EventArgs e)
    {
        if (grdtravelExpanse.Rows.Count > 0)
        {
            grdtravelExpanse.UseAccessibleHeader = true;
            grdtravelExpanse.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void ddl_traveltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_Currency();
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
        Response.Redirect("~/Travel/OOPExpense.aspx");
    }
}