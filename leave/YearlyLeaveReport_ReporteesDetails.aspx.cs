using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Leave_YearlyLeaveReport_ReporteesDetails : System.Web.UI.Page
{
    public string CalanderName;
    public string LeaveName ;

    protected void Page_Load(object sender, EventArgs e)
    {


        string employee = Session["empcode"].ToString();
       // string empcode = Request.QueryString["empcode"];
        string Calander = Request.QueryString["Calander"];
        CalanderName = Request.QueryString["CalanderName"];
        string Policy = Request.QueryString["PolicyId"];
        string Leave = Request.QueryString["Leave"];
        LeaveName = Request.QueryString["LeaveName"];

        if (Leave == "10")
        {
            GenerateLeaveReport1(Calander, Policy, Leave);
        }
        else
        {
            GenerateLeaveReport(Calander, Policy, Leave);
        }
    }

    void GenerateLeaveReport(string calanderId, string policyId, string leaveId)
    {
        //DataSet dsReportees = (DataSet)empcode;
        //if (dsReportees.Tables[0].Rows.Count < 1)
        //    return;
        string sql =
@"select 
L.empcode EmpCode,
J.emp_fname Name,
D.department_name DepartentName,
convert(varchar(10),J.emp_doj,101) DOJ,
L.Entitled_days - ( isnull(A.Jan,0) + isnull(A.Feb,0) + isnull(A.Mar,0) + isnull(A.Apr,0) + isnull(A.May,0) + isnull(A.Jun,0) + isnull(A.Jul,0) + isnull(A.Aug,0) + isnull(A.Sep,0) + isnull(A.Oct,0) + isnull(A.Nov,0) + isnull(A.Dec,0)) OpeningBalance,
R.entitled_days Eligibility,
A.Jan,
A.Feb,
A.Mar,
A.Apr,
A.May,
A.Jun,
A.Jul,
A.Aug,
A.Sep,
A.Oct,
A.Nov,
A.Dec,
( isnull(A.Jan,0) + isnull(A.Feb,0) + isnull(A.Mar,0) + isnull(A.Apr,0) + isnull(A.May,0) + isnull(A.Jun,0) + isnull(A.Jul,0) + isnull(A.Aug,0) + isnull(A.Sep,0) + isnull(A.Oct,0) + isnull(A.Nov,0) + isnull(A.Dec,0)) TotalEligibleLeave,
B.Jan,
B.Feb,
B.Mar,
B.Apr,
B.May,
B.Jun,
B.Jul,
B.Aug,
B.Sep,
B.Oct,
B.Nov,
B.Dec,
( isnull(B.Jan,0) + isnull(B.Feb,0) + isnull(B.Mar,0) + isnull(B.Apr,0) + isnull(B.May,0) + isnull(B.Jun,0) + isnull(B.Jul,0) + isnull(B.Aug,0) + isnull(B.Sep,0) + isnull(B.Oct,0) + isnull(B.Nov,0) + isnull(B.Dec,0)) TotalAvailedLeave,
L.Entitled_days - Used_days Balance

 from tbl_leave_employee_leave_master as L

left join

(
 
select *
from
(
select calanderid, policyid, leaveid, leavemonth, empcode, curmonthentitle
 from tbl_leave_processleavemonthly p
 inner join tbl_leave_processleavemonthlydetails pd on p.id = pd.processid
  group by calanderid, policyid, leaveid, leavemonth, empcode, curmonthentitle, premonthentitle
) src
pivot
(
    max(curmonthentitle)
    for leavemonth in (Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec )
) piv

) as A on A.calanderid = L.calenderid and A.leaveid = L.leaveid and A.policyid = L.PolicyId and A.empcode = L.empcode

left join

(

select *
from
(
select l.calenderid, l.policyid, l.leaveid, l.empcode , CAST(DATENAME(MONTH, fromdate) as VARCHAR(3)) month ,l.no_of_days
 from tbl_leave_apply_leave l
 where  l.leave_status in (6) and l.status in (1)
) src
pivot
(
   sum(no_of_days)
   for month in (Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec )
) pvt
 
) B on L.calenderid = B.calenderid and L.leaveid = B.leaveid and L.PolicyId = B.policyid and L.empcode = B.empcode

left join tbl_intranet_employee_jobDetails J on l.empcode = J.empcode
left join tbl_internate_departmentdetails D on J.dept_id = D.departmentid
left join tbl_leave_employee_hierarchy app on app.employeecode = J.empcode
left join tbl_leave_createdefaultrule R on R.leaveid = @leaveid and R.policyid = @PolicyId

where L.calenderid = @CalenderId and L.leaveid = @leaveid and L.PolicyId = @PolicyId  and app.approverid='" + Session["empcode"].ToString() + "'";
 
//and J.empcode in ('";

//        foreach (DataRow row in dsReportees.Tables[0].Rows)
//        {
//            string reporttee = row["empcode"].ToString().Trim();

//            sql = sql + reporttee + "','";
//        }

//        sql = sql + "')";

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.Parameters.Add("@CalenderId", SqlDbType.Int).Value = calanderId;
                cmd.Parameters.Add("@leaveid", SqlDbType.Int).Value = leaveId;
                cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                grid.DataSource = dt;
                grid.DataBind();

            }
        }
    }

    void GenerateLeaveReport1(string calanderId, string policyId, string leaveId)
    {
        //DataSet dsReportees = (DataSet)Session["teamReportees"];
        //if (dsReportees.Tables[0].Rows.Count < 1)
        //    return;
        string sql =
@"select 
L.empcode EmpCode,
J.emp_fname Name,
D.department_name DepartentName,
convert(varchar(10),J.emp_doj,101) DOJ,
L.Entitled_days - ( isnull(A.Jan,0) + isnull(A.Feb,0) + isnull(A.Mar,0) + isnull(A.Apr,0) + isnull(A.May,0) + isnull(A.Jun,0) + isnull(A.Jul,0) + isnull(A.Aug,0) + isnull(A.Sep,0) + isnull(A.Oct,0) + isnull(A.Nov,0) + isnull(A.Dec,0)) OpeningBalance,
R.entitled_days Eligibility,
A.Jan,
A.Feb,
A.Mar,
A.Apr,
A.May,
A.Jun,
A.Jul,
A.Aug,
A.Sep,
A.Oct,
A.Nov,
A.Dec,
( isnull(A.Jan,0) + isnull(A.Feb,0) + isnull(A.Mar,0) + isnull(A.Apr,0) + isnull(A.May,0) + isnull(A.Jun,0) + isnull(A.Jul,0) + isnull(A.Aug,0) + isnull(A.Sep,0) + isnull(A.Oct,0) + isnull(A.Nov,0) + isnull(A.Dec,0)) TotalEligibleLeave,
B.Jan,
B.Feb,
B.Mar,
B.Apr,
B.May,
B.Jun,
B.Jul,
B.Aug,
B.Sep,
B.Oct,
B.Nov,
B.Dec,
( isnull(B.Jan,0) + isnull(B.Feb,0) + isnull(B.Mar,0) + isnull(B.Apr,0) + isnull(B.May,0) + isnull(B.Jun,0) + isnull(B.Jul,0) + isnull(B.Aug,0) + isnull(B.Sep,0) + isnull(B.Oct,0) + isnull(B.Nov,0) + isnull(B.Dec,0)) TotalAvailedLeave,
L.Entitled_days - Used_days Balance

 from tbl_leave_employee_leave_master as L

left join

(
 
select *
from
(
select calanderid, policyid, leaveid, leavemonth, empcode, curmonthentitle
 from tbl_leave_processleavemonthly p
 inner join tbl_leave_processleavemonthlydetails pd on p.id = pd.processid
  group by calanderid, policyid, leaveid, leavemonth, empcode, curmonthentitle, premonthentitle
) src
pivot
(
    max(curmonthentitle)
    for leavemonth in (Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec )
) piv

) as A on A.calanderid = L.calenderid and A.leaveid = L.leaveid and A.policyid = L.PolicyId and A.empcode = L.empcode

left join

(

select *
from
(
select l.calenderid, l.policyid, l.leaveid, l.empcode , CAST(DATENAME(MONTH, fromdate) as VARCHAR(3)) month ,l.no_of_days
 from tbl_leave_apply_leave l
 where  l.leave_status in (6) and l.status in (1)
) src
pivot
(
   sum(no_of_days)
   for month in (Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec )
) pvt
 
) B on L.calenderid = B.calenderid and L.leaveid = B.leaveid and L.PolicyId = B.policyid and L.empcode = B.empcode

left join tbl_intranet_employee_jobDetails J on l.empcode = J.empcode
left join tbl_internate_departmentdetails D on J.dept_id = D.departmentid
left join tbl_leave_employee_hierarchy app on app.employeecode = J.empcode
left join tbl_leave_createdefaultrule R on R.leaveid = @leaveid and R.policyid = @PolicyId

where L.calenderid = @CalenderId  and L.PolicyId = @PolicyId and app.approverid='" + Session["empcode"].ToString() + "'";
//and J.empcode in ('";

        //foreach (DataRow row in dsReportees.Tables[0].Rows)
        //{
        //    string reporttee = row["empcode"].ToString().Trim();

        //    sql = sql + reporttee + "','";
        //}

        //sql = sql + "')";

        using (SqlConnection conn = new SqlConnection())
        {
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            conn.Open();

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;

                cmd.Parameters.Add("@CalenderId", SqlDbType.Int).Value = calanderId;
                cmd.Parameters.Add("@leaveid", SqlDbType.Int).Value = leaveId;
                cmd.Parameters.Add("@PolicyId", SqlDbType.Int).Value = policyId;

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                sda.Fill(dt);

                grid.DataSource = dt;
                grid.DataBind();

            }
        }
    }

    protected void grid_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            GridViewRow Row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

            for (int i = 1; i <= 6; i++)
            {
                TableCell cell = new TableCell();
                //cell.RowSpan = 2;

                Row.Cells.Add(cell);
            }

            TableCell cell7 = new TableCell();

            cell7.ColumnSpan = 12;
            cell7.Text = "<b>Monthly Leave Grant</b>";
            cell7.HorizontalAlign = HorizontalAlign.Center;
            Row.Cells.Add(cell7);

            TableCell cell8 = new TableCell();
            Row.Cells.Add(cell8);

            TableCell cell9 = new TableCell();

            cell9.ColumnSpan = 12;
            cell9.Text = "<b>Monthly Leave Availed</b>";
            cell9.HorizontalAlign = HorizontalAlign.Center;
            Row.Cells.Add(cell9);

            TableCell cell25 = new TableCell();
            Row.Cells.Add(cell25);

            TableCell cell26 = new TableCell();
            Row.Cells.Add(cell26);



            grid.Controls[0].Controls.AddAt(0, Row);

        }

        if (e.Row.RowType == DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
                if (e.Row.Cells[i].Text.Trim() == "Jan1")
                {
                    e.Row.Cells[i].Text = "Jan";
                }

                if (e.Row.Cells[i].Text.Trim() == "Feb1")
                {
                    e.Row.Cells[i].Text = "Feb";
                }

                if (e.Row.Cells[i].Text.Trim() == "Mar1")
                {
                    e.Row.Cells[i].Text = "Mar";
                }

                if (e.Row.Cells[i].Text.Trim() == "Apr1")
                {
                    e.Row.Cells[i].Text = "Apr";
                }

                if (e.Row.Cells[i].Text.Trim() == "May1")
                {
                    e.Row.Cells[i].Text = "May";
                }
                if (e.Row.Cells[i].Text.Trim() == "Jun1")
                {
                    e.Row.Cells[i].Text = "Jun";
                }

                if (e.Row.Cells[i].Text.Trim() == "Jul1")
                {
                    e.Row.Cells[i].Text = "Jul";
                }

                if (e.Row.Cells[i].Text.Trim() == "Aug1")
                {
                    e.Row.Cells[i].Text = "Aug";
                }

                if (e.Row.Cells[i].Text.Trim() == "Sep1")
                {
                    e.Row.Cells[i].Text = "Sep";
                }

                if (e.Row.Cells[i].Text.Trim() == "Oct1")
                {
                    e.Row.Cells[i].Text = "Oct";
                }

                if (e.Row.Cells[i].Text.Trim() == "Nov1")
                {
                    e.Row.Cells[i].Text = "Nov";
                }

                if (e.Row.Cells[i].Text.Trim() == "Dec1")
                {
                    e.Row.Cells[i].Text = "Dec";
                }
            }
        }
    }

    public DataSet empcode { get; set; }
}