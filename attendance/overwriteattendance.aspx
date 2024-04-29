<%@ Page Language="C#" AutoEventWireup="true" CodeFile="overwriteattendance.aspx.cs" Inherits="attendance_overwriteattendance" %>

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
            function ValidateData() {

                var frmdate = document.getElementById('<%=txt_frmdate.ClientID %>');
                var todate = document.getElementById('<%=txt_todate.ClientID %>');
                var empcode = document.getElementById('<%=txt_employee.ClientID %>');

                if (frmdate.value == "") {
                    alert("Please enter from date.");
                    return false;
                }
                if (todate.value == "") {
                    alert("Please enter to date.");
                    return false;
                }
                if (empcode.value == "") {
                    alert("Please select the employee.");
                    return false;
                }
                return true;
            }

            function isKey(keyCode) {

                return false;

            }
        </script>
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
            runat="server">
            <ProgressTemplate>
                <div class="modal-backdrop fade in">
                    <div class="center">
                        <img src="images/loader.gif" alt="" />
                        Please Wait...
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <script type="text/javascript">
            function ValidateData() {
                var frmdate = document.getElementById('<%=txt_frmdate.ClientID %>');
                var todate = document.getElementById('<%=txt_todate.ClientID %>');
                if (frmdate.value == "") {
                    alert("Please Enter From Date");
                    return false;
                }
                if (todate.value == "") {
                    alert("Please Enter To Date");
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
        <div class="form-horizontal no-margin">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                <div class="main-container">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="page-header">
                                <div class="pull-left">
                                    <h2>Overwrite Attendance</h2>
                                </div>
                               
                                <div class="clearfix"></div>
                            </div>
                            <div class="row-fluid">
                                <div class="widget">
                                    <div class="widget-header">
                                        <div class="title">
                                            <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Overwrite Attendance
                                        </div>
                                    </div>
                                    <div class="widget-body">
                                        <fieldset>
                                            <div class="control-group">
                                                <label class="control-label">From Date</label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_frmdate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <asp:Image ID="img_f" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender1" runat="server" PopupButtonID="img_f" TargetControlID="txt_frmdate">
                                                        </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label">To Date </label>
                                                <div class="controls">
                                                    <asp:TextBox ID="txt_todate" runat="server" CssClass="span3" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/leave/images/clndr.gif" />&nbsp;
                                                        <cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" PopupButtonID="Image1" TargetControlID="txt_todate">
                                                        </cc1:CalendarExtender>
                                                </div>
                                            </div>
                                            <div class="control-group">
                                                <label class="control-label ">Employee Code/Name</label>
                                                <div class="controls ">
                                                    <asp:TextBox ID="txt_employee" runat="server" Width="220px" CssClass="span4" onkeypress="return isKey(event);" ondrop="return false;" onpaste="return false;"></asp:TextBox>
                                                    <a href="JavaScript:newPopup1('PickEmployee.aspx');"><i class="icon-user"></i>Pick Employee</a>
                                                </div>
                                            </div>
                                            <div class="form-actions no-margin">
                                                <asp:Button ID="Button3" runat="server" CssClass="btn btn-info pull-right pull-right" OnClick="Button1_Click" Text="Fetch Attendance" OnClientClick="return ValidateData();" />
                                            </div>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span12">
                                    <div class="widget no-margin">
                                        <div class="widget-header">
                                            <div class="title">
                                                <span class="fs1" aria-hidden="true" data-icon="&#xe14a;"></span>Overwrite Attendance
                                            </div>
                                        </div>
                                        <div class="widget-body">
                                            <div id="dt_example" class="example_alt_pagination">
                                                <asp:GridView ID="empgrid"
                                                    runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="table table-striped table-bordered table-hover table-checkable table-responsive datatable" OnPageIndexChanging="empgrid_PageIndexChanging" OnPreRender="empgrid_PreRender">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Date" HeaderStyle-Width="20%">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lbldateg" runat="server" Text='<%# Bind ("date") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Employee Code" HeaderStyle-Width="20%">

                                                            <ItemTemplate>
                                                                <asp:Label ID="l2" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Card No" HeaderStyle-Width="20%">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblcardnog" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Mode" HeaderStyle-Width="20%">

                                                            <ItemTemplate>
                                                                <asp:Label ID="lblmodeg" runat="server" Text='<%# Bind ("mode") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Change Mode" HeaderStyle-Width="20%">


                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="kcn" runat="server" CssClass="span3" Width="60px">
                                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                                    <asp:ListItem Value="1">A</asp:ListItem>
                                                                    <asp:ListItem Value="2">H</asp:ListItem>
                                                                    <asp:ListItem Value="3">W</asp:ListItem>
                                                                    <asp:ListItem Value="4">HF</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </ItemTemplate>

                                                            <EditItemTemplate>
                                                                <asp:DropDownList ID="ddlrunstatusg" runat="server" Width="60px" SelectedValue='<%#Bind("mode")%>' CssClass="span3" Height="20px">
                                                                    <asp:ListItem Value="0">P</asp:ListItem>
                                                                    <asp:ListItem Value="1">A</asp:ListItem>
                                                                    <asp:ListItem Value="2">H</asp:ListItem>
                                                                    <asp:ListItem Value="3">W</asp:ListItem>

                                                                </asp:DropDownList>
                                                            </EditItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Check" HeaderStyle-Width="10%">

                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="Chkbox" runat="server" BorderStyle="None" Text='<%# Eval("date")%>' ForeColor="White" AutoPostBack="false" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <HeaderStyle CssClass="frm-lft-clr123" />
                                                    <FooterStyle CssClass="frm-lft-clr123" />
                                                    <RowStyle Height="5px" />
                                                </asp:GridView>
                                                <div class="clearfix"></div>
                                            </div>

                                        </div>
                                        <div class="widget-body">
                                            <fieldset>
                                                <div class="form-actions no-margin">
                                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-info pull-right pull-right" OnClick="Button1_Click2"
                                                        Text="Update Attendance" Visible="False" />
                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                    <asp:HiddenField ID="HiddenField2" runat="server" />
                                                </div>
                                            </fieldset>
                                        </div>
                                    </div>

                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>




