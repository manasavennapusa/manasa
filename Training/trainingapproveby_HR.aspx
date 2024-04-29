<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trainingapproveby_HR.aspx.cs" Inherits="Training_trainingapproveby_HR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

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

    <script src="../js/html5-trunk.js"></script>
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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>View Training</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="List Of Employees"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">                              
                                <div>
                                    <table width="100%" class="table table-condensed table-striped  table-bordered ">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Training Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">Training Code</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lbltrainingcode" runat="server"></asp:Label>
                                                        </td>

                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Module Name</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblmodulename" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123">Training Type</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lbltrainintype" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">From Date</td>
                                                        <td class="frm-rght-clr123 ">
                                                            <asp:Label ID="lblfromdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  ">Department Name</td>
                                                        <td class="frm-rght-clr123  ">
                                                            <asp:Label ID="lbldepartmentname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Training Name</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lbltrainingname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Faculty Name</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblfacultyname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123  border-bottom">Training ShortName</td>
                                                        <td class="frm-rght-clr123  border-bottom">
                                                            <asp:Label ID="lbltrainingshortname" runat="server"></asp:Label></td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123">To Date</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lbltodate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123">Branch Name</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblbranchname" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                                                                                                                           
                                    <%--<table width="100%" class="table table-condensed table-striped  table-bordered ">
                                        <tr>
                                            <td align="left" class="txt02" colspan="2" style="height: 20px"><strong>Current Increment Details</strong></td>
                                        </tr>
                                        <tr>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123" style="width: 40%;">Revised Location</td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblrevloc" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Department</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdept" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Designation</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdes" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr id="Tr1" style="height: 36px"  visible="false" runat="server">
                                                        <td class="frm-lft-clr123 ">Revised Grade</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevgrade" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised Cost Center</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevcostcenter" runat="server">
                                                            </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>

                                            <td style="width: 50%; vertical-align: top">
                                                <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                    <tr style="height: 36px">

                                                        <td class="frm-lft-clr123 " style="width: 40%">Hike(%) </td>
                                                        <td class="frm-rght-clr123" width="60%">
                                                            <asp:Label ID="lblcurhike" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Increased Amount</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblincramount" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Current CTC/PA</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcurctc" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Current Bonus</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblcurbonus" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 36px">
                                                        <td class="frm-lft-clr123 ">Revised W.E.F</td>
                                                        <td class="frm-rght-clr123">
                                                            <asp:Label ID="lblrevdate" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>

                                                </table>
                                            </td>
                                        </tr>
                                    </table>--%>                                   
                                    
                                    <div class="clearfix">
                                        <div class="form-actions no-margin" id="div_btn" runat="server">
                                            <asp:Button ID="btnapprove" runat="server" CssClass="btn btn-success" Text="Approve" OnClick="btnapprove_Click" ValidationGroup="r" />
                                            <asp:Button ID="btnreject" runat="server" CssClass="btn btn-danger" Text="Reject" OnClick="btnreject_Click" ValidationGroup="r" />
                                           <%-- <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" CausesValidation="false" Text="Back" OnClick="btnBack_Click" />
                                            <asp:HiddenField ID="hdnassid" runat="server" />--%>
                                        </div>
                                    </div>

                                </div>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>                    
                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>
        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gveligible').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
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




