using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ViewFormDepartmentalClearence : System.Web.UI.Page
{
    // Declarations

    string UserCode, RoleId;
    int WorkFlowTypeId = 2;    // Resignation
    string Id = "0";
    string ResignId = "0";

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
            Id = Request.QueryString["Id"].ToString().Trim();
            ResignId = Request.QueryString["ResignId"].ToString().Trim();

            #region Rule
            Exit = new ExitCommon();
            EmpRule = Exit.GetExitEmployeeRules();
            CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                BindDepartmentClearence();
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
    }


    private void BindDepartmentClearence()
    {
        try
        {
            Lib = new Base();
            Lib.Bee.OpenConnection();
            Lib.Bee.BeginTrasaction();

            Query = "select 1 from tbl_exit_departmentalclearence where ExitId = " + Id + " and Status = 1";
            if (Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query).Tables[0].Rows.Count > 0)
            {
                Query = "select * from tbl_exit_departmentalclearence where ExitId = " + Id + " and Status = 1";
                DataSet ds = Lib.Bee.TGetAllDataByQuery(Lib.Bee.Connection, Lib.Bee.Transaction, Query);
                DataRow row = ds.Tables[0].Rows[0];

                if (row["CompletedAssignedTask"].ToString() == "Y")
                {
                    CompletedAssignedTaskYes.Checked = true;
                    CompletedAssignedTaskNo.Checked = false;
                    CompletedAssignedTaskNA.Checked = false;
                }
                else if (row["CompletedAssignedTask"].ToString() == "N")
                {
                    CompletedAssignedTaskYes.Checked = false;
                    CompletedAssignedTaskNo.Checked = true;
                    CompletedAssignedTaskNA.Checked = false;
                }
                else
                {
                    CompletedAssignedTaskYes.Checked = false;
                    CompletedAssignedTaskNo.Checked = false;
                    CompletedAssignedTaskNA.Checked = true;
                }

                if (row["DataBackUpRequired"].ToString() == "Y")
                {
                    DataBackupRequiredYes.Checked = true;
                    DataBackupRequiredNo.Checked = false;
                    DataBackupRequiredNA.Checked = false;
                }
                else if (row["DataBackUpRequired"].ToString() == "N")
                {
                    DataBackupRequiredYes.Checked = false;
                    DataBackupRequiredNo.Checked = true;
                    DataBackupRequiredNA.Checked = false;
                }
                else
                {
                    DataBackupRequiredYes.Checked = false;
                    DataBackupRequiredNo.Checked = false;
                    DataBackupRequiredNA.Checked = true;
                }

                if (row["KnowledgeTransferDoc"].ToString() == "Y")
                {
                    KnowledgeTransferDocumentationYes.Checked = true;
                    KnowledgeTransferDocumentationNo.Checked = false;
                    KnowledgeTransferDocumentationNA.Checked = false;
                }
                else if (row["KnowledgeTransferDoc"].ToString() == "N")
                {
                    KnowledgeTransferDocumentationYes.Checked = false;
                    KnowledgeTransferDocumentationNo.Checked = true;
                    KnowledgeTransferDocumentationNA.Checked = false;
                }
                else
                {
                    KnowledgeTransferDocumentationYes.Checked = false;
                    KnowledgeTransferDocumentationNo.Checked = false;
                    KnowledgeTransferDocumentationNA.Checked = true;
                }

                WhoReceivedKnowledgeTransfer.Text = row["KnowledgeTransferDetails"].ToString();
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