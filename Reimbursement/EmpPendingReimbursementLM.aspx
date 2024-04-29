<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EmpPendingReimbursementLM.aspx.cs" Inherits="Reimbursement_EmpPendingReimbursementLM" %>

<%@ Register Assembly="AjaxControlToolkit, Version=1.0.11119.7969, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">

    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />

    <!--[if lte IE 7]>
    <script src="css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <link href="../css/main.css" rel="stylesheet" />
    <script type="text/javascript">
        function isKey(keyCode) {
            return false;
        }
    </script>
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="updatepanel2" runat="server">
                <ContentTemplate>
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Employee Reimbursement Status</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span1" runat="server" class="txt-red" enableviewstate="false"></span>
                                            Reimbursement Details
                                            <span id="message" runat="server"></span>
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">From Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txtfromdate" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;" Width=""></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/img/clndr.gif" />
                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txtfromdate" Enabled="True"></cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtfromdate" ToolTip="Enter Date"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">To Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txttodate" runat="server" CssClass="span4" MaxLength="50" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;" Width=""></asp:TextBox>
                                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/img/clndr.gif" />
                                                    <cc1:CalendarExtender Format="dd-MMM-yyyy" ID="CalendarExtender2" runat="server" PopupButtonID="Image2" TargetControlID="txttodate" Enabled="True"></cc1:CalendarExtender>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txttodate" ToolTip="Enter Date"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="c"></asp:RequiredFieldValidator>

                                                </div>
                                            </div>

                                            <div class="form-actions no-margin">
                                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary" Text="Submit" ValidationGroup="c" OnClick="btnsubmit_Click" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>




                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span2" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label1" runat="server" Text="Pending Reimbursement Details"></asp:Label>
                                        </div>
                                    </div>

                                    <div class="widget-body">

                                        <div id="Div1" class="example_alt_pagination">

                                            <asp:GridView ID="grdpending" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable"
                                                DataKeyNames="RID" OnPreRender="grdpending_PreRender">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="RID" HeaderStyle-Width="10%" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbrid" runat="server" Text='<%#Eval("RID")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Date" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbldate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Type" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltype" runat="server" Text='<%# Eval("Type")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblempcode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="20%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("empname")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Code" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblapprovercode" runat="server" Text='<%#Eval("approvercode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Pending Level" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("level")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                    <asp:TemplateField HeaderText="View" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:Button ID="btnpending" runat="server" CssClass="btn btn-primary pull-right" Text="View " OnCommand="btnpending_Command" CommandArgument='<%#Eval("RID")%>' />
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
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btnsubmit" />
                </Triggers>
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
                $('#Grid_Emp').dataTable({
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
