<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultancyRequisitionform.aspx.cs" Inherits="recruitment_ConsultancyRequisitionform" %>

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

</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="page-header">
                    <div class="pull-left">
                        <%--<h2>RECRUITMENT REQUISITION FORM - DETAILS</h2>--%>
                        <h2>Recruitment Requisition Form</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View Status - Requisition Form--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View
                                </div>
                                <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <div class="widget-body">
                                <table class="table table-condensed table-striped table-bordered no-margin">
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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View
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
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Requisition Form Approval Details--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View
                                </div>
                                <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <div class="widget-body">
                                <table class="table table-condensed table-striped table-bordered no-margin">
                                    <thead>
                                        <tr>
                                            <th>Role
                                            </th>
                                            <th>Name
                                            </th>
                                            <th>Status
                                            </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td>Business Head
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_approverName" runat="server"></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Managing Director
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_orgheadname" runat="server"></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lbl_orgstatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td>HR Director
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_hrdname" runat="server"></asp:Label>
                                            </td>

                                            <td>
                                                <asp:Label ID="lbl_hrdstatus" runat="server"></asp:Label>
                                            </td>
                                        </tr>

                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <div class="form-actions no-margin" style="text-align:right">
                            <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="btn btn-info" OnClick="btn_back_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

