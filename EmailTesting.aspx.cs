using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Smart.HR.Common.Mail.Module;

public partial class EmailTesting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EmailFactory email = new Smart.HR.Common.Mail.Module.Leave.UponSubmissionOfRequestFactory();
        EmailClient client = new EmailClient(email);
        client.toEmailId = "sugandh.hv@sdlglobe.com";
        client.empCode = "SDL-0014";
        client.employeeName = "Sugandh KV";
        client.fromDate = "05-Apr-2015";
        client.toDate = "30-Apr-2015";
        client.requestNumber = "1";
        client.Send();
    }
}