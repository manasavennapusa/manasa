using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ViewFormHRDepartmentalClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string ResignId = "0";

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
            ResignId = Request.QueryString["ResignId"].ToString().Trim();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindClearence();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindClearence()
    {
        try
        {
            Lib = new Base();
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

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("ViewExitStatus.aspx?ResignId=" + ResignId + "");
    }

}