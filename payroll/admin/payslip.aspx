<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payslip.aspx.cs" Inherits="payroll_admin_payroll" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payslip</title>
    <style type="text/css">
        body {
            margin: 0;
            padding: 0;
            font: 11px Arial, Helvetica, sans-serif;
            color: #333;
        }

        .bm-lne {
            border-bottom: 1px solid #e7f1ff;
            padding: 5px 0 5px 0px;
            font: normal 11px Arial, Helvetica, sans-serif;
            color: #013366;
        }

        .txt-un {
            font: bold 14px Arial, Helvetica, sans-serif;
            color: #08486d;
            padding: 6px 0;
        }

        .blue-bg1 {
            background: #1a638d;
            color: #fff;
            padding: 0 3px;
            font: normal 11px Tahoma, Helvetica, sans-serif;
        }

        .blue-bg {
            background: #08486d;
            color: #fff;
            padding: 0 10px;
            font: normal 11px Tahoma, Helvetica, sans-serif;
        }

        .txt-red {
            font: bold 11px verdana, Helvetica, sans-serif;
            color: #990000;
        }

        .bdr {
            border: 1px solid #08486d;
        }

        .line-right {
            border-left: 1px solid #08486d;
            border-bottom: 1px solid #08486d;
        }

        .line-left {
            border-bottom: 1px solid #08486d;
        }

        .line-left1 {
            border-left: 0px;
        }

        .line-right1 {
            border-right: 0px;
        }
    </style>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<%--<body>
    <form runat="server" id="form1">
        <table width="80%" border="0" align="center" cellpadding="3" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                         <tr>
                            <td colspan="3" style="height: 21px">
                                <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="hide(); window.print()" class="btn btn-info  pull-right" style="position:absolute;right:150px;top:10px"/>
                        </tr>
                        <tr>
                            <td width="87%" height="22" align="center">
                                <strong>
                                    <span style="padding-left: 120px"><b style="font-size: 20px">ESCALON BUSINESS SERVICES PVT. LTD.</b></span>
                                </strong>
                            </td>
                            <td width="7%" align="right">
                            </td>
                        </tr>

                        <tr>
                            <td height="22" colspan="3" valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" valign="top">
                                            <span>
                                                <img src="../../upload/logo/client_logos1.png" style="float:left" /></span>
                                            <br />
                                            <span style="padding-right: 80px"><b style="font-size: 12px">A-40 2ND Floor,S.P Infocity, Indstrial Area Phase 8,Mohali (Punjab)</b></span>
                                            <br />
                                            <br />
                                            <br />
                                            <span style="padding-right: 60px"><b style="font-size: 15px">Payslip for the month of 
                                            <asp:Label ID="lbl_month" runat="server" Text=""></asp:Label>
                                                -
                                            <asp:Label ID="lbl_year" runat="server" Text=""></asp:Label>
                                            </b></span>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td height="22" align="right" valign="middle">
                                            <span class="txt-red">&nbsp;</span></td>
                                    </tr>
                                    <tr style="border-bottom-color: black; border-style: dotted">
                                        <td valign="top">
                                            <table width="100%" border="0" style="outline-style: auto" cellspacing="0" cellpadding="3">
                                                <tr>
                                                    <td width="25%" border="0">Name
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lbl_empname" runat="server" Text=""></asp:Label>&nbsp;[<asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>&nbsp;]
                                                    </td>
                                                    <td width="25%" border="2">Bank Name
                                                    </td>
                                                    <td width="25%" border="0">
                                                        <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" border="0">Date of Joining
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td width="25%" border="2">Bank A/C No
                                                    </td>
                                                    <td width="25%" border="0">
                                                        <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td width="25%" border="0">Designation
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td width="25%" border="2">PF No
                                                    </td>
                                                    <td width="25%" border="0">
                                                        <asp:Label ID="lbl_pf_acnumber" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" border="0">Department
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lbl_dept" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td width="25%" border="2">PF UAN
                                                    </td>
                                                    <td width="25%" border="0">
                                                        <asp:Label ID="lbl_uan" runat="server" Text=""></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" border="0">Location
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td width="25%" border="2">ESI No
                                                    </td>
                                                    <td width="25%" border="0">
                                                        <asp:Label ID="lbl_esi_number" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" border="0">Effective Work Days
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lbl_effworkdays" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td width="25%" border="2">PAN No
                                                     <td width="25%" border="0">
                                                         <asp:Label ID="lbl_emp_IT_pan" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" border="0">Days In Month
                                                    </td>
                                                    <td style="border-right: 1px solid #000000">
                                                        <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                    <td width="25%" border="2">LOP
                                                    </td>
                                                    <td width="25%" border="0">
                                                        <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                            </td>
                        </tr>

                        <tr>
                            <td valign="top">
                                <table width="100%" style="border-style: none" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
                                    <tr>
                                        <td width="50%" valign="top" style="border: none; outline-style: auto">
                                            <asp:GridView ID="earning_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No such employee exists !">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Earnings">
                                                        <HeaderStyle Height="20px" HorizontalAlign="left" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="0"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Full">
                                                        <HeaderStyle Width="17%" HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="0"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("fullamount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <HeaderStyle Width="17%" HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="0"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <HeaderStyle CssClass="frm-lft-clr123" />
                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                <RowStyle Height="5px" />
                                            </asp:GridView>
                                        </td>
                                        <td valign="top" width="50%" style="outline-style: auto">
                                            <asp:GridView ID="deduction_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No deduction !">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Deductions">
                                                        <HeaderStyle Height="20px" HorizontalAlign="left" />
                                                        <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="0"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Amount">
                                                        <HeaderStyle Width="17%" HorizontalAlign="center" />
                                                        <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="0"
                                                            VerticalAlign="Top" />
                                                        <ItemTemplate>
                                                            <asp:Label ID="l3" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
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
                                        <td valign="top">
                                            <table width="100%" border="0" cellpadding="2" cellspacing="0"
                                                style="outline-style: auto">
                                                <tr>
                                                    <td width="81%" class="line-left">
                                                        <strong>Total Earnings : Rs.</strong></td>
                                                    <td width="17%" class="line-right" align="right">
                                                        <asp:Label ID="lbl_total_earning" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top">
                                            <table width="100%" border="0" cellpadding="2" cellspacing="0" style="outline-style: auto">
                                                <tr>
                                                    <td width="83%">
                                                        <strong>Total Deductions :</strong></td>
                                                    <td width="17%" class="line-right" align="right">
                                                        <asp:Label ID="lbl_total_deductions" runat="server" Text=""></asp:Label></td>
                                                </tr>
                                                <tr>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="reimdiv" runat="server">
                                    <table width="100%">
                                        <tr>
                                            <td valign="top">
                                                <asp:GridView ID="reimbursement_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                    CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="50%" AutoGenerateColumns="False"
                                                    BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No Reimbursement Exists !">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Reimbursement">
                                                            <HeaderStyle CssClass="blue-bg1 line-left" Height="20px" HorizontalAlign="left" />
                                                            <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="1"
                                                                VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Amount">
                                                            <HeaderStyle Width="17%" CssClass="blue-bg1 line-right" HorizontalAlign="center" />
                                                            <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="1"
                                                                VerticalAlign="Top" />
                                                            <ItemTemplate>
                                                                <asp:Label ID="l3" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
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
                                            <td>
                                                <table width="50%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse; border-color: #08486d;">
                                                    <tr class="bdr">
                                                        <td width="83%" class="line-left">
                                                            <strong>Total Reimbursement</strong></td>
                                                        <td width="17%" align="right">
                                                            <asp:Label ID="lbl_reimbursement" runat="server" Text=""></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </td>
                        </tr>
                        <tr id="trTotal" runat="server" visible="false">
                            <td>
                                <table width="50%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse; border-color: #08486d;">
                                    <tr class="bdr">
                                        <td class="line-left">
                                            <strong>Grand Total</strong></td>
                                        <td>
                                            <asp:Label ID="lbl_tot_grandtotal" runat="server" Text=""></asp:Label></td>
                                        <td class="line-left">
                                            <strong>Total Deduction</strong></td>
                                        <td>
                                            <asp:Label ID="lbl_tot_deduction" runat="server" Text=""></asp:Label></td>
                                        <td class="line-left">
                                            <strong>Total Reimbursement</strong></td>
                                        <td>
                                            <asp:Label ID="lbl_tot_reimbursement" runat="server" Text=""></asp:Label></td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>

                </td>
            </tr>
        </table>

        <table style="border-style: none" width="100%" border="1" align="center" cellpadding="3" cellspacing="0">
            <tr>
                <td>
                    <b>Net Pay for the month ( Total Earnings - Total Deductions):</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
            
            </tr>
            <tr>
                 <td align="center">
                    <b>This is a system generated payslip and does not require signature.</b>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <tr>
            <td align="center">
                <a href="javascript: window.close ()">
                    <button class="blue1" id="b1" onclick='window.close()'>
                        Close Window</button></a>

            </td>
        </tr>
        <tr>
            <td style="height: 20px">&nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"></CR:CrystalReportViewer>
            </td>
        </tr>

    </form>
     <script type="text/javascript">
         function hide() {
             var x = document.getElementById('printButton');
             x.style.display = 'none';
             var y = document.getElementById('b1');
             y.style.display = 'none';
         }

    </script>
</body>--%>
<body>
    <form runat="server" id="form1">
        <table cellpadding="3" cellspacing="0" style="width: 80%; margin-left: 70px; border: 1px solid #808080; margin-top: 20px; border-bottom: none; box-shadow: 0px 0px 0px 0px">
            <tr>
                <td style="width: 30%"></td>
                <td style="width: 70%">
                    <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="hide(); window.print()" class="btn btn-info  pull-right" Style="float: right" />
                </td>
            </tr>
            <tr>
                <td style="width: 30%">
                    <img src="../../upload/logo/client_logos1.png" alt="" style="width:140px" />
                </td>
                <td style="width: 70%;">
                    <table cellpadding="1" cellspacing="0" style="width: 100%; border: none; font-weight: 600;">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                                    <tr>
                                        <td style="font-size: 18px; font-family: 'Times New Roman';"> ESCALON BUSINESS SERVICES PVT. LTD.
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 84.5%; font-family: 'Times New Roman';">Plot No A 40 A, 2nd Floor, SVEPL Building, Co-Developer Quarkcity SEZ, 
                                                                                                     Industrial Area, Phase 8-B, SAS Nagar Mohali Punjab – 160059.
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr><td style="height: 10px"></td></tr>
                        <tr>
                            <td style="font-size: 13px; font-family: 'Times New Roman';">
                                <table cellpadding="0" cellspacing="0" style="width: 100%;padding-left:60px">
                                    <tr>
                                        <td>Payslip for the month of&nbsp;<asp:Label ID="lbl_month" runat="server"></asp:Label>&nbsp;-&nbsp;<asp:Label ID="lbl_year" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>

        </table>
        <table cellpadding="0" cellspacing="0" style="width: 80%; margin-left: 70px; font-family: 'Times New Roman'; border: none">
            <tr>
                <td style="border: 1px solid #808080; width: 50%">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; font-size: 13px;">
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Name :
                                        </td>
                                        <td style="width: 70%; text-align: justify;">
                                            <asp:Label ID="lbl_empname" runat="server" Text=""></asp:Label>&nbsp;[<asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>]
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Date of Joining :
                                        </td>
                                        <td style="width: 70%; text-align: justify;">
                                            <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Designation
                                        </td>
                                        <td style="width: 70%; text-align: justify">
                                            <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Department
                                        </td>
                                        <td style="width: 70%; text-align: justify;">
                                            <asp:Label ID="lbl_dept" runat="server" Text=""></asp:Label>&nbsp; 
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Location
                                        </td>
                                        <td style="width: 70%; text-align: justify;">
                                            <asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Effective Work Days  
                                        </td>
                                        <td style="width: 70%; text-align: justify;">
                                            <asp:Label ID="lbl_effworkdays" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                        <tr>
                            <td style="width: 50%; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Days In Month
                                        </td>
                                        <td style="width: 70%; text-align: justify;">
                                            <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>

                        </tr>
                    </table>
                </td>
                <td style="border: 1px solid #808080; width: 50%; border-left: none;">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; border: none; font-size: 13px;">
                        <tr>
                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Bank Name :
                                        </td>
                                        <td style="width: 70%">
                                            <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">Bank Account No
                                        </td>
                                        <td style="width: 70%;">
                                            <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">PF No
                                        </td>
                                        <td style="width: 70%;">
                                            <asp:Label ID="lbl_pf_acnumber" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">PF UAN
                                        </td>
                                        <td style="width: 70%;">
                                            <asp:Label ID="lbl_uan" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">ESI No
                                        </td>
                                        <td style="width: 70%;">
                                            <asp:Label ID="lbl_esi_number" runat="server" Text=""></asp:Label>&nbsp; 
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">PAN No
                                        </td>
                                        <td style="width: 70%;">
                                            <asp:Label ID="lbl_emp_IT_pan" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>

                            <td style="width: 50%; text-align: justify; padding: 3px 3px 3px 3px">
                                <table cellpadding="0" cellspacing="0" style="width: 100%; border: none">
                                    <tr>
                                        <td style="width: 30%;">LOP
                                        </td>
                                        <td style="width: 70%;">
                                            <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>&nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" style="width: 80%; margin-left: 70px; font-family: 'Times New Roman'">
            <tr>
                <td style="width: 50%; border: 1px solid #808080; border-top: none; font-weight: 500; font-size: 13px" valign="top">
                    <asp:GridView ID="earning_grid" runat="server"
                        CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False" 
                        BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No such employee exists !">
                        <Columns>
                            <asp:TemplateField HeaderText="Earnings">
                                <HeaderStyle Height="20px" HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="Left" BorderWidth="0"
                                    VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Full">
                                <HeaderStyle Width="17%" HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="Center" BorderWidth="0"
                                    VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="full_amount" runat="server" Text='<%# Bind("fullamount")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual">
                                <HeaderStyle Width="17%" HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="Center" BorderWidth="0"
                                    VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="amount" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
                <td style="width: 50%; border: 1px solid #808080; border-left: none; border-top: none; font-weight: 500; font-size: 13px;" valign="top">
                    <asp:GridView ID="deduction_grid" runat="server"
                        CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                        BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No deduction !">
                        <Columns>
                            <asp:TemplateField HeaderText="Deductions">
                                <HeaderStyle Height="20px" HorizontalAlign="left" />
                                <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderWidth="0"
                                    VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="payhead" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Actual">
                                <HeaderStyle Width="17%" HorizontalAlign="center" />
                                <ItemStyle HorizontalAlign="Center" CssClass="line-right" BorderWidth="0"
                                    VerticalAlign="Top" />
                                <ItemTemplate>
                                    <asp:Label ID="lblam" runat="server" Text='<%# Bind ("amount") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td style="width: 50%">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; border: 1px solid #808080; border-top: none; font-weight: 600; font-size: 13px">
                        <tr>
                            <td style="width: 65%; padding: 4px 4px 4px 4px">Total Earnings : Rs.   
                            </td>
                            <td style="width: 35%; padding: 4px 4px 4px 4px; text-align: center">
                                <table style="width: 100%" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="width: 50%;">
                                            <asp:Label ID="lbl_total_fixed" runat="server" Style="font-weight: 100"></asp:Label>
                                        </td>
                                        <td style="width: 50%;">
                                            <asp:Label ID="lbl_total_earning" runat="server" Style="font-weight: 100"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 50%">
                    <table cellpadding="0" cellspacing="0" style="width: 100%; border: 1px solid #808080; border-top: none; font-weight: 600; font-size: 13px; border-left: none">
                        <tr>
                            <td style="width: 86%; padding: 4px 4px 4px 4px">Total Deductions :
                            </td>
                            <td style="width: 14%; padding: 4px 4px 4px 4px; font-weight: 100">
                                <b>RS.</b><asp:Label ID="lbl_total_deductions" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table id="reimdiv" runat="server" cellpadding="0" cellspacing="0" style="width: 80%; margin-left: 70px; font-family: 'Times New Roman'">
            <tr>
                <td>
                    <div>
                        <table width="100%">
                            <tr>
                                <td valign="top">
                                    <asp:GridView ID="reimbursement_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                        CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="50%" AutoGenerateColumns="False"
                                        BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No Reimbursement Exists !">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Reimbursement">
                                                <HeaderStyle CssClass="blue-bg1 line-left" Height="20px" HorizontalAlign="left" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="1"
                                                    VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <asp:Label ID="pay" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Amount">
                                                <HeaderStyle Width="17%" CssClass="blue-bg1 line-right" HorizontalAlign="center" />
                                                <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="1"
                                                    VerticalAlign="Top" />
                                                <ItemTemplate>
                                                    <asp:Label ID="amt" runat="server" Text='<%# Bind("amount")%>'></asp:Label>
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
                                <td>
                                    <table width="50%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse; border-color: #08486d;">
                                        <tr class="bdr">
                                            <td width="83%" class="line-left">
                                                <strong>Total Reimbursement</strong></td>
                                            <td width="17%" align="right">
                                                <asp:Label ID="lbl_reimbursement" runat="server" Text=""></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
            </tr>
            <tr id="trTotal" runat="server" visible="false">
                <td>
                    <table width="50%" border="1" cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color: #08486d;">
                        <tr class="bdr">
                            <td class="line-left">
                                <strong>Grand Total</strong></td>
                            <td>
                                <asp:Label ID="lbl_tot_grandtotal" runat="server" Text=""></asp:Label></td>
                            <td class="line-left">
                                <strong>Total Deduction</strong></td>
                            <td>
                                <asp:Label ID="lbl_tot_deduction" runat="server" Text=""></asp:Label></td>
                            <td class="line-left">
                                <strong>Total Reimbursement</strong></td>
                            <td>
                                <asp:Label ID="lbl_tot_reimbursement" runat="server" Text=""></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" style="width: 80%; margin-left: 70px; font-family: 'Times New Roman'; border: 1px solid #808080; border-top: none; font-weight: 500; font-size: 13px; padding: 4px 4px 4px 4px">
            <tr>
                <td style="width: 50%; padding: 4px 4px 4px 2px">Net Pay for the month ( Total Earnings - Total Deductions):<br />
                    (<asp:Label ID="lbl_word" runat="server" Text="" Style="font-style: italic; font-weight: 600; font-size: 13px"></asp:Label>)
                </td>
                <td style="width: 50%; padding: 4px 4px 4px 4px">
                    <b>
                        <asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label></b>

                </td>
            </tr>
            <tr>
                <td></td>
            </tr>
        </table>
        <table cellpadding="0" cellspacing="0" style="width: 80%; margin-left: 70px; font-family: 'Times New Roman'; font-weight: 500; font-size: 15px; padding: 4px 4px 4px 4px; text-align: center">
            <tr>
                <td>This is a system generated payslip and does not require signature.
                </td>
            </tr>
            <tr>
                <td style="height: 15px"></td>
            </tr>
            <tr>
                <td align="center">
                    <a href="javascript: window.close ()">
                        <button class="blue1" id="b1" onclick='window.close()'>
                            Close Window</button></a>

                </td>
            </tr>
            <tr>
                <td style="height: 20px">&nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true"></CR:CrystalReportViewer>
                </td>
            </tr>

        </table>
    </form>
    <script type="text/javascript">
        function hide() {
            var x = document.getElementById('printButton');
            x.style.display = 'none';
            var y = document.getElementById('b1');
            y.style.display = 'none';
        }

    </script>
</body>
</html>
