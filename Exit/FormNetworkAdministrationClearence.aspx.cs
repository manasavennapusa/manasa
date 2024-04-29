using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;


public partial class Exit_FormNetworkAdministrationClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
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
        Query = @"select distinct ExitId,A.EmpCode,job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName,emp_doj,P.mobile_no,P.email_id,C.per_add1,C.per_add2,D.department_name,AppliedDate,DefaultLWD
from
(
select E.ExitId,E.EmpCode EmpCode,R.AppliedDate,R.DefaultLWD
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
        string PendriveExternalHardDrive = "A";
        string LaptopBag = "A";
        string LaptopChargerReturned = "A";
        string HeadphonesReturned = "A";
        string BlackberreyDeactivation = "A";
        string DomainAccountDeactivated = "A";
        string ACCPACAccessDeactivated = "A";
        string EmailAccountDeactivated = "A";
        string DataBackTaken = "A";
        string DistrubutionSecurityGroupDeactivated = "A";

        int Flag = 0;
        Lib = new Base();

        if (PendriveExternalHardDriveYes.Checked == true)
            PendriveExternalHardDrive = "Y";
        if (PendriveExternalHardDriveNo.Checked == true)
            PendriveExternalHardDrive = "N";
        if (PendriveExternalHardDriveNA.Checked == true)
            PendriveExternalHardDrive = "A";

        if (LaptopBagYes.Checked == true)
            LaptopBag = "Y";
        if (LaptopBagNo.Checked == true)
            LaptopBag = "N";
        if (LaptopBagNA.Checked == true)
            LaptopBag = "A";

        if (LaptopChargerReturnedYes.Checked == true)
            LaptopChargerReturned = "Y";
        if (LaptopChargerReturnedNo.Checked == true)
            LaptopChargerReturned = "N";
        if (LaptopChargerReturnedNA.Checked == true)
            LaptopChargerReturned = "A";

        if (HeadphonesReturnedYes.Checked == true)
            HeadphonesReturned = "Y";
        if (HeadphonesReturnedNo.Checked == true)
            HeadphonesReturned = "N";
        if (HeadphonesReturnedNA.Checked == true)
            HeadphonesReturned = "A";

        if (BlackberreyDeactivationYes.Checked == true)
            BlackberreyDeactivation = "Y";
        if (BlackberreyDeactivationNo.Checked == true)
            BlackberreyDeactivation = "N";
        if (BlackberreyDeactivationNA.Checked == true)
            BlackberreyDeactivation = "A";

        if (DomainAccountDeactivatedYes.Checked == true)
            DomainAccountDeactivated = "Y";
        if (DomainAccountDeactivatedNo.Checked == true)
            DomainAccountDeactivated = "N";
        if (DomainAccountDeactivatedNA.Checked == true)
            DomainAccountDeactivated = "A";

        if (ACCPACAccessDeactivatedYes.Checked == true)
            ACCPACAccessDeactivated = "Y";
        if (ACCPACAccessDeactivatedNo.Checked == true)
            ACCPACAccessDeactivated = "N";
        if (ACCPACAccessDeactivatedNA.Checked == true)
            ACCPACAccessDeactivated = "A";

        if (EmailAccountDeactivatedYes.Checked == true)
            EmailAccountDeactivated = "Y";
        if (EmailAccountDeactivatedNo.Checked == true)
            EmailAccountDeactivated = "N";
        if (EmailAccountDeactivatedNA.Checked == true)
            EmailAccountDeactivated = "A";

        if (DataBackTakenYes.Checked == true)
            DataBackTaken = "Y";
        if (DataBackTakenNo.Checked == true)
            DataBackTaken = "N";
        if (DataBackTakenNA.Checked == true)
            DataBackTaken = "A";

        if (DistrubutionSecurityGroupDeactivatedYes.Checked == true)
            DistrubutionSecurityGroupDeactivated = "Y";
        if (DistrubutionSecurityGroupDeactivatedNo.Checked == true)
            DistrubutionSecurityGroupDeactivated = "N";
        if (DistrubutionSecurityGroupDeactivatedNA.Checked == true)
            DistrubutionSecurityGroupDeactivated = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus in ('A','C')";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {

                    Query = "update tbl_exit_networkadminclearence set Status = 0 where ExitId = " + Id + " and ApproverStatus = 'S'";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Flag = 0;
                        if (DateOfClearence.Text != "")
                            Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','S','" + UserCode + "',getdate(),1)";
                        else
                            Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "',null,'S','" + UserCode + "',getdate(),1)";


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
                    Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','S','" + UserCode + "',getdate(),1)";
                else
                    Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "',null,'S','" + UserCode + "',getdate(),1)";


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
        string PendriveExternalHardDrive = "A";
        string LaptopBag = "A";
        string LaptopChargerReturned = "A";
        string HeadphonesReturned = "A";
        string BlackberreyDeactivation = "A";
        string DomainAccountDeactivated = "A";
        string ACCPACAccessDeactivated = "A";
        string EmailAccountDeactivated = "A";
        string DataBackTaken = "A";
        string DistrubutionSecurityGroupDeactivated = "A";

        int Flag = 0;
        bool BFlag = false;

        Lib = new Base();

        if (PendriveExternalHardDriveYes.Checked == true)
            PendriveExternalHardDrive = "Y";
        if (PendriveExternalHardDriveNo.Checked == true)
            PendriveExternalHardDrive = "N";
        if (PendriveExternalHardDriveNA.Checked == true)
            PendriveExternalHardDrive = "A";

        if (LaptopBagYes.Checked == true)
            LaptopBag = "Y";
        if (LaptopBagNo.Checked == true)
            LaptopBag = "N";
        if (LaptopBagNA.Checked == true)
            LaptopBag = "A";

        if (LaptopChargerReturnedYes.Checked == true)
            LaptopChargerReturned = "Y";
        if (LaptopChargerReturnedNo.Checked == true)
            LaptopChargerReturned = "N";
        if (LaptopChargerReturnedNA.Checked == true)
            LaptopChargerReturned = "A";

        if (HeadphonesReturnedYes.Checked == true)
            HeadphonesReturned = "Y";
        if (HeadphonesReturnedNo.Checked == true)
            HeadphonesReturned = "N";
        if (HeadphonesReturnedNA.Checked == true)
            HeadphonesReturned = "A";

        if (BlackberreyDeactivationYes.Checked == true)
            BlackberreyDeactivation = "Y";
        if (BlackberreyDeactivationNo.Checked == true)
            BlackberreyDeactivation = "N";
        if (BlackberreyDeactivationNA.Checked == true)
            BlackberreyDeactivation = "A";

        if (DomainAccountDeactivatedYes.Checked == true)
            DomainAccountDeactivated = "Y";
        if (DomainAccountDeactivatedNo.Checked == true)
            DomainAccountDeactivated = "N";
        if (DomainAccountDeactivatedNA.Checked == true)
            DomainAccountDeactivated = "A";

        if (ACCPACAccessDeactivatedYes.Checked == true)
            ACCPACAccessDeactivated = "Y";
        if (ACCPACAccessDeactivatedNo.Checked == true)
            ACCPACAccessDeactivated = "N";
        if (ACCPACAccessDeactivatedNA.Checked == true)
            ACCPACAccessDeactivated = "A";

        if (EmailAccountDeactivatedYes.Checked == true)
            EmailAccountDeactivated = "Y";
        if (EmailAccountDeactivatedNo.Checked == true)
            EmailAccountDeactivated = "N";
        if (EmailAccountDeactivatedNA.Checked == true)
            EmailAccountDeactivated = "A";

        if (DataBackTakenYes.Checked == true)
            DataBackTaken = "Y";
        if (DataBackTakenNo.Checked == true)
            DataBackTaken = "N";
        if (DataBackTakenNA.Checked == true)
            DataBackTaken = "A";

        if (DistrubutionSecurityGroupDeactivatedYes.Checked == true)
            DistrubutionSecurityGroupDeactivated = "Y";
        if (DistrubutionSecurityGroupDeactivatedNo.Checked == true)
            DistrubutionSecurityGroupDeactivated = "N";
        if (DistrubutionSecurityGroupDeactivatedNA.Checked == true)
            DistrubutionSecurityGroupDeactivated = "A";


        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1";

            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                    if (Flag > 0)
                    {

                        Query = "update tbl_exit_networkadminclearence set ApproverStatus = 'A' where ExitId = " + Id + " and Status = 1";
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
                    Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "',getdate(),'A','" + UserCode + "',getdate(),1)";
                else
                    Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "',getdate(),'A','" + UserCode + "',getdate(),1)";
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
        string PendriveExternalHardDrive = "A";
        string LaptopBag = "A";
        string LaptopChargerReturned = "A";
        string HeadphonesReturned = "A";
        string BlackberreyDeactivation = "A";
        string DomainAccountDeactivated = "A";
        string ACCPACAccessDeactivated = "A";
        string EmailAccountDeactivated = "A";
        string DataBackTaken = "A";
        string DistrubutionSecurityGroupDeactivated = "A";

        int Flag = 0;
        Lib = new Base();

        if (PendriveExternalHardDriveYes.Checked == true)
            PendriveExternalHardDrive = "Y";
        if (PendriveExternalHardDriveNo.Checked == true)
            PendriveExternalHardDrive = "N";
        if (PendriveExternalHardDriveNA.Checked == true)
            PendriveExternalHardDrive = "A";

        if (LaptopBagYes.Checked == true)
            LaptopBag = "Y";
        if (LaptopBagNo.Checked == true)
            LaptopBag = "N";
        if (LaptopBagNA.Checked == true)
            LaptopBag = "A";

        if (LaptopChargerReturnedYes.Checked == true)
            LaptopChargerReturned = "Y";
        if (LaptopChargerReturnedNo.Checked == true)
            LaptopChargerReturned = "N";
        if (LaptopChargerReturnedNA.Checked == true)
            LaptopChargerReturned = "A";

        if (HeadphonesReturnedYes.Checked == true)
            HeadphonesReturned = "Y";
        if (HeadphonesReturnedNo.Checked == true)
            HeadphonesReturned = "N";
        if (HeadphonesReturnedNA.Checked == true)
            HeadphonesReturned = "A";

        if (BlackberreyDeactivationYes.Checked == true)
            BlackberreyDeactivation = "Y";
        if (BlackberreyDeactivationNo.Checked == true)
            BlackberreyDeactivation = "N";
        if (BlackberreyDeactivationNA.Checked == true)
            BlackberreyDeactivation = "A";

        if (DomainAccountDeactivatedYes.Checked == true)
            DomainAccountDeactivated = "Y";
        if (DomainAccountDeactivatedNo.Checked == true)
            DomainAccountDeactivated = "N";
        if (DomainAccountDeactivatedNA.Checked == true)
            DomainAccountDeactivated = "A";

        if (ACCPACAccessDeactivatedYes.Checked == true)
            ACCPACAccessDeactivated = "Y";
        if (ACCPACAccessDeactivatedNo.Checked == true)
            ACCPACAccessDeactivated = "N";
        if (ACCPACAccessDeactivatedNA.Checked == true)
            ACCPACAccessDeactivated = "A";

        if (EmailAccountDeactivatedYes.Checked == true)
            EmailAccountDeactivated = "Y";
        if (EmailAccountDeactivatedNo.Checked == true)
            EmailAccountDeactivated = "N";
        if (EmailAccountDeactivatedNA.Checked == true)
            EmailAccountDeactivated = "A";

        if (DataBackTakenYes.Checked == true)
            DataBackTaken = "Y";
        if (DataBackTakenNo.Checked == true)
            DataBackTaken = "N";
        if (DataBackTakenNA.Checked == true)
            DataBackTaken = "A";

        if (DistrubutionSecurityGroupDeactivatedYes.Checked == true)
            DistrubutionSecurityGroupDeactivated = "Y";
        if (DistrubutionSecurityGroupDeactivatedNo.Checked == true)
            DistrubutionSecurityGroupDeactivated = "N";
        if (DistrubutionSecurityGroupDeactivatedNA.Checked == true)
            DistrubutionSecurityGroupDeactivated = "A";


        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1";

            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_networkadminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'C'";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'C' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Query = "update tbl_exit_networkadminclearence set ApproverStatus = 'C' where ExitId = " + Id + " and Status = 1";
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
                    Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','C','" + UserCode + "',getdate(),1)";
                else
                    Query = @"insert into tbl_exit_networkadminclearence (ExitId,EmpCode,ApproverCode,PendriveExternalHardDrive,LaptopBag,LaptopChargerReturned,HeadphonesReturned,BlackberreyDeactivation,DomainAccountDeactivated,ACCPACAccessDeactivated,EmailAccountDeactivated,DataBackTaken,DistrubutionSecurityGroupDeactivated,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + PendriveExternalHardDrive + "','" + LaptopBag + "','" + LaptopChargerReturned + "','" + HeadphonesReturned + "','" + BlackberreyDeactivation + "','" + DomainAccountDeactivated + "','" + ACCPACAccessDeactivated + "','" + EmailAccountDeactivated + "','" + DataBackTaken + "','" + DistrubutionSecurityGroupDeactivated + "','" + Others.Text.Trim() + "',null,'C','" + UserCode + "',getdate(),1)";


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