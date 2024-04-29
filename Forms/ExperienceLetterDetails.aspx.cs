using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_ExperienceLetterDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string experience_letter_number = Request.QueryString["Experience_Letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string issued_date = Request.QueryString["Issued_Date"];
        string date_of_join = Request.QueryString["Date_Of_Join"];
        string to_date = Request.QueryString["To_Date"];
        string designation = Request.QueryString["Designation"];
        string email = Request.QueryString["Email_ID"];

        txt_experience_letter_number.Text = experience_letter_number;
        txt_hr_1.Text = hr_1;
        txt_hr_2.Text = hr_2;
        txt_date.Text = issued_date;
        txt_empname.Text = employee_name;
        txt_doj_frm_date.Text = date_of_join;
        txt_to_date.Text = to_date;
        txt_designation.Text = Session["designation"].ToString();
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateExperienceLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=ExperienceLetter.doc");
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