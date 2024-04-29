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

public partial class payroll_admin_fullnfinalreport : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    DataSet dsEarnings = new DataSet();
    DataSet dsOtherEarningDeduction = new DataSet();
    SqlDataAdapter da = new SqlDataAdapter();
    string connStr = string.Empty;
    string fyear = "2018-2019";
    decimal totalEarning = 0;
    decimal totalDeduction = 0;
    decimal A = 0;
    decimal B = 0;
    decimal C = 0;

    int flag = 0;
    string month = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        connStr = ConfigurationManager.ConnectionStrings["intranetConnectionString"].ConnectionString.ToString();
        if (Request.QueryString.HasKeys())
        {
            BindEmpBasicDetails();
            BindTotalEarnings();
            BindFinalEarningDeduction();
        }
    }
    protected void BindFinalEarningDeduction()
    {
        A = totalEarning;
        lbltotalFinalEarnings.Text = A.ToString();

        B = totalDeduction;
        lbltotalFinalDeduction.Text = B.ToString();
        C = A - B;
        lblFinalDues.Text = C.ToString();
        lblFinalTMsg.Text = C.ToString();
    }

    protected void BindEmpBasicDetails()
    {
        //lblEmpCode.Text = Request.QueryString["empcode"].ToString();
        lbl_sdate.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        //lblTotalDays.Text = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month).ToString();
        //lblWorkedDays.Text = DateTime.Now.ToString("dd");
        string empcode = Request.QueryString["empcode"].ToString();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_select_employee_basic_details", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@empcode", Request.QueryString["empcode"].ToString());
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(ds);
                lblemployee.Text = ds.Tables[0].Rows[0]["empname"].ToString();
                lbl_doj.Text = ds.Tables[0].Rows[0]["doj"].ToString();
                lbl_ac.Text = ds.Tables[0].Rows[0]["ac_number"].ToString();
                lbl_bank.Text = ds.Tables[0].Rows[0]["bank_name"].ToString();
                lbl_desg.Text = ds.Tables[0].Rows[0]["designationname"].ToString();
                lbl_branch.Text = ds.Tables[0].Rows[0]["branch_name"].ToString();
                if (ds.Tables[1].Rows[0]["lwp"].ToString() == "")
                {
                    lbl_lwp.Text = "";
                }
                else
                {
                    lbl_lwp.Text = ds.Tables[1].Rows[0]["lwp"].ToString();
                }
                lbl_lastwdays.Text = ds.Tables[0].Rows[0]["sattlement_date"].ToString();
                lblmonth.Text = Request.QueryString["month"].ToString();
                //Company Name
               // lblCompanyName.Text = ds.Tables[1].Rows[0]["companyname"].ToString();//Company Name

                //LWP,Working Days
                if (ds.Tables[1].Rows.Count < 0)
                    return;
                //lbl_lastwdays.Text = ds.Tables[1].Rows[0]["working_days"].ToString();
                lbl_totaldays.Text = ds.Tables[1].Rows[0]["working_days"].ToString();
            }
        }
    }
    protected void BindTotalEarnings()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_select_full_and_fianl_sattlement", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("@empcode", Request.QueryString["empcode"].ToString());
            cmd.Parameters.AddWithValue("@fyear", Request.QueryString["year"].ToString());
            cmd.Parameters.AddWithValue("@month", Request.QueryString["month"].ToString());
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                da.Fill(dsEarnings);
                if (dsEarnings.Tables[0].Rows.Count > 0)
                {
                    if (dsEarnings.Tables[2].Rows.Count > 0)
                    {
                        if (dsEarnings.Tables[2].Rows[0]["amount"].ToString() == null || dsEarnings.Tables[2].Rows[0]["amount"].ToString() == "")
                        {
                            lbl_calg.Text = "0";
                        }
                        else
                        {
                            lbl_calg.Text = dsEarnings.Tables[2].Rows[0]["amount"].ToString();
                        }
                    }
                    else
                    {
                        lbl_calg.Text = "0";
                    }
                    grdItComputation.DataSource = dsEarnings;
                    grdItComputation.DataBind();
                    if (dsEarnings.Tables[1].Rows.Count > 0)
                    {
                        grdItComputation1.DataSource = dsEarnings.Tables[1];
                        grdItComputation1.DataBind();
                    }
                    else
                    {
                        grdItComputation1.DataSource = dsEarnings.Tables[1];
                        grdItComputation1.DataBind();
                    }
                }
                else
                {
                    grdItComputation.DataSource = dsEarnings;
                    grdItComputation.DataBind();
                }
            }
        }
    }

    protected void tbn_submit_Click(object sender, EventArgs e)
    {

    }
    protected void grdItComputation_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label payheadId = (Label)e.Row.FindControl("lblPayheadid");
            Label payhead = (Label)e.Row.FindControl("lblPayhead");
            Label amount = (Label)e.Row.FindControl("lblAmountE");

            //Apr.ToolTip = "Apr";
            //amount.Text = GetAmount(amount, payheadId.Text.Trim(), payhead.Text.Trim());
            totalEarning = totalEarning + Convert.ToDecimal(amount.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FinalTotal = (Label)e.Row.FindControl("totalE");
            FinalTotal.Text = totalEarning.ToString();
        }
    }
    protected void grdItComputation1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label payheadId = (Label)e.Row.FindControl("lblPayheadid");
            Label payhead = (Label)e.Row.FindControl("lblPayhead");
            Label amount = (Label)e.Row.FindControl("lblAmountD");

            //Apr.ToolTip = "Apr";
            //amount.Text = GetAmount(amount, payheadId.Text.Trim(), payhead.Text.Trim());
            totalDeduction = totalDeduction + Convert.ToDecimal(amount.Text.Trim());
        }

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            Label FinalTotal = (Label)e.Row.FindControl("totalD");
            FinalTotal.Text = totalDeduction.ToString();
        }
    }

    protected string GetAmount(Label amount, string payheadid, string payhead)
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("usp_get_total_amount", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empcode", Request.QueryString["empcode"].ToString());
            //cmd.Parameters.AddWithValue("@fyear", fyear);
            cmd.Parameters.AddWithValue("@payheadid", payheadid);
            cmd.Parameters.AddWithValue("@payhead", payhead);

            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    amount.Text = cmd.ExecuteScalar().ToString();

                    if (flag == 0)
                    {
                        DataSet ds = new DataSet();
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            month = month + ds.Tables[1].Rows[i]["month"].ToString() + ",";
                        }
                       // lblMonths.Text = month.TrimEnd(',');
                        flag = 2;
                    }
                }
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    throw new Exception(ex.Message);
                }
            } return amount.Text;

        }
    }
}