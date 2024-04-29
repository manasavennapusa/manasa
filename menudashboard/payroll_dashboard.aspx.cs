using Common.Console;
using Common.Data;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menudashboard_payroll_dashboard : System.Web.UI.Page
{
    DataActivity activity = new DataActivity();
    SqlConnection connection = new SqlConnection();
    string companyid, usercode, roleid, rolename, image, gender;

    int Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec;
    int Jan1, Feb1, Mar1, Apr1, May1, Jun1, Jul1, Aug1, Sep1, Oct1, Nov1, Dec1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["role"] == null)
        {
            Response.Redirect("~/notlogged.aspx");
        }
        roleid = Session["role"].ToString();
        rolename = Session["rolename"].ToString();
        usercode = Session["empcode"].ToString();
        companyid = Session["companyid"].ToString();
        image = Session["PerEmpPhoto"].ToString();
        gender = Session["gender"].ToString();

        bind_Payroll_dashboard();

        if (!IsPostBack)
        {
            bind_EL_CLSL_ML_PL();
            bindpayrollsummary();
            bind_Payroll_Freeze_status();
        }
        string currentmonth = DateTime.Now.ToString("MM");
        if (currentmonth == "04")
        {
            tbl_1.Visible = true;
        }
        else if (currentmonth == "05")
        {
            tbl_2.Visible = true;
        }
        else if (currentmonth == "06")
        {
            tbl_3.Visible = true;
        }
        else if (currentmonth == "07")
        {
            tbl_4.Visible = true;
        }
        else if (currentmonth == "08")
        {
            tbl_5.Visible = true;
        }
        else if (currentmonth == "09")
        {
            tbl_6.Visible = true;
        }
        else if (currentmonth == "10")
        {
            tbl_7.Visible = true;
        }
        else if (currentmonth == "11")
        {
            tbl_8.Visible = true;
        }
        else if (currentmonth == "12")
        {
            tbl_9.Visible = true;
        }
        else if (currentmonth == "01")
        {
            tbl_10.Visible = true;
        }
        else if (currentmonth == "02")
        {
            tbl_11.Visible = true;
        }
        else if (currentmonth == "03")
        {
            tbl_12.Visible = true;
        }
        else
        {
            tbl_1.Visible = false;
            tbl_2.Visible = false;
            tbl_3.Visible = false;
            tbl_4.Visible = false;
            tbl_5.Visible = false;
            tbl_6.Visible = false;
            tbl_7.Visible = false;
            tbl_8.Visible = false;
            tbl_9.Visible = false;
            tbl_10.Visible = false;
            tbl_11.Visible = false;
            tbl_12.Visible = false;
        }
    }

    #region Binding of Earned Leave, Maternity Leave,Paternity Leave
    protected void bind_EL_CLSL_ML_PL()
    {
        string sqlstr_11 = @"select  jd.empcode,jd.emp_status,es.id,es.employeestatus  from tbl_intranet_employee_status es
inner join tbl_intranet_employee_jobDetails jd on jd.emp_status=es.id where jd.empcode='" + usercode + "'";
        DataSet ds_11 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_11);
        if (ds_11.Tables[0].Rows.Count > 0)
        {
            if (ds_11.Tables[0].Rows[0]["emp_status"] != "")
            {
                Session["employeestatus"] = ds_11.Tables[0].Rows[0]["emp_status"].ToString();
            }
        }

        DataSet ds = new DataSet();
        DataSet ds_1 = new DataSet();
        DataSet ds_2 = new DataSet();
        DataSet ds_3 = new DataSet();

        string sqlstr = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='EL'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr);
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_EL.Text = ds.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_EL.Text = "!!";
        }

        string sqlstr_1 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='PBL'";
        ds_1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_1);
        if (ds_1.Tables[0].Rows.Count > 0)
        {
            lbl_ProbL.Text = ds_1.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_ProbL.Text = "!!";
        }

        string sqlstr_2 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='ML'";
        ds_2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_2);
        if (ds_2.Tables[0].Rows.Count > 0)
        {
            lbl_ML.Text = ds_2.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_ML.Text = "!!";
        }

        string sqlstr_3 = @"SELECT distinct lm.id,lm.PolicyId,lm.leaveid, cl.leaveid,cl.leavetype,cl.displayleave,lm.empcode,lm.Entitled_days,lm.Used_days,
CAST((lm.Entitled_days - lm.Used_days) as float) AS balance,lm.status 
FROM tbl_leave_employee_leave_master lm 
inner join tbl_leave_createleave cl on lm.leaveid=cl.leaveid
where lm.status=1 and lm.empcode='" + usercode + "' and cl.displayleave='PL'";
        ds_3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_3);
        if (ds_3.Tables[0].Rows.Count > 0)
        {
            lbl_PL.Text = ds_3.Tables[0].Rows[0]["balance"].ToString();
        }
        else
        {
            lbl_PL.Text = "!!";
        }


        if (gender == "M")
        {
            row_PL_1.Visible = true;
            row_PL_2.Visible = true;
        }
        else if (gender == "F")
        {
            row_ML_1.Visible = true;
            row_ML_2.Visible = true;
        }
        else
        {
            row_PL_1.Visible = false;
            row_PL_2.Visible = false;
            row_ML_1.Visible = false;
            row_ML_2.Visible = false;
        }

        if (Session["employeestatus"].ToString() == "1")
        {
            row_ProbLev_1.Visible = true;
            row_ProbLev_2.Visible = true;
        }
        else
        {
            row_EarnedLev_1.Attributes.Add("class", "col-md-8 align-right");
            row_EarnedLev_1.Style.Add("text-align", "right");
            row_EarnedLev_2.Attributes.Add("class", "col-md-8");
            row_circle_EarnedLev_1.Style.Add("margin-left", "170px");
            lbl_earned_leave_name.Style.Add("margin-left", "130px");
        }

    }
    #endregion

    #region Binding of My Attendance & Payout Summary
    protected void bindpayrollsummary()
    {
        string query;
        var activity = new DataActivity();
        SqlConnection connection = activity.OpenConnection();
        try
        {
            query = @"select * from tbl_payroll_employee_salary where EMPCODE='" + usercode + "'";
            DataSet ds = SQLServer.ExecuteDataset(connection, CommandType.Text, query);

            string query1 = @"select * from tbl_payroll_employee_attendence where EMPCODE='" + usercode + "'";
            DataSet ds1 = SQLServer.ExecuteDataset(connection, CommandType.Text, query1);

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    if (dr["MONTH"].ToString() == "Jan")
                    {
                        Jan = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Jan = 0;
                    }
                    if (dr["MONTH"].ToString() == "Feb")
                    {
                        Feb = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Feb = 0;
                    }
                    if (dr["MONTH"].ToString() == "Mar")
                    {
                        Mar = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Mar = 0;
                    }

                    if (dr["MONTH"].ToString() == "Apr")
                    {
                        Apr = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Apr = 0;
                    }
                    if (dr["MONTH"].ToString() == "May")
                    {
                        May = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        May = 0;
                    }
                    if (dr["MONTH"].ToString() == "Jun")
                    {
                        Jun = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Jun = 0;
                    }
                    if (dr["MONTH"].ToString() == "Jul")
                    {
                        Jul = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Jul = 0;
                    }
                    if (dr["MONTH"].ToString() == "Aug")
                    {
                        Aug = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Aug = 0;
                    }
                    if (dr["MONTH"].ToString() == "Sep")
                    {
                        Sep = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Sep = 0;
                    }
                    if (dr["MONTH"].ToString() == "Oct")
                    {
                        Oct = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Oct = 0;
                    }
                    if (dr["MONTH"].ToString() == "Nov")
                    {
                        Nov = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Nov = 0;
                    }
                    if (dr["MONTH"].ToString() == "Dec")
                    {
                        Dec = Convert.ToInt32(dr["NTOTAL"]);
                    }
                    else
                    {
                        Dec = 0;
                    }


                    Session["jan"] = Jan;
                    Session["feb"] = Feb;
                    Session["mar"] = Mar;
                    Session["apr"] = Apr;
                    Session["may"] = May;
                    Session["jun"] = Jun;
                    Session["jul"] = Jul;
                    Session["Aug"] = Aug;
                    Session["Sep"] = Sep;
                    Session["Oct"] = Oct;
                    Session["Nov"] = Nov;
                    Session["Dec"] = Dec;

                }
            }
            else
            {
                int Jan = 0;
                int Feb = 0;
                int Mar = 0;
                int Apr = 0;
                int May = 0;
                int Jun = 0;
                int Jul = 0;
                int Aug = 0;
                int Sep = 0;
                int Oct = 0;
                int Nov = 0;
                int Dec = 0;

                Session["jan"] = Jan;
                Session["feb"] = Feb;
                Session["mar"] = Mar;
                Session["apr"] = Apr;
                Session["may"] = May;
                Session["jun"] = Jun;
                Session["jul"] = Jul;
                Session["Aug"] = Aug;
                Session["Sep"] = Sep;
                Session["Oct"] = Oct;
                Session["Nov"] = Nov;
                Session["Dec"] = Dec;
            }
            if (ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr1 in ds1.Tables[0].Rows)
                {
                    if (dr1["MONTH"].ToString() == "Jan")
                    {
                        Jan1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Jan1 = 0;
                    }

                    if (dr1["MONTH"].ToString() == "Feb")
                    {
                        Feb1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Feb1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Mar")
                    {
                        Mar1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Mar1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Apr")
                    {
                        Apr1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Apr1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "May")
                    {
                        May1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        May1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Jun")
                    {
                        Jun1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Jun1 = 0;
                    }

                    if (dr1["MONTH"].ToString() == "Jul")
                    {
                        Jul1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Jul1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Aug")
                    {
                        Aug1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Aug1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Sep")
                    {
                        Sep1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Sep1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Oct")
                    {
                        Oct1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Oct1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Nov")
                    {
                        Nov1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Nov1 = 0;
                    }
                    if (dr1["MONTH"].ToString() == "Dec")
                    {
                        Dec1 = Convert.ToInt32(dr1["WORKING_DAYS"]);
                    }
                    else
                    {
                        Dec1 = 0;
                    }

                    Session["jan1"] = Jan1;
                    Session["feb1"] = Feb1;
                    Session["mar1"] = Mar1;
                    Session["apr1"] = Apr1;
                    Session["may1"] = May1;
                    Session["jun1"] = Jun1;
                    Session["jul1"] = Jul1;
                    Session["Aug1"] = Aug1;
                    Session["Sep1"] = Sep1;
                    Session["Oct1"] = Oct1;
                    Session["Nov1"] = Nov1;
                    Session["Dec1"] = Dec1;
                }
            }
            else
            {
                int Jan1 = 0;
                int Feb1 = 0;
                int Mar1 = 0;
                int Apr1 = 0;
                int may1 = 0;
                int Jun1 = 0;
                int Jul1 = 0;
                int Aug1 = 0;
                int Sep1 = 0;
                int Oct1 = 0;
                int Nov1 = 0;
                int Dec1 = 0;

                Session["jan"] = Jan1;
                Session["feb"] = Feb1;
                Session["mar"] = Mar1;
                Session["apr"] = Apr1;
                Session["may"] = may1;
                Session["jun"] = Jun1;
                Session["jul"] = Jul1;
                Session["Aug"] = Aug1;
                Session["Sep"] = Sep1;
                Session["Oct"] = Oct1;
                Session["Nov"] = Nov1;
                Session["Dec"] = Dec1;
            }

        }
        catch (Exception ex)
        {
            Common.Console.Output.Log("Error occured in : Page :-  " + System.Web.HttpContext.Current.Request.Url.AbsolutePath.ToString() + " ,  function :-  " + System.Reflection.MethodBase.GetCurrentMethod().Name.ToString() + " , exception :-  " + ex.Message + ".    " + DateTime.Now);
            Response.Redirect("../Error.aspx");
        }
        finally
        {
            activity.CloseConnection();
        }

    }
    #endregion

    #region Binding of Payroll Freeze Status

    protected void bind_Payroll_Freeze_status()
    {
        DataSet ds = new DataSet();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_getpayrollfreezestatus_for_dashboard");
        if (ds.Tables[0].Rows.Count > 0)
        {
            lbl_month_1.Text = ds.Tables[0].Rows[0]["MONTH"].ToString();
            lbl_year_1.Text = ds.Tables[0].Rows[0]["YEAR"].ToString();
            lbl_status_1.Text = ds.Tables[0].Rows[0]["status"].ToString();
            if (ds.Tables[0].Rows[0]["status"].ToString() == "Freezed")
            {
                td_1.Style.Add("background-color", "#097c1d"); td_1_1.Style.Add("background-color", "#679358");
                td_1.Style.Add("border-radius", "7px 7px 0 0"); td_1_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[0].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_1.Style.Add("background-color", "#18a6aa"); td_1_1.Style.Add("background-color", "#417a8a");
                td_1.Style.Add("border-radius", "7px 7px 0 0"); td_1_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_1.Style.Add("background-color", "#808080"); td_1_1.Style.Add("background-color", "#9f9f9f");
                td_1.Style.Add("border-radius", "7px 7px 0 0"); td_1_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[0].Rows[0]["MONTH"].ToString();
            //Session["month"]=month.ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_1.Visible = true;
            //}
            //else
            //{
            //    tbl_1.Visible = false;
            //}
        }
        if (ds.Tables[1].Rows.Count > 0)
        {
            lbl_month_2.Text = ds.Tables[1].Rows[0]["MONTH"].ToString();
            lbl_year_2.Text = ds.Tables[1].Rows[0]["YEAR"].ToString();
            lbl_status_2.Text = ds.Tables[1].Rows[0]["status"].ToString();
            if (ds.Tables[1].Rows[0]["status"].ToString() == "Freezed")
            {
                td_2.Style.Add("background-color", "#097c1d"); td_2_1.Style.Add("background-color", "#679358");
                td_2.Style.Add("border-radius", "7px 7px 0 0"); td_2_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[1].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_2.Style.Add("background-color", "#18a6aa"); td_2_1.Style.Add("background-color", "#417a8a");
                td_2.Style.Add("border-radius", "7px 7px 0 0"); td_2_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_2.Style.Add("background-color", "#808080"); td_2_1.Style.Add("background-color", "#9f9f9f");
                td_2.Style.Add("border-radius", "7px 7px 0 0"); td_2_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[1].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_2.Visible = true;
            //}
            //else
            //{
            //    tbl_2.Visible = false;
            //}
        }
        if (ds.Tables[2].Rows.Count > 0)
        {
            lbl_month_3.Text = ds.Tables[2].Rows[0]["MONTH"].ToString();
            lbl_year_3.Text = ds.Tables[2].Rows[0]["YEAR"].ToString();
            lbl_status_3.Text = ds.Tables[2].Rows[0]["status"].ToString();
            if (ds.Tables[2].Rows[0]["status"].ToString() == "Freezed")
            {
                td_3.Style.Add("background-color", "#097c1d"); td_3_1.Style.Add("background-color", "#679358");
                td_3.Style.Add("border-radius", "7px 7px 0 0"); td_3_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[2].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_3.Style.Add("background-color", "#18a6aa"); td_3_1.Style.Add("background-color", "#417a8a");
                td_3.Style.Add("border-radius", "7px 7px 0 0"); td_3_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_3.Style.Add("background-color", "#808080"); td_3_1.Style.Add("background-color", "#9f9f9f");
                td_3.Style.Add("border-radius", "7px 7px 0 0"); td_3_1.Style.Add("border-radius", "0 0 7px 7px");
            }


            //string month = ds.Tables[2].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_3.Visible = true;
            //}
            //else
            //{
            //    tbl_3.Visible = false;
            //}
        }
        if (ds.Tables[3].Rows.Count > 0)
        {
            lbl_month_4.Text = ds.Tables[3].Rows[0]["MONTH"].ToString();
            lbl_year_4.Text = ds.Tables[3].Rows[0]["YEAR"].ToString();
            lbl_status_4.Text = ds.Tables[3].Rows[0]["status"].ToString();
            if (ds.Tables[3].Rows[0]["status"].ToString() == "Freezed")
            {
                td_4.Style.Add("background-color", "#097c1d"); td_4_1.Style.Add("background-color", "#679358");
                td_4.Style.Add("border-radius", "7px 7px 0 0"); td_4_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[3].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_4.Style.Add("background-color", "#18a6aa"); td_4_1.Style.Add("background-color", "#417a8a");
                td_4.Style.Add("border-radius", "7px 7px 0 0"); td_4_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_4.Style.Add("background-color", "#808080"); td_4_1.Style.Add("background-color", "#9f9f9f");
                td_4.Style.Add("border-radius", "7px 7px 0 0"); td_4_1.Style.Add("border-radius", "0 0 7px 7px");
            }


            //string month = ds.Tables[3].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_4.Visible = true;
            //}
            //else
            //{
            //    tbl_4.Visible = false;
            //}
        }
        if (ds.Tables[4].Rows.Count > 0)
        {
            lbl_month_5.Text = ds.Tables[4].Rows[0]["MONTH"].ToString();
            lbl_year_5.Text = ds.Tables[4].Rows[0]["YEAR"].ToString();
            lbl_status_5.Text = ds.Tables[4].Rows[0]["status"].ToString();
            if (ds.Tables[4].Rows[0]["status"].ToString() == "Freezed")
            {
                td_5.Style.Add("background-color", "#097c1d"); td_5_1.Style.Add("background-color", "#679358");
                td_5.Style.Add("border-radius", "7px 7px 0 0"); td_5_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[4].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_5.Style.Add("background-color", "#18a6aa"); td_5_1.Style.Add("background-color", "#417a8a");
                td_5.Style.Add("border-radius", "7px 7px 0 0"); td_5_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_5.Style.Add("background-color", "#808080"); td_5_1.Style.Add("background-color", "#9f9f9f");
                td_5.Style.Add("border-radius", "7px 7px 0 0"); td_5_1.Style.Add("border-radius", "0 0 7px 7px");
            }


            //string month = ds.Tables[4].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_5.Visible = true;
            //}
            //else
            //{
            //    tbl_5.Visible = false;
            //}
        }
        if (ds.Tables[5].Rows.Count > 0)
        {
            lbl_month_6.Text = ds.Tables[5].Rows[0]["MONTH"].ToString();
            lbl_year_6.Text = ds.Tables[5].Rows[0]["YEAR"].ToString();
            lbl_status_6.Text = ds.Tables[5].Rows[0]["status"].ToString();
            if (ds.Tables[5].Rows[0]["status"].ToString() == "Freezed")
            {
                td_6.Style.Add("background-color", "#097c1d"); td_6_1.Style.Add("background-color", "#679358");
                td_6.Style.Add("border-radius", "7px 7px 0 0"); td_6_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[5].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_6.Style.Add("background-color", "#18a6aa"); td_6_1.Style.Add("background-color", "#417a8a");
                td_6.Style.Add("border-radius", "7px 7px 0 0"); td_6_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_6.Style.Add("background-color", "#808080"); td_6_1.Style.Add("background-color", "#9f9f9f");
                td_6.Style.Add("border-radius", "7px 7px 0 0"); td_6_1.Style.Add("border-radius", "0 0 7px 7px");
            }


            //string month = ds.Tables[5].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_6.Visible = true;
            //}
            //else
            //{
            //    tbl_6.Visible = false;
            //}
        }
        if (ds.Tables[6].Rows.Count > 0)
        {
            lbl_month_7.Text = ds.Tables[6].Rows[0]["MONTH"].ToString();
            lbl_year_7.Text = ds.Tables[6].Rows[0]["YEAR"].ToString();
            lbl_status_7.Text = ds.Tables[6].Rows[0]["status"].ToString();
            if (ds.Tables[6].Rows[0]["status"].ToString() == "Freezed")
            {
                td_7.Style.Add("background-color", "#097c1d"); td_7_1.Style.Add("background-color", "#679358");
                td_7.Style.Add("border-radius", "7px 7px 0 0"); td_7_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[6].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_7.Style.Add("background-color", "#18a6aa"); td_7_1.Style.Add("background-color", "#417a8a");
                td_7.Style.Add("border-radius", "7px 7px 0 0"); td_7_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_7.Style.Add("background-color", "#808080"); td_7_1.Style.Add("background-color", "#9f9f9f");
                td_7.Style.Add("border-radius", "7px 7px 0 0"); td_7_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[6].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_7.Visible = true;
            //}
            //else
            //{
            //    tbl_7.Visible = false;
            //}
        }
        if (ds.Tables[7].Rows.Count > 0)
        {
            lbl_month_8.Text = ds.Tables[7].Rows[0]["MONTH"].ToString();
            lbl_year_8.Text = ds.Tables[7].Rows[0]["YEAR"].ToString();
            lbl_status_8.Text = ds.Tables[7].Rows[0]["status"].ToString();
            if (ds.Tables[7].Rows[0]["status"].ToString() == "Freezed")
            {
                td_8.Style.Add("background-color", "#097c1d"); td_8_1.Style.Add("background-color", "#679358");
                td_8.Style.Add("border-radius", "7px 7px 0 0"); td_8_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[7].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_8.Style.Add("background-color", "#18a6aa"); td_8_1.Style.Add("background-color", "#417a8a");
                td_8.Style.Add("border-radius", "7px 7px 0 0"); td_8_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_8.Style.Add("background-color", "#808080"); td_8_1.Style.Add("background-color", "#9f9f9f");
                td_8.Style.Add("border-radius", "7px 7px 0 0"); td_8_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[7].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_8.Visible = true;
            //}
            //else
            //{
            //    tbl_8.Visible = false;
            //}
        }
        if (ds.Tables[8].Rows.Count > 0)
        {
            lbl_month_9.Text = ds.Tables[8].Rows[0]["MONTH"].ToString();
            lbl_year_9.Text = ds.Tables[8].Rows[0]["YEAR"].ToString();
            lbl_status_9.Text = ds.Tables[8].Rows[0]["status"].ToString();
            if (ds.Tables[8].Rows[0]["status"].ToString() == "Freezed")
            {
                td_9.Style.Add("background-color", "#097c1d"); td_9_1.Style.Add("background-color", "#679358");
                td_9.Style.Add("border-radius", "7px 7px 0 0"); td_9_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[8].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_9.Style.Add("background-color", "#18a6aa"); td_9_1.Style.Add("background-color", "#417a8a");
                td_9.Style.Add("border-radius", "7px 7px 0 0"); td_9_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_9.Style.Add("background-color", "#808080"); td_9_1.Style.Add("background-color", "#9f9f9f");
                td_9.Style.Add("border-radius", "7px 7px 0 0"); td_9_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[8].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_9.Visible = true;
            //}
            //else
            //{
            //    tbl_9.Visible = false;
            //}
        }
        if (ds.Tables[9].Rows.Count > 0)
        {
            lbl_month_10.Text = ds.Tables[9].Rows[0]["MONTH"].ToString();
            lbl_year_10.Text = ds.Tables[9].Rows[0]["YEAR"].ToString();
            lbl_status_10.Text = ds.Tables[9].Rows[0]["status"].ToString();
            if (ds.Tables[9].Rows[0]["status"].ToString() == "Freezed")
            {
                td_10.Style.Add("background-color", "#097c1d"); td_10_1.Style.Add("background-color", "#679358");
                td_10.Style.Add("border-radius", "7px 7px 0 0"); td_10_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[9].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_10.Style.Add("background-color", "#18a6aa"); td_10_1.Style.Add("background-color", "#417a8a");
                td_10.Style.Add("border-radius", "7px 7px 0 0"); td_10_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_10.Style.Add("background-color", "#808080"); td_10_1.Style.Add("background-color", "#9f9f9f");
                td_10.Style.Add("border-radius", "7px 7px 0 0"); td_10_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[9].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_10.Visible = true;
            //}
            //else
            //{
            //    tbl_10.Visible = false;
            //}
        }
        if (ds.Tables[10].Rows.Count > 0)
        {
            lbl_month_11.Text = ds.Tables[10].Rows[0]["MONTH"].ToString();
            lbl_year_11.Text = ds.Tables[10].Rows[0]["YEAR"].ToString();
            lbl_status_11.Text = ds.Tables[10].Rows[0]["status"].ToString();
            if (ds.Tables[10].Rows[0]["status"].ToString() == "Freezed")
            {
                td_11.Style.Add("background-color", "#097c1d"); td_11_1.Style.Add("background-color", "#679358");
                td_11.Style.Add("border-radius", "7px 7px 0 0"); td_11_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[10].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_11.Style.Add("background-color", "#18a6aa"); td_11_1.Style.Add("background-color", "#417a8a");
                td_11.Style.Add("border-radius", "7px 7px 0 0"); td_11_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_11.Style.Add("background-color", "#808080"); td_11_1.Style.Add("background-color", "#9f9f9f");
                td_11.Style.Add("border-radius", "7px 7px 0 0"); td_11_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[10].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_11.Visible = true;
            //}
            //else
            //{
            //    tbl_11.Visible = false;
            //}
        }
        if (ds.Tables[11].Rows.Count > 0)
        {
            lbl_month_12.Text = ds.Tables[11].Rows[0]["MONTH"].ToString();
            lbl_year_12.Text = ds.Tables[11].Rows[0]["YEAR"].ToString();
            lbl_status_12.Text = ds.Tables[11].Rows[0]["status"].ToString();
            if (ds.Tables[11].Rows[0]["status"].ToString() == "Freezed")
            {
                td_12.Style.Add("background-color", "#097c1d"); td_12_1.Style.Add("background-color", "#679358");
                td_12.Style.Add("border-radius", "7px 7px 0 0"); td_12_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else if (ds.Tables[11].Rows[0]["status"].ToString() == "UnFreezed")
            {
                td_12.Style.Add("background-color", "#18a6aa"); td_12_1.Style.Add("background-color", "#417a8a");
                td_12.Style.Add("border-radius", "7px 7px 0 0"); td_12_1.Style.Add("border-radius", "0 0 7px 7px");
            }
            else
            {
                td_12.Style.Add("background-color", "#808080"); td_12_1.Style.Add("background-color", "#9f9f9f");
                td_12.Style.Add("border-radius", "7px 7px 0 0"); td_12_1.Style.Add("border-radius", "0 0 7px 7px");
            }

            //string month = ds.Tables[11].Rows[0]["MONTH"].ToString();
            //string currentmonth = Convert.ToDateTime(System.DateTime.Now).ToString("MMM");
            //if (month == currentmonth)
            //{
            //    tbl_12.Visible = true;
            //}
            //else
            //{
            //    tbl_12.Visible = false;
            //}
        }
    }

    #endregion

    #region Binding of Number Of Employee Status Per Department

    [WebMethod]
    public static List<object> NoOfEmpChart()
    {

        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "department_name","TotalEmployee"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand("Sp_DeptWiseHeadCountForDashBoard"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                         sdr["department_name"],sdr["TotalEmployee"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Salary Range Breakdown

    [WebMethod]
    public static List<object> SalaryRangeBreakDownChart()
    {
        string query = @"select bb.Range[Ranges],count(bb.Range)[Employees] from (select
case when SUM(aa.total) BETWEEN 10000 AND 20000 then '10k-20k' when SUM(aa.total) BETWEEN 20000 AND 30000 then '20k-30k'
when SUM(aa.total) BETWEEN 30000 AND 40000 then '30k-40k' when SUM(aa.total) BETWEEN 40000 AND 50000 then '40k-50k'
when SUM(aa.total) BETWEEN 50000 AND 60000 then '50k-60k' when SUM(aa.total) BETWEEN 60000 AND 70000 then '60k-70k'
when SUM(aa.total) BETWEEN 70000 AND 80000 then '70k-80k' when SUM(aa.total) BETWEEN 80000 AND 90000 then '80k-90k'
when SUM(aa.total) BETWEEN 90000 AND 100000 then '90k-100k' else 'Above 100k' end
[Range],
SUM(aa.total)[Total]
 from 
(
select pep.EMPCODE,SUM(pepd.amount) as total from tbl_payroll_employee_paystructure_detail pepd
inner join tbl_payroll_employee_paystructure pep on pep.ID=pepd.paystructure_id 
group by pep.EMPCODE,pepd.amount
) aa 
group by aa.empcode)as bb group by bb.Range order by Range desc";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Ranges", "Employees"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["Ranges"], sdr["Employees"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Average Salary By Department

    [WebMethod]
    public static List<object> AvgSalByDeptChart()
    {
        string query = @"select dept.department_name[Department],AVG(Cast(emp_pay_dtls.amount as integer)) as AvgAmount
from tbl_payroll_employee_paystructure emp_pay
inner join tbl_intranet_employee_jobDetails jd on emp_pay.EMPCODE=jd.empcode
inner join tbl_internate_departmentdetails dept on jd.dept_id=dept.departmentid
inner join tbl_payroll_employee_paystructure_detail emp_pay_dtls  on emp_pay.ID=emp_pay_dtls.paystructure_id
group by dept.department_name";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Department", "AvgAmount"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["Department"], sdr["AvgAmount"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Salary BreakDown By Department

    [WebMethod]
    public static List<object> SalBreakDownByDeptChart()
    {
        string query = @"select aa.department_name[Department],SUM(aa.amount1)[TotalSalary] from
(
select payhead.id[PayHead_Id],payhead.alias_name[PayHead_Name],dept.departmentid,dept.department_name,SUM(emp_pay_dtls.amount)[amount1] 
from tbl_payroll_employee_paystructure emp_pay
inner join tbl_payroll_employee_paystructure_detail emp_pay_dtls  on emp_pay.ID=emp_pay_dtls.paystructure_id
inner join tbl_payroll_payhead payhead on emp_pay_dtls.payhead=payhead.id
inner join tbl_intranet_employee_jobDetails jd on emp_pay.EMPCODE=jd.empcode
inner join tbl_internate_departmentdetails dept on jd.dept_id=dept.departmentid
group by payhead.id,payhead.alias_name,dept.departmentid,dept.department_name
) aa
group by aa.department_name";
        string constr = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        List<object> chartData = new List<object>();
        chartData.Add(new object[]
    {
        "Department", "TotalSalary"
    });
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        chartData.Add(new object[]
                    {
                        sdr["Department"], sdr["TotalSalary"]
                    });
                    }
                }
                con.Close();
                return chartData;
            }
        }
    }

    #endregion

    #region Binding of Payroll Dashboard

    protected void bind_Payroll_dashboard()
    {
        string sqlstr_10 = @"select financial_year from tbl_payroll_tax_master order by id desc";
        DataSet ds_10 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_10);
        string financial_year = ds_10.Tables[0].Rows[0]["financial_year"].ToString();

        string sqlstr_11 = @"select distinct MONTH,YEAR,b.branch_name,s.branch_id,case when s.flag=1 then 'Unfreezed' else 'Freezed' end as status ,
s.flag from tbl_payroll_employee_salary s
inner join dbo.tbl_intranet_branch_detail b 
on b.branch_id = s.branch_id where YEAR='" + financial_year + "' and s.flag=0";
        DataSet ds_11 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString(), CommandType.Text, sqlstr_11);
        if (ds_11.Tables[0].Rows.Count > 0)
        {
            if (roleid == "13")
            {
                row_payout_summary.Visible = true;
            }
            else if (roleid == "1")
            {
                row_payout_summary.Visible = true;
            }
            else
            {
                row_No_Of_Emp_SalaryRange.Visible = true;
                row_Avg_Sal_Sal_BreakDown.Visible = true;
                row_freeze_status.Visible = true;
            }
        }
        else 
        {
            Output.Show("Payroll for the partcular month has not been freezed");
        }

    }

    #endregion

}