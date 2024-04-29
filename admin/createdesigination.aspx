<%@ Page Language="C#" AutoEventWireup="true" CodeFile="createdesigination.aspx.cs"
    Inherits="Admin_company_createcompany" Title="Create company" %>

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
    <style type="text/css">
        .star {
            color: red;
        }
    </style>

    <script type="text/javascript">
        function Validate() {
            var branch = document.getElementById('<%=DropDownList1.ClientID%>');
            var dept = document.getElementById('<%=DropDownList1.ClientID%>');
            //var bu = document.getElementById('%=txt_branch_name.ClientID%>');

            if (branch.value == "0") {
                alert("Please select WorkLoaction.");
                return false;
            }

            if (dept.value == "0") {
                alert("Please select Department.");
                return false;
            }
            if (bu.value == "") {
                alert("Please enter Designation.");
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2> Designation </h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>Create
                                </div>
                            </div>

                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group" runat="server" visible="false">
                                        <label class="control-label">Work Location</label>
                                        <%-- <div class="controls">
                                            <asp:DropDownList ID="drpbranch" runat="server" CssClass="span4" Height="" Width=""
                                                DataSourceID="sql_data_branch" DataTextField="branch_name" DataValueField="Branch_Id"
                                                OnDataBound="drpbranch_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpbranch_SelectedIndexChanged">
                                            </asp:DropDownList>--
                                             <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drpbranch"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Work Location"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                            <asp:SqlDataSource
                                                ID="sql_data_branch" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]"></asp:SqlDataSource>
                                        </div>--%>


                                       
                                    </div>

                                     <div class="control-group">
                                            <label class="control-label">Department Name<span class="star" style="color:red">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="span4" Height="" Width=""
                                                    DataTextField="department_name" DataValueField="departmentid"
                                                    OnDataBound="DropDownList1_DataBound" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                 <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownList1"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Department"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>
                                                <%--<asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="drpdepartment"
                                                ErrorMessage="CompareValidator" Operator="NotEqual" ValidationGroup="c" ValueToCompare="0"
                                                ToolTip="Select Department Name"><img src="../img/error1.gif" alt="" /></asp:CompareValidator>--%>

                                                <%--  <asp:SqlDataSource
                                                ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand="select departmentid,department_name from dbo.tbl_internate_departmentdetails"></asp:SqlDataSource>--%>
                                            </div>
                                        </div>

                                    <div class="control-group">
                                        <label class="control-label">Designation Name<span class="star" style="color:red">*</span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_branch_name" runat="server"  CssClass="span4" Width="290px" onkeypress="return isChar_Space_dash()"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_branch_name"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter Designation Name" ValidationGroup="c"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">Description</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_branch_code" runat="server" CssClass="span4" Width="290px" Height="50px" onkeypress="return isChar_Space_dash()"
                                                TextMode="MultiLine"></asp:TextBox>

                                        </div>
                                    </div>

                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btnsv" OnClick="btnsv_Click" runat="server" Text="Submit" CssClass="btn btn-info" ValidationGroup="c"></asp:Button>
                                        <asp:Button ID="btnreset" OnClick="btnreset_Click" runat="server" Text="Reset" CssClass="btn btn-info" ValidationGroup=""></asp:Button>
                                        <%--<button type="button" class="btn">Cancel</button>--%>
                                    </div>
                                    <%--  </fieldset>--%>
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
        <script type="text/javascript">
            document.write('<style type="text/css">.tabber{display:none;}<\/style>');
        </script>


    </form>
</body>
</html>
