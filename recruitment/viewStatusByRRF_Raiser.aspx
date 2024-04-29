<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewStatusByRRF_Raiser.aspx.cs" Inherits="recruitment_viewStatusByRRF_Raiser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server" id="Head1">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
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


    <link href="../css/table.css" rel="stylesheet" type="text/css" />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>RECRUITMENT REQUISITON FORM</h2>--%>
                        <h2>Recruitment Requisition Form</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <%-- <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>RECRUITMENT REQUISITON FORM - STATUS--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                    <ol>
                                        <li>Pending Forms</li>
                                        <li>Rejected Forms</li>
                                        <li>Approved & Recruitment Initiated</li>
                                        <li>Recruitment Closed</li>
                                    </ol>

                                    <div>
                                        <p>
                                            <div class="widget-body">
                                                <div id="dt_example" class="example_alt_pagination">
                                                    <asp:GridView ID="grdPendingRRF" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" AllowSorting="True" OnPreRender="grdPendingRRF_PreRender"
                                                        EmptyDataText="No Data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                        <Columns>
                                                             <asp:TemplateField HeaderText="RRF Id">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrrfid" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Department">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No Of Posts">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requested By">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requisition Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" View" Visible="false">
                                                                <ItemTemplate>
                                                                    <a href='r_rrfview.aspx?id=<%# Eval("id") %>' class="link05">Status</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RRF Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                              <asp:HyperLinkField DataNavigateUrlFields="id" HeaderText="Edit" DataNavigateUrlFormatString="edit_rrf.aspx?id={0}"
                                                NavigateUrl="editempmaster.aspx" Text="&lt;img src='images/edit.png'/&gt;">
                                                <ControlStyle CssClass="link05"  Width="70%"/>
                                                <HeaderStyle CssClass="" />
                                                <ItemStyle CssClass=""></ItemStyle>
                                            </asp:HyperLinkField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <%--<a href='r_viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>--%>
                                                                    <a href='r_viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05">
                                                                        <img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </p>

                                    </div>

                                    <div>
                                        <p>
                                            <div class="widget-body">
                                                <div id="dt_example1" class="example_alt_pagination">
                                                    <asp:GridView ID="grdRejectedRRF" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdRejectedRRF_PreRender"
                                                        EmptyDataText="No Data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                        <Columns>

                                                            <asp:TemplateField HeaderText=" Department">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No Of Posts">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requested By">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requisition Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" View" Visible="false">
                                                                <ItemTemplate>
                                                                    <a href='r_rrfview.aspx?id=<%# Eval("id") %>' class="link05">Candidates</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RRF Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <%--<a href='viewrejectedrequisition.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>--%>
                                                                    <a href='viewrejectedrequisition.aspx?id=<%# Eval("id") %>' class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <div class="widget-body">
                                                <div id="dt_example2" class="example_alt_pagination">
                                                    <asp:GridView ID="grdRRF" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdRRF_PreRender"
                                                        EmptyDataText="No Data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText=" Department">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No Of Posts">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requested By">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requisition Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" View">
                                                                <ItemTemplate>
                                                                    <a href='r_rrfview.aspx?id=<%# Eval("id") %>' class="link05">Candidates</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RRF Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" View">
                                                                <ItemTemplate>
                                                                    <%--<a href='r_viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>--%>
                                                                    <a href='r_viewRequistionStatus.aspx?id=<%# Eval("id") %>' class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </p>
                                    </div>

                                    <div>
                                        <p>
                                            <div class="widget-body">
                                                <div id="dt_example3" class="example_alt_pagination">
                                                    <asp:GridView ID="grdclosedrrf" runat="server" AutoGenerateColumns="False" AllowSorting="True" OnPreRender="grdclosedrrf_PreRender"
                                                        EmptyDataText="No Data Found." CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText=" Department">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDepartment" runat="server" Text='<%# Eval("department_name") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Designation">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("designationname") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="No Of Posts">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblnoofposts" runat="server" Text='<%# Eval("total_no_posts") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requested By">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblRequestedBy" runat="server" Text='<%# Eval("requestedby") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" Requisition Date">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrequisitionDate" runat="server" Text='<%# Eval("createddate") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText=" View">
                                                                <ItemTemplate>
                                                                    <a href='r_rrfview.aspx?id=<%# Eval("id") %>' class="link05">Status</a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="RRF Code">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="View">
                                                                <ItemTemplate>
                                                                    <%--<a href='viewclosedrequisition.aspx?id=<%# Eval("id") %>' class="link05"><%# Eval("rrf_code") %></a>--%>
                                                                    <a href='viewclosedrequisition.aspx?id=<%# Eval("id") %>' class="link05"><img src="../images/view.png" width="17" height="17" border="0"></a>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </div>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="../js/jquery.min.js"></script>

    <script src="../js/jquery.dataTables.js"></script>
    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdPendingRRF').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

        $(document).ready(function () {
            $('#grdRejectedRRF').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

        $(document).ready(function () {
            $('#grdclosedrrf').dataTable({
                "sPaginationType": "full_numbers"
            });
        });

        $(document).ready(function () {
            $('#grdRRF').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
    <script type="text/javascript">
        $("#wizard").bwizard();
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
