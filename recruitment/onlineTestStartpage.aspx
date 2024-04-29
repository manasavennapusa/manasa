<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onlineTestStartpage.aspx.cs"
    Inherits="recruitment_onlineTestStartpage" %>

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
                    <td valign="top" class="blue-brdr-1" colspan="2">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01">ONLINE TEST START PAGE
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Rules
                    </td>
                    <td class="frm-rght-clr123" width="70%">
                        <asp:TextBox ID="TextBox1" runat="server" CssClass="blue1" TextMode="MultiLine" MaxLength="1000"
                            Width="250px" Height="80px"></asp:TextBox>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td colspan="2" class="border-bottom">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="frm-lft-clr123" width="25%">Paper
                                </td>
                                <td class="frm-lft-clr123" width="25%">Subject
                                </td>
                                <td class="frm-lft-clr123" width="30%">Access Key
                                </td>
                                <td class="frm-lft-clr123" width="20%">Start
                                </td>
                            </tr>
                            <tr>
                                <td class="frm-rght-clr123">
                                    <asp:Label ID="lbl5" runat="server"></asp:Label>
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:Label ID="Label1" runat="server"></asp:Label>
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="blue1" MaxLength="200" Width="142px"></asp:TextBox>
                                </td>
                                <td class="frm-rght-clr123 ">
                                    <asp:Button ID="Button1" runat="server" Text="Start" CssClass="button" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td colspan="2" width="100%"   align="center">
                        <asp:Button ID="Button5" runat="server" Text="End Test" CssClass="button" />&nbsp;
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
