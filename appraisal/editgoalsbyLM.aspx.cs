using DataAccessLayer;
using Smart.HR.Common.Console;
using Smart.HR.Common.Data;
using Smart.HR.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class appraisal_editgoalsbyLM : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string UserCode,employeecode,assessmentid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        UserCode = Session["empcode"].ToString();
        if (Request.QueryString["empcode"].ToString() != null)
        {
            employeecode = Request.QueryString["empcode"].ToString();
            assessmentid = Request.QueryString["asd_id"].ToString();
        }
        if (!IsPostBack)
        {
            bindGoal();
        }
       
    }

    protected void bindGoal()
    {
        SqlConnection Connection = null;
        try
        {
            Connection = DataActivity.OpenConnection();

            string str = @"select asd.empcode,asd.asd_id,assessment_id,asd.flow_id,asd.role,asd.kca,asd.kpi,asd.weightage,asd.create_by  
from tbl_appraisal_assessment_details asd
inner join tbl_intranet_employee_jobDetails jd on jd.empcode=asd.empcode where asd.empcode='" + employeecode + "' and asd.asd_id='" + assessmentid + "'";
            DataSet ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, str);
            if (ds.Tables[0].Rows.Count > 0)
            {
                textrole.Text = ds.Tables[0].Rows[0]["role"].ToString();
                textkca_outcome.Text = ds.Tables[0].Rows[0]["kca"].ToString();
                textkpi_milestone.Text = ds.Tables[0].Rows[0]["kpi"].ToString();
                txtWeightage_timeline.Text = ds.Tables[0].Rows[0]["weightage"].ToString();
            }
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            DataActivity.CloseConnection();
        }
    }

    protected void btnupdate_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam = new SqlParameter[22];
        int i = 0;
        try
        {
            string sqlstr = @"Update tbl_appraisal_assessment_details 
Set role='" + textrole.Text + "',kca='" + textkca_outcome.Text + "',kpi='" + textkpi_milestone.Text + "',weightage='" + txtWeightage_timeline.Text + "' where empcode='" + employeecode + "' and asd_id='" + assessmentid + "'";
            i = DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not Saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            if (i > 0)
            {
                Response.Redirect("ReviewGoalsByManager.aspx?upd=true");
            }
        }
    }

    protected void btnback_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReviewGoalsByManager.aspx");
    }

}