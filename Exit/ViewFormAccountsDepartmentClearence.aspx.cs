using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ViewFormAccountsDepartmentClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string ResignId = "0";
    string PageId = "Exit Approvers";
    int ApplicationId = 4;
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

            Query = "select 1 from tbl_exit_accountdepartmentalclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_accountdepartmentalclearence where ExitId = " + Id + " and Status = 1";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];

                if (row["SalaryAdvanceBalance"].ToString() == "Y")
                {
                    SalaryAdvanceBalanceYes.Checked = true;
                    SalaryAdvanceBalanceNo.Checked = false;
                    SalaryAdvanceBalanceNA.Checked = false;
                }
                else if (row["SalaryAdvanceBalance"].ToString() == "N")
                {
                    SalaryAdvanceBalanceYes.Checked = false;
                    SalaryAdvanceBalanceNo.Checked = true;
                    SalaryAdvanceBalanceNA.Checked = false;
                }
                else
                {
                    SalaryAdvanceBalanceYes.Checked = false;
                    SalaryAdvanceBalanceNo.Checked = false;
                    SalaryAdvanceBalanceNA.Checked = true;
                }

                if (row["PersonalHouseloanBalance"].ToString() == "Y")
                {
                    PersonalHouseloanBalanceYes.Checked = true;
                    PersonalHouseloanBalanceNo.Checked = false;
                    PersonalHouseloanBalanceNA.Checked = false;
                }
                else if (row["PersonalHouseloanBalance"].ToString() == "N")
                {
                    PersonalHouseloanBalanceYes.Checked = false;
                    PersonalHouseloanBalanceNo.Checked = true;
                    PersonalHouseloanBalanceNA.Checked = false;
                }
                else
                {
                    PersonalHouseloanBalanceYes.Checked = false;
                    PersonalHouseloanBalanceNo.Checked = false;
                    PersonalHouseloanBalanceNA.Checked = true;
                }

                if (row["CarLeasedBalance"].ToString() == "Y")
                {
                    CarLeasedBalanceYes.Checked = true;
                    CarLeasedBalanceNo.Checked = false;
                    CarLeasedBalanceNA.Checked = false;
                }
                else if (row["CarLeasedBalance"].ToString() == "N")
                {
                    CarLeasedBalanceYes.Checked = false;
                    CarLeasedBalanceNo.Checked = true;
                    CarLeasedBalanceNA.Checked = false;
                }
                else
                {
                    CarLeasedBalanceYes.Checked = false;
                    CarLeasedBalanceNo.Checked = false;
                    CarLeasedBalanceNA.Checked = true;
                }

                if (row["ReimbursementBalance"].ToString() == "Y")
                {
                    ReimbursementBalanceYes.Checked = true;
                    ReimbursementBalanceNo.Checked = false;
                    ReimbursementBalanceNA.Checked = false;
                }
                else if (row["ReimbursementBalance"].ToString() == "N")
                {
                    ReimbursementBalanceYes.Checked = false;
                    ReimbursementBalanceNo.Checked = true;
                    ReimbursementBalanceNA.Checked = false;
                }
                else
                {
                    ReimbursementBalanceYes.Checked = false;
                    ReimbursementBalanceNo.Checked = false;
                    ReimbursementBalanceNA.Checked = true;
                }

                if (row["TravelAdvanceSettlement"].ToString() == "Y")
                {
                    TravelAdvanceSettlementYes.Checked = true;
                    TravelAdvanceSettlementNo.Checked = false;
                    TravelAdvanceSettlementNA.Checked = false;
                }
                else if (row["TravelAdvanceSettlement"].ToString() == "N")
                {
                    TravelAdvanceSettlementYes.Checked = false;
                    TravelAdvanceSettlementNo.Checked = true;
                    TravelAdvanceSettlementNA.Checked = false;
                }
                else
                {
                    TravelAdvanceSettlementYes.Checked = false;
                    TravelAdvanceSettlementNo.Checked = false;
                    TravelAdvanceSettlementNA.Checked = true;
                }

                Others.Text = row["Others"].ToString();
                Cheque.Text = row["Cheque"].ToString();
                DateOfClearence.Text = row["DateOfClearence"].ToString();
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