using System;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Data;
using System.Web.UI.WebControls;

public partial class attendance_shiftmapping : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
        }
        else { }

        if (!IsPostBack)
        {
            BindBranch(Convert.ToInt32(CompanyId));
        }
    }

    protected void BindBranch(int companyId)
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select branch_id, branch_name from tbl_intranet_branch_detail";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            ddl_branch.DataSource = ds;
            ddl_branch.DataTextField = "branch_name";
            ddl_branch.DataValueField = "branch_id";
            ddl_branch.DataBind();
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }

    }

    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        Upload();
    }

    private bool Upload()
    {
        bool Flag = true;
        try
        {
            if (fileUpload.HasFile)
            {
                Common.Data.Excel Excel = new Common.Data.Excel();
                OleDbConnection Connection = null;
                string Extension = Excel.GetFileExtension(fileUpload.FileName);
                string PathName = "";
                try
                {
                    if (Extension == ".xls" || Extension == ".xlsx")
                    {
                        string filename = Path.GetFileName(fileUpload.FileName);
                        PathName = Server.MapPath("~/Attendance/Upload/") + filename;
                        System.IO.File.Delete(PathName);
                        fileUpload.SaveAs(PathName);

                        Connection = Excel.OpenExcelConnection(PathName);
                        DataSet ds = Excel.ReadExcelData("SELECT * FROM [Sheet1$]", Connection);
                        Excel.CloseConnection();
                        DataTable dt = ds.Tables[0];
                        Save(dt);
                    }
                    else
                    {
                        Flag = false;
                        Common.Console.Output.Show("Invalid file. Please select choose file.");
                    }
                }
                catch (Exception ex)
                {
                    Flag = false;

                    if (Connection.State == ConnectionState.Open)
                        Excel.CloseConnection();
                    Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
                }
                finally
                {

                }
            }
        }
        catch
        {

        }
        finally
        {

        }

        return Flag;
    }

    private bool EmployeeExists(string empcode)
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity DA = new Common.Data.DataActivity();

        Connection = DA.OpenConnection();
        DA.CloseConnection();
        string query = @"select *
 from tbl_intranet_employee_jobDetails where empcode = '" + empcode + "' and branch_id = '" + ddl_branch.SelectedValue + "'";

        DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);

        DA.CloseConnection();
        if (ds.Tables[0].Rows.Count > 0)
            return true;
        else
            return false;
    }

    private void Save(DataTable dt)
    {
        SqlConnection _Connection = new SqlConnection();
        Common.Data.DataActivity _DA = new Common.Data.DataActivity();
        string Query = "sp_leave_shift_mapping";
        try
        {
            _Connection = _DA.OpenConnection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["EmpCode"].ToString().Trim() != "")
                {
                    if (EmployeeExists(dt.Rows[i]["EmpCode"].ToString().Trim()))
                    {
                        SqlParameter[] parm = new SqlParameter[3];

                        Common.Console.Output.AssignParameter(parm, 0, "@empcode", "String", 50, dt.Rows[i]["EmpCode"].ToString().Trim());
                        Common.Console.Output.AssignParameter(parm, 1, "@shiftid", "Int", 0, dt.Rows[i]["ShiftCode"].ToString().Trim());
                        Common.Console.Output.AssignParameter(parm, 2, "@user", "String", 50, UserCode);

                        int Flag = Common.Data.SQLServer.ExecuteNonQuery(_Connection, CommandType.StoredProcedure, Query, parm);
                    }
                }
            }

            BindBranch(Convert.ToInt32(CompanyId));
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            _DA.CloseConnection();
        }

    }

    protected void ddl_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity DA = new Common.Data.DataActivity();

        Connection = DA.OpenConnection();
        DA.CloseConnection();
        string query = @"select E.empcode, 
E.emp_fname + ' '+ isnull(E.emp_m_name,'') +' '+isnull(E.emp_l_name,'') name,
E.dept_id,
D.department_name,
S.shiftid,
F.shiftname,
cast(F.starttime as time) starttime,
cast(F.endtime  as time) endtime
 from tbl_intranet_employee_jobDetails E
  inner join tbl_employee_shift_mapping S on E.empcode = S.empcode and S.status = 1
  inner join tbl_leave_shift F on S.shiftid = F.shiftid and F.status = 1
  left join tbl_internate_departmentdetails D on D.departmentid = E.dept_id
   where E.branch_id = '" + ddl_branch.SelectedValue + "' order by empcode";

        DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
        DA.CloseConnection();

        if (ds.Tables[0].Rows.Count > 0)
        {
            shiftgrid.DataSource = ds;
            shiftgrid.DataBind();
        }
        else
        {
            shiftgrid.DataSource = null;
            shiftgrid.DataBind();
        }
    }

    protected void ddl_branch_DataBound(object sender, EventArgs e)
    {
        ddl_branch.Items.Insert(0, new ListItem("--Select--", "0"));
    }
}
