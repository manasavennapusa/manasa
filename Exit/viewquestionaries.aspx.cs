using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;
using System.Web.UI;
using System.Net.Mail;
using System.Configuration;
using Common.Data;
using System.Data.SqlClient;

public partial class Exit_viewquestionaries : System.Web.UI.Page
{
    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation

    string PageId = "Exit Approvers";

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
     
            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindDetails1();
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

    private void BindDetails1()
    {
        Lib = new Base();
        // Application Type and Work Flow Type
        // Pending - Status = 1 and Resign Status = U
        Query = @"
  
select  ExitId,A.EmpCode,job.emp_fname + ' ' + isnull(job.emp_l_name,'') + ' ' + isnull(job.emp_l_name,'') EmpName, ApplicationId, case when ApplicationId='6' then 'Exit Interview Questionaries'  end as ApplicationName,case when ApproverStatus='A' then 'Submitted' else 'Pending' end as ApproverStatus
from
(
select E.ExitId,E.EmpCode EmpCode,ApplicationId,ApplicationId as ApplicationName,EP.ApproverStatus
from tbl_exit_Exit E 
inner join tbl_exit_ExitProcess EP on E.ExitId = EP.ResignationId
inner join tbl_exit_ResignationProcess pro on pro.ResignationId=E.ResignationId
where pro.ApproversCode='" + UserCode + "' AND EP.ApplicationId = 6 AND pro.Level=3) A inner join tbl_intranet_employee_jobDetails job on A.EmpCode = job.empcode order by job.empcode";


        Lib.Bee.WBindGrid(Query, GridView1);

            

        // Cancelled - Status = 0 and Resign Status = C
        // Rejected - Status = 0 and Resign Status = J
        // Freezed - Status = 1 and Resign Status = F
        // Re-Initiate - Make Status = 0 and Resign Status = R for the previous record and insert new record with the same values except, Status = 1 and Resign Status = U
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int Id = (int)GridView1.DataKeys[(int)e.NewEditIndex].Value;

        //DataSet ds = Lib.Bee.WGetData(Query);
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    DataRow row = ds.Tables[0].Rows[0];
        //    string Path = row["Path"].ToString().Trim();

        //    Server.Transfer(Path + "?Id= " + Id);
        //}
        Server.Transfer("ExitInterviewQuestion.aspx?ResignId=" + Id + "");

  
    }
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        if (GridView1.Rows.Count > 0)
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}