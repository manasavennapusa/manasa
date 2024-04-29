<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_employee_tds_detail.aspx.cs"
    Inherits="payroll_admin_edit_employee_tds_detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

    <script src="../../leave/js/popup.js"></script>

    <script type="text/javascript" language="javascript">

function returnempcode(val,val2)

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="leave" runat="server">
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
                                <td valign="bottom">
                                    Please Wait...
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" colspan="5">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td width="3%">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>
                                            <td id="Td1" class="txt01" runat="server">
                                                Employee Tax Detail
                                            </td>
                                            <td id="Td2" runat="server" align="right" class="txt02">
                                                <asp:Label ID="lbl_message" runat="server" Enabled="true" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5">
                                </td>
                            </tr>
                            <tr>
                                <td valign="top" style="height: 460px">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td class="frm-lft-clr123" width="30%">
                                                Financial Year
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:DropDownList ID="dd_year" runat="server" AutoPostBack="True" CssClass="blue1"
                                                    Width="129px" DataSourceID="SqlDataSource1" DataTextField="financial_year" DataValueField="id">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_year"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=TEAM-PRAMOD\TEAMWORKS;Initial Catalog=intranet;User ID=pramod;Password=teamworks"
                                                    SelectCommand="select id, financial_year from tbl_payroll_tax_master"></asp:SqlDataSource>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Month
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:DropDownList ID="dd_month" runat="server" CssClass="blue1" AutoPostBack="True"
                                                    Width="127px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_month"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                    Operator="NotEqual" ValueToCompare="0"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Pick Employee
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:Label ID="lbl_emp" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                TDS Amount
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_tds_amnt" runat="server" CssClass="blue1" Width="118px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_tds_amnt"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_tds_amnt"
                                                    Display="Dynamic" ErrorMessage="Enter a valid amount" MaximumValue="9999999999"
                                                    MinimumValue="0" Type="Currency"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Surcharge
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_srchrg" runat="server" CssClass="blue1" Width="118px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txt_srchrg"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_srchrg"
                                                    Display="Dynamic" ErrorMessage="Enter a valid amount" MaximumValue="9999999999"
                                                    MinimumValue="0" Type="Currency"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Education Cess
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_education_cess" runat="server" CssClass="blue1" Width="118px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txt_education_cess"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                <asp:RangeValidator ID="RangeValidator3" runat="server" ControlToValidate="txt_education_cess"
                                                    Display="Dynamic" ErrorMessage="Enter a valid amount" MaximumValue="9999999999"
                                                    MinimumValue="0" Type="Currency"></asp:RangeValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Cheque/DD Number
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_chk_no" runat="server" CssClass="blue1" Width="118px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                BSR Code of Bank Branch
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_bsr" runat="server" CssClass="blue1" Width="118px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_bsr"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Tax Deposite Date
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_deposite" runat="server" CssClass="blue1" Width="93px"></asp:TextBox>
                                                <asp:Image ID="img_t" runat="server" ImageUrl="~/leave/images/clndr.gif" />
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txt_deposite"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'></asp:RequiredFieldValidator>
                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="img_t"
                                                    TargetControlID="txt_deposite">
                                                </cc1:CalendarExtender>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123">
                                                Transfer Voucher Number
                                            </td>
                                            <td class="frm-rght-clr123" colspan="2">
                                                <asp:TextBox ID="txt_transfer_boucher" runat="server" CssClass="blue1" Width="118px"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_transfer_boucher"
                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="frm-lft-clr123 border-bottom">
                                                &nbsp;
                                            </td>
                                            <td class="frm-rght-clr123 border-bottom">
                                                <asp:Button ID="btnsbmit" runat="server" Text="Submit" CssClass="button" OnClick="btnsbmit_Click"
                                                    ToolTip="Click to submit the Employee Pay Master Details" />
                                                <asp:Button ID="btn_reset" runat="server" CssClass="button" OnClick="btn_reset_Click"
                                                    Text="Reset" ValidationGroup="a" />
                                            </td>
                                        </tr>
                                    </table>
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
