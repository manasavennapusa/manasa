<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default4.aspx.cs" Inherits="Default4" %>

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

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

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

</head>

<body>

    <header>
        <a href="Default4.aspx">
            <img src="upload/logo/client-logo.png" /></a>

        <div id="mini-nav">
            <ul class="hidden-phone">
                <li>
                    <a href="#" data-toggle="modal" data-original-title="">Documentation
                    </a>
                    <div id="documentation" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel1" aria-hidden="true" aria-disabled="true">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">
                                ×
                            </button>
                            <h4 id="myModalLabel1">Full html documentation is available on purchase.
                            </h4>
                        </div>
                        <div class="modal-body">
                            <img src="img/documentation.png" />
                        </div>
                    </div>
                </li>
                <li class="dropdown">
                    <a data-toggle="dropdown" class="dropdown-toggle" href="#">Theming
             
                    <span class="caret icon-white"></span>
                    </a>
                    <ul class="dropdown-menu pull-right">
                        <li>
                            <a href="#" id="default">Default</a>
                        </li>
                        <li>
                            <a href="#" id="facebook">Facebook</a>
                        </li>
                        <li>
                            <a href="#" id="foursquare">Foursquare</a>
                        </li>
                        <li>
                            <a href="#" id="google-plus">Google+</a>
                        </li>
                        <li>
                            <a href="#" id="instagram">Instagram</a>
                        </li>
                        <li>
                            <a href="#" id="whitesmoke">White Smoke</a>
                        </li>
                        <li>
                            <a href="#" id="grey">Grey</a>
                        </li>
                    </ul>
                </li>
                <li>
                    <a href="#"><span class="fs1" aria-hidden="true" data-icon="&#xe03b;"></span></a>
                </li>
                <li>
                    <a href="#" ><span class="fs1" aria-hidden="true" data-icon="&#xe090;"></span></a>
                </li>
                <li>
                    <a href="Default.aspx"><span class="fs1" aria-hidden="true" data-icon="&#xe0b1;"></span></a>
                </li>
            </ul>
            <div class="clearfix"></div>
        </div>
    </header>

    <div class="container-fluid">
        <div class="left-sidebar hidden-tablet hidden-phone">
            <div class="user-details" style="height:70px">
                <div class="user-img">

                    <% if (Session["PerPhoto"] != null) Response.Write(Session["PerPhoto"].ToString()); %>
                </div>
                <div class="welcome-text">
                    <span>Welcome</span>
                    <br />
                    <span style="color: white">
                        <% if (Session["rolename"] != null) Response.Write(Session["rolename"].ToString()); %>
                        ( <% if (Session["empcode"] != null) Response.Write(Session["empcode"].ToString()); %> -
                         <% if (Session["name"] != null) Response.Write(Session["name"].ToString()); %> ) 

                    </span> 
                </div>
            </div>

            <% if (Session["menu"] != null) { Response.Write(Session["menu"].ToString().ToString()); } %>


            <%--<div class="easy-pie-chart">
                <div class="pie_chart_1" data-percent="69">
                    69%
         
                </div>
                <p class="name">
                    Animated Chart         
                </p>
            </div>--%>
        </div>
        <div class="dashboard-wrapper">
            <div id="main-nav" class="hidden-phone hidden-tablet">
                <ul id="nav">
                    <% Response.Write(Session["AdminSection"].ToString()); %>
                </ul>

                <script type="text/javascript">
                    var current = document.getElementById('default');

                    function highlite(el) {
                        if (current != null) {
                            current.className = "";
                        }
                        el.className = "selected";
                        current = el;
                    }
                </script>
                <div class="clearfix"></div>
            </div>
            <div id="superadmin" runat="server" visible="false">
                <iframe src="Default5.aspx" name="ifrmSDL" id="ifrmSDL" style="width: 100%; height: 1500px; border: 0px; min-height: 1154px; overflow:hidden"></iframe>
            </div>
            <div id="temp" runat="server" visible="false">
                <iframe src="onboarding/edittemplogin.aspx" name="ifrmSDL" id="ifrmtemp" style="width: 100%; height: 1500px; border: 0px; min-height: 1154px; overflow:hidden"></iframe>
            </div>
            
            <%--for Employee dashboard--%>
            <%-- <div id="employee" runat="server" visible="false">
                <iframe src="EmployeeDashboard.aspx" name="ifrmSDL" id="Iframe2" style="width: 100%; height: 2500px; border: 0px; min-height: 1154px;"></iframe>
            </div>--%>
            <%--for HR dashboard--%>
            <%--  <div id="hr" runat="server" visible="false">
                <iframe src="Default5.aspx" name="ifrmSDL" id="ifrmSDL" style="width: 100%; height: 2500px; border: 0px; min-height: 1154px;"></iframe>
            </div>--%>
            <%--for Admin dashboard--%>

            <%--   <div id="admindash" runat="server" visible="false">
                <iframe src="CeoDashboard.aspx" name="ifrmSDL" id="Iframe1" style="width: 100%; height: 2500px; border: 0px; min-height: 1154px;"></iframe>
            </div>--%>
        </div>
        <!-- dashboard-container -->
    </div>
    <!-- container-fluid -->
    <div id="loader" style="display: none;">
        <img src="img/loader.gif" style="width: 25%; height: 25%" />
    </div>
    <script src="js/jquery.min.js"></script>
    <script src="js/bootstrap.js"></script>
    <script src="js/moment.js"></script>
    <script src="js/jquery-1.3.2.min.js"></script>

    <!-- Flot charts -->
    <script src="js/flot/jquery.flot.js"></script>
    <script src="js/flot/jquery.flot.selection.js"></script>
    <script src="js/flot/jquery.flot.pie.js"></script>
    <script src="js/flot/jquery.flot.tooltip.js"></script>

    <!-- Google Visualization JS -->
    <script type="text/javascript" src="https://www.google.com/jsapi"></script>

    <!-- Easy Pie Chart JS -->
    <script src="js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="js/tiny-scrollbar.js"></script>

    <!-- Sparkline charts -->
    <script src="js/sparkline.js"></script>

    <!-- Datatables JS -->
    <script src="js/jquery.dataTables.js"></script>

    <!-- Calendar Js -->
    <script src='js/fullcalendar/jquery-ui-1.10.2.custom.min.js'></script>
    <script src='js/fullcalendar/fullcalendar.min.js'></script>

    <!-- Custom Js -->
    <script src="js/custom-index.js"></script>
    <script src="js/custom-calendar.js"></script>

    <script src="js/theming.js"></script>
    <script src="js/custom.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#wizard").bwizard();
        });
    </script>
    <%--<script type="text/javascript">
        $(function () {
            setNavigation();
        });
        function setNavigation() {
            var path = window.location.href;
            path = path.replace(/\/$/, "");
            path = decodeURIComponents(path);

            $("#subnav a").each(function () {
                var href = $(this).attr('href');
                if (path.substring(0, href.length) == href) {
                    $(this).closest('li').active('selected');
                }
            });
        }
                </script>--%>

    <%--<script>
        (function (i, s, o, g, r, a, m) {
            i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                (i[r].q = i[r].q || []).push(arguments)
            }, i[r].l = 1 * new Date(); a = s.createElement(o),
            m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
        })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

        ga('create', 'UA-41161221-1', 'srinu.html');
        ga('send', 'pageview');

    </script>--%>
</body>
</html>
