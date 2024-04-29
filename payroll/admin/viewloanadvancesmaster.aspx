<%@ Page Language="C#" AutoEventWireup="true" CodeFile="viewloanadvancesmaster.aspx.cs"
    Inherits="payroll_admin_viewloanmaster" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
    </style>

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
            <td valign="top" style="height: 451px">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td valign="top" class="blue-brdr-1">
                          <%--  <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="3%">
                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                    </td>
                                    <td class="txt01">
                                        Loan/Advances Master
                                    </td>
                                </tr>
                            </table>--%>
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
                                    <td width="27%" class="txt02">
                                        View Loan/Advances Details
                                    </td>
                                    <td width="73%" align="right" class="txt-red">
                                        <span id="message" runat="server"></span>&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" style="height: 123px">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Loan/Advances Name
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_name" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Alias Name
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_alias" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Name in Pay Slip
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_nameinpay" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Interest
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_interest" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="frm-lft-clr123" width="25%">
                                        Intrest (@ SBI)
                                    </td>
                                    <td class="frm-rght-clr123" width="75%">
                                        <asp:Label ID="lbl_interestSBI" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123">
                                        Loan/Advances A/c No.
                                    </td>
                                    <td width="75%" class="frm-rght-clr123">
                                        <asp:Label ID="lbl_acno" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="25%" class="frm-lft-clr123 border-bottom">
                                        Eligibility Year
                                    </td>
                                    <td width="75%" class="frm-rght-clr123 border-bottom">
                                        <asp:Label ID="lbl_eligibility_year" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="5" colspan="2">
                                    </td>
                                </tr>
                            </table>
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
