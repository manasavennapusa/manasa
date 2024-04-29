<%@ Page Language="C#" AutoEventWireup="true" CodeFile="bonusmaster.aspx.cs" Inherits="payroll_admin_bonusmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="payroll" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="1" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate>
                    <div class="divajax">
                        <table width="100%">
                            <tr>
                                <td align="center" valign="top">
                                    <img src="../../images/loading.gif" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="bottom" align="center" class="txt01">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                <tbody>
                    <tr>
                        <td valign="top">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td class="blue-brdr-1" valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td width="3%">
                                                            <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                        </td>
                                                        <td class="txt01">
                                                            Bonus Master
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="5">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top" height="20">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="txt02" width="27%">
                                                            Create Bonus
                                                        </td>
                                                        <td class="txt-red" align="right" width="73%">
                                                            <span id="message" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 123px" valign="top">
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Name
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:TextBox ID="txt_name" runat="server" ToolTip="Bonus Name" CssClass="blue1" size="40"
                                                                AutoPostBack="True" OnTextChanged="txt_name_TextChanged"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ToolTip="Enter Reimbursement Name"
                                                                Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                ControlToValidate="txt_name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Alias name
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:TextBox ID="txt_alias" runat="server" CssClass="blue1" Width="223px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ToolTip="Enter Alias Name"
                                                                Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                ControlToValidate="txt_alias"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                   
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Pay Head Type
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:DropDownList ID="dd_payheadtype" runat="server" CssClass="blue1" ValidationGroup="v"
                                                                Width="100px">
                                                                <asp:ListItem Value="0" Selected="True">Earnings</asp:ListItem>
                                                                <asp:ListItem Value="1">Deductions</asp:ListItem>
                                                                <asp:ListItem Value="2">N/A</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    
                                                    <tr>
                                                        <td class="frm-lft-clr123" width="25%">
                                                            Name in payslip
                                                        </td>
                                                        <td class="frm-rght-clr123" width="75%">
                                                            <asp:TextBox ID="txt_payslip" runat="server" CssClass="blue1" Width="223px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ToolTip="Enter name to display in payslip"
                                                                Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                ControlToValidate="txt_payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td class="frm-lft-clr123 border-bottom" width="25%">
                                                            &nbsp;
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="75%">
                                                            <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" ToolTip="Click to submit the created Bonus"
                                                                CssClass="button" ValidationGroup="v" Text="Submit"></asp:Button>&nbsp;
                                                            <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="button"
                                                                Text="Reset"></asp:Button>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
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
