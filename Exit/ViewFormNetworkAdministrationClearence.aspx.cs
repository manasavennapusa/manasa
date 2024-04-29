using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;


public partial class Exit_ViewFormNetworkAdministrationClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string ResignId = "0";

    string PageId = "Exit Approvers";
    int ApplicationId = 5;

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

            Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];

                if (row["PendriveExternalHardDrive"].ToString() == "Y")
                {
                    PendriveExternalHardDriveYes.Checked = true;
                    PendriveExternalHardDriveNo.Checked = false;
                    PendriveExternalHardDriveNA.Checked = false;
                }
                else if (row["PendriveExternalHardDrive"].ToString() == "N")
                {
                    PendriveExternalHardDriveYes.Checked = false;
                    PendriveExternalHardDriveNo.Checked = true;
                    PendriveExternalHardDriveNA.Checked = false;
                }
                else
                {
                    PendriveExternalHardDriveYes.Checked = false;
                    PendriveExternalHardDriveNo.Checked = false;
                    PendriveExternalHardDriveNA.Checked = true;
                }

                if (row["LaptopBag"].ToString() == "Y")
                {
                    LaptopBagYes.Checked = true;
                    LaptopBagNo.Checked = false;
                    LaptopBagNA.Checked = false;
                }
                else if (row["LaptopBag"].ToString() == "N")
                {
                    LaptopBagYes.Checked = false;
                    LaptopBagNo.Checked = true;
                    LaptopBagNA.Checked = false;
                }
                else
                {
                    LaptopBagYes.Checked = false;
                    LaptopBagNo.Checked = false;
                    LaptopBagNA.Checked = true;
                }

                if (row["LaptopChargerReturned"].ToString() == "Y")
                {
                    LaptopChargerReturnedYes.Checked = true;
                    LaptopChargerReturnedNo.Checked = false;
                    LaptopChargerReturnedNA.Checked = false;
                }
                else if (row["LaptopChargerReturned"].ToString() == "N")
                {
                    LaptopChargerReturnedYes.Checked = false;
                    LaptopChargerReturnedNo.Checked = true;
                    LaptopChargerReturnedNA.Checked = false;
                }
                else
                {
                    LaptopChargerReturnedYes.Checked = false;
                    LaptopChargerReturnedNo.Checked = false;
                    LaptopChargerReturnedNA.Checked = true;
                }

                if (row["HeadphonesReturned"].ToString() == "Y")
                {
                    HeadphonesReturnedYes.Checked = true;
                    HeadphonesReturnedNo.Checked = false;
                    HeadphonesReturnedNA.Checked = false;
                }
                else if (row["HeadphonesReturned"].ToString() == "N")
                {
                    HeadphonesReturnedYes.Checked = false;
                    HeadphonesReturnedNo.Checked = true;
                    HeadphonesReturnedNA.Checked = false;
                }
                else
                {
                    HeadphonesReturnedYes.Checked = false;
                    HeadphonesReturnedNo.Checked = false;
                    HeadphonesReturnedNA.Checked = true;
                }

                if (row["BlackberreyDeactivation"].ToString() == "Y")
                {
                    BlackberreyDeactivationYes.Checked = true;
                    BlackberreyDeactivationNo.Checked = false;
                    BlackberreyDeactivationNA.Checked = false;
                }
                else if (row["BlackberreyDeactivation"].ToString() == "N")
                {
                    BlackberreyDeactivationYes.Checked = false;
                    BlackberreyDeactivationNo.Checked = true;
                    BlackberreyDeactivationNA.Checked = false;
                }
                else
                {
                    BlackberreyDeactivationYes.Checked = false;
                    BlackberreyDeactivationNo.Checked = false;
                    BlackberreyDeactivationNA.Checked = true;
                }

                if (row["DomainAccountDeactivated"].ToString() == "Y")
                {
                    DomainAccountDeactivatedYes.Checked = true;
                    DomainAccountDeactivatedNo.Checked = false;
                    DomainAccountDeactivatedNA.Checked = false;
                }
                else if (row["DomainAccountDeactivated"].ToString() == "N")
                {
                    DomainAccountDeactivatedYes.Checked = false;
                    DomainAccountDeactivatedNo.Checked = true;
                    DomainAccountDeactivatedNA.Checked = false;
                }
                else
                {
                    DomainAccountDeactivatedYes.Checked = false;
                    DomainAccountDeactivatedNo.Checked = false;
                    DomainAccountDeactivatedNA.Checked = true;
                }

                if (row["ACCPACAccessDeactivated"].ToString() == "Y")
                {
                    ACCPACAccessDeactivatedYes.Checked = true;
                    ACCPACAccessDeactivatedNo.Checked = false;
                    ACCPACAccessDeactivatedNA.Checked = false;
                }
                else if (row["ACCPACAccessDeactivated"].ToString() == "N")
                {
                    ACCPACAccessDeactivatedYes.Checked = false;
                    ACCPACAccessDeactivatedNo.Checked = true;
                    ACCPACAccessDeactivatedNA.Checked = false;
                }
                else
                {
                    ACCPACAccessDeactivatedYes.Checked = false;
                    ACCPACAccessDeactivatedNo.Checked = false;
                    ACCPACAccessDeactivatedNA.Checked = true;
                }

                if (row["EmailAccountDeactivated"].ToString() == "Y")
                {
                    EmailAccountDeactivatedYes.Checked = true;
                    EmailAccountDeactivatedNo.Checked = false;
                    EmailAccountDeactivatedNA.Checked = false;
                }
                else if (row["EmailAccountDeactivated"].ToString() == "N")
                {
                    EmailAccountDeactivatedYes.Checked = false;
                    EmailAccountDeactivatedNo.Checked = true;
                    EmailAccountDeactivatedNA.Checked = false;
                }
                else
                {
                    EmailAccountDeactivatedYes.Checked = false;
                    EmailAccountDeactivatedNo.Checked = false;
                    EmailAccountDeactivatedNA.Checked = true;
                }

                if (row["DataBackTaken"].ToString() == "Y")
                {
                    DataBackTakenYes.Checked = true;
                    DataBackTakenNo.Checked = false;
                    DataBackTakenNA.Checked = false;
                }
                else if (row["DataBackTaken"].ToString() == "N")
                {
                    DataBackTakenYes.Checked = false;
                    DataBackTakenNo.Checked = true;
                    DataBackTakenNA.Checked = false;
                }
                else
                {
                    DataBackTakenYes.Checked = false;
                    DataBackTakenNo.Checked = false;
                    DataBackTakenNA.Checked = true;
                }

                if (row["DistrubutionSecurityGroupDeactivated"].ToString() == "Y")
                {
                    DistrubutionSecurityGroupDeactivatedYes.Checked = true;
                    DistrubutionSecurityGroupDeactivatedNo.Checked = false;
                    DistrubutionSecurityGroupDeactivatedNA.Checked = false;
                }
                else if (row["DistrubutionSecurityGroupDeactivated"].ToString() == "N")
                {
                    DistrubutionSecurityGroupDeactivatedYes.Checked = false;
                    DistrubutionSecurityGroupDeactivatedNo.Checked = true;
                    DistrubutionSecurityGroupDeactivatedNA.Checked = false;
                }
                else
                {
                    DistrubutionSecurityGroupDeactivatedYes.Checked = false;
                    DistrubutionSecurityGroupDeactivatedNo.Checked = false;
                    DistrubutionSecurityGroupDeactivatedNA.Checked = true;
                }

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