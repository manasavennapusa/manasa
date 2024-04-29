<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproverResignationViewDetails.aspx.cs" Inherits="Exit_ApproverResignationViewDetails" %>

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
    <%--<script type="text/javascript">
        function Validate() {

            var Comments = document.getElementById("txtComments");
            if (Comments.value.trim() == "") {
                Comments.focus();
                alert("Please enter your comments.");
                return false;
            }

            return true;
        }

    </script>--%>
    <style>
        .center
        {
            position: absolute;
            top: 448px;
            left: 500px;
        }
    </style>
</head>
<body>

    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel1" runat="server" UpdateMode="Always">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="modal-backdrop fade in">
                                <div class="center">
                                    <img src="../img/loading.gif" />"
                                    Please Wait...
                                </div>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Resignation Request</h2>
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
                                            <asp:HiddenField ID="EmployeeTypeId" runat="server"></asp:HiddenField>
                                            <div class="control-group">
                                                <label class="control-label">Applied Date and Time</label>
                                                <div class="controls">
                                                    <asp:Label ID="lblAppliedDate" runat="server" CssClass="span4"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Employee Type</label>
                                                <div class="controls">
                                                    <asp:Label ID="lblEmployeeType" runat="server" CssClass="span4"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Notice Period</label>
                                                <div class="controls">
                                                    <asp:Label ID="lblNoticePeriod" runat="server" CssClass="span4"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group" >
                                                <label class="control-label">Default Last Working Day</label>
                                                <div class="controls">
                                                    <asp:Label ID="lblDLWD" runat="server" CssClass="span4"></asp:Label>
                                                    <asp:ImageButton ID="imgbtn" runat="server" ImageUrl="~/Exit/image/edit.png" Visible="true" OnClick="imgbtn_Click" style="display:none" />
                                                </div>
                                            </div>
                                            <div class="control-group" id="LWD" runat="server">
                                                <label class="control-label">New Last Working Day</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="NewLWD" runat="server" CssClass="span4"></asp:TextBox>
                                                    <asp:Image ID="Image11" runat="server" ImageUrl="~/img/clndr.gif" />
                                                    <cc1:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="Image11" TargetControlID="NewLWD" Enabled="True" Format="dd-MMM-yyyy">
                                                    </cc1:CalendarExtender>
                                                    <asp:Button ID="EditLED" runat="server" Text="Update LWD" OnClick="EditLED_Click" Visible="false" CssClass="btn btn-primary" />
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">Employee Comments</label>
                                                <div class="controls">
                                                    <asp:Label ID="lblComments" runat="server" CssClass="span4"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="control-group" id="CommentBox" runat="server">
                                                <label class="control-label">Comments</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtComments" TextMode="MultiLine" Rows="8" MaxLength="8000" runat="server" CssClass="span8"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="txtrequired" runat="server" ControlToValidate="txtComments" ErrorMessage="*" ForeColor="Red" ValidationGroup="g"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approver List                                                          
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                                EmptyDataText="No Data Found" OnRowDataBound="Grid_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Approver Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblAppvrCode" runat="server" Text='<%#Eval("ApproversCode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <ItemTemplate>
                                                            <%#Eval("EmpName")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("ApproverStatus")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Comments">
                                                        <ItemTemplate>
                                                            <%#Eval("ApproverComments")%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <ItemTemplate>
                                                            <%#Eval("WorkFlowName")%>
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
                        <br />
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-body">
                                        <div class="form-actions no-margin" style="text-align: right">
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="return Validate();" Style="display: none" />
                                            <asp:Button ID="btnApprove" runat="server" CssClass="btn btn-primary" Text="Approve" OnClick="btnApprove_Click" ValidationGroup="g" />
                                            <asp:Button ID="btnReject" runat="server" CssClass="btn btn-primary" Text="Reject" OnClick="btnReject_Click" ValidationGroup="g" />
                                            
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </ContentTemplate>
               
            </asp:UpdatePanel>
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


