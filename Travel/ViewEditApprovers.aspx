<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewEditApprovers.aspx.cs" Inherits="Travel_ViewEditApprovers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="utf-8" content="" />
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
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
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee Profile</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid" id="tripdetails" runat="server">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="Label3" runat="server" Text="Employee Details"></asp:Label>

                                </div>

                            </div>
                            <div class="widget-body">

                                <div id="dt_example" class="example_alt_pagination">

                                    <asp:GridView ID="empgird" runat="server" CssClass="table table-condensed table-striped  table-bordered pull-left" DataKeyNames="empcode"
                                        AutoGenerateColumns="False" EmptyDataText="Sorry no record found" OnPreRender="empgird_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code"
                                                HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="25%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("EmpName") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="22%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department" HeaderStyle-Width="22%">
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="15%"  HeaderText="View" >
                                                <ItemTemplate>
                                                    <a href="EditEmployeeApprover.aspx?id=<%#DataBinder.Eval(Container.DataItem, "empcode")%>" class="link05">View </a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>

                                    </asp:GridView>
                                    <div class="clearfix"></div>
                                </div>

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
                $('#empgird').dataTable({
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
