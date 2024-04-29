using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ViewFormGeneralAdministrationClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string ResignId = "0";

    string PageId = "Exit Approvers";
    int ApplicationId = 3;

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
                BindGeneralAdminClearence();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindGeneralAdminClearence()
    {
        try
        {
            Lib = new Base();
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];

                if (row["KeysReturnedNumber"].ToString() == "Y")
                {
                    KeysReturnedNumberYes.Checked = true;
                    KeysReturnedNumberNo.Checked = false;
                    KeysReturnedNumberNA.Checked = false;
                }
                else if (row["KeysReturnedNumber"].ToString() == "N")
                {
                    KeysReturnedNumberYes.Checked = false;
                    KeysReturnedNumberNo.Checked = true;
                    KeysReturnedNumberNA.Checked = false;
                }
                else
                {
                    KeysReturnedNumberYes.Checked = false;
                    KeysReturnedNumberNo.Checked = false;
                    KeysReturnedNumberNA.Checked = true;
                }

                if (row["MobilePhoneReturnedWithCharger"].ToString() == "Y")
                {
                    MobilePhoneReturnedWithChargerYes.Checked = true;
                    MobilePhoneReturnedWithChargerNo.Checked = false;
                    MobilePhoneReturnedWithChargerNA.Checked = false;
                }
                else if (row["MobilePhoneReturnedWithCharger"].ToString() == "N")
                {
                    MobilePhoneReturnedWithChargerYes.Checked = false;
                    MobilePhoneReturnedWithChargerNo.Checked = true;
                    MobilePhoneReturnedWithChargerNA.Checked = false;
                }
                else
                {
                    MobilePhoneReturnedWithChargerYes.Checked = false;
                    MobilePhoneReturnedWithChargerNo.Checked = false;
                    MobilePhoneReturnedWithChargerNA.Checked = true;
                }

                if (row["DataCardReturned"].ToString() == "Y")
                {
                    DataCardReturnedYes.Checked = true;
                    DataCardReturnedNo.Checked = false;
                    DataCardReturnedNA.Checked = false;
                }
                else if (row["DataCardReturned"].ToString() == "N")
                {
                    DataCardReturnedYes.Checked = false;
                    DataCardReturnedNo.Checked = true;
                    DataCardReturnedNA.Checked = false;
                }
                else
                {
                    DataCardReturnedYes.Checked = false;
                    DataCardReturnedNo.Checked = false;
                    DataCardReturnedNA.Checked = true;
                }


                if (row["SIMCardReturned"].ToString() == "Y")
                {
                    SIMCardReturnedYes.Checked = true;
                    SIMCardReturnedNo.Checked = false;
                    SIMCardReturnedNA.Checked = false;
                }
                else if (row["SIMCardReturned"].ToString() == "N")
                {
                    SIMCardReturnedYes.Checked = false;
                    SIMCardReturnedNo.Checked = true;
                    SIMCardReturnedNA.Checked = false;
                }
                else
                {
                    SIMCardReturnedYes.Checked = false;
                    SIMCardReturnedNo.Checked = false;
                    SIMCardReturnedNA.Checked = true;
                }

                if (row["ReturnedIdentityAccessBadge"].ToString() == "Y")
                {
                    ReturnedIdentityAccessBadgeYes.Checked = true;
                    ReturnedIdentityAccessBadgeNo.Checked = false;
                    ReturnedIdentityAccessBadgeNA.Checked = false;
                }
                else if (row["ReturnedIdentityAccessBadge"].ToString() == "N")
                {
                    ReturnedIdentityAccessBadgeYes.Checked = false;
                    ReturnedIdentityAccessBadgeNo.Checked = true;
                    ReturnedIdentityAccessBadgeNA.Checked = false;
                }
                else
                {
                    ReturnedIdentityAccessBadgeYes.Checked = false;
                    ReturnedIdentityAccessBadgeNo.Checked = false;
                    ReturnedIdentityAccessBadgeNA.Checked = true;
                }

                Key.Text = row["ReturnedKeyvalue"].ToString();
                Others.Text = row["Others"].ToString();
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