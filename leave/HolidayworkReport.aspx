<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HolidayworkReport.aspx.cs" Inherits="leave_HolidayworkReport" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
    <script type="text/javascript">
        function isKey(keyCode) {
            return false;
        }
    </script>

    <style type="text/css">
        .star:before
        {
            color: red !important;
            content: " *";
        }
    </style>

</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">
            function ValidateData() {
                var frmdate = document.getElementById('<%=txt_sdate.ClientID %>');
                var todate = document.getElementById('<%=txt_edate.ClientID %>');
                var empcode = document.getElementById('<%=txt_employee.ClientID %>');
                //if (frmdate.value == "") {
                //    alert("Please Enter From Date");
                //    return false;
                //}
                //if (todate.value == "") {
                //    alert("Please Enter To Date");
                //    return false;
                //}

                //return true;
            }
        </script>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <%--<asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>

        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <div class="page-header">
                        <div class="pull-left">
                            <h2>Holiday Details Report</h2>  
                        </div>

                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Employee--%>
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">From Date<span class="star"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_sdate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_sdate"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip=" Please Select From Date"
                                                ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To Date<span class="star"></span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_edate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_edate"
                                                Display="Dynamic" ErrorMessage='<img src="../images/error1.gif" alt="" />' ToolTip=" Please Select To Date"
                                                ValidationGroup="v" Width="16px" SetFocusOnError="True"><img src="../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <cc1:CalendarExtender
                                                ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txt_edate">
                                            </cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="span3" Width="" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i></a>
                                        </div>

                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" Text="Search" OnClick="Button1_Click" ValidationGroup="v" />
                                         <%--OnClientClick="return ValidateData();"--%>&nbsp;&nbsp;
                                        <asp:Button ID="btn_export" runat="server" CssClass="btn btn-info" OnClick="btn_export_Click" Text="Export" OnClientClick="return ValidateData();" />
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <%--   </ContentTemplate>
                    </asp:UpdatePanel>--%>
                    <div class="row-fluid">
                        <div class="span12">
                            <div class="widget no-margin">
                                <div class="widget-header">
                                    <div class="title">
                                        <%--<span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Leave Details Report--%>
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="grid_leave" runat="server" EmptyDataText="No records found!!" AutoGenerateColumns="False" CssClass="table table-condensed table-striped table-hover table-bordered pull-left" OnPreRender="grid_leave_PreRender">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Empcode" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                               <%-- <asp:TemplateField HeaderText="Leave Type" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("leavetype") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:TemplateField HeaderText="Duration" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l5" runat="server" Text='<%# Bind("date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="No of Days" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l7" runat="server" Text='<%# Bind("day") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Comments" HeaderStyle-Width="50%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="l7" runat="server" Text='<%# Bind("reason") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle Height="5px" />
                                        </asp:GridView>
                                        <div class="clearfix"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#grid_leave').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

