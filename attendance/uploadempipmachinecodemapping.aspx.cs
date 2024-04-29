using System;
using System.Data;

using Common.Data;
using System.Data.OleDb;
using System.IO;
using System.Data.SqlClient;
using Common.Console;

public partial class attendance_uploadempipmachinecodemapping : System.Web.UI.Page
{
    int iferror = 0;
    string CompanyId, UserCode;
    string error = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            UserCode = Session["empcode"].ToString();
            CompanyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {

            }
        }
        else
        {

        }
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


    protected void btnUpload_Click(object sender, EventArgs e)
    {
        Upload();
    }
}

