using Common.Console;
using Common.Data;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


public partial class leave_leaveencashmentform : System.Web.UI.Page
{
    private DataSet ds = new DataSet();
    DataSet _ds = new DataSet();
    SqlTransaction transaction = null;
    SqlConnection _connection;
    DataTable dtable;
    Common.Data.DataActivity activity = new Common.Data.DataActivity();
    private string _companyId, _userCode, sqlstr;
    public int i, error;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["empcode"] != null && Session["companyid"] != null)
        {
            _companyId = Session["companyid"].ToString();
            _userCode = Session["empcode"].ToString();
            if (!IsPostBack)
            {
               // ddl_cc_code.Items.Insert(0, new ListItem("--Select--", "0"));
                ddl_leave.Items.Insert(0, new ListItem("--Select--", "0"));
                Bind_fyear();
              //  BindMonth();
            }
        }
        else
        {
           Response.Redirect("~/notlogged.aspx");
        }

    }
    #region Bind Year

    private void Bind_fyear()
    {
        //drpyear.Items.Clear();
        //drpyear.Items.Insert(0, "--Select Financial Year--");
        //for (int yr = 2014; yr <= DateTime.Now.Year + 1; yr++)
        //{
        //    int nextyear = yr + 1;
        //    drpyear.Items.Add(new ListItem(Convert.ToString(yr + "-" + (nextyear))));
        //}
        try
        {
            _connection = activity.OpenConnection();
            string sqlstr = "select id ,periodname from tbl_leave_leaveperiod where status=0";
            DataSet ds3 = new DataSet();
            ds3 = SQLServer.ExecuteDataset(_connection, CommandType.Text, sqlstr);

            drpyear.DataTextField = "periodname";
            drpyear.DataValueField = "id";
            drpyear.DataSource = ds3;
            drpyear.DataBind();
            drpyear.Items.Insert(0, new ListItem("--Select--", "0"));
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
    #endregion
    protected void BindMonth()
    {

        SqlConnection Connection = null;
        var Activity = new DataActivity();
        try
        {
            dd_month.Items.Clear();
            dd_month.Items.Insert(0, "--Select Month--");
            Connection = Activity.OpenConnection();
            DataSet ds = SQLServer.ExecuteDataset(Connection, CommandType.StoredProcedure, "sp_leave_getmonth_name");
            dd_month.DataTextField = "monthname";
            dd_month.DataValueField = "month";
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ListItem item = new ListItem();
                item.Text = ds.Tables[0].Rows[i]["monthname"].ToString();
                item.Value = ds.Tables[0].Rows[i]["month"].ToString();
                dd_month.Items.Add(new ListItem(Convert.ToString(item.Text), Convert.ToString(item.Value)));
            }
        }
        catch (Exception ex)
        {

            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            Activity.CloseConnection();
        }
    }
    protected void ddl_leave_DataBound(object sender, EventArgs e)
    {
        ddl_leave.Items.Insert(0, new ListItem("--Select--", "0"));
       // ddl_leave.Items.Insert(0, "--Select Leave--");
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindLeaveTypes();
        if (txt_employee.Text != "")
        {
            Session["Leaveempcode"] = txt_employee.Text;
            Session["periodid"] = drpyear.SelectedValue;

            lslink.Visible = true;
        }
        else Output.Show("Please Select Empcode");
    }
    protected void ddl_leave_SelectedIndexChanged(object sender, EventArgs e)
    {
        //SqlConnection connection = activity.OpenConnection();
        //sqlstr = @"select fyear tbl_leave_encashment where empcode='" + txt_employee.Text.ToString() + "' and fyear='"+ +"' and leaveid=" + ddl_leave.SelectedValue + "";
        //_ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
        BindLeaveInfo(txt_employee.Text.Trim(), ddl_leave.SelectedValue);
        if (!ValidateEncashDays(txtEncashDays.Text, lblEncashLimit.Text))
            return;

    }
    private void BindLeaveInfo(string _empCode, string _leaveId)
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = @"select tbl_leave_emp_leave_history.PolicyId as PolicyId,empcode,
 tbl_leave_emp_leave_history.encashmentdays as finalbalance, 
tbl_leave_emp_leave_history.encashmentdays as encash_days_limt 

from tbl_leave_emp_leave_history  
inner join tbl_leave_createdefaultrule on tbl_leave_createdefaultrule.leaveid=tbl_leave_emp_leave_history.leaveid 
and tbl_leave_createdefaultrule.policyid=tbl_leave_emp_leave_history.PolicyId 
                           where empcode='" + _empCode.ToString() + "' and tbl_leave_emp_leave_history.encashmentstatus=1 and tbl_leave_emp_leave_history.leaveid=" + _leaveId + " and  tbl_leave_emp_leave_history.encashmentapplicable=1 and tbl_leave_emp_leave_history.calenderid=" + drpyear.SelectedValue + "";
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                lblCurBalance.Text = _ds.Tables[0].Rows[0]["finalbalance"].ToString();
                lblEncashLimit.Text = _ds.Tables[0].Rows[0]["encash_days_limt"].ToString();
                hdnpolicyid.Value = _ds.Tables[0].Rows[0]["PolicyId"].ToString();
            }
            else
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
    private void BindLeaveTypes()
    {
        try
        {
            SqlConnection connection = activity.OpenConnection();
            sqlstr = @"select distinct tbl_leave_createleave.leaveid,tbl_leave_createleave.leavetype 
from tbl_leave_createleave 
 --inner join tbl_leave_createdefaultrule on tbl_leave_createdefaultrule.leaveid=tbl_leave_createleave.leaveid 
 inner join tbl_leave_emp_leave_history on tbl_leave_emp_leave_history.leaveid=tbl_leave_createleave.leaveid
                            where tbl_leave_emp_leave_history.encashmentapplicable=1 and tbl_leave_emp_leave_history.status=1 and tbl_leave_emp_leave_history.encashmentstatus=1 and empcode='" + txt_employee.Text + "' and tbl_leave_emp_leave_history.calenderid='" + drpyear.SelectedValue + "' ";
            _ds = SQLServer.ExecuteDataset(connection, CommandType.Text, sqlstr);
            if (_ds.Tables[0].Rows.Count > 0)
            {
                ddl_leave.DataTextField = "leavetype";
                ddl_leave.DataValueField = "leaveid";
                ddl_leave.DataSource = _ds;
                ddl_leave.DataBind();
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
    }


    protected void btn_sbmit_Click(object sender, EventArgs e)
    {
        if (Convert.ToDouble(txtEncashDays.Text) > 0.0)
        {
            if (!ValidateEncashDays(txtEncashDays.Text, lblEncashLimit.Text))
                return;
            SaveEncashDetails();
        }
        else Output.Show("Please Enter Encashment Days should be greater than 0.");
    }

    private void SaveEncashDetails()
    {
        int j = 0;
        try
        {
            _connection = activity.OpenConnection();
            transaction = _connection.BeginTransaction();
            sqlstr = @"insert into tbl_leave_encashment(companyid,policyid,leaveid,empcode,leavebalasondate,encashmentlimit,fyear,month,createdby,comments,Encashment_Days,status,calenderid)
                              values ('" + _companyId + "','" + hdnpolicyid.Value + "','" + ddl_leave.SelectedValue.ToString() + "','" + txt_employee.Text.Trim().ToString() + "','" + lblCurBalance.Text.ToString() + "','" + lblEncashLimit.Text.ToString() + "','" + drpyear.SelectedItem.ToString() + "','" + dd_month.SelectedItem.ToString() + "','" + _userCode + "','" + txtcomments.Text + "','" + txtEncashDays.Text + "',1," + drpyear.SelectedValue + ")";
            i = SQLServer.ExecuteNonQuery(_connection, CommandType.Text, transaction, sqlstr);

            //sqlstr = @"update tbl_leave_emp_leave_history set encashmentdays=encashmentdays-" + Convert.ToDecimal(txtEncashDays.Text.Trim()) + "  where empcode='" + txt_employee.Text + "' and leaveid='" + ddl_leave.SelectedValue + "' and PolicyId='" + hdnpolicyid.Value + "'and periodid='" + drpyear.SelectedValue + "' and encashmentstatus=1";

            sqlstr = @"update tbl_leave_emp_leave_history set encashmentstatus=0 ,cur_encashed='" + txtEncashDays.Text.ToString() + "' , elapsed=elapsed+(" + lblEncashLimit.Text.ToString() + "-" + txtEncashDays.Text.ToString() + ") where empcode='" + txt_employee.Text + "' and leaveid='" + ddl_leave.SelectedValue + "' and PolicyId='" + hdnpolicyid.Value + "'and calenderid='" + drpyear.SelectedValue + "'";
            j = SQLServer.ExecuteNonQuery(_connection, CommandType.Text, transaction, sqlstr);
            transaction.Commit();
        }
        catch (Exception ex)
        {
            if (transaction != null) transaction.Rollback();
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
        }
        if (i > 0 && j > 0)
        {
            Output.Show("Encashment Details are added successfully.");
            Reset();
        }
        else
        {
            Output.Show("Encashment Details are not added successfully.please contact Admin.");
        }
    }

    private void Reset()
    {
        txt_employee.Text = string.Empty;
        lslink.Visible = false;
        ddl_leave.Items.Clear();
        ddl_leave.SelectedValue = "0";
        drpyear.SelectedValue = "0";
        dd_month.SelectedValue = "0";
        lblCurBalance.Text = "0.0";
        lblEncashLimit.Text = "0.0";
        txtEncashDays.Text = "0.0";
        txtcomments.Text = string.Empty;


    }

    private bool ValidateEncashDays(string _encashDays, string _encashLimit)
    {
        if (Convert.ToDouble(_encashLimit) == 0.0)
        {
            Common.Console.Output.Show("Selected Employee Not Eligible for Leave Encashment.Please check Employee Leave Balance.");
            return false;
        }
        if (Convert.ToDouble(_encashDays) > Convert.ToDouble(_encashLimit))
        {
            Common.Console.Output.Show("Encashment days should be less than Encashment Limit.");
            return false;
        }
        return true;
    }


    protected void dd_month_DataBound(object sender, EventArgs e)
    {
        ddl_leave.Items.Insert(0, "--Select Month--");
    }
}
