using System;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;


public partial class appraisal_EmpRatingStatus : System.Web.UI.Page
{
    string UserCode, RoleId;
    //int WorkFlowTypeId = 1;    // Resignation
    //int ApplicationId = 1;
    //string PageId = "Employee";
    DataActivity DataActivity = new DataActivity();
    //IBase Lib = null;
    //string Query = "";
    //ExitCommon Exit = null;
    //ExitEmployeeRule EmpRule = null;
    //ExitCompanyRule CompanyRule = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] != null)
        {
            UserCode = Session["empcode"].ToString();
            RoleId = Session["role"].ToString();

            #region Rule
            //Exit = new ExitCommon();
            //EmpRule = Exit.GetExitEmployeeRules();
            //CompanyRule = Exit.GetExitCompanyRules();
            #endregion

            if (!IsPostBack)
            {
                drp_exitstatus.SelectedIndex = 0;
            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

        if (Request.QueryString["msg"] != null)
        {
            if (Request.QueryString["msg"].ToString().Trim() == "True")
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", Smart.HR.Common.Console.Output.Message("Resignation request has been submitted successfully."));
            }
        }
    }

    //protected void Grid_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
    //{
    //    int Id = (int)Grid.DataKeys[(int)e.NewEditIndex].Value;
    //    Server.Transfer("ViewResignationDetails.aspx?ResignId=" + Id + "");
    //}
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bind_grid();
    }

    protected void bind_grid()
    {
        SqlConnection Connection = null;
        Connection = DataActivity.OpenConnection();
        if (Convert.ToInt32(drp_exitstatus.SelectedValue) == 2)
        {

            string Query = @"select ass.empcode,ass.assessment_id,job.emp_fname,case when ass.R_cycle=4 then 'Approved' else 'Pending' end as R_cycle  from tbl_appraisal_assessment ass inner join tbl_intranet_employee_jobDetails job on job.empcode=ass.empcode where ass.empcode='" + UserCode + "' and ass.G2_cycle=1 and ass.R_cycle=4";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);
            
            Grid.DataSource = ds;
            Grid.DataBind();
            
        }


        else if (Convert.ToInt32(drp_exitstatus.SelectedValue) == 1)
        {

            string Query = @"select ass.empcode,ass.assessment_id,job.emp_fname,case when ass.R_cycle=4 then 'Approved' else case when ass.R_cycle=2 then 'Pending at LM' else case when ass.R_cycle=2 then 'Pending at BH' else
'Pending' end end end as R_cycle  from tbl_appraisal_assessment ass inner join tbl_intranet_employee_jobDetails job on job.empcode=ass.empcode where ass.empcode='" + UserCode + "' and ass.G2_cycle=1 and (ass.R_cycle=3 or ass.R_cycle=2 or ass.R_cycle=1)";
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, Query);

            Grid.DataSource = ds;
            Grid.DataBind();

        }

    }


    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }

    protected void reset()
    {
        drp_exitstatus.SelectedIndex = -1;
    }
}