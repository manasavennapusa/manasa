using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_forwardVacancys : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_clear_Click(object sender, EventArgs e)
    {
        cleartext();
    }

    protected void btn_Sumbit_Click(object sender, EventArgs e)
    {
        cleartext();
        Response.Redirect("requisitionForwardingByHR.aspx");
    }
    private void cleartext()
    {
        txt_fromdate.Text = "";
        txt_todate.Text = "";
        ddl_raiser.SelectedValue = "";
        ddl_location.SelectedValue = "";
        ddl_department.SelectedValue = "";
    }
}