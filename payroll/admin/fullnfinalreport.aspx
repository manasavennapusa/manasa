<%@ Page Language="C#" AutoEventWireup="true" CodeFile="fullnfinalreport.aspx.cs" Inherits="payroll_admin_fullnfinalreport" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />


    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script src="../../leave/js/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="Emp_PayStructure" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
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
                                                                <td valign="top" class="blue-brdr-1" style="width: 100%">
                                                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top" style="width: 100%">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr align="center">
                                                                            <td class="txt02" style="height: 20px; background-color: #74b9ff">Statement Of Full and Final Settlement
                                                                            </td>
                                                                            <td class="txt02" align="right">
                                                                                <span id="message" runat="server"></span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <br />
                                                            <tr>
                                                                <td valign="top" style="height: 123px; width: 100%;">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">

                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Empcode & Name<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lblemployee" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">Branch<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                                                <asp:Label ID="lbl_branch" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Designation<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lbl_desg" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Total Days<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lbl_totaldays" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123" style="width: 11%">DOJ<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lbl_doj" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="frm-lft-clr123" style="width: 11%">LWP<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lbl_lwp" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">Settlement Date<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                                                <asp:Label ID="lbl_sdate" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="frm-lft-clr123" style="width: 11%">Bank Name<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123" style="width: 27%">
                                                                                <asp:Label ID="lbl_bank" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr id="Tr1" runat="server">
                                                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">Last Working Day<span class="star"></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                                                <asp:Label ID="lbl_lastwdays" runat="server"></asp:Label>
                                                                            </td>
                                                                            <td class="frm-lft-clr123 border-bottom" style="width: 11%">Account No.<span class=""></span>
                                                                            </td>
                                                                            <td class="frm-rght-clr123 border-bottom" style="width: 27%">
                                                                                <asp:Label ID="lbl_ac" runat="server"></asp:Label>
                                                                            </td>
                                                                        </tr>

                                                                    </table>
                                                                    <br />
                                                                    <br />


                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td height="5" colspan="4"></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="20" valign="top" style="width: 100%">
                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                        <tr>
                                                                            <td class="txt02" style="height: 20px; background-color: #74b9ff">Settlement detail for the month(s) of <asp:Label ID="lblmonth" runat="server"></asp:Label> </td>
                                                                            <td class="txt02" align="right">
                                                                                <span id="Span1" runat="server"></span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <br />
                                                            <br />
                                                            <table style="width: 100%; border: 1px solid #ded8d8; margin-left: 0px" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                            <br />
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
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #74b9ff;">
                                                                                                    <tr>
                                                                                                        <td width="60%" style="line-height: 22px; padding-left: 3px;" class="black-hdr">Earnings</td>
                                                                                                        <td width="40%" align="right" style="padding-right: 5px;">Amount</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </HeaderTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #74b9ff;">
                                                                                                    <tr>
                                                                                                        <td class="black-hdr" style="line-height: 22px; padding-left: 3px; font: bolder 11px Arial; color: #990000;"
                                                                                                            width="60%" height="23px">Total
                                                                                                        </td>
                                                                                                        <td width="40%" align="right" style="padding-right: 5px; font: bolder 11px Arial; color: #990000;">
                                                                                                            <asp:Label ID="totalE" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <ItemTemplate>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="60%" style="line-height: 22px; padding-left: 3px;" align="left">
                                                                                                            <asp:Label ID="lblPayheadid" runat="server" Visible="false" Text='<%# Bind("payheadid") %>'></asp:Label>
                                                                                                            <asp:Label ID="lblPayhead" runat="server" Text='<%# Bind("payhead") %>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td width="40%" align="right" style="padding-right: 5px;">
                                                                                                            <asp:Label ID="lblAmountE" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                    <HeaderStyle HorizontalAlign="Left" />
                                                                                </asp:GridView>
                                                                            </td>
                                                                            <td width="2%" valign="top">&nbsp;</td>
                                                                            <td width="48%" valign="top">
                                                                                <asp:GridView ID="grdItComputation1" runat="server" AutoGenerateColumns="False" Width="100%"
                                                                                    ShowFooter="True" Style="margin-top: 0px" OnRowDataBound="grdItComputation1_RowDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateField>
                                                                                            <HeaderTemplate>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0" style="background-color: #74b9ff;">
                                                                                                    <tr>
                                                                                                        <td width="60%" style="line-height: 22px; padding-left: 3px;" class="black-hdr">Deduction</td>
                                                                                                        <td width="40%" align="right" style="padding-right: 5px;">Amount</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </HeaderTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" style="background-color: #74b9ff;">
                                                                                                    <tr>
                                                                                                        <td class="black-hdr" style="line-height: 22px; padding-left: 3px; font: bolder 11px Arial; color: #990000;"
                                                                                                            width="60%" height="23px">Total
                                                                                                        </td>
                                                                                                        <td width="40%" align="right" style="padding-right: 5px; font: bolder 11px Arial; color: #990000;">
                                                                                                            <asp:Label ID="totalD" runat="server"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <ItemTemplate>
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="60%" style="line-height: 22px; padding-left: 3px;" align="left">
                                                                                                            <asp:Label ID="lblPayheadid" runat="server" Visible="false" Text='<%# Bind("payheadid") %>'></asp:Label>
                                                                                                            <asp:Label ID="lblPayhead" runat="server" Text='<%# Bind("payhead") %>'></asp:Label>
                                                                                                        </td>
                                                                                                        <td width="40%" align="right" style="padding-right: 5px;">
                                                                                                            <asp:Label ID="lblAmountD" runat="server" Text='<%# Bind("amount") %>'></asp:Label>
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
                                                            <br />
                                                            <br />
                                                            <table style="margin-left: 0px; width: 100%">
                                                                <tr>
                                                                    <td style="width: 20%"><b>Total Earnings:</b></td>
                                                                    <td style="width: 30%">
                                                                        <b>
                                                                            <asp:Label ID="lbltotalFinalEarnings" runat="server"></asp:Label></b></td>
                                                                    <td style="width: 20%"><b>Total Deduction:</b></td>
                                                                    <td style="width: 30%">
                                                                        <b>
                                                                            <asp:Label ID="lbltotalFinalDeduction" runat="server"></asp:Label></b></td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table style="width: 100%; border: 1px solid #ded8d8; margin-left: 0px" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table style="margin-left: 0px; width: 100%">
                                                                <tr>
                                                                    <td style="width: 20%"><b>Final Dues (Total Earning - Total Deduction ):</b></td>
                                                                    <td style="width: 30%">
                                                                        <b>
                                                                            <asp:Label ID="lblFinalDues" runat="server"></asp:Label></b></td>

                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table style="width: 100%; border: 1px solid #ded8d8; margin-left: 0px" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table style="margin-left: 0px; width: 100%">
                                                                <tr>
                                                                    <td style="width: 20%"><b>Payable in Full and Final Settlement:</b></td>
                                                                    <td style="width: 30%">
                                                                        <b>
                                                                            <asp:Label ID="lbl_calg" runat="server"></asp:Label></b></td>

                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table style="width: 100%; border: 1px solid #ded8d8; margin-left: 0px" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                            <br />
                                                            <table style="margin-left: 0px; width: 100%" runat="server" visible="false">
                                                                <tr>
                                                                    <td height="20" colspan="2"><b>Received a Sum of Rs.
                                                                       <asp:Label ID="lblFinalTMsg" ForeColor="#990000" runat="server"></asp:Label>
                                                                        Towards Full and Final settlement of my Dues.</b>
                                                                    </td>

                                                                </tr>
                                                            </table>
                                                            <%--<br />
                                                            <table style="width: 100%; border: 1px solid #ded8d8; margin-left: 0px" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td></td>
                                                                </tr>
                                                            </table>
                                                            <br />--%>
                                                            <table style="margin-left: 0px; width: 100%" runat="server" visible="false">
                                                                <tr>
                                                                    <td height="20" style="width:25%"><b>Employee Signature</b>
                                                                    </td>
                                                                    <td height="20">&nbsp;</td>
                                                                    <td height="20">&nbsp;</td>
                                                                    <td height="20">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="20" style="border-bottom: 1px #808080 solid;width:20%;">&nbsp;</td>
                                                                    <td height="20">&nbsp;</td>
                                                                    <td height="20">&nbsp;</td>
                                                                    <td height="20">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                            <br />

                                                            <br />
                                                            <table style="margin-left: 0px; width: 100%">
                                                                <tr>
                                                                    <td height="20" colspan="4" align="center">
                                                                        <span style="font-weight: normal;">This is a system generated report &amp; does not
                                                                          require any signature.</span>
                                                                    </td>
                                                                </tr>
                                                            </table>
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
            <%--  <Triggers>
                <asp:PostBackTrigger ControlID="btnprint" />
            </Triggers>--%>
        </asp:UpdatePanel>
    </form>
</body>
</html>
