<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Candidatedetails.aspx.cs" Inherits="recruitment_Candidatedetails" %>

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
    <link href="../icomoon/style.css" rel="stylesheet" />

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
                        <h2>Candidate Details</h2>
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
                                    <ol>
                                        <li>Requisition form details</li>
                                        <li>Candidate information</li>
                                        <li>Interview Schedule And Assessment </li>
                                    </ol>

                                    <div>
                                        <p>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>View Status - Requisition Form
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
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

                                                                    
                                                                </tbody>
                                                            </table>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Requisition Form Details
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <table class="table table-condensed table-striped  table-bordered pull-left">
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
                                                                        <th>Experience (In Years)</th>
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
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row-fluid" runat="server" visible="false">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Previous Comments
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div3" class="example_alt_pagination">
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

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;">Hold Logs</span>
                                                            </div>
                                                        </div>
                                                        <div class="widget-body">
                                                            <div id="Div2" class="example_alt_pagination">
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

                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header" style="border-bottom: none;">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Requisition Form Approval Details
                                                            </div>
                                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                                        </div>
                                                        <div class="widget-body">
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
                                                            <div class="clearfix"></div>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>

                                        </p>
                                    </div>

                                    <div>
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
                                    </div>

                                    <div>
                                        <p>
                                            <div class="row-fluid">
                                                <div class="span12">
                                                    <div class="widget">
                                                        <div class="widget-header">
                                                            <div class="title">
                                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details                                     
                                                            </div>
                                                        </div>

                                                        <div class="widget-body">
                                                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                                                <tbody>
                                                                    <tr>
                                                                        <th>Candidate Name </th>
                                                                        <td>
                                                                            <asp:Label ID="lblCandidatename" runat="server"></asp:Label></td>
                                                                        <th>Mobile No.</th>
                                                                        <td>
                                                                            <asp:Label ID="lblmobile" runat="server"></asp:Label></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <th>Phone No.</th>
                                                                        <td>
                                                                            <asp:Label ID="lblphoneno" runat="server"></asp:Label></td>
                                                                        <th>Email</th>
                                                                        <td>
                                                                            <asp:Label ID="lblemail" runat="server"></asp:Label></td>
                                                                    </tr>

                                                                </tbody>
                                                            </table>

                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:UpdatePanel ID="rrr" runat="server" UpdateMode="Always">
                                                <ContentTemplate>
                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <div class="widget">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Interview History Details                                
                                                                    </div>
                                                                </div>

                                                                <div class="widget-body">

                                                                    <table class="table table-bordered table-condensed table-striped no-margin">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>Rounds
                                                                                </th>
                                                                                <th>Functional Name
                                                                                </th>
                                                                                <th>Maximum Marks
                                                                                </th>
                                                                                <th>Cutoff Marks
                                                                                </th>
                                                                                <th>Marks Scored
                                                                                </th>
                                                                                <th>Status
                                                                                </th>
                                                                                <th>
    Interview Analysis
</th> 
                                                                                <th>Date
                                                                                </th>
                                                                                <th>Time
                                                                                </th>
                                                                                <th>Reschedule
                                                                                </th>
                                                                            </tr>

                                                                        </thead>
                                                                        <tbody>
                                                                            <tr id="txtrnd_1_slct" runat="server" visible="true">
                                                                                <td>Round One
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblpapername1" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblmaxmarks"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblcutoffmarks" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="txtround1marks"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="txtround1status"></asp:Label>
                                                                                </td>
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblr1date"></asp:Label>
                                                                                    <div id="editdate" runat="server" visible="false">
                                                                                        <asp:TextBox ID="txtDate" runat="server" CssClass="span7"></asp:TextBox>
                                                                                        <asp:Image ID="Image12" runat="server" ImageUrl="images/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="Image12" TargetControlID="txtDate" Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate"
                                                                                            Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Time fro Interview"
                                                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblr1time"></asp:Label>
                                                                                    <div id="edittime" runat="server" visible="false">
                                                                                        <asp:TextBox ID="tbttime" runat="server" CssClass="span7" onkeypress="return entertime(event);"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="tbttime"
                                                                                            Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Time fro Interview"
                                                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnreschedule" runat="server" Text="Reschedule" OnClick="btnreschedule_Click" CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" />

                                                                                    <div id="divUpdate" runat="server" visible="false">
                                                                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" />&nbsp;&nbsp;&nbsp;
                                                                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>

                                                                            <tr id="txtrnd_2_slct" runat="server" visible="true">
                                                                                <td>Round Two
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblpapername2" runat="server"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblmaxmarks1"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label ID="lblcutoffmarks1" runat="server"></asp:Label>
                                                                                </td>
                                                                                
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblround2marks"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="txtround2status"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <a href='viewInterviewResult2.aspx?id=<%= txt_id.Text %>&no=2' class="link05"><img src="../images/Evaluate.png" width="30" height="30"></a>
                                                                                </td>
                                                                                <td id="Td1" runat="server" visible="false">
                                                                                    <asp:Label runat="server" ID="txt_id"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblr2date"></asp:Label>
                                                                                    <div id="editdate2" runat="server" visible="false">
                                                                                        <asp:TextBox ID="txtdate2" runat="server" CssClass="span9"></asp:TextBox>
                                                                                        <asp:Image ID="Image1" runat="server" ImageUrl="images/clndr.gif" />
                                                                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtdate2" Enabled="True">
                                                                                        </cc1:CalendarExtender>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtdate2"
                                                                                            Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Time fro Interview"
                                                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblr2time"></asp:Label>
                                                                                    <div id="edittime2" runat="server" visible="false">
                                                                                        <asp:TextBox ID="txttime2" runat="server" CssClass="span6" onkeypress="return entertime(event);"></asp:TextBox>
                                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txttime2"
                                                                                            Display="Dynamic" ErrorMessage='<img src="images/error1.gif" alt="" />' ToolTip="Enter Time fro Interview"
                                                                                            ValidationGroup="v" Width="6px" SetFocusOnError="True"><img src="images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                    </div>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Button ID="btnreschedule2" runat="server" Text="Reschedule" OnClick="btnreschedule2_Click" Visible="false" CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" />

                                                                                    <div id="divupdate2" runat="server" visible="false">
                                                                                        <asp:Button ID="btnupdate2" runat="server" Text="Update" OnClick="btnUpdate2_Click" CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" />
                                                                                        <asp:Button ID="btncancel2" runat="server" Text="Cancel" OnClick="btnCancel2_Click" CssClass="btn btn-small btn-primary hidden-tablet hidden-phone" />
                                                                                    </div>
                                                                                </td>
                                                                            </tr>

                                                                            <tr id="txtinterview_analysis" runat="server" visible="true">
                                                                                <td>Round Three
                                                                                </td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                <td></td>
                                                                                
                                                                                <td></td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="txtianalysis"></asp:Label>&nbsp;&nbsp;
                                                                                     <asp:Button ID="btnview" runat="server" Text="view" CssClass="btn btn-info" OnClick="btnview_Click" Visible="false"/>
                                                                                </td>
                                                                                <td>
                                                                                    <a href='CandidateInterviewHistory2.aspx?id=<%= txt_id.Text %>&no=2' class="link05"><img src="../images/Evaluate.png" width="30" height="30"></a>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblr3date"></asp:Label>
                                                                                </td>
                                                                                <td>
                                                                                    <asp:Label runat="server" ID="lblr3time"></asp:Label>
                                                                                </td>
                                                                                <td></td>
                                                                            </tr>

                                                                        </tbody>
                                                                    </table>

                                                                    <div class="clearfix"></div>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <div class="widget">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Interview Reschedule Log
                                     
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="dt_example" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdreschedule" runat="server" AutoGenerateColumns="False" OnPreRender="grdreschedule_PreRender"
                                                                            CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                                            EmptyDataText="No Data Found">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Round">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRound" runat="server" Text='<%# Eval("rounddetails")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Date">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbldate" runat="server" Text='<%# Eval("rounddate", "{0:dd MMM yyyy}")%>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Time">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lbltime" runat="server" Text='<%# Eval("roundtime")%>'></asp:Label>
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

                                                    <div class="row-fluid">
                                                        <div class="span12">
                                                            <div class="widget">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Assigned Panels                                
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body">
                                                                    <div id="Div1" class="example_alt_pagination">
                                                                        <asp:GridView ID="grdassigned" runat="server" AutoGenerateColumns="False" CaptionAlign="Left" AllowSorting="True"
                                                                            EmptyDataText="No Data Found" CssClass="table table-condensed table-striped  table-bordered pull-left">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="RRF Code">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblrrfcode" runat="server" Text='<%# Eval("rrf_code") %>'>></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                 <asp:TemplateField HeaderText="Designation">
                                                                                  <ItemTemplate>
                                                                                  <asp:Label ID="lbldesgnt" runat="server" Text='<%# Eval("designationname") %>'>></asp:Label>
                                                                                 </ItemTemplate>
                                                                               </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Panle Code">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblpcode" runat="server" Text='<%# Eval("panelcode") %>'>></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Panel Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblname" runat="server" Text='<%# Eval("Panelname") %>'>></asp:Label>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Subject Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblsubname" runat="server" Text='<%# Eval("subjectname") %>'>></asp:Label>
                                                                                    </ItemTemplate>

                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Resource Code  -  Name">
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblresname" runat="server" Text='<%# Eval("resourcenames") %>'></asp:Label>&nbsp;&nbsp;-&nbsp;&nbsp;
                                                                                        <asp:Label ID="lblempf" runat="server" Text='<%# Eval("emp_fname") %>'></asp:Label>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:HyperLinkField HeaderText="Edit" DataNavigateUrlFields="id" DataNavigateUrlFormatString="~/recruitment/createjobsite_consultancy.aspx?Id={0}"
                                                                                    Text="Edit" Visible="false"></asp:HyperLinkField>

                                                                            </Columns>
                                                                        </asp:GridView>
                                                                        <div class="clearfix"></div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>

                                                    <div class="row-fluid" id="interviewanalysis" runat="server" visible="false">
                                                        <div class="span12">
                                                            <div class="widget">
                                                                <div class="widget-header">
                                                                    <div class="title">
                                                                        <span class="fs1" aria-hidden="true" data-icon=""></span>Interview Rating
                                                                    </div>
                                                                </div>
                                                                <div class="widget-body" id="radiobuttons">
                                                                    <table class="table table-condensed table-bordered no-margin">
                                                                        <thead>
                                                                            <tr>
                                                                                <th style="width: 3%">Functional</th>
                                                                                <th style="width: 5%">UnSatisfactory</th>
                                                                                <th style="width: 5%">Satisfactory</th>
                                                                                <th style="width: 3%">Good</th>
                                                                                 <th style="width: 5%">Excellent</th>
                                                                                <th style="width: 5%">Exceptional</th>
                                                                                <th style="width: 5%">Not Applicable </th>
                                                                                <th>Particulars</th>
                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>General/ Basic Knowledge</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="optionsRadios2" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio1" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio2" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio3" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio4" value="2" /></td>
                                                                                <td>
                                                                                    
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Personality" id="Radio47" value="1" /></td>
                                                                                  
                                                                                <td>
                                                                                    <p>
                                                                                        Basic knowledge of work related to the field as applicable (Accounting/ Payroll/Benefit/ US HR/ HR/PHP/Finance/ Taxation)
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Concepts and Standards</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio5" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio6" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio7" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio8" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio9" value="2" /></td>
                                                                              
                                                                                     <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Academic" id="Radio48" value="1" /></td>
                                                                                  
                                                                                <td>
                                                                                    <p>
                                                                                        Understanding of concepts and standards as applicable
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Advance Knowledge</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio10" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio11" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio12" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio13" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio14" value="2" /></td>
                                                                               
                                                                                     <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Goal" id="Radio49" value="1" /></td>
                                                                                <td>
                                                                                    <p>
                                                                                        Advance level of knowledge in respective field
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Software knowledge</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio15" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio16" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio17" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio18" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio19" value="2" /></td>
                                                                                <td>
                                                                                      
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Communication" id="Radio50" value="1" /></td>
                                                                                <td>
                                                                                    <p>
                                                                                        Software knowledge in respective field
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Decision Making/ Trouble Shooting</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio20" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio21" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio22" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio23" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio24" value="2" /></td>
                                                                              
                                                                                     <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Knowledge" id="Radio51" value="1" /></td>
                                                                                <td>
                                                                                    <p>
                                                                                        Demonstrate decision making and trouble shooting skills in respective field
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>Review/Analytical skills</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio25" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio26" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio27" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio28" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio29" value="2" /></td>
                                                                                
                                                                                         <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Learning" id="Radio52" value="1" /></td>
                                                                                <td>
                                                                                    <p>
                                                                                        Demonstrate review and analytical skills in respective field
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" visible="false">
                                                                                <td>Customer Orientation</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio30" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio31" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio32" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio33" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio34" value="2" /></td>
                                                                                
                                                                                      <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Customer" id="Radio53" value="1" /></td>
                                                                                <td>
                                                                                    <h6>Customer Orientation:
                                                                                    </h6>
                                                                                    <p>
                                                                                        Alert to customer needs, develop & maintain relationships.
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr runat="server" visible="false">
                                                                                <td>Culter Fit</td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio35" value="6" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio36" value="5" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio37" value="4" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio38" value="3" /></td>
                                                                                <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio39" value="2" /></td>
                                                                               
                                                                                    <td>
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Culter" id="Radio54" value="1" /></td>
                                                                                <td>
                                                                                    <h6>Culter Fit:
                                                                                    </h6>
                                                                                    <p>
                                                                                        Ability to fit himself/herself to the Escalon Business Services Pvt Ltd
                                                                                    </p>
                                                                                </td>
                                                                            </tr>
                                                                            <tr id="Tr3" style="background-color:#f2f2f2" runat="server">
                                            <td id="Td8" style="background-color:#f2f2f2" runat="server"><b>HR</b></td>
                                            <td id="Td9" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td10" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td11" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td12" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td13" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td14" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                            <td id="Td15" style="border-right:none; border-left:none; background-color:#f2f2f2" runat="server"></td>
                                        </tr>
                                        <tr>
                                            <td>Behavior</td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio57" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio58" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio59" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio60" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio61" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Behavior" disabled="disabled" id="Radio62" value="1" onclick="avg();" /></td>
                                            <td id="Td16" runat="server" style="border-bottom:none">
                                              
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Stability</td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio63" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio64" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio65" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio66" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio67" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Stability" disabled="disabled" id="Radio68" value="1" onclick="avg();" /></td>
                                            <td id="Td17" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Relevant Experience</td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio69" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio70" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio71" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio72" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio73" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Experience" disabled="disabled" id="Radio74" value="1" onclick="avg();" /></td>
                                            <td id="Td18" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Interest in Profile</td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio75" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio76" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio77" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio78" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio79" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Interest" disabled="disabled" id="Radio80" value="1" onclick="avg();" /></td>
                                            <td id="Td19" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Communication Skills</td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio81" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio82" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio83" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio84" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio85" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Skills" disabled="disabled" id="Radio86" value="1" onclick="avg();" /></td>
                                            <td id="Td20" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Need</td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio87" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio88" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio89" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio90" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio91" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Need" disabled="disabled" id="Radio92" value="1" onclick="avg();" /></td>
                                            <td id="Td21" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Self Development</td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio93" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio94" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio95" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio96" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio97" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Development" disabled="disabled" id="Radio98" value="1" onclick="avg();" /></td>
                                            <td id="Td22" runat="server" style="border-bottom:none; border-top:none">
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Team Co-ordination/ Management</td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio99" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio100" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio101" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio102" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio103" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Management" disabled="disabled" id="Radio104" value="1" onclick="avg();" /></td>
                                            <td id="Td23" runat="server" style="border-bottom:none; border-top:none">
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Package Budget</td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio105" value="6" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio106" value="5" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio107" value="4" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio108" value="3" onclick="avg();" /></td>
                                            <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio109" value="2" onclick="avg();" /></td>
                                               <td>
                                                <input type="radio" runat="server" name="Budget" disabled="disabled" id="Radio110" value="1" onclick="avg();" /></td>
                                            <td id="Td24" runat="server" style="border-top:none">
                                                
                                            </td>
                                        </tr>
                                                                        </tbody>

                                                                    </table>
                                                                    <table class="table table-condensed table-bordered no-margin">
                                                                        <tr runat="server" visible="false">
                                                                            <td>Overall Assessment</td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio40" value="6" />Exceptional
                                                                                </label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio41" value="5" />Excellent 
                                                                                </label>
                                                                            </td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio42" value="4" />Good</label></td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio43" value="3" />Average</label></td>
                                                                           
                                                                              <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio55" value="2" />Satisfactory</label></td>

                                                                              <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" runat="server" disabled="disabled" name="Overall" id="Radio56" value="1" />Unsatisfactory</label></td>

                                                                        </tr>
                                                                        <tr runat="server" visible="false">
                                                                            <td>Panel's Recomendation</td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" name="Recomendation" runat="server" disabled="disabled" id="Radio44" value="3" />
                                                                                    Selected</label></td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" name="Recomendation" runat="server" disabled="disabled" id="Radio45" value="2" />Not Selected</label></td>
                                                                            <td>
                                                                                <label class="radio inline">
                                                                                    <input type="radio" name="Recomendation" runat="server" disabled="disabled" id="Radio46" value="1" />Put On Hold</label></td>
                                                                            <td>  <label class="radio inline"></label></td>
                                                                            <td><label class="radio inline"></label></td>
                                                                            <td><label class="radio inline"></label></td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td>Remarks:</td>
                                                                            <td colspan="6">
                                                                                <asp:TextBox ID="txtRemarks" runat="server" disabled="disabled" TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                        </tr>
                                                                    </table>

                                                                    <div class="form-actions no-margin" style="text-align:right">
                                                                        <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn btn-info" OnClick="btnClose_Click" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
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

    <script src="../js/analytics.js"></script>
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

    </script>
</body>
</html>

