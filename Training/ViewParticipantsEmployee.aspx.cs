using Common.Console;
using Common.Data;
using Smart.HR.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Training_ViewParticipantsEmployee : System.Web.UI.Page
{
    string sqlstr, _userCode, _companyId, RoleId, trainingcode, fromdate, todate, modulename, departmentid, modulenamess;
    int flag;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    int tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            tid = Convert.ToInt32(Request.QueryString["id"]);
          //  message.InnerHtml = "";

            if (Request.QueryString["trainingcode"].ToString() != null)
            {
                trainingcode = Request.QueryString["trainingcode"].ToString();
                fromdate = Request.QueryString["FromDate"].ToString();
                todate = Request.QueryString["ToDate"].ToString();
                modulename = Request.QueryString["modulename"].ToString();
                departmentid = Request.QueryString["dept_id"].ToString();
            }
            if (!IsPostBack)
            {
                bind_markattendance();

            }
        }
        else
        {
            Response.Redirect("~/notlogged.aspx");
        }
        if (Request.QueryString["updated"] == "true")
        {
            Common.Console.Output.Show("Transaction completed Successfully");
        }

    }

    protected void Grid_Markattendance_PreRender(object sender, EventArgs e)
    {

    }

    protected void btn_select_Click(object sender, EventArgs e)
    {

        if (gridmark.Rows.Count > 0)
        {
            foreach (GridViewRow row in gridmark.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                chk.Checked = true;
            }
        }

    }

    protected void btn_deselect_Click(object sender, EventArgs e)
    {
        if (gridmark.Rows.Count > 0)
        {
            foreach (GridViewRow row in gridmark.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chk");
                chk.Checked = false;
            }
        }
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {

    }

    protected void bind_markattendance()
    {
        try
        {
            connection = activity.OpenConnection();
            string strng = @"select module_name from tbl_training_schedul where id='" + tid + "'";
            DataSet dsInsertedEmps = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, strng);
            if (dsInsertedEmps.Tables[0].Rows.Count < 0)
            {
                return;
            }
            else
            {
                modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();
            }


//        sqlstr = @"select distinct emp.empcode,emp.emp_fname,emp.designationname,emp.department_name,emp.training_name,
//emp.training_code,emp.branch_name,convert(varchar(20),emp.fromdate,103)as fromdate,
//convert(varchar(20),emp.todate,103) as todate,
//CASE
//         WHEN sch.faculty LIKE '% %' THEN LEFT(sch.faculty, Charindex(' ', sch.faculty) - 1)
//         ELSE sch.faculty
//       END as Faculty,
//      emp.modulename,
//case when emp.status='1' then 'From User' else 'From LM' end as status,
// case when mark.attendenceStatus='Present' then 'Present' else 'Absent' end as attendenceStatus
//from tbl_training_elegible_emp  emp
//inner join tbl_training_schedul sch on emp.training_code=sch.training_code
//left join tbl_training_mark_attendance mark on mark.empcode=emp.empcode
// WHERE emp.fromdate='" + fromdate + "' AND emp.todate='" + todate + "'";\

            sqlstr = @"select distinct emp.empcode,emp.emp_fname,emp.designationname,emp.department_name,emp.training_name,
emp.training_code,emp.branch_name,convert(varchar(20),emp.fromdate,103)as fromdate,
convert(varchar(20),emp.todate,103) as todate,convert(varchar(20),mark.Newdatepresent,103)as Newdatepresent,

 emp.Faculty,
      emp.modulename,
case when emp.status='1' then 'From User' else 'From LM' end as status,
 case when mark.attendenceStatus='Present' then 'Present' else 'Absent' end as attendenceStatus
from tbl_training_elegible_emp  emp
inner join tbl_training_schedul sch on emp.training_code=sch.training_code 
inner join tbl_internate_departmentdetails deb on deb.departmentid=sch.dept_name 
left join tbl_training_mark_attendance mark on mark.empcode=emp.empcode and emp.department_name=mark.department_name and emp.id= mark.eligid
where emp.fromdate='" + fromdate + "' AND emp.todate='" + todate + "' and emp.training_code=" + trainingcode + "  and emp.modulename='" + modulenamess + "' and deb.departmentid='" + departmentid + "'";

            DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 0)
            {
                return;
            }
            gridmark.DataSource = ds1;
            gridmark.DataBind();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
    }

   
    protected void gridmark_PreRender(object sender, EventArgs e)
    {
        if (gridmark.Rows.Count > 0)
        {
            gridmark.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (gridmark.Rows.Count > 0)
        {
            //gridmark.HeaderRow.Cells[8].Visible = false;
            //gridmark.HeaderRow.Cells[9].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < gridmark.Rows.Count; i++)
            {
                GridViewRow row = gridmark.Rows[i];
                //row.Cells[8].Visible = false;
                //row.Cells[9].Visible = false;
                //gridmark.Columns[8].Visible = false;
                //gridmark.Columns[9].Visible = false;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "ViewALLEmployeeReport" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < gridmark.Rows.Count; i++)
            {

                gridmark.Rows[i].Style.Add("width", "150px");
                gridmark.Rows[i].Style.Add("height", "20px");
            }

            gridmark.GridLines = GridLines.Both;
            gridmark.HeaderStyle.Font.Bold = true;
            gridmark.RenderControl(htmltextwrtter);
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


