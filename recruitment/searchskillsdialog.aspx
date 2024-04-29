<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchskillsdialog.aspx.cs" Inherits="searchskillsdialog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        @import "../css/ajax__tab_xp2.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top" class="blue-brdr-1" colspan="4">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01">SKILL SELECTION DIALOG BOX
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4"></td>
                </tr>
                <tr>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:DropDownList ID="ddl_dep" runat="server" CssClass="blue1" Width="142px" Height="20px">
                        </asp:DropDownList>
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:TextBox ID="txt_Posts" runat="server" CssClass="blue1" MaxLength="200" Width="142px"></asp:TextBox>
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:Button ID="btnclear" runat="server" Text="Search" CssClass="button" />
                    </td>
                    <td class="frm-rght-clr123 border-bottom " width="25%">
                        <asp:Button ID="Button1" runat="server" Text="Search Clear" CssClass="button" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdSkills" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText=" Name">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkName" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="40%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Description">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescription" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="60%" />
                                    <ItemStyle CssClass="frm-rght-clr1234"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4" width="100%">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>&nbsp;
                                <asp:Button ID="Button2" runat="server" Text="Select All" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button3" runat="server" Text="Deselect All" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button4" runat="server" Text="Submit" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button5" runat="server" Text="First" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button6" runat="server" Text="Previous" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button7" runat="server" Text="Next" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button8" runat="server" Text="Last" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="blue1" MaxLength="4" Width="60px"></asp:TextBox>&nbsp;
                                </td>
                                <td>
                                    <asp:Button ID="Button10" runat="server" Text="GoTo Page" CssClass="button" />&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="lblpageno" runat="server"></asp:Label>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
