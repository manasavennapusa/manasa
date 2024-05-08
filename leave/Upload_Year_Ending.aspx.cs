using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
using System.Data.OleDb;
using System.IO;

public partial class leave_Upload_Year_Ending : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity DA = new DataActivity();
    string CompanyId, UserCode, _error = "";
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
            if (dds["Emp ID"].ToString() == "")
            {
                _error += "Policy Id is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Leave_id"].ToString() == "")
            {
                _error += "Leave id is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["EmpName"].ToString() == "")
            {
                _error += "Empcode is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Calenderid"].ToString() == "")
            {
                _error += "Calenderid is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Carrried_Forward"].ToString() == "")
            {
                _error += "Carrried Forward is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
           
            if (dds["Opening_Balance"].ToString() == "")
            {
                _error += "Useddays is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Lapsed_Leaves"].ToString() == "")
            {
                _error += "Lapsed leaves  is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["CalenderYear"].ToString() == "")
            {
                _error += "Calender year is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
            if (dds["Encashed_Leaves"].ToString() == "")
            {
                _error += "Entitledays is empty for row no." + ds.Tables[0].Rows.IndexOf(dds) + 1 + "";
                flag = false; break;
            }
        }

        return flag;
    }
     #region
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

            string sqlstr3 = @"select id from tbl_leave_leaveperiod where status=1";
            DataSet dsCalenderId = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr3);

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
                string exp = "empcode='" + row["Emp ID"].ToString().Trim() + "'";
                DataRow[] myrow = dsEmp.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Employee Code <font color='red'>" + row["Emp ID"].ToString() + "</font> doesn't exist.  ";
                    return false;
                }

            }

            foreach (DataRow row in dtEmp.Rows)
            {
                string exp = "id='" + row["Calenderid"].ToString().Trim() + "'";
                DataRow[] myrow = dsCalenderId.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Calenderid <font color='red'>" + row["Calenderid"].ToString() + "</font> doesn't exist.  ";
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
     #region
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
            //Output.Show("Upload Leave balance some problem is their. Please contact system admin. For error details please go through the log file.");
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
                DataSet dsLeaveBalance = Excel.ReadExcelData("SELECT * FROM [YearEndingLeaveBalance$]", Connection);
               
                Excel.CloseConnection();
                if (!IsValidateLeaveBalance(dsLeaveBalance))
                    return false;
                
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
   
    private void SaveLeaveBalnce(DataSet dds, SqlConnection conn, SqlTransaction tran)
    {
        if (ValidateLeaveBalance(dds))
        {
            for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
            {
                SqlParameter[] sqlparm = new SqlParameter[11];
                Output.AssignParameter(sqlparm, 0, "@policyid", "Int", 50, dds.Tables[0].Rows[i]["Policy_id"].ToString().Trim());
                Output.AssignParameter(sqlparm, 1, "@leaveid", "Int", 50, dds.Tables[0].Rows[i]["Leave_id"].ToString().Trim());
                Output.AssignParameter(sqlparm, 2, "@empcode", "String", 50, dds.Tables[0].Rows[i]["Emp ID"].ToString().Trim());
                Output.AssignParameter(sqlparm, 3, "@calenderyear", "String", 50, dds.Tables[0].Rows[i]["CalenderYear"].ToString().Trim());

                Output.AssignParameter(sqlparm, 4, "@EmpName", "String", 50, dds.Tables[0].Rows[i]["EmpName"].ToString().Trim());
                Output.AssignParameter(sqlparm, 5, "@CarrriedForward", "Decimal", 50, dds.Tables[0].Rows[i]["Carrried_Forward"].ToString().Trim());
                Output.AssignParameter(sqlparm, 6, "@EncashedLeaves", "Decimal", 50, dds.Tables[0].Rows[i]["Encashed_Leaves"].ToString().Trim());
                Output.AssignParameter(sqlparm, 7, "@OpeningBalance ", "Decimal", 100, dds.Tables[0].Rows[i]["Opening_Balance"].ToString().Trim());
                Output.AssignParameter(sqlparm, 8, "@LapsedLeaves", "Decimal", 100, dds.Tables[0].Rows[i]["Lapsed_Leaves"].ToString().Trim());
                Output.AssignParameter(sqlparm, 9, "@Calenderid", "Int", 100, dds.Tables[0].Rows[i]["Calenderid"].ToString().Trim());
                Output.AssignParameter(sqlparm, 10, "@processBy", "String", 100, UserCode.ToString());
                SQLServer.ExecuteNonQuery(conn, CommandType.StoredProcedure, tran, "sp_leave_upload_YearEnding_Process", sqlparm);
                
            }
        }
        else
        {
            Output.Show("Some of the fields need correction in leave balance");
        }
    }
    #endregion

}