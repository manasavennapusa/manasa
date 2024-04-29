using System;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Data.SqlClient;
public partial class leave_reportemployeereporteesdetails : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            drpdepartment.Items.Insert(0, new ListItem("All", "0"));
            drpdegination.Items.Insert(0, new ListItem("All", "0"));
            bindempoloyee();
        }
    }
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }

    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' ";
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
            sqlstr = "select  id,designationname FROM tbl_intranet_designation where tbl_intranet_designation.departmentid=" + deptid;
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

    public void bindempoloyee()
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = @"select coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,tbl_intranet_employee_jobDetails.empcode,tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,
            tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name
            from tbl_intranet_employee_jobDetails 
            INNER JOIN tbl_intranet_designation on tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id
            INNER JOIN tbl_intranet_branch_detail on tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_Id 
            where  emp_doleaving is null ";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
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

    
    protected void btn_search_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            sqlstr = "";
            sqlstr = @"select coalesce(tbl_intranet_employee_jobDetails.emp_fname,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_m_name,'') + ' ' + coalesce(tbl_intranet_employee_jobDetails.emp_l_name,'') as name ,
        tbl_intranet_employee_jobDetails.empcode as empcode,tbl_intranet_employee_jobDetails.degination_id,tbl_intranet_designation.designationname,
        tbl_intranet_employee_jobDetails.branch_id,tbl_intranet_branch_detail.branch_name                
        from tbl_intranet_employee_jobDetails 
        INNER JOIN tbl_intranet_designation on tbl_intranet_employee_jobDetails.degination_id=tbl_intranet_designation.id
        INNER JOIN tbl_intranet_branch_detail on tbl_intranet_employee_jobDetails.branch_id=tbl_intranet_branch_detail.Branch_id 
        WHERE 1=1 and emp_doleaving is null";


            if (txt_employee.Text != "")
            {
                sqlstr = sqlstr + " and empcode='" + txt_employee.Text + "'";
                // sqlstr = sqlstr + " AND emp_fname '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or empcode like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_m_name + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%' or emp_fname + ' ' + emp_m_name + ' ' + emp_l_name like '%" + txt_employee.Text.Replace("'", "''").Trim().ToString() + "%'";
            }

            if (drpbranch.SelectedIndex != 0)
            {
                sqlstr = sqlstr + " AND tbl_intranet_employee_jobDetails.branch_id = '" + drpbranch.SelectedValue + "'";
            }

            if (drpdegination.SelectedIndex != 0)
            {
                sqlstr = sqlstr + " AND tbl_intranet_employee_jobDetails.degination_id ='" + drpdegination.SelectedValue + "'";
            }
            if (drpdepartment.SelectedIndex != 0)
            {
                sqlstr = sqlstr + " AND tbl_intranet_employee_jobDetails.dept_id ='" + drpdepartment.SelectedValue + "'";
            }

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
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

    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }
    protected void empgrid_PreRender(object sender, EventArgs e)
    {
        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;

    }
}
