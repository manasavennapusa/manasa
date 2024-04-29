<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_provident_esi.aspx.cs"
    Inherits="payroll_admin_view_provident_esi" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>View Leave Rule</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>
    <script src="../../leave/js/popup.js"></script>
     <link href="../../css/blue1.css" rel="stylesheet" />
    <link href="../../css/main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
            <div class="dashboard-wrapper" style="margin-left: 0px;">
                    <div class="main-container">
                        <div class="row-fluid">
                            <div class="span12">
                                <div class="widget">

                                    <div class="widget-body">
                                        <fieldset>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td valign="top" class="blue-brdr-1">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                <%--    <td width="3%" style="height: 16px">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>--%>
                                   <%-- <td class="txt01" style="height: 15px">
                                        &nbsp;Provident Fund / ESI&nbsp;
                                    </td>--%>
                                    <td width="73%" align="right" class="txt-red">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" valign="middle" class="txt02">
                            <table width="100%">
                                <tr>
                                    <td align="left">
                                        &nbsp;Employee PF Contribution(EPF)
                                    </td>
                                <%--    <td align="right">
                                        <asp:Button ID="btn_edit2" runat="server" CssClass="button" OnClick="btn_edit2_Click"
                                            Text="Edit" />
                                    </td>--%>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                       Effect From Date
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_formdate" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Percentage contribution
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_per" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Maximum amount
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_emp_max" runat="server"></asp:Label>
                                    </td>
                                </tr>
                              
                                <tr>
                                    <td class="frm-lft-clr123 border-bottom" style="width: 250px">
                                        Minimum amount
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom">
                                        <asp:Label ID="lbl_emp_min" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="middle" class="txt02">
                            &nbsp;Employer PF Contribution
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Employer PF contribution
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_empr_Pf" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Employer Pension Fund contribution
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_empr_pension" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Administrative Charges PF<span class="txt06">&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                            &nbsp; &nbsp;&nbsp; (Account No. 02)</span>
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_empr_02" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Insurance Fund Contribution<br />
                                        <span class="txt06">(Account No. 21)</span>
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_empr_21" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                             
                                <tr>
                                    <td class="frm-lft-clr123 border-bottom" style="width: 250px">
                                        Administrative Charges<br />
                                        <span class="txt06">(Account No.22)</span>
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom">
                                        <asp:Label ID="lbl_empr_22" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td height="20" valign="middle" class="txt02">
                            &nbsp;Employee State Insurance
                        </td>
                    </tr>
                    <tr>
                        <td valign="top">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Employee Contribution
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_esi_emp" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Employer Contribution
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_esi_empr" runat="server"></asp:Label>%
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td class="frm-lft-clr123" style="width: 250px">
                                        Cutoff Amount
                                    </td>
                                    <td class="frm-rght-clr123">
                                        <asp:Label ID="lbl_esi_cutoff" runat="server"></asp:Label>
                                    </td>
                                </tr>
                               
                                <tr>
                                    <td class="frm-lft-clr123 border-bottom" style="width: 250px">
                                        &nbsp;
                                    </td>
                                    <td class="frm-rght-clr123 border-bottom">
                                        <asp:Button ID="btnsbmit" runat="server" Text="Edit" CssClass="button" OnClick="btnsbmit_Click"
                                            ValidationGroup="v" />&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
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
    </form>
</body>
</html>
