<%@ Page Language="C#" AutoEventWireup="true" CodeFile="departmenttype.aspx.cs" Inherits="admin_departmenttype" Title="Create Company"%>

<%--<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createdepartment.aspx.cs"
    Inherits="Admin_Company_createcompany"  %>--%>

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
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <style type="text/css">
        .star
        {
            color: red;
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
                        <h2> Department Type </h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    Create
                                </div>
                            </div>

                            <div class="widget-body">
                                <fieldset>
                                   

                                    <div class="control-group">
                                        <label class="control-label">Work Location<span class="star" style="color:red"></span></label>
                                        <div class="controls">
                                          <asp:DropDownList ID="drp_work_location" runat="server" CssClass="span4" DataSourceID="SqlDataSource1" DataTextField="branch_name"
                                               DataValueField="branch_id" OnSelectedIndexChanged="drp_work_location_SelectedIndexChanged" OnDataBound="drp_work_location_DataBound"></asp:DropDownList>
                                          <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select branch_id,branch_name from dbo.tbl_intranet_branch_detail"></asp:SqlDataSource>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="drp_work_location"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Select Work Location" ValidationGroup="c"
                                                        InitialValue="0" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Department Type Name <span class="star" style="color:red"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_dept_typename" runat="server" CssClass="span4" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_dept_typename"
                                                        Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Department Type Name" ValidationGroup="c"
                                                        Width="6px"><img 
                                                            src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                           
                                        </div>
                                    </div>
                                   

                                    <div class="form-actions no-margin">
                                        <div style="padding-left:0%">
                                            <asp:Button ID="btn_save" OnClick="btn_save_Click" runat="server" Text="Submit" CssClass="btn btn-info" ValidationGroup="c"
                                                ></asp:Button>
                                             <asp:Button ID="btnrest" OnClick="btnrest_Click" runat="server" Text="Reset" CssClass="btn btn-info" 
                                                ></asp:Button>
                                        </div>
                                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    </div>
                                </fieldset>
                            </div>

                            <%--<table class="table table-condensed table-striped  table-bordered pull-left">

                                <tbody>
                                    <tr>
                                        <td width="25%">Work Location<span class="star"></span>
                                        </td>
                                        <td width="75%">
                                            <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="span4" DataSourceID="SqlDataSource1" DataTextField="branch_name" DataValueField="Branch_Id"
                                                OnDataBound="drp_comp_name_DataBound">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Branch Name"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Department Name<span class="star"></span>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_branch_name" runat="server" CssClass="span4" Width="" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Department Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_branch_name"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123" width="44%">Establishment Date</td>       
                                        <td class="frm-rght-clr123" width="55%">
                                            <asp:TextBox ID="txt_est_date" runat="server" CssClass="span4"  onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                             <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                              <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11"
                                               TargetControlID="txt_est_date" Enabled="True" Format="dd MMM yyyy">
                                                </cc1:CalendarExtender>
                                           <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image11"
                                                TargetControlID="txt_est_date" Enabled="True" Format=" dd MMM yyyy ">
                                            </cc1:CalendarExtender>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Department Code
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txt_branch_code" runat="server" CssClass="span4" Width="" onkeypress="return isAlphaNumeric();"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_branch_code"
                                                ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z0-9]+$" ToolTip="Enter only aphanumeric"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>


                                </tbody>
                            </table>--%>
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
            $(document).ready(function () {
                $('input[type=text]').bind('paste', function (e) {
                    e.preventDefault();
                });
            });
            document.write('<style type="text/css">.tabber{display:none;}<\/style>');

        </script>



    </form>
</body>
</html>
