<%@ Page Language="C#" AutoEventWireup="true" CodeFile="holdrrfprocess.aspx.cs" Inherits="recruitment_holdrrfprocess" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->
    <script src="../Travel/js/popup1.js"></script>
    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />

    <%-- <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />--%>

    <style type="text/css">
        .ajax__calendar_container td {
            border: none;
            padding: 0px;
        }
    </style>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>RECRUITMENT REQUISITION FORM</h2>--%>
                        <h2>RRF Details</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                   <%-- <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">Recruitment Requisition Forms</span>--%>
                                     <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">View</span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="grdholdrrf" runat="server" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="id"
                                        EmptyDataText="No data Found" CssClass="table table-condensed table-striped  table-bordered pull-left" OnPreRender="grdholdrrf_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Requested By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreq" runat="server" Text='<%#Eval("requestedby")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesig" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldept" runat="server" Text='<%#Eval("department_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="view">
                                                <ItemTemplate>
                                                    <a href="JavaScript:newPopup1('holdrrfdetails.aspx?id=<%# Eval("id") %>')" class="link05" style="color:#196db5"><%# Eval("rrf_code") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Select" Visible="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkclose" runat="server" />
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

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;">Recruitment Requisition Forms on Hold</span>--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">On Hold</span>
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example1" class="example_alt_pagination">

                                    <asp:GridView ID="grdactivaterrf" runat="server" AutoGenerateColumns="False" AllowSorting="True" DataKeyNames="id"
                                        EmptyDataText="No data Found" CssClass="table table-condensed table-striped  table-bordered pull-left" OnPreRender="grdactivaterrf_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Requested By">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblreq" runat="server" Text='<%#Eval("requestedby")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldesig" runat="server" Text='<%#Eval("designationname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldept" runat="server" Text='<%#Eval("department_name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="view">
                                                <ItemTemplate>
                                                    <a href="JavaScript:newPopup1('activaterrfdetails.aspx?id=<%# Eval("id") %>')" class="link05" style="color:#196db5"><%# Eval("rrf_code") %></a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Filled By" Visible="false">
                                                <ItemTemplate>
                                                    <a href='fillApplicants.aspx?id=<%# Eval("id") %>' class="link05">Enter</a>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Select" Visible="false">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkclose" runat="server" />
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

            </div>
        </div>
    </form>

    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

    <script src="../js/analytics.js"></script>
    <!-- Custom Js -->
    <script src="../js/theming.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

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

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdholdrrf').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdactivaterrf').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>

