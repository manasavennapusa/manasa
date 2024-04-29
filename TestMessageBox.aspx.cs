



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CSASPNETMessageBox
{
    public partial class TestMessageBox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //MessageBox messageBox = new MessageBox();
            //messageBox.MessageTitle = "Information";
            //messageBox.MessageText = "Hello everyone, I am an Asp.net MessageBox. Please put your message here and click the following button to close me.";
            //Literal1.Text = messageBox.Show(this);
        }

        protected void btnInvokeMessageBox_Click(object sender, EventArgs e)
        {
            MessageBox messageBox = new MessageBox();
            messageBox.MessageTitle = "Information";
            messageBox.MessageText = "Hello everyone, I am an Asp.net MessageBox. Please put your message here and click the following button to close me.";
            Literal1.Text = messageBox.Show(this);
        }
    }
}