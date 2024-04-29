<%@ Page Language="C#" AutoEventWireup="true" CodeFile="attendance_dashboard.aspx.cs" Inherits="menudashboard_attendance_dashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

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
    <script src="../js/jsapi.js"></script>
    <script src="../js/morris/morris.js"></script>
    <script src="../js/morris/raphael-min.js"></script>

    <link href="../build/nv.d3.css" rel="stylesheet" type="text/css" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/d3/3.5.2/d3.min.js" charset="utf-8"></script>
    <script src="../build/nv.d3.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $border_color = "#efefef";
        var $grid_color = "#ddd";
        var $default_black = "#666";
        var $default_grey = "#ccc";
        var $primary_color = "#428bca";
        var $go_green = "#93caa3";
        var $jet_blue = "#70aacf";
        var $lemon_yellow = "#ffe38a";
        var $nagpur_orange = "#fc965f";
        var $orangered = "#db4211";
        var $ruby_red = "#fa9c9b";
        var $FireBrick = "#B22222";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1";

        var totalEmployees = parseInt('<%= Session["totalEmpReportee"] %>');
        var presentEmployees = parseInt('<%= Session["totalEmpReporteePresent"] %>');
        var prsntEmpRepDeci = parseFloat('<%= Session["totlPrsntinDeciRep"] %>');
        var absentEmployees = parseInt(totalEmployees) - parseInt(presentEmployees);
        var absntEmpRep = parseFloat("100") - prsntEmpRepDeci;
        document.getElementById('absentEmployeeReportee').innerHTML = absentEmployees;
        document.getElementById('absentEmployeeReporteePrcnt').innerHTML = absntEmpRep + "%";

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Day', 'No of Emp', 'Present', 'Absent'],
              ['Today', totalEmployees, presentEmployees, absentEmployees],
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$orangered, $DarkOrange, $RoyalBlue, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
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
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myReporteeAttendance'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart5);

        // chart colors
        var $border_color = "#efefef";
        var $grid_color = "#ddd";
        var $default_black = "#666";
        var $default_grey = "#ccc";
        var $primary_color = "#428bca";
        var $go_green = "#93caa3";
        var $jet_blue = "#70aacf";
        var $lemon_yellow = "#ffe38a";
        var $nagpur_orange = "#fc965f";
        var $orangered = "#db4211";
        var $ruby_red = "#fa9c9b";
        var $FireBrick = "#B22222";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1";

        var totalEmployees = parseInt('<%= Session["totalEmpReportee"] %>');
        var presentEmployees = parseInt('<%= Session["totalEmpReporteePresent"] %>');
        var prsntEmpRepDeci = parseFloat('<%= Session["totlPrsntinDeciRep"] %>');
        var absentEmployees = parseInt(totalEmployees) - parseInt(presentEmployees);
        var absntEmpRep = parseFloat("100") - prsntEmpRepDeci;
        //document.getElementById('absentEmployeeReportee').innerHTML = ": " + absentEmployees;
        //document.getElementById('absentEmployeeReporteePrcnt').innerHTML = ": " + absntEmpRep + "%";
        document.getElementById('absentEmployeeReportee').innerHTML = absentEmployees;
        document.getElementById('absentEmployeeReporteePrcnt').innerHTML = absntEmpRep + "%";

        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Day', 'No of Emp', 'Present', 'Absent'],
              ['Today', totalEmployees, presentEmployees, absentEmployees],
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$orangered, $DarkOrange, $RoyalBlue, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
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
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myReporteeAttendance_1'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart6);

        // chart colors
        var $border_color = "#efefef";
        var $grid_color = "#ddd";
        var $default_black = "#666";
        var $default_grey = "#ccc";
        var $primary_color = "#428bca";
        var $go_green = "#93caa3";
        var $jet_blue = "#70aacf";
        var $lemon_yellow = "#ffe38a";
        var $nagpur_orange = "#fc965f";
        var $ruby_red = "#fa9c9b";
        var $FireBrick = "#B22222";
        var $OrangeRed = "#FF4500";
        var $orangered = "#db4211";
        var $maroon = "#800000";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1"

        var totalEmployees6 = parseInt('<%= Session["totalEmp"] %>');
        //alert(totalEmployees6);
        var prsntEmp = parseInt('<%= Session["prsntEmployee1"] %>');
        //alert(prsntEmp);
        var presentEmployees6 = parseFloat('<%= Session["totlPrsntInDeci"] %>');
        var absentEmployees6 = parseFloat("100") - presentEmployees6;
        var absntEmployee = totalEmployees6 - prsntEmp;
        document.getElementById('lblAbsentEmpInPrcnt').innerHTML = ": " + absentEmployees6 + "%";
        document.getElementById('absentEmployee').innerHTML = ": " + absntEmployee;


        function drawChart6() {
            var data = google.visualization.arrayToDataTable([
              ['Day', 'No of Emp', 'Present', 'Absent'],
              ['Today', totalEmployees6, prsntEmp, absntEmployee],
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$orangered, $DarkOrange, $RoyalBlue, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
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
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('col_chart'));
            chart.draw(data, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart4);

        // chart colors
        var $go_green = "#93caa3";
        var $jet_blue = "#70aacf";
        var $ruby_red = "#fa9c9b";
        var $FireBrick = "#B22222";
        var $orangered = "#db4211";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1";

        //var deptmnt_name = (<%= Session["dept_name"] %>);
        var totalEmpDept1 = parseInt('<%= Session["totalEmpDept1"] %>');
        var presentEmpDept1 = parseFloat('<%= Session["totlPrsntinDeciDept1"] %>');
        var absentEmpDept1;
        if (totalEmpDept1 < 1) {
            totalEmpDept1 = 0;
            absentEmpDept1 = 0;
        }
        else {
            totalEmpDept1 = 100;
            absentEmpDept1 = parseFloat("100") - presentEmpDept1;
        }
        document.getElementById('totalAbbsentDept1').innerHTML = ": " + absentEmpDept1 + "%";

        var totalEmpDept2 = parseInt('<%= Session["totalEmpDept2"] %>');
        var presentEmpDept2 = parseFloat('<%= Session["totlPrsntinDeciDept2"] %>');
        var absentEmpDept2;
        if (totalEmpDept2 < 1) {
            totalEmpDept2 = 0;
            absentEmpDept2 = 0;
        }
        else {
            totalEmpDept2 = 100;
            absentEmpDept2 = parseFloat("100") - presentEmpDept2;
        }
        document.getElementById('totalAbbsentDept2').innerHTML = ": " + absentEmpDept2 + "%";

        var totalEmpDept3 = parseInt('<%= Session["totalEmpDept3"] %>');
        var presentEmpDept3 = parseFloat('<%= Session["totlPrsntinDeciDept3"] %>');
        var absentEmpDept3;
        if (totalEmpDept3 < 1) {
            totalEmpDept3 = 0;
            absentEmpDept3 = 0;
        }
        else {
            totalEmpDept3 = 100;
            absentEmpDept3 = parseFloat("100") - presentEmpDept3;
        }
        document.getElementById('totalAbbsentDept3').innerHTML = ": " + absentEmpDept3 + "%";

        function drawChart4() {
            var data = google.visualization.arrayToDataTable([
              ['Day', 'No of Emp', 'Present', 'Absent'],
              ['<%= Session["dept_name"] %>', totalEmpDept1, presentEmpDept1, absentEmpDept1],
            ]);

              var options = {
                  width: '500',
                  height: '220',
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
                  animation: {
                      duration: 1000,
                      easing: 'out',
                      startup: true
                  }
              };

              var chart = new google.visualization.ColumnChart(document.getElementById('deptAttendanceColumnChart'));
              chart.draw(data, options);
          }
    </script>

        <script type="text/javascript">
            google.charts.load('current', { packages: ['corechart', 'bar'] });
            google.charts.setOnLoadCallback(drawChart10);

            // chart colors
            // chart colors
            var $border_color = "#efefef";
            var $grid_color = "#ddd";
            var $default_black = "#666";
            var $default_grey = "#ccc";
            var $primary_color = "#428bca";
            var $go_green = "#93caa3";
            var $jet_blue = "#70aacf";
            var $lemon_yellow = "#ffe38a";
            var $nagpur_orange = "#fc965f";
            var $orangered = "#db4211";
            var $ruby_red = "#fa9c9b";
            var $FireBrick = "#B22222";
            var $DarkOrange = "#FF8C00";
            var $RoyalBlue = "#4169E1";

            function drawChart10() {
                var inTime = parseInt('<%= Session["Emp_log1"] %>');
            var late_1 = parseInt('<%= Session["Emp_log2"] %>');
            var late_2 = parseInt('<%= Session["Emp_log3"] %>');

            var data1 = google.visualization.arrayToDataTable([
              ['Task', 'Hours per Day'],
              ['In Time', inTime],
              ['15 min Late', late_1],
              ['30 min Late', late_2]
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue, $RoyalBlue, $DarkOrange, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
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
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('emp_piechart1'));
            chart.draw(data1, options);
        }
    </script>

        <script type="text/javascript">
            google.charts.load('current', { packages: ['corechart', 'bar'] });
            google.charts.setOnLoadCallback(drawChart10);

            // chart colors
            // chart colors
            var $border_color = "#efefef";
            var $grid_color = "#ddd";
            var $default_black = "#666";
            var $default_grey = "#ccc";
            var $primary_color = "#428bca";
            var $go_green = "#93caa3";
            var $jet_blue = "#70aacf";
            var $lemon_yellow = "#ffe38a";
            var $nagpur_orange = "#fc965f";
            var $orangered = "#db4211";
            var $ruby_red = "#fa9c9b";
            var $FireBrick = "#B22222";
            var $DarkOrange = "#FF8C00";
            var $RoyalBlue = "#4169E1";

            function drawChart10() {
                var inTime = parseInt('<%= Session["Emp_log1"] %>');
            var late_1 = parseInt('<%= Session["Emp_log2"] %>');
            var late_2 = parseInt('<%= Session["Emp_log3"] %>');

            var data1 = google.visualization.arrayToDataTable([
              ['Task', 'Hours per Day'],
              ['In Time', inTime],
              ['15 min Late', late_1],
              ['30 min Late', late_2]
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$RoyalBlue, $RoyalBlue, $DarkOrange, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
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
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('emp_piechart2'));
            chart.draw(data1, options);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart1);

        function drawChart1() {

            var allowedcompoff = parseFloat('<%= Session["allowedcompoff"] %>');
            var approvedcompoff = parseFloat('<%= Session["approvedcompoff"] %>');
            var compoffbalance = parseFloat('<%= Session["compoffbalance"] %>');

            var data1 = google.visualization.arrayToDataTable([
              ['Balance Days', 'Balance'],
              ['Entitled Days', allowedcompoff],
              ['Used Days', approvedcompoff],
              ['Available Days', compoffbalance]

            ]);
            var options = {
                pieHole: 0.4,
                width: '440',
                height: 'auto',
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
                    position: 'right',
                    textStyle: {
                        color: 'black',
                        fontSize: 12
                    }
                },
                chartArea: {
                    left: 0,
                    top: 10,
                    width: "100%",
                    height: "100%"
                },
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };
            var chart1 = new google.visualization.PieChart(document.getElementById('mycompoff'));

            chart1.draw(data1, options);
            // initial value
            var percent = 0;
            // start the animation loop
            var handler = setInterval(function () {
                // values increment
                percent += 1;
                // apply new values
                data.setValue(0, 1, percent);
                data.setValue(1, 1, 100 - percent);
                // update the pie
                chart.draw(data, options);
                // check if we have reached the desired value
                if (percent > 74)
                    // stop the loop
                    clearInterval(handler);
            }, 30);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChart8);

        // chart colors
        var $orangered = "#db4211";
        var $DarkOrange = "#FF8C00";
        var $RoyalBlue = "#4169E1"

        var ApprovedHW = parseInt('<%= Session["ApprovedHW"] %>');
        var PendingHW = parseInt('<%= Session["PendingHW"] %>');

        function drawChart8() {
            var data = google.visualization.arrayToDataTable([
              ['Status', 'Approved', 'Pending'],
              ['Total', ApprovedHW, PendingHW],
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                bar: { groupWidth: '40%' },
                colors: [$RoyalBlue, $orangered],
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
                animation: {
                    duration: 1000,
                    easing: 'out',
                    startup: true
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myholidaywork'));
            chart.draw(data, options);
        }
    </script>

    <style type="text/css">
        .btn-green {
            color: #fff;
            background-color: #28a745;
            border-color: #28a745;
            padding: 1px 5px;
            width: 80px;
            font-weight: 700;
            margin-top: 43px;
        }

            .btn-green:hover {
                color: #fff;
                background-color: #218838;
                border-color: #1e7e34;
            }

        .btn-red {
            color: #fff;
            background-color: #dc3545;
            border-color: #dc3545;
            padding: 1px 5px;
            width: 80px;
            font-weight: 700;
            margin-top: 43px;
        }

            .btn-red:hover {
                color: #fff;
                background-color: #c82333;
                border-color: #bd2130;
            }
    </style>

</head>
<body>
    <form id="form1" runat="server" class="border-top-golden">
        <asp:ScriptManager ID="scr" runat="server">
        </asp:ScriptManager>

        <section class="services-area-6 bg-gray text-center p-25px attendancee_dashboard_height">

            <div class="row">
                <div class="leadership-area col-lg-12 col-md-12 transition-3 wow fadeInUp pb-20px  o-hidden" data-wow-delay="0.35s">
                    <div class="wow fadeInUp" data-wow-delay="0.3s">
                        <div class="row">
                            <div class="col-lg-1 col-md-1 transition-3 text-center align-middle">
                                <div class="width-130px height-85 bg-fff p-7px radius-10 mt-10px max-min-height-125px">
                                    <% if (Session["PerEmpPhoto"] != null) Response.Write(Session["PerEmpPhoto"].ToString()); else Response.Redirect("~/notlogged.aspx"); %>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 transition-3 text-left">
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
                            <div class="col-lg-3 col-md-3 transition-3 align-bottom">
                                <table class="width-100">
                                    <tr>
                                        <td class="width-50" id="Td1" runat="server">
                                            <asp:Button ID="btn_loging" runat="server" CssClass="btn btn-green" Text="Log-In" OnClick="btn_loging_Click" />
                                        </td>
                                        <td class="width-50" id="Td2" runat="server">
                                            <asp:Button ID="btn_logout" runat="server" CssClass="btn btn-red" Text="Log-Out" OnClick="btn_logout_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="width-50 pt-10px" id="Td3" runat="server">
                                            <asp:Label ID="lbl_cloakintime" runat="server" Style="color: #28a745; font-size: 18px; font: bold">00:00</asp:Label>
                                        </td>
                                        <td class="width-50 pt-10px" id="Td4" runat="server">
                                            <asp:Label ID="lbl_cloakouttime" runat="server" Style="color: #dc3545; font-size: 18px; font: bold">00:00</asp:Label>
                                        </td>
                                    </tr>
                                </table>
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

            <div class="row pb-5px" id="Div3" runat="server">
                <div class="col-lg-12 col-md-12" data-wow-delay="0.35s">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px">
                        <table class="width-100 mb-20px">
                            <tr>
                                <td class="width-3 text-left p-5px">
                                    <img src="../images/chart_icon/table_icon.png" style="width: 18px; height: 18px" />
                                </td>
                                <td class="width-97 align-bottom text-left pt-5px">&nbsp;
                                    <b>My Monthwise Attendance</b>
                                </td>
                            </tr>
                        </table>
                        <div id="dt_example" class="example_alt_pagination">
                            <asp:GridView ID="grdempatndnce" runat="server" AllowSorting="true" CellPadding="10" AutoGenerateColumns="False" BorderWidth="1" HeaderStyle-Font-Size="14px" RowStyle-Font-Size="13px"
                                EmptyDataText="No Data Present" CssClass="table table-striped table-bordered table-hover" OnPreRender="grdempatndnce_PreRender">
                                <Columns>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("DateList")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="InTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInTime" runat="server" Text='<%#Eval("InTime")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="OutTime">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOutTime" runat="server" Text='<%#Eval("OutTime")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Hours">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotHour" runat="server" Text='<%#Eval("TotalHours")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" id="row_2" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s" id="row_2_col_1" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 text-left mb-20px">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>Attendance</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="col_chart"></div>
                        <table class="width-60 ml-40px">
                            <tr>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["totalEmp"] != null) Response.Write(Session["totalEmp"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["prsntEmployee1"] != null) Response.Write(Session["prsntEmployee1"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <asp:Label ID="absentEmployee" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <asp:Label ID="Label3" runat="server">100%</asp:Label>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["totalPresentEmp"] != null) Response.Write(Session["totalPresentEmp"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <asp:Label ID="lblAbsentEmpInPrcnt" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s" id="row_2_col_2" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 text-left mb-20px">
                            <tr>
                                <td class="width-70">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-10">
                                                <img src="../images/chart_icon/barchart.png" style="width: 25px; height: 25px" />
                                            </td>
                                            <td class="width-90 align-bottom pt-5px">
                                                <b>Department wise Attendance</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td class="width-30 dropdown">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddl_department" runat="server" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged" AutoPostBack="true" CssClass="dropdown"></asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="ddl_department" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                        <div id="deptAttendanceColumnChart"></div>
                        <table class="width-60 ml-40px">
                            <tr>
                                <td class="width-20 text-justify p-3px"></td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <asp:Label ID="Label2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-left p-3px">
                                    <% if (Session["dept_name"] != null) Response.Write(Session["dept_name"].ToString()); %>
                                </td>
                                <td id="tdRecruitment" runat="server" class="text-left p-3px">
                                    <asp:Label ID="Label4" runat="server">100%</asp:Label>
                                </td>
                                <td id="tdRecruitment0" runat="server" class="text-left p-3px">
                                    <% if (Session["presentpercnt"] != null) Response.Write(Session["presentpercnt"].ToString()); %>
                                </td>
                                <td class="text-left p-3px">
                                    <% if (Session["absentpercnt"] != null) Response.Write(Session["absentpercnt"].ToString()); %>
                                </td>
                                <td class="text-left p-3px">
                                    <asp:Label ID="totalAbbsentDept1" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>

            <div class="row" id="row_3" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s" id="row_3_col_1" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 text-left mb-20px">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>My Reportee Attendance</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="myReporteeAttendance"></div>
                        <table class="width-60 ml-40px">
                            <tr>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["totalEmpReportee"] != null) Response.Write(Session["totalEmpReportee"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["totalEmpReporteePresent"] != null) Response.Write(Session["totalEmpReporteePresent"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <asp:Label ID="absentEmployeeReportee" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td>
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="text-justify p-3px">
                                    <asp:Label ID="Label1" runat="server">100%</asp:Label>
                                </td>
                                <td class="text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td>
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="text-justify p-3px">
                                    <% if (Session["totalPresentEmpRep"] != null) Response.Write(Session["totalPresentEmpRep"].ToString()); %>
                                </td>
                                <td class="text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td>
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="text-justify p-3px">
                                    <asp:Label ID="absentEmployeeReporteePrcnt" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s" id="row_3_col_2" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 text-left mb-20px">
                            <tr>
                                <td class="width-100">
                                    <img src="../images/chart_icon/calendar_check.png" style="width: 25px; height: 25px" />&nbsp;&nbsp;
                                     <b>Team Attendance</b>
                                </td>
                            </tr>
                        </table>

                        <table class="width-100">
                            <tr>
                                <td class="width-25 text-center p-3px">
                                    <asp:Label ID="lblEmpCode" runat="server" Text="Employee" CssClass="color-555 fw-600"></asp:Label>
                                </td>
                                <td class="width-25 text-center p-3px">
                                    <asp:Label ID="lblIntime" runat="server" Text="In-Time" CssClass="color-green fw-600"></asp:Label>
                                </td>
                                <td class="width-25 text-center p-3px">
                                    <asp:Label ID="lblOuttime" runat="server" Text="Out-Time" CssClass="color-green fw-600"></asp:Label>
                                </td>
                                <td class="width-25 text-center p-3px">
                                    <asp:Label ID="lblAvgHour" runat="server" Text="Total-Hour" CssClass="color-green fw-600"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <div style="text-align: center; background-repeat: repeat-x; background-attachment: fixed; background-position: center; height: 230px; overflow-y: auto; overflow-style: scrollbar; overflow-x: hidden; margin-top: 10px">
                            <% Response.Write(Session["TA"].ToString()); %>
                        </div>
                    </div>
                </div>
            </div>

            <div class="row" id="row_5" runat="server" visible="false">
                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s" id="row_5_col_1" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 text-left mb-20px">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>My Reportee Attendance</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="myReporteeAttendance_1"></div>
                        <table class="width-60 ml-40px">
                            <tr>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["totalEmpReportee"] != null) Response.Write(Session["totalEmpReportee"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <% if (Session["totalEmpReporteePresent"] != null) Response.Write(Session["totalEmpReporteePresent"].ToString()); %>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td class="width-5">
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="width-5 text-justify p-3px">
                                    <asp:Label ID="Label6" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="text-justify p-3px">
                                    <div class="rectangle-orangered"></div>
                                </td>
                                <td>
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="text-justify p-3px">
                                    <asp:Label ID="Label7" runat="server">100%</asp:Label>
                                </td>
                                <td class="text-justify p-3px">
                                    <div class="rectangle-DarkOrange"></div>
                                </td>
                                <td>
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="text-justify p-3px">
                                    <% if (Session["totalPresentEmpRep"] != null) Response.Write(Session["totalPresentEmpRep"].ToString()); %>
                                </td>
                                <td class="text-justify p-3px">
                                    <div class="rectangle-RoyalBlue"></div>
                                </td>
                                <td>
                                    <div class="tripledotcolon"></div>
                                </td>
                                <td class="text-justify p-3px">
                                    <asp:Label ID="asas" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 transition-3 wow fadeInUp" data-wow-delay="0.35s" id="row_5_col_2" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp height-360px">
                        <table class="width-100 text-left">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/piechart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                                <b>My Attendance(Month-Wise)</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100 pt-20px pb-20px">
                                    <div id="emp_piechart2"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

            </div>

            <div class="row" id="row_6" runat="server" visible="true">
                <div class="col-lg-6 col-md-6" id="Div1" runat="server">
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
                                                <b>My CompOff</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100 pt-20px pb-20px">
                                    <div id="mycompoff"></div>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6" id="Div2" runat="server">
                    <div class="mt-10px mb-10px bg-fff p-10px radius-10px transition-3 wow fadeInUp">
                        <table class="width-100 text-left mb-20px">
                            <tr>
                                <td class="width-100">
                                    <table class="width-100 text-left">
                                        <tr>
                                            <td class="width-5">
                                                <img src="../images/chart_icon/barchart.png" />
                                            </td>
                                            <td class="width-95 align-bottom pt-5px">&nbsp;
                                               <b>My Holiday Work</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div id="myholidaywork"></div>
                    </div>
                </div>
            </div>

            <div class="row" id="row_4" runat="server" visible="false">
                <div class="col-lg-6 col-md-6" id="row_4_col_1" runat="server">
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
                                                <b>My Attendance(Month-Wise)</b>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="width-100 pt-20px pb-20px">
                                    <div id="emp_piechart1"></div>
                                </td>
                            </tr>
                        </table>
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
            $('#grdempatndnce').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
