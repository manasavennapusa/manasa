<%@ Page Language="C#" AutoEventWireup="true" CodeFile="editpayheadmaster.aspx.cs"
    Inherits="payroll_admin_editpayheadmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Payhead" runat="server">
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
                                                                    <%--          <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="3%">
                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                </td>
                                                <td class="txt01">Pay Head Master
                                                </td>
                                            </tr>
                                        </table>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" valign="top"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td width="27%" class="txt01">Update Pay Head Details
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
                                                                            <td width="25%" class="frm-lft-clr123">Name
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_name" size="40" CssClass="span4" runat="server" ToolTip="Payhead Name" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"
                                                                                    Display="Dynamic" ToolTip="Enter Payhead Name"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                <asp:RegularExpressionValidator ID="rg" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_name"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
                                                        <img src="../../images/error1.gif" alt="" />
                                                                                </asp:RegularExpressionValidator>
                                                                            </td>
                                                                        </tr>

                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Alias Name
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_alias" runat="server" CssClass="span4" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_alias"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter Alias Name" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_alias"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>

                                                                            </td>
                                                                        </tr>
                                                                        <%--  <tr>
              <td height="5" colspan="2"></td>
            </tr>
            <tr>
              <td width="25%" class="frm-lft-clr123">
                  Under</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:DropDownList ID="dd_under" runat="server" CssClass="span4" ValidationGroup="v" Width="100px">
                      <asp:ListItem Value="0">Select Under</asp:ListItem>
                      <asp:ListItem Value="Assets">Assets</asp:ListItem>
                      <asp:ListItem Value="Liabilities">Liabilities</asp:ListItem>
                  </asp:DropDownList>
                  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_under"
                      Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                      Operator="NotEqual" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator></td>
            </tr>--%>

                                                                        <%--    <tr>
              <td width="25%" class="frm-lft-clr123">
                  Apply slab rate</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:RadioButton ID="opt_apply_slab_yes" runat="server" Checked="True"
                      GroupName="a" Text="Yes" />
                  <asp:RadioButton ID="opt_apply_slab_no" runat="server" GroupName="a"
                      Text="No" /></td>
            </tr>
             <tr>
              <td height="5" colspan="2"></td>
            </tr>--%>
                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123">Pay Head Type
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:DropDownList ID="dd_payheadtype" runat="server" CssClass="span4" ValidationGroup="v"
                                                                                    >
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
                                                                            <td width="25%" class="frm-lft-clr123">Name in Pay Slip
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123">
                                                                                <asp:TextBox ID="txt_payslip" runat="server" CssClass="span4" onkeypress="return isCharOrSpace()"></asp:TextBox>
                                                                                <asp:RequiredFieldValidator ID="rfvpayslip" runat="server" ControlToValidate="txt_payslip"
                                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                                    ToolTip="Enter name to display in payslip" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ToolTip="enter  only alphabets"
                                                                                    ValidationExpression="^[a-zA-Z\s]+$" ControlToValidate="txt_payslip"
                                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>

                                                                            </td>
                                                                        </tr>
                                                                        <%--    <tr>
              <td height="5" colspan="2"></td>
            </tr>
                  <tr>
              <td width="25%" class="frm-lft-clr123">
                  Use for gratuity</td>
              <td width="75%" class="frm-rght-clr123">
                  <asp:RadioButton ID="opt_gratuity_yes" runat="server" Checked="True"
                      GroupName="c" Text="Yes" />
                  <asp:RadioButton ID="opt_gratuity_no" runat="server" GroupName="c"
                      Text="No" /></td>
            </tr>--%>

                                                                        <tr>
                                                                            <td width="25%" class="frm-lft-clr123 border-bottom">&nbsp;
                                                                            </td>
                                                                            <td width="75%" class="frm-rght-clr123 border-bottom">
                                                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                                                    ValidationGroup="v" ToolTip="Click to submit the edited Payhead" />&nbsp;
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Cancel" OnClick="btn_reset_Click" />
                                                                            </td>
                                                                        </tr>
                                                                        <%--  <tr>
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
