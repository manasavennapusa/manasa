using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;

/// <summary>
/// Summary description for ExitCommon
/// </summary>
public class ExitCommon
{
    public ExitCommon()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    IBase Lib = null;
    string Query = "";

    #region Rules
    public ExitEmployeeRule GetExitEmployeeRules()
    {
        Lib = new Base();
        ExitEmployeeRule Rule = new ExitEmployeeRule();

        string Query = @"select * from dbo.tbl_exit_employeerule where status = 1;";
        DataSet ds = Lib.Bee.WGetData(Query);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow Row = ds.Tables[0].Rows[0];

            Rule.CommentBoxRequired = Row["CommentBoxRequired"].ToString();
            Rule.Approve = Row["Approve"].ToString();
            Rule.Reject = Row["Reject"].ToString();
            Rule.Cancel = Row["Cancel"].ToString();
            Rule.ReInitiate = Row["ReInitiate"].ToString();
            Rule.Initiate = Row["Initiate"].ToString();
            Rule.ApplicationTypeId = Convert.ToInt32(Row["ApplicationTypeId"].ToString());
        }
        return Rule;

    }

    public ExitCompanyRule GetExitCompanyRules()
    {
        Lib = new Base();
        ExitCompanyRule Rule = new ExitCompanyRule();

        string Query = @"select * from dbo.tbl_exit_companyrule where status = 1;";
        DataSet ds = Lib.Bee.WGetData(Query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow Row = ds.Tables[0].Rows[0];

            Rule.DefaultLastWorkingDays = Convert.ToInt32(Row["DefaultLastWorkingDays"].ToString());
            Rule.IfReInitiateInitiateDateWillRemainSame = Row["IfReInitiateInitiateDateWillRemainSame"].ToString();
            Rule.ConfirmedEmployeeNoticePeriod = Convert.ToInt32(Row["ConfirmedEmployeeNoticePeriod"].ToString());
            Rule.UnConfirmedEmployeeNoticePeriod = Convert.ToInt32(Row["UnConfirmedEmployeeNoticePeriod"].ToString());
        }
        return Rule;

    }

    public ExitWorkFlowRule GetExitWorkRules(string ApproverCode, string EmpCode)
    {
        Lib = new Base();
        ExitWorkFlowRule Rule = new ExitWorkFlowRule();

        string Query = @"select distinct *
                          from tbl_exit_workflowrule wf 
                          left join tbl_exit_approverdetails app on wf.WorkFlowId = app.WorkFlowId
                          where wf.Status = 1 and app.Status = 1 and app.ApproverCode = '" + ApproverCode + "' and app.UserCode = '" + EmpCode + "'";

        DataSet ds = Lib.Bee.WGetData(Query);

        foreach (DataRow Row in ds.Tables[0].Rows)
        {
            if (Row["CommentBoxRequired"].ToString() == "Y")
                Rule.CommentBoxRequired = Row["CommentBoxRequired"].ToString();

            if (Row["Approve"].ToString() == "Y")
                Rule.Approve = Row["Approve"].ToString();

            if (Row["Reject"].ToString() == "Y")
                Rule.Reject = Row["Reject"].ToString();

            if (Row["Cancel"].ToString() == "Y")
                Rule.Cancel = Row["Cancel"].ToString();

            if (Row["ReInitiate"].ToString() == "Y")
                Rule.ReInitiate = Row["ReInitiate"].ToString();

            if (Row["Initiate"].ToString() == "Y")
                Rule.Initiate = Row["Initiate"].ToString();

            if (Row["InitiateNextWorkFlow"].ToString() == "Y")
                Rule.InitiateNextWorkFlow = Row["InitiateNextWorkFlow"].ToString();

            if (Row["EmailAlertRequiredNoOfDaysBefore"].ToString() == "Y")
                Rule.EmailAlertRequiredNoOfDaysBefore = Row["EmailAlertRequiredNoOfDaysBefore"].ToString();

            if (Row["EmailRequired"].ToString() == "Y")
                Rule.EmailRequired = Row["EmailRequired"].ToString();

            if (Row["InitiateExitClearenceCertificate"].ToString() == "Y")
                Rule.InitiateExitClearenceCertificate = Row["InitiateExitClearenceCertificate"].ToString();

            Rule.ApplicationId = Convert.ToInt32(Row["ApplicationId"].ToString());

            if (Row["CanEditLWD"].ToString() == "Y")
                Rule.CanEditLWD = Row["CanEditLWD"].ToString();

        }
        return Rule;
    }

    #endregion

    #region Queries
    public string ApproversDetails(string UserCode, int WorkFlowTypeId)
    {
        Query = @"select appr.ApproverCode, emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') ApproverName,appr.WorkFlowId,wf.WorkFlowName
                         from tbl_exit_approverdetails appr 
                         left join tbl_intranet_employee_jobDetails job on appr.ApproverCode = job.empcode
                         left join tbl_exit_workflow wf on wf.WorkFlowId = appr.WorkFlowId
                         where appr.UserCode = '" + UserCode + "' and appr.Status = 1 and appr.WorkFlowTypeId = " + WorkFlowTypeId + "";

        return Query;
    }

    public string ResignationDetails(string UserCode)
    {
        Query = @" select job.empcode EmpCode, emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName, job.emp_status, stat.employeestatus as EmployeeStatus,com.ConfirmedEmployeeNoticePeriod,com.UnConfirmedEmployeeNoticePeriod, getdate() AppliedDate
 ,designationname,dep.department_name
                    from tbl_intranet_employee_jobDetails job,tbl_exit_companyrule com,tbl_intranet_employee_status stat
                   ,tbl_intranet_designation des,tbl_internate_departmentdetails dep
                    where job.emp_status = stat.id and des.id=job.degination_id and dep.departmentid=job.dept_id and com.Status = 1 and job.empcode = '" + UserCode + "'";

        return Query;
    }

    #endregion
}

#region Rule Classes

public class ExitCompanyRule
{
    public ExitCompanyRule() { }
    public int DefaultLastWorkingDays { get; set; }
    public string IfReInitiateInitiateDateWillRemainSame { get; set; }
    public int ConfirmedEmployeeNoticePeriod { get; set; }
    public int UnConfirmedEmployeeNoticePeriod { get; set; }
}

public class ExitEmployeeRule
{
    public ExitEmployeeRule() { }
    public string CommentBoxRequired { get; set; }
    public string Approve { get; set; }
    public string Reject { get; set; }
    public string Cancel { get; set; }
    public string ReInitiate { get; set; }
    public string Initiate { get; set; }
    public int ApplicationTypeId { get; set; }
}

public class ExitWorkFlowRule
{
    public ExitWorkFlowRule() { }

    public string CommentBoxRequired { get; set; }
    public string Approve { get; set; }
    public string Reject { get; set; }
    public string Cancel { get; set; }
    public string ReInitiate { get; set; }
    public string Initiate { get; set; }
    public string InitiateNextWorkFlow { get; set; }
    public string EmailAlertRequiredNoOfDaysBefore { get; set; }
    public string EmailRequired { get; set; }
    public string InitiateExitClearenceCertificate { get; set; }
    public int ApplicationId { get; set; }
    public string CanEditLWD { get; set; }
}

#endregion