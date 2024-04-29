using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;

public partial class attendance_generatemonthlyattendancereport : System.Web.UI.Page
{
    string CompanyId, RoleId = "";
    string sqlstr;
    DataSet ds;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null && Session["role"] != null)
        {
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();


            if (!IsPostBack)
            {
                // month();
                Year();
            }
        }
        else {Response.Redirect("~/notlogged.aspx"); }
        drpdepartment.Items.Insert(0, new ListItem("All", "0"));

    }
    #region Bind Year

    private void Year()
    {
        ddlYear.Items.Clear();
        ddlYear.Items.Add(new ListItem("--Select Year--", "0"));

        for (int yr = 2014; yr <= DateTime.Now.Year; yr++)
        {
            ddlYear.Items.Add(new ListItem(Convert.ToString(yr)));
        }
    }
    #endregion
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
       // bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
        bind_departmenttype(Convert.ToInt32(drpbranch.SelectedValue));
    }

    //protected void bind_departmnt(int branchid)
    //{
    //    try
    //    {
    //        connection = activity.OpenConnection();
    //        string sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' ";
    //        DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

    //        drpdepartment.DataTextField = "department_name";
    //        drpdepartment.DataValueField = "departmentid";
    //        drpdepartment.DataSource = ds1;
    //        drpdepartment.DataBind();
    //    }
    //    catch (Exception ex)
    //    {
    //        Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
    //        Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
    //    }
    //    finally
    //    {
    //        activity.CloseConnection();
    //    }
    //}

    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void bind_departmenttype(int dept_type_id)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type where branch_id='" + dept_type_id + "' order by dept_type_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            ddldepatrtmenttype.DataTextField = "dept_type_name";
            ddldepatrtmenttype.DataValueField = "dept_type_id";
            ddldepatrtmenttype.DataSource = ds1;
            ddldepatrtmenttype.DataBind();
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

    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }


   
    protected void bindgrid()
    {
        string type = "0";
        string empcode = txt_employee.Text.Trim();
        string branch = drpbranch.SelectedValue;
        string depttype = ddldepatrtmenttype.SelectedValue;       
        string dept = drpdepartment.SelectedValue;
        string month = dd_month.SelectedValue;
        string year = ddlYear.SelectedValue;
        ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", "var Mleft = (screen.width/2)-(760/2);var Mtop = (screen.height/2)-(700/2);window.open( 'monthlyattendancereport.aspx?Branch=" + branch + "&DepartmentType" + depttype + "&Department=" + dept + "&Type=" + type + " &EmpCode=" + empcode + " &Month=" + month + "&Year=" + year + "', null, 'height=600,width=1260,status=yes,toolbar=no,scrollbars=yes,menubar=no,location=no,top=\'+Mtop+\', left=\'+Mleft+\'' );", true);
    }

    protected void dd_month_DataBound(object sender, EventArgs e)
    {
        dd_month.Items.Insert(0, new ListItem("--Select--", " 0"));
    }
   
    protected void btnreport_Click(object sender, EventArgs e)
    {
        bindgrid();
    }

    protected void ddldepatrtmenttype_DataBound(object sender, EventArgs e)
    {
        ddldepatrtmenttype.Items.Insert(0, new ListItem("--Select--", " 0"));
    }

    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE dept_type_id='" + branchid + "' order by department_name ";
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


    //protected void ddldepatrtmenttype_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //   
    //}

    protected void ddldepatrtmenttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(ddldepatrtmenttype.SelectedValue));
    }
}