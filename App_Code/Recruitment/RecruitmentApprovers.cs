using System;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;

/// <summary>
/// Summary description for RecruitmentApprovers
/// </summary>
public class RecruitmentApprovers
{
    IBase Lib = null;

	public RecruitmentApprovers()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataRow GetRecruitmentRaisedEmployee(string rrfId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select A.createdby empcode, J.emp_fname empname, J.official_email_id officialemailid
 from tbl_intranet_employee_jobDetails J
 inner join tbl_recruitment_requisition_form A on J.empcode = A.createdby 
  where rrf_code = '" + rrfId + "'";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0];
    }

    public DataSet GetRecruitmentApprovers(string rrfId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select A.ApproverCode empcode, J.emp_fname empname, J.official_email_id officialemailid, A.Approvelevel level, A.ApproverStatus status
 from tbl_intranet_employee_jobDetails J
 inner join tbl_recruitment_master_approvers A on J.empcode = A.ApproverCode 
  where rrf_code = '" + rrfId + "' order by A.Approvelevel";

        Query += @";select A.createdby empcode, J.emp_fname empname, J.official_email_id officialemailid
 from tbl_intranet_employee_jobDetails J
 inner join tbl_recruitment_requisition_form A on J.empcode = A.createdby 
  where rrf_code = '" + rrfId + "'";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds;
    }

    public string GetRRFId(int id)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select rrf_code
   from tbl_recruitment_requisition_form
    where id = " + id + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0]["rrf_code"].ToString();
    }

    public bool CheckStatusOfHRBPAndMD(string rrfId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"
select sum(isnull(flag,0)) flag
  from
  (
   select COUNT(*) flag
    from tbl_recruitment_master_approvers
     where rrf_code = '" + rrfId + @"' and Approvelevel = 2 and ApproverStatus = 'A'
   union 
   select COUNT(*) flag
    from tbl_recruitment_master_approvers
     where rrf_code = '" + rrfId + @"' and Approvelevel = 3 and ApproverStatus = 'A'
   ) T
";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);

        if (Convert.ToInt32(ds.Tables[0].Rows[0]["flag"].ToString()) == 2)
            return true;
        else
            return false;
    }

    public DataRow GetPanelDetails(string candidateId)
    {
        var activity = new DataActivity();
        string Query = "";

        Query = @"select Ap.rrf_code , AP.panelcode , RF.rrf_code, PM.Panelname, PM.resourcenames
 from tbl_recruitment_assignpanel AP
  inner join tbl_recruitment_requisition_form RF on AP.rrf_code = RF.id
  inner join tbl_recruitment_candidate_registration CR on CR.rrf_id = RF.id
  inner join tbl_recruitment_panel_master PM on Ap.panelid = PM.id
   where CR.id = " + candidateId + "";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0];
    }

    public DataRow GetEmployeeInfo(string empcodes)
    {
        string[] empcode = empcodes.Split(',');

        var activity = new DataActivity();
        string Query = "";

        Query = @"select empcode ,emp_fname, official_email_id
  from tbl_intranet_employee_jobDetails 
   where empcode = '" + empcode[0].Trim() + "'";

        SqlConnection connection = activity.OpenConnection();
        Lib = new Base();
        DataSet ds = Lib.Bee.WGetData(Query);
        return ds.Tables[0].Rows[0];
    }
}