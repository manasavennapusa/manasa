<%@ Page Language="C#" AutoEventWireup="true" CodeFile="attendance-cum-canteen-master.aspx.cs"
    Inherits="payroll_admin_attendance_cum_canteen_master" %>

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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td class="txt01">
                                                Attendance Cum Canteen Master
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top">
                                </td>
                            </tr>
                            <tr>
                                <td height="20" valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="27%" class="txt02">
                                                Create Code
                                            </td>
                                            <td width="73%" align="right" class="txt-red">
                                                <span id="message" runat="server"></span>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 123px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Code
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_name" size="40" CssClass="blue1" runat="server" Width="146px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                    Display="Dynamic" ToolTip="Enter Payhead Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Used For
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                &nbsp;<asp:DropDownList ID="ddlusedfor" runat="server" CssClass="blue1" Width="145px">
                                                    <asp:ListItem Value="A-I">Attendance-In</asp:ListItem>
                                                    <asp:ListItem Value="A-O">Attendance-Out</asp:ListItem>
                                                    <asp:ListItem Value="B">Canteen - Breakfast</asp:ListItem>
                                                    <asp:ListItem Value="L">Canteen - Lunch</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123 border-bottom">
                                                &nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ValidationGroup="v" ToolTip="Click to submit the created Payhead" />&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Reset" OnClick="btn_reset_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="txt02">
                                    Attendance-Canteen Code Mapping View
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="grid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"
                                        Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="No code exist"
                                        OnPageIndexChanging="grid_PageIndexChanging" OnRowDeleting="grid_RowDeleting"
                                        OnRowEditing="grid_RowEditing" OnRowUpdating="grid_RowUpdating" DataKeyNames="id"
                                        OnRowCancelingEdit="grid_RowCancelingEdit" CssClass="gvclass" Border="1px solid #ddd">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Code">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l2" runat="server" Text='<%# Bind ("code") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtcodeg" runat="server" Text='<%# Bind("code") %>'></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Used For">
                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                <ItemStyle Width="20%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:Label ID="l4" runat="server" Text='<%# Bind ("usedfor") %>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:DropDownList ID="ddlusedforg" runat="server" CssClass="blue1" Width="145px">
                                                        <asp:ListItem Value="A-I">Attendance-In</asp:ListItem>
                                                        <asp:ListItem Value="A-O">Attendance-Out</asp:ListItem>
                                                        <asp:ListItem Value="B">Canteen - Breakfast</asp:ListItem>
                                                        <asp:ListItem Value="L">Canteen - Lunch</asp:ListItem>
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lnk_update" CssClass="link05" CommandName="Update" runat="server"
                                                        ValidationGroup="grid">Update</asp:LinkButton>|
                                                    <asp:LinkButton ID="lnk_cancel" CssClass="link05" CommandName="Cancel" runat="server"
                                                        ValidationGroup="noone">Cancel</asp:LinkButton>
                                                </EditItemTemplate>
                                                <ItemStyle Width="24%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lnk_edit" CssClass="link05" CommandName="Edit" runat="server"
                                                        ValidationGroup="noone">Edit </asp:LinkButton>|
                                                    <asp:LinkButton ID="lnk_delete" CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');"
                                                        CommandName="Delete" runat="server" ValidationGroup="noone">Delete</asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                        <FooterStyle CssClass="frm-lft-clr123" />
                                        <RowStyle Height="5px" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
