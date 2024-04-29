<%@ Page Language="C#" AutoEventWireup="true" CodeFile="employee_tds.aspx.cs" Inherits="payroll_admin_employee_tds" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        .pop2
        {
            position: absolute;
            background-color: #fff;
            z-index: 1002;
            overflow: auto;
            padding: 0px;
            left: 135px;
            top: 48%;
            width: 500px;
        }
    </style>

    <script src="../../leave/js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="payroll" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:UpdateProgress ID="UpdateProgress1" runat="server">
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
            <div id="divapply">
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
                                                    Employee TDS
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
                                                <td width="29%" class="txt02">
                                                    TDS Details
                                                </td>
                                                <td width="71%" align="right" class="txt-red">
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
                                                <td width="30%" class="frm-lft-clr123">
                                                    Employee Code
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <table width="100%" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="30%">
                                                                <asp:TextBox ID="txt_employee" size="30" CssClass="blue1" runat="server" ToolTip="Employee Code"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="rfvempcode" runat="server" ControlToValidate="txt_employee"
                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                    ToolTip="Select Employee Code"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td width="40%">
                                                                <a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">
                                                                    Pick Employee</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Month
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="dd_month" runat="server" CssClass="blue1" Width="90px">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Month"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Year
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:DropDownList ID="dd_year" runat="server" CssClass="blue1" Width="90px">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_year"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Select Year"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123">
                                                    Amount
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_amnt" runat="server" CssClass="blue1" size="30"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_amnt"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter Interest Amount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="frm-lft-clr123 border-bottom">
                                                    &nbsp;
                                                </td>
                                                <td class="frm-rght-clr123 border-bottom">
                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsubmit_Click"
                                                        ToolTip="Click to submit the TDS Details" />&nbsp;
                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" OnClick="btnreset_Click"
                                                        ToolTip="Click to reset the entered details" ValidationGroup="none" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" colspan="2">
                                                    Mandatory Fields (<img src="../../images/error1.gif" alt="" />)
                                                </td>
                                            </tr>
                                        </table>
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
