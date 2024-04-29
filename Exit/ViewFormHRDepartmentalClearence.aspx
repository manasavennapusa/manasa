<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewFormHRDepartmentalClearence.aspx.cs" Inherits="Exit_ViewFormHRDepartmentalClearence" %>

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
<head id="Head1"  runat="server" >
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


</head>
<body>

    <form id="myForm"  runat="server" class="form-horizontal no-margin">
        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>HR Department Clearance</h2>
                    </div>
                   
                    <div class="clearfix"></div>
                </div>
                
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                    View
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group" style="display:none;">
                                        <label class="control-label">Received Resignation Letter From Employee</label>
                                        <div class="controls">
                                            <input type="radio" name="ReceivedResignationLetterFromEmployee" id="ReceivedResignationLetterFromEmployeeYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp; 
                                            <input type="radio" name="ReceivedResignationLetterFromEmployee" id="ReceivedResignationLetterFromEmployeeNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReceivedResignationLetterFromEmployee" id="ReceivedResignationLetterFromEmployeeNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                            
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Resignation Approval From Manager</label>
                                        <div class="controls">
                                            <input type="radio" name="ResignationApprovalFromManager" id="ResignationApprovalFromManagerYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ResignationApprovalFromManager" id="ResignationApprovalFromManagerNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ResignationApprovalFromManager" id="ResignationApprovalFromManagerNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Notice Period Served</label>
                                        <div class="controls">
                                            <input type="radio" name="NoticePeriodServed" id="NoticePeriodServedYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodServed" id="NoticePeriodServedNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodServed" id="NoticePeriodServedNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Notice Period Recovery</label>
                                        <div class="controls">
                                            <input type="radio" name="NoticePeriodRecovery" id="NoticePeriodRecoveryYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodRecovery" id="NoticePeriodRecoveryNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="NoticePeriodRecovery" id="NoticePeriodRecoveryNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Eligible For Re-Hire</label>
                                        <div class="controls">
                                            <input type="radio" name="EligibleForReHire" id="EligibleForReHireYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="EligibleForReHire" id="EligibleForReHireNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="EligibleForReHire" id="EligibleForReHireNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="text" runat="server" id="NoticePeriodRecoveryDays" placeholder="Days" disabled="disabled" />&nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="text" runat="server" id="NoticePeriodRecoveryAmount" placeholder="Amount" disabled="disabled" />
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Reason for not eligible for Re-Hire</label>
                                        <div class="controls">
                                            <asp:TextBox ID="ReasonForNotEligibleForReHire" runat="server" CssClass="span4" TextMode="MultiLine" Rows="5" Enabled="false"></asp:TextBox>
                                            
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Investment Proofs Submitted</label>
                                        <div class="controls">
                                            <input type="radio" name="InvestmentProofsSubmitted" id="InvestmentProofsSubmittedYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="InvestmentProofsSubmitted" id="InvestmentProofsSubmittedNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="InvestmentProofsSubmitted" id="InvestmentProofsSubmittedNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Reimbursement Proofs Submitted</label>
                                        <div class="controls">
                                            <input type="radio" name="ReimbursementProofsSubmitted" id="ReimbursementProofsSubmittedYes"  runat="server" disabled="disabled"  />
                                            YES &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReimbursementProofsSubmitted" id="ReimbursementProofsSubmittedNo"  runat="server" disabled="disabled"  />
                                            NO &nbsp;&nbsp;&nbsp;&nbsp;
                                            <input type="radio" name="ReimbursementProofsSubmitted" id="ReimbursementProofsSubmittedNA"  runat="server" disabled="disabled"   />
                                            NA &nbsp;&nbsp;&nbsp;&nbsp;
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Annual Leave Balance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="AnnualLeaveBalance"  runat="server" disabled="disabled"  CssClass="span4"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">LOP Days</label>
                                        <div class="controls">
                                            <asp:TextBox ID="LOPDays"  runat="server" disabled="disabled"  CssClass="span4"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Reason of Leaving</label>
                                        <div class="controls">
                                            <asp:TextBox ID="ReasonofLeaving"  runat="server" disabled="disabled"  CssClass="span4" TextMode="MultiLine" Rows="5" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Other Comments / Important Notes</label>
                                        <div class="controls">
                                            <asp:TextBox ID="OtherComments"  runat="server" disabled="disabled"  CssClass="span4" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Date Of Clearance</label>
                                        <div class="controls">
                                            <asp:TextBox ID="DateOfClearence"  runat="server" disabled="disabled"  CssClass="span4"></asp:TextBox>
                                            
                                        </div>
                                    </div>                                 
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget" style="width:76px; float:right; height:46px ">
                            <div class="widget-header" style="border-bottom: none; height:36px">
                                <div class="pull-right">
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-primary" Text="Back" OnClick="btnBack_Click" />
                    </div>
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




