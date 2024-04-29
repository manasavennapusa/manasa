using System;
using System.Web;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
	public Email()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static void getemail(string fromEmail, string fromPwd, string fromName, string toEmail, string toName, string subject, string body, string smtp, string emailLogo)
    {
        //string htmlBody = body;

        //AlternateView avHtml = AlternateView.CreateAlternateViewFromString
        //    (htmlBody, null, MediaTypeNames.Text.Html);

        //// Create a LinkedResource object for each embedded image
        //// LinkedResource pic1 = new LinkedResource(emailLogo, MediaTypeNames.Image.Jpeg);
        //// pic1.ContentId = "Pic1";
        //// avHtml.LinkedResources.Add(pic1);

        //// Add the alternate views instead of using MailMessage.Body
        //MailMessage m = new MailMessage();
        //m.AlternateViews.Add(avHtml);

        //// Address and send the message
        //m.From = new MailAddress(fromEmail, fromName);
        //m.To.Add(new MailAddress(toEmail));

        //m.Subject = subject;
        //SmtpClient client = new SmtpClient(smtp);
        //client.Credentials = new System.Net.NetworkCredential(fromName, fromPwd);
        ////   client.EnableSsl = true;
        //client.Send(m);
    }


    public static void getemailwithcc(string fromEmail, string fromPwd, string fromName, string toEmail,string cc, string toName, string subject, string body, string smtp, string emailLogo)
    {
        //string htmlBody = body;

        //AlternateView avHtml = AlternateView.CreateAlternateViewFromString
        //    (htmlBody, null, MediaTypeNames.Text.Html);

        //// Create a LinkedResource object for each embedded image
        //// LinkedResource pic1 = new LinkedResource(emailLogo, MediaTypeNames.Image.Jpeg);
        //// pic1.ContentId = "Pic1";
        //// avHtml.LinkedResources.Add(pic1);

        //// Add the alternate views instead of using MailMessage.Body
        //MailMessage m = new MailMessage();
        //m.AlternateViews.Add(avHtml);

        //// Address and send the message
        //m.From = new MailAddress(fromEmail, fromName);
        //m.To.Add(new MailAddress(toEmail));
        //m.CC.Add(new MailAddress(cc));
        //m.Subject = subject;
        //SmtpClient client = new SmtpClient(smtp);
        //client.Credentials = new System.Net.NetworkCredential(fromName, fromPwd);
        ////   client.EnableSsl = true;
        //client.Send(m);
    }


    public static string GetBody(string fromName, string toName, string bodyContent)
    {
        StringBuilder str = new StringBuilder();

        str.Append("<html xmlns:v='urn:schemas-microsoft-com:vml' xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:w='urn:schemas-microsoft-com:office:word' xmlns:m='http://schemas.microsoft.com/office/2004/12/omml' xmlns='http://www.w3.org/TR/REC-html40'>");
        str.Append("<head>");
        str.Append("<meta http-equiv=Content-Type content='text/html; charset=iso-8859-1'>");
        str.Append("<meta name=Generator content='Microsoft Word 12 (filtered medium)'>");
        str.Append("<!--[if !mso]>");
        str.Append("<style>");
        str.Append("v\\:* {behavior:url(#default#VML);}");
        str.Append("o\\:* {behavior:url(#default#VML);}");
        str.Append("w\\:* {behavior:url(#default#VML);}");
        str.Append(".shape {behavior:url(#default#VML);}");
        str.Append("</style>");
        str.Append("<![endif]-->");
        str.Append("<style>");
        str.Append("<!--");
        str.Append("/* Font Definitions */");
        str.Append("@font-face");
        str.Append("{font-family:'Cambria Math';");
        str.Append("panose-1:2 4 5 3 5 4 6 3 2 4;}");
        str.Append("@font-face");
        str.Append("{font-family:Calibri;");
        str.Append("panose-1:2 15 5 2 2 2 4 3 2 4;}");
        str.Append("@font-face");
        str.Append("{font-family:Tahoma;");
        str.Append("panose-1:2 11 6 4 3 5 4 4 2 4;}");
        str.Append("@font-face");
        str.Append("{font-family:Verdana;");
        str.Append("panose-1:2 11 6 4 3 5 4 4 2 4;}");
        str.Append("@font-face");
        str.Append("{font-family:Webdings;");
        str.Append("panose-1:5 3 1 2 1 5 9 6 7 3;}");
        str.Append("/* Style Definitions */");
        str.Append("p.MsoNormal, li.MsoNormal, div.MsoNormal");
        str.Append("{margin:0in;");
        str.Append("margin-bottom:.0001pt;");
        str.Append("font-size:11.0pt;");
        str.Append("font-family:'Calibri','sans-serif';}");
        str.Append("a:link, span.MsoHyperlink");
        str.Append("{mso-style-priority:99;");
        str.Append("color:blue;");
        str.Append("text-decoration:underline;}");
        str.Append("a:visited, span.MsoHyperlinkFollowed");
        str.Append("{mso-style-priority:99;");
        str.Append("color:purple;");
        str.Append("text-decoration:underline;}");
        str.Append("p.MsoAcetate, li.MsoAcetate, div.MsoAcetate");
        str.Append("{mso-style-priority:99;");
        str.Append("mso-style-link:'Balloon Text Char';");
        str.Append("margin:0in;");
        str.Append("margin-bottom:.0001pt;");
        str.Append("font-size:8.0pt;");
        str.Append("font-family:'Tahoma','sans-serif';}");
        str.Append("span.EmailStyle17");
        str.Append("{mso-style-type:personal-compose;");
        str.Append("font-family:'Calibri','sans-serif';");
        str.Append("color:windowtext;}");
        str.Append("span.BalloonTextChar");
        str.Append("{mso-style-name:'Balloon Text Char';");
        str.Append("mso-style-priority:99;");
        str.Append("mso-style-link:'Balloon Text';");
        str.Append("font-family:'Tahoma','sans-serif';}");
        str.Append(".MsoChpDefault");
        str.Append("{mso-style-type:export-only;}");
        str.Append("@page Section1");
        str.Append("{size:8.5in 11.0in;");
        str.Append("margin:1.0in 1.0in 1.0in 1.0in;}");
        str.Append("div.Section1");
        str.Append("{page:Section1;}");
        str.Append("-->");
        str.Append("</style>");
        str.Append("<!--[if gte mso 9]><xml>");
        str.Append("<o:shapedefaults v:ext='edit' spidmax='2050' />");
        str.Append("</xml><![endif]--><!--[if gte mso 9]><xml>");
        str.Append("<o:shapelayout v:ext='edit'>");
        str.Append("<o:idmap v:ext='edit' data='1' />");
        str.Append("</o:shapelayout></xml><![endif]-->");
        str.Append("</head>");

        str.Append("<body lang=EN-US link=blue vlink=purple>");

        str.Append("<div class=Section1>");
        
        str.Append("<p class=MsoNormal>Dear "+ toName +"<o:p></o:p></p>");

        str.Append("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

        str.Append("<p class=MsoNormal>"+bodyContent+"");
       // str.Append("reference.<o:p></o:p></p>");

      //  str.Append("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

        //str.Append(bodyContent);

        //str.Append("<p class=MsoNormal>Username: Emp1<o:p></o:p></p>");

        //str.Append("<p class=MsoNormal>Password: 00043<o:p></o:p></p>");

        str.Append("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

        str.Append("<p class=MsoNormal><b><span lang=EN-IN style='font-size:8.0pt;font-family:'Verdana','sans-serif';");
        str.Append("color:#1f497d'>Thanks &amp; Regards<o:p></o:p></span></b></p>");

        //str.Append("<p class=MsoNormal><span lang=EN-IN style='font-size:12.0pt;font-family:'Verdana','sans-serif';");
        //str.Append("color:#848484'></span></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:1.5pt'><b><span lang=EN-IN");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:#1f497d'>" + fromName + "");
        //str.Append("CN<o:p></o:p></span></b></p>");

       // str.Append("<p class=MsoNormal style='margin-bottom:6.0pt'><b><span lang=EN-IN");
      //  str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:#595959'>Software");
     //   str.Append("Developer<o:p></o:p></span></b></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:6.0pt'><b><span style='font-size:12.0pt;");
        //str.Append("font-family:'Verdana','sans-serif';color:#848484'><img border=0 width=205");
        //str.Append("height=51 id='Picture_x0020_1' src=\'cid:Pic1\'");
        //str.Append("alt='cid:image001.jpg@01CE8D3B.1879B7A0'></span></b><b><span lang=EN-IN");
        //str.Append("style='font-size:12.0pt;font-family:'Verdana','sans-serif';color:#848484'><o:p></o:p></span></b></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:6.0pt'><b><span lang=EN-IN");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:#595959'>SmartDriveLabs");
        //str.Append("Technologies India Pvt Ltd<o:p></o:p></span></b></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:1.5pt'><span lang=EN-IN");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:gray;");
        //str.Append("background:white'># 1143, 18th Main, 1st Stage, 5th Block</span><span");
        //str.Append("lang=EN-IN style='font-size:7.5pt;font-family:'Verdana','sans-serif';");
        //str.Append("color:gray'><br>");
        //str.Append("<span style='background:white'>HBR Layout, Bangalore 560 043</span><br>");
        //str.Append("<b><span style='border:none windowtext 1.0pt;padding:0in;background:white'>Phone:</span></b>&nbsp;+91-80-8065701846<o:p></o:p></span></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:1.5pt'><b><span lang=EN-IN");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:gray;");
        //str.Append("background:white'>Mobile</span></b><span lang=EN-IN style='font-size:7.5pt;");
        //str.Append("font-family:'Verdana','sans-serif';color:gray;background:white'>:");
        //str.Append("+91-9740442635&nbsp; <o:p></o:p></span></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:1.5pt'><b><span lang=EN-IN");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:gray'>Skype id:");
        //str.Append("</span></b><span lang=EN-IN style='font-size:7.5pt;font-family:'Verdana','sans-serif';");
        //str.Append("color:gray'>raghavendra.cn2<o:p></o:p></span></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:1.5pt'><a");
        //str.Append("href='http://www.smartdrivelabs.com'><b><span lang=EN-IN style='font-size:7.5pt;");
        //str.Append("font-family:'Verdana','sans-serif';color:blue'>www.smartdrivelabs.com</span></b></a><b><span");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:gray'> <span");
        //str.Append("lang=EN-IN><o:p></o:p></span></span></b></p>");

        //str.Append("<p class=MsoNormal style='margin-bottom:1.5pt'><span lang=EN-IN");
        //str.Append("style='font-size:7.5pt;font-family:'Verdana','sans-serif';color:#002060'><o:p>&nbsp;</o:p></span></p>");

        //str.Append("<p class=MsoNormal><i><span lang=EN-IN style='font-size:7.5pt;font-family:'Arial','sans-serif';");
        //str.Append("color:blue'>Disclaimer: This e-mail, including any attachment(s) hereto, is");
        //str.Append("intended only for the individual or entity to whom it is addressed.&nbsp; It");
        //str.Append("may contain proprietary, confidential or privileged information or attorney");
        //str.Append("work product belonging to Smartdrive Labs Technologies India Pvt.Ltd. or&nbsp;");
        //str.Append("its affiliates. If you are not the intended recipient of this e-mail, or if you");
        //str.Append("have otherwise received this e-mail in error, please immediately notify the");
        //str.Append("sender via return e-mail and permanently delete the original mail, any print");
        //str.Append("outs and any copies, including any attachments. Any dissemination,");
        //str.Append("distribution, alteration or copying of this e-mail is strictly prohibited. The");
        //str.Append("originator of this e-mail does not guarantee the security of this message and");
        //str.Append("will not be responsible for any damages arising from any dissemination,");
        //str.Append("distribution, alteration or copying of this message and/or any attachments to");
        //str.Append("this message by a third party or as a result of any virus being passed");
        //str.Append("on.&nbsp;Any comments or statements made in this are not necessarily those of");
        //str.Append("Smartdrive Labs Technologies India Pvt.Ltd.&nbsp; or any other Smartdrive Labs");
        //str.Append("Technologies India Pvt.Ltd.&nbsp; entity.&nbsp;All e-mails sent from or to");
        //str.Append("Smartdrive Labs Technologies India Pvt.Ltd&nbsp; may be subject to our");
        //str.Append("monitoring and recording procedures.&nbsp;</span></i><span lang=EN-IN");
        //str.Append("style='color:#1F497D'><o:p></o:p></span></p>");

        //str.Append("<p class=MsoNormal style='mso-margin-top-alt:auto;mso-margin-bottom-alt:auto'><span");
        //str.Append("lang=PT style='font-size:18.0pt;font-family:Webdings;color:green'>ü</span><span");
        //str.Append("style='font-size:13.5pt;font-family:'Times New Roman','serif';color:black'>&nbsp;</span><span");
        //str.Append("style='font-size:7.5pt;font-family:'Tahoma','sans-serif';color:green'>Please");
        //str.Append("consider your environmental responsibility before printing this e-mail.</span><span");
        //str.Append("style='font-size:13.5pt;font-family:'Times New Roman','serif';color:black'><o:p></o:p></span></p>");

        //str.Append("<p class=MsoNormal><o:p>&nbsp;</o:p></p>");

        str.Append("</div>");

        str.Append("</body>");

        str.Append("</html>");

        return str.ToString();

    }
}