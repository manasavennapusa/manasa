using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_TrainingLetterDetails : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string training_Letter_number = Request.QueryString["Training_letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string effective_date = Request.QueryString["Effective_Date"];
        string issued_date = Request.QueryString["Issued_Date"];
        string period_of = Request.QueryString["Period_Of"];
        string financial_year = Request.QueryString["Financial_Year"];
        string stipend_amount = Request.QueryString["Stipend_Amount"];
        string department = Request.QueryString["Department"];
        string designation = Request.QueryString["Designation"];
        string issued_by = Request.QueryString["Issued_By"];
        string email = Request.QueryString["Email_ID"];
        string Address = Session["Address"].ToString();

        txt_training_letter.Text = training_Letter_number;
        txt_hr_1.Text = hr_1;
        txt_hr_2.Text = hr_2;
        txt_date.Text = issued_date;
        txt_emp_name.Text = employee_name;
        txt_employee_name.Text = employee_name;
        txt_effective_date.Text = effective_date;
        txt_period_of.Text = period_of;
        txt_financial_year.Text = financial_year;
        txt_stipend_amount.Text = (stipend_amount+" "+("/-"));

        txt_address.Text = Address;

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateTrainingLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=TrainingLetter.doc");
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