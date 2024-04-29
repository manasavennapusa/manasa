<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selfRegistration.aspx.cs"
    Inherits="recruitment_selfRegistration" %>

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
                    <td valign="top" class="blue-brdr-1" colspan="4">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="3%">
                                    <img src="../images/employee-icon.jpg" width="16" height="16" />
                                </td>
                                <td class="txt01">SELF REGISTRATION
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="frm-lft-clr123">Rules for Applying
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="txt_rules" runat="server" CssClass="blue1" Width="200px" Height="50"
                                        TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td height="5" colspan="2"></td>
                            </tr>--%>
                            <tr>
                                <td class="frm-lft-clr123">Reasons for Applying
                                </td>
                                <td class="frm-rght-clr123">
                                    <asp:TextBox ID="txt_reasons" runat="server" CssClass="blue1" Height="50" TextMode="MultiLine"
                                        Width="200px"></asp:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td height="5" colspan="2"></td>
                            </tr>--%>
                            <tr>
                                <td class="frm-lft-clr123 border-bottom">Resume (word format)
                                </td>
                                <td class="frm-rght-clr123 border-bottom">
                                    <asp:FileUpload ID="fpResume" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td height="5" colspan="2"></td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">Mandatory Fields (<img alt="" src="../images/error1.gif" />)&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                                <asp:Button ID="btnApply" runat="server" Text="Apply" CssClass="button" />&nbsp;
                                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="button" />&nbsp;
                                <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="button" />
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
