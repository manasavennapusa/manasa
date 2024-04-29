<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employee_processed_attendance.aspx.cs"
    Inherits="payroll_admin_employee_processed_attendance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" height="463px" colspan="5">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Attendance
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 26%">
                                        Month
                                    </td>
                                    <td class="frm-rght-clr123" style="width: 24%">
                                        <asp:DropDownList ID="dd_year" runat="server" CssClass="blue1">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" class="frm-rght-clr123">
                                        <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Process" OnClick="btn_search_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="7">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td valign="bottom" class="txt02">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td class="txt02" style="width: 30%; height: 13px">
                                                    Employee Processed Attendance
                                                </td>
                                                <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" class="head-2">
                            <asp:GridView ID="attendancegrid" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                CellPadding="4" CellSpacing="0" Font-Names="Arial" Font-Size="11px" Width="100%"
                                AllowPaging="True" PageSize="30" EmptyDataText="Sorry no record found" CssClass="gvclass"
                                Border="1px solid #ddd">
                                <Columns>
                                    <asp:TemplateField HeaderText="Employee Name">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Employee Code">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("empcode") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("department_name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="LWP">
                                        <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                        <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                            Width="25%" />
                                        <ItemTemplate>
                                            <asp:Label ID="l4" runat="server" Text='<%# Bind("mode")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle CssClass="frm-lft-clr123" />
                                <FooterStyle CssClass="frm-lft-clr123" />
                                <RowStyle Height="5px" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate>
</asp:UpdatePanel>  --%>
    </form>
</body>
</html>
