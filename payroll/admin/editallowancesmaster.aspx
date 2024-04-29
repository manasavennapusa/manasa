<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editallowancesmaster.aspx.cs"
    Inherits="payroll_admin_editallowancesmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
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
                                    <td valign="bottom" align="center" class="txt01">Please Wait...
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ProgressTemplate>
                </asp:UpdateProgress>
                <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td valign="top" class="blue-brdr-1">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <%--        <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                                                            <%--<td class="txt01">Allowances Master
                                                </td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" valign="top"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="27%" class="txt02">Update Allowances Details
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
                                                                            <td width="25%" class="frm-lft-clr123">Name <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_name" size="40" CssClass="span4" runat="server" ToolTip="Allowance Name"
                                                                                    onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                                                    Display="Dynamic" ToolTip="Enter Allowance Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="rg" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Alias Name  <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="span4" ToolTip="Alias Name"
                                                                                    onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter Alias Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_alias"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="25%">Fixed/Variable
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="75%">
                                                                                <asp:DropDownList ID="drp_type" runat="server" CssClass="span4">
                                                                                    <asp:ListItem Value="2">Fixed</asp:ListItem>
                                                                                    <asp:ListItem Value="3">Variable</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="2" class="frm-lft-clr123" width="100%">Select Grade
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-rght-clr123" colspan="2">
                                                                                <table width="100%">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:LinkButton ID="lnkcheckall" OnClick="lnkcheckall_Click" runat="server" CssClass="txt-red">Check All</asp:LinkButton>
                                                                                            |
                                                            <asp:LinkButton ID="lnkuncheckall" runat="server" CssClass="txt-red" OnClick="lnkuncheckall_Click">Uncheck All</asp:LinkButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:CheckBoxList ID="chkgrade" runat="server" CellPadding="10" CellSpacing="10"
                                                                                                RepeatColumns="8">
                                                                                            </asp:CheckBoxList>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Pay Head type
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="dd_payheadtype" runat="server" CssClass="span4" ValidationGroup="v"
                                                                                    Width="" ToolTip="Select Payhead Type">
                                                                                    <asp:ListItem Value="0" Selected="True">Earnings</asp:ListItem>
                                                                                    <asp:ListItem Value="1">Deductions</asp:ListItem>
                                                                                    <asp:ListItem Value="2">N/A</asp:ListItem>
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Appear in Pay Slip
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:RadioButton ID="opt_apper_yes" runat="server" GroupName="b" Text="Yes" AutoPostBack="True"
                                                                                    OnCheckedChanged="opt_apper_yes_CheckedChanged" />
                                                                                <asp:RadioButton ID="opt_apper_no" runat="server" GroupName="b" Text="No" AutoPostBack="True"
                                                                                    OnCheckedChanged="opt_apper_no_CheckedChanged" />
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Name in Pay Slip  <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_payslip" runat="server" CssClass="span4" ToolTip="Enter Name in Payslip"
                                                                                    onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvpayslip" runat="server" ControlToValidate="txt_payslip"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter name to display in payslip" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_payslip"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Tax Rebate  <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_taxrebate" runat="server" CssClass="span4" ToolTip="Enter Tax Rebate" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvtaxrebate" runat="server" ControlToValidate="txt_taxrebate"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter name to display in payslip" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                                                    ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_taxrebate" ToolTip="only enter numbers"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                                                    ValidationGroup="v" ToolTip="Click to submit the edited details" />&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Cancel" OnClick="btn_reset_Click"
                                                    ToolTip="Click to cancel the updation" />
                                                                            </td>
                                                                        </tr>
                                                                        <%--      <tr>
                                                <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                </td>
                                            </tr>--%>
                                                                    </table>
                                                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top">&nbsp;
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </fieldset>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
