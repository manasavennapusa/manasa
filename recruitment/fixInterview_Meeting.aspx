<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fixInterview_Meeting.aspx.cs"
    Inherits="recruitment_fixInterview_Meeting" %>

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
                                <td class="txt01">FIX INTERVIEW
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
                    <td colspan="4">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="100%" colspan="2">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Date Of Interview
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox ID="txt_intdate" runat="server" CssClass="blue1" MaxLength="200" Width="142px"></asp:TextBox>
                                                &nbsp;
                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/images/clndr.gif" />
                                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="Image2"
                                                    TargetControlID="txt_intdate" Enabled="True">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <%--  <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Contact Person
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox runat="server" ID="txt_Address" CssClass="blue1" Width="142px" TextMode="MultiLine"
                                                    Height="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Phone No.
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox ID="txt_phoneno" runat="server" CssClass="blue1" MaxLength="12" Width="142px"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txt_phoneno"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Mobile No.
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox ID="txt_mobileno" runat="server" CssClass="blue1" Width="142px" MaxLength="12"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator14" ControlToValidate="txt_mobileno"
                                                    ValidationGroup="v" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only Numbers"
                                                    ErrorMessage='<img src="../images/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Email
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox ID="txt_email" runat="server" CssClass="blue1" Width="142px" MaxLength="50"></asp:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                                    ValidationGroup="v" ToolTip="Not a Vaild Email ID" SetFocusOnError="True" Display="Dynamic"
                                                    ControlToValidate="txt_email" ErrorMessage='<img src="../images/error1.gif" alt="" />'
                                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Time Of Interview
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox ID="txt_Qualifications" runat="server" CssClass="blue1" Width="142px"
                                                    MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Venue
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox runat="server" ID="TextBox1" CssClass="blue1" Width="142px" TextMode="MultiLine"
                                                    Height="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123" width="48%">Remarks
                                            </td>
                                            <td class="frm-rght-clr123" width="52%">
                                                <asp:TextBox runat="server" ID="TextBox2" CssClass="blue1" Width="142px" TextMode="MultiLine"
                                                    Height="50px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>--%>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="48%">Documents Required
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom" width="52%">
                                                <asp:TextBox ID="txt_notes" runat="server" CssClass="blue1" TextMode="MultiLine"
                                                    Height="50" Width="142px" MaxLength="50"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" colspan="2"></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="left">&nbsp;&nbsp;&nbsp;&nbsp; Mandatory Fields (<img alt="" src="../images/error1.gif" />)
                                </td>
                                <td align="right">
                                    <asp:Button ID="btn_Submit" runat="server" Text="Fix Interview" CssClass="button" ValidationGroup="v" OnClick="btn_Submit_Click" />&nbsp;
                                <asp:Button ID="btn_clear" runat="server" Text="Clear" CssClass="button" OnClick="btn_clear_Click" />
                                </td>
                            </tr>
                            <tr>
                    <td height="5" colspan="2"></td>
                </tr>
                        </table>
                    </td>
                </tr>
                
                <tr>
                    <td align="right" class="frm-rght-clr123">
                        <asp:Button ID="Button1" runat="server" Text="Back" CssClass="button" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
