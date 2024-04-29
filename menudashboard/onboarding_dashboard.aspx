<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onboarding_dashboard.aspx.cs" Inherits="menudashboard_onboarding_dashboard" %>
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
                //title: 'Onboarded Employees(Month-wise)',
                width: 1010,
                height: 279,
                //bar: { groupWidth: "10%" },
                legend: { position: "none" },
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
                url: "onboarding_dashboard.aspx/GetChartData",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.ColumnChart($("#chart_div")[0]);
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
                //title: 'USA City Distribution',
                //pieHole: 0.5,
                width: 480,
                height: 279,
                pieStartAngle: 0
            };
            $.ajax({
                type: "POST",
                url: "onboarding_dashboard.aspx/OnBoardEmpChart",
                data: '{}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (r) {
                    var data = google.visualization.arrayToDataTable(r.d);
                    var chart = new google.visualization.PieChart($("#onboardempdeptwise")[0]);
                    google.visualization.events.addListener(chart, 'ready', function () {
                        if (options.pieStartAngle < 60) {
                            options.pieStartAngle++;
                            setTimeout(function () {
                                chart.draw(data, options);
                            }, 1);
                        }
                    });
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <section class="services-area-6 bg-gray text-center p-25px onboarding_dashboard_height">
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

            <div class="row">
                <div class="col-lg-3 col-md-3 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text mt-10px mb-10px bg-fff p-3px radius-10px transition-3 wow fadeInUp">
                        <table style="width: 100%; background-color: forestgreen; border-radius: 10px 10px;">
                            <tr>
                                <td class="fs-50 fw-200 text-center color-fff">
                                    <asp:Label ID="lbl_on_boarded_emp" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 10px 0px 10px;">
                                    <table style="width: 100%; border-bottom: 1px solid #fff; padding-left: 10px; padding-right: 10px;">
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="fs-20 fw-200 p-5px text-center color-fff">OnBoarded Employees
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text mt-10px mb-10px bg-fff p-3px radius-10px transition-3 wow fadeInUp">
                        <table style="width: 100%; background-color: mediumvioletred; border-radius: 10px 10px;">
                            <tr>
                                <td class="fs-50 fw-200 text-center color-fff">
                                    <asp:Label ID="lbl_in_progress_emp" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 10px 0px 10px;">
                                    <table style="width: 100%; border-bottom: 1px solid #fff; padding-left: 10px; padding-right: 10px;">
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="fs-20 fw-200 p-5px text-center color-fff">In Progress Employees
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text mt-10px mb-10px bg-fff p-3px radius-10px transition-3 wow fadeInUp">
                        <table style="width: 100%; background-color: cornflowerblue; border-radius: 10px 10px;">
                            <tr>
                                <td class="fs-50 fw-200 text-center color-fff">
                                    <asp:Label ID="lbl_sumitted_to_HR" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 10px 0px 10px;">
                                    <table style="width: 100%; border-bottom: 1px solid #fff; padding-left: 10px; padding-right: 10px;">
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="fs-20 fw-200 p-5px text-center color-fff">Submitted To HR
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-3 col-md-3 transition-3 wow fadeInUp" data-wow-delay="0.35s">
                    <div class="services-text mt-10px mb-10px bg-fff p-3px radius-10px transition-3 wow fadeInUp">
                        <table style="width: 100%; background-color: darkgoldenrod; border-radius: 10px 10px;">
                            <tr>
                                <td class="fs-50 fw-200 text-center color-fff">
                                    <asp:Label ID="lbl_onboarding_completed" runat="server">!!</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding: 0px 10px 0px 10px;">
                                    <table style="width: 100%; border-bottom: 1px solid #fff; padding-left: 10px; padding-right: 10px;">
                                        <tr>
                                            <td></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="fs-20 fw-200 p-5px text-center color-fff">OnBoarding Completed
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

              <div class="row mt-10px">
                <div class="col-lg-12 col-md-12">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px text-left">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-3">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-97 align-bottom pt-5px">&nbsp;
                                               <b>Onboarded Employees(Month-wise)</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="chart_div" runat="server" style="height: 279px"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row mt-10px">
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
                                                 <b>Onboarded Employees (Department wise)</b>
                                            </td>
                                        </tr>
                                    </table>
                                    <div id="onboardempdeptwise"></div>
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
