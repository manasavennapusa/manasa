<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loanadvancesmaster.aspx.cs"
    Inherits="payroll_admin_loanadvancesmaster" %>

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
                                                                            <%--     <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>--%>
                                                                            <%-- <td class="txt01">Loan/Advances Master
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
                                                                            <td width="27%" class="txt02">Create Loan/Advances Type
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
                                                                                <asp:TextBox ID="txt_name" size="40" CssClass="span4" runat="server" ToolTip="Loan/Advances Name"
                                                                                    AutoPostBack="True" OnTextChanged="txt_name_TextChanged" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                                    ToolTip="Enter Loan/Advances Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="rg" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'>
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Alias Name <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="span4"  ToolTip="Loan/Advances Alias Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter Alias Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_alias"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'>
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Name in Pay Slip <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_payslip" runat="server" CssClass="span4"  ToolTip="Loan/Advances Name in Payslip" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_payslip"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter name to display in payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator
                                                                                    ID="RegularExpressionValidator2"
                                                                                    runat="server"
                                                                                    Display="Dynamic"
                                                                                    ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$"
                                                                                    ControlToValidate="txt_payslip"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' src="../../images/error1.gif" alt=""></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Interest
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_interest" size="40" CssClass="span4" runat="server" ToolTip="Interest applicable on Loan/Advances">0.0</asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_interest"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter name to display in payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_interest"
                                                                                    ErrorMessage="Enter year between 0 and 60" MaximumValue="60" MinimumValue="0"
                                                                                    Type="Double">Enter interest between 0 and 100</asp:RangeValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Interest (@ SBI)
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_taxSBI" size="40" CssClass="span4" runat="server" ToolTip="Interest applicable on Loan/Advances">0.0</asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_taxSBI"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter name to display in payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_taxSBI"
                                                                                    ErrorMessage="Enter year between 0 and 60" MaximumValue="60" MinimumValue="0"
                                                                                    Type="Double">Enter interest between 0 and 100</asp:RangeValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Loan/Advances A/c No. <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_loan_acno" size="40" CssClass="span4" runat="server" ToolTip="Loan/Advances A/c Number" onkeypress="return isAlphaNumeric()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_loan_acno"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                                    ToolTip="Enter Loan/Advances A/c No."><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                                                    ValidationExpression="^[a-zA-Z0-9]+$" ControlToValidate="txt_loan_acno" ToolTip=" enter only alphabets or numbers"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />'>
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>

                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Eligibility Year <span class="star"></span>
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_eligibility_yr" size="40" CssClass="span4" runat="server" ToolTip="Eligibility Year"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_eligibility_yr"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                                    ToolTip="Enter Eligibility Year"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_eligibility_yr"
                                                                                    ErrorMessage="Enter year between 0 and 60" MaximumValue="60" MinimumValue="0"
                                                                                    Type="Double">Enter year between 0 and 60</asp:RangeValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                                                    ToolTip="Click to submit the created Loan/Advances Type" />
                                                                                <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click"
                                                                                    ToolTip="Click to reset the entries" ValidationGroup="none" />
                                                                            </td>
                                                                        </tr>
                                                                        <%--        <tr>
                                                <td align="left" colspan="2">Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                </td>
                                            </tr>--%>
                                                                    </table>
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
