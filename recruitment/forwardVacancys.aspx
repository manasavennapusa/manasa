<%@ Page Language="C#" AutoEventWireup="true" CodeFile="forwardVacancys.aspx.cs"
    Inherits="recruitment_forwardVacancys" %>

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
                                <td class="txt01">CRITERIA FOR VACANCY POSTING ON INTRANET BY HR
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
                    <td class="frm-lft-clr123" width="40%">From Date
                    </td>
                    <td class="frm-rght-clr123" width="60%">
                        <asp:TextBox ID="txt_fromdate" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&#160;
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/images/clndr.gif" />
                        <cc1:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="Image4"
                            TargetControlID="txt_fromdate" Enabled="True">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
               <%-- <tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123">To Date
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:TextBox ID="txt_todate" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>&#160;
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                            TargetControlID="txt_todate" Enabled="True">
                        </cc1:CalendarExtender>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123">Location Of Vacancy
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:DropDownList ID="ddl_location" runat="server" CssClass="blue1" Width="142px"
                            Height="20px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123">Department Of Vacancy
                    </td>
                    <td class="frm-rght-clr123">
                        <asp:DropDownList ID="ddl_department" runat="server" CssClass="blue1" Width="142px"
                            Height="20px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
                    <td colspan="2" height="5"></td>
                </tr>--%>
                <tr>
                    <td class="frm-lft-clr123 border-bottom">Raiser Of Vacancy
                    </td>
                    <td class="frm-rght-clr123 border-bottom">
                        <asp:DropDownList ID="ddl_raiser" runat="server" CssClass="blue1" Width="142px"
                            Height="20px">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td colspan="2" height="5"></td>
                </tr>
                <tr>
                    <td  colspan="2" align="center">
                        <asp:Button ID="btn_Sumbit" runat="server" Text="Submit" CssClass="button" OnClick="btn_Sumbit_Click" />
                        &nbsp;
                    <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="button" OnClick="btn_clear_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
