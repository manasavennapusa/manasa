using System;
using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using DataAccessLayer;
using Common.Data;
using Common.Console;
using System.Web.UI.WebControls;
public partial class Admin_company_createcompany : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        message.InnerHtml = "";
        if (!IsPostBack)
        {
            bind_desigination_information();
            bind_departmnt();
            if (Session["role"] != null)
            {
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
            bind_desigination_information();
        }
    }
    #region Bind Department
    protected void bind_departmnt()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartment.DataTextField = "department_name";
            drpdepartment.DataValueField = "departmentid";
            drpdepartment.DataSource = ds1;
            drpdepartment.DataBind();

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    #endregion
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
       // bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
       // drpbranch.Items.Insert(0, new ListItem("---Select Work Location---", "0"));
    }
    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("---Select Department---", "0"));
    }
    protected void bind_desigination_information()
    {
        string id = Request.QueryString["id"].ToString();

//        string sqlstr = @"select tbl_intranet_designation.id,tbl_intranet_designation.departmentid,department_name,branch_name,tbl_internate_departmentdetails.branchid,designationname,description FROM tbl_intranet_designation
// inner join dbo.tbl_internate_departmentdetails on dbo.tbl_internate_departmentdetails.departmentid=tbl_intranet_designation.departmentid 
//inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid where tbl_intranet_designation.id = " + Request.QueryString["desigination_id"].ToString();

        string sqlstr = @"select 
tbl_intranet_designation.id,
tbl_intranet_designation.designationname,
tbl_internate_departmentdetails.departmentid,
tbl_intranet_designation.description
from tbl_intranet_designation
inner join tbl_internate_departmentdetails 
on tbl_internate_departmentdetails.departmentid=tbl_intranet_designation.departmentid where id=" + id;

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        drpdepartment.SelectedValue = ds.Tables[0].Rows[0]["departmentid"].ToString();
        txt_branch_name.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
        txt_branch_code.Text = ds.Tables[0].Rows[0]["description"].ToString(); ;
    }

    public void btnsv_Click(object sender, EventArgs e)
    {
        Edit_department_detail();
    }

    protected void Edit_department_detail()
    {
        string id = Request.QueryString["id"].ToString();
        SqlParameter[] sqlparam = new SqlParameter[4];

        sqlparam[0] = new SqlParameter("@designationname", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_branch_name.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_branch_code.Text;

        sqlparam[2] = new SqlParameter("@desigination_id", SqlDbType.Int);
        sqlparam[2].Value = Convert.ToInt32(id);

        sqlparam[3] = new SqlParameter("@deptid", SqlDbType.Int);
        sqlparam[3].Value = drpdepartment.SelectedValue;

        // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_edit_designation", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_intranet_edit_designation]", sqlparam);


        if (i <= 0)
        {
            message.InnerHtml = "Designation name already exists, please enter another name";
        }
        else
        {
            message.InnerHtml = "Transaction Completed Successfully!!!";

           // reset();

            Response.Redirect("desiginationview.aspx?updated=true");
        }
    }

    protected void reset()
    {
       // txt_branch_code.Text = "";
       // txt_branch_name.Text = "";
    }
    protected void DropDownList1_DataBound(object sender, System.EventArgs e)
    {

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }
    protected void btncancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("desiginationview.aspx");
    }
}
