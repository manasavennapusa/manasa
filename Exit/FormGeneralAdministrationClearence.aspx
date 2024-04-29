<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormGeneralAdministrationClearence.aspx.cs" Inherits="Exit_FormGeneralAdministrationClearence" %>

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
    <title>SmartDrive Labs</title>

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


</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <%--<script type="text/javascript">
             function Validate() {
                 var obj = document.getElementById('<%= Others.ClientID%>');
                if (obj.value == "") {
                    alert('Please enter required field.');
                    obj.focus();
                    return false;
                }
                else
                    return true;
            }
        </script>--%>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>General Administration Clearance</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name:</label>
                                        <div class="controls">
                                            <asp:Label ID="EmpName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Code:</label>
                                        <div class="controls">
                                            <asp:Label ID="EmpCode" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Department:</label>
                                        <div class="controls">
                                            <asp:Label ID="Department" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date of Joining:</label>
                                        <div class="controls">
                                            <asp:Label ID="DOJ" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date of Resignation:</label>
                                        <div class="controls">
                                            <asp:Label ID="DOR" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Last Working Day:</label>
                                        <div class="controls">
                                            <asp:Label ID="LWD" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Permanent Address:</label>
                                        <div class="controls">
                                            <asp:Label ID="PA" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal Mobile Number:</label>
                                        <div class="controls">
                                            <asp:Label ID="PMN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal Email Id:</label>
                                        <div class="controls">
                                            <asp:Label ID="PEI" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    General Administration Clearance Form
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Keys Returned Number</label>
                                        <div class="controls">
                                            <input type="radio" name="KeysReturnedNumber" id="KeysReturnedNumberYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp; 
                                            <input type="radio" name="KeysReturnedNumber" id="KeysReturnedNumberNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="KeysReturnedNumber" id="KeysReturnedNumberNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                            <asp:TextBox ID="Key" runat="server" CssClass="span2"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Mobile Phone Returned With Charger</label>
                                        <div class="controls">
                                            <input type="radio" name="MobilePhoneReturnedWithCharger" id="MobilePhoneReturnedWithChargerYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="MobilePhoneReturnedWithCharger" id="MobilePhoneReturnedWithChargerNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="MobilePhoneReturnedWithCharger" id="MobilePhoneReturnedWithChargerNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Data Card Returned</label>
                                        <div class="controls">
                                            <input type="radio" name="DataCardReturned" id="DataCardReturnedYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="DataCardReturned" id="DataCardReturnedNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="DataCardReturned" id="DataCardReturnedNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">SIM Card Returned</label>
                                        <div class="controls">
                                            <input type="radio" name="SIMCardReturned" id="SIMCardReturnedYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="SIMCardReturned" id="SIMCardReturnedNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="SIMCardReturned" id="SIMCardReturnedNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Returned Identity & Access Badge</label>
                                        <div class="controls">
                                            <input type="radio" name="ReturnedIdentityAccessBadge" id="ReturnedIdentityAccessBadgeYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReturnedIdentityAccessBadge" id="ReturnedIdentityAccessBadgeNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReturnedIdentityAccessBadge" id="ReturnedIdentityAccessBadgeNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Others(Specify)</label>
                                        <div class="controls">
                                            <asp:TextBox ID="Others" runat="server" CssClass="span4" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="txtrequired" runat="server" ControlToValidate="Others" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <script type="text/javascript">
                                        function isKey(keyCode) {
                                            return false;
                                        }
                                    </script>
                                    <div class="control-group" style="display:none;">
                                        <label class="control-label">Date Of Clearance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="DateOfClearence" runat="server" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11" TargetControlID="DateOfClearence" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click" ValidationGroup="g" Visible="false"/>
                                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary" Text="Approve" OnClick="btnApprove_Click" ValidationGroup="g"/>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Reject" OnClick="btnCancel_Click" />
                                    </div>
                                </fieldset>
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
                $('#grdstaytype').dataTable({
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




