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
using Common.Data;
using Common.Console;

public partial class payroll_admin_process_attendance_salary : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_message.Text = "";
        if (!IsPostBack)
        {
            bind_fyear();
            if (Session["role"] != null)
            {
              
            }
            else Response.Redirect("~/notlogged.aspx");
            //current_month(); //22Sep2010
        }
       
        //validate_attendance();
    }

    protected void current_month()
    {
        DateTime dt = DateTime.Now;
        DateTime da = new DateTime(dt.Year, dt.Month, 1);

        if (Convert.ToInt16(dt.Day) > da.AddMonths(1).AddDays(-1).Day)
            dt = dt.AddMonths(1);

        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        dd_month.Items.Add(new ListItem(dt.ToString("MMM"), dt.Month.ToString()));
        dd_month.SelectedValue = dt.Month.ToString();
    }
    protected void bind_fyear()
    {
        int year = DateTime.Now.Year, count = 1;
        lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        for (int i = year - 1; i < year + 5; i++)
        {
            lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
            count++;
        }
        //DateTime dt = DateTime.Now;

        //if (Convert.ToInt16(dt.Day) >= 30)
        //    dt = dt.AddMonths(1);

        //if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
        //    lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //else
        //    lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }
    protected void validate_attendance()
    {
        sqlstr = "select count(MONTH) as rows from tbl_payroll_employee_attendence_detail where MONTH='" + dd_month.SelectedItem.Text.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);
     
        //******************  Case 1: when there is data for the selected month for attendance in tbl_payroll_employee_attendence **************// 
        
        if (Convert.ToInt16(ds.Tables[0].Rows[0]["rows"])>0)
        {
         sqlstr = "select count(MONTH) as salary_rows from tbl_payroll_employee_salary where MONTH='" + dd_month.SelectedItem.Text.ToString() + "'";
         ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text,sqlstr);

        //******************  Case 2: when there is  data for slected month for salary in tbl_payroll_employee_salary **************// 

             if(Convert.ToInt16(ds.Tables[0].Rows[0]["salary_rows"])>0)
            {
                btn_procs_att.Enabled = false;
                btn_procs_salary.Enabled = false;
                btn_reprocs_att.Enabled = true;
                btn_reprocs_salary.Enabled = true;    
             }
         //******************  Case 3: when there is no data for slected month for salary in tbl_payroll_employee_salary **************// 
            else
            {
               btn_procs_salary.Enabled=true;
               btn_reprocs_salary.Enabled=false;
               btn_procs_att.Enabled = false;
               btn_reprocs_att.Enabled = true;
            }
        }
        //******************  Case 4: when there is no data for slected month for attendance in tbl_payroll_employee_salary **************// 

        else
        {
            btn_procs_att.Enabled=true;
            btn_procs_salary.Enabled=false;
            btn_reprocs_att.Enabled=false;
            btn_reprocs_salary.Enabled=false;
        }
    }
    
    protected void bind_attendance()
    {
        DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 26);
        DateTime dt2 = dt.AddMonths(-1).AddDays(1);

        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[5];

        sqlparam[0] = new SqlParameter("@enddate", SqlDbType.DateTime);
        sqlparam[0].Value = dt;

        sqlparam[1] = new SqlParameter("@sdate", SqlDbType.DateTime);
        sqlparam[1].Value = dt2;

        sqlparam[2] = new SqlParameter("@FYEAR", SqlDbType.VarChar,50);
        sqlparam[2].Value = lbl_fyear.Text.Trim().ToString();

        sqlparam[3] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        sqlparam[3].Value = dd_month.SelectedItem.Text;

        sqlparam[4] = new SqlParameter("@branchid", SqlDbType.Int);
        if (ddlbranch.SelectedIndex != 0)
        {
            sqlparam[4].Value = ddlbranch.SelectedValue;
        }
        else
        {
            sqlparam[4].Value = 0;
        }

        DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_payroll_generate_employee_attendance]", sqlparam);

    //    SqlParameter[] sqlparam;
    //    sqlparam = new SqlParameter[3];

    //    sqlparam[0] = new SqlParameter("@month", SqlDbType.VarChar, 50);
    //    sqlparam[0].Value = dd_month.SelectedItem.Text.ToString();
       
    //    sqlparam[1] = new SqlParameter("@enddate", SqlDbType.DateTime);
    //    sqlparam[1].Value = dt;

    //    sqlparam[2] = new SqlParameter("@sdate", SqlDbType.DateTime);
    //    sqlparam[2].Value = dt2;

        
    //DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_process_employee_attendance", sqlparam); 
    }
    protected void btn_reprocs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        lbl_message.Text = lbl_message.Text = "Attendance re-processed successfully";
        //validate_attendance();
    }
    protected void btn_procs_att_Click(object sender, EventArgs e)
    {
        bind_attendance();
        lbl_message.Text = lbl_message.Text = "Attendance processed successfully";
        //validate_attendance();
    }
   
    protected void bind_salary()
    {
        if (rbtnbranch.Checked)
        {
            if (Session["name"] != null)
            {
                string fyer = lbl_fyear.Text.Trim().ToString();
                string[] mob = fyer.Split('-');
                int year;
                if (Convert.ToInt32(dd_month.SelectedValue) <= 3)
                {
                    year = Convert.ToInt32(mob[1].ToString());
                }
                else
                {
                     year = Convert.ToInt32(mob[0].ToString());
                }

                int dtNow = DateTime.DaysInMonth(year, Convert.ToInt32(dd_month.SelectedValue));
                DateTime dt = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), 01);
                DateTime dt2 = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), dtNow);

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

                sqlparam[5] = new SqlParameter("@branchid", SqlDbType.Int);
                if (ddlbranch.SelectedIndex != 0)
                {
                    sqlparam[5].Value = ddlbranch.SelectedValue;
                }
                else
                {
                    sqlparam[5].Value = 0;
                }

                //sqlparam[6] = new SqlParameter("@month_id", SqlDbType.VarChar, 50);
                //sqlparam[6].Value = dd_month.SelectedValue;

                //sqlparam[7] = new SqlParameter("@yaer", SqlDbType.VarChar, 50);
                //sqlparam[7].Value = year;

                DBTask.ExecuteScalar(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "SP_PAYROLL_EMPLOYEE_SALARY_GENERATE", sqlparam);
            }
        }
        if (rbtnemp.Checked)
        {
            bind_emp_sal();
        }
    }

    protected void bind_emp_sal()
    {
       // DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 25);
     //   DateTime dt2 = dt.AddMonths(-1).AddDays(1);

        string fyer = lbl_fyear.Text.Trim().ToString();
        string[] mob = fyer.Split('-');
        int year;

        if (Convert.ToInt32(dd_month.SelectedValue) <= 3)
        {
            year = Convert.ToInt32(mob[1].ToString());
        }
        else
        {
            year = Convert.ToInt32(mob[0].ToString());
        }

        int dtNow = DateTime.DaysInMonth(year, Convert.ToInt32(dd_month.SelectedValue));
        DateTime dt = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), 01);
        DateTime dt2 = new DateTime(year, Convert.ToInt32(dd_month.SelectedValue), dtNow);

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
        DataSet ds = new DataSet();
        DataActivity activity = new DataActivity();
        SqlConnection connection = new SqlConnection();

        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select distinct FLAG from tbl_payroll_employee_salary where MONTH='" + dd_month.SelectedItem.Text + "' and YEAR = '" + lbl_fyear.Text + "' and branch_id = '" + ddlbranch.SelectedValue + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                bind_salary();
                lbl_message.Text = "Salary processed successfully";

            if (ds.Tables[0].Rows.Count >= 1)
            {
                if (ds.Tables[0].Rows[0]["FLAG"].ToString() == "False")
                {
                    ddlbranch.SelectedValue = "0";
                    //dd_month.SelectedValue = "1";
                    lbl_message.Text = lbl_message.Text = "Already Freezed! You can't process the salary for " + dd_month.SelectedItem.Text + "" + lbl_fyear.Text + "";
                }
                if (ds.Tables[0].Rows[0]["FLAG"].ToString() == "True")
                {
                    bind_salary();
                    lbl_message.Text = "Salary processed successfully";
                    // return;
                }
            }
            return;
               
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
        //try
        //{
            
        //    bind_salary();
        //}
        //catch
        //{
        //}
        
        ////validate_attendance();
    }

    protected void btn_reprocs_salary_Click(object sender, EventArgs e)
    {
        bind_salary();
        lbl_message.Text = "Salary re-processed successfully"; 
        //validate_attendance();
    }

    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_fyear();
        //validate_attendance();
    }

    //protected void find_end_start_date()
    //{
    //    DateTime dt = new DateTime(DateTime.Now.Year, Convert.ToInt32(dd_month.SelectedValue), 24);
    //    DateTime dt2 = dt.AddMonths(-1).AddDays(1);
        
         
    //}
    protected void ddlbranch_DataBound(object sender, EventArgs e)
    {
        ddlbranch.Items.Insert(0, new ListItem("---Select Branch---", "0"));
    }

    protected void rbtnemp_CheckedChanged(object sender, EventArgs e)
    {
        divemp.Visible = true;
        divbranch.Visible = false;
    }

    protected void rbtnbranch_CheckedChanged(object sender, EventArgs e)
    {
        divemp.Visible = false;
        divbranch.Visible = true;
    }

    protected void Frezeed()
    {
        DataSet ds = new DataSet();
        DataActivity activity = new DataActivity();
        SqlConnection connection = new SqlConnection();

        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"select distinct FLAG from tbl_payroll_employee_salary where MONTH='" + dd_month.SelectedItem.Text + "' and YEAR = '" + lbl_fyear.Text + "' and branch_id = '" + ddlbranch.SelectedValue + "'";
            ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count < 1)
                return;

            if (ds.Tables[0].Rows[0]["FLAG"].ToString() == "False")
            {
                ddlbranch.SelectedValue = "0";
                dd_month.SelectedValue = "1";
                lbl_message.Text = lbl_message.Text = "Already Freezed! You can't process the salary for " + dd_month.SelectedItem.Text + "" + lbl_fyear.Text + "";
            }
            if (ds.Tables[0].Rows[0]["FLAG"].ToString() == "True")
                return;
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
