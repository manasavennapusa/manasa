<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editcostcentergroup.aspx.cs"
    Inherits="admin_editcostcentergroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Admin Panel</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>

    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>

    <script type="text/javascript">
        document.write('<style type="text/css">.tabber{display:none;}<\/style>');
    </script>

</head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div>
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                <tbody>
                    <tr>
                        <td valign="top" class="blue-brdr-1" colspan="2">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    
                                    <td class="txt01">
                                        Edit Cost Center Group
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
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="frm-lft-clr123" width="23%">
                                            Cost Center Group Name<span class="star"></span>
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom" width="50%">
                                            <asp:TextBox ID="txt_Cost_Center_Group" MaxLength="100" runat="server" CssClass="blue1" onkeypress="return isCharOrSpace()"
                                                Width="200px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" Width="6px"
                                                ToolTip="Enter Cost Center Group " ValidationGroup="c" ControlToValidate="txt_Cost_Center_Group"
                                                SetFocusOnError="True" Display="Dynamic"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                             <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txt_Cost_Center_Group"
                                                            ValidationGroup="c" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom">
                                            &nbsp;
                                        </td>
                                        <td class="frm-rght-clr123 border-bottom">
                                            <asp:Button ID="btnsv" runat="server" Text="Save" CssClass="button" 
                                                ValidationGroup="c" onclick="btnsv_Click"
                                                ></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        </form>
    </div>
</body>
</html>
