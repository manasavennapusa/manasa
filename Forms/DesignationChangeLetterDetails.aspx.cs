using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_DesignationChangeLetterDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string designation_change_letter_number = Request.QueryString["Designation_Change_Letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string issued_date = Request.QueryString["Issued_Date"];
        string designation = Session["designation"].ToString();
        string email = Request.QueryString["Email_ID"];

        txt_designation_change_letter.Text = designation_change_letter_number;
        txt_HR_1.Text = hr_1;
        txt_HR_2.Text = hr_2;
        txt_date.Text = issued_date;
        txt_employee_name.Text = employee_name;
        txt_department.Text = Session["department"].ToString();
        txt_empname.Text = employee_name;
        txt_year.Text = DateTime.Now.Year.ToString();
        txt_department_1.Text = Session["department"].ToString();
        txt_designation.Text = designation;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateDesignationChangeLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=DesignationChangeLetter.doc");
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