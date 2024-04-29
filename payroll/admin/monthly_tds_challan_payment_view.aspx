<%@ Page Language="C#" AutoEventWireup="true" CodeFile="monthly_tds_challan_payment_view.aspx.cs" Inherits="payroll_admin_monthly_tds_challan_payment_view" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
    <script language="JavaScript" type="text/javascript" src="../../js/popup.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1"
                    runat="server">
                    <ProgressTemplate>
                        <div class="divajax" style="left: 250px; top: 150px">
                            <table width="100%">
                                <tr>
                                    <td align="center" valign="top">
                                        <img src="../../images/loading.gif" /></td>
                                </tr>
                                <tr>
                                    <td valign="bottom" align="center" class="txt01">Please Wait...</td>
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
                                            <div>
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top" style="height: 733px">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top" class="blue-brdr-1">
                                                                        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                            <tr>
                                                                                <td width="3%" style="height: 16px">
                                                                                    <img src="../../images/employee-icon.jpg" width="16" height="16" /></td>
                                                                                <td class="txt01" style="height: 16px">Monthly TDS Challan View</td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                
                                                                <tr>
                                                                    <td valign="top" style="height: 651px">
                                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                            <tr>
                                                                                <td height="20" valign="top" class="txt02">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td width="27%" class="txt02" style="height: 13px">Monthly TDS Challan</td>
                                                                                            <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                                                <span id="message" runat="server"></span>&nbsp;</td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="top">
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="21%">Challan No</td>
                                                                                            <td class="frm-rght-clr123" width="27%">&nbsp;<asp:Label ID="lblchallanno" runat="server" Text=""></asp:Label></td>
                                                                                            <td class="frm-lft-clr123" width="23%">Cost Center</td>
                                                                                            <td class="frm-rght-clr123" width="29%" colspan="2">&nbsp;<asp:Label ID="lblcostcenter" runat="server"></asp:Label>
                                                                                                &nbsp;<asp:Label ID="lblbranch" runat="server" Visible="False"></asp:Label></td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="21%">Financial Year</td>
                                                                                            <td class="frm-rght-clr123" width="27%">&nbsp;<asp:Label ID="lblfinancial_year" runat="server" Text=""></asp:Label></td>
                                                                                            <td class="frm-lft-clr123" width="23%">Month</td>
                                                                                            <td class="frm-rght-clr123" width="29%" colspan="2">&nbsp;<asp:Label ID="lblmonth" runat="server" Text=""></asp:Label></td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="21%">Bank Name</td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="27%">&nbsp;
                                                                                                <asp:Label ID="lblBankName" runat="server"></asp:Label>

                                                                                            </td>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="23%">BSR Code</td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="29%" colspan="2">&nbsp;<asp:Label ID="txt_bsr" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                       
                                                                                        <tr>
                                                                                            <td height="20" valign="top" colspan="4" class="txt02">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="27%" class="txt02" style="height: 13px">Payment Mode Details</td>
                                                                                                        <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                                                            <span id="Span1" runat="server"></span>&nbsp;</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                       
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="21%">Cheque/DD No.</td>
                                                                                            <td class="frm-rght-clr123" width="27%" colspan="4">&nbsp;
                                                                                                <asp:Label ID="txt_no" runat="server"></asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="21%">Tranfer Voucher No</td>
                                                                                            <td class="frm-rght-clr123 border-bottom" width="27%">&nbsp;<asp:Label ID="txt_vou" runat="server"></asp:Label>
                                                                                            </td>
                                                                                            <td class="frm-lft-clr123 border-bottom" width="23%">&nbsp;Tax Deposite Date</td>
                                                                                            <td class="frm-rght-clr123 border-bottom" colspan="2" width="29%">&nbsp;<asp:Label ID="txt_date" runat="server"></asp:Label>

                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="5" align="right" height="5" valign="bottom">&nbsp;&nbsp;
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                        <tr>
                                                                                            <td height="20" valign="top" colspan="4" class="txt02">
                                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tr>
                                                                                                        <td width="27%" class="txt02" style="height: 13px">Payment Details</td>
                                                                                                        <td width="73%" align="right" class="txt-red" style="height: 13px">
                                                                                                            <span id="Span2" runat="server"></span>&nbsp;</td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="21%">Tds</td>
                                                                                            <td class="frm-rght-clr123" width="27%">&nbsp;<asp:Label ID="txttdsrupees" runat="server">0.00</asp:Label></td>
                                                                                            <td class="frm-lft-clr123" width="21%">Interest</td>
                                                                                            <td class="frm-rght-clr123" width="27%">&nbsp;<asp:Label ID="txtinterest" runat="server">0.00</asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                       
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="21%">Surcharge</td>
                                                                                            <td class="frm-rght-clr123">&nbsp;<asp:Label ID="txtsurcharge" runat="server">0.00</asp:Label></td>
                                                                                            <td class="frm-lft-clr123" width="21%">Others</td>
                                                                                            <td class="frm-rght-clr123" width="27%">&nbsp;<asp:Label ID="txtothers" runat="server">0.00</asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                        
                                                                                        <tr>
                                                                                            <td class="frm-lft-clr123" width="21%">Education Cess</td>
                                                                                            <td class="frm-rght-clr123">&nbsp;<asp:Label ID="txteducationcess" runat="server">0.00</asp:Label></td>
                                                                                            <td class="frm-lft-clr123" width="21%">Addl Amount</td>
                                                                                            <td class="frm-rght-clr123" width="27%">&nbsp;<asp:Label ID="txtaddlamount" runat="server">0.00</asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                       
                                                                                        <tr>

                                                                                            <td class="frm-lft-clr123 border-bottom" width="21%">Total Amount</td>
                                                                                            <%--<td class="frm-lft-clr123 border-bottom" width="27%">&nbsp;<asp:Label ID="txttotal" runat="server">0.00</asp:Label></td>--%>
                                                                                             <td colspan="3" class="frm-rght-clr123 border-bottom " width="27%">&nbsp;<asp:Label ID="txttotal" runat="server">0.00</asp:Label>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>


                                                                        </table>
                                                                    </td>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
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
