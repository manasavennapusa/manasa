<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InitiateIncrementalCyle.aspx.cs" Inherits="appraisal_InitiateIncrementalCyle" %>

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
                        <h2>Salary Increment Initiation</h2>
                    </div>
                  
                    <div class="clearfix"></div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
                            <ProgressTemplate>
                                <div class="divajax">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <img src="../images/loading.gif" /></td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                                        </tr>
                                    </table>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Salary Increment Initiation"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">

                                        <table style="width: 100%; border: 0">

                                            <tr>
                                                <td>
                                                    <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">
                                                        <%--<tr>
                                                            <td align="left" class="txt02" colspan="7">
                                                                <h5>Search Employee</h5>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td class="frm-lft-clr123 " width="12%">EmpName/EmpCode</td>
                                                            <td class="frm-rght-clr123 " width="17%">
                                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span11" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                            </td>
                                                            <td class="frm-lft-clr123 "  width="11%">Department</td>
                                                            <td class="frm-rght-clr123 " width="16%">&nbsp;<asp:DropDownList ID="ddl_dept" runat="server" CssClass="span11" DataSourceID="SqlDataSourc4"
                                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound" >
                                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                                            </td>
                                                            <td class="frm-lft-clr123 " style=" width: 8%">Grade</td>
                                                            <td class="frm-rght-clr123 " width="16%">
                                                                <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11"
                                                                    OnDataBound="dd_dpt_DataBound" >
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td class="frm-rght-clr123 " style=" width: 10%">
                                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>

                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee List
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <asp:GridView ID="gveligible" runat="server" CellSpacing="0"
                                            CellPadding="4" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" OnPageIndexChanging="gveligible_PageIndexChanging"
                                            BorderWidth="0px" AllowPaging="True" PageSize="50" EmptyDataText="No such employee exists !"
                                            CssClass="table table-condensed table-striped  table-bordered pull-left">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Sl.NO">

                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex +1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Eval ("empcode") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempname" runat="server" Text='<%# Eval ("name") %>'></asp:Label></a>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderStyle-Width="8%">
                                                    <HeaderTemplate>
                                                        Select 
                                                <asp:CheckBox ID="chkAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkAll_CheckedChanged" />
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" />
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <div class="clearfix"></div>

                                    </div>
                                    <div class="form-actions no-margin" id="divbutton" runat="server">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Text="Initiate Ratings" OnClick="btnSave_Click" Style="float: right" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
