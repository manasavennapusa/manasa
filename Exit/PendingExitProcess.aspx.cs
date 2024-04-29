using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_PendingExitProcess : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation

    string PageId = "Exit Approvers";

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
            //if (Request.QueryString["approve"] != null)
            //    Output.Show("Application cancelled successfully.");
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["msg"] != null)
        {
            if (Request.QueryString["msg"].ToString().Trim() == "Approved")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", Smart.HR.Common.Console.Output.Message("Submitted Successfully"));
            }
        }
    }

    private void BindDetails()
    {
        Lib = new Base();
        // Application Type and Work Flow Type
        // Pending - Status = 1 and Resign Status = U
        Query = @"
select ExitId,A.EmpCode,job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName, ApplicationId, ApplicationName,case when ApproverStatus='A' then 'Submitted' else 'Pending' end as ApproverStatus
from
(
select E.ExitId,E.EmpCode EmpCode,ApplicationId,ApplicationName,EP.ApproverStatus
from tbl_exit_Exit E 
inner join tbl_exit_ExitProcess EP on E.ExitId = EP.ResignationId
inner join tbl_exit_applicationtype AT on EP.ApplicationId = AT.ApplicationTypeId
where E.WorkFlowTypeId = " + WorkFlowTypeId + "  and E.Status = 1 and E.ResignStatus in ('U') and E.EmpCode = '" + UserCode + "' and EP.ApproverStatus = 'P' and EP.Status = 1) A inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode order by job.empcode";

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

            Server.Transfer(Path + "?Id= " + Id);
        }
        else
        {
            Output.Show("Applications are not defined. Please contact system admin.");
        }
        Output.Show("Submitted Successfully");
    }
    protected void Grid_PreRender(object sender, EventArgs e)
    {
        if (Grid.Rows.Count > 0)
            Grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}