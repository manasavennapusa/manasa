using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;
using System.Configuration;
using DataAccessLayer;
//using System.Transactions;

public partial class Appraisal_PromotionStatus : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();
    string _userCode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] == null)
            Response.Redirect("~/notlogged.aspx");
        _userCode = Session["empcode"].ToString();

        if (!IsPostBack)
        {
            getActiveCycle();
            LoadAppraisalData();
        }
    }

    protected void grid_PreRender(object sender, EventArgs e)
    {
        if (grid.Rows.Count > 0)
            grid.HeaderRow.TableSection = TableRowSection.TableHeader;
        else grid.EmptyDataText = "No Records Found";
    }

    private void getActiveCycle()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"select appcycle_id, from_month +'-'+ from_year +' to '+ to_month +'-'+ to_year appcyclename,APP_year
                                     from tbl_appraisal_cycle 
                                      where status = 1
                                       order by appcycle_id desc";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                ddlAppraisalCycle.DataSource = dt;
                ddlAppraisalCycle.DataValueField = "appcycle_id";
                ddlAppraisalCycle.DataTextField = "APP_year";
                ddlAppraisalCycle.DataBind();
            }
        }
    }

    private void LoadAppraisalData()
    {
        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                string query1 = @"SELECT appcycle_id,quater,APP_year FROM tbl_appraisal_cycle where status=1";
                DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, query1);
                string quater = ds1.Tables[0].Rows[0]["quater"].ToString();
                string APP_year = ds1.Tables[0].Rows[0]["APP_year"].ToString();
                //                cmd.CommandText = @"     
                //select 
                //  a.assessment_id,
                //  a.empcode, 
                //  j.emp_fname,
                //  case when h.ismin2yearsonsamerole = 0 then 'Select'
                //       when h.ismin2yearsonsamerole = 1 then 'Yes'
                //       when h.ismin2yearsonsamerole = 2 then 'No' end ismin2yearsonsamerole,
                //
                //  case when h.avr2yearweightagegreaterthan85 = 0 then 'Select'
                //       when h.avr2yearweightagegreaterthan85 = 1 then 'Yes'
                //       when h.avr2yearweightagegreaterthan85 = 2 then 'No' end avr2yearweightagegreaterthan85,
                // 
                //  h.reason,
                //  case when h.approvalstatus = 0 then 'Pending in Employee'
                //       when h.approvalstatus = 1 then 'Pending in LM'
                //       when h.approvalstatus = 2 then 'Pending in BH'
                //       when h.approvalstatus = 3 then 'Approved by BH' end approvalstatus ,
                //
                //  case when h.promotionstatus = 0 then 'Pending'
                //       when h.promotionstatus = 6 then 'Approved' end promotionstatus
                //
                //   from tbl_appraisal_promotion h
                //    inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id   
                //    left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
                //     where a.appcycle_id = @appcycleid";

                cmd.CommandText = @"select a.assessment_id,a.empcode,j.emp_fname,case when h.ismin2yearsonsamerole = 0 then 'Select'
when h.ismin2yearsonsamerole = 1 then 'Yes' when h.ismin2yearsonsamerole = 2 then 'No' end ismin2yearsonsamerole,
case when h.avr2yearweightagegreaterthan85 = 0 then 'Select' when h.avr2yearweightagegreaterthan85 = 1 then 'Yes'
when h.avr2yearweightagegreaterthan85 = 2 then 'No' end avr2yearweightagegreaterthan85,h.reason,
case when h.approvalstatus = 'VH' then 'Pending in BH' when h.approvalstatus = 'S' then 'Approved by BH' when h.approvalstatus = '0' then 'Pending in VH'
when h.approvalstatus = 'R' then 'Rejected by BH'end approvalstatus,
case when h.promotionstatus = 'P' then 'Pending in VH' when h.promotionstatus = 'P1' then 'Pending in BH'
when h.promotionstatus = 'P1_S' then 'Approved by BH' when h.promotionstatus = 'P1_R' then 'Rejected by BH' end promotionstatus,a.APP_year
from tbl_appraisal_promotion h
inner join tbl_appraisal_assessment a on h.assessmentid = a.assessment_id
left join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
 where a.appcycle_id = @appcycleid and a.APP_year='" + APP_year + "' and (a.promotion_status ='Initiated' OR a.promotion_status ='Approved')";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;

                cmd.Parameters.Add("@appcycleid", SqlDbType.Int).Value = Convert.ToInt32(ddlAppraisalCycle.SelectedValue);

                DataTable dt = new DataTable();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                grid.DataSource = dt;
                grid.DataBind();

            }
        }
    }

    protected void ddlAppraisalCycle_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAppraisalData();
    }

}

