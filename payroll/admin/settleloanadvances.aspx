<%@ Page Language="C#" AutoEventWireup="true" CodeFile="settleloanadvances.aspx.cs"
    Inherits="payroll_admin_settleloanadvances" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <title>SDL Employee Information</title>
    <style type="text/css" media="all">
        @import "../../css/blue1.css";
        .star:before {
            content:" *";
        }
    </style>

    <script src="../../leave/js/popup.js"></script>

    <script type="text/javascript" src="../../js/jquery-1.2.2.pack.js"></script>

    <script type="text/javascript" src="../../js/ddaccordion.js"></script>

    <script type="text/javascript">
        ddaccordion.init({
            headerclass: "expandable", //Shared CSS class name of headers group that are expandable
            contentclass: "categoryitems", //Shared CSS class name of contents group
            revealtype: "click", //Reveal content when user clicks or onmouseover the header? Valid value: "click" or "mouseover
            collapseprev: false, //Collapse previous content (so only one open at any time)? true/false 
            defaultexpanded: [0, 1], //index of content(s) open by default [index1, index2, etc]. [] denotes no content
            onemustopen: true, //Specify whether at least one header should be open always (so never all headers closed)
            animatedefault: true, //Should contents open by default be animated into view?
            persiststate: false, //persist state of opened contents within browser session?
            toggleclass: ["", "openheader"], //Two CSS classes to be applied to the header when it's collapsed and expanded, respectively ["class1", "class2"]
            togglehtml: ["prefix", "", ""], //Additional HTML added to the header when it's collapsed and expanded, respectively  ["position", "html1", "html2"] (see docs)
            animatespeed: "normal", //speed of animation: "fast", "normal", or "slow"
            oninit: function (headers, expandedindices) { //custom code to run when headers have initalized
                //do nothing
            },
            onopenclose: function (header, index, state, isuseractivated) { //custom code to run whenever a header is opened or closed
                //do nothing
            }
        })
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="payroll" runat="server">
        </asp:ScriptManager>
        <%--
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>    
        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="1" runat="server">
            <ProgressTemplate>
                <div class="divajax"><table width="100%"><tr><td align="center" valign="top"><img src="../../images/loading.gif" /></td><td valign="bottom">Please Wait...</td></tr></table></div>
            </ProgressTemplate> 
        </asp:UpdateProgress>--%>
        <div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td valign="top" height="463px">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td valign="top" class="blue-brdr-1">
                                    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
                                        <tr>
                                        <%--    <td width="3%" style="height: 16px">
                                                <img src="../../images/employee-icon.jpg" width="16" height="16" />
                                            </td>--%>
                                            <td class="txt01" style="height: 16px">Loan & Advances Settlement
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td height="5" valign="top"></td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td height="20" valign="top" class="txt02">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td width="37%" class="txt02">Search Employee Loan/Advances Detail
                                                        </td>
                                                        <td width="63%" align="right" class="txt-red">
                                                            <span id="message" runat="server"></span>&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" style="height: 5px"></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td class="frm-lft-clr123 border-bottom" width="20%">Loan Reference No. <span class="star"></span>
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="60%">
                                                            <asp:TextBox ID="txt_loanref" runat="server" CssClass="blue1" Width="90px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="rfvloanref" runat="server" ControlToValidate="txt_loanref"
                                                                Display="Dynamic" ErrorMessage='<img src="../../images/error1.gif" alt="" />'
                                                                ToolTip="Enter Loan Reference ID" ValidationGroup="s"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                                                ValidationExpression="^[a-zA-Z0-9\.\\\/\-_]+$" ControlToValidate="txt_loanref" ToolTip=" enter only alphabets or numbers"
                                                                ErrorMessage='<img src="../../images/error1.gif" alt="" />' ValidationGroup="v"></asp:RegularExpressionValidator>
                                                        </td>
                                                        <td class="frm-rght-clr123 border-bottom" width="20%">
                                                            <asp:Button ID="btn_search" runat="server" CssClass="button" Text="Search" OnClick="btn_search_Click"
                                                                ValidationGroup="s" />&nbsp;
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5" valign="top"></td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                    <tr>
                                                        <td valign="top">
                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                <tr>
                                                                    <td valign="top">
                                                                        <div id="divloan" runat="server">
                                                                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td valign="middle" class="txt02" style="height: 24px" colspan="4">Applied Loan/Advances Detail
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td width="20%" class="frm-lft-clr123">Employee Code
                                                                                    </td>
                                                                                    <td width="30%" class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_empcode" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td width="17%" class="frm-lft-clr123">Employee Name
                                                                                    </td>
                                                                                    <td width="33%" class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_empname" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123">Loan Name
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_loanname" runat="server"></asp:Label>
                                                                                    </td>
                                                                                    <td class="frm-lft-clr123">Loan Amount
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123">
                                                                                        <asp:Label ID="lbl_laonamnt" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>

                                                                                <tr>
                                                                                    <td class="frm-lft-clr123 border-bottom">Sanction Date
                                                                                    </td>
                                                                                    <td class="frm-rght-clr123 border-bottom" colspan="3">
                                                                                        <asp:Label ID="lbl_sdate" runat="server"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="middle" class="txt02">
                                                <div id="divpaid" runat="server">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <div class="glossymenu1">
                                                                    <a class="menuheader1 expandable" href="#">Paid Loan/Advances Installments</a>
                                                                    <div class="categoryitems">
                                                                        <ul>
                                                                            <li>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="head-2">
                                                                                            <asp:GridView ID="paidgrid" runat="server" Font-Size="11px" Font-Names="Arial" CellPadding="4"
                                                                                                Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="There is no paid Loan/Advances"
                                                                                                AllowPaging="True" PageSize="80" CssClass="gvclass" Border="1px solid #ddd">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Month/Year">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("month_year") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Installment Amount">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("pinst_amount") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Beginning Balance">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l37" runat="server" Text='<%# Bind ("beginningbalance") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Interest Payment">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l36" runat="server" Text='<%# Bind ("interestpayment") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Principal payment">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l35" runat="server" Text='<%# Bind ("principalpayment") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Ending Balance">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l34" runat="server" Text='<%# Bind ("endingbalance") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Total Principal">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l33" runat="server" Text='<%# Bind ("totalprincipal") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Total Interest">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l32" runat="server" Text='<%# Bind ("totalinterest") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                <RowStyle Height="5px" />
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="5"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div id="divunpaid" runat="server">
                                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                        <tr>
                                                            <td>
                                                                <div class="glossymenu1">
                                                                    <a class="menuheader1 expandable" href="#">Unpaid Loan/Advances Installments</a>
                                                                    <div class="categoryitems">
                                                                        <ul>
                                                                            <li>
                                                                                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                                                                    <tr>
                                                                                        <td height="5"></td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td class="head-2">
                                                                                            <asp:GridView ID="unpaidgrid" runat="server" Font-Size="11px" Font-Names="Arial"
                                                                                                CellPadding="4" Width="100%" AutoGenerateColumns="False" BorderWidth="0px" EmptyDataText="There is no unpaid Loan/Advances"
                                                                                                AllowPaging="True" PageSize="80">
                                                                                                <Columns>
                                                                                                    <asp:TemplateField HeaderText="Month/Year">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="12%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l1" runat="server" Text='<%# Bind ("month_year") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Installment Amount">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l2" runat="server" Text='<%# Bind ("pinst_amount") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Beginning Balance">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l37" runat="server" Text='<%# Bind ("beginningbalance") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Interest Payment">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l36" runat="server" Text='<%# Bind ("interestpayment") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Principal payment">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l35" runat="server" Text='<%# Bind ("principalpayment") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Ending Balance">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l34" runat="server" Text='<%# Bind ("endingbalance") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Total Principal">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l33" runat="server" Text='<%# Bind ("totalprincipal") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                    <asp:TemplateField HeaderText="Total Interest">
                                                                                                        <HeaderStyle HorizontalAlign="Left" CssClass="frm-lft-clr123" />
                                                                                                        <ItemStyle Width="10%" HorizontalAlign="Left" VerticalAlign="Top" CssClass="frm-rght-clr1234" />
                                                                                                        <ItemTemplate>
                                                                                                            <asp:Label ID="l32" runat="server" Text='<%# Bind ("totalinterest") %>'></asp:Label>
                                                                                                        </ItemTemplate>
                                                                                                    </asp:TemplateField>
                                                                                                </Columns>
                                                                                                <FooterStyle CssClass="frm-lft-clr123" />
                                                                                                <RowStyle Height="5px" />
                                                                                            </asp:GridView>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <div id="divamnt" runat="server">
                                                    <table width="100%" cellpadding="0" cellspacing="0" border="0">
                                                        <tr>
                                                            <td class="frm-lft-clr123" width="33%">Total Unpaid Installment Amount
                                                            </td>
                                                            <td class="frm-rght-clr123" width="67%">
                                                                <asp:Label ID="lbl_tinstamnt" runat="server"></asp:Label>&nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123">Settlement Date
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_sdate" runat="server" CssClass="blue1" Width="100px"></asp:TextBox>
                                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/clndr.gif" />
                                                                <asp:RequiredFieldValidator ID="rfvsdate" runat="server" ControlToValidate="txt_sdate"
                                                                    ErrorMessage='<img src="../../images/error1.gif" alt="" />' Display="Dynamic"
                                                                    ToolTip="Select Loan Settlement Date" ValidationGroup="v"><img src="../../images/error1.gif" alt="" /></asp:RequiredFieldValidator>
                                                                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="Image1"
                                                                    TargetControlID="txt_sdate">
                                                                </cc1:CalendarExtender>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123">Settlement Detail
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:TextBox ID="txt_detail" runat="server" CssClass="blue1" Width="200px" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="5" colspan="2"></td>
                                                        </tr>
                                                        <tr>
                                                            <td class="frm-lft-clr123">Pay all Unpaid Installments
                                                            </td>
                                                            <td class="frm-rght-clr123">
                                                                <asp:Button ID="btnpaid" runat="server" CssClass="button" Text="Submit" OnClick="btnpaid_Click"
                                                                    ValidationGroup="v" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
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
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>
    </form>
</body>
</html>
