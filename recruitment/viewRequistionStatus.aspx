<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewRequistionStatus.aspx.cs"
    Inherits="recruitment_viewRequistionStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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

    <style type="text/css">
        .ajax__calendar_container td
        {
            border: none;
            padding: 0px;
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
                        <%--<h2>RECRUITMENT REQUISITON FORM - DETAILS</h2>--%>
                        <h2>Recruitment Details</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>CANDIDATE DETAILS--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="wizard">
                                  <%--  <ol>
                                        <li>Requisition form details</li>
                                        <li>Candidate information</li>
                                        <%--<li>Interview assessment </li>
                                    </ol>--%>
                                    <div>
                                        <p>

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View Status - Requisition Form--%>
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Requisition Form
                                                            </div>
                                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                                        </div>
                                                        <div class="widget-body">
                                                            <table class="table table-condensed table-striped table-bordered no-margin">
                                                                <tbody>
                                                                    <tr>
                                                                        <th>RRF Code</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_rrfcode" runat="server"></asp:Label>
                                                                        </td>
                                                                        <th>Requested By</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_requestedby" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>


                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Requisition Form Details--%>
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Form Details
                                                            </div>
                                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                                        </div>
                                                        <div class="widget-body">
                                                            <table class="table table-condensed table-striped table-bordered no-margin">
                                                                <tbody>
                                                                    <tr>
                                                                        <th class="span3">Total No of Posts</th>
                                                                        <td class="span4">
                                                                            <asp:Label ID="lbl_Posts" runat="server"></asp:Label>
                                                                        </td>
                                                                        <th class="span3">Request Type</th>
                                                                        <td class="span4">
                                                                            <asp:Label ID="lbl_requestType" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <th>Vacancy Type</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_vacancyType" runat="server"></asp:Label>
                                                                        </td>
                                                                        <th>Expected CTC</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_incentive" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr runat="server" visible="false">
                                                                        <th>Temporary(in days)</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_temparary" runat="server"></asp:Label>
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
                                                                        <th>Location</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                                                        </td>

                                                                    </tr>

                                                                    <tr>
                                                                        <th>Shift Hours</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_shifthours" runat="server"></asp:Label>
                                                                        </td>
                                                                        <th>Department Type</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_costcenter" runat="server"></asp:Label>
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
                                                                    <tr runat="server" visible="false">
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
                                                                        <th>Skills</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_skills" runat="server"></asp:Label>
                                                                        </td>

                                                                        <th>Job Description</th>

                                                                        <td>
                                                                            <asp:Label ID="lbl_jobdesc" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>

                                                                    <tr>
                                                                        <th>Experience (In Months)</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_Exp" runat="server"></asp:Label>
                                                                        </td>
                                                                        <th>Educational Qualification</th>

                                                                        <td>
                                                                            <asp:Label ID="lbl_edu" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Industries Prefered</th>
                                                                        <td>
                                                                            <asp:Label ID="lbl_industries" runat="server"></asp:Label>
                                                                        </td>

                                                                        <th>Additional Qualification</th>
                                                                        <td>
                                                                            <asp:Label ID="lblQualifiers" runat="server"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

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
                                                                        <asp:TemplateField HeaderText="Hold Date & Time">
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
                                                                        <asp:TemplateField HeaderText="Active Date & Time">
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

                                            <div id="Div1" class="row-fluid" runat="server">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Previous Comments
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div2" class="example_alt_pagination">
                                                                <asp:GridView ID="Gridcomments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                                    EmptyDataText="No Data Found">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Comments">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblcomments" runat="server" Text='<%#Eval("comments")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbldate" runat="server" Text='<%#Eval("cretaeddate")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("status")%>'></asp:Label>
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

                                            <div class="row-fluid" runat="server">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver Details
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div3" class="example_alt_pagination">
                                                                <asp:GridView ID="grdapprovers" runat="server" AutoGenerateColumns="False"
                                                                    EmptyDataText="No data Found" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Employee Code">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("ApproverCode")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Employee Name">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblempname" runat="server" Text='<%#Eval("ApproverName")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Level">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lbllevels" runat="server" Text='<%#Eval("Approvelevel")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Role">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblrole" runat="server" Text='<%#Eval("ApproverRole")%>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Status" Visible="false">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblrole" runat="server" Text='<%#Eval("ApproverStatus")%>'></asp:Label>
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

                                       <%--<div>
                                                <p>
                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <div class="widget no-margin">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View                                     
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                        <tbody>
                                                                            <tr>
                                                                                <th class="span3">Candidate Name 
                                                                                </th>
                                                                                <td class="span4">
                                                                                    <asp:Label ID="txt_candidateName" runat="server"></asp:Label>
                                                                                </td>
                                                                                <th class="span3">DOB 
                                                                                </th>
                                                                                <td class="span4">
                                                                                    <asp:Label ID="lbldob" runat="server"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>Mobile No. 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_mobile" runat="server"></asp:Label>
                                                                                </td>

                                                                                <th>Gender 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="txt_gender"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>Skills 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="txt_skills"></asp:Label>
                                                                                </td>
                                                                                <th>Email 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_email" runat="server"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>Qualifications 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_Qualifications" runat="server"></asp:Label>
                                                                                </td>
                                                                                <th>Alternate Phone No. 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_phoneno" runat="server"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>Experience (in months) 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_experience" runat="server"></asp:Label>
                                                                                </td>

                                                                                <th>Expected Salary 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="lblexpectedsalary" runat="server"></asp:Label>
                                                                                </td>

                                                                            </tr>
                                                                            <tr>
                                                                                <th>Passport No. 
                                                                      
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="lblpassportno" runat="server"> </asp:Label>
                                                                                </td>
                                                                                <th>Achievements 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="lblachievements" runat="server"></asp:Label>
                                                                                </td>

                                                                            </tr>

                                                                            <tr>
                                                                                <th>Join Status 
                                                                                </th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_joinstatus" runat="server"> </asp:Label>&nbsp;Days
                                                                                </td>

                                                                                <th>Address</th>
                                                                                <td>
                                                                                    <asp:Label ID="lbladdress" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Notes</th>
                                                                                <td>
                                                                                    <asp:Label ID="lblnotes" runat="server"></asp:Label>
                                                                                </td>

                                                                                <th>Resume</th>
                                                                                <td>
                                                                                    <asp:LinkButton ID="lbtnview" runat="server" OnClick="lbtnview_Click" CssClass="link05">Download</asp:LinkButton>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Applied Date</th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_applied_date" runat="server"></asp:Label>
                                                                                </td>

                                                                                <th>Referred By</th>
                                                                                <td>
                                                                                    <asp:Label ID="lbl_refered_by" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <th>Designation</th>
                                                                                <td>
                                                                                    <asp:Label ID="txt_designation" runat="server"></asp:Label>
                                                                                </td>

                                                                                <th>Passport Validity</th>
                                                                                <td>
                                                                                    <asp:Label ID="lbl_passport_validity" runat="server"></asp:Label>
                                                                                </td>
                                                                            </tr>

                                                                        </tbody>
                                                                    </table>
                                                                </div>
                                                                <div class="clearfix"></div>

                                                            </div>

                                                        </div>
                                                    </div>
                                                </p>
                                            </div>--%>
                                        </p>
                                        <div class="form-actions no-margin">
                                            <a href="javascript:history.go(-1)" class="btn btn-info" style="margin-left: 800px" title="Back to previous page">Back</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


            </div>
        </div>
    </form>

    <%--<script src="../js/analytics.js"></script>
    <script src="../js/jquery.min.js"></script>
    <script src="../js/bootstrap.js"></script>
    <script src="../js/moment.js"></script>

    <script src="../js/jquery.dataTables.js"></script>

    <!-- Easy Pie Chart JS -->
    <script src="../js/pie-charts/jquery.easy-pie-chart.js"></script>

    <!-- Tiny scrollbar js -->
    <script src="../js/tiny-scrollbar.js"></script>

    <!-- Custom Js -->
    <script src="../js/wizard/bwizard.js"></script>

    <!-- Custom Js -->
    <script src="../js/theming.js"></script>
    <script src="../js/custom.js"></script>

    <script type="text/javascript">
        $("#wizard").bwizard();
    </script>
    <script type="text/javascript">
        //Data Tables
        $(document).ready(function () {
            $('#grdreschedule').dataTable({
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

    </script>--%>

</body>
</html>
