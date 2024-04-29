using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ViewResignationDetails : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 1;    // Resignation
    int ApplicationId = 1;
    string PageId = "Employee";

    IBase Lib = null;
    string Query = "";
    ExitCommon Exit = null;
    ExitEmployeeRule EmpRule = null;
    ExitCompanyRule CompanyRule = null;
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
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                EmployeeTypeId.Value = "";
                BindDetails(ResignId);
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }

    private void BindDetails(int ResignId)
    {
        Lib = new Base();
        Exit = new ExitCommon();

        string query = @"select distinct pro.ResignationId from tbl_exit_ResignationProcess pro
inner join tbl_employee_approvers app on app.app_dotted_linemanager=pro.ApproversCode
inner join tbl_exit_Resignation res on res.ResignationId=pro.ResignationId
where pro.ResignationId='" + ResignId + "' and pro.Level=1 and CONVERT(varchar(20), DATEADD(day, 2, res.AppliedDate), 102) = CONVERT(varchar(20), GETDATE(), 102)";
        DataSet ds2 = Lib.Bee.WGetData(query);

        if (ds2.Tables[0].Rows.Count > 0)
        {

            Query = @"select ResignPro.ApproversCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,ResignPro.ApproverComments,ApproverStatus,WF.WorkFlowName
                  from tbl_exit_ResignationProcess ResignPro
                   inner join tbl_exit_Resignation Resign on ResignPro.ResignationId = Resign.ResignationId
                   left join tbl_intranet_employee_jobDetails job on ResignPro.ApproversCode = job.empcode
                   left join tbl_exit_workflow WF on ResignPro.Level = WF.WorkFlowId
                  where ResignPro.ResignationId = " + ResignId + " order by WF.WorkFlowId";
            DataSet ds1 = Lib.Bee.WGetData(Query);
            ds1.Tables[0].Rows[0]["WorkFlowName"] = "Dotted Line Manager";
            DataTable dt = new DataTable();
            dt.Columns.Add("ApproversCode");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("ApproverStatus");
            dt.Columns.Add("ApproverComments");
            dt.Columns.Add("WorkFlowName");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {


                DataRow rw = dt.NewRow();
                rw["ApproversCode"] = ds1.Tables[0].Rows[i]["ApproversCode"].ToString();
                rw["EmpName"] = ds1.Tables[0].Rows[i]["EmpName"].ToString();
                rw["ApproverStatus"] = ds1.Tables[0].Rows[i]["ApproverStatus"].ToString();
                rw["ApproverComments"] = ds1.Tables[0].Rows[i]["ApproverComments"].ToString();
                rw["WorkFlowName"] = ds1.Tables[0].Rows[i]["WorkFlowName"].ToString();
                dt.Rows.Add(rw);

                if (ds1.Tables[0].Rows[i]["ApproverStatus"].ToString() == "J")
                {
                    break;
                }

            }

            Grid.DataSource = dt;
            Grid.DataBind();
            //Grid.DataSource = ds1;
            //Grid.DataBind();
            //Lib.Bee.WBindGrid(Query, Grid);
        }
        else
        {
            Query = @"select ResignPro.ApproversCode,emp_fname +' '+ isnull(emp_m_name,'') +' '+ isnull(emp_l_name,'') EmpName,ResignPro.ApproverComments,ApproverStatus,WF.WorkFlowName
                  from tbl_exit_ResignationProcess ResignPro
                   inner join tbl_exit_Resignation Resign on ResignPro.ResignationId = Resign.ResignationId
                   left join tbl_intranet_employee_jobDetails job on ResignPro.ApproversCode = job.empcode
                   left join tbl_exit_workflow WF on ResignPro.Level = WF.WorkFlowId
                  where ResignPro.ResignationId = " + ResignId + " order by WF.WorkFlowId";
            DataSet ds1 = Lib.Bee.WGetData(Query);
            DataTable dt = new DataTable();
            dt.Columns.Add("ApproversCode");
            dt.Columns.Add("EmpName");
            dt.Columns.Add("ApproverStatus");
            dt.Columns.Add("ApproverComments");
            dt.Columns.Add("WorkFlowName");
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {


                DataRow rw = dt.NewRow();
                rw["ApproversCode"] = ds1.Tables[0].Rows[i]["ApproversCode"].ToString();
                rw["EmpName"] = ds1.Tables[0].Rows[i]["EmpName"].ToString();
                rw["ApproverStatus"] = ds1.Tables[0].Rows[i]["ApproverStatus"].ToString();
                rw["ApproverComments"] = ds1.Tables[0].Rows[i]["ApproverComments"].ToString();
                rw["WorkFlowName"] = ds1.Tables[0].Rows[i]["WorkFlowName"].ToString();
                dt.Rows.Add(rw);

                if (ds1.Tables[0].Rows[i]["ApproverStatus"].ToString() == "J")
                {
                    break;
                }

            }

            Grid.DataSource = dt;
            Grid.DataBind();
        }
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
            txtComments.Text = row["Comments"].ToString();
        }

    }

    private void Cancel()
    {
        IBase Base = new Base();
        int Flag = 0;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'C' where ResignStatus = 'U' and ResignationId = " + ResignId + ";";
            Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);

            if (Flag > 0)
            {
                Query = "insert into tbl_exit_ResignationProcess (ResignationId,ApproversCode,ApproverStatus,ApproverComments,Level,Status) values (" + ResignId + ",'" + UserCode + "','C','Cancelled by himself',0,1)";
                Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            }

            Base.Bee.Commit();

            if (Flag > 0)
            {
                BindDetails(ResignId);
                Output.Show("Resignation application cancelled successfully.");
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
    }

    private void Reject()
    {
        IBase Base = new Base();
        int Flag = 0;
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "update tbl_exit_Resignation set ResignStatus = 'J' where ResignStatus = 'U' and ResignationId = " + ResignId + ";";
            Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            if (Flag > 0)
            {
                Query = "insert into tbl_exit_ResignationProcess (ResignationId,ApproversCode,ApproverStatus,ApproverComments,Level,Status) values (" + ResignId + ",'" + UserCode + "','J','Rejected by himself',0,1)";
                Flag = Base.Bee.TApplyChanges(Base.Bee.Connection, CommandType.Text, Base.Bee.Transaction, Query);
            }

            Base.Bee.Commit();
            if (Flag > 0)
            {
                BindDetails(ResignId);
                Output.Show("Resignation application rejected successfully.");
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
    }

    private void ReInitiate()
    {
        IBase Base = new Base();
        try
        {
            Base.Bee.OpenConnection();
            Base.Bee.BeginTrasaction();

            Query = "sp_exit_resignationrerequest";

            DataSet Flag = Base.Bee.TGetAllDataByProcedure(Base.Bee.Connection, Base.Bee.Transaction, Query, ResignId, UserCode, WorkFlowTypeId);
            DataRow Row = Flag.Tables[0].Rows[0];
            Base.Bee.Commit();
            Output.Show(Row["Msg"].ToString());
        }
        catch (Exception ex)
        {
            Base.Bee.RollBack();
            Output.Log("During Re-Initiating Resignation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Base.Bee.CloseConnection();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        if (EmpRule.Cancel == "Y" && EmpRule.ApplicationTypeId == ApplicationId)
            Cancel();
        else
            Output.Show("You do not have permission to cancel resignation application. Please contact admin.");
    }

    protected void btnReject_Click(object sender, EventArgs e)
    {
        if (EmpRule.Reject == "Y" && EmpRule.ApplicationTypeId == ApplicationId)
            Reject();
        else
            Output.Show("You do not have permission to reject resignation application. Please contact admin.");
    }

    //protected void btnReInitiate_Click(object sender, EventArgs e)
    //{
    //    if (EmpRule.ReInitiate == "Y" && EmpRule.ApplicationTypeId == ApplicationId)
    //        ReInitiate();
    //    else
    //        Output.Show("You do not have permission to reject resignation application. Please contact admin.");
    //}

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
                Status.ForeColor = System.Drawing.Color.Green;
                Status.Text = "Approved";
            }
        }
    }
    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("EmpResignationStatus.aspx");
    }
}