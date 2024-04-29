using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Encode;
using Common.Data;
using Common.Console;

public partial class admin_empviewbyhr : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            if (Request.QueryString["updated"] != null)
                SmartHr.Common.Alert("Employee Profile updated successfully");
            if (Request.QueryString["password"] != null)
                SmartHr.Common.Alert("No such employee exists");
            if (Request.QueryString["passwordreset"] != null)
                SmartHr.Common.Alert("Password reseted sucessfully");
            drpdepartment.Items.Insert(0, new ListItem("All", "0"));
            drpdegination.Items.Insert(0, new ListItem("All", "0"));
            dept_type.Items.Insert(0, new ListItem("All", "0"));
            bindempdetail();
        }

        if (Session["role"] != null)
        {

        }
        else
            Response.Redirect("~/notlogged.aspx");


    }
    protected void drprole_DataBound(object sender, EventArgs e)
    {
        drprole.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmenttype(Convert.ToInt16(drpbranch.SelectedValue));

        //bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }

    private void bind_departmenttype(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select dept_type_id,dept_type_name from tbl_internate_department_type WHERE branch_id='" + branchid + "' order by dept_type_name";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            dept_type.DataTextField = "dept_type_name";
            dept_type.DataValueField = "dept_type_id";
            dept_type.DataSource = ds1;
            dept_type.DataBind();
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


    #region Bind Department
    protected void bind_departmnt(int dept_type)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select departmentid,department_name from tbl_internate_departmentdetails where dept_type_id='" + dept_type + "' order by department_name";
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
    protected void drpdepartment_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_broadgroup(drpdepartment.SelectedValue);
        BindDesignation(drpdepartment.SelectedValue);
    }

    private void BindDesignation(string deptid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid + " order by designationname ";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                drpdegination.DataSource = ds;
                drpdegination.DataTextField = "designationname";
                drpdegination.DataValueField = "id";
                drpdegination.DataBind();
            }
            // drpdegination.Items.Insert(0, new ListItem("--Select--", "0"));
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

    protected void bindempdetail()
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
            sqlparam[0].Value = txt_employee.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = drpdegination.SelectedValue;

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = drpdepartment.SelectedValue;

            sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            sqlparam[3].Value = "All";

            sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
            if (drpbranch.SelectedValue != "")
                sqlparam[4].Value = drpbranch.SelectedValue;
            else
                sqlparam[4].Value = "0";

            sqlparam[5] = new SqlParameter("@role", SqlDbType.Int);
            sqlparam[5].Value = drprole.SelectedValue;


            sqlparam[6] = new SqlParameter("@departtype", SqlDbType.Int);
            sqlparam[6].Value = dept_type.SelectedValue;

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detail2", sqlparam);
            empgrid.DataSource = ds;
            empgrid.DataBind();

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

    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void dd_designation_DataBound(object sender, EventArgs e)
    {
        drpdegination.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void empgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int a = (int)empgrid.DataKeys[e.NewEditIndex].Value;
        Response.Redirect("createemployeeprofile.aspx?approvercode=" + Request.QueryString["approvercode"] + "");

    }
    protected void empgrid_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        //bindempdetail();

        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam = new SqlParameter[7];

            sqlparam[0] = new SqlParameter("@name", SqlDbType.VarChar, 150);
            sqlparam[0].Value = txt_employee.Text.Trim().ToString();

            sqlparam[1] = new SqlParameter("@desg", SqlDbType.Int);
            sqlparam[1].Value = drpdegination.SelectedValue;

            sqlparam[2] = new SqlParameter("@department", SqlDbType.Int);
            sqlparam[2].Value = drpdepartment.SelectedValue;

            sqlparam[3] = new SqlParameter("@status", SqlDbType.VarChar, 50);
            sqlparam[3].Value = "All";

            sqlparam[4] = new SqlParameter("@branch", SqlDbType.Int);
            if (drpbranch.SelectedValue != "")
                sqlparam[4].Value = drpbranch.SelectedValue;
            else
                sqlparam[4].Value = "0";

            sqlparam[5] = new SqlParameter("@role", SqlDbType.Int);
            sqlparam[5].Value = drprole.SelectedValue;


            sqlparam[6] = new SqlParameter("@departtype", SqlDbType.Int);
            sqlparam[6].Value = dept_type.SelectedValue;

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_leave_fetch_emp_detail4", sqlparam);
            
            empgrid.DataSource = ds;
            empgrid.DataBind();
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

    protected string linkreset(string id)
    {
        QueryString q = new QueryString();
        string pairs = String.Format("empcode={0}", id.Trim());
        string encoded;
        encoded = q.EncodePairs(pairs);
        return "<a class='link05' href='ResetPassword.aspx?q=" + encoded + "' >Reset</a>";
    }

    protected void empgrid_PreRender2(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
        {
            empgrid.UseAccessibleHeader = true;
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void dept_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(dept_type.SelectedValue));
    }
    protected void dept_type_DataBound(object sender, EventArgs e)
    {
        dept_type.Items.Insert(0, new ListItem("All", "0"));
    }
}