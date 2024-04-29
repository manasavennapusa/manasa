<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EDB_Details_upload.aspx.cs" Inherits="admin_EDB_Details_upload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <%-- <meta name="author" content="Srinu Basava">
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport">
    <meta name="description" content="StartUp Admin UI">
    <meta name="keywords" content="StartUp Admin UI, Admin UI, Admin Dashboard, Srinu Basava, Best admin UI, Best backend UI, Best Dashboard, Responsive admin UI, Responsive dashboard, Responsive Backend, Mobile admin, Mobile Backend, Mobile Dashboard">--%>
    <script src="js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">


                <div class="page-header">
                    <div class="pull-left">
                        <h2>Employee Upload Details</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">

                    <div class="widget">
                        <div class="widget-header">
                            <div class="title">
                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Upload Employee Details
                 
                            </div>
                        </div>
                        <div class="widget-body">
                            <fieldset>
                                <table border="0" width="100%" align="left" cellpadding="4" cellspacing="1">
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom" width="30%">Upload Employee Data Bank</td>
                                        <td class="frm-rght-clr123 border-bottom" width="40%">
                                            <asp:FileUpload ID="fpEDB" runat="server" />
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                                ControlToValidate="fpEDB" ValidationGroup="b" CssClass="txt-red" ErrorMessage="only Excel format(.xls,.xlsx)"
                                                ValidationExpression="^.+(.xls|.XLS|.xlsx|.XLSX)$"></asp:RegularExpressionValidator>
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="30%" style="border-left: none">
                                            <asp:Button ID="btn_Branch" Text="Submit" runat="server" CssClass="button" ValidationGroup="b" OnClick="btn_Branch_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                    </div>
                </div>

            </div>
        </div>



        <script src="js/jquery.min.js" type="text/javascript"></script>
        <script src="js/bootstrap.js" type="text/javascript"></script>
        <script src="js/moment.js" type="text/javascript"></script>

        <!-- Data tables JS -->

        <script src="js/jquery.dataTables.js" type="text/javascript"></script>

        <!-- Sparkline Chart JS -->
        <script src="js/sparkline.js" type="text/javascript"></script>

        <!-- Easy Pie Chart JS -->
        <script src="js/pie-charts/jquery.easy-pie-chart.js" type="text/javascript"></script>

        <!-- Tiny scrollbar js -->
        <script src="js/tiny-scrollbar.js" type="text/javascript"></script>

        <!-- Custom Js -->
        <script src="js/theming.js" type="text/javascript"></script>
        <script src="js/custom.js" type="text/javascript"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_Emp').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script type="text/javascript">
            (function (i, s, o, g, r, a, m) {
                i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
                    (i[r].q = i[r].q || []).push(arguments)
                }, i[r].l = 1 * new Date(); a = s.createElement(o),
                m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
            })(window, document, 'script', '../../www.google-analytics.com/analytics.js', 'ga');

            ga('create', 'UA-41161221-1', 'srinu.html');
            ga('send', 'pageview');

        </script>

        <script type="text/javascript">
            function validate() {

                var module = $('#txtModule').val();
                var moduledesc = $('#txtModuleDesc').val();

                var regModuleName = document.getElementById('txtModuleName').pattern;
                var regModuleDesc = document.getElementById('txtModuleDesc').pattern;


                if (module == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModule').focus();
                    return false;
                }

                if (!document.getElementById('txtModuleName').value.match(regModuleName)) {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModule').focus();
                    return false;
                }

                if (moduledesc == '') {
                    window.parent.$('body').attr('style', 'opacity:1');
                    $('#loader').attr('style', 'display:none');
                    $('#txtModuleDesc').focus();
                    return false;
                }

            };
        </script>

    </form>
</body>
</html>
