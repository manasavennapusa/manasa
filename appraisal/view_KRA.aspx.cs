using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
using Smart.HR.Data;
using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using Smart.HR.Common.Mail.Module;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Web.UI;

public partial class appraisal_view_KRA : System.Web.UI.Page
{
    private string _companyId, _userCode;
    Common.Data.DataActivity DataActivity = new Common.Data.DataActivity();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
                Binddetails();
            }
            else
            {
                Response.Redirect("~/notlogged.aspx");
            }
        }
    }

    protected void Binddetails()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();
            // string str = @"select apt.assessment_id,aps.asd_id,apt.empcode,aps.kca,aps.weightage,aps.emp_comments,sd.parameter,aps.mng_comments ,sd.empcomments,sd.emprating,sd.mgrrating,sd.mgrcomments from tbl_appraisal_assessment_details aps inner join tbl_appraisal_assessment apt on aps.assessment_id=apt.assessment_id inner join tbl_appraisal_rating_details sd on sd.asd_id=aps.asd_id where apt.status in(1,3) and (apt.R_cycle=1 or R_cycle=5) and apt.appcycle_id=" + Convert.ToInt32(Session["appcycle"]) + " and  apt.empcode='" + Session["empcode"].ToString() + "'";
//            string str = @"select apt.assessment_id as initializeid,aps.asd_id,aps.flow_id,aps.assessment_id,apt.empcode,aps.kca,aps.weightage,aps.emp_comments,aps.mng_comments,aps.desigid  
//from tbl_appraisal_assessment_details aps 
//
//inner join tbl_appraisal_assessment apt on aps.desigid=apt.desigid
//
//where apt.status in(1,3) and (apt.R_cycle=1 or R_cycle=5) and
//apt.appcycle_id= '" + Convert.ToInt32(Session["appcycle"]) + "' and  apt.empcode='" + Session["empcode"].ToString() + "'";

//            string str = @"select apt.assessment_id as initializeid,aps.asd_id,aps.flow_id,aps.assessment_id,apt.empcode,aps.kca,aps.weightage,
//aps.emp_comments,aps.mng_comments,aps.desigid from tbl_appraisal_assessment_details aps 
//inner join tbl_appraisal_assessment apt on aps.desigid=apt.desigid
//where apt.status in(1,3) and apt.R_cycle=0 and apt.G1_cycle=1 and apt.G2_cycle=1 
//and apt.appcycle_id= '" + Convert.ToInt32(Session["appcycle"]) + "' and  apt.empcode='" + _userCode + "'";

            string str = @"select apt.empcode, role_name_of_the_goal,kca_kra_desired_outcome_impact,kpi_milestone_to_check_improvement,weightage_timeline_and_support_required,
designationid from tbl_appraisal_emp_goal_cycle1 goal_cycle1
left join tbl_appraisal_assessment apt on goal_cycle1.empcode=apt.empcode  and goal_cycle1.applycyclid =apt.appcycle_id
where (apt.G1_cycle=1 or apt.G2_cycle=1) and goal_cycle1.applycyclid= '" + Convert.ToInt32(Session["appcycle"]) + "' and  apt.empcode='" + _userCode + "' order by apt.empcode";

            DataSet ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, str);
            Grid.DataSource = ds;
            Grid.DataBind();
            
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
           DataActivity.CloseConnection();
        }
    }
    protected void Grid_PreRender(object sender, EventArgs e)
    {
        if (Grid.Rows.Count > 0)
            Grid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }
}