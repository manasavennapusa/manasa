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
using NumberToEnglish;
using System.Globalization;

public partial class payroll_admin_payslip_for_contract : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string strempcode, strmonth, stryear, strmonthn;
    DateTime a;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["role"] != null)
            {
                if (Session["role"].ToString() != "1" && Session["role"].ToString() != "2" && Session["role"].ToString() != "3")
                    Response.Redirect("~/Authenticate.aspx");
            }
            else Response.Redirect("~/notlogged.aspx");
        }
        query q = new query();
        strempcode = (q["empcode"] != null) ? q["empcode"] : "0";
        strmonth = (q["month"] != null) ? q["month"] : "0";
        stryear = (q["year"] != null) ? q["year"] : "0";
        bind_employee_salary_detail();
        bind_earnings();
        bind_deduction();
        bind_reimbursement();
        bind_total();
    }

    private string GetMonthNumberFromAbbreviation(string mmm)
    {
        string[] monthAbbrev =
           CultureInfo.CurrentCulture.DateTimeFormat.AbbreviatedMonthNames;
        int index = Array.IndexOf(monthAbbrev, mmm) + 1;
        return index.ToString("0#");
    }
    protected void bind_employee_salary_detail()
    {
        // a = new DateTime(1900,Convert.ToInt16(strmonth.ToString()), 1);
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = strempcode.ToString();
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = a.ToString("MMM");
        sqlparam[1].Value = strmonth.ToString();

        sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[2].Value = stryear.ToString();
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "generate_payslip", sqlparam);
        //lbl_companyname.Text = ds.Tables[0].Rows[0]["companyname"].ToString();

        //----Added by Anuj on 3-June-14 for convert month to specific salary cycle period.

        //lbl_month.Text = strmonth.ToString(); //Commented by Anuj on 3-June-14 
        int i = DateTime.ParseExact(strmonth, "MMM", CultureInfo.CurrentCulture).Month;
        int pMonth = 0;
        if (i == 1)
            pMonth = 12;
        else
            pMonth = i - 1;
        string strPreviousMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pMonth);
        string strCurrentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

        //lbl_month.Text = 26 + " " + strPreviousMonth + " to " + 25 + " " + strCurrentMonth;
        lbl_month.Text = strCurrentMonth;
        //----EOC by Anuj on 3-June-14 for convert month to specific salary cycle period.

        lbl_empname.Text = ds.Tables[1].Rows[0]["name"].ToString();
        lbl_branch.Text = ds.Tables[1].Rows[0]["branch_name"].ToString();
        lbl_dept.Text = ds.Tables[1].Rows[0]["department_name"].ToString();
        lbl_desg.Text = ds.Tables[1].Rows[0]["designationname"].ToString();
        lbl_empcode.Text = ds.Tables[1].Rows[0]["empcode"].ToString();
        // lblgrade.Text = ds.Tables[1].Rows[0]["gradename"].ToString();
        lbldoj.Text = ds.Tables[1].Rows[0]["emp_doj"].ToString();
        lblacno.Text = ds.Tables[1].Rows[0]["ac_number"].ToString();
        //lblpaymentmode.Text = ds.Tables[1].Rows[0]["paymentmode"].ToString();
        //lbl_bank_details.Text = ds.Tables[1].Rows[0]["bank_name"].ToString();
        if (ds.Tables[1].Rows[0]["ac_number"].ToString() == "")
        {
            lblacno.Text = "N/A";
        }
        else
        {
            lblacno.Text = ds.Tables[1].Rows[0]["ac_number"].ToString();
        }
        if (ds.Tables[1].Rows[0]["uan"].ToString() == "")
        {
            lbl_uan.Text = "N/A";
        }
        else
        {
            lbl_uan.Text = ds.Tables[1].Rows[0]["uan"].ToString();
        }
        if (ds.Tables[1].Rows[0]["bank_name"].ToString() == "")
        {
            lbl_bank_details.Text = "N/A";
        }
        else
        {
            lbl_bank_details.Text = ds.Tables[1].Rows[0]["bank_name"].ToString();
        }
        if (ds.Tables[1].Rows[0]["esi_no"].ToString() == "")
        {
            lbl_esi_number.Text = "N/A";
        }
        else
        {
            lbl_esi_number.Text = ds.Tables[1].Rows[0]["esi_no"].ToString();
        }
        if (ds.Tables[1].Rows[0]["pan_no"].ToString() == "")
        {
            lbl_emp_IT_pan.Text = "N/A";
        }
        else
        {
            lbl_emp_IT_pan.Text = ds.Tables[1].Rows[0]["pan_no"].ToString();
        }
        if (ds.Tables[1].Rows[0]["pf_no"].ToString() == "")
        {
            lbl_pf_acnumber.Text = "N/A";
        }
        else
        {
            lbl_pf_acnumber.Text = ds.Tables[1].Rows[0]["pf_no"].ToString();
        }
      
      //  lbl_amount.Text = ds.Tables[2].Rows[0]["ntotal"].ToString();
        lbl_reimbursement.Text = ds.Tables[2].Rows[0]["REIMNTOTAL"].ToString();

        lblworkingdays.Text = ds.Tables[2].Rows[0]["working_days"].ToString();
        lbllwp.Text = ds.Tables[2].Rows[0]["lwp"].ToString();

        lbl_year.Text = ds.Tables[2].Rows[0]["year"].ToString();
        decimal a = Convert.ToDecimal(lblworkingdays.Text) - Convert.ToDecimal(lbllwp.Text);
        lbl_effworkdays.Text = a.ToString();
        //Convert.ToString((Decimal.Parse(textBox8.Text)) - (((Decimal.Parse(textBox6.Text)) * (Decimal.Parse(textBox9.Text)))));

    }

    protected void bind_earnings()
    {
        //        sqlstr = @"SELECT distinct tbl_payroll_employee_salarydetail.payheadid,tbl_payroll_employee_salarydetail.id,
        //        tbl_payroll_employee_salarydetail.month,tbl_payroll_employee_salarydetail.payhead,
        //        tbl_payroll_employee_salarydetail.HEAD_TYPE,tbl_payroll_employee_salarydetail.amount,tbl_payroll_employee_salarydetail.type
        //        from tbl_payroll_employee_salarydetail 
        //        inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salarydetail.empcode=tbl_intranet_employee_jobDetails.empcode 
        //INNER JOIN  tbl_payroll_employee_salary ON tbl_payroll_employee_salarydetail.empcode=tbl_payroll_employee_salary.empcode and 
        //tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid   
        sqlstr = @"SELECT distinct top(1) tbl_payroll_employee_salarydetail.payheadid,tbl_payroll_employee_salarydetail.id,
        tbl_payroll_employee_salarydetail.month,tbl_payroll_employee_salarydetail.payhead,
        tbl_payroll_employee_salarydetail.HEAD_TYPE,tbl_payroll_employee_salarydetail.amount,tbl_payroll_employee_salarydetail.type,tbl_payroll_employee_paystructure_detail.amount as fullamount
        from tbl_payroll_employee_salarydetail 
        inner join tbl_intranet_employee_jobDetails on tbl_payroll_employee_salarydetail.empcode=tbl_intranet_employee_jobDetails.empcode 
INNER JOIN  tbl_payroll_employee_salary ON tbl_payroll_employee_salarydetail.empcode=tbl_payroll_employee_salary.empcode and 
tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid 
left join tbl_payroll_employee_paystructure_detail on tbl_payroll_employee_paystructure_detail.paystructure_id=tbl_payroll_employee_salary.paystructureid and tbl_payroll_employee_paystructure_detail.empcode = tbl_payroll_employee_salarydetail.EMPCODE and
tbl_payroll_employee_salarydetail.month=tbl_payroll_employee_salary.month and
tbl_payroll_employee_paystructure_detail.payhead = tbl_payroll_employee_salarydetail.PAYHEADID and 
tbl_payroll_employee_salarydetail.salaryid=tbl_payroll_employee_salary.salaryid       
where HEAD_TYPE=0 and year='" + stryear.ToString() + "' and tbl_payroll_employee_salary.month ='" + strmonth.ToString() + "' and tbl_payroll_employee_salarydetail.empcode='" + strempcode.ToString() + "' and tbl_payroll_employee_salarydetail.APPEAR_INPAYSLIP=1 and tbl_payroll_employee_salarydetail.type!=3 order by tbl_payroll_employee_salarydetail.type,tbl_payroll_employee_salarydetail.payheadid";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        earning_grid.DataSource = ds;
        earning_grid.DataBind();
    }

    protected void bind_deduction()
    {
        decimal basic = Convert.ToDecimal(ds.Tables[0].Rows[0]["fullamount"]);
        decimal PF = (basic * 10 / 100);

        lblProfFee.Text = Convert.ToString(PF);
        lbl_total_deductions.Text = PF.ToString();
        lbl_total_earning.Text = basic.ToString();

        decimal total = Convert.ToDecimal(basic - PF);

        lbl_amount.Text = total.ToString();
        NumberToEnglish.NumberToEnglish abc = new NumberToEnglish.NumberToEnglish();

        lblwords.Text = abc.changeCurrencyToWords(Convert.ToDouble(lbl_amount.Text));
    }

    protected void bind_reimbursement()
    {
        sqlstr = @"select s.empcode,s.month,payhead,sd.amount,sd.id 
                    from tbl_payroll_employee_salarydetail sd
                    INNER JOIN  tbl_payroll_employee_salary s ON sd.empcode=s.empcode and 
                    sd.month=s.month and 
                    sd.salaryid=s.salaryid
                    where TYPE=3 and s.month ='" + strmonth.ToString() + "'and sd.empcode='" + strempcode.ToString() + "' and sd.APPEAR_INPAYSLIP=1 order by sd.type";

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        reimbursement_grid.DataSource = ds;
        reimbursement_grid.DataBind();

        if (ds.Tables[0].Rows.Count > 0)
        {
            reimdiv.Visible = true;
        }
        else
        {
            reimdiv.Visible = false;
        }
    }

    protected void bind_total()
    {
        int currentyear, currentmonth = 0;
        if (strmonth.ToLower() == "jan")
        {
            currentmonth = 1;
        }
        if (strmonth.ToLower() == "feb")
        {
            currentmonth = 2;
        }
        if (strmonth.ToLower() == "mar")
        {
            currentmonth = 3;
        }
        if (strmonth.ToLower() == "apr")
        {
            currentmonth = 4;
        }
        if (strmonth.ToLower() == "may")
        {
            currentmonth = 5;
        }
        if (strmonth.ToLower() == "jun")
        {
            currentmonth = 6;
        }
        if (strmonth.ToLower() == "jul")
        {
            currentmonth = 7;
        }
        if (strmonth.ToLower() == "aug")
        {
            currentmonth = 8;
        }
        if (strmonth.ToLower() == "sep")
        {
            currentmonth = 9;
        }
        if (strmonth.ToLower() == "oct")
        {
            currentmonth = 10;
        }
        if (strmonth.ToLower() == "nov")
        {
            currentmonth = 11;
        }
        if (strmonth.ToLower() == "dec")
        {
            currentmonth = 12;
        }
        //currentmonth = Convert.ToInt32(strmonthn);
        currentyear = Convert.ToInt32(stryear.Substring(0, 4));

        if ((currentmonth == 1) || (currentmonth == 2) || (currentmonth == 3))
        {
            currentyear = currentyear + 1;
        }
        DateTime todate;
        //fromdate = Convert.ToDateTime("04/24/" + currentyear);
        //todate = Convert.ToDateTime(currentmonth + "/25/" + currentyear);
        todate = Utilities.Utility.dataformat(currentmonth + "/25/" + currentyear);

        query q = new query();
        stryear = (q["year"] != null) ? q["year"] : "0";
        sqlstr = @"select isnull(sum(gtotal),0.00) GrandTotal,
                    isnull(sum(dtotal),0.00) DeductionTotal,
                    isnull(sum(REIMNTOTAL),0.00) ReimbursementTotal 
                    from tbl_payroll_employee_salary

                    where year='" + stryear + "' and empcode='" + strempcode.ToString() + "' and todate<='" + todate.ToString() + "'";//  between '" + fromdate + "' and '" + todate + "' and empcode='" + strempcode.ToString() + "'";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        lbl_tot_deduction.Text = ds.Tables[0].Rows[0]["DeductionTotal"].ToString();
        lbl_tot_grandtotal.Text = ds.Tables[0].Rows[0]["GrandTotal"].ToString();
        lbl_tot_reimbursement.Text = ds.Tables[0].Rows[0]["ReimbursementTotal"].ToString();
    }

    protected void lnkprint_Click(object sender, EventArgs e)
    {
        SqlParameter[] sqlparam;
        sqlparam = new SqlParameter[3];
        sqlparam[0] = new SqlParameter("@empcode", SqlDbType.VarChar, 50);
        sqlparam[0].Value = strempcode;
        sqlparam[1] = new SqlParameter("@month", SqlDbType.VarChar, 50);
        //sqlparam[1].Value = a.ToString("MMM");
        sqlparam[1].Value = strmonth;

        sqlparam[2] = new SqlParameter("@year", SqlDbType.VarChar, 50);
        sqlparam[2].Value = stryear;

        //----Added by Anuj on 3-June-14 for convert month to specific salary cycle period.

        //lbl_month.Text = strmonth.ToString(); //Commented by Anuj on 3-June-14 
        int i = DateTime.ParseExact(strmonth, "MMM", CultureInfo.CurrentCulture).Month;
        int pMonth = 0;
        if (i == 1)
            pMonth = 12;
        else
            pMonth = i - 1;
        string strPreviousMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(pMonth);
        string strCurrentMonth = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i);

        string pdfSalCycle = 26 + " " + strPreviousMonth + " to " + 25 + " " + strCurrentMonth + " - ";

        //----EOC by Anuj on 3-June-14 for convert month to specific salary cycle period.

        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.StoredProcedure, "generate_payslip_printing", sqlparam);
        ds.Tables[0].TableName = "payslip_emp";

        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_deduction", sqlparam);
        ds1.Tables[0].TableName = "payslip_emp_deduction";

        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_earning", sqlparam);
        ds2.Tables[0].TableName = "payslip_emp_earning";

        DataSet ds3 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "generate_payslip_emp_tot_earning_deduction", sqlparam);
        ds3.Tables[0].TableName = "payslip_emp_tot_earning_deduction";

        DataSet ds4 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString.ToString(), CommandType.StoredProcedure, "sp_intranet_fetch_companydetail", sqlparam);
        ds4.Tables[0].TableName = "companydetail";

        string companyname = (ds4.Tables[0].Rows[0]["companyname"].ToString()).Replace(" ", string.Empty);

        CrystalReportViewer1.DisplayGroupTree = false;
        CrystalReportViewer1.HasCrystalLogo = false;

        ReportDocument myReportDocument = new ReportDocument();
        myReportDocument.Load(Server.MapPath(".") + "\\reports\\payslip.rpt");
        myReportDocument.SetDataSource(ds.Tables["payslip_emp"]);

        myReportDocument.OpenSubreport("payslip_emp_deduction.rpt").SetDataSource(ds1.Tables["payslip_emp_deduction"]);
        myReportDocument.OpenSubreport("payslip_emp_earning.rpt").SetDataSource(ds2.Tables["payslip_emp_earning"]);
        myReportDocument.OpenSubreport("payslip_total_earn_deduction.rpt").SetDataSource(ds3.Tables["payslip_emp_tot_earning_deduction"]);
        myReportDocument.OpenSubreport("payslip_company.rpt").SetDataSource(ds4.Tables["companydetail"]);
        // myReportDocument.SetParameterValue("month", strmonth);
        myReportDocument.SetParameterValue("month", pdfSalCycle);
        //myReportDocument.SetParameterValue("year", stryear);
        myReportDocument.SetParameterValue("year", DateTime.Now.Year);
        CrystalReportViewer1.ReportSource = myReportDocument;
        CrystalReportViewer1.DataBind();

        // Stop buffering the response
        Response.Buffer = false;
        // Clear the response content and headers
        Response.ClearContent();
        Response.ClearHeaders();
        try
        {
            // Export the Report to Response stream in PDF format and file name Customers
            myReportDocument.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "'" + strempcode.ToString() + "'" + companyname);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            ex = null;
        }
    }
}