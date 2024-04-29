using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_RelievingLetterDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string employee_name = Request.QueryString["Employee_Name"];
        string relieving_letter_number = Request.QueryString["Relieving_Letter_Number"];
        string hr_1 = Request.QueryString["Hr_1"];
        string hr_2 = Request.QueryString["Hr_2"];
        string issued_date = Request.QueryString["Issued_Date"];
        string resignation_date = Request.QueryString["Resignation_Date"];
        string relieving_date = Request.QueryString["Relieving_Date"];
        string date_of_join = Request.QueryString["Date_Of_Join"];
        string designation = Request.QueryString["Designation"];
        string email = Request.QueryString["Email_ID"];

        txt_relieving_letter.Text = relieving_letter_number;
        txt_hr_1.Text = hr_1;
        txt_hr_2.Text = hr_2;
        txt_date.Text = issued_date;
        txt_emp_name.Text = employee_name;
        txt_designation.Text = Session["designation"].ToString();
        txt_doj.Text = date_of_join;
        txt_resignation_date.Text = resignation_date;
        txt_relieving_date.Text = relieving_date;

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateRelievingLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=RelievingLetter.doc");
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