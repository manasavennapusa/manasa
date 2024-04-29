using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;

/// <summary>
/// Summary description for Approvers
/// </summary>
public class Reimbursement
{
    IBase Lib = null;

    public Reimbursement()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataRow GetEmployeeInfo(int reimbursementId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select R.Empcode, J.emp_fname, J.official_email_id
 from tbl_intranet_employee_jobDetails J
  inner join tbl_Rb_Reimbursement R on J.empcode = R.Empcode
   where R.RID = " + reimbursementId + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0];
    }

    public DataRow GetApprovers(int reimbursementId, int level)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select 
A.Approvercode,
J.emp_fname, 
J.official_email_id
 from 
 tbl_intranet_employee_jobDetails J 
 inner join tbl_Rb_Approvers A on A.Approvercode = J.empcode 
   where A.RID = " + reimbursementId + " and A.Level = " + level + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0];
    }
}