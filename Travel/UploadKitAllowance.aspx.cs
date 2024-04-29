using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Console;
using Common.Data;
using System.Data.OleDb;


public partial class Travel_UploadKitAllowance : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string _error = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        try
        {
            Connection = DataActivity.OpenConnection();
            _Transaction = Connection.BeginTransaction();

            if (fpKitAllowance.PostedFile.FileName.ToString() != "")
            {
                string file = Server.MapPath(".") + "\\upload\\KitAllowance.xlsx";
                fpKitAllowance.PostedFile.SaveAs(file);
                String strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0;HDR=YES;IMEX=1';";
                OleDbConnection objconn = new OleDbConnection(strConn);
                objconn.Open();
                OleDbCommand objcmdselect = new OleDbCommand("SELECT * FROM [KitAllowance$]", objconn);
                OleDbDataAdapter objadapter1 = new OleDbDataAdapter();
                objadapter1.SelectCommand = objcmdselect;
                DataSet dds = new DataSet();
                objadapter1.Fill(dds, "KitAllowance");
                objconn.Close();
                if (!IsValidateEmpcode(dds))
                    return;
               
                    for (int i = 0; i < dds.Tables[0].Rows.Count; i++)
                    {

                        SqlParameter[] param = new SqlParameter[5];

                        param[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
                        param[0].Value = dds.Tables[0].Rows[i]["EmployeeCode"].ToString().Trim();

                        param[1] = new SqlParameter("@accountcode", SqlDbType.VarChar, 100);
                        param[1].Value = dds.Tables[0].Rows[i]["Travel_ID"].ToString().Trim();

                        param[2] = new SqlParameter("@kitallowance", SqlDbType.Decimal);
                        param[2].Value = dds.Tables[0].Rows[i]["KitAllowance"].ToString().Trim();

                        param[3] = new SqlParameter("@createby", SqlDbType.VarChar, 50);
                        param[3].Value = Session["empcode"].ToString();

                        param[4] = new SqlParameter("@applieddate", SqlDbType.Date);
                        param[4].Value = dds.Tables[0].Rows[i]["KitAllowanceDate"].ToString().Trim();

                        SQLServer.ExecuteNonQuery(Connection, CommandType.StoredProcedure, _Transaction, "sp_travel_upload_kitallowance", param);
                    }
                    _Transaction.Commit();
                    Output.Show("Uploaded Successfully");
                }
           
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not fetched. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }
    private bool IsValidateEmpcode(DataSet ds)
    {
        DataTable dtEmp = ds.Tables[0];
        SqlConnection Connection = DataActivity.OpenConnection();
        try
        {
            string sqlstr = @"select  empcode from tbl_intranet_employee_jobDetails";
            DataSet dsEmp = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            foreach (DataRow row in dtEmp.Rows)
            {
                string exp = "empcode='" + row["EmployeeCode"].ToString().Trim() + "'";
                DataRow[] myrow = dsEmp.Tables[0].Select(exp);
                if (myrow.Length <= 0)
                {
                    _error += "Employee Code  " + row["EmployeeCode"].ToString() + " doesn't exist.  ";
                    diverror.InnerText = _error;
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

            DataActivity.CloseConnection();
        }
        return true;
    }
}