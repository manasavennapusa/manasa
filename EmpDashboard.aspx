<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpDashboard.aspx.cs" Inherits="EmpDashboard" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <meta name="author" content="Srinu Basava" />
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport" />
    <meta name="description" content="StartUp Admin UI" />
    <meta name="keywords" content="StartUp Admin UI, Admin UI, Admin Dashboard, Srinu Basava, Best admin UI, Best backend UI, Best Dashboard, Responsive admin UI, Responsive dashboard, Responsive Backend, Mobile admin, Mobile Backend, Mobile Dashboard" />
    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet" />
    <%-- the below three lines are to link bootstrap to this page --%>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
    <%--<script/ src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script/>--%>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>

    <link href="mixin.css" rel="stylesheet" type="mixin/css" />
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

    <link href="../build/nv.d3.css" rel="stylesheet" type="text/css">
    <script src="https://cdnjs.cloudflare.com/ajax/libs/d3/3.5.2/d3.min.js" charset="utf-8"></script>
    <script src="../build/nv.d3.js"></script>

    <style>
        .dashboard-wrapper .main-container .widget .widget-header, .dashboard-wrapper .main-container .widget-border .widget-header {
            background-color: #f2f2f2;
            /* Fallback Color */
            background-image: -webkit-gradient(linear, left top, left bottom, from(white), to(#4a98c9));
            /* Saf4+, Chrome */
            background-image: -webkit-linear-gradient(top, white, #4a98c9);
            /* Chrome 10+, Saf5.1+, iOS 5+ */
            background-image: -moz-linear-gradient(top, white, #4a98c9);
            /* FF3.6 */
            background-image: -ms-linear-gradient(top, white, #4a98c9);
            /* IE10 */
            background-image: -o-linear-gradient(top, white, #4a98c9);
            /* Opera 11.10+ */
            background-image: linear-gradient(top, white, #4a98c9);
            -webkit-border-radius: 3px 3px 0 0;
            -moz-border-radius: 3px 3px 0 0;
            border-radius: 3px 3px 0 0;
            border-bottom: 1px solid #d9d9d9;
            height: 40px;
            line-height: 30px;
            padding: 5px 10px;
        }
    </style>
    <%-- end css modification for height and color of the divisions --%>

    <%-- <script>
        function myFunction() {
            alert("Break Time is start now. To close break time click on ok button");
            break_out();
        }
    </script>--%>
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

          
            // For Leave Balance
            function socialGraph(data) {

                var useddays = (data.d[0].useddays);
                var leavename = data.d[0].leavename;
                if (leavename == "Flexi Leave") {
                    leavename = "FL";
                }
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
                str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 10px;font-weight: bold;'>&nbsp;" + data.d[0].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 10px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 10px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
                $("#leavedata1").append(str);
            }


            

            // For Leave Balance
            function socialGraph1(data) {

                var useddays = parseFloat(data.d[1].useddays);
                var leavename = data.d[1].leavename;
                if (leavename == "Flexi Leave") {
                    leavename = "FL";
                }
                var balance = parseFloat(data.d[1].balance);
                Morris.Donut({
                    element: 'leave_1',
                    data: [
                           { value: useddays, label: leavename + ' - Used' },
                           { value: balance, label: leavename + ' - Balance' }
                    ],
                    labelColor: '#666666',
                    colors: [$jet_blue, $primary_color, $go_green, $default_black, $ruby_red, $lemon_yellow, $nagpur_orange],
                    formatter: function (x) { return x }
                });
                var str = "";
                str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 10px;font-weight: bold;'>&nbsp;" + data.d[1].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 10px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 10px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
                $("#leavedata2").append(str);
            }

            // For Leave Balance
            function socialGraph2(data) {

                var useddays = parseFloat(data.d[2].useddays);
                var leavename = data.d[2].leavename;
                var balance = parseFloat(data.d[2].balance);
                Morris.Donut({
                    element: 'leave_2',
                    data: [
                           { value: useddays, label: leavename + ' - Used' },
                           { value: balance, label: leavename + ' - Balance' }
                    ],
                    labelColor: '#666666',
                    colors: [$primary_color, $jet_blue, $go_green, $default_black, $ruby_red, $lemon_yellow, $nagpur_orange],
                    formatter: function (x) { return x }
                });
                var str = "";
                str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 10px;font-weight: bold;'>&nbsp;" + data.d[2].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 10px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 10px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
                $("#leavedata3").append(str);
            }

            // For Leave Balance
            function socialGraph3(data) {

                var useddays = parseFloat(data.d[3].useddays);
                var leavename = data.d[3].leavename;
                var balance = parseFloat(data.d[3].balance);
                Morris.Donut({
                    element: 'leave_3',
                    data: [
                           { value: useddays, label: leavename + ' - Used' },
                           { value: balance, label: leavename + ' - Balance' }
                    ],
                    labelColor: '#666666',
                    colors: [$primary_color, $jet_blue, $go_green, $default_black, $ruby_red, $lemon_yellow, $nagpur_orange],
                    formatter: function (x) { return x }
                });
                var str = "";
                str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 10px;font-weight: bold;'>&nbsp;" + data.d[3].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 10px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 10px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
                $("#leavedata4").append(str);
            }

            // For Leave Balance
            function socialGraph4(data) {

                var useddays = parseFloat(data.d[4].useddays);
                var leavename = data.d[4].leavename;
                var balance = parseFloat(data.d[4].balance);
                Morris.Donut({
                    element: 'leave_4',
                    data: [
                           { value: useddays, label: leavename + ' - Used' },
                           { value: balance, label: leavename + ' - Balance' }
                    ],
                    labelColor: '#666666',
                    colors: [$primary_color, $jet_blue, $go_green, $default_black, $ruby_red, $lemon_yellow, $nagpur_orange],
                    formatter: function (x) { return x }
                });
                var str = "";
                str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 10px;font-weight: bold;'>&nbsp;" + data.d[0].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 10px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 10px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
                $("#leavedata5").append(str);
            }

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
                        socialGraph1(data);
                        //socialGraph2(data);
                        //socialGraph3(data);
                        //socialGraph4(data);
                    }
                },
                failure: function (response) {
                    // alert(response.d);

                },
                error: function (response) {
                    //  alert(response.d);

                }
            });
            

            // Leave Balance1

            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/lnkbtnNext1_Click",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(leaveparameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        if (ispostback) {
                            socialGraph(data);
                            socialGraph1(data);
                        }
                        socialGraph2(data);
                        socialGraph3(data);
                        //socialGraph4(data);
                    }
                },
                failure: function (response) {
                    // alert(response.d);

                },
                error: function (response) {
                    //  alert(response.d);

                }
            });

            // Leave Balance2

            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/GetLeaveBalance2",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(leaveparameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        //socialGraph(data);
                        //socialGraph1(data);
                        //socialGraph2(data);
                        //socialGraph3(data);
                        socialGraph4(data);
                    }
                },
                failure: function (response) {
                    // alert(response.d);

                },
                error: function (response) {
                    //  alert(response.d);

                }
            });

            // Leave Balance3

            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/GetLeaveBalance3",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(leaveparameters),
                dataType: "json",
                success: function (data) {
                    if (data.d.length > 0) {
                        socialGraph(data);
                        socialGraph1(data);
                        socialGraph2(data);
                        socialGraph3(data);
                        socialGraph4(data);
                    }
                },
                failure: function (response) {
                    // alert(response.d);

                },
                error: function (response) {
                    //  alert(response.d);

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
                    //  alert(response.d);
                },
                error: function (response) {
                    //  alert(response.d);
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
                    //  alert(response.d);
                },
                error: function (response) {
                    //  alert(response.d);
                }
            });


        });

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

        //function BindEventCalender(evndata) {
        //    var color = "";
        //    var caldata = [];
        //    for (var i = 0; i < evndata.length ; i++) //evndata.length
        //    {
        //        if (evndata[i].heading == 'P')
        //            color = '#6ac280';
        //        else if (evndata[i].heading == 'A')
        //            color = '#e84f4c';
        //        else if (evndata[i].heading == 'W')
        //            color = '#5473b8';
        //        else color = '#e89344';
        //        var eachevent = { title: evndata[i].heading, start: new Date(evndata[i].year, evndata[i].month - 1, evndata[i].date), color: color };
        //        caldata.push(eachevent);
        //    }
        //    //   alert(caldata);

        //    var calendar = $('#usercalendar').fullCalendar({
        //        header: {
        //            left: 'prev,next today',
        //            center: 'title',
        //            right: 'month'
        //        },
        //        selectable: true,
        //        selectHelper: true,

        //        editable: true,
        //        events: caldata
        //    });
        //}

    </script>
    <%-- reportee leave balance script start --%>
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
                       
            var leaveParametersReportee = {
                empcode: '<%=Session["empcodeReportee"].ToString()%>',
                gender: '<%=Session["genderReportee"].ToString()%>'
            };

           

            // For Reportee Leave Balance start
            function socialGraph10(data) {

                var useddays = (data.da[0].useddays);
                var leavename = (data.da[0].leavename);
                if (leavename == "Flexi Leave") {
                    leavename = "FL";
                }
                var balance = parseFloat(data.da[0].balance);
                Morris.Donut({
                    element: 'DivReportee',
                    data: [
                           { value: useddays, label: leavename + ' - Used' },
                           { value: balance, label: leavename + ' - Balance' }
                    ],
                    labelColor: '#666666',
                    colors: [$primary_color, $jet_blue, $go_green, $default_black, $ruby_red, $lemon_yellow, $nagpur_orange],
                    formatter: function (x) { return x }
                });
                var str = "";
                str = "<tbody><tr><td><span class='name'>Entitled:</span><span class='value text-info' style='font-size: 10px;font-weight: bold;'>&nbsp;" + data.da[0].entitleddays + "</span></td><td><span class='name'>Balance :</span><span class='value text-success' style='font-size: 10px;font-weight: bold;'>&nbsp;" + balance + "</span></td><td><span class='name'>Used :</span><span class='value text-warning' style='font-size: 10px;font-weight: bold;'>&nbsp;" + useddays + "</span></td></tr></tbody>";
                $("#ReporteeTbl").append(str);
            }
            // For Reportee Leave Balance end
            
            // reporteeLeaveBalance start
            $.ajax({
                type: "POST",
                url: "EmpDashboard.aspx/ddlReportee_SelectedIndexChanged2",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(leaveparametersReportee),
                dataType: "json",
                success: function (data) {
                    if (data.da.length > 0) {
                        socialGraph10(data);
                        //socialGraph1(data);
                        //socialGraph2(data);
                        //socialGraph3(data);
                        //socialGraph4(data);
                    }
                },
                failure: function (response) {
                    // alert(response.d);

                },
                error: function (response) {
                    //  alert(response.d);

                }
            });
            
            // reporteeLeaveBalance end
        
    </script>
    <%-- reportee leave balance script ends --%>
    <%-- script for pie chart --%>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script>
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
              ['Task', 'Hours per Day'],
              ['Work', 11],
              ['Eat', 2],
              ['Commute', 2],
              ['Watch TV', 2],
              ['Sleep', 7]
            ]);

            var options = {
                title: 'My Daily Activities'
            };

            var chart = new google.visualization.PieChart(document.getElementById('div_id'));

            chart.draw(data, options);
        }
    </script>
    <style>
        .ModelBackground {
            background-color: black;
            filter: alpha(opacity=90) !important;
            opacity: 0.6 !important;
            z-index: 20;
        }

        .ModelPopup {
            margin-bottom: 13cm;
            padding: 20px 0px 24px 10px;
            position: relative;
            width: 450px;
            height: 360px;
            background-color: #ddd;
            border: 5px solid;
        }

        .clr {
            color: steelblue;
        }

        .scrollit {
            overflow-y: scroll;
            height: 247px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="scr" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <h2>Dashboard</h2>
                    </div>

                </div>
                <div>
                    <div class="span6" style="padding: 20px;">
                    </div>
                    <div id="a" class="row-fluid" runat="server">
                        <%--<div class="span6" style="padding: 20px;">
                        </div>--%>

                        <div id="logBreak" class="row-fluid" runat="server">
                            <div class="span6" style="padding: 20px;">
                                <%--<asp:Button ID="btn_loging" runat="server" Width="100px" CssClass="btn btn-success btn-xs" Text="Log-In" OnClick="btn_loging_Click" OnClientClick="" />--%>
                                <asp:Label ID="lblLogedIn" runat="server" Width="60px" CssClass="title" Font-Bold="true" Font-Size="Medium" ForeColor="#009900" Text="Log-In:"></asp:Label>
                                <asp:Label ID="lblLoginText" runat="server" Width="90px" Text=""></asp:Label>
                                <%--<asp:Button ID="Button2" runat="server" Width="100px" Visible="false" CssClass="btn btn-warning  btn-xs" Text="Break" OnClick="Button2_Click" />--%>
                                <%--<asp:Button ID="btn_logout" runat="server" Width="100px" CssClass="btn btn-danger btn-xs" Text="Log-Out" OnClick="btn_logout_Click" OnClientClick="" />--%>
                                <asp:Label ID="lblLogedOut" runat="server" Width="72px" CssClass="title" Font-Bold="true" Font-Size="Medium" ForeColor="#cc3300" Text="Log-Out:"></asp:Label>
                                <asp:Label ID="lblLogoutText" runat="server" Width="100px" Text=""></asp:Label>
                                <%--<asp:Label ID="lblBreakHour" runat="server" Width="97px" CssClass="title" Font-Bold="true" Font-Size="Medium" ForeColor="#0066ff" Text="Break Hour:"></asp:Label>
                                <asp:Label ID="lblBreakHourText" runat="server" Width="50px" Text="00:00:00"></asp:Label>--%>
                                <%--<a style="float: left">
                                    <a href="" target="_blank">
                                        <img src="images/30er.jpg" style="padding-left: 25px" />
                                    </a>
                                </a>--%>
                            </div>

                            <div class="span6" style="padding-right: 150px">
                                <div id="alertLate30" runat="server">
                                    <a style="float: right" class="quick-action-btn span5 input-bottom-margin" title="You are <% if (Session["log_time"] != null) Response.Write(Session["log_time"].ToString()); %> late, please come on time.">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe1cb;"></span>
                                        <p class="no-margin">Alert</p>
                                        <div class="label label-important">You are  <% if (Session["log_time"] != null) Response.Write(Session["log_time"].ToString()); %> late</div>
                                    </a>
                                </div>

                                <div id="alertLate15" runat="server">
                                    <a style="float: right" class="quick-action-btn span5 input-bottom-margin" title="You are <% if (Session["log_time"] != null) Response.Write(Session["log_time"].ToString()); %> late,, please come on time. ">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe1cb;"></span>
                                        <p class="no-margin">Alert</p>
                                        <div class="label label-warning">You are <% if (Session["log_time"] != null) Response.Write(Session["log_time"].ToString()); %> minutes late </div>
                                    </a>
                                </div>

                                <div id="alertOnTime" runat="server">
                                    <a style="float: right;" class="quick-action-btn span5 input-bottom-margin" title="">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe1cb;"></span>
                                        <p class="no-margin">Alert</p>
                                        <div class="label label-success">You are <% if (Session["log_time"] != null) Response.Write(Session["log_time"].ToString()); %> minutes early </div>
                                    </a>
                                </div>

                            </div>

                            <div class="span6" style="padding-left: 25px">
                                <div id="Div10" runat="server">
                                </div>
                            </div>




                            <div class="clearfix"></div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <%--start row 0  --%>
                    <%-- column chart my reportee Attendance & my reportee leave balance --%>
                    <div id="managerDiv" class="row-fluid" runat="server">

                        <div class="span6" runat="server" id="div5">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe097;"></span>My Reportee Attendance
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <%-- content Ajax for reportee leave balance starts --%>
                                    <%--   <div id="ForReporteeLeave" class="row-fluid">
                                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                            <ContentTemplate>
                                                <div class="widget-body">
                                                    <div id="divlnkbtn1" style="padding-left: 500px; padding-right: 1100px;">
                                                    <div id="divlnkbtn1">
                                                        <asp:LinkButton ID="lnkbtnNext1" runat="server" Font-Size="XX-Small" ForeColor="#0099ff" Font-Bold="true" PostBackUrl="~/EmpDashboard.aspx">Next</asp:LinkButton>
                                                    </div>
                                                    <div class="row-fluid">
                                                        <div id="Div3" class="span6" runat="server">
                                                            <div id="DivReportee" style="height: 150px;"></div>
                                                            <table id="ReporteeTbl" class="table table-bordered table-condensed table-striped no-margin" style="border-radius: 1px">
                                                            </table>
                                                        </div>
                                                        <div class="span6">
                                                            <div id="Div8" style="height: 150px;"></div>
                                                            <table id="Table2" class="table table-bordered table-condensed table-striped no-margin">
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                            <ContentTemplate>
                                                <div id="divlnkbtn2" style="padding-left: 500px; padding-right: 1100px;">
                                                <div id="divlnkbtn2">
                                                    <asp:LinkButton ID="lnkbtnNext2" runat="server" Font-Size="XX-Small" ForeColor="#0099ff" Font-Bold="true">Next</asp:LinkButton>
                                                </div>
                                                <div id="Div9" class="span6" runat="server">
                                                    <div id="Div10" style="height: 150px;"></div>
                                                </div>
                                                
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                            <ContentTemplate>
                                                <div id="divlnkbtn3" style="padding-left: 500px; padding-right: 1100px;">
                                                    <asp:LinkButton ID="lnkbtnNext3" runat="server" Font-Size="XX-Small" ForeColor="#0099ff" Font-Bold="true">Next</asp:LinkButton>
                                                </div>
                                                
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                            </div>--%>
                                    <%-- content Ajax for reportee leave balance ends --%>
                                    <div id="myReporteeAttendance"></div>
                                    <div>
                                        <table style="text-align: center">
                                            <tr>
                                                <td style="padding-left: 50px;">
                                                    <img src="images/blue.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: <%= Session["totalEmpReportee"] %> </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/green.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: <%= Session["totalEmpReporteePresent"] %> </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/orange.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label id="absentEmployeeReportee" style="padding-top: 9px"></label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 50px;">
                                                    <img src="images/blue.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: 100% </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/green.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: <%= Session["totalPresentEmpRep"] %> </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/orange.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label id="absentEmployeeReporteePrcnt" runat="server" style="padding-top: 9px"></label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span6" runat="server" id="div7">
                            <div class="widget" style="height: 350px">
                                <div class="widget-header">
                                    <div class="title">

                                        <span class="fs1" aria-hidden="true" data-icon="&#xe040;"></span>My Reportee Leave Balance
                                        
                                    </div>
                                    <div style="float: right; text-decoration-color: blue">
                                        <a id="leabeBalanceLink" runat="server" title="Leave Balance" href="~/Leave/reportleavedateils.aspx">Leave Balance<span style="padding-right: 35px"></span></a>
                                        <asp:DropDownList ID="ddlReportee" runat="server" CssClass="span2" OnSelectedIndexChanged="ddlReportee_SelectedIndexChanged2" AutoPostBack="true" Width="150px">
                                            <asp:ListItem Text="-Select-" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <h6>
                                        <asp:Label ID="lblType" runat="server" Text="Type" Style="padding-left: 77px; font: medium; color: black"></asp:Label>
                                        <asp:Label ID="lblEntitled" runat="server" Text="Entitled" Style="padding-left: 95px; color: black"></asp:Label>
                                        <asp:Label ID="lblUsed" runat="server" Text="Used" Style="padding-left: 66px; color: black"></asp:Label>
                                        <asp:Label ID="lblBalance" runat="server" Text="Balance" Style="padding-left: 58px; color: black"></asp:Label>
                                    </h6>
                                    <div class="widget-body scrollit" id="div6" runat="server">
                                        <table class="table table-condensed table-bordered no-margin">
                                            <tbody>
                                                <tr class="error">
                                                    <td style="width: 35%; background-color: lightsteelblue; font-size: small; text-align: center">Casual & SickLeave
                                                    </td>
                                                    <td style="background-color: skyblue; text-align: center"><a href="#">
                                                        <asp:Label ID="lblEntitledSL" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="background-color: skyblue; text-align: center"><a href="#">
                                                        <asp:Label ID="lblUsedSL" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="background-color: skyblue; text-align: center"><a href="#">
                                                        <asp:Label ID="lblBalanceSL" runat="server" Text="0" ForeColor="#009900" Font-Size="Small"></asp:Label></a></td>
                                                </tr>
                                                <tr class="error">
                                                    <td style="background-color: ThreeDHighlight; font-size: small; text-align: center">Earned Leave
                                                    </td>
                                                    <td style="text-align: center"><a href="#">
                                                        <asp:Label ID="lblEntitledFL" runat="server" Text="0" ForeColor="#ff9900" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center"><a href="#">
                                                        <asp:Label ID="lblUsedFL" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center"><a href="#">
                                                        <asp:Label ID="lblBalanceFL" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>
                                                </tr>
                                                <tr class="error">
                                                    <td style="background-color: lightblue; font-size: small; text-align: center">Probationary Leave
                                                    </td>
                                                    <td style="text-align: center; background-color: lightblue"><a href="#">
                                                        <asp:Label ID="lblEntitledPL" runat="server" Text="0" ForeColor="#ff9900" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center; background-color: lightblue"><a href="#">
                                                        <asp:Label ID="lblUsedPL" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center; background-color: lightblue"><a href="#">
                                                        <asp:Label ID="lblBalancePL" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>
                                                </tr>
                                                <tr id="mtrnityLeave" runat="server" class="error">
                                                    <td style="background-color: ThreeDHighlight; font-size: small; text-align: center">Maternity Leave
                                                    </td>
                                                    <td style="text-align: center"><a href="#">
                                                        <asp:Label ID="lblEntitledML" runat="server" Text="0" ForeColor="#ff9900" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center"><a href="#">
                                                        <asp:Label ID="lblUsedML" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center"><a href="#">
                                                        <asp:Label ID="lblBalanceML" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>
                                                </tr>
                                                <tr id="ptrnityLeave" runat="server" class="error">
                                                    <td style="background-color: lightblue; font-size: small; text-align: center">Paternity Leave
                                                    </td>
                                                    <td style="text-align: center; background-color: lightblue"><a href="#">
                                                        <asp:Label ID="lblEntitledPTL" runat="server" Text="0" ForeColor="#ff9900" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center; background-color: lightblue"><a href="#">
                                                        <asp:Label ID="lblUsedPTL" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                    <td style="text-align: center; background-color: lightblue"><a href="#">
                                                        <asp:Label ID="lblBalancePTL" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>
                                                </tr>

                                            </tbody>
                                        </table>
                                    </div>

                                </div>

                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <%-- end row 0 --%>


                    <%--start row 1  --%>

                    <%-- column chart Attendance & Dept wise attendance column chart --%>
                    <div id="divattendance" class="row-fluid" runat="server">

                        <div class="span6" runat="server" id="divAttendnace1">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe097;"></span>Attendance
                 
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="col_chart"></div>
                                    <div>
                                        <table style="text-align: center">
                                            <tr>
                                                <td style="padding-left: 50px;">
                                                    <img src="images/blue.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: <%= Session["totalEmp"] %> </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/green.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: <%= Session["prsntEmployee1"] %> </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/orange.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label id="absentEmployee" runat="server" style="padding-top: 9px"></label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 50px;">
                                                    <img src="images/blue.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: 100% </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/green.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label style="padding-top: 9px">: <%= Session["totalPresentEmp"] %> </label>
                                                </td>
                                                <td style="padding-left: 20px;">
                                                    <img src="images/orange.PNG" alt="View">
                                                </td>
                                                <td>
                                                    <label id="lblAbsentEmpInPrcnt" runat="server" style="padding-top: 9px"></label>
                                                </td>
                                            </tr>
                                            <br />
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span6" runat="server" id="divAttendnace2">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe097;"></span>Department wise Attendance
                                        <span style="padding-left:147px"></span>
                                    </div>
                                    <asp:DropDownList ID="ddl_department" runat="server" CssClass="span4" OnSelectedIndexChanged="ddl_department_SelectedIndexChanged" Width="145px" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div class="widget-body">
                                    <div id="deptAttendanceColumnChart"></div>
                                    <div>
                                        <table>
                                            <tr>
                                                <td style="padding-left: 50px"></td>
                                                <td style="padding-left: 50px">
                                                    <img src="images/blue.PNG" alt="View">
                                                </td>
                                                <td style="padding-left: 50px">
                                                    <img src="images/green.PNG" alt="View">
                                                </td>
                                                <td style="padding-left: 50px">
                                                    <img src="images/orange.PNG" alt="View">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="padding-left: 50px">
                                                    <label><%= Session["dept_name"] %></label>
                                                </td>
                                                <td id="tdRecruitment" runat="server" style="padding-left: 50px">
                                                    <label>: 100%</label></td>
                                                <td id="tdRecruitment0" runat="server" style="padding-left: 50px">
                                                    <label>: 0%</label></td>
                                                <td style="padding-left: 50px">
                                                    <label>: <%= Session["totalPresentEmpDept1"] %></label></td>
                                                <td style="padding-left: 50px">
                                                    <label id="totalAbbsentDept1"></label>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td style="padding-left: 50px">
                                                    <label>Functional </label>
                                                </td>
                                                <td id="tdDomestic" runat="server" style="padding-left: 50px">
                                                    <label>: 100%</label></td>
                                                <td id="tdDomestic0" runat="server" style="padding-left: 50px">
                                                    <label>: 0%</label></td>
                                                <td style="padding-left: 50px">
                                                    <label>: <%= Session["totalPresentEmpDept2"] %></label></td>
                                                <td style="padding-left: 50px">
                                                    <label id="totalAbbsentDept2"></label>
                                                </td>
                                            </tr>--%>
                                            <%--<tr>
                                                <td style="padding-left: 50px">
                                                    <label>Support Function :</label></td>
                                                <td id="tdSF" runat="server" style="padding-left: 50px">
                                                    <label>: 100%</label></td>
                                                <td id="tdsf0" runat="server" style="padding-left: 50px">
                                                    <label>: 0%</label></td>
                                                <td style="padding-left: 50px">
                                                    <label>: <%= Session["totalPresentEmpDept3"] %></label></td>
                                                <td style="padding-left: 50px">
                                                    <label id="totalAbbsentDept3"></label>
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </div>
                                </div>
                                <br />
                                <br />
                            </div>
                        </div>



                    </div>
                    <%-- end row 1 --%>

                    <%-- Start row 2 --%>


                    <div class="row-fluid" id="divAlertsUser" runat="server" style="height: 360px">
                        <div class="span6">
                            <div class="widget" style="height: 355px">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe040;"></span>Celebrations
                                    </div>
                                </div>
                                <%--<div class="widget">
                                <div>
                                    <div>
                                        <asp:Label ID="Label4" runat="server" Text="" Style="padding-left: 20px; padding-right: 30px;"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="Name" Style="padding-left: 20px; padding-right: 60px;"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text="Occasion" Style="padding-left: 50px; padding-right: 80px;"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Date" Style="padding-left: 40px; padding-right: 80px;"></asp:Label>
                                    </div>
                                </div>--%>
                                <div class="widget-body">
                                    <div>
                                        <div>
                                            <div class="track">
                                                <div class="thumb">
                                                    <div class="end"></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="viewport">
                                            <div class="overview">
                                                <div id="Div9">
                                                    <div class="tab-widget" style="height: 289px; overflow: auto;">
                                                        <% Response.Write(Session["Birthday"].ToString()); %>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <%-- attrition report starts --%>
                        <%--<div class="span6" id="attritionReport" runat="server">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe095;"></span>Attrition report  
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="emp_piechart"></div>
                                    <table style="text-align: center">
                                        <tr>
                                            <td style="padding-left: 50px;">
                                                <img src="images/green.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">:  <%=Session["joinedInNumber"] %> </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/orange.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: <%=Session["attritionInNumber"] %> </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/yellow.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: 3</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 50px;">
                                                <img src="images/green.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: Joined </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/orange.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">:Attrition </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/yellow.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: Offered</label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </div>
                            </div>
                        </div>--%>
                        <%-- attrition report ends --%>
                        <div class="span6">
                            <div class="widget box" style="height: 450px">
                                <div class="widget-header">
                                    <div class="title">
                                        <a href="#jobs" data-icon="&#xe040;" data-toggle="collapse">Alerts</a>
                                    </div>
                                </div>
                                <div class="widget-body" id="div13" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <%--<th style="width: 40%">Pending/Approved Items in Queue</th>--%>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending
                                                </th>
                                                <%--<th style="width: 15%; text-align: center">Pending as BH 
                                                </th>
                                                <th style="width: 15%">Pending as HR 
                                                </th>--%>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="error">
                                                <td style="font-size: small; background-color: lightsteelblue; text-align: center">Leave Application
                                                </td>
                                                <td style="background-color: skyblue; font-size: small; text-align: center"><a href="leave/leaveapproval.aspx?hr=0&approvel_status=0">
                                                    <asp:Label ID="Label1" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <td style="background-color: skyblue; font-size: small; text-align: center;display:none"><a href="leave/leaveapproval.aspx?hr=0&approvel_status=1">
                                                    <asp:Label ID="Label2" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <td style="background-color: skyblue; font-size: small; text-align: center;display:none"><a href="leave/leaveapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="Label6" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td style="background-color: skyblue; font-size: small; text-align: center"><a href="leave/leaveapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="Label7" runat="server" Text="0" ForeColor="#009900" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td style="background-color:skyblue"><a href="leave/leavestatus.aspx?leavestatus=2&hr=0">
                                                <asp:Label ID="lblleave235" runat="server" Text="Rejected(0)" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>
                                            <tr id="Tr1" class="error" runat="server" visible="false">
                                                <td style="font-size: small; background-color: ThreeDHighlight; text-align: center">OD Application
                                                </td>
                                                <td style="text-align: center"><a href="leave/odapproval.aspx?hr=0&approvel_status=0">
                                                    <asp:Label ID="LblodLM" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odapproval.aspx?hr=0&approvel_status=1">
                                                    <asp:Label ID="LblodBH" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="Label8" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td style="text-align: center"><a href="leave/odapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="Label9" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td><a href="leave/odstatus.aspx?leavestatus=2">
                                                <asp:Label ID="lblODrejected" runat="server" Text="Rejected(0)" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>


                                             <tr class="error">
                                                <td style="font-size: small; background-color: lightsteelblue; text-align: center">Query
                                                </td>
                                                <td style="background-color: skyblue;text-align: center"><a href="Query/AllqueryStatus.aspx">
                                                    <asp:Label ID="labelpendingqueries" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                              
                                            </tr>
                                            <%--<tr class="success">
                                                <td style="font-size: small; text-align: center">Appraisals
                                                </td>
                                                <td style="text-align: center"><a href="Appraisal/ViewAllGoals.aspx">
                                                    <asp:Label ID="Label10" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>--%>
                                            <%--<td><a href="#">
                                                <asp:Label ID="lblapp5" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblapp10" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblappabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            <%--</tr>--%>
                                            <%--<tr class="success">
                                            <td>Exit Workflows
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexit" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexit5" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexit10" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexitabove" runat="server" Text="0"></asp:Label></a></td>
                                        </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="widget-body" id="divapprsl" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending Goal
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending Rating
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                             <tr class="error">
                                                <td style="font-size: small; text-align: center">E-Evaluation
                                                </td>
                                                <td style="text-align: center"><a href="~/appraisal/ReviewGoalsByManager.aspx">
                                                    <asp:Label ID="Label10" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="~/appraisal/ManagerRating.aspx">
                                                    <asp:Label ID="lblRating" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                            </tr>
                                        </tbody>
                                    </table
                                </div>
                                <br />
                              

                                <div class="widget-body" id="div11" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending 
                                                </th>
                                                <th style="width: 15%; text-align: center">Approved 
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                           <tr class="error">
                                                <td style="font-size: small;  background-color: lightsteelblue; text-align: center"> My Query
                                                </td>
                                                <td style="text-align: center"><a href="Query/AllqueryStatus.aspx">
                                                    <asp:Label ID="Labelqurtupending" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="Query/AllqueryStatus.aspx">
                                                    <asp:Label ID="ladbelappquery" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                                <br />
                            



                                <div class="widget-body" id="div14" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <%--<th style="width: 40%">Pending/Approved Items in Queue</th>--%>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending
                                                </th>
                                                <th style="width: 15%; text-align: center">Approved
                                                </th>
                                                <th style="width: 15%; text-align: center">Rejected
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="error">
                                                <td style="background-color: lightsteelblue; font-size: small; text-align: center">My Leave Application
                                                </td>
                                                <td style="background-color: skyblue; text-align: center"><a href="leave/leavestatus.aspx?leavestatus=0">
                                                    <asp:Label ID="Label11" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <td style="background-color: skyblue; text-align: center"><a href="leave/leavestatus.aspx?leavestatus=1">
                                                    <asp:Label ID="Label12" runat="server" Text="0" ForeColor="#009900" Font-Size="Small"></asp:Label></a></td>
                                                <td style="background-color: skyblue; text-align: center"><a href="leave/leavestatus.aspx?leavestatus=3">
                                                    <asp:Label ID="Label13" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>
                                            <tr class="error" style="display: none">
                                                <td style="background-color: ThreeDHighlight; font-size: small; text-align: center">My OD Application
                                                </td>
                                                <td style="text-align: center"><a href="leave/odstatus.aspx?leavestatus=0">
                                                    <asp:Label ID="Label14" runat="server" Text="0" ForeColor="#ff9900" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odstatus.aspx?leavestatus=1">
                                                    <asp:Label ID="Label15" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odstatus.aspx?leavestatus=3">
                                                    <asp:Label ID="Label16" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>
                                            <%--<tr class="success">
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
                                        </tr>--%>
                                            <%--<tr class="success">
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
                                        </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>


                    </div>


                    <div class="row-fluid" id="Div1" runat="server" style="height: 400px">
                        <div id="teamAttendance" class="span6" style="height: 100px" runat="server">
                            <div class="widget box">
                                <div class="widget-header">
                                    <div class="title">
                                        <a href="#jobs" data-icon="&#xe040;" data-toggle="collapse">Team Attendance</a>
                                    </div>
                                </div>
                                <div class="widget-body" id="div2" runat="server">
                                    <%-- content --%>
                                    <div class="title">
                                        <h6>
                                            <asp:Label ID="lblEmpCode" runat="server" Text="Employee" Style="padding-left: 5px; padding-right: 10px; color: black"></asp:Label>
                                            <asp:Label ID="lblIntime" runat="server" Text="In-Time" Style="padding-left: 7px; padding-right: 17px; color: darkgreen"></asp:Label>
                                            <asp:Label ID="lblBreaktime" runat="server" Text="Break-Time" Style="padding-left: 7px; padding-right: 17px; color: darkgreen"></asp:Label>
                                            <asp:Label ID="lblOuttime" runat="server" Text="Out-Time" Style="padding-left: 5px; padding-right: 10px; color: darkgreen"></asp:Label>
                                            <asp:Label ID="lblAvgHour" runat="server" Text="Total-Hour" Style="padding-left: 7px; padding-right: 10px; color: darkgreen"></asp:Label>
                                        </h6>
                                        <%--<asp:Label ID="lblEmployee" runat="server" Text="" Style="padding-left: 20px; padding-right: 10px;"></asp:Label>
                                    <asp:Label ID="lblIntimeText" runat="server" Text="" Style="padding-left: 27px; padding-right: 17px;"></asp:Label>
                                    <asp:Label ID="lblBreaktimeText" runat="server" Text="" Style="padding-left: 27px; padding-right: 17px;"></asp:Label>
                                    <asp:Label ID="lblOuttimeText" runat="server" Text="" Style="padding-left: 27px; padding-right: 10px;"></asp:Label>--%>
                                        <div class="tab-widget" style="padding-left: 0px; height: 255px; overflow: auto;">
                                            <% Response.Write(Session["TA"].ToString()); %>
                                        </div>
                                    </div>
                                </div>
                                <%--<br />--%>
                            </div>
                        </div>
                        <%-- attrition report starts --%>
                        <%--<div class="span6" id="attritionReport" runat="server">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe095;"></span>Attrition report  
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="emp_piechart"></div>
                                    <table style="text-align: center">
                                        <tr>
                                            <td style="padding-left: 50px;">
                                                <img src="images/green.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">:  <%=Session["joinedInNumber"] %> </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/orange.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: <%=Session["attritionInNumber"] %> </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/yellow.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: 3</label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding-left: 50px;">
                                                <img src="images/green.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: Joined </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/orange.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">:Attrition </label>
                                            </td>
                                            <td style="padding-left: 20px;">
                                                <img src="images/yellow.PNG" alt="View">
                                            </td>
                                            <td>
                                                <label style="padding-top: 9px">: Offered</label>
                                            </td>
                                        </tr>
                                    </table>
                                    <br />
                                </div>
                            </div>
                        </div>--%>
                        <%-- attrition report ends --%>
                        <div class="span6">
                            <div class="widget box" style="height: 450px">
                                <div class="widget-header">
                                    <div class="title">
                                        <a href="#jobs" data-icon="&#xe040;" data-toggle="collapse">Alerts</a>
                                    </div>
                                </div>
                                <div class="widget-body" id="divnotificationtotal" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <%--<th style="width: 40%">Pending/Approved Items in Queue</th>--%>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending
                                                </th>
                                                <%--<th style="width: 15%; text-align: center">Pending as BH 
                                                </th>
                                                <th style="width: 15%">Pending as HR 
                                                </th>--%>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="error">
                                                <td style="font-size: small; background-color: lightsteelblue; text-align: center">Leave Application
                                                </td>
                                                <td id="leaveLM" style="background-color: skyblue; font-size: small; text-align: center"><a href="leave/leaveapproval.aspx?hr=0&approvel_status=0">
                                                    <asp:Label ID="lblleave0LM" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <td id="leaveBH" style="background-color: skyblue; font-size: small; text-align: center;display:none"><a href="leave/leaveapproval.aspx?hr=0&approvel_status=1">
                                                    <asp:Label ID="lblleave0BH" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <td id="leaveHR" style="background-color: skyblue; font-size: small; text-align: center;display:none"><a href="leave/leaveapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="lblleave0" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td style="background-color: skyblue; font-size: small; text-align: center"><a href="leave/leaveapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="lblleave16" runat="server" Text="0" ForeColor="#009900" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td style="background-color:skyblue"><a href="leave/leavestatus.aspx?leavestatus=2&hr=0">
                                                <asp:Label ID="lblleave235" runat="server" Text="Rejected(0)" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>



                                            <tr class="error" style="display:none">
                                                <td style="font-size: small; background-color: ThreeDHighlight; text-align: center">OD Application
                                                </td>
                                                <td style="text-align: center"><a href="leave/odapproval.aspx?hr=0&approvel_status=0">
                                                    <asp:Label ID="LabelodLM" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odapproval.aspx?hr=0&approvel_status=1">
                                                    <asp:Label ID="LabelodBH" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="lblODpending" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td style="text-align: center"><a href="leave/odapproval.aspx?hr=1&approvel_status=2">
                                                    <asp:Label ID="lblODapproved" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td><a href="leave/odstatus.aspx?leavestatus=2">
                                                <asp:Label ID="lblODrejected" runat="server" Text="Rejected(0)" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>--%>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>

                                             <tr class="error">
                                                <td style="font-size: small; background-color: lightsteelblue; text-align: center">Query
                                                </td>
                                                <td style="background-color: skyblue; text-align: center" ><a href="Query/AllqueryStatus.aspx">
                                                    <asp:Label ID="label5" runat="server" Text="0" ForeColor="#ff9933" Font-Size="Small"></asp:Label></a></td>
                                              
                                            </tr>
                                            <%--<tr class="success">
                                                <td style="font-size: small; text-align: center">Appraisals
                                                </td>
                                                <td style="text-align: center"><a href="Appraisal/ViewAllGoals.aspx">
                                                    <asp:Label ID="lblPerformanceAppraisal" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>--%>
                                            <%--<td><a href="#">
                                                <asp:Label ID="lblapp5" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblapp10" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblappabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            <%--</tr>--%>
                                            <%--<tr class="success">
                                            <td>Exit Workflows
                                            </td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexit" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexit5" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexit10" runat="server" Text="0"></asp:Label></a></td>
                                            <td><a href="#">
                                                <asp:Label ID="lblexitabove" runat="server" Text="0"></asp:Label></a></td>
                                        </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="widget-body" id="divNapprsl" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending Goal
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending Rating
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="error">
                                                <td style="font-size: small; text-align: center">E-Evaluation
                                                </td>
                                                <td style="text-align: center"><a href="appraisal/ReviewGoalsByManager.aspx">
                                                    <asp:Label ID="lblPerformanceAppraisal" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="appraisal/ManagerRating.aspx">
                                                    <asp:Label ID="LabelRating" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>

                                 <div class="widget-body" id="div15" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending 
                                                </th>
                                                <th style="width: 15%; text-align: center">Approved 
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="error">
                                                <td style="font-size: small;  background-color: lightsteelblue; text-align: center">My Query
                                                </td>
                                                <td style="text-align: center"><a href="Query/AllqueryStatus.aspx">
                                                    <asp:Label ID="Label3" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="Query/AllqueryStatus.aspx">
                                                    <asp:Label ID="Label4" runat="server" Text="0" ForeColor="#00cc99" Font-Size="Small"></asp:Label></a></td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>


                                 
                                <div class="widget-body" id="divnotificationByUser" runat="server">
                                    <table class="table table-condensed table-bordered no-margin">
                                        <thead>
                                            <tr>
                                                <%--<th style="width: 40%">Pending/Approved Items in Queue</th>--%>
                                                <th style="width: 15%; text-align: center">Notification
                                                </th>
                                                <th style="width: 15%; text-align: center">Pending
                                                </th>
                                                <th style="width: 15%; text-align: center">Approved
                                                </th>
                                                <th style="width: 15%; text-align: center">Rejected
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr class="error">
                                                <td style="background-color: lightsteelblue; font-size: small; text-align: center">My Leave Application
                                                </td>
                                                <td style="background-color: skyblue; text-align: center"><a href="leave/leavestatus.aspx?leavestatus=0">
                                                    <asp:Label ID="lblleave0byUser" runat="server" Text="0" ForeColor="#ffff00" Font-Size="Small"></asp:Label></a></td>
                                                <td style="background-color: skyblue; text-align: center"><a href="leave/leavestatus.aspx?leavestatus=6">
                                                    <asp:Label ID="lblleave16byUser" runat="server" Text="0" ForeColor="#009900" Font-Size="Small"></asp:Label></a></td>
                                                <td style="background-color: skyblue; text-align: center"><a href="leave/leavestatus.aspx?leavestatus=3">
                                                    <asp:Label ID="lblleave235byUser" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>
                                            <tr class="error" style="display:none">
                                                <td style="background-color: ThreeDHighlight; font-size: small; text-align: center">My OD Application
                                                </td>
                                                <td style="text-align: center"><a href="leave/odstatus.aspx?leavestatus=0">
                                                    <asp:Label ID="lblODpenUser" runat="server" Text="0" ForeColor="#ff9900" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odstatus.aspx?leavestatus=1">
                                                    <asp:Label ID="lblODAppdUser" runat="server" Text="0" ForeColor="#33cc33" Font-Size="Small"></asp:Label></a></td>
                                                <td style="text-align: center"><a href="leave/odstatus.aspx?leavestatus=3">
                                                    <asp:Label ID="lblODrejUser" runat="server" Text="0" ForeColor="#ff3300" Font-Size="Small"></asp:Label></a></td>
                                                <%--<td><a href="leave/leaveapproval.aspx?leavestatus=0&hr=0">
                                                <asp:Label ID="lblleaveabove10" runat="server" Text="0"></asp:Label></a></td>--%>
                                            </tr>
                                            <%--<tr class="success">
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
                                        </tr>--%>
                                            <%--<tr class="success">
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
                                        </tr>--%>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>


                    </div>
                    <br />
                    <br />
                    <%--END row 2  --%>


                    <div class="row-fluid" id="Div4" runat="server">
                        <div class="span6" id="Div3" runat="server">
                            <div class="widget no-margin" style="height: 365px">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe095;"></span>My Attendance(Month-Wise)
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="emp_piechart1"></div>

                                </div>
                            </div>
                        </div>

                        <div class="span6">
                            <div class="widget" style="height: 365px">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe040;"></span>My Leave Balance
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <%-- content --%>
                                    <div class="row-fluid">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                                <div class="widget-body">
                                                    <%--<div id="divlnkbtn1" style="padding-left: 500px; padding-right: 1100px;">
                                                    <div id="divlnkbtn1">
                                                        <asp:LinkButton ID="lnkbtnNext1" runat="server" Font-Size="XX-Small" ForeColor="#0099ff" Font-Bold="true" PostBackUrl="~/EmpDashboard.aspx">Next</asp:LinkButton>
                                                    </div>--%>
                                                    <div class="row-fluid">
                                                        <div id="LeaveTab1" class="span6" runat="server">
                                                            <div id="leave_0" style="height: 150px;"></div>
                                                            <table id="leavedata1" class="table table-bordered table-condensed table-striped no-margin" style="border-radius: 1px">
                                                            </table>
                                                        </div>
                                                        <div class="span6">
                                                            <div id="leave_1" style="height: 150px;"></div>
                                                            <table id="leavedata2" class="table table-bordered table-condensed table-striped no-margin" style="border-radius: 1px">
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <%--<div id="divlnkbtn2" style="padding-left: 500px; padding-right: 1100px;">
                                                <div id="divlnkbtn2">
                                                    <asp:LinkButton ID="lnkbtnNext2" runat="server" Font-Size="XX-Small" ForeColor="#0099ff" Font-Bold="true">Next</asp:LinkButton>
                                                </div>--%>
                                                <div id="LeaveTab2" class="span6" runat="server">
                                                    <div id="leave_2" style="height: 150px;"></div>
                                                </div>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                            <ContentTemplate>
                                                <%--<div id="divlnkbtn3" style="padding-left: 500px; padding-right: 1100px;">
                                                    <asp:LinkButton ID="lnkbtnNext3" runat="server" Font-Size="XX-Small" ForeColor="#0099ff" Font-Bold="true">Next</asp:LinkButton>
                                                </div>--%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="clearfix"></div>
                </div>

                <div id="DivAttrn" runat="server" class="row-fluid">
                    <div class="span8">
                        <div class="widget box">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe095;"></span>ATTRITION DATA - Over All  
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="attrnGraph"></div>
                                <div>
                                    <table style="width: 88%" border="1">
                                        <tr>
                                            <%--<td style="padding-left: 3px">
                                                <img src="images/blue.PNG" alt="View">
                                            </td>--%>
                                            <td style="padding-left: 5px">
                                                <img src="images/light_blue.PNG" alt="View" /><span>   New Hires</span>
                                                <%--<label>New Hires</label>--%></td>
                                            <td id="td1" runat="server" style="text-align: center; width: 6.5%">
                                                <label id="lblHirJan" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td id="td2" runat="server" style="padding-left: 0px; width: 6.5%">
                                                <label id="lblHirFeb" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirMar" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirApr" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirMay" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirJun" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirJul" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirAug" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirSep" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirOct" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirNov" runat="server" style="text-align: center"></label>
                                            </td>
                                            <td style="padding-left: 0px; text-align: center; width: 6.5%">
                                                <label id="lblHirDec" runat="server" style="text-align: center"></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td style="padding-left: 3px">
                                                <img src="images/red.jpg" alt="View">
                                            </td>--%>
                                            <td style="padding-left: 5px">
                                                <img src="images/red.jpg" alt="View" /><span>   Exits</span></td>
                                            <%--<label>Exits</label></td>--%>
                                            <td id="td3" runat="server">
                                                <label style="text-align: center"><%= Session["ExitJan"] %></label></td>
                                            <td id="td4" runat="server" style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitFeb"] %></label></td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitMar"] %></label></td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitApr"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitMay"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitJun"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitJul"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitAug"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitSep"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitOct"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitNov"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["ExitDec"] %></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td style="padding-left: 3px">
                                                <img src="images/green.PNG" alt="View">
                                            </td>--%>
                                            <td style="padding-left: 5px">
                                                <img src="images/light_yellow.jpg" alt="View" /><span>   Opening Headcount</span></td>
                                            <%--<label>Opening Headcount</label></td>--%>
                                            <td id="td5" runat="server">
                                                <label style="text-align: center"><%= Session["TotalEmplyJan"] %></label></td>
                                            <td id="td6" runat="server" style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyFeb"] %></label></td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyMar"] %></label></td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyApr"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyMay"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyJun"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyJul"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyAug"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplySep"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyOct"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyNov"] %></label>
                                            </td>
                                            <td style="padding-left: 0px">
                                                <label style="text-align: center"><%= Session["TotalEmplyDec"] %></label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <%--<td style="padding-left: 3px">
                                                <img src="images/yellow.PNG" alt="View">
                                            </td>--%>
                                            <td style="padding-left: 5px">
                                                <img src="images/light_green.jpg" alt="View" /><span>   Attrition % total</span></td>
                                            <%--<label>Attrition % total:</label></td>--%>
                                            <td id="td7" runat="server" style="padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnJan"] %></label></td>
                                            <td id="td8" runat="server" style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnFeb"] %></label></td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnMar"] %></label></td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnApr"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnMay"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnJun"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnJul"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnAug"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnSep"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnOct"] %></label>
                                            </td>
                                            <td style="padding-left: 0px; padding-right: 0px">
                                                <label style="text-align: center"><%= Session["TotalAttrnNov"] %></label>
                                            </td>
                                            <td style="padding-left: 0px;">
                                                <label style="text-align: center"><%= Session["TotalAttrnDec"] %></label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="span4">
                        <div class="widget" style="height: 520px">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe040;"></span>Celebrations
                                </div>
                            </div>
                            <%--<div class="widget">
                                <div>
                                    <div>
                                        <asp:Label ID="Label4" runat="server" Text="" Style="padding-left: 20px; padding-right: 30px;"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="Name" Style="padding-left: 20px; padding-right: 60px;"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text="Occasion" Style="padding-left: 50px; padding-right: 80px;"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Date" Style="padding-left: 40px; padding-right: 80px;"></asp:Label>
                                    </div>
                                </div>--%>
                            <div class="widget-body">
                                <div>
                                    <div>
                                        <div class="track">
                                            <div class="thumb">
                                                <div class="end"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="viewport">
                                        <div class="overview">
                                            <div id="chats">
                                                <div class="tab-widget" style="height: 460px; overflow: auto;">
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
                <div id="divCalendar" runat="server" class="row-fluid">
                    <div id="divStyle" runat="server" class="span8">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe052;"></span>Calendar
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id='calendar'></div>
                            </div>
                        </div>
                    </div>
                    <div id="div12" runat="server" class="span4" style="height: 520px">
                        <div class="widget" style="height: 633px">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe040;"></span>Celebrations
                                </div>
                            </div>
                            <%--<div class="widget">
                                <div>
                                    <div>
                                        <asp:Label ID="Label4" runat="server" Text="" Style="padding-left: 20px; padding-right: 30px;"></asp:Label>
                                        <asp:Label ID="Label1" runat="server" Text="Name" Style="padding-left: 20px; padding-right: 60px;"></asp:Label>
                                        <asp:Label ID="Label2" runat="server" Text="Occasion" Style="padding-left: 50px; padding-right: 80px;"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Text="Date" Style="padding-left: 40px; padding-right: 80px;"></asp:Label>
                                    </div>
                                </div>--%>
                            <div class="widget-body">
                                <div>
                                    <div>
                                        <div class="track">
                                            <div class="thumb">
                                                <div class="end"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="viewport">
                                        <div class="overview">
                                            <div id="Div8">
                                                <div class="tab-widget" style="height: 566px; overflow: auto;">
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
    <!-- Easy Pie Chart JS -->
    <script src="js/pie-charts/jquery.easy-pie-chart.js"></script>
    <!-- Calendar Js -->
    <script src='js/fullcalendar/jquery-ui-1.10.2.custom.min.js'></script>
    <script src='js/fullcalendar/fullcalendar.min.js'></script>

    <%-- <script>
        $(document).ready(function () {

            var date = new Date();
            var d = date.getDate();
            var m = date.getMonth();
            var y = date.getFullYear();

            var calendar = $('#calendar').fullCalendar({
                header: {
                    left: 'prev,next today',
                    center: 'title',
                    right: 'month,agendaWeek,agendaDay'
                },
                selectable: true,
                selectHelper: true,
                select: function (start, end, allDay) {
                    var title = prompt('Event Title:');
                    if (title) {
                        calendar.fullCalendar('renderEvent',
                            {
                                title: title,
                                start: start,
                                end: end,
                                allDay: allDay
                            },
                            true // make the event "stick"
                        );
                    }
                    calendar.fullCalendar('unselect');
                },
                editable: true,
                events: [
                {
                    title: 'P',
                    start: new Date(y, m, 1),
                    color: '#3AB093'
                },
                {
                    title: 'CL',
                    start: new Date(y, m, 2),
                    color: '#DA4747'
                },
                 {
                     title: 'P',
                     start: new Date(y, m, 7),
                     color: '#3AB093'
                 },
                  {
                      title: 'P',
                      start: new Date(y, m, 8),
                      color: '#3AB093'
                  },
                   {
                       title: 'W',
                       start: new Date(y, m, 5),
                       color: '#8D8D86'
                   },
                    {
                        title: 'P',
                        start: new Date(y, m, 6),
                        color: '#3AB093'
                    },
                     {
                         title: 'P',
                         start: new Date(y, m, 9),
                         color: '#3AB093'
                     },
                     {
                         title: 'P',
                         color: '#3AB093'
                     },
              {
                  title: 'Dussehra',
                  start: new Date(y, m, d - 7),
                  end: new Date(y, m, d - 6),
                  color: '#47A3FF'
              },
              {
                  id: 999,
                  title: 'Repeating Event',
                  start: new Date(y, m, d - 3, 16, 0),
                  allDay: false
              },

              {
                  title: 'Meeting',
                  start: new Date(y, m, d, 10, 30),
                  allDay: false
              },
              {
                  title: 'Lunch',
                  start: new Date(y, m, d, 12, 0),
                  end: new Date(y, m, d, 14, 0),
                  allDay: false
              },
              {
                  title: 'Birthday Party',
                  start: new Date(y, m, d + 1, 19, 0),
                  end: new Date(y, m, d + 1, 22, 30),
                  allDay: false,
                  color: '#f3cf59'

              }

                ]
            });
        });
    </script>--%>



    <%-- clock --%>
    <script>
        var canvas = document.getElementById("canvas");
        var ctx = canvas.getContext("2d");
        var radius = canvas.height / 2;
        ctx.translate(radius, radius);
        radius = radius * 0.90
        setInterval(drawClock, 1000);

        function drawClock() {
            drawFace(ctx, radius);
            drawNumbers(ctx, radius);
            drawTime(ctx, radius);
        }

        function drawFace(ctx, radius) {
            var grad;
            ctx.beginPath();
            ctx.arc(0, 0, radius, 0, 2 * Math.PI);
            ctx.fillStyle = 'white';
            ctx.fill();
            grad = ctx.createRadialGradient(0, 0, radius * 0.95, 0, 0, radius * 1.05);
            grad.addColorStop(0, '#333');
            grad.addColorStop(0.5, 'white');
            grad.addColorStop(1, '#333');
            ctx.strokeStyle = grad;
            ctx.lineWidth = radius * 0.1;
            ctx.stroke();
            ctx.beginPath();
            ctx.arc(0, 0, radius * 0.1, 0, 2 * Math.PI);
            ctx.fillStyle = '#333';
            ctx.fill();
        }

        function drawNumbers(ctx, radius) {
            var ang;
            var num;
            ctx.font = radius * 0.15 + "px arial";
            ctx.textBaseline = "middle";
            ctx.textAlign = "center";
            for (num = 1; num < 13; num++) {
                ang = num * Math.PI / 6;
                ctx.rotate(ang);
                ctx.translate(0, -radius * 0.85);
                ctx.rotate(-ang);
                ctx.fillText(num.toString(), 0, 0);
                ctx.rotate(ang);
                ctx.translate(0, radius * 0.85);
                ctx.rotate(-ang);
            }
        }

        function drawTime(ctx, radius) {
            var now = new Date();
            var hour = now.getHours();
            var minute = now.getMinutes();
            var second = now.getSeconds();
            //hour
            hour = hour % 12;
            hour = (hour * Math.PI / 6) +
            (minute * Math.PI / (6 * 60)) +
            (second * Math.PI / (360 * 60));
            drawHand(ctx, hour, radius * 0.5, radius * 0.07);
            //minute
            minute = (minute * Math.PI / 30) + (second * Math.PI / (30 * 60));
            drawHand(ctx, minute, radius * 0.8, radius * 0.07);
            // second
            second = (second * Math.PI / 30);
            drawHand(ctx, second, radius * 0.9, radius * 0.02);
        }

        function drawHand(ctx, pos, length, width) {
            ctx.beginPath();
            ctx.lineWidth = width;
            ctx.lineCap = "round";
            ctx.moveTo(0, 0);
            ctx.rotate(pos);
            ctx.lineTo(0, -length);
            ctx.stroke();
            ctx.rotate(-pos);
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

            var chart = new google.visualization.ColumnChart(document.getElementById('col_chart'));
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
        var $ruby_red = "#fa9c9b";

        var totalEmployees = parseInt('<%= Session["totalEmpReportee"] %>');
        var presentEmployees = parseInt('<%= Session["totalEmpReporteePresent"] %>');
        var prsntEmpRepDeci = parseFloat('<%= Session["totlPrsntinDeciRep"] %>');
        var absentEmployees = totalEmployees - presentEmployees;
        var absntEmpRep = parseFloat("100") - prsntEmpRepDeci;
        document.getElementById('absentEmployeeReportee').innerHTML = ": " + absentEmployees;
        document.getElementById('absentEmployeeReporteePrcnt').innerHTML = ": " + absntEmpRep + "%";
        function drawChart5() {
            var data = google.visualization.arrayToDataTable([
              ['Day', 'No of Emp', 'Present', 'Absent'],
              ['Today', totalEmployees, presentEmployees, absentEmployees],
            ]);

            var options = {
                width: '500',
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

            var chart = new google.visualization.ColumnChart(document.getElementById('myReporteeAttendance'));
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

        //var deptmnt_name = (<%= Session["dept_name"] %>);
        var totalEmpDept1 = parseInt('<%= Session["totalEmpDept1"] %>');
        var presentEmpDept1 = parseFloat('<%= Session["totlPrsntinDeciDept1"] %>');
        var absentEmpDept1;
        if(totalEmpDept1 < 1)
        {
            totalEmpDept1 = 0;
            absentEmpDept1 = 0;
        }
        else
        {
            totalEmpDept1 = 100;
            absentEmpDept1 = parseFloat("100") - presentEmpDept1;
        }
        document.getElementById('totalAbbsentDept1').innerHTML = ": " + absentEmpDept1 + "%";

        var totalEmpDept2 = parseInt('<%= Session["totalEmpDept2"] %>');
        var presentEmpDept2 = parseFloat('<%= Session["totlPrsntinDeciDept2"] %>');
        var absentEmpDept2;
        if(totalEmpDept2 < 1)
        {
            totalEmpDept2 = 0;
            absentEmpDept2 = 0;
        }
        else
        {
            totalEmpDept2 = 100;
            absentEmpDept2 = parseFloat("100") - presentEmpDept2;
        }
        document.getElementById('totalAbbsentDept2').innerHTML = ": " + absentEmpDept2 + "%";

        var totalEmpDept3 = parseInt('<%= Session["totalEmpDept3"] %>');
        var presentEmpDept3 = parseFloat('<%= Session["totlPrsntinDeciDept3"] %>');
        var absentEmpDept3;
        if(totalEmpDept3 < 1)
        {
            totalEmpDept3 = 0;
            absentEmpDept3 = 0;
        }
        else
        {
            totalEmpDept3 = 100;
            absentEmpDept3 = parseFloat("100") - presentEmpDept3;
        }
        document.getElementById('totalAbbsentDept3').innerHTML = ": " + absentEmpDept3 + "%";

        function drawChart4() {
            var data = google.visualization.arrayToDataTable([
              ['Day', 'No of Emp', 'Present', 'Absent'],
              ['<%= Session["dept_name"] %>', totalEmpDept1, presentEmpDept1, absentEmpDept1],
              //['Functional', totalEmpDept2, presentEmpDept2, absentEmpDept2],
              //['Support Function', totalEmpDept3, presentEmpDept3, absentEmpDept3],
            ]);

            var options = {
                width: '500',
                height: '220',
                backgroundColor: 'transparent',
                colors: [$jet_blue, $go_green, $ruby_red],
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

            var chart = new google.visualization.ColumnChart(document.getElementById('deptAttendanceColumnChart'));
            chart.draw(data, options);
        }
    </script>
    <script type="text/javascript">
        google.charts.load('current', { 'packages': ['corechart'] });
        google.charts.setOnLoadCallback(drawChart1);

        function drawChart1() {

            var joined = parseInt('<%=Session["joinedInNumber"] %>');
            //alert(joined);
            var attrition = parseInt('<%=Session["attritionInNumber"] %>');
            //alert(attrition);
            var offered = parseInt(3);

            var data1 = google.visualization.arrayToDataTable([
              ['Task', 'Hours per Day'],
              ['Joined', joined],
              ['Attrition', attrition],
              ['Offered', offered]

            ]);

            //var options = {
            //    title: '',
            //    slices: { 0: { color: '#93caa3' }, 1: { color: '#ffe38a' }, 2: { color: '#fa9c9b' } }
            //};


            var options = {
                width: 'auto',
                height: '265',
                backgroundColor: 'transparent',
                colors: [$go_green, $ruby_red, $lemon_yellow],
                tooltip: {
                    textStyle: {
                        color: '#666666',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    position: 'left',
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
                }
            };
            var chart1 = new google.visualization.PieChart(document.getElementById('emp_piechart'));

            chart1.draw(data1, options);
        }
    </script>
      <script type="text/javascript">
          google.charts.load('current', { 'packages': ['corechart'] });
          google.charts.setOnLoadCallback(drawChart1);

          function drawChart1() {

              var inTime = parseInt('<%= Session["Emp_log1"] %>');
            var late_1 = parseInt('<%= Session["Emp_log2"] %>');
            var late_2 = parseInt('<%= Session["Emp_log3"] %>');

            var data1 = google.visualization.arrayToDataTable([
              ['Task', 'Hours per Day'],
              ['In Time', inTime],
              ['15 min Late', late_1],
              ['30 min Late', late_2]

            ]);

            //var options = {
            //    title: '',
            //    slices: { 0: { color: '#93caa3' }, 1: { color: '#ffe38a' }, 2: { color: '#fa9c9b' } }
            //};


            var options = {
                width: 'auto',
                height: '265',
                backgroundColor: 'transparent',
                colors: [$go_green, $ruby_red, $lemon_yellow],
                tooltip: {
                    textStyle: {
                        color: '#666666',
                        fontSize: 11
                    },
                    showColorCode: true
                },
                legend: {
                    position: 'left',
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
                }
            };
            var chart1 = new google.visualization.PieChart(document.getElementById('emp_piechart1'));

            chart1.draw(data1, options);
        }
    </script>
    <%-- clock --%>
    <script>
        var canvas = document.getElementById("canvas");
        var ctx = canvas.getContext("2d");
        var radius = canvas.height / 2;
        ctx.translate(radius, radius);
        radius = radius * 0.90
        setInterval(drawClock, 1000);

        function drawClock() {
            drawFace(ctx, radius);
            drawNumbers(ctx, radius);
            drawTime(ctx, radius);
        }

        function drawFace(ctx, radius) {
            var grad;
            ctx.beginPath();
            ctx.arc(0, 0, radius, 0, 2 * Math.PI);
            ctx.fillStyle = 'white';
            ctx.fill();
            grad = ctx.createRadialGradient(0, 0, radius * 0.95, 0, 0, radius * 1.05);
            grad.addColorStop(0, '#333');
            grad.addColorStop(0.5, 'white');
            grad.addColorStop(1, '#333');
            ctx.strokeStyle = grad;
            ctx.lineWidth = radius * 0.1;
            ctx.stroke();
            ctx.beginPath();
            ctx.arc(0, 0, radius * 0.1, 0, 2 * Math.PI);
            ctx.fillStyle = '#333';
            ctx.fill();
        }

        function drawNumbers(ctx, radius) {
            var ang;
            var num;
            ctx.font = radius * 0.15 + "px arial";
            ctx.textBaseline = "middle";
            ctx.textAlign = "center";
            for (num = 1; num < 13; num++) {
                ang = num * Math.PI / 6;
                ctx.rotate(ang);
                ctx.translate(0, -radius * 0.85);
                ctx.rotate(-ang);
                ctx.fillText(num.toString(), 0, 0);
                ctx.rotate(ang);
                ctx.translate(0, radius * 0.85);
                ctx.rotate(-ang);
            }
        }

        function drawTime(ctx, radius) {
            var now = new Date();
            var hour = now.getHours();
            var minute = now.getMinutes();
            var second = now.getSeconds();
            //hour
            hour = hour % 12;
            hour = (hour * Math.PI / 6) +
            (minute * Math.PI / (6 * 60)) +
            (second * Math.PI / (360 * 60));
            drawHand(ctx, hour, radius * 0.5, radius * 0.07);
            //minute
            minute = (minute * Math.PI / 30) + (second * Math.PI / (30 * 60));
            drawHand(ctx, minute, radius * 0.8, radius * 0.07);
            // second
            second = (second * Math.PI / 30);
            drawHand(ctx, second, radius * 0.9, radius * 0.02);
        }

        function drawHand(ctx, pos, length, width) {
            ctx.beginPath();
            ctx.lineWidth = width;
            ctx.lineCap = "round";
            ctx.moveTo(0, 0);
            ctx.rotate(pos);
            ctx.lineTo(0, -length);
            ctx.stroke();
            ctx.rotate(-pos);
        }
    </script>

    <script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawChartAttrition);

        var dataNewHirJan = parseInt('<%= Session["NewHirJan"] %>');
        var dataNewHirFeb = parseInt('<%= Session["NewHirFeb"] %>');
        var dataNewHirMar = parseInt('<%= Session["NewHirMar"] %>');
        var dataNewHirApr = parseInt('<%= Session["NewHirApr"] %>');
        var dataNewHirMay = parseInt('<%= Session["NewHirMay"] %>');
        var dataNewHirJun = parseInt('<%= Session["NewHirJun"] %>');
        var dataNewHirJul = parseInt('<%= Session["NewHirJul"] %>');
        var dataNewHirAug = parseInt('<%= Session["NewHirAug"] %>');
        var dataNewHirSep = parseInt('<%= Session["NewHirSep"] %>');
        var dataNewHirOct = parseInt('<%= Session["NewHirOct"] %>');
        var dataNewHirNov = parseInt('<%= Session["NewHirNov"] %>');
        var dataNewHirDec = parseInt('<%= Session["NewHirDec"] %>');

        var dataExitsJan = parseInt('<%= Session["ExitJan"] %>');
        var dataExitsFeb = parseInt('<%= Session["ExitFeb"] %>');
        var dataExitsMar = parseInt('<%= Session["ExitMar"] %>');
        var dataExitsApr = parseInt('<%= Session["ExitApr"] %>');
        var dataExitsMay = parseInt('<%= Session["ExitMay"] %>');
        var dataExitsJun = parseInt('<%= Session["ExitJun"] %>');
        var dataExitsJul = parseInt('<%= Session["ExitJul"] %>');
        var dataExitsAug = parseInt('<%= Session["ExitAug"] %>');
        var dataExitsSep = parseInt('<%= Session["ExitSep"] %>');
        var dataExitsOct = parseInt('<%= Session["ExitOct"] %>');
        var dataExitsNov = parseInt('<%= Session["ExitNov"] %>');
        var dataExitsDec = parseInt('<%= Session["ExitDec"] %>');

        var dataHeadcountJan = parseInt('<%= Session["TotalEmplyJan"] %>');
        var dataHeadcountFeb = parseInt('<%= Session["TotalEmplyFeb"] %>');
        var dataHeadcountMar = parseInt('<%= Session["TotalEmplyMar"] %>');
        var dataHeadcountApr = parseInt('<%= Session["TotalEmplyApr"] %>');
        var dataHeadcountMay = parseInt('<%= Session["TotalEmplyMay"] %>');
        var dataHeadcountJun = parseInt('<%= Session["TotalEmplyJun"] %>');
        var dataHeadcountJul = parseInt('<%= Session["TotalEmplyJul"] %>');
        var dataHeadcountAug = parseInt('<%= Session["TotalEmplyAug"] %>');
        var dataHeadcountSep = parseInt('<%= Session["TotalEmplySep"] %>');
        var dataHeadcountOct = parseInt('<%= Session["TotalEmplyOct"] %>');
        var dataHeadcountNov = parseInt('<%= Session["TotalEmplyNov"] %>');
        var dataHeadcountDec = parseInt('<%= Session["TotalEmplyDec"] %>');

        var dataAttrnJan = parseFloat('<%= Session["TotalAttrnJanDeci"] %>');
        var dataAttrnFeb = parseFloat('<%= Session["TotalAttrnFebDeci"] %>');
        var dataAttrnMar = parseFloat('<%= Session["TotalAttrnMarDeci"] %>');
        var dataAttrnApr = parseFloat('<%= Session["TotalAttrnAprDeci"] %>');
        var dataAttrnMay = parseFloat('<%= Session["TotalAttrnMayDeci"] %>');
        var dataAttrnJun = parseFloat('<%= Session["TotalAttrnJunDeci"] %>');
        var dataAttrnJul = parseFloat('<%= Session["TotalAttrnJulDeci"] %>');
        var dataAttrnAug = parseFloat('<%= Session["TotalAttrnAugDeci"] %>');
        var dataAttrnSep = parseFloat('<%= Session["TotalAttrnSepDeci"] %>');
        var dataAttrnOct = parseFloat('<%= Session["TotalAttrnOctDeci"] %>');
        var dataAttrnNov = parseFloat('<%= Session["TotalAttrnNovDeci"] %>');
        var dataAttrnDec = parseFloat('<%= Session["TotalAttrnDecDeci"] %>');

        var $go_green = "#93caa3";
        var $jet_blue = "#70aacf";
        var $c_red    = "#FF0000";     

        function drawChartAttrition() {
            var dataAttrn = google.visualization.arrayToDataTable([
                ['Month', 'New hires', 'Exits', 'Headcount', 'Attrition % - Right Axis'],
              ['Jan', dataNewHirJan, dataExitsJan, dataHeadcountJan, dataAttrnJan],
              ['Feb', dataNewHirFeb, dataExitsFeb, dataHeadcountFeb, dataAttrnFeb],
              ['Mar', dataNewHirMar, dataExitsMar, dataHeadcountMar, dataAttrnMar],
              ['Apr', dataNewHirApr, dataExitsApr, dataHeadcountApr, dataAttrnApr],
              ['May', dataNewHirMay, dataExitsMay, dataHeadcountMay, dataAttrnMay],
              ['Jun', dataNewHirJun, dataExitsJun, dataHeadcountJun, dataAttrnJun],
              ['Jul', dataNewHirJul, dataExitsJul, dataHeadcountJul, dataAttrnJul],
              ['Aug', dataNewHirAug, dataExitsAug, dataHeadcountAug, dataAttrnAug],
              ['Sep', dataNewHirSep, dataExitsSep, dataHeadcountSep, dataAttrnSep],
              ['Oct', dataNewHirOct, dataExitsOct, dataHeadcountOct, dataAttrnOct],
              ['Nov', dataNewHirNov, dataExitsNov, dataHeadcountNov, dataAttrnNov],
              ['Dec', dataNewHirDec, dataExitsDec, dataHeadcountDec, dataAttrnDec]
            ]);

            var optionsAttrn = {
                width: '760',
                height: '355',
                backgroundColor: 'transparent',
                colors: [$jet_blue, $c_red, $go_green],
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
                    left: 188,
                    top: 10,
                    height: '90%',
                    width:'100%'
                },
                vAxis:{
                    title:'Headcount', titleTextStyle: {
                        color: '#000000',
                        fontSize: 19,
                        bold: true,
                        italic: false
                    },
                    titleFontSize: 48
                },
                vAxes:  {0: {viewWindowMode:'explicit',
                    gridlines: {color: 'transparent'},
                },
                    1: {gridlines: {color: 'transparent'},
                        format:"#%"},
                },
                series: {0: {targetAxisIndex:0},
                    1:{targetAxisIndex:0},
                    2:{targetAxisIndex:1},
                }
            };

            var chart = new google.visualization.ColumnChart(document.getElementById('attrnGraph'));            
            chart.draw(dataAttrn, {curveType: "function", width: 712, height: 335,
                vAxes: {
                    0: {logScale: false, gridlines: {count: 7}, title:'Headcount', titleTextStyle: {
                        color: '#000000',
                        fontSize: 19,
                        bold: true,
                        italic: false},
                    },
                    1: {logScale: false, maxValue: 5}
                },
                series:{
                    0:{targetAxisIndex: 0},
                    1:{targetAxisIndex: 0},
                    2:{targetAxisIndex: 0},
                    3:{targetAxisIndex: 1, type: "line", format: "#%"}
                },
                chartArea: {
                    left: 142,
                    height: '80%'
                }
            } );

            
        }
    </script>

    <%--<script type="text/javascript">
        google.charts.load('current', { packages: ['corechart', 'bar'] });
        google.charts.setOnLoadCallback(drawVisualization);

        var $ab_blue = "#0000ff";

        function drawVisualization() {
            var data = new google.visualization.DataTable();
            data.addColumn('string', 'x');
            data.addColumn('number', 'Cats');
            data.addColumn('number', 'Blanket 1');
            data.addColumn('number', 'Blanket 2');
            data.addRow(["A", 1, 1, 0.5]);
            data.addRow(["B", 2, 0.5, 1]);
            data.addRow(["C", 4, 1, 0.5]);
            data.addRow(["D", 8, 0.5, 1]);
            data.addRow(["E", 7, 1, 0.5]);
            data.addRow(["F", 7, 0.5, 1]);
            data.addRow(["G", 8, 1, 0.5]);
            data.addRow(["H", 4, 0.5, 1]);
            data.addRow(["I", 2, 1, 0.5]);
            data.addRow(["J", 3.5, 0.5, 1]);
            data.addRow(["K", 3, 1, 0.5]);
            data.addRow(["L", 3.5, 0.5, 1]);
            data.addRow(["M", 1, 1, 0.5]);
            data.addRow(["N", 1, 0.5, 1]);

            new google.visualization.ColumnChart(document.getElementById('attrnGraph')).
                draw(data, {curveType: "function", width: 500, height: 400,
                    vAxes: {0: {logScale: false},
                        1: {logScale: false, maxValue: 2}},
                    series:{
                        0:{targetAxisIndex:0},
                        1:{targetAxisIndex:0},
                        2:{targetAxisIndex:0}}}
                    );
        }
    </script>--%>
</body>


</html>
