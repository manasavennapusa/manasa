<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FullAndFinal.aspx.cs" Inherits="payroll_admin_FullAndFinal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Full and Final Settlement</title>
    <link href="../../css/default.css" rel="stylesheet" type="text/css" />
    <link href="../../css/tabcontent.css" rel="stylesheet" type="text/css" />
    <link href="../../css/home.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form name="form1" id="form1" runat="server">
        <div style="border: #CCCCCC 5px solid; padding: 5px 5px 5px 5px;" class="black-normal-bold">
            <table width="100%" border="0" cellspacing="1" cellpadding="1">
                <tr>
                    <td style="padding-top: 5px; padding-bottom: 10px;">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E9E9E9;">
                            <tr>
                                <td width="39%" style="line-height: 25px; padding-left: 5px;">
                                    <asp:Label ID="lblCompanyName" runat="server"></asp:Label></td>
                                <td width="61%">
                                    Statement Of Full and Final Settlement
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="1" cellspacing="1">
                            <tr>
                                <td width="13%" align="left">
                                    Emp Code &amp; Name
                                </td>
                                <td width="1%" align="center">
                                    :</td>
                                <td width="33%" align="left">
                                    <asp:Label ID="lblEmpCode" runat="server"></asp:Label></td>
                                <td width="9%" align="left">
                                    Branch</td>
                                <td width="1%" align="center">
                                    :</td>
                                <td width="43%" align="left">
                                    <asp:Label ID="lblLocation" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Designation</td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label></td>
                                <td align="left">
                                    Total Days
                                </td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblTotalDays" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    DOJ</td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblDOJ" runat="server"></asp:Label></td>
                                <td align="left">
                                    LWP
                                </td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblWorkedDays" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Settlement Date
                                </td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblStatementasOn" runat="server"></asp:Label></td>
                                <td align="left">
                                    Bank Name
                                </td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblBankName" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td align="left">
                                    Last Working Day
                                </td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblLastWorkingday" runat="server"></asp:Label></td>
                                <td align="left">
                                    Account No.
                                </td>
                                <td align="center">
                                    :</td>
                                <td align="left">
                                    <asp:Label ID="lblAccountName" runat="server"></asp:Label></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td height="22" style="background-color: #E9E9E9; padding-left: 5px;">
                        Settlement detail for the month(s) of (
                        <asp:Label ID="lblMonths" ForeColor="#990000" runat="server"></asp:Label>
                        )</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="48%" valign="top">
                                    <asp:GridView ID="grdItComputation" runat="server" AutoGenerateColumns="False" Width="100%"
                                        OnRowDataBound="grdItComputation_RowDataBound" ShowFooter="True" Style="margin-top: 0px">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                                                        <tr>
                                                            <td width="60%" style="line-height: 22px; padding-left: 3px;" class="black-hdr">
                                                                Earnings</td>
                                                            <td width="40%" align="right" style="padding-right: 5px;">
                                                                Amount</td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <FooterTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #EAEAEA;">
                                                        <tr>
                                                            <td class="black-hdr" style="line-height: 22px; padding-left: 3px; font: bolder 11px Arial;
                                                                color: #990000;" width="60%" height="23px">
                                                                Total
                                                            </td>
                                                            <td width="40%" align="right" style="padding-right: 5px; font: bolder 11px Arial;
                                                                color: #990000;">
                                                                <asp:Label ID="totalE" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="60%" style="line-height: 22px; padding-left: 3px;" align="left">
                                                                <asp:Label ID="lblPayheadid" runat="server" Visible="false" Text='<%# bind("payheadid") %>'></asp:Label>
                                                                <asp:Label ID="lblPayhead" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                            </td>
                                                            <td width="40%" align="right" style="padding-right: 5px;">
                                                                <asp:Label ID="lblAmountE" runat="server" Text='<%# bind("amount") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:GridView>
                                </td>
                                <td width="2%" valign="top">
                                    &nbsp;</td>
                                <td width="48%" valign="top">
                                    <asp:GridView ID="grdItComputation1" runat="server" AutoGenerateColumns="False" Width="100%"
                                        ShowFooter="True" Style="margin-top: 0px" OnRowDataBound="grdItComputation1_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField>
                                                <HeaderTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #E0E0E0;">
                                                        <tr>
                                                            <td width="60%" style="line-height: 22px; padding-left: 3px;" class="black-hdr">
                                                                Deduction</td>
                                                            <td width="40%" align="right" style="padding-right: 5px;">
                                                                Amount</td>
                                                        </tr>
                                                    </table>
                                                </HeaderTemplate>
                                                <FooterTemplate>
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #EAEAEA;">
                                                        <tr>
                                                            <td class="black-hdr" style="line-height: 22px; padding-left: 3px; font: bolder 11px Arial;
                                                                color: #990000;" width="60%" height="23px">
                                                                Total
                                                            </td>
                                                            <td width="40%" align="right" style="padding-right: 5px; font: bolder 11px Arial;
                                                                color: #990000;">
                                                                <asp:Label ID="totalD" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </FooterTemplate>
                                                <ItemTemplate>
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td width="60%" style="line-height: 22px; padding-left: 3px;" align="left">
                                                                <asp:Label ID="lblPayheadid" runat="server" Visible="false" Text='<%# bind("payheadid") %>'></asp:Label>
                                                                <asp:Label ID="lblPayhead" runat="server" Text='<%# bind("payhead") %>'></asp:Label>
                                                            </td>
                                                            <td width="40%" align="right" style="padding-right: 5px;">
                                                                <asp:Label ID="lblAmountD" runat="server" Text='<%# bind("amount") %>'></asp:Label>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <HeaderStyle HorizontalAlign="Left" />
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" border="0" cellpadding="1" cellspacing="2">
                            <tr>
                                <td height="5" colspan="4" style="border-bottom: 1px #ccc solid; height: 1px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20" align="right">
                                    &nbsp;</td>
                                <td height="20" align="right">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="28%" height="20">
                                    Total Earnings :
                                </td>
                                <td width="21%" height="20">
                                    <asp:Label ID="lbltotalFinalEarnings" runat="server"></asp:Label></td>
                                <td width="28%" height="20" align="right">
                                    Total Deduction :
                                </td>
                                <td width="23%" height="20" align="right">
                                    <asp:Label ID="lbltotalFinalDeduction" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td height="1" colspan="4" style="border-bottom: 1px #ccc solid; height: 1px;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    Final Dues (Total Earning - Total Deduction ) :
                                </td>
                                <td height="20">
                                    <asp:Label ID="lblFinalDues" runat="server"></asp:Label></td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="1" colspan="4" style="border-bottom: 1px solid #ccc;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    Payable in Full and Final Settlement :
                                </td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="1" colspan="4" style="border-bottom: 1px #ccc solid;">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20" colspan="2">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20" colspan="2">
                                    Received a Sum of Rs.
                                    <asp:Label ID="lblFinalTMsg" ForeColor="#990000" runat="server"></asp:Label>
                                    Towards Full and Final settlement of my Dues.
                                </td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20" colspan="4">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    Employee Signature
                                </td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20" style="border-bottom: 1px #ccc solid;">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20">
                                    Note :-
                                </td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                                <td height="20">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td height="20" colspan="4" align="center">
                                    <span style="font-weight: normal;">This is a system generated report &amp; does not
                                        require any signature.</span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
