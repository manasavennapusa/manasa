<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_employee_arrear_salary_detail.aspx.cs" Inherits="payroll_admin_view_employee_arrear_salary_detail" %>

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
                <td valign="top" style="height: 451px">

                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td valign="top" class="blue-brdr-1">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="3%">
                                            <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                        <td class="txt01">View Employee Salary Arrear Detail</td>
                                        <td align="right">
                                            <input type="button" id="Button1" class="button" value="Back" onclick="javascript: history.go(-1);" /></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td height="5" valign="top"></td>
                        </tr>
                        <tr>
                            <td height="22" valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="29%" class="txt02">View Employee Salary Arrear</td>
                                        <td width="71%" class="txt-red"><span id="message" runat="server"></span>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <tr>
                            <td valign="top">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="22%" class="frm-lft-clr123">Arrear Reference No.</td>
                                        <td width="24%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_ref" runat="server"></asp:Label>&nbsp;</td>
                                        <td width="1%" rowspan="5"></td>
                                        <td width="21%" class="frm-lft-clr123">Status</td>
                                        <td width="32%" class="frm-rght-clr123">
                                            <asp:Label ID="lbl_status" runat="server" Font-Bold="true"></asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="5"></td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Employee Code</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_empcode" runat="server"></asp:Label>&nbsp;</td>
                                        <td class="frm-lft-clr123">Employee Name</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_empname" runat="server"></asp:Label>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td height="5" colspan="5"></td>
                                    </tr>
                                    <tr>
                                        <td class="frm-lft-clr123">Arrear Amount</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_amnt" runat="server"></asp:Label>&nbsp;</td>
                                        <td class="frm-lft-clr123">Arrear Detail</td>
                                        <td class="frm-rght-clr123">
                                            <asp:Label ID="lbl_detail" runat="server"></asp:Label>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td valign="middle" class="txt02">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td height="23" valign="bottom">Dispersement Detail</td>
                                    </tr>
                                    <tr>
                                        <td height="10"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div style="overflow-x: hidden; overflow-y: auto; height: 130px; width: 100%;">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="head-2">
                                                            <asp:GridView ID="griddetail" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="There is no paid Loan/Advances" AllowPaging="True" PageSize="30">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="Month">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("month") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Year">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("year") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Amount">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("pamount") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>

                                                                    <asp:TemplateField HeaderText="Status">
                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                        <ItemStyle Width="25%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("dstatus") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                <RowStyle Height="5px" />
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                </table>

                            </td>
                        </tr>
                        <tr>
                            <td valign="top">&nbsp;</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <input type="button" id="Button3" class="button" value="Back" onclick="javascript: history.go(-1);" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
