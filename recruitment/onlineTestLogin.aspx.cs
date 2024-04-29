using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recruitment_onlineTestLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void cleartext()
    {
        txt_loginID.Text = "";
        txt_password.Text = "";
        ddl_candidateID.SelectedValue = null;
        ddl_RRF.SelectedValue = null;
    }
         
}