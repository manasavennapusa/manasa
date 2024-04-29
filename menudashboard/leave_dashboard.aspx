<%@ Page Language="C#" AutoEventWireup="true" CodeFile="leave_dashboard.aspx.cs" Inherits="menudashboard_leave_dashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <!-- Required meta tags -->
    <meta charset="utf-8" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <title>SmartDrive Labs Technologies India Pvt. Ltd.</title>
    <link href="../css/dashboardcss/animate.css" rel="stylesheet" />
    <link href="../css/dashboardcss/bootstrap.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/et-line-icons.css" rel="stylesheet" />
    <link href="../css/dashboardcss/font-awesome.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/iconmonstr-iconic-font.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/lity.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/main.css" rel="stylesheet" />
    <link href="../css/dashboardcss/owl.carousel.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/owl.theme.default.min.css" rel="stylesheet" />
    <link href="../css/dashboardcss/responsive.css" rel="stylesheet" />
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $orangered = "#db4211";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1";
        var $primary_color = "#428bca";
        var $lemon_yellow = "#ffe38a";
        var $nagpur_orange = "#fc965f";
        var $default_grey = "#ccc";

        var ELbalance = parseFloat('<%= Session["ELbalance"] %>');
        var PBLbalance = parseFloat('<%= Session["PBLbalance"] %>');
        var MLbalance = parseFloat('<%= Session["MLbalance"] %>');
        var PLbalance = parseFloat('<%= Session["PLbalance"] %>');


        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Leave Name', 'Balance'],
              ['Leaves', ELbalance],
              ['PBL', PBLbalance],
              ['ML', MLbalance],
              ['PL', PLbalance]

            ]);

            var options = {
                width: '800',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue],
                fontSize: 12,
                tooltip: {
                    textStyle: {
                        color: '#000',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                //hAxis: {
                //    slantedText: true,
                //    //   slantedTextAngle: 80 // here you can even use 180
                //},
                legend: {
                    position: 'top'
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('all_Leavechart'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart7);

        // chart colors
        var $orangered = "#db4211";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1";
        var $primary_color = "#428bca";
        var $lemon_yellow = "#ffe38a";
        var $nagpur_orange = "#fc965f";
        var $default_grey = "#ccc";

        function drawChart7() {
            var data = google.visualization.arrayToDataTable([
              ['Status', 'Balance'],
              ['Pending Leave', parseInt('<%= Session["Tot_Pend_Leave"] %>')],
              ['Approved Leave', parseInt('<%= Session["Tot_Apvr_Leave"] %>')],
              ['Cancelled Leave', parseInt('<%= Session["Tot_Cancel_Leave"] %>')],
              ['Rejected Leave', parseInt('<%= Session["Tot_Rej_Leave"] %>')]
                ]);

                var options = {
                    width: '510',
                    height: '279',
                    backgroundColor: 'transparent',
                    colors: [$RoyalBlue],
                    fontSize: 12,
                    tooltip: {
                        textStyle: {
                            color: '#000',
                            fontSize: 11
                        },
                        showColorCode: true
                    },
                    //hAxis: {
                    //    slantedText: true,
                    // //   slantedTextAngle: 80 // here you can even use 180
                    //},
                    legend: {
                        position: 'top'
                    },
                    animation: {
                        duration: 1000,
                        easing: 'out',
                        startup: true
                    }
                };

                var chart = new google.visualization.ColumnChart(document.getElementById('annual_leave_status_chart'));
                chart.draw(data, options);
            }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart6);

        var $orangered = "#db4211";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1"

        var PreviousMonth = parseInt('<%= Session["PrevMonth"] %>');
        var CurrentMonth = parseInt('<%= Session["CurrentMonth"] %>');
        var Today = parseInt('<%= Session["Today"] %>');

        function drawChart6() {
            var data = google.visualization.arrayToDataTable([
              //['Employee', 'Previous Month', 'Current Month', 'Today'],
              //['Absent', PreviousMonth, CurrentMonth, Today],
              ['Employee', 'Absent'],
              ['Previous Month', PreviousMonth],
              ['Current Month', CurrentMonth],
              ['Today', Today]
            ]);

            var options = {
                width: '500',
                height: '258',
                backgroundColor: 'transparent',
                colors: [$orangered, $DarkOrange, $RoyalBlue],
                tooltip: {
                    textStyle: {
                        color: '#666666',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    textStyle: {
                        color: 'black',
                        fontSize: 12
                    }
                },
                chartArea: {
                    left: 60,
                    top: 10,
                    height: '80%'
                },
                hAxis: {
                    slantedText: true,
                    //slantedTextAngle: 90 // here you can even use 180
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('absent_emp_chart'));
            chart.draw(data, options);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section class="services-area-6 bg-gray text-center p-25px leave_dashboard_height">

            <div class="row">
                <div class="leadership-area col-lg-12 col-md-12 transition-3 wow fadeInUp pb-20px  o-hidden" data-wow-delay="0.35s">
                    <div class="wow fadeInUp" data-wow-delay="0.3s">
                        <div class="row">
                            <div class="col-lg-1 col-md-1 transition-3 text-center align-middle">
                                <div class="width-130px height-85 bg-fff p-7px radius-10 mt-10px max-min-height-125px">
                                    <% if (Session["PerEmpPhoto"] != null) Response.Write(Session["PerEmpPhoto"].ToString()); else Response.Redirect("~/notlogged.aspx"); %>
                                </div>
                            </div>
                            <div class="col-lg-6 col-md-6 transition-3 text-left">
                                <p class="ml-40px pl-20px pt-10px">
                                    <span class="black-paragraph fw-800 fs-15" style="text-shadow: 2px 2px 2px skyblue;">Welcome&nbsp;<% if (Session["EmployeeRoleName"] != null) Response.Write(Session["EmployeeRoleName"].ToString()); %>
                                    </span>
                                    <br />
                                    <span class="black-paragraph fw-600 fs-14">
                                        <% if (Session["empcode"] != null) Response.Write(Session["empcode"].ToString()); %> 
                                          -
                                        <% if (Session["name"] != null) Response.Write(Session["name"].ToString()); %>
                                    </span>
                                    <br />
                                    <a href="../ResetPassword.aspx" title="Reset Password" target="ifrmSDL" class="fs-12">Change Password</a><br />
                                    <a href="../viewProfile.aspx" title="View Profile" target="ifrmSDL" class="fs-12">My Profile</a><br />
                                    <a href="../notlogged.aspx?logout=1" title="Logout" class="RedLinkButton">Log Out</a>
                                </p>
                            </div>
                            <div class="col-lg-5 col-md-5 transition-3 text-center align-middle" style="display: none">
                                <div class="container about-area-3 mt-20px">
                                    <div class="row">
                                        <div class="col-md-4" id="row_EarnedLev_1" runat="server">
                                            <div class="numberCircle opacity-7" id="row_circle_EarnedLev_1" runat="server">
                                                <asp:Label ID="lbl_EL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="row_ProbLev_1" runat="server" visible="false">
                                            <div class="numberCircle1 opacity-7">
                                                <asp:Label ID="lbl_ProbL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="row_ML_1" runat="server" visible="false">
                                            <div class="numberCircle2 opacity-7">
                                                <asp:Label ID="lbl_ML" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4" id="row_PL_1" runat="server" visible="false">
                                            <div class="numberCircle2 opacity-7">
                                                <asp:Label ID="lbl_PL" runat="server"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-left" id="row_EarnedLev_2" runat="server">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">
                                                <asp:Label ID="lbl_earned_leave_name" runat="server">Leaves</asp:Label>
                                            </div>
                                        </div>
                                        <div class="col-md-4 text-center" id="row_ProbLev_2" runat="server" visible="false">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Probationary Leave</div>
                                        </div>
                                        <div class="col-md-4 text-center" id="row_ML_2" runat="server" visible="false">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Maternity Leave</div>
                                        </div>
                                        <div class="col-md-4 text-center" id="row_PL_2" runat="server" visible="false">
                                            <div class="fw-600 fs-14 text-center ml-20px mt-10px" style="font-family: Verdana">Paternity Leave</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" id="row_2" runat="server" visible="true">
                <div class="col-lg-12 col-md-12">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-50">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/table_icon.png" style="width:18px" />
                                            </td>
                                            <td class="width-95 pt-5px">&nbsp;
                                                <b>My Leave Balance</b>
                                            </td>
                                        </tr>
                                    </table>

                                </td>
                                <td class="width-50"></td>
                            </tr>
                        </table>
                        <table class="table table-bordered text-center mt-10px">
                            <tr>
                                <th style="width: 20%; padding: 5px 5px 5px 5px; background-color: whitesmoke; font-size: 16px">Leave Name
                                </th>
                                <th style="width: 20%; padding: 5px 5px 5px 5px; background-color: whitesmoke; font-size: 16px" id="row_Leaves_1" runat="server" visible="false">Leaves
                                </th>
                                <th style="width: 20%; padding: 5px 5px 5px 5px; background-color: whitesmoke; font-size: 16px" id="row_PBL_1" runat="server" visible="false">PBL
                                </th>
                                <th style="width: 20%; padding: 5px 5px 5px 5px; background-color: whitesmoke; font-size: 16px" id="row_tbl_ML_1" runat="server" visible="false">ML
                                </th>
                                <th style="width: 20%; padding: 5px 5px 5px 5px; background-color: whitesmoke; font-size: 16px" id="row_tbl_PL_1" runat="server" visible="false">PL
                                </th>
                            </tr>
                            <tr>
                                <th style="background-color: lightsteelblue; padding: 5px 5px 5px 5px">Balance
                                </th>
                                <td style="background-color: skyblue; text-align: center; padding: 5px 5px 5px 5px" id="row_Leaves_2" runat="server" visible="false">
                                    <asp:Label ID="lbl_leaves" runat="server" Text="0" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </td>
                                <td style="background-color: skyblue; text-align: center; padding: 5px 5px 5px 5px" id="row_PBL_2" runat="server" visible="false">
                                    <asp:Label ID="lbl_PBL" runat="server" Text="0" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </td>
                                <td style="background-color: skyblue; text-align: center; padding: 5px 5px 5px 5px" id="row_tbl_ML_2" runat="server" visible="false">
                                    <asp:Label ID="lbl_tbl_ML" runat="server" Text="0" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </td>
                                <td style="background-color: skyblue; text-align: center; padding: 5px 5px 5px 5px" id="row_tbl_PL_2" runat="server" visible="false">
                                    <asp:Label ID="lbl_tbl_PL" runat="server" Text="0" Font-Size="16px" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_3" runat="server" visible="false">
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/piechart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>Annual Leave Status</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="annual_leave_status_chart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="col-lg-6 col-md-6 transition-3" style="display: none">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>Absent Employees</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="absent_emp_chart" class="mt-20px"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 wow fadeInUp text-left" data-wow-delay="0.35s" id="row_4_col_2" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 mb-60px">
                            <tr>
                                <td class="width-50 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/empstatus.png" style="width: 21px; height: 21px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px text-left">&nbsp;
                                                 <b>My Leave Balance Summary</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="dt_example" class="example_alt_pagination">
                            <asp:GridView ID="balancegrid" runat="server" Font-Size="13px" BorderWidth="0"
                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-responsive" OnPreRender="balancegrid_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Leave Name" HeaderStyle-Width="40%" ItemStyle-Width="40%">
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("leavename")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Entitled Days" HeaderStyle-Width="30%" ItemStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("entitled_days")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Used" HeaderStyle-Width="15%" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("used") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available" HeaderStyle-Width="15%" ItemStyle-Width="15%">
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp text-left mb-110px" data-wow-delay="0.35s" id="row_4_col_1" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">

                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-50 text-justify p-5px">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/empstatus.png" style="width: 21px; height: 21px" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px text-left">&nbsp;
                                                 <b>My Reportee Leave Balance</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-50 text-right p-5px">
                                    <table class="width-100 text-right">
                                        <tr>
                                            <td class="width-70 text-right">
                                                <a id="leabeBalanceLink" runat="server" title="Leave Balance" href="~/Leave/reportleavedateils.aspx" style="text-decoration: none; padding-right: 15px">Leave Balance</a>
                                            </td>
                                            <td class="width-30 align-middle">
                                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                    <ContentTemplate>
                                                        <asp:DropDownList ID="ddlReportee" runat="server" AutoPostBack="true" CssClass="dropdown1" OnSelectedIndexChanged="ddlReportee_SelectedIndexChanged">
                                                            <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </ContentTemplate>
                                                    <Triggers>
                                                        <asp:PostBackTrigger ControlID="ddlReportee" />
                                                    </Triggers>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                        </table>
                        <div id="dt_example1" class="example_alt_pagination">
                            <asp:GridView ID="grid_my_reportee_leavebalance" runat="server" Font-Size="13px" BorderWidth="0"
                                AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-responsive" OnPreRender="grid_my_reportee_leavebalance_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Empcode" HeaderStyle-Width="20%" ItemStyle-Width="20%">
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind("empcode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Leave Name" HeaderStyle-Width="30%" ItemStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="l2" runat="server" Text='<%# Bind("leavename")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Entitled Days" HeaderStyle-Width="30%" ItemStyle-Width="30%">
                                        <ItemTemplate>
                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("entitled_days")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Used" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("used") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Available" HeaderStyle-Width="10%" ItemStyle-Width="10%">
                                        <ItemTemplate>
                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("balance") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>

        </section>
    </form>
    <script type="text/javascript" src="../js/jquery.min.js"></script>
    <script type="text/javascript" src="../js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grid_my_reportee_leavebalance').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#balancegrid').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
