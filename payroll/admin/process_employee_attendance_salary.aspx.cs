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

public partial class payroll_admin_process_attendance_salary : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_message.Text = "";
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
            }
            else Response.Redirect("~/notlogged.aspx");
            current_month();            
        }
        bind_fyear();
    }

    protected void current_month()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    protected void bind_fyear()
    {
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
            lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }

    
    protected void bind_attendance()
    {
        DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
        DateTime dt2 = dt.AddMonths(-1).AddDays(1);
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[0].Value = dt;

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = dt2;

        sqlparam[2] = new SqlParameter("@FYEAR", SqlDbType.VarChar, 50);
        sqlparam[2].Value = lbl_fyear.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_month.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@EMPCODE", SqlDbType.VarChar,50);
        sqlparam[4].Value = txt_employee.Text;        

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_SINGLE_employee_attendance]", sqlparam);
        
        //CHECK THIS LATTER
        //sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();
       
        //sqlparam[1] = new SqlParameter("@enddate", SqlDbType.DateTime);
        //sqlparam[1].Value = dt;

        //sqlparam[2] = new SqlParameter("@sdate", SqlDbType.DateTime);
        //sqlparam[2].Value = dt2;

        //sqlparam[3] = new SqlParameter("@empcode", SqlDbType.VarChar);
        //sqlparam[3].Value = txt_employee.Text;

        //DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_PROCESS_SINGLEEMPLOYEE_ATTENDANCE", sqlparam);
        //DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_job_process_employee_attendance_ondailybasis", sqlparam);
             
    }

    protected void btn_procs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        lbl_message.Text = lbl_message.Text = "Attendance processed successfully";
   
    }
   
    protected void bind_salary()
    {
        
        DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue),1);
        DateTime dt2 = dt.AddMonths(1).AddDays(-1);
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[6];
        
        sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();

        sqlparam[1] = new SqlParameter("@TODATE", SqlDbType.DateTime);
        sqlparam[1].Value = dt2;

        sqlparam[2] = new SqlParameter("@FROMDATE", SqlDbType.DateTime);
        sqlparam[2].Value = dt;

        sqlparam[3] = new SqlParameter("@user", SqlDbType.VarChar, 50);
        sqlparam[3].Value = Session["name"].ToString();

        sqlparam[4] = new SqlParameter("@fyear", SqlDbType.VarChar, 50);
        sqlparam[4].Value = lbl_fyear.Text;

        sqlparam[5] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[5].Value = txt_employee.Text;

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_SINGLE_EMPLOYEE_SALARY_GENERATE", sqlparam);
    }
    protected void btn_procs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary processed successfully";
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
    }
}
