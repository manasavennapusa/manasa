<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rolemenu.aspx.cs" Inherits="menuconfig_rolemenu" %>

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

<!--
  <![endif]-->

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
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
    <style type="text/css">
        .star 
        {
            color:red;
        }
    </style>


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
                                <h2>Role Menu Configuration</h2>
                            </div>
                           
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="widget">
                                <div class="widget-header">
                                    <div class="title">
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Menu Configuration
                 
                                    </div>
                                </div>

                                <div class="widget-body">

                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Role Name<span class="star">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlRole" runat="server" CssClass="span4"
                                                    DataSourceID="SqlDataSource1" DataTextField="role" DataValueField="id">
                                                    <asp:ListItem Value="0" Text="----Select----"></asp:ListItem>
                                                   <%-- <asp:ListItem Value="E" Text="Employee"></asp:ListItem>--%>
                                                </asp:DropDownList>
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRole"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Role Name" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Module<span class="star">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="ddlModule" runat="server" CssClass="span4" DataSourceID="SqlDataSource2"
                                                    DataTextField="modulename" DataValueField="modulecode">
                                                    <asp:ListItem Text="" Value="0"></asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlModule"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Module" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </div>
                                        </div>

                                        <div class="form-actions no-margin">
                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit"  OnClick="btnSave_Click" ValidationGroup="c" />
                                           <%-- <button type="button" class="btn">Cancel</button>--%>
                                            <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary" Text="Reset" OnClick="btncancel_Click" />
                                        </div>
                                    </fieldset>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Assigned Menus
                                        </div>
                                        <asp:Button ID="btnDelete" Style="float: right;" runat="server"  OnClientClick="return confirm('Deleted Successfully');" CssClass="btn btn-primary" Text="Delete" OnClick="btnDelete_OnClick" />
                                    </div>

                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="gvAssignMenu" runat="server" AutoGenerateColumns="false" DataKeyNames="slno" OnPreRender="gvAssignMenu_PreRender" CssClass="table table-condensed table-striped table-hover table-bordered pull-left">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl. No" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblSlNo" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "slno")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Parent Menu">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "pmenucode")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Child Menu">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menucode")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Menu Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menudesc")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                         <HeaderTemplate>
                                                                                Select All 
                                                                    <asp:CheckBox ID="empgrid1_chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="empgrid1_chkSelectAll_CheckedChanged" />
                                                                            </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkMenu" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <br />
                        <br />

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Un-Assigned Menus
                                    
                                        </div>
                                        <asp:Button ID="btnAssign" Style="float: right;" runat="server"  OnClientClick="return confirm('Unassigned Successfully');" CssClass="btn btn-primary" Text="Unassign" OnClick="btnAssign_OnClick" />

                                    </div>

                                    <div class="widget-body">
                                        <div id="dt_example1" class="example_alt_pagination">

                                            <asp:GridView ID="gvNotAssignMenu" runat="server" AutoGenerateColumns="false" DataKeyNames="menucode" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="gvNotAssignMenu_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Parent Menu" ControlStyle-CssClass="sorting_asc">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "pmenucode")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Child Menu">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMenuCode" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "menucode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Menu Name">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container.DataItem, "menudesc")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select">
                                                         <HeaderTemplate>
                                                                     Select All 
                                                       <asp:CheckBox ID="empgrid2_chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="empgrid2_chkSelectAll_CheckedChanged" />
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkMenu" runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                     <%--<asp:TemplateField HeaderText="Select" HeaderStyle-Width="4px">
                                                                            <HeaderTemplate>
                                                                                Select All 
                                                                    <asp:CheckBox ID="empgrid2_chkSelectAll" AutoPostBack="true" runat="server" OnCheckedChanged="empgrid2_chkSelectAll_CheckedChanged" />
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="chkSelect" runat="server" />
                                                                            </ItemTemplate>

                                                                        </asp:TemplateField>--%>
                                                    <%-- <asp:TemplateField HeaderText="Insert">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkInsert" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Update">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkUpdate" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkDelete" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkPrint" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Export">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkExport" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                                </Columns>
                                            </asp:GridView>
                                            <div class="clearfix"></div>
                                        </div>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" SelectCommand="select '0' as modulecode,'--Select--' as modulename union select modulecode,modulename from module"
            SelectCommandType="Text" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" SelectCommand="select cast('0' as varchar) as id,'--Select--' as role union select 'E' as id,'Employee' as role union select cast(id as varchar) id,role from tbl_intranet_role where status = 1"
            SelectCommandType="Text" ProviderName="System.Data.SqlClient" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"></asp:SqlDataSource>

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
                $('#gvAssignMenu').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gvNotAssignMenu').dataTable({
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
