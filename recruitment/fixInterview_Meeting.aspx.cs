using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_fixInterview_Meeting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void cleartext()
    {
        txt_Address.Text = "";
        txt_email.Text = "";
        txt_intdate.Text = "";
        txt_mobileno.Text = "";
        txt_notes.Text = "";
        txt_phoneno.Text = "";
        txt_Qualifications.Text = "";
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        cleartext();
    }
    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleartext();
    }
}