using Common.Console;
using Common.Data;
using Smart.HR.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class training_markattendance : System.Web.UI.Page
{
    string sqlstr, _userCode;
    int flag;
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    DateTime newdate;
    string Usercode, fromdate, todate, Faculty, modulename, modulenamess, training_name;
    int tid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null)
        {
            _userCode = Session["empcode"].ToString();
            tid = Convert.ToInt16(Request.QueryString["id"]);

            fromdate = Request.QueryString["FromDate"].ToString();
            todate = Request.QueryString["ToDate"].ToString();
            Faculty = Request.QueryString["Faculty"].ToString();
            modulename = Request.QueryString["module_name"].ToString();
            //string empcode = Request.QueryString["empcode"].ToString();
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
            Common.Console.Output.Show("Submitted Successfully");
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

            int deptid = Convert.ToInt16(Request.QueryString["dept_name"].ToString());
            connection = activity.OpenConnection();

            string strng = @"select module_name ,training_name from tbl_training_schedul where id='" + tid + "'";
            DataSet dsInsertedEmps = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, strng);
            if (dsInsertedEmps.Tables[0].Rows.Count < 1)
            {
                return;
            }
            else
            {
                modulenamess = dsInsertedEmps.Tables[0].Rows[0]["module_name"].ToString();
                training_name = dsInsertedEmps.Tables[0].Rows[0]["training_name"].ToString();
            }
//            sqlstr = @"select distinct emp.id ,emp.empcode,emp.emp_fname,emp.designationname,emp.department_name,emp.training_name,
//emp.training_code,emp.branch_name,convert(varchar(20),emp.fromdate,103)as fromdate,
//convert(varchar(20),emp.todate,103) as todate,
//CASE
//         WHEN sch.faculty LIKE '% %' THEN LEFT(sch.faculty, Charindex(' ', sch.faculty) - 1)
//         ELSE sch.faculty
//       END as Faculty,
//      emp.modulename,
//case when emp.status='1' then 'From User' else 'From LM' end as status
//from tbl_training_elegible_emp  emp
//inner join tbl_training_schedul sch on emp.training_code=sch.training_code
//where  emp.id not in (select eligid from tbl_training_mark_attendance where eligid is not null)
//and LEFT(sch.faculty, Charindex(' ', sch.faculty) - 1)='" + _userCode + "'"; 


            sqlstr = @"select distinct emp.id ,emp.empcode,emp.emp_fname,emp.designationname,emp.department_name,emp.training_name,
emp.training_code,emp.branch_name,convert(varchar(20),emp.fromdate,103)as fromdate,
convert(varchar(20),emp.todate,103) as todate,
--CASE
--         WHEN sch.faculty LIKE '% %' THEN LEFT(sch.faculty, Charindex(' ', sch.faculty) - 1)
--         ELSE sch.faculty
--       END as Faculty,
     emp.Faculty,
      emp.modulename

from tbl_training_elegible_emp  emp
inner join tbl_training_schedul sch on emp.training_code=sch.training_code 
where  emp.id not in (select eligid from tbl_training_mark_attendance where eligid is not null) 
and emp.Faculty='" + _userCode + "'and emp.training_name='"+training_name+"' and modulename='" + modulenamess + "'  and  emp.fromdate='" + fromdate + "' and emp.todate='" + todate + "' "; 

            DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds1.Tables[0].Rows.Count < 1)
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

    //protected void chkHeader_CheckedChanged(object sender, EventArgs e)
    //{
    //    CheckBox chkHeader = (CheckBox)Grid_Markattendance.HeaderRow.FindControl("chkHeader");
    //    if (chkHeader.Checked)
    //    {
    //        foreach (GridViewRow gvrow in Grid_Markattendance.Rows)
    //        {
    //            CheckBox chkAttendence = (CheckBox)gvrow.FindControl("chkAttendence");
    //            chkAttendence.Checked = true;
    //        }
    //    }
    //    else
    //    {
    //        foreach (GridViewRow gvrow in Grid_Markattendance.Rows)
    //        {
    //            CheckBox chkAttendence = (CheckBox)gvrow.FindControl("chkAttendence");
    //            chkAttendence.Checked = false;
    //        }
    //    }
    //}
    //protected void chkRow_CheckedChanged(object sender, EventArgs e)
    //{
    //    int count = 0;
    //    int totalRowCountGrid = Grid_Markattendance.Rows.Count;

    //    CheckBox chkHeader = (CheckBox)Grid_Markattendance.HeaderRow.FindControl("chkHeader");

    //    foreach (GridViewRow gvrow in Grid_Markattendance.Rows)
    //    {
    //        CheckBox chkAttendence = (CheckBox)gvrow.FindControl("chkAttendence");
    //        if (chkAttendence.Checked)
    //        {
    //            count++;
    //        }
    //    }

    //    if (count == totalRowCountGrid)
    //    {
    //        chkHeader.Checked = true;
    //    }
    //    else
    //    {
    //        chkHeader.Checked = false;
    //    }
    //}

    protected void btmDisplay_Click(object sender, EventArgs e)
    {
        if (gridmark.Rows.Count > 0)
        {
            SqlConnection Connection = null;
            SqlTransaction Transaction = null;
            Common.Data.DataActivity Activity = new Common.Data.DataActivity();
            string Query = "";

            Connection = Activity.OpenConnection();
            Transaction = Connection.BeginTransaction();

            try
            {
                foreach (GridViewRow row in gridmark.Rows)
                {
                    CheckBox chk = (CheckBox)row.FindControl("chkSelect");
                    if (chk.Checked)
                    {

                        string attendenceStatus = chk.Checked ? "Present" : "Absent";
                        Label emp = (Label)row.FindControl("l0");
                        Label id = (Label)row.FindControl("lid");
                        Label training_code = (Label)row.FindControl("l1");
                        Label training_name = (Label)row.FindControl("l2");
                        Label emp_fname = (Label)row.FindControl("l3");
                        //Label designationname = (Label)row.FindControl("l4");
                        Label department_name = (Label)row.FindControl("l5");
                        Label branch_name = (Label)row.FindControl("l6");
                        Label trining_id = (Label)row.FindControl("l7");
                        Label fromdate = (Label)row.FindControl("lblfromdate");
                        Label todate = (Label)row.FindControl("lbltodate");
                        Label faculty = (Label)row.FindControl("lfac");
                        Label modulename = (Label)row.FindControl("lmod");
                        if (txtdatepicker.Text != "")
                        {
                            newdate = Convert.ToDateTime(txtdatepicker.Text);
                        }
                        //newdate = Convert.ToDateTime(txtdatepicker.Text);
                        //string empcode = row.Cells[1].Text.Trim();
                        //string training_code = row.Cells[2].Text.Trim();
                        //string training_name = row.Cells[3].Text.Trim();
                        //string emp_fname = row.Cells[4].Text.Trim();
                        //string desidepartment_namegnationname = row.Cells[5].Text.Trim();
                        //string  = row.Cells[6].Text.Trim();
                        //string branch_name = row.Cells[7].Text.Trim();
                        //DateTime date= Convert.ToDateTime(System.DateTime.Now);
                      string date =todate.Text;
                        //string x = DateTime.ParseExact(date, "dd'.'MM'.'yyyy", CultureInfo.InvariantCulture).ToString("MM'/'dd'/'yyyy");
                            //Convert.ToDateTime(date.ToString()).ToString("MM/dd/yyyy");
                        string x = Convert.ToString(DateTime.Now.ToString("dd/MM/yyyy"));
                        DateTime dt1 = DateTime.ParseExact(todate.Text, "dd/MM/yyyy", null);
                        DateTime dt2 = DateTime.ParseExact(x, "dd/MM/yyyy", null);
                       
                        if (dt1<=dt2)
                         {

                        string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                        using (SqlConnection con = new SqlConnection(constring))
                        {
                            string query = @"INSERT INTO tbl_training_mark_attendance(empcode,training_code,training_name,emp_fname,department_name,attendenceStatus,branch_name,trainerempname,eligid,Newdatepresent,fromdate,todate)
VALUES('" + emp.Text + "','" + training_code.Text + "','" + training_name.Text + "','" + emp_fname.Text + "','" + department_name.Text + "','" + attendenceStatus + "','" + branch_name.Text + "','" + faculty.Text + "'," + id.Text + ",'" + newdate + "','" + fromdate.Text + "','" + todate.Text + "')";

                            SqlCommand cmd = new SqlCommand(query, con);
                          
                            con.Open();
                         flag  = cmd.ExecuteNonQuery();
                        //string str = "<script> alert('Mark Attendance is update successfully.')</script>";
                            con.Close();
                        }
                        }

                    }
                }
                Transaction.Commit();
                // Clear();
               
            } 
                catch
                {
                    Transaction.Rollback();

                }
            if (flag > 0)
            {

                Response.Redirect("ViewTrainingsectionMarkattdncescheduled.aspx?updated=true");
            }

        }

    }

    protected void gridmark_PreRender(object sender, EventArgs e)
    {
        if (gridmark.Rows.Count > 0)
        {
            gridmark.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    protected void gridmarkatt_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gridmark.HeaderRow.FindControl("gridmarkatt");
        if (chk.Checked == true)
        {
            foreach (GridViewRow row in gridmark.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = true;
            }
        }
        else
        {
            foreach (GridViewRow row in gridmark.Rows)
            {
                CheckBox chkselect = (CheckBox)row.FindControl("chkSelect");
                chkselect.Checked = false;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        fetchleavedetail();

    }
    protected void fetchleavedetail()
    {
        try
        {
            connection = activity.OpenConnection();
            

            sqlstr = @"select distinct emp.id ,emp.empcode,emp.emp_fname,emp.designationname,emp.department_name,emp.training_name,
emp.training_code,emp.branch_name,convert(varchar(20),emp.fromdate,103)as fromdate,
convert(varchar(20),emp.todate,103) as todate,
--CASE
--         WHEN sch.faculty LIKE '% %' THEN LEFT(sch.faculty, Charindex(' ', sch.faculty) - 1)
--         ELSE sch.faculty
--       END as Faculty,
     emp.Faculty,
      emp.modulename

from tbl_training_elegible_emp  emp
inner join tbl_training_schedul sch on emp.training_code=sch.training_code 
where  emp.id not in (select eligid from tbl_training_mark_attendance where eligid is not null) and emp.Faculty='" + _userCode + "'  and emp.fromdate='" + Convert.ToDateTime(txt_sdate.Text) + "' and emp.todate='" + Convert.ToDateTime(txt_edate.Text) + "'";

            DataSet ds1 = Common.Data.SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);

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

}


//#for mark attendence
 //foreach (GridViewRow row in Grid_Markattendance.Rows)
 //        {
 //            if (row.RowType == DataControlRowType.DataRow)
 //            {        
            
 //               CheckBox chkAttendance = row.FindControl("chkAttendence") as CheckBox;
                

 //               foreach (GridViewRow gvr in Grid_Markattendance.Rows)
 //               {
                
 //                   string attendenceStatus = chkAttendance.Checked ? "Present" : "Absent";                  
 //                   string empcode = row.Cells[1].Text.Trim();
 //                   string name = row.Cells[2].Text.Trim();
 //                   string department_name = row.Cells[3].Text.Trim();
 //                   string designationname = row.Cells[4].Text.Trim();
 //                   string location = row.Cells[5].Text.Trim();                 

 //                   string constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
 //                   using (SqlConnection con = new SqlConnection(constring))
 //                   {
 //                       string query = "INSERT INTO tbl_training_mark_attendance(empcode,name,department_name,designationname,attendenceStatus,location) VALUES('" + empcode + "','" + name + "','" + department_name + "','" + designationname + "','" + attendenceStatus + "','" + location + "')";

 //                       SqlCommand cmd = new SqlCommand(query, con);
                        
 //                          con.Open();                     
 //                           cmd.ExecuteNonQuery();
 //                           string str = "<script> alert('Mark Attendance is update successfully.')</script>";
 //                          con.Close();
                        
 //                   }
 //               }
 //           }