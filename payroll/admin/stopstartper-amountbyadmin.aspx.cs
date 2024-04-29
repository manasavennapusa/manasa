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
using DataAccessLayer;
using System.Data.SqlClient;
using Common.Data;
using Common.Console;


public partial class payroll_admin_stopstartper_amountbyadmin : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    SqlTransaction transaction = null;
    string sqlstr, _userCode, _companyId, RoleId;
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        bind_fyear();
        if (Session["role"] != null)
        {
            //if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
            //  Response.Redirect("~/Authenticate.aspx");
        }
        else Response.Redirect("~/notlogged.aspx");
        message.InnerHtml = "";
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

        //if (Convert.ToInt16(dt.Day) > 30)
        //    dt = dt.AddMonths(1);

        //if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
        //{
        //    lbl.Text = dt.Year + "-" + dt.AddYears(1).Year;
        //    lbl_fyear.DataSource = Enumerable.Range(1990, DateTime.Now.Year);
        //    lbl_fyear.DataBind();
        //}
        //else
        //    lbl.Text = dt.AddYears(-1).Year + "-" + dt.Year;
        //    lbl_fyear.DataSource = Enumerable.Range(2000, DateTime.Now.Year);
        //    lbl_fyear.DataBind();
    }
    protected void btnsbmit_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"update tbl_payroll_employee_perquisite set flag = 1 where empcode ='" + txt_employee.Text + "' and fyear='" + lbl_fyear.Text + "'";
            SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            lbl_message.Text = "Employee Perquisite amount is Stop";
            txt_employee.Text="";
           // lbl_fyear.SelectedValue="0";
        }
    }
    protected void btn_start_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            string sqlstr = @"update tbl_payroll_employee_perquisite set flag = 0 where empcode ='" + txt_employee.Text + "' and fyear='" + lbl_fyear.Text + "'";
            SQLServer.ExecuteScalar(connection, CommandType.Text, sqlstr);
            //if (ds.Tables[0].Rows.Count < 1)
            //    return;

        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            lbl_message.Text = "Employee Perquisite amount is Start";
            txt_employee.Text = "";
            //lbl_fyear.Text = "";
        }
    }
}