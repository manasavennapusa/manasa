using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_IncrementLetterDetails : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string increment_letter_number = Request.QueryString["Increment_Letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string issued_date = Request.QueryString["Issued_Date"];
        string annual_fixed_compensation = Request.QueryString["Annual_Fixed_Compensation"];
        string variables = Request.QueryString["Variables"];
        string annual_fixed_compensation_1 = Request.QueryString["Annual_Fixed_Compensation_1"];
        string variables_1 = Request.QueryString["Variables_1"];
        string financial_year = Request.QueryString["Financial_Year"];
        string department = Request.QueryString["Department"];
        string issued_by = Request.QueryString["Issued_By"];
        string emailid = Request.QueryString["Email_ID"];
        string total_earnings = Request.QueryString["Total_Earnings"];
        string total_earnings_1 = Request.QueryString["Total_Earnings_1"];

        txt_increment_letter.Text = increment_letter_number;
        txt_hr_1.Text = hr_1;
        txt_hr_2.Text = hr_2;
        txt_date.Text = issued_date;
        txt_emp_name.Text = employee_name;
        txt_department.Text = Session["department"].ToString();
        txt_employee_name.Text = employee_name;
        txt_financial_year.Text = financial_year;
        txt_annual_fixed_compensation.Text = annual_fixed_compensation;
        txt_variables.Text = variables;
        txt_annual_fixed_compensation_1.Text = annual_fixed_compensation_1;
        txt_variables_1.Text = variables_1;
        txt_result.Text = total_earnings;
        txt_result_1.Text = total_earnings_1;

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateIncrementLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=IncrementLetter.doc");
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

}