using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;

public partial class Exit_ResignedEmployeeListForHr : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
    int ApplicationId = 1;
    string PageId = "Hr";

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

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindDetails();
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
        Query = @"select distinct ExitId,
A.EmpCode,
job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName, 
ApplicationId, 
ApplicationName,
ApproverStatus
from
(
select E.ExitId,E.EmpCode EmpCode,EP.ApplicationId,A.ApplicationName,EP.ApproverStatus
from tbl_exit_Exit E 
inner join tbl_exit_ExitProcess EP on E.ExitId = EP.ResignationId
inner join tbl_exit_Resignation R on R.ResignationId = E.ResignationId
inner join tbl_exit_ResignationProcess RP on R.ResignationId = RP.ResignationId
inner join tbl_exit_applicationtype A on EP.ApplicationId = A.ApplicationTypeId
where E.Status = 1 and 
EP.ApplicationId = 6 and 
EP.ApproverStatus = 'A' and 
EP.Status = 1 and 
R.ResignStatus = 'F' and
RP.ApproversCode = '" + UserCode + "' and RP.ApproverStatus = 'I') A  inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode where job.emp_status not in (4,5,6) and job.emp_doleaving is null";

        Lib.Bee.WBindGrid(Query, Grid);
        // Cancelled - Status = 0 and Resign Status = C
        // Rejected - Status = 0 and Resign Status = J
        // Freezed - Status = 1 and Resign Status = F
        // Re-Initiate - Make Status = 0 and Resign Status = R for the previous record and insert new record with the same values except, Status = 1 and Resign Status = U
    }



    protected void Grid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    {
        Lib = new Base();
        int Id = (int)Grid.DataKeys[(int)e.NewEditIndex].Value;
        Label AppId = (Label)Grid.Rows[(int)e.NewEditIndex].FindControl("lblAppId");

        Query = @"select * from tbl_exit_applicationtype where ApplicationTypeId = " + AppId.Text.Trim() + "";

        DataSet ds = Lib.Bee.WGetData(Query);
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            string Path = row["Path"].ToString().Trim();

            Server.Transfer("View" + Path + "?Id= " + Id + "&ResignId=0");
        }
        else
        {
            Output.Show("Applications are not defined. Please contact system admin.");
        }
    }

    protected void Grid_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

        Label lblEmpCode = (Label)Grid.Rows[e.RowIndex].FindControl("lblEmpCode");
        LinkButton lblStatus = (LinkButton)Grid.Rows[e.RowIndex].FindControl("lblStatus");
        DropDownList drpResignationType = (DropDownList)Grid.Rows[e.RowIndex].FindControl("ResignationType");

        //if (drpResignationType.SelectedValue == "0")
        //{
        //    Output.Show("Please select resignation type.");
        //    drpResignationType.Focus();
        //    return;
        //}


        int ExitId = (int)Grid.DataKeys[(int)e.RowIndex].Value;

        if (lblStatus.Text == "Deactivate")
        {
            try
            {
                Lib = new Base();
                Lib.Bee.OpenConnection();
                Lib.Bee.BeginTrasaction();

                Query = @"update tbl_intranet_employee_jobDetails set emp_status=2, reason_leaving='Releaved through exit process, please check in exit module for more details.' ,emp_doleaving = (select DefaultLWD from tbl_exit_Resignation where ResignationId = ( select ResignationId from tbl_exit_Exit where ExitId = " + ExitId + " ) )  where empcode = '" + lblEmpCode.Text.Trim() + "'";
                if (Lib.Bee.TApplyChanges(Lib.Bee.Connection, CommandType.Text, Lib.Bee.Transaction, Query) > 0)
                {
                    Lib.Bee.Commit();

                    //ExitApprovers objEmail = new ExitApprovers();
                    //int resignId = objEmail.GetResignationId(ExitId);

                    //string EmpNameCode = SendEmailToEmployee(resignId);
                    //SendEmailToLevel(resignId, EmpNameCode);

                    Output.Show("Deactivated Successfully");
                }
                else
                    Output.Show("Employee deactivated failed. Please try again later.");
            }
            catch (Exception ex)
            {
                //Lib.Bee.RollBack();
                Output.Log("During Departmental Clearence: " + ex.Message + ".    " + DateTime.Now);
                Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
            }
            finally
            {
                Lib.Bee.CloseConnection();
            }
            BindDetails();
        }
        else
        {
            Output.Show("This employee is already deactivated");
        }

    }

    protected void Grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblEmpCode = (Label)e.Row.FindControl("lblEmpCode");
            LinkButton lblStatus = (LinkButton)e.Row.FindControl("lblStatus");

            Query = @"select 1 from tbl_intranet_employee_jobDetails where emp_doleaving is null and empcode = '" + lblEmpCode.Text.Trim() + "'";
            DataSet ds = Lib.Bee.WGetData(Query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                lblStatus.Text = "Deactivate";
                lblStatus.CssClass = "btn btn-danger";
            }
            else
            {
                lblStatus.Text = "Deactivated";
                lblStatus.Enabled = false;

            }
        }
    }

    string SendEmailToEmployee(int resignId)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Exit.DeactivateEmp();
        EmailClient client = new EmailClient(email);
        ExitApprovers objEmail = new ExitApprovers();
        DataRow row = objEmail.GetResignationEmployee(resignId);
        client.toEmailId = row["officialemailid"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["empname"].ToString().Trim();
        client.Send();

        return row["empname"].ToString().Trim() + " ( " + row["empcode"].ToString() + " ) ";

    }

    void SendEmailToLevel(int resignId, string empNameCode)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Exit.DeactivateHR();
        EmailClient client = new EmailClient(email);
        ExitApprovers objEmail = new ExitApprovers();
        DataTable dt = objEmail.GetResignationApproversExceptHR(resignId);
        DataRow row = dt.Rows[2];
        client.toEmailId = row["officialemailid"].ToString().Trim();
        client.empCode = row["empcode"].ToString();
        client.employeeName = row["empname"].ToString().Trim();
        client.requestNumber = empNameCode;
        client.Send();     
    }
}