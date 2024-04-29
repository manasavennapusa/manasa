using Common.Console;
using Common.Data;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

public partial class DashBoard : System.Web.UI.Page
{
    string sqlstr;
    DataActivity activity = new DataActivity();
    SqlConnection _Connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
            Response.Redirect("~/notlogged.aspx");
        if (!IsPostBack)
        {
            BindBranch();
            BindTable(drpbranch.SelectedItem.Value);
            GetBirthdayAnniversaries();
        }
    }
    private void GetBirthdayAnniversaries()
    {
        try
        {
            _Connection = activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.StoredProcedure, "demogetbirthdayanniversary");
            System.Text.StringBuilder str = new System.Text.StringBuilder();
            str.Append("<ul class='chats'>");

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                str.Append("<li>");
                str.Append("<div class='user pull-left'>");
                if (row["photo"].ToString() != "")
                    str.Append("<img src='Upload/photo/" + row["photo"].ToString() + "' alt='user'>");
                else
                    str.Append("<img src='upload/photo/image.png' alt='user'>");
                str.Append("</div>");
                str.Append("<div class='info'>");
                str.Append("<h6>");
                str.Append(row["fname"].ToString() + " " + row["lname"].ToString());
                str.Append("</h6>");
                str.Append("<p>");
                str.Append(row["Occasion"].ToString());
                str.Append("</p>");
                str.Append("<small>");
                str.Append(row["dob"].ToString());
                str.Append("</small>");
                str.Append("</div>");
                str.Append("</li>");

            }
            str.Append("</ul>");
            Session["Birthday"] = str.ToString();
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
    protected void BindBranch()
    {
        try
        {
            _Connection = activity.OpenConnection();
            sqlstr = "SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]";
            DataSet ds = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;
            drpbranch.DataSource = ds;
            drpbranch.DataTextField = "branch_name";
            drpbranch.DataValueField = "Branch_Id";
            drpbranch.DataBind();
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

    #region Leave Report
    [WebMethod]
    public static LeaveBalance[] GetLeaveBalance(string empcode, string gender)
    {
        List<LeaveBalance> details = new List<LeaveBalance>();
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select tbl_leave_employee_leave_master.leaveid,displayleave as leavetype,isnull(tbl_leave_employee_leave_master.Entitled_days,0.0) Entitled,isnull(Used_days,0.0) UsedDays,(isnull(tbl_leave_employee_leave_master.Entitled_days,0.0)-isnull(Used_days,0.0)) as CurBalance from tbl_leave_employee_leave_master 
                        inner join tbl_leave_createleave on tbl_leave_createleave.leaveid=tbl_leave_employee_leave_master.leaveid
                        inner join tbl_leave_createleavepolicy on tbl_leave_createleavepolicy.policyid=tbl_leave_employee_leave_master.policyid
                        INNER JOIN tbl_leave_createdefaultrule r ON r.leaveid = tbl_leave_employee_leave_master.leaveid  
                            where empcode='" + empcode.ToString() + "' and tbl_leave_employee_leave_master.leaveid!=0 and ( applicable_to = 'A' or applicable_to = '" + gender.ToString() + "' ) order by tbl_leave_createleave.leavetype";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                LeaveBalance leavebalance = new LeaveBalance();
                leavebalance.leaveid = Convert.ToInt32(dtrow["leaveid"].ToString());
                leavebalance.leavename = dtrow["leavetype"].ToString();
                leavebalance.entitleddays = Convert.ToDecimal(dtrow["Entitled"].ToString());
                leavebalance.useddays = Convert.ToDecimal(dtrow["UsedDays"].ToString());
                leavebalance.balance = Convert.ToDecimal(dtrow["CurBalance"].ToString());
                details.Add(leavebalance);
            }
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
        return details.ToArray();
    }
    public class LeaveBalance
    {
        public int leaveid { get; set; }
        public string leavename { get; set; }
        public decimal entitleddays { get; set; }
        public decimal useddays { get; set; }
        public decimal balance { get; set; }
    }
    #endregion
    #region Attendance Report
    [WebMethod]
    public static Attendance[] GetDepartmentwiseAttendance(string empcode)
    {
        List<Attendance> details = new List<Attendance>();
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @"select isnull(Noofdays,0.0) Noofdays,monthname,isnull(TotalPresent,0.0) TotalPresent,case when (DATEPART(mm,CAST(monthname+ ' 1900' AS DATETIME))=month(getdate())) then  (convert(varchar(3),DATEPART(dd,getdate()))-isnull(TotalPresent,0.0)) else  (isnull(Noofdays,0.0)-isnull(TotalPresent,0.0)) end as Absent from (
                                    select dbo.udf_GetNumDaysInMonth(CONVERT(varchar(12),('01'+'-'+MONTH+'-'+cast(YEAR(GETDATE()) as varchar(10))),101)) as Noofdays, MONTH as monthname,COUNT(MODE)  as TotalPresent 
                                    from tbl_payroll_employee_attendence_detail
                                    where EMPCODE ='" + empcode.ToString() + "' and MODE not in ('A') and YEAR(DATE) = YEAR(GETDATE()) group by MONTH)A order by DATEPART(mm,CAST(monthname+ ' 1900' AS DATETIME)) asc";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                Attendance att = new Attendance();
                att.noofdays = Convert.ToInt32(dtrow["Noofdays"].ToString());
                att.monthname = dtrow["monthname"].ToString();
                att.present = Convert.ToDecimal(dtrow["TotalPresent"].ToString());
                att.absent = Convert.ToDecimal(dtrow["Absent"].ToString());
                details.Add(att);
            }
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
        return details.ToArray();
    }
    public class Attendance
    {
        public decimal noofdays { get; set; }
        public string monthname { get; set; }
        public decimal present { get; set; }
        public decimal absent { get; set; }
    }
    #endregion
    #region HeadCount Report
    protected void BindTable(string branchid)
    {
        try
        {
            _Connection = activity.OpenConnection();
            sqlstr = @"select departmentid,department_name from tbl_internate_departmentdetails where branchid=" + branchid;
            DataSet dsdept = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            string table = "";
            table += @"<table class='table table-condensed table-bordered no-margin'><thead>";
            table += "<tr class='hidden-phone'><td>Your ORG.</td>";
            foreach (DataRow row in dsdept.Tables[0].Rows)
            {
                table += "<td class='hidden-phone'>" + row["department_name"].ToString() + "</td>";
            }
            table += "<td>Total</td></tr></thead><tbody>";
            //business unit
            sqlstr = "select distinct broadgroup_name from tbl_intranet_broadgroup ";
            DataSet dsbus = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

            //employee count
            sqlstr = "select COUNT(*),dept_id,broadgroupid from tbl_intranet_employee_jobDetails group by dept_id,broadgroupid";
            DataSet dsemp = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);
            int busid = 0, noofemp = 0, totalemp = 0;
            int count = 0;
            foreach (DataRow row in dsbus.Tables[0].Rows)
            {
                totalemp = 0;
                if (count == 0)
                    table += "<tr class='success'>";
                table += "<td  class='hidden-phone'>" + row["broadgroup_name"].ToString() + "</td>";
                foreach (DataRow deptrow in dsdept.Tables[0].Rows)
                {
                    //busid
                    sqlstr = "select * from tbl_intranet_broadgroup where departmentid=" + deptrow["departmentid"].ToString();
                    DataSet dsbroad = SQLServer.ExecuteDataset(_Connection, CommandType.Text, sqlstr);

                    if (row["broadgroup_name"].ToString() == dsbroad.Tables[0].Rows[0]["broadgroup_name"].ToString())
                    {
                        if (dsbroad.Tables[0].Rows.Count > 0)
                        {
                            busid = Convert.ToInt32(dsbroad.Tables[0].Rows[0]["id"].ToString());
                        }
                        string countofemp = "dept_id='" + deptrow["departmentid"].ToString() + "' and broadgroupid='" + busid + "'";
                        DataRow[] emprow = dsemp.Tables[0].Select(countofemp);
                        noofemp = emprow.Length;
                        totalemp += noofemp;

                        table += "<td  class='hidden-phone'>" + noofemp + "</td>";
                    }
                    else
                        table += "<td  class='hidden-phone'>0</td>";

                }
                table += "<td  class='hidden-phone'>" + totalemp + "</td>";
                table += "</tr>";
            }

            table += " </tbody></table>";
            divheadcount.InnerHtml = table.ToString();
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
    protected void drpbranch_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTable(drpbranch.SelectedValue);
    }
    #endregion
    #region Event Calender
    [WebMethod]
    public static EventCalender[] BindEventCalender(string empcode)
    {
        List<EventCalender> details = new List<EventCalender>();
        var activity = new DataActivity();
        DataSet ds = new DataSet();
        try
        {
            SqlConnection connection = activity.OpenConnection();
            string sqlstr = @" select heading,eventdate,DATEPART(DD,eventdate) date,DATEPART(MM,eventdate) month,DATEPART(YY,eventdate) year from COMPANY_EVENTS
                                    union select MODE as heading,DATE as eventdate,DATEPART(DD,DATE),DATEPART(MM,DATE) month,DATEPART(YY,DATE) year from tbl_payroll_employee_attendence_detail
                                              where EMPCODE ='" + empcode.ToString() + "' ";

            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            foreach (DataRow dtrow in ds.Tables[0].Rows)
            {
                EventCalender evtcal = new EventCalender();
                evtcal.heading = dtrow["heading"].ToString();
                evtcal.eventdate = Convert.ToDateTime(dtrow["eventdate"].ToString());
                evtcal.date = Convert.ToInt32(dtrow["date"].ToString());
                evtcal.month = Convert.ToInt32(dtrow["month"].ToString());
                evtcal.year = Convert.ToInt32(dtrow["year"].ToString());
                details.Add(evtcal);
            }
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
        return details.ToArray();
    }
    public class EventCalender
    {
        public string heading { get; set; }
        public DateTime eventdate { get; set; }
        public int date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
    #endregion
}