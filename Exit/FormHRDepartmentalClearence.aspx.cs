using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_FormHRDepartmentalClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string PageId = "Exit Approvers";
    int ApplicationId = 7;

    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitEmployeeRule EmpRule = null;
    ExitCompanyRule CompanyRule = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            Id = Request.QueryString["Id"].ToString().Trim();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindDetails();
                BindClearence();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");

        }
    }

    private void BindDetails()
    {
        Lib = new Base();
        // Application Type and Work Flow Type
        // Pending - Status = 1 and Resign Status = U
        Query = @"select distinct ExitId,A.EmpCode,job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName,emp_doj,P.mobile_no,P.email_id,C.per_add1,C.per_add2,D.department_name,AppliedDate,DefaultLWD,Comments
from
(
select E.ExitId,E.EmpCode EmpCode,R.AppliedDate,R.DefaultLWD,R.Comments
from tbl_exit_Exit E 
inner join tbl_exit_ExitProcess EP on E.ExitId = EP.ResignationId
inner join tbl_exit_Resignation R on R.ResignationId = E.ResignationId
where E.ExitId = " + Id + ") A inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode left join tbl_intranet_employee_personalDetails P on A.EmpCode = P.empcode left join tbl_intranet_employee_contactlist C on C.empcode = A.EmpCode left join tbl_internate_departmentdetails D on job.dept_id = D.departmentid";

        DataSet ds = Lib.Bee.WGetData(Query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            EmpName.Text = row["EmpName"].ToString();
            EmpCode.Text = row["EmpCode"].ToString();
            Department.Text = row["department_name"].ToString();
            DOJ.Text = row["emp_doj"].ToString();
            DOR.Text = row["AppliedDate"].ToString();
            LWD.Text = row["DefaultLWD"].ToString();
            PA.Text = row["per_add1"].ToString() + " " + row["per_add2"].ToString();
            PMN.Text = row["mobile_no"].ToString();
            PEI.Text = row["email_id"].ToString();
            ReasonofLeaving.Text = row["Comments"].ToString();
        }

        Query = @"select L.Entitled_days - L.Used_days as AnnualLeave
                  from tbl_leave_employee_leave_master L 
                   where L.leaveid = 1 and L.status=1 and L.empcode = '" + EmpCode.Text.Trim() + "'";
        DataSet ds1 = Lib.Bee.WGetData(Query);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds1.Tables[0].Rows[0];
            AnnualLeaveBalance.Text = row["AnnualLeave"].ToString();
        }

        // Cancelled - Status = 0 and Resign Status = C
        // Rejected - Status = 0 and Resign Status = J
        // Freezed - Status = 1 and Resign Status = F
        // Re-Initiate - Make Status = 0 and Resign Status = R for the previous record and insert new record with the same values except, Status = 1 and Resign Status = U
    }

    private void BindClearence()
    {
        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];

                if (row["ReceivedResignationLetterFromEmployee"].ToString() == "Y")
                {
                    ReceivedResignationLetterFromEmployeeYes.Checked = true;
                    ReceivedResignationLetterFromEmployeeNo.Checked = false;
                    ReceivedResignationLetterFromEmployeeNA.Checked = false;
                }
                else if (row["ReceivedResignationLetterFromEmployee"].ToString() == "N")
                {
                    ReceivedResignationLetterFromEmployeeYes.Checked = false;
                    ReceivedResignationLetterFromEmployeeNo.Checked = true;
                    ReceivedResignationLetterFromEmployeeNA.Checked = false;
                }
                else
                {
                    ReceivedResignationLetterFromEmployeeYes.Checked = false;
                    ReceivedResignationLetterFromEmployeeNo.Checked = false;
                    ReceivedResignationLetterFromEmployeeNA.Checked = true;
                }

                if (row["ResignationApprovalFromManager"].ToString() == "Y")
                {
                    ResignationApprovalFromManagerYes.Checked = true;
                    ResignationApprovalFromManagerNo.Checked = false;
                    ResignationApprovalFromManagerNA.Checked = false;
                }
                else if (row["ResignationApprovalFromManager"].ToString() == "N")
                {
                    ResignationApprovalFromManagerYes.Checked = false;
                    ResignationApprovalFromManagerNo.Checked = true;
                    ResignationApprovalFromManagerNA.Checked = false;
                }
                else
                {
                    ResignationApprovalFromManagerYes.Checked = false;
                    ResignationApprovalFromManagerNo.Checked = false;
                    ResignationApprovalFromManagerNA.Checked = true;
                }

                if (row["NoticePeriodServed"].ToString() == "Y")
                {
                    NoticePeriodServedYes.Checked = true;
                    NoticePeriodServedNo.Checked = false;
                    NoticePeriodServedNA.Checked = false;
                }
                else if (row["NoticePeriodServed"].ToString() == "N")
                {
                    NoticePeriodServedYes.Checked = false;
                    NoticePeriodServedNo.Checked = true;
                    NoticePeriodServedNA.Checked = false;
                }
                else
                {
                    NoticePeriodServedYes.Checked = false;
                    NoticePeriodServedNo.Checked = false;
                    NoticePeriodServedNA.Checked = true;
                }

                if (row["NoticePeriodRecovery"].ToString() == "Y")
                {
                    NoticePeriodRecoveryYes.Checked = true;
                    NoticePeriodRecoveryNo.Checked = false;
                    NoticePeriodRecoveryNA.Checked = false;
                }
                else if (row["NoticePeriodRecovery"].ToString() == "N")
                {
                    NoticePeriodRecoveryYes.Checked = false;
                    NoticePeriodRecoveryNo.Checked = true;
                    NoticePeriodRecoveryNA.Checked = false;
                }
                else
                {
                    NoticePeriodRecoveryYes.Checked = false;
                    NoticePeriodRecoveryNo.Checked = false;
                    NoticePeriodRecoveryNA.Checked = true;
                }

                if (row["EligibleForReHire"].ToString() == "Y")
                {
                    EligibleForReHireYes.Checked = true;
                    EligibleForReHireNo.Checked = false;
                    EligibleForReHireNA.Checked = false;
                }
                else if (row["EligibleForReHire"].ToString() == "N")
                {
                    EligibleForReHireYes.Checked = false;
                    EligibleForReHireNo.Checked = true;
                    EligibleForReHireNA.Checked = false;
                }
                else
                {
                    EligibleForReHireYes.Checked = false;
                    EligibleForReHireNo.Checked = false;
                    EligibleForReHireNA.Checked = true;
                }

                if (row["InvestmentProofsSubmitted"].ToString() == "Y")
                {
                    InvestmentProofsSubmittedYes.Checked = true;
                    InvestmentProofsSubmittedNo.Checked = false;
                    InvestmentProofsSubmittedNA.Checked = false;
                }
                else if (row["InvestmentProofsSubmitted"].ToString() == "N")
                {
                    InvestmentProofsSubmittedYes.Checked = false;
                    InvestmentProofsSubmittedNo.Checked = true;
                    InvestmentProofsSubmittedNA.Checked = false;
                }
                else
                {
                    InvestmentProofsSubmittedYes.Checked = false;
                    InvestmentProofsSubmittedNo.Checked = false;
                    InvestmentProofsSubmittedNA.Checked = true;
                }

                if (row["ReimbursementProofsSubmitted"].ToString() == "Y")
                {
                    ReimbursementProofsSubmittedYes.Checked = true;
                    ReimbursementProofsSubmittedNo.Checked = false;
                    ReimbursementProofsSubmittedNA.Checked = false;
                }
                else if (row["ReimbursementProofsSubmitted"].ToString() == "N")
                {
                    ReimbursementProofsSubmittedYes.Checked = false;
                    ReimbursementProofsSubmittedNo.Checked = true;
                    ReimbursementProofsSubmittedNA.Checked = false;
                }
                else
                {
                    ReimbursementProofsSubmittedYes.Checked = false;
                    ReimbursementProofsSubmittedNo.Checked = false;
                    ReimbursementProofsSubmittedNA.Checked = true;
                }

                AnnualLeaveBalance.Text = row["AnnualLeaveBalance"].ToString();
                LOPDays.Text = row["LOPDays"].ToString();
                ReasonofLeaving.Text = row["ReasonofLeaving"].ToString();
                OtherComments.Text = row["OtherComments"].ToString();
                NoticePeriodRecoveryDays.Value = row["NoticePeriodRecoveryDays"].ToString();
                NoticePeriodRecoveryAmount.Value = row["NoticePeriodRecoveryAmount"].ToString();
                ReasonForNotEligibleForReHire.Text = row["ReasonForNotEligibleForReHire"].ToString();

                if (row["DateOfClearence"].ToString() != "")
                    DateOfClearence.Text = Convert.ToDateTime(row["DateOfClearence"].ToString()).ToString("dd-MMM-yyyy");
                else
                    DateOfClearence.Text = "";
            }

        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Lib.Bee.CloseConnection();
        }
    }


    protected void btnsave_Click(object sender, EventArgs e)
    {
        string ReceivedResignationLetterFromEmployee = "A";
        string ResignationApprovalFromManager = "A";
        string NoticePeriodServed = "A";
        string NoticePeriodRecovery = "A";
        string EligibleForReHire = "A";
        string InvestmentProofsSubmitted = "A";
        string ReimbursementProofsSubmitted = "A";

        int Flag = 0;
        Lib = new Base();

        if (ReceivedResignationLetterFromEmployeeYes.Checked == true)
            ReceivedResignationLetterFromEmployee = "Y";
        if (ReceivedResignationLetterFromEmployeeNo.Checked == true)
            ReceivedResignationLetterFromEmployee = "N";
        if (ReceivedResignationLetterFromEmployeeNA.Checked == true)
            ReceivedResignationLetterFromEmployee = "A";

        if (ResignationApprovalFromManagerYes.Checked == true)
            ResignationApprovalFromManager = "Y";
        if (ResignationApprovalFromManagerNo.Checked == true)
            ResignationApprovalFromManager = "N";
        if (ResignationApprovalFromManagerNA.Checked == true)
            ResignationApprovalFromManager = "A";

        if (NoticePeriodServedYes.Checked == true)
            NoticePeriodServed = "Y";
        if (NoticePeriodServedNo.Checked == true)
            NoticePeriodServed = "N";
        if (NoticePeriodServedNA.Checked == true)
            NoticePeriodServed = "A";

        if (NoticePeriodRecoveryYes.Checked == true)
            NoticePeriodRecovery = "Y";
        if (NoticePeriodRecoveryNo.Checked == true)
            NoticePeriodRecovery = "N";
        if (NoticePeriodRecoveryNA.Checked == true)
            NoticePeriodRecovery = "A";

        if (EligibleForReHireYes.Checked == true)
            EligibleForReHire = "Y";
        if (EligibleForReHireNo.Checked == true)
            EligibleForReHire = "N";
        if (EligibleForReHireNA.Checked == true)
            EligibleForReHire = "A";

        if (InvestmentProofsSubmittedYes.Checked == true)
            InvestmentProofsSubmitted = "Y";
        if (InvestmentProofsSubmittedNo.Checked == true)
            InvestmentProofsSubmitted = "N";
        if (InvestmentProofsSubmittedNA.Checked == true)
            InvestmentProofsSubmitted = "A";

        if (ReimbursementProofsSubmittedYes.Checked == true)
            ReimbursementProofsSubmitted = "Y";
        if (ReimbursementProofsSubmittedNo.Checked == true)
            ReimbursementProofsSubmitted = "N";
        if (ReimbursementProofsSubmittedNA.Checked == true)
            ReimbursementProofsSubmitted = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus in ('A','C')";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {

                    Query = "update tbl_exit_hrdepartmentclearence set Status = 0 where ExitId = " + Id + " and ApproverStatus = 'S'";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Flag = 0;
                        if (DateOfClearence.Text != "")
                            Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','S','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";
                        else
                            Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "',null,'S','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";

                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                        if (Flag > 0)
                        {
                            Lib.Bee.Commit();
                            Output.Show("Record saved successfully.");
                        }
                        else
                        {
                            Lib.Bee.RollBack();
                            Output.Show("Record not saved.");
                        }

                    }
                    else
                    {
                        Output.Show("Record not saved. Only saved application will be able to modify.");
                    }
                }
                else
                {
                    Output.Show("Sorry! not able to save the record. Due to record is already approved/cancelled.");
                }
            }
            else
            {
                if (DateOfClearence.Text != "")
                    Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire)  
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','S','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";
                else
                    Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "',null,'S','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";


                Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                if (Flag > 0)
                {
                    Lib.Bee.Commit();
                    Output.Show("Record saved successfully.");
                }
                else
                {
                    Lib.Bee.RollBack();
                    Output.Show("Record not saved.");
                }
            }

        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Lib.Bee.CloseConnection();
        }

    }


    protected void btnApprove_Click(object sender, EventArgs e)
    {
        string ReceivedResignationLetterFromEmployee = "A";
        string ResignationApprovalFromManager = "A";
        string NoticePeriodServed = "A";
        string NoticePeriodRecovery = "A";
        string EligibleForReHire = "A";
        string InvestmentProofsSubmitted = "A";
        string ReimbursementProofsSubmitted = "A";

        int Flag = 0;
        bool BFlag = false;

        Lib = new Base();

        if (ReceivedResignationLetterFromEmployeeYes.Checked == true)
            ReceivedResignationLetterFromEmployee = "Y";
        if (ReceivedResignationLetterFromEmployeeNo.Checked == true)
            ReceivedResignationLetterFromEmployee = "N";
        if (ReceivedResignationLetterFromEmployeeNA.Checked == true)
            ReceivedResignationLetterFromEmployee = "A";

        if (ResignationApprovalFromManagerYes.Checked == true)
            ResignationApprovalFromManager = "Y";
        if (ResignationApprovalFromManagerNo.Checked == true)
            ResignationApprovalFromManager = "N";
        if (ResignationApprovalFromManagerNA.Checked == true)
            ResignationApprovalFromManager = "A";

        if (NoticePeriodServedYes.Checked == true)
            NoticePeriodServed = "Y";
        if (NoticePeriodServedNo.Checked == true)
            NoticePeriodServed = "N";
        if (NoticePeriodServedNA.Checked == true)
            NoticePeriodServed = "A";

        if (NoticePeriodRecoveryYes.Checked == true)
            NoticePeriodRecovery = "Y";
        if (NoticePeriodRecoveryNo.Checked == true)
            NoticePeriodRecovery = "N";
        if (NoticePeriodRecoveryNA.Checked == true)
            NoticePeriodRecovery = "A";

        if (EligibleForReHireYes.Checked == true)
            EligibleForReHire = "Y";
        if (EligibleForReHireNo.Checked == true)
            EligibleForReHire = "N";
        if (EligibleForReHireNA.Checked == true)
            EligibleForReHire = "A";

        if (InvestmentProofsSubmittedYes.Checked == true)
            InvestmentProofsSubmitted = "Y";
        if (InvestmentProofsSubmittedNo.Checked == true)
            InvestmentProofsSubmitted = "N";
        if (InvestmentProofsSubmittedNA.Checked == true)
            InvestmentProofsSubmitted = "A";

        if (ReimbursementProofsSubmittedYes.Checked == true)
            ReimbursementProofsSubmitted = "Y";
        if (ReimbursementProofsSubmittedNo.Checked == true)
            ReimbursementProofsSubmitted = "N";
        if (ReimbursementProofsSubmittedNA.Checked == true)
            ReimbursementProofsSubmitted = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_departmentalclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                {
                    Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                    if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                    {
                        Query = "select 1 from tbl_exit_accountdepartmentalclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                        if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                        {
                            Query = "select 1 from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                            {
                                Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1";

                                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                                {
                                    Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";

                                    if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                                    {
                                        Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                                        if (Flag > 0)
                                        {
                                            Query = "update tbl_exit_hrdepartmentclearence set ApproverStatus = 'A' where ExitId = " + Id + " and Status = 1";
                                            Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                                            if (Flag > 0)
                                            {
                                                Lib.Bee.Commit();
                                                BFlag = true;
                                                Output.Show("Clearance Request Approved.");
                                            }
                                            else
                                            {
                                                Lib.Bee.RollBack();
                                                Output.Show("Application not approved.");
                                            }
                                        }
                                        else
                                            Output.Show("Application not approved.");
                                    }
                                    else
                                        Output.Show("This application is already approved.");
                                }
                                else
                                {
                                    if (DateOfClearence.Text != "")
                                        Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire)  
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "',getdate(),'A','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";
                                    else
                                        Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire)  
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "',getdate(),'A','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";
                                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                                    if (Flag > 0)
                                    {
                                        Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                                        if (Flag > 0)
                                        {
                                            Lib.Bee.Commit();
                                            BFlag = true;
                                            Output.Show("Clearance Request Approved.");
                                           // Response.Redirect("PendingExitProcess.aspx?approve=true");
                                        }
                                        else
                                        {
                                            Lib.Bee.RollBack();
                                            Output.Show("Application not approved.");
                                        }
                                    }
                                    else
                                        Output.Show("Application not approved.");
                                }
                            }
                            else
                            {
                                Output.Show("Sorry! Interviewer questionaries clearence form is pending.");
                            }
                        }
                        else
                        {
                            Output.Show("Sorry! Account department clearence form is pending.");
                        }
                    }
                    else
                    {
                        Output.Show("Sorry! Network admin clearence form is pending.");
                    }
                }
                else
                {
                    Output.Show("Sorry! General admin clearence form is pending.");
                }
            }
            else
            {
                Output.Show("Sorry! Departmental clearence form is pending.");
            }

        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Lib.Bee.CloseConnection();
            if (BFlag == true)
                Server.Transfer("PendingExitProcess.aspx");
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        string ReceivedResignationLetterFromEmployee = "A";
        string ResignationApprovalFromManager = "A";
        string NoticePeriodServed = "A";
        string NoticePeriodRecovery = "A";
        string EligibleForReHire = "A";
        string InvestmentProofsSubmitted = "A";
        string ReimbursementProofsSubmitted = "A";

        int Flag = 0;
        Lib = new Base();

        if (ReceivedResignationLetterFromEmployeeYes.Checked == true)
            ReceivedResignationLetterFromEmployee = "Y";
        if (ReceivedResignationLetterFromEmployeeNo.Checked == true)
            ReceivedResignationLetterFromEmployee = "N";
        if (ReceivedResignationLetterFromEmployeeNA.Checked == true)
            ReceivedResignationLetterFromEmployee = "A";

        if (ResignationApprovalFromManagerYes.Checked == true)
            ResignationApprovalFromManager = "Y";
        if (ResignationApprovalFromManagerNo.Checked == true)
            ResignationApprovalFromManager = "N";
        if (ResignationApprovalFromManagerNA.Checked == true)
            ResignationApprovalFromManager = "A";

        if (NoticePeriodServedYes.Checked == true)
            NoticePeriodServed = "Y";
        if (NoticePeriodServedNo.Checked == true)
            NoticePeriodServed = "N";
        if (NoticePeriodServedNA.Checked == true)
            NoticePeriodServed = "A";

        if (NoticePeriodRecoveryYes.Checked == true)
            NoticePeriodRecovery = "Y";
        if (NoticePeriodRecoveryNo.Checked == true)
            NoticePeriodRecovery = "N";
        if (NoticePeriodRecoveryNA.Checked == true)
            NoticePeriodRecovery = "A";

        if (EligibleForReHireYes.Checked == true)
            EligibleForReHire = "Y";
        if (EligibleForReHireNo.Checked == true)
            EligibleForReHire = "N";
        if (EligibleForReHireNA.Checked == true)
            EligibleForReHire = "A";

        if (InvestmentProofsSubmittedYes.Checked == true)
            InvestmentProofsSubmitted = "Y";
        if (InvestmentProofsSubmittedNo.Checked == true)
            InvestmentProofsSubmitted = "N";
        if (InvestmentProofsSubmittedNA.Checked == true)
            InvestmentProofsSubmitted = "A";

        if (ReimbursementProofsSubmittedYes.Checked == true)
            ReimbursementProofsSubmitted = "Y";
        if (ReimbursementProofsSubmittedNo.Checked == true)
            ReimbursementProofsSubmitted = "N";
        if (ReimbursementProofsSubmittedNA.Checked == true)
            ReimbursementProofsSubmitted = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_departmentalclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                {
                    Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                    if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                    {
                        Query = "select 1 from tbl_exit_accountdepartmentalclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                        if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                        {
                            Query = "select 1 from tbl_exit_interviewquestion where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";
                            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                            {
                                Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1";

                                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
                                {
                                    Query = "select 1 from tbl_exit_hrdepartmentclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'C'";

                                    if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                                    {
                                        Query = "update tbl_exit_ExitProcess set ApproverStatus = 'C' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                                        if (Flag > 0)
                                        {
                                            Query = "update tbl_exit_hrdepartmentclearence set ApproverStatus = 'C' where ExitId = " + Id + " and Status = 1";
                                            Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                                            if (Flag > 0)
                                            {
                                                Lib.Bee.Commit();
                                                Output.Show("Clearance Request Rejected.");
                                            }
                                            else
                                            {
                                                Lib.Bee.RollBack();
                                                Output.Show("Record not cancelled.");
                                            }
                                        }
                                        else
                                            Output.Show("Record not cancelled.");
                                    }
                                    else
                                        Output.Show("This application is already cancelled.");
                                }
                                else
                                {

                                    if (DateOfClearence.Text != "")
                                        Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire)  
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','C','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";
                                    else
                                        Query = @"insert into tbl_exit_hrdepartmentclearence (ExitId,EmpCode,ApproverCode,ReceivedResignationLetterFromEmployee,ResignationApprovalFromManager,NoticePeriodServed,NoticePeriodRecovery,EligibleForReHire,InvestmentProofsSubmitted,ReimbursementProofsSubmitted,AnnualLeaveBalance,LOPDays,ReasonofLeaving,OtherComments,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status,NoticePeriodRecoveryDays,NoticePeriodRecoveryAmount,ReasonForNotEligibleForReHire)  
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + ReceivedResignationLetterFromEmployee + "','" + ResignationApprovalFromManager + "','" + NoticePeriodServed + "','" + NoticePeriodRecovery + "','" + EligibleForReHire + "','" + InvestmentProofsSubmitted + "','" + ReimbursementProofsSubmitted + "','" + AnnualLeaveBalance.Text.Trim() + "','" + LOPDays.Text.Trim() + "','" + ReasonofLeaving.Text.Trim() + "','" + OtherComments.Text.Trim() + "',null,'C','" + UserCode + "',getdate(),1,'" + NoticePeriodRecoveryDays.Value.Trim() + "','" + NoticePeriodRecoveryAmount.Value.Trim() + "','" + ReasonForNotEligibleForReHire.Text.Trim() + "')";


                                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                                    if (Flag > 0)
                                    {
                                        Query = "update tbl_exit_ExitProcess set ApproverStatus = 'C' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                                        Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                                        if (Flag > 0)
                                        {
                                            Lib.Bee.Commit();
                                            Output.Show("Clearance Request Rejected.");
                                        }
                                        else
                                        {
                                            Lib.Bee.RollBack();
                                            Output.Show("Application not cancelled.");
                                        }
                                    }
                                    else
                                        Output.Show("Application not cancelled.");
                                }
                            }
                            else
                            {
                                Output.Show("Sorry! Intervier questionaries clearence form is pending.");
                            }
                        }
                        else
                        {
                            Output.Show("Sorry! Account department clearence form is pending.");
                        }
                    }
                    else
                    {
                        Output.Show("Sorry! Network admin clearence form is pending.");
                    }
                }
                else
                {
                    Output.Show("Sorry! General admin clearence form is pending.");
                }
            }
            else
            {
                Output.Show("Sorry! Departmental clearence form is pending.");
            }
        }
        catch (Exception ex)
        {
            Lib.Bee.RollBack();
            Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Lib.Bee.CloseConnection();
        }
    }
}