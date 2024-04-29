using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;
using CodeEngine.Framework.QueryBuilder;
using CodeEngine.Framework.QueryBuilder.Enums;
using System.IO;
using Common.Data;
using System.Data.SqlClient;
using Common.Console;
using System.Text;
using DataAccessLayer;
using System.Configuration;
using System.Drawing;

public partial class appraisal_Evaluation_Report : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string empcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            empcode = Request.QueryString["empcode"].ToString();
            BindReports();
        }
        
    }

    protected void BindReports()
    {
        string sqlstr = @"select jd.empcode as [Employee Code],
COALESCE(jd.emp_fname,'')+''+COALESCE(jd.emp_m_name,'')+''+COALESCE(jd.emp_l_name,'') as [Employee Name],
app.emp_overall_rating as  [Employee Overall Rating],
app.emp_overall_cmt as [Employee Overall Comment],
jd2.empcode as [Manager Code],
COALESCE(jd2.emp_fname,'')+''+COALESCE(jd2.emp_m_name,'')+''+COALESCE(jd2.emp_l_name,'') as [Manager Name],
app.mgr_overall_rating as  [Manager Overall Rating],
app.mgr_overall_cmt as  [Manager Overall Comment],
jd3.empcode as [Business Head Code],
COALESCE(jd3.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Business Head Name],
jd3.empcode as [Virtual Head Code],
COALESCE(jd4.emp_fname,'')+''+COALESCE(jd3.emp_m_name,'')+''+COALESCE(jd3.emp_l_name,'') as [Virtual Head Name],
branch.branch_name as Branch,dept.department_name as Department, 
desig.designationname as Designation,st.employeestatus As [Employee Status],
case when (h.ishike=1) then 'YES' else 'NO' END  as [IsHike],
app.hike_status as[Hike status],h.hikeInPercent as [Hike InPercent],hc.comments as [Virtual Head Hike comments],hc.BH_comment as [Business Head Hike comments],
case when (p.ismin2yearsonsamerole=1) then 'YES' else 'NO' END AS [IsPromotion],
pc.comments as [Virtual Head Promotion comments] , pc.BH_comment as [Business Head Promotion comments], 

app.promotion_status as [Promotion Status]
from tbl_intranet_employee_jobDetails jd
inner join tbl_appraisal_assessment app on  app.empcode=jd.empcode
inner JOIN tbl_intranet_designation desig ON jd.degination_id=desig.id    
inner JOIN tbl_internate_departmentdetails dept ON jd.dept_id=dept.departmentid    
inner JOIN tbl_intranet_branch_detail branch ON jd.branch_id=branch.Branch_id    
inner join tbl_intranet_employee_status st on st.id=jd.emp_status
inner join tbl_employee_approvers appr on appr.empcode=jd.empcode
inner join tbl_intranet_employee_jobDetails jd2 on jd2.empcode= appr.app_reportingmanager
inner join tbl_intranet_employee_jobDetails jd3 on jd3.empcode= appr.app_businesshead
inner join tbl_intranet_employee_jobDetails jd4 on jd4.empcode= appr.clr_department
inner join tbl_appraisal_hike h on h.empcode=app.empcode
inner join tbl_appraisal_hike_comments hc on hc.empcode=h.empcode
inner join tbl_appraisal_promotion p on p.empcode=h.empcode
inner join tbl_appraisal_promotion_comments pc on pc.empcode=p.empcode
where app.hike_status='Approved' and app.promotion_status='Approved' and jd.empcode='" + empcode + "'";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        grdgeneratereport.DataSource = ds;
        grdgeneratereport.DataBind();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    protected void btnExport_Click(object sender, EventArgs e)
    {
        if (grdgeneratereport.Rows.Count > 0)
        {
            //grdgeneratereport.HeaderRow.Cells[6].Visible = false;
            //grdgeneratereport.HeaderRow.Cells[8].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < grdgeneratereport.Rows.Count; i++)
            {
                GridViewRow row = grdgeneratereport.Rows[i];
                //row.Cells[6].Visible = false;
                //row.Cells[8].Visible = false;
                //grdgeneratereport.Columns[6].Visible = false;
                //grdgeneratereport.Columns[8].Visible = false;
            }
            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "Appraisal Report" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < grdgeneratereport.Rows.Count; i++)
            {

                grdgeneratereport.Rows[i].Style.Add("width", "150px");
                grdgeneratereport.Rows[i].Style.Add("height", "20px");
            }

            grdgeneratereport.GridLines = GridLines.Both;
            grdgeneratereport.HeaderStyle.Font.Bold = true;
            grdgeneratereport.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();

        }
    }

    protected void grdgeneratereport_PreRender(object sender, EventArgs e)
    {
        if (grdgeneratereport.Rows.Count > 0)
        {
            grdgeneratereport.UseAccessibleHeader=true;
            grdgeneratereport.HeaderRow.TableSection = TableRowSection.TableHeader;
              
        }
    }
}