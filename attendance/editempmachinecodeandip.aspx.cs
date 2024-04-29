using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using Common.Console;

public partial class attendance_editempmachinecodeandip : System.Web.UI.Page
{
    string CompanyId, UserCode, RoleId;
    int iferror = 0;
    string error = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = "2";
            RoleId = Session["role"].ToString();

            if (!IsPostBack)
            {
                ddl_ip.Items.Insert(0, new ListItem("--All--", "0"));
                BindBranch(Convert.ToInt32(CompanyId));
                if (Request.QueryString["update"] != null)
                    Common.Console.Output.Show("Records uploaded succussfully.");
            }
        }
        else
        {
            Response.Redirect("../LogOut.aspx");
        }

    }

    private void BindIPAddress(int companyId, int branchid)
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = "select * from tbl_attendance_ip where companyid=" + companyId + " and status=1 and branchid=" + dd_branch.SelectedValue;
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            ddl_ip.DataSource = ds;
            ddl_ip.DataTextField = "deviceips";
            ddl_ip.DataValueField = "id";
            ddl_ip.DataBind();
            ddl_ip.Items.Insert(0, new ListItem("--All--", "0"));
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

    protected void BindBranch(int companyId)
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select branch_id, branch_name from tbl_intranet_branch_detail union select 0 as branch_id, '--All--' as branch_name";         
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            dd_branch.DataSource = ds;
            dd_branch.DataTextField = "branch_name";
            dd_branch.DataValueField = "branch_id";
            dd_branch.DataBind();
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

    private void BindDetails()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select distinct '" + txt_employee.Text.Trim() + "' as empcode,branch_name,deviceips,machinecode from tbl_attendance_ip";
            query += @" inner join tbl_intranet_branch_detail on  tbl_intranet_branch_detail.branch_id=  tbl_attendance_ip.branchid                                       
                                    left  join  tbl_attendance_empipenrollno_mapping    on tbl_attendance_ip.deviceips=tbl_attendance_empipenrollno_mapping.ip     
                                          and tbl_attendance_empipenrollno_mapping.empcode='" + txt_employee.Text.Trim() + "' where tbl_attendance_ip.status=1";
            if (dd_branch.SelectedValue != "0")
                query += " and tbl_attendance_ip.branchid=" + dd_branch.SelectedValue;
            if (ddl_ip.SelectedValue != "0")
                query += " and tbl_attendance_ip.deviceips='" + ddl_ip.SelectedItem.Text.ToString() + "'";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            ipgrid.DataSource = ds;
            ipgrid.DataBind();

            update.Visible = true;
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
        BindDetails();
    }

    protected void dd_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindIPAddress(Convert.ToInt32(CompanyId), Convert.ToInt32(dd_branch.SelectedValue));
    }

    protected void ipgrid_PreRender(object sender, EventArgs e)
    {

    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {

        SqlConnection Connection = null;
        SqlTransaction transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            Connection = Activity.OpenConnection();
            transaction = Connection.BeginTransaction();
            foreach (GridViewRow GridView in ipgrid.Rows)
            {
                Label ip = (Label)GridView.FindControl("ip");
                var empcode = txt_employee.Text.Trim().ToString();
                TextBox enrollno = (TextBox)GridView.FindControl("txtenrollno");
                var companyid = CompanyId;
                if ((enrollno.Text != null) && (enrollno.Text != ""))
                {
                    SqlParameter[] parm = new SqlParameter[5];

                    Common.Console.Output.AssignParameter(parm, 0, "@ip", "String", 50, ip.Text.ToString());
                    Common.Console.Output.AssignParameter(parm, 1, "@empcode", "String", 50, empcode.ToString());
                    Common.Console.Output.AssignParameter(parm, 2, "@machinecode", "String", 50, enrollno.Text.ToString());
                    Common.Console.Output.AssignParameter(parm, 3, "@companyId", "Int", 50, companyid.ToString());
                    Common.Console.Output.AssignParameter(parm, 4, "@usercode", "String", 50, UserCode.ToString());
                    SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, transaction, "sp_leave_insert_enrolldetails", parm);
                }
            }
            transaction.Commit();
            BindDetails();
        }
        catch (Exception ex)
        {
            transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {
            Activity.CloseConnection();
            Response.Redirect("editempmachinecodeandip.aspx?update=true");
        }
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Upload();
    }

    public bool Upload()
    {
        bool Flag = false;
        if (EDBfileupload.HasFile)
        {
            Common.Data.Excel Excel = new Common.Data.Excel();
            OleDbConnection Connection = null;
            string Extension = Excel.GetFileExtension(EDBfileupload.FileName);
            string PathName = "";

            try
            {
                if (Extension == ".xls" || Extension == ".xlsx")
                {
                    string filename = Path.GetFileName(EDBfileupload.FileName);
                    PathName = Server.MapPath("~/Attendance/Upload/") + filename;
                    System.IO.File.Delete(PathName);
                    EDBfileupload.SaveAs(PathName);

                    Connection = Excel.OpenExcelConnection(PathName);


                    DataTable[] dt = new DataTable[1];

                    dt[0] = Excel.ReadExcelData("SELECT * FROM [Sheet1$]", Connection).Tables[0];
                    Excel.CloseConnection();

                    SaveDetails(dt);

                    if (iferror > 0)
                    {
                        Flag = false;

                    }
                    else
                    {
                        Flag = true;
                    }
                }
                else
                {
                    Common.Console.Output.Show("Invalid file. Please select choose file.");
                }

            }
            catch (Exception ex)
            {
                if (Connection.State == ConnectionState.Open)
                    Excel.CloseConnection();
                Common.Console.Output.Log("During Employee Upload: " + ex.Message + ".    " + DateTime.Now);
            }
            finally
            {
                if (Connection.State == ConnectionState.Open)
                    Excel.CloseConnection();
            }
        }

        return Flag;

    }

    private void SaveDetails(DataTable[] dtIp)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        DataActivity DA = new DataActivity();
        DataSet ds = null;

        string Query = @"sp_attendance_saveempipmachineno";

        try
        {
            Connection = DA.OpenConnection();
            _Transaction = Connection.BeginTransaction();
            foreach (DataRow row in dtIp[0].Rows)
            {
                SqlParameter[] p = new SqlParameter[5];

                Common.Console.Output.AssignParameter(p, 0, "@empcode", "String", 50, row["EmpCode"].ToString().Trim());
                Common.Console.Output.AssignParameter(p, 1, "@ip", "String", 50, row["IP"].ToString().Trim());
                Common.Console.Output.AssignParameter(p, 2, "@machinecode", "String", 50, row["MachineCode"].ToString().Trim());
                Common.Console.Output.AssignParameter(p, 3, "@companyId", "Int", 0, CompanyId);
                Common.Console.Output.AssignParameter(p, 4, "@usercode", "String", 50, UserCode);

                ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, _Transaction, Query, p);

                DataRow rowmsg = ds.Tables[0].Rows[0];
                if (rowmsg["msg"].ToString().Trim() == "Update")
                {
                }
                else if (rowmsg["msg"].ToString().Trim() == "Insert")
                {
                }
                else if (rowmsg["msg"].ToString().Trim() == "IP")
                {
                    error += Common.Console.Output.Log("Employee Code : " + row["EmpCode"].ToString().Trim() + "                   IP : " + row["IP"].ToString().Trim() + "                   Error Message : IP does not exists.");
                }
                else if (rowmsg["msg"].ToString().Trim() == "EmpCode")
                {
                    error += Common.Console.Output.Log("Employee Code : " + row["EmpCode"].ToString().Trim() + "                   Error Message : Employee code does not exists.");
                }
            }

            if (error != "")
            {
                diverror.InnerHtml = error;
                Output.Show("Records uploaded succussfully with warnings.");
            }
            else
            {
                Output.Show("Records uploaded succussfully.");
            }

            _Transaction.Commit();
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DA.CloseConnection();
        }
    }
}
