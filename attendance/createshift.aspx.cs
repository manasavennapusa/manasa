using System;
using System.Globalization;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Data.OleDb;
using System.IO;
public partial class attendance_createshift : System.Web.UI.Page
{
    string _companyId, _userCode;
    DataSet _ds = new DataSet();
    SqlConnection _connection;
    Common.Data.DataActivity Activity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();

            if (!IsPostBack)
            {
                BindBranch(Convert.ToInt32(_companyId));
                BindShifts(Convert.ToInt32(_companyId));

                if (Request.QueryString["updated"] != null)
                    Common.Console.Output.Show("Shift updated successfully.");
                if (Request.QueryString["save"] != null)
                    Common.Console.Output.Show("Shift Created Successfully.");
                if (Request.QueryString["upload"] != null)
                    Common.Console.Output.Show("Shift Uploaded Successfully.");
            }
            Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime'))");
            Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime'))");
        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }

    //====================  Created by Ramu nunna on 16-9-2014 Purpose of Create shift =============================


    #region Save the Shift Details
    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        var parm = new SqlParameter[10];
        SqlTransaction transaction = null;
        var activity = new DataActivity();
        int flag = 0;
        try
        {
            Output.AssignParameter(parm, 0, "@shiftname", "String", 100, txtshift.Text);
            Output.AssignParameter(parm, 1, "@company_id", "Int", 0, _companyId);
            Output.AssignParameter(parm, 2, "@branch_id", "Int", 0, ddbranch_id.SelectedValue);
            Output.AssignParameter(parm, 3, "@starttime", "DateTime", 0, "1900-01-01 " + hide1.Value);
            Output.AssignParameter(parm, 4, "@endtime", "DateTime", 0, "1900-01-01 " + hide2.Value);
            Output.AssignParameter(parm, 5, "@createddate", "DateTime", 0, DateTime.Now.ToString());
            Output.AssignParameter(parm, 6, "@createdby", "String", 100, _userCode);
            Output.AssignParameter(parm, 7, "@modifiedby", "String", 100, _userCode);
            Output.AssignParameter(parm, 8, "@shift_description", "String", 200, txtshiftDesc.Text);
            Output.AssignParameter(parm, 9, "@date_type", "String", 3, ddlDateType.SelectedValue);
            SqlConnection connection = activity.OpenConnection();
            transaction = connection.BeginTransaction();
            flag = SQLServer.ExecuteNonQuery(connection, CommandType.StoredProcedure, transaction, "sp_leave_createshift", parm);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (flag > 0)
        {

           // Output.Show("Shift Created Successfully");
            Clearfield();
            Response.Redirect("createshift.aspx?save=true");
        }
        else
        {
            Output.Show("Shift already exists, try again.");
        }

    }
    #endregion
    #region Reset the Fields
    protected void btn_reset_Click(object sender, EventArgs e)
    {
        Clearfield();
    }

    private void Clearfield()
    {
        txtetime.Text = "";
        txtstime.Text = "";
        txtshift.Text = "";
        ddbranch_id.SelectedValue = "0";
        txtshiftDesc.Text = "";
        ddlDateType.SelectedValue = "ST";

    }
    protected void ddbranch_DataBound(object sender, EventArgs e)
    {
        ddbranch_id.Items.Insert(0, new ListItem("--Select Work Location--", "0"));
    }

    #endregion


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
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }
    }

    protected void ddl_branch_DataBound(object sender, EventArgs e)
    {
        ddl_branch.Items.Insert(0, new ListItem("--Select--", "0"));
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
            Response.Redirect("createshift.aspx?upload=true");
        }

        return Flag;
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
                        Common.Console.Output.AssignParameter(parm, 2, "@user", "String", 50, _userCode);

                        int Flag = Common.Data.SQLServer.ExecuteNonQuery(_Connection, CommandType.StoredProcedure, Query, parm);
                    }
                }
            }

            BindBranch(Convert.ToInt32(_companyId));
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

    protected void ddselbranch_DataBound(object sender, EventArgs e)
    {
        ddselbranch.Items.Insert(0, new ListItem("For all WorkLocations", "0"));
    }

    protected void ddselbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindshift(Convert.ToInt32(ddselbranch.SelectedValue));
    }

    private void Bindshift(int branchid)
    {

        try
        {
            _connection = Activity.OpenConnection();
            string query = "";
            if (branchid == 0)
                query = "select shiftid,shiftname,branch_name, right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1";
            else
                query = "select shiftid,shiftname,branch_name, right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1 and tbl_intranet_branch_detail.branch_id='" + branchid + "'";
            _ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, query);
            shiftgrid.DataSource = _ds;
            shiftgrid.DataBind();

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

    protected void shiftgrid_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Response.Redirect("Updateshift.aspx?shiftid=" + Convert.ToInt32(Request.QueryString["shiftid"]) + "");
    }

    protected void shiftgrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int i = 0;
        try
        {
            _connection = Activity.OpenConnection();
            var dataKey = shiftgrid.DataKeys[e.RowIndex];
            if (dataKey != null)
            {
                int a = (int)dataKey.Value;
                string query = "UPDATE tbl_leave_shift SET status='0' where shiftid=" + a + "";
                i = Common.Data.SQLServer.ExecuteNonQuery(_connection, CommandType.Text, query);
            }
            BindShifts(Convert.ToInt32(Session["companyid"].ToString()));
            //bindshift();

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
        if (i > 0)
        {
            Common.Console.Output.Show("Shift Deleted successfully.");
        }


    }

    protected void shiftgrid_PreRender(object sender, EventArgs e)
    {

        if (shiftgrid.Rows.Count > 0)
            shiftgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    private void BindShifts(int companyId)
    {
        try
        {
            _connection = Activity.OpenConnection();
            string query = "select shiftid,shiftname,branch_name, right(convert(varchar(50),starttime),7)starttime,right(convert(varchar(50),endtime),7)endtime,shift_description from tbl_leave_shift inner join tbl_intranet_branch_detail on tbl_intranet_branch_detail.branch_id=tbl_leave_shift.branch_id where tbl_leave_shift.status=1";
            _ds = Common.Data.SQLServer.ExecuteDataset(_connection, CommandType.Text, query);
            shiftgrid.DataSource = _ds;
            shiftgrid.DataBind();

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
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}
