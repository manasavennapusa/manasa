<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfferletterFinal.aspx.cs" Inherits="Forms_OfferletterFinal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<!--[if lt IE 7]>
    <html class="lt-ie9 lt-ie8 lt-ie7" lang="en">
  <![endif]-->

<!--[if IE 7]>
    <html class="lt-ie9 lt-ie8" lang="en">
  <![endif]-->

<!--[if IE 8]>
    <html class="lt-ie9" lang="en">
  <![endif]-->

<!--[if gt IE 8]>
    <!-->

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script src="js/popup1.js"></script>

    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script type="text/javascript">
        function disableBtn(btnID, newText) {

            var btn = document.getElementById(btnID);
            setTimeout("setImage('" + btnID + "')", 60000);
            btn.disabled = true;
            btn.value = newText;
        }

        function setImage(btnID) {
            var btn = document.getElementById(btnID);
            btn.style.background = 'url(12501270608.gif)';
        }
    </script>
    <script src="js/validation.js"></script>
</head>
<body>
    <form id="form1" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper"  style="margin-left: 0px;">

            <div class="main-container" runat="server" id="dash" style="border-top:0px  ">
                  <div id="Div1" runat="server" style="margin-left:13px">
        

         <div class="page-header">
                    <div class="pull-left">
                        <h2> </h2>
                    </div>
                   
                    <div class="clearfix">
                         <asp:Button ID="print" runat="server" OnClientClick="hide(); show(); window.print();" class="btn btn-info pull-right"  Text="Print" style="float:right"/>
                    </div>
                </div>
        <asp:Image runat="server" ID="img"  ImageUrl="~/images/esclon.jpg" />
        <br />
        <br />
        
    <p> <b> Offer Letter  </b> 
         <br />
            _________________________________</p>
         
        <p> HR/_____/____	</p>
        <br />
        <p>  Date ___________</p>
        <br />
       
       <p> Hi ________________</p>
        <br />
        <p>Based on our recent discussions with you, we are pleased to extend you an offer to join Escalon Business Services Private Limited in India; Mohali. This letter will officially confirm your annual total earning potential and terms of your employment.</p>

        
        <p>Date of Joining: _____________________________<br />
        Timing’s: These will be as per the needs of the client and the company.  <br />
        Role – _______________________________<br />
        Segment- _______________________________</p>
      
        <p>Your annual total cash compensation will be INR ___________/- and will be structured as per the attached<br />
        Annexure 1 – Compensation Details. This will continue to be applicable until further communication on the same. Your annual total earning potential includes:</p>
        

        <p> - Annual fixed compensation of INR __________/-; this includes allowances and statutory benefits and will be structured in accordance with the Company’s compensation guidelines. The said amount includes employer’s contribution to Provident Fund, as applicable. </p>
        
        <p>On joining you may undergo a training program to acquire the knowledge to enable you to successfully perform to the expectations of the position for which you are being considered for employment. This offer and your employment with Escalon are contingent upon you successfully completing the training program, as per the satisfaction of Escalon standards. Failing which, Escalon may, in its sole discretion, elect to terminate or suspend your employment giving 15 days’ notice.</p>
      
        <p> This offer is contingent on us working together to determine an appropriate start date for your employment. This letter and this offer are valid for seven (7) days from the date of this letter. </p>
        <p> You are required to provide copies of all mandatory documents required by the Company before joining with in first 7 days to close the position officially. The offer of employment and your employment with the Company is dependent on timely submission of such required documents. Non furnishing of mandatory document/s within the specified time shall result in termination of employment.</p>
        
        <p>We look forward to hearing from you regarding your decision to join our team. In the meantime, please feel free to call us.</p>
        
        <p>Please send two references of previous employment for internal process (Reference check) and your acceptance in reply to this mailer to confirm us officially to close the opening. </p>
      
        <p>We believe you have a successful career ahead of you and look forward to your joining us.</p>
        <br />
         <p> For <b> Escalon Business Services Pvt Ltd </b></p>
        <p style="font-style:oblique"> Ritu Chitra</p>
        <p> <p> Ritu Chitra<br />
            <b> HR Manager</b>
        <br />
        <p> Authorized Signatory</p>
        <br />
        <p> ACKNOWLEDGED AND AGREED:</p>
        <br />
        <br />
        <br />
        <br />
       
        <p> _____________________</p>
    
        <p>[Insert full name] Candidate’s signature____________</p>
        <br />
        <br />
        <p>Date:</p>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       
      
     <center>   <p> ANNEXURE 1</p>               </center>
        <p> &nbsp;Your compensation is as mentioned below:</p>   
        

        <table style="width:100%;text-align:center;" border="1" cellspacing="0" cellpadding="0">
            <tr style="height:10px; width:100%">
                <td style="width:100%; text-align:left" colspan="2">
                 &nbsp;   Total Cash Compensation
                </td>
                
            </tr>
            <tr  style="height:30px">
                <td style="border-right:none">

                </td>
                <td style="border-left:none">
                    Annual (INR )
                </td>
            </tr>
            <tr>
                <td style="width:50%;text-align:left"  >
                 &nbsp;    A)	Annual Compensation 
                </td>
                <td style="width:50%;text-align:left"> 
                     &nbsp; &nbsp; INR _____________/-
                </td>
            </tr>
        </table>
        <br />
        

        <p>Any Shift allowance or facility availed will be add-on to CTC.In addition to your annual earning potential, you will be eligible for following benefits, which will be governed by Escalon Policies:</p>
        <p>1.	Medical Insurance for self, spouse and 3 dependent children will be covered as per Escalon Policy.
Premium for this 90% will be paid by Escalon. <br />
You have the option of availing Escalon negotiated rates to cover your parents and any additional child under a separate Insurance plan. The entirepremium for this will have to be borne by you.<br />

        2.	Personal Accident Coverage of INR 5,00,000<br />
         3.	Gratuity as per The Payment of Gratuity Act, 1972, In case of Gratuity applicability one will also be applicable for Gratuity Multiplier of 5% on actual gratuity amount with every passing year.
The Company may, at any time and in its sole and absolute discretion, amend, suspend, vary and modify any of the terms and conditions of the above mentioned benefits.
</p>
        
        <p> DECLARATION </p>
       
        <p>I hereby represent and assure that I will be joining on mentioned date and I have not, during the course of any current/previous employer and any other employment or contractor relationships, entered into or agreed to any arrangement.</p>
        
        <p> I also assure that I’ll not disclose the salary or bonus figures to anybody. If I do so, I’ll be liable for termination.</p>
        
        <p> Candidate’s signature____________</p>
         <br />
        <br />
        <br />
        <br />
     
        <p>REQUIRED DOCUMENTATION:</p>
       
        <p> To be submitted <br />
           <br />
        •	2 Passport size photographs<br />
        •	2 copy of PAN Card<br />
        
         •	2 copy of Passport <br />
        
        •	HDFC account #, if any.<br />
        •	Certificate of Educational Qualification (10th, +2 , Graduation and Masters If any)<br />
         •	Last 3 salary slips<br />
        •	Accepted copy of resignation (from Current employer) within 7 days of offer letter <br />
         •	Relieving letter at the time of joining </p>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
       
         <center> <p style="font-size:13px;text-align:center;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%">-------------------------------------------- Escalon Business Services Pvt Ltd. ------------------------------------------- <br />
          Office: #40A,SP Info City  2nd Floor, Industrial Area, Phase 8B Mobile, Phone : 0172-5013839 Website:www.escalon.services
               </p></center>  
        <br />
        <br />
        <br />

</div>
                </div>
            </div>
                <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>
    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#gveligible').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#gvGoals1').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
                 <script>
                     function hide() {
                         var x = document.getElementById('print');

                         x.style.display = 'none';

                         var y = document.getElementById('dash');

                         x.style.display = 'none';

                     }

                     function show() {
                         var y = document.getElementById('Div1');
                         y.style.display = 'block';
                     }
</script>
    <script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>
    </form>
</body>
</html>
