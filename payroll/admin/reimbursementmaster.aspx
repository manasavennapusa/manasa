<%@ Page Language="C#" AutoEventWireup="true" CodeFile="reimbursementmaster.aspx.cs"
    Inherits="payroll_admin_reimbursementmaster" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                <tr>
                                                    <td valign="top">
                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                            <tr>
                                                                <td class="blue-brdr-1" valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                                        <tr>
                                                                            <%--    <td width="3%">
                                                    <img height="16" src="../../images/employee-icon.jpg" width="16" />
                                                </td>--%>
                                                                            <%--    <td class="txt01">Reimbursement Master
                                                </td>--%>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" height="5"></td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" height="20">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="txt02" width="27%">Create Reimbursement
                                                                            </td>
                                                                            <td class="txt-red" align="right" width="73%">
                                                                                <span id="message" runat="server"></span>&nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 123px" valign="top">
                                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="25%">Name <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="75%">
                                                                                <asp:TextBox ID="txt_name" runat="server" ToolTip="Reimbursement Name" CssClass="span4"
                                                                                    size="40" OnTextChanged="txt_name_TextChanged" AutoPostBack="True"
                                                                                    onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ToolTip="Enter Reimbursement Name"
                                                                                    Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ControlToValidate="txt_name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="rg" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="25%">Alias Name <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="75%">
                                                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="span4"
                                                                                    onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ToolTip="Enter Alias Name"
                                                                                    Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ControlToValidate="txt_alias"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_alias"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
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
                                                                        <%--<tr>
              <td height="5" colspan="2"></td>
            </tr>
        <tr>
        <td class="frm-lft-clr123" width="25%">Pay head type</td>
        <td class="frm-rght-clr123" width="75%">
        <asp:DropDownList id="dd_payheadtype" runat="server" CssClass="span4" ValidationGroup="v" Width="100px">
                   <asp:ListItem Value="0" Selected="True">Earnings</asp:ListItem>
                      <asp:ListItem Value="1">Deductions</asp:ListItem>
                      <asp:ListItem Value="2">N/A</asp:ListItem>
                      </asp:DropDownList> 
                      </td>
                      </tr>--%>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" width="25%">Name in Pay Slip <span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" width="75%">
                                                                                <asp:TextBox ID="txt_payslip" runat="server" CssClass="span4"
                                                                                    onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ToolTip="Enter name to display in payslip"
                                                                                    Display="Dynamic" ValidationGroup="v" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ControlToValidate="txt_payslip"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_payslip"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Max. Reimbursement  <span class="star"></span>
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
                                                                            <td class="frm-lft-clr123 border-bottom" width="25%">&nbsp;
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" width="75%">
                                                                                <asp:Button ID="btnsbmit" OnClick="btnsbmit_Click" runat="server" ToolTip="Click to submit the created Reimbursement"
                                                                                    CssClass="button" ValidationGroup="v" Text="Submit"></asp:Button>&nbsp;
                                                <asp:Button ID="btn_reset" OnClick="btn_reset_Click" runat="server" CssClass="button"
                                                    Text="Reset"></asp:Button>
                                                                            </td>
                                                                        </tr>
                                                                        <%--                  <tr>
                                                <td align="left" colspan="2">Mandatory Fields (<img alt="" src="../../images/error1.gif" />)
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
