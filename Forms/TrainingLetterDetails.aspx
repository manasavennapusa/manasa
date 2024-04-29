<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TrainingLetterDetails.aspx.cs" Inherits="Forms_TrainingLetterDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<style type="text/css">
    .auto-style1 {
        height: 20px;
    }
</style>
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
    
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <%--<link href="../icomoon/style.css" rel="stylesheet" />--%>
    <script src="js/popup1.js"></script>

    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <%--<link href="../css/nvd-charts.css" rel="stylesheet" />--%>

    <!-- Bootstrap css -->
    <%--<link href="../css/main.css" rel="stylesheet" />--%>

    <!-- fullcalendar css -->
    <%--<link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />--%>
    <%--<link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />--%>
    <script type="text/ecmascript">
        function hide() {
            var x = document.getElementById('btn_print');
            x.style.display = 'none';
            var y = document.getElementById('div_letter');
            y.style.display = 'block';
            var z = document.getElementById('btn_back');
            z.style.display = 'none';
            var e = document.getElementById('btn_export');
            e.style.display = 'none';
        }
        function show() {
            var y = document.getElementById('div_letter');
            y.style.display = 'block';
        }
    </script>
    <script src="js/validation.js"></script>

    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
        .btn {
    display: inline-block;
    *display: inline;
    /* IE7 inline-block hack */
    *zoom: 1;
    padding: 4px 12px;
    margin-bottom: 0;
    font-size: 14px;
    line-height: 20px;
    text-align: center;
    vertical-align: middle;
    cursor: pointer;
    color: #333333;
    text-shadow: 0 1px 1px rgba(255, 255, 255, 0.75);
    background-color: #e6e6e6;
    /* Fallback Color */
    background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#e6e6e6));
    /* Saf4+, Chrome */
    background-image: -webkit-linear-gradient(top, white, #e6e6e6);
    /* Chrome 10+, Saf5.1+, iOS 5+ */
    background-image: -moz-linear-gradient(top, white, #e6e6e6);
    /* FF3.6 */
    background-image: -ms-linear-gradient(top, white, #e6e6e6);
    /* IE10 */
    background-image: -o-linear-gradient(top, white, #e6e6e6);
    /* Opera 11.10+ */
    background-image: linear-gradient(top, white, #e6e6e6);
    background-repeat: repeat-x;
    border-color: #f0f0f0 #f0f0f0 #e6e6e6;
    border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
    border: 1px solid #f0f0f0;
    *border: 0;
    border-bottom-color: #e6e6e6;
    -webkit-border-radius: 2px;
    -moz-border-radius: 2px;
    border-radius: 2px;
    *margin-left: .3em;
    -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2) 0 1px 2px rgba(0, 0, 0, 0.05);
    -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2) 0 1px 2px rgba(0, 0, 0, 0.05);
    box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.2) 0 1px 2px rgba(0, 0, 0, 0.05);
}
        .btn-info {
    color: white;
    text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.25);
    background-color: #337ead;
    /* Fallback Color */
    background-image: -webkit-gradient(linear, left top, left bottom, from(#4a98c9), to(#337ead));
    /* Saf4+, Chrome */
    background-image: -webkit-linear-gradient(top, #4a98c9, #337ead);
    /* Chrome 10+, Saf5.1+, iOS 5+ */
    background-image: -moz-linear-gradient(top, #4a98c9, #337ead);
    /* FF3.6 */
    background-image: -ms-linear-gradient(top, #4a98c9, #337ead);
    /* IE10 */
    background-image: -o-linear-gradient(top, #4a98c9, #337ead);
    /* Opera 11.10+ */
    background-image: linear-gradient(top, #4a98c9, #337ead);
    border-color: #4a98c9 #4a98c9 #337ead;
    border-color: rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.1) rgba(0, 0, 0, 0.25);
}

    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="" style="margin-left: 0px; padding: 10px 0px 10px 0px; background-color: white; border-color: #1b478e">
            <div class="main-container" id="div_letter" runat="server">
                <div>
                    <table id="tbl_btn" runat="server" style="width: 90%; text-align: justify; margin: 10px 5px 10px 5px">
                        <tr>
                            <td>
                                <asp:Image ID="img_logo" runat="server" ImageUrl="~/images/Escalon_logo.png" Width="150px" />
                            </td>
                            <td>
                                <asp:Button ID="btn_back" runat="server" class="btn btn-info pull-right" Text="Back" title="Go Back" Style="margin-left: 10px" OnClick="btn_back_Click" />
                                &nbsp;&nbsp;
                                <asp:Button ID="btn_print" runat="server" OnClientClick="hide();window.print()" class="btn btn-info pull-right" Text="Print" />
                                &nbsp;&nbsp;
                                  <asp:Button ID="btn_export" runat="server" Text="Export To Word" title="Export to Word" OnClick="btn_export_Click" CssClass="btn btn-info" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 95%; text-align: justify; font: bold; font-size: 15px; font-weight: 500; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 800; text-decoration: underline">Training Letter
                            </td>
                        </tr>
                        <%-- <tr>
                            <td>
                                <asp:Label ID="txt_training_letter" runat="server" Style="border: none; text-decoration: underline; padding: 0px 0px 4px 3px" placeholder="Enter offer letter"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td><b>HR&nbsp;/&nbsp;<asp:Label ID="txt_hr_1" runat="server" Style="border: none; padding: 0px 0px 4px 3px"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_hr_2" runat="server" Style="border: none; padding: 0px 0px 4px 3px"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_training_letter" runat="server" Style="border: none; padding: 0px 0px 4px 3px"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 600">Date&nbsp;<asp:Label ID="txt_date" runat="server" Style="border: none; padding: 0px 0px 4px 3px" placeholder="Enter date"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Mr.<asp:Label ID="txt_emp_name" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 600">
                                <asp:Label ID="txt_address" runat="server" Style="border: none; padding: 0px 0px 3px 0px" Width="170px"></asp:Label>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Dear
                                <asp:Label ID="txt_employee_name" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>In reference to your application we would like to congratulate you on being selected for internship with <b>Escalon Business Services Pvt Ltd.</b> based at <b>Mohali - Punjab.</b> Your internship is scheduled to start effective&nbsp;<asp:Label ID="txt_effective_date" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>&nbsp;for a period of &nbsp;<asp:Label ID="txt_period_of" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>.&nbsp; All of us at Escalon are excited that you will be joining our team!<br />
                                As such, your internship will include training/orientation and focus primarily on learning and developing new skills and gaining a deeper understanding of concepts through hands-on application of the knowledge you learned in class.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>The project details and technical platform will be shared with you during your internship period 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>You should report for training at the following address:
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <%--<b>Escalon Business Services Pvt Ltd.</b><br />Phase 8A SP Info city <br />2nd Floor--%>
                                <table cellspacing="0" cellpadding="0" style="font-size: 15px">
                                    <tr>
                                        <td><b>Escalon Business Services Pvt Ltd.</b></td>
                                    </tr>
                                    <tr>
                                        <td>Phase 8A SP Info city</td>
                                    </tr>
                                    <tr>
                                        <td>2nd Floor</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <b>Contact Person / Reporting Manager Name:</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>We expect you to perform the activities and achieve the learning objectives as proposed in the Schedule below to the best of your ability and to maintain appropriate standards of behaviour at all times. We will also expect you to comply with our rules, policies, procedures, standards and instructions. 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>For <b>Escalon Business Services Pvt Ltd</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-family: Brush Script MT; font-size: 20px">Ritu Chitra
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>Ritu Chitra
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify; font: bold; font-size: 15px; font-weight: 700;">HR Manager 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right">Page-1
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: justify; font: bold; font-size: 15px; font-weight: 700;">Important Points: 
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>1. <b>National Holidays:</b> The Intern will be entitled for the national holidays as per the list published by the HR for the FY&nbsp;<asp:Label ID="txt_financial_year" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>&nbsp;.
                            </td>
                        </tr>
                        <tr>
                            <td>2. <b>Company Property:</b> The Intern will maintain the good decorum in the office and will maintain in good condition company property, which may be entrusted for official purpose during the course of internship. 
                            </td>
                        </tr>
                        <tr>
                            <td>3. <b>Stipend:</b> Your internship is a voluntary activity and we will provide you’re with Rs&nbsp;<asp:Label ID="txt_stipend_amount" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>&nbsp;as a stipend for the course of your internship.
                            </td>
                        </tr>
                        <tr>
                            <td>4. <b>NON-DISCLOSURE OF INFORMATION:</b> The Intern understands and agree that she shall not, at any time during the continuance or after the termination of the internship hereunder, divulge either directly or indirectly to any person, firm or Company or use for himself or for another any knowledge, information, end-customer information (names, personal or financial information), formulae, processes, methods, compositions, ideas or documents, concerning the business and affairs of the company or any of its dealings, transactions or affairs which the Intern may acquire from the company or any of its dealings, transactions or affairs which he may acquire or have gained knowledge during the course of and incidental to the Internship.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; font-size: 15px; font-weight: 700;">IT Department Acceptable Use Policy 
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>• Interns are responsible for exercising good judgment regarding the reasonableness of personal use. Individual departments are responsible for creating guidelines concerning personal use of Internet/Intranet/Extranet systems.
                            </td>
                        </tr>
                        <tr>
                            <td>• For security and network maintenance purposes, authorized individuals within Escalon may monitor equipment, systems and network traffic at any time, per IT Department's Audit Policy.
                            </td>
                        </tr>
                        <tr>
                            <td>• Under no circumstances is an Intern of Escalon authorized to engage in any activity that is illegal under local, state, federal or international law while utilizing Escalon-owned resources.
                            </td>
                        </tr>
                        <tr>
                            <td>• Unauthorized copying of copyrighted material including, but not limited to, digitization and distribution of photographs from magazines, books or other copyrighted sources, copyrighted music, and the installation of any copyrighted software for which Escalon or the end user does not have an active license is strictly prohibited 
                            </td>
                        </tr>
                        <tr>
                            <td>• Revealing your account password to others or allowing use of your account by others. This includes family and other household members when work is being done at home.
                            </td>
                        </tr>
                        <tr>
                            <td>• Providing information about, or lists of, Escalon employees to parties outside Escalon.
                            </td>
                        </tr>
                        <tr>
                            <td>• The official sites and accounts like Skype, Outlook, and Share file, Basecamp or any other are not to be used for personal use. They are strictly to be used for official purpose.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td style="font-size: 15px; font-weight: 700;">Enforcement 
                            </td>
                        </tr>
                        <tr>
                            <td>Any Intern found to have violated this policy may be subject to disciplinary action, up to and including termination of Internship. The Company shall be entitled to initiate civil and criminal proceedings relevant under the Indian laws for the time being in force.
                            </td>
                        </tr>

                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                    </table>

                    <table style="width: 90%; text-align: justify; margin: 10px 5px 10px 15px">
                        <tr>
                            <td style="font-size: 15px; font-weight: 600; width: 45%; text-align: left">(Employee Signature)
                            </td>
                            <td style="font-size: 15px; font-weight: 600; width: 45%; text-align: right">(Employer Signature)
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 95%; text-align: center; font: bold; font-family: Verdana; font-size: 15px; font-weight: 700; margin: 10px 5px 10px 15px">
                        <tr>
                            <td>-------------------- Escalon Business Services Pvt Ltd. --------------------
                            </td>
                        </tr>
                        <tr>
                            <td>Office: D-151, 2nd Floor, Industrial Area, Phase 8 Mohali, Phone : 0172-5013839 Website:www.escalon.services

                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td>
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 95%; margin: 10px 5px 10px 15px; text-align: right">
                        <tr>
                            <td>Page-2
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </form>

    <script src="../js/analytics.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>
</body>
</html>
