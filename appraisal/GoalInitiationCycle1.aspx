<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoalInitiationCycle1.aspx.cs" Inherits="appraisal_GoalInitiationCycle1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartDrive Labs</title>
    <meta charset="utf-8" />

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <script src="js/popup1.js"></script>

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
    <style>
        .center {
            position: absolute;
            top: 948px;
            left: 500px;
        }
    </style>
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="images/loader.gif" alt="" />
                                    Please Wait...
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Goals Cycle 1 </h2>
                                <%--Initiation--%>
                            </div>

                            <div class="clearfix"></div>
                        </div>



                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style=": none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="lblhead" runat="server" Text="Goals Cycle 1 Initiation"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="widget-body">

                                        <table style="width: 100%;">

                                            <tr>
                                                <td>
                                                    <table width="100%" class="table table-condensed table-striped  table-bordered pull-left">

                                                        <tr>
                                                            <td class="frm-lft-clr123">EmpCode</td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span10" onkeypress="return isAlphaNumeric()"></asp:TextBox>

                                                                <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Empcode" ValidationGroup="d"
                                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td class="frm-lft-clr123">Department</td>
                                                            <td class="frm-rght-clr123">&nbsp;
                                                                <asp:DropDownList ID="ddl_dept" runat="server" CssClass="span10" DataSourceID="SqlDataSourc4"
                                                                    DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound">
                                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                    ProviderName="System.Data.SqlClient" SelectCommand="select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_dept"
                                                                    Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department" ValidationGroup="d" InitialValue="0"
                                                                    Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </td>
                                                            <%-- SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name">--%>
                                                            <%--  <td class="frm-lft-clr123  " style="width: 8%">Grade</td>
                                                            <td class="frm-rght-clr123  " width="16%">
                                                                <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                                    DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound">
                                                                </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                    ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                                            </td>--%>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Button ID="btn_search" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btn_search_Click" ValidationGroup="d" />
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
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="gveligible" runat="server" DataKeyNames="empcode" Width="100%" AutoGenerateColumns="False" OnPreRender="gveligible_PreRender" EmptyDataText="No Data Found!"
                                                CssClass="table table-condensed table-striped  table-bordered pull-left" OnRowDeleting="gveligible_RowDeleting" OnRowDataBound="gveligible_RowDataBound" OnPageIndexChanging="gveligible_PageIndexChanging">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Employee Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Department">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("dept") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date of Joining">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("emp_doj") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Goal Status">
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkdelete" runat="server" OnClientClick="return confirm('Are you sure to delete this entry?')" CommandName="Delete" CssClass="link05" Text="Delete" ToolTip="Delete" />&nbsp;
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Select" Visible="false">
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
                                        </div>

                                        <div class="clearfix"></div>

                                    </div>
                                    <div class="form-actions no-margin" id="divbutton" runat="server" visible="false">
                                        <asp:Button ID="btnInitiateAprasial" runat="server" visible="false" CssClass="btn btn-primary" Text="Initiate Goals" OnClick="btnInitiateAprasial_Click" Style="float: right" />
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

    <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#gveligible').dataTable({
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
</body>
</html>
