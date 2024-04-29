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

public partial class Appraisal_ViewAllGoals : System.Web.UI.Page
{
    DataActivity DataActivity = new DataActivity();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] == null)
            Response.Redirect("~/LogOut.aspx");

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
                cmd.CommandText = @"select appcycle_id, from_month +'-'+ from_year +' to '+ to_month +'-'+ to_year appcyclename ,APP_year
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
                cmd.CommandText = @"     
select distinct
a.assessment_id,
a.empcode, 
j.emp_fname,
convert(varchar(11),j.emp_doj,101) emp_doj,
j.emp_gender,
stat.employeestatus,
--b.branch_name,
g.designationname,
convert(varchar(11),a.create_date,101) create_date,
a.APP_year,
case when c.freeze = 0 then 'Unfreezed'
 when c.freeze = 1 then 'Freezed'
  end as freeze
 from tbl_appraisal_assessment a 
  inner join tbl_intranet_employee_jobDetails j on a.empcode = j.empcode
  inner join tbl_intranet_designation g on g.id = j.degination_id
  inner join tbl_intranet_branch_detail b on b.branch_id = j.branch_id
  inner join tbl_appraisal_cycle c on c.appcycle_id = a.appcycle_id
inner join tbl_appraisal_eligible_employee empelg on empelg.empcode=a.empcode 
and a.appcycle_id =empelg.appcycle_id AND a.APP_year=empelg.APP_year
inner join tbl_intranet_employee_status stat on stat.id=j.emp_status
  
  
  where a.appcycle_id = @appcycleid";

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