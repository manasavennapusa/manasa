using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_ConfirmationForm : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string candidatename = Request.QueryString["CandidateName"];
        string confirmation_number = Request.QueryString["ConfirmationNumber"];
        string hr_1 = Request.QueryString["Hr1"];
        string hr_2 = Request.QueryString["Hr2"];
        string address = Request.QueryString["Address"];
        string effective_date = Request.QueryString["EffectiveDate"];
        string issued_date = Request.QueryString["IssuedDate"];
        string department = Session["Department"].ToString();
        string designation = Session["Designation"].ToString();
        string employee_id = Request.QueryString["EmployeeID"];
        string issued_by = Request.QueryString["IssuedBy"];
        string email = Request.QueryString["EmailID"];

        txt_confirmation_letter.Text = confirmation_number;
        txt_HR_1.Text = hr_1;
        txt_HR_2.Text = hr_2;
        txt_date_1.Text = issued_date;
        txt_candidate_name.Text = candidatename;
        txt_dept.Text = department;
        lbl_name.Text = candidatename;
        txt_designation.Text = designation;
        txt_frm_date.Text = effective_date;
    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("ConfirmationLetterDetails.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=ConfirmationForm.doc");
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