<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewTripDetails.aspx.cs" Inherits="Travel_ViewTripDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">
    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">

        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                

         <%--   <div class="row-fluid" id="empdetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span4" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label1" runat="server" Text="Employee Details"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 100%">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Employee Code

                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 60%">
                                                                    <asp:Label ID="lblempcode" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Employee Name
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lblempname" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Grade
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lblgrade" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Designation
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lbldesingantion" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 99%" align="right">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Location
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 60%">
                                                                    <asp:Label ID="lbllocation" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Department
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lbldept" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">Reporting Manager
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblmgr" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 33%; vertical-align: top">
                                                        <table style="width: 99%" align="right">
                                                            <tr>
                                                                <td class="frm-lft-clr123" style="width: 40%">Cost Center
                                                                </td>
                                                                <td class="frm-rght-clr123" style="width: 60%">
                                                                    <asp:Label ID="Label9" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123">Bank Account No.
                                                                </td>
                                                                <td class="frm-rght-clr123">
                                                                    <asp:Label ID="lblbank" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="frm-lft-clr123 border-bottom">ACCPAC Code
                                                                </td>
                                                                <td class="frm-rght-clr123 border-bottom">
                                                                    <asp:Label ID="lblaccpac" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="traveldetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label2" runat="server" Text="Travel Details"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <table style="width: 100%">
                                                <tr style="height: 40px;">
                                                    <td class="frm-lft-clr123" style="width: 20%">Travel Code
                                                    </td>
                                                    <td class="frm-rght-clr123" style="width: 80%">
                                                        <asp:Label ID="lbltravelCode" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="frm-lft-clr123 border-bottom" style="width: 20%">Travel Purpose
                                                    </td>
                                                    <td class="frm-rght-clr123 border-bottom" style="width: 80%">
                                                        <asp:Label ID="lblTravelPurpose" runat="server"></asp:Label>

                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="miscellaneousdetails" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label5" runat="server" Text="Miscellaneous Allowance"></asp:Label>
                                        </div>

                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            
                                           
                                            <div style="height: 40px; float: right"></div>
                                            <div id="dt_example1" class="example_alt_pagination">
                                                <asp:GridView ID="grid_Advance" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                    EmptyDataText="No Data Exists" DataKeyNames="id" OnPreRender="grid_Advance_PreRender">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Description" HeaderStyle-Width="40%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("advance_desc")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Currency" HeaderStyle-Width="15%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblCurrency" runat="server" Text='<%#Eval("currencycode")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount" HeaderStyle-Width="30%">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblAmount" runat="server" Text='<%#Eval("amount")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <div class="clearfix"></div>
                                            </div>

                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="Label3" runat="server" Text="Trip Details"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <table style="width: 100%">
                                        <tr>
                                            <td style="vertical-align: top; width: 50%">
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
                                                    <tr >
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
                                                </table>
                                            </td>
                                            <td style="vertical-align: top; width: 50%">
                                                <table style="width: 99%;" align="right">
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
                                                    <tr >
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
                                            </td>
                                        </tr>
                                    </table>
                            </div>

                            <div class="clearfix"></div>
                             <div class="form-actions no-margin" style="text-align: right">
                <asp:Button ID="btnclose" runat="server" CssClass="btn btn-primary" CausesValidation="false"
                    Text="Close" OnClientClick="window.close();"/>
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
                $('#Grid_Emp').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Approvers').dataTable({
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
