<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sanction_bonus.aspx.cs" Inherits="payroll_admin_sanction_bonus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
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
                                                    Sanction Bonus
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
                                                    Bonus Details
                                                </td>
                                                <td width="71%" align="right" class="txt-red">
                                                    <span id="message" runat="server"></span>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" colspan="2">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
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
                                                            <td width="45%">
                                                                <a href="JavaScript:newPopup1('../../leave/admin/pickemployee.aspx');" class="link05">
                                                                    Pick Employee</a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Bonus
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:DropDownList ID="dd_bonus" runat="server" CssClass="blue1" Width="180px" DataSourceID="SqlDataSource1"
                                                        DataTextField="PAYHEAD_NAME" DataValueField="id" AppendDataBoundItems="True">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="dd_bonus"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        Operator="NotEqual" ValueToCompare="0" ToolTip="Enter Loan/Advances Name"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                                        SelectCommand="select [ID],[PAYHEAD_NAME] from tbl_payroll_bonus where status = 1"
                                                        ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Bonus Reference No.
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_remb_ref" runat="server" CssClass="blue1" size="30" ToolTip="Loan Reference ID"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_remb_ref"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter Reference ID"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123" style="height: 33px">
                                                    Bonus Amount
                                                </td>
                                                <td width="75%" class="frm-rght-clr123" style="height: 33px">
                                                    <asp:TextBox ID="txt_remb_amount" runat="server" CssClass="blue1" size="30" ToolTip="Loan Amount"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfvloanamnt" runat="server" ControlToValidate="txt_remb_amount"
                                                        Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                        ToolTip="Enter Amount"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txt_remb_amount"
                                                        ErrorMessage='Enter valid amount' MaximumValue="999999" MinimumValue="0" Type="Currency"
                                                        ValidationGroup="c" Display="Dynamic"></asp:RangeValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Sanction Date
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_sanct" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>
                                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                    <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txt_sanct"
                                                        ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                        ToolTip="Select Sanction Date"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                        TargetControlID="txt_sanct">
                                                    </cc1:CalendarExtender>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    Detail
                                                </td>
                                                <td class="frm-rght-clr123">
                                                    <asp:TextBox ID="txt_detail" runat="server" TextMode="MultiLine" Width="219px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="20" valign="top" colspan="2" align="center">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="29%" class="txt02" align="left">
                                                                Dispersement Detail
                                                            </td>
                                                            <td width="71%" align="right" class="txt-red">
                                                                <span id="Span1" runat="server"></span>&nbsp;
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10" valign="top" colspan="2" class="head-2">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="25%" class="frm-lft-clr123">
                                                                Month
                                                            </td>
                                                            <td width="25%" class="frm-lft-clr123">
                                                                Year
                                                            </td>
                                                            <td width="30%" class="frm-lft-clr123">
                                                                Amount
                                                            </td>
                                                            <td width="20%" class="frm-lft-clr123">
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-rght-clr1234">
                                                                <asp:DropDownList ID="dd_month" runat="server" CssClass="select1" Width="120px">
                                                                </asp:DropDownList>
                                                                <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="dd_month"
                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                    Operator="NotEqual" ToolTip="Select Leave Name" ValueToCompare="0" ValidationGroup="c"></asp:CompareValidator>
                                                            </td>
                                                            <td class="frm-rght-clr1234">
                                                                <asp:DropDownList ID="dd_year" runat="server" CssClass="select1" Width="120px">
                                                                </asp:DropDownList>
                                                                &nbsp;
                                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="dd_year"
                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                    Operator="NotEqual" ToolTip="Select year" ValueToCompare="0" ValidationGroup="c"></asp:CompareValidator>&nbsp;
                                                            </td>
                                                            <td class="frm-rght-clr1234">
                                                                <asp:TextBox ID="txt_dispers" runat="server" CssClass="blue1"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_dispers"
                                                                    Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                    ToolTip="Enter amount" ValidationGroup="c"><img src="../../images/error1.gif" alt="Enter amount" /></asp:RequiredFieldValidator>
                                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txt_dispers"
                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' MaximumValue="999999"
                                                                    MinimumValue="0" Type="Currency" ValidationGroup="c" Display="Dynamic"></asp:RangeValidator>
                                                            </td>
                                                            <td align="left" style="height: 20px" class="frm-rght-clr1234">
                                                                <asp:Button ID="btm_add" runat="server" Text="Add" CssClass="button" OnClick="btm_add_Click"
                                                                    ValidationGroup="c" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="10" valign="top" colspan="2" class="head-2">
                                                    <asp:GridView ID="grid_aleave" runat="server" AutoGenerateColumns="False" BorderWidth="0px"
                                                        CellPadding="4" CellSpacing="0" DataKeyNames="month" Font-Names="Arial" Font-Size="11px"
                                                        Width="100%" EmptyDataText="No record found" OnRowDeleting="grid_aleave_RowDeleting"
                                                        CssClass="gvclass" Border="1px solid #ddd">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Month">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="25%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="kck" runat="server" Text='<%# Bind("month")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Year">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="25%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="pck" runat="server" Text='<%# Bind("year")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Amount">
                                                                <HeaderStyle CssClass="frm-lft-clr123" HorizontalAlign="Left" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="30%" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="acl" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField>
                                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                                <ItemStyle CssClass="frm-rght-clr1234" HorizontalAlign="Left" VerticalAlign="Top"
                                                                    Width="20%" />
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="LinkButton2" runat="server" ValidationGroup="noone" CommandName="Delete"
                                                                        CssClass="link05" OnClientClick="return confirm(' Do you want to Delete this record?');">Delete</asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <HeaderStyle CssClass="frm-lft-clr123" />
                                                        <FooterStyle CssClass="frm-lft-clr123" />
                                                        <RowStyle Height="5px" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="5" colspan="2">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="25%" class="frm-lft-clr123">
                                                    &nbsp;
                                                </td>
                                                <td width="75%" class="frm-rght-clr123">
                                                    <asp:Button ID="btnsubmit" runat="server" Text="Submit" CssClass="button" ToolTip="Click to submit Reimbursement Details"
                                                        OnClick="btnsubmit_Click" />&nbsp;
                                                    <asp:Button ID="btnreset" runat="server" CssClass="button" Text="Reset" ToolTip="Click to reset the entered details"
                                                        ValidationGroup="none" OnClick="btnreset_Click" />
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
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnsubmit" />
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
