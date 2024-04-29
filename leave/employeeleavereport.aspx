<%@ Page
    Language="C#"
    AutoEventWireup="false"
    CodeFile="employeeleavereport.aspx.cs"
    Inherits="leave_employeeleavereport"
    EnableEventValidation="true"
    ViewStateMode="Disabled"
    EnableSessionState="ReadOnly" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />

    <title>SmartDrive Labs</title>
    <script src="../js/html5-trunk.js"></script>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />

</head>

<body>
    <form id="myForm" runat="server" class="form-horizontal no-margin">

        <div class="dashboard-wrapper" style="margin-left: 0px;">

            <div class="main-container">

                <div class="page-header">
                    <div class="pull-left">
                        <h2>Calender Year Leave Report</h2>
                    </div>

                    <div class="clearfix"></div>
                </div>

                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">
                            <div class="widget-header" style="border-bottom: none;">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe023;">Leave Report</span>
                                </div>
                            </div>
                            <div id="tblcountry" runat="server">
                                <div class="widget-body">
                                    <fieldset>
                                        <div class="control-group">
                                            <label class="control-label">Select Leave Period</label>
                                            <div class="controls">
                                                <asp:DropDownList
                                                    ID="ddlLeavePeriod"
                                                    runat="server"
                                                    CssClass="span4"
                                                    ViewStateMode="Enabled"
                                                    ValidationGroup="v"
                                                    OnDataBound="ddlLeavePeriod_DataBound">
                                                    <asp:ListItem
                                                        Value="0"
                                                        Text="--Select--"></asp:ListItem>
                                                </asp:DropDownList>

                                                <asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1"
                                                    runat="server"
                                                    ControlToValidate="ddlLeavePeriod"
                                                    EnableClientScript="true"
                                                    Display="Dynamic"
                                                    ValidationGroup="v"
                                                    ViewStateMode="Disabled"
                                                    InitialValue="0"
                                                    ErrorMessage="Please select the leave period"
                                                    Text="*"
                                                    SetFocusOnError="true"></asp:RequiredFieldValidator>

                                            </div>
                                        </div>


                                        <div class="form-actions no-margin">
                                            <asp:ValidationSummary
                                                ID="ValidationSummary1"
                                                runat="server"
                                                EnableClientScript="true"
                                                ShowMessageBox="true"
                                                ShowSummary="false"
                                                ValidationGroup="v"
                                                ViewStateMode="Disabled"
                                                DisplayMode="BulletList" />

                                            <asp:Button
                                                ID="btnSearch"
                                                runat="server"
                                                CssClass="btn btn-info"
                                                CausesValidation="true"
                                                ViewStateMode="Disabled"
                                                Text="Search"
                                                ValidationGroup="v"
                                                OnClick="btnSearch_Click" />
                                                                                    <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info" OnClick="btn_export_Click" Text="Export" />

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
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Calender Leave Report
                 
                                </div>
                            </div>
                            <div class="widget-body">
                                <div id="dt_example" class="example_alt_pagination">
                                    <asp:GridView
                                        ID="grid"
                                        runat="server"
                                        AutoGenerateColumns="false"
                                        CssClass="table table-condensed table-striped table-hover table-bordered pull-left"
                                        ViewStateMode="Enabled" OnPreRender="grid_PreRender">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Period Name" Visible="false">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"periodname") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valid From Date" Visible="false">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"fromdate") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Valid To Date"  Visible="false">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"todate") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Policy Name"  Visible="false">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"policyname") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                       
                                            <asp:TemplateField HeaderText="Employee Code">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"empcode") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Employee Name">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"emp_fname") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- <asp:TemplateField HeaderText="Employee Status">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"status_activity") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>
                                                 <asp:TemplateField HeaderText="Leave Name">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"displayleave") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Total Leave">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"entitled_days") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                              <asp:TemplateField HeaderText="Previous Year Balance">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"Balance") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                  <asp:TemplateField HeaderText="CarryForward Days">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"carryforward") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="EL Carry forward to the next year">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"caryfwrdeddays") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Leave Encashmet">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"encashmentdays") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Leave Encashed">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"cur_encashed") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Lapsed">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"elapsed") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Current Year Entitlement">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"curEntitledays") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Leave Used">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"curUseddays") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="As on Date Balance">
                                                <ItemTemplate>
                                                    <%#DataBinder.Eval(Container.DataItem,"curBalance") %>
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
        </div>
        <script src="../js/jquery.min.js"></script>
        <script src="../js/bootstrap.js"></script>
        <script src="../js/moment.js"></script>

        <!-- Data tables JS -->

        <script src="../js/jquery.dataTables.js"></script>

        <!-- Tiny scrollbar js -->
        <script src="../js/tiny-scrollbar.js"></script>

        <!-- Custom Js -->
        <script src="../js/theming.js"></script>
        <script src="../js/custom.js"></script>

        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>

    </form>
</body>
</html>
