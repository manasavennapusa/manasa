<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schedularCriteria.aspx.cs"
    Inherits="recruitment_schedularCriteria" %>

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
                                <td class="txt01">CRITERIA FOR RECRUITMENT SCHEDULAR
                                </td>
                                <td align="right">
                                    <span id="message" runat="server" class="txt-red" enableviewstate="false"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Select RRF
                    </td>
                    <td class="frm-rght-clr123" width="70%">
                        <asp:DropDownList ID="ddl_rrf" runat="server" CssClass="blue1" Width="142px" Height="20px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123" width="30%">Select Type
                    </td>
                    <td class="frm-rght-clr123" width="70%">
                        <asp:RadioButtonList ID="rbtnltype" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Group</asp:ListItem>
                            <asp:ListItem>Individual</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td class="frm-lft-clr123 border-bottom">Select Scheme
                    </td>
                    <td class="frm-rght-clr123 border-bottom" width="25%">
                        <asp:DropDownList ID="ddl_schema" runat="server" CssClass="blue1" Width="142px" Height="20px">
                        </asp:DropDownList>
                    </td>

                </tr>

                <tr>
                    <td colspan="2" height="5"></td>
                </tr>

                <tr>
                    <td colspan="4" height="5"></td>
                </tr>
                <tr>
                    <td colspan="4" width="100%" class="frm-rght-clr123 ">
                        <table width="100%" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td align="center">
                                    <asp:Button ID="btnsave" runat="server" Text="Save" CssClass="button" />&nbsp;
                                <asp:Button ID="btnclear" runat="server" Text="Clear" CssClass="button" />&nbsp;
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
