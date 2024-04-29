<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IncrementLetterDetails.aspx.cs" Inherits="Forms_IncrementLetterDetails" EnableEventValidation="false" %>

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
    <%--link href="../icomoon/style.css" rel="stylesheet" />--%>
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
   <%-- <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />--%>
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
        <div id="dv_content" runat="server" style="margin-left: 0px;padding:10px 0px 10px 0px;background-color:white;border-color:#1b478e">
            <div class="main-container" id="div_letter" runat="server">
                <div>
                    &nbsp;<table id="tbl_btn" runat="server" style="width: 90%; text-align: justify; margin: 5px 5px 10px 5px">
                        <tr>
                            <td>
                                <asp:Image ID="img_logo" runat="server" ImageUrl="~/images/Escalon_logo.png" Width="150px" />
                            </td>
                            <td>
                                <asp:Button ID="btn_back" runat="server" class="btn btn-info pull-right" Text="Back" title="Go Back" style="margin-left:10px" OnClick="btn_back_Click" />&nbsp;&nbsp;
                                <asp:Button ID="btn_print" runat="server" OnClientClick="hide();window.print()" class="btn btn-info pull-right" Text="Print" />&nbsp;&nbsp;
                                <asp:Button ID="btn_export" runat="server" Text="Export To Word" title="Export to Word" OnClick="btn_export_Click" CssClass="btn btn-info" />&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <table style="width: 95%; text-align: justify; font: bold; font-size: 15px; font-weight: 500; margin: 15px 5px 10px 15px">
                        <tr>
                            <td style="font: bold; font-size: 14px; font-weight: 800;text-decoration:underline">Increment Letter
                            </td>
                        </tr>
                        <%--<tr>
                            <td style="font: bold; font-size: 15px; font-weight: 600">
                                <asp:Label ID="txt_increment_letter" runat="server" Style="border: none;padding: 0px 0px 4px 3px" placeholder="Enter offer letter"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>

                            </td>
                        </tr>
                        <tr>
                          <td><b>HR&nbsp;/&nbsp;<asp:Label ID="txt_hr_1" runat="server" Style="border: none;padding: 0px 0px 4px 3px"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_hr_2" runat="server" Style="border: none;padding: 0px 0px 4px 3px"></asp:Label>&nbsp;/&nbsp;<asp:Label ID="txt_increment_letter" runat="server" Style="border: none;padding: 0px 0px 4px 3px" placeholder="Enter offer letter"></asp:Label></b>
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
                            <td style="font: bold; font-size: 15px; font-weight: 600">
                                Name&nbsp;:&nbsp;<asp:Label ID="txt_emp_name" runat="server" Style="border: none;padding: 0px 0px 3px 3px"></asp:Label>                            
                            </td>
                        </tr>
                         <tr>
                            <td style="font: bold; font-size: 15px; font-weight: 600">
                                Department&nbsp;:&nbsp;<asp:Label ID="txt_department" runat="server" Style="border: none; padding: 0px 0px 3px 3px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                 
                       <tr>
                            <td>
                                <b>Greetings!!</b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                               <br />
                            </td>
                        </tr>
                        <tr>
                            <td><b>Dear
                                <asp:Label ID="txt_employee_name" runat="server" Style="border: none;padding: 0px 0px 3px 3px"></asp:Label> </b>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td>
            Escalon has continued to build an organization that is engaged and collaborative and these efforts are having a positive impact on employee satisfaction.  Escalon as an organization continues to offer a progressive career path. We will endeavour to ensure deep levels of employee engagements across the organization in future too. We are also keen to continually recognize and nurture outstanding talent in our organization.
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                We are pleased to have you successful completion of&nbsp;FY&nbsp;<asp:Label ID="txt_financial_year" runat="server" Style="border: none;padding: 0px 0px 3px 3px"></asp:Label>&nbsp;performance review process with Escalon Business Services. Thank you for contributing.  
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td>
                               <table style="width:100%;font: bold; font-size: 15px; font-weight: 600;border:1px solid #808080;border-bottom:none" cellspacing="0" cellpadding="0">
                                   <tr>
                                       <td style="width:40%;padding:7px 3px 7px 3px;border-right:1px solid #808080">

                                       </td>
                                       <td style="width:60%;text-align:center;padding:7px 3px 7px 3px;">
                                           Annual Compensation INR
                                       </td>
                                   </tr>
                               </table>
                                <table style="width:100%;font: bold; font-size: 15px; font-weight: 500;border:1px solid #808080" cellspacing="0" cellpadding="0">
                                   <tr>
                                       <td style="width:40%;border-bottom:none;border-right:1px solid #808080;padding:7px 3px 7px 63px;text-align:justify">
                                            A) Annual fixed compensation
                                       </td>
                                       <td style="width:30%;border-right:1px solid #808080;border-bottom:1px solid #808080;padding:7px 3px 7px 23px">
                                           <asp:Label ID="txt_annual_fixed_compensation" runat="server"></asp:Label>
                                       </td>
                                       <td style="width:30%;border-bottom:1px solid #808080;padding:7px 3px 7px 23px">
                                            <asp:Label ID="txt_annual_fixed_compensation_1" runat="server"></asp:Label>
                                       </td>
                                   </tr>
                                    <tr>
                                       <td style="width:40%;border-bottom:none;border-right:1px solid #808080;padding:7px 3px 7px 63px;text-align:justify">
                                            B) Variable
                                       </td>
                                       <td style="width:30%;border-right:1px solid #808080;border-bottom:none;padding:7px 3px 7px 23px">
                                            <asp:Label ID="txt_variables" runat="server"></asp:Label>
                                       </td>
                                       <td style="width:30%;border-bottom:none;padding:7px 3px 7px 23px">
                                           <asp:Label ID="txt_variables_1" runat="server"></asp:Label>
                                       </td>
                                   </tr>
                                    <tr>
                                       <td style="width:40%;border-bottom:none;border-right:1px solid #808080;border-top:1px solid #808080;padding:15px 3px 15px 3px;">
                                         
                                       </td>
                                       <td style="width:30%;border-bottom:none;border-right:1px solid #808080;border-top:1px solid #808080;padding:15px 3px 15px 3px;">

                                       </td>
                                       <td style="width:30%;border-bottom:none;border-right:none;border-top:1px solid #808080;padding:15px 3px 15px 3px;">

                                       </td>
                                   </tr>
                                    <tr>
                                       <td style="width:40%;border-bottom:none;border-right:1px solid #808080;border-top:1px solid #808080;padding:7px 3px 7px 43px;font-size: 15px; font-weight: 600;">
                                          Total Earnings (A+B)  
                                       </td>
                                       <td style="width:30%;border-right:1px solid #808080;border-bottom:none;border-top:1px solid #808080;padding:7px 3px 7px 23px;font-size: 15px; font-weight: 600;">
                                            <asp:Label ID="txt_result" runat="server"></asp:Label>
                                       </td>
                                       <td style="width:30%;padding:7px 3px 7px 23px;border-bottom:none;border-top:1px solid #808080;font: bold; font-size: 13px; font-weight: 600;">
                                              <asp:Label ID="txt_result_1" runat="server"></asp:Label>
                                       </td>
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
                                We wish you all the best and take this opportunity to welcome you to continue this journey of success with us.
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                For <b>Escalon Business Services Pvt Ltd </b>
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td style="font-family: Brush Script MT;font-size:20px">
                                Ritu Chitra
                            </td>
                        </tr>
                         <tr>
                            <td>
                                <br />
                            </td>
                        </tr>
                         <tr>
                            <td>
                                 Ritu Chitra
                            </td>
                        </tr>
                         <tr>
                            <td style="font-size: 15px; font-weight: 600;">
                                HR Manager 
                            </td>
                        </tr>
                        </table>
                      <table><tr><td></td></tr></table>
                    <table style="width: 99%; text-align: center; font: bold; font-family: Verdana; font-size: 15px; font-weight: 800; margin: 0px 5px 10px 15px">
                        <tr>
                            <td>------------------------- Escalon Business Services Pvt Ltd. -------------------------
                            </td>
                        </tr>
                        <tr>
                            <td>Office: D-151, 2nd Floor, Industrial Area, Phase 8 Mohali, Phone : 0172-5013839 Website:www.escalon.services

                            </td>
                        </tr>
                    </table>
                     <table><tr><td><br /></td></tr></table>
                    <table style="width: 95%;margin: 0px 5px 10px 15px;text-align:right">
                        <tr>
                            <td>Page-1
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
