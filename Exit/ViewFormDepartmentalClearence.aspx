<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFormDepartmentalClearence.aspx.cs" Inherits="Exit_ViewFormDepartmentalClearence" %>

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
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <link href="../css/table.css" rel="stylesheet" type="text/css" />


</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Departmental Clearance</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    View
                                </div>
                                
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Completed Assigned Task</label>
                                        <div class="controls">
                                            <input type="radio" name="CompletedAssignedTask" id="CompletedAssignedTaskYes" runat="server" disabled="disabled" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="CompletedAssignedTask" id="CompletedAssignedTaskNo" runat="server" disabled="disabled" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="CompletedAssignedTask" id="CompletedAssignedTaskNA" runat="server" disabled="disabled" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Data Backup Required</label>
                                        <div class="controls">
                                            <input type="radio" name="DataBackupRequired" id="DataBackupRequiredYes" runat="server" disabled="disabled" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="DataBackupRequired" id="DataBackupRequiredNo" runat="server" disabled="disabled" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="DataBackupRequired" id="DataBackupRequiredNA" runat="server" disabled="disabled" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Knowledge Transfer Documentation</label>
                                        <div class="controls">
                                            <input type="radio" name="KnowledgeTransferDocumentation" id="KnowledgeTransferDocumentationYes" runat="server" disabled="disabled" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="KnowledgeTransferDocumentation" id="KnowledgeTransferDocumentationNo" runat="server" disabled="disabled" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="KnowledgeTransferDocumentation" id="KnowledgeTransferDocumentationNA" runat="server" disabled="disabled" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Who Received Knowledge Transfer</label>
                                        <div class="controls">
                                            <asp:TextBox ID="WhoReceivedKnowledgeTransfer" runat="server" disabled="disabled" CssClass="span4"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date Of Clearance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="DateOfClearence" runat="server" disabled="disabled" CssClass="span4"></asp:TextBox>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget" style="width:76px; float:right; height:46px ">
                            <div class="widget-header" style="border-bottom: none; height:36px">
                               
                                <div class="pull-right">
                                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
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
                $('#grdstaytype').dataTable({
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





