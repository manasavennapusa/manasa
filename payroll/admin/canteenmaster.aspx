<%@ Page Language="C#" AutoEventWireup="true" CodeFile="canteenmaster.aspx.cs" Inherits="payroll_admin_canteenmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
    </asp:ScriptManager>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax">
                <table width="100%">
                <tr>
                <td align="center" valign="top"><img src="../../images/loading.gif" /></td>
                </tr>
                <tr>
                <td valign="bottom" align="center" class="txt01">Please Wait...</td>
                </tr>
                </table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
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
                                        Canteen Master
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
                                        Create Canteen
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
                                        Breakfast Cost(Rs)
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:TextBox ID="txtbrkfstcost" size="40" CssClass="blue1" runat="server" Width="146px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtbrkfstcost"
                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                            Display="Dynamic" ToolTip="Enter Breakfast Cost"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Lunch Cost(Rs)
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:TextBox ID="txtlunchcost" runat="server" CssClass="blue1" size="40" Width="146px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlunchcost"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                            Height="3px" ToolTip="Enter Lunch Code" ValidationGroup="v" Width="1px"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123 border-bottom">
                                        &nbsp;
                                    </td>
                                    <td width="75%" class="frm-rght-clr123 border-bottom">
                                        <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                            ValidationGroup="v" ToolTip="Click to submit" />&nbsp;
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
                        <td valign="top" style="height: 14px">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <%--</ContentTemplate> 
</asp:UpdatePanel>--%>
    </form>
</body>
</html>
