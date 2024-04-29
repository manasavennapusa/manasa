<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditEmployeeApprover.aspx.cs" Inherits="Travel_EditEmployeeApprover" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head>
    <meta charset="utf-8" content="" />
    <title>SmartDrive Labs</title>

    <script src="../js/html5-trunk.js" type="text/javascript"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet" />

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet" />
    <link href="../css/blue1.css" rel="stylesheet" />
    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <link href="../css/table.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                        runat="server">
                        <ProgressTemplate>
                            <div class="divajax">
                                <table width="100%">
                                    <tr>
                                        <td align="center" valign="top">
                                            <img src="../img/loading.gif" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>

                    <div class="main-container">
                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Approver's Hierarchy</h2>
                            </div>
                          
                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid" id="gridview" runat="server">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            <span id="Span3" runat="server" class="txt-red" enableviewstate="false"></span>
                                            <asp:Label ID="Label3" runat="server" Text="Employee Details"></asp:Label>

                                        </div>

                                    </div>

                                    <div class="widget-body">

                                        <div id="dt_example" class="example_alt_pagination">

                                            <asp:GridView ID="empgird" runat="server" CssClass="table table-condensed table-striped  table-bordered pull-left" DataKeyNames="id"
                                                AutoGenerateColumns="False" EmptyDataText="Sorry no record found" OnPreRender="empgird_PreRender" OnRowEditing="empgird_RowEditing">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Approver Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("approvercode") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("ApproverName") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Type">
                                                        <ItemTemplate>
                                                            <%--<asp:Label ID="l4" runat="server" Text='<%# Bind ("traveltype") %>'></asp:Label>--%>  
                                                             <asp:Label ID="l4" runat="server" Text='<%#Eval("traveltype").ToString()=="D" ? "Domestic":"International" %>'></asp:Label>                                                        
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Workflow">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l5" runat="server" Text='<%# Bind("workflow") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level Of Approver">
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("level") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="link05" Text="Edit"></asp:LinkButton>
                                                            <%-- <a href="EditEmployeeApprover.aspx?id=<%#DataBinder.Eval(Container.DataItem, "empcode")%>" class="link05">Edit </a>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>

                                                </Columns>

                                            </asp:GridView>

                                            <div class="clearfix"></div>
                                        </div>
                                        <br />
                                          <div class="form-actions no-margin" style="text-align: right">
                                            <asp:Button ID="BtnBack" runat="server" OnClick="BtnBack_Click" CssClass="btn btn-primary" Text="Back"
                                               CausesValidation="false" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid" id="editapprovers" runat="server" visible="false">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            Approver's Hierarchy
                                        </div>
                                    </div>
                                    <div class="widget-body">

                                        <div class="control-group">
                                            <label class="control-label">Employee Code</label>
                                            <div class="controls">
                                                <asp:Label ID="lbl_empname" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Travel Type</label>
                                            <div class="controls">
                                                <asp:Label ID="lblTraveltype" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Approvers For</label>
                                            <div class="controls">
                                                <asp:Label ID="lblApproverfor" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Level</label>
                                            <div class="controls">
                                                <asp:Label ID="lblLevel" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="control-group">
                                            <label class="control-label">Approver Name </label>
                                            <div class="controls">
                                                <asp:TextBox ID="txt_employee" runat="server" CssClass="span4" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                    ValidationGroup="app" ControlToValidate="txt_employee" Display="Dynamic"></asp:RequiredFieldValidator>
                                                <a href="JavaScript:newPopup1('pickemployee.aspx');" class="link05">Pick Approver</a>
                                            </div>
                                        </div>

                                        <div class="control-group" style="display: none">
                                            <label class="control-label">Id</label>
                                            <div class="controls">
                                                <asp:Label ID="lblid" runat="server"></asp:Label>
                                            </div>
                                        </div>

                                        <div class="form-actions no-margin" style="text-align: right">
                                            <asp:Button ID="btnupdate" runat="server" OnClick="btnupdate_Click" CssClass="btn btn-primary" Text="Update"
                                                ValidationGroup="app" />
                                             <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" CssClass="btn btn-primary" Text="Cancel"
                                               CausesValidation="false" />
                                        </div>


                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
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
                $('#empgird').dataTable({
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
