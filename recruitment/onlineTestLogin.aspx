<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onlineTestLogin.aspx.cs"
    Inherits="recruitment_onlineTestLogin" %>

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
                            <td class="txt01">
                                ONLINE TEST LOGIN
                            </td>
                            <td align="right">
                                <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="5">
                </td>
            </tr>
            <tr>
                <td class="frm-lft-clr123" width="30%">
                    Select RRF
                </td>
                <td class="frm-rght-clr123" width="70%">
                    <asp:DropDownList ID="ddl_RRF" runat="server" CssClass="blue1" Width="142px" Height="20px">
                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td colspan="2" height="5">
                </td>
            </tr>--%>
            <tr>
                <td class="frm-lft-clr123">
                    Candidate ID
                </td>
                <td class="frm-rght-clr123" width="25%">
                    <asp:DropDownList ID="ddl_candidateID" runat="server" CssClass="blue1" Width="142px"
                        Height="20px">
                    </asp:DropDownList>
                </td>
            </tr>
            <%--<tr>
                <td colspan="2" height="5">
                </td>
            </tr>--%>
            <tr>
                <td class="frm-lft-clr123">
                    Login ID
                </td>
                <td class="frm-rght-clr123" width="25%">
                    <asp:TextBox ID="txt_loginID" runat="server" CssClass="blue1" MaxLength="200" Width="142px"></asp:TextBox>
                </td>
            </tr>
           <%-- <tr>
                <td colspan="2" height="5">
                </td>
            </tr>--%>
            <tr>
                <td class="frm-lft-clr123 border-bottom">
                    Password
                </td>
                <td class="frm-rght-clr123 border-bottom">
                    <asp:TextBox ID="txt_password" runat="server" CssClass="blue1" TextMode="Password" MaxLength="200"
                        Width="142px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" height="5">
                </td>
            </tr>
            <tr>
                <td colspan="2" width="100%"   align="center">
                    <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="button" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
