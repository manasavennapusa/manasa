<%@ Page
    Language="C#"
    AutoEventWireup="True"
    CodeFile="leaveperiod1.aspx.cs"
    Inherits="leave_leaveperiod1"
    ViewStateMode="Disabled" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %>

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

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8">
    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet">
    <!--[if lte IE 7]>
    <script src="../css/icomoon-font/lte-ie7.js"></script>
    <![endif]-->

    <!-- NVD graphs css -->
    <link href="../css/nvd-charts.css" rel="stylesheet">

    <!-- Bootstrap css -->
    <link href="../css/main.css" rel="stylesheet">

    <!-- fullcalendar css -->
    <link href='../css/fullcalendar/fullcalendar.css' rel='stylesheet' />
    <link href='../css/fullcalendar/fullcalendar.print.css' rel='stylesheet' media='print' />
</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">
        <asp:ScriptManager 
            ID="ScriptManager1" 
            runat="server" 
            EnablePartialRendering="true">
        </asp:ScriptManager>

        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <asp:UpdatePanel 
                ID="updatepanel1" 
                runat="server" 
                ChildrenAsTriggers="true" 
                UpdateMode="Always">

                <ContentTemplate>
                    <asp:UpdateProgress 
                        runat="server" 
                        AssociatedUpdatePanelID="updatepanel1">

                        <ProgressTemplate>
                           
                        </ProgressTemplate>

                    </asp:UpdateProgress>
                    
                    <div class="main-container">

                        <div class="page-header">
                            <div class="pull-left">
                                <h2>Leave Period</h2>
                            </div>

                            <div class="clearfix"></div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">
                                    <div class="widget-header" style="border-bottom: none;">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe023;">Leave Period</span>
                                        </div>
                                    </div>
                                    <div id="tblcountry" runat="server">
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="control-group">
                                                    <label class="control-label">Period Name</label>
                                                    <div class="controls">
                                                        <asp:HiddenField
                                                            ID="hdnId"
                                                            runat="server"
                                                            ViewStateMode="Disabled"
                                                            Value="0" />

                                                        <asp:TextBox
                                                            ID="txtPeriodName"
                                                            runat="server"
                                                            ViewStateMode="Disabled"
                                                            ValidationGroup="v"
                                                            TextMode="SingleLine"
                                                            CssClass="span4">  
                                                        </asp:TextBox>

                                                        <asp:RequiredFieldValidator
                                                            ID="RequiredFieldValidator1"
                                                            runat="server"
                                                            ControlToValidate="txtPeriodName"
                                                            EnableClientScript="true"
                                                            ErrorMessage="Please enter period name."
                                                            Text="*"
                                                            SetFocusOnError="true"
                                                            ValidationGroup="v"
                                                            ViewStateMode="Disabled"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">From Date</label>
                                                    <div class="controls">
                                                        <asp:TextBox
                                                            ID="txtFromDate"
                                                            runat="server"
                                                            ViewStateMode="Disabled"
                                                            ValidationGroup="v"
                                                            TextMode="SingleLine"
                                                            CssClass="span4">  
                                                        </asp:TextBox>

                                                        <asp:Image
                                                            ID="imgFromDate"
                                                            runat="server"
                                                            ImageUrl="~/leave/images/clndr.gif" />&nbsp;

                                        <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator2"
                                            runat="server"
                                            ControlToValidate="txtFromDate"
                                            EnableClientScript="true"
                                            ErrorMessage="Please enter from date."
                                            Text="*"
                                            SetFocusOnError="true"
                                            ValidationGroup="v"
                                            ViewStateMode="Disabled"></asp:RequiredFieldValidator>

                                                        <cc:CalendarExtender
                                                            ID="CalendarExtender1"
                                                            ViewStateMode="Disabled"
                                                            TargetControlID="txtFromDate"
                                                            runat="server"
                                                            Format="dd MMM yyyy"
                                                            PopupButtonID="imgFromDate">
                                                        </cc:CalendarExtender>
                                                    </div>
                                                </div>
                                                <div class="control-group">
                                                    <label class="control-label">To Date</label>
                                                    <div class="controls">
                                                        <asp:TextBox
                                                            ID="txtToDate"
                                                            runat="server"
                                                            ViewStateMode="Disabled"
                                                            ValidationGroup="v"
                                                            TextMode="SingleLine"
                                                            CssClass="span4">  
                                                        </asp:TextBox>

                                                        <asp:Image
                                                            ID="imgToDate"
                                                            runat="server"
                                                            ImageUrl="~/leave/images/clndr.gif" />&nbsp;

                                        <asp:RequiredFieldValidator
                                            ID="RequiredFieldValidator3"
                                            runat="server"
                                            ControlToValidate="txtToDate"
                                            EnableClientScript="true"
                                            ErrorMessage="Please enter to date."
                                            Text="*"
                                            SetFocusOnError="true"
                                            ValidationGroup="v"
                                            ViewStateMode="Disabled"></asp:RequiredFieldValidator>

                                                        <cc:CalendarExtender
                                                            ID="CalendarExtender2"
                                                            ViewStateMode="Disabled"
                                                            TargetControlID="txtToDate"
                                                            runat="server"
                                                            Format="dd MMM yyyy"
                                                            PopupButtonID="imgToDate">
                                                        </cc:CalendarExtender>

                                                    </div>
                                                </div>
                                                 <div class="control-group"  style="display:none">
                                        <label class="control-label">Is Active?</label>
                                        <div class="controls">
                                            <asp:CheckBox ID="chkActive" runat="server" Checked="false" Enabled="false" />
                                        </div>
                                    </div>
                                                <div class="form-actions no-margin">
                                                    <asp:ValidationSummary
                                                        ID="ValidationSummary"
                                                        runat="server"
                                                        EnableClientScript="true"
                                                        DisplayMode="BulletList"
                                                        ShowMessageBox="true"
                                                        ShowSummary="false"
                                                        ValidationGroup="v"
                                                        ViewStateMode="Disabled" />

                                                    <asp:Button
                                                        ID="btnSave"
                                                        runat="server"
                                                        CausesValidation="true"
                                                        ViewStateMode="Disabled"
                                                        OnClick="btnSave_Click"
                                                        ValidationGroup="v"
                                                        Text="Save" />
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>

                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget no-margin">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Leave Period
                 
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <div id="dt_example" class="example_alt_pagination">
                                            <asp:GridView
                                                ID="grid"
                                                runat="server"
                                                DataKeyNames="id"
                                                AutoGenerateColumns="False"
                                                CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                               
                                                OnRowDataBound="grid_RowDataBound"
                                                OnRowUpdating="grid_RowUpdating" 
                                                ViewStateMode="Enabled">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sl#" Visible="false">
                                                        <ItemTemplate>
                                                            <%#Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Id" >
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem,"id") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Period Name">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem,"periodname") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="From Date">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem,"fromdate") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="To Date">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem,"todate") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Status" Visible="false">
                                                        <ItemTemplate>
                                                            <%#DataBinder.Eval(Container.DataItem,"status") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                   <%-- <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton
                                                                ID="lnkEdit"
                                                                runat="server"
                                                                CommandName="Edit"
                                                                CausesValidation="true"
                                                                Text="Edit"></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>--%>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton
                                                                ID="lnkStatus"
                                                                runat="server"
                                                                CommandName="Update"
                                                                CausesValidation="false" 
                                                                Text='<%#DataBinder.Eval(Container.DataItem,"status") %>'></asp:LinkButton>
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
