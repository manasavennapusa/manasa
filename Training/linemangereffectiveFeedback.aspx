<%@ Page Language="C#" AutoEventWireup="true" CodeFile="linemangereffectiveFeedback.aspx.cs" Inherits="Training_linemangereffectiveFeedback" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css@vd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />

    <style type="text/css">
        .auto-style8 {
            width: 11%;
        }

        .auto-style9 {
            width: 22%;
        }
    </style>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="viewfeedbackemp" runat="server" class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Effectiveness FeedBack Form</h2>
                            </div>

                        </div>
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="Grid_feedback" runat="server" DataKeyNames="id" AutoGenerateColumns="False"
                                                EmptyDataText="No such employee exists !" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive"
                                                 OnPreRender="Grid_feedback_PreRender">
                                                <Columns>

                                                   <%-- <asp:TemplateField HeaderText="TrainingID" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltrainingid" runat="server" Text='<%# Bind ("trining_id") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>

                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraincode" runat="server" Text='<%# Bind ("training_code") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Training Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraininame" runat="server" Text='<%# Bind ("training_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempname" runat="server" Text='<%# Bind ("emp_fname") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblfromdate" runat="server" Text='<%# Bind ("FromDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltodate" runat="server" Text='<%# Bind ("ToDate") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   <%-- <asp:TemplateField HeaderText="Module Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblmodulename" runat="server" Text='<%# Bind ("module_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldep" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:HyperLinkField DataNavigateUrlFields="empcode" HeaderText="View" DataNavigateUrlFormatString="viewEffectiveLinemagerfeed.aspx?empcode={0}&back=0"
                                                NavigateUrl="viewEffectiveLinemagerfeed.aspx" Text="&lt;img src='../images/view.png'/&gt;">

                                                <HeaderStyle CssClass="" />
                                                <ControlStyle CssClass="link05" Width="50%" />
                                            </asp:HyperLinkField>
                                                   <%-- <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="viewEffectiveLinemagerfeed.aspx?empcode={0}"
                                                        NavigateUrl="viewEffectiveLinemagerfeed.aspx" Text="View" ControlStyle-CssClass="btn btn-info"></asp:HyperLinkField>--%>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
         <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/moment.js" type="text/javascript"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>

        <!-- Sparkline Chart JS -->
        <script src="../js/sparkline.js" type="text/javascript"></script>

        <!-- Easy Pie Chart JS -->
        <script src="../js/pie-charts/jquery.easy-pie-chart.js" type="text/javascript"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js" type="text/javascript"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js" type="text/javascript"></script>
        <script src="../js/custom.js" type="text/javascript"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#Grid_feedback').dataTable({
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


