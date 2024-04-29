<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default5.aspx.cs" Inherits="Default5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="js/html5-trunk.js"></script>
    <link href="icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

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
                    <div class="span8">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe097;"></span>My Attendance
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="social-catigories" style="height: 240px;"></div>
                            </div>
                        </div>
                    </div>

                    <div class="span4">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe095;"></span>DepartmentWise Attendance
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="piechart" style="height: 240px;"></div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe09f;"></span>Modules
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <a href="admin/empview.aspx" class="quick-action-btn span2 input-bottom-margin" data-original-title="ESS">
                                  <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-important">ESS</div>
                                </a>
                                <a class="quick-action-btn span2 input-bottom-margin" data-original-title="Leave & Attendance">
                                  <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-info">Leave & Attendance</div>
                                </a>
                                <a href="Travel/TravelForm.aspx" class="quick-action-btn span2 input-bottom-margin" data-original-title="Travel & Expenses">
                                     <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-success">Travel & Expenses</div>
                                </a>
                                <a class="quick-action-btn span2 input-bottom-margin" data-original-title="Reimbursement">
                                    <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-warning">Reimbursement</div>
                                </a>
 <a class="quick-action-btn span2 input-bottom-margin" data-original-title="Appraisal">
                                   <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-success">Appraisal</div>
                                </a>

                                <a class="quick-action-btn span2 input-bottom-margin" data-original-title="Traning">
                                     <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-important">Traning</div>
                                </a>
                                <a class="quick-action-btn span2 input-bottom-margin" data-original-title="Recruitment">
                                    <span class="fs1" aria-hidden="true" data-icon=""></span>
                                    <p class="no-margin"></p>
                                    <div class="label label-info">Recruitment</div>
                                </a>
                               

                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid" style="display: none">
                    <div class="span8">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe0c2;"></span>Geo Chart
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="geo_chart"></div>
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

                                <div id='calendar'></div>
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

        <!-- container-fluid -->

        <script src="js/jquery.min.js"></script>
        <script src="js/bootstrap.js"></script>
        <script src="js/moment.js"></script>

        <!-- Flot charts -->
        <script src="js/flot/jquery.flot.js"></script>
        <script src="js/flot/jquery.flot.selection.js"></script>
        <script src="js/flot/jquery.flot.pie.js"></script>
        <script src="js/flot/jquery.flot.categories.js"></script>
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
        <script src="js/custom-flot-graphs.js"></script>
        <script src="js/custom-index.js"></script>
        <script src="js/custom-calendar.js"></script>

        <script src="js/theming.js"></script>
        <script src="js/custom.js"></script>

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
