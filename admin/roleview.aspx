<%@ Page Language="C#" AutoEventWireup="true" CodeFile="roleview.aspx.cs" Inherits="Admin_company_empview"
    Title="SmartDrive Labs Technologies India Pvt. Ltd. : Role View" %>

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
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Role </h2>
                            </div>
                          
                            <div class="clearfix"></div>
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
                                            <asp:GridView ID="Grid_Emp" runat="server"  DataKeyNames="id" OnPreRender="Grid_Emp_PreRender"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left" AutoGenerateColumns="false">
                                                <PagerSettings PageButtonCount="100"></PagerSettings>
                                                <Columns>
                                                      <asp:BoundField DataField="id" HeaderText="Role ID " SortExpression="role"></asp:BoundField>
                                                    <asp:BoundField DataField="role" HeaderText="Role " SortExpression="role"></asp:BoundField>
                                                    <asp:BoundField DataField="description" HeaderText="Description" ReadOnly="True"
                                                        SortExpression="description"></asp:BoundField>
                                                    <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <a href="editrole.aspx?role_id=<%#DataBinder.Eval(Container.DataItem, "id")%>" target="_self"
                                                                class="link05"><img src="images/edit.png" width="15" height="15" border="0"></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                        <%--<asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="SELECT id,role,description FROM tbl_intranet_role"
                            DeleteCommand="DELETE FROM [tbl_intranet_role] WHERE [id]=@id" ProviderName="System.Data.SqlClient"
                            ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>--%>
                    </div>


                </ContentTemplate>
            </asp:UpdatePanel>
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
