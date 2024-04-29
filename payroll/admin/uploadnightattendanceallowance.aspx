<%@ Page Language="C#" AutoEventWireup="true" CodeFile="uploadnightattendanceallowance.aspx.cs"
    Inherits="payroll_admin_uploadnightattendanceallowance" %>

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
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" height="463px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%" style="height: 16px">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01" style="height: 16px">
                                        Compute Allowances
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 5px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" width="14%">
                                        Financial Year
                                    </td>
                                    <td class="frm-rght-clr123" width="10%">
                                        <asp:Label ID="lbl_fyear" runat="server" Text="Label"></asp:Label>&nbsp;
                                    </td>
                                    <td class="frm-lft-clr123" width="14%">
                                        Month
                                    </td>
                                    <td class="frm-rght-clr123" colspan="3">
                                        <asp:DropDownList ID="dd_month" runat="server" CssClass="blue1" DataTextField="month "
                                            DataValueField="month " ToolTip="Month" Width="145px" AutoPostBack="True" OnSelectedIndexChanged="dd_month_SelectedIndexChanged">
                                            <asp:ListItem Value="1">Jan</asp:ListItem>
                                            <asp:ListItem Value="2">Feb</asp:ListItem>
                                            <asp:ListItem Value="3">Mar</asp:ListItem>
                                            <asp:ListItem Value="4">Apr</asp:ListItem>
                                            <asp:ListItem Value="5">May</asp:ListItem>
                                            <asp:ListItem Value="6">Jun</asp:ListItem>
                                            <asp:ListItem Value="7">Jul</asp:ListItem>
                                            <asp:ListItem Value="8">Aug</asp:ListItem>
                                            <asp:ListItem Value="9">Sep</asp:ListItem>
                                            <asp:ListItem Value="10">Oct</asp:ListItem>
                                            <asp:ListItem Value="11">Nov</asp:ListItem>
                                            <asp:ListItem Value="12">Dec</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="reqPayHead" runat="server" ControlToValidate="dd_month"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                            ToolTip="Select Month" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123 border-bottom" width="14%">
                                        Allowance
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom" width="15%">
                                        <asp:DropDownList ID="drpPayHead" runat="server" CssClass="blue1" ToolTip="Pay Head"
                                            Width="145px" OnDataBound="drpPayHead_DataBound" AutoPostBack="True" OnSelectedIndexChanged="drpPayHead_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator111" runat="server" ControlToValidate="drpPayHead"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                            Operator="NotEqual" ValueToCompare="0" ToolTip="Select Financial Year" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:CompareValidator>
                                    </td>
                                    <td class="frm-lft-clr123 border-bottom" width="14%%">
                                        Branch
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom" colspan="3" width="20%">
                                        <asp:DropDownList ID="drp_comp_name" runat="server" CssClass="blue1" DataSourceID="SqlDataSource1"
                                            DataTextField="branch_name" DataValueField="Branch_Id" Height="20px" OnDataBound="drp_comp_name_DataBound"
                                            Width="145px">
                                        </asp:DropDownList>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="drp_comp_name"
                                            ErrorMessage="CompareValidator" Operator="NotEqual" ToolTip="Select Branch Name"
                                            ValidationGroup="v" ValueToCompare="0"><img src="../../images/../images/error1.gif" alt="" /></asp:CompareValidator>
                                        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:intranetConnectionString %>"
                                            ProviderName="System.Data.SqlClient" SelectCommand="SELECT [Branch_Id], [branch_name] FROM [tbl_intranet_branch_detail]">
                                        </asp:SqlDataSource>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr id="tramount" visible="false" runat="server">
                                    <td class="frm-lft-clr123 border-bottom" width="14%">
                                        Amount
                                    </td>
                                    <td colspan="5" class="frm-rght-clr123 border-bottom" width="15%">
                                        <asp:TextBox ID="txtamount" runat="server" CssClass="blue1">0</asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtamount"
                                            Display="Dynamic" ErrorMessage='<img src="../../images/../images/error1.gif" alt="" />'
                                            MaximumValue="1000000" MinimumValue="0" Type="Double" ValidationGroup="v"></asp:RangeValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="5" align="right" valign="top">
                            &nbsp;<asp:Button ID="btn_view" runat="server" CssClass="button" OnClick="btn_view_Click"
                                Text="Excel" ValidationGroup="v" />&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td height="5" valign="top">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
