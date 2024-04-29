<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewtempemployeedetails.aspx.cs" Inherits="admin_viewtempemployeedetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>SmartHR</title>
    <meta name="author" content="SDLGlobe Technologies India Pvt. Ltd.">
    <meta content="width=device-width, initial-scale=1.0, user-scalable=no" name="viewport">
    <meta name="description" content="SDLGlobe Technologies India Pvt. Ltd.">
    <meta name="keywords" content="SDLGlobe Technologies India Pvt. Ltd.">
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
                        <h2>View Employee</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>

                <%--   <asp:UpdatePanel ID="updatepannel1" runat="server">
                    <ContentTemplate>--%>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                   <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Employee Master 
                                </div>
                            </div>

                            <table class="table table-condensed table-striped table-hover table-bordered pull-left">
                                <tr>
                                    <td class="frm-lft-clr123 border-bottom" width="15%">Emp Name/Code
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom" width="15%" style="border-right:1px solid #e0e0e0">
                                        <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="120px"></asp:TextBox>
                                    </td>
                                    <td class="frm-lft-clr123 border-bottom" style="border-left: none;" width="15%">Designation
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom" width="15%"  style="border-right:1px solid #e0e0e0">
                                        <asp:DropDownList ID="dd_designation" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1" Width="100px"
                                            DataTextField="designationname" DataValueField="id" OnDataBound="dd_designation_DataBound">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [id], [designationname] FROM [tbl_intranet_designation]"></asp:SqlDataSource>
                                    </td>
                                    <td class="frm-lft-clr123 border-bottom" style="border-left: none;" width="13%">Department
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom" width="15%"  style="border-right:1px solid #e0e0e0">
                                        <asp:DropDownList ID="dd_branch" runat="server" CssClass="blue1" DataSourceID="SqlDataSource2"
                                            DataTextField="department_name" DataValueField="departmentid" OnDataBound="dd_branch_DataBound"
                                            Width="172px">
                                        </asp:DropDownList>
                                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT distinct  [departmentid], branch_name + '-' + department_name department_name FROM [tbl_internate_departmentdetails] INNER JOIN tbl_intranet_branch_detail ON tbl_intranet_branch_detail.branch_id=tbl_internate_departmentdetails.branchid order by department_name"></asp:SqlDataSource>
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom" style="border-left: none;" width="12%">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info pull-right" Text="Search" OnClick="btn_search_Click" />&nbsp;
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>
                <%--</ContentTemplate>
                </asp:UpdatePanel>--%>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Employee Details
                                    
                                </div>

                            </div>
                            <div class="widget-body">

                                <div id="dt_example" class="example_alt_pagination">



                                    <asp:GridView ID="empgrid" runat="server" DataKeyNames="empcode" AutoGenerateColumns="False"
                                        EmptyDataText="No such employee exists !" class="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="empgrid_PreRender2">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="16%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l0" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="26%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Designation">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l1" runat="server" Text='<%# Bind ("designationname") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Department">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="viewempdetail.aspx?empcode={0}"
                                                NavigateUrl="viewempdetail.aspx" Text="View" Visible="false">

                                                <HeaderStyle CssClass="" />
                                                <ControlStyle CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" Width="50%" />
                                            </asp:HyperLinkField>
                                            <asp:HyperLinkField DataNavigateUrlFields="empcode" DataNavigateUrlFormatString="edittemploginbyhr.aspx?empcode={0}"
                                                NavigateUrl="edittemploginbyhr.aspx" Text="Edit">
                                                <ControlStyle CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" Width="50%" />
                                                <HeaderStyle CssClass="" />
                                                <ItemStyle CssClass=""></ItemStyle>
                                            </asp:HyperLinkField>
                                            <asp:TemplateField Visible="false">
                                                <HeaderStyle CssClass="" HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <%#linkreset(Convert.ToString(DataBinder.Eval(Container.DataItem, "empcode"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="" />
                                        <FooterStyle CssClass="" />
                                        <RowStyle Height="5px" />
                                        <PagerStyle CssClass=""></PagerStyle>
                                    </asp:GridView>

                                    <asp:SqlDataSource ID="SqlDataSource3" ConnectionString="<%$ ConnectionStrings:intranetConnectionString  %>"
                                        runat="server" SelectCommand="sp_leave_fetch_emp_detail" SelectCommandType="StoredProcedure">
                                        <SelectParameters>
                                            <asp:Parameter Direction="ReturnValue" Name="RETURN_VALUE" Type="Int32" />
                                            <asp:Parameter DefaultValue="" Name="name" Type="String" />
                                            <asp:Parameter DefaultValue="0" Name="desg" Type="Int32" />
                                            <asp:Parameter DefaultValue="0" Name="branch" Type="Int32" />
                                            <asp:Parameter Name="status" Type="String" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                    <div class="clearfix"></div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>



                <span id="message" runat="server">&nbsp;</span>
            </div>
        </div>
    </form>
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
            $('#empgrid').dataTable({
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

