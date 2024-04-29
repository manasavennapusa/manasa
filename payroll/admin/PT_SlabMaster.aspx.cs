using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer;
using System.Configuration;

public partial class payroll_admin_PT_SlabMaster : System.Web.UI.Page
{

    DataTable dtable;
    string CompanyId, UserCode;
    protected void Page_Load(object sender, EventArgs e)
    {

        UserCode = Session["empcode"].ToString();
        CompanyId = Session["companyid"].ToString();


        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            if (Session["PTslab"] != null)
            {
                Session.Remove("PTslab");
            }

            bindState();
           
        }



    }

    private void bindState()
    {

        try
        {
            string query = "select ID,state from tbl_intranet_state_master where Country='India'";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);

            ddl_state.DataTextField = "state";
            ddl_state.DataValueField = "ID";
            ddl_state.DataSource = ds;
            ddl_state.DataBind();

        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    private void bindptslabs()
    {

        try
        {
            string query = "select * from tbl_payroll_pt where status=1";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
            grd_ptslabs.DataSource = ds;
            grd_ptslabs.DataBind();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void ddl_state_DataBound(object sender, EventArgs e)
    {
        ddl_state.Items.Insert(0, new ListItem("----Select---", "0"));
    }
    protected void ddl_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int sid = Convert.ToInt32(ddl_state.SelectedValue);

            string query = @"select pt.state_id,pt.from_date,pt.to_date,ptr.from_amount,ptr.to_amount, ptr.rate,st.state from tbl_payroll_pt pt
inner join tbl_payroll_pt_range ptr on ptr.pt_id= pt.id inner join tbl_intranet_state_master st on st.ID=pt.state_id where  pt.state_id=" + sid + " and pt.status=1";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query);
            if (Session["PTslab"] == null)
            {
                createatable();
            }
            DataRow dr;

            dtable = (DataTable)Session["PTslab"];
            if (dtable.Rows.Count > 0)
                if (sid != Convert.ToInt32(dtable.Rows[0]["StateId"]))
                    dtable.Rows.Clear();

            for (int i = 0; ds.Tables[0].Rows.Count > i; i++)
            {
                dr = dtable.NewRow();
                dr["StateId"] = ds.Tables[0].Rows[i]["state_id"].ToString();
                dr["State"] = ds.Tables[0].Rows[i]["state"].ToString();
                dr["FromDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["from_date"].ToString()).ToString("M/d/yyyy");
                dr["ToDate"] = Convert.ToDateTime(ds.Tables[0].Rows[i]["to_date"].ToString()).ToString("M/d/yyyy");
                dr["Amountfrom"] = ds.Tables[0].Rows[i]["from_amount"].ToString();
                dr["AmountTo"] = ds.Tables[0].Rows[i]["to_amount"].ToString();
                dr["TaxRate"] = ds.Tables[0].Rows[i]["rate"].ToString();
                dtable.Rows.Add(dr);
            }
            Session["PTslab"] = dtable;
            bindPT_slab();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {

        int id = Convert.ToInt32(Request.QueryString["id"]);
        int Flag = 0;
        deletePreviousData();
        try
        {


            int sid = Convert.ToInt32(ddl_state.SelectedValue);
            int ptid = 0;
            if (Session["PTslab"] != null)
            {
                dtable = (DataTable)Session["PTslab"];
                if (dtable.Rows.Count > 0)
                {
                    for (int i = 0; i < dtable.Rows.Count; i++)
                    {
                        SqlParameter[] param1 = new SqlParameter[6];

                        param1[0] = new SqlParameter("@stateid", SqlDbType.Int);
                        param1[0].Value = ddl_state.SelectedValue;

                        param1[1] = new SqlParameter("@fromdate", SqlDbType.DateTime);
                        param1[1].Value = dtable.Rows[i]["FromDate"].ToString();

                        param1[2] = new SqlParameter("@todate", SqlDbType.DateTime);
                        param1[2].Value = dtable.Rows[i]["ToDate"].ToString();

                        param1[3] = new SqlParameter("@created_by", SqlDbType.VarChar, 100);
                        param1[3].Value = dtable.Rows[i]["ToDate"].ToString();

                        param1[4] = new SqlParameter("@id", SqlDbType.Int);
                        param1[4].Direction = ParameterDirection.Output;

                        param1[5] = new SqlParameter("@company_id", SqlDbType.Int);
                        param1[5].Value = CompanyId;

                        if (i == 0)
                        {
                            int fg = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Payroll_insert_ptslab", param1);
                            ptid = Convert.ToInt32(param1[4].Value);
                        }
                        else
                            if (dtable.Rows[i - 1]["FromDate"].ToString() != dtable.Rows[i]["FromDate"].ToString())
                            {
                                int fg = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Payroll_insert_ptslab", param1);
                                ptid = Convert.ToInt32(param1[4].Value);
                            }

                        if (ptid > 0)
                        {

                            SqlParameter[] param2 = new SqlParameter[4];

                            param2[0] = new SqlParameter("@pt_id", SqlDbType.Int);
                            param2[0].Value = ptid;

                            param2[1] = new SqlParameter("@fromamount", SqlDbType.Decimal);
                            param2[1].Value = dtable.Rows[i]["Amountfrom"].ToString();

                            param2[2] = new SqlParameter("@toamount", SqlDbType.Decimal);
                            param2[2].Value = dtable.Rows[i]["AmountTo"].ToString();

                            param2[3] = new SqlParameter("@taxrate", SqlDbType.Decimal);
                            param2[3].Value = dtable.Rows[i]["TaxRate"].ToString();

                            Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_Payroll_insert_ptrange", param2);

                        }
                        // message.InnerHtml = "PT Slab Details saved successfully.";

                    }
                }
            }
        }
        catch (Exception ex)
        {

        }


    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        ddl_state.SelectedIndex = 0;
        Session["PTslab"] = null;
        bindPT_slab();
        txtfromdate.Text = "";
        txttodate.Text = "";
        clear();

    }

    protected void addPTSlab()
    {
        DataRow dr;
        if (Session["PTslab"] == null)
        {
            createatable();

        }
        dtable = (DataTable)Session["PTslab"];

        dr = dtable.NewRow();

        dr["StateId"] = ddl_state.SelectedValue;
        dr["State"] = ddl_state.SelectedItem.Text;
        dr["FromDate"] = txtfromdate.Text.ToString();
        dr["ToDate"] = txttodate.Text.ToString();
        dr["Amountfrom"] = txtamountfrom.Text.ToString();
        dr["AmountTo"] = txtamountto.Text.ToString();
        dr["TaxRate"] = txtrate.Text.ToString();
        dtable.Rows.Add(dr);

        Session["ptslab"] = dtable;
        clear();
        bindPT_slab();
    }

    protected void createatable()
    {
        DataColumn id = new DataColumn();
        id.AllowDBNull = false;
        id.AutoIncrement = true;
        id.AutoIncrementSeed = 1;
        id.AutoIncrementStep = 1;
        id.ColumnName = "autoID";
        id.DataType = System.Type.GetType("System.Int32");
        id.Unique = true;
        dtable = new DataTable();
        dtable.Columns.Add(id);
        dtable.PrimaryKey = new DataColumn[] { dtable.Columns["autoID"] };
        dtable.Columns.Add("StateId", typeof(string));
        dtable.Columns.Add("State", typeof(string));
        dtable.Columns.Add("FromDate", typeof(string));
        dtable.Columns.Add("ToDate", typeof(string));
        dtable.Columns.Add("Amountfrom", typeof(string));
        dtable.Columns.Add("AmountTo", typeof(string));
        dtable.Columns.Add("TaxRate", typeof(string));
        Session["PTslab"] = dtable;
    }

    protected void bindPT_slab()
    {
        dtable = (DataTable)Session["PTslab"];
        grd_ptslabs.DataSource = dtable;
        grd_ptslabs.DataBind();
    }

    protected void grd_ptslabs_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        dtable = (DataTable)Session["PTslab"];
        DataRow drfind_PTS = dtable.Rows.Find(Convert.ToString(grd_ptslabs.DataKeys[e.RowIndex].Value));
        if (drfind_PTS != null)
        {
            drfind_PTS.Delete();
            Session["PTslab"] = dtable;
            bindPT_slab();
        }
    }

    protected void clear()
    {
        txtamountfrom.Text = "";
        txtamountto.Text = "";
        //txtfromdate.Text = "";
        //txttodate.Text = "";
        txtrate.Text = "";
        //ddl_state.SelectedValue = "0";
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        addPTSlab();
    }

    protected bool deletePreviousData()
    {
        int id = Convert.ToInt32(Request.QueryString["id"]);
        int Flag = 0;
        try
        {
            int sid = Convert.ToInt32(ddl_state.SelectedValue);

            string query1 = @"delete from tbl_payroll_pt_range where pt_id in (select id from tbl_payroll_pt where state_id=" + ddl_state.SelectedValue + ")";

            int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query1);

            string query2 = @" Delete from tbl_payroll_pt where state_id=" + ddl_state.SelectedValue + "";

            Flag = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query2);

            if (Flag > 0)
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

}
