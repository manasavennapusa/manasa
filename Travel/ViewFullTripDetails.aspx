<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFullTripDetails.aspx.cs" Inherits="Travel_ViewFullTripDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script type="text/javascript" src="js/timepicker.js"></script>
    <script src="../js/JavaScriptValidations.js"></script>
    <script type="text/javascript">
        function RefreshParent() {

            if (window.opener != null && !window.opener.closed) {
                window.opener.location.reload();
                window.close();
            }
        }
        //window.onbeforeunload = RefreshParent;
        function ClosePopup()
        { window.close(); }
    </script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">

        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header" runat="server" visible="false">
                    <div class="pull-left">
                        <h2>
                            <asp:Label ID="lblheader" runat="server" Text="View/Edit Trip Details"></asp:Label></h2>
                    </div>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid" id="divTrip" runat="server">
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Trip Details
                                       
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <table style="width: 100%">
                                        <tr>
                                            <td class="frm-lft-clr123">Travel Type</td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="ddl_traveltype" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" style="width: 44%">Date Of Departure</td>
                                            <td class="frm-rght-clr123" style="width: 54%">
                                                <asp:Label ID="lbldepartdate" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>

                                            <td class="frm-lft-clr123">Time Of Departure </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbldeparttime" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">From</td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_source" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom">Employee Comments</td>
                                            <td class="frm-rght-clr123 border-bottom">
                                                <asp:Label ID="lblEmpCommets" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123">Stay Accommodation</td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_stayType" runat="server">
                                                </asp:Label>

                                            </td>
                                        </tr>


                                        <tr>
                                            <td class="frm-lft-clr123" width="44%">Date Of Arrival</td>
                                            <td class="frm-rght-clr123" width="55%">
                                                <asp:Label ID="lblarvlDate" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">Time Of Arrival</td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lblArvlTime" runat="server"></asp:Label>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">To
                                            </td>
                                            <td class="frm-rght-clr123">
                                                <asp:Label ID="lbl_destination" runat="server">
                                                </asp:Label>
                                            </td>
                                        </tr>

                                        <tr>
                                            <td class="frm-lft-clr123">Airlines Member Ship?</td>
                                            <td class="frm-rght-clr123">
                                                <asp:RadioButtonList ID="rbtnl_airlinems" runat="server" RepeatDirection="Horizontal" Enabled="false" CssClass="radio inline" CellPadding="10" Height="25px">
                                                    <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <br />
                                                <asp:Label ID="lblairlinedetails" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123  border-bottom">Hotel Member Ship?</td>
                                            <td class="frm-rght-clr123 border-bottom">

                                                <asp:RadioButtonList ID="rbtnl_hotelms" runat="server" Enabled="false" RepeatDirection="Horizontal" CssClass="radio inline" CellPadding="10" Height="25px">
                                                    <asp:ListItem Value="true">Yes &nbsp;&nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="false" Selected="True">No</asp:ListItem>
                                                </asp:RadioButtonList>
                                                <br />
                                                <asp:Label ID="lblhoteldetails" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>Expense Details
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <table style="width: 100%">
                                    <tr>
                                        <td style="vertical-align: top; width: 100%">
                                            <table style="width: 100%">
                                                <tr>
                                                    <td colspan="2" height="30px" class="txt02">Travel</td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123" style="width: 44%">Ticket Booked</td>
                                                    <td class="frm-rght-clr123">
                                                        <table class="radio inline">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rbtnl" runat="server" Width="100px" RepeatDirection="Horizontal" Enabled="false">
                                                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>

                                                <tr id="trticketadv" runat="server">
                                                    <td class="frm-lft-clr123">Advance Amount</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lblticketAdvcurrency" runat="server">
                                                        </asp:Label>
                                                        <asp:Label ID="txtticketAdv" runat="server"></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr id="trticket1" runat="server" visible="false">

                                                    <td class="frm-lft-clr123">Tier </td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="ddl_tier" runat="server">
                                                        </asp:Label>

                                                    </td>
                                                </tr>
                                                <tr id="trticket2" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Mode</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="ddl_mode" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trticket3" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Class</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="ddl_modeClass" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trticket4" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Fare</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="lbl_fareCurrecny" runat="server" Width="34%">
                                                        </asp:Label>
                                                        <asp:Label ID="txtticketfair" runat="server"></asp:Label>

                                                    </td>
                                                </tr>
                                                <tr id="trticket5" runat="server" visible="false">
                                                    <td class="frm-lft-clr123" style="width: 44%">Ticket Upload</td>
                                                    <td class="frm-rght-clr123" style="width: 54%">
                                                        <a id="hrefticket" runat="server" class="link05">
                                                            <asp:Label ID="lblviewticket" runat="server"></asp:Label></a>
                                                    </td>
                                                </tr>
                                                <tr id="trticket6" runat="server">
                                                    <td class="frm-lft-clr123" style="width: 44%">Boarding Pass Collected</td>
                                                    <td class="frm-rght-clr123" style="width: 54%">
                                                        <asp:CheckBox ID="chkpass" runat="server" Width="90%" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                </tr>
                                                <tr style="display: none">
                                                    <td class="frm-lft-clr123" style="width: 44%">Exception</td>
                                                    <td class="frm-rght-clr123" style="width: 54%">
                                                        <asp:CheckBox ID="chkException" runat="server" Width="90%" Enabled="false"></asp:CheckBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom">Admin Comments</td>
                                                    <td class="frm-rght-clr123 border-bottom">
                                                        <asp:Label ID="txtAdminComments" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table style="width: 100%;" align=" right">
                                                <tr>
                                                    <td height="30px" colspan="2" class="txt02">Stay Details</td>

                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 5px"></td>
                                                </tr>

                                                <tr>
                                                    <td class="frm-lft-clr123">Lodge Booked</td>
                                                    <td class="frm-rght-clr123">
                                                        <table class="radio inline">
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButtonList ID="rbtnl_lodge" runat="server" Width="100px" RepeatDirection="Horizontal" Enabled="false">
                                                                        <asp:ListItem Value="True">Yes</asp:ListItem>
                                                                        <asp:ListItem Value="False" Selected="True">No</asp:ListItem>
                                                                    </asp:RadioButtonList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr id="trlodge" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Fare</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtlodgefare" runat="server"></asp:Label>
                                                        <asp:Label ID="ddl_stayCurrency" runat="server">
                                                        </asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="trlodge2" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Address</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txtLodgeAddress" runat="server"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr>
                                                    <td colspan="2" class=" border-bottom"></td>
                                                </tr>
                                                <tr id="trlodgeAdv" runat="server" visible="false">
                                                    <td class="frm-lft-clr123">Advance Amount</td>
                                                    <td class="frm-rght-clr123">
                                                        <asp:Label ID="txt_lodgeAdv" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>

                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>

                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14b;"></span>View Ticket
                                </div>
                            </div>
                            <div class="widget-body">
                                <div class="example_alt_pagination">
                                    <iframe name="content" frameborder="0" width="100%" height="500px" ></iframe>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="form-actions no-margin" style="text-align: right;">
                    <asp:Button ID="btnCancelTripDetails" runat="server" CssClass="btn"
                        Text="Cancel" OnClientClick="ClosePopup();" />
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
                $('#Grid_Emp').dataTable({
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
