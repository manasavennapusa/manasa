<%@ Page Language="C#" AutoEventWireup="true" CodeFile="travel_dashboard.aspx.cs" Inherits="menudashboard_travel_dashboard" %>
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
           google.load("visualization", "1", { packages: ["corechart"] });
           google.setOnLoadCallback(drawChart);
           function drawChart() {
               var options = {
                   width: 480,
                   height: 279,
                   legend: { position: 'top' },
                   isStacked: true,
                   animation: {
                       duration: 1100,
                       easing: 'out',
                       startup: true
                   }
               };
               $.ajax({
                   type: "POST",
                   url: "travel_dashboard.aspx/CurrencyChart",
                   data: '{}',
                   contentType: "application/json; charset=utf-8",
                   dataType: "json",
                   success: function (r) {
                       var data = google.visualization.arrayToDataTable(r.d);
                       var chart = new google.visualization.ColumnChart($("#currencychart")[0]);
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
                height: 279,
                legend: { position: 'top' },
                isStacked: true,
                animation: {
                    duration: 1100,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "travel_dashboard.aspx/TravelStatusChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#travelstatuschart")[0]);
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
                height: 279,
                hAxis: {
                    slantedText: true,
                    //slantedTextAngle: 90 // here you can even use 180
                },
                legend: { position: 'top' },
                isStacked: true,
                animation: {
                    duration: 1100,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "travel_dashboard.aspx/TravelApproverChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#travelapproverchart")[0]);
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
                height: 279,
                hAxis: {
                    slantedText: true,
                    //slantedTextAngle: 90 // here you can even use 180
                },
                legend: { position: 'top' },
                isStacked: true,
                animation: {
                    duration: 1100,
                    easing: 'out',
                    startup: true
                }
            };
            $.ajax({
                type: "POST",
                url: "travel_dashboard.aspx/InterTravelApproverChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#Intertravelapproverchart")[0]);
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
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $RoyalBlue = "#4169E1";

        var domestic = parseInt('<%= Session["Domestic"] %>');
        var international = parseInt('<%= Session["International"] %>');

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['TravelType', 'Total'],
              ['Domestic', domestic],
              ['International', international],
            ]);

            var options = {
                width: '480',
                height: '279',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue],
                tooltip: {
                    textStyle: {
                        color: 'black',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    position: 'top'
                },
                animation: {
                    duration: 1500,
                    easing: 'out',
                    startup: true
                },
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myrepttrvlchart'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $RoyalBlue = "#4169E1";

        var mydomestic = parseInt('<%= Session["MyDomestic"] %>');
        var myinternational = parseInt('<%= Session["MyInternational"] %>');

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['TravelType', 'Total'],
              ['Domestic', mydomestic],
              ['International', myinternational],
            ]);

            var options = {
                width: '480',
                height: '279',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue],
                tooltip: {
                    textStyle: {
                        color: 'black',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    position: 'top'
                },
                animation: {
                    duration: 1500,
                    easing: 'out',
                    startup: true
                },
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('mytravelchart'));
            chart.draw(data, options);
        }
    </script>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section class="services-area-6 bg-gray text-center p-25px Travel_dashboard_height">
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

            <div class="row" id="row_2" runat="server" visible="false">
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
                                               <b>Currency</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="currencychart"></div>
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
                                               <b>Travel Status</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="travelstatuschart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_3" runat="server" visible="false">
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
                                               <b>Domestic Travel Approvers</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="travelapproverchart"></div>
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
                                               <b>International Travel Approvers</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="Intertravelapproverchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-6 col-md-6" id="row_4_col_1" runat="server">
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
                                               <b>My Reportee Travel Status</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="myrepttrvlchart"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6" id="row_4_col_2" runat="server">
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
                                               <b>My Travel Status</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="mytravelchart"></div>
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
