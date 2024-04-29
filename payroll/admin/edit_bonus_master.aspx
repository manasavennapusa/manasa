<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_bonus_master.aspx.cs"
    Inherits="payroll_admin_edit_bonus_master" %>

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
            <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                runat="server">
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
                                                Bonus Master
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
                                            <td width="33%" class="txt02">
                                                Update Bonus Details
                                            </td>
                                            <td width="67%" align="right" class="txt-red">
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
                                                Name
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_name" size="40" CssClass="blue1" runat="server" ToolTip="Bonus Name"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                    Display="Dynamic" ToolTip="Enter Reimbursement Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Alias name
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="blue1" Width="223px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter Alias Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Pay Head type
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:DropDownList ID="dd_payheadtype" runat="server" CssClass="blue1" ValidationGroup="v"
                                                    Width="100px">
                                                    <asp:ListItem Value="0" Selected="True">Earnings</asp:ListItem>
                                                    <asp:ListItem Value="1">Deductions</asp:ListItem>
                                                    <asp:ListItem Value="2">N/A</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123">
                                                Name in payslip
                                            </td>
                                            <td width="75%" class="frm-rght-clr123">
                                                <asp:TextBox ID="txt_payslip" runat="server" CssClass="blue1" Width="223px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_payslip"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    ToolTip="Enter name to display in namslip" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        
                                        <tr>
                                            <td width="25%" class="frm-lft-clr123 border-bottom">
                                                &nbsp;
                                            </td>
                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ValidationGroup="v" ToolTip="Click to submit the created Bonus" />&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Cancel" OnClick="btn_reset_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" colspan="2">
                                                Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                            </td>
                                        </tr>
                                    </table>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
