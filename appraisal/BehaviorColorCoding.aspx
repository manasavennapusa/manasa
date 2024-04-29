<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BehaviorColorCoding.aspx.cs" Inherits="appraisal_BehaviorColorCoding" %>

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

<!--<html lang="en">
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
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
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Appraisal Approvers Master</h2>
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
                                    <asp:Label ID="lblhead" runat="server" Text="Create Appraisal Approvers"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdcolor" runat="server" Width="100%" AutoGenerateColumns="False"
                                        DataKeyNames="id"  OnPreRender="grdcolor_PreRender"
                                        CssClass="table table-condensed table-striped  table-bordered pull-left">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Performance Objcetives" HeaderStyle-Width="20%">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblObjcetives" runat="server" Text='<%# Eval("performance_objectivies") %>' ></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Unaccetable"  HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Unaccetable" runat="server" CssClass="button"  CommandArgument='<%#Eval("unaccetable") %>' OnCommand="btn_Unaccetable_Command"  BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("unaccetable").ToString()) %>' Text="" Width="100%" Height="150%" ></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Sometimes"  HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Sometimes" runat="server" CommandArgument='<%#Eval("sometimes") %>' OnCommand="btn_Unaccetable_Command"  BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("sometimes").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Regularly"  HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Regularly" runat="server"  CommandArgument='<%#Eval("regular") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("regular").ToString()) %>' Text="" Width="100%" Height="150%"></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Always"  HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_Always" runat="server"  CommandArgument='<%#Eval("always") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("always").ToString()) %>' Text="" Width="100%"  Height="150%" ></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Role Model"  HeaderStyle-Width="16%">
                                                <ItemTemplate>
                                                    <asp:Button ID="btn_RoleModel" runat="server" CommandArgument='<%#Eval("role_model") %>' OnCommand="btn_Unaccetable_Command" BackColor='<%# System.Drawing.ColorTranslator.FromHtml(Eval("role_model").ToString()) %>' Text="" Width="100%" Height="150%" ></asp:Button>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <div class="row">
                                        Performance and Behavour <asp:Label ID="lblpreformance" runat="server" Width="150px" Height="50" ></asp:Label>
                                    </div>
                                     <div class="clearfix"></div>
                                </div>
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
                $('#grdcolor').dataTable({
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
