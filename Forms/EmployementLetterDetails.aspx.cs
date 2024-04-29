using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_EmployementLetterDetails : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string employement_Letter_number = Request.QueryString["Employement_letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string employee_id = Request.QueryString["Employee_ID"];
        string from_date = Request.QueryString["From_Date"];
        string to_date = Request.QueryString["To_Date"];
        string department = Session["dept"].ToString();
        string designation = Session["Designation"].ToString();
        string issued_by = Request.QueryString["Issued_By"];
        string email = Request.QueryString["Email_ID"];
        string Address = Session["Address"].ToString();

        txt_employement_letter.Text = employement_Letter_number;
        txt_hr_1.Text = hr_1;
        txt_hr_2.Text = hr_2;
        txt_date.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txt_emp_name.Text = employee_name;
        txt_department.Text = department;
        txt_emp_name_1.Text = employee_name;
        txt_emp_id.Text = employee_id;
        txt_address.Text = Address;
        txt_from_date.Text = from_date;
        txt_to_date.Text = to_date;
        txt_designation.Text = designation;

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateEmployementLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=EmployementLetter.doc");
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