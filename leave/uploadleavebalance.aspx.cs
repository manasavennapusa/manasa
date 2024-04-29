using System;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Data.OleDb;
using System.IO;

public partial class leave_uploadleavebalance : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DA = new DataActivity();
    string CompanyId, UserCode, _error = "";
    //============= Created by Ramu Nunna on Purpose of Upload Leave Balance & Approver List =============================//
    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        diverror.InnerText = "";
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
        }
        else { Response.Redirect("~/notlogged.aspx"); }

    }
    #endregion
    #region Validate the Leave Balance (Policy Id,Leave Id and Empcode)
    bool ValidateLeaveBalance(DataSet ds)
    {
        bool flag = true;

        foreach (DataRow dds in ds.Tables[0].Rows)
        {
            if (dds["Policy_id"].ToString() == "")
            {
                _error += "Policy Id is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Policy_id"].ToString() == "")
            {
                _error += "Policy Id is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Leave_id"].ToString() == "")
            {
                _error += "Leave id is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Emp_code"].ToString() == "")
            {
                _error += "Empcode is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Calenderid"].ToString() == "")
            {
                _error += "Calenderid is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            //if (dds["Month"].ToString() == "")
            //{
            //    _error += "Month is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
            //    flag = false; break;
            //}
            if (dds["Entitle_days"].ToString() == "")
            {
                _error += "Entitledays is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Used_days"].ToString() == "")
            {
                _error += "Useddays is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
        }

        return flag;
    }
    private bool IsValidateLeaveBalance(DataSet dsLeave)
    {
        DataTable dtEmp = dsLeave.Tables[0];
        SqlConnection Connection = DA.OpenConnection();
        try
        {
            string sqlstr = @"select  empcode from tbl_intranet_employee_jobDetails";
            DataSet dsEmp = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);

            string sqlstr1 = @"select  leaveid from tbl_leave_createleave where status=1";
            DataSet dsleave = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr1);

            string sqlstr2 = @"select  policyid from tbl_leave_createleavepolicy where status=1 ";
            DataSet dspolicy = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr2);

            //DataTable dtEmployee = new DataTable();
            foreach (DataRow row in dtEmp.Rows)
            {
                string exp = "policyid='" + row["Policy_id"].ToString().Trim() + "'";
                DataRow[] myrow = dspolicy.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Policy Id <font color='red'>" + row["Policy_id"].ToString() + "</font> doesn't exist. ";
                    return false;
                }
            }

            foreach (DataRow row in dtEmp.Rows)
            {
                string exp = "leaveid='" + row["Leave_id"].ToString().Trim() + "'";
                DataRow[] myrow = dsleave.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Leave Id <font color='red'>" + row["Leave_id"].ToString() + "</font> doesn't exist . ";
                    return false;
                }

            }

            foreach (DataRow row in dtEmp.Rows)
            {
                string exp = "empcode='" + row["Emp_code"].ToString().Trim() + "'";
                DataRow[] myrow = dsEmp.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Employee Code <font color='red'>" + row["Emp_code"].ToString() + "</font> doesn't exist.  ";
                    return false;
                }

            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log(" Error: " + ex.Message + " " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {

            DA.CloseConnection();
        }
        return true;
    }
    #endregion
    #region Validate the Approver List
    bool ValidateApproverList(DataSet ds)
    {
        bool flag = true;

        foreach (DataRow dds in ds.Tables[0].Rows)
        {
            if (dds["Emp_code"].ToString() == "")
            {
                _error += "Empcode is empty for row no." + (ds.Tables[0].Rows.IndexOf(dds)) + 1 + "";
                flag = false; break;
            }
            if (dds["Approver1_code"].ToString() == "")
            {
                _error += "Approver1code is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            //if (dds["Approver2_code"].ToString() == "")
            //{
            //    flag = false; break;
            //}
            if (dds["Hr_code"].ToString() == "")
            {
                _error += "Hrcode is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }

        }

        return flag;
    }
    private bool IsValidateApproverList(DataSet dsApproverlist)
    {
        DataTable dtEmp = dsApproverlist.Tables[0];
        SqlConnection Connection = DA.OpenConnection();
        try
        {
            string sqlstr = @"select  empcode from tbl_intranet_employee_jobDetails";
            DataSet dsEmp = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            //DataTable dtEmployee = new DataTable();
            foreach (DataRow row in dtEmp.Rows)
            {
                string exp = "empcode='" + row["Emp_code"].ToString().Trim() + "'";
                DataRow[] myrow = dsEmp.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Employee Code <font color='red'>" + row["Emp_code"].ToString() + "</font> doesn't exist.  ";
                    return false;
                }

                string exp1 = "empcode='" + row["Approver1_code"].ToString().Trim() + "'";
                DataRow[] myrow1 = dsEmp.Tables[0].Select(exp1);
                if (myrow1.Length <= 0)
                {
                    _error += "Approver Code <font color='red'>" + row["Approver1_code"].ToString() + "</font> doesn't exist.  ";
                    return false;
                }

                string exp2 = "empcode='" + row["Hr_code"].ToString().Trim() + "'";
                DataRow[] myrow2 = dsEmp.Tables[0].Select(exp2);
                if (myrow2.Length <= 0)
                {
                    _error += "HR Code <font color='red'>" + row["Hr_code"].ToString() + "</font> doesn't exist.  ";
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log(" Error: " + ex.Message + " " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");

        }
        finally
        {

            DA.CloseConnection();
        }
        return true;
    }
    #endregion
    #region Save Leave Balane & Approver List
    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        // worddocument();
        var activity = new DataActivity();
        SqlConnection conn = activity.OpenConnection();
        SqlTransaction tran = null;
        try
        {
            if (exceldocument(conn, tran))
            {
                if (_error != "")
                {
                    diverror.InnerHtml = _error;
                }
                else
                    Output.Show("Employee Leave Balance uploaded  Sucessfully");
            }
            else
            {
                if (_error != "")
                {
                    diverror.InnerHtml = _error;
                }
                Output.Show("Employee Leave Balance Not uploaded Successfully");
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Upload Leave balance some problem is their. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }
    private bool exceldocument(SqlConnection conn, SqlTransaction tran)
    {
        if (fupload.HasFile)
        {
            Common.Data.Excel Excel = new Common.Data.Excel();
            OleDbConnection Connection = null;
            string Extension = Excel.GetFileExtension(fupload.FileName);
            string PathName = "";
            if (Extension == ".xls" || Extension == ".xlsx")
            {
                string filename = Path.GetFileName(fupload.FileName);
                PathName = Server.MapPath("../Leave/Upload/") + filename;
                //PathName = Server.MapPath("../Leave/Upload/");
                System.IO.File.Delete(PathName);
               fupload.SaveAs(PathName);

                Connection = Excel.OpenExcelConnection(PathName);
                DataSet dsLeaveBalance = Excel.ReadExcelData("SELECT * FROM [LeaveBalance$]", Connection);
               // DataSet dsApproverlist = Excel.ReadExcelData("SELECT * FROM [ApproverList$]", Connection);
                Excel.CloseConnection();
                if (!IsValidateLeaveBalance(dsLeaveBalance))
                    return false;
                //if (!IsValidateApproverList(dsApproverlist))
                //    return false;
                try
                {
                    tran = conn.BeginTransaction();
                   SaveLeaveBalnce(dsLeaveBalance, conn, tran);
                   // SaveApproverList(dsApproverlist, conn, tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Common.Console.Output.Log(" Error: " + ex.Message + " " + DateTime.Now);
                    Output.Show("Upload Leave Balance some Problem is their. Please contact system admin. For error details please go through the log file.");
                }
            }
            else
            {
                Output.Show("Please Choose Valid File .");
                return false;
            }
        }
        else
        {
            //Output.Show("Please Choose File. ");
            return false;
        }
        return true;
    }
    private void SaveApproverList(DataSet dds, SqlConnection conn, SqlTransaction tran)
    {
        if (ValidateApproverList(dds))
        {
            for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
            {
                SqlParameter[] sqlparm = new SqlParameter[9];
                Output.AssignParameter(sqlparm, 0, "@empcode", "String", 50, dds.Tables[0].Rows[i]["Emp_code"].ToString().Trim());
                Output.AssignParameter(sqlparm, 1, "@approver1", "String", 50, dds.Tables[0].Rows[i]["Approver1_code"].ToString().Trim());
                Output.AssignParameter(sqlparm, 2, "@approver1name", "String", 50, dds.Tables[0].Rows[i]["Approver1_name"].ToString().Trim());
                Output.AssignParameter(sqlparm, 3, "@approver2", "String", 50, dds.Tables[0].Rows[i]["Approver2_code"].ToString().Trim());
                Output.AssignParameter(sqlparm, 4, "@approver2name", "String", 50, dds.Tables[0].Rows[i]["Approver2_name"].ToString().Trim());
                Output.AssignParameter(sqlparm, 5, "@hrcode", "String", 50, dds.Tables[0].Rows[i]["Hr_code"].ToString().Trim());
                Output.AssignParameter(sqlparm, 6, "@hrname", "String", 50, dds.Tables[0].Rows[i]["Hr_name"].ToString().Trim());
                Output.AssignParameter(sqlparm, 7, "@usercode", "String", 50, UserCode);
                Output.AssignParameter(sqlparm, 8, "@companyid", "Int", 50, CompanyId.ToString());
                SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, tran, "sp_leave_insert_approver_list", sqlparm);
            }

        }
        else
        {
            Output.Show("Some of the fields need correction in approver list");
        }
    }
    private void SaveLeaveBalnce(DataSet dds, SqlConnection conn, SqlTransaction tran)
    {
        if (ValidateLeaveBalance(dds))
        {
            for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
            {
                SqlParameter[] sqlparm = new SqlParameter[7];
                Output.AssignParameter(sqlparm, 0, "@policyid", "Int", 50, dds.Tables[0].Rows[i]["Policy_id"].ToString().Trim());
                Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 50, dds.Tables[0].Rows[i]["Leave_id"].ToString().Trim());
                Output.AssignParameter(sqlparm, 2, "@empcode", "String", 50, dds.Tables[0].Rows[i]["Emp_code"].ToString().Trim());
                Output.AssignParameter(sqlparm, 3, "@year", "String", 50, dds.Tables[0].Rows[i]["Calenderid"].ToString().Trim());
                //Output.AssignParameter(sqlparm, 4, "@month", "Int", 50, dds.Tables[0].Rows[i]["Month"].ToString().Trim());
                Output.AssignParameter(sqlparm, 4, "@entiledays", "Decimal", 50, dds.Tables[0].Rows[i]["Entitle_days"].ToString().Trim());
                Output.AssignParameter(sqlparm, 5, "@useddays", "Decimal", 50, dds.Tables[0].Rows[i]["Used_days"].ToString().Trim());
                Output.AssignParameter(sqlparm, 6, "@usercode", "String", 50, UserCode.ToString());
                SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, tran, "sp_leave_insert_leave_balance", sqlparm);


                SqlParameter[] sqlgridparm = new SqlParameter[8];

                Output.AssignParameter(sqlgridparm, 0, "@policyid", "Int", 100, dds.Tables[0].Rows[i]["Policy_id"].ToString().Trim());
                Output.AssignParameter(sqlgridparm, 1, "@leaveid", "Int", 100, "0");
                Output.AssignParameter(sqlgridparm, 2, "@empcode", "String", 100, dds.Tables[0].Rows[i]["Emp_code"].ToString().Trim());
                Output.AssignParameter(sqlgridparm, 3, "@Entitled_days", "Decimal", 10, "200.00");
                Output.AssignParameter(sqlgridparm, 4, "@createdby", "String", 100, UserCode);
                Output.AssignParameter(sqlgridparm, 5, "@modifiedby", "String", 100, UserCode);
                Output.AssignParameter(sqlgridparm, 6, "@createddate", "DateTime", 0, DateTime.Now.ToString());
                Output.AssignParameter(sqlgridparm, 7, "@year", "Int", 50, dds.Tables[0].Rows[i]["Calenderid"].ToString().Trim());
                int flag = SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, tran, "sp_leave_create_customizerule", sqlgridparm);
            }
        }
        else
        {
            Output.Show("Some of the fields need correction in leave balance");
        }
    }
    #endregion
}