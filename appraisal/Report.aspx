<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="appraisal_Report" %>

<!DOCTYPE html>

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
    <link href="../css/main.css" rel="stylesheet" />

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


</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Appraisal Status</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                    <asp:Label ID="lblhead" runat="server" Text="Appraisal Status"></asp:Label>
                                </div>
                            </div>
                            <div class="widget-body">
                                <table class="table table-condensed table-striped table-bordered pull-left" style="width: 100%">

                                    <tr>
                                        <td class="frm-lft-clr123">EmpCode</td>
                                        <td class="frm-rght-clr123">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span10" Width="172px" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                            <a href="JavaScript:newPopup1('PickEmployee.aspx?role=13&empcode=<%=txt_employee.Text.ToString() %>');" title="Pick Employee"><i class="icon-user"></i></a>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txt_employee"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Select Empcode" ValidationGroup="e"
                                                Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="frm-lft-clr123">Department</td>
                                        <td class="frm-rght-clr123">
                                            <asp:DropDownList ID="ddl_dept" runat="server" CssClass="span10" DataSourceID="SqlDataSourc4"
                                                DataTextField="department_name" DataValueField="departmentid" OnDataBound="ddl_dept_DataBound" Width="172px">
                                            </asp:DropDownList><asp:SqlDataSource ID="SqlDataSourc4" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                ProviderName="System.Data.SqlClient" SelectCommand=" select distinct departmentid, department_name from tbl_internate_departmentdetails order by department_name"></asp:SqlDataSource>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_dept"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Select Department" ValidationGroup="e" InitialValue="0"
                                                Width="6px"><img  src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                        <%--SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name--%>
                                        <%-- <td class="frm-lft-clr123  " width="8%">Grade</td>
                                                                <td class="frm-rght-clr123  " width="16%" >
                                                                    <asp:DropDownList ID="dd_dpt" runat="server" CssClass="span11" DataSourceID="SqlDataSource2"
                                                                        DataTextField="gradename" DataValueField="id" OnDataBound="dd_dpt_DataBound" Width="172px">
                                                                    </asp:DropDownList><asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                                        ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  id, gradename  from tbl_intranet_grade"></asp:SqlDataSource>
                                                                </td>--%>
                                        <td class="frm-rght-clr123">
                                            <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass=" btn btn-primary" ValidationGroup="e" OnClick="btnSearch_Click" />
                                        </td>
                                    </tr>
                                </table>
                                <div class="clearfix"></div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td style="width: 100%; border-right: 1px solid #d7d7d7">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Employee List
                                                <span class="fs1" style="margin-left: 500px">Select Appraisal Cycle Year 
                                                </span>
                                                <span class="fs1" style="margin-left: 5px">
                                                    <asp:DropDownList ID="ddl_appraisal_cycle" runat="server" OnDataBound="ddl_appraisal_cycle_DataBound" OnSelectedIndexChanged="ddl_appraisal_cycle_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                                </span>
                                            </div>
                                        </div>
                                    </td>

                                </tr>
                            </table>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView ID="gvReport" runat="server" AllowSorting="True" AutoGenerateColumns="False" BorderWidth="0px"
                                        CaptionAlign="Left" CellPadding="4" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                        HorizontalAlign="Left" Width="110%"
                                        EmptyDataText="No Data Found">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Sl.No">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>
                                                <HeaderStyle Width="2%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Appraisal Year">
                                                <ItemTemplate>
                                                    <asp:Label ID="lebelyear" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"APP_year") %>'></asp:Label>

                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcode" runat="Server" Text='<%# Eval("Employee Code") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempname" runat="Server" Text='<%# Eval("Employee Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp Overall Rating" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblemprating" runat="Server" Text='<%# Eval("Employee Overall Rating") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp Overall Comment" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblempcomments" runat="Server" Text='<%# Eval("Employee Overall Comment") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsuprcode" runat="Server" Text='<%# Eval("Manager Code") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Name" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblsuprname" runat="Server" Text='<%# Eval("Manager Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Virtual Head Code ">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVituprcode" runat="Server" Text='<%# Eval("Virtual Head Code") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Virtual Head Name" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblVitprname" runat="Server" Text='<%# Eval("Virtual Head Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Overall rating" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmgrrating" runat="Server" Text='<%# Eval("Manager Overall Rating") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Manager Overall Comment" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmgrcomments" runat="Server" Text='<%# Eval("Manager Overall Comment") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Business Head Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmgrcode" runat="Server" Text='<%# Eval("Business Head Code") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Business Head Name" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblmgrname" runat="Server" Text='<%# Eval("Business Head Name") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Work Location" Visible="true">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbranch" runat="Server" Text='<%# Eval("Branch") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDept" runat="Server" Text='<%# Eval("Department") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Desig nation">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesignation" runat="Server" Text='<%# Eval("Designation") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Emp Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="Server" Text='<%# Eval("Employee Status") %>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle Width="5%" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <a href="#" class="btn btn-mini btn-info "
                                                        onclick="window.open('Evaluation_Report.aspx?empcode=<%#Eval("Employee Code") %>','_blank','height=400px,width=600px,top=120,left=450')">View</a>
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

        <script type="text/javascript" src="../js/timepicker.js"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#gvReport').dataTable({
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
