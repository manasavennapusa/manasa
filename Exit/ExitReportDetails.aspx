<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExitReportDetails.aspx.cs" Inherits="Exit_ExitReportDetails" %>

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
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>ESCALON BUSINESS SERVICE PRIVATE LIMITED</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
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
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <%--<script type="text/javascript">
        function Validate() {

            var Comments = document.getElementById("txtComments");
            if (Comments.value.trim() == "") {
                Comments.focus();
                alert("Please enter your comments.");
                return false;
            }

            return true;
        }

    </script>--%>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee Resignation Detail</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;" runat="server">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    View
                                </div>
                                <div style="text-align: right;">
                                    <asp:Button ID="btnprint" runat="server" CssClass="btn btn-primary" Text="Print" OnClientClick="hide(); window.print()"/>
                                
                                <asp:Button ID="back" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="back_Click" OnClientClick="hide();"/>
                                    </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <asp:HiddenField ID="EmployeeTypeId" runat="server"></asp:HiddenField>
                                    <div class="control-group">
                                        <label class="control-label">Applied Date and Time:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lblAppliedDate" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Type:</label>
                                        <div class="controls" style="padding-top:6px">

                                            <asp:Label ID="lblEmployeeType" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Notice Period:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lblNoticePeriod" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Default Last Working Day:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lblDLWD" runat="server" CssClass="span4"></asp:Label>
                                            
                                        </div>
                                    </div>
                                    <div class="control-group" id="LWD" runat="server">
                                        <label class="control-label">New Last Working Day:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:TextBox ID="NewLWD" runat="server" CssClass="span4"></asp:TextBox>
                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11" TargetControlID="NewLWD" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Comments:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lblComments" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group" id="CommentBox" runat="server" style="display: none">
                                        <label class="control-label">Comments:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:TextBox ID="txtComments" TextMode="MultiLine" Rows="8" MaxLength="8000" runat="server" CssClass="span8"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">LM/DLM Comments:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lbllmcomments" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">BH Comments:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lblbhcomments" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Exit Interview Questionarie</label>
                                        <div class="controls" style="padding-top:6px">
                                            <table>
                                                <tr>
                                                    <td id="lbl1" runat="server">
                                                        <asp:Label runat="server" ID="iblreason1" Visible="true" style="border-right:1px solid; padding-right:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl2" runat="server">
                                                        <asp:Label runat="server" ID="iblreason2" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl3" runat="server">
                                                        <asp:Label runat="server" ID="iblreason3" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl4" runat="server">
                                                        <asp:Label runat="server" ID="iblreason4" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl5" runat="server">
                                                        <asp:Label runat="server" ID="iblreason5" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                               
                                                    <td id="lbl6" runat="server">
                                                        <asp:Label runat="server" ID="iblreason6" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl7" runat="server">
                                                        <asp:Label runat="server" ID="iblreason7" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td id="lbl8" runat="server">
                                                        <asp:Label runat="server" ID="iblreason8" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                     
                                                    <td id="lbl9" runat="server">
                                                        <asp:Label runat="server" ID="iblreason9" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl10" runat="server">
                                                        <asp:Label runat="server" ID="iblreason10" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                
                                                    <td id="lbl11" runat="server">
                                                        <asp:Label runat="server" ID="iblreason11" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl12" runat="server">
                                                        <asp:Label runat="server" ID="iblreason12" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl13" runat="server">
                                                        <asp:Label runat="server" ID="iblreason13" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl14" runat="server">
                                                        <asp:Label runat="server" ID="iblreason14" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    </tr>
                                                <tr>
                                                    <td id="lbl15" runat="server">
                                                        <asp:Label runat="server" ID="iblreason15" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td >
                                                
                                                    <td id="lbl16" runat="server">
                                                        <asp:Label runat="server" ID="iblreason16" Visible="true" style="border-right:1px solid; padding-right:3px; padding-left:4px"></asp:Label>
                                                    </td>
                                                    <td id="lbl17" runat="server">
                                                        <asp:Label runat="server" ID="iblreason17" Visible="true" ></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">HR Comments:</label>
                                        <div class="controls" style="padding-top:6px">
                                            <asp:Label ID="lblhrcomments" runat="server" CssClass="span4"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>

                <br />


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

       <%-- <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grdstaytype').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>--%>

        <script type="text/javascript">
            function hide() {
                var x = document.getElementById('btnprint');
                var y = document.getElementById('back');
                x.style.display = 'none';
                y.style.display = 'none';
                
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