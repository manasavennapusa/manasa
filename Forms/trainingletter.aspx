<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trainingletter.aspx.cs" Inherits="Forms_trainingletter" %>

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
    <title></title>
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
    <div>

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
        <table>
            <tr>
                <td>
          <p>     <b> Training Letter </b>
               _________________________<br />
          </p>           
       
    </div>
        <b>HR/____/____</b>
        <br />
        <br />
        <b>Date</b>________________<br />
                <br />
             
        __________________________<br />
        __________________________<br />
        __________________________<br />

        <br />
                <br />

       <b>Dear........  </b> 
                <br />
                <br />
                <br />
        <p> In reference to your application we would like to congratulate you on being selected for internship with
            <b> Escalon Business Services Pvt Ltd.</b> based at<b> Mohali - Punjab.</b> Your internship is scheduled to start
             effective _________ for a period of ________. All of us at Escalon are excited that you will be joining our team!
             As such, your internship will include training/orientation and focus primarily on learning and 
             developing new skills and gaining a deeper understanding of concepts through hands-on application of
             the knowledge you learned in class.</p> 
        <p> The project details and technical platform will be shared with you during your internship period </p> 
         <p>  You should report for training at the following address:</p>
                <b>Escalon Business Services Pvt Ltd.</b><br />
                <p>Phase 8A SP Info city <br />
                    2nd Floor </p>
             
               <p> <b>Contact Person / Reporting Manager Name: </b>
                   <br />
                   <br />
                We expect you to perform the activities and achieve the learning objectives as proposed in the Schedule below
                to the best of your ability and to maintain appropriate standards of behaviour at all times. We will also expect
                 you to comply with our rules, policies, procedures, standards and instructions. </p>
                <br />
              <p> For <b> Escalon Business Services Pvt Ltd </b></p>
        <p style="font-style:oblique"> Ritu Chitra</p>
        <p> <p> Ritu Chitra<br />
            <b> HR Manager</b>
            </p>   </p>
                </div>
                 <br />
       
               
                </td>
            </tr>
        </table>
   
                <table>
                    <tr>
                        <td>
                            
                <p> <b>Important Points:</b> <br />1.<b> National Holidays:</b>  The Intern will be entitled for the national holidays as per the list published by the HR for the FY _________.<br />
                2. <b>Company Property: </b>   The Intern will maintain the good decorum in the office and will maintain in good condition company property, which may be entrusted for official purpose during the course of internship.  <br />
               3. <b>	Stipend:</b> Your internship is a voluntary activity and we will provide you’re with Rs _________ as a stipend for the course of your internship.<br />
               4. <b> 	NON-DISCLOSURE OF INFORMATION:</b> The Intern understands and agree that she shall 
                    not, at any time during the continuance or after the termination of the internship hereunder,
                    divulge either directly or indirectly to any person, firm or Company or use for himself or for
                    another any knowledge, information, end-customer information (names, personal or financial information), 
                   formulae, processes, methods, compositions, ideas or documents, concerning the business and affairs of the company 
                   or any of its dealings, transactions or affairs which the Intern may acquire from the company or any of its dealings,
                    transactions or affairs which he may acquire or have gained knowledge during the course of and incidental to the Internship.</p><br />
                   <br />

                   <center> <p> <u><b> IT Department Acceptable Use Policy <br /></b></u> </p> </center><br />
                   <p>• Interns are responsible for exercising good judgment regarding the reasonableness of personal use. Individual departments are responsible for creating guidelines concerning personal use of Internet/Intranet/Extranet systems.<br />
                  • For security and network maintenance purposes, authorized individuals within Escalon may monitor equipment, systems and network traffic at any time, per IT Department's Audit Policy.<br />
                    • Under no circumstances is an Intern of Escalon authorized to engage in any activity that is illegal under local, state, federal or international law while utilizing Escalon-owned resources.<br />
                   •	Unauthorized copying of copyrighted material including, but not limited to, digitization and distribution of photographs from magazines, books or other copyrighted sources, copyrighted music, and the installation of any copyrighted software for which Escalon or the end user does not have an active license is strictly prohibited <br />
                    •	Revealing your account password to others or allowing use of your account by others. This includes family and other household members when work is being done at home.<br />
                   •	Providing information about, or lists of, Escalon employees to parties outside Escalon.<br />
                   •	The official sites and accounts like Skype, Outlook, and Share file, Basecamp or any other are not to be used for personal use. They are strictly to be used for official purpose.</p>
                    </table>
                   <b>Enforcement</b>
                   <p> Any Intern found to have violated this policy may be subject to disciplinary action, up to and including termination of Internship. The Company shall be entitled to initiate civil and criminal proceedings relevant under the Indian laws for the time being in force. </p>
                   <br />
                   <br />

                   <p> (Employee Signature)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                       (Employer Signature)</p>

                   <%--<p> For <b> Escalon Business Services Pvt Ltd </b></p>
        <p style="font-style:oblique"> Ritu Chitra</p>
        <p> <p> Ritu Chitra<br />
            <b> HR Manager</b>--%>
            </p>   </p>
                </div>
                 <br />
        <br />
        <br />
        <br />
                <center> <p> <P style="font-size:13px;text-align:center;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%">-------------------------------------------- Escalon Business Services Pvt Ltd. ------------------------------------------- <br />
          Office: D-151, 2nd Floor, Industrial Area, Phase 8 Mobile, Phone : 0172-5013839 Website:www.escalon.services
               </P></p></center>  
        <br />
        <br />
        <br />
        <br />
            </div>
      
        <br />
        <br />
        <br />



                    




    </form>
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
</body>
</html>
