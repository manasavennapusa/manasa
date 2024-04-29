using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_AppointmentLetterDetails : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    string sqlstr;
    string strempcode, strmonth, stryear, strmonthn, empcode;
    protected void Page_Load(object sender, EventArgs e)
    {
        empcode = Session["employeecode"].ToString();
        string candidate_name = Request.QueryString["CandidateName"];
        string appointment_Letter_number = Request.QueryString["Appointment_letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];

        string date_of_join = Request.QueryString["Date_Of_Join"];
        string ctc = Request.QueryString["CTC"];
        string issued_date = Request.QueryString["Issued_Date"];
        string terminated_service_days = Request.QueryString["Terminated_Service_Days"];
        string sum_not_exceeding_days = Request.QueryString["Sum_Not_Exceeding_Days"];
        string job_location = Request.QueryString["Job_Location"];
        string department = Request.QueryString["Department"];
        string designation = Session["designation"].ToString();
        string issued_by = Request.QueryString["Issued_By"];
        string email = Request.QueryString["Email_ID"];
        string Emp_address = Session["Address"].ToString();
        //string Emp_address = ViewState["address"].ToString();

        txt_appointment_letter.Text = appointment_Letter_number;
        txt_HR_1.Text = hr_1;
        txt_HR_2.Text = hr_2;
        txt_address.Text = Emp_address.Replace("  ", "").ToString();
        txt_employee_name.Text = candidate_name;
        txt_emp_name.Text = candidate_name;
        txt_desg.Text = designation;
        txt_desg_1.Text = designation;
        txt_doj.Text = date_of_join;
        txt_ctc.Text = ctc;
        txt_terminated_days.Text = terminated_service_days;
        txt_sum_not_exceeding.Text = sum_not_exceeding_days;
        txt_employee_name_1.Text = candidate_name;
        txt_desg_3.Text = designation;
        txt_location.Text = job_location;
        txt_doj_1.Text = date_of_join;

        lbl_year.Text = DateTime.Now.Year.ToString();
        txt_date.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        bind_earning_grid();
        bind_deduction_grid();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateAppointmentLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=AppointmentLetter.doc");
        Response.Charset = "";
        EnableViewState = false;
        System.IO.StringWriter sw = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);
        tbl_btn.Visible = false;
        Page.RenderControl(hw);
        Response.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void bind_earning_grid()
    {
        sqlstr = @"SELECT distinct sd.empcode,sd.id,sd.payhead,sd.amount as monthly,sd.amount*12 as Annual,pay.payhead_name
from tbl_payroll_employee_paystructure_detail sd 
inner join tbl_intranet_employee_jobDetails jd on sd.empcode=jd.empcode 
INNER JOIN  dbo.tbl_payroll_employee_paystructure es ON sd.empcode=es.empcode  and sd.paystructure_id=es.ID  
inner join tbl_payroll_payhead pay on pay.id = sd.payhead
where sd.empcode='" + empcode + "' and sd.status=1";
        ds = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
        {
            earning_grid.DataSource = ds;
            earning_grid.DataBind();
            //tr_cash_benefits.Visible = true;
            //td_deduction.Visible = true;
        }
        else
            return;
        //----------------------------------------------------------------------------------------------------------------------------------------------------------
        sqlstr = @"SELECT sum(sd.amount) as MonthlyTotal,sum(sd.amount*12) as AnnualTotal
from tbl_payroll_employee_paystructure_detail sd 
inner join tbl_intranet_employee_jobDetails jd on sd.empcode=jd.empcode 
INNER JOIN  dbo.tbl_payroll_employee_paystructure es ON sd.empcode=es.empcode  and sd.paystructure_id=es.ID  
inner join tbl_payroll_payhead pay on pay.id = sd.payhead
where sd.empcode='" + empcode + "' and sd.status=1";
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds.Tables.Count > 0)
        {
            //lbl_total_earning_monthly.Text = ds1.Tables[0].Rows[0]["MonthlyTotal"].ToString();
            //lbl_total_earning_annual.Text = ds1.Tables[0].Rows[0]["AnnualTotal"].ToString();
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            GridView1.ShowHeader = false;

            //tr_cash_benefits.Visible = true;
            //td_deduction.Visible = true;
        }
        else
            return;
    }

    protected void bind_deduction_grid()
    {
        sqlstr = @"SELECT distinct sd.empcode,pay.payhead_name,sd.amount as monthly,sd.amount*12 as Annual,(sd.amount*12)/100 as [Employer Share PF],
((sd.amount*12)/100)*12 as [Annual PF]
from tbl_payroll_employee_paystructure_detail sd 
inner join tbl_intranet_employee_jobDetails jd on sd.empcode=jd.empcode 
INNER JOIN  dbo.tbl_payroll_employee_paystructure es ON sd.empcode=es.empcode  and sd.paystructure_id=es.ID  
inner join tbl_payroll_payhead pay on pay.id = sd.payhead
where sd.empcode='" + empcode + "' and sd.status=1 and pay.payhead_name in('Basic')";
        DataSet ds2 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds2.Tables[0].Rows.Count > 0)
        {
            Double pf,annual_pf;
            lbl_pf.Text = ds2.Tables[0].Rows[0]["Employer Share PF"].ToString();
            Double.TryParse(lbl_pf.Text, out pf);
            lbl_pf.Text = pf.ToString(".00");

            lbl_annual_pf.Text = ds2.Tables[0].Rows[0]["Annual PF"].ToString();
            Double.TryParse(lbl_annual_pf.Text, out annual_pf);
            lbl_annual_pf.Text = annual_pf.ToString(".00");

            //tr_cash_benefits.Visible = true;
            td_deduction.Visible = true;
            //tr_cash.Visible = true;
            GridView1.Visible = true;
            dv_salary_structure.Visible = true;
        }
        else
            return;
        //----------------------------------------------------------------------------------------------------------------------------------------------------

        sqlstr = @"SELECT (sum(sd.amount)*1.75/100) as ESI,(sum(sd.amount)*1.75/100)*12 as [Annual ESI]
from tbl_payroll_employee_paystructure_detail sd 
inner join tbl_intranet_employee_jobDetails jd on sd.empcode=jd.empcode 
INNER JOIN  dbo.tbl_payroll_employee_paystructure es ON sd.empcode=es.empcode  and sd.paystructure_id=es.ID  
inner join tbl_payroll_payhead pay on pay.id = sd.payhead
where sd.empcode='" + empcode + "' and sd.status=1";
        DataSet ds1 = DBTask.ExecuteDataset(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString(), CommandType.Text, sqlstr);
        if (ds1.Tables[0].Rows.Count > 0)
        {
            Double esi,annual_esi;
            lbl_esi.Text = ds1.Tables[0].Rows[0]["ESI"].ToString();
            Double.TryParse(lbl_esi.Text, out esi);
            lbl_esi.Text = esi.ToString(".00");

            lbl_annual_esi.Text = ds1.Tables[0].Rows[0]["Annual ESI"].ToString();
            Double.TryParse(lbl_annual_esi.Text, out annual_esi);
            lbl_annual_esi.Text = annual_esi.ToString(".00");


            //tr_cash_benefits.Visible = true;
            td_deduction.Visible = true;
            dv_salary_structure.Visible = true;
        }
        else
            return;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        float value1, value2, result = 0, value3, value4, result_1 = 0;
        value1 = float.Parse(lbl_pf.Text);
        value2 = float.Parse(lbl_esi.Text);
        result = value1 + value2;
        lbl_total_deduction_monthly.Text = result.ToString();
        value3 = float.Parse(lbl_annual_pf.Text);
        value4 = float.Parse(lbl_annual_esi.Text);
        result_1 = value3 + value4;
        lbl_total_deduction_annual.Text = result_1.ToString();
    }

}