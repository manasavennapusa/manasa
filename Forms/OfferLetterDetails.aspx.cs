
using Smart.HR.Common.Console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Forms_OfferLetterDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string candidate_name = Request.QueryString["candidatename"];
        string issued_date = Request.QueryString["issueddate"];
        string offer_letter_num = Request.QueryString["offerletternumber"];
        string hr_1 = Request.QueryString["hr1"];
        string hr_2 = Request.QueryString["hr2"];
        string address = Request.QueryString["Address"];
        string CTC = Request.QueryString["ctc"];
        string join_date = Request.QueryString["joindate"];
        string issued_by = Request.QueryString["issuedby"];
        string job_loc = Request.QueryString["jobloc"];
        string dept = Session["Department"].ToString();
        string desg = Session["Designation"].ToString();
        string last_dt_to_join = Request.QueryString["lastdatetojoin"];
        string email_id = Request.QueryString["emailid"];

        txt_offer_letter.Text = offer_letter_num;
        txt_HR_1.Text = hr_1;
        txt_HR_2.Text = hr_2;
        txt_date_1.Text = issued_date;
        txt_candidate_name.Text = candidate_name;
        txt_doj.Text = join_date;
        txt_role.Text = desg;
        txt_segment.Text = dept;
        annual_tot_cash.Text = (CTC + " " + ("/-"));
        txt_fixed_compensation.Text = (CTC + " " + ("/-"));
        txt_fullname.Text = candidate_name;
        txt_date.Text = DateTime.Now.ToString("dd-MMM-yyyy");
        txt_compn_inr.Text = (CTC + " " + ("/-"));

    }

    protected void btn_back_Click(object sender, EventArgs e)
    {
        Response.Redirect("GenerateOfferLetter.aspx");
    }

    protected void btn_export_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.word";
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.AddHeader("Content-Disposition", "attachment;filename=OfferLetter.doc");
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