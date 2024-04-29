<%@ Page Language="C#" AutoEventWireup="true" CodeFile="costcentergroup.aspx.cs"
    Inherits="admin_costcentergroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>

<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="up1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                    <tbody>
                        <tr>
                            <td valign="top" class="blue-brdr-1" colspan="2">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        
                                        <td class="txt01">
                                            Create Cost Center Group
                                        </td>
                                        <td align="right">
                                            <span id="message" runat="server" class="txt02" enableviewstate="false">&nbsp;</span>
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
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom" width="40%">
                                            Cost Center Group<span class="star"></span>
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="50%">
                                            <asp:TextBox ID="txt_costcentergroup" MaxLength="100" runat="server" CssClass="blue1" onkeypress="return isCharOrSpace()"
                                                Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" Width="6px"
                                                ToolTip="Enter Cost Center Group " ValidationGroup="c" ControlToValidate="txt_costcentergroup"
                                                SetFocusOnError="True" Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_costcentergroup"
                                                            ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </td>
                                        <td align="center" class="frm-rght-clr123 border-bottom" width="10%">
                                            <asp:Button ID="btnAddCostCenterGroup" runat="server" CssClass="button" Text="ADD"
                                                ValidationGroup="c" OnClick="btnAddCostCenterGroup_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" height="10px">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
