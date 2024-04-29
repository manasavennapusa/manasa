<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generatemachinecodereport.aspx.cs" Inherits="attendance_generatemachinecodereport" %>

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
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee MachineCode&IP Address Report</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Create/Update MachineCode & IP Address"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <fieldset>
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="control-group">
                                                <label class="control-label">Branch</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_branch" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">EmpCode</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtempcode" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>

                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" CssClass="btn btn-primary pull-right"
                                            ToolTip="Click to submit the created Reimbursement" Text="Submit" OnClientClick="return Validate()"></asp:Button>&nbsp;

                                     <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="btn btn-primary pull-right"
                                         Text="Reset"></asp:Button>&nbsp;
                                    </div>
                                </fieldset>

                            </div>
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
                $('#Grid_Emp').dataTable({
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
