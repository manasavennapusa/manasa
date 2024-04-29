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

            bind_departmnt();


            if (Session["role"] != null)
            {
                //drpdepartment.Items.Insert(0, new ListItem("---Select Department---", "0"));
                //if (Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                   // Response.Redirect("~/Authenticate.aspx");
            }
            else
                Response.Redirect("~/notlogged.aspx");
        }
    }

    public void btnsv_Click(object sender, EventArgs e)
    {
        insert_department_detail();
    }
    #region Bind Department
    protected void bind_departmnt()
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            DropDownList1.DataTextField = "department_name";
            DropDownList1.DataValueField = "departmentid";
            DropDownList1.DataSource = ds1;
            DropDownList1.DataBind();

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

    //protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    //}
    //protected void drpbranch_DataBound(object sender, EventArgs e)
    //{
    //    drpbranch.Items.Insert(0, new ListItem("---Select Work Location---", "0"));
    //}
    //protected void drpdepartment_DataBound(object sender, EventArgs e)
    //{
    //    drpdepartment.Items.Insert(0, new ListItem("---Select Department---", "0"));
    //}
    protected void insert_department_detail()
    {
        //@designationname varchar(50),
        //@description varchar(500)
        SqlParameter[] sqlparam = new SqlParameter[3];

        sqlparam[0] = new SqlParameter("@designationname", SqlDbType.VarChar, 50);
        sqlparam[0].Value = txt_branch_name.Text;

        sqlparam[1] = new SqlParameter("@description", SqlDbType.VarChar, 500);
        sqlparam[1].Value = txt_branch_code.Text;

        sqlparam[2] = new SqlParameter("@deptid", SqlDbType.Int);
        sqlparam[2].Value = DropDownList1.SelectedValue;


        // ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_designation", sqlparam);
        int i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_insert_designation", sqlparam);


        if (i <= 0)
        {
            Common.Console.Output.Show( "Designation name already exists, please enter another name");
        }
        else
        {
            Common.Console.Output.Show("Created Successfully");
            reset();
        }
    }

    protected void reset()
    {
        txt_branch_code.Text = "";
        txt_branch_name.Text = "";
        //drpbranch.SelectedValue = "0";
        DropDownList1.SelectedValue = "0";
    }
    protected void btnreset_Click(object sender, EventArgs e)
    {
        reset();
    }
    //protected void drpdepartment_DataBound1(object sender, EventArgs e)
    //{
    //    drpdepartment.Items.Insert(0, new ListItem("---Select Work Location---", "0"));
    //}
    //protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    //}
    protected void DropDownList1_DataBound(object sender, EventArgs e)
    {
        DropDownList1.Items.Insert(0, new ListItem("--Select--", "0"));
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_departmnt(Convert.ToInt16(DropDownList1.SelectedValue));
    }
}
