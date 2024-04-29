using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_FormGeneralAdministrationClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
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

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindDetails();
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


    protected void btnsave_Click(object sender, EventArgs e)
    {
        string KeysReturnedNumber = "A";
        string MobilePhoneReturnedWithCharger = "A";
        string DataCardReturned = "A";
        string SIMCardReturned = "A";
        string ReturnedIdentityAccessBadge = "A";

        int Flag = 0;
        Lib = new Base();

        if (KeysReturnedNumberYes.Checked == true)
            KeysReturnedNumber = "Y";
        if (KeysReturnedNumberNo.Checked == true)
            KeysReturnedNumber = "N";
        if (KeysReturnedNumberNA.Checked == true)
            KeysReturnedNumber = "A";

        if (MobilePhoneReturnedWithChargerYes.Checked == true)
            MobilePhoneReturnedWithCharger = "Y";
        if (MobilePhoneReturnedWithChargerNo.Checked == true)
            MobilePhoneReturnedWithCharger = "N";
        if (MobilePhoneReturnedWithChargerNA.Checked == true)
            MobilePhoneReturnedWithCharger = "A";

        if (DataCardReturnedYes.Checked == true)
            DataCardReturned = "Y";
        if (DataCardReturnedNo.Checked == true)
            DataCardReturned = "N";
        if (DataCardReturnedNA.Checked == true)
            DataCardReturned = "A";

        if (SIMCardReturnedYes.Checked == true)
            SIMCardReturned = "Y";
        if (SIMCardReturnedNo.Checked == true)
            SIMCardReturned = "N";
        if (SIMCardReturnedNA.Checked == true)
            SIMCardReturned = "A";

        if (ReturnedIdentityAccessBadgeYes.Checked == true)
            ReturnedIdentityAccessBadge = "Y";
        if (ReturnedIdentityAccessBadgeNo.Checked == true)
            ReturnedIdentityAccessBadge = "N";
        if (ReturnedIdentityAccessBadgeNA.Checked == true)
            ReturnedIdentityAccessBadge = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus in ('A','C')";
                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_generaladminclearence set Status = 0 where ExitId = " + Id + " and ApproverStatus = 'S'";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Flag = 0;
                        if (DateOfClearence.Text != "")
                            Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','S','" + UserCode + "',getdate(),1)";
                        else
                            Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "',null,'S','" + UserCode + "',getdate(),1)";

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
                    Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','S','" + UserCode + "',getdate(),1)";
                else
                    Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "',null,'S','" + UserCode + "',getdate(),1)";


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
        string KeysReturnedNumber = "A";
        string MobilePhoneReturnedWithCharger = "A";
        string DataCardReturned = "A";
        string SIMCardReturned = "A";
        string ReturnedIdentityAccessBadge = "A";

        int Flag = 0;
        bool BFlag = false;

        Lib = new Base();

        if (KeysReturnedNumberYes.Checked == true)
            KeysReturnedNumber = "Y";
        if (KeysReturnedNumberNo.Checked == true)
            KeysReturnedNumber = "N";
        if (KeysReturnedNumberNA.Checked == true)
            KeysReturnedNumber = "A";

        if (MobilePhoneReturnedWithChargerYes.Checked == true)
            MobilePhoneReturnedWithCharger = "Y";
        if (MobilePhoneReturnedWithChargerNo.Checked == true)
            MobilePhoneReturnedWithCharger = "N";
        if (MobilePhoneReturnedWithChargerNA.Checked == true)
            MobilePhoneReturnedWithCharger = "A";

        if (DataCardReturnedYes.Checked == true)
            DataCardReturned = "Y";
        if (DataCardReturnedNo.Checked == true)
            DataCardReturned = "N";
        if (DataCardReturnedNA.Checked == true)
            DataCardReturned = "A";

        if (SIMCardReturnedYes.Checked == true)
            SIMCardReturned = "Y";
        if (SIMCardReturnedNo.Checked == true)
            SIMCardReturned = "N";
        if (SIMCardReturnedNA.Checked == true)
            SIMCardReturned = "A";

        if (ReturnedIdentityAccessBadgeYes.Checked == true)
            ReturnedIdentityAccessBadge = "Y";
        if (ReturnedIdentityAccessBadgeNo.Checked == true)
            ReturnedIdentityAccessBadge = "N";
        if (ReturnedIdentityAccessBadgeNA.Checked == true)
            ReturnedIdentityAccessBadge = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'A' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "' and ApplicationId = " + ApplicationId + "";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Query = "update tbl_exit_generaladminclearence set ApproverStatus = 'A' where ExitId = " + Id + " and Status = 1";
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
                    Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "',getdate(),'A','" + UserCode + "',getdate(),1)";
                else
                    Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "',getdate(),'A','" + UserCode + "',getdate(),1)";

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
        string KeysReturnedNumber = "A";
        string MobilePhoneReturnedWithCharger = "A";
        string DataCardReturned = "A";
        string SIMCardReturned = "A";
        string ReturnedIdentityAccessBadge = "A";

        int Flag = 0;
        Lib = new Base();

        if (KeysReturnedNumberYes.Checked == true)
            KeysReturnedNumber = "Y";
        if (KeysReturnedNumberNo.Checked == true)
            KeysReturnedNumber = "N";
        if (KeysReturnedNumberNA.Checked == true)
            KeysReturnedNumber = "A";

        if (MobilePhoneReturnedWithChargerYes.Checked == true)
            MobilePhoneReturnedWithCharger = "Y";
        if (MobilePhoneReturnedWithChargerNo.Checked == true)
            MobilePhoneReturnedWithCharger = "N";
        if (MobilePhoneReturnedWithChargerNA.Checked == true)
            MobilePhoneReturnedWithCharger = "A";

        if (DataCardReturnedYes.Checked == true)
            DataCardReturned = "Y";
        if (DataCardReturnedNo.Checked == true)
            DataCardReturned = "N";
        if (DataCardReturnedNA.Checked == true)
            DataCardReturned = "A";

        if (SIMCardReturnedYes.Checked == true)
            SIMCardReturned = "Y";
        if (SIMCardReturnedNo.Checked == true)
            SIMCardReturned = "N";
        if (SIMCardReturnedNA.Checked == true)
            SIMCardReturned = "A";

        if (ReturnedIdentityAccessBadgeYes.Checked == true)
            ReturnedIdentityAccessBadge = "Y";
        if (ReturnedIdentityAccessBadgeNo.Checked == true)
            ReturnedIdentityAccessBadge = "N";
        if (ReturnedIdentityAccessBadgeNA.Checked == true)
            ReturnedIdentityAccessBadge = "A";

        try
        {
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count > 0)
            {
                Query = "select 1 from tbl_exit_generaladminclearence where ExitId = " + Id + " and Status = 1 and ApproverStatus = 'A'";

                if (Lib.Bee.WGetData(Query).Tables[0].Rows.Count < 1)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'C' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "'";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                    if (Flag > 0)
                    {
                        Query = "update tbl_exit_generaladminclearence set ApproverStatus = 'C' where ExitId = " + Id + " and Status = 1";
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
                else
                    Output.Show("This application is already cancelled.");
            }
            else
            {
                if (DateOfClearence.Text != "")
                    Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "','" + DateOfClearence.Text.Trim() + "','C','" + UserCode + "',getdate(),1)";
                else
                    Query = @"insert into tbl_exit_generaladminclearence (ExitId,EmpCode,ApproverCode,KeysReturnedNumber,ReturnedKeyvalue,MobilePhoneReturnedWithCharger,DataCardReturned,SIMCardReturned,ReturnedIdentityAccessBadge,Others,DateOfClearence,ApproverStatus,CreatedBy,CreateDateTime,Status) 
values (" + Id + ",'" + EmpCode.Text.Trim() + "','" + UserCode + "','" + KeysReturnedNumber + "','" + Key.Text.Trim() + "','" + MobilePhoneReturnedWithCharger + "','" + DataCardReturned + "','" + SIMCardReturned + "','" + ReturnedIdentityAccessBadge + "','" + Others.Text.Trim() + "',null,'C','" + UserCode + "',getdate(),1)";

                Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);
                if (Flag > 0)
                {
                    Query = "update tbl_exit_ExitProcess set ApproverStatus = 'C' where ResignationId = " + Id + " and ApproversCode = '" + UserCode + "'";
                    Flag = Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query);

                    if (Flag > 0)
                    {
                        Lib.Bee.Commit();
                        Output.Show("Clearance Request Rejected.");
                    }
                    else
                    {
                        Lib.Bee.RollBack();
                        Output.Show("Application not cemcelled.");
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