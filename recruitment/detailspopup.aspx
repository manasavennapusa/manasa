<%@ Page Language="C#" AutoEventWireup="true" CodeFile="detailspopup.aspx.cs" Inherits="recruitment_detailspopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="tab-content">
            <div class="tab-pane active" id="date">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14c;"></span>Requisition Form Details
                                </div>
                                <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>

                                    <tr>
                                        <td>RRF Code</td>
                                        <td>
                                            <asp:Label ID="lbl_rrfcode" runat="server"></asp:Label>
                                        </td>
                                        <td>Requested By</td>
                                        <td>
                                            <asp:Label ID="lbl_requestedby" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Department</td>
                                        <td>
                                            <asp:Label ID="lbl_dept" runat="server"></asp:Label>
                                        </td>
                                        <td>Designation</td>
                                        <td>
                                            <asp:Label ID="lbl_designation" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
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
                                <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                            </div>
                            <table class="table table-condensed table-striped  table-bordered pull-left">
                                <tbody>
                                    <tr>
                                        <td>Total No of Posts</td>
                                        <td>
                                            <asp:Label ID="lbl_Posts" runat="server"></asp:Label>
                                        </td>
                                        <td>Request Type</td>
                                        <td>
                                            <asp:Label ID="lbl_requestType" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Vacancy Type</td>
                                        <td>
                                            <asp:Label ID="lbl_vacancyType" runat="server"></asp:Label>
                                        </td>
                                        <td>Temporary(in days)</td>
                                        <td>
                                            <asp:Label ID="lbl_temparary" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Incentive</td>
                                        <td>
                                            <asp:Label ID="lbl_incentive" runat="server"></asp:Label>
                                        </td>
                                        <td>Working Hours</td>
                                        <td>
                                            <asp:Label ID="lbl_workinghours" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Reasons of Request</td>
                                        <td>
                                            <asp:Label ID="lbl_reasons" runat="server"></asp:Label>
                                        </td>

                                        <td>Cost Center</td>
                                        <td>
                                            <asp:Label ID="lbl_costcenter" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Budget</td>
                                        <td>
                                            <asp:Label ID="lbl_budget" runat="server"></asp:Label>
                                        </td>
                                        <td>Location</td>
                                        <td>
                                            <asp:Label ID="lbl_location" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Gross Salary</td>
                                        <td>
                                            <asp:Label ID="lbl_grosssalary" runat="server"></asp:Label>
                                        </td>
                                        <td>TCTC</td>
                                        <td>
                                            <asp:Label ID="lbl_tctc" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>Shift Hours</td>
                                        <td>
                                            <asp:Label ID="lbl_shifthours" runat="server"></asp:Label>
                                        </td>

                                        <td>ADDITIONAL QUALIFIERS</td>
                                        <td>
                                            <asp:Label ID="lblQualifiers" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>INDUSTRIES PREFERRED</td>
                                        <td>
                                            <asp:Label ID="lbl_industries" runat="server"></asp:Label>
                                        </td>

                                        <td>JOB DESCRIPTION</td>

                                        <td>
                                            <asp:Label ID="lbl_jobdesc" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>SKILLS</td>
                                        <td>
                                            <asp:Label ID="lbl_skills" runat="server"></asp:Label>
                                        </td>

                                        <td>EDUCATIONAL QUALIFICATION</td>

                                        <td>
                                            <asp:Label ID="lbl_edu" runat="server"></asp:Label>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>EXPERIENCE</td>
                                        <td>
                                            <asp:Label ID="lbl_Exp" runat="server"></asp:Label>
                                        </td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </tbody>
                            </table>
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
                            <table class="table table-bordered table-condensed table-striped no-margin">

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
                                    <tr>
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
                        <%-- <div class="form-actions no-margin" style="text-align: right">
                                                        <asp:Button ID="btn_back" runat="server" Text="Back" CssClass="btn btn-info" OnClick="btn_back_Click" />
                                                    </div>--%>
                    </div>
                </div>
            </div>

            <div class="tab-pane" id="relevance">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details                                     
                                </div>
                            </div>

                            <div class="widget-body">

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Candidate Name :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="txt_candidateName" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Phone No. :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="txt_phoneno" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Email :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="txt_email" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Mobile No. :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="txt_mobile" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Expected Salary :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="lblexpectedsalary" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Achievements :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="lblachievements" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label" for="email1">
                                            Experience (in months) :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="txt_experience" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Skills :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label runat="server" ID="txt_skills"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Qualifications :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="txt_Qualifications" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Join Status :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="txt_joinstatus" runat="server"> </asp:Label>&nbsp;Days
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Passport No. :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="lblpassportno" runat="server"> </asp:Label>
                                        </div>
                                    </div>

                                </div>

                            </div>

                            <div class="clearfix"></div>
                            <%-- <div class="form-actions no-margin" style="text-align: right">
                                                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Back" ValidationGroup="c"
                                                                OnClick="btn_back_Click" />
                                                        </div>--%>
                        </div>

                    </div>
                </div>
            </div>
            <div class="tab-pane" id="dealership">

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Candidate Details                                     
                                </div>
                            </div>

                            <div class="widget-body">

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Candidate Name :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="lblCandidatename" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Phone No. :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="lblphoneno" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Email :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="lblemail" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Mobile No. :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label ID="lblmobile" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                </div>

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label" for="email1">
                                            Experience (in months) :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="lblexp" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="DateofBirthMonth">
                                            Skills :
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label runat="server" ID="lblskills"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Qualifications :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="lblqualification" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Join Status :
                                        </label>
                                        <div class="controls">
                                            <asp:Label ID="lbljoinstatus" runat="server"> </asp:Label>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                    </div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget no-margin">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Interview History Details                                
                                </div>
                            </div>

                            <div class="widget-body">

                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Round 1 Marks:
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label runat="server" ID="txtround1marks"></asp:Label>

                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label" for="repPassword">
                                            Round 1 Status:
                                        </label>
                                        <div class="controls">
                                            <asp:Label runat="server" ID="txtround1status"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="span6">
                                    <div class="control-group">
                                        <label class="control-label">
                                            Round 2 Status:
                                        </label>
                                        <div class="controls controls-row">
                                            <asp:Label runat="server" ID="txtround2status"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="control-group">
                                        <label class="control-label">
                                            Interview Analysis:
                                        </label>
                                        <div class="controls">
                                            <asp:Label runat="server" ID="txtianalysis"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
