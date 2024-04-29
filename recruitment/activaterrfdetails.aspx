<%@ Page Language="C#" AutoEventWireup="true" CodeFile="activaterrfdetails.aspx.cs" Inherits="recruitment_activaterrfdetails" %>

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
                        <h2>RECRUITMENT REQUISITION FORM</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>RECRUITMENT REQUISITION FORM DETAILS
                                </div>
                            </div>

                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>
                                    <tr>
                                        <th class="span3">RRF Code</th>
                                        <td class="span4">
                                            <asp:Label ID="lbl_rrfcode" runat="server"></asp:Label>
                                        </td>
                                        <th class="span3">Requested By</th>
                                        <td class="span4">
                                            <asp:Label ID="lbl_requestedby" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Department</th>
                                        <td>
                                            <asp:Label ID="lbl_dept" runat="server"></asp:Label>
                                        </td>
                                        <th>Designation</th>
                                        <td>
                                            <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Total No of Posts</th>
                                        <td>
                                            <asp:Label ID="lbl_Posts" runat="server"></asp:Label>
                                        </td>
                                        <th>Request Type</th>
                                        <td>
                                            <asp:Label ID="lbl_requestType" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Vacancy Type</th>
                                        <td>
                                            <asp:Label ID="lbl_vacancyType" runat="server"></asp:Label>
                                        </td>
                                        <th>Temporary(in days)</th>
                                        <td>
                                            <asp:Label ID="lbl_temparary" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Expected CTC</th>
                                        <td>
                                            <asp:Label ID="lbl_incentive" runat="server"></asp:Label>
                                        </td>
                                        <th>Working Hours</th>
                                        <td>
                                            <asp:Label ID="lbl_workinghours" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Reasons of Request</th>
                                        <td>
                                            <asp:Label ID="lbl_reasons" runat="server"></asp:Label>
                                        </td>
                                        <th>Cost Center</th>
                                        <td>
                                            <asp:Label ID="lbl_costcenter" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Shift Hours</th>
                                        <td>
                                            <asp:Label ID="lbl_shifthours" runat="server"></asp:Label>
                                        </td>
                                        <th>Location</th>
                                        <td>
                                            <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <th>Department</th>
                                        <td>
                                            <asp:Label ID="Label1" runat="server"></asp:Label>
                                        </td>
                                        <th>Designation</th>
                                        <td>
                                            <asp:Label ID="Label2" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="Tr1" runat="server" visible="false">
                                        <th>Gross Salary</th>
                                        <td>
                                            <asp:Label ID="lbl_grosssalary" runat="server"></asp:Label>
                                        </td>
                                        <th>TCTC</th>
                                        <td>
                                            <asp:Label ID="lbl_tctc" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                   

                                    <tr>
                                        <th>Job Description</th>
                                        <td>
                                            <asp:Label ID="lbl_jobdesc" runat="server"></asp:Label>
                                        </td>

                                        <th>Skills</th>
                                        <td>
                                            <asp:Label ID="lbl_skills" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <th>Educational Qualification</th>
                                        <td>
                                            <asp:Label ID="lbl_edu" runat="server"></asp:Label>
                                        </td>

                                        <th>Experience</th>

                                        <td>
                                            <asp:Label ID="lbl_Exp" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                     <tr>
                                        <th>Additional Qualification</th>
                                        <td>
                                            <asp:Label ID="lblQualifiers" runat="server"></asp:Label>
                                        </td>
                                        <th>Industries Preferred</th>
                                        <td>
                                            <asp:Label ID="lbl_industries" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">Hold Logs</span>
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="dt_example" class="example_alt_pagination">
                                                <asp:GridView ID="grdrrfholddetails" runat="server" AutoGenerateColumns="False" AllowSorting="True"
                                                    EmptyDataText="No data Found" CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Hold Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblholddate" runat="server" Text='<%#Eval("holddate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Comments">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("comments")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Hold By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblholdby" runat="server" Text='<%#Eval("createdby")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Active Date">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactivedate" runat="server" Text='<%#Eval("activedate")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Active By">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblactiveby" runat="server" Text='<%#Eval("updatedby")%>'></asp:Label>
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

                            <div class="form-actions no-margin" style="text-align:right">
                                <asp:Button ID="btnActivate" runat="server" Text="Activate RRF" CssClass="btn btn-info" OnClick="btnActivate_Click" />&nbsp;
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
            $('#grdrrfholddetails').dataTable({
                "sPaginationType": "full_numbers"
            });
        });
    </script>
</body>
</html>
