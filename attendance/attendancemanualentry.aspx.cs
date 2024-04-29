using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;

public partial class attendance_attendancemanualentry : System.Web.UI.Page
{
    string _companyId;
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            if (!IsPostBack)
            {
            }
            Image1.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtstime'))");
            Image2.Attributes.Add("onclick", "javascript:selectTime(this,getElementById('txtetime'))");
        }
        else { Response.Redirect("../LogOut.aspx"); }
    }

    protected void submitbtn_Click(object sender, EventArgs e)
    {
        SqlConnection Connection = null;
        SqlTransaction _Transaction = null;
        int Flag = 0;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();
        try
        {
            if ((txtstime.Text.Trim() != "") || (txtetime.Text.Trim() != "") || (txt_employee.Text.Trim() != "") || (txt_start_date.Text.Trim() != ""))
            {

                if (!ValidateDOJ())
                    return;
                string ttime;
                string etime;
                ttime = Convert.ToDateTime(txt_start_date.Text.Trim() + " " + txtstime.Text.Trim()).ToString();
                etime = Convert.ToDateTime(txt_start_date.Text.Trim() + " " + txtetime.Text.Trim()).ToString();
                string str3 = @"if not exists (select * from tbl_attendance_overrite_latest where empcode='" + txt_employee.Text.Trim() + "' and date='" + txt_start_date.Text.Trim() + "' and company_id='" + _companyId + "')";
                str3 += "insert into tbl_attendance_overrite_latest(company_id,empcode,date,mode,status,intime,outtime) values('" + _companyId + "','" + txt_employee.Text.Trim() + "','" + txt_start_date.Text.Trim() + "','P',1";
                if (txtstime.Text.Trim().ToString() != "")
                    str3 += ", '" + ttime + "' ";
                else
                    str3 += ",null";

                if (txtetime.Text.Trim().ToString() != "")
                    str3 += ", '" + etime + "') ";
                else
                    str3 += ", null)";

                str3 += "else update tbl_attendance_overrite_latest set mode=null ";
                if (txtstime.Text.Trim().ToString() != "")
                    str3 += ", intime='" + ttime + "' ";
                else
                    str3 += ", intime=null";

                if (txtetime.Text.Trim().ToString() != "")
                    str3 += ", outtime='" + etime + "' ";
                else
                    str3 += ", outtime=null";
                str3 += " where empcode='" + txt_employee.Text.Trim() + "' and date='" + txt_start_date.Text.Trim() + "' and  company_id='" + _companyId + "'";
                _Transaction = Connection.BeginTransaction();
                Flag = SQLServer.ExecuteNonQuery(Connection, CommandType.Text, _Transaction, str3);
                _Transaction.Commit();
            }
            else
            {
                Output.Show("Please select either Intime or OutTime.");
                return;
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
            Output.Show("Attendance updated successfully");
            Reset();
        }
        else
        {
            Output.Show("Attendance Not updated successfully");
        }
    }

    private bool ValidateDOJ()
    {
        SqlConnection Connection = null;
        Common.Data.DataActivity Activity = new Common.Data.DataActivity();
        Connection = Activity.OpenConnection();

        try
        {
            string sqlstr = @"select convert(varchar(10),emp_doj,101) as emp_doj from tbl_intranet_employee_jobDetails where empcode='" + txt_employee.Text.Trim() + "'";

            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.Text, sqlstr);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["emp_doj"] != null && ds.Tables[0].Rows[0]["emp_doj"].ToString() != "")
                {
                    if (Convert.ToDateTime(ds.Tables[0].Rows[0]["emp_doj"].ToString()) > Convert.ToDateTime(txt_start_date.Text.ToString()))
                    {
                        Output.Show("Please note Employee Attendance starts from " + ds.Tables[0].Rows[0]["emp_doj"].ToString() + "  . Please check Date of Joining for Selected Employee.");
                        return false;
                    }
                }
            }
        }

        catch (Exception ex)
        {
            Common.Console.Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            //Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
        return true;
    }

    private void Reset()
    {
        txt_employee.Text = "";
        txt_start_date.Text = "";
        txtstime.Text = "";
        txtetime.Text = "";
    }
}
