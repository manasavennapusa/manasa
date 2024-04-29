<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onlineTestReview.aspx.cs"
    Inherits="recruitment_onlineTestReview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                    <td valign="top" class="blue-brdr-1">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01" align="right">REMAINING TIME&nbsp;
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="blue1" Width="80px"></asp:TextBox>&nbsp;MINS&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="5"></td>
                </tr>
                <tr>
                    <td class="txt01" align="center">REVIEW
                    </td>
                </tr>
                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="grdOnlineTest" runat="server" AutoGenerateColumns="False" Width="100%"
                            CellPadding="4" CaptionAlign="Left" AllowSorting="True" PageSize="100" Style="border-right: 1px solid #c9dffb"
                            EmptyDataText="No Data Found" CssClass="gvclass">
                            <Columns>
                                <asp:TemplateField HeaderText="Question Numbers">
                                    <ItemTemplate>
                                        <asp:Label ID="lblQuesNo" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle CssClass="frm-lft-clr123" Width="5%" />
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
                    <td colspan="4" width="100%" class="frm-rght-clr123 ">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td>
                                    <asp:Label ID="lblNotviewed" Text="Not Viewed" BackColor="Orange" runat="server" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label1" Text="Viewed" BackColor="Aquamarine" runat="server" Width="200px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label2" Text="Bookmark" BackColor="ActiveBorder" runat="server" Width="200px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" width="100%" class="frm-rght-clr123 ">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" />&nbsp;
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
