using System;
using System.Data;
using Smart.HR.BeeLogic;
using Smart.HR.Contracts;
using Smart.HR.Common.Console;
using System.Web.UI.WebControls;

public partial class Exit_ExitReportDetails : System.Web.UI.Page
{
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

            //if (ApproverRule.CanEditLWD != "Y")
            //    EditLED.Visible = false;

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

        string Query1 = @"select ApproversCode,ApproverComments from tbl_exit_ResignationProcess where Level=1 and ResignationId='" + ResignId + "' select ApproversCode,ApproverComments from tbl_exit_ResignationProcess where Level=2 and ResignationId='" + ResignId + "' select ApproversCode,ApproverComments from tbl_exit_ResignationProcess where Level=3 and ResignationId='"+ResignId+"'";
        DataSet ds1 = Lib.Bee.WGetData(Query1);
        DataRow row1 = ds1.Tables[0].Rows[0];
        DataRow row2 = ds1.Tables[1].Rows[0];
        DataRow row3 = ds1.Tables[2].Rows[0];

        if (ds1.Tables[0].Rows.Count > 0)
            lbllmcomments.Text = row1["ApproverComments"].ToString();
        else
            lbllmcomments.Text = "";
        
        if (ds1.Tables[1].Rows.Count > 0)
            lblbhcomments.Text = row2["ApproverComments"].ToString();
        else
            lblbhcomments.Text = "";

        if (ds1.Tables[2].Rows.Count > 0)
            lblhrcomments.Text = row3["ApproverComments"].ToString();
        else
            lblhrcomments.Text = "";

        string strquery = @"declare @empcode varchar(20) set @empcode=(select EmpCode from dbo.tbl_exit_Resignation where ResignationId=" + ResignId + "); select * from dbo.tbl_exit_interviewquestion where EmpCode=@empcode ";
        DataSet ds2 = Lib.Bee.WGetData(strquery);
        DataRow dr = ds2.Tables[0].Rows[0];

        if (Convert.ToInt32(dr["Position"].ToString()) == 1)
            iblreason1.Text = "Took another position";
        else
            lbl1.Visible = false;

        if (Convert.ToInt32(dr["Home"].ToString()) == 1)
            iblreason2.Text = "Home/family needs";
        else
            lbl2.Visible = false;

        if (Convert.ToInt32(dr["Health"].ToString()) == 1)
            iblreason3.Text = "Poor health/physical disability";
        else
            lbl3.Visible = false;

        if (Convert.ToInt32(dr["Relocation"].ToString()) == 1)
            iblreason4.Text = "Relocation to another city";
        else
            lbl4.Visible = false;

        if (Convert.ToInt32(dr["Travel"].ToString()) == 1)
            iblreason5.Text = "Travel difficulties";
        else
            lbl5.Visible = false;

        if (Convert.ToInt32(dr["Education"].ToString()) == 1)
            iblreason6.Text = "To attend Education";
        else
            lbl6.Visible = false;

        if (Convert.ToInt32(dr["Dissatisfaction"].ToString()) == 1)
            iblreason7.Text = "Dissatisfaction with salary";
        else
            lbl7.Visible = false;

        if (Convert.ToInt32(dr["Dis_work"].ToString()) == 1)
            iblreason8.Text = "Dissatisfaction-work";
        else
            lbl8.Visible = false;

        if (Convert.ToInt32(dr["Dis_Supervisor"].ToString()) == 1)
            iblreason9.Text = "Dissatisfaction -supervisor";
        else
            lbl9.Visible = false;

        if (Convert.ToInt32(dr["Dis_co"].ToString()) == 1)
            iblreason10.Text = "Dissatisfaction -co-workers";
        else
            lbl10.Visible = false;

        if (Convert.ToInt32(dr["Dis_work_condition"].ToString()) == 1)
            iblreason11.Text = "Dissatisfaction– working Conditions";
        else
            lbl11.Visible = false;

        if (Convert.ToInt32(dr["Dis_benifits"].ToString()) == 1)
            iblreason12.Text = "Dissatisfaction with benefits";
        else
            lbl12.Visible = false;

        if (Convert.ToInt32(dr["Laid_off"].ToString()) == 1)
            iblreason13.Text = "LAID OFF";
        else
            lbl13.Visible = false;

        if (Convert.ToInt32(dr["Lack_of_work"].ToString()) == 1)
            iblreason14.Text = "Lack of work";
        else
            lbl14.Visible = false;

        if (Convert.ToInt32(dr["Abolition"].ToString()) == 1)
            iblreason15.Text = "Abolition of position";
        else
            lbl15.Visible = false;

        if (Convert.ToInt32(dr["Funds"].ToString()) == 1)
            iblreason16.Text = "Lack of funds";
        else
            lbl16.Visible = false;

        if (Convert.ToInt32(dr["Termination"].ToString()) == 1)
            iblreason17.Text = "Termination";
        else
            lbl17.Visible = false;

    }
    protected void back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ExitReport.aspx");
    }

    
}