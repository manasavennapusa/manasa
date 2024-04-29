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
using System.IO;
using System.Data.OleDb;
using System.Linq;
using Common.Console;
using Common.Data;
public partial class payroll_admin_holdandrelesesalary : System.Web.UI.Page
{
    string sqlstr;
    DataSet ds = new DataSet();
    string _userCode, _companyId, RoleId;
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        _userCode = Session["empcode"].ToString();
        _companyId = Session["companyid"].ToString();
        lbl_message.Text = "";
        if (!IsPostBack)
        {
           
            //bind_fyear();
            if (Session["role"] != null)
            {
                binddetail();
                bind_month();
            }
            else Response.Redirect("~/notlogged.aspx");
            //current_month(); //22Sep2010
        }
    }



    protected void bind_fyear()
    {

        //int year = DateTime.Now.Year, count = 1;
        //lbl_fyear.Items.Insert(0, new ListItem("---select---"));

        //for (int i = year-1; i < year + 5; i++)
        //{
        //    lbl_fyear.Items.Insert(count, new ListItem(i.ToString() + "-" + (i + 1).ToString()));
        //    count++;
        //}
        DateTime dt = DateTime.Now;

        if (Convert.ToInt16(dt.Day) >= 30)
            dt = dt.AddMonths(1);

        if (Convert.ToInt32(dd_month.SelectedValue) >= 4)
            lbl_fyear.Text = dt.Year + "-" + dt.AddYears(1).Year;
        else
            lbl_fyear.Text = dt.AddYears(-1).Year + "-" + dt.Year;
    }

    protected void btn_procs_att_Click(object sender, EventArgs e)
    {
        try
        {
            connection = activity.OpenConnection();
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[5];

            sqlparam[0] = new SqlParameter("@loan_id", SqlDbType.Int);
            sqlparam[0].Value = Request.QueryString["loan_id"];

            sqlparam[1] = new SqlParameter("@remarks", SqlDbType.VarChar,1000);
            sqlparam[1].Value = txt_remarks.Text;

            sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
            sqlparam[2].Value = lbl_fyear.Text.Trim().ToString();

            sqlparam[3] = new SqlParameter("@months", SqlDbType.VarChar, 50);
            sqlparam[3].Value = dd_month.SelectedItem.Text;

            sqlparam[4] = new SqlParameter("@cretaed_by", SqlDbType.VarChar,50);
            sqlparam[4].Value = _userCode;

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_payroll_hold_load", sqlparam);
            insert_newloan();
        }
        catch (Exception ex)
        {
            Output.Log("During validation: " + ex.Message + ".    " + DateTime.Now);
            Output.Show("Record not saved. Please contact system admin. For error details please go through the log file.");
        }
        finally
        {
            activity.CloseConnection();
            //Output.Show("Salay on Hold for empcode '"+txt_employee.Text+"'");
            lbl_message.Text =  "Salay on Hold for empcode '" + txt_employee.Text + "'";
            reset();
        }
        
    }

    protected void binddetail()
    {
        SqlParameter[] sqlparam = new SqlParameter[1];

        sqlparam[0] = new SqlParameter("@loan_id", SqlDbType.Int);
        sqlparam[0].Value = Request.QueryString["loan_id"].ToString();

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_payroll_viewapplyloanhold", sqlparam);

        txt_employee.Text = ds.Tables[0].Rows[0]["empcode"].ToString();
        lbl_fyear.Text = ds.Tables[0].Rows[0]["fyear"].ToString();

    }

    protected void bind_month()
    {
        string sqlstr = "select month from tbl_payroll_employee_loandetail where status =1 and hold_loan=0 and loan_id = '" + Request.QueryString["loan_id"].ToString() + "'";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        dd_month.DataTextField = "month";
        dd_month.DataValueField = "month";
        dd_month.DataSource = ds3;
        dd_month.DataBind();
        dd_month.Items.Insert(0, new ListItem("--Select--", "0"));

    }

    protected void empgrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }

    protected void reset()
    {
        //txt_employee.Text = "";
        txt_remarks.Text = "";
        dd_month.SelectedValue = "0";
    }
    protected void dd_month_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_fyear();
    }


    protected void insert_newloan()
    {
        string sqlstr = "select top(1) MONTH,year from tbl_payroll_employee_loandetail where loan_id = '" + Request.QueryString["loan_id"].ToString() + "' order by id desc";
        DataSet ds3 = new DataSet();
        ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);

        string new_month ="";
        int new_year;
        new_year = Convert.ToInt32(ds3.Tables[0].Rows[0]["year"]);

        for (int i = 0; i < ds3.Tables[0].Rows.Count; i++)
        {
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Jan")
            {
                new_month = "Feb";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Feb")
            {
                new_month = "Mar";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Mar")
            {
                new_month = "Apr";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Apr")
            {
                new_month = "May";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "May")
            {
                new_month = "Jun";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Jun")
            {
                new_month = "Jul";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Jul")
            {
                new_month = "Aug";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Aug")
            {
                new_month = "Sep";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Sep")
            {
                new_month = "Oct";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Oct")
            {
                new_month = "Nov";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Nov")
            {
                new_month = "Dec";
            }
            if (ds3.Tables[0].Rows[0]["MONTH"].ToString() == "Dec")
            {
                new_month = "Jan";
                new_year = Convert.ToInt32(ds3.Tables[0].Rows[0]["year"]) + 1;
            }

            connection = activity.OpenConnection();
            SqlParameter[] sqlparam;
            sqlparam = new SqlParameter[4];

            sqlparam[0] = new SqlParameter("@loan_id", SqlDbType.VarChar, 50);
            sqlparam[0].Value = Request.QueryString["loan_id"].ToString();

            sqlparam[1] = new SqlParameter("@months", SqlDbType.VarChar, 50);
            sqlparam[1].Value = new_month;

            sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
            sqlparam[2].Value = new_year;

            sqlparam[3] = new SqlParameter("@last_month", SqlDbType.VarChar, 50);
            sqlparam[3].Value = ds3.Tables[0].Rows[0]["MONTH"].ToString();

            ds = SQLServer.ExecuteDataset(connection, CommandType.StoredProcedure, "sp_payroll_loan_update", sqlparam);
        }

    }
}