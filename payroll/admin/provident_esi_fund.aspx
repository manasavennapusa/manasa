<%@ Page Language="C#" AutoEventWireup="true" CodeFile="provident_esi_fund.aspx.cs"
    Inherits="payroll_admin_provident_esi_fund" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>View Leave Rule</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="dashboard-wrapper" style="margin-left: 0px;">
            <div class="main-container">
                <div class="row-fluid">
                    <div class="span12">
                        <div class="widget">

                            <div class="widget-body">
                                <fieldset>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td valign="top" class="blue-brdr-1">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" class="blue-brdr-1">
                                                            <%-- <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%" style="height: 16px">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                        </td>
                                        <td class="txt01" style="height: 15px" valign="middle">&nbsp; Provident Fund / ESI
                                        </td>
                                    </tr>
                                </table>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" valign="middle" class="txt02">&nbsp;Employee PF Contribution(EPF)
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Effect From Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_formdate" runat="server" CssClass="span4"
                                                                            onkeypress="return isNumber_dot()"></asp:TextBox><asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_emp_percentage"
                                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:Image ID="Image4" runat="server"
                                                                            ImageUrl="~/img/clndr.gif" placeholder="Select Date" />
                                                                        <cc1:calendarextender format="dd-MMM-yyyy"
                                                                            id="CalendarExtender4" runat="server" popupbuttonid="Image4" targetcontrolid="txt_formdate"
                                                                            enabled="True">
                                                                                                    </cc1:calendarextender>


                                                                    </td>
                                                                </tr>

                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Percentage Contribution
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_emp_percentage" runat="server" CssClass="span4"
                                                                            onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                                ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_emp_percentage"
                                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>

                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_emp_percentage" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Maximum Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_emp_max" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_emp_max"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            ToolTip="Amount must lies between 0 to 100000" MaximumValue="100000" MinimumValue="0"
                                                                            Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">Minimum Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:TextBox ID="txt_emp_min" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_emp_min"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            ToolTip="Amount must lies between 0 to 100000" MaximumValue="100000" MinimumValue="0"
                                                                            Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" height="10"></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" valign="middle" class="txt02">&nbsp;Employer PF Contribution
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Employer PF Contribution
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_emr_pfcontri" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_emr_pfcontri"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_emr_pfcontri" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Employer Pension Fund Contribution
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_emprpf" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_emprpf" Display="Dynamic"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_emprpf" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Administrative Charges PF<br />
                                                                        <span class="txt06">(Account No. 02)</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_empr_02" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_empr_02" Display="Dynamic"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator><strong><span
                                                                                style="font-size: 11px; font-family: verdana, Helvetica, sans-serif; background-color: #edf5ff"></span></strong>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_empr_02" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Insurance Fund Contribution<br />
                                                                        <span class="txt06">(Account No. 21)</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_empr_21" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_empr_21" Display="Dynamic"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_empr_21" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom" style="width: 250px">Administrative Charges<br />
                                                                        <span class="txt06">(Account No.22)</span>
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:TextBox ID="txt_empr_22" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator8" runat="server" ControlToValidate="txt_empr_22" Display="Dynamic"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_empr_22" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" height="10"></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" valign="middle" class="txt02">&nbsp;Employee State Insurance
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td class="frm-lft-clr123" style="width: 250px">Employee Contribution
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_esi_emp" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator9" runat="server" ControlToValidate="txt_esi_emp" Display="Dynamic"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_esi_emp" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Employer Contribution
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_esi_emr" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>%<asp:RequiredFieldValidator
                                                                            ID="RequiredFieldValidator10" runat="server" ControlToValidate="txt_esi_emr"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" Display="Dynamic"
                                                                            ValidationExpression="^[0-9\.]+$" ControlToValidate="txt_esi_emr" ToolTip="only enter numbers"
                                                                            ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="">
<img src="../../images/error1.gif" alt="" /></asp:RegularExpressionValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Cutoff Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:TextBox ID="txt_esi_cutoff" runat="server" CssClass="span4" ValidationGroup="" onkeypress="return isNumber_dot()"></asp:TextBox>
                                                                        <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_esi_cutoff"
                                                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                            ToolTip="Amount must lies between 0 to 100000" MaximumValue="100000" MinimumValue="0"
                                                                            Type="Currency"><img src="../../images/error1.gif" alt="" /></asp:RangeValidator>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">&nbsp;
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Button ID="btnsbmit" runat="server" Text="Update" CssClass="button" OnClick="btnsbmit_Click" />&nbsp;
                                        <asp:Button ID="btn_reset" runat="server" CssClass="button" Text="Cancel" OnClick="btn_reset_Click" />
                                                                    </td>
                                                                </tr>
                                                            </table>
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
    </form>
</body>
</html>
