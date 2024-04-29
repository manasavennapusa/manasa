<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view_applyloanadvances_detail.aspx.cs"
    Inherits="payroll_admin_viewapplyloanadvances_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
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
                                                            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td width="3%">
                                                                        <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                                                    </td>
                                                                    <td class="txt01">View Applied Loan/Advances Detail
                                                                    </td>
                                                                    <td align="right">
                                                                        <input type="button" id="Button1" class="button" value="Back" onclick="javascript: history.go(-1);" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="5" valign="top"></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="20" valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td width="43%" class="txt02">View Applied Loan/Advances Details
                                                                    </td>
                                                                    <td width="57%" class="txt-red">
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
                                                                    <td width="29%" class="frm-lft-clr123">Loan/Advances Reference No.
                                                                    </td>
                                                                    <td width="18%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_loanref" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td width="1%" rowspan="11">&nbsp;
                                                                    </td>
                                                                    <td width="27%" class="frm-lft-clr123">Status
                                                                    </td>
                                                                    <td width="25%" class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_status" runat="server" Font-Bold="true"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Employee Code
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_empcode" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="frm-lft-clr123">Employee Name
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_empname" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Loan/Advances Type
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_loanname" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="frm-lft-clr123">Loan/Advances A/c No.
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_loanacno" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Sanction Date
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_sdate" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="frm-lft-clr123">Recover From
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_recover_month" runat="server"></asp:Label>&nbsp;<asp:Label ID="lbl_recover_year"
                                                                            runat="server"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123">Loan/Advances Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_loanamnt" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="frm-lft-clr123">Interest Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123">
                                                                        <asp:Label ID="lbl_intamnt" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td class="frm-lft-clr123 border-bottom">No. of Installments
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_instal_no" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                    <td class="frm-lft-clr123 border-bottom">Total Installment Amount
                                                                    </td>
                                                                    <td class="frm-rght-clr123 border-bottom">
                                                                        <asp:Label ID="lbl_totalintamnt" runat="server"></asp:Label>&nbsp;
                                                                    </td>
                                                                </tr>

                                                                <tr>

                                                                    <%-- <td height="10" colspan="5">
                                    </td>
                                    <td height="8" colspan="5">
                                    </td>--%>
                                                                </tr>

                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="middle">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td>
                                                                        <br />
                                                                        Loan/Advances Installments Detail
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="5px">&nbsp;
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <div>
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:GridView ID="griddetail" runat="server"
                                                                                            AutoGenerateColumns="False" EmptyDataText="There is no paid Loan/Advances"
                                                                                            AllowPaging="True" PageSize="80"
                                                                                            CssClass="table table-hover table-striped table-bordered table-highlight-head">
                                                                                            <Columns>
                                                                                                <asp:TemplateField HeaderText="Month/Year">
                                                                                                    <%-- <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                    <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />--%>
                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l1" runat="server" Text='<%# Bind ("month_year") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Installment Amount">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l2" runat="server" Text='<%# Bind ("pinst_amount") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Beginning Balance">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l37" runat="server" Text='<%# Bind ("beginningbalance") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Interest Payment">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l36" runat="server" Text='<%# Bind ("interestpayment") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Principal payment">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l35" runat="server" Text='<%# Bind ("principalpayment") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Ending Balance">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l34" runat="server" Text='<%# Bind ("endingbalance") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Total Principal">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l33" runat="server" Text='<%# Bind ("totalprincipal") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Total Interest">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l32" runat="server" Text='<%# Bind ("totalinterest") %>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                                <asp:TemplateField HeaderText="Status">

                                                                                                    <ItemTemplate>
                                                                                                        <asp:Label ID="l4" runat="server" Text='<%# Bind("dstatus") %>' class="label label-info" Visible='<%#Eval("dstatus").ToString()=="Unpaid"?true:false%>'></asp:Label>
                                                                                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("dstatus") %>' class="label label-important" Visible='<%#Eval("dstatus").ToString()=="Hold"?true:false%>'></asp:Label>
                                                                                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("dstatus") %>' class="label label-success" Visible='<%#Eval("dstatus").ToString()=="Paid"?true:false%>'></asp:Label>
                                                                                                    </ItemTemplate>
                                                                                                </asp:TemplateField>
                                                                                            </Columns>

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
                                                        <td valign="top">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <input type="button" id="Button3" class="button" value="Back" onclick="javascript: history.go(-1);" />
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
