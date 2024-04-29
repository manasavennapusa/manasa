using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using DataAccessLayer;

public partial class Travel_KitAllowanceMaster : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            bindKitAllowance();
            btnupdate.Visible = false;

            if (Request.QueryString["Id"] != null)
            {
                Bindkitallowancedetails();
                btntier.Visible = false;
                btnupdate.Visible = true;
            }

        }
    }

    private void Bindkitallowancedetails()
    {

        int id = Convert.ToInt32(Request.QueryString["Id"]);
        sqlstr = "select kitallowance,create_date,status from tbl_travel_kitallowance_master where id="+id.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        txtKitAllowance.Text = ds.Tables[0].Rows[0]["kitallowance"].ToString();
        

    }

    private void bindKitAllowance()
    {
//        sqlstr = @"select id,kitallowance,create_date,J.emp_fname + isnull(J.emp_m_name,'') + isnull(J.emp_l_name,'') create_by ,K.status 
//
//from tbl_travel_kitallowance_master K inner join 
//tbl_intranet_employee_jobDetails J on K.create_by = J.empcode
//order by id desc ";

        sqlstr = @"select id,
kitallowance,
create_date,
K.create_by ,
K.status 
from tbl_travel_kitallowance_master K inner join 
tbl_intranet_employee_jobDetails J on K.create_by = J.empcode
order by id desc";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdkitallowance.DataSource = ds;
        grdkitallowance.DataBind();
    }

    protected void btntier_Click(object sender, EventArgs e)
    {
        string empcode = Session["empcode"].ToString();
        SqlParameter[] sqlParam = new SqlParameter[4];
        sqlParam[0] = new SqlParameter("@kitallowance", SqlDbType.Decimal);
        sqlParam[0].Value = txtKitAllowance.Text;
        sqlParam[1] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[1].Value = "I";
        sqlParam[2] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[2].Value = empcode;
        sqlParam[3] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[3].Value = 0;

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_kitallowanceMaster]", sqlParam);

        if (i <= 0)
        {
           // SmartHr.Common.Alert("Tier name already exists, please enter another name");
        }
        else
        {
            SmartHr.Common.Alert("Kit Allowance Created Successfully!!!");
            txtKitAllowance.Text = "";
            bindKitAllowance();
        }
    }

    protected void grdkitallowance_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlParameter[] sqlParam = new SqlParameter[4];
        int id = Convert.ToInt32(grdkitallowance.DataKeys[e.RowIndex].Value);
        
        sqlParam[0] = new SqlParameter("@kitallowance", SqlDbType.Decimal);
        sqlParam[0].Value = "";
        sqlParam[1] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[1].Value = "D";
        sqlParam[2] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[2].Value = id;
        sqlParam[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = "";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_kitallowanceMaster]", sqlParam);
        if (i <= 0)
        {
            //SmartHr.Common.Alert("Tier name already exists, please enter another name");
        }
        else
        {
            bindKitAllowance();
            btntier.Visible = true;
            btnupdate.Visible = false;
            SmartHr.Common.Alert("Kit Allowance Deleted Successfully!!!");
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

        SqlParameter[] sqlParam = new SqlParameter[4];
        int Tid = Convert.ToInt32(Request.QueryString["Id"]);

        sqlParam[0] = new SqlParameter("@kitallowance", SqlDbType.Decimal);
        sqlParam[0].Value = txtKitAllowance.Text;
        sqlParam[1] = new SqlParameter("@flag", SqlDbType.Char, 1);
        sqlParam[1].Value = "U";
        sqlParam[2] = new SqlParameter("@id", SqlDbType.Int);
        sqlParam[2].Value = Tid;
        sqlParam[3] = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
        sqlParam[3].Value = "";

        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_Travel_insert_kitallowanceMaster]", sqlParam);

        if (i <= 0)
        {
            //SmartHr.Common.Alert("Tier name already exists, please enter another name");
        }
        else
        {
            SmartHr.Common.Alert("Kit Allowance Update Successfully!!!");
            txtKitAllowance.Text = "";
            
            bindKitAllowance();
            btntier.Visible = true;
            btnupdate.Visible = false;
        }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        txtKitAllowance.Text = "";
        if (Request.QueryString["Id"] != null)
        {
            btntier.Visible = true;
            btnupdate.Visible = false;
        }

    }

    protected void grdkitallowance_PreRender(object sender, EventArgs e)
    {
        if (grdkitallowance.Rows.Count > 0)
        {
            grdkitallowance.UseAccessibleHeader = true;
            grdkitallowance.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}