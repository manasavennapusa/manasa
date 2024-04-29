<%@ Page Language="C#" AutoEventWireup="true" CodeFile="city.aspx.cs" Inherits="admin_city" %>

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
                        <h2>City </h2>
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
                                    <asp:Label ID="lblhead" runat="server" Text="Create City"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">

                                <fieldset>
                                    <asp:UpdatePanel ID="updatepanel1" runat="server">
                                        <ContentTemplate>
                                            <div class="control-group">
                                                <label class="control-label">Country</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlcountry" runat="server" CssClass="blue1"
                                                        OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"
                                                        OnDataBound="ddlcountry_OnDataBound">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlcountry"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Country" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">State</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddlstate" runat="server" CssClass="blue1"
                                                        AutoPostBack="true" OnDataBound="ddlstate_OnDataBound"
                                                        OnSelectedIndexChanged="ddlstate_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlstate"
                                                        Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select State"
                                                        ValidationGroup="c" Width="6px"><img 
                                                                src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">City</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtcity" runat="server" CssClass="blue1" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtcity"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter City" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtcity"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Description</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_Description" runat="server" CssClass="blue1" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                 <%--   <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtcity"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter City" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>--%>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_Description"
                                                        ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                        ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btncity" runat="server" CssClass="btn btn-primary" OnClick="btncity_Click"
                                            Text="Save" ValidationGroup="c" />
                                         <asp:Button ID="btnrest" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btn_cncl_Click" ></asp:Button>
                                    </div>
                                </fieldset>

                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid" id="grujj" runat="server">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View 
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="Grid_Emp" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                        OnPreRender="Grid_Emp_PreRender"
                                        EmptyDataText="No Data  Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="City Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcity" runat="server" Text='<%#Eval("city")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="cid" DataNavigateUrlFormatString="~/admin/city.aspx?Id={0}"
                                                 Text="&lt;img src='images/edit.png'/&gt;" HeaderStyle-Width="20%">
                                                <ControlStyle CssClass="link05" Width="6%" />
                                            </asp:HyperLinkField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="clearfix"></div>

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
