using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ViewExitStatus : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string PageId = "Exit Approvers";
    int ApplicationId = 2;

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
            Id = Request.QueryString["ResignId"].ToString().Trim();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindDetails();
                BindApproverDetails();
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
where E.ResignationId = " + Id + ") A inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode left join tbl_intranet_employee_personalDetails P on A.EmpCode = P.empcode left join tbl_intranet_employee_contactlist C on C.empcode = A.EmpCode left join tbl_internate_departmentdetails D on job.dept_id = D.departmentid";

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

    private void BindApproverDetails()
    {
        Lib = new Base();
        // Application Type and Work Flow Type
        // Pending - Status = 1 and Resign Status = U
        Query = @"
select ExitId,
A.EmpCode,job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName, 
ApplicationId, 
ApplicationName,
ApproverStatus
from
(
select EP.ResignationId ExitId,EP.ApproversCode EmpCode,ApplicationId,ApplicationName,EP.ApproverStatus
from tbl_exit_ExitProcess EP 
inner join tbl_exit_applicationtype AT on EP.ApplicationId = AT.ApplicationTypeId
where EP.Status = 1 and ResignationId = (select ExitId
                                          from tbl_exit_Exit
                                           where ResignationId = " + Id + ")) A inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode order by ApplicationId";

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

            Server.Transfer("View" + Path + "?Id= " + Id + "&ResignId=" + Request.QueryString["ResignId"].ToString().Trim());
        }
        else
        {
            Output.Show("Applications are not defined. Please contact system admin.");
        }

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


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Server.Transfer("ExitStatusforHr.aspx");
    }
}