using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Travel_TierMaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");

        if (!IsPostBack)
        {
            create.Visible = true;
            edit.Visible = false;
            create1.Visible = true;
            edit1.Visible = false;
            bindTier();
            btnupdate.Visible = false;
            btncancel2.Visible = false;

            if (Request.QueryString["Id"] != null)
            {
                BindTierdetails();
                btntier.Visible = false;
                btncancel.Visible = false;
                btnupdate.Visible = true;
                btncancel2.Visible = true;
            }

        }
    }

    private void BindTierdetails()
    {
        create.Visible = false;
        edit.Visible = true;
        create1.Visible = false;
        edit1.Visible = true;
        grid1.Visible = false;
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);
        sqlstr = "select tier,tierdesc from tbl_travel_Tier where status=1 and tierid='" + Tid + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txttier.Text = ds.Tables[0].Rows[0]["tier"].ToString();
        txttierDes.Text = ds.Tables[0].Rows[0]["tierdesc"].ToString();
       
    }

    private void bindTier()
    {
        create.Visible = true;
        edit.Visible = false;
        create1.Visible = true;
        edit1.Visible = false;
        grid1.Visible = true;
        sqlstr = "select tierid,tier,tierdesc from tbl_travel_Tier where status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdtiers.DataSource = ds;
        grdtiers.DataBind();
    }

    protected void btntier_Click(object sender, EventArgs e)
    {
        string empcode = Session["empcode"].ToString();
        SqlParameter[] sqlParam = new SqlParameter[5];

        sqlParam[0] = new SqlParameter("@tier", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txttier.Text;

        sqlParam[1] = new SqlParameter("@tierdesc", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txttierDes.Text;
        sqlParam[2] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[2].Value = "I";
        sqlParam[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = empcode;
        sqlParam[4] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[4].Value = 0;
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_TierMaster]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Domestic Tier name already exists, please enter another name");
            
        }
        else
        {
            SmartHr.Common.Alert("Domestic Tier Master Created Successfully!!!");

            txttier.Text = "";
            txttierDes.Text = "";
            bindTier();
        }
    }
   
    protected void grdtiers_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlParam = new SqlParameter[5];
        int Tid = Convert.ToInt32(grdtiers.DataKeys[e.RowIndex].Value);
        sqlParam[0] = new SqlParameter("@tier", SqlDbType.VarChar, 50);
        sqlParam[0].Value = "";

        sqlParam[1] = new SqlParameter("@tierdesc", SqlDbType.VarChar, 100);
        sqlParam[1].Value = "";
        sqlParam[2] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[2].Value = "D";
        sqlParam[3] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[3].Value = Tid;
        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = "";
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_TierMaster]", sqlParam);
        if (i > 0)
        {
            bindTier();
            btntier.Visible = true;
            btnupdate.Visible = false;
            SmartHr.Common.Alert("Domestic Tier Master Deleted Successfully!!!");
        }
        else
        {
            SmartHr.Common.Alert("Domestic Tier Master Not Deleted successfully!!!");
        }
      
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
       
        SqlParameter[] sqlParam = new SqlParameter[5];
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);

        sqlParam[0] = new SqlParameter("@tier", SqlDbType.VarChar, 50);
        sqlParam[0].Value = txttier.Text;

        sqlParam[1] = new SqlParameter("@tierdesc", SqlDbType.VarChar, 100);
        sqlParam[1].Value = txttierDes.Text;
        sqlParam[2] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[2].Value = "U";
        sqlParam[3] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[3].Value = Tid;
        sqlParam[4] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[4].Value = "";
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_TierMaster]", sqlParam);

        if (i <= 0)
        {
            SmartHr.Common.Alert("Domestic Tier name already exists, please enter another name");
            
        }
        else
        {
            SmartHr.Common.Alert("Domestic Tier Updated successfully!!!");

            txttier.Text = "";
            txttierDes.Text = "";
            bindTier();
            btntier.Visible = true;
            btnupdate.Visible = false;
            btncancel.Visible = true;
            btncancel2.Visible = false;
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        txttier.Text = "";
        txttierDes.Text = "";
        if (Request.QueryString["Id"] != null)
        {
            btntier.Visible = true;
            btnupdate.Visible = false;
        }

    }

    protected void grdtiers_PreRender(object sender, EventArgs e)
    {
        if (grdtiers.Rows.Count > 0)
        {
            grdtiers.UseAccessibleHeader = true;
            grdtiers.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btncancel2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Travel/TierMaster.aspx");
    }
}