using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_viewtrainingschedule : System.Web.UI.Page
{
    string _userCode, _companyId, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            _companyId = Session["companyid"].ToString();
            RoleId = Session["role"].ToString();
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }

        if (!IsPostBack)
        {
            bindtrainingschedule();
        }
        if (Request.QueryString["upd"] != null)
        {
            SmartHr.Common.Alert("Updated Successfully");
        }
        if (Request.QueryString["notupd"] != null)
        {
            SmartHr.Common.Alert("Not Updated ");
        }
       
    }

    private void bindtrainingschedule()
    {
        //        string sqlstr = @"select Convert(varchar(10),ts.fromdate,101) as FromDate,ts.id,ts.training_code,ts.bachcode,ts.training_shortname,
        //ts.training_name,ts.dept_name,dep.department_name,ts.module_name,case when tee.status='1' then count(tee.status) end Need_participent,
        //case when tee.status='2' then count(tee.status) end Add_participent from tbl_training_elegible_emp tee
        //inner join tbl_training_schedul ts on tee.trining_id=ts.id 
        //inner join tbl_internate_departmentdetails dep on dep.departmentid=ts.dept_name
        //where tee.status in(1,2) group by tee.trining_id,ts.fromdate,ts.training_code,ts.training_name,dep.department_name,
        //ts.module_name,ts.id,ts.bachcode,ts.training_shortname,tee.status,ts.dept_name";      

        string sqlstr = @"select distinct ts.training_code as trainingcode,ts.training_name,ts.branch,ts.dept_type,ts.dept_name as dept_id,dept.department_name,
ts.module_name as modulename,ts.descriptions,ts.month,CONVERT(varchar(40), ts.fromdate, 106) as FromDate,
CONVERT(varchar(40), ts.todate, 106) as ToDate,ts.bachcode,ts.training_type,ts.training_shortname,ts.year,
ts.todate,ts.trainer,ts.faculty,ts.noofhours,ts.source_internal,ts.source_external,ts.effectiveness_to_be_cond,
ts.feedback_to_be_cond,ts.action_plan_to_be_cond,ts.program,ts.faculty_description,ts.any_other,ts.createdby,
ts.createddate,ts.status,ts.approverstatus,ts.tds
from tbl_training_schedul ts
left join tbl_internate_departmentdetails dept on dept.departmentid=ts.dept_name where ts.createdby='" + _userCode + "'";
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count < 0)
        {
            return;
        }
        trigrid.DataSource = ds;
        trigrid.DataBind();
    }

    protected void trigrid_PreRender(object sender, EventArgs e)
    {
       
        if (trigrid.Rows.Count > 0)
        {
            trigrid.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (trigrid.Rows.Count > 0)
        {
            // Hides the first column in the grid (zero-based index)
            trigrid.HeaderRow.Cells[7].Visible = false;
            trigrid.HeaderRow.Cells[8].Visible = false;
            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < trigrid.Rows.Count; i++)
            {
                GridViewRow row = trigrid.Rows[i];
                row.Cells[7].Visible = false;
                row.Cells[8].Visible = false;
                trigrid.Columns[7].Visible = false;
                trigrid.Columns[8].Visible = false;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "TrainingScheduleReport" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < trigrid.Rows.Count; i++)
            {

                trigrid.Rows[i].Style.Add("width", "150px");
                trigrid.Rows[i].Style.Add("height", "20px");
            }

            trigrid.GridLines = GridLines.Both;
            trigrid.HeaderStyle.Font.Bold = true;
            trigrid.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }
}