<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ApproversHierarchy.aspx.cs" Inherits="Travel_ApproversHierarchy" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/Controls/Uploader.ascx" TagName="File_Uploader" TagPrefix="File_Uploader" %>
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
<head runat="server">
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
    <script lang="JavaScript" type="text/javascript" src="js/popup1.js"></script>
    <script lang="JavaScript" src="../js/JavaScriptValidations.js"></script>
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

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;"></span>
                                            Approver's Hierarchy
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div class="control-group">
                                                <label class="control-label">Employee Code</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_employee" runat="server" CssClass="span4" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_employee" ToolTip="Select Employee"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    <a href="JavaScript:newPopup1('pickemployee.aspx');" class="link05">Pick Employee</a>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Travel Type</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_traveltype" CssClass="span4" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                        <asp:ListItem Value="D">Domestic</asp:ListItem>
                                                        <asp:ListItem Value="I">International</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddl_traveltype" ToolTip="Select Travel Type" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="control-group">
                                                <label class="control-label">Approvers For</label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="ddl_approversfor" CssClass="span4" runat="server">
                                                        <asp:ListItem Value="0">---Select---</asp:ListItem>
                                                        <asp:ListItem Value="Travel">Travel</asp:ListItem>
                                                        <asp:ListItem Value="Expense">Expense</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddl_approversfor" ToolTip="Select Approvers For" InitialValue="0"
                                                        ErrorMessage='<img src="../img/error1.gif" alt="" />' ValidationGroup="a"></asp:RequiredFieldValidator>
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
                                            Add Approver
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>

                                            <div class="control-group">
                                                <label class="control-label">Approver Name </label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_approver" runat="server" CssClass="span4" onkeypress="return enterdate(event);" onkeydown="return enterdate(event);"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage='<img src="../img/error1.gif" alt="" />'
                                                        ValidationGroup="app" ControlToValidate="txt_approver" Display="Dynamic"></asp:RequiredFieldValidator>

                                                    <a href="JavaScript:newPopup1('pickapprover.aspx');" class="link05">Pick Approver</a>
                                                </div>
                                            </div>

                                            <div class="form-actions no-margin" style="text-align: right">
                                                <asp:Button ID="btn_add" runat="server" CssClass="btn btn-primary" Text="Add" OnClick="btn_add_Click"
                                                    ValidationGroup="app" />

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
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Approval Level
                
                                           
                                        </div>
                                        <div style="float: right">
                                            <asp:Button ID="btn_resetgrid" runat="server" CssClass="btn btn-primary" ValidationGroup="onone" Visible="false"
                                                Text="Reset Grid" OnClick="btn_greset_Click" />
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView ID="approvalgrid" runat="server" AutoGenerateColumns="False" CssClass="table table-condensed table-striped  table-bordered pull-left"
                                                EmptyDataText="No Data  Found">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Approver Code">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblapprovercode" runat="server" Text='<%#Eval("empcode")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approver Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblname" runat="server" Text='<%#Eval("name")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Approvers For">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblworkflow" runat="server" Text='<%#Eval("workflow")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Level">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbllevel" runat="server" Text='<%#Eval("level")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Travel Type">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltraveltype" runat="server" Text='<%#Eval("traveltype").ToString()=="I"?"International":"Domestic"%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                            <div class="clearfix"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:HiddenField ID="hidd_name" runat="server" />
                            <asp:HiddenField ID="hiddenlevel" runat="server" Value="1" />
                        </div>

                        <div class="form-actions no-margin" style="text-align: right">
                            <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="btnSubmit_Click" CssClass="btn btn-primary"
                                ValidationGroup="a"></asp:Button>
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn"
                                OnClick="btnCancel_Click"></asp:Button>
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
                $('#approvalgrid').dataTable({
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
