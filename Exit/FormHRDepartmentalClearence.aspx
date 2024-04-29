<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormHRDepartmentalClearence.aspx.cs" Inherits="Exit_FormHRDepartmentalClearence" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

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
<html lang="en">
<!--
  <![endif]-->
<head id="Head1" runat="server">
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

    <script type="text/javascript">
        function NoticePeriod() {

            if (document.getElementById("NoticePeriodServedNA").checked == true) {
                document.getElementById("NoticePeriodRecovery").style.display = "block";
            }
            else
                document.getElementById("NoticePeriodRecovery").style.display = "none";
        }
    </script>
    <script type="text/javascript">
        function IsNumericDot(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]|\./;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
    <script type="text/javascript">
        function IsNumeric(evt) {
            var theEvent = evt || window.event;
            var key = theEvent.keyCode || theEvent.which;
            key = String.fromCharCode(key);
            var regex = /[0-9]/;
            if (!regex.test(key)) {
                theEvent.returnValue = false;
                if (theEvent.preventDefault) theEvent.preventDefault();
            }
        }
    </script>
    <script type="text/javascript">
        function isKey(keyCode) {
            return false;
        }
    </script>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>HR Department Clearance</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>
                <div class="row-fluid">
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name:</label>
                                        <div class="controls">
                                            <asp:Label ID="EmpName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Code:</label>
                                        <div class="controls">
                                            <asp:Label ID="EmpCode" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Department:</label>
                                        <div class="controls">
                                            <asp:Label ID="Department" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date of Joining:</label>
                                        <div class="controls">
                                            <asp:Label ID="DOJ" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date of Resignation:</label>
                                        <div class="controls">
                                            <asp:Label ID="DOR" runat="server"></asp:Label>
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="span6">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>

                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">Last Working Day:</label>
                                        <div class="controls">
                                            <asp:Label ID="LWD" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Permanent Address:</label>
                                        <div class="controls">
                                            <asp:Label ID="PA" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal Mobile Number:</label>
                                        <div class="controls">
                                            <asp:Label ID="PMN" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Personal Email Id:</label>
                                        <div class="controls">
                                            <asp:Label ID="PEI" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    HR Department Clearance Form
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group" style="display: none;">
                                        <label class="control-label">Received Resignation Letter From Employee</label>
                                        <div class="controls">
                                            <input type="radio" name="ReceivedResignationLetterFromEmployee" id="ReceivedResignationLetterFromEmployeeYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp; 
                                            <input type="radio" name="ReceivedResignationLetterFromEmployee" id="ReceivedResignationLetterFromEmployeeNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReceivedResignationLetterFromEmployee" id="ReceivedResignationLetterFromEmployeeNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Resignation Approval From Manager</label>
                                        <div class="controls">
                                            <input type="radio" name="ResignationApprovalFromManager" id="ResignationApprovalFromManagerYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ResignationApprovalFromManager" id="ResignationApprovalFromManagerNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ResignationApprovalFromManager" id="ResignationApprovalFromManagerNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Notice Period Served</label>
                                        <div class="controls">
                                            <input type="radio" name="NoticePeriodServed" id="NoticePeriodServedYes" runat="server" onclick="NoticePeriod();" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodServed" id="NoticePeriodServedNo" runat="server" onclick="NoticePeriod();" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodServed" id="NoticePeriodServedNA" runat="server" checked="true" onclick="NoticePeriod();" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group" id="NoticePeriodRecovery">
                                        <label class="control-label">Notice Period Recovery</label>
                                        <div class="controls">
                                            <input type="radio" name="NoticePeriodRecovery" id="NoticePeriodRecoveryYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodRecovery" id="NoticePeriodRecoveryNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodRecovery" id="NoticePeriodRecoveryNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="text" runat="server" id="NoticePeriodRecoveryDays" placeholder="Days" onkeypress="return IsNumeric(event);" ondrop="return false;" onpaste="return false;"/>&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="text" runat="server" id="NoticePeriodRecoveryAmount" placeholder="Amount" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"/>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Eligible For Re-Hire</label>
                                        <div class="controls">
                                            <input type="radio" name="EligibleForReHire" id="EligibleForReHireYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="EligibleForReHire" id="EligibleForReHireNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="EligibleForReHire" id="EligibleForReHireNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Reason for not eligible for Re-Hire</label>
                                        <div class="controls">
                                            <asp:TextBox ID="ReasonForNotEligibleForReHire" runat="server" CssClass="span4" TextMode="MultiLine" Rows="5"></asp:TextBox>

                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Investment Proofs Submitted</label>
                                        <div class="controls">
                                            <input type="radio" name="InvestmentProofsSubmitted" id="InvestmentProofsSubmittedYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="InvestmentProofsSubmitted" id="InvestmentProofsSubmittedNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="InvestmentProofsSubmitted" id="InvestmentProofsSubmittedNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Reimbursement Proofs Submitted</label>
                                        <div class="controls">
                                            <input type="radio" name="ReimbursementProofsSubmitted" id="ReimbursementProofsSubmittedYes" runat="server" />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReimbursementProofsSubmitted" id="ReimbursementProofsSubmittedNo" runat="server" />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReimbursementProofsSubmitted" id="ReimbursementProofsSubmittedNA" runat="server" checked="true" />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Annual Leave Balance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="AnnualLeaveBalance" runat="server" CssClass="span4" Enabled="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="txtrequired" runat="server" ControlToValidate="AnnualLeaveBalance" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">LOP Days</label>
                                        <div class="controls">
                                            <asp:TextBox ID="LOPDays" runat="server" CssClass="span4" onkeypress="return IsNumericDot(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LOPDays" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Reason of Leaving</label>
                                        <div class="controls">
                                            <asp:TextBox ID="ReasonofLeaving" runat="server" CssClass="span4" TextMode="MultiLine" Rows="5" Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ReasonofLeaving" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Other Comments / Important Notes</label>
                                        <div class="controls">
                                            <asp:TextBox ID="OtherComments" runat="server" CssClass="span4" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="OtherComments" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="control-group" style="display:none;">
                                        <label class="control-label">Date Of Clearance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="DateOfClearence" runat="server" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11" TargetControlID="DateOfClearence" Enabled="True" Format="dd-MMM-yyyy">
                                            </cc1:CalendarExtender>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="DateOfClearence" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin" style="text-align: right">
                                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="btnsave_Click" Visible="false" />
                                        <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary" Text="Approve" OnClick="btnApprove_Click" ValidationGroup="g" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Reject" OnClick="btnCancel_Click" ValidationGroup="g" />
                                    </div>
                                </fieldset>
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

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grdstaytype').dataTable({
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




