<%@ Page Language="C#" AutoEventWireup="true" CodeFile="costcenteredit.aspx.cs" Inherits="admin_costcenteredit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css" media="all">
        @import "../css/blue1.css";
        @import "../css/example.css";
        .star:before {
            content:" *";
        }
    </style>
    <script type="text/javascript" src="../js/JavaScriptValidations.js"></script>

<link href="../css/blue1.css" rel="stylesheet" /></head>
<body>
    <div class="header">
        <form id="cmaster" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                            runat="server">
                            <ProgressTemplate>
                                <div class="divajax">
                                    <table width="100%">
                                        <tr>
                                            <td align="center" valign="top">
                                                <img src="../images/loading.gif" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="bottom" align="center" class="txt01" height="23">Please Wait...
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <div>
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tbody>
                                    <tr>
                                        <td valign="top" class="blue-brdr-1" colspan="2">
                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                  <%--  <td width="3%">
                                                        <img src="../images/employee-icon.jpg" width="16" height="16" />
                                                    </td>--%>
                                                    <td class="txt01">Edit Cost Center
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="message" runat="server" CssClass="txt-red"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td height="5"></td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">Cost Center Group <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <asp:DropDownList ID="ddlCostCenterGroup" runat="server" CssClass="blue1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlCostCenterGroup"
                                                InitialValue="0" Display="Dynamic" SetFocusOnError="True" ToolTip="Select cost center Group"
                                                ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                      
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">Cost Center Code <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                            <asp:TextBox ID="txtCostCenterCode" runat="server" CssClass="blue1" onkeypress="return isNumber()"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCostCenterCode"
                                                Display="Dynamic" SetFocusOnError="True" ToolTip="Enter cost center code" ValidationGroup="cc"
                                                Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtCostCenterCode"
                                                ValidationGroup="cc" runat="server" ValidationExpression="^[0-9]+$" ToolTip="Enter only numbers"
                                                ErrorMessage='<img src="../img/error1.gif" alt=""  />'></asp:RegularExpressionValidator>
                                        </td>
                                                </tr>
                                              
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">Cost Center Name <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <asp:TextBox ID="txtCostCentrName" runat="server" CssClass="blue1" ></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtCostCentrName"
                                                            Display="Dynamic" SetFocusOnError="True" ToolTip="Enter cost center name" ValidationGroup="cc"
                                                            Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">Country
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <asp:DropDownList ID="ddlCostCenterCountry" runat="server" CssClass="blue1" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlCostCenterCountry_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCostCenterCountry"
                                                            InitialValue="0" Display="Dynamic" SetFocusOnError="True" ToolTip="Select Country"
                                                            ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                               
                                                <tr>
                                                    <td class="frm-lft-clr123" width="40%">State <span class="star"></span>
                                                    </td>
                                                    <td class="frm-rght-clr123" width="60%">
                                                        <asp:DropDownList ID="ddlCostCenterState" runat="server" CssClass="blue1" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlCostCenterState_SelectedIndexChanged1">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlCostCenterState"
                                                            InitialValue="0" Display="Dynamic" SetFocusOnError="True" ToolTip="Select State"
                                                            ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    </td>
                                        </td>
                                    </tr>
                                    
                                    <tr>
                                        <td class="frm-lft-clr123" width="40%">City <span class="star"></span>
                                        </td>
                                        <td class="frm-rght-clr123" width="60%">
                                            <asp:DropDownList ID="ddlCostCenterCity" runat="server"  CssClass="blue1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlCostCenterCity"
                                                InitialValue="0" Display="Dynamic" SetFocusOnError="True" ToolTip="Select City"
                                                ValidationGroup="cc" Width="6px"><img src="../img/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td class="frm-lft-clr123 border-bottom" width="40%">Location <span class="star"></span>
                                        </td>
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
                                        <td width="20%" style="padding-top: 20px"><%--Mandatory Fields (<img src="../img/error1.gif" alt="" />)--%>
                                        </td>
                                        <td style="padding-top: 20px" align="right" width="80%">
                                            <asp:Button ID="btnEditCostCenter" runat="server" CssClass="button" Text="Update"
                                                ValidationGroup="cc" OnClick="btnEditCostCenter_Click" />&nbsp
                                        <%--&nbsp
                <asp:Button ID="btnCostcentReset" runat="server" CssClass="button" Text="Reset" />--%>
                                        </td>
                                    </tr>
                            </table>
                            </tbody> </table>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </form>
    </div>
</body>
</html>
