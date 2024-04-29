<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payroll_dashboard.aspx.cs" Inherits="menudashboard_payroll_dashboard" %>

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
    <%--<script type="text/javascript" src="https://www.google.com/jsapi"></script>--%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.2/jquery.min.js"></script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['bar'] });
        google.charts.setOnLoadCallback(drawStuff);

        var jan = parseInt('<%= Session["jan"] %>');
        var feb = parseInt('<%= Session["feb"] %>');
        var mar = parseInt('<%= Session["mar"] %>');
        var apr = parseInt('<%= Session["apr"] %>');
        var may = parseInt('<%= Session["may"] %>');
        var jun = parseInt('<%= Session["jun"] %>');
        var jul = parseInt('<%= Session["jul"] %>');
        var Aug = parseInt('<%= Session["Aug"] %>');
        var Sep = parseInt('<%= Session["Sep"] %>');
        var Oct = parseInt('<%= Session["Oct"] %>');
        var Nov = parseInt('<%= Session["Nov"] %>');
        var Dec = parseInt('<%= Session["Dec"] %>');

        var Jan1 = parseInt('<%= Session["jan1"] %> ');
        var feb1 = parseInt('<%= Session["feb1"] %>');
        var mar1 = parseInt('<%= Session["mar1"] %>');
        var apr1 = parseInt('<%= Session["apr1"] %>');
        var may1 = parseInt('<%= Session["may1"] %>');
        var jun1 = parseInt('<%= Session["jun1"] %>');
        var jul1 = parseInt('<%= Session["jul1"] %>');
        var Aug1 = parseInt('<%= Session["Aug1"] %>');
        var Sep1 = parseInt('<%= Session["Sep1"] %>');
        var Oct1 = parseInt('<%= Session["Oct1"] %>');
        var Nov1 = parseInt('<%= Session["Nov1"] %>');
        var Dec1 = parseInt('<%= Session["Dec1"] %>');


        google.charts.load('current', { 'packages': ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawStuff);

        function drawStuff() {

            var button = document.getElementById('change-chart');
            var chartDiv = document.getElementById('graph');

            var data = google.visualization.arrayToDataTable([
              ['', 'Payroll', 'Attendance'],
              ['Jan', jan, Jan1],
              ['Feb', feb, feb1],
              ['Mar', mar, mar1],
              ['Apr', apr, apr1],
              ['May', may, may1],
              ['jun', jun, jun1],
              ['Jul', jul, jul1],
              ['Aug', Aug, Aug1],
              ['Sep', Sep, Sep1],
              ['Oct', Oct, Oct1],
              ['Nov', Nov, Nov1],
              ['Dec', Dec, Dec1],
            ]);

            var materialOptions = {
                width: 1020,
                height: 300,

                series: {
                    0: { axis: 'distance' }, // Bind series 0 to an axis named 'distance'.
                    1: { axis: 'brightness' } // Bind series 1 to an axis named 'brightness'.
                },
                axes: {
                    y: {
                        distance: { label: 'My Payout' }, // Left y-axis.
                        brightness: { side: 'right', label: 'My Attendance' } // Right y-axis.
                    },
                    h: {
                        slantedText: true,
                    },

                }
            };

            var classicOptions = {
                width: 1020,
                height: 350,
                series: {
                    0: { targetAxisIndex: 0 },
                    1: { targetAxisIndex: 1, format: this.value }
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                },
                title: 'Nearby galaxies - distance on the left, brightness on the right',
                vAxes: {
                    // Adds titles to each axis.
                    0: { title: 'parsecs' },
                    1: { title: 'apparent magnitude' }
                }
            };

            function drawMaterialChart() {
                var materialChart = new google.charts.Bar(chartDiv);
                materialChart.draw(data, google.charts.Bar.convertOptions(materialOptions));
                button.innerText = 'Change to Classic';
                button.onclick = drawClassicChart;
            }

            function drawClassicChart() {
                var classicChart = new google.visualization.ColumnChart(chartDiv);
                classicChart.draw(data, classicOptions);
                button.innerText = 'Change to Material';
                button.onclick = drawMaterialChart;
            }

            drawMaterialChart();
            var chart = new google.charts.Bar(document.getElementById('graph'));
            // Convert the Classic options to Material options.
            chart.draw(data, google.charts.Bar.convertOptions(options));
        };
    </script>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 350,
                legend: { position: 'top' },
                isStacked: true,
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
            $.ajax({
                type: "POST",
                url: "payroll_dashboard.aspx/NoOfEmpChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#noofempchart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.load("visualization", "1", { packages: ["corechart"] });
        google.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 350,
                bar: { groupWidth: "90%" },
                legend: { position: "top" },
                isStacked: true,
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "payroll_dashboard.aspx/SalaryRangeBreakDownChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.BarChart($("#salaryrangechart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 350,
                bar: { groupWidth: "90%" },
                legend: { position: "top" },
                isStacked: true,
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "payroll_dashboard.aspx/AvgSalByDeptChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.BarChart($("#avgsalbydeptchart")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);
        function drawChart() {
            var options = {
                width: 480,
                height: 350,
                bar: { groupWidth: "90%", textalign: 'center' },
                legend: {
                    position: 'top',

                },
                isStacked: true,
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "payroll_dashboard.aspx/SalBreakDownByDeptChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.BarChart($("#salbreakdownbydept")[0]);
                    chart.draw(data, options);
                },
                failure: function (r) {
                    alert(r.d);
                },
                error: function (r) {
                    alert(r.d);
                }
            });
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <section class="services-area-6 bg-gray text-center p-25px payroll_dashboard_height">

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
                            <div class="col-lg-5 col-md-5 transition-3 text-center align-middle" style="display:none">
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
                                                <asp:Label ID="lbl_earned_leave_name" runat="server">Earned Leave</asp:Label>
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

            <div class="row" id="row_freeze_status" runat="server" visible="false">
                <div class="transition-3 wow fadeInUp width-7 ml-15px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_1" runat="server" style="padding: 5px 5px; background-color: #808080;">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_1" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_1_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_1" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_1" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_2" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_2" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_2_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_2" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_2" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_3" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_3" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_3_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_3" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_3" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_4" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_4" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_4" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_4_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_4" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_4" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_5" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_5" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_5" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_5_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_5" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_5" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%">
                            <tr>
                                <td id="td_6" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_6" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_6" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_6_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_6" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_6" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_7" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_7" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_7" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_7_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_7" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_7" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_8" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_8" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_8" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_8_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_8" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_8" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_9" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_9" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_9" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_9_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_9" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_9" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_10" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_10" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_10" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_10_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_10" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_10" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_11" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_11" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_11" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_11_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_11" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_11" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <div class="transition-3 wow fadeInUp width-7 ml-8px" data-wow-delay="0.35s">
                    <div class="mt-10px mb-5px radius-5px transition-3 wow fadeInUp">
                        <table style="width: 100%;">
                            <tr>
                                <td id="td_12" runat="server" style="padding: 5px 5px; background-color: #808080">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td style="font-size: 15px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_month_12" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size: 14px; font-weight: 700; color: #e8e8e8">
                                                <asp:Label ID="lbl_year_12" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td id="td_12_1" runat="server" style="font-size: 12px; font-weight: 600; padding: 1px 5px; color: #e8e8e8; background-color: #9f9f9f">
                                    <asp:Label ID="lbl_status_12" runat="server">UpComing</asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tbl_12" runat="server" visible="false" style="width: 100%; background-color: transparent">
                            <tr>
                                <td>
                                    <img src="../images/chart_icon/uphand.png" title="Current Month" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="mt-0px mb-20px radius-10px transition-3 wow fadeInUp">
                        <table style="width: 100%; background-color: #b6ff00">
                            <tr>
                                <td style="padding: 3px 2px; background-color: #186ea7"></td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_payout_summary" runat="server" visible="false">
                <div class="col-lg-12 col-md-12">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <img src="../images/chart_icon/barchart.png" style="width: 25px; height: 25px" />&nbsp;
                                    <b>My Attendance & Payout Summary</b>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100">
                                    <div id="graph" class="p-20px"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_No_Of_Emp_SalaryRange" runat="server" visible="false">
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>Number Of Employees Per Department</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="noofempchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>Salary Range Breakdown</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="salaryrangechart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_Avg_Sal_Sal_BreakDown" runat="server" visible="false">
                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>Average Salary By Department</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="avgsalbydeptchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>Salary Breakdown By Department</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="salbreakdownbydept"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

        </section>
    </form>
</body>
</html>
