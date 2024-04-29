using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;


public partial class Exit_HrResignationRejectViewDetails : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
    int ExitWorkFlowTypeId = 2;    // Resignation
    int ApplicationId = 1;
    string PageId = "Approver";

    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitCompanyRule CompanyRule = null;
    ExitWorkFlowRule ApproverRule = null;

    int ResignId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();
            ResignId = Convert.ToInt32(Request.QueryString["ResignId"].ToString().Trim());

            #region Rule
            Exit = new ExitCommon();
            Lib = new Base();

            DataSet ds = Lib.Bee.WGetData("select EmpCode from tbl_exit_Resignation where ResignationId = " + ResignId + "");
            DataRow row = ds.Tables[0].Rows[0];
            CompanyRule = Exit.GetExitCompanyRules();
            ApproverRule = Exit.GetExitWorkRules(UserCode, row["EmpCode"].ToString().Trim());

            #endregion

            if (ApproverRule.CommentBoxRequired != "Y")
                CommentBox.Visible = false;

            if (ApproverRule.CanEditLWD != "Y")
                EditLED.Visible = false;

            if (!IsPostBack)
            {
                LWD.Visible = false;
                EmployeeTypeId.Value = "";
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
        Exit = new ExitCommon();

        Query = @"select ResignPro.ApproversCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,ResignPro.ApproverComments,ApproverStatus,WF.WorkFlowName
                  from tbl_exit_ResignationProcess ResignPro
                   inner join tbl_exit_Resignation Resign on ResignPro.ResignationId = Resign.ResignationId
                   left join tbl_intranet_employee_jobDetails job on ResignPro.ApproversCode = job.empcode
                   left join tbl_exit_workflow WF on ResignPro.Level = WF.WorkFlowId
                  where ResignPro.ResignationId = " + ResignId + " order by WF.WorkFlowId";

        Lib.Bee.WBindGrid(Query, Grid);

        Query = @"select ResignationId,AppliedDate,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,Comments,stat.employeestatus as EmployeeStatus,Resign.NoticePeriod,DefaultLWD
                   from tbl_exit_Resignation Resign
                    left join tbl_intranet_employee_jobDetails job on Resign.EmpCode = job.empcode
                    left join tbl_intranet_employee_status stat on Resign.EmployeeType = stat.id
                   where Resign.ResignationId = " + ResignId + "";

        DataSet ds = Lib.Bee.WGetData(Query);

        if (ds.Tables[0].Rows.Count > 0)
        {
            DataRow row = ds.Tables[0].Rows[0];
            lblAppliedDate.Text = row["AppliedDate"].ToString();
            lblEmployeeType.Text = row["EmployeeStatus"].ToString();
            lblNoticePeriod.Text = row["NoticePeriod"].ToString();
            lblDLWD.Text = row["DefaultLWD"].ToString();
            lblComments.Text = row["Comments"].ToString();
        }

        //if (Grid.Rows.Count >2)
        //{
        //    Label lblStatus = (Label)Grid.Rows[2].FindControl("lblStatus");
        //    if (lblStatus.Text == "Approved")
        //    {
        //        btnInitiateExit.Visible = true;
        //        btnCancel.Visible = true;
        //    }
        //    else
        //    {
        //        btnInitiateExit.Visible = false;
        //        btnCancel.Visible = false;
        //    }
        //}
    }


    private void Cancel()
    {
        IBase Base = new Base();
        bool istrue = false;

        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'C' where ResignationId = " + ResignId + ";";
            Query += "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'C' where ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "';";
            Query += "update tbl_intranet_employee_jobDetails set emp_doleaving = null where empcode = (select EmpCode from tbl_exit_Resignation where ResignationId = " + ResignId + " );";

            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (Flag > 0)
            {
                //BindDetails();
                //Output.Show("Resignation application cancelled successfully.");
                istrue = true;
            }
            else
                Output.Show("Resignation application not cancelled. Please try again later.");


        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
            Server.Transfer("HrResignationView.aspx?msg=Cancel");
    }

    private void Reject()
    {
        IBase Base = new Base();
        bool istrue = false;

        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'J' where ResignationId = " + ResignId + ";";
            Query += "update tbl_exit_ResignationProcess set ApproverComments = '" + txtComments.Text.Trim() + "', ApproverStatus = 'J' where ResignationId = " + ResignId + " and ApproversCode = '" + UserCode + "';";
            Query += "update tbl_intranet_employee_jobDetails set emp_doleaving = null where empcode = (select EmpCode from tbl_exit_Resignation where ResignationId = " + ResignId + " );";

            int Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            Base.Bee.Commit();

            if (Flag > 0)
            {
                //BindDetails();
                //Output.Show("Resignation application rejected successfully.");
                istrue = true;
            }
            else
                Output.Show("Resignation application not rejected. Please try again later.");

        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
            Server.Transfer("HrResignationView.aspx?msg=Reject");
    }


    private void InitiateNextWorkFlow()
    {
        IBase Base = new Base();
        DataSet Flag = null;
        bool istrue = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "sp_exit_initiatenextworkflow";

            Flag = Base.Bee.TGetAllDataByProcedure(Base.Bee.Connection, Base.Bee.Transaction, Query, ResignId, ExitWorkFlowTypeId, UserCode, txtComments.Text.Trim());
            DataRow Row = Flag.Tables[0].Rows[0];
            Base.Bee.Commit();
            if (Row["Msg"].ToString() == "True")
                istrue = true;
            else
                Output.Show(Row["Msg"].ToString());
        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        if (istrue == true)
            Server.Transfer("HrResignationView.aspx?msg=Approved");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Cancel == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Cancel();
        else
            Output.Show("You do not have permission to cancel resignation application. Please contact admin.");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        if (ApproverRule.Reject == "Y" && ApproverRule.ApplicationId == ApplicationId)
            Reject();
        else
            Output.Show("You do not have permission to reject resignation application. Please contact admin.");
    }

    protected void btnInitiateExit_Click(object sender, EventArgs e)
    {
        if (ApproverRule.InitiateNextWorkFlow == "Y" && ApproverRule.ApplicationId == ApplicationId)
            InitiateNextWorkFlow();
        else
            Output.Show("You do not have permission to approve resignation application. Please contact admin.");
    }

    protected void Grid_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
    {
        if (e.Row.RowType == System.Web.UI.WebControls.DataControlRowType.DataRow)
        {
            Label Status = (Label)e.Row.FindControl("lblStatus");
            if (Status.Text == "A")
            {
                Status.ForeColor = System.Drawing.Color.Green;
                Status.Text = "Approved";
            }
            else if (Status.Text == "P")
            {
                Status.ForeColor = System.Drawing.Color.Orange;
                Status.Text = "Pending";
            }
            else if (Status.Text == "C")
            {
                Status.ForeColor = System.Drawing.Color.Red;
                Status.Text = "Cancelled";
            }
            else if (Status.Text == "J")
            {
                Status.ForeColor = System.Drawing.Color.SteelBlue;
                Status.Text = "Rejected";
            }
            else if (Status.Text == "I")
            {
                Status.ForeColor = System.Drawing.Color.SteelBlue;
                Status.Text = "Exit Initiated";
            }
        }
    }

    private bool UpdateLWD()
    {
        IBase Base = new Base();
        int Flag = 0;
        bool Flip = false;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set DefaultLWD = '" + NewLWD.Text.Trim() + "' where ResignationId = " + ResignId + ";";
            Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);

            Query = "insert into tbl_exit_Resignation_LWD (ResignationId,Old_LWD,New_LWD,Status,UpdatedBy,UpdatedDate) values (" + ResignId + ",'" + lblDLWD.Text.Trim() + "','" + NewLWD.Text.Trim() + "',1,'" + UserCode + "',getdate())";
            Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);

            Base.Bee.Commit();

            if (Flag > 0)
            {
                Flip = true;
            }
        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Updating LWD: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }

        return Flip;
    }

    protected void EditLED_Click(object sender, EventArgs e)
    {
        if (EditLED.Text == "Edit")
        {
            LWD.Visible = true;
            EditLED.Text = "Update LWD";
        }
        else if (EditLED.Text == "Update LWD")
        {
            if (NewLWD.Text.Trim() != "")
            {
                if (Convert.ToDateTime(lblAppliedDate.Text) <= Convert.ToDateTime(NewLWD.Text.Trim()))
                {
                    if (ApproverRule.CanEditLWD == "Y")
                    {
                        if (UpdateLWD())
                        {
                            LWD.Visible = false;
                            EditLED.Text = "Edit";
                            BindDetails();
                        }
                    }
                    else
                        Output.Show("You do not have permission to edit LWD. Please contact admin.");
                }
                else
                {
                    Output.Show("You have entered invalid date.");
                }
            }
        }
    }

    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("CancelledResignationRequestForApprover.aspx");
    }
}