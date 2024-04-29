<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DashBoard.aspx.cs" Inherits="DashBoard" %>

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


<!-- Mirrored from srinubasava.com/startup/index.html by HTTrack Website Copier/3.x [XR&CO'2013], Tue, 06 May 2014 12:52:30 GMT -->
<head>
    <meta charset="utf-8">
    <title>StartUp Admin</title>
    <meta name="author" content="Srinu Basava">
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport">
    <meta name="description" content="StartUp Admin UI">
    <meta name="keywords" content="StartUp Admin UI, Admin UI, Admin Dashboard, Srinu Basava, Best admin UI, Best backend UI, Best Dashboard, Responsive admin UI, Responsive dashboard, Responsive Backend, Mobile admin, Mobile Backend, Mobile Dashboard">
    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/moment.js"></script>

    <%-- <script type="text/javascript" src="https://www.google.com/jsapi"></script>--%>

    <!-- morris charts -->
    <script src="js/jsapi.js"></script>
    <script src="js/morris/morris.js"></script>
    <script src="js/morris/raphael-min.js"></script>

    <%-- <script src="js/custom-google-graphs.js"></script>--%>
    <%-- <script src="js/custom-other-graphs.js"></script>--%>

    <%-- <script>

        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>--%>
    <!-- Flot charts -->
    <%--<script src="js/flot/jquery.flot.js"></script>
    <script src="js/flot/jquery.flot.selection.js"></script>
    <script src="js/flot/jquery.flot.pie.js"></script>
    <script src="js/flot/jquery.flot.tooltip.js"></script>

    <!-- Google Visualization JS -->
   

    <!-- Easy Pie Chart JS -->
    <script src="js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="js/tiny-scrollbar.js"></script>

    <%--   <!-- Sparkline charts -->
        <script src="js/sparkline.js"></script>--%>

    <!-- Datatables JS -->
    <script src="js/jquery.dataTables.js"></script>

    <!-- Calendar Js -->
    <script src='js/fullcalendar/jquery-ui-1.10.2.custom.min.js'></script>
    <script src='js/fullcalendar/fullcalendar.min.js'></script>


    <!-- Custom Js -->

    <%--  <script src="js/custom-index.js"></script>--%>
    <%-- <script src="js/custom-calendar.js"></script>

    <script src="js/theming.js"></script>--%>
    <%-- <script src="js/custom.js"></script>--%>

    <script type="text/javascript">
        // chart colors for Leave Balance
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
        google.load("visualization", "1", {
            packages: ["corechart"]
        });
        $(document).ready(function () {

            var leaveparameters = {
                empcode: '<%=Session["empcode"].ToString()%>',
                gender: '<%=Session["gender"].ToString()%>'
            };

            // Leave Balance
            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/GetLeaveBalance",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(leaveparameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        socialGraph(data);
                        socialGraph_1(data);
                    }
                    if (data.d.length > 2) {
                        socialGraph_2();
                    }
                },
                failure: function (response) {
                    alert(response.d);

                },
                error: function (response) {
                    alert(response.d);

                }
            });

            // My Attendance 

            var attparameters = {
                empcode: '<%=Session["empcode"].ToString()%>'
            };

            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/GetDepartmentwiseAttendance",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(attparameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        drawChart3(data.d);
                    }
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });

            // Event Calender
            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/BindEventCalender",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(attparameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        BindEventCalender(data.d)
                    }
                },
                failure: function (response) {
                    alert(response.d);
                },
                error: function (response) {
                    alert(response.d);
                }
            });


        });

        // For Leave Balance
        function socialGraph(data) {

            var useddays = parseFloat(data.d[0].useddays);
            var leavename = data.d[0].leavename;
            var balance = parseFloat(data.d[0].balance);
            Morris.Donut({
                element: 'leave_0',
                data: [
                       { value: useddays, label: leavename + ' - Used' },
                       { value: balance, label: leavename + ' - Balance' }
                ],
                labelColor: '#666666',
                colors: [$primary_color, $jet_blue, $go_green, $default_black, $ruby_red, $lemon_yellow, $nagpur_orange],
                formatter: function (x) { return x }
            });
            var str = "";
            str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 14px;font-weight: bold;'>&nbsp;" + data.d[0].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 14px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 14px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
            $("#leavedata1").append(str);
        }

        function socialGraph_1(data) {
            var useddays = parseFloat(data.d[1].useddays);
            var leavename = data.d[1].leavename;
            var balance = parseFloat(data.d[1].balance);
            Morris.Donut({
                element: 'leave_1',
                data: [
                       { value: useddays, label: leavename + ' - Used' },
                       { value: balance, label: leavename + ' - Balance' }
                ],
                labelColor: '#666666',

                colors: [$lemon_yellow, $nagpur_orange, $jet_blue, $primary_color, $ruby_red, $go_green, $default_black],
                formatter: function (x) { return x }
            });
            var str = "";
            str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 14px;font-weight: bold;'>&nbsp;" + data.d[1].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 14px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 14px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
            $("#leavedata2").append(str);
        }

        function socialGraph_2(data) {
            var useddays = parseFloat(data.d[2].useddays);
            var leavename = data.d[2].leavename;
            var balance = parseFloat(data.d[2].balance);
            Morris.Donut({
                element: 'leave_3',
                data: [
                 { value: useddays, label: leavename + ' - Used' },
                       { value: balance, label: leavename + ' - Balance' }
                ],
                labelColor: '#666666',
                colors: [$ruby_red, $jet_blue, $go_green, $lemon_yellow, $primary_color, $nagpur_orange, $default_black],
                formatter: function (x) { return x }
            });
        }
        // For Attendacne 

        function drawChart3(adata) {

            var p = [];
            var a = [];
            var noofdays = [];
            for (var i = 0; i < adata.length; i += 1) {
                if (adata[i].monthname == 'Jan') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Feb') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Mar') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Apr') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'May') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Jun') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Jul') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Aug') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Sep') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Oct') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Nov') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
                else if (adata[i].monthname == 'Dec') {
                    noofdays.push(parseFloat(adata[i].noofdays));
                    p.push(parseFloat(adata[i].present));
                    a.push(parseFloat(adata[i].absent));
                }
            }

            var data = google.visualization.arrayToDataTable([
            ['Month', 'No.ofDays', 'Present', 'Absent'],
            ['Jan', noofdays[0], p[0], a[0]],
            ['Feb', noofdays[1], p[1], a[1]],
            ['Mar', noofdays[2], p[2], a[2]],
            ['Apr', noofdays[3], p[3], a[3]],
            ['May', noofdays[4], p[4], a[4]],
            ['Jun', noofdays[5], p[5], a[5]],
            ['Jul', noofdays[6], p[6], a[6]],
            ['Aug', noofdays[7], p[7], a[7]],
            ['Sep', noofdays[8], p[8], a[8]],
            ['Oct', noofdays[9], p[9], a[9]],
            ['Nov', noofdays[10], p[10], a[10]],
            ['Dec', noofdays[11], p[11], a[11]]]);

            var options = {
                width: 'auto',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$jet_blue, $go_green, $ruby_red, $primary_color, $lemon_yellow, $nagpur_orange, $default_grey],
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
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('myatt_chart'));
            chart.draw(data, options);
        }

        // Calendar

        function BindEventCalender(evndata) {
            var color = "";
            var caldata = [];
            for (var i = 0; i < evndata.length ; i++) //evndata.length
            {
                if (evndata[i].heading == 'P')
                    color = '#6ac280';
                else if (evndata[i].heading == 'A')
                    color = '#e84f4c';
                else if (evndata[i].heading == 'W')
                    color = '#5473b8';
                else color = '#e89344';
                var eachevent = { title: evndata[i].heading, start: new Date(evndata[i].year, evndata[i].month - 1, evndata[i].date), color: color };
                caldata.push(eachevent);
            }
            //   alert(caldata);

            var calendar = $('#usercalendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month'
                },
                selectable: true,
                selectHelper: true,

                editable: true,
                events: caldata
            });
        }

    </script>
</head>
<body style="background-color: white">
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Dashboard</h2>
                    </div>
                    <%--<div class="pull-right">
                        <ul class="stats">
                            <li class="color-first">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe037;"></span>
                                <div class="details">
                                    <span class="big">$879,89</span>
                                    <span>Balance</span>
                                </div>
                            </li>
                            <li class="color-second hidden-phone">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe052;"></span>
                                <div class="details" id="date-time">
                                    <span>Date </span>
                                    <span>Day, Time</span>
                                </div>
                            </li>
                        </ul>
                    </div>--%>
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe097;"></span>My Attendance Chart
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="myatt_chart" style="min-height: 238px"></div>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="widget ">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe095;"></span>My Leave Balance
                                </div>
                            </div>
                            <div class="widget-body">
                                <div class="row-fluid">
                                    <div class="span6">
                                        <div id="leave_0" style="height: 150px;"></div>
                                        <table id="leavedata1" class="table table-bordered table-condensed table-striped no-margin">
                                        </table>
                                    </div>
                                    <div class="span6">
                                        <div id="leave_1" style="height: 150px;"></div>
                                        <table id="leavedata2" class="table table-bordered table-condensed table-striped no-margin">
                                        </table>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon=""></span>Action Item Queue
                                </div>
                            </div>
                            <div class="widget-body">
                                <table class="table table-condensed table-bordered no-margin">
                                    <thead>
                                        <tr>
                                            <th style="width: 40%">Pending Items in Queue</th>
                                            <th style="width: 15%">No. of Items
                                            </th>
                                            <th style="width: 15%">0-5 days
                                            </th>
                                            <th style="width: 15%">6-10 days
                                            </th>
                                            <th style="width: 15%">> 10 Days
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="success">
                                            <td>Leave Application
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="lblleave" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label1" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label2" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label3" runat="server" Text="0"></asp:Label></a></td>
                                        </tr>
                                        <tr class="error">
                                            <td>Performance Appraisals
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="Label4" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label5" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label6" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label7" runat="server" Text="0"></asp:Label></a></td>
                                        </tr>
                                        <tr class="info">
                                            <td>Exit Workflows
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="Label8" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label9" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label10" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label11" runat="server" Text="0"></asp:Label></a></td>
                                        </tr>
                                        <tr class="warning">

                                            <td>Travel Approvals
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="Label12" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label13" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label14" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label15" runat="server" Text="0"></asp:Label></a></td>

                                        </tr>
                                        <tr class="success">
                                            <td>Business Reimbursements
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="Label16" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label17" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label18" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="Label19" runat="server" Text="0"></asp:Label></a></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget ">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Head Count Report
                                </div>
                                <div class="btn-group" style="float: right">
                                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="span12"
                                        AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="widget-body" id="divheadcount" runat="server">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span8">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe052;"></span>Calendar
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id='usercalendar'></div>
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe040;"></span>Celebrations
                 
                                </div>
                            </div>

                            <div class="widget-body">
                                <div id="scrollbar-two">
                                    <div class="scrollbar">
                                        <div class="track">
                                            <div class="thumb">
                                                <div class="end"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="viewport">
                                        <div class="overview">
                                            <div id="chats">
                                                <div class="tab-widget">
                                                    <% Response.Write(Session["Birthday"].ToString()); %>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>


</body>

<!-- Mirrored from srinubasava.com/startup/index.html by HTTrack Website Copier/3.x [XR&CO'2013], Tue, 06 May 2014 12:52:55 GMT -->
</html>


