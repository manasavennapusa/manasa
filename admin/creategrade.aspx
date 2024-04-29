<%@ Page Language="C#" AutoEventWireup="true" CodeFile="creategrade.aspx.cs" Inherits="Admin_Company_createcompany"
    Title="Create Company" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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
   <meta charset="utf-8" content="" />
    <title>SmartDrive Labs</title>
    <meta name="author" content="Srinu Basava">
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport">
    <meta name="description" content="StartUp Admin UI">
    <meta name="keywords" content="StartUp Admin UI, Admin UI, Admin Dashboard, Srinu Basava, Best admin UI, Best backend UI, Best Dashboard, Responsive admin UI, Responsive dashboard, Responsive Backend, Mobile admin, Mobile Backend, Mobile Dashboard">
    
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
                        <h2> Grade </h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span></span>Create
                                </div>
                            </div>                             


                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Grade Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_branch_name" runat="server" CssClass="blue1" Width="300px" onkeypress="return isChar_Number_space_ifin()"></asp:TextBox>                                            
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Grade Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_branch_name"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9\s\-]+$" ToolTip="Enter only alphanumeric and space,-"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Description</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_branch_code" runat="server" CssClass="blue1" Width="300px" Height="50px"
                                                TextMode="MultiLine"></asp:TextBox>
                                           
                                        </div>
                                    </div>

                                    <div class="control-group" style="display:none">
                                        <label class="control-label">Grade Type</label>
                                        <div class="controls">
                                            <label class="radio inline">
                                                <asp:RadioButtonList ID="rbtn_gradetype" runat="server" CellSpacing="1000" RepeatDirection="Horizontal">
                                                    <asp:ListItem Value="A" Selected="True">Administration &nbsp; &nbsp;&nbsp; &nbsp;</asp:ListItem>
                                                    <asp:ListItem Value="T">Technical</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </label>

                                        </div>
                                    </div>

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-primary"
                                            ValidationGroup="c"></asp:Button>
                                        <asp:Button ID="btnreset" OnClick="btnreset_Click" runat="server" Text="Reset" CssClass="btn btn-primary"
                                            ValidationGroup=""></asp:Button>
                                       <%-- <button type="button" class="btn">Cancel</button>--%>
                                    </div>
                                </fieldset>
                            </div>

                        </div>
                    </div>
                </div>
                <span id="message" runat="server"></span>
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
