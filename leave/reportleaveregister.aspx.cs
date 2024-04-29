using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Common.Data;
using Common.Console;
using System.Web;
using System.IO;
using System.Web.UI;

public partial class leave_reportleaveregister : System.Web.UI.Page
{
    string strsql;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        // p3.Visible = false;
        if (!IsPostBack)
        {
            if (Session["role"] == null)
                Response.Redirect("~/notlogged.aspx");
            drpdepartment.Items.Insert(0, new ListItem("All", "0"));

        }
    }

    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_departmnt(Convert.ToInt16(drpbranch.SelectedValue));
    }

    protected void bind_departmnt(int branchid)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = "SELECT departmentid,department_name FROM tbl_internate_departmentdetails WHERE branchid='" + branchid + "' ";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

            drpdepartment.DataTextField = "department_name";
            drpdepartment.DataValueField = "departmentid";
            drpdepartment.DataSource = ds1;
            drpdepartment.DataBind();
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

    protected void drpdepartment_DataBound(object sender, EventArgs e)
    {
        drpdepartment.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void drpbranch_DataBound(object sender, EventArgs e)
    {
        drpbranch.Items.Insert(0, new ListItem("All", "0"));
    }

    protected void btn_reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void btn_search_Click(object sender, EventArgs e)
    {
        bindempleave();
    }

    DataSet GetLeave()
    {
        try
        {
            connection = activity.OpenConnection();
            DateTime dt = DateTime.Now;
            DateTime sdate = new DateTime();
            DateTime edate = new DateTime();

            sdate = Common.Date.Utility.DateFormat(txt_sdate.Text.ToString());
            edate = Common.Date.Utility.DateFormat(txt_edate.Text.ToString());
            strsql = @"select T2.empcode,T2.ename,T2.designation,T2.department,T2.branch_name,T2.nod,T2.leaveid ,
  case when T1.fromdate is null  then  convert(varchar(20),T1.hdate,106) else convert(varchar(20),T1.fromdate,106) end  + ' to ' +
 case when T1.todate is null  then convert(varchar(20),T1.hdate,106) else convert(varchar(20),T1.todate,106) end date,typ.leavetype   
   from tbl_leave_apply_leave T1 inner join (select emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'') as ename,
        deg.designationname designation,dep.department_name department,branch.branch_name,
        leave.no_of_days nod,leave.leaveid,leave.Applied_leave
        from 
        tbl_intranet_employee_jobDetails emp  
        inner join 
        tbl_leave_apply_leave_datewise leave on emp.empcode=leave.empcode
        --inner join 
       -- tbl_leave_adjustment_apply aleave on leave.id=aleave.apply_leave_id and aleave.leaveid!=0
        left outer join 
        tbl_intranet_branch_detail branch on emp.branch_id=branch.branch_id
        left outer join
        tbl_intranet_designation deg on emp.degination_id=deg.id 
        left outer join 
        tbl_internate_departmentdetails dep on emp.dept_id=dep.departmentid
        where ((leave.date between '" + sdate + "' and '" + edate + "') ) and leave.leave_status=" + drp_leavestatus.SelectedValue;

            if (drpbranch.SelectedValue != "0")
                strsql = strsql + "and branch.branch_id=" + drpbranch.SelectedValue;
            if (drpdepartment.SelectedValue != "0")
                strsql = strsql + "and dep.departmentid=" + drpdepartment.SelectedValue;
            if (txt_empcode.Text != "")
                strsql = strsql + " and leave.empcode in ('" + txt_empcode.Text.Trim() + "')";

            strsql = strsql + @" group by emp.empcode,emp.empcode,coalesce(emp.emp_fname,'') + ' ' + coalesce(emp.emp_m_name,'') + ' ' + coalesce(emp.emp_l_name,'')
        ,deg.designationname,dep.department_name,branch.branch_name,no_of_days,leaveid,Applied_leave)T2 on T1.id= T2.leaveid inner join tbl_leave_createleave typ on T2.Applied_leave=typ.leaveid";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, strsql);
           
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

        return ds;
    }


    protected void bindempleave()
    {
        empleavegrid.DataSource = GetLeave();
        empleavegrid.DataBind();
    }

    protected void reset()
    {
        txt_edate.Text = "";
        txt_sdate.Text = "";
        drp_leavestatus.SelectedIndex = -1;
        drpbranch.SelectedIndex = -1;
        drpdepartment.SelectedIndex = -1;
        txt_empcode.Text = "";
    }

    protected void empleavegrid_PreRender(object sender, EventArgs e)
    {
        if (empleavegrid.Rows.Count > 0)
            empleavegrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //required to avoid the run time error "  
        //Control 'GridView1' of type 'Grid View' must be placed inside a form tag with runat=server."  
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        if (empleavegrid.Rows.Count > 0)
        {
            // Hides the first column in the grid (zero-based index)
          //  empleavegrid.HeaderRow.Cells[6].Visible = false;

            // Loop through the rows and hide the cell in the first column
            for (int i = 0; i < empleavegrid.Rows.Count; i++)
            {
                GridViewRow row = empleavegrid.Rows[i];
             //   row.Cells[6].Visible = false;
            }

            Response.Clear();
            Response.Buffer = true;
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Charset = "";
            string FileName = "LeaveReport" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            for (int i = 0; i < empleavegrid.Rows.Count; i++)
            {

                empleavegrid.Rows[i].Style.Add("width", "150px");
                empleavegrid.Rows[i].Style.Add("height", "20px");
            }
          
            empleavegrid.GridLines = GridLines.Both;
            empleavegrid.HeaderStyle.Font.Bold = true;
            empleavegrid.RenderControl(htmltextwrtter);
            Response.Write(strwritter.ToString());
            Response.End();
        }
    }
}
