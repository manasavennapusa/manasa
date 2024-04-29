using System;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;

public class ExitApprovers
{
    IBase Lib = null;

    public ExitApprovers()
    {

    }

    public DataRow GetResignationEmployee(int resignationId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @" select R.EmpCode empcode, J.emp_fname empname, J.official_email_id officialemailid
  from tbl_intranet_employee_jobDetails J inner join
   tbl_exit_Resignation R on J.empcode = R.EmpCode
   where R.ResignationId = " + resignationId + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0];
    }

    public DataTable GetResignationApproversExceptHR(int resignationId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select R.ApproversCode empcode,J.emp_fname empname,J.official_email_id officialemailid,R.Level level
  from tbl_intranet_employee_jobDetails J inner join
   tbl_exit_ResignationProcess R on J.empcode = R.ApproversCode
   where R.ResignationId = " + resignationId + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0];
    }

    public DataTable GetResignationApproverLevel(int resignationId, string empCode)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select R.ApproversCode empcode,J.emp_fname empname,J.official_email_id officialemailid,R.Level level
  from tbl_intranet_employee_jobDetails J inner join
   tbl_exit_ResignationProcess R on J.empcode = R.ApproversCode
   where R.ResignationId = " + resignationId + " and R.ApproversCode = '" + empCode + "' and R.Level = 2";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0];
    }

    public DataTable GetExitApproverLevel(int resignationId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select R.ApproversCode empcode,J.emp_fname empname,J.official_email_id officialemailid,R.ApplicationId,T.ApplicationName
  from tbl_intranet_employee_jobDetails J 
  inner join tbl_exit_ExitProcess R on J.empcode = R.ApproversCode
  inner join tbl_exit_applicationtype T on T.ApplicationTypeId = R.ApplicationId
  inner join tbl_exit_Exit X on X.ExitId = R.ResignationId
   where X.ResignationId = " + resignationId + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0];
    }

    public int GetResignationId(int exitId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select ResignationId 
 from  tbl_exit_Exit
  where ExitId = " + exitId + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return Convert.ToInt32(ds.Tables[0].Rows[0]["ResignationId"].ToString());
    }
}