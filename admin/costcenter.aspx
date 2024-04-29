<%@ Page Language="C#" AutoEventWireup="true" CodeFile="costcenter.aspx.cs" Inherits="admin_costcenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
    </style>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>

    
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                    <tbody>
                        <tr>
                            <td valign="top" class="blue-brdr-1" colspan="2">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                       
                                        <td class="txt01">Create Cost Center
                                        </td>
                                        <td align="right">
                                            <span id="message" runat="server" class="txt02" enableviewstate="false">&nbsp;</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top"></td>
                        </tr>
                        <tr>
                            <td valign="top">
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tr>
                                        <td class="frm-lft-clr123" width="40%">Cost Center Group<span class="star"></span>
                                        </td>
                                        <td class="frm-rght-clr123" width="60%">
                                            <asp:DropDownList ID="ddlCostCenterGroup" runat="server" CssClass="blue1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCostCenterGroup"
                                                InitialValue="0" Display="Dynamic" SetFocusOnError="True" ToolTip="Select cost center Group"
                                                ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td class="frm-lft-clr123" width="40%">Cost Center Code<span class="star"></span>
                                        </td>
                                        <td class="frm-rght-clr123" width="60%">
                                            <asp:TextBox ID="txtCostCenterCode" runat="server" CssClass="blue1" onkeypress="return isNumber()"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCostCenterCode"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter cost center code" ValidationGroup="cc"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtCostCenterCode"
                                                ValidationGroup="cc" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <caption>
                                      
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Cost Center Name <span class="star"></span></td>
                                            <td class="frm-rght-clr123" width="60%">
                                                <asp:TextBox ID="txtCostCentrName" runat="server" CssClass="blue1" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" CssClass="blue1" ControlToValidate="txtCostCentrName" Display="Dynamic" SetFocusOnError="True" ToolTip="Enter cost center Name" ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtCostCentrName"
                                                ValidationGroup="cc" runat="server" ValidationExpression="^[a-zA-Z\s]+$" ToolTip="Enter only alphabets and space"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">Country <span class="star"></span></td>
                                            <td class="frm-rght-clr123" width="60%">
                                                <asp:DropDownList ID="ddlCostCenterCountry" runat="server" CssClass="blue1" AutoPostBack="true" OnSelectedIndexChanged="ddlCostCenterCountry_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCostCenterCountry" Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select Country" ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">State <span class="star"></span></td>
                                            <td class="frm-rght-clr123" width="60%">
                                                <asp:DropDownList ID="ddlCostCenterState" runat="server" CssClass="blue1" AutoPostBack="true" OnSelectedIndexChanged="ddlCostCenterState_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCostCenterState" Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select State" ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123" width="40%">City <span class="star"></span></td>
                                            <td class="frm-rght-clr123" width="60%">
                                                <asp:DropDownList ID="ddlCostCenterCity" runat="server" CssClass="blue1">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCostCenterCity" Display="Dynamic" InitialValue="0" SetFocusOnError="True" ToolTip="Select City" ValidationGroup="cc"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom" width="40%">Location <span class="star"></span></td>
                                            <td class="frm-rght-clr123 border-bottom" width="60%">
                                                <asp:TextBox ID="txtCostCenterLocation" runat="server" CssClass="blue1"  onkeypress="return isAlphaNumeric_slash_infin_dot_Ash()"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCostCenterLocation" Display="Dynamic" SetFocusOnError="True" ToolTip="Select Location" ValidationGroup="cc" ><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator16" ControlToValidate="txtCostCenterLocation"
                                                            ValidationGroup="cc" runat="server" ValidationExpression="^[a-zA-Z0-9\/\-\.\s\#]+$" ToolTip="Enter only alphanumeric space / #  ."
                                                            ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" height="5px"></td>
                                        </tr>
                                        <tr>
                                            
                                            <td align="right" style="padding-top: 20px" width="80%" colspan="2">
                                                <asp:Button ID="btnAddCostCenter" runat="server" CssClass="button" OnClick="btnAddCostCenter_Click" Text="Save" ValidationGroup="cc" />
                                                &nbsp; </td>
                                        </tr>
                                    </caption>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
