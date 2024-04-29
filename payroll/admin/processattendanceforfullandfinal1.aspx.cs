using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using DataAccessLayer;
using querystring;
//--for CrystalReports's ReportDocument.
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
public partial class payroll_admin_processattendanceforfullandfinal1 : System.Web.UI.Page
{
    string connStr = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString();
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");

            bind_fyear();
        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        SaveAttendance();
    }

    protected void bind_fyear()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(ddl_month.SelectedValue) >= 4)
            lblfyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lblfyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }

    protected void SaveAttendance()
    {
        string sno, empcode, lwp, workingDays, month, year;
        sno = "1";
        empcode = txt_employee.Text.Trim();
        lwp = txtlwp.Text.Trim();
        workingDays = txt_wdays.Text.Trim();
        month = ddl_month.SelectedItem.ToString();
        year = lblfyear.Text.Trim();
        DateTime fromDate = new DateTime(DateTime.Now.Year, Convert.ToInt32(ddl_month.SelectedValue), 01);
        DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("sp_payroll_employee_import_attendance", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@sno",sno);
            cmd.Parameters.AddWithValue("@empcode", empcode);
            cmd.Parameters.AddWithValue("@lwp", lwp);
            cmd.Parameters.AddWithValue("@working_days", workingDays);
            cmd.Parameters.AddWithValue("@fromdate", fromDate);
            cmd.Parameters.AddWithValue("@todate", toDate);
            cmd.Parameters.AddWithValue("@month", month);
            cmd.Parameters.AddWithValue("@year", year);
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                int i = cmd.ExecuteNonQuery();
                message.InnerText = "Attendance data uploaded successfully!";
                txtlwp.Text = string.Empty;
                txt_wdays.Text = string.Empty;
            }

        }
    }
    protected void ddl_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}