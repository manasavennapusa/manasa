<%@ Page Language="C#" AutoEventWireup="true" CodeFile="payslip-for-contract.aspx.cs" Inherits="payroll_admin_payslip_for_contract" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>Payslip</title>
    <style type="text/css">
body {
 margin:0; padding:0; font: 11px Arial, Helvetica, sans-serif; color: #333;
}
.bm-lne {
border-bottom: 1px solid #e7f1ff; padding: 5px 0 5px 0px; font: normal 11px Arial, Helvetica, sans-serif; color:#013366;
}

.txt-un {
 font: bold 14px Arial, Helvetica, sans-serif; color:#08486d; padding: 6px 0;
}
.blue-bg1 {
 background: #1a638d; color: #fff; padding: 0 3px; font: normal 11px Tahoma, Helvetica, sans-serif;
}
.blue-bg {
 background: #08486d; color: #fff; padding: 0 10px; font: normal 11px Tahoma, Helvetica, sans-serif;
}
.txt-red {
 font: bold 11px verdana, Helvetica, sans-serif; color:#990000;
}
.bdr {
 border: 1px solid #08486d;
}
.line-right {
 border-left:1px solid #08486d; border-bottom: 1px solid #08486d;
}
.line-left {
 border-bottom: 1px solid #08486d;
}
.line-left1 {border-left:0px;
}
.line-right1 {border-right:0px;
}
</style>
    <link href="/aspnet_client/System_Web/2_0_50727/CrystalReportWebFormViewer3/css/default.css"
        rel="stylesheet" type="text/css" />
</head>
<body>
    <form runat="server" id="form1">
        <table width="80%" border="0" align="center" cellpadding="3" cellspacing="0">
            <tr>
                <td valign="top">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="3" style="height: 21px;">
                                  <asp:Button ID="printButton" runat="server" Text="Print" OnClientClick="hide(); window.print()" class="btn btn-info  pull-right" style="position:absolute;right:150px;top:10px"/>
                        </tr>
                        <tr>
                           <%-- <td  style="width: 8%"><%--class="blue-bg"--%
                            </td>--%>
                            <td width="87%" height="22" align="center" ><%--class="blue-bg"--%>
                                <strong>
                                     <span style="padding-left:90px"><b style="font-size:20px">Escalon Business Services Pvt. Ltd.</b></span>
                                  <%--  <asp:Label ID="lbl_companyname" runat="server" Text=""></asp:Label>--%>
                                </strong>
                            </td>
                            <td width="7%" align="right" ><%--class="blue-bg"--%>
                            </td>
                        </tr>

                        <tr>
                            <td height="22" colspan="3" valign="top">
                                <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td align="center" valign="top" ><%--class="txt-un"--%>
                                            <span><asp:Image ID="imgMyPrfl" runat="server" ImageUrl="upload/client-logo1.png" style="float:left"/></span>
                                             <br />
                                             <span style="padding-right:185px"><b style="font-size:12px">A-40 2ND FLOOR, S.P INFOCITY,INDUSTRIAL AREA PHASE 8,MOHALI (PUNJAB).</b></span>
                                            <br />
                                            <br />
                                            <br />
                                            <span style="padding-right:230px"><b style="font-size:15px">Payslip for the month of 
                                            <asp:Label ID="lbl_month" runat="server" Text=""></asp:Label>
                                            -
                                            <asp:Label ID="lbl_year" runat="server" Text=""></asp:Label>
                                               </b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                       <%-- <td height="22" align="center" valign="middle">
                                            <span class="txt-red">Name : 
                                                <asp:Label ID="lbl_empname" runat="server" Text=""></asp:Label></span>
                                        </td>--%>
                                    </tr>
                                    <tr>
                                        <td height="22" align="right" valign="middle">
                                            <span class="txt-red">&nbsp;</span></td>
                                    </tr>
                                    <tr style="border-bottom-color:black;border-style:dotted">
                                        <td valign="top" >
                                            <table width="100%" border="0" style="outline-style:auto" cellspacing="0" cellpadding="3">
                                                <tr>
                                                   <td width="25%" border="0">
                                                      Name
                                                   </td>
                                                    <td style="border-right:1px solid #000000">
                                                        <asp:Label ID="lbl_empname" runat="server" Text=""></asp:Label>&nbsp;[<asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>&nbsp;]
                                                    </td>                                               
                                                    <td width="25%" border="2">
                                                       Bank Name
                                                    </td>
                                                    <td width="25%" border="0">
                                                         <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>&nbsp;
                                                    </td>                                               
                                                </tr>                                        
                                                <tr>
                                                     <td width="25%" border="0">
                                                       Date of Joining
                                                     </td>
                                                     <td style="border-right:1px solid #000000">
                                                        <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>                                                                                             
                                                     <td width="25%" border="2">
                                                        Bank A/C No
                                                     </td>
                                                     <td width="25%" border="0">
                                                         <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>
                                                    
                                                </tr>
                                                <tr>
                                                     <td width="25%" border="0">
                                                     Designation
                                                     </td>
                                                     <td style="border-right:1px solid #000000">
                                                       <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>                                                                                             
                                                     <td width="25%" border="2">
                                                        PF No
                                                     </td>
                                                     <td width="25%" border="0">
                                                          <asp:Label ID="lbl_pf_acnumber" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>
                                                </tr>
                                                <tr>
                                                     <td width="25%" border="0">
                                                        Department
                                                     </td>
                                                     <td style="border-right:1px solid #000000">
                                                        <asp:Label ID="lbl_dept" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>                                                                                             
                                                     <td width="25%" border="2">
                                                        PF UAN
                                                     </td>
                                                     <td width="25%" border="0">
                                                         <asp:Label ID="lbl_uan" runat="server" Text=""></asp:Label>
                                                     </td>
                                                </tr>
                                                <tr>
                                                     <td width="25%" border="0">
                                                       Location
                                                     </td>
                                                     <td style="border-right:1px solid #000000">
                                                        <asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>                                                                                             
                                                     <td width="25%" border="2">
                                                       ESI No
                                                     </td>
                                                     <td width="25%" border="0">
                                                          <asp:Label ID="lbl_esi_number" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>
                                                </tr>
                                                <tr>
                                                     <td width="25%" border="0">
                                                       Effective Work Days
                                                     </td>
                                                     <td style="border-right:1px solid #000000">
                                                        <asp:Label ID="lbl_effworkdays" runat="server" Text=""></asp:Label>
                                                     </td>                                                                                             
                                                     <td width="25%" border="2">
                                                      PAN No
                                                     <td width="25%" border="0">
                                                         <asp:Label ID="lbl_emp_IT_pan" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>
                                                </tr>
                                                <tr>
                                                     <td width="25%" border="0">
                                                       Days In Month
                                                     </td>
                                                     <td style="border-right:1px solid #000000">
                                                         <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>                                                                                             
                                                     <td width="25%" border="2">
                                                       LOP
                                                     </td>
                                                     <td width="25%" border="0">
                                                         <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>&nbsp;
                                                     </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                 

                                     <%--<tr style="border-bottom-color:black;border-style:dotted">
                                        <td valign="top" >
                                            <table width="100%" border="0" style="outline-style:auto" cellspacing="0" cellpadding="3">
                                                      <tr>
                                                          <td width="25%" border="0"><strong>Name</strong>
                                                          </td>
                                                      </tr>                                                   
                                            </table>
                                        </td>
                                           <td valign="top">
                                            <table width="100%" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
                                                <tr>
                                                    
                                                </tr>
                                            </table>
                                        </td>
                                     </tr>--%>



                                 <%--<table width="100%" border="0" cellspacing="0" cellpadding="3">
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Employee Code</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_empcode" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Designation</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_desg" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Date of Joining</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbldoj" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Grade</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblgrade" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Department</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_dept" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Branch</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_branch" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>Payment Mode</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblpaymentmode" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td class="bm-lne" width="16%">
                                                        <strong>Bank Name</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lbl_bank_details" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                    <td width="16%" class="bm-lne">
                                                        <strong>A/C No</strong></td>
                                                    <td class="bm-lne">
                                                        <asp:Label ID="lblacno" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                </tr>
                                                <%--<tr>

<td class="bm-lne" width="16%"><strong>ESI Number</strong></td>
<td class="bm-lne">
    <asp:Label ID="lbl_esi_number" runat="server" Text=""></asp:Label>&nbsp;</td>
    <td width="16%" class="bm-lne"><strong>PF Account Number</strong></td>
<td class="bm-lne">
    <asp:Label ID="lbl_pf_acnumber" runat="server" Text=""></asp:Label>&nbsp;</td>>
<td class="bm-lne" width="16%"><strong>Employee I.T. PAN</strong></td>
<td class="bm-lne">
    <asp:Label ID="lbl_emp_IT_pan" runat="server" Text=""></asp:Label>&nbsp;</td>
</tr>--%
                                                <tr>
                                                    <td class="bm-lne">
                                                        &nbsp;</td>
                                                    <td class="bm-lne">
                                                        &nbsp;</td>
                                                    <td class="bm-lne">
                                                        &nbsp;</td>
                                                    <td class="bm-lne">
                                                        &nbsp;</td>
                                                    <td class="bm-lne" colspan="2">
                                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                            <tr>
                                                                <td width="16%">
                                                                    LWP</td>
                                                                <td>
                                                                    <asp:Label ID="lbllwp" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                                <td width="22%">
                                                                    Total Days</td>
                                                                <td>
                                                                    <asp:Label ID="lblworkingdays" runat="server" Text=""></asp:Label>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>--%>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td valign="top">BorderColor="White" BorderWidth="0"
                                            &nbsp;</td>
                                    </tr>--%>
                        <tr>
                                        <td valign="top">
                                            <table width="100%" style="border-style:none" border="0" cellspacing="0" cellpadding="0" style="border-collapse: collapse;">
                                                <tr>
                                                    <td width="50%" valign="top" style="border:none;  outline-style:auto"><%--class="bdr"--%>
                                                        <asp:GridView ID="earning_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No such employee exists !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Earnings">
                                                                    <HeaderStyle  Height="20px" HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="0" 
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind ("payhead") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Full" >
                                                                    <HeaderStyle Width="17%"  HorizontalAlign="center"  />
                                                                    <ItemStyle HorizontalAlign="Right" CssClass="line-right" BorderColor="#08486d" BorderWidth="0"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='<%# Bind("fullamount")%>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle Width="17%"  HorizontalAlign="center" />
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
                                                    <td valign="top" width="50%" style="outline-style:auto"> <%--class="bdr"--%>
                                                        <asp:GridView Visible="false" ID="deduction_grid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                            CellSpacing="0" CellPadding="4" DataKeyNames="id" Width="100%" AutoGenerateColumns="False"
                                                            BorderWidth="0px" AllowPaging="False" PageSize="5" EmptyDataText="No deduction !">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Deductions">
                                                                    <HeaderStyle  Height="20px" HorizontalAlign="left" />
                                                                    <ItemStyle HorizontalAlign="Left" CssClass="line-left" BorderColor="#08486d" BorderWidth="0"
                                                                        VerticalAlign="Top" />
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="l3" runat="server" Text='Professional fee'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Amount">
                                                                    <HeaderStyle  Width="17%" HorizontalAlign="center" />
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
                                                        <table>
                                                            <tr style="border-bottom:1px solid">
                                                                <th align="left" style="border-right:1px solid;width:438px;">Deductions</th>
                                                                <th align="right" style="width:84px;">Amount</th>
                                                            </tr>
                                                            
                                                          <tr style="height:9px">

                                                               <td style="border-right:1px solid;width:483px">
                                                                   
                                                                </td>
                                                                <td align="right" style="width:84px">
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr >

                                                                <td style="border-top:1px solid;width:438px">
                                                                    Professional fee 
                                                                </td>
                                                                <td align="right" style="border-top:1px solid;width:84px">
                                                                    <asp:Label ID="lblProfFee" runat="server"></asp:Label>
                                                                   <%-- <label id="lblProfFee" runat="server">500</label>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" ><%--class="bdr"--%>
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" 
                                                            style="outline-style:auto"><%--style="border-collapse: collapse;  bordercolor=#08486d; border-left: none;   border-right: none;--%>
                                                            <tr>
                                                                <td width="81%" class="line-left">
                                                                    <strong>Total Earnings : Rs</strong></td>
                                                                <td width="17%" class="line-right" align="right">
                                                                    <asp:Label ID="lbl_total_earning" runat="server" Text=""></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                               <%-- <td>
                                                                    &nbsp;</td>
                                                                <td>
                                                                    &nbsp;</td>--%>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" >
                                                        <table width="100%" border="0" cellpadding="2" cellspacing="0" style="outline-style:auto">
                                                            <tr><%--style="border-collapse: collapse; border-color: #08486d;--%>
                                                                <td width="83%" ><%--class="line-left"--%>
                                                                    <strong>Total Deductions :</strong></td>
                                                                <td width="17%" class="line-right" align="right">
                                                                    <asp:Label ID="lbl_total_deductions" runat="server" Text=""></asp:Label></td>
                                                            </tr>
                                                            <tr>
                                                                <%--<td class="line-left">
                                                                   <%-- <strong>Net Amount</strong>--%
                                                                  </td>
                                                                <td class="line-right" align="right">
                                                                    <%--<asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label>--%
                                                                      </td>--%>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                       <%-- <td valign="top">
                                            &nbsp;</td>
                                    </tr>--%>
                        <tr>
                                        <td>
                                            <div id="reimdiv" runat="server">
                                                <table width="100%" >
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
                                                            <table width="50%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse;
                                                                border-color: #08486d;">
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
                                    <%-- Hide Grand Total as per client call by ANUJ OJHA on 9-July-14 --%>
                        <tr id="trTotal" runat="server" visible="false"> 
                                        <td>
                                            <table width="50%" border="1" cellpadding="3" cellspacing="0" style="border-collapse: collapse;
                                                border-color: #08486d;">
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
               
          <%--  <tr>
                <td class="bm-lne">
                    &nbsp;</td>
            </tr>--%>
        <table style="border-style:none" width="100%" border="1" align="center" cellpadding="3" cellspacing="0">
            <tr>
                <td>
                    <b>Net Pay for the month ( Total Earnings - Total Deductions):</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lbl_amount" runat="server" Text=""></asp:Label>                   
                </td>           
            </tr>
            <tr>
                <td>
                    <b>Net Salary in words:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblwords" runat="server"></asp:Label>
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
                <td style="height: 20px">
                    &nbsp;<CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true">
                    </CR:CrystalReportViewer>
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
</body>
</html>
