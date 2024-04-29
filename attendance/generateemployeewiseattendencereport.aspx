<%@ Page Language="C#" AutoEventWireup="true" CodeFile="generateemployeewiseattendencereport.aspx.cs" Inherits="attendance_generateemployeewiseattendencereport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="utf-8" />
    <title>SmartDrive Labs</title>
    <link href="../icomoon/style.css" rel="stylesheet" />
    <link href="../css/main.css" rel="stylesheet" />
    <script src="js/popup.js"></script>
</head>
<body>
    <form id="myForm" runat="server">
        <script type="text/javascript">
            function validate()
            {
                var frmdate = document.getElementById('<%=txt_sdate.ClientID %>');
                var todate = document.getElementById('<%=txt_edate.ClientID %>');
                var empcode = document.getElementById('<%=txt_employee.ClientID %>');

                if (frmdate.value == "") {
                    alert("Please Enter From Date");
                    return false;
                }
                if (todate.value == "") {
                    alert("Please Enter To Date");
                    return false;
                }
                if (empcode.value == "") {
                    alert("Please Pick Employee.");
                    return false;
                }
                return true;
            }
        </script>
         <script type="text/javascript">
             function isKey(keyCode) {
                 return false;
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
                            <h2>Employeewise Attendance</h2>
                        </div>
                     
                        <div class="clearfix"></div>
                    </div>

                    <div class="row-fluid">
                        <div class="widget">
                            <div class="widget-header">
                                <div class="title">
                                    <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Search Employee
                                </div>
                            </div>
                            <div class="widget-body">
                                <fieldset>
                                    <div class="control-group">
                                        <label class="control-label">From Date</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_sdate" runat="server" Width="200px" CssClass="blue1" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender ID="cextender" runat="server" PopupButtonID="img_f" TargetControlID="txt_sdate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">To Date</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_edate" runat="server" Width="200px" CssClass="blue1" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1" TargetControlID="txt_edate" Format="MM/dd/yyyy"></cc1:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="control-group">
                                        <label class="control-label">Employee Name\Code</label>
                                        <div class="controls">
                                            <asp:TextBox ID="txt_employee" runat="server" CssClass="blue1" Width="" onkeypress="return isAlphaNumeric()"></asp:TextBox>

                                            <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                        </div>
                                    </div>
                                    <div class="form-actions no-margin">
                                        <asp:Button ID="btn_search" runat="server" CssClass="btn btn-info" OnClick="btn_search_Click" Text="Search" OnClientClick="return validate();" />
                                        <asp:Button ID="btn_reset" runat="server" CssClass="btn btn-info" OnClick="btn_reset_Click" Text="Reset"  />
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-info" OnClick="Button1_Click" Text="Export" OnClientClick="return validate();" />
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
                                        <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>View Attendance
                                    </div>
                                </div>
                                <div class="widget-body">
                                    <div id="dt_example" class="example_alt_pagination">
                                        <asp:GridView ID="attendancegrid" runat="server" AutoGenerateColumns="False" EmptyDataText="No records found!!"
                                            OnPreRender="attendancegrid_PreRender" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempcode" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Employee Name" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblempname" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Department" HeaderStyle-Width="15%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldept" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Date" HeaderStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lbldate" runat="server" Text='<%# Bind("date")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Day" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblday" runat="server" Text='<%# Bind("dayofweek")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Intime" HeaderStyle-Width="14%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblintime" runat="server" Text='<%# Bind("intime")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="OutTime" HeaderStyle-Width="14%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblouttime" runat="server" Text='<%# Bind("outtime")%>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mode" HeaderStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblmode" runat="server" Text='<%# Bind("mode")%>'></asp:Label>
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
            </div>
        </div>
        <script src="../js/jquery.min.js" type="text/javascript"></script>
        <script src="../js/bootstrap.js" type="text/javascript"></script>
        <script src="../js/jquery.dataTables.js" type="text/javascript"></script>
        <script type="text/javascript">
            //Data Tables
            $(document).ready(function () {
                $('#attendancegrid').dataTable({
                    "sPaginationType": "full_numbers"
                });
            });
        </script>
    </form>
</body>
</html>

