using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Common.Console;
using Common.Data;
public partial class attendance_overwriteattendance : System.Web.UI.Page
{
    string _companyId;
    DataSet ds = new DataSet();
    bool c = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
               
            }
        }
        else {Response.Redirect("~/notlogged.aspx"); }
    }

    #region Bind the Attendance
    protected void bind_attendance()
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        string FromDate = Common.Date.Utility.DateFormat(txt_frmdate.Text).ToString("dd-MMM-yyyy");
        string ToDate = Common.Date.Utility.DateFormat(txt_todate.Text).ToString("dd-MMM-yyyy");

        try
        {
            Connection = Activity.OpenConnection();
            string query = @"select distinct mode,tbl_payroll_employee_attendence_detail.empcode,tbl_payroll_employee_attendence_detail.empcode,convert(varchar(10),date,101) date from tbl_payroll_employee_attendence_detail INNER JOIN tbl_intranet_employee_jobDetails jD ON tbl_payroll_employee_attendence_detail.empcode=jD.empcode where tbl_payroll_employee_attendence_detail.empcode in ('" + txt_employee.Text + "') and date between ('" + FromDate + "') and ('" + ToDate + "') order by date";
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Button1.Visible = true;
               // update.Visible = true;
                empgrid.DataSource = ds;
                empgrid.DataBind();
               
            }
            else
            {
                Button1.Visible = false;
               // update.Visible = false;
                //message.InnerHtml = "No data found";
              
            }
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }


    }
    #endregion
    #region Fetch Attendance
    protected void Button1_Click(object sender, EventArgs e)
    {
        bind_attendance();
    }
    #endregion


    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        empgrid.PageIndex = e.NewPageIndex;
        bind_attendance();
    }

    protected void updateattendance()
    {
        SqlParameter[] parm = new SqlParameter[8];
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        int Flag = 0;
        try
        {
            foreach (GridViewRow GridView in empgrid.Rows)
            {
                CheckBox chkbox = (CheckBox)GridView.FindControl("Chkbox");
                if (chkbox.Checked)
                {
                    c = true;
                    string mode = ((DropDownList)empgrid.Rows[GridView.RowIndex].Cells[4].Controls[1]).SelectedItem.Text;
                    string code = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[2].Controls[1]).Text);
                    string empcode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[1].Controls[1]).Text);
                    string date = Common.Date.Utility.DateFormat(((Label)empgrid.Rows[GridView.RowIndex].Cells[0].Controls[1]).Text).ToString("dd-MMM-yyyy");
                    string oldmode = Convert.ToString(((Label)empgrid.Rows[GridView.RowIndex].Cells[3].Controls[1]).Text);

                    string month = Convert.ToDateTime(date).ToString("MMMM");
                    string year = Convert.ToDateTime(date).Year.ToString();

                    string chk_freez = @"select * from tbl_freezeattendance where month='"+month+"' and YEAR='"+year+"' and status='F'";
                    ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, chk_freez);

                    if (ds.Tables[0].Rows.Count < 1)
                    {
                        if (mode != oldmode)
                        {
                            int olddate = GetOldDate(empcode, date, _companyId);
                            if (olddate <= 0)
                            {
                                string str3 = @"insert into tbl_attendance_overrite_latest(company_id,empcode,date,mode,status) values('" + _companyId + "','" + empcode + "','" + date + "','" + mode + "',1) ";
                                _Transaction = Connection.BeginTransaction();
                                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str3);
                                _Transaction.Commit();
                            }
                            else
                            {
                                string str1 = @"update tbl_attendance_overrite_latest set mode='" + mode + "' where empcode='" + empcode + "' and date='" + date + "' and  company_id='" + _companyId + "'";
                                _Transaction = Connection.BeginTransaction();
                                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str1);
                                _Transaction.Commit();

                            }
                            string str5 = @"update tbl_payroll_employee_attendence_detail set mode='" + mode + "' where empcode='" + empcode + "' and date='" + date + "' and company_id='" + _companyId + "'";
                            _Transaction = Connection.BeginTransaction();
                            Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str5);
                            _Transaction.Commit();
                        }
                    }
                }
            }
            if (c == false)
            {
                Output.Show("Please check atleast one employee before overwriting attendance");
            }
        }
        catch (Exception ex)
        {
            _Transaction.Rollback();
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        if (Flag > 0)
        {
            // DBTask.ExecuteNonQuery(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "[sp_job_process_employee_attendance_ondailybasis]");
            bind_attendance();
            Output.Show("Attendance updated successfully");
            //  Reset();
        }
        else
        {
            Output.Show("Attendance Not updated successfully");
        }


    }

    private int GetOldDate(string empcode, string date, string CompanyId)
    {
        SqlConnection Connection = null;
        DataSet ds = null;
        SqlParameter[] parm = new SqlParameter[6];
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        try
        {
            string query = @"select count(date) as date from dbo.tbl_attendance_overrite_latest where  company_id=" + CompanyId + " and empcode='" + empcode + "' and  date='" + date + "'";
            Connection = Activity.OpenConnection();
            ds = Common.Data.SQLServer.ExecuteDataset(Connection, CommandType.Text, query);
            // if (ds.Tables[0].Rows.Count > 0)
            return Convert.ToInt32(ds.Tables[0].Rows[0]["date"].ToString());
            //  else return -1;
        }
        catch (Exception ex)
        {

            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Common.Console.Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        //  if (ds.Tables[0].Rows.Count > 0)
        return Convert.ToInt32(ds.Tables[0].Rows[0]["date"].ToString());
        //  else return -1;
    }

    protected void Button1_Click2(object sender, EventArgs e)
    {
        updateattendance();
    }

   
    protected void empgrid_PreRender(object sender, EventArgs e)
    {

        if (empgrid.Rows.Count > 0)
            empgrid.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

  
}
