using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_ResignationAcceptanceLetter_1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string resign_acceptance_letter_num = Request.QueryString["Resign_Acceptance_Letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string last_working_date = Request.QueryString["Last_Working_Date"];
        string issued_date = Request.QueryString["Issued_Date"];
        string designation = Request.QueryString["Designation"];
        string issued_by = Request.QueryString["Issued_By"];
        string email_id = Request.QueryString["Email_ID"];

        txt_resignation_acceptance_letter.Text = resign_acceptance_letter_num;
        txt_HR_1.Text = hr_1;
        txt_HR_2.Text = hr_2;
        txt_date.Text = issued_date;
        txt_employee_name.Text = employee_name;
        txt_designation.Text = Session["designation"].ToString();
        txt_empname.Text = employee_name;
        txt_last_working_date.Text = last_working_date;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateResignationAcceptanceLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=ResignationAcceptanceLetter.doc");
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